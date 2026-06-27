using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Expenses;
using Restory.Data.RegularPayments;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.Devices;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.TimeSystems;
using Restory.Gameplay.WorkOrders;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Restory.TimeSystems;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Statistics
{
	public class GameStatisticsService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		[SerializeField]
		private ExpenseInfo elementsExpenseInfo;

		[SerializeField]
		private ExpenseInfo licensesExpenseInfo;

		[SerializeField]
		private ExpenseInfo devicesExpenseInfo;

		[SerializeField]
		private ExpenseInfo cleaningToolsExpenseInfo;

		[SerializeField]
		private ExpenseInfo decorItemsExpenseInfo;

		private GameCalendar gameCalendar;

		private Wallet wallet;

		private bool clearDataInTheMorning;

		private int currentDayNumber;

		private OrdersStatisticsData workOrdersStatistics = new OrdersStatisticsData();

		private OrdersStatisticsData emailOrdersStatistics = new OrdersStatisticsData();

		private readonly List<GameStatisticsSentDecorData> sentDecorsStatistics = new List<GameStatisticsSentDecorData>();

		private readonly List<GameStatisticsSentDeviceRecord> currentDaySentDevices = new List<GameStatisticsSentDeviceRecord>();

		private readonly AllExpensesRecord currentDayExpenses = new AllExpensesRecord();

		private int moneyInWalletAtDayStart;

		private int moneyAmountChangedToday;

		public IReadOnlyList<GameStatisticsSentDeviceRecord> CurrentDaySentDevices => currentDaySentDevices;

		public IReadOnlyList<Expense> CurrentDayPurchases
		{
			get
			{
				if (currentDayExpenses != null)
				{
					return currentDayExpenses.Purchases;
				}
				return Array.Empty<Expense>();
			}
		}

		public IReadOnlyList<RegularPaymentInfo> CurrentDayRegularPaymentsMade
		{
			get
			{
				if (currentDayExpenses != null)
				{
					return currentDayExpenses.RegularPayments;
				}
				return Array.Empty<RegularPaymentInfo>();
			}
		}

		public OrdersStatisticsData WorkOrdersStatistics => workOrdersStatistics;

		public OrdersStatisticsData EmailOrdersStatistics => emailOrdersStatistics;

		public IEnumerable<GameStatisticsSentDecorData> CurrentDaySentDecors => sentDecorsStatistics.Where((GameStatisticsSentDecorData sentDecorData) => sentDecorData.DayIndex == CurrentDayNumber);

		public int CurrentDayNumber => currentDayNumber;

		public int MoneyAmountChangedToday => moneyAmountChangedToday;

		public int MoneyAmountAtDayStart => moneyInWalletAtDayStart;

		[Inject]
		private void Construct(GameCalendar gameCalendar, Wallet wallet)
		{
			this.gameCalendar = gameCalendar;
			this.wallet = wallet;
		}

		public void ProcessAssignedWorkOrder(int assignedWorkOrderID)
		{
			if (workOrdersStatistics.AssignedOrdersIDs.Contains(assignedWorkOrderID))
			{
				Debug.LogError(string.Format("{0} contains ID {1} already", "AssignedOrdersIDs", assignedWorkOrderID));
			}
			else
			{
				workOrdersStatistics.AssignedOrdersIDs.Add(assignedWorkOrderID);
			}
		}

		public void ProcessAssignedEmailOrder(int assignedEmailOrderID)
		{
			if (emailOrdersStatistics.AssignedOrdersIDs.Contains(assignedEmailOrderID))
			{
				Debug.LogError(string.Format("{0} contains ID {1} already", "AssignedOrdersIDs", assignedEmailOrderID));
			}
			else
			{
				emailOrdersStatistics.AssignedOrdersIDs.Add(assignedEmailOrderID);
			}
		}

		public void ProcessCancelledWorkOrder(int cancelledWorkOrderID)
		{
			if (!workOrdersStatistics.AssignedOrdersIDs.Remove(cancelledWorkOrderID))
			{
				Debug.LogError($"Cancelled work order for ID {cancelledWorkOrderID} was not assigned");
			}
		}

		public void ProcessClaimedWorkOrder(int claimedWorkOrderID, WorkOrderBase workOrder)
		{
			if (!workOrdersStatistics.AssignedOrdersIDs.Remove(claimedWorkOrderID))
			{
				Debug.LogError($"Claimed work order for ID {claimedWorkOrderID} was not assigned");
			}
			currentDaySentDevices.Add(new GameStatisticsWorkOrderRecord
			{
				MoneyReceived = workOrder.SavedGivenRewardMoneyAmount,
				DeviceInfo = workOrder.SavedGivenDeviceData.DeviceInfo,
				DeviceQuality = workOrder.SavedGivenDeviceData.Quality,
				DayIndex = gameCalendar.CurrentDayNumber
			});
			workOrdersStatistics.AllTimeCompletedOrdersCount++;
		}

		public void ProcessClaimedEmailOrder(TrackedEmailOrder emailOrder)
		{
			if (!emailOrdersStatistics.AssignedOrdersIDs.Remove(emailOrder.ID))
			{
				Debug.LogError($"Claimed email order for ID {emailOrder.ID} was not assigned");
			}
			currentDaySentDevices.Add(new GameStatisticsEmailOrderRecord
			{
				MoneyReceived = emailOrder.Order.Payment,
				DeviceInfo = emailOrder.DeviceContainer.Device.Info,
				DeviceQuality = emailOrder.DeviceContainer.Quality,
				DayIndex = gameCalendar.CurrentDayNumber
			});
			emailOrdersStatistics.AllTimeCompletedOrdersCount++;
		}

		public void ProcessCompletedFreeSale(int moneyReceived, DeviceContainer deviceContainer)
		{
			currentDaySentDevices.Add(new GameStatisticsFreeSaleRecord
			{
				MoneyReceived = moneyReceived,
				DeviceInfo = deviceContainer.Device.Info,
				DayIndex = gameCalendar.TimeSinceStartingTime.Days,
				DeviceQuality = deviceContainer.Quality
			});
		}

		public void ProcessCompletedDecorSale(int moneyReceived, DecorObject decorObject)
		{
			sentDecorsStatistics.Add(new GameStatisticsSentDecorData
			{
				Info = decorObject.Info,
				MoneyReceived = moneyReceived,
				DayIndex = gameCalendar.CurrentDayNumber
			});
		}

		public void ProcessElementsPurchasedInShop(int moneySpent)
		{
			AddExpense(elementsExpenseInfo, moneySpent);
		}

		public void ProcessLicensesPurchasedInShop(int moneySpent)
		{
			AddExpense(licensesExpenseInfo, moneySpent);
		}

		public void ProcessDevicesPurchasedInShop(int moneySpent)
		{
			AddExpense(devicesExpenseInfo, moneySpent);
		}

		public void ProcessCleaningToolsPurchasedInShop(int moneySpent)
		{
			AddExpense(cleaningToolsExpenseInfo, moneySpent);
		}

		public void ProcessDecorItemsPurchasedInShop(int moneySpent)
		{
			AddExpense(decorItemsExpenseInfo, moneySpent);
		}

		public void ProcessRegularPaymentMade(RegularPaymentInfo paymentInfo)
		{
			TryToAddRegularPayment(paymentInfo);
		}

		public void ProcessDayEnded()
		{
			moneyAmountChangedToday = wallet.MoneyAvailable - moneyInWalletAtDayStart;
		}

		public void ProcessMorningStarted(MainDayTimes lastDayTime)
		{
			currentDayNumber = gameCalendar.CurrentDayNumber;
			if (lastDayTime != MainDayTimes.None || clearDataInTheMorning)
			{
				ClearDataAtStartOfNewDay();
				clearDataInTheMorning = false;
			}
		}

		public void ProcessStoreClosed()
		{
			clearDataInTheMorning = true;
		}

		public void ClearDataAtStartOfNewDay()
		{
			workOrdersStatistics.PreviousDayAssignedOrdersCount = workOrdersStatistics.AssignedOrdersIDs.Count;
			emailOrdersStatistics.PreviousDayAssignedOrdersCount = emailOrdersStatistics.AssignedOrdersIDs.Count;
			currentDaySentDevices.Clear();
			sentDecorsStatistics.Clear();
			currentDayExpenses.Purchases.Clear();
			currentDayExpenses.RegularPayments.Clear();
			moneyAmountChangedToday = 0;
			moneyInWalletAtDayStart = wallet.MoneyAvailable;
		}

		private void AddExpense(ExpenseInfo expenseInfo, int moneySpent)
		{
			if (moneySpent <= 0)
			{
				return;
			}
			foreach (Expense purchase in currentDayExpenses.Purchases)
			{
				if (purchase.Info.ID == expenseInfo.ID)
				{
					purchase.Sum += moneySpent;
					return;
				}
			}
			currentDayExpenses.Purchases.Add(new Expense
			{
				Info = expenseInfo,
				Sum = moneySpent
			});
		}

		private bool TryToAddRegularPayment(RegularPaymentInfo paymentInfo)
		{
			currentDayExpenses.RegularPayments.Add(paymentInfo);
			return true;
		}

		public object CaptureState()
		{
			try
			{
				GameStatisticsSentDeviceSaveData[] array = new GameStatisticsSentDeviceSaveData[currentDaySentDevices.Count];
				for (int i = 0; i < currentDaySentDevices.Count; i++)
				{
					GameStatisticsSentDeviceRecord gameStatisticsSentDeviceRecord = currentDaySentDevices[i];
					if (!(gameStatisticsSentDeviceRecord is GameStatisticsWorkOrderRecord gameStatisticsWorkOrderRecord))
					{
						if (!(gameStatisticsSentDeviceRecord is GameStatisticsEmailOrderRecord gameStatisticsEmailOrderRecord))
						{
							if (!(gameStatisticsSentDeviceRecord is GameStatisticsFreeSaleRecord gameStatisticsFreeSaleRecord))
							{
								throw new NotImplementedException();
							}
							array[i] = new GameStatisticsCompletedFreeSaleSaveData
							{
								Device = gameStatisticsFreeSaleRecord.DeviceInfo,
								MoneyReceived = gameStatisticsFreeSaleRecord.MoneyReceived,
								DayIndex = gameStatisticsFreeSaleRecord.DayIndex,
								DeviceQuality = gameStatisticsFreeSaleRecord.DeviceQuality
							};
						}
						else
						{
							array[i] = new GameStatisticsCompletedEmailOrderSaveData
							{
								Device = gameStatisticsEmailOrderRecord.DeviceInfo,
								MoneyReceived = gameStatisticsEmailOrderRecord.MoneyReceived,
								DayIndex = gameStatisticsEmailOrderRecord.DayIndex,
								DeviceQuality = gameStatisticsEmailOrderRecord.DeviceQuality
							};
						}
					}
					else
					{
						array[i] = new GameStatisticsCompletedWorkOrderSaveData
						{
							Device = gameStatisticsWorkOrderRecord.DeviceInfo,
							MoneyReceived = gameStatisticsWorkOrderRecord.MoneyReceived,
							DayIndex = gameStatisticsWorkOrderRecord.DayIndex,
							DeviceQuality = gameStatisticsWorkOrderRecord.DeviceQuality
						};
					}
				}
				return new GameStatisticsSaveData
				{
					ClearDataInTheMorning = clearDataInTheMorning,
					CurrentDay = CurrentDayNumber,
					WorkOrdersStatistics = workOrdersStatistics,
					EmailOrdersStatistics = emailOrdersStatistics,
					Expenses = currentDayExpenses.Purchases.ToArray(),
					RegularPaymentsMade = currentDayExpenses.RegularPayments.ToArray(),
					MoneyAtDayStart = moneyInWalletAtDayStart,
					MoneyChanged = moneyAmountChangedToday,
					SentDevices = array,
					SentDecors = sentDecorsStatistics
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				currentDayExpenses.Purchases.Clear();
				currentDayExpenses.RegularPayments.Clear();
				GameStatisticsSaveData gameStatisticsSaveData = DataMigrationWizard.Migrate<GameStatisticsSaveData>(state, base.gameObject);
				clearDataInTheMorning = gameStatisticsSaveData.ClearDataInTheMorning;
				currentDayNumber = gameStatisticsSaveData.CurrentDay;
				workOrdersStatistics = gameStatisticsSaveData.WorkOrdersStatistics;
				emailOrdersStatistics = gameStatisticsSaveData.EmailOrdersStatistics;
				currentDayExpenses.Purchases.AddRange(gameStatisticsSaveData.Expenses);
				currentDayExpenses.RegularPayments.AddRange(gameStatisticsSaveData.RegularPaymentsMade);
				moneyInWalletAtDayStart = gameStatisticsSaveData.MoneyAtDayStart;
				moneyAmountChangedToday = gameStatisticsSaveData.MoneyChanged;
				currentDaySentDevices.Clear();
				GameStatisticsSentDeviceSaveData[] sentDevices = gameStatisticsSaveData.SentDevices;
				foreach (GameStatisticsSentDeviceSaveData gameStatisticsSentDeviceSaveData in sentDevices)
				{
					if (!(gameStatisticsSentDeviceSaveData is GameStatisticsCompletedWorkOrderSaveData gameStatisticsCompletedWorkOrderSaveData))
					{
						if (!(gameStatisticsSentDeviceSaveData is GameStatisticsCompletedEmailOrderSaveData gameStatisticsCompletedEmailOrderSaveData))
						{
							if (gameStatisticsSentDeviceSaveData is GameStatisticsCompletedFreeSaleSaveData gameStatisticsCompletedFreeSaleSaveData)
							{
								currentDaySentDevices.Add(new GameStatisticsFreeSaleRecord
								{
									DeviceInfo = gameStatisticsCompletedFreeSaleSaveData.Device,
									DayIndex = gameStatisticsCompletedFreeSaleSaveData.DayIndex,
									MoneyReceived = gameStatisticsCompletedFreeSaleSaveData.MoneyReceived,
									DeviceQuality = gameStatisticsCompletedFreeSaleSaveData.DeviceQuality
								});
							}
						}
						else
						{
							currentDaySentDevices.Add(new GameStatisticsEmailOrderRecord
							{
								DeviceInfo = gameStatisticsCompletedEmailOrderSaveData.Device,
								DayIndex = gameStatisticsCompletedEmailOrderSaveData.DayIndex,
								MoneyReceived = gameStatisticsCompletedEmailOrderSaveData.MoneyReceived,
								DeviceQuality = gameStatisticsCompletedEmailOrderSaveData.DeviceQuality
							});
						}
					}
					else
					{
						currentDaySentDevices.Add(new GameStatisticsWorkOrderRecord
						{
							DeviceInfo = gameStatisticsCompletedWorkOrderSaveData.Device,
							DayIndex = gameStatisticsCompletedWorkOrderSaveData.DayIndex,
							MoneyReceived = gameStatisticsCompletedWorkOrderSaveData.MoneyReceived,
							DeviceQuality = gameStatisticsCompletedWorkOrderSaveData.DeviceQuality
						});
					}
				}
				sentDecorsStatistics.Clear();
				if (gameStatisticsSaveData.SentDecors != null)
				{
					sentDecorsStatistics.AddRange(gameStatisticsSaveData.SentDecors);
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
