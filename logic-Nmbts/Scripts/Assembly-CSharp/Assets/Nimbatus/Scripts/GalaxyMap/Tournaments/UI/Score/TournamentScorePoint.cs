using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI.Score
{
	public class TournamentScorePoint : MonoBehaviour
	{
		public UITexture ScorePoint;

		public UITexture Border;

		public Color ActiveColor;

		public Color InActiveColor;

		public void Init(bool scored)
		{
			ScorePoint.gameObject.SetActive(scored);
			ScorePoint.color = (scored ? ActiveColor : InActiveColor);
			Border.color = (scored ? ActiveColor : InActiveColor);
		}
	}
}
