using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.CabControls;
using DV.CashRegister;
using DV.InventorySystem;
using DV.UserManagement;
using DV.Utils;
using UnityEngine;

namespace DV.ServicePenalty
{
	public class CareerManagerDebtController : SingletonBehaviour<CareerManagerDebtController>
	{
		public const float STARTING_INSURANCE_QUOTA = 100f;

		public const float SAVE_DEBT_PRICE_THRESHOLD = 0f;

		public const int TOLERANCE_EXPIRATION_HOUR = 7;

		private const float ALLOW_JOB_TAKING_MONEY_THRESHOLD = 20000f;

		private const float FEE_TOLERANCE_BASIC_AMOUNT = 5000f;

		private const float FEE_TOLERANCE_PLAYER_MONEY_LOWER_BOUND = 20000f;

		private const float FEE_TOLERANCE_PLAYER_MONEY_HIGHER_BOUND = 450000f;

		private const float MAX_FEE_TOLERANCE_ADDITION = 95000f;

		private const float DEBT_REFRESH_PERIOD_REALWORLD_SECONDS = 60f;

		public InsuranceFeeQuota feeQuota = new InsuranceFeeQuota(100f);

		private List<DisplayableDebt> currentNonZeroPricedDebts = new List<DisplayableDebt>();

		private List<DisplayableDebt> currentZeroPricedDebts = new List<DisplayableDebt>();

		public bool HasAnyUnpayableFees => currentNonZeroPricedDebts.Any((DisplayableDebt debt) => !debt.IsPayable);

		public int NumberOfNonZeroPricedDebts => currentNonZeroPricedDebts.Count;

		public int NumberOfZeroPricedDebts => currentZeroPricedDebts.Count;

		public float TotalFees
		{
			get
			{
				RefreshExistingDebtsState();
				return GetAllDebtsPrice();
			}
		}

		public static float FeeTolerance
		{
			get
			{
				float num = Mathf.InverseLerp(20000f, 450000f, (float)SingletonBehaviour<Inventory>.Instance.PlayerMoney);
				return Mathf.Round(5000f + num * 95000f);
			}
		}

		public event Action DebtListsUpdated;

		public new static string AllowAutoCreate()
		{
			return "[CareerManagerDebtController]";
		}

		protected override void Awake()
		{
			base.Awake();
			LicenseManager instance = SingletonBehaviour<LicenseManager>.Instance;
			feeQuota.Quota = instance.InsuranceFeeQuota;
			instance.InsuranceFeeQuotaUpdated += OnInsuranceFeeQuotaUpdated;
			LocoResourceModule.LocoResourceBoughtGlobalEvent += OnLocoResourceBought;
			StartCoroutine(PeriodicalDebtsRefresh());
		}

		public void RegisterDebt(DisplayableDebt debt)
		{
			if (!debt.IsStaged && debt.GetTotalPrice() <= 0f)
			{
				currentZeroPricedDebts.Add(debt);
				return;
			}
			currentNonZeroPricedDebts.Add(debt);
			this.DebtListsUpdated?.Invoke();
		}

		public void UnregisterDebt(DisplayableDebt debt)
		{
			if (!currentZeroPricedDebts.Remove(debt))
			{
				if (currentNonZeroPricedDebts.Remove(debt))
				{
					this.DebtListsUpdated?.Invoke();
				}
				else
				{
					Debug.LogError("Couldn't unregister debt, not found! DebtID: " + debt.ID);
				}
			}
		}

		public void RefreshExistingDebtsState()
		{
			for (int num = currentNonZeroPricedDebts.Count - 1; num >= 0; num--)
			{
				DisplayableDebt displayableDebt = currentNonZeroPricedDebts[num];
				if (!displayableDebt.IsStaged)
				{
					displayableDebt.UpdateDebtState();
				}
				if ((displayableDebt.GetDebtType() == DebtType.ExistingOther || displayableDebt.GetDebtType() == DebtType.ExistingLoco) && displayableDebt.GetTotalPrice() <= 0f)
				{
					currentNonZeroPricedDebts.RemoveAt(num);
					currentZeroPricedDebts.Add(displayableDebt);
				}
			}
			for (int num2 = currentZeroPricedDebts.Count - 1; num2 >= 0; num2--)
			{
				DisplayableDebt displayableDebt2 = currentZeroPricedDebts[num2];
				if (!displayableDebt2.IsStaged)
				{
					displayableDebt2.UpdateDebtState();
					if (displayableDebt2.GetTotalPrice() > 0f)
					{
						currentZeroPricedDebts.RemoveAt(num2);
						currentNonZeroPricedDebts.Add(displayableDebt2);
					}
				}
			}
		}

