using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerPropertyUI : MonoBehaviour
{
	public enum PropertyViewState
	{
		List = 0,
		Detail = 1,
		ActiveProperty = 2
	}

	[Header("References")]
	[Tooltip("ComputerPropertyManager referansı (otomatik bulunabilir)")]
	[SerializeField]
	private ComputerPropertyManager propertyManager;

	[Header("Factory Info")]
	[Tooltip("Para miktarı text'i")]
	[SerializeField]
	private TextMeshProUGUI moneyText;

	[Tooltip("Level text'i")]
	[SerializeField]
	private TextMeshProUGUI levelText;

	[Header("View Containers")]
	[Tooltip("Liste görünümü container'ı")]
	[SerializeField]
	private GameObject listViewContainer;

	[Tooltip("Detay görünümü container'ı")]
	[SerializeField]
	private GameObject detailViewContainer;

	[Tooltip("Aktif property görünümü container'ı")]
	[SerializeField]
	private GameObject activePropertyContainer;

	[Header("List View")]
	[Tooltip("PropertyItemUI prefab'ı (GameObject)")]
	[SerializeField]
	private GameObject propertyItemPrefab;

	[Tooltip("Property item'larının parent'ı (ScrollView Content)")]
	[SerializeField]
	private Transform propertyListContent;

	[Header("Detail View - Property Info")]
	[Tooltip("Detay - Emlak görseli")]
	[SerializeField]
	private Image detailPropertyImage;

	[Tooltip("Detay - Emlak ismi")]
	[SerializeField]
	private TextMeshProUGUI detailNameText;

	[Tooltip("Detay - Emlak adresi")]
	[SerializeField]
	private TextMeshProUGUI detailAddressText;

	[Tooltip("Detay - Emlak fiyatı")]
	[SerializeField]
	private TextMeshProUGUI detailPriceText;

	[Tooltip("Detay - Emlak boyutu")]
	[SerializeField]
	private TextMeshProUGUI detailSizeText;

	[Tooltip("Detay - Emlak türü")]
	[SerializeField]
	private TextMeshProUGUI detailTypeText;

	[Tooltip("Detay - Emlak level")]
	[SerializeField]
	private TextMeshProUGUI detailLevelText;

	[Header("Detail View - Layers")]
	[Tooltip("Tüm layer'ların parent container'ı (layout rebuild için)")]
	[SerializeField]
	private Transform detailMiningLayersContainer;

	[Tooltip("LayerItemUI prefab'ı (GameObject)")]
	[SerializeField]
	private GameObject layerItemPrefab;

	[Tooltip("Yüzey katmanı container'ı")]
	[SerializeField]
	private Transform surfaceLayerContent;

	[Tooltip("Yüzey katmanı başlık text'i (opsiyonel)")]
	[SerializeField]
	private TextMeshProUGUI surfaceLayerTitle;

	[Tooltip("Orta katman container'ı")]
	[SerializeField]
	private Transform middleLayerContent;

	[Tooltip("Orta katman başlık text'i (opsiyonel)")]
	[SerializeField]
	private TextMeshProUGUI middleLayerTitle;

	[Tooltip("Derin katman container'ı")]
	[SerializeField]
	private Transform deepLayerContent;

	[Tooltip("Derin katman başlık text'i (opsiyonel)")]
	[SerializeField]
	private TextMeshProUGUI deepLayerTitle;

	[Header("Detail View - Buttons")]
	[Tooltip("Detay - Pazarlık başlat butonu (interactable kontrolü için)")]
	[SerializeField]
	private Button negotiateButton;

	[Header("Active Property View - Property Info")]
	[Tooltip("Aktif - Emlak görseli")]
	[SerializeField]
	private Image activePropertyImage;

	[Tooltip("Aktif - Emlak ismi")]
	[SerializeField]
	private TextMeshProUGUI activeNameText;

	[Tooltip("Aktif - Emlak adresi/lokasyon")]
	[SerializeField]
	private TextMeshProUGUI activeLocationText;

	[Tooltip("Aktif - Emlak fiyatı (satın alınan)")]
	[SerializeField]
	private TextMeshProUGUI activePriceText;

	[Tooltip("Aktif - Emlak boyutu")]
	[SerializeField]
	private TextMeshProUGUI activeSizeText;

	[Tooltip("Aktif - Emlak türü text")]
	[SerializeField]
	private TextMeshProUGUI activeTypeText;

	[Tooltip("Aktif - Emlak türü ikonu")]
	[SerializeField]
	private Image activeTypeIcon;

	[Tooltip("Aktif - Konut ikonu")]
	[SerializeField]
	private Sprite activeResidentialIcon;

	[Tooltip("Aktif - Ticari ikon")]
	[SerializeField]
	private Sprite activeCommercialIcon;

	[Header("Active Property View - Layers")]
	[Tooltip("Tüm layer'ların parent container'ı (layout rebuild için)")]
	[SerializeField]
	private Transform activeMiningLayersContainer;

	[Tooltip("Aktif - Yüzey katmanı container'ı")]
	[SerializeField]
	private Transform activeSurfaceLayerContent;

	[Tooltip("Aktif - Yüzey katmanı başlık text'i")]
	[SerializeField]
	private TextMeshProUGUI activeSurfaceLayerTitle;

	[Tooltip("Aktif - Orta katman container'ı")]
	[SerializeField]
	private Transform activeMiddleLayerContent;

	[Tooltip("Aktif - Orta katman başlık text'i")]
	[SerializeField]
	private TextMeshProUGUI activeMiddleLayerTitle;

	[Tooltip("Aktif - Derin katman container'ı")]
	[SerializeField]
	private Transform activeDeepLayerContent;

	[Tooltip("Aktif - Derin katman başlık text'i")]
	[SerializeField]
	private TextMeshProUGUI activeDeepLayerTitle;

	[Header("Active Property View - Buttons")]
	[Tooltip("Aktif - Kazı alanına git butonu (interactable kontrolü için)")]
	[SerializeField]
	private Button goToPropertyButton;

	[Header("Remove Property Panel")]
	[Tooltip("Property kaldırma onay paneli")]
	[SerializeField]
	private GameObject removePropertyPanelContainer;

	[Tooltip("Remove Panel - Property görseli")]
	[SerializeField]
	private Image removePropertyImage;

	[Tooltip("Remove Panel - Property ismi")]
	[SerializeField]
	private TextMeshProUGUI removePropertyNameText;

	[Tooltip("Remove Panel - Property adresi")]
	[SerializeField]
	private TextMeshProUGUI removePropertyAddressText;

	[Header("Negotiation Chat Panel - Property Info")]
	[Tooltip("Pazarlık panel container'ı")]
	[SerializeField]
	private GameObject negotiationPanelContainer;

	[Tooltip("Chat - Property görseli")]
	[SerializeField]
	private Image chatPropertyImage;

	[Tooltip("Chat - Property ismi")]
	[SerializeField]
	private TextMeshProUGUI chatPropertyNameText;

	[Tooltip("Chat - Property adresi")]
	[SerializeField]
	private TextMeshProUGUI chatPropertyAddressText;

	[Header("Negotiation Chat Panel - Messages")]
	[Tooltip("Chat mesajları scroll content")]
	[SerializeField]
	private Transform chatContent;

	[Tooltip("Chat ScrollRect (Inspector'dan atanmalı)")]
	[SerializeField]
	private ScrollRect chatScrollRect;

	[Tooltip("Satıcı mesaj prefab'ı")]
	[SerializeField]
	private GameObject sellerMessagePrefab;

	[Tooltip("Alıcı mesaj prefab'ı")]
	[SerializeField]
	private GameObject buyerMessagePrefab;

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

	[Tooltip("Anlaşma kabul edildi göstergesi (GameObject)")]
	[SerializeField]
	private GameObject offerAcceptedIndicator;

	[Tooltip("Pazarlığı iptal butonu")]
	[SerializeField]
	private Button cancelNegotiationButton;

	[Header("Negotiation Chat Panel - Sound Effects")]
	[Tooltip("Satıcı mesaj sesi")]
	[SerializeField]
	private AudioClip sellerMessageSound;

	[Tooltip("Alıcı (oyuncu) mesaj sesi")]
	[SerializeField]
	private AudioClip buyerMessageSound;

	[Tooltip("Anlaşma kabul edildi sesi")]
	[SerializeField]
	private AudioClip acceptedMessageSound;

	[Tooltip("AudioSource (opsiyonel - yoksa otomatik oluşturulur)")]
	[SerializeField]
	private AudioSource chatAudioSource;

	private List<PropertyItemUI> _spawnedItems = new List<PropertyItemUI>();

	private List<LayerItemUI> _spawnedLayerItems = new List<LayerItemUI>();

	private Dictionary<T_ItemAreaSpawner.MiningLayer, List<LayerItemUI>> _spawnedActiveLayerItemsByLayer = new Dictionary<T_ItemAreaSpawner.MiningLayer, List<LayerItemUI>>();

	private List<NegotiationChatMessageUI> _spawnedChatMessages = new List<NegotiationChatMessageUI>();

	private GameObject _currentTypingIndicator;

	private int _purchasedPrice;

	private PropertyListingData _selectedProperty;

	private PropertyViewState _currentView;

	private int _currentSliderValue;

	private string _lastClosedNegotiationId;

	private bool _isWaitingForSellerResponse;

	private bool _isSettingUpSlider;

	private bool _isSendPriceTutorialRunning;

	private static readonly string[] PlayerOfferKeys = new string[5] { "ChatMessage_Property_PlayerOffer1", "ChatMessage_Property_PlayerOffer2", "ChatMessage_Property_PlayerOffer3", "ChatMessage_Property_PlayerOffer4", "ChatMessage_Property_PlayerOffer5" };

	public PropertyViewState CurrentView => _currentView;

	public PropertyListingData SelectedProperty => _selectedProperty;

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
		if (propertyManager == null)
		{
			propertyManager = ComputerPropertyManager.Instance;
		}
		if (chatAudioSource == null)
		{
			chatAudioSource = GetComponent<AudioSource>();
			if (chatAudioSource == null)
			{
				chatAudioSource = base.gameObject.AddComponent<AudioSource>();
				chatAudioSource.playOnAwake = false;
			}
		}
	}

	private void OnEnable()
	{
		SubscribeToEvents();
		SubscribeToFactoryEvents();
		RefreshUI();
		UpdateFactoryInfo();
	}

	private void OnDisable()
	{
		UnsubscribeFromEvents();
		UnsubscribeFromFactoryEvents();
	}

	private void SubscribeToEvents()
	{
		if (propertyManager == null)
		{
			propertyManager = ComputerPropertyManager.Instance;
		}
		if (propertyManager != null)
		{
			propertyManager.onPropertyListed.AddListener(OnPropertyListed);
			propertyManager.onPropertyDelisted.AddListener(OnPropertyDelisted);
			propertyManager.onPropertyPurchased.AddListener(OnPropertyPurchased);
			propertyManager.onActivePropertyCleared.AddListener(OnActivePropertyCleared);
			propertyManager.onNegotiationStarted.AddListener(OnNegotiationStarted);
			propertyManager.onNegotiationUpdated.AddListener(OnNegotiationUpdated);
			propertyManager.onNegotiationEnded.AddListener(OnNegotiationEnded);
			propertyManager.onMiningDataUpdated.AddListener(OnMiningDataUpdated);
		}
	}

	private void UnsubscribeFromEvents()
	{
		if (propertyManager != null)
		{
			propertyManager.onPropertyListed.RemoveListener(OnPropertyListed);
			propertyManager.onPropertyDelisted.RemoveListener(OnPropertyDelisted);
			propertyManager.onPropertyPurchased.RemoveListener(OnPropertyPurchased);
			propertyManager.onActivePropertyCleared.RemoveListener(OnActivePropertyCleared);
			propertyManager.onNegotiationStarted.RemoveListener(OnNegotiationStarted);
			propertyManager.onNegotiationUpdated.RemoveListener(OnNegotiationUpdated);
			propertyManager.onNegotiationEnded.RemoveListener(OnNegotiationEnded);
			propertyManager.onMiningDataUpdated.RemoveListener(OnMiningDataUpdated);
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

	private void OnFactoryMoneyChanged(int oldValue, int newValue)
	{
		UpdateMoneyText(newValue);
	}

	private void OnFactoryLevelChanged(int oldValue, int newValue)
	{
		UpdateLevelText(newValue);
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
		if (propertyManager == null)
		{
			propertyManager = ComputerPropertyManager.Instance;
			if (propertyManager == null)
			{
				Debug.LogWarning("[ComputerPropertyUI] PropertyManager bulunamadı!");
				return;
			}
		}
		if (listViewContainer != null)
		{
			listViewContainer.SetActive(value: true);
		}
		RefreshPropertyList();
		if (propertyManager.HasActiveProperty)
		{
			ShowActivePropertyView();
		}
		else if (activePropertyContainer != null)
		{
			activePropertyContainer.SetActive(value: false);
		}
		if (detailViewContainer != null)
		{
			detailViewContainer.SetActive(value: false);
		}
	}

	public void ShowListView()
	{
		_currentView = PropertyViewState.List;
		if (listViewContainer != null)
		{
			listViewContainer.SetActive(value: true);
		}
		if (detailViewContainer != null)
		{
			detailViewContainer.SetActive(value: false);
		}
		RefreshPropertyList();
	}

	public void ShowDetailView(PropertyListingData property)
	{
		_selectedProperty = property;
		_currentView = PropertyViewState.Detail;
		if (listViewContainer != null)
		{
			listViewContainer.SetActive(value: true);
		}
		if (detailViewContainer != null)
		{
			detailViewContainer.SetActive(value: true);
		}
		if ((propertyManager == null || !propertyManager.HasActiveProperty) && activePropertyContainer != null)
		{
			activePropertyContainer.SetActive(value: false);
		}
		UpdateDetailView();
	}

	public void HideDetailView()
	{
		if (detailViewContainer != null)
		{
			detailViewContainer.SetActive(value: false);
		}
		_currentView = ((propertyManager != null && propertyManager.HasActiveProperty) ? PropertyViewState.ActiveProperty : PropertyViewState.List);
	}

	public void ShowActivePropertyView()
	{
		if (propertyManager == null)
		{
			Debug.LogWarning("[ComputerPropertyUI] PropertyManager null!");
			return;
		}
		if (!propertyManager.HasActiveProperty)
		{
			Debug.LogWarning("[ComputerPropertyUI] Aktif property yok, view açılamıyor!");
			if (activePropertyContainer != null)
			{
				activePropertyContainer.SetActive(value: false);
			}
			return;
		}
		_currentView = PropertyViewState.ActiveProperty;
		if (listViewContainer != null)
		{
			listViewContainer.SetActive(value: true);
		}
		if (activePropertyContainer != null)
		{
			activePropertyContainer.SetActive(value: true);
		}
		else
		{
			Debug.LogWarning("[ComputerPropertyUI] activePropertyContainer null!");
		}
		UpdateActivePropertyView();
	}

	public void HideActivePropertyView()
	{
		if (activePropertyContainer != null)
		{
			activePropertyContainer.SetActive(value: false);
		}
	}

	private void RefreshPropertyList()
	{
		ClearPropertyList();
		if (propertyManager == null)
		{
			return;
		}
		foreach (PropertyListingData listedProperty in propertyManager.ListedProperties)
		{
			CreatePropertyItem(listedProperty);
		}
		Debug.Log($"[ComputerPropertyUI] {_spawnedItems.Count} property item oluşturuldu.");
	}

	private void CreatePropertyItem(PropertyListingData listing)
	{
		if (!(propertyItemPrefab == null) && !(propertyListContent == null))
		{
			GameObject gameObject = Object.Instantiate(propertyItemPrefab, propertyListContent);
			PropertyItemUI component = gameObject.GetComponent<PropertyItemUI>();
			if (component != null)
			{
				component.Initialize(listing, OnPropertyItemClicked);
				_spawnedItems.Add(component);
			}
			else
			{
				Debug.LogWarning("[ComputerPropertyUI] PropertyItemUI component bulunamadı!");
				Object.Destroy(gameObject);
			}
		}
	}

	private void ClearPropertyList()
	{
		foreach (PropertyItemUI spawnedItem in _spawnedItems)
		{
			if (spawnedItem != null)
			{
				Object.Destroy(spawnedItem.gameObject);
			}
		}
		_spawnedItems.Clear();
	}

	private void RemovePropertyItemFromList(string listingId)
	{
		for (int num = _spawnedItems.Count - 1; num >= 0; num--)
		{
			if (_spawnedItems[num] != null && _spawnedItems[num].ListingId == listingId)
			{
				Object.Destroy(_spawnedItems[num].gameObject);
				_spawnedItems.RemoveAt(num);
				break;
			}
		}
	}

	private void UpdateDetailView()
	{
		if (!_selectedProperty.IsValid)
		{
			return;
		}
		PropertyConfigSO config = propertyManager?.GetConfig(_selectedProperty.configId);
		if (detailNameText != null)
		{
			detailNameText.text = _selectedProperty.LocalizedName;
		}
		if (detailAddressText != null)
		{
			detailAddressText.text = _selectedProperty.LocalizedAddress;
		}
		if (detailPriceText != null)
		{
			detailPriceText.text = $"{_selectedProperty.basePrice:N0}";
		}
		if (detailSizeText != null)
		{
			detailSizeText.text = $"{_selectedProperty.size} m²";
		}
		if (detailTypeText != null)
		{
			detailTypeText.text = LocalizationManager.GetTranslation(_selectedProperty.propertyType);
		}
		if (detailLevelText != null)
		{
			string translation = LocalizationManager.GetTranslation("Level");
			LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, object> { 
			{
				"Number",
				_selectedProperty.propertyLevel.ToString()
			} });
			detailLevelText.text = translation;
		}
		if (detailPropertyImage != null)
		{
			Sprite visual = _selectedProperty.GetVisual(config);
			if (visual != null)
			{
				detailPropertyImage.sprite = visual;
				detailPropertyImage.gameObject.SetActive(value: true);
			}
			else
			{
				detailPropertyImage.gameObject.SetActive(value: false);
			}
		}
		UpdateLayerViews(config);
		UpdateNegotiateButtonState();
	}

	private void UpdateLayerViews(PropertyConfigSO config)
	{
		ClearLayerItems();
		if (!(config == null))
		{
			T_ItemSpawnProfile spawnProfile = _selectedProperty.GetSpawnProfile(config);
			if (!(spawnProfile == null))
			{
				PopulateLayerContent(spawnProfile.surface.items, surfaceLayerContent);
				PopulateLayerContent(spawnProfile.mid.items, middleLayerContent);
				PopulateLayerContent(spawnProfile.deep.items, deepLayerContent);
				StartCoroutine(ForceRebuildLayerLayoutsDelayed());
			}
		}
	}

	private IEnumerator ForceRebuildLayerLayoutsDelayed()
	{
		yield return null;
		RebuildAllChildLayouts(detailMiningLayersContainer);
		Canvas.ForceUpdateCanvases();
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
		RectTransform[] array = componentsInChildren;
		foreach (RectTransform rectTransform in array)
		{
			if (rectTransform != null && rectTransform.gameObject.activeInHierarchy)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
			}
		}
	}

	private void PopulateLayerContent(List<T_ItemSpawnProfile.WeightedSO> layerItems, Transform content)
	{
		if (content == null || layerItemPrefab == null || layerItems == null || layerItems.Count == 0)
		{
			return;
		}
		int num = 0;
		foreach (T_ItemSpawnProfile.WeightedSO layerItem in layerItems)
		{
			if (layerItem != null && layerItem.so != null)
			{
				num += layerItem.maxCount;
			}
		}
		foreach (T_ItemSpawnProfile.WeightedSO layerItem2 in layerItems)
		{
			if (layerItem2 != null && !(layerItem2.so == null))
			{
				float spawnRate = ((num > 0) ? ((float)layerItem2.maxCount / (float)num) : 0f);
				CreateLayerItem(layerItem2.so, spawnRate, content);
			}
		}
	}

	private void CreateLayerItem(T_ItemSO itemSO, float spawnRate, Transform parent)
	{
		if (!(layerItemPrefab == null) && !(parent == null) && !(itemSO == null))
		{
			GameObject gameObject = Object.Instantiate(layerItemPrefab, parent);
			LayerItemUI component = gameObject.GetComponent<LayerItemUI>();
			if (component != null)
			{
				component.Initialize(itemSO, spawnRate);
				_spawnedLayerItems.Add(component);
			}
			else
			{
				Debug.LogWarning("[ComputerPropertyUI] LayerItemUI component bulunamadı!");
				Object.Destroy(gameObject);
			}
		}
	}

	private void ClearLayerItems()
	{
		foreach (LayerItemUI spawnedLayerItem in _spawnedLayerItems)
		{
			if (spawnedLayerItem != null)
			{
				Object.Destroy(spawnedLayerItem.gameObject);
			}
		}
		_spawnedLayerItems.Clear();
	}

	private void UpdateNegotiateButtonState()
	{
		if (!(negotiateButton == null))
		{
			bool interactable = propertyManager != null && !propertyManager.HasActiveProperty && !propertyManager.HasActiveNegotiation;
			negotiateButton.interactable = interactable;
		}
	}

	private void UpdateActivePropertyView()
	{
		if (propertyManager == null || !propertyManager.HasActiveProperty)
		{
			return;
		}
		PropertyListingData activeProperty = propertyManager.ActiveProperty;
		PropertyConfigSO config = propertyManager.GetConfig(activeProperty.configId);
		if (activeNameText != null)
		{
			activeNameText.text = activeProperty.LocalizedName;
		}
		if (activeLocationText != null)
		{
			activeLocationText.text = activeProperty.LocalizedAddress;
		}
		if (activeSizeText != null)
		{
			activeSizeText.text = $"{activeProperty.size} m²";
		}
		if (activePriceText != null)
		{
			int num = ((propertyManager.PurchasedPrice > 0) ? propertyManager.PurchasedPrice : activeProperty.basePrice);
			activePriceText.text = $"{num:N0}";
		}
		if (activeTypeText != null)
		{
			activeTypeText.text = LocalizationManager.GetTranslation(activeProperty.propertyType);
		}
		if (activeTypeIcon != null)
		{
			activeTypeIcon.sprite = ((activeProperty.propertyType == PropertyType.Residential) ? activeResidentialIcon : activeCommercialIcon);
		}
		if (activePropertyImage != null)
		{
			Sprite visual = activeProperty.GetVisual(config);
			if (visual != null)
			{
				activePropertyImage.sprite = visual;
				activePropertyImage.gameObject.SetActive(value: true);
			}
			else
			{
				activePropertyImage.gameObject.SetActive(value: false);
			}
		}
		UpdateActiveLayerViews(config);
		if (goToPropertyButton != null)
		{
			goToPropertyButton.interactable = !string.IsNullOrEmpty(activeProperty.linkedSceneName);
		}
	}

	private void UpdateActiveLayerViews(PropertyConfigSO config)
	{
		ClearActiveLayerItems();
		if (!(config == null) && !(propertyManager == null) && propertyManager.HasActiveProperty)
		{
			T_ItemSpawnProfile spawnProfile = propertyManager.ActiveProperty.GetSpawnProfile(config);
			if (!(spawnProfile == null))
			{
				PopulateActiveLayerContent(spawnProfile.surface.items, activeSurfaceLayerContent, T_ItemAreaSpawner.MiningLayer.Surface);
				PopulateActiveLayerContent(spawnProfile.mid.items, activeMiddleLayerContent, T_ItemAreaSpawner.MiningLayer.Mid);
				PopulateActiveLayerContent(spawnProfile.deep.items, activeDeepLayerContent, T_ItemAreaSpawner.MiningLayer.Deep);
				RefreshActivePropertyLayerRates();
				StartCoroutine(ForceRebuildActiveLayerLayoutsDelayed());
			}
		}
	}

	private IEnumerator ForceRebuildActiveLayerLayoutsDelayed()
	{
		yield return null;
		RebuildAllChildLayouts(activeMiningLayersContainer);
		Canvas.ForceUpdateCanvases();
		RefreshActivePropertyLayerRates();
	}

	private void PopulateActiveLayerContent(List<T_ItemSpawnProfile.WeightedSO> layerItems, Transform content, T_ItemAreaSpawner.MiningLayer layer)
	{
		if (content == null || layerItemPrefab == null || layerItems == null || layerItems.Count == 0)
		{
			return;
		}
		int num = 0;
		foreach (T_ItemSpawnProfile.WeightedSO layerItem in layerItems)
		{
			if (layerItem != null && layerItem.so != null)
			{
				num += layerItem.maxCount;
			}
		}
		foreach (T_ItemSpawnProfile.WeightedSO layerItem2 in layerItems)
		{
			if (layerItem2 != null && !(layerItem2.so == null))
			{
				float spawnRate = ((num > 0) ? ((float)layerItem2.maxCount / (float)num) : 0f);
				CreateActiveLayerItem(layerItem2.so, spawnRate, content, layer);
			}
		}
	}

	private void CreateActiveLayerItem(T_ItemSO itemSO, float spawnRate, Transform parent, T_ItemAreaSpawner.MiningLayer layer)
	{
		if (layerItemPrefab == null || parent == null || itemSO == null)
		{
			return;
		}
		GameObject gameObject = Object.Instantiate(layerItemPrefab, parent);
		LayerItemUI component = gameObject.GetComponent<LayerItemUI>();
		if (component != null)
		{
			component.Initialize(itemSO, spawnRate);
			if (!_spawnedActiveLayerItemsByLayer.ContainsKey(layer))
			{
				_spawnedActiveLayerItemsByLayer[layer] = new List<LayerItemUI>();
			}
			_spawnedActiveLayerItemsByLayer[layer].Add(component);
		}
		else
		{
			Debug.LogWarning("[ComputerPropertyUI] LayerItemUI component bulunamadı!");
			Object.Destroy(gameObject);
		}
	}

	private void ClearActiveLayerItems()
	{
		foreach (KeyValuePair<T_ItemAreaSpawner.MiningLayer, List<LayerItemUI>> item in _spawnedActiveLayerItemsByLayer)
		{
			foreach (LayerItemUI item2 in item.Value)
			{
				if (item2 != null)
				{
					Object.Destroy(item2.gameObject);
				}
			}
		}
		_spawnedActiveLayerItemsByLayer.Clear();
	}

	private void ClearActivePropertyUI()
	{
		if (activeNameText != null)
		{
			activeNameText.text = "";
		}
		if (activeLocationText != null)
		{
			activeLocationText.text = "";
		}
		if (activeSizeText != null)
		{
			activeSizeText.text = "";
		}
		if (activePriceText != null)
		{
			activePriceText.text = "";
		}
		if (activeTypeText != null)
		{
			activeTypeText.text = "";
		}
		if (activePropertyImage != null)
		{
			activePropertyImage.sprite = null;
			activePropertyImage.gameObject.SetActive(value: false);
		}
		if (activeTypeIcon != null)
		{
			activeTypeIcon.sprite = null;
		}
		ClearActiveLayerItems();
	}

	private void OnMiningDataUpdated()
	{
		if (_spawnedActiveLayerItemsByLayer.Count > 0)
		{
			RefreshActivePropertyLayerRates();
		}
	}

	private void RefreshActivePropertyLayerRates()
	{
		if (propertyManager == null)
		{
			return;
		}
		Dictionary<T_ItemAreaSpawner.MiningLayer, Dictionary<string, (int, int)>> allMiningDataByLayer = propertyManager.GetAllMiningDataByLayer();
		if (allMiningDataByLayer == null || allMiningDataByLayer.Count == 0)
		{
			Debug.Log($"[ComputerPropertyUI] RefreshActivePropertyLayerRates - Mining data boş! isServer={propertyManager.isServer}");
			return;
		}
		Debug.Log($"[ComputerPropertyUI] RefreshActivePropertyLayerRates - {allMiningDataByLayer.Count} katman verisi bulundu, {_spawnedActiveLayerItemsByLayer.Count} layer item grubu var");
		foreach (KeyValuePair<T_ItemAreaSpawner.MiningLayer, List<LayerItemUI>> item in _spawnedActiveLayerItemsByLayer)
		{
			T_ItemAreaSpawner.MiningLayer key = item.Key;
			List<LayerItemUI> value = item.Value;
			if (!allMiningDataByLayer.TryGetValue(key, out var value2) || value2 == null || value2.Count == 0)
			{
				continue;
			}
			foreach (LayerItemUI item2 in value)
			{
				if (!(item2 == null) && !(item2.ItemSO == null))
				{
					string itemID = item2.ItemSO.GetItemID();
					if (value2.TryGetValue(itemID, out var value3))
					{
						item2.UpdateRemainingCount(value3.Item2);
					}
				}
			}
		}
	}

	private void OnPropertyListed(PropertyListingData listing)
	{
		if (_currentView == PropertyViewState.List)
		{
			RefreshPropertyList();
		}
	}

	private void OnPropertyDelisted(PropertyListingData listing)
	{
		RemovePropertyItemFromList(listing.listingId);
		if (_currentView == PropertyViewState.Detail && _selectedProperty.listingId == listing.listingId)
		{
			ShowListView();
		}
	}

	private void OnPropertyPurchased(PropertyListingData listing)
	{
		if (propertyManager != null)
		{
			_purchasedPrice = propertyManager.PurchasedPrice;
		}
		else
		{
			_purchasedPrice = listing.basePrice;
		}
		HideDetailView();
		RefreshPropertyList();
		StartCoroutine(ShowActivePropertyViewDelayed());
	}

	private IEnumerator ShowActivePropertyViewDelayed()
	{
		yield return null;
		ShowActivePropertyView();
	}

	private void OnActivePropertyCleared()
	{
		_purchasedPrice = 0;
		ClearActiveLayerItems();
		ClearActivePropertyUI();
		if (activePropertyContainer != null)
		{
			activePropertyContainer.SetActive(value: false);
		}
		RefreshPropertyList();
		UpdateNegotiateButtonState();
		_currentView = PropertyViewState.List;
	}

	private void OnNegotiationStarted(PropertyNegotiationData negotiation)
	{
		UpdateNegotiateButtonState();
		if (NetworkServer.active)
		{
			ShowNegotiationPanel(negotiation);
		}
	}

	private void OnNegotiationUpdated(PropertyNegotiationData negotiation)
	{
		if (NetworkServer.active)
		{
			if (negotiation.state == NegotiationState.Accepted)
			{
				StartCoroutine(AddSellerMessageWithTypingIndicatorForAccepted(negotiation.sellerMessage));
			}
			else
			{
				StartCoroutine(AddSellerMessageWithTypingIndicator(negotiation.sellerMessage, negotiation));
			}
		}
	}

	private void OnNegotiationEnded(PropertyNegotiationData negotiation)
	{
		UpdateNegotiateButtonState();
		if (NetworkServer.active)
		{
			if (negotiation.listingId == _lastClosedNegotiationId && negotiation.state == NegotiationState.Rejected)
			{
				_lastClosedNegotiationId = null;
			}
			else if (negotiation.state == NegotiationState.Rejected)
			{
				StartCoroutine(AddSellerMessageWithTypingIndicatorEnd(negotiation.sellerMessage, negotiation));
			}
		}
	}

	private IEnumerator AddSellerMessageWithTypingIndicatorForAccepted(string message)
	{
		if (IsNegotiationPanelOpen)
		{
			ShowTypingIndicator();
			float seconds = Random.Range(0.75f, 1.5f);
			yield return new WaitForSeconds(seconds);
			if (IsNegotiationPanelOpen)
			{
				HideTypingIndicator();
				AddSellerMessageWithAcceptedSound(message);
				_isWaitingForSellerResponse = false;
				UpdateNegotiationButtonsForAccepted();
			}
		}
	}

	private IEnumerator AddSellerMessageWithTypingIndicator(string message, PropertyNegotiationData negotiation)
	{
		if (!IsNegotiationPanelOpen)
		{
			yield break;
		}
		ShowTypingIndicator();
		float seconds = Random.Range(0.75f, 1.5f);
		yield return new WaitForSeconds(seconds);
		if (IsNegotiationPanelOpen)
		{
			HideTypingIndicator();
			AddSellerMessage(message);
			_isWaitingForSellerResponse = false;
			if (sendOfferButton != null && negotiation.state == NegotiationState.InProgress)
			{
				sendOfferButton.interactable = true;
			}
			UpdateNegotiationButtonStates(negotiation);
		}
	}

	private IEnumerator AddSellerMessageWithTypingIndicatorEnd(string message, PropertyNegotiationData negotiation)
	{
		if (!IsNegotiationPanelOpen)
		{
			yield break;
		}
		ShowTypingIndicator();
		float seconds = Random.Range(2f, 4f);
		yield return new WaitForSeconds(seconds);
		if (!IsNegotiationPanelOpen)
		{
			yield break;
		}
		HideTypingIndicator();
		AddSellerMessage(message);
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
			_currentTypingIndicator = Object.Instantiate(typingIndicatorPrefab, chatContent);
			ScrollChatToBottom();
		}
	}

	private void HideTypingIndicator()
	{
		if (_currentTypingIndicator != null)
		{
			Object.Destroy(_currentTypingIndicator);
			_currentTypingIndicator = null;
		}
	}

	private void ShowNegotiationPanel(PropertyNegotiationData negotiation)
	{
		if (!(negotiationPanelContainer == null))
		{
			_lastClosedNegotiationId = null;
			_isWaitingForSellerResponse = false;
			StopAllNegotiationCoroutines();
			HideTypingIndicator();
			ClearChatMessages();
			negotiationPanelContainer.SetActive(value: true);
			UpdateChatPropertyInfo();
			SetupPriceSlider(negotiation);
			if (offerAcceptedIndicator != null)
			{
				offerAcceptedIndicator.SetActive(value: false);
			}
			if (sendOfferButton != null)
			{
				sendOfferButton.gameObject.SetActive(value: true);
			}
			AddSellerMessage(negotiation.sellerMessage);
			UpdateNegotiationButtonStates(negotiation);
		}
	}

	private void UpdateChatPropertyInfo()
	{
		if (!_selectedProperty.IsValid)
		{
			return;
		}
		PropertyConfigSO config = propertyManager?.GetConfig(_selectedProperty.configId);
		if (chatPropertyNameText != null)
		{
			chatPropertyNameText.text = _selectedProperty.LocalizedName;
		}
		if (chatPropertyAddressText != null)
		{
			chatPropertyAddressText.text = _selectedProperty.LocalizedAddress;
		}
		if (chatPropertyImage != null)
		{
			Sprite visual = _selectedProperty.GetVisual(config);
			if (visual != null)
			{
				chatPropertyImage.sprite = visual;
				chatPropertyImage.gameObject.SetActive(value: true);
			}
			else
			{
				chatPropertyImage.gameObject.SetActive(value: false);
			}
		}
	}

	public void HideNegotiationPanel()
	{
		StopAllNegotiationCoroutines();
		HideTypingIndicator();
		_isWaitingForSellerResponse = false;
		if (propertyManager != null && propertyManager.HasActiveNegotiation)
		{
			PropertyNegotiationData currentNegotiation = propertyManager.CurrentNegotiation;
			if (currentNegotiation.state == NegotiationState.InProgress || currentNegotiation.state == NegotiationState.FinalOffer)
			{
				_lastClosedNegotiationId = currentNegotiation.listingId;
				propertyManager.RequestCancelNegotiation();
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

	private void SetupPriceSlider(PropertyNegotiationData negotiation)
	{
		if (!(priceSlider == null))
		{
			_isSettingUpSlider = true;
			int num = 10;
			int num2 = negotiation.rejectThreshold / num * num;
			int num3 = negotiation.basePrice / num * num;
			priceSlider.minValue = num2;
			priceSlider.maxValue = num3;
			priceSlider.wholeNumbers = true;
			int num4 = num3;
			priceSlider.value = num4;
			_currentSliderValue = num4;
			UpdateSliderValueText();
			_isSettingUpSlider = false;
		}
	}

	private void UpdateSliderValueText()
	{
		if (sliderValueText != null)
		{
			sliderValueText.text = $"{_currentSliderValue:N0}";
		}
	}

	private void UpdateNegotiationButtonStates(PropertyNegotiationData negotiation)
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
	}

	private void AddSellerMessage(string message)
	{
		if (!(sellerMessagePrefab == null) && !(chatContent == null) && !string.IsNullOrEmpty(message))
		{
			NegotiationChatMessageUI component = Object.Instantiate(sellerMessagePrefab, chatContent).GetComponent<NegotiationChatMessageUI>();
			if (component != null)
			{
				component.Initialize(message, isSeller: true);
				_spawnedChatMessages.Add(component);
			}
			PlayChatSound(sellerMessageSound);
			ScrollChatToBottom();
		}
	}

	private void AddSellerMessageWithAcceptedSound(string message)
	{
		if (!(sellerMessagePrefab == null) && !(chatContent == null) && !string.IsNullOrEmpty(message))
		{
			NegotiationChatMessageUI component = Object.Instantiate(sellerMessagePrefab, chatContent).GetComponent<NegotiationChatMessageUI>();
			if (component != null)
			{
				component.Initialize(message, isSeller: true);
				_spawnedChatMessages.Add(component);
			}
			PlayChatSound(acceptedMessageSound);
			ScrollChatToBottom();
		}
	}

	private void AddBuyerMessage(string message)
	{
		if (!(buyerMessagePrefab == null) && !(chatContent == null))
		{
			NegotiationChatMessageUI component = Object.Instantiate(buyerMessagePrefab, chatContent).GetComponent<NegotiationChatMessageUI>();
			if (component != null)
			{
				component.Initialize(message, isSeller: false);
				_spawnedChatMessages.Add(component);
			}
			PlayChatSound(buyerMessageSound);
			ScrollChatToBottom();
		}
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
				Object.Destroy(spawnedChatMessage.gameObject);
			}
		}
		_spawnedChatMessages.Clear();
	}

	private void PlayChatSound(AudioClip clip)
	{
		if (!(clip == null) && !(chatAudioSource == null))
		{
			chatAudioSource.PlayOneShot(clip);
		}
	}

	public void OnNegotiateButtonClicked()
	{
		if (!NetworkServer.active)
		{
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
		}
		else if (GameManager.Instance != null && GameManager.Instance.dayNightManager.IsNighttime)
		{
			Debug.LogWarning("[ComputerContractManager] Gece Negotiation başlatılamaz!");
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Too Late For This Action"), isComputer: true);
			}
		}
		else if (_selectedProperty.IsValid)
		{
			TutorialManager.Instance?.TryCompleteSubStep(TutorialConfigType.Property, TutorialStepType.BuyProperty, TutorialSubStepType.OpenOffer);
			propertyManager?.RequestStartNegotiation(_selectedProperty.listingId);
		}
	}

	public void OnDetailBackButtonClicked()
	{
		HideDetailView();
	}

	public void OnGoToPropertyButtonClicked()
	{
		if (!(propertyManager == null) && propertyManager.HasActiveProperty)
		{
			PropertyListingData activeProperty = propertyManager.ActiveProperty;
			if (string.IsNullOrEmpty(activeProperty.linkedSceneName))
			{
				Debug.LogWarning("[ComputerPropertyUI] Bağlantılı scene bulunamadı!");
			}
			else if (PropertyLoader.Instance != null)
			{
				PropertyLoader.Instance.LoadProperty(activeProperty.linkedSceneName);
			}
			else
			{
				Debug.LogWarning("[ComputerPropertyUI] PropertyLoader bulunamadı!");
			}
		}
	}

	public void OnRemovePropertyButtonClicked()
	{
		if (!NetworkServer.active)
		{
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
		}
		else if (TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning)
		{
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_NotAvailableDuringTutorial"), isComputer: true);
			}
		}
		else if (IsAnyVehicleInDigsite())
		{
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_VehicleInDigsite_CannotRemoveProperty"), isComputer: true);
		}
		else if (!(propertyManager == null) && propertyManager.HasActiveProperty)
		{
			ShowRemovePropertyPanel();
		}
	}

	private bool IsAnyVehicleInDigsite()
	{
		foreach (SCC_Network allVehicle in SCC_Network.AllVehicles)
		{
			if (allVehicle != null && allVehicle.isInDigsite)
			{
				return true;
			}
		}
		return false;
	}

	private void ShowRemovePropertyPanel()
	{
		if (!(removePropertyPanelContainer == null))
		{
			removePropertyPanelContainer.SetActive(value: true);
			UpdateRemovePropertyPanelInfo();
		}
	}

	private void UpdateRemovePropertyPanelInfo()
	{
		if (propertyManager == null || !propertyManager.HasActiveProperty)
		{
			return;
		}
		PropertyListingData activeProperty = propertyManager.ActiveProperty;
		PropertyConfigSO config = propertyManager.GetConfig(activeProperty.configId);
		if (removePropertyNameText != null)
		{
			removePropertyNameText.text = activeProperty.LocalizedName;
		}
		if (removePropertyAddressText != null)
		{
			removePropertyAddressText.text = activeProperty.LocalizedAddress;
		}
		if (removePropertyImage != null)
		{
			Sprite visual = activeProperty.GetVisual(config);
			if (visual != null)
			{
				removePropertyImage.sprite = visual;
				removePropertyImage.gameObject.SetActive(value: true);
			}
			else
			{
				removePropertyImage.gameObject.SetActive(value: false);
			}
		}
	}

	public void HideRemovePropertyPanel()
	{
		if (removePropertyPanelContainer != null)
		{
			removePropertyPanelContainer.SetActive(value: false);
		}
	}

	public void OnCloseRemovePropertyPanelClicked()
	{
		HideRemovePropertyPanel();
	}

	public void OnConfirmRemovePropertyClicked()
	{
		if (!NetworkServer.active)
		{
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
		}
		else if (!(propertyManager == null) && propertyManager.HasActiveProperty)
		{
			HideRemovePropertyPanel();
			if (PropertyLoader.Instance != null && PropertyLoader.Instance.IsPropertyLoaded)
			{
				PropertyLoader.Instance.UnloadProperty();
			}
			propertyManager.RequestClearActiveProperty();
			_purchasedPrice = 0;
			ClearActiveLayerItems();
			ClearActivePropertyUI();
			if (activePropertyContainer != null)
			{
				activePropertyContainer.SetActive(value: false);
			}
			_currentView = PropertyViewState.List;
			UpdateNegotiateButtonState();
		}
	}

	public void OnSliderValueChanged()
	{
		if (!(priceSlider == null))
		{
			int num = 10;
			_currentSliderValue = Mathf.RoundToInt(priceSlider.value / (float)num) * num;
			priceSlider.SetValueWithoutNotify(_currentSliderValue);
			UpdateSliderValueText();
			if (!_isSettingUpSlider && TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning && !_isSendPriceTutorialRunning)
			{
				_isSendPriceTutorialRunning = true;
				StartCoroutine(CompleteSendPriceTutorialWithDelay());
			}
		}
	}

	private IEnumerator CompleteSendPriceTutorialWithDelay()
	{
		yield return new WaitForSeconds(2f);
		TutorialManager.Instance?.TryCompleteSubStep(TutorialConfigType.Property, TutorialStepType.BuyProperty, TutorialSubStepType.SendPrice);
	}

	public void OnSendOfferButtonClicked()
	{
		if (!NetworkServer.active)
		{
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
		}
		else
		{
			if (propertyManager == null || !propertyManager.HasActiveNegotiation || _isWaitingForSellerResponse)
			{
				return;
			}
			TutorialManager.Instance?.TryCompleteSubStep(TutorialConfigType.Property, TutorialStepType.BuyProperty, TutorialSubStepType.SendOffer);
			if (FactoryManager.Instance != null && FactoryManager.Instance.Money < _currentSliderValue)
			{
				NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_InsufficientBalance_CannotSendOffer"), isComputer: true);
				Debug.LogWarning($"[ComputerPropertyUI] Yetersiz bakiye! Teklif: ${_currentSliderValue:N0}, Mevcut: ${FactoryManager.Instance.Money:N0}");
				return;
			}
			_isWaitingForSellerResponse = true;
			if (sendOfferButton != null)
			{
				sendOfferButton.interactable = false;
			}
			AddBuyerMessage(GetBuyerOfferMessage(_currentSliderValue));
			propertyManager.RequestMakeOffer(_currentSliderValue);
		}
	}

	public void OnCancelNegotiationButtonClicked()
	{
		HideNegotiationPanel();
	}

	private void OnPropertyItemClicked(PropertyListingData listing)
	{
		ShowDetailView(listing);
	}

	private string GetBuyerOfferMessage(int amount)
	{
		return string.Format(LocalizationManager.GetTranslation(PlayerOfferKeys[Random.Range(0, PlayerOfferKeys.Length)]), $"${amount:N0}");
	}
}
