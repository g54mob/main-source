using System.Collections;
using DV.Booklets;
using DV.CashRegister;
using DV.Localization;
using DV.Printers;
using DV.Utils;
using TMPro;
using UnityEngine;

namespace DV.ServicePenalty.UI
{
	public class CareerManagerFeePayingScreen : DisplayScreen
	{
		private const double MIN_PRICE_THRESHOLD = 0.009999999776482582;

		public DisplayScreenSwitcher screenSwitcher;

		public CareerManagerFeesScreen feesScreen;

		public CashRegisterCareerManager cashReg;

		public PrinterController feePrinter;

		public TextMeshPro insuranceQuotaText;

		public TextMeshPro title2;

		public TextMeshPro debtPriceText;

		public TextMeshPro insertWallet;

		public TextMeshPro depositedText;

		public TextMeshPro depositedValue;

		public AudioClip prepareMoneySound;

		private Coroutine debtCostRefreshCoro;

		private bool clampPriceWithInsuranceParticipation;

		public DisplayableDebt DebtToPay { get; private set; }

		private void Awake()
		{
			if (screenSwitcher == null)
			{
				Debug.LogError("screenSwitcher reference isn't set! Screen can't function!");
			}
			else if (cashReg == null)
			{
				Debug.LogError("cashReg reference isn't set! Screen can't function!");
			}
			else if (feePrinter == null)
			{
				Debug.LogError("feePrinter reference isn't set! Screen can't function!");
			}
			else if (prepareMoneySound == null)
			{
				Debug.LogWarning("Not all audio references were set, some sounds effects won't be played!");
			}
		}

		public void SetDebtToPay(DisplayableDebt debt)
		{
			DebtToPay = debt;
		}

		public override void Activate(IDisplayScreen previousScreen)
		{
			if (DebtToPay == null)
			{
				Debug.LogError("DebtToPay wasn't set! Activating fees screen.");
				SwitchToFeesScreen();
				return;
			}
			float num = DebtToPay.GetTotalPrice();
			InsuranceFeeQuota feeQuota = SingletonBehaviour<CareerManagerDebtController>.Instance.feeQuota;
			clampPriceWithInsuranceParticipation = feeQuota.InsuranceUsed && feeQuota.LeftToReachQuota < num;
			if (clampPriceWithInsuranceParticipation)
			{
				num = feeQuota.LeftToReachQuota;
				insuranceQuotaText.text = CareerManagerFeesScreen.GetInsuranceQuotaText(SingletonBehaviour<CareerManagerDebtController>.Instance.feeQuota);
			}
			else
			{
				insuranceQuotaText.text = CareerManagerLocalization.FEES;
			}
			cashReg.SetTotalCost(num);
			cashReg.CashAdded += OnCashAdded;
			title2.text = CareerManagerLocalization.FEE_TITLE(DebtToPay.ID);
			debtPriceText.text = "$" + num.ToString("N2", LocalizationAPI.CC);
			insertWallet.text = CareerManagerLocalization.INSERT_WALLET_TO_PAY;
			depositedText.text = CareerManagerLocalization.DEPOSITED;
			depositedValue.text = "$" + cashReg.DepositedCash.ToString("N2", LocalizationAPI.CC);
			if (debtCostRefreshCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(debtCostRefreshCoro);
				debtCostRefreshCoro = null;
			}
			DebtType debtType = DebtToPay.GetDebtType();
			if (debtType == DebtType.StagedOther || debtType == DebtType.ExistingOther || debtType == DebtType.ExistingLoco || debtType == DebtType.ExistingJob)
			{
				debtCostRefreshCoro = SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(RefreshDebtCost());
			}
			if (prepareMoneySound != null)
			{
				prepareMoneySound.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
			}
		}

		public override void Disable()
		{
			SetDebtToPay(null);
			if (debtCostRefreshCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(debtCostRefreshCoro);
				debtCostRefreshCoro = null;
			}
			cashReg.ClearCurrentTransaction();
			cashReg.CashAdded -= OnCashAdded;
			TextMeshPro textMeshPro = insuranceQuotaText;
			TextMeshPro textMeshPro2 = title2;
			TextMeshPro textMeshPro3 = debtPriceText;
			TextMeshPro textMeshPro4 = insertWallet;
			TextMeshPro textMeshPro5 = depositedText;
			string text = (depositedValue.text = string.Empty);
			string text2 = (textMeshPro5.text = text);
			string text4 = (textMeshPro4.text = text2);
			string text6 = (textMeshPro3.text = text4);
			string text8 = (textMeshPro2.text = text6);
			textMeshPro.text = text8;
			clampPriceWithInsuranceParticipation = false;
		}

