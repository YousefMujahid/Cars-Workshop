
using UnityEngine;
using UnityEngine.UI;

public class ColorPreview : MonoBehaviour
{
    public Graphic previewGraphic;
    public ColorPicker colorPicker;
    public GameObject tip;

    private void Start()
    {
        previewGraphic.color = colorPicker.color;
        colorPicker.onColorChanged += OnColorChanged;
    }

    public void OnColorChanged(Color c)
    { 
        previewGraphic.color = c;
        tip.gameObject.GetComponent<Renderer>().material.color = c;
    }

    private void OnDestroy()
    {
        if (colorPicker != null)
            colorPicker.onColorChanged -= OnColorChanged;
    }
}