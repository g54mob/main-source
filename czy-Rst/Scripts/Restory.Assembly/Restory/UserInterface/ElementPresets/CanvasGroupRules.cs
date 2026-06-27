using System;
using UnityEngine;

namespace Restory.UserInterface.ElementPresets
{
	[Serializable]
	public struct CanvasGroupRules
	{
		[Serializable]
		public struct Rule
		{
			public CanvasGroup CanvasGroup;

			public float Alpha;

			public bool Interactable;

			public bool BlocksRaycasts;

			public bool IgnoreParentGroups;

			public void Apply()
			{
				CanvasGroup.alpha = Alpha;
				CanvasGroup.interactable = Interactable;
				CanvasGroup.blocksRaycasts = BlocksRaycasts;
				CanvasGroup.ignoreParentGroups = IgnoreParentGroups;
			}

			public void CacheCurrentValues()
			{
				Alpha = CanvasGroup.alpha;
				Interactable = CanvasGroup.interactable;
				BlocksRaycasts = CanvasGroup.blocksRaycasts;
				IgnoreParentGroups = CanvasGroup.ignoreParentGroups;
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
			for (int i = 0; i < CachedRules.Length; i++)
			{
				CanvasGroup canvasGroup = Rules[i].CanvasGroup;
				CachedRules[i] = new Rule
				{
					CanvasGroup = canvasGroup,
					Alpha = canvasGroup.alpha,
					Interactable = canvasGroup.interactable,
					BlocksRaycasts = canvasGroup.blocksRaycasts,
					IgnoreParentGroups = canvasGroup.ignoreParentGroups
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
