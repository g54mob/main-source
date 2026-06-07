using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Reached Rank", fileName = "ReachRank", order = 4)]
	public class ReachRankedSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private OnUpdatedRankEvent _onUpdatedRankEvent;

		[SerializeField]
		private RankConfigSO _rankConfig;

		[SerializeField]
		private int _rankToReach;

		private bool _init;

		private bool _rankWasReached;

		public override bool IsValid()
		{
			if (!_init)
			{
				if (_rankConfig.GetCurrentRank() >= _rankToReach)
				{
					_rankWasReached = true;
				}
				else
				{
					_onUpdatedRankEvent.Register(OnRankReached);
				}
				_init = true;
			}
			return _rankWasReached;
		}

		private void OnRankReached(int currentRank)
		{
			if (currentRank >= _rankToReach - 1)
			{
				_rankWasReached = true;
			}
		}

		public override void Reset()
		{
			_init = false;
			_rankWasReached = false;
			_onUpdatedRankEvent.UnRegister(OnRankReached);
		}
	}
}
