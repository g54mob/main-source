using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventObjectiveCompleted : HospitalEvent, IHospitalEventFinance, IHospitalEventReputation
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				ObjectiveEvents objectiveEvents = _level.ObjectiveEvents;
				objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			}

			public override void UnregisterEvents()
			{
				ObjectiveEvents objectiveEvents = _level.ObjectiveEvents;
				objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Remove(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			}

			private void OnObjectiveCompleted(Objective objective, Objective.CompletionType completionType)
			{
				if (completionType != Objective.CompletionType.Invalid && !(objective is Challenge) && !(objective is StaffChallenge) && !(objective is StaffChallengeResignation) && !objective.Definition.NameLocalised.IsNull())
				{
					IReward[] rewards = objective.GetRewards(completionType);
					_level.HospitalEventLog.AddEvent(new HospitalEventObjectiveCompleted
					{
						_config = this,
						Date = _level.TimelineManager.CurrentGameDate,
						_definition = objective.Definition,
						_completionType = completionType,
						_money = RewardUtils.GetMoneyValue(rewards),
						_reputation = RewardUtils.GetReputationValue(rewards)
					});
				}
			}
		}

		private ObjectiveDefinition _definition;

		private Objective.CompletionType _completionType;

		private int _money;

		private float _reputation;

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return (_completionType switch
			{
				Objective.CompletionType.Incomplete => ScriptLocalization.HospitalEvent.ObjectiveCompleted_Incomplete_CS, 
				Objective.CompletionType.Abandoned => ScriptLocalization.HospitalEvent.ObjectiveCompleted_Abandoned_CS, 
				Objective.CompletionType.Failed => ScriptLocalization.HospitalEvent.ObjectiveCompleted_Failed_CS, 
				Objective.CompletionType.Successful => ScriptLocalization.HospitalEvent.ObjectiveCompleted_Successful_CS, 
				_ => throw new ArgumentOutOfRangeException(), 
			}).Replace("{[OBJECTIVE]}", _definition.NameLocalised.Translation);
		}

		public int GetFinanceValue()
		{
			return _money;
		}

		public bool IsFinanceValueValid()
		{
			return GetFinanceValue() != 0;
		}

		public bool ShowOnStatement()
		{
			return true;
		}

		public float GetReputationValue()
		{
			return _reputation;
		}
	}
}
