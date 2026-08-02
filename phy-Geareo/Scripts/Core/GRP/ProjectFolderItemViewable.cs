using System;
using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP
{
	public class ProjectFolderItemViewable : Viewable
	{
		[TextCrew]
		public string name;

		public Action<ProjectFolderDefinition> onFolderSelected;

		public ProjectFolderDefinition folder;

		private Context context;

		private ProjectContainer container;

		public ProjectFolderItemViewable(Context context, ProjectContainer container, ProjectFolderDefinition folder, Action<ProjectFolderDefinition> onFolderSelected = null)
		{
		}

		[CrewMethod]
		public void Select()
		{
		}

		[CrewMethod]
		public void Rename()
		{
		}

		[CrewMethod]
		public void Delete()
		{
		}

		[CrewMethod]
		public void SaveBuiltin()
		{
		}
	}
}
