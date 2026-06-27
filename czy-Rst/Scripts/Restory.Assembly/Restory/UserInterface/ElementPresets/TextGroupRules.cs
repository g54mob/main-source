using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface.ElementPresets
{
	[Serializable]
	public struct TextGroupRules
	{
		[Serializable]
		public struct Rule
		{
			public TextMeshProUGUI TextMeshPro;

			public Text Text;

			public Color Color;

			public FontStyles FontStyle;

			public void Apply()
			{
				if ((bool)TextMeshPro)
				{
					TextMeshPro.color = Color;
					TextMeshPro.fontStyle = FontStyle;
				}
				if ((bool)Text)
				{
					Text.color = Color;
				}
			}

			public void CacheCurrentValues()
			{
				Color = TextMeshPro.color;
				FontStyle = TextMeshPro.fontStyle;
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
				TextMeshProUGUI textMeshPro = Rules[i].TextMeshPro;
				Text text = Rules[i].Text;
				CachedRules[i] = new Rule
				{
					TextMeshPro = textMeshPro,
					Text = text,
					Color = (textMeshPro ? textMeshPro.color : text.color)
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
