using System;
using System.Collections.Generic;
using System.Linq;
using DV.InventorySystem;
using DV.Localization;
using DV.Logic.Job;
using DV.Utils;
using TMPro;
using UnityEngine;

namespace DV.ServicePenalty.UI
{
	public class CareerManagerStatsScreen : DisplayScreen
	{
		private enum StatsType
		{
			MONEY = 0,
			ACTIVE_JOBS = 1,
			COPAY_REMAINING = 2,
			COPAY_TOTAL = 3,
			FEES_TOTAL = 4,
			FEE_TOLERANCE = 5,
			TIME_BONUS = 6,
			LICENSES_OWNED = 7
		}

		[Serializable]
		private class StatsEntry
		{
			public TextMeshPro name;

			public TextMeshPro value;

			public StatsEntry(TextMeshPro name, TextMeshPro value)
			{
				this.name = name;
				this.value = value;
			}

			public void Set(string nameText, string valueText)
			{
				name.text = nameText;
				value.text = valueText;
			}
		}

		public DisplayScreenSwitcher screenSwitcher;

		public CareerManagerMainScreen mainScreen;

		public TextMeshPro title;

		[SerializeField]
		private List<StatsEntry> statsEntries;

		private void Awake()
		{
			if (screenSwitcher == null)
			{
				Debug.LogError("screenSwitcher reference isn't set! Screen can't function!");
			}
		}

		public override void Activate(IDisplayScreen _)
		{
			title.text = CareerManagerLocalization.STATS;
			int count = statsEntries.Count;
			List<StatsType> list = Enum.GetValues(typeof(StatsType)).Cast<StatsType>().ToList();
			int count2 = list.Count;
			if (count2 > count)
			{
				Debug.LogError("Implement scrolling, can't display all stats!");
			}
			LicenseManager instance = SingletonBehaviour<LicenseManager>.Instance;
			for (int i = 0; i < count; i++)
			{
				if (i >= count2)
				{
					statsEntries[i].Set(string.Empty, string.Empty);
					continue;
				}
				switch (list[i])
				{
				case StatsType.MONEY:
					statsEntries[i].Set(CareerManagerLocalization.MONEY_CURRENT, "$" + SingletonBehaviour<Inventory>.Instance.PlayerMoney.ToString("N2", LocalizationAPI.CC));
					break;
				case StatsType.ACTIVE_JOBS:
					statsEntries[i].Set(CareerManagerLocalization.ACTIVE_JOBS, $"{SingletonBehaviour<JobsManager>.Instance.currentJobs.Count}");
					break;
				case StatsType.COPAY_REMAINING:
				{
					InsuranceFeeQuota feeQuota = SingletonBehaviour<CareerManagerDebtController>.Instance.feeQuota;
					string valueText3 = (feeQuota.InsuranceUsed ? ("$" + Mathf.FloorToInt(feeQuota.LeftToReachQuota).ToString("N0", LocalizationAPI.CC)) : ("$" + 0.ToString("N0", LocalizationAPI.CC)));
					statsEntries[i].Set(CareerManagerLocalization.COPAY_REMAINING, valueText3);
					break;
				}
				case StatsType.COPAY_TOTAL:
				{
					InsuranceFeeQuota feeQuota2 = SingletonBehaviour<CareerManagerDebtController>.Instance.feeQuota;
					string valueText4 = (feeQuota2.InsuranceUsed ? ("$" + Mathf.FloorToInt(feeQuota2.Quota).ToString("N0", LocalizationAPI.CC)) : ("$" + 0.ToString("N0", LocalizationAPI.CC)));
					statsEntries[i].Set(CareerManagerLocalization.COPAY_TOTAL, valueText4);
					break;
				}
				case StatsType.FEES_TOTAL:
					statsEntries[i].Set(CareerManagerLocalization.FEES_TOTAL, "$" + SingletonBehaviour<CareerManagerDebtController>.Instance.TotalFees.ToString("N0", LocalizationAPI.CC));
					break;
				case StatsType.FEE_TOLERANCE:
					statsEntries[i].Set(CareerManagerLocalization.FEE_TOLERANCE, "$" + CareerManagerDebtController.FeeTolerance.ToString("N0", LocalizationAPI.CC));
					break;
				case StatsType.TIME_BONUS:
				{
					string valueText2 = ((instance.BonusTimeDecreasePercentage > 0f) ? "-" : "+") + Mathf.Abs(instance.BonusTimeDecreasePercentage * 100f).ToString("N2", LocalizationAPI.CC) + "%";
					statsEntries[i].Set(CareerManagerLocalization.TIME_BONUS_DEADLINE_TOTAL, valueText2);
					break;
				}
				case StatsType.LICENSES_OWNED:
				{
					int num = instance.GetNumberOfAcquiredGeneralLicenses() + instance.GetNumberOfAcquiredJobLicenses();
					int allLicensesCount = SingletonBehaviour<LicenseManager>.Instance.AllLicensesCount;
					string valueText = $"{num}/{allLicensesCount}";
					statsEntries[i].Set(CareerManagerLocalization.LICENSES_OWNED, valueText);
					break;
				}
				default:
					Debug.LogError($"Unexpected stats type {list[i]}!");
					break;
				}
			}
		}

		public override void Disable()
		{
			title.text = string.Empty;
			foreach (StatsEntry statsEntry in statsEntries)
			{
				statsEntry.Set(string.Empty, string.Empty);
			}
		}

		public override void HandleInputAction(InputAction input)
		{
			switch (input)
			{
			case InputAction.Cancel:
			case InputAction.Confirm:
				screenSwitcher.SetActiveDisplay(mainScreen);
				break;
			case InputAction.Up:
			case InputAction.Down:
			case InputAction.PrintInfo:
				break;
			}
		}
	}
}
