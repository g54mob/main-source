using UnityEngine.UI;

namespace UI.Xml.CustomAttributes
{
	public abstract class AspectRatioFitterAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override eAttributeGroup AttributeGroup => eAttributeGroup.RectTransform;

		protected AspectRatioFitter GetAspectRatioFitter(XmlElement element)
		{
			AspectRatioFitter aspectRatioFitter = element.GetComponent<AspectRatioFitter>();
			if (aspectRatioFitter == null)
			{
				aspectRatioFitter = element.gameObject.AddComponent<AspectRatioFitter>();
			}
			return aspectRatioFitter;
		}
	}
}
