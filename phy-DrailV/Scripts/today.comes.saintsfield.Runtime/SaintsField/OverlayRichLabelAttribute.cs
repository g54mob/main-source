using System.Diagnostics;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	public class OverlayRichLabelAttribute : RichLabelAttribute
	{
		public readonly bool End;

		public readonly float Padding;

		public override SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public override string GroupBy { get; }

		public OverlayRichLabelAttribute(string richTextXml, bool isCallback = false, bool end = false, float padding = 5f, string groupBy = "")
			: base(richTextXml, isCallback)
		{
			End = end;
			Padding = padding;
			GroupBy = groupBy;
		}
	}
}
