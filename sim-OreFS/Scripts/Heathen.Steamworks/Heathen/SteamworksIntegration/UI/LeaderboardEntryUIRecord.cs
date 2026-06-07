using TMPro;
using UnityEngine;

namespace Heathen.SteamworksIntegration.UI
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/unity-engine/ui-components/leaderboard-entry-ui-record")]
	public class LeaderboardEntryUIRecord : MonoBehaviour, ILeaderboardEntryDisplay
	{
		[SerializeField]
		private SetUserAvatar avatar;

		[SerializeField]
		private SetUserName userName;

		[SerializeField]
		private TextMeshProUGUI score;

		[SerializeField]
		private TextMeshProUGUI rank;

		private LeaderboardEntry _entry;

		public LeaderboardEntry Entry
		{
			get
			{
				return _entry;
			}
			set
			{
				SetEntry(value);
			}
		}

		private void SetEntry(LeaderboardEntry entry)
		{
			avatar.UserData = entry.User;
			userName.UserData = entry.User;
			score.text = entry.Score.ToString();
			rank.text = entry.Rank.ToString();
			_entry = entry;
		}
	}
}
