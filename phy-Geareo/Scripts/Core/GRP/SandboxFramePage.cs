using Rhizomatic;

namespace GRP
{
	public class SandboxFramePage : ProjectFramePage
	{
		[ViewCrew(typeof(CatalogView))]
		public CatalogViewable catalog;

		protected override void Setup()
		{
		}

		public override void OnContextDispose()
		{
		}

		private void OnClick(WorldPointerEvent evt)
		{
		}

		public static void HandleBuildToolToggle(WorldPointerEvent evt, Project project, CatalogViewable catalog)
		{
		}
	}
}
