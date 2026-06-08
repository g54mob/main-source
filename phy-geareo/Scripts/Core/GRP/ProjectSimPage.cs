using GRP.Net;
using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class ProjectSimPage : Page
	{
		[ViewCrew(typeof(TimeScaleView))]
		public TimeScaleViewable timeScale;

		public Project project;

		public NetProjectViewable netProjectView;

		public State<bool> draggableDisabled;

		public ProjectSimPage(Project project)
		{
		}

		public override void OnContext()
		{
		}

		public override void OnContextDispose()
		{
		}

		[CrewMethod]
		public void Close()
		{
		}
	}
}
