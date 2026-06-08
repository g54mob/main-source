using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CEffectCreator : IItemProperty, IAttachableProperty, IComponentData
	{
		public int Source;

		public bool AffectTables;

		public bool AllowMultiple;
	}
}
