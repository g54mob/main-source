using System;
using UnityEngine;

namespace TH20
{
	public class HospitalEventAwardWon : HospitalEvent, IHospitalEventFinance, IHospitalEventStaff, IHospitalEventReputation
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				HospitalAwardsManager hospitalAwardsManager = _level.HospitalAwardsManager;
				hospitalAwardsManager.OnAwardWon = (Action<HospitalAwardsManager.AwardType, HospitalAwardsManager.AwardInstanceData, CharacterName>)Delegate.Combine(hospitalAwardsManager.OnAwardWon, new Action<HospitalAwardsManager.AwardType, HospitalAwardsManager.AwardInstanceData, CharacterName>(OnAwardWon));
			}

			public override void UnregisterEvents()
			{
				HospitalAwardsManager hospitalAwardsManager = _level.HospitalAwardsManager;
				hospitalAwardsManager.OnAwardWon = (Action<HospitalAwardsManager.AwardType, HospitalAwardsManager.AwardInstanceData, CharacterName>)Delegate.Remove(hospitalAwardsManager.OnAwardWon, new Action<HospitalAwardsManager.AwardType, HospitalAwardsManager.AwardInstanceData, CharacterName>(OnAwardWon));
			}

			private void OnAwardWon(HospitalAwardsManager.AwardType awardType, HospitalAwardsManager.AwardInstanceData data, CharacterName staffName)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventAwardWon
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_successText = _level.HospitalAwardsManager.GetEventLogSuccesssText(awardType),
					_staffName = staffName,
					_money = RewardUtils.GetMoneyValue(data.HospitalRewards),
					_reputation = RewardUtils.GetReputationValue(data.HospitalRewards)
				});
			}
		}

		private string _successText;

		private CharacterName _staffName;

		private int _money;

		private float _reputation;

		public override bool HasExpired(GameDate currentDate)
		{
			return false;
		}

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return _successText;
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

		public CharacterName GetStaffName()
		{
			return _staffName;
		}

		public float GetReputationValue()
		{
			return _reputation;
		}
	}
}
