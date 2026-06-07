using System;
using TMPro;
using UnityEngine;

namespace DV.ServicePenalty.UI
{
	public class CareerManagerInfoScreen : DisplayScreen
	{
		public enum Preset : ushort
		{
			None = 0,
			MissingLicense = 1,
			Fees = 2,
			FeesCleared = 3,
			OwnedVehicleManualService = 4,
			LicensesUnavailableInSandbox = 5,
			OwnedVehiclesUnavailableInSandbox = 6
		}

		public DisplayScreenSwitcher screenSwitcher;

		public CareerManagerMainScreen mainScreen;

		public TextMeshPro title;

		public TextMeshPro paragraph;

		public TextMeshPro infoLine1;

		public TextMeshPro infoLine2;

		public TextMeshPro infoLine3;

		public TextMeshPro infoLine4;

		private string titleStr;

		private string paragraphStr;

		private string infoLine1Str;

		private string infoLine2Str;

		private string infoLine3Str;

		private string infoLine4Str;

		private Action actionToTakeOnConfirm;

		private IDisplayScreen returnScreen;

		private void Awake()
		{
			if (screenSwitcher == null)
			{
				Debug.LogError("screenSwitcher reference isn't set! Screen can't function!");
			}
		}

		public override void Activate(IDisplayScreen _)
		{
			title.text = titleStr;
			paragraph.text = paragraphStr;
			infoLine1.text = infoLine1Str;
			infoLine2.text = infoLine2Str;
			infoLine3.text = infoLine3Str;
			infoLine4.text = infoLine4Str;
		}

		public override void Disable()
		{
			TextMeshPro textMeshPro = title;
			TextMeshPro textMeshPro2 = paragraph;
			TextMeshPro textMeshPro3 = infoLine1;
			TextMeshPro textMeshPro4 = infoLine2;
			TextMeshPro textMeshPro5 = infoLine3;
			string text = (infoLine4.text = string.Empty);
			string text2 = (textMeshPro5.text = text);
			string text4 = (textMeshPro4.text = text2);
			string text6 = (textMeshPro3.text = text4);
			string text8 = (textMeshPro2.text = text6);
			textMeshPro.text = text8;
			SetInfoData(null);
		}

		public void SetInfoData(IDisplayScreen returnScreen, Preset preset, string data = null)
		{
			switch (preset)
			{
			case Preset.None:
				SetInfoData(returnScreen);
				break;
			case Preset.MissingLicense:
				SetInfoData(returnScreen, CareerManagerLocalization.FEES, CareerManagerLocalization.NEED_TO_OWN(data));
				break;
			case Preset.Fees:
				SetInfoData(returnScreen, CareerManagerLocalization.FEES, CareerManagerLocalization.FEES_NOT_CLEARED_LINE1 + "\n\n" + CareerManagerLocalization.FEES_NOT_CLEARED_LINE2 + "\n");
				break;
			case Preset.FeesCleared:
				SetInfoData(returnScreen, CareerManagerLocalization.INSURANCE_COPAY_MET, CareerManagerLocalization.INSURANCE_CLEARED_ALL_FEES);
				break;
			case Preset.OwnedVehicleManualService:
				SetInfoData(returnScreen, CareerManagerLocalization.OWNED_VEHICLES, CareerManagerLocalization.OWNED_VEHICLE_MANUAL_SERVICE);
				break;
			case Preset.LicensesUnavailableInSandbox:
				SetInfoData(returnScreen, CareerManagerLocalization.LICENSES, CareerManagerLocalization.UNAVAILABLE_IN_SANDBOX);
				break;
			case Preset.OwnedVehiclesUnavailableInSandbox:
				SetInfoData(returnScreen, CareerManagerLocalization.OWNED_VEHICLES, CareerManagerLocalization.UNAVAILABLE_IN_SANDBOX);
				break;
			}
		}

		private void SetInfoData(IDisplayScreen returnScreen, string title = "", string paragraph = "", string info1 = "", string info2 = "", string info3 = "", string info4 = "", Action customAction = null)
		{
			this.returnScreen = returnScreen;
			titleStr = title;
			paragraphStr = paragraph;
			infoLine1Str = info1;
			infoLine2Str = info2;
			infoLine3Str = info3;
			infoLine4Str = info4;
			actionToTakeOnConfirm = customAction;
		}

		public override void HandleInputAction(InputAction input)
		{
			if (input - 1 <= InputAction.Confirm)
			{
				actionToTakeOnConfirm?.Invoke();
				SwitchToPreviousScreen();
			}
		}

		private void SwitchToPreviousScreen()
		{
			if (returnScreen != null)
			{
				screenSwitcher.SetActiveDisplay(returnScreen);
				return;
			}
			Debug.LogError("returnScreen wasn't set with SetInfoData before activating this screen! Invalid activation of a screen, switching to main screen.");
			screenSwitcher.SetActiveDisplay(mainScreen);
		}
	}
}
