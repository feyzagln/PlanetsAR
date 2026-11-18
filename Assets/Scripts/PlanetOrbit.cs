using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    public Transform sun;                 // Güneş objesi
    public float orbitRadius = 1f;        // Yörünge yarıçapı (root'un yerel birimi)
    public float orbitSpeed = 20f;        // Derece/saniye
    public bool randomStartAngle = true;  // Gezegenler aynı hizada başlamasın
    public float startAngle = 0f;

    private float angle;

    private void Start()
    {
        angle = randomStartAngle ? Random.Range(0f, 360f) : startAngle;
        UpdatePosition();
    }

    private void Update()
    {
        angle += orbitSpeed * Time.deltaTime;
        if (angle > 360f) angle -= 360f;
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        float rad = angle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(rad), 0f, Mathf.Sin(rad)) * orbitRadius;

        transform.localPosition = sun.localPosition + offset;
    }
}
