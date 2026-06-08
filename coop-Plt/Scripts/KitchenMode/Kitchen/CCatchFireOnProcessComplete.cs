using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CCatchFireOnProcessComplete : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public float Probability;
	}
}
