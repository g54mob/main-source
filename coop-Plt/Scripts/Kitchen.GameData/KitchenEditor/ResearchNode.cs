using KitchenData;
using XNode;

namespace KitchenEditor
{
	[CreateNodeMenu("Research Upgrade")]
	public class ResearchNode : Node, IResearchNode
	{
		[Output(ShowBackingValue.Always, ConnectionType.Multiple, TypeConstraint.None, false)]
		public Research Item;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public UnlockConnection Requires;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public UnlockConnection LeadsTo;

		public GameDataObject RefersTo => Item;

		private void OnValidate()
		{
			base.name = ((Item == null) ? "Empty Research" : RefersTo.name);
		}

		public override object GetValue(NodePort port)
		{
			return Item;
		}
	}
}
