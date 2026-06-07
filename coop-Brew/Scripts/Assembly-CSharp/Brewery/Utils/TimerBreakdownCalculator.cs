using Brewery.Buffs;
using Brewery.Skills;

namespace Brewery.Utils
{
	public static class TimerBreakdownCalculator
	{
		private const float MIN_DURATION = 0.5f;

		public static TimerBreakdown CalculateBreakdown(float baseDuration, ulong clientId, SkillType skillType, BuffType buffType)
		{
			return default(TimerBreakdown);
		}

		public static string FormatBreakdown(TimerBreakdown breakdown)
		{
			return null;
		}

		public static string FormatStepBreakdown(string stepName, TimerBreakdown breakdown)
		{
			return null;
		}

		public static string FormatTotalSummary(MultiStepSummary summary)
		{
			return null;
		}

		public static string FormatSavingsSummary(MultiStepSummary summary)
		{
			return null;
		}

		public static MultiStepSummary CalculateMultiStepSummary(ulong clientId, params StepDefinition[] steps)
		{
			return default(MultiStepSummary);
		}
	}
}
