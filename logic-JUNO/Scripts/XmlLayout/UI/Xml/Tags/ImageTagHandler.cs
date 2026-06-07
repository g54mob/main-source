using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class ImageTagHandler : ElementTagHandler
	{
		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<Image>();
			}
		}

		public override void SetValue(string newValue, bool fireEventHandlers = true)
		{
			base.currentXmlElement.SetAndApplyAttribute("image", newValue);
		}
	}
}
