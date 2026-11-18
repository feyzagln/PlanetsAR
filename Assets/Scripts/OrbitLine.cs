using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitLine : MonoBehaviour
{
    public PlanetOrbit planet;
    public int segments = 100;
    public float lineWidth = 0.005f;

    private void Start()
    {
        var lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = false;   // SolarSystemRoot ile birlikte hareket eder
        lr.loop = true;
        lr.widthMultiplier = lineWidth;
        lr.positionCount = segments;

        for (int i = 0; i < segments; i++)
        {
            float a = i / (float)segments * Mathf.PI * 2f;
            lr.SetPosition(i, new Vector3(Mathf.Cos(a), 0f, Mathf.Sin(a)) * planet.orbitRadius);
        }
    }
}