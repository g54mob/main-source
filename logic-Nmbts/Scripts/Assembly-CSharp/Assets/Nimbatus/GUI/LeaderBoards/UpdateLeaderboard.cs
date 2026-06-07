using Assets.Nimbatus.Scripts.Leaderboards;
using UnityEngine;

namespace Assets.Nimbatus.GUI.LeaderBoards
{
	public class UpdateLeaderboard : MonoBehaviour
	{
		public DisplayLeaderBoard LeaderBoard;

		public void OnClick()
		{
			StartCoroutine(LeaderBoard.UpdateLeaderBoard());
		}
	}
}
