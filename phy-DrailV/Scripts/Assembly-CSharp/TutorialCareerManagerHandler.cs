using DV.ServicePenalty;
using DV.ServicePenalty.UI;
using DV.Utils;
using UnityEngine;

public class TutorialCareerManagerHandler
{
	public delegate void TutorialCareerManagerScreenUpdatedDelegate(IDisplayScreen screen, string selection, int index, bool validPayScreen);

	private CareerManagerMainScreen mainScreen;

	private CareerManagerFeesScreen feesSelectionScreen;

	public IDisplayScreen main;

	public IDisplayScreen fees;

	public IDisplayScreen info;

	private string debtID;

	public DisplayScreenSwitcher ScreenSwitcher { get; private set; }

	public bool Initialized { get; private set; }

	public string CurrentSelection { get; private set; } = string.Empty;

	public int CurrentIndex { get; private set; }

	public bool IsValidPayScreen { get; private set; }

	public event TutorialCareerManagerScreenUpdatedDelegate TutorialCareerManagerScreenUpdated;

	public TutorialCareerManagerHandler(GameObject careerManagerGO, string debtID)
	{
		SingletonBehaviour<CareerManagerDebtController>.Instance.RefreshExistingDebtsState();
		ScreenSwitcher = careerManagerGO.GetComponentInChildren<DisplayScreenSwitcher>(includeInactive: true);
		mainScreen = careerManagerGO.GetComponentInChildren<CareerManagerMainScreen>(includeInactive: true);
		main = mainScreen;
		feesSelectionScreen = careerManagerGO.GetComponentInChildren<CareerManagerFeesScreen>(includeInactive: true);
		fees = feesSelectionScreen;
		info = careerManagerGO.GetComponentInChildren<CareerManagerInfoScreen>(includeInactive: true);
		this.debtID = debtID;
		if (ScreenSwitcher == null || main == null || fees == null)
		{
			Debug.LogError("Missing references. TutorialCareerManagerHandler will not work properly.");
			return;
		}
		SetupListeners(on: true);
		OnScreenSwitched(ScreenSwitcher.CurrentScreen);
		Initialized = true;
	}

	public void SetupListeners(bool on)
	{
		if (on)
		{
			ScreenSwitcher.DisplayScreenUpdated += OnScreenSwitched;
			mainScreen.SubscribeToSelectionChange(MainScreenSelectionUpdated);
			feesSelectionScreen.SubscribeToSelectionChange(FeesScreenSelectionUpdated);
		}
		else
		{
			ScreenSwitcher.DisplayScreenUpdated -= OnScreenSwitched;
			mainScreen.UnsubscribeToSelectionChange(MainScreenSelectionUpdated);
			feesSelectionScreen.UnsubscribeToSelectionChange(FeesScreenSelectionUpdated);
		}
	}

	public void ToggleAllInputs(bool on)
	{
		ScreenSwitcher.ToggleAllInputs(on);
	}

	public void BlockInputs(params InputAction[] inputsToBlock)
	{
		ScreenSwitcher.BlockInputs(inputsToBlock);
	}

	public void UnblockInputs(params InputAction[] inputsToUnblock)
	{
		ScreenSwitcher.UnblockInputs(inputsToUnblock);
	}

	public void ForceUpdate()
	{
		OnScreenSwitched(ScreenSwitcher.CurrentScreen);
	}

	private void MainScreenSelectionUpdated(int selection)
	{
		this.TutorialCareerManagerScreenUpdated?.Invoke(main, mainScreen.GetCurrentSelection(), selection, validPayScreen: false);
	}

	private void FeesScreenSelectionUpdated(int selection)
	{
		this.TutorialCareerManagerScreenUpdated?.Invoke(fees, feesSelectionScreen.GetCurrentSelection(), selection, validPayScreen: false);
	}

	private void OnScreenSwitched(IDisplayScreen screen)
	{
		IsValidPayScreen = false;
		string selection;
		if (screen == main)
		{
			selection = mainScreen.GetCurrentSelection();
			CurrentIndex = mainScreen.CurrentSelection;
		}
		else if (screen == fees)
		{
			selection = feesSelectionScreen.GetCurrentSelection();
			CurrentIndex = feesSelectionScreen.CurrentSelection;
		}
		else
		{
			selection = string.Empty;
			CurrentIndex = -1;
			CareerManagerFeePayingScreen careerManagerFeePayingScreen = screen as CareerManagerFeePayingScreen;
			IsValidPayScreen = careerManagerFeePayingScreen != null && careerManagerFeePayingScreen.DebtToPay != null && careerManagerFeePayingScreen.DebtToPay.ID == debtID;
		}
		this.TutorialCareerManagerScreenUpdated?.Invoke(screen, selection, CurrentIndex, IsValidPayScreen);
	}
}
