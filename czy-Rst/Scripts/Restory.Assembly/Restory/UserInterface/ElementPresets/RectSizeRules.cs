using System;
using UnityEngine;

namespace Restory.UserInterface.ElementPresets
{
	[Serializable]
	public struct RectSizeRules
	{
		[Serializable]
		public struct Rule
		{
			public RectTransform RectTransform;

			public Vector2 Size;

			public void Apply()
			{
				RectTransform.sizeDelta = Size;
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
				RectTransform rectTransform = Rules[i].RectTransform;
				CachedRules[i] = new Rule
				{
					RectTransform = rectTransform,
					Size = rectTransform.rect.size
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
