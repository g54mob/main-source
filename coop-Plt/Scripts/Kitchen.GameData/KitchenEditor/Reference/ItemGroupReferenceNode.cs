using KitchenData;
using XNode;

namespace KitchenEditor.Reference
{
	[CreateNodeMenu("Item Group")]
	public class ItemGroupReferenceNode : ReferenceNode<ItemGroup>, IProcessResultNode, IGameDataReference, IProcessNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public ProcessConnection SourceProcesses;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public ProcessSetConnection Sets;

		ProcessConnection IProcessResultNode.SourceProcesses => SourceProcesses;
	}
}
