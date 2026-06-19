using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class FinanceTabCashFlowPanel : OverviewMenuTabPanel
	{
		private enum DisplayMode
		{
			DmNone = 0,
			DmYearly = 1,
			DmQuarterly = 2
		}

		[InspectorMargin(8)]
		[InspectorHeader("Localisation")]
		[SerializeField]
		private LocalisedString _quarterlyProfitsString;

		[SerializeField]
		private LocalisedString _yearlyProfitsString;

		[InspectorMargin(8)]
		[InspectorHeader("Text Components")]
		[SerializeField]
		private TMP_Text _expensesText;

		[SerializeField]
		private TMP_Text _profitText;

		[SerializeField]
		private TMP_Text _revenueText;

		[InspectorMargin(8)]
		[InspectorHeader("PanelItem Components")]
		[SerializeField]
		private PanelItemCashFlowBar _expensesBar;

		[SerializeField]
		private PanelItemCashFlowBar _revenueBar;

		[SerializeField]
		private PanelItemRadioButtonsGroup _modeSelectionButtons;

		[SerializeField]
		private PanelItemValueViewer _profitsViewer;

		[SerializeField]
		private PanelItemTrendIcon _expensesTrend;

		[SerializeField]
		private PanelItemTrendIcon _revenueTrend;

		[SerializeField]
		private TooltipSpawner _expensesTooltip;

		[SerializeField]
		private TooltipSpawner _revenueTooltip;

		private int _previousExpenses = -1;

		private int _previousProfit = -1;

		private int _previousRevenue = -1;

		private float _previousExpensesTrend;

		private float _previousRevenueTrend;

		private DisplayMode _currentDisplayMode;

		public override void Setup(OverviewMenuTab theTabRoot)
		{
			base.Setup(theTabRoot);
			if ((bool)_modeSelectionButtons)
			{
				PanelItemRadioButtonsGroup modeSelectionButtons = _modeSelectionButtons;
				modeSelectionButtons.OnButtonSelected = (Action<int>)Delegate.Combine(modeSelectionButtons.OnButtonSelected, new Action<int>(OnModeChange));
			}
			if ((bool)_expensesBar && (bool)_revenueBar)
			{
				float barHeight = _expensesBar.BarHeight;
				float barHeight2 = _revenueBar.BarHeight;
				_expensesBar.SetMetrics(barHeight2, barHeight);
				_revenueBar.SetMetrics(barHeight2, barHeight);
			}
			if ((bool)_modeSelectionButtons)
			{
				_modeSelectionButtons.SelectButton((!theTabRoot.TheOverviewMenu.IsEndOfYear) ? 1 : 0);
			}
			if (_expensesTooltip != null)
			{
				_expensesTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = ExpensesTooltip();
				});
			}
			if (_revenueTooltip != null)
			{
				_revenueTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = RevenueTooltip();
				});
			}
		}

		protected void OnDestroy()
		{
			if ((bool)_modeSelectionButtons)
			{
				PanelItemRadioButtonsGroup modeSelectionButtons = _modeSelectionButtons;
				modeSelectionButtons.OnButtonSelected = (Action<int>)Delegate.Remove(modeSelectionButtons.OnButtonSelected, new Action<int>(OnModeChange));
			}
		}

		private void OnModeChange(int buttonID)
		{
			DisplayMode displayMode = (DisplayMode)(buttonID + 1);
			if (Enum.IsDefined(typeof(DisplayMode), displayMode) && displayMode != _currentDisplayMode)
			{
				SetMode(displayMode);
			}
		}

		private void SetMode(DisplayMode theMode)
		{
			_currentDisplayMode = theMode;
			int num = 0;
			switch (_currentDisplayMode)
			{
			case DisplayMode.DmQuarterly:
				num = 3;
				if ((bool)_profitsViewer)
				{
					_profitsViewer.SetTitleText(_quarterlyProfitsString.Translation);
				}
				break;
			case DisplayMode.DmYearly:
				num = 12;
				if ((bool)_profitsViewer)
				{
					_profitsViewer.SetTitleText(_yearlyProfitsString.Translation);
				}
				break;
			default:
				return;
			}
			if (_expensesTrend != null)
			{
				_expensesTrend.SetNumTrendMonths(num);
			}
			if (_revenueTrend != null)
			{
				_revenueTrend.SetNumTrendMonths(num);
			}
			Refresh(force: true);
		}

		private void Refresh(bool force)
		{
			float num = 0f;
			float num2 = 0f;
			int numMonths = ((_currentDisplayMode == DisplayMode.DmQuarterly) ? 3 : 12);
			_levelStatsDatabase.GetPreviousMonthsProfitAndLoss(numMonths, out var expenses, out var revenue, out var profit);
			if (_previousProfit != profit || force)
			{
				_profitText.text = StringUtils.FormatCurrency(profit, prefixPlus: true, bReplaceLineBreakingChars: false);
				_previousProfit = profit;
				if ((bool)_profitsViewer)
				{
					if (profit < 0)
					{
						_profitsViewer.SetAlternativeBackground();
					}
					else
					{
						_profitsViewer.ClearAlternativeBackground();
					}
				}
			}
			if (_previousExpenses != expenses || force)
			{
				_expensesText.text = StringUtils.FormatCurrency(expenses, prefixPlus: true);
				_previousExpenses = expenses;
			}
			if (_previousRevenue != revenue || force)
			{
				_revenueText.text = StringUtils.FormatCurrency(revenue, prefixPlus: true);
				_previousRevenue = revenue;
			}
			if (_previousExpensesTrend.CompareTo(num) != 0 || force)
			{
				_previousExpensesTrend = num;
				if ((bool)_expensesTrend)
				{
					_expensesTrend.SetTrendIconDirection(_previousExpensesTrend);
				}
			}
			if (_previousRevenueTrend.CompareTo(num2) != 0 || force)
			{
				_previousRevenueTrend = num2;
				if ((bool)_revenueTrend)
				{
					_revenueTrend.SetTrendIconDirection(_previousRevenueTrend);
				}
			}
			if ((bool)_expensesBar && (bool)_revenueBar)
			{
				float num3 = Mathf.Max(expenses, revenue);
				float num4 = Mathf.Min(expenses, revenue);
				float num5 = num3 - num4;
				if (num5 > 0f)
				{
					_expensesBar.BarHeight = ((float)expenses - num4) / num5;
					_revenueBar.BarHeight = ((float)revenue - num4) / num5;
				}
				else
				{
					_expensesBar.BarHeight = 0.5f;
					_revenueBar.BarHeight = 0.5f;
				}
			}
		}

		private string RevenueTooltip()
		{
			int numMonths = ((_currentDisplayMode == DisplayMode.DmQuarterly) ? 3 : 12);
			LevelStatsDatabase.RevenueBreakdown revenueBreakdown = _levelStatsDatabase.GetRevenueBreakdown(numMonths);
			return LocalisedString.Replace(ScriptLocalization.Tooltip.FinanceTab_CashFlow_Revenue_CS, new SubPair[3]
			{
				new SubPair("{[TREATMENT]}", StringUtils.FormatCurrency(revenueBreakdown.Treatment)),
				new SubPair("{[DIAGNOSIS]}", StringUtils.FormatCurrency(revenueBreakdown.Diagnosis)),
				new SubPair("{[OTHER]}", StringUtils.FormatCurrency(revenueBreakdown.Other))
			});
		}

		private string ExpensesTooltip()
		{
			int numMonths = ((_currentDisplayMode == DisplayMode.DmQuarterly) ? 3 : 12);
			LevelStatsDatabase.ExpensesBreakdown expensesBreakdown = _levelStatsDatabase.GetExpensesBreakdown(numMonths);
			return LocalisedString.Replace(ScriptLocalization.Tooltip.FinanceTab_CashFlow_Expenses_CS, new SubPair[2]
			{
				new SubPair("{[WAGES]}", StringUtils.FormatCurrency(expensesBreakdown.Wages)),
				new SubPair("{[OTHER]}", StringUtils.FormatCurrency(expensesBreakdown.Other))
			});
		}
	}
}