		public bool IsPlayerAllowedToTakeJob()
		{
			if (SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.GameMode == "FreeRoam")
			{
				return true;
			}
			double num = SingletonBehaviour<Inventory>.Instance.PlayerMoney;
			foreach (CashRegisterBase allCashRegister in CashRegisterBase.allCashRegisters)
			{
				num += (double)(float)allCashRegister.DepositedCash;
			}
			if (SingletonBehaviour<StorageController>.Instance != null)
			{
				num += SingletonBehaviour<StorageController>.Instance.GetAllStorageItems().Sum(delegate(ItemBase item)
				{
					if (item == null)
					{
						return 0.0;
					}
					Banknotes component = item.GetComponent<Banknotes>();
					return (!(component != null)) ? 0.0 : component.Amount;
				});
			}
			if (num < 20000.0)
			{
				return true;
			}
			RefreshExistingDebtsState();
			SortNonZeroDebtsAscending();
			DateTime tolerableDateTime = SingletonBehaviour<DateTimeWrapper>.Instance.GetDateTimeOfMostRecentHour(7);
			List<DisplayableDebt> list = currentNonZeroPricedDebts.Where((DisplayableDebt d) => d.ActivationTime < tolerableDateTime).ToList();
			if (list.Count == 0)
			{
				return true;
			}
			float feeTolerance = FeeTolerance;
			float num2 = 0f;
			for (int num3 = 0; num3 < list.Count; num3++)
			{
				float totalPrice = list[num3].GetTotalPrice();
				num2 += totalPrice;
			}
			if (num2 > feeTolerance)
			{
				bool num4 = (double)list[0].GetTotalPrice() <= num;
				bool flag = feeQuota.InsuranceUsed && (double)feeQuota.LeftToReachQuota <= num;
				if (!num4)
				{
					return !flag;
				}
				return false;
			}
			return true;
		}

		public void SortNonZeroDebtsAscending()
		{
			currentNonZeroPricedDebts.Sort((DisplayableDebt debt1, DisplayableDebt debt2) => debt1.GetTotalPrice().CompareTo(debt2.GetTotalPrice()));
		}

		public void ClearDebtsViaInsuranceQuotaReached()
		{
			ClearRestOfThePayableDebts();
			feeQuota.ClearPaidQuota();
		}

		public void ClearRestOfThePayableDebts()
		{
			for (int num = currentNonZeroPricedDebts.Count - 1; num >= 0; num--)
			{
				DisplayableDebt displayableDebt = currentNonZeroPricedDebts[num];
				if (displayableDebt.IsPayable)
				{
					displayableDebt.Pay();
				}
			}
		}

		public float GetAllDebtsPrice()
		{
			float num = 0f;
			foreach (DisplayableDebt currentNonZeroPricedDebt in currentNonZeroPricedDebts)
			{
				num += currentNonZeroPricedDebt.GetTotalPrice();
			}
			return num;
		}

		public DisplayableDebt GetIthNonZeroDebt(int i)
		{
			if (i < 0 || i >= currentNonZeroPricedDebts.Count)
			{
				Debug.LogError($"Index for selecting debt is out of range (Entries count {currentNonZeroPricedDebts.Count},  attempted index: {i})");
				return null;
			}
			return currentNonZeroPricedDebts[i];
		}

		public DisplayableDebt GetIthZeroDebt(int i)
		{
			if (i < 0 || i >= currentZeroPricedDebts.Count)
			{
				Debug.LogError($"Index for selecting debt is out of range (Entries count {currentZeroPricedDebts.Count},  attempted index: {i})");
				return null;
			}
			return currentZeroPricedDebts[i];
		}

		private void OnInsuranceFeeQuotaUpdated()
		{
			feeQuota.Quota = SingletonBehaviour<LicenseManager>.Instance.InsuranceFeeQuota;
		}

		private void OnLocoResourceBought(float manualServiceResourcePrice, bool playerSpawnedOrOwnedCar)
		{
			if (!playerSpawnedOrOwnedCar)
			{
				UpdateInsuranceFeePaidAmount(manualServiceResourcePrice);
			}
		}

		public void UpdateInsuranceFeePaidAmount(float paidAmount)
		{
			if (feeQuota.InsuranceUsed)
			{
				feeQuota.PayInsuranceAmount(paidAmount);
			}
		}

		private IEnumerator PeriodicalDebtsRefresh()
		{
			while (true)
			{
				yield return WaitFor.Seconds(60f);
				RefreshExistingDebtsState();
			}
		}

		public void PrintDebtsActivationTime()
		{
			string text = "Debts:\n";
			for (int i = 0; i < NumberOfZeroPricedDebts; i++)
			{
				DisplayableDebt ithZeroDebt = GetIthZeroDebt(i);
				text += $"[{ithZeroDebt.GetDebtType()} # {ithZeroDebt.ID} # ] = {ithZeroDebt.GetTotalPrice()} - Time {ithZeroDebt.ActivationTime}\n";
			}
			for (int j = 0; j < NumberOfNonZeroPricedDebts; j++)
			{
				DisplayableDebt ithNonZeroDebt = GetIthNonZeroDebt(j);
				text += $"[{ithNonZeroDebt.GetDebtType()} # {ithNonZeroDebt.ID} # ] = {ithNonZeroDebt.GetTotalPrice()} - Time {ithNonZeroDebt.ActivationTime}\n";
			}
			Debug.Log(text);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<LicenseManager>.Instance.InsuranceFeeQuotaUpdated -= OnInsuranceFeeQuotaUpdated;
			}
			LocoResourceModule.LocoResourceBoughtGlobalEvent -= OnLocoResourceBought;
		}
	}
}