		public override void HandleInputAction(InputAction input)
		{
			switch (input)
			{
			case InputAction.Cancel:
				SwitchToFeesScreen();
				break;
			case InputAction.Confirm:
			{
				DebtType debtType = DebtToPay.GetDebtType();
				if (debtType == DebtType.ExistingLoco)
				{
					if (!(DebtToPay is ExistingLocoDebt item))
					{
						Debug.LogError(string.Format("Unexpected state: {0}: {1} couldn't be casted properly, returning to main screen!", "debtType", debtType));
						SwitchToFeesScreen();
						break;
					}
					if (!SingletonBehaviour<LocoDebtController>.Instance.trackedLocosDebts.Contains(item))
					{
						Debug.LogWarning("Fee was staged in the meantime (loco destroyed), returning to main screen!");
						SwitchToFeesScreen();
						break;
					}
				}
				if (debtType == DebtType.ExistingJob)
				{
					if (!(DebtToPay is ExistingJobDebt item2))
					{
						Debug.LogError(string.Format("Unexpected state: {0}: {1} couldn't be casted properly, returning to main screen!", "debtType", debtType));
						SwitchToFeesScreen();
						break;
					}
					if (!SingletonBehaviour<JobDebtController>.Instance.existingTrackedJobs.Contains(item2))
					{
						Debug.LogWarning("Fee was staged in the meantime (job abandoned/completed/expired), returning to main screen!");
						SwitchToFeesScreen();
						break;
					}
				}
				if (debtType == DebtType.StagedOther || debtType == DebtType.ExistingOther || debtType == DebtType.ExistingLoco || debtType == DebtType.ExistingJob)
				{
					UpdateDebtCost();
					if (cashReg.GetTotalCost() < 0.009999999776482582)
					{
						Debug.LogWarning("In the meantime price of debt became 0, returning to fees screen.");
						SwitchToFeesScreen();
						break;
					}
				}
				if (cashReg.Buy())
				{
					DebtToPay.Pay();
					SwitchToFeesScreen();
				}
				break;
			}
			case InputAction.PrintInfo:
			{
				if (feePrinter.IsOnCooldown)
				{
					feePrinter.PlayErrorSound();
					break;
				}
				Vector3 position = feePrinter.spawnAnchor.position;
				Quaternion rotation = feePrinter.spawnAnchor.rotation;
				BookletCreator.CreateDebtBooklet(DebtToPay, position, rotation, WorldMover.OriginShiftParent);
				feePrinter.Print();
				break;
			}
			}
		}

		private void SwitchToFeesScreen()
		{
			screenSwitcher.SetActiveDisplay(feesScreen);
		}

		private void OnCashAdded()
		{
			depositedValue.text = "$" + cashReg.DepositedCash.ToString("N2", LocalizationAPI.CC);
		}

		private IEnumerator RefreshDebtCost()
		{
			while (true)
			{
				yield return WaitFor.Seconds(1f);
				UpdateDebtCost();
				if (cashReg.GetTotalCost() < 0.009999999776482582)
				{
					Debug.LogWarning("In the meantime price of debt became 0, returning to fees screen.");
					SwitchToFeesScreen();
				}
			}
		}

		private void UpdateDebtCost()
		{
			if (DebtToPay == null)
			{
				return;
			}
			if (!DebtToPay.IsStaged)
			{
				DebtToPay.UpdateDebtState();
			}
			double totalCost = cashReg.GetTotalCost();
			float totalPrice = DebtToPay.GetTotalPrice();
			InsuranceFeeQuota feeQuota = SingletonBehaviour<CareerManagerDebtController>.Instance.feeQuota;
			bool flag = feeQuota.InsuranceUsed && feeQuota.LeftToReachQuota < totalPrice;
			if (flag != clampPriceWithInsuranceParticipation)
			{
				clampPriceWithInsuranceParticipation = flag;
				if (clampPriceWithInsuranceParticipation)
				{
					insuranceQuotaText.text = CareerManagerFeesScreen.GetInsuranceQuotaText(SingletonBehaviour<CareerManagerDebtController>.Instance.feeQuota);
				}
				else
				{
					insuranceQuotaText.text = CareerManagerLocalization.FEES;
				}
			}
			if (!(Mathd.Abs(totalCost - (double)totalPrice) >= 0.009999999776482582))
			{
				return;
			}
			float num = totalPrice;
			if (clampPriceWithInsuranceParticipation)
			{
				float num2 = Mathf.Min(SingletonBehaviour<CareerManagerDebtController>.Instance.feeQuota.LeftToReachQuota, totalPrice);
				if (totalCost == (double)num2)
				{
					return;
				}
				num = num2;
			}
			cashReg.SetTotalCost(num);
			debtPriceText.text = "$" + num.ToString("N2", LocalizationAPI.CC);
		}
	}
}
