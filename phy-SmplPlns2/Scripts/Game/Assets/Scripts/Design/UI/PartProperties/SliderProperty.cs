using System;
using System.Reflection;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.UI.Controls;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class SliderProperty : ConfigurableProperty, ISliderProperty, IConfigurableProperty
	{
		private bool _refreshingUI;

		private bool _valueChangedSincePointerDown;

		public SliderControl Slider { get; private set; }

		public DesignerPropertySliderAttribute SliderAttribute => (DesignerPropertySliderAttribute)base.Attribute;

		public float Value
		{
			get
			{
				return Slider.Slider.Value;
			}
			set
			{
				Slider.Slider.Value = value;
			}
		}

		public SliderProperty(MemberInfo member, DesignerPropertyAttribute attribute)
			: base(member, attribute)
		{
		}

		public override void CreateUI(Widget parent)
		{
			base.RootWidget = CreateWidgetFromTemplate("control-slider", parent);
			Slider = new SliderControl(base.RootWidget);
			Slider.ManualValueString = true;
			Slider.LabelText = GetDefaultLabel();
			Slider.Slider.NumberOfSteps = SliderAttribute.NumberOfSteps;
			Slider.Slider.ValueChanged += OnValueChanged;
			Slider.Slider.PointerUp += OnPointerUp;
		}

		public override void RefreshUI()
		{
			PartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier != null)
			{
				_refreshingUI = true;
				float num = Convert.ToSingle(GetValue());
				float value = (num - SliderAttribute.MinValue) / (SliderAttribute.MaxValue - SliderAttribute.MinValue);
				Slider.LabelText = currentPartModifier.GetGenericDesignerPropertyNameLabel(this);
				Slider.Slider.NumberOfSteps = SliderAttribute.NumberOfSteps;
				Slider.ValueFormatter = null;
				Slider.Slider.Value = value;
				RefreshSliderLabel(num);
				_refreshingUI = false;
			}
		}

		private void OnPointerUp(Widget widget)
		{
			if (_valueChangedSincePointerDown)
			{
				_valueChangedSincePointerDown = false;
				RaiseValueChanged();
				RaiseValueCommitted();
			}
		}

		private void OnValueChanged(float value)
		{
			if (_refreshingUI || base.CurrentPartModifier == null)
			{
				return;
			}
			float num = SliderAttribute.MinValue + (SliderAttribute.MaxValue - SliderAttribute.MinValue) * Slider.Slider.Slider.normalizedValue;
			foreach (var symmetricModifier in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier.PartModifier.OnGenericDesignerPropertyChanging(base.Member.Name, num.ToString());
			}
			SetValue(num, convertType: true, updateSymmetricProperties: true, raiseValueChangedEvent: false);
			foreach (var symmetricModifier2 in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier2.PartModifier.OnGenericDesignerPropertyChanged(base.Member.Name, num.ToString());
			}
			RefreshSliderLabel(num);
			_valueChangedSincePointerDown = true;
		}

		private void RefreshSliderLabel(float value)
		{
			PartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier != null)
			{
				string genericDesignerPropertySliderValueLabel = currentPartModifier.GetGenericDesignerPropertySliderValueLabel(base.Member.Name, value);
				Slider.ValueText.Text = genericDesignerPropertySliderValueLabel;
			}
		}
	}
}
