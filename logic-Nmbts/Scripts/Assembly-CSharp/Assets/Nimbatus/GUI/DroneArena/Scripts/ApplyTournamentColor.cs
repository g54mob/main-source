using System.Collections.Generic;
using Assets.Nimbatus.Scripts.GalaxyMap.Tournaments;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneArena.Scripts
{
	public class ApplyTournamentColor : MonoBehaviour
	{
		public List<UITexture> Textures = new List<UITexture>();

		public List<UILabel> Labels = new List<UILabel>();

		public void Start()
		{
			Textures.ForEach(delegate(UITexture t)
			{
				t.color = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.UiColor;
			});
			Labels.ForEach(delegate(UILabel t)
			{
				t.color = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.UiColor;
			});
		}
	}
}
