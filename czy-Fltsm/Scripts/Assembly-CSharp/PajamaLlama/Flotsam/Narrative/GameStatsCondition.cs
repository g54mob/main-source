using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class GameStatsCondition : IScenarioTriggerableCondition
	{
		private enum GameStat
		{
			ActorStat = 0
		}

		private enum Condition
		{
			StatIsSmallerThanValue = 0,
			StatIsSmallerThanOrEqualsValue = 1,
			StatIsLargerThanValue = 2,
			StatIsLargerThanOrEqualsValue = 3,
			StatEqualsValue = 4
		}

		[SerializeField]
		private GameStat _stat;

		[SerializeField]
		[ConditionalEnumHide("_stat", 0, false, HideInInspector = true)]
		private ActorType _actorType;

		[SerializeField]
		[ConditionalEnumHide("_stat", 0, false, HideInInspector = true)]
		private ActorStat _actorStat;

		[SerializeField]
		private int _value;

		[SerializeField]
		private Condition _condition;

		public bool IsMet()
		{
			int stat = GetStat();
			switch (_condition)
			{
			case Condition.StatIsSmallerThanValue:
				return stat < _value;
			case Condition.StatIsSmallerThanOrEqualsValue:
				return stat <= _value;
			case Condition.StatIsLargerThanValue:
				return stat > _value;
			case Condition.StatIsLargerThanOrEqualsValue:
				return stat >= _value;
			case Condition.StatEqualsValue:
				return stat == _value;
			default:
				Debug.LogException(new NotImplementedException(_condition.ToString()));
				return false;
			}
		}

		private int GetStat()
		{
			if (_stat == GameStat.ActorStat)
			{
				return GameStatsManager.GetActorStat(_actorType, _actorStat);
			}
			return 0;
		}
	}
}
