using System;
using System.Linq;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventEpidemicEnd : HospitalEvent, IHospitalEventFinance, IHospitalEventReputation
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
				if (challenge.CompletionResult != Objective.CompletionType.Invalid && challenge is ChallengeEpidemic)
				{
					IReward[] rewards = challenge.GetRewards(challenge.CompletionResult);
					int num = rewards?.OfType<IRewardChallenge>().Sum((IRewardChallenge reward) => reward.GetCashPrize(challenge)) ?? 0;
					_level.HospitalEventLog.AddEvent(new HospitalEventEpidemicEnd
					{
						_config = this,
						Date = _level.TimelineManager.CurrentGameDate,
						_completionType = challenge.CompletionResult,
						_money = RewardUtils.GetMoneyValue(rewards) + num,
						_reputation = RewardUtils.GetReputationValue(rewards)
					});
				}
			}
		}

		private Objective.CompletionType _completionType;

		private int _money;

		private float _reputation;

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return _completionType switch
			{
				Objective.CompletionType.Incomplete => ScriptLocalization.HospitalEvent.EpidemicEnd_Incomplete_CS, 
				Objective.CompletionType.Abandoned => ScriptLocalization.HospitalEvent.EpidemicEnd_Abandoned_CS, 
				Objective.CompletionType.Failed => ScriptLocalization.HospitalEvent.EpidemicEnd_Failed_CS, 
				Objective.CompletionType.Successful => ScriptLocalization.HospitalEvent.EpidemicEnd_Successful_CS, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
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
