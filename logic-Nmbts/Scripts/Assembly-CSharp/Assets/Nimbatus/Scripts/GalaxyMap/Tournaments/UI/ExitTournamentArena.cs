using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class ExitTournamentArena : MonoBehaviour
	{
		public void OnClick()
		{
			if (GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.IsTournamentRunning())
			{
				GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.IncreaseLoss();
			}
			NimbatusSceneManager.GoToBookmarkedScene();
		}
	}
}
