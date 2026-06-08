using System.Collections.Generic;

namespace GRP
{
	public class MainMenuScene : DomainScene<MainMenu>
	{
		public ProjectSim projectSim;

		public Project project;

		private ProjectDataContainer lastProject;

		private List<ProjectDataContainer> projects;

		private int counter;

		protected override void Setup()
		{
		}

		private void Update()
		{
		}

		protected override void OnDispose()
		{
		}

		private void Dispose()
		{
		}

		public void NewProject()
		{
		}

		public void ReloadProject()
		{
		}
	}
}
