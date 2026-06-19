using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class OverviewMenuStaffTab : OverviewMenuTab
	{
		[SerializeField]
		private StaffTabOverviewPanel _theOverviewPanel;

		[SerializeField]
		private StaffTabStatusPanel _theStatusPanel;

		[SerializeField]
		private TMP_Text _profitLossText;

		public override void Setup(OverviewMenu theOverviewRoot, OverviewMenu.Mode theMode)
		{
			base.Setup(theOverviewRoot, theMode);
			_theOverviewPanel.SetupAdvisor(theOverviewRoot.TheAdvisorScene);
			_theOverviewPanel.SetupBreakSliders(theOverviewRoot.TheLevel.WorkLifeBalanceManager);
			_levelStatsDatabase.GetPreviousMonthsProfitAndLoss(12, out var _, out var _, out var profit);
			_profitLossText.text = StringUtils.FormatCurrency(profit, prefixPlus: true);
		}

		public void Update()
		{
			if (_theOverviewPanel != null)
			{
				_theOverviewPanel.UpdateProgressBars();
			}
			if (_theStatusPanel != null)
			{
				_theStatusPanel.UpdateProgressBars();
			}
		}

		public override void Activate(bool state)
		{
			base.Activate(state);
			if (state)
			{
				base.TheOverviewMenu.SetStandardAdvisor();
				_theOverviewPanel.AdvisorVisible = true;
			}
			else
			{
				_theOverviewPanel.ResetAdvisor();
			}
		}
	}
}
