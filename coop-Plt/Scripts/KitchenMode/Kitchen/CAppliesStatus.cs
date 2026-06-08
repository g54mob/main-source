using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CAppliesStatus : IEffectType, IAttachableProperty, IComponentData
	{
		public DecorationBonus Bonus;
	}
}
