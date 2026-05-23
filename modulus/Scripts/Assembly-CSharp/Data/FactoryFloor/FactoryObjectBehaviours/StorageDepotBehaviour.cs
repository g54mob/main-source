using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Maps;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.FactoryObjectBehaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/Storage Depot", fileName = "StorageDepotBehaviour", order = 0)]
	public class StorageDepotBehaviour : ResourceHolderBehaviour
	{
		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private ResourceDataSO _shapeResourceData;

		[SerializeField]
		private ulong _maxStorage = 1024uL;

		private OperatorStateBehaviour _operatorStateBehaviour;

		private Resource _storedResource;

		private ulong _storedAmount;

		private bool _windUp;

		public MainThreadEvent<ulong> OnStoredAmountChanged = new MainThreadEvent<ulong>();

		public MainThreadEvent<Resource> OnStoredResourceChanged = new MainThreadEvent<Resource>();

		public bool IsConfigured => _storedResource != null;

		public ulong StoredAmount => _storedAmount;

		public Resource StoredResource => _storedResource;

		public ulong MaxStorage => _maxStorage;

		public override void Init(FactoryObject factoryObject)
		{
			throw new NotIncludedInDemoException();
		}

		public override void HandleOutputResource(Resource resource, int outputIndex)
		{
			throw new NotIncludedInDemoException();
		}

		private void TryOutputShape()
		{
			throw new NotIncludedInDemoException();
		}

		private Resource GetCopyResource()
		{
			throw new NotIncludedInDemoException();
		}

		public override void Update()
		{
		}

		public override void Process(int step)
		{
			throw new NotIncludedInDemoException();
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			throw new NotIncludedInDemoException();
		}

		private bool ShapesAreTheSame(Resource newResource)
		{
			throw new NotIncludedInDemoException();
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			throw new NotIncludedInDemoException();
		}

		public override void RemoveResource(Resource resource)
		{
			throw new NotIncludedInDemoException();
		}

		public void ResetStorage()
		{
			throw new NotIncludedInDemoException();
		}

		private void ApplySaveState(FactoryObject factoryObject)
		{
			throw new NotIncludedInDemoException();
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			throw new NotIncludedInDemoException();
		}

		public override BehaviourConfigurationDto GetConfiguration()
		{
			return new StorageDepotBehaviourConfigurationDto();
		}
	}
}
