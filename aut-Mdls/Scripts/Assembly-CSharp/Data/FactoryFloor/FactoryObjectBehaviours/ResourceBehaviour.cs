using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using UnityEngine;

namespace Data.FactoryFloor.FactoryObjectBehaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/ResourceBehaviour", fileName = "ResourceBehaviour", order = 0)]
	public class ResourceBehaviour : FactoryObjectBehaviour
	{
		[SerializeField]
		private ResourceDataSO _resourceData;

		public ResourceDataSO ResourceData => _resourceData;

		public override void Update()
		{
		}

		protected void SetResourceData(ResourceDataSO resourceData)
		{
			_resourceData = resourceData;
		}
	}
}
