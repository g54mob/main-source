using System;
using System.Collections;
using System.Collections.Generic;
using DV.Booklets;
using DV.Localization;
using DV.OriginShift;
using DV.Printers;
using DV.Utils;
using TMPro;
using UnityEngine;

namespace DV.ServicePenalty.UI
{
	public class CareerManagerFeesScreen : ScrollableDisplayScreen
	{
		[Serializable]
		private class FeeEntry
		{
			public TextMeshPro id;

			public TextMeshPro value;

			public FeeEntry(TextMeshPro id, TextMeshPro value)
			{
				this.id = id;
				this.value = value;
			}
		}

		private const float DEBT_REFRESH_PERIOD = 1f;

		private const float MANUAL_SERVICE_MESSAGE_PRICE_THRESHOLD = 5000f;

		public DisplayScreenSwitcher screenSwitcher;

		public CareerManagerMainScreen mainScreen;

		public CareerManagerFeePayingScreen feePayScreen;

		public CareerManagerCustomActionChoiceScreen confirmActionScreen;

		public CareerManagerInfoScreen infoScreen;

		public PrinterController feePrinter;

		public TextMeshPro insuranceQuotaText;

		public TextMeshPro pressPrintInfo;

		public TextMeshPro paragraphText;

		[SerializeField]
		private List<FeeEntry> feeEntries;

		public AudioClip feesClearedSound;

		private Coroutine periodicRefreshCoro;

		protected override int TotalSlotCount => SingletonBehaviour<CareerManagerDebtController>.Instance.NumberOfNonZeroPricedDebts;

		private void Awake()
		{
			if (screenSwitcher == null)
			{
				Debug.LogError("screenSwitcher reference isn't set! Screen can't function!");
				return;
			}
			if (feePrinter == null)
			{
				Debug.LogError("feePrinter reference isn't set! Screen can't function!");
				return;
			}
			if (feesClearedSound == null)
			{
				Debug.LogWarning("Not all audio references were set, some sounds effects won't be played!");
			}
			activeSlotCount = feeEntries.Count;
			if (activeSlotCount == 0)
			{
				Debug.LogError("feeEntries count is 0. Screen can't function properly!");
			}
			selector = new IntIterator(0, 0, isWrappable: true);
		}

		private void SetupListeners(bool set)
		{
			if (set)
			{
				SingletonBehaviour<CareerManagerDebtController>.Instance.DebtListsUpdated += OnDebtListUpdated;
			}
			else
			{
				SingletonBehaviour<CareerManagerDebtController>.Instance.DebtListsUpdated -= OnDebtListUpdated;
			}
		}

		public override void Activate(IDisplayScreen previousScreen)
		{
			SingletonBehaviour<CareerManagerDebtController>.Instance.RefreshExistingDebtsState();
			SingletonBehaviour<CareerManagerDebtController>.Instance.SortNonZeroDebtsAscending();
			InsuranceFeeQuota feeQuota = SingletonBehaviour<CareerManagerDebtController>.Instance.feeQuota;
			if (feeQuota.InsuranceUsed && feeQuota.QuotaReached)
			{
				if (!SingletonBehaviour<CareerManagerDebtController>.Instance.HasAnyUnpayableFees)
				{
					SingletonBehaviour<CareerManagerDebtController>.Instance.ClearDebtsViaInsuranceQuotaReached();
					SwitchToInsuranceQuotaClearedAllFeesInfoScreen();
					return;
				}
				Debug.LogError("Unexpected state: There are some debts that are not payable! Can't clear fees");
			}
			SetSelectorWithinBounds();
			if (previousScreen != mainScreen)
			{
				SetIndexOfFirstDisplayWithinBounds();
			}
			else
			{
				selector.Reset();
				base.IndexOfFirstDisplayedEntry = 0;
			}
			Scroll(base.IndexOfFirstDisplayedEntry, selector.Current);
			SetupListeners(set: true);
			if (periodicRefreshCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(periodicRefreshCoro);
			}
			periodicRefreshCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(PeriodicRefresh());
			pressPrintInfo.text = ((SingletonBehaviour<CareerManagerDebtController>.Instance.NumberOfNonZeroPricedDebts > 0) ? CareerManagerLocalization.PRESS_PRINT_FOR_DETAILS : string.Empty);
		}

		public override void Disable()
		{
			TextMeshPro textMeshPro = insuranceQuotaText;
			TextMeshPro textMeshPro2 = pressPrintInfo;
			string text = (paragraphText.text = string.Empty);
			string text2 = (textMeshPro2.text = text);
			textMeshPro.text = text2;
			ClearTextsFromIndex(0);
			base.Disable();
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(set: false);
				if (periodicRefreshCoro != null)
				{
					SingletonBehaviour<CoroutineManager>.Instance.Stop(periodicRefreshCoro);
					periodicRefreshCoro = null;
				}
			}
		}

