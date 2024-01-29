
using UnityEngine;
using UnityEngine.UI;

public class ColorPreview : MonoBehaviour
{
    public Graphic previewGraphic;
    public ColorPicker colorPicker;
    public CustomCarColor carColor;

    private void Start()
    {
        previewGraphic.color = colorPicker.color;
        colorPicker.onColorChanged += OnColorChanged;
    }

    public void OnColorChanged(Color c)
    { 
        previewGraphic.color = c;
        carColor._CarMaterial.SetColor(carColor.IsFristColor ? "_Color1" : "_Color2", c);
    }

    private void OnDestroy()
    {
        if (colorPicker != null)
            colorPicker.onColorChanged -= OnColorChanged;
    }
}