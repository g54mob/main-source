using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerContractUI : MonoBehaviour
{
	public enum ContractViewTab
	{
		ContractList = 0,
		ActiveContracts = 1
	}

	[Header("References")]
	[Tooltip("ComputerContractManager referansı (otomatik bulunabilir)")]
	[SerializeField]
	private ComputerContractManager contractManager;

	[Tooltip("Contract tamamlama popup UI")]
	[SerializeField]
	private ContractCompletedUI contractCompletedUI;

	[Header("Factory Info")]
	[Tooltip("Para miktarı text'i")]
	[SerializeField]
	private TextMeshProUGUI moneyText;

	[Tooltip("Level text'i")]
	[SerializeField]
	private TextMeshProUGUI levelText;

	[Header("Tab Buttons")]
	[Tooltip("Contract listesi tab butonu")]
	[SerializeField]
	private Button contractListTabButton;

	[Tooltip("Aktif contract'lar tab butonu")]
	[SerializeField]
	private Button activeContractsTabButton;

	[Header("View Containers")]
	[Tooltip("Contract listesi container'ı")]
	[SerializeField]
	private GameObject contractListContainer;

	[Tooltip("Contract detay container'ı")]
	[SerializeField]
	private GameObject contractDetailContainer;

	[Tooltip("Aktif contract'lar container'ı")]
	[SerializeField]
	private GameObject activeContractsContainer;

	[Header("Contract List View")]
	[Tooltip("ContractItemUI prefab'ı (GameObject)")]
	[SerializeField]
	private GameObject contractItemPrefab;

	[Tooltip("Contract item'larının parent'ı (ScrollView Content)")]
	[SerializeField]
	private Transform contractListContent;

	[Tooltip("Contract listesi ScrollRect (Listed ve Active için ortak)")]
	[SerializeField]
	private ScrollRect mainContractScrollRect;

	[Tooltip("ScrollRect'in Content objesi (en üst parent - rebuild için)")]
	[SerializeField]
	private RectTransform scrollRectContent;

	[Header("Contract Limits UI")]
	[Tooltip("Contract limit text (0/4 formatında)")]
	[SerializeField]
	private TextMeshProUGUI contractLimitText;

	[Tooltip("Yenileme hakkı text (0/1 formatında)")]
	[SerializeField]
	private TextMeshProUGUI refreshLimitText;

	[Tooltip("Contract yenileme butonu")]
	[SerializeField]
	private Button refreshContractsButton;

	[Header("Contract Detail View - Company Info")]
	[Tooltip("Detay - Şirket logosu")]
	[SerializeField]
	private Image detailCompanyLogoImage;

	[Tooltip("Detay - Şirket arkaplan")]
	[SerializeField]
	private Image detailCompanyBackgroundImage;

	[Tooltip("Detay - Şirket ismi")]
	[SerializeField]
	private TextMeshProUGUI detailCompanyNameText;

	[Tooltip("Detay - Contract numarası")]
	[SerializeField]
	private TextMeshProUGUI detailContractNumberText;

	[Header("Contract Detail View - Contract Info")]
	[Tooltip("Detay - Contract fiyatı")]
	[SerializeField]
	private TextMeshProUGUI detailPriceText;

	[Tooltip("Detay - Teslimat süresi")]
	[SerializeField]
	private TextMeshProUGUI detailDeliveryDaysText;

	[Tooltip("Detay - Kazanılacak XP")]
	[SerializeField]
	private TextMeshProUGUI detailXPText;

	[Tooltip("Detay - Contract açıklama metni")]
	[SerializeField]
	private TextMeshProUGUI detailDescriptionText;

	[Header("Contract Detail View - Materials")]
	[Tooltip("ContractMaterialItemUI prefab'ı")]
	[SerializeField]
	private GameObject materialItemPrefab;

	[Tooltip("Malzeme listesi parent")]
	[SerializeField]
	private Transform detailMaterialListContent;

	[Header("Contract Detail View - Buttons")]
	[Tooltip("Detay - Pazarlık başlat butonu")]
	[SerializeField]
	private Button negotiateButton;

	[Tooltip("Aktif contract iptal butonu (detail view'da)")]
	[SerializeField]
	private GameObject detailCancelContractButton;

	[Tooltip("Delivery Request butonu (detail view'da) - Henüz request yokken gösterilir")]
	[SerializeField]
	private GameObject detailRequestDeliveryButton;

	[Tooltip("Cancel Delivery butonu (detail view'da) - Zone'da item yokken gösterilir (sadece araç gider)")]
	[SerializeField]
	private GameObject detailCancelDeliveryButton;

	[Tooltip("Complete Delivery butonu (detail view'da) - Zone'da item varken gösterilir (ödeme + contract tamamlama)")]
	[SerializeField]
	private GameObject detailCompleteDeliveryButton;

	[Header("Active Contracts View")]
	[Tooltip("Aktif contract için ContractItemUI prefab'ı (aynı prefab kullanılabilir)")]
	[SerializeField]
	private GameObject activeContractItemPrefab;

	[Tooltip("Aktif contract item'larının parent'ı")]
	[SerializeField]
	private Transform activeContractListContent;

	[Tooltip("Aktif contract yok mesajı")]
	[SerializeField]
	private GameObject noActiveContractsMessage;

	[Header("Cancel Contract Panel")]
	[Tooltip("Contract iptal onay paneli")]
	[SerializeField]
	private GameObject cancelContractPanelContainer;

	[Tooltip("Cancel Panel - Şirket logosu")]
	[SerializeField]
	private Image cancelPanelCompanyLogoImage;

	[Tooltip("Cancel Panel - Şirket arkaplan")]
	[SerializeField]
	private Image cancelPanelCompanyBackgroundImage;

	[Tooltip("Cancel Panel - Şirket ismi")]
	[SerializeField]
	private TextMeshProUGUI cancelPanelCompanyNameText;

	[Tooltip("Cancel Panel - Contract numarası")]
	[SerializeField]
	private TextMeshProUGUI cancelPanelContractNumberText;

	[Tooltip("Cancel Panel - Kalan gün")]
	[SerializeField]
	private TextMeshProUGUI cancelPanelRemainingDaysText;

	[Header("Negotiation Chat Panel - Company Info")]
	[Tooltip("Pazarlık panel container'ı")]
	[SerializeField]
	private GameObject negotiationPanelContainer;

	[Tooltip("Chat - Şirket logosu")]
	[SerializeField]
	private Image chatCompanyLogoImage;

	[Tooltip("Chat - Şirket arkaplan")]
	[SerializeField]
	private Image chatCompanyBackgroundImage;

	[Tooltip("Chat - Şirket ismi")]
	[SerializeField]
	private TextMeshProUGUI chatCompanyNameText;

	[Tooltip("Chat - Contract numarası")]
	[SerializeField]
	private TextMeshProUGUI chatContractNumberText;

	[Tooltip("Chat - Fiyat")]
	[SerializeField]
	private TextMeshProUGUI chatPriceText;

	[Tooltip("Chat - Teslimat süresi text")]
	[SerializeField]
	private TextMeshProUGUI chatDeliveryDaysText;

	[Header("Negotiation Chat Panel - Messages")]
	[Tooltip("Chat mesajları scroll content")]
	[SerializeField]
	private Transform chatContent;

	[Tooltip("Chat ScrollRect")]
	[SerializeField]
	private ScrollRect chatScrollRect;

	[Tooltip("Şirket (alıcı) mesaj prefab'ı")]
	[SerializeField]
	private GameObject buyerMessagePrefab;

	[Tooltip("Oyuncu (satıcı) mesaj prefab'ı")]
	[SerializeField]
	private GameObject sellerMessagePrefab;

	[Tooltip("Yazıyor... animasyonu prefab'ı")]
	[SerializeField]
	private GameObject typingIndicatorPrefab;

	[Header("Negotiation Chat Panel - Controls")]
	[Tooltip("Fiyat slider'ı")]
	[SerializeField]
	private Slider priceSlider;

	[Tooltip("Slider değer text'i")]
	[SerializeField]
	private TextMeshProUGUI sliderValueText;

	[Tooltip("Teklif gönder butonu")]
	[SerializeField]
	private Button sendOfferButton;

	[Tooltip("Anlaşma kabul edildi göstergesi")]
	[SerializeField]
	private GameObject offerAcceptedIndicator;

	[Tooltip("Pazarlığı iptal butonu")]
	[SerializeField]
	private Button cancelNegotiationButton;

	[Header("Negotiation Chat Panel - Sound Effects")]
	[Tooltip("Şirket (alıcı) mesaj sesi")]
	[SerializeField]
	private AudioClip buyerMessageSound;

	[Tooltip("Oyuncu (satıcı) mesaj sesi")]
	[SerializeField]
	private AudioClip sellerMessageSound;

	[Tooltip("Anlaşma kabul edildi sesi")]
	[SerializeField]
	private AudioClip acceptedMessageSound;

	[Tooltip("AudioSource (opsiyonel - yoksa otomatik oluşturulur)")]
	[SerializeField]
	private AudioSource chatAudioSource;

	private List<ContractItemUI> _spawnedContractItems = new List<ContractItemUI>();

	private List<ContractMaterialItemUI> _spawnedMaterialItems = new List<ContractMaterialItemUI>();

	private List<ContractItemUI> _spawnedActiveContractItems = new List<ContractItemUI>();

	private List<NegotiationChatMessageUI> _spawnedChatMessages = new List<NegotiationChatMessageUI>();

	private GameObject _currentTypingIndicator;

	private ContractListingData _selectedContract;

	private ActiveContractData _selectedActiveContract;

	private bool _isDetailViewForActiveContract;

	private ContractViewTab _currentTab;

	private int _currentSliderValue;

	private string _lastClosedNegotiationId;

	private bool _isWaitingForBuyerResponse;

	private static readonly string[] PlayerOfferKeys = new string[5] { "ChatMessage_Contract_PlayerOffer1", "ChatMessage_Contract_PlayerOffer2", "ChatMessage_Contract_PlayerOffer3", "ChatMessage_Contract_PlayerOffer4", "ChatMessage_Contract_PlayerOffer5" };

	public ContractViewTab CurrentTab => _currentTab;

	public ContractListingData SelectedContract => _selectedContract;

	private bool IsNegotiationPanelOpen
	{
		get
		{
			if (negotiationPanelContainer != null)
			{
				return negotiationPanelContainer.activeSelf;
			}
			return false;
		}
	}

	private void Awake()
	{
		if (contractManager == null)
		{
			contractManager = ComputerContractManager.Instance;
		}
	}

	private void OnEnable()
	{
		SubscribeToEvents();
		SubscribeToFactoryEvents();
		SubscribeToDeliveryZoneEvents();
		RefreshUI();
		UpdateFactoryInfo();
	}

	private void OnDisable()
	{
		UnsubscribeFromEvents();
		UnsubscribeFromFactoryEvents();
		UnsubscribeFromDeliveryZoneEvents();
	}

	private void SubscribeToEvents()
	{
		if (contractManager == null)
		{
			contractManager = ComputerContractManager.Instance;
		}
		if (contractManager != null)
		{
			contractManager.onContractListed.AddListener(OnContractListed);
			contractManager.onContractDelisted.AddListener(OnContractDelisted);
			contractManager.onContractAccepted.AddListener(OnContractAccepted);
			contractManager.onContractCompleted.AddListener(OnContractCompleted);
			contractManager.onContractFailed.AddListener(OnContractFailed);
			contractManager.onContractUpdated.AddListener(OnContractUpdated);
			contractManager.onNegotiationStarted.AddListener(OnNegotiationStarted);
			contractManager.onNegotiationUpdated.AddListener(OnNegotiationUpdated);
			contractManager.onNegotiationEnded.AddListener(OnNegotiationEnded);
			contractManager.onContractsRefreshed.AddListener(OnContractsRefreshed);
			contractManager.onDeliveryContractChanged.AddListener(OnDeliveryContractChanged);
		}
	}

	private void UnsubscribeFromEvents()
	{
		if (contractManager != null)
		{
			contractManager.onContractListed.RemoveListener(OnContractListed);
			contractManager.onContractDelisted.RemoveListener(OnContractDelisted);
			contractManager.onContractAccepted.RemoveListener(OnContractAccepted);
			contractManager.onContractCompleted.RemoveListener(OnContractCompleted);
			contractManager.onContractFailed.RemoveListener(OnContractFailed);
			contractManager.onContractUpdated.RemoveListener(OnContractUpdated);
			contractManager.onNegotiationStarted.RemoveListener(OnNegotiationStarted);
			contractManager.onNegotiationUpdated.RemoveListener(OnNegotiationUpdated);
			contractManager.onNegotiationEnded.RemoveListener(OnNegotiationEnded);
			contractManager.onContractsRefreshed.RemoveListener(OnContractsRefreshed);
			contractManager.onDeliveryContractChanged.RemoveListener(OnDeliveryContractChanged);
		}
	}

	private void SubscribeToFactoryEvents()
	{
		if (FactoryManager.Instance != null)
		{
			FactoryManager.Instance.onMoneyChanged.AddListener(OnFactoryMoneyChanged);
			FactoryManager.Instance.onLevelChanged.AddListener(OnFactoryLevelChanged);
		}
	}

	private void UnsubscribeFromFactoryEvents()
	{
		if (FactoryManager.Instance != null)
		{
			FactoryManager.Instance.onMoneyChanged.RemoveListener(OnFactoryMoneyChanged);
			FactoryManager.Instance.onLevelChanged.RemoveListener(OnFactoryLevelChanged);
		}
	}

	private void SubscribeToDeliveryZoneEvents()
	{
		if (T_DeliveryZone.Instance != null)
		{
			T_DeliveryZone.Instance.OnItemsChanged.AddListener(OnDeliveryZoneItemsChanged);
		}
	}

	private void UnsubscribeFromDeliveryZoneEvents()
	{
		if (T_DeliveryZone.Instance != null)
		{
			T_DeliveryZone.Instance.OnItemsChanged.RemoveListener(OnDeliveryZoneItemsChanged);
		}
	}

	private void OnDeliveryZoneItemsChanged()
	{
		if (_isDetailViewForActiveContract && contractDetailContainer != null && contractDetailContainer.activeSelf)
		{
			UpdateDeliveryButtons();
		}
	}

	private void OnFactoryMoneyChanged(int oldValue, int newValue)
	{
		UpdateMoneyText(newValue);
	}

	private void OnFactoryLevelChanged(int oldValue, int newValue)
	{
		UpdateLevelText(newValue);
		if (_currentTab == ContractViewTab.ContractList)
		{
			RefreshContractList();
		}
		if (contractDetailContainer != null && contractDetailContainer.activeSelf && !_isDetailViewForActiveContract)
		{
			UpdateNegotiateButtonState();
		}
	}

	private void UpdateFactoryInfo()
	{
		if (FactoryManager.Instance != null)
		{
			UpdateMoneyText(FactoryManager.Instance.Money);
			UpdateLevelText(FactoryManager.Instance.Level);
		}
	}

	private void UpdateMoneyText(int money)
	{
		if (moneyText != null)
		{
			moneyText.text = $"{money:N0}";
		}
	}

	private void UpdateLevelText(int level)
	{
		if (levelText != null)
		{
			string translation = LocalizationManager.GetTranslation("Level");
			LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, object> { 
			{
				"Number",
				level.ToString()
			} });
			levelText.text = translation;
		}
	}

	public void RefreshUI()
	{
		if (contractManager == null)
		{
			contractManager = ComputerContractManager.Instance;
			if (contractManager == null)
			{
				Debug.LogWarning("[ComputerContractUI] ContractManager bulunamadı!");
				return;
			}
		}
		UpdateLimitDisplays();
		ShowTab(_currentTab);
	}

	private void UpdateLimitDisplays()
	{
		if (!(contractManager == null))
		{
			if (contractLimitText != null)
			{
				contractLimitText.text = $"{contractManager.ActiveContractCount}/{contractManager.MaxActiveContracts}";
			}
			if (refreshLimitText != null)
			{
				refreshLimitText.text = $"{contractManager.RemainingRefreshes}/{contractManager.DailyRefreshLimit}";
			}
			if (refreshContractsButton != null)
			{
				refreshContractsButton.interactable = contractManager.CanRefresh;
			}
		}
	}

	public void ShowContractListTab()
	{
		ShowTab(ContractViewTab.ContractList);
	}

	public void ShowActiveContractsTab()
	{
		ShowTab(ContractViewTab.ActiveContracts);
	}

	public void ShowTab(ContractViewTab tab)
	{
		_currentTab = tab;
		if (contractListContainer != null)
		{
			contractListContainer.SetActive(tab == ContractViewTab.ContractList);
		}
		if (activeContractsContainer != null)
		{
			activeContractsContainer.SetActive(tab == ContractViewTab.ActiveContracts);
		}
		if (contractDetailContainer != null)
		{
			contractDetailContainer.SetActive(value: false);
		}
		UpdateTabButtonStates();
		UpdateLimitDisplays();
		switch (tab)
		{
		case ContractViewTab.ContractList:
			RefreshContractList();
			UpdateNegotiateButtonState();
			break;
		case ContractViewTab.ActiveContracts:
			RefreshActiveContractList();
			break;
		}
	}

	public void ShowDetailView(ContractListingData contract)
	{
		_selectedContract = contract;
		_isDetailViewForActiveContract = false;
		if (contractDetailContainer != null)
		{
			contractDetailContainer.SetActive(value: true);
		}
		if (negotiateButton != null)
		{
			negotiateButton.gameObject.SetActive(value: true);
		}
		if (detailCancelContractButton != null)
		{
			detailCancelContractButton.SetActive(value: false);
		}
		if (detailRequestDeliveryButton != null)
		{
			detailRequestDeliveryButton.SetActive(value: false);
		}
		if (detailCancelDeliveryButton != null)
		{
			detailCancelDeliveryButton.SetActive(value: false);
		}
		if (detailCompleteDeliveryButton != null)
		{
			detailCompleteDeliveryButton.SetActive(value: false);
		}
		UpdateDetailView();
	}

	public void HideDetailView()
	{
		if (contractDetailContainer != null)
		{
			contractDetailContainer.SetActive(value: false);
		}
	}

	private void UpdateTabButtonStates()
	{
		if (contractListTabButton != null)
		{
			contractListTabButton.interactable = _currentTab != ContractViewTab.ContractList;
		}
		if (activeContractsTabButton != null)
		{
			activeContractsTabButton.interactable = _currentTab != ContractViewTab.ActiveContracts;
		}
	}

	private void RefreshContractList()
	{
		ClearContractList();
		if (contractManager == null)
		{
			return;
		}
		foreach (ContractListingData listedContract in contractManager.ListedContracts)
		{
			CreateContractItem(listedContract);
		}
		Debug.Log($"[ComputerContractUI] {_spawnedContractItems.Count} kontrat oluşturuldu.");
		StartCoroutine(ForceLayoutRebuildDelayed(scrollRectContent, mainContractScrollRect));
	}

	private IEnumerator ForceLayoutRebuildDelayed(RectTransform rootTransform, ScrollRect scrollRect = null, bool resetScrollToTop = true)
	{
		if (!(rootTransform == null))
		{
			for (int i = 0; i < 3; i++)
			{
				yield return null;
				RebuildAllChildLayouts(rootTransform);
				Canvas.ForceUpdateCanvases();
			}
			if (scrollRect != null && resetScrollToTop)
			{
				scrollRect.verticalNormalizedPosition = 1f;
				scrollRect.velocity = Vector2.zero;
			}
		}
	}

	private void RebuildAllChildLayouts(Transform parent)
	{
		if (parent == null)
		{
			return;
		}
		RectTransform[] componentsInChildren = parent.GetComponentsInChildren<RectTransform>(includeInactive: true);
		if (componentsInChildren == null || componentsInChildren.Length == 0)
		{
			return;
		}
		Array.Sort(componentsInChildren, (RectTransform a, RectTransform b) => GetDepth(b) - GetDepth(a));
		RectTransform[] array = componentsInChildren;
		foreach (RectTransform rectTransform in array)
		{
			if (rectTransform != null && rectTransform.gameObject.activeInHierarchy)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
			}
		}
	}

	private int GetDepth(Transform t)
	{
		int num = 0;
		while (t.parent != null)
		{
			num++;
			t = t.parent;
		}
		return num;
	}

	private void CreateContractItem(ContractListingData listing)
	{
		if (!(contractItemPrefab == null) && !(contractListContent == null))
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(contractItemPrefab, contractListContent);
			ContractItemUI component = gameObject.GetComponent<ContractItemUI>();
			if (component != null)
			{
				component.InitializeAsListing(listing, OnContractItemClicked);
				_spawnedContractItems.Add(component);
			}
			else
			{
				Debug.LogWarning("[ComputerContractUI] ContractItemUI component bulunamadı!");
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	private void ClearContractList()
	{
		foreach (ContractItemUI spawnedContractItem in _spawnedContractItems)
		{
			if (spawnedContractItem != null)
			{
				UnityEngine.Object.Destroy(spawnedContractItem.gameObject);
			}
		}
		_spawnedContractItems.Clear();
	}

	private void RemoveContractItemFromList(string listingId)
	{
		for (int num = _spawnedContractItems.Count - 1; num >= 0; num--)
		{
			if (_spawnedContractItems[num] != null && _spawnedContractItems[num].ListingId == listingId)
			{
				UnityEngine.Object.Destroy(_spawnedContractItems[num].gameObject);
				_spawnedContractItems.RemoveAt(num);
				break;
			}
		}
	}

	private void UpdateDetailView()
	{
		if (!_selectedContract.IsValid)
		{
			return;
		}
		ContractSO contractSO = contractManager?.GetContractConfig(_selectedContract.contractId);
		if (detailCompanyNameText != null)
		{
			detailCompanyNameText.text = _selectedContract.companyName;
		}
		if (detailContractNumberText != null)
		{
			detailContractNumberText.text = $"#{_selectedContract.contractNumber:D3}";
		}
		if (detailPriceText != null)
		{
			detailPriceText.text = $"{_selectedContract.price:N0}";
		}
		if (detailDeliveryDaysText != null)
		{
			string arg = ((_selectedContract.deliveryDays == 1) ? LocalizationManager.GetTranslation("Day") : LocalizationManager.GetTranslation("Days"));
			string translation = LocalizationManager.GetTranslation("Delivery Time");
			detailDeliveryDaysText.text = $"{_selectedContract.deliveryDays} {arg} {translation}";
		}
		if (detailXPText != null)
		{
			detailXPText.text = ((contractSO != null) ? $"{contractSO.TierXP} XP" : "");
		}
		if (detailDescriptionText != null)
		{
			string text = contractSO?.company?.companyDescKey ?? "";
			string text2 = ((!string.IsNullOrEmpty(text)) ? LocalizationManager.GetTranslation(text) : "");
			detailDescriptionText.text = text2;
			detailDescriptionText.gameObject.SetActive(!string.IsNullOrEmpty(text2));
		}
		if (detailCompanyLogoImage != null)
		{
			Sprite logo = _selectedContract.GetLogo(contractSO);
			if (logo != null)
			{
				detailCompanyLogoImage.sprite = logo;
				detailCompanyLogoImage.gameObject.SetActive(value: true);
			}
			else
			{
				detailCompanyLogoImage.gameObject.SetActive(value: false);
			}
		}
		if (detailCompanyBackgroundImage != null)
		{
			Sprite background = _selectedContract.GetBackground(contractSO);
			if (background != null)
			{
				detailCompanyBackgroundImage.sprite = background;
				detailCompanyBackgroundImage.gameObject.SetActive(value: true);
			}
			else
			{
				detailCompanyBackgroundImage.gameObject.SetActive(value: false);
			}
		}
		UpdateDetailMaterialList();
		UpdateNegotiateButtonState();
	}

	private void UpdateDetailMaterialList()
	{
		ClearDetailMaterialList();
		if (materialItemPrefab == null)
		{
			Debug.LogWarning("[ComputerContractUI] materialItemPrefab NULL!");
			return;
		}
		if (detailMaterialListContent == null)
		{
			Debug.LogWarning("[ComputerContractUI] detailMaterialListContent NULL!");
			return;
		}
		for (int i = 0; i < _selectedContract.MaterialCount; i++)
		{
			if (_selectedContract.TryGetMaterial(i, out var itemId, out var count))
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(materialItemPrefab, detailMaterialListContent);
				ContractMaterialItemUI component = gameObject.GetComponent<ContractMaterialItemUI>();
				if (component != null)
				{
					component.InitializeForListing(itemId, count);
					_spawnedMaterialItems.Add(component);
				}
				else
				{
					Debug.LogWarning("[ComputerContractUI] ContractMaterialItemUI component bulunamadı!");
					UnityEngine.Object.Destroy(gameObject);
				}
			}
		}
		if (contractDetailContainer != null)
		{
			StartCoroutine(ForceLayoutRebuildDelayed(contractDetailContainer.GetComponent<RectTransform>(), null, resetScrollToTop: false));
		}
	}

	private void ClearDetailMaterialList()
	{
		foreach (ContractMaterialItemUI spawnedMaterialItem in _spawnedMaterialItems)
		{
			if (spawnedMaterialItem != null)
			{
				UnityEngine.Object.Destroy(spawnedMaterialItem.gameObject);
			}
		}
		_spawnedMaterialItems.Clear();
	}

	private void UpdateNegotiateButtonState()
	{
		if (!(negotiateButton == null))
		{
			if (_isDetailViewForActiveContract)
			{
				negotiateButton.gameObject.SetActive(value: false);
				return;
			}
			if (_selectedContract.IsValid && _selectedContract.IsLocked)
			{
				negotiateButton.gameObject.SetActive(value: false);
				return;
			}
			negotiateButton.gameObject.SetActive(value: true);
			bool flag = contractManager != null && contractManager.HasActiveNegotiation && _selectedContract.IsValid && contractManager.CurrentNegotiation.listingId == _selectedContract.listingId;
			negotiateButton.interactable = !flag;
		}
	}

	private void RefreshActiveContractList()
	{
		ClearActiveContractList();
		if (contractManager == null)
		{
			return;
		}
		if (noActiveContractsMessage != null)
		{
			noActiveContractsMessage.SetActive(contractManager.ActiveContractCount == 0);
		}
		foreach (ActiveContractData activeContract in contractManager.ActiveContracts)
		{
			CreateActiveContractItem(activeContract);
		}
		Debug.Log($"[ComputerContractUI] {_spawnedActiveContractItems.Count} aktif kontrat oluşturuldu.");
		UpdateLimitDisplays();
		StartCoroutine(ForceLayoutRebuildDelayed(scrollRectContent, mainContractScrollRect));
	}

	private void CreateActiveContractItem(ActiveContractData contract)
	{
		if (!(activeContractItemPrefab == null) && !(activeContractListContent == null))
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(activeContractItemPrefab, activeContractListContent);
			ContractItemUI component = gameObject.GetComponent<ContractItemUI>();
			if (component != null)
			{
				component.InitializeAsActive(contract, OnActiveContractDetailClicked, OnActiveContractCancelClicked);
				_spawnedActiveContractItems.Add(component);
			}
			else
			{
				Debug.LogWarning("[ComputerContractUI] ContractItemUI component bulunamadı!");
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	private void ClearActiveContractList()
	{
		foreach (ContractItemUI spawnedActiveContractItem in _spawnedActiveContractItems)
		{
			if (spawnedActiveContractItem != null)
			{
				UnityEngine.Object.Destroy(spawnedActiveContractItem.gameObject);
			}
		}
		_spawnedActiveContractItems.Clear();
	}

	private void UpdateActiveContractItem(ActiveContractData contract)
	{
		foreach (ContractItemUI spawnedActiveContractItem in _spawnedActiveContractItems)
		{
			if (spawnedActiveContractItem != null && spawnedActiveContractItem.ActiveId == contract.activeId)
			{
				spawnedActiveContractItem.UpdateActiveContractData(contract);
				break;
			}
		}
	}

	private void RemoveActiveContractItem(string activeId)
	{
		for (int num = _spawnedActiveContractItems.Count - 1; num >= 0; num--)
		{
			if (_spawnedActiveContractItems[num] != null && _spawnedActiveContractItems[num].ActiveId == activeId)
			{
				UnityEngine.Object.Destroy(_spawnedActiveContractItems[num].gameObject);
				_spawnedActiveContractItems.RemoveAt(num);
				return;
			}
		}
		if (noActiveContractsMessage != null && contractManager != null)
		{
			noActiveContractsMessage.SetActive(contractManager.ActiveContractCount == 0);
		}
	}

	private void OnContractListed(ContractListingData listing)
	{
		if (_currentTab == ContractViewTab.ContractList)
		{
			CreateContractItem(listing);
		}
	}

	private void OnContractDelisted(ContractListingData listing)
	{
		RemoveContractItemFromList(listing.listingId);
		if (_selectedContract.listingId == listing.listingId)
		{
			HideDetailView();
		}
	}

	private void OnContractAccepted(ActiveContractData contract)
	{
		if (_currentTab == ContractViewTab.ActiveContracts)
		{
			CreateActiveContractItem(contract);
			if (noActiveContractsMessage != null)
			{
				noActiveContractsMessage.SetActive(value: false);
			}
		}
		UpdateLimitDisplays();
		HideDetailView();
	}

	private void OnContractCompleted(ActiveContractData contract)
	{
		RemoveActiveContractItem(contract.activeId);
		UpdateLimitDisplays();
	}

	private void OnContractFailed(ActiveContractData contract)
	{
		RemoveActiveContractItem(contract.activeId);
		UpdateLimitDisplays();
	}

	private void OnContractUpdated(ActiveContractData contract)
	{
		UpdateActiveContractItem(contract);
	}

	private void OnContractsRefreshed()
	{
		RefreshContractList();
		UpdateLimitDisplays();
	}

	private void OnDeliveryContractChanged(string contractId)
	{
		if (_isDetailViewForActiveContract && contractDetailContainer != null && contractDetailContainer.activeSelf)
		{
			UpdateDeliveryButtons();
		}
	}

	private void UpdateDeliveryButtons()
	{
		if (!_isDetailViewForActiveContract || !_selectedActiveContract.IsValid)
		{
			if (detailRequestDeliveryButton != null)
			{
				detailRequestDeliveryButton.SetActive(value: false);
			}
			if (detailCancelDeliveryButton != null)
			{
				detailCancelDeliveryButton.SetActive(value: false);
			}
			if (detailCompleteDeliveryButton != null)
			{
				detailCompleteDeliveryButton.SetActive(value: false);
			}
			return;
		}
		bool flag = contractManager != null && contractManager.DeliveryRequestedContractId == _selectedActiveContract.activeId;
		if (detailRequestDeliveryButton != null)
		{
			detailRequestDeliveryButton.SetActive(!flag);
		}
		if (flag)
		{
			bool flag2 = T_DeliveryZone.Instance != null && T_DeliveryZone.Instance.TotalDeliveredCount > 0;
			if (detailCancelDeliveryButton != null)
			{
				detailCancelDeliveryButton.SetActive(!flag2);
			}
			if (detailCompleteDeliveryButton != null)
			{
				detailCompleteDeliveryButton.SetActive(flag2);
			}
		}
		else
		{
			if (detailCancelDeliveryButton != null)
			{
				detailCancelDeliveryButton.SetActive(value: false);
			}
			if (detailCompleteDeliveryButton != null)
			{
				detailCompleteDeliveryButton.SetActive(value: false);
			}
		}
	}

	private void OnNegotiationStarted(ContractNegotiationData negotiation)
	{
		UpdateNegotiateButtonState();
		uint num = NetworkClient.localPlayer?.netId ?? 0;
		if (negotiation.negotiatorNetId == num)
		{
			ShowNegotiationPanel(negotiation);
		}
	}

	private void OnNegotiationUpdated(ContractNegotiationData negotiation)
	{
		uint num = NetworkClient.localPlayer?.netId ?? 0;
		if (negotiation.negotiatorNetId == num)
		{
			if (negotiation.state == NegotiationState.Accepted)
			{
				StartCoroutine(AddBuyerMessageWithTypingIndicatorForAccepted(negotiation.buyerMessage));
			}
			else
			{
				StartCoroutine(AddBuyerMessageWithTypingIndicator(negotiation.buyerMessage, negotiation));
			}
		}
	}

	private void OnNegotiationEnded(ContractNegotiationData negotiation)
	{
		UpdateNegotiateButtonState();
		uint num = NetworkClient.localPlayer?.netId ?? 0;
		if (negotiation.negotiatorNetId == num)
		{
			if (negotiation.listingId == _lastClosedNegotiationId && negotiation.state == NegotiationState.Rejected)
			{
				_lastClosedNegotiationId = null;
			}
			else if (negotiation.state == NegotiationState.Rejected)
			{
				StartCoroutine(AddBuyerMessageWithTypingIndicatorEnd(negotiation.buyerMessage, negotiation));
			}
		}
	}

	private IEnumerator AddBuyerMessageWithTypingIndicator(string message, ContractNegotiationData negotiation)
	{
		if (!IsNegotiationPanelOpen)
		{
			yield break;
		}
		ShowTypingIndicator();
		float seconds = UnityEngine.Random.Range(0.75f, 1.5f);
		yield return new WaitForSeconds(seconds);
		if (IsNegotiationPanelOpen)
		{
			HideTypingIndicator();
			AddBuyerMessage(message);
			_isWaitingForBuyerResponse = false;
			if (sendOfferButton != null && negotiation.state == NegotiationState.InProgress)
			{
				sendOfferButton.interactable = true;
			}
			UpdateNegotiationButtonStates(negotiation);
		}
	}

	private IEnumerator AddBuyerMessageWithTypingIndicatorForAccepted(string message)
	{
		if (IsNegotiationPanelOpen)
		{
			ShowTypingIndicator();
			float seconds = UnityEngine.Random.Range(0.75f, 1.5f);
			yield return new WaitForSeconds(seconds);
			if (IsNegotiationPanelOpen)
			{
				HideTypingIndicator();
				AddBuyerMessage(message);
				_isWaitingForBuyerResponse = false;
				UpdateNegotiationButtonsForAccepted();
			}
		}
	}

	private IEnumerator AddBuyerMessageWithTypingIndicatorEnd(string message, ContractNegotiationData negotiation)
	{
		if (!IsNegotiationPanelOpen)
		{
			yield break;
		}
		ShowTypingIndicator();
		float seconds = UnityEngine.Random.Range(2f, 4f);
		yield return new WaitForSeconds(seconds);
		if (!IsNegotiationPanelOpen)
		{
			yield break;
		}
		HideTypingIndicator();
		AddBuyerMessage(message);
		if (negotiation.state == NegotiationState.Rejected)
		{
			yield return new WaitForSeconds(1.5f);
			if (IsNegotiationPanelOpen)
			{
				HideNegotiationPanel();
			}
		}
	}

	private void ShowTypingIndicator()
	{
		if (!(typingIndicatorPrefab == null) && !(chatContent == null))
		{
			HideTypingIndicator();
			_currentTypingIndicator = UnityEngine.Object.Instantiate(typingIndicatorPrefab, chatContent);
			ScrollChatToBottom();
		}
	}

	private void HideTypingIndicator()
	{
		if (_currentTypingIndicator != null)
		{
			UnityEngine.Object.Destroy(_currentTypingIndicator);
			_currentTypingIndicator = null;
		}
	}

	private void ShowNegotiationPanel(ContractNegotiationData negotiation)
	{
		if (!(negotiationPanelContainer == null))
		{
			_lastClosedNegotiationId = null;
			_isWaitingForBuyerResponse = false;
			StopAllNegotiationCoroutines();
			HideTypingIndicator();
			ClearChatMessages();
			negotiationPanelContainer.SetActive(value: true);
			UpdateChatContractInfo();
			SetupPriceSlider(negotiation);
			if (offerAcceptedIndicator != null)
			{
				offerAcceptedIndicator.SetActive(value: false);
			}
			if (sendOfferButton != null)
			{
				sendOfferButton.gameObject.SetActive(value: true);
			}
			AddBuyerMessage(negotiation.buyerMessage);
			UpdateNegotiationButtonStates(negotiation);
		}
	}

	private void UpdateChatContractInfo()
	{
		if (!_selectedContract.IsValid)
		{
			return;
		}
		ContractSO contractSO = contractManager?.GetContractConfig(_selectedContract.contractId);
		if (chatCompanyNameText != null)
		{
			chatCompanyNameText.text = _selectedContract.companyName;
		}
		if (chatContractNumberText != null)
		{
			chatContractNumberText.text = $"#{_selectedContract.contractNumber:D3}";
		}
		if (chatPriceText != null)
		{
			chatPriceText.text = $"{_selectedContract.price:N0}";
		}
		if (chatDeliveryDaysText != null)
		{
			string arg = ((_selectedContract.deliveryDays == 1) ? LocalizationManager.GetTranslation("Day") : LocalizationManager.GetTranslation("Days"));
			string translation = LocalizationManager.GetTranslation("Delivery Time");
			chatDeliveryDaysText.text = $"{_selectedContract.deliveryDays} {arg} {translation}";
		}
		if (chatCompanyLogoImage != null)
		{
			Sprite sprite = contractSO?.company?.companyLogo;
			if (sprite != null)
			{
				chatCompanyLogoImage.sprite = sprite;
				chatCompanyLogoImage.gameObject.SetActive(value: true);
			}
			else
			{
				chatCompanyLogoImage.gameObject.SetActive(value: false);
			}
		}
		if (chatCompanyBackgroundImage != null)
		{
			Sprite sprite2 = contractSO?.company?.companyBackground;
			if (sprite2 != null)
			{
				chatCompanyBackgroundImage.sprite = sprite2;
				chatCompanyBackgroundImage.gameObject.SetActive(value: true);
			}
			else
			{
				chatCompanyBackgroundImage.gameObject.SetActive(value: false);
			}
		}
	}

	public void HideNegotiationPanel()
	{
		StopAllNegotiationCoroutines();
		HideTypingIndicator();
		_isWaitingForBuyerResponse = false;
		if (contractManager != null && contractManager.HasActiveNegotiation)
		{
			ContractNegotiationData currentNegotiation = contractManager.CurrentNegotiation;
			if (currentNegotiation.state == NegotiationState.InProgress || currentNegotiation.state == NegotiationState.FinalOffer)
			{
				_lastClosedNegotiationId = currentNegotiation.listingId;
				contractManager.RequestCancelNegotiation();
			}
		}
		if (negotiationPanelContainer != null)
		{
			negotiationPanelContainer.SetActive(value: false);
		}
		ClearChatMessages();
		UpdateNegotiateButtonState();
	}

	private void StopAllNegotiationCoroutines()
	{
		StopAllCoroutines();
	}

	private void SetupPriceSlider(ContractNegotiationData negotiation)
	{
		if (!(priceSlider == null))
		{
			int num = 10;
			int num2 = negotiation.basePrice / num * num;
			int num3 = Mathf.RoundToInt((float)negotiation.basePrice * 1.4f) / num * num;
			priceSlider.minValue = num2;
			priceSlider.maxValue = num3;
			priceSlider.wholeNumbers = true;
			int num4 = num2;
			priceSlider.value = num4;
			_currentSliderValue = num4;
			UpdateSliderValueText();
		}
	}

	private void UpdateSliderValueText()
	{
		if (sliderValueText != null)
		{
			sliderValueText.text = $"{_currentSliderValue:N0}";
		}
	}

	private void UpdateNegotiationButtonStates(ContractNegotiationData negotiation)
	{
		bool isActive = negotiation.IsActive;
		if (negotiation.state == NegotiationState.Accepted)
		{
			UpdateNegotiationButtonsForAccepted();
			return;
		}
		if (sendOfferButton != null)
		{
			sendOfferButton.gameObject.SetActive(value: true);
			sendOfferButton.interactable = isActive;
		}
		if (offerAcceptedIndicator != null)
		{
			offerAcceptedIndicator.SetActive(value: false);
		}
		if (priceSlider != null)
		{
			priceSlider.interactable = isActive;
		}
		if (cancelNegotiationButton != null)
		{
			cancelNegotiationButton.interactable = isActive;
		}
	}

	private void UpdateNegotiationButtonsForAccepted()
	{
		if (sendOfferButton != null)
		{
			sendOfferButton.gameObject.SetActive(value: false);
		}
		if (offerAcceptedIndicator != null)
		{
			offerAcceptedIndicator.SetActive(value: true);
		}
		if (priceSlider != null)
		{
			priceSlider.interactable = false;
		}
		if (cancelNegotiationButton != null)
		{
			cancelNegotiationButton.interactable = true;
		}
		PlayAcceptedSound();
	}

	private void AddBuyerMessage(string message)
	{
		if (!(buyerMessagePrefab == null) && !(chatContent == null) && !string.IsNullOrEmpty(message))
		{
			NegotiationChatMessageUI component = UnityEngine.Object.Instantiate(buyerMessagePrefab, chatContent).GetComponent<NegotiationChatMessageUI>();
			if (component != null)
			{
				component.Initialize(message, isSeller: true);
				_spawnedChatMessages.Add(component);
			}
			PlayChatSound(buyerMessageSound);
			ScrollChatToBottom();
		}
	}

	private void AddSellerMessage(string message)
	{
		if (!(sellerMessagePrefab == null) && !(chatContent == null))
		{
			NegotiationChatMessageUI component = UnityEngine.Object.Instantiate(sellerMessagePrefab, chatContent).GetComponent<NegotiationChatMessageUI>();
			if (component != null)
			{
				component.Initialize(message, isSeller: false);
				_spawnedChatMessages.Add(component);
			}
			PlayChatSound(sellerMessageSound);
			ScrollChatToBottom();
		}
	}

	private void PlayChatSound(AudioClip clip)
	{
		if (!(clip == null))
		{
			if (chatAudioSource == null)
			{
				chatAudioSource = base.gameObject.AddComponent<AudioSource>();
				chatAudioSource.playOnAwake = false;
			}
			chatAudioSource.PlayOneShot(clip);
		}
	}

	private void PlayAcceptedSound()
	{
		PlayChatSound(acceptedMessageSound);
	}

	private void ScrollChatToBottom()
	{
		StartCoroutine(ScrollChatToBottomDelayed());
	}

	private IEnumerator ScrollChatToBottomDelayed()
	{
		yield return null;
		if (chatContent != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(chatContent as RectTransform);
		}
		Canvas.ForceUpdateCanvases();
		yield return null;
		if (chatScrollRect != null)
		{
			chatScrollRect.verticalNormalizedPosition = 0f;
			chatScrollRect.velocity = Vector2.zero;
		}
		yield return null;
		if (chatScrollRect != null)
		{
			chatScrollRect.verticalNormalizedPosition = 0f;
		}
	}

	private void ClearChatMessages()
	{
		foreach (NegotiationChatMessageUI spawnedChatMessage in _spawnedChatMessages)
		{
			if (spawnedChatMessage != null)
			{
				UnityEngine.Object.Destroy(spawnedChatMessage.gameObject);
			}
		}
		_spawnedChatMessages.Clear();
	}

	public void OnContractListTabClicked()
	{
		ShowContractListTab();
	}

	public void OnActiveContractsTabClicked()
	{
		ShowActiveContractsTab();
	}

	public void OnNegotiateButtonClicked()
	{
		if (GameManager.Instance != null && GameManager.Instance.dayNightManager.IsNighttime)
		{
			Debug.LogWarning("[ComputerContractManager] Gece Negotiation başlatılamaz!");
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Too Late For This Action"), isComputer: true);
			}
		}
		else if (_selectedContract.IsValid)
		{
			contractManager?.RequestStartNegotiation(_selectedContract.listingId);
		}
	}

	public void OnDetailBackButtonClicked()
	{
		HideDetailView();
	}

	public void OnSliderValueChanged()
	{
		if (!(priceSlider == null))
		{
			int num = 10;
			_currentSliderValue = Mathf.RoundToInt(priceSlider.value / (float)num) * num;
			priceSlider.SetValueWithoutNotify(_currentSliderValue);
			UpdateSliderValueText();
		}
	}

	public void OnSendOfferButtonClicked()
	{
		if (!(contractManager == null) && contractManager.HasActiveNegotiation && !_isWaitingForBuyerResponse)
		{
			_isWaitingForBuyerResponse = true;
			if (sendOfferButton != null)
			{
				sendOfferButton.interactable = false;
			}
			AddSellerMessage(GetSellerOfferMessage(_currentSliderValue));
			contractManager.RequestMakeOffer(_currentSliderValue);
		}
	}

	public void OnCancelNegotiationButtonClicked()
	{
		HideNegotiationPanel();
	}

	public void OnDetailCancelContractButtonClicked()
	{
		if (_isDetailViewForActiveContract && _selectedActiveContract.IsValid)
		{
			ShowCancelContractPanel();
		}
	}

	private void ShowCancelContractPanel()
	{
		if (!(cancelContractPanelContainer == null))
		{
			cancelContractPanelContainer.SetActive(value: true);
			UpdateCancelContractPanelInfo();
		}
	}

	private void UpdateCancelContractPanelInfo()
	{
		if (!_selectedActiveContract.IsValid)
		{
			return;
		}
		ContractSO contractSO = contractManager?.GetContractConfig(_selectedActiveContract.contractId);
		if (cancelPanelCompanyNameText != null)
		{
			cancelPanelCompanyNameText.text = _selectedActiveContract.companyName;
		}
		if (cancelPanelContractNumberText != null)
		{
			cancelPanelContractNumberText.text = $"#{_selectedActiveContract.contractNumber:D3}";
		}
		if (cancelPanelRemainingDaysText != null)
		{
			int remainingDays = _selectedActiveContract.RemainingDays;
			if (remainingDays > 0)
			{
				string arg = ((remainingDays == 1) ? LocalizationManager.GetTranslation("Day") : LocalizationManager.GetTranslation("Days"));
				string translation = LocalizationManager.GetTranslation("Remaining!");
				cancelPanelRemainingDaysText.text = $"{remainingDays} {arg} {translation}";
			}
			else
			{
				string text = LocalizationManager.GetTranslation("Last Day");
				if (string.IsNullOrEmpty(text))
				{
					text = "Last Day";
				}
				cancelPanelRemainingDaysText.text = text;
			}
		}
		if (cancelPanelCompanyLogoImage != null)
		{
			Sprite sprite = contractSO?.company?.companyLogo;
			if (sprite != null)
			{
				cancelPanelCompanyLogoImage.sprite = sprite;
				cancelPanelCompanyLogoImage.gameObject.SetActive(value: true);
			}
			else
			{
				cancelPanelCompanyLogoImage.gameObject.SetActive(value: false);
			}
		}
		if (cancelPanelCompanyBackgroundImage != null)
		{
			Sprite sprite2 = contractSO?.company?.companyBackground;
			if (sprite2 != null)
			{
				cancelPanelCompanyBackgroundImage.sprite = sprite2;
				cancelPanelCompanyBackgroundImage.gameObject.SetActive(value: true);
			}
			else
			{
				cancelPanelCompanyBackgroundImage.gameObject.SetActive(value: false);
			}
		}
	}

	public void HideCancelContractPanel()
	{
		if (cancelContractPanelContainer != null)
		{
			cancelContractPanelContainer.SetActive(value: false);
		}
	}

	public void OnCloseCancelContractPanelClicked()
	{
		HideCancelContractPanel();
	}

	public void OnConfirmCancelContractClicked()
	{
		if (!_selectedActiveContract.IsValid)
		{
			return;
		}
		if (contractManager != null && contractManager.DeliveryRequestedContractId == _selectedActiveContract.activeId)
		{
			if (!CheckDeliveryZoneOccupancy())
			{
				return;
			}
			contractManager.RequestCancelDeliveryOnly();
		}
		HideCancelContractPanel();
		contractManager?.RequestCancelContract(_selectedActiveContract.activeId);
		HideDetailView();
		UpdateLimitDisplays();
	}

	private bool CheckDeliveryZoneOccupancy()
	{
		if (T_DeliveryZone.Instance == null)
		{
			return true;
		}
		if (T_DeliveryZone.Instance.HasOccupants)
		{
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_DeliveryZone_Occupied"), isComputer: true);
			}
			return false;
		}
		return true;
	}

	public void OnDetailRequestDeliveryButtonClicked()
	{
		if (!_isDetailViewForActiveContract || !_selectedActiveContract.IsValid || contractManager == null)
		{
			return;
		}
		if (GameManager.Instance != null && GameManager.Instance.dayNightManager.IsNighttime)
		{
			Debug.LogWarning("[ComputerContractManager] Gece delivery çağrılamaz!");
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Too Late For This Action"), isComputer: true);
			}
		}
		else if (contractManager.HasDeliveryRequest)
		{
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("AlreadyHaveADelivery"), isComputer: true);
			}
		}
		else
		{
			contractManager.RequestSetDeliveryContract(_selectedActiveContract.activeId);
			UpdateDeliveryButtons();
		}
	}

	public void OnDetailCancelDeliveryButtonClicked()
	{
		if (_isDetailViewForActiveContract && _selectedActiveContract.IsValid && !(contractManager == null) && CheckDeliveryZoneOccupancy())
		{
			contractManager.RequestCancelDeliveryOnly();
			UpdateDeliveryButtons();
		}
	}

	public void OnDetailCompleteDeliveryButtonClicked()
	{
		if (_isDetailViewForActiveContract && _selectedActiveContract.IsValid && !(contractManager == null) && CheckDeliveryZoneOccupancy())
		{
			contractManager.RequestClearDeliveryContract();
			HideDetailView();
			UpdateLimitDisplays();
		}
	}

	public void OnRefreshContractsButtonClicked()
	{
		if (!(contractManager == null))
		{
			if (!NetworkServer.active)
			{
				NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
				return;
			}
			contractManager.RequestRefreshContracts();
			UpdateLimitDisplays();
		}
	}

	private void OnContractItemClicked(ContractListingData listing)
	{
		ShowDetailView(listing);
	}

	private void OnActiveContractDetailClicked(ActiveContractData contract)
	{
		ShowActiveContractDetailView(contract);
	}

	private void ShowActiveContractDetailView(ActiveContractData contract)
	{
		_selectedActiveContract = contract;
		_isDetailViewForActiveContract = true;
		if (contractDetailContainer != null)
		{
			contractDetailContainer.SetActive(value: true);
		}
		if (negotiateButton != null)
		{
			negotiateButton.gameObject.SetActive(value: false);
		}
		if (detailCancelContractButton != null)
		{
			detailCancelContractButton.SetActive(value: true);
		}
		UpdateDeliveryButtons();
		UpdateActiveContractDetailView();
	}

	private void UpdateActiveContractDetailView()
	{
		if (!_selectedActiveContract.IsValid)
		{
			return;
		}
		ContractSO contractSO = contractManager?.GetContractConfig(_selectedActiveContract.contractId);
		if (detailCompanyNameText != null)
		{
			detailCompanyNameText.text = _selectedActiveContract.companyName;
		}
		if (detailContractNumberText != null)
		{
			detailContractNumberText.text = $"#{_selectedActiveContract.contractNumber:D3}";
		}
		if (detailPriceText != null)
		{
			detailPriceText.text = $"{_selectedActiveContract.agreedPrice:N0}";
		}
		if (detailDeliveryDaysText != null)
		{
			int remainingDays = _selectedActiveContract.RemainingDays;
			if (remainingDays > 0)
			{
				string arg = ((remainingDays == 1) ? LocalizationManager.GetTranslation("Day") : LocalizationManager.GetTranslation("Days"));
				string translation = LocalizationManager.GetTranslation("Remaining!");
				detailDeliveryDaysText.text = $"{remainingDays} {arg} {translation}";
			}
			else
			{
				string text = LocalizationManager.GetTranslation("Last Day");
				if (string.IsNullOrEmpty(text))
				{
					text = "Last Day";
				}
				detailDeliveryDaysText.text = text;
			}
		}
		if (detailXPText != null)
		{
			detailXPText.text = ((contractSO != null) ? $"{contractSO.TierXP} XP" : "");
		}
		if (detailDescriptionText != null)
		{
			string text2 = contractSO?.company?.companyDescKey ?? "";
			string text3 = ((!string.IsNullOrEmpty(text2)) ? LocalizationManager.GetTranslation(text2) : "");
			detailDescriptionText.text = text3;
			detailDescriptionText.gameObject.SetActive(!string.IsNullOrEmpty(text3));
		}
		if (detailCompanyLogoImage != null)
		{
			Sprite sprite = contractSO?.company?.companyLogo;
			if (sprite != null)
			{
				detailCompanyLogoImage.sprite = sprite;
				detailCompanyLogoImage.gameObject.SetActive(value: true);
			}
			else
			{
				detailCompanyLogoImage.gameObject.SetActive(value: false);
			}
		}
		if (detailCompanyBackgroundImage != null)
		{
			Sprite sprite2 = contractSO?.company?.companyBackground;
			if (sprite2 != null)
			{
				detailCompanyBackgroundImage.sprite = sprite2;
				detailCompanyBackgroundImage.gameObject.SetActive(value: true);
			}
			else
			{
				detailCompanyBackgroundImage.gameObject.SetActive(value: false);
			}
		}
		UpdateActiveContractDetailMaterialList();
	}

	private void UpdateActiveContractDetailMaterialList()
	{
		ClearDetailMaterialList();
		if (materialItemPrefab == null || detailMaterialListContent == null)
		{
			return;
		}
		for (int i = 0; i < _selectedActiveContract.MaterialCount; i++)
		{
			if (_selectedActiveContract.materialIds != null && i < _selectedActiveContract.materialIds.Length)
			{
				string itemId = _selectedActiveContract.materialIds[i];
				int requiredCount = _selectedActiveContract.materialCounts[i];
				int deliveredCount = ((_selectedActiveContract.deliveredCounts != null && i < _selectedActiveContract.deliveredCounts.Length) ? _selectedActiveContract.deliveredCounts[i] : 0);
				GameObject gameObject = UnityEngine.Object.Instantiate(materialItemPrefab, detailMaterialListContent);
				ContractMaterialItemUI component = gameObject.GetComponent<ContractMaterialItemUI>();
				if (component != null)
				{
					component.InitializeForActiveContract(itemId, requiredCount, deliveredCount, _selectedActiveContract.activeId);
					_spawnedMaterialItems.Add(component);
				}
				else
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
		}
	}

	private void OnActiveContractCancelClicked(ActiveContractData contract)
	{
		contractManager?.RequestCancelContract(contract.activeId);
	}

	private string GetSellerOfferMessage(int amount)
	{
		return string.Format(LocalizationManager.GetTranslation(PlayerOfferKeys[UnityEngine.Random.Range(0, PlayerOfferKeys.Length)]), $"${amount:N0}");
	}

	public void ShowContractCompletedUI(ContractCompletionResult result)
	{
		if (contractCompletedUI != null)
		{
			contractCompletedUI.Show(result);
		}
	}
}
