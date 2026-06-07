using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class SetActiveTournament : MonoBehaviour
	{
		public ETournamentType Tournament;

		public void OnClick()
		{
			GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.SetActiveTournament(Tournament);
		}
	}
}
