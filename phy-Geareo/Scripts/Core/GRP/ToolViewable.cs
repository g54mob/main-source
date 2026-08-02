using Rhizomatic.Reactive;

namespace GRP
{
	public abstract class ToolViewable : Viewable
	{
		public Tool tool;

		public void _Setup(Tool tool)
		{
		}

		protected virtual void Setup()
		{
		}

		public void Select()
		{
		}
	}
	public class ToolViewable<TTool> : ToolViewable where TTool : Tool
	{
		public new TTool tool => null;
	}
}
