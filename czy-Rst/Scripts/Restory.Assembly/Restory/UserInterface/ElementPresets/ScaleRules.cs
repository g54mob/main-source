using System;
using UnityEngine;

namespace Restory.UserInterface.ElementPresets
{
	[Serializable]
	public struct ScaleRules
	{
		[Serializable]
		public struct Rule
		{
			public Transform Transform;

			public float Scale;

			public void Apply()
			{
				Transform.localScale = Vector3.one * Scale;
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
				Transform transform = Rules[i].Transform;
				CachedRules[i] = new Rule
				{
					Transform = transform,
					Scale = transform.localScale.x
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
