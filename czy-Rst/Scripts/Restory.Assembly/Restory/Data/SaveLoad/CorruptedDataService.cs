using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Helpers.Attributes;
using Restory.AssetManagement.References;
using Restory.Data.Locations;
using Restory.Data.ReadWriteServices;
using Restory.Data.ReadWriteServices.Interfaces;
using Restory.Gameplay.SaveLoad.Services;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States;
using Restory.Infrastructure.StateMachine.States.InitializationStates;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Restory.Data.SaveLoad
{
	public class CorruptedDataService : MonoBehaviour, IDisposable
	{
		[SerializeField]
		private GameScenesAssetRef corruptedDataScenePreset;

		[SerializeField]
		private GameScenesAssetRef mainMenuScenePreset;

		[SerializeField]
		[Scene]
		private string corruptedDataSceneName;

		private IReadWriteDataService saveLoadSystem;

		private GlobalStateMachine stateMachine;

		private PlayerProfileService profileService;

		private IDiskSpaceService diskSpaceService;

		private DateTime lastReadFailedAt;

		private readonly Queue<Action> executionQueue = new Queue<Action>();

		[Inject]
		private void Construct(IReadWriteDataService saveLoadSystem, IDiskSpaceService diskSpaceService, GlobalStateMachine stateMachine, PlayerProfileService profileService)
		{
			this.saveLoadSystem = saveLoadSystem;
			this.stateMachine = stateMachine;
			this.diskSpaceService = diskSpaceService;
			this.profileService = profileService;
			saveLoadSystem.OnWriteFailed += OnWriteFailed;
			saveLoadSystem.OnReadFailed += OnReadFailed;
		}

		public void Dispose()
		{
			if (saveLoadSystem != null)
			{
				saveLoadSystem.OnWriteFailed -= OnWriteFailed;
				saveLoadSystem.OnReadFailed -= OnReadFailed;
			}
		}

		public void OnReadFailed(FileType fileType)
		{
			if (fileType == FileType.GameSave && !((DateTime.Now - lastReadFailedAt).TotalSeconds < 5.0))
			{
				lastReadFailedAt = DateTime.Now;
				Enqueue(QuitToCorruptedDataScene());
			}
		}

		public async void OnWriteFailed(FileType fileType)
		{
			if (fileType != FileType.GameSave)
			{
				return;
			}
			if (!IsEnoughDiskSpace())
			{
				Enqueue(QuitToMainMenuScene());
				return;
			}
			SaveFileNameParameters parameters = GetSaveFileNameParameters();
			await saveLoadSystem.CheckCorruptedSaveFilesAsync(parameters);
			while (IsLoadingNextScene())
			{
				await Task.Delay(5000);
			}
			GameplaySaveLoadService gameplaySaveLoadService = UnityEngine.Object.FindAnyObjectByType<GameplaySaveLoadService>();
			if (gameplaySaveLoadService != null)
			{
				await gameplaySaveLoadService.SaveProgressAsync(parameters.GameplayMode);
			}
		}

		private IEnumerator QuitToMainMenuScene()
		{
			while (IsLoadingNextScene())
			{
				yield return null;
			}
			stateMachine.Enter<StartLoadingPresetListState, GameScenesAssetRef>(mainMenuScenePreset);
		}

		private IEnumerator QuitToCorruptedDataScene()
		{
			if (!IsCorruptedSceneLoaded())
			{
				while (IsLoadingNextScene())
				{
					yield return null;
				}
				stateMachine.Enter<StartLoadingPresetListState, GameScenesAssetRef>(corruptedDataScenePreset);
			}
		}

		private bool IsCorruptedSceneLoaded()
		{
			return IsSceneLoaded(corruptedDataSceneName);
		}

		private bool IsSceneLoaded(string sceneName)
		{
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				if (sceneAt.IsValid() && sceneAt.name == sceneName)
				{
					return true;
				}
			}
			return false;
		}

		private SaveFileNameParameters GetSaveFileNameParameters()
		{
			GameMode gameplayMode = GameMode.Story;
			GameLauncherState state = stateMachine.GetState<GameLauncherState>();
			if (state != null && state.ActivePreset != null)
			{
				gameplayMode = state.ActivePreset.GameplayMode;
			}
			return new SaveFileNameParameters(gameplayMode, profileService.CurrentProfile);
		}

		private bool IsLoadingNextScene()
		{
			return stateMachine.IsInInitializationState;
		}

		private bool IsEnoughDiskSpace()
		{
			return diskSpaceService.IsEnoughDiskSpace();
		}

		public void Update()
		{
			lock (executionQueue)
			{
				while (executionQueue.Count > 0)
				{
					executionQueue.Dequeue()();
				}
			}
		}

		private void Enqueue(Action action)
		{
			Enqueue(ActionWrapper(action));
		}

		private void Enqueue(IEnumerator action)
		{
			lock (executionQueue)
			{
				executionQueue.Enqueue(delegate
				{
					StartCoroutine(action);
				});
			}
		}

		private IEnumerator ActionWrapper(Action action)
		{
			action();
			yield return null;
		}
	}
}
