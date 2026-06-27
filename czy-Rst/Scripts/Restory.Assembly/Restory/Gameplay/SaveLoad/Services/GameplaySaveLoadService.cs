using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Restory.Data.Identifications;
using Restory.Data.Locations;
using Restory.Data.ReadWriteServices.Interfaces;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.CustomContextStateResolvers;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.SaveLoad.Services
{
	public class GameplaySaveLoadService : MonoBehaviour, IGameplaySaveLoadService, IDisposable
	{
		private IGameplayReadWriteDataService readWriteDataService;

		private GameplaySaveLoadRegistry registry;

		private GameLauncherState gameLoopState;

		private GlobalStateMachine globalStateMachine;

		private PlayerProfileService profileService;

		private List<IContextStateResolver> resolvers;

		private readonly GameplayDataCleaner gameplayDataCleaner = new GameplayDataCleaner();

		private Action onSaveSucceedCallback;

		private readonly CancellationTokenSource cancellationTokenOnDestroy = new CancellationTokenSource();

		public bool IsSaving { get; private set; }

		public bool IsSaveAllowed
		{
			get
			{
				if (!IsSaving)
				{
					return !IsLoadingNextScene();
				}
				return false;
			}
		}

		public DateTime LastSaveDateTime { get; private set; } = DateTime.MinValue;

		private int CurrentProfile => profileService.CurrentProfile;

		public event Action OnSaveBegin;

		public event Action OnSaveCompleted;

		public event Action OnSaveFailed;

		public event Action OnLoadBegin;

		public event Action OnLoadCompleted;

		public event Action OnLoadFailed;

		public event Action OnSaveNotFound;

		[Inject]
		private void Construct(IGameplayReadWriteDataService readWriteDataService, GameplaySaveLoadRegistry registry, GlobalStateMachine globalStateMachine, PlayerProfileService profileService, List<IContextStateResolver> resolvers)
		{
			this.readWriteDataService = readWriteDataService;
			this.registry = registry;
			gameLoopState = globalStateMachine.GetState<GameLauncherState>();
			this.profileService = profileService;
			this.globalStateMachine = globalStateMachine;
			this.resolvers = resolvers;
		}

		public async void SaveProgressAsync(Action onComplete = null)
		{
			GameScenesPreset activePreset = gameLoopState.ActivePreset;
			if (!activePreset)
			{
				Debug.LogWarning("<color=yellow>GameLoopState active preset is null, if save was called during loading - ignore this message</color>");
			}
			else
			{
				await SaveProgressAsync(activePreset.GameplayMode, onComplete);
			}
		}

		public async Task SaveProgressAsync(GameMode forGameMode, Action onComplete = null)
		{
			if (!IsSaving && !IsLoadingNextScene())
			{
				onSaveSucceedCallback = onComplete;
				SaveFileNameParameters parameters = new SaveFileNameParameters(forGameMode, CurrentProfile);
				await SaveProgressAsyncTask(parameters);
			}
			else
			{
				onSaveSucceedCallback = (Action)Delegate.Combine(onSaveSucceedCallback, onComplete);
				Debug.LogWarning("[GameplaySaveLoadService] skipped saving process. Reason: IsSaveAllowed is false");
			}
		}

		private async Task SaveProgressAsyncTask(SaveFileNameParameters parameters)
		{
			IsSaving = true;
			CancellationToken token = cancellationTokenOnDestroy.Token;
			GameScenesPreset activePreset = gameLoopState.ActivePreset;
			try
			{
				OnConcurrentTasksStarted();
				this.OnSaveBegin?.Invoke();
				token.ThrowIfCancellationRequested();
				StartPreCaptureProcess();
				UpdateSnapshots();
				GameplayProgressSaveData gameplayProgressSaveData = UpdatePreviousGameState(activePreset, new GameplayProgressSaveData());
				gameplayProgressSaveData.ActivePreset = activePreset;
				await readWriteDataService.WriteGameProgressAsync(parameters, gameplayProgressSaveData, token);
				LastSaveDateTime = DateTime.Now;
				StartPostCaptureProcess();
				InvokeOnSaveCompleted();
			}
			catch (OperationCanceledException exception)
			{
				Debug.LogException(exception);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(typeof(GameplaySaveLoadService), innerException));
				this.OnSaveFailed?.Invoke();
			}
			finally
			{
				IsSaving = false;
				OnConcurrentTasksFinished();
			}
		}

		private void StartPreCaptureProcess()
		{
			foreach (SaveLoadGameObjectRecord item in registry.All)
			{
				if (!(item == null) && (bool)item.SaveableEntity)
				{
					item.SaveableEntity.PreCapture();
				}
			}
		}

		private void UpdateSnapshots()
		{
			foreach (SaveLoadGameObjectRecord item in registry.All)
			{
				if (!(item == null) && (bool)item.SaveableEntity)
				{
					item.SaveableEntity.MakeSnapshot();
				}
			}
		}

		private void StartPostCaptureProcess()
		{
			foreach (SaveLoadGameObjectRecord item in registry.All)
			{
				if (!(item == null) && (bool)item.SaveableEntity)
				{
					item.SaveableEntity.PostCapture();
				}
			}
		}

		public async void LoadProgressAsync(GameScenesPreset preset, Action onComplete = null)
		{
			try
			{
				this.OnLoadBegin?.Invoke();
				SaveFileNameParameters parameters = new SaveFileNameParameters(preset.GameplayMode, CurrentProfile);
				SaveSystemSaveData saveSystemSaveData = await readWriteDataService.ReadLastGameProgressAsync<SaveSystemSaveData>(parameters);
				StartPreRestoreProcess();
				if (saveSystemSaveData.HasData)
				{
					RestoreGameState(saveSystemSaveData.GameplayState, preset);
				}
				else
				{
					this.OnSaveNotFound?.Invoke();
				}
				StartPostRestoreProcess();
				LastSaveDateTime = DateTime.Now;
				this.OnLoadCompleted?.Invoke();
				onComplete?.Invoke();
			}
			catch (Exception data)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, data));
				this.OnLoadFailed?.Invoke();
			}
		}

		private void StartPreRestoreProcess()
		{
			foreach (SaveLoadGameObjectRecord item in registry.All)
			{
				if (!(item == null) && (bool)item.SaveableEntity)
				{
					item.SaveableEntity.PreRestore();
				}
			}
		}

		private void StartPostRestoreProcess()
		{
			for (int i = 0; i < registry.All.Count; i++)
			{
				SaveLoadGameObjectRecord saveLoadGameObjectRecord = registry.All.ElementAt(i);
				if (!(saveLoadGameObjectRecord == null) && (bool)saveLoadGameObjectRecord.SaveableEntity)
				{
					saveLoadGameObjectRecord.SaveableEntity.PostRestore();
				}
			}
		}

		private GameplayProgressSaveData UpdatePreviousGameState(GameScenesPreset preset, GameplayProgressSaveData previousProgress)
		{
			foreach (SaveLoadGameObjectRecord item in registry.All)
			{
				if (item == null || !item.Identificator)
				{
					continue;
				}
				SaveableEntity saveableEntity = item.SaveableEntity;
				if (!saveableEntity || saveableEntity.SaveMode != SaveModeType.Individual)
				{
					continue;
				}
				Identificator identificator = item.Identificator;
				if (identificator.IsEmptyOrNull)
				{
					Debug.LogWarning("The Object " + item.Name + " can't capture its state. Reason: ID is null or empty");
					continue;
				}
				Dictionary<string, object> orCreateStates = GetOrCreateStates(preset, previousProgress, saveableEntity);
				string iD = identificator.ID;
				if (orCreateStates.TryGetValue(iD, out var value))
				{
					orCreateStates[iD] = saveableEntity.CombineStates((Dictionary<string, object>)value);
				}
				else
				{
					orCreateStates[iD] = saveableEntity.GetSnapshot();
				}
				gameplayDataCleaner.AddActualId(iD);
			}
			if (previousProgress.ConcreteContainers.TryGetValue(preset.SaveDataContainerId.ID, out var value2))
			{
				gameplayDataCleaner.Clean(value2.States);
			}
			return previousProgress;
		}

		private void RestoreGameState(GameplayProgressSaveData savedState, GameScenesPreset preset)
		{
			GameScenesPreset gameScenesPreset = ((preset != null) ? preset : savedState.ActivePreset);
			if (gameScenesPreset == null || !savedState.ConcreteContainers.TryGetValue(gameScenesPreset.SaveDataContainerId.ID, out var value))
			{
				value = new ContextState
				{
					Preset = gameScenesPreset,
					States = new Dictionary<string, object>()
				};
			}
			for (int i = 0; i < registry.All.Count; i++)
			{
				SaveLoadGameObjectRecord saveLoadGameObjectRecord = registry.All.ElementAt(i);
				if (saveLoadGameObjectRecord == null)
				{
					continue;
				}
				SaveableEntity saveableEntity = saveLoadGameObjectRecord.SaveableEntity;
				if (!saveableEntity || saveableEntity.SaveMode != SaveModeType.Individual)
				{
					continue;
				}
				Identificator identificator = saveLoadGameObjectRecord.Identificator;
				if (!identificator || identificator.IsEmptyOrNull)
				{
					Debug.LogWarning("The Object " + saveableEntity.name + " can't restore its state. Reason: ID is null or empty", saveableEntity.gameObject);
					continue;
				}
				string iD = identificator.ID;
				object value3;
				if (saveableEntity.Common)
				{
					if (savedState.CommonContainer.TryGetValue(iD, out var value2))
					{
						saveableEntity.RestoreState(value2);
					}
				}
				else if (value.States.TryGetValue(iD, out value3))
				{
					saveableEntity.RestoreState(value3);
				}
			}
			foreach (ContextState value4 in savedState.ConcreteContainers.Values)
			{
				ResolveState(value4);
			}
		}

		public bool HasSaveFiles(GameMode forGameMode)
		{
			return readWriteDataService.SaveFileExists(new SaveFileNameParameters(forGameMode, CurrentProfile));
		}

		private bool IsLoadingNextScene()
		{
			return globalStateMachine.IsInInitializationState;
		}

		private Dictionary<string, object> GetOrCreateStates(GameScenesPreset preset, GameplayProgressSaveData saveData, SaveableEntity saveableEntity)
		{
			if (saveableEntity.Common)
			{
				return saveData.CommonContainer;
			}
			if (!saveData.ConcreteContainers.TryGetValue(preset.SaveDataContainerId.ID, out var value))
			{
				value = new ContextState
				{
					Preset = preset,
					States = new Dictionary<string, object>()
				};
				saveData.ConcreteContainers[preset.SaveDataContainerId.ID] = value;
			}
			return value.States;
		}

		private void InvokeOnSaveCompleted()
		{
			this.OnSaveCompleted?.Invoke();
			onSaveSucceedCallback?.Invoke();
			onSaveSucceedCallback = null;
		}

		private void ResolveState(ContextState contextState)
		{
			foreach (IContextStateResolver resolver in resolvers)
			{
				resolver.Resolve(contextState);
			}
		}

		private void OnConcurrentTasksStarted()
		{
			RunInBackgroundSolver.OnConcurrentTasksStarted();
		}

		private void OnConcurrentTasksFinished()
		{
			RunInBackgroundSolver.OnConcurrentTasksFinished();
		}

		public void Dispose()
		{
			this.OnSaveBegin = null;
			this.OnSaveCompleted = null;
			this.OnSaveFailed = null;
			this.OnLoadBegin = null;
			this.OnLoadCompleted = null;
			this.OnLoadFailed = null;
			onSaveSucceedCallback = null;
			cancellationTokenOnDestroy.Cancel();
		}
	}
}
