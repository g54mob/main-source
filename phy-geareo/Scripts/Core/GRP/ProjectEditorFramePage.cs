using Rhizomatic;

namespace GRP
{
	public class ProjectEditorFramePage : ProjectFramePage
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
	}
}
