using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class MissionEditorFramePage : ProjectFramePage
	{
		[ViewCrew(typeof(CatalogView))]
		public CatalogViewable catalog;

		public Mission mission;

		protected override void Setup()
		{
		}

		public override void OnContextDispose()
		{
		}

		[CrewMethod]
		public void Save()
		{
		}

		private void OnClick(WorldPointerEvent evt)
		{
		}
	}
}
