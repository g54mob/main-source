using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class HospitalValueMenu : MenuBase
	{
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

		private LevelStatsDatabase _levelStatsDatabase;

		private int _previousValue;

		private int _previousCash;

		private int _previousTotalAssetValue;

		private int _previousAverageProfits;

		private int _previousTotalLoans;

		public void Setup(LevelStatsDatabase levelStatsDatabase)
		{
			_levelStatsDatabase = levelStatsDatabase;
			Refresh(force: true);
		}

		protected override void Update()
		{
			base.Update();
			Refresh(force: false);
		}

		private void Refresh(bool force)
		{
			LevelStatsDatabase.MonthStats latestCompletedMonthStats = _levelStatsDatabase.GetLatestCompletedMonthStats();
			List<LevelStatsDatabase.MonthStats> previousMonthlyStats = _levelStatsDatabase.GetPreviousMonthlyStats(12);
			int hospitalValue = latestCompletedMonthStats.HospitalValue;
			int balance = latestCompletedMonthStats.Balance;
			int totalPhysicalAssetValue = latestCompletedMonthStats.TotalPhysicalAssetValue;
			int num = previousMonthlyStats.Sum((LevelStatsDatabase.MonthStats x) => x.Profit) / previousMonthlyStats.Count;
			int totalLoans = latestCompletedMonthStats.TotalLoans;
			if (hospitalValue != _previousValue || force)
			{
				_hospitalValueText.text = StringUtils.FormatCurrency(hospitalValue);
				_previousValue = hospitalValue;
			}
			if (balance != _previousCash || force)
			{
				_cashText.text = StringUtils.FormatCurrency(balance);
				_previousCash = balance;
			}
			if (totalPhysicalAssetValue != _previousTotalAssetValue || force)
			{
				_physicalAssetsText.text = StringUtils.FormatCurrency(totalPhysicalAssetValue);
				_previousTotalAssetValue = totalPhysicalAssetValue;
			}
			if (num != _previousAverageProfits || force)
			{
				_averageProfitsText.text = StringUtils.FormatCurrency(num);
				_previousAverageProfits = num;
			}
			if (totalLoans != _previousTotalLoans || force)
			{
				_totalLoansText.text = StringUtils.FormatCurrency(totalLoans);
				_previousTotalLoans = totalLoans;
			}
		}
	}
}
