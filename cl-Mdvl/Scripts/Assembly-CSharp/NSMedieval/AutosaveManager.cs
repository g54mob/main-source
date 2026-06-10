using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.UI;

namespace NSMedieval
{
	public class AutosaveManager : MonoSingleton<AutosaveManager>
	{
		private int daysPassed;

		private void OnEnable()
		{
			MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent += OnMainSceneLoaded;
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnLeavingMainScene;
			MonoSingleton<LoadingController>.Instance.HomeSceneLeavingEvent += OnLeavingHomeScene;
			MonoSingleton<GlobalSaveController>.Instance.AutosaveEndEvent += OnAutosaveEnd;
		}

		private void OnDisable()
		{
			if (!(MonoSingleton<AutosaveManager>.Instance != this))
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent -= OnMainSceneLoaded;
				MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= OnLeavingMainScene;
				MonoSingleton<LoadingController>.Instance.HomeSceneLeavingEvent -= OnLeavingHomeScene;
				if (MonoSingleton<GlobalSaveController>.IsInstantiated())
				{
					MonoSingleton<GlobalSaveController>.Instance.AutosaveEndEvent -= OnAutosaveEnd;
				}
			}
		}

		private void OnMainSceneLoaded()
		{
			MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent += OnDateUpdate;
			MonoSingleton<OptionsController>.Instance.AutosaveFrequencyChangedAction += OnAutosaveFrequencyChange;
		}

		private void OnLeavingMainScene()
		{
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent -= OnDateUpdate;
			}
			if (MonoSingleton<OptionsController>.IsInstantiated())
			{
				MonoSingleton<OptionsController>.Instance.AutosaveFrequencyChangedAction -= OnAutosaveFrequencyChange;
			}
		}

		private void OnLeavingHomeScene()
		{
			daysPassed = 0;
		}

		private void OnDateUpdate()
		{
			if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.AutosaveFrequency != 0 && !GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				daysPassed++;
				if (daysPassed >= MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.GetAutosaveDays())
				{
					daysPassed = 0;
					MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("autosave_inprogress"));
					MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.1f).Then(AutoSave);
				}
			}
		}

		private void OnAutosaveEnd()
		{
			MonoSingleton<UIController>.Instance.ClosePrompt();
		}

		private void AutoSave()
		{
			MonoSingleton<GlobalSaveController>.Instance.AutosaveCurrentVillage();
		}

		private void OnAutosaveFrequencyChange()
		{
			daysPassed = 0;
		}
	}
}
