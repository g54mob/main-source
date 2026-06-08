using KitchenData;
using XNode;

namespace KitchenEditor
{
	[CreateNodeMenu("Item")]
	public class ItemReferenceNode : ReferenceNode<Item>, IProcessResultNode, IGameDataReference, IProcessNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public ProcessConnection SourceProcesses;

		ProcessConnection IProcessResultNode.SourceProcesses => SourceProcesses;
	}
}
