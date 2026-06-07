using UnityEngine.UI;

namespace UI.Xml.CustomAttributes
{
	public class ContentSizeFitterAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			ContentSizeFitter contentSizeFitter = xmlElement.GetComponent<ContentSizeFitter>();
			if (contentSizeFitter == null)
			{
				contentSizeFitter = xmlElement.gameObject.AddComponent<ContentSizeFitter>();
			}
			switch (value)
			{
			case "vertical":
				contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
				contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
				break;
			case "horizontal":
				contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
				contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.Unconstrained;
				break;
			case "both":
				contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
				contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
				break;
			default:
				contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.Unconstrained;
				contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
				break;
			}
		}
	}
}
