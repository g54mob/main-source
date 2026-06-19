using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventChallengeCompleted : HospitalEvent, IHospitalEventFinance, IHospitalEventReputation
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				ChallengeEvents challengeEvents = _level.ChallengeEvents;
				challengeEvents.OnChallengeCompleted = (Action<Challenge>)Delegate.Combine(challengeEvents.OnChallengeCompleted, new Action<Challenge>(OnChallengeCompleted));
			}

			public override void UnregisterEvents()
			{
				ChallengeEvents challengeEvents = _level.ChallengeEvents;
				challengeEvents.OnChallengeCompleted = (Action<Challenge>)Delegate.Remove(challengeEvents.OnChallengeCompleted, new Action<Challenge>(OnChallengeCompleted));
			}

			private void OnChallengeCompleted(Challenge challenge)
			{
				if (challenge.CompletionResult != Objective.CompletionType.Invalid && !(challenge is ChallengeEpidemic) && !(challenge is ChallengeEarthquake) && !(challenge is ChallengeVIP))
				{
					IReward[] rewards = challenge.GetRewards(challenge.CompletionResult);
					_level.HospitalEventLog.AddEvent(new HospitalEventChallengeCompleted
					{
						_config = this,
						Date = _level.TimelineManager.CurrentGameDate,
						_definition = challenge.Definition,
						_completionType = challenge.CompletionResult,
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
