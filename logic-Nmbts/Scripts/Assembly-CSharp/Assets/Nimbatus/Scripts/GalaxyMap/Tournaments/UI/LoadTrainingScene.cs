using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class LoadTrainingScene : MonoBehaviour
	{
		public void OnClick()
		{
			GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.IsInTraining = true;
			NimbatusSceneManager.LoadScene("TournamentTrainingScene");
		}
	}
}
