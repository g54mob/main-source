using System;
using Restory.Data.Locations;
using Restory.Gameplay.Common;
using Restory.Gameplay.SaveLoad.Services;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States.InitializationStates;
using UnityEngine;

namespace Restory.Gameplay.TimeSystems
{
	public class TransitionToEndOfDayService : IActiveStateSwitchRequester, IDisposable
	{
		private readonly TimeSystem timeSystem;

		private readonly GlobalStateMachine globalStateMachine;

		private readonly IGameplaySaveLoadService saveLoadService;

		private readonly GameScenesPresetTransition transitionToEndOfDayScenes;

		private Coroutine doCallbackAfterDelayCoroutine;

		public TransitionToEndOfDayService(GlobalStateMachine globalStateMachine, IGameplaySaveLoadService saveLoadService, TimeSystem timeSystem, GameScenesPresetTransition transitionToEndOfDayScenes)
		{
			this.globalStateMachine = globalStateMachine;
			this.saveLoadService = saveLoadService;
			this.timeSystem = timeSystem;
			this.transitionToEndOfDayScenes = transitionToEndOfDayScenes;
		}

		public void PerformDaySwitchingOperation()
		{
			timeSystem.BlockTimeSystem(this);
			saveLoadService.SaveProgressAsync(delegate
			{
				globalStateMachine.Enter<StartLoadingPresetListState, GameScenesPresetTransition>(transitionToEndOfDayScenes);
			});
		}

		public void Dispose()
		{
			timeSystem?.StopBlockingTimeSystem(this);
		}
	}
}
