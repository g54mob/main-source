using TMPro;
using UI.Xml;

namespace Assets.Scripts.Menu.ListView
{
	public class DetailsPropertyScript : DetailsWidgetBaseScript
	{
		private TextMeshProUGUI _label;

		private TextMeshProUGUI _value;

		public string LabelText
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

		public string LabelTooltip
		{
			get
			{
				return _label.GetComponent<XmlElement>().Tooltip;
			}
			set
			{
				XmlElement component = _label.GetComponent<XmlElement>();
				component.Tooltip = value;
				component.ApplyAttributes(new AttributeDictionary { { "tooltip", value } });
			}
		}

		public string Tooltip
		{
			set
			{
				XmlElement component = _label.GetComponent<XmlElement>();
				component.Tooltip = value;
				component.ApplyAttributes(new AttributeDictionary { { "tooltip", value } });
				XmlElement component2 = _value.GetComponent<XmlElement>();
				component2.Tooltip = value;
				component2.ApplyAttributes(new AttributeDictionary { { "tooltip", value } });
			}
		}

		public string ValueText
		{
			get
			{
				return _value.text;
			}
			set
			{
				_value.text = value;
			}
		}

		public string ValueTooltip
		{
			get
			{
				return _value.GetComponent<XmlElement>().Tooltip;
			}
			set
			{
				XmlElement component = _value.GetComponent<XmlElement>();
				component.Tooltip = value;
				component.ApplyAttributes(new AttributeDictionary { { "tooltip", value } });
			}
		}

		public override void Initialize(ListViewDetailsScript details)
		{
			XmlElement component = GetComponent<XmlElement>();
			_label = component.GetElementByInternalId<TextMeshProUGUI>("label");
			_value = component.GetElementByInternalId<TextMeshProUGUI>("value");
		}
	}
}
