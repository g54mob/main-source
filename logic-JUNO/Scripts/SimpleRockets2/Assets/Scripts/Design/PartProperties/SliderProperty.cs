using System;
using System.Reflection;
using Assets.Scripts.Ui;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design;
using ModApi.Design.PartProperties;
using ModApi.Scripts.State.Validation;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design.PartProperties
{
	public class SliderProperty : ConfigurableProperty, ISliderProperty, IConfigurableProperty
	{
		private bool _refreshingUI;

		private SliderControl _slider;

		private float _stepValue;

		public string LabelValue
		{
			get
			{
				return _slider.LabelText.text;
			}
			set
			{
				_slider.LabelText.text = value;
			}
		}

		public float MaxValue { get; set; }

		public float MinValue { get; set; }

		public int NumberOfSteps { get; private set; }

		public DesignerPropertySliderAttribute SliderAttribute => (DesignerPropertySliderAttribute)base.Attribute;

		public string SliderValue
		{
			get
			{
				return _slider.ValueText.text;
			}
			set
			{
				_slider.ValueText.text = value;
			}
		}

		public SliderProperty(FieldInfo field, DesignerPropertyAttribute attribute)
			: base(field, attribute)
		{
		}

		public override void RefreshUI()
		{
			if (base.CurrentPartModifier != null)
			{
				_refreshingUI = true;
				float num = Convert.ToSingle(GetValue());
				float value = (num - MinValue) / _stepValue;
				_slider.Slider.value = value;
				RefreshSliderLabel(num);
				_refreshingUI = false;
			}
		}

		public void UpdateSliderSettings(float minValue, float maxValue, int numberOfSteps)
		{
			UpdateSliderSettings(minValue, maxValue, numberOfSteps, refreshUI: true);
		}

		public void UpdateSliderSettings(float minValue, float maxValue, int numberOfSteps, bool refreshUI)
		{
			MinValue = minValue;
			MaxValue = maxValue;
			NumberOfSteps = Mathf.Max(1, numberOfSteps);
			_slider.Slider.minValue = 0f;
			_slider.Slider.maxValue = NumberOfSteps - 1;
			_stepValue = (maxValue - minValue) / (float)Mathf.Max(1, numberOfSteps - 1);
			if (refreshUI)
			{
				RefreshUI();
			}
		}

		protected override GameObject OnCreateUI(GameObject parent, PartPropertiesFlyoutScript flyout)
		{
			XmlElement xmlElement = flyout.CloneTemplateElement("template-slider", parent.transform, "PartProperties." + base.FieldName);
			_slider = new SliderControl(xmlElement);
			LabelValue = base.FieldName;
			SliderValue = "Error";
			_slider.Slider.onValueChanged.AddListener(OnValueChanged);
			_slider.Slider.wholeNumbers = true;
			DesignerPropertySliderAttribute sliderAttribute = SliderAttribute;
			float num = sliderAttribute.MaxValue;
			int numberOfSteps = sliderAttribute.NumberOfSteps;
			IGameStateValidator validator = Game.Instance.GameState.Validator;
			if (validator.IsCareerMode && sliderAttribute.TechTreeIdForMaxValue != null)
			{
				float num2 = validator.ItemValue(sliderAttribute.TechTreeIdForMaxValue);
				float num3 = (sliderAttribute.MaxValue - sliderAttribute.MinValue) / (float)(sliderAttribute.NumberOfSteps - 1);
				num = num2;
				numberOfSteps = (int)(Mathf.Round((num - sliderAttribute.MinValue) / num3) + 1f);
			}
			UpdateSliderSettings(sliderAttribute.MinValue, num, numberOfSteps, refreshUI: false);
			return xmlElement.gameObject;
		}

		private void OnValueChanged(float value)
		{
			if (!_refreshingUI && base.CurrentPartModifier != null)
			{
				float num = MinValue + _stepValue * value;
				object value2 = Convert.ChangeType(num, base.Field.FieldType);
				SetValue(value2);
				RefreshSliderLabel(num);
			}
		}

		private void RefreshSliderLabel(float value)
		{
			IDesignerPartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier != null)
			{
				object value2 = ((base.Field.FieldType == typeof(float)) ? ((object)value) : Convert.ChangeType(value, base.Field.FieldType));
				string valueLabel = currentPartModifier.DesignerPartProperties.GetValueLabel(base.Field, value2);
				SliderValue = valueLabel;
			}
		}
	}
}
