using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Logic.Threading.Events;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.FactoryObjectBehaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/Display", fileName = "DisplayBehaviour", order = 0)]
	public class DisplayBehaviour : ResourceHolderBehaviour
	{
		public MainThreadEvent<Resource> OnStoredResourceChanged = new MainThreadEvent<Resource>();

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private ResourceDataSO _shapeResourceData;

		private Resource _storedResource;

		public Resource StoredResource => _storedResource;

		public bool IsConfigured => _storedResource != null;

		public override void Init(FactoryObject factoryObject)
		{
			throw new NotIncludedInDemoException();
		}

		private void ApplySaveState(FactoryObject factoryObject)
		{
			throw new NotIncludedInDemoException();
		}

		public override void Update()
		{
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			throw new NotIncludedInDemoException();
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			throw new NotIncludedInDemoException();
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			throw new NotIncludedInDemoException();
		}

		public override void UnInit()
		{
			throw new NotIncludedInDemoException();
		}

		public void Reset()
		{
			throw new NotIncludedInDemoException();
		}
	}
}
