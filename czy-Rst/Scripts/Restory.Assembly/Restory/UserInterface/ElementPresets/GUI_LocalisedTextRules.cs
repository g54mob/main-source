using System;
using Restory.Data.Localization;

namespace Restory.UserInterface.ElementPresets
{
	[Serializable]
	public struct GUI_LocalisedTextRules
	{
		[Serializable]
		public struct Rule
		{
			public GUI_LocalisedText LocalisedText;

			[LocalizationKey]
			public string LocalizationKey;

			public void Apply()
			{
				if ((bool)LocalisedText)
				{
					LocalisedText.LocalizationID = LocalizationKey;
				}
			}
		}

		public Rule[] Rules;

		private Rule[] CachedRules;

		public bool IsEmpty
		{
			get
			{
				if (Rules == null || Rules.Length == 0)
				{
					if (CachedRules != null)
					{
						return CachedRules.Length == 0;
					}
					return true;
				}
				return false;
			}
		}

		public void Apply()
		{
			if (Rules != null)
			{
				if (CachedRules == null)
				{
					Cache();
				}
				Rule[] rules = Rules;
				foreach (Rule rule in rules)
				{
					rule.Apply();
				}
			}
		}

		private void Cache()
		{
			if (CachedRules == null || CachedRules.Length == 0)
			{
				CachedRules = new Rule[Rules.Length];
			}
			for (int i = 0; i < CachedRules.Length && i < Rules.Length; i++)
			{
				GUI_LocalisedText localisedText = Rules[i].LocalisedText;
				CachedRules[i] = new Rule
				{
					LocalisedText = localisedText,
					LocalizationKey = localisedText.LocalizationID
				};
			}
		}

		public void Revert()
		{
			if (CachedRules != null)
			{
				Rule[] cachedRules = CachedRules;
				foreach (Rule rule in cachedRules)
				{
					rule.Apply();
				}
			}
		}
	}
}
