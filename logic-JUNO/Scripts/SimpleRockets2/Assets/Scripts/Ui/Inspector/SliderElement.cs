using ModApi.Common.Extensions;
using ModApi.Math;
using ModApi.Ui.Inspector;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Inspector
{
	public class SliderElement : ItemElement
	{
		private SliderModel _model;

		private SliderControl _slider;

		public bool Interactable
		{
			get
			{
				return _slider.Slider.interactable;
			}
			set
			{
				_slider.Slider.interactable = value;
			}
		}

		public SliderElement(XmlElement xmlElement, SliderModel model, GroupModel group, float minValue, float maxValue, bool wholeNumbers)
			: base(xmlElement, model, group)
		{
			_model = model;
			XmlElement elementByInternalId = xmlElement.GetElementByInternalId("slider");
			if (model.Style == SliderModel.SliderStyle.Bipolar)
			{
				elementByInternalId.AddClass("bipolar");
			}
			_slider = new SliderControl(elementByInternalId);
			if (model.AllowManualInput)
			{
				_slider.EnableManualInput(SetManualInput, () => _model.Value.ToString());
			}
			Slider slider = _slider.Slider;
			slider.minValue = minValue;
			slider.maxValue = maxValue;
			slider.wholeNumbers = wholeNumbers;
			slider.value = _model.Value;
			slider.onValueChanged.AddListener(delegate(float x)
			{
				OnSliderValueChanged(x);
			});
			slider.gameObject.AddMissingComponent<SliderModel.SliderPointerScript>().OnSliderAdjustmentEnded += delegate
			{
				OnSliderAdjustmentEnded();
			};
			Update();
			UpdateValueText();
		}

		public override void Update()
		{
			base.Update();
			Slider slider = _slider.Slider;
			if (_slider.LabelText.text != _model.Label)
			{
				_slider.LabelText.text = _model.Label;
			}
			if (slider.maxValue != _model.MaxValue)
			{
				slider.maxValue = _model.MaxValue;
			}
			if (slider.minValue != _model.MinValue)
			{
				slider.minValue = _model.MinValue;
			}
			if (slider.value != _model.Value || _model.ForceRefreshValueText)
			{
				_model.ForceRefreshValueText = false;
				slider.SetValueWithoutNotify(_model.Value);
				UpdateValueText();
			}
		}

		private void OnSliderAdjustmentEnded()
		{
			_model.SetValueFromUserInput(_slider.Slider.value, _model.Label, finished: true, ignoreIfEqual: false);
			UpdateValueText();
		}

		private void OnSliderValueChanged(float value)
		{
			_model.SetValueFromUserInput(value, _model.Label, finished: false);
			UpdateValueText();
		}

		private void SetManualInput(float value)
		{
			if (_model.ManualInputMinValue.HasValue)
			{
				value = Mathf.Max(value, _model.ManualInputMinValue.Value);
			}
			if (_model.ManualInputMaxValue.HasValue)
			{
				value = Mathf.Min(value, _model.ManualInputMaxValue.Value);
			}
			_model.SetValueIgnoringLimits(value, _model.Label);
		}

		private void UpdateValueText()
		{
			if (_model.ValueFormatter != null)
			{
				_slider.ValueText.text = _model.ValueFormatter(_model.Value);
			}
			else
			{
				_slider.ValueText.text = Units.GetPercentageString(_model.Value);
			}
		}
	}
}
