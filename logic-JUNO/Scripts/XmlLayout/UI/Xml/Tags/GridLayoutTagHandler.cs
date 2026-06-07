using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class GridLayoutTagHandler : ElementTagHandler
	{
		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<GridLayoutGroup>();
			}
		}
	}
}
