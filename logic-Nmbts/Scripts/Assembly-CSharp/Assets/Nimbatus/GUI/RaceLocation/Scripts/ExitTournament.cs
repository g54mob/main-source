using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap.Tournaments;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.RaceLocation.Scripts
{
	public class ExitTournament : MonoBehaviour
	{
		public void OnClick()
		{
			NimbatusSceneManager.LoadScene("CompetitiveModeScene");
			GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.SetActiveTournament(ETournamentType.None);
		}
	}
}
