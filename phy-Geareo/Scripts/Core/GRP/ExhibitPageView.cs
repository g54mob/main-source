using System.Collections.Generic;
using Rhizomatic;

namespace GRP
{
	public class ExhibitPageView : PageView<ExhibitPage>
	{
		public ProjectConfigEntry projectConfig;

		public ExhibitLoader exhibitPrefab;

		public List<ExhibitLoader> spawned;

		protected override void OnViewCreated()
		{
		}

		protected override void OnViewOpen()
		{
		}

		protected override void OnViewClose()
		{
		}
	}
}
