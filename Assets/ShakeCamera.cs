using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class ShakeCamera : MonoBehaviour
{
    //Reference camera
    [SerializeField] CinemachineVirtualCamera vcam;

    //Initialize variables
    [SerializeField] float shakeStrength = 2f;
    [SerializeField] float shakeDuration = 0.2f;

    //Reference the events
    public UnityEvent OnShakeStart = new UnityEvent();
    public UnityEvent OnShakeStop = new UnityEvent();

    //Start Shake function
    public void StartShake()
    {
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = shakeStrength;

        Invoke(nameof(StopShake), shakeDuration);
    }

    //End Shake function
    public void StopShake()
    {
        shakeStrength = 0;
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = shakeStrength;
    }
}
