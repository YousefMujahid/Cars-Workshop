using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomCarColor : MonoBehaviour
{
    #region field
    [SerializeField] GameObject _LeftHand;
    [SerializeField] Slider _MetallicSlider;
    [SerializeField] Slider _SmoothnesSlider;
    [SerializeField] GameObject _CarMenu;
    [SerializeField] SocketManger _SocketManger;
    [SerializeField] int _Angle;
    public Material _CarMaterial;
    public bool IsFristColor { get; set; }
    #endregion
    #region unity method
    void Start()
    {
        _MetallicSlider.maxValue = 1;
        _SmoothnesSlider.maxValue = 1;
        _MetallicSlider.value = _CarMaterial.GetFloat("_Metallic");
        _SmoothnesSlider.value = _CarMaterial.GetFloat("_Smoothnes");
        _SmoothnesSlider.onValueChanged.AddListener(delegate { SmoothnesAdjust(); });
        _MetallicSlider.onValueChanged.AddListener(delegate { MetallicAdjust(); });
    }
    private void Update()
    {
        ShowMenu();
    }
    #endregion
    #region public method
    public void MetallicAdjust()
    {
        _CarMaterial.SetFloat("_Metallic", _MetallicSlider.value);
    }
    public void SmoothnesAdjust()
    {
        _CarMaterial.SetFloat("_Smoothness", _SmoothnesSlider.value);
    }
    #endregion
    #region private method
    private bool IsWithinAngleRange(float angle, float min, float max)
    {
        angle = (angle + 360) % 360;
        min = (min + 360) % 360;
        max = (max + 360) % 360;
        return min < max ? angle >= min && angle <= max : angle >= min || angle <= max;
    }
    private void ShowMenu()
    {
        _CarMenu.SetActive(IsWithinAngleRange(_LeftHand.transform.eulerAngles.z, -_Angle-60, _Angle-60)&& _SocketManger.IsAllPartAssembled);
    }
    #endregion
}
