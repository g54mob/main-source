using System;

namespace Gh.Tk
{
	public sealed class GameSettingsGameModifierAttribute : Attribute
	{
		public string PropertyName { get; private set; }

		public int DefaultValue { get; private set; }

		public string DisplayName { get; private set; }

		public bool PositiveIsEasier { get; private set; }

		public int MinValue { get; private set; }

		public int MaxValue { get; private set; }

		public int Steps { get; private set; }

		public string Category { get; set; }

		public GameDifficultyValueType ValueType { get; private set; }

		public GameDifficultyValueDisplayType ValueDisplayType { get; private set; }

		public int[] DifficultyPresets { get; set; }

		public int DisabledValue { get; private set; }

		public GameSettingsGameModifierAttribute(string propertyName, string displayName, bool[] difficultyPresets, bool defaultValue = false, string category = "General")
		{
		}

		public GameSettingsGameModifierAttribute(string propertyName, string displayName, bool positiveIsEasier, int[] difficultyPresets, int minValue = -100, int maxValue = 100, int defaultValue = 0, int disabledValue = -100, GameDifficultyValueDisplayType valueDisplayType = GameDifficultyValueDisplayType.Percentage, int steps = 0, string category = "General")
		{
		}

		public string GetDisplayValue(int value)
		{
			return null;
		}

		private string GetCustomDisplayValue(int value)
		{
			return null;
		}
	}
}
