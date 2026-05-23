using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Events.FactoryFloor;
using UnityEngine;

namespace Data.FactoryFloor.FactoryObjectBehaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/ScrapperBehaviour", fileName = "ScrapperBehaviour", order = 0)]
	public class ScrapperBehaviour : ResourceHolderBehaviour
	{
		[SerializeField]
		private ResourceScrappedEvent _resourceScrappedEvent;

		public override void Update()
		{
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			_resourceScrappedEvent.Fire(resource);
			StartActivity();
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
