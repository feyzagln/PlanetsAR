using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARRefreshController : MonoBehaviour
{
    public ARSession arSession;
    public Transform arCamera;
    public Transform planetRoot;
    public float distance = 2f;       // Kameradan uzaklık
    public float heightOffset = 0f;   // + yukarı, - aşağı (metre)

    private void Start()
    {
        StartCoroutine(PlaceRoutine());
    }

    public void RefreshAR()
    {
        StopAllCoroutines();
        StartCoroutine(RefreshRoutine());
    }

    private IEnumerator RefreshRoutine()
    {
        arSession.Reset();
        yield return null;
        yield return PlaceRoutine();
    }

    private IEnumerator PlaceRoutine()
    {
        // Takip başlayana kadar bekle
        yield return new WaitUntil(() =>
            ARSession.state == ARSessionState.SessionTracking);
        yield return new WaitForSeconds(0.3f); // kamera pozu otursun

        Vector3 forward = arCamera.forward;
        forward.y = 0f;
        if (forward.sqrMagnitude < 0.001f) forward = arCamera.up; // telefon yere bakıyorsa
        forward.Normalize();

        Vector3 pos = arCamera.position + forward * distance;
        pos.y = arCamera.position.y + heightOffset;   // göz hizası

        planetRoot.position = pos;
    }
}