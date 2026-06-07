using System.Reflection;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design.PartProperties
{
	public class TextInputProperty : ConfigurableProperty, ITextInputProperty, IConfigurableProperty
	{
		private TextMeshProUGUI _labelText;

		private TMP_InputField _valueInput;

		public string LabelValue
		{
			get
			{
				return _labelText.text;
			}
			set
			{
				_labelText.text = value;
			}
		}

		public string Value
		{
			get
			{
				return _valueInput.text;
			}
			set
			{
				_valueInput.text = value;
			}
		}

		public TextInputProperty(FieldInfo field, DesignerPropertyAttribute attribute)
			: base(field, attribute)
		{
		}

		public override void RefreshUI()
		{
			if (base.CurrentPartModifier != null)
			{
				_valueInput.text = (GetValue() ?? string.Empty).ToString();
			}
		}

		protected override GameObject OnCreateUI(GameObject parent, PartPropertiesFlyoutScript flyout)
		{
			XmlElement xmlElement = flyout.CloneTemplateElement("template-text-input", parent.transform);
			_labelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			_labelText.text = base.FieldName;
			_valueInput = xmlElement.GetElementByInternalId<TMP_InputField>("input-field");
			_valueInput.onEndEdit.AddListener(OnEndEdit);
			return xmlElement.gameObject;
		}

		private void OnEndEdit(string value)
		{
			SetValue(value);
		}
	}
}
