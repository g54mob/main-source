using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageBoxView : BaseGUIView
{
	public const string ConfirmButtonEvent = "MessageBoxView.ConfirmButtonEvent";

	public const string CancelButtonEvent = "MessageBoxView.CancelButtonEvent";

	private TextMeshProUGUI headerText;

	private TextMeshProUGUI infoText;

	private Button confirmButton;

	private Button cancelButton;

	private Button closeButton;

	private GameObject loadingIcon;

	private GameObject warningIcon;

	public override void Initialize()
	{
		headerText = mainPanel.transform.FindComponent<TextMeshProUGUI>("HeaderText", isRecursively: true);
		infoText = mainPanel.transform.FindComponent<TextMeshProUGUI>("InfoText", isRecursively: true);
		confirmButton = mainPanel.transform.FindComponent<Button>("ConfirmButton", isRecursively: true);
		cancelButton = mainPanel.transform.FindComponent<Button>("CancelButton", isRecursively: true);
		closeButton = mainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		loadingIcon = mainPanel.transform.FindChildRecursively("LoadingIcon").gameObject;
		warningIcon = mainPanel.transform.FindChildRecursively("WarningIcon").gameObject;
		confirmButton.onClick.AddListener(delegate
		{
			NotifyChange("MessageBoxView.ConfirmButtonEvent");
		});
		cancelButton.onClick.AddListener(delegate
		{
			NotifyChange("MessageBoxView.CancelButtonEvent");
		});
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("MessageBoxView.CancelButtonEvent");
		});
	}

	public void SetHeaderText(string text)
	{
		headerText.text = text;
	}

	public void SetInfoText(string text)
	{
		infoText.text = text;
	}

	public void SetConfirmButtonVisibility(bool isVisible)
	{
		confirmButton.gameObject.SetActive(isVisible);
	}

	public void SetCancelButtonVisibility(bool isVisible)
	{
		if (cancelButton.gameObject.activeSelf != isVisible)
		{
			cancelButton.gameObject.SetActive(isVisible);
		}
		if (closeButton.gameObject.activeSelf != isVisible)
		{
			closeButton.gameObject.SetActive(isVisible);
		}
	}

	public void SetIconType(bool isWarningIcon)
	{
		loadingIcon.SetActive(!isWarningIcon);
		warningIcon.SetActive(isWarningIcon);
	}
}
