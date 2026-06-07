using System;
using System.Collections.Generic;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CTS
{
	public class FinancialLoaningManager : MonoSingleton<FinancialLoaningManager>
	{
		[SerializeField]
		private bool _debugMode;

		[SerializeField]
		private string _allLoan;

		private readonly Dictionary<FinancialLoaningContract, float> _contractsInterestAmountQueue = new Dictionary<FinancialLoaningContract, float>();

		public readonly List<FinancialLoaningContract> Contracts = new List<FinancialLoaningContract>();

		public HashSet<FinancialLoaningContract> ActiveContracts = new HashSet<FinancialLoaningContract>();

		private float _totalMonthlyInstallment;

		public IList<FinancialLoanSO> FinancialLoanSO { get; set; }

		public static event Action OnLoanManagerInitialized;

		public static event Action OnInterestReset;

		public static event Action OnInterestChanged;

		public static event Action<int> OnTakeOutALoan;

		public static event Action OnLoanReimbursed;

		protected override void SingletonAwake()
		{
			FinancialLoanSO = Addressables.LoadAssetsAsync<FinancialLoanSO>("Financial").WaitForCompletion();
		}

		private void OnEnable()
		{
			CalendarHandlers.NewMonth += PayMonthlyInstallment;
		}

		private void Start()
		{
			FinancialLoaningManager.OnLoanManagerInitialized?.Invoke();
		}

		private void OnDisable()
		{
			CalendarHandlers.NewMonth -= PayMonthlyInstallment;
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void PayMonthlyInstallment()
		{
			foreach (FinancialLoaningContract activeContract in ActiveContracts)
			{
				if (activeContract.ContractIsActive)
				{
					activeContract.ItsTimeToPay();
				}
			}
		}

		private void ResetLoanInterest()
		{
			foreach (KeyValuePair<FinancialLoaningContract, float> item in _contractsInterestAmountQueue)
			{
				_contractsInterestAmountQueue[item.Key] = 0f;
			}
			FinancialLoaningManager.OnInterestReset?.Invoke();
		}

		public void NewLoanInstantiated(FinancialLoaningContract contract)
		{
			Contracts.Add(contract);
		}

		public void RemoveLoanDestroyed(FinancialLoaningContract contract)
		{
			if (_contractsInterestAmountQueue.ContainsKey(contract))
			{
				Contracts.Remove(contract);
			}
		}

		public void ChangeLoanInterest(float newInterest)
		{
			foreach (FinancialLoaningContract contract in Contracts)
			{
				if (_contractsInterestAmountQueue.ContainsKey(contract))
				{
					if (_contractsInterestAmountQueue[contract] > newInterest)
					{
						_contractsInterestAmountQueue[contract] = newInterest;
					}
				}
				else
				{
					_contractsInterestAmountQueue.Add(contract, newInterest);
				}
			}
			FinancialLoaningManager.OnInterestChanged?.Invoke();
		}

		public void NewLoanContraction(FinancialLoaningContract contract)
		{
			ActiveContracts.Add(contract);
			ResetLoanInterest();
			FinancialLoaningManager.OnTakeOutALoan?.Invoke(contract.GetContractAmount());
			if (ActiveContracts.Count >= Contracts.Count)
			{
				UnlockAchivement(_allLoan);
			}
		}

		public float GetLoanInterestPendingQueue(FinancialLoaningContract contract)
		{
			if (_contractsInterestAmountQueue.Remove(contract, out var value))
			{
				return value;
			}
			return 0f;
		}

		public void EndLoanContraction(FinancialLoaningContract contract)
		{
			ActiveContracts.Remove(contract);
			FinancialLoaningManager.OnLoanReimbursed?.Invoke();
		}

		public float GetMonthlyInstallment()
		{
			_totalMonthlyInstallment = 0f;
			if (ActiveContracts.Count == 0)
			{
				return 0f;
			}
			foreach (FinancialLoaningContract activeContract in ActiveContracts)
			{
				if (activeContract.ContractIsActive)
				{
					_totalMonthlyInstallment += activeContract.GetMonthlyInstallment();
				}
			}
			return _totalMonthlyInstallment;
		}

		private void UnlockAchivement(string Key)
		{
			Debug.Log("Unlock this : " + Key);
			if (Key != string.Empty)
			{
				AchievementManager.UnlockAchievement(Key);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void SetNewInterest()
		{
			ChangeLoanInterest(10f);
		}
	}
}
