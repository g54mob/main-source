using System.Collections.Generic;
using System.Threading.Tasks;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.States;
using Infrastructure.Services;
using Infrastructure.Services.BoxService;
using Infrastructure.Services.PersistentProgress;
using NewGameplayScripts;
using Tasks_for_levels;
using UnityEngine;

namespace Infrastructure.Factory
{
	public class GameFactory : IGameFactory, IService
	{
		private readonly IAssetProvider _assets;

		private readonly IGameStateMachine _stateMachine;

		private readonly IPersistentProgressService _persistentProgressService;

		public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();

		public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

		public GameFactory(IAssetProvider assets, IGameStateMachine stateMachine, IPersistentProgressService persistentProgressService)
		{
			_assets = assets;
			_stateMachine = stateMachine;
			_persistentProgressService = persistentProgressService;
		}

		public void WarmUp()
		{
			Register(ProgressManager.Instance);
			if (NewScoreUI.Instance != null)
			{
				Register(NewScoreUI.Instance);
			}
			if (NextLevelButtonUI.Instance != null)
			{
				Register(NextLevelButtonUI.Instance);
			}
			if (TotalScoreCalculator.Instance != null)
			{
				Register(TotalScoreCalculator.Instance);
			}
			Register(CollectionManager.Instance);
			Register(SettingsUI.Instance);
			Register(MovementSystem.Instance);
			Register(PlantCreatingSystem.Instance);
			if (AllServices.Container.Single<ITaskService>().GetCurrentTask() != null)
			{
				Register(AllServices.Container.Single<ITaskService>().GetCurrentTask());
			}
			RegisterBoxesOnLevel();
		}

		public async Task CreateLevelTransfer(Vector3 at)
		{
			await InstantiateRegisteredAsync("LevelTransferTrigger", at);
		}

		private void Register(ISavedProgressReader progressReader)
		{
			if (progressReader is ISavedProgress item)
			{
				ProgressWriters.Add(item);
			}
			ProgressReaders.Add(progressReader);
		}

		public void Cleanup()
		{
			ProgressReaders.Clear();
			ProgressWriters.Clear();
		}

		private GameObject InstantiateRegistered(GameObject prefab, Vector3 at)
		{
			GameObject gameObject = Object.Instantiate(prefab, at, Quaternion.identity);
			RegisterProgressWatchers(gameObject);
			return gameObject;
		}

		private GameObject InstantiateRegistered(GameObject prefab)
		{
			GameObject gameObject = Object.Instantiate(prefab);
			RegisterProgressWatchers(gameObject);
			return gameObject;
		}

		private async Task<GameObject> InstantiateRegisteredAsync(string prefabPath, Vector3 at)
		{
			GameObject gameObject = await _assets.Instantiate(prefabPath, at);
			RegisterProgressWatchers(gameObject);
			return gameObject;
		}

		private async Task<GameObject> InstantiateRegisteredAsync(string prefabPath)
		{
			GameObject gameObject = await _assets.Instantiate(prefabPath);
			RegisterProgressWatchers(gameObject);
			return gameObject;
		}

		private void RegisterProgressWatchers(GameObject gameObject)
		{
			ISavedProgressReader[] componentsInChildren = gameObject.GetComponentsInChildren<ISavedProgressReader>();
			foreach (ISavedProgressReader progressReader in componentsInChildren)
			{
				Register(progressReader);
			}
		}

		private void RegisterBoxesOnLevel()
		{
			if (AllServices.Container.Single<IBoxService>().GetCurrentBoxes() == null)
			{
				return;
			}
			foreach (BoxOnLevel currentBox in AllServices.Container.Single<IBoxService>().GetCurrentBoxes())
			{
				Register(currentBox);
			}
		}
	}
}
