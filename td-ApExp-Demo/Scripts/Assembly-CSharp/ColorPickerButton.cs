using TS.ColorPicker;
using UnityEngine;
using UnityEngine.UI;

public class ColorPickerButton : MonoBehaviour
{
	[SerializeField]
	private Color color;

	[SerializeField]
	private Image colorImage;

	private ColorPickerPredefined colorPickerPredefined;

	public Color Color => color;

	private void Start()
	{
		colorPickerPredefined = base.transform.parent.parent.GetComponent<ColorPickerPredefined>();
		colorImage.color = color;
	}

	public void OnClick()
	{
		if (colorPickerPredefined != null)
		{
			colorPickerPredefined.SetCurrentColor(color);
		}
	}

	public void SetColor(Color newColor)
	{
		color = newColor;
		if (colorImage != null)
		{
			colorImage.color = color;
		}
	}
}
