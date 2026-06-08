using Rhizomatic.Reactive;

namespace GRP
{
	public class BuildTool : Tool
	{
		public State<Module> module;

		public CreatedPartContainer partContainer;

		public override bool canInteractPart => false;

		protected override ToolViewable DoCreateViewable()
		{
			return null;
		}

		public override void OnContext()
		{
		}
	}
}
