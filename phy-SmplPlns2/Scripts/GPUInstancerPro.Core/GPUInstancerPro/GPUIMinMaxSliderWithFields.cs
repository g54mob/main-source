using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace GPUInstancerPro
{
	public class GPUIMinMaxSliderWithFields : VisualElement
	{
		private MinMaxSlider minMaxSlider;

		private FloatField minField;

		private FloatField maxField;

		private const int floatFieldWidth = 42;

		public GPUIMinMaxSliderWithFields(string label, float minLimit, float maxLimit, float initialMin, float initialMax, Action<Vector2> valueChangedCallback)
		{
			GPUIMinMaxSliderWithFields gPUIMinMaxSliderWithFields = this;
			minMaxSlider = new MinMaxSlider(initialMin, initialMax, minLimit, maxLimit);
			minMaxSlider.label = label;
			minMaxSlider.labelElement.style.width = 170f;
			minMaxSlider.style.flexGrow = 1f;
			minMaxSlider.style.paddingRight = 5f;
			minMaxSlider.style.marginRight = 2f;
			Add(minMaxSlider);
			minField = new FloatField
			{
				value = initialMin
			};
			minField.style.flexGrow = 0f;
			minField.style.minWidth = 42f;
			minField.style.maxWidth = 42f;
			maxField = new FloatField
			{
				value = initialMax
			};
			maxField.style.flexGrow = 0f;
			maxField.style.minWidth = 42f;
			maxField.style.maxWidth = 42f;
			VisualElement visualElement = new VisualElement();
			visualElement.style.flexDirection = FlexDirection.Row;
			visualElement.Add(minMaxSlider);
			visualElement.Add(minField);
			visualElement.Add(maxField);
			Add(visualElement);
			minField.RegisterValueChangedCallback(delegate(ChangeEvent<float> evt)
			{
				float num = Mathf.Clamp(evt.newValue, minLimit, gPUIMinMaxSliderWithFields.maxField.value);
				gPUIMinMaxSliderWithFields.minField.value = num;
				gPUIMinMaxSliderWithFields.minMaxSlider.value = new Vector2(num, gPUIMinMaxSliderWithFields.minMaxSlider.value.y);
				valueChangedCallback?.Invoke(gPUIMinMaxSliderWithFields.minMaxSlider.value);
			});
			maxField.RegisterValueChangedCallback(delegate(ChangeEvent<float> evt)
			{
				float num = Mathf.Clamp(evt.newValue, gPUIMinMaxSliderWithFields.minField.value, maxLimit);
				gPUIMinMaxSliderWithFields.maxField.value = num;
				gPUIMinMaxSliderWithFields.minMaxSlider.value = new Vector2(gPUIMinMaxSliderWithFields.minMaxSlider.value.x, num);
				valueChangedCallback?.Invoke(gPUIMinMaxSliderWithFields.minMaxSlider.value);
			});
			minMaxSlider.RegisterValueChangedCallback(delegate(ChangeEvent<Vector2> evt)
			{
				gPUIMinMaxSliderWithFields.minField.value = evt.newValue.x;
				gPUIMinMaxSliderWithFields.maxField.value = evt.newValue.y;
				valueChangedCallback?.Invoke(evt.newValue);
			});
		}

		public void SetValues(float min, float max)
		{
			minField.value = min;
			maxField.value = max;
			minMaxSlider.value = new Vector2(min, max);
		}
	}
}
