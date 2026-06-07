using System;
using ModApi.Common.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModApi.Ui.Inspector
{
	public class SliderModel : ValueModel<float>
	{
		public delegate void SliderAdjustmentStartStopHandler(SliderModel source);

		public enum SliderStyle
		{
			Normal = 0,
			Bipolar = 1
		}

		public class SliderPointerScript : MonoBehaviour, IPointerUpHandler, IEventSystemHandler, IPointerDownHandler
		{
			public event SliderAdjustmentStartStopHandler OnSliderAdjustmentEnded;

			public event SliderAdjustmentStartStopHandler OnSliderAdjustmentStarted;

			public void OnPointerDown(PointerEventData eventData)
			{
				this.OnSliderAdjustmentStarted?.Invoke(null);
			}

			public void OnPointerUp(PointerEventData eventData)
			{
				this.OnSliderAdjustmentEnded?.Invoke(null);
			}
		}

		public bool AllowManualInput { get; set; }

		public bool ForceRefreshValueText { get; set; }

		public string Label { get; set; }

		public float? ManualInputMaxValue { get; set; }

		public float? ManualInputMinValue { get; set; }

		public float MaxValue { get; set; }

		public float MinValue { get; set; }

		public SliderStyle Style { get; set; }

		public override float Value => base.Value;

		public Func<float, string> ValueFormatter { get; set; }

		public bool WholeNumbers { get; }

		public event SliderAdjustmentStartStopHandler OnSliderAdjustmentEnded;

		public event SliderAdjustmentStartStopHandler OnSliderAdjustmentStarted;

		public SliderModel(string label, Func<float> valueGetter, Action<float> valueSetter, float minValue = 0f, float maxValue = 1f, bool wholeNumbers = false, bool allowManualInput = true)
			: base(valueGetter, valueSetter)
		{
			Label = label;
			MinValue = minValue;
			MaxValue = maxValue;
			WholeNumbers = wholeNumbers;
			AllowManualInput = allowManualInput;
			base.ElementCreated += delegate(IItemElement x)
			{
				SliderPointerScript sliderPointerScript = x.GameObject.GetComponentInChildren<Slider>().gameObject.AddMissingComponent<SliderPointerScript>();
				sliderPointerScript.OnSliderAdjustmentEnded += delegate
				{
					this.OnSliderAdjustmentEnded?.Invoke(this);
				};
				sliderPointerScript.OnSliderAdjustmentStarted += delegate
				{
					this.OnSliderAdjustmentStarted?.Invoke(this);
				};
			};
		}

		public override void SetValueFromUserInput(float value, string name, bool finished = true, bool ignoreIfEqual = true)
		{
			base.SetValueFromUserInput(Mathf.Clamp(value, MinValue, MaxValue), name, finished, ignoreIfEqual);
		}

		public void SetValueIgnoringLimits(float value, string name)
		{
			base.SetValueFromUserInput(value, name);
		}
	}
}