		public override void HandleInputAction(InputAction input)
		{
			if (!selector.HasElements && input != InputAction.Cancel)
			{
				return;
			}
			switch (input)
			{
			case InputAction.Up:
				ScrollUp();
				break;
			case InputAction.Down:
				ScrollDown();
				break;
			case InputAction.Cancel:
				SwitchToMainScreen();
				break;
			case InputAction.Confirm:
			{
				DisplayableDebt debtToPay = SingletonBehaviour<CareerManagerDebtController>.Instance.GetIthNonZeroDebt(base.IndexOfFirstDisplayedEntry + selector.Current);
				if (debtToPay == null)
				{
					break;
				}
				if (debtToPay.IsPayable)
				{
					InsuranceFeeQuota feeQuota = SingletonBehaviour<CareerManagerDebtController>.Instance.feeQuota;
					if (feeQuota.InsuranceUsed && feeQuota.QuotaReached)
					{
						Debug.LogError("Unexpected state: Shouldn't be able to pay a fee when quota is reached! Switching to main menu");
						SwitchToMainScreen();
						break;
					}
					ExistingLocoDebt existingLocoDebt;
					if ((existingLocoDebt = debtToPay as ExistingLocoDebt) != null)
					{
						float totalPrice = debtToPay.GetTotalPrice();
						bool flag = !feeQuota.InsuranceUsed || (feeQuota.InsuranceUsed && feeQuota.LeftToReachQuota > totalPrice / 2f);
						bool flag2 = totalPrice > 5000f;
						if (!existingLocoDebt.locoDebtTracker.IsDebtOnlyEnvironmental() && flag2 && flag)
						{
							string dO_YOU_HAVE_MANUAL_SERVICE = CareerManagerLocalization.DO_YOU_HAVE_MANUAL_SERVICE;
							string yOU_COULD_SAVE_MONEY = CareerManagerLocalization.YOU_COULD_SAVE_MONEY;
							Action actionToTakeOnConfirm = delegate
							{
								if (SingletonBehaviour<LocoDebtController>.Instance.trackedLocosDebts.Contains(existingLocoDebt))
								{
									debtToPay.UpdateDebtState();
									existingLocoDebt.locoDebtTracker.TurnOffDebtSources();
									feePayScreen.SetDebtToPay(debtToPay);
									confirmActionScreen.OverrideReturnScreen(feePayScreen);
								}
							};
							confirmActionScreen.SetCustomActionData(actionToTakeOnConfirm, this, dO_YOU_HAVE_MANUAL_SERVICE, yOU_COULD_SAVE_MONEY);
							screenSwitcher.SetActiveDisplay(confirmActionScreen);
							break;
						}
						existingLocoDebt.locoDebtTracker.TurnOffDebtSources();
					}
					feePayScreen.SetDebtToPay(debtToPay);
					screenSwitcher.SetActiveDisplay(feePayScreen);
				}
				else
				{
					Debug.LogError($"Unexpected state: debt type {debtToPay.GetDebtType()} isn't payable (something is not right). Ignoring request!");
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
				DisplayableDebt ithNonZeroDebt = SingletonBehaviour<CareerManagerDebtController>.Instance.GetIthNonZeroDebt(base.IndexOfFirstDisplayedEntry + selector.Current);
				Vector3 position = feePrinter.spawnAnchor.position;
				Quaternion rotation = feePrinter.spawnAnchor.rotation;
				BookletCreator.CreateDebtBooklet(ithNonZeroDebt, position, rotation, WorldMover.OriginShiftParent);
				feePrinter.Print();
				break;
			}
			}
		}

		private void OnDebtListUpdated()
		{
			SetSelectorWithinBounds();
			SetIndexOfFirstDisplayWithinBounds();
			Scroll(base.IndexOfFirstDisplayedEntry, selector.Current);
		}

		private IEnumerator PeriodicRefresh()
		{
			while (true)
			{
				yield return WaitFor.Seconds(1f);
				SingletonBehaviour<CareerManagerDebtController>.Instance.RefreshExistingDebtsState();
				OnDebtListUpdated();
				bool flag = SingletonBehaviour<CareerManagerDebtController>.Instance.NumberOfNonZeroPricedDebts > 0;
				if (!string.IsNullOrEmpty(pressPrintInfo.text) != flag)
				{
					pressPrintInfo.text = (flag ? CareerManagerLocalization.PRESS_PRINT_FOR_DETAILS : string.Empty);
				}
			}
		}

		public override void PopulateTextsFromIndex(int startingIndex)
		{
			base.PopulateTextsFromIndex(startingIndex);
			int num = Mathf.Min(TotalSlotCount - startingIndex, activeSlotCount);
			for (int i = 0; i < num; i++)
			{
				DisplayableDebt ithNonZeroDebt = SingletonBehaviour<CareerManagerDebtController>.Instance.GetIthNonZeroDebt(startingIndex + i);
				string text = string.Empty;
				if (ithNonZeroDebt is ExistingLocoDebt existingLocoDebt)
				{
					Vector3 point = existingLocoDebt.car.transform.AbsolutePosition();
					text = ((SingletonBehaviour<LevelInfo>.Instance != null) ? ("[" + SingletonBehaviour<LevelInfo>.Instance.Get8x8PositionCoords(point) + "]") : "N/A");
				}
				feeEntries[i].id.text = ithNonZeroDebt.ID + " " + text;
				feeEntries[i].value.text = "$" + ithNonZeroDebt.GetTotalPrice().ToString("N2", LocalizationAPI.CC);
			}
			if (num <= 0)
			{
				paragraphText.text = CareerManagerLocalization.NO_FEES_CAN_BUY_LICENSES;
				insuranceQuotaText.text = CareerManagerLocalization.FEES;
			}
			else
			{
				paragraphText.text = "";
				insuranceQuotaText.text = GetInsuranceQuotaText(SingletonBehaviour<CareerManagerDebtController>.Instance.feeQuota);
			}
			ClearTextsFromIndex(num);
		}

		private void ClearTextsFromIndex(int startClearIndex)
		{
			for (int i = startClearIndex; i < activeSlotCount; i++)
			{
				feeEntries[i].id.text = string.Empty;
				feeEntries[i].value.text = string.Empty;
			}
		}

		public override void HighlightSelected(int newHighlight, int prevHighlighted = -1)
		{
			if (prevHighlighted != -1 && prevHighlighted != newHighlight)
			{
				feeEntries[prevHighlighted].id.color = screenSwitcher.REGULAR_COLOR;
				feeEntries[prevHighlighted].value.color = screenSwitcher.REGULAR_COLOR;
			}
			if (newHighlight != -1)
			{
				feeEntries[newHighlight].id.color = screenSwitcher.HIGHLIGHTED_COLOR;
				feeEntries[newHighlight].value.color = screenSwitcher.HIGHLIGHTED_COLOR;
			}
		}

		private void SwitchToInsuranceQuotaClearedAllFeesInfoScreen()
		{
			infoScreen.SetInfoData(mainScreen, CareerManagerInfoScreen.Preset.FeesCleared);
			if (feesClearedSound != null)
			{
				feesClearedSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
			}
			screenSwitcher.SetActiveDisplay(infoScreen);
		}

		private void SwitchToMainScreen()
		{
			screenSwitcher.SetActiveDisplay(mainScreen);
		}

		public static string GetInsuranceQuotaText(InsuranceFeeQuota feeQuota)
		{
			if (feeQuota.InsuranceUsed)
			{
				float allDebtsPrice = SingletonBehaviour<CareerManagerDebtController>.Instance.GetAllDebtsPrice();
				if (feeQuota.LeftToReachQuota > allDebtsPrice)
				{
					return CareerManagerLocalization.PAY_FEES_TO_REDUCE_COPAY("$" + Mathf.FloorToInt(feeQuota.LeftToReachQuota - allDebtsPrice).ToString("N0", LocalizationAPI.CC));
				}
				return CareerManagerLocalization.PAY_TO_CLEAR_ALL_FEES("$" + Mathf.FloorToInt(feeQuota.LeftToReachQuota).ToString("N0", LocalizationAPI.CC));
			}
			return CareerManagerLocalization.FEES;
		}

		public string GetCurrentSelection()
		{
			if (selector == null || feeEntries == null || selector.Current < 0 || selector.Current >= feeEntries.Count)
			{
				return CareerManagerLocalization.INVALID_SELECTION;
			}
			return feeEntries[selector.Current].id.text;
		}

		public void SubscribeToSelectionChange(IntIterator.IntIteratorCurrentUpdatedDelegate callback)
		{
			selector.CurrentUpdated += callback;
		}

		public void UnsubscribeToSelectionChange(IntIterator.IntIteratorCurrentUpdatedDelegate callback)
		{
			selector.CurrentUpdated -= callback;
		}
	}
}
