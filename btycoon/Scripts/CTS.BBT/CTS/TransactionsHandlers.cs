using System;
using System.Collections.Generic;
using System.Linq;
using CTS.BBT;
using CTS.BBT.Handlers.Transactions;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class TransactionsHandlers : MonoSingleton<TransactionsHandlers>
	{
		[Space(10f)]
		[Header("Main Data")]
		public int[,] CurrentTransactionsData = new int[2, 7];

		public int[,] OldTransactionsData = new int[2, 7];

		public List<(TransactionType, int, TransactionTag)> TransactionsHistoryData;

		private (TransactionType, int, TransactionTag) _tmpNewArrayTransactionHistoryData;

		public static event Action<int> DataUpdated;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void OnEnable()
		{
			SceneReset.Reset += ResetData;
			CalendarHandlers.NewMonthAfterYearChanged += NewMonth;
			TransactionsHistoryData = new List<(TransactionType, int, TransactionTag)>();
			CurrentTransactionsData = new int[Enum.GetValues(typeof(TransactionType)).Length, Enum.GetValues(typeof(TransactionTag)).Length];
			OldTransactionsData = new int[Enum.GetValues(typeof(TransactionType)).Length, Enum.GetValues(typeof(TransactionTag)).Length];
		}

		private void OnDisable()
		{
			SceneReset.Reset -= ResetData;
			CalendarHandlers.NewMonth -= NewMonth;
		}

		private void NewMonth()
		{
			ResetData();
			Array.Copy(CurrentTransactionsData, OldTransactionsData, CurrentTransactionsData.Length);
			RetrievingAllValues();
			TransactionsHandlers.DataUpdated?.Invoke(1);
		}

		private void RetrievingAllValues()
		{
			GetPurchaseOfGoodsExpensesData();
			GetFurnitureExpensesData();
			GetRenovationExpensesData();
			GetHumanCustomersIncomesData();
			GetVampireCustomersIncomesData();
			GetMissionsIncomesData();
			GetOtherSalesIncomesData();
			GetExceptionalIncomesData();
		}

		private void GetPurchaseOfGoodsExpensesData()
		{
			CurrentTransactionsData[1, 4] = 0;
			foreach (var item in TransactionsHistoryData.Where(((TransactionType, int, TransactionTag) item) => item.Item1 == TransactionType.Expense && item.Item3 == TransactionTag.Grocery))
			{
				CurrentTransactionsData[1, 4] += item.Item2;
			}
		}

		private void GetFurnitureExpensesData()
		{
			CurrentTransactionsData[1, 5] = 0;
			foreach (var item in TransactionsHistoryData.Where(((TransactionType, int, TransactionTag) item) => item.Item1 == TransactionType.Expense && item.Item3 == TransactionTag.Furniture))
			{
				CurrentTransactionsData[1, 5] += item.Item2;
			}
		}

		private void GetRenovationExpensesData()
		{
			CurrentTransactionsData[1, 6] = 0;
			foreach (var item in TransactionsHistoryData.Where(((TransactionType, int, TransactionTag) item) => item.Item1 == TransactionType.Expense && item.Item3 == TransactionTag.Renovation))
			{
				CurrentTransactionsData[1, 6] += item.Item2;
			}
		}

		private void GetHumanCustomersIncomesData()
		{
			CurrentTransactionsData[0, 0] = 0;
			foreach (var item in TransactionsHistoryData.Where(((TransactionType, int, TransactionTag) item) => item.Item1 == TransactionType.Income && item.Item3 == TransactionTag.HumanCustomer))
			{
				CurrentTransactionsData[0, 0] += item.Item2;
			}
		}

		private void GetVampireCustomersIncomesData()
		{
			CurrentTransactionsData[0, 1] = 0;
			foreach (var item in TransactionsHistoryData.Where(((TransactionType, int, TransactionTag) item) => item.Item1 == TransactionType.Income && item.Item3 == TransactionTag.VampireCustomer))
			{
				CurrentTransactionsData[0, 1] += item.Item2;
			}
		}

		private void GetMissionsIncomesData()
		{
			CurrentTransactionsData[0, 2] = 0;
			foreach (var item in TransactionsHistoryData.Where(((TransactionType, int, TransactionTag) item) => item.Item1 == TransactionType.Income && item.Item3 == TransactionTag.Mission))
			{
				CurrentTransactionsData[0, 2] += item.Item2;
			}
		}

		private void GetOtherSalesIncomesData()
		{
			CurrentTransactionsData[0, 3] = 0;
			foreach (var item in TransactionsHistoryData.Where(((TransactionType, int, TransactionTag) item) => item.Item1 == TransactionType.Income && item.Item3 == TransactionTag.OtherSale))
			{
				CurrentTransactionsData[0, 3] += item.Item2;
			}
		}

		private void GetExceptionalIncomesData()
		{
			CurrentTransactionsData[0, 7] = 0;
			foreach (var item in TransactionsHistoryData.Where(((TransactionType, int, TransactionTag) item) => item.Item1 == TransactionType.Income && item.Item3 == TransactionTag.Exceptional))
			{
				CurrentTransactionsData[0, 7] += item.Item2;
			}
		}

		public void ResetData()
		{
			TransactionsHistoryData.Clear();
		}

		public void AddNewData(TransactionType _type, int _amount, TransactionTag _tag)
		{
			_tmpNewArrayTransactionHistoryData = (_type, _amount, _tag);
			TransactionsHistoryData.Add(_tmpNewArrayTransactionHistoryData);
			RetrievingAllValues();
			TransactionsHandlers.DataUpdated?.Invoke(0);
		}
	}
}
