using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using TMPro;
using UnityEngine;

namespace TH20.UI
{
	public class FinanceTabHospitalValuePanel : OverviewMenuTabPanel
	{
		[SerializeField]
		private TMP_Text _dateText;

		[SerializeField]
		private TMP_Text _hospitalValueText;

		[SerializeField]
		private TMP_Text _cashText;

		[SerializeField]
		private TMP_Text _physicalAssetsText;

		[SerializeField]
		private TMP_Text _averageProfitsText;

		[SerializeField]
		private TMP_Text _totalLoansText;

		[SerializeField]
		private TooltipSpawner _profitFactorTooltip;

		[SerializeField]
		private PanelItemTrendIcon _cashTrendIcon;

		[SerializeField]
		private PanelItemTrendIcon _profitTrendIcon;

		[SerializeField]
		private PanelItemTrendIcon _totalTrendIcon;

		private int _previousValue = int.MinValue;

		private int _previousCash = int.MinValue;

		private int _previousAssetValue = int.MinValue;

		private int _previousProfits = int.MinValue;

		private int _previousLoans = int.MinValue;

		private int _value;

		private int _cash;

		private int _assetValue;

		private int _profits;

		private int _loans;

		private int _netProfit;

		private int _positiveMonthlyNetProfit;

		private int _cashTrendEnd;

		private int _cashTrendStart;

		private int _profitTrendEnd;

		private int _profitTrendStart;

		private int _totalTrendEnd;

		private int _totalTrendStart;

		public override void Setup(OverviewMenuTab theTabRoot)
		{
			base.Setup(theTabRoot);
			PanelItemValueViewer[] componentsInChildren = GetComponentsInChildren<PanelItemValueViewer>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].Setup();
			}
			LevelStatsDatabase.MonthStats latestCompletedMonthStats = _levelStatsDatabase.GetLatestCompletedMonthStats();
			_value = latestCompletedMonthStats.HospitalValue;
			_cash = latestCompletedMonthStats.Balance;
			_assetValue = latestCompletedMonthStats.TotalPhysicalAssetValue;
			_profits = latestCompletedMonthStats.ProfitFactor;
			_loans = latestCompletedMonthStats.TotalLoans;
			_netProfit = latestCompletedMonthStats.NetProfit;
			_positiveMonthlyNetProfit = latestCompletedMonthStats.PositiveMonthlyNetProfitCount;
			List<LevelStatsDatabase.MonthStats> previousMonthlyStats = _levelStatsDatabase.GetPreviousMonthlyStats(GameAlgorithms.Config.NumMonthsForGeneralTrendIndicators);
			if (previousMonthlyStats.Count > 0)
			{
				_cashTrendStart = previousMonthlyStats.Last().Balance;
				_cashTrendEnd = previousMonthlyStats[0].Balance;
				_profitTrendStart = previousMonthlyStats.Last().ProfitFactor;
				_profitTrendEnd = previousMonthlyStats[0].ProfitFactor;
				_totalTrendStart = previousMonthlyStats.Last().HospitalValue;
				_totalTrendEnd = previousMonthlyStats[0].HospitalValue;
			}
			if (_profitFactorTooltip != null)
			{
				_profitFactorTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					string financeTab_ProfitFactor_CS = ScriptLocalization.Tooltip.FinanceTab_ProfitFactor_CS;
					financeTab_ProfitFactor_CS = financeTab_ProfitFactor_CS.Replace("{[VALUE1]}", StringUtils.FormatCurrency(_netProfit));
					financeTab_ProfitFactor_CS = financeTab_ProfitFactor_CS.Replace("{[VALUE2]}", $"{_positiveMonthlyNetProfit}");
					tooltip.Text = financeTab_ProfitFactor_CS;
				});
			}
			int month = theTabRoot.TheOverviewMenu.TheLevel.TimelineManager.Month;
			int num = theTabRoot.TheOverviewMenu.TheLevel.TimelineManager.Year + 1;
			if (month == 0)
			{
				month = 11;
				num--;
			}
			else
			{
				month--;
			}
			string newValue = $"{num:00}";
			_dateText.text = ScriptLocalization.Menu_Overview_Menu_Finance.MonthAndYear_CS;
			_dateText.text = _dateText.text.Replace("{[MONTH_ABBR]}", GameDateUtils.MonthCountToShortName(month));
			_dateText.text = _dateText.text.Replace("{[YEAR]}", newValue);
		}

		protected override void Update()
		{
			base.Update();
			Refresh(force: false);
		}

		private void Refresh(bool force)
		{
			if (_value != _previousValue || force)
			{
				_previousValue = _value;
				if ((bool)_hospitalValueText)
				{
					_hospitalValueText.text = StringUtils.FormatCurrency(_value, prefixPlus: false, bReplaceLineBreakingChars: false);
				}
			}
			if (_cash != _previousCash || force)
			{
				_previousCash = _cash;
				if ((bool)_cashText)
				{
					_cashText.text = StringUtils.FormatCurrency(_cash, prefixPlus: false, bReplaceLineBreakingChars: false);
				}
			}
			if (_assetValue != _previousAssetValue || force)
			{
				_previousAssetValue = _assetValue;
				if ((bool)_physicalAssetsText)
				{
					_physicalAssetsText.text = StringUtils.FormatCurrency(_assetValue, prefixPlus: false, bReplaceLineBreakingChars: false);
				}
			}
			if (_profits != _previousProfits || force)
			{
				_previousProfits = _profits;
				if ((bool)_averageProfitsText)
				{
					_averageProfitsText.text = StringUtils.FormatCurrency(_profits, prefixPlus: false, bReplaceLineBreakingChars: false);
				}
			}
			if (_loans != _previousLoans || force)
			{
				_previousLoans = _loans;
				if ((bool)_totalLoansText)
				{
					_totalLoansText.text = StringUtils.FormatCurrency(_loans, prefixPlus: false, bReplaceLineBreakingChars: false);
				}
			}
			if ((bool)_cashTrendIcon)
			{
				_cashTrendIcon.SetTrend(_cashTrendStart, _cashTrendEnd);
			}
			if ((bool)_profitTrendIcon)
			{
				_profitTrendIcon.SetTrend(_profitTrendStart, _profitTrendEnd);
			}
			if ((bool)_totalTrendIcon)
			{
				_totalTrendIcon.SetTrend(_totalTrendStart, _totalTrendEnd);
			}
		}
	}
}
