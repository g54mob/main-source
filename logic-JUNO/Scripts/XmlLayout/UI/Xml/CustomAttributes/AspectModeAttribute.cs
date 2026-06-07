using System;
using UnityEngine.UI;

namespace UI.Xml.CustomAttributes
{
	public class AspectModeAttribute : AspectRatioFitterAttribute
	{
		public override string ValueDataType => string.Join(",", Enum.GetNames(typeof(AspectRatioFitter.AspectMode)));

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary attributes)
		{
			GetAspectRatioFitter(xmlElement).aspectMode = (AspectRatioFitter.AspectMode)Enum.Parse(typeof(AspectRatioFitter.AspectMode), value, ignoreCase: true);
		}
	}
}
