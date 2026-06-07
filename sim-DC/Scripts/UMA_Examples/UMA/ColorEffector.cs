using UnityEngine;

namespace UMA
{
	public class ColorEffector : MonoBehaviour
	{
		public IColorSelector colorEffector;

		public string colorName;

		public OverlayColorData color;

		public void Setup(IColorSelector colorSelector, string colorName, OverlayColorData color)
		{
		}

		public void OnClick()
		{
		}

		public void ColorChanged(OverlayColorData value)
		{
		}
	}
}
