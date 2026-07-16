using UnityEngine;
using UnityEngine.UI;

namespace TS.ColorPicker
{
	[RequireComponent(typeof(PointerTrackerArea), typeof(Slider))]
	public class ColorSlider : MonoBehaviour
	{
		public delegate void OnValueChanged(ColorSlider sender, float value);

		public OnValueChanged ValueChanged;

		private Slider _slider;

		private PointerTrackerArea _tracker;

		public float Value
		{
			get
			{
				return _slider.value;
			}
			set
			{
				_slider.SetValueWithoutNotify(value);
			}
		}

		private void Awake()
		{
			_slider = GetComponent<Slider>();
			_tracker = GetComponent<PointerTrackerArea>();
		}

		private void Start()
		{
			_slider.onValueChanged.AddListener(Slider_ValueChanged);
			_tracker.Drag = PointerTrackerArea_Drag;
		}

		private void Slider_ValueChanged(float arg0)
		{
			ValueChanged?.Invoke(this, arg0);
		}

		private void PointerTrackerArea_Drag(PointerTrackerArea sender, Vector2 position)
		{
			_slider.value = sender.Normalize(position).y;
		}
	}
}
