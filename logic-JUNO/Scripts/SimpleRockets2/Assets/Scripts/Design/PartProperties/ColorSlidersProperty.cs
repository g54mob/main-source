using System.Reflection;
using Assets.Scripts.Ui;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design.PartProperties
{
	public class ColorSlidersProperty : ConfigurableProperty, IColorSlidersProperty, IConfigurableProperty
	{
		private TextMeshProUGUI _label;

		private bool _refreshingUI;

		private SliderControl _sliderAlpha;

		private SliderControl _sliderBlue;

		private SliderControl _sliderGreen;

		private SliderControl _sliderRed;

		public DesignerPropertyColorSlidersAttribute ColorSlidersAttribute => (DesignerPropertyColorSlidersAttribute)base.Attribute;

		public string LabelValue
		{
			get
			{
				return _label.text;
			}
			set
			{
				_label.text = value;
			}
		}

		public ColorSlidersProperty(FieldInfo field, DesignerPropertyAttribute attribute)
			: base(field, attribute)
		{
		}

		public override void RefreshUI()
		{
			if (base.CurrentPartModifier != null)
			{
				_refreshingUI = true;
				Color32 color = ((base.Field.FieldType == typeof(Color)) ? ((Color32)(Color)GetValue()) : ((Color32)GetValue()));
				_sliderRed.Slider.value = (int)color.r;
				_sliderGreen.Slider.value = (int)color.g;
				_sliderBlue.Slider.value = (int)color.b;
				_sliderAlpha.Slider.value = (int)color.a;
				RefreshSliderLabels();
				_refreshingUI = false;
			}
		}

		protected override GameObject OnCreateUI(GameObject parent, PartPropertiesFlyoutScript flyout)
		{
			XmlElement xmlElement = flyout.CloneTemplateElement("template-color-sliders", parent.transform, "PartProperties." + base.FieldName);
			_label = xmlElement.GetElementByInternalId<TextMeshProUGUI>("color-sliders-label");
			_sliderRed = InitializeSlider(xmlElement.GetElementByInternalId("slider-panel-red"));
			_sliderGreen = InitializeSlider(xmlElement.GetElementByInternalId("slider-panel-green"));
			_sliderBlue = InitializeSlider(xmlElement.GetElementByInternalId("slider-panel-blue"));
			_sliderAlpha = InitializeSlider(xmlElement.GetElementByInternalId("slider-panel-alpha"));
			LabelValue = base.FieldName;
			if (!ColorSlidersAttribute.ShowAlpha)
			{
				_sliderAlpha.Panel.SetAndApplyAttribute("active", "false");
			}
			else
			{
				_sliderAlpha.LabelText.text = ColorSlidersAttribute.AlphaLabel;
			}
			return xmlElement.gameObject;
		}

		private SliderControl InitializeSlider(XmlElement element)
		{
			SliderControl sliderControl = new SliderControl(element);
			sliderControl.Slider.onValueChanged.AddListener(OnValueChanged);
			sliderControl.Slider.wholeNumbers = true;
			sliderControl.Slider.minValue = 0f;
			sliderControl.Slider.maxValue = 255f;
			return sliderControl;
		}

		private void OnValueChanged(float value)
		{
			if (!_refreshingUI)
			{
				Color32 color = new Color32((byte)_sliderRed.Slider.value, (byte)_sliderGreen.Slider.value, (byte)_sliderBlue.Slider.value, (byte)_sliderAlpha.Slider.value);
				SetValue((base.Field.FieldType == typeof(Color)) ? ((object)(Color)color) : ((object)color));
				RefreshSliderLabels();
			}
		}

		private void RefreshSliderLabels()
		{
			if (base.CurrentPartModifier != null)
			{
				Color32 color = ((base.Field.FieldType == typeof(Color)) ? ((Color32)(Color)GetValue()) : ((Color32)GetValue()));
				_sliderRed.ValueText.text = color.r.ToString();
				_sliderGreen.ValueText.text = color.g.ToString();
				_sliderBlue.ValueText.text = color.b.ToString();
				_sliderAlpha.ValueText.text = color.a.ToString();
			}
		}
	}
}
