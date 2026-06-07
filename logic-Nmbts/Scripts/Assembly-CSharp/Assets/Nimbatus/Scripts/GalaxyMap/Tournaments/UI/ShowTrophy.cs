using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class ShowTrophy : SerializedMonoBehaviour
	{
		public List<GameObject> Trophies;

		public void Update()
		{
			if (GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament != null)
			{
				int currentScore = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.GetCurrentScore();
				for (int i = 0; i < Trophies.Count; i++)
				{
					Trophies[i].SetActive(i == currentScore);
				}
			}
		}
	}
}
