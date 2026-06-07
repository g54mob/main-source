using System.Reflection;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design;
using ModApi.Design.PartProperties;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design.PartProperties
{
	public class LabelProperty : ConfigurableProperty, ILabelProperty, IConfigurableProperty
	{
		private float _originalFontSize;

		private TextMeshProUGUI _valueText;

		public float FontSize => _valueText.fontSize;

		public string LabelValue
		{
			get
			{
				return _valueText.text;
			}
			set
			{
				_valueText.text = value;
			}
		}

		public LabelProperty(FieldInfo field, DesignerPropertyAttribute attribute)
			: base(field, attribute)
		{
		}

		public override void RefreshUI()
		{
			IDesignerPartModifierData currentPartModifier = base.CurrentPartModifier;
			if (currentPartModifier != null)
			{
				string value = GetValue() as string;
				string valueLabel = currentPartModifier.DesignerPartProperties.GetValueLabel(base.Field, value);
				_valueText.text = valueLabel;
			}
		}

		public void RestoreFontSize()
		{
			_valueText.enableAutoSizing = false;
			_valueText.fontSize = _originalFontSize;
		}

		public void SetFontSize(float size)
		{
			_valueText.enableAutoSizing = false;
			_valueText.fontSize = size;
		}

		public void SetFontSize(float minSize, float maxSize)
		{
			_valueText.enableAutoSizing = true;
			_valueText.fontSizeMin = minSize;
			_valueText.fontSizeMax = maxSize;
		}

		protected override GameObject OnCreateUI(GameObject parent, PartPropertiesFlyoutScript flyout)
		{
			XmlElement xmlElement = null;
			if (string.IsNullOrEmpty(base.Attribute.Label))
			{
				xmlElement = flyout.CloneTemplateElement("template-label", parent.transform);
				_valueText = xmlElement.GetComponentInChildren<TextMeshProUGUI>();
			}
			else
			{
				xmlElement = flyout.CloneTemplateElement("template-label-value", parent.transform);
				xmlElement.GetElementByInternalId<TextMeshProUGUI>("label").text = base.Attribute.Label;
				_valueText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("value");
			}
			_originalFontSize = _valueText.fontSize;
			return xmlElement.gameObject;
		}
	}
}
