using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventVIPExit : HospitalEvent, IHospitalEventFinance, IHospitalEventReputation
	{
		public new class Config : HospitalEvent.Config
		{
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
				if (challenge.CompletionResult != Objective.CompletionType.Invalid && challenge is ChallengeVIP challengeVIP && challenge.CompletionResult != Objective.CompletionType.Abandoned && challengeVIP.VIPIcon != null)
				{
					IReward[] rewards = challengeVIP.GetRewards(challenge.CompletionResult);
					_level.HospitalEventLog.AddEvent(new HospitalEventVIPExit
					{
						_config = this,
						Date = _level.TimelineManager.CurrentGameDate,
						_icon = challengeVIP.VIPIcon,
						_VIPName = challengeVIP.VIPName,
						_completionType = challenge.CompletionResult,
						_money = RewardUtils.GetMoneyValue(rewards),
						_reputation = RewardUtils.GetReputationValue(rewards)
					});
				}
			}
		}

		private Sprite _icon;

		private string _VIPName;

		private Objective.CompletionType _completionType;

		private int _money;

		private float _reputation;

		public override Sprite GetEventIcon()
		{
			return _icon;
		}

		public override string GetDescription()
		{
			return (_completionType switch
			{
				Objective.CompletionType.Incomplete => ScriptLocalization.HospitalEvent.VIPExit_Incomplete_CS, 
				Objective.CompletionType.Abandoned => ScriptLocalization.HospitalEvent.VIPExit_Abandoned_CS, 
				Objective.CompletionType.Failed => ScriptLocalization.HospitalEvent.VIPExit_Failed_CS, 
				Objective.CompletionType.Successful => ScriptLocalization.HospitalEvent.VIPExit_Successful_CS, 
				_ => throw new ArgumentOutOfRangeException(), 
			}).Replace("{[NAME]}", _VIPName);
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
