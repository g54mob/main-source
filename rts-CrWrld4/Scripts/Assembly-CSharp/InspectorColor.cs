using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions.ColorPicker;

public class InspectorColor : MonoBehaviour
{
	public Text propertyNameText;

	public Image colorImage;

	private ColorPickerControl picker;

	public Color propertyValue
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	public string propertyName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void OnChooseClicked()
	{
	}

	private void ColorChanged(Color c)
	{
	}
}
