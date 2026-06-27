using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Restory.UserInterface.ElementPresets
{
	[Serializable]
	public struct MonoBehaviourActivationRules
	{
		[Serializable]
		public struct Rule
		{
			public GameObject Target;

			public MonoBehaviour MonoBehaviour;

			public bool Enabled;

			public void Apply()
			{
				MonoBehaviour.enabled = Enabled;
			}

			private void OnTargetChanged()
			{
				if (Target == null || (MonoBehaviour != null && MonoBehaviour.gameObject != Target))
				{
					MonoBehaviour = null;
				}
			}

			private IList<ValueDropdownItem<MonoBehaviour>> GetComponents()
			{
				if (Target == null)
				{
					return new ValueDropdownItem<MonoBehaviour>[1]
					{
						new ValueDropdownItem<MonoBehaviour>("Null", null)
					};
				}
				Target.GetComponents<MonoBehaviour>();
				List<ValueDropdownItem<MonoBehaviour>> list = new List<ValueDropdownItem<MonoBehaviour>>();
				MonoBehaviour[] components = Target.GetComponents<MonoBehaviour>();
				foreach (MonoBehaviour monoBehaviour in components)
				{
					list.Add(new ValueDropdownItem<MonoBehaviour>(monoBehaviour.GetType().Name, monoBehaviour));
				}
				return list;
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
				MonoBehaviour monoBehaviour = Rules[i].MonoBehaviour;
				CachedRules[i] = new Rule
				{
					MonoBehaviour = monoBehaviour,
					Enabled = monoBehaviour.enabled
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
