using GRP.Pages.NSProjectFrame;
using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP
{
	public abstract class ProjectFramePage : Page
	{
		[ViewCrew(typeof(ModuleItemView))]
		public ModuleItemViewable glueModule;

		[ViewCrew(typeof(ExpositorView))]
		public ExpositorViewable expositor;

		[ViewCrew(typeof(CollapsibleView))]
		public CollapsibleViewable expositorCollapsible;

		[ViewCrew(typeof(TimeScaleView))]
		public TimeScaleViewable timeScale;

		[SelectableCrew]
		public StateSelector<bool> undo;

		[SelectableCrew]
		public StateSelector<bool> redo;

		[ToggleCrew]
		public State<bool> advanced;

		[ViewCrew(typeof(ToolItemView))]
		public SimpleToolItemViewable buildTool;

		[ViewCrew(typeof(ToolItemView))]
		public HandleToolItemViewable handleTool;

		[ViewCrew(typeof(ToolItemView))]
		public SimpleToolItemViewable deleteTool;

		[ViewCrew(typeof(ToolItemView))]
		public MoveToolItemViewable moveTool;

		[ViewCrew(typeof(ToolItemView))]
		public RotateToolItemViewable rotateTool;

		[ViewCrew(typeof(ToolItemView))]
		public ColorPainterToolItemViewable colorPainterTool;

		public ProjectPage projectPage;

		public ProjectContainer projectContainer => null;

		public Project project => null;

		protected virtual void Setup()
		{
		}

		public void _Setup(ProjectPage projectPage)
		{
		}

		[CrewMethod]
		public void StartSim()
		{
		}

		[CrewMethod]
		public void Undo()
		{
		}

		[CrewMethod]
		public void Redo()
		{
		}

		[CrewMethod]
		public void Hub()
		{
		}

		[CrewMethod]
		public void Settings()
		{
		}

		[CrewMethod]
		public void Control()
		{
		}

		[CrewMethod]
		public void Palette()
		{
		}

		[CrewMethod]
		public void Gearpedia()
		{
		}

		[CrewMethod]
		public void Close()
		{
		}

		[CrewMethod]
		public void Mirror()
		{
		}

		[CrewMethod]
		public void Clear()
		{
		}

		[CrewMethod]
		public void Back()
		{
		}
	}
}
