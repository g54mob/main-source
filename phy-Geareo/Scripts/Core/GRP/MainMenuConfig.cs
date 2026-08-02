using Rhizomatic;

namespace GRP
{
	public class MainMenuConfig : DomainConfig
	{
		public ProjectConfigEntry projectConfig;

		public ProjectDataContainer[] startProjects;

		public ProjectDataContainer[] projects;

		public override Thing CreateThing()
		{
			return null;
		}
	}
}
