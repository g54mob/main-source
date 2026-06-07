using System;
using TMPro;
using UnityEngine;

namespace DV.ServicePenalty.UI
{
	public class CareerManagerCustomActionChoiceScreen : DisplayScreen
	{
		public DisplayScreenSwitcher screenSwitcher;

		public CareerManagerMainScreen mainScreen;

		public TextMeshPro title;

		public TextMeshPro infoLine;

		private string titleStr;

		private string infoLineStr;

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
			infoLine.text = infoLineStr;
		}

		public override void Disable()
		{
			TextMeshPro textMeshPro = title;
			string text = (infoLine.text = string.Empty);
			textMeshPro.text = text;
			SetCustomActionData(null, null);
		}

		public void SetCustomActionData(Action actionToTakeOnConfirm, IDisplayScreen returnScreen, string title = "", string info = "")
		{
			this.returnScreen = returnScreen;
			this.actionToTakeOnConfirm = actionToTakeOnConfirm;
			titleStr = title;
			infoLineStr = info;
		}

		public void OverrideReturnScreen(IDisplayScreen returnScreen)
		{
			this.returnScreen = returnScreen;
		}

		public override void HandleInputAction(InputAction input)
		{
			switch (input)
			{
			case InputAction.Cancel:
				SwitchToPreviousScreen();
				break;
			case InputAction.Confirm:
				actionToTakeOnConfirm();
				SwitchToPreviousScreen();
				break;
			}
		}

		private void SwitchToPreviousScreen()
		{
			if (returnScreen != null)
			{
				screenSwitcher.SetActiveDisplay(returnScreen);
				return;
			}
			Debug.LogError("returnScreen wasn't set with SetCustomActionData before activating this screen! Invalid activation of a screen, switching to main screen.");
			screenSwitcher.SetActiveDisplay(mainScreen);
		}
	}
}
