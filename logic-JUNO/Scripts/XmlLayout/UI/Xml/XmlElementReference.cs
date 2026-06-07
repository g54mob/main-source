using UnityEngine;

namespace UI.Xml
{
	public class XmlElementReference<T> : IXmlElementReference where T : MonoBehaviour
	{
		private T _element;

		private XmlLayout xmlLayout;

		private string id;

		private bool useInternalId;

		public T element
		{
			get
			{
				if (_element == null)
				{
					if (useInternalId)
					{
						_element = xmlLayout.XmlElement.GetElementByInternalId<T>(id);
					}
					else
					{
						_element = xmlLayout.GetElementById<T>(id);
					}
				}
				return _element;
			}
			protected set
			{
				_element = value;
			}
		}

		public XmlElementReference(XmlLayout xmlLayout, string id, bool useInternalId = false)
		{
			this.xmlLayout = xmlLayout;
			this.id = id;
			this.useInternalId = useInternalId;
		}

		public static implicit operator T(XmlElementReference<T> getXmlElement)
		{
			return getXmlElement.element;
		}

		public void ClearElement()
		{
			_element = null;
		}
	}
}
