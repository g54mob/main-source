using TMPro;
using UnityEngine.Events;

public class TextEntryPanel : MenuPanel
{
	public TextMeshProUGUI headerText;

	public TMP_InputField inputField;

	public LabelButton confirmButton;

	public LabelButton cancelButton;

	public UnityAction<string> confirmDelegate;

	public UnityAction cancelDelegate;

	private string confirmKey;

	public override void Show()
	{
		base.Show();
		MenuManager.SetFocusOnInputField(inputField);
	}

	public override void Initialize()
	{
		base.Initialize();
		confirmButton.AddPointerClickTrigger(OnConfirmPressed);
		confirmButton.buttonState = CustomButtonState.Default;
		cancelButton.AddPointerClickTrigger(OnCancelPressed);
		cancelButton.buttonState = CustomButtonState.Default;
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		headerText.text = "PromptEnterTownName".Localized();
		confirmButton.label.text = confirmKey.Localized();
		cancelButton.label.text = "Cancel".Localized();
	}

	public void ShowWithDefaultText(string s, string confirmLocalizationKey, UnityAction<string> confirm, UnityAction cancel = null)
	{
		confirmKey = confirmLocalizationKey;
		inputField.text = s;
		inputField.characterLimit = 50;
		confirmDelegate = confirm;
		cancelDelegate = cancel;
		ReloadLabels();
		Show();
	}

	private void OnCancelPressed()
	{
		Hide();
		cancelDelegate?.Invoke();
	}

	private void OnConfirmPressed()
	{
		Hide();
		confirmDelegate?.Invoke(inputField.text);
	}
}
