using System.Linq;
using UnityEngine.UI;

namespace UI.Xml.CustomAttributes
{
	public class AspectRatioAttribute : AspectRatioFitterAttribute
	{
		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary attributes)
		{
			AspectRatioFitter aspectRatioFitter = GetAspectRatioFitter(xmlElement);
			aspectRatioFitter.aspectRatio = ParseAspectRatioStringValue(value);
			XmlLayoutTimer.AtEndOfFrame(delegate
			{
				aspectRatioFitter.aspectRatio = ParseAspectRatioStringValue(value);
			}, xmlElement);
		}

		protected float ParseAspectRatioStringValue(string value)
		{
			float result = 1f;
			try
			{
				if (!string.IsNullOrEmpty(value) && !float.TryParse(value, out result))
				{
					float[] array = (from v in value.Split(':')
						select float.Parse(v)).ToArray();
					result = array[0] / array[1];
				}
			}
			catch
			{
			}
			return result;
		}
	}
}
