using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour
{
    [SerializeField] bool _disablePhysics;
    [SerializeField] Toggle _lowPowerModeToggle;
    [SerializeField] RectTransform _renderIndicator;
    [SerializeField] bool _enableVSync;

    void Start()
    {
        Physics.autoSimulation = !_disablePhysics;
        _lowPowerModeToggle.SetIsOnWithoutNotify(true);
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            QualitySettings.vSyncCount = _enableVSync ? 1 : 0;
            Application.targetFrameRate = 0;
            OnDemandRendering.renderFrameInterval = 0;
        }
        else if (_lowPowerModeToggle.isOn)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 30;
            OnDemandRendering.renderFrameInterval = 60;
        }

        if (OnDemandRendering.willCurrentFrameRender)
        {
            _renderIndicator.Rotate(Vector3.forward, 180 * Time.deltaTime);
        }
    }
}