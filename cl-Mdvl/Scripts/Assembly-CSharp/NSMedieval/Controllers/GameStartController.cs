using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.GameDifficulty;
using NSMedieval.GameEventSystem;
using NSMedieval.InfoMessages;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.State;
using NSMedieval.Tutorial;
using NSMedieval.UI;

namespace NSMedieval.Controllers
{
	public class GameStartController : MonoSingleton<GameStartController>
	{
		public Action<string> VillageNameChangedEvent;

		public GameParametersInstance SelectedGameParameters { get; set; }

		public bool ShowTutorial { get; set; }

		public Scenario SelectedScenario { get; set; }

		public List<HumanoidInstance> Workers { get; set; }

		public string SelectedVillageName { get; set; }

		public MapSize SelectedMapSize { get; set; }

		public string SelectedMapType { get; set; }

		public string SelectedMapSeed { get; set; }

		protected override void OnDestroy()
		{
			base.OnDestroy();
			Workers = null;
		}

		public bool StartGame()
		{
			MonoSingleton<LoadingController>.Instance.DebugMeasureLoadingTime($"Started a new game. Map type: {SelectedMapType}, Size: {SelectedMapSize}.");
			if (!CreateSave())
			{
				MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: false);
				return false;
			}
			MonoSingleton<AddressableSceneLoadingManager>.Instance.LoadMainScene();
			return true;
		}

		private void OnGameplayStart(bool obj)
		{
			MonoSingleton<UIController>.Instance.GameStartedEvent -= OnGameplayStart;
			if (!TutorialManager.IsTutorialActive && !(SelectedScenario == null) && SelectedScenario.TryGetStartEventId(out var eventGroupInstance))
			{
				MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.StartEvent(eventGroupInstance);
			}
		}

		private void OnMainSceneLoaded()
		{
			MonoSingleton<UIController>.Instance.GameStartedEvent += OnGameplayStart;
		}

		private void OnHomeSceneLoaded()
		{
			Workers = null;
		}

		public void VillageNameChanged(string villageNameText)
		{
			SelectedVillageName = villageNameText;
			VillageNameChangedEvent?.Invoke(villageNameText);
		}

		private bool CreateSave()
		{
			if (SelectedMapSize == null || SelectedMapSize.Width == 0 || SelectedMapSize.Height == 0 || SelectedMapSize.Length == 0)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("map_size_error"));
				return false;
			}
			WorldDate.GameStartSeason = SelectedScenario.StartSeason;
			WorldDate.GameStartHour = SelectedScenario.StartHour;
			MonoSingleton<GlobalSaveController>.Instance.CreateNewVillage(SelectedVillageName);
			VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
			currentVillageData.SetMapSourceIDs(SelectedMapSize, SelectedMapType, SelectedMapSeed);
			currentVillageData.GameParametersCurrent = SelectedGameParameters;
			currentVillageData.Scenario = SelectedScenario;
			foreach (HumanoidInstance worker in Workers)
			{
				currentVillageData.AddWorker(worker);
			}
			Workers.Clear();
			List<GameplayTipsSchedule> list = new List<GameplayTipsSchedule>();
			foreach (GameplayTipsScheduler allItem in Repository<GameplayTipsScheduleRepository, GameplayTipsScheduler>.Instance.GetAllItems())
			{
				list.Add(new GameplayTipsSchedule(allItem.GetID(), allItem.DisplayHour, allItem.TipId, allItem.SkipIfTutorialCompleted));
			}
			currentVillageData.SetGameplayTipsSchedule(list);
			MonoSingleton<OptionsController>.Instance.SetShowTutorial(ShowTutorial);
			if (MonoSingleton<EventInteractionManager>.IsInstantiated())
			{
				MonoSingleton<EventInteractionManager>.Instance.InitializeGlobalChances();
			}
			return true;
		}

		private void OnEnable()
		{
			MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent += OnMainSceneLoaded;
			MonoSingleton<LoadingController>.Instance.HomeSceneLoadedEvent += OnHomeSceneLoaded;
		}

		private void OnDisable()
		{
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent -= OnMainSceneLoaded;
				MonoSingleton<LoadingController>.Instance.HomeSceneLoadedEvent -= OnHomeSceneLoaded;
			}
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.GameStartedEvent -= OnGameplayStart;
			}
		}
	}
}
