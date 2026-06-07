using TMPro;
using UI.Xml;

namespace Assets.Scripts.Menu.ListView
{
	public class DetailsPropertyPairScript : DetailsWidgetBaseScript
	{
		private TextMeshProUGUI _labelLeft;

		private TextMeshProUGUI _labelRight;

		private TextMeshProUGUI _valueLeft;

		private TextMeshProUGUI _valueRight;

		public string LeftLabelText
		{
			get
			{
				return _labelLeft.text;
			}
			set
			{
				_labelLeft.text = value;
			}
		}

		public string RightLabelText
		{
			get
			{
				return _labelRight.text;
			}
			set
			{
				_labelRight.text = value;
			}
		}

		public string LeftLabelTooltip
		{
			get
			{
				return _labelLeft.GetComponent<XmlElement>().Tooltip;
			}
			set
			{
				XmlElement component = _labelLeft.GetComponent<XmlElement>();
				component.Tooltip = value;
				component.ApplyAttributes(new AttributeDictionary { { "tooltip", value } });
			}
		}

		public string RightLabelTooltip
		{
			get
			{
				return _labelRight.GetComponent<XmlElement>().Tooltip;
			}
			set
			{
				XmlElement component = _labelRight.GetComponent<XmlElement>();
				component.Tooltip = value;
				component.ApplyAttributes(new AttributeDictionary { { "tooltip", value } });
			}
		}

		public string LeftTooltip
		{
			set
			{
				XmlElement component = _labelLeft.GetComponent<XmlElement>();
				component.Tooltip = value;
				component.ApplyAttributes(new AttributeDictionary { { "tooltip", value } });
				XmlElement component2 = _valueLeft.GetComponent<XmlElement>();
				component2.Tooltip = value;
				component2.ApplyAttributes(new AttributeDictionary { { "tooltip", value } });
			}
		}

		public string RightTooltip
		{
			set
			{
				XmlElement component = _labelRight.GetComponent<XmlElement>();
				component.Tooltip = value;
				component.ApplyAttributes(new AttributeDictionary { { "tooltip", value } });
				XmlElement component2 = _valueRight.GetComponent<XmlElement>();
				component2.Tooltip = value;
				component2.ApplyAttributes(new AttributeDictionary { { "tooltip", value } });
			}
		}

		public string LeftValueText
		{
			get
			{
				return _valueLeft.text;
			}
			set
			{
				_valueLeft.text = value;
			}
		}

		public string RightValueText
		{
			get
			{
				return _valueRight.text;
			}
			set
			{
				_valueRight.text = value;
			}
		}

		public string LeftValueTooltip
		{
			get
			{
				return _valueLeft.GetComponent<XmlElement>().Tooltip;
			}
			set
			{
				XmlElement component = _valueLeft.GetComponent<XmlElement>();
				component.Tooltip = value;
				component.ApplyAttributes(new AttributeDictionary { { "tooltip", value } });
			}
		}

		public string RightValueTooltip
		{
			get
			{
				return _valueRight.GetComponent<XmlElement>().Tooltip;
			}
			set
			{
				XmlElement component = _valueRight.GetComponent<XmlElement>();
				component.Tooltip = value;
				component.ApplyAttributes(new AttributeDictionary { { "tooltip", value } });
			}
		}

		public override void Initialize(ListViewDetailsScript details)
		{
			XmlElement component = GetComponent<XmlElement>();
			_labelLeft = component.GetElementByInternalId<TextMeshProUGUI>("label-left");
			_valueLeft = component.GetElementByInternalId<TextMeshProUGUI>("value-left");
			_labelRight = component.GetElementByInternalId<TextMeshProUGUI>("label-right");
			_valueRight = component.GetElementByInternalId<TextMeshProUGUI>("value-right");
		}
	}
}
