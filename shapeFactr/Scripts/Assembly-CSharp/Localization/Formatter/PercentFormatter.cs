using UnityEngine.Localization.SmartFormat.Core.Extensions;

namespace Localization.Formatter
{
	public class PercentFormatter : FormatterBase
	{
		public override string[] DefaultNames => null;

		public override bool TryEvaluateFormat(IFormattingInfo formattingInfo)
		{
			return false;
		}
	}
}
