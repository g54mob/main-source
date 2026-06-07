using System.Reflection;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public abstract class InputBaseTagHandler : ElementTagHandler
	{
		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			base.ApplyAttributes(attributesToApply);
			Text componentInChildren = base.currentInstanceTransform.GetComponentInChildren<Text>();
			if (attributesToApply.ContainsKey("textColor"))
			{
				componentInChildren.color = attributesToApply["textcolor"].ToColor(base.currentXmlLayoutInstance);
			}
			if (!attributesToApply.ContainsKey("backgroundColor"))
			{
				return;
			}
			PropertyInfo property = primaryComponent.GetType().GetProperty("targetGraphic");
			if (property != null)
			{
				Image image = property.GetValue(primaryComponent, XmlLayoutUtilities.BindingFlags, null, null, null) as Image;
				if (image != null)
				{
					image.color = attributesToApply["backgroundColor"].ToColor(base.currentXmlLayoutInstance);
				}
			}
		}
	}
}
