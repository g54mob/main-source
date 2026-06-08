using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CEffectAtNight : IEffectCondition, IAttachableProperty, IComponentData
	{
		public bool DaytimeOnly;
	}
}
