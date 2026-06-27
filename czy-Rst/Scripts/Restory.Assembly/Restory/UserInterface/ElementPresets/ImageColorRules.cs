using System;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface.ElementPresets
{
	[Serializable]
	public struct ImageColorRules
	{
		[Serializable]
		public struct Rule
		{
			public Image Image;

			public Color Color;

			public void Apply()
			{
				Image.color = Color;
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
				Image image = Rules[i].Image;
				CachedRules[i] = new Rule
				{
					Image = image,
					Color = image.color
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
