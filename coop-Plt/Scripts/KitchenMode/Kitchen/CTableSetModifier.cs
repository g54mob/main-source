using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CTableSetModifier : IComponentData
	{
		public PatienceValues PatienceModifiers;

		public OrderingValues OrderingModifiers;

		public DecorationValues DecorationModifiers;

		public float Attractiveness;
	}
}
