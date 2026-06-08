using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CQueueModifier : IEffectType, IAttachableProperty, IComponentData
	{
		public Factor PatienceFactor;
	}
}
