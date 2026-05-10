using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HSVPicker
{
	[DefaultExecutionOrder(10)]
	[RequireComponent(typeof(Slider))]
	public class ColorSlider : MonoBehaviour, IEndDragHandler, IEventSystemHandler
	{
		public ColorPicker hsvpicker;

		public ColorValues type;

		private Slider slider;

		private bool listen;

		[Header("Event")]
		public SliderOnChangeEndEvent onSliderChangeEndEvent;

		private void Awake()
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

		private void SliderChanged(float newValue)
		{
		}

		public virtual void OnEndDrag(PointerEventData eventData)
		{
		}

		public void SliderClicked(BaseEventData data)
		{
		}
	}
}
