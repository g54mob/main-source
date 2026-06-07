using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI.Score
{
	public class TournamentScoreDisplay : SerializedMonoBehaviour
	{
		public TournamentScorePoint PointPrefab;

		public UITexture LineTexture;

		public float PointDistance;

		public void Init(TournamentUI manager)
		{
			float num = PointDistance * 9f;
			Vector3 vector = new Vector3(0f - num / 2f, 0f, 0f);
			LineTexture.fillAmount = 1f / 9f * (float)(GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.GetCurrentScore() - 1);
			for (int i = 0; i < 10; i++)
			{
				Vector3 localPosition = vector + new Vector3((float)i * PointDistance, 0f, 0f);
				TournamentScorePoint tournamentScorePoint = Object.Instantiate(PointPrefab);
				tournamentScorePoint.transform.SetParent(base.transform);
				tournamentScorePoint.transform.localPosition = localPosition;
				tournamentScorePoint.transform.localScale = Vector3.one;
				tournamentScorePoint.Init(i < GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.GetCurrentScore());
			}
		}
	}
}
