using System.Collections.Generic;
using DV.Localization;
using DV.Scenarios.Common;

namespace DV.UI
{
	public static class DifficultyExtensions
	{
		public static readonly Dictionary<string, string> LOCALIZATION_KEYS = new Dictionary<string, string>
		{
			{ "Standard", "difficulty/standard" },
			{ "Realistic", "difficulty/realistic" },
			{ "Comfort", "difficulty/comfort" },
			{ "Custom", "difficulty/custom" },
			{ "Standard Sandbox", "difficulty/standard_sandbox" }
		};

		public static string ToLocalizedString(this IDifficulty difficulty)
		{
			if (difficulty.IsReadOnly && LOCALIZATION_KEYS.TryGetValue(difficulty.Name, out var value))
			{
				return LocalizationAPI.L(value);
			}
			return difficulty.Name;
		}
	}
}
