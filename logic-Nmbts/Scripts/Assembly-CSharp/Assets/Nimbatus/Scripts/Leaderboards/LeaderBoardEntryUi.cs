using System.Globalization;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Leaderboards
{
	public class LeaderBoardEntryUi : MonoBehaviour
	{
		public UILabel NameLabel;

		public UILabel RankLabel;

		public UILabel ScoreLabel;

		private SteamLeaderboard _leaderBoard;

		public void Init(LeaderBoardEntry entry, SteamLeaderboard leaderBoard)
		{
			_leaderBoard = leaderBoard;
			bool flag = entry.UserId == SteamUser.GetSteamID().m_SteamID;
			RankLabel.text = (flag ? LabelHelper.Orange : LabelHelper.LightGrey);
			NameLabel.text = (flag ? LabelHelper.Orange : LabelHelper.LightGrey);
			ScoreLabel.text = (flag ? LabelHelper.Orange : LabelHelper.LightGrey);
			RankLabel.text += entry.Rank.ToString(CultureInfo.InvariantCulture);
			NameLabel.text += entry.UserName;
			int score = entry.Score;
			float num = 0f;
			switch (_leaderBoard.DisplayType)
			{
			case ELeaderboardDisplayType.k_ELeaderboardDisplayTypeNone:
				ScoreLabel.text += score.ToString(CultureInfo.InvariantCulture);
				break;
			case ELeaderboardDisplayType.k_ELeaderboardDisplayTypeNumeric:
				score = entry.Score;
				ScoreLabel.text += score.ToString("F2", CultureInfo.InvariantCulture);
				break;
			case ELeaderboardDisplayType.k_ELeaderboardDisplayTypeTimeSeconds:
				score = entry.Score;
				num = score;
				ScoreLabel.text += num.ToTimeString();
				break;
			case ELeaderboardDisplayType.k_ELeaderboardDisplayTypeTimeMilliSeconds:
				num = (float)entry.Score / 1000f;
				ScoreLabel.text += num.ToTimeString();
				break;
			}
		}
	}
}
