namespace Assets.Scripts.Career.Research.UI
{
	public class ItemBlockScript : BlockScript
	{
		public TechItemValue Item { get; private set; }

		public NodeScript Node { get; private set; }

		public virtual void Initialize(NodeScript node, TechItemValue item)
		{
			Node = node;
			Item = item;
		}
	}
}
