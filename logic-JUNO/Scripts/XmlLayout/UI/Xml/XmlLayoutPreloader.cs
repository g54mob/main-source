using System.Collections.Generic;
using UnityEngine;

namespace UI.Xml
{
	public class XmlLayoutPreloader : MonoBehaviour
	{
		public void Preload()
		{
			Preload_Internal();
		}

		private void Preload_Internal()
		{
			List<string> xmlTagHandlerNames = XmlLayoutUtilities.GetXmlTagHandlerNames();
			List<string> customAttributeNames = XmlLayoutUtilities.GetCustomAttributeNames();
			foreach (string item in xmlTagHandlerNames)
			{
				XmlLayoutUtilities.LoadResource<GameObject>(XmlLayoutUtilities.GetXmlTagHandler(item).prefabPath);
			}
			foreach (string item2 in customAttributeNames)
			{
				XmlLayoutUtilities.GetCustomAttribute(item2);
			}
		}
	}
}
