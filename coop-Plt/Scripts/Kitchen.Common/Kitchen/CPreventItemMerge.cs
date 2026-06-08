using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CPreventItemMerge : IItemProperty, IAttachableProperty, IComponentData
	{
		public MergeCondition Condition;
	}
}
