using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.BBT.Handlers.Charges;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(-20)]
	public class ChargesHandlers : MonoSingleton<ChargesHandlers>, ILockable
	{
		[Space(10f)]
		public int[] ChargesData = new int[5];

		public int[] OldChargesData;

		[SerializeField]
		[Space(10f)]
		[Header("Link GameObjects")]
		private FinancialSettingsScriptable _baseFinancialSettings;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Debug")]
		private bool _debugMode;

		private int _exceptionalChargesCosts;

		private float _totalChargesCosts;

		private int _currentNbCells;

		private readonly Dictionary<Worker, int> _workersThisMonth = new Dictionary<Worker, int>();

		private FinancialSettingsScriptable _customFinancialSettingsSettings;

		private static readonly StringKey _difficultyInsuranceKey = "Diff_Insurance";

		private static readonly StringKey _difficultyEnergyKey = "Diff_Energy";

		public Lock ObjectLock { get; set; }

		private FinancialSettingsScriptable FinancialSettingsSettings
		{
			get
			{
				if (!_customFinancialSettingsSettings)
				{
					return _baseFinancialSettings;
				}
				return _customFinancialSettingsSettings;
			}
		}

		public Action<bool> LockStateChanged { get; set; }

		public static event Action<int> DataUpdated;

		public static event Action<ChargeTypes, int> ChargePayed;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void OnEnable()
		{
			CalendarHandlers.NewMonth += TriggerNewMonth;
			CalendarHandlers.NewMonth += TriggerNewMonth;
			Worker.WorkerSpawned += OnWorkerHired;
			BuildingRoomsContainerManager.OnCellsCountChanged += UpdateTotalCells;
			UpdateTotalCells(0);
		}

		private void OnDisable()
		{
			CalendarHandlers.NewMonth -= TriggerNewMonth;
			CalendarHandlers.NewMonth -= TriggerNewMonth;
			Worker.WorkerSpawned -= OnWorkerHired;
			BuildingRoomsContainerManager.OnCellsCountChanged -= UpdateTotalCells;
		}

		void ILockable.OnLocked()
		{
		}

		void ILockable.OnUnlocked()
		{
		}

		private void OnWorkerHired(Worker worker)
		{
			_workersThisMonth.Add(worker, MonoSingleton<CalendarHandlers>.Instance.CurrentDay);
			GetASimulation(simulation: true);
			ChargesHandlers.DataUpdated?.Invoke(0);
		}

		private void UpdateTotalCells(int cellsCount)
		{
			_currentNbCells = cellsCount;
		}

		private void TriggerNewMonth()
		{
			if (!ObjectLock.IsLocked())
			{
				if (OldChargesData.Length == 0)
				{
					OldChargesData = new int[ChargesData.Length];
				}
				Array.Copy(ChargesData, OldChargesData, ChargesData.Length);
				Array.Clear(ChargesData, 0, ChargesData.Length);
				GetASimulation(simulation: false);
				_exceptionalChargesCosts = 0;
				EventsManager.ChangeMoney?.Invoke(Currencies.Dollars, -(int)Math.Ceiling(_totalChargesCosts));
				ChargesHandlers.DataUpdated?.Invoke(1);
			}
		}

		private int CalculateSalaries(bool simulation)
		{
			int num = 0;
			int nBDaysCurrentMonth = MonoSingleton<CalendarHandlers>.Instance.NBDaysCurrentMonth;
			foreach (Worker item in WorkerList.All)
			{
				if (_workersThisMonth.TryGetValue(item, out var value))
				{
					int num2 = ((value == 1) ? item.Salary : ((int)Math.Round((float)item.Salary / (float)nBDaysCurrentMonth * (float)(nBDaysCurrentMonth - value))));
					num += num2;
					if (!simulation)
					{
						_workersThisMonth.Remove(item);
					}
				}
				else
				{
					num += item.Salary;
				}
			}
			return num;
		}

		private int CalculateInsurance()
		{
			if (MonoSingleton<CalendarHandlers>.Instance.CurrentMonth != 1 || MonoSingleton<CalendarHandlers>.Instance.CurrentYear != 0)
			{
				return (int)((float)_currentNbCells * FinancialSettingsSettings.InsuranceCosts * Difficulty.GetMultiplicativeDifficulty(_difficultyInsuranceKey));
			}
			return 0;
		}

		private int CalculateEnergy()
		{
			if (MonoSingleton<CalendarHandlers>.Instance.CurrentMonth != 1 || MonoSingleton<CalendarHandlers>.Instance.CurrentYear != 0)
			{
				return (int)((float)_currentNbCells * FinancialSettingsSettings.EnergyCosts * Difficulty.GetMultiplicativeDifficulty(_difficultyEnergyKey));
			}
			return 0;
		}

		private int CalculateLoans()
		{
			return (int)MonoSingleton<FinancialLoaningManager>.Instance.GetMonthlyInstallment();
		}

		private void GetASimulation(bool simulation)
		{
			_totalChargesCosts = 0f;
			ChargesData[0] = CalculateSalaries(simulation);
			if (!simulation)
			{
				ChargesHandlers.ChargePayed?.Invoke(ChargeTypes.Salaries, ChargesData[0]);
			}
			ChargesData[2] = CalculateInsurance();
			if (!simulation)
			{
				ChargesHandlers.ChargePayed?.Invoke(ChargeTypes.Insurance, ChargesData[2]);
			}
			ChargesData[1] = CalculateEnergy();
			if (!simulation)
			{
				ChargesHandlers.ChargePayed?.Invoke(ChargeTypes.Energy, ChargesData[1]);
			}
			ChargesData[3] = CalculateLoans();
			if (!simulation)
			{
				ChargesHandlers.ChargePayed?.Invoke(ChargeTypes.Loans, ChargesData[3]);
			}
			ChargesData[4] = _exceptionalChargesCosts;
			if (!simulation)
			{
				ChargesHandlers.ChargePayed?.Invoke(ChargeTypes.Exceptional, ChargesData[4]);
			}
			int[] chargesData = ChargesData;
			foreach (float num in chargesData)
			{
				_totalChargesCosts += num;
			}
		}

		public void AddExceptionalCharges(int amount)
		{
			_exceptionalChargesCosts += amount;
		}

		public void SetFinancialSettings(FinancialSettingsScriptable settings)
		{
			_customFinancialSettingsSettings = settings;
		}
	}
}
