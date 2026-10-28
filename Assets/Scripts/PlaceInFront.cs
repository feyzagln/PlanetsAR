using UnityEngine;

public class PlaceInFront : MonoBehaviour
{
    public float distance = 4.0f; // Kameradan kaç metre uzakta belireceğini belirler

    void Start()
    {
        // Ana kameranın (telefonunuzun) o anki konumunu ve yönünü alır
        Transform cam = Camera.main.transform;
        
        // Gezegeni, kameranın baktığı yönün (forward) 4 metre ilerisine yerleştirir
        transform.position = cam.position + cam.forward * distance;
    }
}