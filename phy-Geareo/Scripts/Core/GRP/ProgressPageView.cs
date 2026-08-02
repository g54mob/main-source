using Rhizomatic;
using Rhizomatic.UI;

namespace GRP
{
	public class ProgressPageView : PageView<ProgressPage>
	{
		public TextMember info;

		public BarMember progress;

		public TextMember progressText;

		protected override void OnViewOpen()
		{
		}

		protected override void LateUpdate()
		{
		}
	}
}
