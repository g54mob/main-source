using Rhizomatic.Reactive;

namespace GRP
{
	public class HandleToolViewable : ToolViewable<HandleTool>
	{
		public StateSelector<bool> selected;

		public StateSelector<Part> selectedPart;

		protected override void Setup()
		{
		}
	}
}
