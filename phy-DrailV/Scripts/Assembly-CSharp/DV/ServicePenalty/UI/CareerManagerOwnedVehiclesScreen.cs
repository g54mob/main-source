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
	public class CareerManagerOwnedVehiclesScreen : ScrollableDisplayScreen
	{
		[Serializable]
		private class VehicleEntry
		{
			public TextMeshPro id;

			public TextMeshPro value;

			public VehicleEntry(TextMeshPro id, TextMeshPro value)
			{
				this.id = id;
				this.value = value;
			}
		}

		private const float STATE_REFRESH_PERIOD = 1f;

		public DisplayScreenSwitcher screenSwitcher;

		public CareerManagerMainScreen mainScreen;

		public CareerManagerInfoScreen infoScreen;

		public PrinterController statePrinter;

		public TextMeshPro titleText;

		public TextMeshPro pressPrintInfo;

		public TextMeshPro paragraphText;

		[SerializeField]
		private List<VehicleEntry> vehicleEntries;

		private Coroutine periodicRefreshCoro;

		protected override int TotalSlotCount => SingletonBehaviour<OwnedCarsStateController>.Instance.NumberOfCarStates;

		private void Awake()
		{
			if (screenSwitcher == null)
			{
				Debug.LogError("screenSwitcher reference isn't set! Screen can't function!");
				return;
			}
			if (statePrinter == null)
			{
				Debug.LogError("statePrinter reference isn't set! Screen can't function!");
				return;
			}
			activeSlotCount = vehicleEntries.Count;
			if (activeSlotCount == 0)
			{
				Debug.LogError("vehicleEntries count is 0. Screen can't function properly!");
			}
			selector = new IntIterator(0, 0, isWrappable: true);
		}

		private void SetupListeners(bool set)
		{
			if (set)
			{
				SingletonBehaviour<OwnedCarsStateController>.Instance.EntriesUpdated += OnCarListUpdated;
			}
			else
			{
				SingletonBehaviour<OwnedCarsStateController>.Instance.EntriesUpdated -= OnCarListUpdated;
			}
		}

		public override void Activate(IDisplayScreen previousScreen)
		{
			SingletonBehaviour<OwnedCarsStateController>.Instance.RefreshOwnedCarsStatesData();
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
			titleText.text = CareerManagerLocalization.OWNED_VEHICLES;
			SetupListeners(set: true);
			if (periodicRefreshCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(periodicRefreshCoro);
			}
			periodicRefreshCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(PeriodicRefresh());
			pressPrintInfo.text = ((SingletonBehaviour<OwnedCarsStateController>.Instance.NumberOfCarStates > 0) ? CareerManagerLocalization.PRESS_PRINT_FOR_DETAILS : string.Empty);
		}

		public override void Disable()
		{
			TextMeshPro textMeshPro = pressPrintInfo;
			TextMeshPro textMeshPro2 = titleText;
			string text = (paragraphText.text = string.Empty);
			string text2 = (textMeshPro2.text = text);
			textMeshPro.text = text2;
			ClearTextsFromIndex(0);
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(set: false);
			}
			if (periodicRefreshCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(periodicRefreshCoro);
				periodicRefreshCoro = null;
			}
			base.Disable();
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
				infoScreen.SetInfoData(this, CareerManagerInfoScreen.Preset.OwnedVehicleManualService);
				screenSwitcher.SetActiveDisplay(infoScreen);
				break;
			case InputAction.PrintInfo:
			{
				if (statePrinter.IsOnCooldown)
				{
					statePrinter.PlayErrorSound();
					break;
				}
				DisplayableDebt ithSortedVehicleState = SingletonBehaviour<OwnedCarsStateController>.Instance.GetIthSortedVehicleState(base.IndexOfFirstDisplayedEntry + selector.Current);
				Vector3 position = statePrinter.spawnAnchor.position;
				Quaternion rotation = statePrinter.spawnAnchor.rotation;
				BookletCreator.CreateDebtBooklet(ithSortedVehicleState, position, rotation, WorldMover.OriginShiftParent);
				statePrinter.Print();
				break;
			}
			}
		}

		private void OnCarListUpdated()
		{
			SetSelectorWithinBounds();
			SetIndexOfFirstDisplayWithinBounds();
			PopulateTextsFromIndex(base.IndexOfFirstDisplayedEntry);
		}

		private IEnumerator PeriodicRefresh()
		{
			while (true)
			{
				yield return WaitFor.Seconds(1f);
				SingletonBehaviour<OwnedCarsStateController>.Instance.RefreshOwnedCarsStatesData();
				OnCarListUpdated();
				bool flag = SingletonBehaviour<OwnedCarsStateController>.Instance.NumberOfCarStates > 0;
				if (!string.IsNullOrEmpty(pressPrintInfo.text) != flag)
				{
					pressPrintInfo.text = (flag ? CareerManagerLocalization.PRESS_PRINT_FOR_DETAILS : string.Empty);
				}
			}
		}

		public override void PopulateTextsFromIndex(int startingIndex)
		{
			base.PopulateTextsFromIndex(startingIndex);
			int num = Mathf.Min(SingletonBehaviour<OwnedCarsStateController>.Instance.NumberOfCarStates - startingIndex, activeSlotCount);
			for (int i = 0; i < num; i++)
			{
				DisplayableDebt ithSortedVehicleState = SingletonBehaviour<OwnedCarsStateController>.Instance.GetIthSortedVehicleState(startingIndex + i);
				string text = "";
				if (ithSortedVehicleState is ExistingOwnedCarDebt existingOwnedCarDebt)
				{
					Vector3 point = existingOwnedCarDebt.car.transform.AbsolutePosition();
					text = ((SingletonBehaviour<LevelInfo>.Instance != null) ? ("[" + SingletonBehaviour<LevelInfo>.Instance.Get8x8PositionCoords(point) + "]") : "N/A");
				}
				vehicleEntries[i].id.text = ithSortedVehicleState.ID + " " + text;
				vehicleEntries[i].value.text = "$" + ithSortedVehicleState.GetTotalPrice().ToString("N2", LocalizationAPI.CC);
			}
			paragraphText.text = ((num <= 0) ? CareerManagerLocalization.NO_OWNED_VEHICLES : "");
			ClearTextsFromIndex(num);
		}

		private void ClearTextsFromIndex(int startClearIndex)
		{
			for (int i = startClearIndex; i < activeSlotCount; i++)
			{
				vehicleEntries[i].id.text = string.Empty;
				vehicleEntries[i].value.text = string.Empty;
			}
		}

		public override void HighlightSelected(int newHighlight, int prevHighlighted = -1)
		{
			if (prevHighlighted != -1 && prevHighlighted != newHighlight)
			{
				vehicleEntries[prevHighlighted].id.color = screenSwitcher.REGULAR_COLOR;
				vehicleEntries[prevHighlighted].value.color = screenSwitcher.REGULAR_COLOR;
			}
			if (newHighlight != -1)
			{
				vehicleEntries[newHighlight].id.color = screenSwitcher.HIGHLIGHTED_COLOR;
				vehicleEntries[newHighlight].value.color = screenSwitcher.HIGHLIGHTED_COLOR;
			}
		}

		private void SwitchToMainScreen()
		{
			screenSwitcher.SetActiveDisplay(mainScreen);
		}
	}
}
