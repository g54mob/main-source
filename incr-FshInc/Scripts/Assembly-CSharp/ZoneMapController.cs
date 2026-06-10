using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class ZoneMapController : MonoBehaviour
{
	[Header("Data")]
	public List<ZoneData> allZones;

	[Header("Materials")]
	public List<Material> zoneMaterials;

	public Material fishSilhouetteMaterial;

	public Color lockedIconColor = Color.gray;

	[Header("Zone Price Colors")]
	public Color canAffordColor = new Color(0.75f, 1f, 0.75f);

	public Color cannotAffordColor = new Color(1f, 0.75f, 0.75f);

	[Header("Level Previews")]
	public List<Image> levelPreviewPanels;

	[Header("Prefabs & Containers")]
	public ZoneMapNode nodePrefab;

	public RectTransform nodesContainer;

	public RectTransform viewportCenter;

	[Header("UI - The Card")]
	public TextMeshProUGUI zoneNameText;

	public Image zoneIconImage;

	public TextMeshProUGUI zoneStatsText;

	public Button actionButton;

	public TextMeshProUGUI actionButtonText;

	public TMP_Text passiveIncomeText;

	public GameObject fishPreviewPrefab;

	public RectTransform fishPreviewContainer;

	public Image xpBarImage;

	public TMP_Text currentLevelXpText;

	public TMP_Text nextLevelXpText;

	public TMP_Text xPProgressText;

	[Header("UI - Navigation")]
	public Button leftArrowBtn;

	public Button rightArrowBtn;

	[Header("Notifications")]
	[Tooltip("Notification shown on the zone map when the player can afford a new zone.")]
	public GameObject mapAffordNotification;

	[Tooltip("Notification shown on the zone card when the player can afford a new zone.")]
	public GameObject cardAffordNotification;

	[Header("Animation Settings")]
	public float scrollSpeed = 10f;

	private int _currentIndex;

	private List<ZoneMapNode> _spawnedNodes = new List<ZoneMapNode>();

	private Vector2 _targetPosition;

	private bool _initComplete;

	private Dictionary<Material, Material> _desaturatedMaterialsCache = new Dictionary<Material, Material>();

	public static ZoneMapController Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private IEnumerator Start()
	{
		GenerateMap();
		leftArrowBtn.onClick.RemoveAllListeners();
		rightArrowBtn.onClick.RemoveAllListeners();
		actionButton.onClick.RemoveAllListeners();
		leftArrowBtn.onClick.AddListener(PrevZone);
		rightArrowBtn.onClick.AddListener(NextZone);
		actionButton.onClick.AddListener(OnActionClicked);
		yield return new WaitForEndOfFrame();
		LayoutRebuilder.ForceRebuildLayoutImmediate(nodesContainer);
		int value = PlayerPrefs.GetInt("LastSelectedZone", 0);
		value = Mathf.Clamp(value, 0, allZones.Count - 1);
		SelectZone(value, instant: true);
		_initComplete = true;
		GameManager instance = GameManager.Instance;
		instance.OnMoneyChanged = (Action<double>)Delegate.Combine(instance.OnMoneyChanged, new Action<double>(OnMoneyChanged));
		UpdateAffordNotifications();
	}

	private void OnDestroy()
	{
		if (GameManager.Instance != null)
		{
			GameManager instance = GameManager.Instance;
			instance.OnMoneyChanged = (Action<double>)Delegate.Remove(instance.OnMoneyChanged, new Action<double>(OnMoneyChanged));
		}
		if (mapAffordNotification != null)
		{
			mapAffordNotification.transform.DOKill();
		}
		if (cardAffordNotification != null)
		{
			cardAffordNotification.transform.DOKill();
		}
	}

	private void OnMoneyChanged(double newMoney)
	{
		if (_currentIndex >= 0 && _currentIndex < allZones.Count)
		{
			ZoneData zoneData = allZones[_currentIndex];
			if (!zoneData.isUnlocked)
			{
				double effectiveZoneUnlockCost = GameManager.Instance.GetEffectiveZoneUnlockCost(zoneData);
				bool flag = newMoney >= effectiveZoneUnlockCost;
				actionButtonText.color = (flag ? canAffordColor : cannotAffordColor);
				UpdateAffordNotifications();
			}
		}
	}

	private Material GetDesaturatedMaterial(Material originalMat)
	{
		if (originalMat == null)
		{
			return null;
		}
		if (!_desaturatedMaterialsCache.ContainsKey(originalMat))
		{
			Material material = new Material(originalMat);
			material.SetFloat("_Saturation", 0f);
			_desaturatedMaterialsCache[originalMat] = material;
		}
		return _desaturatedMaterialsCache[originalMat];
	}

	private void Update()
	{
		if (_initComplete)
		{
			nodesContainer.anchoredPosition = Vector2.Lerp(nodesContainer.anchoredPosition, _targetPosition, Time.deltaTime * scrollSpeed);
		}
	}

	private void GenerateMap()
	{
		foreach (Transform item in nodesContainer)
		{
			if (item.name != "mapBGLight")
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
		}
		_spawnedNodes.Clear();
		for (int i = 0; i < allZones.Count; i++)
		{
			ZoneMapNode zoneMapNode = UnityEngine.Object.Instantiate(nodePrefab, nodesContainer);
			bool isLastNode = i == allZones.Count - 1;
			Material material = null;
			if (zoneMaterials != null && zoneMaterials.Count > 0)
			{
				Material material2 = zoneMaterials[i % zoneMaterials.Count];
				material = (allZones[i].isUnlocked ? material2 : GetDesaturatedMaterial(material2));
			}
			if (levelPreviewPanels != null && i < levelPreviewPanels.Count && levelPreviewPanels[i] != null)
			{
				levelPreviewPanels[i].material = material;
			}
			zoneMapNode.Setup(allZones[i], i, isLastNode, this, material);
			_spawnedNodes.Add(zoneMapNode);
		}
	}

	public void NextZone()
	{
		SelectZone(_currentIndex + 1);
	}

	public void PrevZone()
	{
		SelectZone(_currentIndex - 1);
	}

	public void SelectZone(int index)
	{
		SelectZone(index, instant: false);
	}

	public void SelectZone(int index, bool instant)
	{
		if (index < 0 || index >= allZones.Count)
		{
			return;
		}
		if (!instant && _initComplete && index != _currentIndex)
		{
			bool flag = index > _currentIndex;
			int num = (flag ? _currentIndex : index);
			if (num >= 0 && num < _spawnedNodes.Count && _spawnedNodes[num].gameObject.activeInHierarchy)
			{
				_spawnedNodes[num].AnimateTravelDots(flag);
			}
		}
		_currentIndex = index;
		PlayerPrefs.SetInt("LastSelectedZone", _currentIndex);
		PlayerPrefs.Save();
		UpdateCardUI();
		UpdateMapVisuals();
		UpdateAffordNotifications();
		CenterMapOnNode(index, instant);
	}

	private void CenterMapOnNode(int index, bool instant)
	{
		if (_spawnedNodes.Count != 0)
		{
			RectTransform component = _spawnedNodes[index].GetComponent<RectTransform>();
			float num = ((viewportCenter != null) ? viewportCenter.rect.width : ((float)Screen.width)) / 2f;
			float x = 0f - component.anchoredPosition.x + num;
			_targetPosition = new Vector2(x, nodesContainer.anchoredPosition.y);
			if (instant)
			{
				nodesContainer.anchoredPosition = _targetPosition;
			}
		}
	}

	private void UpdateCardUI()
	{
		ZoneData zoneData = allZones[_currentIndex];
		LocalizedString localizedString = new LocalizedString("Skills", "#ui.hud.income.text");
		LocalizedString localizedString2 = new LocalizedString("Skills", "#ui.unit.per_sec");
		LocalizedString localizedString3 = new LocalizedString("Skills", "#ui.hud.go.fish.text");
		LocalizedString localizedString4 = new LocalizedString("Skills", "#ui.unit.gold");
		string text = zoneData.zoneName.Trim().ToLowerInvariant().Replace(" ", ".");
		string text2 = "#ui.zone." + text + ".title";
		LocalizedString localizedString5 = new LocalizedString("Skills", text2);
		string text3 = localizedString5.GetLocalizedString();
		if (string.IsNullOrWhiteSpace(text3) || text3 == text2)
		{
			text3 = zoneData.zoneName;
		}
		zoneNameText.text = (zoneData.isUnlocked ? text3 : "????");
		zoneIconImage.sprite = zoneData.zoneIcon;
		if (zoneMaterials != null && zoneMaterials.Count > 0)
		{
			Material material = zoneMaterials[_currentIndex % zoneMaterials.Count];
			zoneIconImage.material = (zoneData.isUnlocked ? material : GetDesaturatedMaterial(material));
		}
		else
		{
			zoneIconImage.material = null;
		}
		float currentPassiveIncome = zoneData.GetCurrentPassiveIncome();
		string text4 = ((currentPassiveIncome >= 1000f) ? CurrencyFormatter.FormatMoneyPrecise(currentPassiveIncome) : currentPassiveIncome.ToString("G2"));
		zoneStatsText.text = localizedString5.GetLocalizedString(zoneData.currentLevel) + "\n " + localizedString.GetLocalizedString(text4) + localizedString2.GetLocalizedString();
		passiveIncomeText.text = "<size=75%>" + localizedString.GetLocalizedString(text4) + localizedString2.GetLocalizedString() + "</size>";
		if (zoneData.isUnlocked)
		{
			actionButtonText.text = localizedString3.GetLocalizedString();
			actionButtonText.color = Color.white;
		}
		else
		{
			double effectiveZoneUnlockCost = GameManager.Instance.GetEffectiveZoneUnlockCost(zoneData);
			actionButtonText.text = CurrencyFormatter.FormatMoneyPrecise(effectiveZoneUnlockCost) + " " + localizedString4.GetLocalizedString();
			bool flag = GameManager.Instance.totalMoney >= effectiveZoneUnlockCost;
			actionButtonText.color = (flag ? canAffordColor : cannotAffordColor);
		}
		foreach (Transform item in fishPreviewContainer)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		int num = 0;
		foreach (FishEncounterData possibleCatch in zoneData.possibleCatches)
		{
			GameObject obj = UnityEngine.Object.Instantiate(fishPreviewPrefab, fishPreviewContainer);
			obj.transform.DOPunchScale(Vector3.one * 0.2f, 0.2f, 1, 0.2f).SetDelay((float)num * 0.04f).SetEase(Ease.OutBounce);
			Image component = obj.transform.Find("icon").GetComponent<Image>();
			component.sprite = possibleCatch.fishSpecies.availableRarities[0].artwork;
			Shadow component2 = component.GetComponent<Shadow>();
			bool flag2 = false;
			if (FishLogManager.Instance != null)
			{
				flag2 = FishLogManager.Instance.HasCaughtSpecies(possibleCatch.fishSpecies.speciesName);
			}
			if (!zoneData.isUnlocked || !flag2)
			{
				if (fishSilhouetteMaterial != null)
				{
					component.material = fishSilhouetteMaterial;
				}
				if (component2 != null)
				{
					component2.enabled = false;
				}
			}
			else
			{
				component.material = null;
				if (component2 != null)
				{
					component2.enabled = true;
				}
			}
			num++;
		}
		actionButton.interactable = true;
		leftArrowBtn.interactable = _currentIndex > 0;
		rightArrowBtn.interactable = _currentIndex < allZones.Count - 1;
		LocalizedString localizedString6 = new LocalizedString("Skills", "#ui.fishlog.xpbar.text");
		float levelProgressCof = zoneData.GetLevelProgressCof();
		xpBarImage.DOKill();
		xpBarImage.DOFillAmount(levelProgressCof, 0.5f).SetEase(Ease.InBack);
		zoneIconImage.transform.DOKill();
		zoneIconImage.transform.localScale = Vector3.one;
		zoneIconImage.transform.DOPunchScale(new Vector3(0.15f, 0.15f, 0.15f), 0.3f, 4, 0.5f);
		SoundManager.PlaySound("Tooltip_Pop");
		currentLevelXpText.text = zoneData.currentLevel.ToString();
		nextLevelXpText.text = (zoneData.currentLevel + 1).ToString();
		xPProgressText.text = localizedString6.GetLocalizedString(zoneData.currentXp, zoneData.GetXpForNextLevel());
	}

	private void UpdateMapVisuals()
	{
		for (int i = 0; i < _spawnedNodes.Count; i++)
		{
			_spawnedNodes[i].SetSelected(i == _currentIndex);
		}
	}

	private void UpdateAffordNotifications()
	{
		bool show = MenuUIManager.CanAffordAnyLockedZone();
		SetNotificationState(mapAffordNotification, show);
		bool show2 = false;
		if (_currentIndex >= 0 && _currentIndex < allZones.Count)
		{
			ZoneData zoneData = allZones[_currentIndex];
			if (!zoneData.isUnlocked)
			{
				double effectiveZoneUnlockCost = GameManager.Instance.GetEffectiveZoneUnlockCost(zoneData);
				show2 = GameManager.Instance.totalMoney >= effectiveZoneUnlockCost;
			}
		}
		SetNotificationState(cardAffordNotification, show2);
		foreach (ZoneMapNode spawnedNode in _spawnedNodes)
		{
			spawnedNode.UpdateAffordNotification();
		}
	}

	private void SetNotificationState(GameObject indicator, bool show)
	{
		if (indicator == null)
		{
			return;
		}
		if (show)
		{
			indicator.transform.DOKill();
			indicator.SetActive(value: true);
			indicator.transform.localScale = Vector3.one;
		}
		else if (indicator.activeSelf)
		{
			indicator.transform.DOKill();
			indicator.transform.DOScale(0f, 0.3f).SetEase(Ease.InBack).OnComplete(delegate
			{
				indicator.SetActive(value: false);
				indicator.transform.localScale = Vector3.one;
			});
		}
		else
		{
			indicator.SetActive(value: false);
		}
	}

	private void OnActionClicked()
	{
		ZoneData zoneData = allZones[_currentIndex];
		if (zoneData.isUnlocked)
		{
			TravelToZone(zoneData);
		}
		else
		{
			TryUnlockZone(zoneData);
		}
	}

	private void TravelToZone(ZoneData data)
	{
		Debug.Log("[MapController] Traveling to " + data.zoneName + "...");
		GameManager.Instance.SelectZone(data);
	}

	private void TryUnlockZone(ZoneData data)
	{
		if (GameManager.Instance.UnlockZone(data))
		{
			data.isUnlocked = true;
			SoundManager.PlaySound("Unlock_Zone", 1f);
			UpdateCardUI();
			Material matToUse = null;
			if (zoneMaterials != null && zoneMaterials.Count > 0)
			{
				matToUse = zoneMaterials[_currentIndex % zoneMaterials.Count];
				if (levelPreviewPanels != null && _currentIndex < levelPreviewPanels.Count && levelPreviewPanels[_currentIndex] != null)
				{
					Image previewImg = levelPreviewPanels[_currentIndex];
					Material tempAnimMat = new Material(matToUse);
					tempAnimMat.SetFloat("_Saturation", 0f);
					previewImg.material = tempAnimMat;
					tempAnimMat.DOFloat(1f, "_Saturation", 1.5f).OnComplete(delegate
					{
						if (previewImg != null)
						{
							previewImg.material = matToUse;
						}
						UnityEngine.Object.Destroy(tempAnimMat);
					});
				}
			}
			bool isLastNode = _currentIndex == allZones.Count - 1;
			_spawnedNodes[_currentIndex].Setup(data, _currentIndex, isLastNode, this, matToUse, animateUnlock: true);
			_spawnedNodes[_currentIndex].SetSelected(isSelected: true);
			UpdateAffordNotifications();
		}
		else
		{
			Debug.Log("Not enough gold!");
			SoundManager.PlaySound("Error_Bloop", 1f);
		}
	}
}
