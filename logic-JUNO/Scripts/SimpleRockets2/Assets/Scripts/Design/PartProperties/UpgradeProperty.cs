using System.Reflection;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design.PartProperties
{
	public class UpgradeProperty : ConfigurableProperty
	{
		private TextMeshProUGUI _valueText;

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

		public DesignerPropertyUpgradeAttribute UpgradeAttribute => base.Attribute as DesignerPropertyUpgradeAttribute;

		public UpgradeProperty(FieldInfo field, DesignerPropertyAttribute attribute)
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

		protected override GameObject OnCreateUI(GameObject parent, PartPropertiesFlyoutScript flyout)
		{
			XmlElement xmlElement = flyout.CloneTemplateElement("template-upgrade", parent.transform);
			_valueText = xmlElement.GetComponentInChildren<TextMeshProUGUI>();
			xmlElement.GetElementByInternalId("button").AddOnClickEvent(delegate
			{
				SetValue(GetValue());
			});
			return xmlElement.gameObject;
		}
	}
}
