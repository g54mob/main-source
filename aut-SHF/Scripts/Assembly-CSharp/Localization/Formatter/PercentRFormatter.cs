using UnityEngine.Localization.SmartFormat.Core.Extensions;

namespace Localization.Formatter
{
	public class PercentRFormatter : FormatterBase
	{
		public override string[] DefaultNames => null;

		public override bool TryEvaluateFormat(IFormattingInfo formattingInfo)
		{
			return false;
		}
	}
}
