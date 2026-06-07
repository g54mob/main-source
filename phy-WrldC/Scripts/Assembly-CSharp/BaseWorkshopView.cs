using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseWorkshopView<T> : BaseGUIView where T : class
{
	public enum ViewMode
	{
		None = 0,
		Upload = 1,
		Upgrade = 2,
		Unsubscribe = 3
	}

	public const string ModelConfiguratedEvent = "BaseWorkshopView.ModelConfiguratedEvent";

	public const string UploadItemEvent = "BaseWorkshopView.UploadItemEvent";

	public const string UpgradeItemEvent = "BaseWorkshopView.UpgradeItemEvent";

	public const string UnsubscribItemEvent = "BaseWorkshopView.UnsubscribItemEvent";

	public const string OpenItemPageEvent = "BaseWorkshopView.OpenItemPageEvent";

	public const string BackButtonEvent = "BaseWorkshopView.BackButtonEvent";

	protected TextMeshProUGUI headerText;

	protected TextMeshProUGUI itemNameText;

	protected TextMeshProUGUI descriptionText;

	protected TextMeshProUGUI noImageText;

	protected Image itemImage;

	protected TextMeshProUGUI warningText;

	protected Button uploadButton;

	protected Button upgradeButton;

	protected Button unsubscribeButton;

	protected Button openButton;

	protected Button backButton;

	protected Button closeButton;

	protected string uploadTextId;

	protected string upgradeTextId;

	protected string unsubscribeTextId;

	protected T selectedModel;

	public override void Initialize()
	{
		headerText = mainPanel.transform.FindComponent<TextMeshProUGUI>("HeaderText", isRecursively: true);
		itemNameText = mainPanel.transform.FindComponent<TextMeshProUGUI>("ItemNameText", isRecursively: true);
		descriptionText = mainPanel.transform.FindComponent<TextMeshProUGUI>("DescriptionText", isRecursively: true);
		noImageText = mainPanel.transform.FindComponent<TextMeshProUGUI>("NoImageText", isRecursively: true);
		itemImage = mainPanel.transform.FindComponent<Image>("ItemImage", isRecursively: true);
		warningText = mainPanel.transform.FindComponent<TextMeshProUGUI>("WarningText", isRecursively: true);
		uploadButton = mainPanel.transform.FindComponent<Button>("UploadButton", isRecursively: true);
		upgradeButton = mainPanel.transform.FindComponent<Button>("UpgradeButton", isRecursively: true);
		unsubscribeButton = mainPanel.transform.FindComponent<Button>("UnsubscribeButton", isRecursively: true);
		openButton = mainPanel.transform.FindComponent<Button>("OpenButton", isRecursively: true);
		backButton = mainPanel.transform.FindComponent<Button>("BackButton", isRecursively: true);
		closeButton = mainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		uploadButton.onClick.AddListener(delegate
		{
			NotifyChange("BaseWorkshopView.UploadItemEvent", selectedModel);
		});
		upgradeButton.onClick.AddListener(delegate
		{
			NotifyChange("BaseWorkshopView.UpgradeItemEvent", selectedModel);
		});
		unsubscribeButton.onClick.AddListener(delegate
		{
			NotifyChange("BaseWorkshopView.UnsubscribItemEvent", selectedModel);
		});
		openButton.onClick.AddListener(delegate
		{
			NotifyChange("BaseWorkshopView.OpenItemPageEvent", selectedModel);
		});
		backButton.onClick.AddListener(delegate
		{
			NotifyChange("BaseWorkshopView.BackButtonEvent");
		});
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("BaseWorkshopView.BackButtonEvent");
		});
	}

	public virtual void SetConfiguration(T model)
	{
		if (model == null)
		{
			itemNameText.SetText("-");
			descriptionText.SetText("");
			itemImage.enabled = false;
			noImageText.gameObject.SetActive(value: false);
			uploadButton.interactable = false;
			upgradeButton.interactable = false;
			unsubscribeButton.interactable = false;
		}
		else
		{
			uploadButton.interactable = true;
			upgradeButton.interactable = true;
			unsubscribeButton.interactable = true;
		}
		warningText.gameObject.SetActive(value: false);
		selectedModel = model;
	}

	public void SetWarningText(string text, Color color)
	{
		warningText.gameObject.SetActive(value: true);
		warningText.SetText(text);
		warningText.color = color;
	}

	public void SetUploadUpgradeButtonInteractivity(bool isInteractable)
	{
		uploadButton.interactable = isInteractable;
		upgradeButton.interactable = isInteractable;
	}

	public void SetUnsubscribeButtonInteractivity(bool isInteractable)
	{
		unsubscribeButton.interactable = isInteractable;
	}

	public void SetOpenButtonVisibility(bool isVisible)
	{
		if (openButton.gameObject.activeSelf != isVisible)
		{
			openButton.gameObject.SetActive(isVisible);
		}
	}

	public void SetViewMode(ViewMode viewMode)
	{
		switch (viewMode)
		{
		case ViewMode.Upload:
		{
			string text = LanguagesManager.Instance.GetText(uploadTextId);
			headerText.SetText(text);
			uploadButton.gameObject.SetActive(value: true);
			upgradeButton.gameObject.SetActive(value: false);
			unsubscribeButton.gameObject.SetActive(value: false);
			openButton.gameObject.SetActive(value: false);
			break;
		}
		case ViewMode.Upgrade:
		{
			string text = LanguagesManager.Instance.GetText(upgradeTextId);
			headerText.SetText(text);
			uploadButton.gameObject.SetActive(value: false);
			upgradeButton.gameObject.SetActive(value: true);
			unsubscribeButton.gameObject.SetActive(value: false);
			openButton.gameObject.SetActive(value: true);
			break;
		}
		case ViewMode.Unsubscribe:
		{
			string text = LanguagesManager.Instance.GetText(unsubscribeTextId);
			headerText.SetText(text);
			uploadButton.gameObject.SetActive(value: false);
			upgradeButton.gameObject.SetActive(value: false);
			unsubscribeButton.gameObject.SetActive(value: true);
			openButton.gameObject.SetActive(value: true);
			break;
		}
		case ViewMode.None:
			headerText.SetText("-");
			uploadButton.gameObject.SetActive(value: false);
			upgradeButton.gameObject.SetActive(value: false);
			unsubscribeButton.gameObject.SetActive(value: false);
			openButton.gameObject.SetActive(value: false);
			break;
		}
	}
}
