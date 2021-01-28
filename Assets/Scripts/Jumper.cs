using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Jumper : MonoBehaviour
{

    public XRNode inputSource;
    public Transform theCube;

    [SerializeField] private TeleportationProvider _teleportationProvider;
    [SerializeField] private bool isTrigger;

    void Start()
    {
        _teleportationProvider = GetComponent<TeleportationProvider>();

    }

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.triggerButton, out isTrigger);

        if (isTrigger)
        {
            Jump();
        }
    }
    private void Jump()
    {
        var teleportRequest = new TeleportRequest();
        teleportRequest.destinationPosition = theCube.position;
        _teleportationProvider.QueueTeleportRequest(teleportRequest);
    }
}


