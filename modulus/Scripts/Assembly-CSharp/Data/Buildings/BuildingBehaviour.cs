#define ENABLE_DEBUG_EXCEPTIONS
#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using System.Linq;
using Data.Analytics;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Buildings;
using Data.FactoryFloor.Maps;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Shapes;
using Events;
using Events.FactoryFloor.Buildings;
using Logic.Factory;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;
using UnityEngine.Pool;
using Utils;

namespace Data.Buildings
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/BuildingBehaviour", fileName = "BuildingBehaviour", order = 0)]
	public class BuildingBehaviour : ResourceHolderBehaviour
	{
		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private BaseEvent _upgradeAllBuildingsEvent;

		[SerializeField]
		private AnalyticsData _analyticsData;

		[SerializeField]
		private ResourceDataSO _shapeResourceData;

		[SerializeField]
		private BuildingReceivedResourceEvent _buildingReceivedResourceEvent;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private bool _needsDroneToTakeOutput = true;

		[SerializeField]
		private bool _canBeOverclocked = true;

		[SerializeField]
		private bool _showSpeedRequirementInUI;

		[SerializeField]
		private int _processTicksToSupplyAllModules = 384;

		private int _currentBuildingStage;

		private BuildingObjectData _buildingObjectData;

		protected bool _isBuildingActive = true;

		protected bool _buildingCompleted;

		protected bool _isUpgrading = true;

		private bool _hasResources;

		private BuildingLandingPad _buildingLandingPad;

		private ReferenceFactoryObjectBehaviour _referenceBehaviour;

		private IslandObject _islandObject;

		private float _overclockLeftoverCounter;

		private readonly Dictionary<ResourceDataSO, int> _buildRequirementIndices = new Dictionary<ResourceDataSO, int>();

		private readonly List<BuildingConstructionResource> _currBuildRequirements = new List<BuildingConstructionResource>();

		public MainThreadEvent<int> OnStageCompleted = new MainThreadEvent<int>();

		public MainThreadEvent<ShapeData, int> OnShapeAdded = new MainThreadEvent<ShapeData, int>();

		public MainThreadEvent<BuildingBehaviour> OnCreatedResources = new MainThreadEvent<BuildingBehaviour>();

		public MainThreadEvent<bool> OnUpgradeStateChanged = new MainThreadEvent<bool>();

		public MainThreadEvent OnClearedResources = new MainThreadEvent();

		public List<BuildingConstructionResource> BuildRequirements => _currBuildRequirements;

		public BuildingObjectData BuildingObjectData => _buildingObjectData;

		public bool MaxLockedBuildingStageReached => _currentBuildingStage >= _buildingObjectData.BuildingMaxLockedStage;

		public bool MaxBuildingStageReached => _currentBuildingStage >= MaxBuildingStage;

		public int CurrentBuildingStage => _currentBuildingStage;

		public int MaxBuildingStage => Math.Max(1, _buildingObjectData.Upgrades.Count + 1);

		public bool BuildingCompleted => _buildingCompleted;

		public bool IsUpgrading => _isUpgrading;

		public bool IsBuildingActive => _isBuildingActive;

		public bool HasResources => _hasResources;

		public bool NeedsDroneToTakeOutput => _needsDroneToTakeOutput;

		public IslandOverclockData OverclockData => _islandObject.OverclockData;

		public bool IsOverClocked => _islandObject.OverclockData.IsOverclocked;

		public bool CanBeOverclocked => _canBeOverclocked;

		public bool ShowSpeedRequirementInUI => _showSpeedRequirementInUI;

		public int ProcessTicksToSupplyAllModules => _processTicksToSupplyAllModules;

		public float CurrentProgress
		{
			get
			{
				int num = 0;
				float num2 = 0f;
				foreach (BuildingConstructionResource buildRequirement in BuildRequirements)
				{
					num += buildRequirement.Max;
					num2 += (float)buildRequirement.Count;
				}
				return num2 / (float)num;
			}
		}

		public BuildingLandingPad BuildingLandingPad => _buildingLandingPad;

		private BuildingObjectData.BuildingUpgrade CurrentUpgrade
		{
			get
			{
				if (_currentBuildingStage - 1 < 0)
				{
					return new BuildingObjectData.BuildingUpgrade
					{
						CostMultiplier = 1
					};
				}
				return _buildingObjectData.Upgrades[_currentBuildingStage - 1];
			}
		}

		public static event Action<BuildingBehaviour, int> OnBuildingUpgraded;

		public static event Action OnBuildingStartUpgrade;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			if (_islandLayer != null)
			{
				_islandLayer.TryGetIslandAtWorldPosition(factoryObject.Position, out _islandObject);
			}
			_buildingObjectData = _factoryObjectDatabase.BuildingsObjectData.GetBuildingDataWithId(factoryObject.ObjectId);
			_upgradeAllBuildingsEvent.Register(ReceivedAllModules);
			_buildingLandingPad = new BuildingLandingPad(_factoryObject, this);
			BuildingBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<BuildingBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				SetSaveState(behaviourSaveStateDto);
			}
			else
			{
				InitializeRequirements();
			}
			_referenceBehaviour = factoryObject.GetFactoryObjectBehaviour<ReferenceFactoryObjectBehaviour>();
			_referenceBehaviour.OnAddedReferencedObject += LinkToHarvesterPad;
			_referenceBehaviour.OnRemovedReferencedObject += UnlinkFromHarvesterPad;
			foreach (ReferenceFactoryObjectBehaviour referencedObject in _referenceBehaviour.ReferencedObjects)
			{
				if (referencedObject.FactoryObject.HasFactoryObjectBehaviour(out HarvesterPadBehaviour behaviour))
				{
					behaviour.TryLinkBuilding(_referenceBehaviour);
				}
			}
			for (int num = _referenceBehaviour.ReferencedObjects.Count - 1; num >= 0; num--)
			{
				ReferenceFactoryObjectBehaviour referenceFactoryObjectBehaviour = _referenceBehaviour.ReferencedObjects[num];
				if (referenceFactoryObjectBehaviour.FactoryObject.HasFactoryObjectBehaviour(out HarvesterPadBehaviour behaviour2) && !behaviour2.TryLinkBuilding(_referenceBehaviour))
				{
					_referenceBehaviour.RemoveReference(referenceFactoryObjectBehaviour);
				}
			}
			_analyticsData.OnStartedBuilding(_buildingObjectData.DioramaSave.Name, 0);
		}

		public override void UnInit()
		{
			_upgradeAllBuildingsEvent.UnRegister(ReceivedAllModules);
			_buildingLandingPad.Dispose();
			_buildingLandingPad = null;
			_referenceBehaviour.OnAddedReferencedObject -= LinkToHarvesterPad;
			_referenceBehaviour.OnRemovedReferencedObject -= UnlinkFromHarvesterPad;
			base.UnInit();
		}

		private void LinkToHarvesterPad(ReferenceFactoryObjectBehaviour referenceObject)
		{
			_buildingLandingPad.GenerateLandingPad(referenceObject.FactoryObject);
		}

		private void UnlinkFromHarvesterPad(ReferenceFactoryObjectBehaviour referenceObject)
		{
			_buildingLandingPad.DestroyLandingPad();
		}

		protected virtual IReadOnlyDictionary<ShapeHashPair, DioramaEditorSave.DioramaShapeCollection> GetCurrentShapesDictionary()
		{
			return _buildingObjectData.DioramaSave.DioramaShapesDictionary;
		}

		protected virtual List<BuildingObjectData.BuildingResourceData> GetAdditionalInputs()
		{
			return _buildingObjectData.AdditionalInputs;
		}

		private void InitializeRequirements(float multiplier = 1f, bool keepResources = false)
		{
			lock (this)
			{
				List<BuildingConstructionResource> list = null;
				if (keepResources)
				{
					list = CollectionPool<List<BuildingConstructionResource>, BuildingConstructionResource>.Get();
					list.AddRange(_currBuildRequirements);
				}
				_currBuildRequirements.Clear();
				_buildRequirementIndices.Clear();
				foreach (KeyValuePair<ShapeHashPair, DioramaEditorSave.DioramaShapeCollection> item3 in GetCurrentShapesDictionary())
				{
					ShapeConstructionResource item = new ShapeConstructionResource(_shapeResourceData)
					{
						Count = 0,
						Max = Mathf.RoundToInt((float)item3.Value.Shapes.Count * multiplier),
						ShapeData = item3.Value.ShapeData.Data,
						Hash = item3.Value.ShapeData.Data.RotationIndependantHash
					};
					_currBuildRequirements.Add(item);
					if (!_buildRequirementIndices.ContainsKey(_shapeResourceData))
					{
						_buildRequirementIndices.Add(_shapeResourceData, _currBuildRequirements.Count - 1);
					}
				}
				if (RequiresAdditionalResourceInputs())
				{
					foreach (BuildingObjectData.BuildingResourceData additionalInput in GetAdditionalInputs())
					{
						BuildingConstructionResource item2 = new BuildingConstructionResource(additionalInput.ResourceData)
						{
							Count = 0,
							Max = additionalInput.Value
						};
						_currBuildRequirements.Add(item2);
						if (!_buildRequirementIndices.ContainsKey(additionalInput.ResourceData))
						{
							_buildRequirementIndices.Add(additionalInput.ResourceData, _currBuildRequirements.Count - 1);
						}
					}
				}
				if (keepResources)
				{
					AddOldResources(list);
					CollectionPool<List<BuildingConstructionResource>, BuildingConstructionResource>.Release(list);
				}
			}
		}

		public virtual bool RequiresAdditionalResourceInputs()
		{
			return !_isUpgrading;
		}

		public override void Update()
		{
		}

		public bool AllRequirementsMet()
		{
			foreach (BuildingConstructionResource currBuildRequirement in _currBuildRequirements)
			{
				if (currBuildRequirement.Count < currBuildRequirement.Max)
				{
					return false;
				}
			}
			return true;
		}

		protected virtual void ReceivedAllModules()
		{
			if (_isUpgrading)
			{
				Upgrade(newUpgrade: true);
			}
			else if (_buildingObjectData.ConditionToWorkIsMet)
			{
				CreateResources();
			}
		}

		public int GetSmallestMultiplier(out int smallestAmountOfResources)
		{
			if (BuildRequirements.Count == 0)
			{
				smallestAmountOfResources = 0;
				return 0;
			}
			smallestAmountOfResources = int.MaxValue;
			foreach (BuildingConstructionResource buildRequirement in BuildRequirements)
			{
				smallestAmountOfResources = Mathf.Min(smallestAmountOfResources, buildRequirement.Max);
			}
			int num = 1;
			bool flag = false;
			while (!flag)
			{
				flag = true;
				foreach (BuildingConstructionResource buildRequirement2 in BuildRequirements)
				{
					if (buildRequirement2.Max * num % smallestAmountOfResources != 0)
					{
						flag = false;
						num++;
						break;
					}
				}
			}
			return num;
		}

		protected void CreateResources()
		{
			_hasResources = true;
			OnCreatedResources.Fire(this);
			if (!_needsDroneToTakeOutput)
			{
				ClearBuildingResources();
			}
		}

		public void ClearBuildingResources()
		{
			_hasResources = false;
			if (_isUpgrading)
			{
				InitializeRequirements(CurrentUpgrade.CostMultiplier);
			}
			else
			{
				InitializeRequirements(_buildingObjectData.ProducingCostMultiplier);
			}
			OnClearedResources.Fire();
		}

		public IEnumerable<(ResourceDataSO, int)> GetCurrentOutputs()
		{
			foreach (BuildingObjectData.BuildingResourceData resourceOutput in _buildingObjectData.ResourceOutputs)
			{
				int resourceOutputAtStage = _buildingObjectData.GetResourceOutputAtStage(resourceOutput.ResourceData, _currentBuildingStage);
				float num = _islandObject.OverclockData.OverclockMultiplier + _overclockLeftoverCounter;
				int num2 = Mathf.FloorToInt((float)resourceOutputAtStage * num);
				float num3 = (float)num2 / (float)resourceOutputAtStage;
				_overclockLeftoverCounter = num - num3;
				yield return (resourceOutput.ResourceData, num2);
			}
		}

		public void SetBuildingActive(bool active)
		{
			_isBuildingActive = active;
			if (active)
			{
				CallCanReceiveNewResources();
			}
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			_buildingReceivedResourceEvent.Fire(new BuildingReceivedResourceData
			{
				BuildingBehaviour = this,
				Resource = resource
			});
			if (_buildingCompleted)
			{
				BuildingCompletedAddResource(resource, inputData);
			}
			else if (resource is ShapeResource shapeResource)
			{
				AddShape(shapeResource.ShapeData);
			}
			else
			{
				AddNonShapeResource(resource);
			}
		}

		protected virtual void BuildingCompletedAddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			if (resource is ShapeResource shapeResource)
			{
				AddShape(shapeResource.ShapeData);
			}
			else
			{
				AddNonShapeResource(resource);
			}
		}

		public void AddShape(ShapeData shapeData)
		{
			foreach (BuildingConstructionResource currBuildRequirement in _currBuildRequirements)
			{
				if (currBuildRequirement is ShapeConstructionResource shapeConstructionResource)
				{
					bool num = shapeConstructionResource.Count >= shapeConstructionResource.Max;
					bool flag = num || shapeConstructionResource.IsShape(shapeData);
					if (!num && flag)
					{
						currBuildRequirement.Count++;
						OnShapeAdded.Fire(shapeConstructionResource.ShapeData, currBuildRequirement.Count);
						CheckIfAllRequirementsMet();
						break;
					}
				}
			}
		}

		public void AddNonShapeResource(Resource resource)
		{
			BuildingConstructionResource buildingConstructionResource = _currBuildRequirements[_buildRequirementIndices[resource.Data]];
			if (buildingConstructionResource.Count < buildingConstructionResource.Max)
			{
				buildingConstructionResource.Count++;
				OnShapeAdded.Fire(null, 0);
				CheckIfAllRequirementsMet();
			}
		}

		public void CheckIfAllRequirementsMet()
		{
			if (AllRequirementsMet())
			{
				ReceivedAllModules();
			}
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			if (!_isUpgrading && !_buildingObjectData.ConditionToWorkIsMet)
			{
				return false;
			}
			if (_buildingCompleted)
			{
				return BuildingCompletedCanReceiveResource(resource, inputData, position);
			}
			return BuildingNotCompletedCanReceiveResource(resource, inputData, position);
		}

		private bool BuildingNotCompletedCanReceiveResource(Resource resource, FactoryObjectData.InputData _ = default(FactoryObjectData.InputData), Vector3Int __ = default(Vector3Int))
		{
			lock (this)
			{
				if ((_hasResources && !_isUpgrading) || !_isBuildingActive)
				{
					return false;
				}
				if (resource is ShapeResource shapeResource)
				{
					foreach (BuildingConstructionResource currBuildRequirement in _currBuildRequirements)
					{
						if (currBuildRequirement is ShapeConstructionResource shapeConstructionResource && shapeConstructionResource.Count < shapeConstructionResource.Max && shapeConstructionResource.IsShape(shapeResource.ShapeData))
						{
							return true;
						}
					}
					return false;
				}
				if (!_buildRequirementIndices.TryGetValue(resource.Data, out var value))
				{
					return false;
				}
				BuildingConstructionResource buildingConstructionResource = _currBuildRequirements[value];
				return buildingConstructionResource.Count < buildingConstructionResource.Max;
			}
		}

		protected virtual bool BuildingCompletedCanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			return BuildingNotCompletedCanReceiveResource(resource, inputData, position);
		}

		public override void RemoveResource(Resource resource)
		{
		}

		public virtual void StartUpgrading()
		{
			if (!_isUpgrading && !MaxBuildingStageReached)
			{
				if (MaxLockedBuildingStageReached)
				{
					this.LogError($"Cannot upgrade this building past max locked level: {_buildingObjectData.BuildingMaxLockedStage}", "StartUpgrading", 498);
					return;
				}
				_isUpgrading = true;
				InitializeRequirements(CurrentUpgrade.CostMultiplier, keepResources: true);
				_analyticsData.OnStartedUpgrade(_buildingObjectData.DioramaSave.Name, $"BuildingStage_{_currentBuildingStage}", 0);
				BuildingBehaviour.OnBuildingStartUpgrade();
				OnUpgradeStateChanged.Fire(_isUpgrading);
			}
		}

		public void StopUpgrading()
		{
			if (_isUpgrading)
			{
				_isUpgrading = false;
				InitializeRequirements(_buildingObjectData.ProducingCostMultiplier, keepResources: true);
				OnUpgradeStateChanged.Fire(_isUpgrading);
				_analyticsData.OnFailedUpgrade(_buildingObjectData.DioramaSave.Name, $"BuildingStage_{_currentBuildingStage}", 0);
			}
		}

		private void AddOldResources(IReadOnlyList<BuildingConstructionResource> oldBuildRequirements)
		{
			for (int i = 0; i < _currBuildRequirements.Count; i++)
			{
				if (!(_currBuildRequirements[i] is ShapeConstructionResource shapeConstructionResource))
				{
					continue;
				}
				for (int j = 0; j < oldBuildRequirements.Count; j++)
				{
					if (oldBuildRequirements[j] is ShapeConstructionResource shapeConstructionResource2 && !(shapeConstructionResource.ShapeData.GetShapeHash() != shapeConstructionResource2.ShapeData.GetShapeHash()))
					{
						for (int k = 0; k < Mathf.Min(shapeConstructionResource2.Count, shapeConstructionResource.Max); k++)
						{
							AddShape(shapeConstructionResource.ShapeData);
						}
					}
				}
			}
		}

		protected virtual void Upgrade(bool newUpgrade = false)
		{
			_currentBuildingStage++;
			CheckBuildingCompleted();
			_isUpgrading = false;
			InitializeRequirements(_buildingObjectData.ProducingCostMultiplier);
			OnStageCompleted.Fire(_currentBuildingStage - 1);
			BuildingBehaviour.OnBuildingUpgraded(this, _currentBuildingStage);
			_analyticsData.OnUpgradeCompleted(_buildingObjectData.DioramaSave.Name, string.Format("BuildingStage_{0}", _buildingCompleted ? "Complete" : ((object)_currentBuildingStage)), 0);
		}

		private void CheckBuildingCompleted()
		{
			if (_currentBuildingStage > _buildingObjectData.Upgrades.Count)
			{
				_buildingCompleted = true;
				_isUpgrading = false;
				HandleBuildingCompleted();
				InitializeRequirements(_buildingObjectData.ProducingCostMultiplier);
				_analyticsData.BuildingsCompleted++;
			}
		}

		protected virtual void HandleBuildingCompleted()
		{
		}

		public override BehaviourConfigurationDto GetConfiguration()
		{
			return new BuildingBehaviourConfigurationDto();
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			List<int> list = new List<int>();
			foreach (BuildingConstructionResource currBuildRequirement in _currBuildRequirements)
			{
				if (currBuildRequirement is ShapeConstructionResource)
				{
					list.Add(currBuildRequirement.Count);
				}
			}
			return new BuildingBehaviourSaveStateDto
			{
				Stage = _currentBuildingStage,
				IsUpgrading = _isUpgrading,
				IsActive = _isBuildingActive,
				ShapeRequirements = list
			};
		}

		protected void SetSaveState(BuildingBehaviourSaveStateDto saveStateDto)
		{
			while (_currentBuildingStage < saveStateDto.Stage && _currentBuildingStage < _buildingObjectData.Upgrades.Count + 1)
			{
				Upgrade();
			}
			if (saveStateDto.IsUpgrading)
			{
				InitializeRequirements();
				StartUpgrading();
			}
			else
			{
				InitializeRequirements(_buildingObjectData.ProducingCostMultiplier);
			}
			SetBuildingActive(saveStateDto.IsActive);
			for (int i = 0; i < saveStateDto.ShapeRequirements.Count; i++)
			{
				for (int j = 0; j < saveStateDto.ShapeRequirements[i]; j++)
				{
					AddShape((_currBuildRequirements.ElementAt(i) as ShapeConstructionResource).ShapeData);
				}
			}
		}

		public double CalculateEstimatedOutputSpeed()
		{
			if (!base.FactoryObject.TryGetFactoryObjectBehaviour<BuildingCranesBehaviour>(out var behaviour))
			{
				this.DevException("Couldn't find BuildingCranesBehaviour on the attached factory object", "CalculateEstimatedOutputSpeed", 634);
				return 0.0;
			}
			if (_currentBuildingStage == 0)
			{
				return 0.0;
			}
			int num = 0;
			foreach (BuildingConstructionResource buildRequirement in BuildRequirements)
			{
				num += buildRequirement.Max;
			}
			int count = behaviour.Cranes.Count;
			int item = GetCurrentOutputs().ElementAt(0).Item2;
			return (double)Mathf.Round((float)((double)FactoryUpdater.Instance.GetUnscaledStepsPerSecond() / (double)behaviour.UpdateFrequency * 60.0 / ((double)num / (double)count) * (double)item * 100.0)) * 0.01;
		}

		static BuildingBehaviour()
		{
			BuildingBehaviour.OnBuildingUpgraded = delegate
			{
			};
			BuildingBehaviour.OnBuildingStartUpgrade = delegate
			{
			};
		}
	}
}
