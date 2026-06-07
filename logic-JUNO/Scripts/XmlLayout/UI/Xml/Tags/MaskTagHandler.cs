using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class MaskTagHandler : ElementTagHandler
	{
		public override MonoBehaviour primaryComponent => base.currentInstanceTransform.GetComponent<Mask>();
	}
}
