#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Freighter;
using Data.FactoryFloor.Maps;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Variables;
using Logic.Freighters;
using Logic.Threading.Events;
using Presentation.Locators;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;
using Utils;

namespace Data.FactoryFloor.FactoryObjectBehaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/Freight Hub", fileName = "FreightHubBehaviour", order = 0)]
	public class FreightHubBehaviour : ResourceHolderBehaviour
	{
		public struct FreightHubSlot
		{
			public Resource Resource;

			public int Amount;

			public bool HasResource => Amount > 0;

			public FreightHubSlot GetCopy()
			{
				return new FreightHubSlot
				{
					Resource = Resource,
					Amount = Amount
				};
			}
		}

		public const int MaxStorageSlots = 4;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private IntVariableSO _maxStorage;

		[SerializeField]
		private FreightersManagerLocator _freightersManagerLocator;

		[SerializeField]
		private BoolVariableSO _isCurrentlyUsingMoveToolSO;

		[SerializeField]
		private FreightersNameGenerator _freightersNameGenerator;

		private string _customName;

		private int _occupyingFreighterId;

		private bool _isOccupied;

		private List<int> _freighterQueue = new List<int>();

		private OperatorStateBehaviour _operatorStateBehaviour;

		private ReferenceFactoryObjectBehaviour _referenceBehaviour;

		private readonly FreightHubSlot[] _inSlots = new FreightHubSlot[4];

		private readonly FreightHubSlot[] _outSlots = new FreightHubSlot[4];

		public MainThreadEvent<int, FreightHubSlot> OnInSlotChanged = new MainThreadEvent<int, FreightHubSlot>();

		public MainThreadEvent<int, FreightHubSlot> OnOutSlotChanged = new MainThreadEvent<int, FreightHubSlot>();

		public MainThreadEvent<int, FreightHubSlot, bool> OnLoadCrateIntoFreighter = new MainThreadEvent<int, FreightHubSlot, bool>();

		public MainThreadEvent<int, FreightHubSlot, bool> OnUnloadCrateFromFreighter = new MainThreadEvent<int, FreightHubSlot, bool>();

		public string CustomName => _customName;

		public int OccupyingFreighterId => _occupyingFreighterId;

		public bool IsOccupied => _isOccupied;

		public int MaxInStorage => _maxStorage.Value;

		public int MaxOutStorage => _maxStorage.Value;

		public static event Action OnFreightHubsChanged;

		public FreightHubSlot GetInSlot(int i)
		{
			return _inSlots[i];
		}

		public FreightHubSlot GetOutSlot(int i)
		{
			return _outSlots[i];
		}

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			_operatorStateBehaviour = factoryObject.GetFactoryObjectBehaviour<OperatorStateBehaviour>();
			_referenceBehaviour = factoryObject.GetFactoryObjectBehaviour<ReferenceFactoryObjectBehaviour>();
			_referenceBehaviour.OnReferencesInitialized += ResolveFreighterPathProblemsOnInit;
			_maxStorage.ValueChanged += OnMaxStorageChanged;
			FreightHubSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<FreightHubSaveStateDto>();
			ApplySaveState(behaviourSaveStateDto);
			for (int i = 0; i < 4; i++)
			{
				OnInSlotChanged.Fire(i, _inSlots[i]);
				OnOutSlotChanged.Fire(i, _outSlots[i]);
			}
			OnOutputResource.RegisterInline(OnOutput);
		}

		public override void UnInit()
		{
			_referenceBehaviour.OnUnInit += ResolveFreighterPathProblemsOnUnInit;
			_maxStorage.ValueChanged -= OnMaxStorageChanged;
			OnOutputResource.UnRegisterInline(OnOutput);
			_freightersNameGenerator.ReturnFreightHubName(_customName);
			ClearFreighterQueue();
			base.UnInit();
		}

		private void OnMaxStorageChanged(int _)
		{
			CallCanReceiveNewResources();
		}

		private void ResolveFreighterPathProblemsOnInit(ReferenceFactoryObjectBehaviour _)
		{
			_referenceBehaviour.OnReferencesInitialized -= ResolveFreighterPathProblemsOnUnInit;
			foreach (FreighterObject item in _freightersManagerLocator.Manager.GetFreightersWithFreightHubInPath(_referenceBehaviour.ReferenceID))
			{
				item.ResolveFreightHubInPathInit(_referenceBehaviour.ReferenceID);
			}
			FreightHubBehaviour.OnFreightHubsChanged();
		}

		private void ResolveFreighterPathProblemsOnUnInit(FactoryObjectBehaviour _)
		{
			_referenceBehaviour.OnUnInit -= ResolveFreighterPathProblemsOnUnInit;
			foreach (FreighterObject item in _freightersManagerLocator.Manager.GetFreightersWithFreightHubInPath(_referenceBehaviour.ReferenceID))
			{
				item.ResolveFreightHubInPathUnInit(_referenceBehaviour.ReferenceID, _isCurrentlyUsingMoveToolSO.Value);
			}
			FreightHubBehaviour.OnFreightHubsChanged();
		}

		public override void Update()
		{
			for (int i = 0; i < 4; i++)
			{
				TryOutputShape(i);
			}
		}

		private void OnOutput(Resource resource, int outputIndex)
		{
			_outSlots[outputIndex].Amount--;
			if (_outSlots[outputIndex].Amount <= 0)
			{
				_outSlots[outputIndex] = default(FreightHubSlot);
			}
			OnOutSlotChanged.Fire(outputIndex, _outSlots[outputIndex]);
		}

		private void TryOutputShape(int outputIndex)
		{
			if (_outSlots[outputIndex].HasResource && !IsTryingToOutputAtIndex(outputIndex))
			{
				Resource copyResource = GetCopyResource(_outSlots[outputIndex].Resource);
				TryOutput(copyResource, outputIndex);
			}
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			lock (this)
			{
				base.AddResource(resource, inputData);
				TakeResourceFromInputBuffer(inputData.Index);
				if (!_inSlots[inputData.Index].HasResource)
				{
					_inSlots[inputData.Index].Resource = resource;
					_inSlots[inputData.Index].Amount = 1;
					OnInSlotChanged.Fire(inputData.Index, _inSlots[inputData.Index]);
				}
				else if (!IsSameResourceAsInSlot(resource, inputData.Index))
				{
					_operatorStateBehaviour.SetStateWrongInputTypeGeneral();
					this.LogError($"This slot has {_inSlots[inputData.Index].Resource.Data} and cannot accept {resource.Data} in the slot {inputData.Index}", "AddResource", 186);
				}
				else if (_inSlots[inputData.Index].Amount >= MaxInStorage)
				{
					this.LogError("This is full and cannot accept more", "AddResource", 193);
				}
				else
				{
					_operatorStateBehaviour.ResetState();
					_inSlots[inputData.Index].Amount++;
					OnInSlotChanged.Fire(inputData.Index, _inSlots[inputData.Index]);
				}
			}
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			if (!base.CanReceiveResource(resource, inputData, position))
			{
				return false;
			}
			if (!_inSlots[inputData.Index].HasResource)
			{
				_operatorStateBehaviour.ResetState();
				return true;
			}
			if (_inSlots[inputData.Index].Amount >= MaxInStorage)
			{
				return false;
			}
			bool num = IsSameResourceAsInSlot(resource, inputData.Index);
			if (!num)
			{
				_operatorStateBehaviour.SetStateWrongInputTypeGeneral();
				return num;
			}
			_operatorStateBehaviour.ResetState();
			return num;
		}

		public void ResetAllSlots()
		{
			_operatorStateBehaviour.ResetState();
			for (int i = 0; i < 4; i++)
			{
				_inSlots[i] = default(FreightHubSlot);
				_outSlots[i] = default(FreightHubSlot);
				OnInSlotChanged.Fire(i, _inSlots[i]);
				OnOutSlotChanged.Fire(i, _outSlots[i]);
			}
			CallCanReceiveNewResources();
		}

		public void SetInSlot(int slotIndex, FreightHubSlot hubSlot)
		{
			if (hubSlot.Amount <= 0)
			{
				ClearInSlot(slotIndex);
				return;
			}
			if (hubSlot.Amount > _maxStorage.Value)
			{
				hubSlot.Amount = _maxStorage.Value;
			}
			_inSlots[slotIndex] = hubSlot;
			OnInSlotChanged.Fire(slotIndex, hubSlot);
			CallClearedInputBufferEvent(slotIndex);
		}

		public void SetOutSlot(int slotIndex, FreightHubSlot hubSlot)
		{
			if (hubSlot.Amount <= 0)
			{
				ClearOutSlot(slotIndex);
				return;
			}
			if (hubSlot.Amount > _maxStorage.Value)
			{
				hubSlot.Amount = _maxStorage.Value;
			}
			_outSlots[slotIndex] = hubSlot;
			OnOutSlotChanged.Fire(slotIndex, hubSlot);
		}

		public void LoadCrateIntoFreighter(int slotIndex, FreightHubSlot slot, bool alreadyHasResource)
		{
			OnLoadCrateIntoFreighter.Fire(slotIndex, slot, alreadyHasResource);
		}

		public void UnloadCrateFromFreighter(int slotIndex, FreightHubSlot slot, bool hasLeftOvers)
		{
			OnUnloadCrateFromFreighter.Fire(slotIndex, slot, hasLeftOvers);
		}

		public void ClearInSlot(int slotIndex)
		{
			_inSlots[slotIndex] = default(FreightHubSlot);
			OnInSlotChanged.Fire(slotIndex, _inSlots[slotIndex]);
			_operatorStateBehaviour.ResetState();
			CallClearedInputBufferEvent(slotIndex);
		}

		public void ClearOutSlot(int slotIndex)
		{
			_outSlots[slotIndex] = default(FreightHubSlot);
			OnOutSlotChanged.Fire(slotIndex, _outSlots[slotIndex]);
			StopTryingToOutput();
		}

		public void PassInSlot(int slotIndex)
		{
			if (_outSlots[slotIndex].HasResource && IsSameResourceAsInSlot(_outSlots[slotIndex].Resource, slotIndex))
			{
				_outSlots[slotIndex].Amount += _inSlots[slotIndex].Amount;
				_inSlots[slotIndex] = default(FreightHubSlot);
			}
			else
			{
				_outSlots[slotIndex] = _inSlots[slotIndex];
				_inSlots[slotIndex] = default(FreightHubSlot);
			}
			OnInSlotChanged.Fire(slotIndex, _inSlots[slotIndex]);
			OnOutSlotChanged.Fire(slotIndex, _outSlots[slotIndex]);
			_operatorStateBehaviour.ResetState();
			CallClearedInputBufferEvent(slotIndex);
		}

		public void SetCustomName(string name)
		{
			_freightersNameGenerator.ReturnFreighterName(_customName);
			_customName = name;
		}

		private void ApplySaveState(FreightHubSaveStateDto saveStateDto)
		{
			if (saveStateDto == null)
			{
				_customName = _freightersNameGenerator.GetFreightHubName();
				return;
			}
			_customName = saveStateDto.CustomName;
			_freightersNameGenerator.UseFreightHubName(_customName);
			for (int i = 0; i < 4; i++)
			{
				_inSlots[i] = default(FreightHubSlot);
				if (saveStateDto.InResourceAmounts[i] > 0 && saveStateDto.InResources[i] != null)
				{
					_inSlots[i].Resource = saveStateDto.InResources[i].ToResource(_resourceFactory, _resourceDatabase);
					_inSlots[i].Amount = saveStateDto.InResourceAmounts[i];
				}
				_outSlots[i] = default(FreightHubSlot);
				if (saveStateDto.OutResourceAmounts[i] > 0 && saveStateDto.OutResources[i] != null)
				{
					_outSlots[i].Resource = saveStateDto.OutResources[i].ToResource(_resourceFactory, _resourceDatabase);
					_outSlots[i].Amount = saveStateDto.OutResourceAmounts[i];
				}
			}
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			int islandId = -1;
			if (_islandLayer.TryGetIslandAtWorldPosition(base.Position, out var islandObject))
			{
				islandId = islandObject.CreatedId;
			}
			FreightHubSaveStateDto freightHubSaveStateDto = new FreightHubSaveStateDto
			{
				InResources = new ResourceDto[_inSlots.Length],
				InResourceAmounts = new int[_inSlots.Length],
				OutResources = new ResourceDto[_inSlots.Length],
				OutResourceAmounts = new int[_inSlots.Length],
				IslandId = islandId,
				CustomName = _customName
			};
			for (int i = 0; i < 4; i++)
			{
				if (_inSlots[i].HasResource)
				{
					freightHubSaveStateDto.InResources[i] = new ResourceDto(_inSlots[i].Resource);
					freightHubSaveStateDto.InResourceAmounts[i] = _inSlots[i].Amount;
				}
				if (_outSlots[i].HasResource)
				{
					freightHubSaveStateDto.OutResources[i] = new ResourceDto(_outSlots[i].Resource);
					freightHubSaveStateDto.OutResourceAmounts[i] = _outSlots[i].Amount;
				}
			}
			return freightHubSaveStateDto;
		}

		private Resource GetCopyResource(Resource resource)
		{
			if (resource is ShapeResource shapeResource)
			{
				return _resourceFactory.CreateShapeResource(shapeResource.ShapeData);
			}
			if (resource is ColorResource colorResource)
			{
				return _resourceFactory.CreateResource(resource.Data, colorResource.ColorValue);
			}
			return _resourceFactory.CreateResource(resource.Data);
		}

		private bool IsSameResourceAsSlot(Resource resource, in FreightHubSlot slot)
		{
			if (resource.Data == slot.Resource.Data && !(resource is ShapeResource))
			{
				return true;
			}
			if (resource is ShapeResource shapeResource && slot.Resource is ShapeResource shapeResource2)
			{
				return shapeResource2.ShapeData.RotationIndependantHash.Contains(shapeResource.ShapeData.GetShapeHash());
			}
			return false;
		}

		public void StartOccupying(FreighterObject freighterObject)
		{
			if (!_isOccupied)
			{
				_occupyingFreighterId = freighterObject.CreatedId;
				_isOccupied = true;
			}
		}

		public void StopOccupying(FreighterObject freighterObject)
		{
			if (_isOccupied && _occupyingFreighterId == freighterObject.CreatedId)
			{
				_occupyingFreighterId = -1;
				_isOccupied = false;
				OccupyByNextFreighterInQueue();
			}
		}

		public void RemoveFromQueue(FreighterObject freighterObject)
		{
			_freighterQueue.Remove(freighterObject.CreatedId);
		}

		private void OccupyByNextFreighterInQueue()
		{
			FreighterObject freighterObject;
			while (_freighterQueue.Count > 0 && !_freightersManagerLocator.Manager.TryGetFreighter(_freighterQueue[0], out freighterObject))
			{
				Dequeue();
			}
			if (_freighterQueue.Count != 0)
			{
				_freightersManagerLocator.Manager.TryGetFreighter(_freighterQueue[0], out freighterObject);
				Dequeue();
				StartOccupying(freighterObject);
				freighterObject.Movement.RemoveFromQueue();
			}
			void Dequeue()
			{
				_freighterQueue.RemoveAt(0);
				for (int i = 0; i < _freighterQueue.Count; i++)
				{
					if (_freightersManagerLocator.Manager.TryGetFreighter(_freighterQueue.ElementAt(i), out var freighterObject2))
					{
						freighterObject2.Movement.MoveDownInQueue();
					}
				}
			}
		}

		public int QueueFreighter(int createdId)
		{
			if (!_freighterQueue.Contains(createdId))
			{
				_freighterQueue.Add(createdId);
				return _freighterQueue.Count;
			}
			return _freighterQueue.Find((int i) => i == createdId);
		}

		private void ClearFreighterQueue()
		{
			for (int i = 0; i < _freighterQueue.Count; i++)
			{
				if (_freightersManagerLocator.Manager.TryGetFreighter(_freighterQueue[i], out var freighterObject))
				{
					freighterObject.Movement.RemoveFromQueue();
				}
			}
			_freighterQueue.Clear();
		}

		public bool IsSameResourceAsInSlot(Resource resource, int inputIndex)
		{
			return IsSameResourceAsSlot(resource, in _inSlots[inputIndex]);
		}

		public bool IsSameResourceAsOutSlot(Resource resource, int inputIndex)
		{
			return IsSameResourceAsSlot(resource, in _outSlots[inputIndex]);
		}

		public List<FreighterObject> GetFreightersWithFreightHub()
		{
			return _freightersManagerLocator.Manager.GetFreightersWithFreightHubInPath(_referenceBehaviour.ReferenceID);
		}

		static FreightHubBehaviour()
		{
			FreightHubBehaviour.OnFreightHubsChanged = delegate
			{
			};
		}
	}
}
