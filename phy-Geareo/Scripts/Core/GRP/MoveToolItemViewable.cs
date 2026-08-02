using GRP.Pages.NSProjectFrame;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP
{
	public class MoveToolItemViewable : ToolItemViewable
	{
		[InputFieldCrew]
		public State<string> gridField;

		public ToolGridControl gridControl;

		public MoveToolItemViewable(ToolViewable tool)
		{
		}

		[CrewMethod]
		public void GridNext()
		{
		}

		[CrewMethod]
		public void GridPrevious()
		{
		}
	}
}
