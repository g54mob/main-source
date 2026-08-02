using GRP.Net;
using Rhizomatic;
using Rhizomatic.MemberBinding;

namespace GRP
{
	public class ProjectSimPageView : PageView<ProjectSimPage>
	{
		public WorldPointablePort port;

		public ProjectSim sim;

		public NetProjectView netProject;

		public DraggablePhysicsController draggablePhysicsController;

		private bool followShown;

		private Hertz hertz;

		private NetGame netGame;

		protected override void OnViewCreated()
		{
		}

		protected override void OnViewOpen()
		{
		}

		protected override void OnRender()
		{
		}

		protected override void OnPageOpen()
		{
		}

		protected override void OnPageClose()
		{
		}

		protected override void Update()
		{
		}

		public void Explode()
		{
		}

		[Member]
		public void Freeze()
		{
		}
	}
}
