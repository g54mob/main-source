using System.Collections;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using I2.Loc;
using Sirenix.OdinInspector;
using Sirenix.Utilities;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class TournamentUI : SerializedMonoBehaviour
	{
		public UILabel ConnectionLabel;

		public UILabel TitleScreen;

		public UITexture[] TexturesToColor;

		public TournamentProgressScreen ProgressScreen;

		public TournamentStatsScreen StatsScreen;

		public TournamentStartScreen StartScreen;

		public TournamentFinishScreen FinishScreen;

		public TournamentLoadingScreen LoadingScreen;

		public void Start()
		{
			if (!SteamManager.Connected)
			{
				ConnectionLabel.text = LocalizationManager.GetTermTranslation("Tournaments/Not Connected");
			}
			else
			{
				ConnectionLabel.text = LocalizationManager.GetTermTranslation("Tournaments/Connected");
			}
			TitleScreen.text = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.Title.GetTranslation();
			TitleScreen.color = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.UiColor;
			TexturesToColor.ForEach(delegate(UITexture t)
			{
				t.color = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.UiColor;
			});
			ProgressScreen.Init(this);
			StartScreen.Init(this);
			FinishScreen.Init(this);
			StatsScreen.Init(this);
			LoadingScreen.Init(this);
			if (GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.IsTournamentRunning() && GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.HasFinished() && !GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.IsInTraining)
			{
				ShowFinishScreen();
			}
			else if (GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.IsTournamentRunning() && !GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.IsInTraining)
			{
				ShowProgressScreen();
			}
			else
			{
				ShowStartScreen();
			}
		}

		public IEnumerator StartTournament()
		{
			StartScreen.Show(false);
			GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.IsInTraining = false;
			if (GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.IsTournamentRunning())
			{
				ShowProgressScreen();
				yield break;
			}
			TitleScreen.text = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.TournamentTitle.GetTranslation();
			LoadingScreen.Show(true);
			LoadingScreen.UpdateText(LocalizationManager.GetTermTranslation("Tournaments/EnteringTournament"));
			DroneData activeDrone = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetActiveDrone(0);
			yield return GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.StartTournament(activeDrone);
			NimbatusSceneManager.BookmarkActiveScene();
			GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.ApplySettings();
			NimbatusSceneManager.LoadScene(GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.ArenaSceneName);
		}

		public IEnumerator PlayNextMatch()
		{
			ProgressScreen.Show(false);
			LoadingScreen.Show(true);
			LoadingScreen.UpdateText(LocalizationManager.GetTermTranslation("Tournaments/LookingForMatchingOpponent"));
			yield return GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.FindOpponentAndStart();
			NimbatusSceneManager.BookmarkActiveScene();
			GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.ApplySettings();
			NimbatusSceneManager.LoadScene(GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.ArenaSceneName);
		}

		public void ShowStatisticScreen(bool show)
		{
			if (show)
			{
				ProgressScreen.Show(false);
				FinishScreen.Show(false);
				LoadingScreen.Show(false);
				StartScreen.Show(false);
				StatsScreen.Show(true);
				StatsScreen.Init(this);
			}
			else
			{
				ShowStartScreen();
			}
		}

		public void ShowStartScreen()
		{
			StatsScreen.Show(false);
			ProgressScreen.Show(false);
			FinishScreen.Show(false);
			StartScreen.Show(true);
			LoadingScreen.Show(false);
			StartScreen.Init(this);
			TitleScreen.text = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.Title.GetTranslation();
		}

		public void ShowProgressScreen()
		{
			StatsScreen.Show(false);
			ProgressScreen.Show(true);
			FinishScreen.Show(false);
			StartScreen.Show(false);
			LoadingScreen.Show(false);
			ProgressScreen.Init(this);
			TitleScreen.text = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.TournamentTitle.GetTranslation();
		}

		public void ShowFinishScreen()
		{
			StatsScreen.Show(false);
			ProgressScreen.Show(false);
			FinishScreen.Show(true);
			StartScreen.Show(false);
			LoadingScreen.Show(false);
			FinishScreen.Init(this);
		}

		public IEnumerator FinishTournament(bool upload = true)
		{
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ResetActiveDrone(0);
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ResetActiveDrone(1);
			ShowStartScreen();
			yield return GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.StopTournament(upload);
		}

		public IEnumerator ResetTournament()
		{
			GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.IncreaseLoss();
			ShowFinishScreen();
			yield return true;
		}
	}
}
