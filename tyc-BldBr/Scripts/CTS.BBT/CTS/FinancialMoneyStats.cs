using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CTS.BBT.Handlers.Transactions;
using CTS.Core;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(-10)]
	public class FinancialMoneyStats : MonoSingleton<FinancialMoneyStats>
	{
		[SerializeField]
		[Space(10f)]
		[BoxGroup("GameObject Links")]
		private TextMeshProUGUI _currentMonthlyTurnover;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TextMeshProUGUI _lastMonthlyTurnover;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TextMeshProUGUI _balanceDataText;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("GameObject Links")]
		private TextMeshProUGUI[] _chargesDataCurrentMonth;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TextMeshProUGUI[] _chargesDataLastMonth;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TextMeshProUGUI[] _incomesDataCurrentMonth;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TextMeshProUGUI[] _incomesDataLastMonth;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Debug View")]
		private int[] _chargesData;

		[SerializeField]
		[BoxGroup("Debug View")]
		private int[] _oldChargesData;

		[SerializeField]
		[Foldout("Success")]
		private float _successAmount;

		[SerializeField]
		[Foldout("Success")]
		private string _keyToUnlock;

		private ChargesHandlers _chargesHandlersInstance;

		private TransactionsHandlers _transactionsHandlersInstance;

		private int[,] _currentTransactionsData;

		private int[,] _oldTransactionsData;

		private float _currentIncomeAmount;

		private float _oldIncomeAmount;

		private float _currentExpenseAmount;

		private float _oldExpenseAmount;

		private float _currentMonth;

		private float _totalWin;

		private int _balanceDataSavingSystem;

		private string[] _chargesDataCurrentMonthSavingSystem;

		private string[] _chargesDataLastMonthSavingSystem;

		private string[] _incomesDataCurrentMonthSavingSystem;

		private string[] _incomesDataLastMonthSavingSystem;

		private int[,] _currentTransactionsDataSavingSystem;

		private int[,] _oldTransactionsDataSavingSystem;

		private int[] _chargesDataSavingSystem;

		private int[] _oldChargesDataSavingSystem;

		public static event Action NegatifMonth;

		protected override void SingletonAwake()
		{
			InitializeHandlers();
			FinancialGraph.OnGraphRefresh += RefreshResult;
			FinancialGraph.OnGraphLoaded += FinancialGraph_OnGraphLoaded;
			CalendarHandlers.NewMonthAfterYearChanged += CalendarHandlers_NewMonthAfterYearChanged;
		}

		private void CalendarHandlers_NewMonthAfterYearChanged()
		{
			StartCoroutine(RefreshMounthDelay());
		}

		private IEnumerator RefreshMounthDelay()
		{
			yield return new WaitForSeconds(1f);
			_currentIncomeAmount = CalculateTotalAmount(_currentTransactionsData, TransactionType.Income);
			_currentExpenseAmount = CalculateTotalExpenses(_chargesData, _currentTransactionsData);
			if (_currentIncomeAmount < _currentExpenseAmount)
			{
				FinancialMoneyStats.NegatifMonth?.Invoke();
			}
			Debug.Log("Month passed " + (_currentIncomeAmount < _currentExpenseAmount));
			RefreshResult();
			UpdateGraph();
		}

		private void OnEnable()
		{
			RegisterEvents();
			InitializeDataArrays();
			ResetData();
		}

		private void Start()
		{
		}

		private void OnDisable()
		{
			UnregisterEvents();
		}

		protected override void OnSingletonDestroy()
		{
			FinancialGraph.OnGraphRefresh -= RefreshResult;
			FinancialGraph.OnGraphLoaded -= FinancialGraph_OnGraphLoaded;
			CalendarHandlers.NewMonthAfterYearChanged -= CalendarHandlers_NewMonthAfterYearChanged;
		}

		private void InitializeHandlers()
		{
			_chargesHandlersInstance = MonoSingleton<ChargesHandlers>.Instance;
			_transactionsHandlersInstance = MonoSingleton<TransactionsHandlers>.Instance;
		}

		private void RegisterEvents()
		{
			MoneyHandler.MoneyAmountChanged += RefreshCurrentBalance;
			ChargesHandlers.DataUpdated += RefreshChargesData;
			TransactionsHandlers.DataUpdated += RefreshTransactionsData;
		}

		private void UnregisterEvents()
		{
			MoneyHandler.MoneyAmountChanged -= RefreshCurrentBalance;
			ChargesHandlers.DataUpdated -= RefreshChargesData;
			TransactionsHandlers.DataUpdated -= RefreshTransactionsData;
		}

		private void InitializeDataArrays()
		{
			_currentTransactionsData = new int[Enum.GetValues(typeof(TransactionType)).Length, Enum.GetValues(typeof(TransactionTag)).Length];
			_oldTransactionsData = new int[Enum.GetValues(typeof(TransactionType)).Length, Enum.GetValues(typeof(TransactionTag)).Length];
		}

		private void RefreshCurrentBalance(int _amount)
		{
			_balanceDataText.text = "$" + _amount.ToString("N0", CultureInfo.GetCultureInfo("fr-FR"));
		}

		private void RefreshChargesData(int refreshType)
		{
			_chargesData = _chargesHandlersInstance.ChargesData;
			_oldChargesData = _chargesHandlersInstance.OldChargesData;
			UpdateChargesData(_chargesHandlersInstance.ChargesData, _chargesDataCurrentMonth);
			if (refreshType == 1)
			{
				UpdateChargesData(_chargesHandlersInstance.OldChargesData, _chargesDataLastMonth);
			}
		}

		private void RefreshTransactionsData(int refreshType)
		{
			UpdateTransactionData(_transactionsHandlersInstance.CurrentTransactionsData, _currentTransactionsData, _incomesDataCurrentMonth, _chargesDataCurrentMonth);
			if (refreshType == 1)
			{
				UpdateTransactionData(_transactionsHandlersInstance.OldTransactionsData, _oldTransactionsData, _incomesDataLastMonth, _chargesDataLastMonth);
				return;
			}
			RefreshResult();
			UpdateGraph();
		}

		private void RefreshResult()
		{
			_currentIncomeAmount = CalculateTotalAmount(_currentTransactionsData, TransactionType.Income);
			_oldIncomeAmount = CalculateTotalAmount(_oldTransactionsData, TransactionType.Income);
			_currentExpenseAmount = CalculateTotalExpenses(_chargesData, _currentTransactionsData);
			_oldExpenseAmount = CalculateTotalExpenses(_oldChargesData, _oldTransactionsData);
			float num = _oldIncomeAmount - _oldExpenseAmount;
			if (num > 0f)
			{
				_totalWin += num;
			}
			if (_totalWin >= _successAmount)
			{
				AchievementManager.UnlockAchievement(_keyToUnlock);
			}
			UpdateTurnover(_currentMonthlyTurnover, _currentIncomeAmount, _currentExpenseAmount);
			UpdateTurnover(_lastMonthlyTurnover, _oldIncomeAmount, _oldExpenseAmount);
		}

		private float CalculateTotalAmount(int[,] transactionsData, TransactionType transactionType)
		{
			return Enumerable.Range(0, transactionsData.GetLength(1)).Sum((int i) => transactionsData[(int)transactionType, i]);
		}

		private float CalculateTotalExpenses(int[] chargesData, int[,] transactionsData)
		{
			return chargesData.Sum() + transactionsData[1, 4] + transactionsData[1, 5] + transactionsData[1, 6];
		}

		private void UpdateTurnover(TextMeshProUGUI turnoverText, float income, float expenses)
		{
			turnoverText.text = "$" + ((int)(income - expenses)).ToString("N0", CultureInfo.GetCultureInfo("fr-FR"));
		}

		private void UpdateChargesData(int[] chargesData, TextMeshProUGUI[] displayData)
		{
			foreach (KeyValuePair<int, Func<int>> item in new Dictionary<int, Func<int>>
			{
				{
					0,
					() => chargesData[0]
				},
				{
					1,
					() => chargesData[1] + chargesData[2]
				},
				{
					4,
					() => chargesData[3]
				},
				{
					5,
					() => chargesData[4]
				}
			})
			{
				displayData[item.Key].text = "$" + item.Value();
			}
		}

		private void UpdateTransactionData(int[,] sourceData, int[,] destinationData, TextMeshProUGUI[] incomesDisplay, TextMeshProUGUI[] expensesDisplay)
		{
			Array.Copy(sourceData, destinationData, sourceData.Length);
			expensesDisplay[2].text = "$" + destinationData[1, 4];
			expensesDisplay[3].text = "$" + (destinationData[1, 5] + destinationData[1, 6]);
			for (int i = 0; i < incomesDisplay.Length; i++)
			{
				incomesDisplay[i].text = "$" + destinationData[0, i];
			}
		}

		private void FinancialGraph_OnGraphLoaded()
		{
			UpdateGraph();
		}

		private void UpdateGraph()
		{
			MonoSingleton<FinancialGraph>.Instance.UpdateGraph(ToDataGraph());
		}

		public float[] ToDataGraph()
		{
			return new float[2] { _currentIncomeAmount, _currentExpenseAmount };
		}

		private void ResetGraphData()
		{
		}

		private void ResetData()
		{
			ResetTextFields(_chargesDataCurrentMonth);
			ResetTextFields(_chargesDataLastMonth);
			ResetTextFields(_incomesDataCurrentMonth);
			ResetTextFields(_incomesDataLastMonth);
			_currentMonthlyTurnover.text = "$0";
			_lastMonthlyTurnover.text = "$0";
		}

		private void ResetTextFields(TextMeshProUGUI[] textFields)
		{
			for (int i = 0; i < textFields.Length; i++)
			{
				textFields[i].text = "$0";
			}
		}

		public void SaveSavingData()
		{
			_balanceDataSavingSystem = MonoSingleton<MoneyHandler>.Instance.CurrentMoney;
			_currentTransactionsDataSavingSystem = (int[,])_currentTransactionsData.Clone();
			_oldTransactionsDataSavingSystem = (int[,])_oldTransactionsData.Clone();
			_chargesDataSavingSystem = (int[])_chargesData.Clone();
			_oldChargesDataSavingSystem = (int[])_oldChargesData.Clone();
		}

		public void LoadSavingData()
		{
			RefreshCurrentBalance(_balanceDataSavingSystem);
			_currentTransactionsData = (int[,])_currentTransactionsDataSavingSystem.Clone();
			_oldTransactionsData = (int[,])_oldTransactionsDataSavingSystem.Clone();
			_chargesData = (int[])_chargesDataSavingSystem.Clone();
			_oldChargesData = (int[])_oldChargesDataSavingSystem.Clone();
			UpdateChargesData(_chargesHandlersInstance.ChargesData, _chargesDataCurrentMonth);
			if (_chargesHandlersInstance.OldChargesData.Length != 0)
			{
				UpdateChargesData(_chargesHandlersInstance.OldChargesData, _chargesDataLastMonth);
			}
			UpdateTransactionData(_transactionsHandlersInstance.CurrentTransactionsData, _currentTransactionsData, _incomesDataCurrentMonth, _chargesDataCurrentMonth);
			UpdateTransactionData(_transactionsHandlersInstance.OldTransactionsData, _oldTransactionsData, _incomesDataLastMonth, _chargesDataLastMonth);
			RefreshResult();
		}
	}
}
