using System;
using System.Collections.Generic;
using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP
{
	public class ProjectFilePickerPage : Page
	{
		[TextCrew]
		public StateSelector<string> relativePath;

		[ListLoaderCrew]
		public StateSelector<List<ProjectFilePickerItemViewable>> items;

		public Action<ProjectFileDefinition> callback;

		public State<string> path;

		public ProjectFilePickerPage(Action<ProjectFileDefinition> callback)
		{
		}

		public override void OnContext()
		{
		}

		private List<ProjectFilePickerItemViewable> GetAll()
		{
			return null;
		}

		public void SelectFolder(ProjectFolderDefinition folder)
		{
		}

		public void SelectFile(ProjectFileDefinition file)
		{
		}

		[CrewMethod]
		public void Back()
		{
		}
	}
}
