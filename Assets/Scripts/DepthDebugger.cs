
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DepthDebugger : MonoBehaviour
{
    private AROcclusionManager occlusionManager;
    private float timer;

    void Start()
    {
        occlusionManager = GetComponent<AROcclusionManager>();

        if (occlusionManager == null)
        {
            Debug.LogError("AR Occlusion Manager bulunamadi!");
            return;
        }

        occlusionManager.requestedEnvironmentDepthMode =
            EnvironmentDepthMode.Fastest;

        Debug.Log("Depth Debugger baslatildi.");
    }

    void Update()
    {
        if (occlusionManager == null)
            return;

        timer += Time.deltaTime;

        if (timer < 2f)
            return;

        timer = 0f;

        var descriptor = occlusionManager.descriptor;

        if (descriptor == null)
        {
            Debug.LogWarning("Occlusion Descriptor bulunamadi!");
            return;
        }

        Debug.Log("Depth destek: " +
            descriptor.environmentDepthImageSupported);

        Debug.Log("Aktif Depth Mode: " +
            occlusionManager.currentEnvironmentDepthMode);

        bool available =
            occlusionManager.TryGetEnvironmentDepthTexture(
                out Texture depth
            );

        Debug.Log("Depth Texture: " + available);

        if (available && depth != null)
        {
            Debug.Log("Texture boyutu: " +
                depth.width + "x" + depth.height);
        }
    }
}
