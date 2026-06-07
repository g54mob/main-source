using System;
using System.Reflection;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design.PartProperties
{
	public class ToggleButtonProperty : ConfigurableProperty, IToggleButtonProperty, IConfigurableProperty
	{
		private TextMeshProUGUI _label;

		private Toggle _toggle;

		public DesignerPropertyToggleButtonAttribute ButtonAttribute => (DesignerPropertyToggleButtonAttribute)base.Attribute;

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

		public bool ToggleValue
		{
			get
			{
				return GetBooleanValue();
			}
			set
			{
				SetValue(value);
			}
		}

		public ToggleButtonProperty(FieldInfo field, DesignerPropertyAttribute attribute)
			: base(field, attribute)
		{
			if (field.FieldType != typeof(bool))
			{
				Debug.LogErrorFormat("Field '{0}' for modifier type '{1}' is attempting to use a toggle button. Toggle buttons are only for boolean fields", field.Name, field.DeclaringType.FullName);
			}
		}

		public override void RefreshUI()
		{
			if (base.CurrentPartModifier != null)
			{
				_toggle.isOn = GetBooleanValue();
			}
		}

		protected override GameObject OnCreateUI(GameObject parent, PartPropertiesFlyoutScript flyout)
		{
			XmlElement xmlElement = flyout.CloneTemplateElement("template-toggle", parent.transform);
			_label = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			_label.text = base.FieldName;
			_toggle = xmlElement.GetElementByInternalId<Toggle>("toggle");
			_toggle.onValueChanged.AddListener(OnValueChanged);
			return xmlElement.gameObject;
		}

		private bool GetBooleanValue()
		{
			return Convert.ToBoolean(GetValue());
		}

		private void OnValueChanged(bool toggled)
		{
			if (base.CurrentPartModifier != null)
			{
				SetValue(toggled);
			}
		}
	}
}
