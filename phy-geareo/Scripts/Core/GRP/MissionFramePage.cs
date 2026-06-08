using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class MissionFramePage : ProjectFramePage
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

		private void OnClick(WorldPointerEvent evt)
		{
		}

		[CrewMethod]
		public void Reload()
		{
		}
	}
}
