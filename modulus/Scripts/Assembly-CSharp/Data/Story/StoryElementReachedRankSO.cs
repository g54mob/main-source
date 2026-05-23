using UnityEngine;

namespace Data.Story
{
	[CreateAssetMenu(fileName = "StoryElementReachedRankSO", menuName = "Story/StoryElementReachedRankSO")]
	public class StoryElementReachedRankSO : StoryElementSO
	{
		[SerializeField]
		private OnUpdatedRankEvent _onUpdatedRankEvent;

		[SerializeField]
		private RankConfigSO _rankConfig;

		[SerializeField]
		private int _rankToReach;

		public override void Initialize()
		{
			if (_rankConfig.GetCurrentRank() >= _rankToReach)
			{
				TryExecute();
			}
			else
			{
				_onUpdatedRankEvent.Register(OnRankReached);
			}
		}

		private void OnRankReached(int currentRank)
		{
			if (currentRank >= _rankToReach - 1)
			{
				TryExecute();
				_onUpdatedRankEvent.UnRegister(OnRankReached);
			}
		}

		public override void Destroy()
		{
			_onUpdatedRankEvent.UnRegister(OnRankReached);
		}
	}
}
