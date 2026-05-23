#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor.Drones;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Variables.Drones;
using Events.FactoryFloor;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using SaveData.FactoryFloor.SaveStates.Drones;
using Unity.Collections;
using UnityEngine;
using Utils;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/HarvesterPadBehaviour", fileName = "HarvesterPadBehaviour", order = 0)]
	public class HarvesterPadBehaviour : ResourceHolderBehaviour
	{
		public MainThreadEvent<int> OnLinkedBuildingsCountChanged = new MainThreadEvent<int>();

		public MainThreadEvent<BuildingBehaviour> DoCreateDrone = new MainThreadEvent<BuildingBehaviour>();

		public MainThreadEvent OnResourceCountChanged = new MainThreadEvent();

		[SerializeField]
		private HarvestPadDroneBehaviour _droneBehaviour;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabaseSO;

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private DroneMaxAmountPerHarvesterPadData _maxDroneAmountData;

		[SerializeField]
		private int _maxStorage = 16;

		[SerializeField]
		private HarvesterPadOutputResourceEventSO _harvesterPadOutputResourceEvent;

		[SerializeField]
		private float _maxLinkingDistance = 100f;

		[Header("Drone offsets")]
		[SerializeField]
		private Vector3 _harvesterPadDroneOffset;

		[SerializeField]
		private Vector3 _buildingLandingPadDroneOffset;

		[SerializeField]
		private HarvesterPadDroneHeights _droneHeights = new HarvesterPadDroneHeights();

		private OperatorStateBehaviour _operatorStateBehaviour;

		private ReferenceFactoryObjectBehaviour _referenceBehaviour;

		private readonly List<BuildingBehaviour> _linkedBuildings = new List<BuildingBehaviour>();

		private readonly List<HarvestPadDroneBehaviour> _dronesInstances = new List<HarvestPadDroneBehaviour>();

		private readonly List<Resource> _resources = new List<Resource>();

		private bool _hasSpecificResource;

		private ResourceDataSO _resourceData;

		private HarvesterPadBehaviourSaveStateDto _droneSaveState;

		private readonly List<BuildingBehaviour> _buildingsPendingOutput = new List<BuildingBehaviour>();

		public HarvesterPadDroneHeights DroneHeights => _droneHeights;

		public int MaxLinkedBuildings => _maxDroneAmountData.Value;

		public int LinkedBuildingsCount => _linkedBuildings.Count;

		public IEnumerable<BuildingBehaviour> LinkedBuildings => _linkedBuildings;

		public IEnumerable<HarvestPadDroneBehaviour> DroneInstances => _dronesInstances;

		public bool HasSpecificResource => _hasSpecificResource;

		public ResourceDataSO ResourceData => _resourceData;

		public int CurrentResourceCount => _resources.Count;

		public int MaxStorage => _maxStorage;

		public OperatorStateBehaviour OperatorStateBehaviour => _operatorStateBehaviour;

		public float MaxLinkingDistance => _maxLinkingDistance;

		public event Action<HarvestPadDroneBehaviour> OnCreatedDroneMainThread = delegate
		{
		};

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			_hasSpecificResource = false;
			_droneHeights.Reset();
			_operatorStateBehaviour = factoryObject.GetFactoryObjectBehaviour<OperatorStateBehaviour>();
			_referenceBehaviour = factoryObject.GetFactoryObjectBehaviour<ReferenceFactoryObjectBehaviour>();
			_referenceBehaviour.OnAddedReferencedObject += LinkBuilding;
			_referenceBehaviour.OnRemovedReferencedObject += UnlinkBuilding;
			for (int num = _referenceBehaviour.ReferencedObjects.Count - 1; num >= 0; num--)
			{
				ReferenceFactoryObjectBehaviour referenceObject = _referenceBehaviour.ReferencedObjects[num];
				LinkBuilding(referenceObject);
			}
			HarvesterPadBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<HarvesterPadBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				ApplySaveState(behaviourSaveStateDto);
			}
			DoCreateDrone.RegisterMainThread(OnResourceCreated);
		}

		public override void UnInit()
		{
			_referenceBehaviour.OnAddedReferencedObject -= LinkBuilding;
			_referenceBehaviour.OnRemovedReferencedObject -= UnlinkBuilding;
			_resources.Clear();
			foreach (HarvestPadDroneBehaviour dronesInstance in _dronesInstances)
			{
				dronesInstance.DestroyDrone();
			}
			_dronesInstances.Clear();
			_buildingsPendingOutput.Clear();
			DoCreateDrone.UnRegisterMainThread(OnResourceCreated);
			base.UnInit();
		}

		public override void HandleOutputResource(Resource resource, int outputIndex)
		{
			_harvesterPadOutputResourceEvent.Fire(resource);
			_resources.RemoveAt(_resources.Count - 1);
			OnResourceCountChanged.Fire();
			if (LinkedBuildingsCount == 0 && _resources.Count == 0)
			{
				_hasSpecificResource = false;
				_resourceData = null;
			}
			TrySpawnDrone();
			base.HandleOutputResource(resource, outputIndex);
		}

		public void LinkBuilding(ReferenceFactoryObjectBehaviour referenceObject)
		{
			if (!TryLinkBuilding(referenceObject))
			{
				_referenceBehaviour.RemoveReference(referenceObject);
			}
		}

		public bool TryLinkBuilding(ReferenceFactoryObjectBehaviour referenceObject)
		{
			if (_linkedBuildings.Count >= MaxLinkedBuildings)
			{
				return false;
			}
			if (!referenceObject.FactoryObject.TryGetFactoryObjectBehaviour<BuildingBehaviour>(out var behaviour) || _linkedBuildings.Contains(behaviour))
			{
				return false;
			}
			if (!IsPointInsideLinkingDistance(referenceObject.Position))
			{
				return false;
			}
			if (behaviour.BuildingObjectData.ResourceOutputs.Count == 0)
			{
				this.LogError("Failed to link to building " + behaviour.BuildingObjectData.name + " because it has no ResourceOutputs", "TryLinkBuilding", 151);
				return false;
			}
			if (_hasSpecificResource && _resourceData != behaviour.BuildingObjectData.ResourceOutputs[0].ResourceData)
			{
				return false;
			}
			_linkedBuildings.Add(behaviour);
			_factoryObject.SoftLink(behaviour.FactoryObject);
			behaviour.FactoryObject.SoftLink(_factoryObject);
			_hasSpecificResource = true;
			_resourceData = behaviour.BuildingObjectData.ResourceOutputs[0].ResourceData;
			TryApplySaveStateForLink(behaviour, referenceObject.ReferenceID, _droneSaveState);
			behaviour.OnCreatedResources.RegisterMainThread(OnResourceCreated);
			if (behaviour.HasResources)
			{
				OnResourceCreated(behaviour);
			}
			OnLinkedBuildingsCountChanged.Fire(LinkedBuildingsCount);
			return true;
		}

		public void UnlinkBuilding(ReferenceFactoryObjectBehaviour referenceObject)
		{
			UnlinkBuilding(referenceObject.FactoryObject.GetFactoryObjectBehaviour<BuildingBehaviour>());
		}

		public void UnlinkBuilding(BuildingBehaviour buildingBehaviour)
		{
			for (int num = _dronesInstances.Count - 1; num >= 0; num--)
			{
				if (_dronesInstances[num].BuildingBehaviour == buildingBehaviour)
				{
					DestroyDrone(num);
				}
			}
			buildingBehaviour.FactoryObject.UnlinkSoft(_factoryObject);
			_factoryObject.UnlinkSoft(buildingBehaviour.FactoryObject);
			_linkedBuildings.Remove(buildingBehaviour);
			_buildingsPendingOutput.Remove(buildingBehaviour);
			buildingBehaviour.OnCreatedResources.UnRegisterMainThread(OnResourceCreated);
			if (LinkedBuildingsCount == 0 && _resources.Count == 0)
			{
				_hasSpecificResource = false;
				_resourceData = null;
			}
			OnLinkedBuildingsCountChanged.Fire(LinkedBuildingsCount);
		}

		public void UnlinkFromAllBuildings()
		{
			for (int num = _linkedBuildings.Count - 1; num >= 0; num--)
			{
				UnlinkBuilding(_linkedBuildings[num]);
			}
		}

		public override void Process(int step)
		{
			base.Process(step);
			UpdateDrones();
			TryOutputResource();
		}

		private void TrySpawnDrone()
		{
			if (!CanReceiveResourcesCountingDrones())
			{
				return;
			}
			while (_buildingsPendingOutput.Count > 0)
			{
				if (_buildingsPendingOutput[0].HasResources)
				{
					DoCreateDrone.Fire(_buildingsPendingOutput[0]);
				}
				_buildingsPendingOutput.RemoveAtSwapBack(0);
			}
		}

		public override void Update()
		{
		}

		private void TryOutputResource()
		{
			if (_resources.Count > 0 && !IsTryingToOutput())
			{
				List<Resource> resources = _resources;
				TryOutput(resources[resources.Count - 1], 0);
			}
		}

		private void OnResourceCreated(BuildingBehaviour buildingBehaviour)
		{
			if (!CanReceiveResourcesCountingDrones())
			{
				if (!_buildingsPendingOutput.Contains(buildingBehaviour))
				{
					_buildingsPendingOutput.Add(buildingBehaviour);
				}
				return;
			}
			if (buildingBehaviour.HasResources)
			{
				CreateDrone(buildingBehaviour);
			}
			_buildingsPendingOutput.Remove(buildingBehaviour);
		}

		private HarvestPadDroneBehaviour CreateDrone(BuildingBehaviour buildingBehaviour, HarvesterPadDroneSaveStateDto saveState = null)
		{
			HarvestPadDroneBehaviour freeDroneInstance = GetFreeDroneInstance();
			freeDroneInstance.Init(this, buildingBehaviour, buildingBehaviour.BuildingLandingPad.GetLandingPadPosition(base.Position) + _buildingLandingPadDroneOffset, base.Position + _harvesterPadDroneOffset, saveState);
			this.OnCreatedDroneMainThread(freeDroneInstance);
			return freeDroneInstance;
		}

		private HarvestPadDroneBehaviour GetFreeDroneInstance()
		{
			foreach (HarvestPadDroneBehaviour dronesInstance in _dronesInstances)
			{
				if (dronesInstance.IsHidden)
				{
					return dronesInstance;
				}
			}
			HarvestPadDroneBehaviour harvestPadDroneBehaviour = UnityEngine.Object.Instantiate(_droneBehaviour);
			_dronesInstances.Add(harvestPadDroneBehaviour);
			return harvestPadDroneBehaviour;
		}

		private void DestroyDrone(int droneIndex)
		{
			_dronesInstances[droneIndex].DestroyDrone();
		}

		private void UpdateDrones()
		{
			foreach (HarvestPadDroneBehaviour dronesInstance in _dronesInstances)
			{
				dronesInstance.Update();
			}
		}

		public void ClearHarvesterPadResources()
		{
			_resources.Clear();
			_hasSpecificResource = false;
			_resourceData = null;
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			int num = ((_resources.Count > 0) ? _resources[0].Data.ID : 0);
			int resourceID = ((_resourceData == null) ? num : _resourceData.ID);
			Dictionary<int, List<HarvesterPadDroneSaveStateDto>> dictionary = new Dictionary<int, List<HarvesterPadDroneSaveStateDto>>();
			foreach (HarvestPadDroneBehaviour dronesInstance in _dronesInstances)
			{
				if (!dronesInstance.IsHidden && dronesInstance.BuildingBehaviour.FactoryObject.TryGetFactoryObjectBehaviour<ReferenceFactoryObjectBehaviour>(out var behaviour))
				{
					if (!dictionary.TryGetValue(behaviour.ReferenceID, out var value))
					{
						value = new List<HarvesterPadDroneSaveStateDto>(1);
						dictionary.Add(behaviour.ReferenceID, value);
					}
					value.Add(dronesInstance.GetSaveState());
				}
			}
			return new HarvesterPadBehaviourSaveStateDto(resourceID, CurrentResourceCount, dictionary);
		}

		private void ApplySaveState(HarvesterPadBehaviourSaveStateDto saveStateDto)
		{
			_droneSaveState = saveStateDto;
			_resourceData = _resourceDatabaseSO.GetResourceDataFromID(saveStateDto.ResourceID);
			for (int i = 0; i < saveStateDto.ResourceCount; i++)
			{
				Resource resource = _resourceFactory.CreateResource(_resourceData);
				if (resource != null)
				{
					_resources.Add(resource);
				}
			}
			foreach (BuildingBehaviour linkedBuilding in _linkedBuildings)
			{
				if (linkedBuilding.FactoryObject.TryGetFactoryObjectBehaviour<ReferenceFactoryObjectBehaviour>(out var behaviour))
				{
					TryApplySaveStateForLink(linkedBuilding, behaviour.ReferenceID, saveStateDto);
				}
			}
			OnResourceCountChanged.Fire();
		}

		private bool TryApplySaveStateForLink(BuildingBehaviour buildingBehaviour, int referenceID, HarvesterPadBehaviourSaveStateDto saveStateDto)
		{
			if (saveStateDto == null || saveStateDto.DroneSaveStates == null)
			{
				return false;
			}
			if (!saveStateDto.DroneSaveStates.TryGetValue(referenceID, out var value))
			{
				return false;
			}
			_droneSaveState.DroneSaveStates.Remove(referenceID);
			foreach (HarvesterPadDroneSaveStateDto item in value)
			{
				CreateDrone(buildingBehaviour, item);
			}
			return true;
		}

		public bool CanReceiveResourcesCountingDrones(int skipDrones = 3)
		{
			int num = 0;
			foreach (HarvestPadDroneBehaviour dronesInstance in _dronesInstances)
			{
				if (skipDrones > 0)
				{
					skipDrones--;
					continue;
				}
				foreach (KeyValuePair<ResourceDataSO, int> resource in dronesInstance.Resources)
				{
					num += resource.Value;
				}
			}
			return CanReceiveResources(num);
		}

		public bool CanReceiveResources(int resourceCount = 0)
		{
			return CurrentResourceCount + resourceCount < _maxStorage;
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			_resources.Add(resource);
			OnResourceCountChanged.Fire();
		}

		public int GetDroppingDroneCount()
		{
			int num = 0;
			foreach (HarvestPadDroneBehaviour dronesInstance in _dronesInstances)
			{
				if (dronesInstance.State == HarvestPadDroneBehaviour.HarvestPadDroneState.WaitingToDropResources || dronesInstance.State == HarvestPadDroneBehaviour.HarvestPadDroneState.DroppingResources)
				{
					num++;
				}
			}
			return num;
		}

		public override string ToString()
		{
			return $"Linked buildings: {_linkedBuildings.Count}";
		}

		public bool IsPointInsideLinkingDistance(Vector3 point)
		{
			return IsPointInsideLinkingDistance(base.FactoryObject.Position, point);
		}

		public bool IsPointInsideLinkingDistance(Vector3 fromPosition, Vector3 point)
		{
			return (fromPosition - point).sqrMagnitude < _maxLinkingDistance * _maxLinkingDistance;
		}
	}
}
