using System.Collections.Generic;
using Data.FactoryFloor.Drones;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Variables;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using SaveData.FactoryFloor.SaveStates.Drones;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/SupplyTankBehaviour", fileName = "SupplyTankBehaviour", order = 0)]
	public class SupplyTankBehaviour : ResourceHolderBehaviour
	{
		[SerializeField]
		private SupplyTankDroneBehaviour _droneBehaviour;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabaseSO;

		[SerializeField]
		private IntVariableSO _maxLinkedRecipients;

		[SerializeField]
		private int _maxStorage = 16;

		[SerializeField]
		private int _storagePerCapsule = 4;

		[SerializeField]
		private List<Vector3> _dronePositions = new List<Vector3>();

		private bool _isStoringResource;

		private ResourceDataSO _currentResourceData;

		private int _currentResourceAmount;

		private bool[] _currentCapsulesFilled = new bool[4];

		private int[] _currentCapsuleResourceIDs = new int[4];

		private readonly List<int> _possibleIDs = new List<int> { 0, 1, 2, 3 };

		private OperatorStateBehaviour _operatorStateBehaviour;

		private SupplyTankBehaviourSaveStateDto _droneSaveState;

		private ReferenceFactoryObjectBehaviour _referenceBehaviour;

		private Dictionary<SupplyTankRecipientBehaviour, SupplyTankDroneBehaviour> _linkedRecipients = new Dictionary<SupplyTankRecipientBehaviour, SupplyTankDroneBehaviour>();

		public MainThreadEvent<int> OnLinkedRecipientsCountChanged = new MainThreadEvent<int>();

		public MainThreadEvent<SupplyTankDroneBehaviour> OnCreatedDrone = new MainThreadEvent<SupplyTankDroneBehaviour>();

		public MainThreadEvent OnResourceCountChanged = new MainThreadEvent();

		public MainThreadEvent OnResourceAdded = new MainThreadEvent();

		public MainThreadEvent<int, int> OnCapsuleFilled = new MainThreadEvent<int, int>();

		public MainThreadEvent<int> OnCapsuleTaken = new MainThreadEvent<int>();

		public int MaxLinkedRecipients => _maxLinkedRecipients.Value;

		public int LinkedRecipientsCount => _linkedRecipients.Count;

		public int MaxStorage => _maxStorage;

		public bool IsStoringResource => _isStoringResource;

		public ResourceDataSO CurrentResourceData => _currentResourceData;

		public int CurrentResourceAmount => _currentResourceAmount;

		public int StoragePerCapsule => _storagePerCapsule;

		public Dictionary<SupplyTankRecipientBehaviour, SupplyTankDroneBehaviour> LinkedRecipients => _linkedRecipients;

		public override void Init(FactoryObject factoryObject)
		{
			throw new NotIncludedInDemoException();
		}

		public override void UnInit()
		{
			throw new NotIncludedInDemoException();
		}

		private void LinkRecipient(ReferenceFactoryObjectBehaviour referenceObject)
		{
			throw new NotIncludedInDemoException();
		}

		public void UnlinkAllRecipients()
		{
			throw new NotIncludedInDemoException();
		}

		public void UnlinkRecipient(ReferenceFactoryObjectBehaviour referenceObject)
		{
			throw new NotIncludedInDemoException();
		}

		private void UnlinkRecipient(SupplyTankRecipientBehaviour supplyTankRecipientBehaviour)
		{
			throw new NotIncludedInDemoException();
		}

		public override void Process(int step)
		{
			throw new NotIncludedInDemoException();
		}

		public override void Update()
		{
			throw new NotIncludedInDemoException();
		}

		private void TryFillCapsule()
		{
			throw new NotIncludedInDemoException();
		}

		private int GetFreeDroneID()
		{
			return _possibleIDs[0];
		}

		public Vector3 GetFreeDronePosition()
		{
			if (_possibleIDs.Count <= 0)
			{
				return base.FactoryObject.Position;
			}
			return base.FactoryObject.DataPosToWorldPos(_dronePositions[_possibleIDs[0]]);
		}

		private SupplyTankDroneBehaviour CreateDrone(SupplyTankRecipientBehaviour supplyTankRecipientBehaviour)
		{
			throw new NotIncludedInDemoException();
		}

		private void DestroyDrone(SupplyTankRecipientBehaviour supplyTankRecipientBehaviour)
		{
		}

		private void UpdateDrones()
		{
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			return false;
		}

		public bool HasFilledCapsule(int droneID)
		{
			return _currentCapsulesFilled[droneID];
		}

		public int GetCapsuleResourceID(int index)
		{
			return _currentCapsuleResourceIDs[index];
		}

		public (ResourceDataSO resourceData, int amount) TakeCapsule(int droneID)
		{
			ResourceDataSO resourceDataFromID = _resourceDatabaseSO.GetResourceDataFromID(_currentCapsuleResourceIDs[droneID]);
			_currentCapsulesFilled[droneID] = false;
			OnCapsuleTaken.Fire(droneID);
			return (resourceData: resourceDataFromID, amount: _storagePerCapsule);
		}

		public override void RemoveResource(Resource resource)
		{
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			Dictionary<int, SupplyTankDroneSaveStateDto> dictionary = new Dictionary<int, SupplyTankDroneSaveStateDto>();
			foreach (KeyValuePair<SupplyTankRecipientBehaviour, SupplyTankDroneBehaviour> linkedRecipient in _linkedRecipients)
			{
				if (linkedRecipient.Key.FactoryObject.TryGetFactoryObjectBehaviour<ReferenceFactoryObjectBehaviour>(out var behaviour))
				{
					dictionary.Add(behaviour.ReferenceID, linkedRecipient.Value.GetSaveState());
				}
			}
			return new SupplyTankBehaviourSaveStateDto(_isStoringResource, _isStoringResource ? _currentResourceData.ID : (-1), _currentResourceAmount, _currentCapsulesFilled, _currentCapsuleResourceIDs, dictionary);
		}

		private void ApplySaveState(SupplyTankBehaviourSaveStateDto saveStateDto)
		{
		}

		private void TryApplySaveStateForLink(SupplyTankDroneBehaviour droneBehaviour, int referenceID, SupplyTankBehaviourSaveStateDto saveStateDto)
		{
		}

		public override string ToString()
		{
			return $"Linked recipients count: {_linkedRecipients.Count}";
		}
	}
}
