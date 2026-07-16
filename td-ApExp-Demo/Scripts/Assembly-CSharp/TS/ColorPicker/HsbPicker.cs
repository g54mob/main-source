using UnityEngine;
using UnityEngine.UI;

namespace TS.ColorPicker
{
	public class HsbPicker : MonoBehaviour
	{
		public delegate void OnValueChanged(HsbPicker sender, float hue, float saturation, float brightness);

		[Header("References")]
		[SerializeField]
		private ColorSlider _colorSlider;

		[Header("Inner")]
		[SerializeField]
		private Image _imageColor;

		public OnValueChanged ValueChanged;

		private RectPicker _picker;

		public float Hue => _colorSlider.Value;

		public float Saturation => _picker.NormalizedValue.x;

		public float Brightness => _picker.NormalizedValue.y;

		private void Awake()
		{
			_picker = GetComponent<RectPicker>();
		}

		private void Start()
		{
			_colorSlider.ValueChanged = Slider_ValueChanged;
			_picker.ValueChanged = RectPicker_ValueChanged;
		}

		public void SetColor(Color color)
		{
			Color.RGBToHSV(color, out var H, out var S, out var V);
			_colorSlider.Value = H;
			UpdateImageColor(H);
			_picker.NormalizedValue = new Vector2(S, V);
		}

		private void Slider_ValueChanged(ColorSlider sender, float value)
		{
			UpdateImageColor(value);
			InvokeValueChanged();
		}

		private void RectPicker_ValueChanged(RectPicker sender, Vector2 position)
		{
			InvokeValueChanged();
		}

		private void UpdateImageColor(float hue)
		{
			_imageColor.color = Color.HSVToRGB(hue, 1f, 1f);
		}

		private void InvokeValueChanged()
		{
			ValueChanged?.Invoke(this, Hue, Saturation, Brightness);
		}
	}
}
