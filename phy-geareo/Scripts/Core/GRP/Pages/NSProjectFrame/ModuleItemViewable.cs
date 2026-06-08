using System;
using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP.Pages.NSProjectFrame
{
	public class ModuleItemViewable : Viewable, IListItemView<Module>
	{
		[TextCrew]
		public string name;

		[GameObjectCrew]
		public StateSelector<bool> selected;

		public Module module;

		public BuildTool tool;

		public Project project;

		public Action<Part> onAdded;

		public Module model => null;

		public ModuleItemViewable(Project project, Module module)
		{
		}

		public void Select()
		{
		}

		public void Deselect()
		{
		}
	}
}
