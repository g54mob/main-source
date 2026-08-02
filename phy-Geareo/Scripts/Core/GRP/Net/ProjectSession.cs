using Rhizomatic.Utility;

namespace GRP.Net
{
	public class ProjectSession : Domain<ProjectSessionConfig>
	{
		public ProjectContainer projectContainer;

		private Debouncer debouncer;

		public override void OnContext()
		{
		}

		protected override void OnLoaded()
		{
		}

		public void OpenMainMenu()
		{
		}

		public void StartSession()
		{
		}

		public void JoinSession()
		{
		}
	}
}
