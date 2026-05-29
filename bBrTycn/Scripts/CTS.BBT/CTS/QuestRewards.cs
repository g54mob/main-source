using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(Quest))]
	public class QuestRewards : CTSBehaviour
	{
		[SerializeField]
		private Quest _quest;

		[SerializeField]
		private string _rewardDialog;

		[SerializeField]
		private int _moneyRewardAmount;

		public static event Action<int> RewardEarned;

		protected override void OnAwake()
		{
			if (!_quest)
			{
				_quest = GetComponent<Quest>();
			}
		}

		protected override void OnDisabled()
		{
			_quest.Succeeded -= OnQuestSucceeded;
		}

		protected override void OnEnabled()
		{
			_quest.Succeeded += OnQuestSucceeded;
		}

		private void OnQuestSucceeded()
		{
			EventsManager.ChangeMoney?.Invoke(Currencies.Dollars, _moneyRewardAmount);
			MonoSingleton<FeedbackHandler>.Instance.ShowFeedback(_rewardDialog, 5f);
			QuestRewards.RewardEarned?.Invoke(_moneyRewardAmount);
		}
	}
}
