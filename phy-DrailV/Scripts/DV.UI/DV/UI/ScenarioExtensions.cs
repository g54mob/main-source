using System.Collections.Generic;
using DV.Localization;
using DV.Scenarios.Common;

namespace DV.UI
{
	public static class ScenarioExtensions
	{
		private static readonly Dictionary<string, string> LOCALIZATION_KEYS = new Dictionary<string, string>();

		public static string ToLocalizedString(this IScenario scenario)
		{
			if (scenario.IsReadOnly && LOCALIZATION_KEYS.TryGetValue(scenario.Name, out var value))
			{
				return LocalizationAPI.L(value);
			}
			return scenario.Name;
		}
	}
}
