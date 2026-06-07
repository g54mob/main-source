using Assets.Nimbatus.Scripts.Common.Helpers;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Leaderboards
{
	public class SwitchLeaderBoardMode : MonoBehaviour
	{
		public DisplayLeaderBoard LeaderBoard;

		public UILabel Label;

		public void Start()
		{
		}

		public void OnClick()
		{
			LeaderBoard.ToggleFilterMode();
		}

		public void Update()
		{
			if (LeaderBoard != null)
			{
				Label.text = LeaderBoard.Filter.ToLocalizationString();
			}
		}
	}
}
