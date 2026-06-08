using KitchenData;
using XNode;

namespace KitchenEditor.Reference
{
	[CreateNodeMenu("Unlock")]
	public class UnlockReferenceNode : ReferenceNode<Unlock>, IUnlockNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public UnlockConnection Prerequisites;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public UnlockConnection Blockers;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public UnlockConnection Unlocks;
	}
}
