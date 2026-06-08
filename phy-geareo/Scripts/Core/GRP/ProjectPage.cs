using System;
using System.Collections.Generic;
using GRP.Net;
using Rhizomatic;

namespace GRP
{
	public class ProjectPage : Page
	{
		public ProjectViewable projectView;

		public NetProjectViewable netProjectView;

		public List<ToolViewable> toolViews;

		public ProjectContainer projectContainer;

		public Project project;

		public Action<WorldPointerEvent> onClick;

		public ProjectPage(ProjectContainer projectContainer)
		{
		}

		public override void OnContext()
		{
		}

		public override void OnContextDispose()
		{
		}

		public void NewPart()
		{
		}
	}
}
