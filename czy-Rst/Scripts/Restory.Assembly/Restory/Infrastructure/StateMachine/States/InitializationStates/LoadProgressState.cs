using System;
using Restory.Data.Locations;
using Restory.Gameplay.SaveLoad.Services;
using Restory.Infrastructure.StateMachine.States.Base;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.StateMachine.States.InitializationStates
{
	public class LoadProgressState : InitializationStateBase, IPayloadedState<GameScenesPreset>, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<LoadProgressState>
		{
		}

		public void Enter(GameScenesPreset preset)
		{
			LogDebug("Enter state");
			GameplaySaveLoadService gameplaySaveLoadService = UnityEngine.Object.FindAnyObjectByType<GameplaySaveLoadService>(FindObjectsInactive.Include);
			if ((bool)gameplaySaveLoadService)
			{
				gameplaySaveLoadService.LoadProgressAsync(preset, delegate
				{
					MoveToTheNextState(preset);
					base.Progress = 1f;
				});
			}
			else
			{
				MoveToTheNextState(preset);
				base.Progress = 1f;
			}
		}

		private void MoveToTheNextState(GameScenesPreset preset)
		{
			GameStateMachine.Enter<FinalSelectionState, GameScenesPreset>(preset);
		}

		public override void Exit()
		{
			LogDebug("Exit state");
		}
	}
}
