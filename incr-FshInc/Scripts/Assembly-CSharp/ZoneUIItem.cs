using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoneUIItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public TMP_Text zoneNameText;

	public TMP_Text costText;

	public Button selectButton;

	public Image zoneIcon;

	public Animator lockedAnimator;

	public GameObject lockedBackground;

	public TMP_Text passiveIncomeText;

	[Header("Discoverable Fish")]
	public List<Image> fishIconSlots;

	public Material silhouetteMaterial;

	[Header("Bonus Display")]
	public TMP_Text goldBonusText;

	public TMP_Text xpBonusText;

	private ZoneData zoneData;

	private ZoneSelectionPanel selectionPanel;

	public Image xpBarFill;

	public TMP_Text levelText;

	public TMP_Text xpText;

	[Header("Hover & Details Panel")]
	public RectTransform animatedContainer;

	public RectTransform detailsPanel;

	public float hoverMoveY = 15f;

	public float hoverScale = 1.05f;

	public float animDuration = 0.2f;

	public float panelGap = 20f;

	[Tooltip("How high the info button should rise on hover.")]
	public float infoButtonHoverY = 5f;

	[Tooltip("Drag the EventTrigger component from your Info Button here.")]
	public EventTrigger infoButtonEventTrigger;

	[Tooltip("How many items are in each row of your grid?")]
	public int itemsPerRow = 3;

	private bool isLastInRow;

	private Vector2 originalDetailsPivot;

	private Vector2 originalDetailsAnchorMin;

	private Vector2 originalDetailsAnchorMax;

	private Vector2 originalDetailsAnchoredPos;

	private Vector3 originalPosition;

	private Vector3 originalScale;

	private Tween hoverTween;

	private Tween scaleTween;

	private Tween panelTween;

	private Canvas myCanvas;

	private int mainItemOriginalSortOrder;

	private Canvas detailsPanelCanvas;

	private int detailsPanelOriginalSortOrder;

	private bool isPanelOpen;

	[Header("Details Panel Content")]
	[Tooltip("The title text inside the details panel (e.g., 'Green Lake')")]
	public TMP_Text detailsPondNameText;

	[Tooltip("The parent object (e.g., ScrollView Content) where fish entries will be created")]
	public Transform fishInfoContainer;

	[Tooltip("The prefab that has your 'DiscoverFishEntry.cs' script on it")]
	public GameObject discoverFishEntryPrefab;

	private Vector3 infoButtonOriginalPos;

	private Tween infoButtonTween;

	private void Awake()
	{
		isLastInRow = (base.transform.GetSiblingIndex() + 1) % itemsPerRow == 0;
		myCanvas = GetComponent<Canvas>();
		if (myCanvas != null)
		{
			mainItemOriginalSortOrder = myCanvas.sortingOrder;
			myCanvas.overrideSorting = false;
		}
		if (animatedContainer != null)
		{
			originalPosition = animatedContainer.localPosition;
			originalScale = animatedContainer.localScale;
		}
		else
		{
			Debug.LogError("AnimatedContainer is not assigned on " + base.gameObject.name);
		}
		if (detailsPanel != null)
		{
			detailsPanel.gameObject.SetActive(value: false);
			detailsPanel.localScale = Vector3.zero;
			detailsPanelCanvas = detailsPanel.GetComponent<Canvas>();
			if (detailsPanelCanvas != null)
			{
				detailsPanelOriginalSortOrder = detailsPanelCanvas.sortingOrder;
				detailsPanelCanvas.overrideSorting = false;
			}
			else
			{
				Debug.LogError("Details Panel on " + base.gameObject.name + " is MISSING a Canvas component. Add a Canvas and GraphicRaycaster to it to fix sorting.");
			}
			originalDetailsPivot = detailsPanel.pivot;
			originalDetailsAnchorMin = detailsPanel.anchorMin;
			originalDetailsAnchorMax = detailsPanel.anchorMax;
			originalDetailsAnchoredPos = detailsPanel.anchoredPosition;
		}
		if (infoButtonEventTrigger != null)
		{
			infoButtonOriginalPos = infoButtonEventTrigger.transform.localPosition;
			EventTrigger.Entry item = new EventTrigger.Entry
			{
				eventID = EventTriggerType.PointerEnter
			};
			infoButtonEventTrigger.triggers.Add(item);
			EventTrigger.Entry entry = new EventTrigger.Entry
			{
				eventID = EventTriggerType.PointerExit
			};
			entry.callback.AddListener(delegate
			{
				OnInfoButtonExit();
			});
			infoButtonEventTrigger.triggers.Add(entry);
		}
		else
		{
			Debug.LogWarning("InfoButtonEventTrigger is not assigned on " + base.gameObject.name + ". Details panel hover will not work.");
		}
	}

	public void Setup(ZoneData data, ZoneSelectionPanel panel)
	{
		zoneData = data;
		selectionPanel = panel;
		zoneNameText.text = zoneData.zoneName;
		zoneIcon.sprite = zoneData.zoneIcon;
		selectButton.onClick.AddListener(OnButtonClicked);
		PopulateDetailsPanel();
	}

	private void PopulateDetailsPanel()
	{
		if (zoneData == null)
		{
			return;
		}
		if (detailsPondNameText != null)
		{
			detailsPondNameText.text = zoneData.zoneName;
		}
		if (fishInfoContainer == null || discoverFishEntryPrefab == null)
		{
			Debug.LogError("Details Panel is not set up correctly. Assign Container and Prefab on " + base.gameObject.name);
			return;
		}
		foreach (Transform item in fishInfoContainer)
		{
			Object.Destroy(item.gameObject);
		}
		float num = 0f;
		foreach (FishEncounterData possibleCatch in zoneData.possibleCatches)
		{
			num += possibleCatch.encounterWeight;
		}
		if (num <= 0f)
		{
			num = 1f;
		}
		foreach (FishEncounterData possibleCatch2 in zoneData.possibleCatches)
		{
			Fish fishSpecies = possibleCatch2.fishSpecies;
			if (!(fishSpecies == null))
			{
				DiscoverFishEntry component = Object.Instantiate(discoverFishEntryPrefab, fishInfoContainer).GetComponent<DiscoverFishEntry>();
				if (component != null)
				{
					bool isDiscovered = FishLogManager.Instance.HasCaughtSpecies(fishSpecies.speciesName);
					component.Setup(fishSpecies, possibleCatch2.encounterWeight, num, isDiscovered);
				}
			}
		}
	}

	public void RefreshVisuals()
	{
		lockedAnimator.SetBool("Locked", !zoneData.isUnlocked);
		levelText.text = "lvl " + zoneData.currentLevel;
		xpText.text = $" {zoneData.currentXp} / {zoneData.GetXpForNextLevel()} XP";
		xpBarFill.fillAmount = (float)zoneData.currentXp / (float)zoneData.GetXpForNextLevel();
		if (zoneData.isUnlocked)
		{
			selectButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Go Fish!";
			lockedBackground.SetActive(value: false);
			goldBonusText.text = $"+{zoneData.GetCurrentGoldBonusPercent():P1} Gold";
			xpBonusText.text = $"+{zoneData.GetCurrentXpBonusPercent():P1} XP";
			float currentPassiveIncome = zoneData.GetCurrentPassiveIncome();
			passiveIncomeText.text = "<color=yellow>" + CurrencyFormatter.FormatMoney(currentPassiveIncome) + "</color> G/s";
		}
		else
		{
			double effectiveZoneUnlockCost = GameManager.Instance.GetEffectiveZoneUnlockCost(zoneData);
			costText.text = CurrencyFormatter.FormatMoney(effectiveZoneUnlockCost) + " G";
			selectButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Unlock";
			lockedBackground.SetActive(value: true);
			goldBonusText.gameObject.SetActive(value: false);
			xpBonusText.gameObject.SetActive(value: false);
		}
	}

	private void OnButtonClicked()
	{
		if (zoneData.isUnlocked)
		{
			GameManager.Instance.SelectZone(zoneData);
		}
		else
		{
			selectionPanel.AttemptUnlock(zoneData);
		}
	}

	private void UpdateFishSilhouettes()
	{
		for (int i = 0; i < fishIconSlots.Count; i++)
		{
			if (i < zoneData.possibleCatches.Count)
			{
				fishIconSlots[i].gameObject.SetActive(value: true);
				Fish fishSpecies = zoneData.possibleCatches[i].fishSpecies;
				if (fishSpecies.availableRarities.Count > 0)
				{
					fishIconSlots[i].sprite = fishSpecies.availableRarities[0].artwork;
				}
				if (FishLogManager.Instance.HasCaughtSpecies(fishSpecies.speciesName))
				{
					fishIconSlots[i].material = null;
				}
				else
				{
					fishIconSlots[i].material = silhouetteMaterial;
				}
			}
			else
			{
				fishIconSlots[i].gameObject.SetActive(value: false);
			}
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		hoverTween?.Kill();
		scaleTween?.Kill();
		panelTween?.Kill();
		if (selectButton.interactable)
		{
			SoundManager.PlaySound("Tooltip_Pop", 0.05f);
		}
		if (myCanvas != null)
		{
			myCanvas.overrideSorting = true;
			myCanvas.sortingOrder = mainItemOriginalSortOrder + 10;
		}
		if (detailsPanelCanvas != null)
		{
			detailsPanelCanvas.overrideSorting = true;
			detailsPanelCanvas.sortingOrder = mainItemOriginalSortOrder + 20;
		}
		hoverTween = animatedContainer.DOLocalMoveY(originalPosition.y + hoverMoveY, animDuration).SetEase(Ease.OutQuad);
		scaleTween = animatedContainer.DOScale(originalScale * hoverScale, animDuration).SetEase(Ease.OutQuad);
		if (zoneData.isUnlocked && detailsPanel != null)
		{
			if (detailsPanelCanvas != null)
			{
				detailsPanelCanvas.overrideSorting = true;
				detailsPanelCanvas.sortingOrder = mainItemOriginalSortOrder + 20;
			}
			if (isLastInRow)
			{
				detailsPanel.pivot = new Vector2(1f, 0.5f);
				detailsPanel.anchorMin = new Vector2(0f, 0.5f);
				detailsPanel.anchorMax = new Vector2(0f, 0.5f);
				detailsPanel.anchoredPosition = new Vector2(0f - panelGap, originalDetailsAnchoredPos.y);
			}
			else
			{
				detailsPanel.pivot = new Vector2(0f, 0.5f);
				detailsPanel.anchorMin = new Vector2(1f, 0.5f);
				detailsPanel.anchorMax = new Vector2(1f, 0.5f);
				detailsPanel.anchoredPosition = new Vector2(panelGap, originalDetailsAnchoredPos.y);
			}
			detailsPanel.gameObject.SetActive(value: true);
			panelTween = detailsPanel.DOScale(Vector3.one, animDuration).SetEase(Ease.OutBack);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hoverTween?.Kill();
		scaleTween?.Kill();
		hoverTween = animatedContainer.DOLocalMoveY(originalPosition.y, animDuration).SetEase(Ease.OutQuad);
		scaleTween = animatedContainer.DOScale(originalScale, animDuration).SetEase(Ease.OutQuad);
		scaleTween.OnComplete(delegate
		{
			if (myCanvas != null)
			{
				myCanvas.overrideSorting = false;
				myCanvas.sortingOrder = mainItemOriginalSortOrder;
			}
		});
		if (!(detailsPanel != null) || !detailsPanel.gameObject.activeSelf)
		{
			return;
		}
		panelTween = detailsPanel.DOScale(Vector3.zero, animDuration).SetEase(Ease.InQuad).OnComplete(delegate
		{
			if (detailsPanel != null)
			{
				detailsPanel.gameObject.SetActive(value: false);
				detailsPanel.pivot = originalDetailsPivot;
				detailsPanel.anchorMin = originalDetailsAnchorMin;
				detailsPanel.anchorMax = originalDetailsAnchorMax;
				detailsPanel.anchoredPosition = originalDetailsAnchoredPos;
			}
			if (detailsPanelCanvas != null)
			{
				detailsPanelCanvas.overrideSorting = false;
				detailsPanelCanvas.sortingOrder = detailsPanelOriginalSortOrder;
			}
		});
	}

	public void OnInfoButtonEnter()
	{
		SoundManager.PlaySound("SmallUI_Pop", 0.1f);
		if (infoButtonEventTrigger != null)
		{
			infoButtonTween?.Kill();
			infoButtonTween = infoButtonEventTrigger.transform.DOLocalMoveY(infoButtonOriginalPos.y + infoButtonHoverY, animDuration).SetEase(Ease.OutQuad);
		}
		if (isPanelOpen)
		{
			return;
		}
		isPanelOpen = true;
		if (!zoneData.isUnlocked)
		{
			return;
		}
		panelTween?.Kill();
		if (detailsPanelCanvas != null)
		{
			detailsPanelCanvas.overrideSorting = true;
			detailsPanelCanvas.sortingOrder = mainItemOriginalSortOrder + 20;
		}
		if (detailsPanel != null)
		{
			if (isLastInRow)
			{
				detailsPanel.pivot = new Vector2(1f, 0.5f);
				detailsPanel.anchorMin = new Vector2(0f, 0.5f);
				detailsPanel.anchorMax = new Vector2(0f, 0.5f);
				detailsPanel.anchoredPosition = new Vector2(0f - panelGap, originalDetailsAnchoredPos.y);
			}
			else
			{
				detailsPanel.pivot = new Vector2(0f, 0.5f);
				detailsPanel.anchorMin = new Vector2(1f, 0.5f);
				detailsPanel.anchorMax = new Vector2(1f, 0.5f);
				detailsPanel.anchoredPosition = new Vector2(panelGap, originalDetailsAnchoredPos.y);
			}
			detailsPanel.gameObject.SetActive(value: true);
			panelTween = detailsPanel.DOScale(Vector3.one, animDuration).SetEase(Ease.OutBack);
		}
	}

	public void OnInfoButtonExit()
	{
		if (infoButtonEventTrigger != null)
		{
			infoButtonTween?.Kill();
			infoButtonTween = infoButtonEventTrigger.transform.DOLocalMoveY(infoButtonOriginalPos.y, animDuration).SetEase(Ease.OutQuad);
		}
		if (!isPanelOpen)
		{
			return;
		}
		isPanelOpen = false;
		panelTween?.Kill();
		if (!(detailsPanel != null))
		{
			return;
		}
		panelTween = detailsPanel.DOScale(Vector3.zero, animDuration).SetEase(Ease.InQuad).OnComplete(delegate
		{
			if (detailsPanel != null && !isPanelOpen)
			{
				detailsPanel.gameObject.SetActive(value: false);
			}
			if (detailsPanelCanvas != null)
			{
				detailsPanelCanvas.overrideSorting = false;
				detailsPanelCanvas.sortingOrder = detailsPanelOriginalSortOrder;
			}
			if (detailsPanel != null)
			{
				detailsPanel.pivot = originalDetailsPivot;
				detailsPanel.anchorMin = originalDetailsAnchorMin;
				detailsPanel.anchorMax = originalDetailsAnchorMax;
				detailsPanel.anchoredPosition = originalDetailsAnchoredPos;
			}
		});
	}
}
