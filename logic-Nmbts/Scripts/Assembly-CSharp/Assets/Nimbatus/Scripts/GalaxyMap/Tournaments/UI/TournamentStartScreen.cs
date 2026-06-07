using Assets.Nimbatus.Scripts.GalaxyMap.SumoArena;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.UIControls.ActiveDroneDisplay;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class TournamentStartScreen : TournamentScreen
	{
		public UILabel DescriptionLabel;

		public StartTournamentButton StartButton;

		public DroneSelectionButton DroneSelectionButton;

		public ReadOnlyDroneDisplay DroneDisplay;

		public GameObject TrainingPanel;

		public GameObject TournamentPanel;

		public ShowTournamentPanelButton TournamentButton;

		public ShowTrainingPanelButton TrainingButton;

		public void ShowTrainingPanel()
		{
			TournamentButton.Enable(false);
			TrainingButton.Enable(true);
			TrainingPanel.SetActive(true);
			TournamentPanel.SetActive(false);
		}

		public void ShowTournamentPanel()
		{
			TournamentButton.Enable(true);
			TrainingButton.Enable(false);
			TrainingPanel.SetActive(false);
			TournamentPanel.SetActive(true);
		}

		public override void Init()
		{
			Tournament activeTournament = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament;
			GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.IsInTraining = false;
			TournamentButton.Init(this);
			TrainingButton.Init(this);
			ShowTournamentPanel();
			bool num = activeTournament.IsTournamentRunning() && !activeTournament.HasFinished();
			StartButton.Init(Manager);
			if (num)
			{
				DroneDisplay.gameObject.SetActive(true);
				DroneSelectionButton.gameObject.SetActive(false);
				DroneDisplay.Init(activeTournament.GetCurrentDrone(), activeTournament.CurrentScore, false, true);
			}
			else
			{
				DroneDisplay.gameObject.SetActive(false);
				DroneSelectionButton.gameObject.SetActive(true);
				DroneSelectionButton.SetSettings(activeTournament.GetDroneSettings());
			}
			DescriptionLabel.text = activeTournament.Settings.Description.GetTranslation();
		}

		private bool IsDroneSelected()
		{
			if (SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetActiveDrone(0) != null)
			{
				return true;
			}
			return false;
		}

		public void Update()
		{
			if (GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament != null)
			{
				StartButton.Enable(IsDroneSelected() || GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.IsTournamentRunning());
			}
		}
	}
}
