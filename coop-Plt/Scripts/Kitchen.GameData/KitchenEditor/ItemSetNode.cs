using System;
using System.Linq;
using KitchenData;
using XNode;

namespace KitchenEditor
{
	[NodeTint("#3E5D5B")]
	[CreateNodeMenu("Combine With")]
	public class ItemSetNode : Node, IProcessNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public Item Items;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public ProcessSetConnection Result;

		public int Min;

		public int Max;

		public bool IsMandatory;

		public bool RequiresUnlock;

		public bool IsOrderOnly;

		public override object GetValue(NodePort port)
		{
			return null;
		}

		public ItemGroup.ItemSet Build(IGameDataObjectMap map)
		{
			Item[] inputValues = GetInputValues("Items", Array.Empty<Item>());
			return new ItemGroup.ItemSet
			{
				Min = Min,
				Max = Max,
				IsMandatory = IsMandatory,
				RequiresUnlock = RequiresUnlock,
				OrderingOnly = IsOrderOnly,
				Items = inputValues.ToList()
			};
		}
	}
}
