using UnityEngine;
using UnityEngine.UI;

namespace HSVPicker
{
	[RequireComponent(typeof(RawImage))]
	[ExecuteInEditMode]
	public class ColorSliderImage : MonoBehaviour
	{
		public ColorPicker picker;

		public ColorValues type;

		public Slider.Direction direction;

		private RawImage image;

		private RectTransform rectTransform => null;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void ColorChanged(Color newColor)
		{
		}

		private void HSVChanged(float hue, float saturation, float value)
		{
		}

		private void RegenerateTexture()
		{
		}
	}
}
