using System;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.CustomizationScene
{
	public class CUIColorPicker : MonoBehaviour
	{
		[SerializeField]
		private Slider alphaSlider;

		[SerializeField]
		private Image alphaSliderBGImage;

		private Color _color;

		private Action<Color> _onValueChange;

		private Action _update;

		public Color Color
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public void SetOnValueChangeCallback(Action<Color> onValueChange)
		{
		}

		private static void RGBToHSV(Color color, out float h, out float s, out float v)
		{
			h = default(float);
			s = default(float);
			v = default(float);
		}

		private static bool GetLocalMouse(GameObject go, out Vector2 result)
		{
			result = default(Vector2);
			return false;
		}

		private static Vector2 GetWidgetSize(GameObject go)
		{
			return default(Vector2);
		}

		private GameObject GO(string name)
		{
			return null;
		}

		private void Setup(Color inputColor)
		{
		}

		public void SetRandomColor()
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
