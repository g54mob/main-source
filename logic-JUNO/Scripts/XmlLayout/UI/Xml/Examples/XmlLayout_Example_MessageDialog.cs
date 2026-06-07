using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Examples
{
	public class XmlLayout_Example_MessageDialog : XmlLayoutController
	{
		private XmlElementReference<Text> titleText;

		private XmlElementReference<Text> messageText;

		private void Awake()
		{
			titleText = XmlElementReference<Text>("titleText");
			messageText = XmlElementReference<Text>("messageText");
		}

		public void Show(string title, string text)
		{
			base.xmlLayout.Show();
			StartCoroutine(DelayedShow(title, text));
		}

		protected IEnumerator DelayedShow(string title, string text)
		{
			yield return new WaitForEndOfFrame();
			titleText.element.text = title;
			messageText.element.text = text;
		}

		public void AppendText(string newText)
		{
			Show(titleText.element.text, messageText.element.text + "\r\n\r\n" + newText);
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			Localize(base.xmlLayout.XmlElement);
		}

		private void Localize(XmlElement element)
		{
			element.attributes.ContainsKey("localized");
			if (element.childElements.Count <= 0)
			{
				return;
			}
			foreach (XmlElement childElement in element.childElements)
			{
				if (!(childElement.tagType == "ChildXmlLayout"))
				{
					Localize(childElement);
				}
			}
		}
	}
}
