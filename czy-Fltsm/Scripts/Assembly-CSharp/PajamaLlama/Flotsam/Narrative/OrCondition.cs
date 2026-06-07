using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class OrCondition : IScenarioTriggerableCondition
	{
		[Serializable]
		private struct ConditionGroup
		{
			[SerializeReference]
			[InstantiateSerializeReference]
			private IScenarioTriggerableCondition[] _conditions;

			public bool IsMet()
			{
				IScenarioTriggerableCondition[] conditions = _conditions;
				for (int i = 0; i < conditions.Length; i++)
				{
					if (!conditions[i].IsMet())
					{
						return false;
					}
				}
				return true;
			}
		}

		[SerializeField]
		private ConditionGroup[] _conditionGroups;

		public bool IsMet()
		{
			ConditionGroup[] conditionGroups = _conditionGroups;
			foreach (ConditionGroup conditionGroup in conditionGroups)
			{
				if (conditionGroup.IsMet())
				{
					return true;
				}
			}
			return false;
		}
	}
}
