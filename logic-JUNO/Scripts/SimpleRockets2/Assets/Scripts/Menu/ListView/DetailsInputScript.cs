using TMPro;
using UI.Xml;

namespace Assets.Scripts.Menu.ListView
{
	public class DetailsInputScript : DetailsWidgetBaseScript
	{
		private XmlElement _placeholder;

		public TMP_InputField Input { get; private set; }

		public string PlaceholderText
		{
			get
			{
				return _placeholder.GetText();
			}
			set
			{
				_placeholder.SetText(value);
			}
		}

		public string Text
		{
			get
			{
				return Input.text;
			}
			set
			{
				Input.text = value;
			}
		}

		public override void Initialize(ListViewDetailsScript details)
		{
			Input = GetComponentInChildren<TMP_InputField>();
			XmlElement component = GetComponent<XmlElement>();
			_placeholder = component.GetElementByInternalId("input-placeholder");
		}
	}
}
