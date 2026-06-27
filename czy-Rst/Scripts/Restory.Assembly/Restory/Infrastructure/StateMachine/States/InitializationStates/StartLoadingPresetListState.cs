using System;
using Restory.AssetManagement;
using Restory.AssetManagement.References;
using Restory.Data.Locations;
using Restory.Infrastructure.StateMachine.States.Base;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UserInterface;
using Zenject;

namespace Restory.Infrastructure.StateMachine.States.InitializationStates
{
	public class StartLoadingPresetListState : InitializationStateBase, IPayloadedState<GameScenesAssetRef>, IExitableState, IDisposable, IPayloadedState<GameScenesPreset>, IPayloadedState<GameScenesPresetTransition>
	{
		public class Factory : PlaceholderFactory<StartLoadingPresetListState>
		{
		}

		private readonly GUI_FadeScreens fadeScreens;

		private readonly IAssetProvider assetProvider;

		public StartLoadingPresetListState(GUI_FadeScreens fadeScreens, IAssetProvider assetProvider)
		{
			this.fadeScreens = fadeScreens;
			this.assetProvider = assetProvider;
		}

		public async void Enter(GameScenesAssetRef nextListRef)
		{
			LogDebug("Enter state");
			Enter(await assetProvider.Load<GameScenesPreset>(nextListRef, preserved: true));
		}

		public void Enter(GameScenesPreset payload)
		{
			LogDebug("Enter state");
			fadeScreens.FadeInDefaultScreen(payload.LoadingScreenAppearDuration, null, delegate
			{
				MoveToNextState(payload);
			});
		}

		public async void Enter(GameScenesPresetTransition payload)
		{
			GameScenesPreset gameScenesPreset = await assetProvider.Load<GameScenesPreset>(payload.ScenesPreset, preserved: true);
			ScenesTransitionArguments transitionArguments = new ScenesTransitionArguments
			{
				ScenesPreset = gameScenesPreset,
				LoadingScreen = payload.LoadingScreen
			};
			switch (payload.FadeScreen)
			{
			case FadeScreenTypes.None:
				MoveToNextState(transitionArguments);
				break;
			case FadeScreenTypes.DefaultFadeScreen:
				fadeScreens.FadeInDefaultScreen(gameScenesPreset.LoadingScreenAppearDuration, null, delegate
				{
					MoveToNextState(transitionArguments);
				});
				break;
			case FadeScreenTypes.BlackScreen:
				fadeScreens.FadeInBlackScreen(gameScenesPreset.LoadingScreenAppearDuration, null, delegate
				{
					MoveToNextState(transitionArguments);
				});
				break;
			default:
				throw new NotImplementedException();
			}
		}

		public override void Exit()
		{
			LogDebug("Exit state");
		}

		private void MoveToNextState(GameScenesPreset nextPreset)
		{
			base.Progress = 1f;
			GameStateMachine.Enter<DisposePresetListState, GameScenesPreset>(nextPreset);
		}

		private void MoveToNextState(ScenesTransitionArguments nextPresetTransition)
		{
			base.Progress = 1f;
			GameStateMachine.Enter<DisposePresetListState, ScenesTransitionArguments>(nextPresetTransition);
		}
	}
}
