using System.Collections.Generic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class ProjectViewable : Viewable
	{
		public OrbitCameraViewable camera;

		public StateSelector<List<PartViewable>> partViews;

		public Project project;

		public ProjectViewable(Project project)
		{
		}

		public void Dispose()
		{
		}
	}
}
