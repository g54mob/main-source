using System.Collections.Generic;
using System.Linq;

namespace TH20.UI
{
	public class FinanceTabProfitLossTrendsPanel : OverviewMenuTrendPanelBase
	{
		public override void Setup(OverviewMenuTab theTabRoot)
		{
			base.Setup(theTabRoot);
			LevelStatsDatabase.YearStats latestCompletedYearStats = _levelStatsDatabase.GetLatestCompletedYearStats();
			List<LevelStatsDatabase.MonthStats> previousMonthlyStats = _levelStatsDatabase.GetPreviousMonthlyStats(3);
			if (latestCompletedYearStats.Months.Count > 0)
			{
				_monthFirst = latestCompletedYearStats.Months.Last().Profit;
				_monthLast = latestCompletedYearStats.Months[0].Profit;
			}
			if (previousMonthlyStats.Count > 0)
			{
				_quarterFirst = previousMonthlyStats.Last().Profit;
				_quarterLast = previousMonthlyStats[0].Profit;
			}
		}
	}
}
