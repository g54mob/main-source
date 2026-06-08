using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP.Pages.NSKit
{
	public class KitViewable : Viewable
	{
		[ViewCrew(typeof(KitManualView))]
		public KitManualViewable manual;

		[ViewCrew(typeof(KitCatalogView))]
		public KitCatalogViewable catalog;

		public Project project;

		public Kit kit;

		public KitViewable(Project project, Kit kit)
		{
		}
	}
}
