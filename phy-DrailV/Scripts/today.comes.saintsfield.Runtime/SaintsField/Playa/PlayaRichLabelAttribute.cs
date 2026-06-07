using System;
using System.Diagnostics;

namespace SaintsField.Playa
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class PlayaRichLabelAttribute : Attribute, IPlayaAttribute
	{
		public readonly string RichTextXml;

		public readonly bool IsCallback;

		public PlayaRichLabelAttribute(string richTextXml, bool isCallback = false)
		{
			RichTextXml = richTextXml;
			IsCallback = isCallback;
		}
	}
}
