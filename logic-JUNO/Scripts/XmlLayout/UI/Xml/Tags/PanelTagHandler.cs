using UnityEngine;

namespace UI.Xml.Tags
{
	public class PanelTagHandler : ElementTagHandler
	{
		public override MonoBehaviour primaryComponent => base.currentInstanceTransform.GetComponent<SimpleLayoutGroup>();

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			if (base.currentXmlElement.HasAttribute("image") && !base.currentXmlElement.HasAttribute("raycastTarget"))
			{
				attributesToApply.Add("raycastTarget", "true");
				base.currentXmlElement.SetAttribute("raycastTarget", "true");
			}
			base.ApplyAttributes(attributesToApply);
			RectOffset value = attributesToApply.GetValue<RectOffset>("padding");
			if (value != null)
			{
				SimpleLayoutGroup obj = primaryComponent as SimpleLayoutGroup;
				obj.padding = value;
				obj.enabled = true;
			}
		}
	}
}
