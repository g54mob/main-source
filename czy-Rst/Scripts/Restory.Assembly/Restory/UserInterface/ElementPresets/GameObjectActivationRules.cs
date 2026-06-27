using System;
using UnityEngine;

namespace Restory.UserInterface.ElementPresets
{
	[Serializable]
	public struct GameObjectActivationRules
	{
		[Serializable]
		public struct Rule
		{
			public GameObject GameObject;

			public bool IsActive;

			public void Apply()
			{
				if (GameObject.activeSelf != IsActive)
				{
					GameObject.SetActive(IsActive);
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
				GameObject gameObject = Rules[i].GameObject;
				CachedRules[i] = new Rule
				{
					GameObject = gameObject,
					IsActive = gameObject.activeSelf
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
