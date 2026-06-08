using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP.Pages.NSProjectFrame
{
	public abstract class ToolItemViewable : Viewable
	{
		[GameObjectCrew]
		public StateSelector<bool> selected;

		public ToolViewable tool;

		public ToolItemViewable()
		{
		}

		public ToolItemViewable(ToolViewable tool)
		{
		}

		[CrewMethod]
		public void Select()
		{
		}
	}
}
