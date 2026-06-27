using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Locations;
using Restory.Infrastructure.ProjectServices;
using Restory.Infrastructure.StateMachine.States.Base;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.Wrappers.Zenject;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.StateMachine.States.InitializationStates
{
	public class InstallServicesState : InitializationStateBase, IPayloadedState<GameScenesPreset>, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<InstallServicesState>
		{
		}

		private const int FRAMES_DELAY = 5;

		private readonly ICoroutineRunner coroutineRunner;

		[Inject]
		public InstallServicesState(ICoroutineRunner coroutineRunner)
		{
			this.coroutineRunner = coroutineRunner;
		}

		public void Enter(GameScenesPreset preset)
		{
			LogDebug("Enter state");
			coroutineRunner.Run(InstallationRoutine(preset));
		}

		public override void Exit()
		{
			LogDebug("Exit state");
		}

		private IEnumerator InstallationRoutine(GameScenesPreset preset)
		{
			WaitForEndOfFrame endFrameDelay = new WaitForEndOfFrame();
			InitSceneContainers();
			base.Progress = 0.3f;
			InitGameObjectContainers();
			base.Progress = 0.6f;
			for (int i = 0; i < 5; i++)
			{
				yield return endFrameDelay;
			}
			InitializableCoroutineManager[] initializableCoroutineManagers = UnityEngine.Object.FindObjectsByType<InitializableCoroutineManager>(FindObjectsSortMode.None);
			if (initializableCoroutineManagers.Length != 0)
			{
				InitializableCoroutineManager[] array = initializableCoroutineManagers;
				for (int j = 0; j < array.Length; j++)
				{
					array[j].StartInitializationRoutine();
				}
				yield return new WaitUntil(() => initializableCoroutineManagers.All((InitializableCoroutineManager x) => x.HasInitialized));
			}
			base.Progress = 1f;
			EnterNextState(preset);
		}

		private void EnterNextState(GameScenesPreset preset)
		{
			GameStateMachine.Enter<LoadProgressState, GameScenesPreset>(preset);
		}

		private void InitSceneContainers()
		{
			List<SceneContext> list = UnityEngine.Object.FindObjectsByType<SceneContext>(FindObjectsSortMode.None).ToList();
			list.RemoveAll((SceneContext x) => x.ContractNames.Contains("LoadingScreen") || x.Initialized);
			SceneContext sceneContext = list.FirstOrDefault((SceneContext x) => x.ContractNames.Contains("MainScene"));
			if (sceneContext != null)
			{
				sceneContext.Run();
				list.Remove(sceneContext);
			}
			SceneContext sceneContext2 = list.FirstOrDefault((SceneContext x) => x.ContractNames.Contains("StoryMode"));
			if (sceneContext2 != null)
			{
				sceneContext2.Run();
				list.Remove(sceneContext2);
			}
			foreach (SceneContext item in list.OrderBy((SceneContext x) => x.ParentContractNames.Count()))
			{
				item.Run();
			}
		}

		private void InitGameObjectContainers()
		{
			GameObjectContext[] array = UnityEngine.Object.FindObjectsByType<GameObjectContext>(FindObjectsSortMode.None);
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Run();
			}
		}
	}
}
