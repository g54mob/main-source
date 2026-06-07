using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Shapes;
using Data.Statistics;
using Events.FactoryFloor;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;
using UnityEngine.Pool;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/ExoportBehaviour", fileName = "ExoportBehaviour", order = 0)]
	public class ExoportBehaviour : ResourceHolderBehaviour
	{
		public MainThreadEvent<ResourceDataSO> OnNewResourceAdded = new MainThreadEvent<ResourceDataSO>();

		public MainThreadEvent<ShapeData> OnNewShapeResourceAdded = new MainThreadEvent<ShapeData>();

		public MainThreadEvent OnResourcesCleared = new MainThreadEvent();

		[SerializeField]
		private ResourceDeliveredEventSO _resourceDeliveredEvent;

		[SerializeField]
		private List<ResourceDataSO> _allowedResources;

		[SerializeField]
		private SerializedDictionary<ResourceDataSO, int> _allowedResourcesMaxAmounts_Demo;

		[SerializeField]
		private StatisticsSO _statisticsSO;

		[SerializeField]
		private List<ShapeDataSO> _allowedModuleChallenges;

		[SerializeField]
		private List<ShapeDataSO> _allowedModuleChallengesDemo;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		private OperatorStateBehaviour _operatorStateBehaviour;

		private readonly HashSet<int> _collectedResources = new HashSet<int>();

		private readonly HashSet<ShapeHashPair> _collectedShapeResources = new HashSet<ShapeHashPair>();

		public SerializedDictionary<ResourceDataSO, int> AllowedResourcesMaxAmountsDemo => _allowedResourcesMaxAmounts_Demo;

		public List<ShapeDataSO> AllowedModuleChallenges => _allowedModuleChallengesDemo;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			_operatorStateBehaviour = factoryObject.GetFactoryObjectBehaviour<OperatorStateBehaviour>();
			ExoportBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<ExoportBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				SetSaveState(behaviourSaveStateDto);
			}
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			_resourceDeliveredEvent.Fire(resource);
			_operatorStateBehaviour.ResetState();
			if (resource is ShapeResource shapeResource)
			{
				AddShapeResource(shapeResource);
			}
			else
			{
				AddNonShapeResource(resource);
			}
		}

		private void AddNonShapeResource(Resource resource)
		{
			if (!_collectedResources.Contains(resource.Data.ID))
			{
				_collectedResources.Add(resource.Data.ID);
				OnNewResourceAdded.Fire(resource.Data);
			}
		}

		private void AddShapeResource(ShapeResource shapeResource)
		{
			ShapeHashPair shapeHash = shapeResource.ShapeData.GetShapeHash();
			if (_collectedShapeResources.Contains(shapeHash))
			{
				return;
			}
			foreach (ShapeDataSO allowedModuleChallenge in AllowedModuleChallenges)
			{
				if (allowedModuleChallenge.Data.RotationIndependantHash.Contains(shapeResource.ShapeData.GetShapeHash()))
				{
					OnNewShapeResourceAdded.Fire(allowedModuleChallenge.Data);
					ShapeHashPair[] rotations = shapeResource.ShapeData.RotationIndependantHash.Rotations;
					foreach (ShapeHashPair item in rotations)
					{
						_collectedShapeResources.Add(item);
					}
					break;
				}
			}
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			if (_allowedResourcesMaxAmounts_Demo.ContainsKey(resource.Data))
			{
				int num = _allowedResourcesMaxAmounts_Demo[resource.Data];
				if (_statisticsSO.GetDeliveredStatistic(resource.Data.ID) >= num)
				{
					_operatorStateBehaviour.SetStateDemoDeliveriesCap();
					return false;
				}
				return true;
			}
			if (resource is ShapeResource shapeResource)
			{
				foreach (ShapeDataSO allowedModuleChallenge in AllowedModuleChallenges)
				{
					if (allowedModuleChallenge.Data.RotationIndependantHash.Contains(shapeResource.ShapeData.GetShapeHash()))
					{
						return true;
					}
				}
			}
			_operatorStateBehaviour.SetStateExpectingBots();
			return false;
		}

		public override void RemoveResource(Resource resource)
		{
		}

		public override void Update()
		{
			if (_collectedResources.Count == 0 && _collectedShapeResources.Count == 0)
			{
				EndActivity();
				return;
			}
			StartActivity();
			_collectedShapeResources.Clear();
			_collectedResources.Clear();
			OnResourcesCleared.Fire();
			CallCanReceiveNewResources();
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			return new ExoportBehaviourSaveStateDto(_collectedResources.ToArray(), _collectedShapeResources);
		}

		private void SetSaveState(ExoportBehaviourSaveStateDto saveStateDto)
		{
			_collectedResources.Clear();
			_collectedShapeResources.Clear();
			_collectedResources.EnsureCapacity(saveStateDto.CollectedResourceIDs.Length);
			_collectedShapeResources.EnsureCapacity(saveStateDto.CollectedShapeResourceHashes.Length);
			int[] collectedResourceIDs = saveStateDto.CollectedResourceIDs;
			foreach (int item in collectedResourceIDs)
			{
				_collectedResources.Add(item);
			}
			string[] collectedShapeResourceHashes = saveStateDto.CollectedShapeResourceHashes;
			foreach (string hashString in collectedShapeResourceHashes)
			{
				_collectedShapeResources.Add(ShapeHashPair.Parse(hashString));
			}
		}

		public void GetAllUniqueResourcesAdded(Action<ResourceDataSO> onResourceAdded, Action<ShapeData> onShapeResourceAdded)
		{
			foreach (int collectedResource in _collectedResources)
			{
				ResourceDataSO resourceDataFromID = _resourceDatabase.GetResourceDataFromID(collectedResource);
				onResourceAdded(resourceDataFromID);
			}
			List<ShapeDataSO> list = CollectionPool<List<ShapeDataSO>, ShapeDataSO>.Get();
			list.AddRange(AllowedModuleChallenges);
			foreach (ShapeHashPair collectedShapeResource in _collectedShapeResources)
			{
				for (int num = list.Count - 1; num >= 0; num--)
				{
					if (list[num].Data.RotationIndependantHash.Contains(collectedShapeResource))
					{
						onShapeResourceAdded(list[num].Data);
						list.RemoveAt(num);
						break;
					}
				}
			}
			CollectionPool<List<ShapeDataSO>, ShapeDataSO>.Release(list);
		}
	}
}
