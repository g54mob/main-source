using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class ExhibitPage : Page
	{
		[ViewCrew(typeof(ExhibitView))]
		public ExhibitViewable exhibit;

		[ViewCrew(typeof(OrbitCameraView))]
		public OrbitCameraViewable camera;

		public ExhibitPage(OrbitCameraViewable camera)
		{
		}

		public ExhibitPage(OrbitCameraViewable camera, Exhibit exhibit)
		{
		}

		[CrewMethod]
		public void Back()
		{
		}
	}
}
