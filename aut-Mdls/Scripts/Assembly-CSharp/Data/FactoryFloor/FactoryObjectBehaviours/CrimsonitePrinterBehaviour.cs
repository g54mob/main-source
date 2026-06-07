using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Variables;
using UnityEngine;

namespace Data.FactoryFloor.FactoryObjectBehaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/CrimsonitePrinter", fileName = "CrimsonitePrinterBehaviour", order = 0)]
	public class CrimsonitePrinterBehaviour : ResourceHolderBehaviour
	{
		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private ResourceDataSO _resourceData;

		[SerializeField]
		private MainThreadBoolVariableSO _isMonumentChargedSO;

		private Resource _resource;

		public override void Init(FactoryObject factoryObject)
		{
			throw new NotIncludedInDemoException();
		}

		public override void Update()
		{
			throw new NotIncludedInDemoException();
		}

		private void TryOutput()
		{
			throw new NotIncludedInDemoException();
		}

		private Resource GetCopyResource(Resource resource)
		{
			throw new NotIncludedInDemoException();
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			return true;
		}

		public override void RemoveResource(Resource resource)
		{
		}
	}
}
