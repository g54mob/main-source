using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public abstract class LayoutBaseTagHandler : ElementTagHandler
	{
		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<HorizontalOrVerticalLayoutGroup>();
			}
		}
	}
}
