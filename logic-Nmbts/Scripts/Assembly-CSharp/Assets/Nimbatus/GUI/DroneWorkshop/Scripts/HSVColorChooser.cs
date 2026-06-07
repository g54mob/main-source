using Assets.Nimbatus.GUI.Common.Scripts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class HSVColorChooser : MonoBehaviour
	{
		public Color SelectedColor;

		public FloatInputSlider HSlider;

		public FloatInputSlider SSlider;

		public FloatInputSlider VSlider;

		public FloatInputSlider ASlider;

		private bool _isInit;

		private Color _originalColor;

		public void Init(Color originalColor)
		{
			HSlider.Init(0f, 1f, 100);
			SSlider.Init(0f, 1f, 100);
			VSlider.Init(0f, 1f, 100);
			ASlider.Init(0f, 1f, 100);
			_originalColor = originalColor;
			SetColorToSlider(_originalColor);
			_isInit = true;
		}

		private void SetColorToSlider(Color color)
		{
			float H;
			float S;
			float V;
			Color.RGBToHSV(color, out H, out S, out V);
			float a = color.a;
			SelectedColor = color;
			HSlider.CurrentValue = H;
			SSlider.CurrentValue = S;
			VSlider.CurrentValue = V;
			ASlider.CurrentValue = a;
		}

		private Color GetColorFromSlider()
		{
			float currentValue = HSlider.CurrentValue;
			float currentValue2 = SSlider.CurrentValue;
			float currentValue3 = VSlider.CurrentValue;
			float currentValue4 = ASlider.CurrentValue;
			Color result = Color.HSVToRGB(currentValue, currentValue2, currentValue3);
			result.a = currentValue4;
			return result;
		}

		public void Update()
		{
			if (_isInit)
			{
				SelectedColor = GetColorFromSlider();
			}
		}

		public void Reset()
		{
			SetColorToSlider(_originalColor);
		}
	}
}
