using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class ShowTournamentDrone : MonoBehaviour
	{
		public UITexture Image;

		public UILabel NameLabel;

		private TournamentUI _manager;

		public void Init(TournamentUI manager)
		{
			_manager = manager;
		}

		public void Update()
		{
			if (GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament != null && GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.IsTournamentRunning())
			{
				DroneData currentDrone = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.GetCurrentDrone();
				if (currentDrone != null)
				{
					Image.mainTexture = currentDrone.Image;
					NameLabel.text = currentDrone.DroneName;
				}
			}
		}
	}
}
