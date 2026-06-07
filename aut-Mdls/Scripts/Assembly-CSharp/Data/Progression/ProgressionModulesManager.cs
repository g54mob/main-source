#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor.Resources;
using Data.Notifications;
using Data.Shapes;
using Events;
using Events.FactoryFloor;
using Events.UI.Notifications;
using UnityEngine;
using Utils;

namespace Data.Progression
{
	public class ProgressionModulesManager : MonoBehaviour
	{
		[SerializeField]
		private ProgressionManagerLocator _progressionManagerLocator;

		[SerializeField]
		private ProgressionPersistentSO _progressionPersistentSO;

		[Space]
		[SerializeField]
		private BuildingObjectDatabase _buildingObjectDatabase;

		[SerializeField]
		private ModuleChallengeSO _moduleChallengeSO;

		[Header("Events")]
		[SerializeField]
		private BaseEvent _preLoadingSaveEvent;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		[SerializeField]
		private ResourceCreatedEventSO _resourceCreatedEvent;

		[SerializeField]
		private NotificationEvent _notificationEvent;

		private readonly Dictionary<ShapeHashPair, ShapeData> _undiscoveredShapes = new Dictionary<ShapeHashPair, ShapeData>();

		private readonly List<ShapeData> _discoveredShapes = new List<ShapeData>();

		private bool _factoryIsLoading;

		public IReadOnlyList<ShapeData> DiscoveredShapes => _discoveredShapes;

		private void Awake()
		{
			_progressionManagerLocator.ProgressionModules = this;
			_preLoadingSaveEvent.Register(OnStartingLoadFactory);
			_finishedLoadingSaveEvent.Register(OnFinishedLoadFactory);
			_resourceCreatedEvent.RegisterMainThread(HandleResourceProduced);
		}

		private void OnDestroy()
		{
			_preLoadingSaveEvent.UnRegister(OnStartingLoadFactory);
			_finishedLoadingSaveEvent.UnRegister(OnFinishedLoadFactory);
			_resourceCreatedEvent.UnRegisterMainThread(HandleResourceProduced);
		}

		private void Start()
		{
			_progressionPersistentSO.TryGetSaveData(out var progressionSaveData);
			ApplySaveData(progressionSaveData);
		}

		private void OnStartingLoadFactory()
		{
			_factoryIsLoading = true;
		}

		private void OnFinishedLoadFactory()
		{
			_factoryIsLoading = false;
		}

		private void HandleResourceProduced(Resource resource)
		{
			if (_factoryIsLoading || !(resource is ShapeResource shapeResource) || !_undiscoveredShapes.TryGetValue(shapeResource.ShapeData.GetShapeHash(), out var value))
			{
				return;
			}
			ShapeHashPair[] rotations = shapeResource.ShapeData.RotationIndependantHash.Rotations;
			foreach (ShapeHashPair shapeHashPair in rotations)
			{
				if (!_undiscoveredShapes.Remove(shapeHashPair))
				{
					this.LogError(string.Format("Failed to remove shape hash \"{0}\" from {1}", shapeHashPair, "_undiscoveredShapes"), "HandleResourceProduced", 75);
				}
			}
			_discoveredShapes.Add(value);
			_notificationEvent.Fire(new ModuleNotificationData(value));
		}

		internal void ApplySaveData(ProgressionSaveData saveData)
		{
			_discoveredShapes.Clear();
			_undiscoveredShapes.Clear();
			foreach (BuildingObjectData buildingData in _buildingObjectDatabase.BuildingDatas)
			{
				foreach (ModuleViewerData.ShapeDataAndAmount module in buildingData.GetModuleViewerData.Modules)
				{
					AddShapeToUndiscovered(saveData, module.Shape.Data);
				}
			}
			foreach (ModuleChallengeSet set in _moduleChallengeSO.Sets)
			{
				foreach (ObjectiveTargetCategorySO category in set.Categories)
				{
					if (category.Resource.HasShapeData)
					{
						AddShapeToUndiscovered(saveData, category.Resource.ShapeData.Data);
					}
				}
			}
		}

		private void AddShapeToUndiscovered(ProgressionSaveData saveData, ShapeData shapeData)
		{
			if (IsShapeInSaveData(saveData, shapeData))
			{
				if (!_discoveredShapes.Contains(shapeData))
				{
					_discoveredShapes.Add(shapeData);
				}
				return;
			}
			ShapeHashPair[] rotations = shapeData.RotationIndependantHash.Rotations;
			foreach (ShapeHashPair key in rotations)
			{
				_undiscoveredShapes.TryAdd(key, shapeData);
			}
			static bool IsShapeInSaveData(ProgressionSaveData progressionSaveData, ShapeData shapeData2)
			{
				if (progressionSaveData == null)
				{
					return false;
				}
				ShapeHashPair[] discoveredShapeHashes = progressionSaveData.DiscoveredShapeHashes;
				for (int j = 0; j < discoveredShapeHashes.Length; j++)
				{
					if (discoveredShapeHashes[j] == shapeData2.GetShapeHash())
					{
						return true;
					}
				}
				return false;
			}
		}

		internal void Reset()
		{
			ApplySaveData(null);
		}
	}
}
