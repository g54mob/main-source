using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.SaveLoad.Containers;
using Restory.Gameplay.Statistics;
using Restory.UI.Views.DayEndWindow;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.DayEndWindow
{
	public sealed class GUI_DayEndWindow : MonoBehaviour
	{
		[SerializeField]
		private GUI_DayEndWindowView view;

		private GameStatisticsService gameStatistics;

		private Action switchToNextDayInputActionPerformedCallback;

		public event Action OnSwitchToNextDayRequested;

		[Inject]
		private void Construct(GameStatisticsService gameStatistics)
		{
			this.gameStatistics = gameStatistics;
		}

		private void OnEnable()
		{
			view.OnFinalizeDayActionPerformed += ResolveStartNextDayActionPerformed;
		}

		private void OnDisable()
		{
			if (view.MonoShellExists())
			{
				view.OnFinalizeDayActionPerformed -= ResolveStartNextDayActionPerformed;
			}
		}

		public void Show(Action switchToNextDayInputActionPerformedCallback = null)
		{
			this.switchToNextDayInputActionPerformedCallback = switchToNextDayInputActionPerformedCallback;
			view.SetUpStatsInfo(GetDayStats());
			view.Show();
		}

		public void Hide()
		{
			switchToNextDayInputActionPerformedCallback = null;
			view.Hide();
		}

		private DayEndWindowStatsArguments GetDayStats()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			List<GameStatisticsSentDeviceRecord> list = new List<GameStatisticsSentDeviceRecord>();
			List<GameStatisticsSentDeviceRecord> list2 = new List<GameStatisticsSentDeviceRecord>();
			List<GameStatisticsSentDeviceRecord> list3 = new List<GameStatisticsSentDeviceRecord>();
			foreach (GameStatisticsSentDeviceRecord currentDaySentDevice in gameStatistics.CurrentDaySentDevices)
			{
				if (!(currentDaySentDevice is GameStatisticsWorkOrderRecord gameStatisticsWorkOrderRecord))
				{
					if (!(currentDaySentDevice is GameStatisticsEmailOrderRecord gameStatisticsEmailOrderRecord))
					{
						if (!(currentDaySentDevice is GameStatisticsFreeSaleRecord gameStatisticsFreeSaleRecord))
						{
							throw new NotImplementedException();
						}
						num3 += gameStatisticsFreeSaleRecord.MoneyReceived;
						list3.Add(gameStatisticsFreeSaleRecord);
					}
					else
					{
						num2 += gameStatisticsEmailOrderRecord.MoneyReceived;
						list2.Add(gameStatisticsEmailOrderRecord);
					}
				}
				else
				{
					num += gameStatisticsWorkOrderRecord.MoneyReceived;
					list.Add(gameStatisticsWorkOrderRecord);
				}
			}
			foreach (GameStatisticsSentDecorData currentDaySentDecor in gameStatistics.CurrentDaySentDecors)
			{
				num3 += currentDaySentDecor.MoneyReceived;
			}
			MoneyReceiptData moneyReceiptData = new MoneyReceiptData
			{
				MoneyEarnedFromCompletingWorkOrders = num,
				MoneyEarnedFromCompletingEmailOrders = num2,
				MoneyEarnedFromSellingDevices = num3,
				Purchases = gameStatistics.CurrentDayPurchases.ToArray(),
				RegularPaymentsMade = gameStatistics.CurrentDayRegularPaymentsMade.ToArray(),
				MoneyBalanceChangeToday = gameStatistics.MoneyAmountChangedToday,
				MoneyBalance = gameStatistics.MoneyAmountAtDayStart + gameStatistics.MoneyAmountChangedToday
			};
			return new DayEndWindowStatsArguments
			{
				CurrentDay = gameStatistics.CurrentDayNumber,
				WorkOrdersStatistics = gameStatistics.WorkOrdersStatistics,
				EmailOrdersStatistics = gameStatistics.EmailOrdersStatistics,
				MoneyReceiptData = moneyReceiptData,
				ClaimedWorkOrders = list,
				ClaimedEmailOrders = list2,
				SoldDevices = list3
			};
		}

		private void ResolveStartNextDayActionPerformed()
		{
			switchToNextDayInputActionPerformedCallback?.Invoke();
			this.OnSwitchToNextDayRequested?.Invoke();
		}
	}
}
