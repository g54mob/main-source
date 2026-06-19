using UnityEngine;

namespace TH20.UI
{
	public class StaffTabStatusPanel : OverviewMenuTabPanel
	{
		[SerializeField]
		private Color[] _colourRange;

		protected override void Refresh()
		{
			base.Refresh();
			PanelItemProgressBar[] progressBars = _progressBars;
			for (int i = 0; i < progressBars.Length; i++)
			{
				progressBars[i].ApplyColourRange(_colourRange);
			}
		}

		public override void UpdateProgressBars()
		{
			base.UpdateProgressBars();
			PanelItemProgressBar[] progressBars = _progressBars;
			for (int i = 0; i < progressBars.Length; i++)
			{
				progressBars[i].CheckUpdateProgressBarWidth();
			}
		}
	}
}
