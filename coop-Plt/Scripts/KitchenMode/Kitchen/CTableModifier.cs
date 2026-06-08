using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CTableModifier : IEffectType, IAttachableProperty, IComponentData
	{
		public PatienceValues PatienceModifiers;

		public OrderingValues OrderingModifiers;

		public DecorationValues DecorationModifiers;

		public float Attractiveness;
	}
}
