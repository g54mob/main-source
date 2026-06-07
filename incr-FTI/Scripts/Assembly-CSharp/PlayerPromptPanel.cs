using TMPro;
using UnityEngine.Events;

public class PlayerPromptPanel : MenuPanel
{
	public TextMeshProUGUI messageLabel;

	public LabelButton leftButton;

	public LabelButton rightButton;

	private UnityAction confirmDelegate;

	private UnityAction onHideDelegate;

	protected override void Awake()
	{
		base.Awake();
		leftButton.AddPointerClickTrigger(OnLeftButtonPressed);
		rightButton.AddPointerClickTrigger(OnRightButtonPressed);
	}

	public override void Show()
	{
		base.Show();
		MenuPanel.m.welcomeCanvasGroup.blocksRaycasts = false;
		MenuPanel.m.mainCanvasGroup.blocksRaycasts = false;
	}

	public override void Hide()
	{
		base.Hide();
		MenuPanel.m.welcomeCanvasGroup.blocksRaycasts = true;
		MenuPanel.m.mainCanvasGroup.blocksRaycasts = true;
		onHideDelegate?.Invoke();
	}

	private void OnLeftButtonPressed()
	{
		Hide();
	}

	private void OnRightButtonPressed()
	{
		confirmDelegate?.Invoke();
		Hide();
	}

	public void ShowResetTownInvalid()
	{
		messageLabel.text = "ResetTownMessageInvalid".Localized() + "\n\n" + string.Format("ResetTownRequirement".Localized(), 0);
		leftButton.gameObject.SetActive(value: false);
		rightButton.gameObject.SetActive(value: true);
		rightButton.buttonState = CustomButtonState.Default;
		rightButton.label.text = "OK".Localized();
		Show();
		confirmDelegate = null;
		onHideDelegate = null;
	}

	public void ShowConfirmResetTown(UnityAction del)
	{
		messageLabel.text = "ResetTownMessageConfirm".Localized() + "\n\n" + "ResetTownMessagePreserve".Localized() + "\n\n" + string.Format("ResetTownMessageReward".Localized(), TextDisplay.LocalizedNumber(MenuPanel.gm.activeTown.pendingPrestigeCoins));
		confirmDelegate = del;
		leftButton.gameObject.SetActive(value: true);
		rightButton.gameObject.SetActive(value: true);
		leftButton.label.text = "Cancel".Localized();
		rightButton.label.text = "Reset".Localized();
		leftButton.buttonState = CustomButtonState.Default;
		rightButton.buttonState = CustomButtonState.Default;
		Show();
		onHideDelegate = null;
	}

	public void ShowConfirmDelete(UnityAction del, string fileName, UnityAction hideDel)
	{
		messageLabel.text = string.Format("MessageConfirmDelete".Localized(), fileName);
		confirmDelegate = del;
		leftButton.gameObject.SetActive(value: true);
		rightButton.gameObject.SetActive(value: true);
		leftButton.label.text = "Cancel".Localized();
		rightButton.label.text = "Delete".Localized();
		leftButton.buttonState = CustomButtonState.Default;
		rightButton.buttonState = CustomButtonState.Invalid;
		Show();
		onHideDelegate = hideDel;
	}

	public void ShowConfirmOverwrite(UnityAction confirmAction, UnityAction hideAction)
	{
		messageLabel.text = string.Format("MessageConfirmOverwrite".Localized());
		confirmDelegate = confirmAction;
		onHideDelegate = hideAction;
		leftButton.gameObject.SetActive(value: true);
		rightButton.gameObject.SetActive(value: true);
		leftButton.label.text = "Cancel".Localized();
		rightButton.label.text = "Overwrite".Localized();
		leftButton.buttonState = CustomButtonState.Background;
		rightButton.buttonState = CustomButtonState.Default;
		Show();
	}
}
