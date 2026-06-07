using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.UIControls.ActiveDroneDisplay;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class SetTournamentSettings : SerializedMonoBehaviour
	{
		public List<DroneSelectionButton> Buttons;

		protected void Awake()
		{
			DroneSettings settings = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.GetDroneSettings();
			Buttons.ForEach(delegate(DroneSelectionButton b)
			{
				b.SetSettings(settings);
			});
		}
	}
}
