using System;
using TMPro;
using UI.Xml;

namespace Assets.Scripts.Menu.ListView
{
	public class DetailsButtonScript : DetailsWidgetBaseScript
	{
		private TextMeshProUGUI _text;

		private XmlElement _xmlElement;

		public Action<DetailsButtonScript> Clicked { get; set; }

		public string Text
		{
			get
			{
				return _text.text;
			}
			set
			{
				_text.text = value;
			}
		}

		public override void Initialize(ListViewDetailsScript details)
		{
			_text = GetComponentInChildren<TextMeshProUGUI>();
			_xmlElement = GetComponent<XmlElement>();
			_xmlElement.GetElementByInternalId("button").AddOnClickEvent(delegate
			{
				Clicked?.Invoke(this);
			});
		}

		public void RaiseClickedEvent()
		{
			Clicked?.Invoke(this);
		}
	}
}
