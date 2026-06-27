using System;
using Restory.Data.Locations;
using Restory.Data.ReadWriteServices.Interfaces;
using Restory.Data.SaveLoad.Containers;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States.InitializationStates;
using Restory.UserInterface;
using Zenject;

namespace Restory.Data.SaveLoad
{
	public class LastSaveLoader
	{
		public class Factory : PlaceholderFactory<LastSaveLoader>
		{
		}

		private readonly GlobalStateMachine stateMachine;

		private readonly IGameplayReadOnlyDataService gameplayReadOnlyDataService;

		private readonly PlayerProfileService profileService;

		private GUI_FadeScreens fadeScreens;

		public LastSaveLoader(GlobalStateMachine stateMachine, IGameplayReadOnlyDataService gameplayReadOnlyDataService, PlayerProfileService profileService, GUI_FadeScreens fadeScreens)
		{
			this.stateMachine = stateMachine;
			this.gameplayReadOnlyDataService = gameplayReadOnlyDataService;
			this.profileService = profileService;
			this.fadeScreens = fadeScreens;
		}

		public void LoadLastGame(GameMode gameplayMode)
		{
			LoadLastGamePreset(gameplayMode);
		}

		private async void LoadLastGamePreset(GameMode gameplayMode)
		{
			fadeScreens.FadeInDefaultScreen(2f);
			SaveFileNameParameters parameters = new SaveFileNameParameters(gameplayMode, profileService.CurrentProfile);
			SaveSystemSaveData saveSystemSaveData = await gameplayReadOnlyDataService.ReadLastGameProgressAsync<SaveSystemSaveData>(parameters);
			fadeScreens.FadeOut(2f);
			if (saveSystemSaveData.GameplayState.ActivePreset != null)
			{
				stateMachine.Enter<StartLoadingPresetListState, GameScenesPreset>(saveSystemSaveData.GameplayState.ActivePreset);
				return;
			}
			throw new NotImplementedException();
		}
	}
}
