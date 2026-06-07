using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class EnterTournamentOnStart : MonoBehaviour
	{
		public ETournamentType Tournament;

		public string Scene;

		public void Awake()
		{
			GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.SetActiveTournament(Tournament);
			NimbatusSceneManager.LoadScene(Scene);
		}
	}
}
