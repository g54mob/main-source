using I2.Loc;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ComputerUI : MonoBehaviour
{
	public GameObject computerPanel;

	[Header("Time Display")]
	public TextMeshProUGUI timeText;

	[Header("Factory Identity")]
	public FactoryIdentityPanel factoryIdentityPanel;

	[Header("Tutorial")]
	public GameObject namingWindow;

	[Header("Tutorial Masks - Property")]
	public GameObject maskOpenPropertiesApp;

	public GameObject maskSelectProperty;

	public GameObject maskOpenOffer;

	public GameObject maskSendPrice;

	public GameObject maskSendOffer;

	[Header("Tutorial Masks - Mining (BuyMachine)")]
	public GameObject maskOpenMarketplaceApp;

	public GameObject maskSelectFirstMachine;

	public GameObject maskPurchaseMachine;

	[Header("Tutorial Masks - StockSell")]
	public GameObject maskOpenStockSellApp;

	public GameObject maskSelectProducedItem;

	public GameObject maskSelectOffer;

	public GameObject maskSellToOfferTarget;

	[Header("Tutorial Masks - Contract")]
	public GameObject maskOpenContractApp;

	[Header("Contract UI")]
	public ComputerContractUI computerContractUI;

	[Header("Vehicle Rescue")]
	public VehicleRescuePanel vehicleRescuePanel;

	[Header("Events")]
	public UnityEvent onEndDayClosed;

	private bool isSubscribed;

	private void Start()
	{
		SubscribeToTimeEvent();
	}

	private void OnEnable()
	{
		SubscribeToTimeEvent();
	}

	private void OnDisable()
	{
		UnsubscribeFromTimeEvent();
	}

	private void SubscribeToTimeEvent()
	{
		if (!isSubscribed && !(GameManager.Instance == null))
		{
			GameManager.Instance.OnMinuteChanged += OnTimeChanged;
			isSubscribed = true;
		}
	}

	private void UnsubscribeFromTimeEvent()
	{
		if (isSubscribed && !(GameManager.Instance == null))
		{
			GameManager.Instance.OnMinuteChanged -= OnTimeChanged;
			isSubscribed = false;
		}
	}

	private void OnTimeChanged(string timeString)
	{
		if (!(computerPanel == null) && computerPanel.activeInHierarchy && !(timeText == null))
		{
			timeText.text = timeString;
		}
	}

	public void OnComputerPanelOpened()
	{
		if (timeText != null && GameManager.Instance != null)
		{
			timeText.text = GameManager.Instance.CurrentTimeString;
		}
		computerPanel.SetActive(value: true);
		OpenNamingWindowForTutorial();
	}

	public void OnComputerPanelClosed()
	{
		computerPanel.SetActive(value: false);
		CloseAllMasks();
	}

	public void OpenNamingWindowForTutorial()
	{
		if (!(TutorialManager.Instance == null) && TutorialManager.Instance.GetActiveConfig() == TutorialConfigType.Factory && TutorialManager.Instance.CurrentStep == TutorialStepType.CompanySettings && namingWindow != null)
		{
			namingWindow.SetActive(value: true);
			factoryIdentityPanel.OnRandomNameClicked();
			factoryIdentityPanel.OnRandomLogoClicked();
		}
	}

	public void OnNamingWindowClosed()
	{
		TutorialManager.Instance?.TryCompleteSubStep(TutorialConfigType.Factory, TutorialStepType.CompanySettings, TutorialSubStepType.EnterCompanyName);
	}

	public void OpenFactoryIdentityPanel()
	{
		if (factoryIdentityPanel != null)
		{
			factoryIdentityPanel.Open();
		}
	}

	public void CloseFactoryIdentityPanel()
	{
		if (factoryIdentityPanel != null)
		{
			factoryIdentityPanel.Close();
		}
	}

	[ContextMenu("Test: Open Factory Identity Panel")]
	private void TestOpenFactoryIdentityPanel()
	{
		if (factoryIdentityPanel != null)
		{
			factoryIdentityPanel.gameObject.SetActive(value: true);
			factoryIdentityPanel.Open();
		}
	}

	public void ShowDemoNotAvailableNotification()
	{
		if (NotificationManager.Instance != null)
		{
			NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("NOT AVAILABLE IN DEMO"), isComputer: true);
		}
	}

	public void ShowContractCompletedUI(ContractCompletionResult result)
	{
		if (computerContractUI != null)
		{
			computerContractUI.ShowContractCompletedUI(result);
		}
	}

	public void OpenDayEndPanel()
	{
		if (!NetworkServer.active)
		{
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
			}
		}
		else if (DayEndManager.Instance != null)
		{
			onEndDayClosed.Invoke();
			DayEndManager.Instance.ShowDaySummary();
		}
	}

	public void UpdateMaskForCurrentSubStep()
	{
		if (!NetworkServer.active)
		{
			return;
		}
		CloseAllMasks();
		if (TutorialManager.Instance == null)
		{
			return;
		}
		if (TutorialManager.Instance.GetActiveConfig() == TutorialConfigType.Property && TutorialManager.Instance.CurrentStep == TutorialStepType.BuyProperty)
		{
			switch (TutorialManager.Instance.CurrentSubStep)
			{
			case TutorialSubStepType.OpenPropertiesApp:
				if (maskOpenPropertiesApp != null)
				{
					maskOpenPropertiesApp.SetActive(value: true);
				}
				break;
			case TutorialSubStepType.SelectProperty:
				if (maskSelectProperty != null)
				{
					maskSelectProperty.SetActive(value: true);
				}
				break;
			case TutorialSubStepType.OpenOffer:
				if (maskOpenOffer != null)
				{
					maskOpenOffer.SetActive(value: true);
				}
				break;
			case TutorialSubStepType.SendPrice:
				if (maskSendPrice != null)
				{
					maskSendPrice.SetActive(value: true);
				}
				break;
			case TutorialSubStepType.SendOffer:
				if (maskSendOffer != null)
				{
					maskSendOffer.SetActive(value: true);
				}
				break;
			}
		}
		else if (TutorialManager.Instance.GetActiveConfig() == TutorialConfigType.Production && TutorialManager.Instance.CurrentStep == TutorialStepType.BuyMachine)
		{
			switch (TutorialManager.Instance.CurrentSubStep)
			{
			case TutorialSubStepType.OpenMarketplaceApp:
				if (maskOpenMarketplaceApp != null)
				{
					maskOpenMarketplaceApp.SetActive(value: true);
				}
				break;
			case TutorialSubStepType.SelectFirstMachine:
				if (maskSelectFirstMachine != null)
				{
					maskSelectFirstMachine.SetActive(value: true);
				}
				break;
			case TutorialSubStepType.PurchaseMachine:
				if (maskPurchaseMachine != null)
				{
					maskPurchaseMachine.SetActive(value: true);
				}
				break;
			case TutorialSubStepType.AddToCart:
				break;
			}
		}
		else if (TutorialManager.Instance.GetActiveConfig() == TutorialConfigType.StockSellAndContract && TutorialManager.Instance.CurrentStep == TutorialStepType.StockSell)
		{
			switch (TutorialManager.Instance.CurrentSubStep)
			{
			case TutorialSubStepType.OpenStockSellApp:
				if (maskOpenStockSellApp != null)
				{
					maskOpenStockSellApp.SetActive(value: true);
				}
				break;
			case TutorialSubStepType.SelectProducedItem:
				if (maskSelectProducedItem != null)
				{
					maskSelectProducedItem.SetActive(value: true);
				}
				break;
			case TutorialSubStepType.SelectOffer:
				if (maskSelectOffer != null)
				{
					maskSelectOffer.SetActive(value: true);
				}
				break;
			case TutorialSubStepType.SellToOfferTarget:
				if (maskSellToOfferTarget != null)
				{
					maskSellToOfferTarget.SetActive(value: true);
				}
				break;
			}
		}
		else if (TutorialManager.Instance.GetActiveConfig() == TutorialConfigType.Day2 && TutorialManager.Instance.CurrentStep == TutorialStepType.Contracts && TutorialManager.Instance.CurrentSubStep == TutorialSubStepType.OpenContractsApp && maskOpenContractApp != null)
		{
			maskOpenContractApp.SetActive(value: true);
		}
	}

	public void CloseAllMasks()
	{
		if (maskOpenPropertiesApp != null && maskOpenPropertiesApp.activeSelf)
		{
			maskOpenPropertiesApp.SetActive(value: false);
		}
		if (maskSelectProperty != null && maskSelectProperty.activeSelf)
		{
			maskSelectProperty.SetActive(value: false);
		}
		if (maskOpenOffer != null && maskOpenOffer.activeSelf)
		{
			maskOpenOffer.SetActive(value: false);
		}
		if (maskSendPrice != null && maskSendPrice.activeSelf)
		{
			maskSendPrice.SetActive(value: false);
		}
		if (maskSendOffer != null && maskSendOffer.activeSelf)
		{
			maskSendOffer.SetActive(value: false);
		}
		if (maskOpenMarketplaceApp != null && maskOpenMarketplaceApp.activeSelf)
		{
			maskOpenMarketplaceApp.SetActive(value: false);
		}
		if (maskSelectFirstMachine != null && maskSelectFirstMachine.activeSelf)
		{
			maskSelectFirstMachine.SetActive(value: false);
		}
		if (maskPurchaseMachine != null && maskPurchaseMachine.activeSelf)
		{
			maskPurchaseMachine.SetActive(value: false);
		}
		if (maskOpenStockSellApp != null && maskOpenStockSellApp.activeSelf)
		{
			maskOpenStockSellApp.SetActive(value: false);
		}
		if (maskSelectProducedItem != null && maskSelectProducedItem.activeSelf)
		{
			maskSelectProducedItem.SetActive(value: false);
		}
		if (maskSelectOffer != null && maskSelectOffer.activeSelf)
		{
			maskSelectOffer.SetActive(value: false);
		}
		if (maskSellToOfferTarget != null && maskSellToOfferTarget.activeSelf)
		{
			maskSellToOfferTarget.SetActive(value: false);
		}
		if (maskOpenContractApp != null && maskOpenContractApp.activeSelf)
		{
			maskOpenContractApp.SetActive(value: false);
		}
	}
}
