using TMPro;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration.UI
{
	public class LeaderboardUserEntry : MonoBehaviour
	{
		public LeaderboardObject leaderboard;

		public TextMeshProUGUI score;

		public TextMeshProUGUI rank;

		public LeaderboardEntry Entry { get; private set; }

		private void Start()
		{
			leaderboard.UserEntryUpdated.AddListener(Refresh);
			Invoke("Refresh", 1.5f);
		}

		public void Refresh()
		{
			leaderboard.GetUserEntry(delegate(LeaderboardEntry entry, bool error)
			{
				if (!error && entry != null)
				{
					Refresh(entry);
				}
			});
		}

		public void Refresh(LeaderboardEntry entry)
		{
			if (entry != null)
			{
				Entry = entry;
				score.text = entry.Score.ToString();
				rank.text = entry.Rank.ToString();
			}
		}
	}
}
