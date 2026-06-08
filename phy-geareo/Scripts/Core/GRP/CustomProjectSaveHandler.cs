using System;

namespace GRP
{
	public class CustomProjectSaveHandler : ProjectSaveHandler
	{
		public Action<Project> loadAction;

		public Action<Project> saveAction;

		public CustomProjectSaveHandler(Action<Project> loadAction, Action<Project> saveAction)
		{
		}

		public override void Load(Project project)
		{
		}

		public override void Save(Project project)
		{
		}
	}
}
