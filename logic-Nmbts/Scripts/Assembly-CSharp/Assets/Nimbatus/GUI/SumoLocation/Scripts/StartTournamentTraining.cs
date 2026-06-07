using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap.Tournaments;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using I2.Loc;
using NGenerics.Extensions;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.GUI.SumoLocation.Scripts
{
	public class StartTournamentTraining : SerializedMonoBehaviour
	{
		public bool InTournament = true;

		[ShowIf("InTournament", true)]
		public UILabel TitleLabel;

		[ShowIf("InTournament", true)]
		public UILabel ButtonLabel;

		[HideIf("InTournament", true)]
		public ETournamentType TournamentType;

		private UIButton[] _buttons;

		public void Start()
		{
			_buttons = GetComponents<UIButton>();
			if (InTournament)
			{
				ButtonLabel.text = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.TrainingStartButtonTitle.GetTranslation();
				TitleLabel.text = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.TrainingTitle.GetTranslation();
			}
		}

		public void OnClick()
		{
			if (IsReadyToBattle())
			{
				if (InTournament)
				{
					GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.IsInTraining = true;
					NimbatusSceneManager.BookmarkActiveScene();
					GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.ApplySettings();
					NimbatusSceneManager.LoadScene(GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.ArenaSceneName);
				}
				else
				{
					NimbatusSceneManager.BookmarkActiveScene();
					Tournament tournament = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.GetTournament(TournamentType);
					tournament.Settings.ApplySettings();
					NimbatusSceneManager.LoadScene(tournament.Settings.ArenaSceneName);
				}
			}
		}

		private bool IsReadyToBattle()
		{
			if (SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetActiveDrone(0) != null && SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetActiveDrone(1) != null)
			{
				return true;
			}
			return false;
		}

		public void Update()
		{
			if (!IsReadyToBattle())
			{
				_buttons.ForEach(delegate(UIButton b)
				{
					b.SetState(UIButtonColor.State.Disabled, true);
				});
			}
		}

		public void OnTooltip(bool show)
		{
			if (show && !IsReadyToBattle())
			{
				NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("Tournaments/SelectTwoDrones"));
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
