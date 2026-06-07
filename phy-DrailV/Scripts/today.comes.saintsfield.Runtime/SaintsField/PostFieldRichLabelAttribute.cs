using System;
using System.Diagnostics;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field)]
	public class PostFieldRichLabelAttribute : RichLabelAttribute
	{
		public readonly float Padding;

		public override SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public override string GroupBy { get; }

		public PostFieldRichLabelAttribute(string richTextXml, bool isCallback = false, float padding = 5f, string groupBy = "")
			: base(richTextXml, isCallback)
		{
			Padding = padding;
			GroupBy = groupBy;
		}
	}
}
