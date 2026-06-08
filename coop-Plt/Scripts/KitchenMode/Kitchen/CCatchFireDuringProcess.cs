using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CCatchFireDuringProcess : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int Process;

		public float Probability;

		public float BadProbability;
	}
}
