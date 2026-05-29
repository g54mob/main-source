using UnityEngine.Localization.SmartFormat.Core.Extensions;

namespace Localization.Formatter
{
	public class PlusplusFormatter : FormatterBase
	{
		public override string[] DefaultNames => null;

		public override bool TryEvaluateFormat(IFormattingInfo formattingInfo)
		{
			return false;
		}

		public static string Ppp(int value)
		{
			return null;
		}
	}
}
