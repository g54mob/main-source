using UnityEngine.UI;

namespace UI.Xml.CustomAttributes
{
	public abstract class SelectableAttribute : CustomXmlAttribute
	{
		protected Selectable FindElement(XmlElement fromElement, string desiredElementId)
		{
			return fromElement.xmlLayoutInstance.GetElementById<Selectable>(desiredElementId);
		}
	}
}
