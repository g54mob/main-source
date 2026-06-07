using UnityEngine;
using UnityEngine.UI;

public class ColourWidgetSwatch : MonoBehaviour
{
	[SerializeField]
	private Image _colourImage;

	public int SwatchSlot;

	public Color SwatchColor
	{
		get
		{
			return _colourImage.color;
		}
		set
		{
			_colourImage.color = new Color(value.r, value.g, value.b, 1f);
		}
	}
}
