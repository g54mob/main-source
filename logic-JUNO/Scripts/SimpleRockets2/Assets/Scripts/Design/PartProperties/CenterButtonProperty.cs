using System.Reflection;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design;
using ModApi.Design.PartProperties;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design.PartProperties
{
	public class CenterButtonProperty : ConfigurableProperty, ICenterButtonProperty, IConfigurableProperty
	{
		private TextMeshProUGUI _label;

		public CenterButtonProperty(FieldInfo field, DesignerPropertyAttribute attribute)
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
				if (valueLabel != null)
				{
					_label.text = valueLabel;
				}
			}
		}

		protected override GameObject OnCreateUI(GameObject parent, PartPropertiesFlyoutScript flyout)
		{
			XmlElement xmlElement = flyout.CloneTemplateElement("template-button", parent.transform);
			_label = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			_label.text = base.FieldName;
			xmlElement.GetElementByInternalId<Button>("button").onClick.AddListener(OnClick);
			return xmlElement.gameObject;
		}

		private void OnClick()
		{
			SetValue(GetValue());
		}
	}
}
