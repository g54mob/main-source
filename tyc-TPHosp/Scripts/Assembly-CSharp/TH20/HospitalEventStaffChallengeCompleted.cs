using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventStaffChallengeCompleted : HospitalEventStaff, IHospitalEventFinance, IHospitalEventReputation
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
				if (objective.CompletionResult != Objective.CompletionType.Invalid)
				{
					StaffChallenge staffChallenge = objective as StaffChallenge;
					StaffChallengeResignation staffChallengeResignation = objective as StaffChallengeResignation;
					if (staffChallenge != null)
					{
						IReward[] rewards = staffChallenge.GetRewards(staffChallenge.CompletionResult);
						_level.HospitalEventLog.AddEvent(new HospitalEventStaffChallengeCompleted(staffChallenge.Staff, _level.TimelineManager.CurrentGameDate)
						{
							_config = this,
							_staffName = staffChallenge.Staff.CharacterName,
							_completionType = staffChallenge.CompletionResult,
							_money = RewardUtils.GetMoneyValue(rewards),
							_reputation = RewardUtils.GetReputationValue(rewards)
						});
					}
					else if (staffChallengeResignation != null)
					{
						IReward[] rewards2 = staffChallengeResignation.GetRewards(staffChallengeResignation.CompletionResult);
						_level.HospitalEventLog.AddEvent(new HospitalEventStaffChallengeCompleted(staffChallengeResignation.Staff, _level.TimelineManager.CurrentGameDate)
						{
							_config = this,
							_staffName = staffChallengeResignation.Staff.CharacterName,
							_completionType = staffChallengeResignation.CompletionResult,
							_money = RewardUtils.GetMoneyValue(rewards2),
							_reputation = RewardUtils.GetReputationValue(rewards2)
						});
					}
				}
			}
		}

		private CharacterName _staffName;

		private Objective.CompletionType _completionType;

		private int _money;

		private float _reputation;

		public HospitalEventStaffChallengeCompleted(Staff staff, GameDate expiryDate)
			: base(staff, expiryDate)
		{
		}

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return LocalisedString.Replace(_completionType switch
			{
				Objective.CompletionType.Incomplete => ScriptLocalization.HospitalEvent.StaffChallengeCompleted_Incomplete_CS, 
				Objective.CompletionType.Abandoned => ScriptLocalization.HospitalEvent.StaffChallengeCompleted_Abandoned_CS, 
				Objective.CompletionType.Failed => ScriptLocalization.HospitalEvent.StaffChallengeCompleted_Failed_CS, 
				Objective.CompletionType.Successful => ScriptLocalization.HospitalEvent.StaffChallengeCompleted_Successful_CS, 
				_ => throw new ArgumentOutOfRangeException(), 
			}, new SubPair[1]
			{
				new SubPair("{[STAFF]}", _staffName.GetCharacterName())
			});
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

		public override CharacterName GetStaffName()
		{
			return _staffName;
		}
	}
}
