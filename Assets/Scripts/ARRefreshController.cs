using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARRefreshController : MonoBehaviour
{
    public ARSession arSession;       // Sahnedeki AR Session objesi
    public Transform arCamera;        // Main Camera (XR Origin > Camera Offset > Main Camera)
    public Transform planetRoot;      // Gezegenlerin ortak parent objesi
    public float distance = 2f;       // Kameradan uzaklık (metre)

    public void RefreshAR()
    {
        StopAllCoroutines();
        StartCoroutine(RefreshRoutine());
    }

    private IEnumerator RefreshRoutine()
    {
        // 1) ARCore oturumunu sıfırla (dünya koordinatı ve takip baştan başlar)
        arSession.Reset();

        // 2) Takip tekrar başlayana kadar bekle
        yield return null;
        yield return new WaitUntil(() =>
            ARSession.state == ARSessionState.SessionTracking);

        // 3) Gezegeni kameranın baktığı yönün önüne yerleştir
        Vector3 forward = arCamera.forward;
        forward.y = 0f;               // yatay düzlemde tut
        forward.Normalize();

        planetRoot.position = arCamera.position + forward * distance;
    }
}