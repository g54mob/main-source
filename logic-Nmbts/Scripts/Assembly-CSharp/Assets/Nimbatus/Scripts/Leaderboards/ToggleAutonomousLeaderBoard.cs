using Assets.Nimbatus.Scripts.GalaxyMap.Race;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Leaderboards
{
	public class ToggleAutonomousLeaderBoard : MonoBehaviour
	{
		public DisplayLeaderBoard LeaderBoard;

		public UITexture Background;

		public Color NotSelectedColor;

		public Color SelectedColor;

		public bool Autonomous;

		public void Update()
		{
			if (LeaderBoard.AutonomousLeaderBoard == Autonomous)
			{
				Background.color = SelectedColor;
			}
			else
			{
				Background.color = NotSelectedColor;
			}
		}

		public void OnClick()
		{
			LeaderBoard.ToggleAutonomousMode(Autonomous);
			BaseSingleton<RaceTrackManager>.Instance.Autonomous = Autonomous;
		}
	}
}
