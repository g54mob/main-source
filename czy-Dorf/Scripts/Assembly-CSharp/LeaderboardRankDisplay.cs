using Dorfromantik;
using TMPro;
using UnityEngine;

public class LeaderboardRankDisplay : MonoBehaviour
{
	[SerializeField]
	private LeaderboardManager leaderboardManager;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private TextMeshProUGUI leaderboardRankLabel;

	private void Start()
	{
		UpdateLeaderboardRank(initial: true);
		rewardSystem.OnLeaderboardRankChanged += UpdateLeaderboardRankFromRewardSystem;
	}

	public void RequestCurrentRank()
	{
		rewardSystem.RequestLeaderboardRankUpdate();
		UpdateLeaderboardRank(initial: false);
	}

	private void UpdateLeaderboardRankFromRewardSystem()
	{
		UpdateLeaderboardRank(initial: false);
	}

	private void UpdateLeaderboardRank(bool initial)
	{
		LeaderboardType currentLeaderboard = leaderboardManager.GetCurrentLeaderboard(initial);
		if (!(currentLeaderboard == null))
		{
			if (rewardSystem.GetRank(currentLeaderboard) > 0)
			{
				DisplayRank(rewardSystem.GetRank(currentLeaderboard));
			}
			else if (currentLeaderboard != null)
			{
				DisplayRank(PlayerPrefsAccessor.GetInt(currentLeaderboard.GetPlayerPrefsRankKey(), -1));
			}
		}
	}

	private void DisplayRank(int newRank)
	{
		leaderboardRankLabel.text = ((newRank > 0) ? $"# {newRank}" : "-\u00a0 \u00a0 \u00a0 \u00a0");
	}

	private void OnDestroy()
	{
		rewardSystem.OnLeaderboardRankChanged -= UpdateLeaderboardRankFromRewardSystem;
	}
}
