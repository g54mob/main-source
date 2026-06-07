using DV.UserManagement;
using DV.Utils;
using TMPro;
using UnityEngine;

namespace DV.ServicePenalty.UI
{
	public class CareerManagerMainScreen : ScrollableDisplayScreen
	{
		public DisplayScreenSwitcher screenSwitcher;

		public CareerManagerFeesScreen feesScreen;

		public CareerManagerLicensesScreen licensesScreen;

		public CareerManagerOwnedVehiclesScreen ownedVehiclesScreen;

		public CareerManagerStatsScreen statsScreen;

		public CareerManagerInfoScreen infoScreen;

		public TextMeshPro title;

		public TextMeshPro fees;

		public TextMeshPro licenses;

		public TextMeshPro ownedVehicles;

		public TextMeshPro stats;

		private TextMeshPro[] selectableText;

		protected override int TotalSlotCount => selectableText.Length;

		private void Awake()
		{
			if (screenSwitcher == null)
			{
				Debug.LogError("screenSwitcher reference isn't set! Screen can't function!");
				return;
			}
			activeSlotCount = 4;
			selector = new IntIterator(0, 4, isWrappable: true);
			selectableText = new TextMeshPro[4] { fees, licenses, ownedVehicles, stats };
		}

		public override void Activate(IDisplayScreen _)
		{
			title.text = CareerManagerLocalization.PLEASE_SELECT;
			fees.text = CareerManagerLocalization.FEES;
			licenses.text = CareerManagerLocalization.LICENSES;
			ownedVehicles.text = CareerManagerLocalization.OWNED_VEHICLES;
			stats.text = CareerManagerLocalization.STATS;
			selector.Reset();
			HighlightSelected(selector.Current);
		}

		public override void Disable()
		{
			TextMeshPro textMeshPro = title;
			TextMeshPro textMeshPro2 = fees;
			TextMeshPro textMeshPro3 = licenses;
			TextMeshPro textMeshPro4 = stats;
			string text = (ownedVehicles.text = string.Empty);
			string text2 = (textMeshPro4.text = text);
			string text4 = (textMeshPro3.text = text2);
			string text6 = (textMeshPro2.text = text4);
			textMeshPro.text = text6;
			HighlightSelected(-1, selector.Current);
			base.Disable();
		}

		public override void HandleInputAction(InputAction input)
		{
			switch (input)
			{
			case InputAction.Up:
				ScrollUp();
				break;
			case InputAction.Down:
				ScrollDown();
				break;
			case InputAction.Confirm:
				Debug.Log("Switched to screen " + selectableText[selector.Current].text);
				switch (selector.Current)
				{
				case 0:
					screenSwitcher.SetActiveDisplay(feesScreen);
					break;
				case 1:
					if (SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.GameMode == "Career")
					{
						screenSwitcher.SetActiveDisplay(licensesScreen);
						break;
					}
					infoScreen.SetInfoData(this, CareerManagerInfoScreen.Preset.LicensesUnavailableInSandbox);
					screenSwitcher.SetActiveDisplay(infoScreen);
					break;
				case 2:
					if (SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.GameMode == "Career")
					{
						screenSwitcher.SetActiveDisplay(ownedVehiclesScreen);
						break;
					}
					infoScreen.SetInfoData(this, CareerManagerInfoScreen.Preset.OwnedVehiclesUnavailableInSandbox);
					screenSwitcher.SetActiveDisplay(infoScreen);
					break;
				case 3:
					screenSwitcher.SetActiveDisplay(statsScreen);
					break;
				default:
					Debug.LogError(string.Format("Unhandled case in {0}: {1}", "CareerManagerMainScreen", selector.Current));
					break;
				}
				break;
			case InputAction.Cancel:
				break;
			}
		}

		public override void HighlightSelected(int newHighlight, int prevHighlighted = -1)
		{
			if (prevHighlighted != -1 && prevHighlighted != newHighlight)
			{
				selectableText[prevHighlighted].color = screenSwitcher.REGULAR_COLOR;
			}
			if (newHighlight != -1)
			{
				selectableText[newHighlight].color = screenSwitcher.HIGHLIGHTED_COLOR;
			}
		}

		public string GetCurrentSelection()
		{
			if (selector == null)
			{
				return CareerManagerLocalization.INVALID_SELECTION;
			}
			switch (selector.Current)
			{
			case 0:
				return CareerManagerLocalization.FEES;
			case 1:
				return CareerManagerLocalization.LICENSES;
			case 2:
				return CareerManagerLocalization.OWNED_VEHICLES;
			case 3:
				return CareerManagerLocalization.STATS;
			default:
				return CareerManagerLocalization.INVALID_SELECTION;
			}
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
