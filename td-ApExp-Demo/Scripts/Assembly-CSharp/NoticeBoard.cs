using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Localization;
using UnityEngine.UI;

public class NoticeBoard : Menu
{
	[Header("Buttons")]
	[SerializeField]
	private Button HomeButton;

	[SerializeField]
	private TextMeshProUGUI HomeText;

	[SerializeField]
	private Button ModulesButton;

	[SerializeField]
	private TextMeshProUGUI ModulesText;

	[SerializeField]
	private Button RelicsButton;

	[SerializeField]
	private TextMeshProUGUI RelicsText;

	[SerializeField]
	private Button GeneralButton;

	[SerializeField]
	private TextMeshProUGUI GeneralText;

	[SerializeField]
	private Sprite HomeSprite;

	[SerializeField]
	private Sprite ModulesSprite;

	[SerializeField]
	private Sprite RelicsSprite;

	[SerializeField]
	private Sprite GeneralSprite;

	[SerializeField]
	private Image HomeImg;

	[SerializeField]
	private Image ModulesImg;

	[SerializeField]
	private Image RelicsImg;

	[SerializeField]
	private Image GeneralImg;

	[SerializeField]
	private Button BackButton;

	private Image BackButtonImage;

	private GameObject BackButtonText;

	[Header("Selectio Sprites")]
	[SerializeField]
	private Sprite HomeHoverSprite;

	[SerializeField]
	private Sprite modulesHoverSprite;

	[SerializeField]
	private Sprite relicsHoverSprite;

	[SerializeField]
	private Sprite upgradeHoverSprite;

	[SerializeField]
	private Sprite HomeSelectedSprite;

	[SerializeField]
	private Sprite modulesSelectedSprite;

	[SerializeField]
	private Sprite relicsSelectedSprite;

	[SerializeField]
	private Sprite upgradeSelectedSprite;

	[Header("Close to Unlock")]
	[SerializeField]
	private GameObject closeToUnlockContainer;

	[SerializeField]
	private List<GameObject> closeToUnlockGOs;

	private Slider[] closeToUnlockBars;

	private TextMeshProUGUI[] closeToUnlockNames;

	private TextMeshProUGUI[] closeToUnlockProgressPercentages;

	private Button[] closeToUnlockButtons;

	private Image[] closeToUnlockIcons;

	private Image[] closeToUnlockBorders;

	private Image[] closeToUnlockMasks;

	[Header("LockedPage")]
	[SerializeField]
	private Slider lockedBar;

	[SerializeField]
	private TextMeshProUGUI lockedName;

	[SerializeField]
	private TextMeshProUGUI lockedRarity;

	[SerializeField]
	private TextMeshProUGUI lockedPercent;

	[SerializeField]
	private TextMeshProUGUI lockedText;

	[SerializeField]
	private Image lockedBorder;

	[SerializeField]
	private Image lockedMask;

	[SerializeField]
	private Image lockedIcon;

	[Header("UnlockedPage")]
	[SerializeField]
	private Image unlockedIcon;

	[SerializeField]
	private TextMeshProUGUI unlockedName;

	[SerializeField]
	private TextMeshProUGUI unlockedRarity;

	[SerializeField]
	private TextMeshProUGUI unlockedText;

	[SerializeField]
	private Image unlockedBorder;

	[SerializeField]
	private Image unlockedMask;

	[Header("Content")]
	[SerializeField]
	private GameObject contentPrefab;

	private Dictionary<GameObject, Enhancement> content;

	[SerializeField]
	private GameObject contentGroup;

	[SerializeField]
	private GameObject moduleContentGroup;

	[SerializeField]
	private TextMeshProUGUI contentHeader;

	[SerializeField]
	private Scrollbar contentScrollbar;

	[SerializeField]
	private ScrollRect contentScrollRect;

	[Header("Module Header")]
	[SerializeField]
	private Button headerButton;

	[SerializeField]
	private Image headerIcon;

	[SerializeField]
	private TextMeshProUGUI headerName;

	[SerializeField]
	private Image headerBorder;

	[SerializeField]
	private Image headerMask;

	[Header("Pages")]
	[SerializeField]
	private GameObject overviewPage;

	[SerializeField]
	private GameObject contentsPage;

	[SerializeField]
	private GameObject enhancementsPage;

	[SerializeField]
	private GameObject enhancementsPageItemContainer;

	[SerializeField]
	private GameObject unlockedPage;

	[SerializeField]
	private GameObject lockedPage;

	[Header("Borders")]
	[SerializeField]
	private List<Sprite> moduleBorders;

	[SerializeField]
	private List<Sprite> upgradeBorders;

	[SerializeField]
	private List<Sprite> relicBorders;

	[Header("Masks")]
	[SerializeField]
	private Sprite moduleMask;

	[SerializeField]
	private Sprite upgradeMask;

	[SerializeField]
	private Sprite relicMask;

	[Header("Slots")]
	[SerializeField]
	private Sprite moduleSlot;

	[SerializeField]
	private Sprite upgradeSlot;

	[SerializeField]
	private Sprite relicSlot;

	[Header("Hovers")]
	[SerializeField]
	private Sprite moduleHover;

	[SerializeField]
	private Sprite upgradeHover;

	[SerializeField]
	private Sprite relicHover;

	[Header("Selected")]
	[SerializeField]
	private Sprite moduleSelected;

	[SerializeField]
	private Sprite upgradeSelected;

	[SerializeField]
	private Sprite relicSelected;

	[Header("Navigation")]
	[SerializeField]
	private Hotkey CategoryNavigationLeft;

	[SerializeField]
	private Hotkey CategoryNavigationRight;

	[Header("Misc")]
	[SerializeField]
	private Stats GeneralStats;

	private List<Milestone> top5;

	[SerializeField]
	private Scrollbar enhancementScrollbar;

	[SerializeField]
	private ScrollRect enhancementScrollRect;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString relicHeaderLocalized;

	[SerializeField]
	private LocalizedString moduleHeaderLocalized;

	[SerializeField]
	private LocalizedString generalHeaderLocalized;

	[SerializeField]
	private LocalizedString relicExtraLocalized;

	[SerializeField]
	private LocalizedString moduleExtraLocalized;

	[SerializeField]
	private LocalizedString upgradeExtraLocalized;

	private EnhancementType _currentEnhancementType;

	private ControllerType _currentControllerType;

	private bool isItemSelected;

	private float _categoryButtonUpHeight = -1.5f;

	private float _categoryButtonDownHeight = -3.8f;

	private bool gridChildrenFound;

	private bool gridSearchTimeout;

	private int rows;

	private int columns;

	public override void Init()
	{
		base.Init();
		content = new Dictionary<GameObject, Enhancement>();
		HomeButton.onClick.AddListener(delegate
		{
			OnHomeCLicked();
		});
		ModulesButton.onClick.AddListener(delegate
		{
			OnModulesClicked();
		});
		RelicsButton.onClick.AddListener(delegate
		{
			OnRelicsClicked();
		});
		GeneralButton.onClick.AddListener(delegate
		{
			OnGeneralClicked();
		});
		BackButtonImage = BackButton.gameObject.GetComponent<Image>();
		BackButtonText = BackButton.transform.GetChild(0).gameObject;
	}

	protected override void OnOpen()
	{
		base.OnOpen();
		HomeButton.onClick?.Invoke();
		HomeButton.onClick.AddListener(PlayMainSound);
		_currentEnhancementType = EnhancementType.Home;
		SetUpForControllerType(InputManager.Instance.LastControllerTypeUsed);
		SetSelectedItem(closeToUnlockContainer.transform.GetChild(0).GetComponent<CloseToUnlock>().UnlockButton.gameObject);
		InputManager.Instance.OnRB += HandleInputRB;
		InputManager.Instance.OnLB += HandleInputLB;
		InputHandler.OnAnyInputDetected = (Action<int, ControllerType>)Delegate.Combine(InputHandler.OnAnyInputDetected, new Action<int, ControllerType>(HandleDeviceChanged));
	}

	protected override void OnClose()
	{
		HomeButton.onClick.RemoveListener(PlayMainSound);
		InputManager.Instance.OnRB -= HandleInputRB;
		InputManager.Instance.OnLB -= HandleInputLB;
		InputHandler.OnAnyInputDetected = (Action<int, ControllerType>)Delegate.Remove(InputHandler.OnAnyInputDetected, new Action<int, ControllerType>(HandleDeviceChanged));
		base.OnClose();
	}

	private void HandleSelectionNavigation(int obj)
	{
	}

	private void HandleDeviceChanged(int playerIndex, ControllerType controllerType)
	{
		if (_currentControllerType != controllerType)
		{
			_currentControllerType = controllerType;
			SetUpForControllerType(controllerType);
		}
	}

	private void SetUpForControllerType(ControllerType lastControllerTypeUsed)
	{
		SetCategoryNavigationButtons(lastControllerTypeUsed);
		switch (_currentEnhancementType)
		{
		case EnhancementType.Home:
			TrySetSelectedItem(closeToUnlockContainer.transform.GetChild(0).GetComponent<CloseToUnlock>().UnlockButton.gameObject, lastControllerTypeUsed);
			break;
		case EnhancementType.Module:
		case EnhancementType.Relic:
			if (contentGroup.transform.childCount > 0)
			{
				TrySetSelectedItem(contentGroup.transform.GetChild(0).gameObject, lastControllerTypeUsed);
			}
			break;
		case EnhancementType.General:
			if (moduleContentGroup.transform.childCount > 0)
			{
				TrySetSelectedItem(moduleContentGroup.transform.GetChild(0).gameObject, lastControllerTypeUsed);
			}
			break;
		}
	}

	private void SetSelectedItem(GameObject container)
	{
		TrySetSelectedItem(container, InputManager.Instance.LastControllerTypeUsed);
	}

	private void TrySetSelectedItem(GameObject container, ControllerType lastControllerTypeUsed)
	{
		if (container == null)
		{
			Debug.LogWarning("Container is null, cannot set selected upgrade.");
		}
		else if (!isItemSelected)
		{
			isItemSelected = true;
			StartCoroutine(SelectItemCoroutine(container));
		}
	}

	private IEnumerator SelectItemCoroutine(GameObject container)
	{
		EventSystem.current.SetSelectedGameObject(container);
		yield return new WaitForSeconds(0.1f);
		EventSystem.current.SetSelectedGameObject(container);
	}

	private void SetCategoryNavigationButtons(ControllerType controllerType)
	{
		CategoryNavigationLeft.UpdateIconAndKey(controllerType);
		CategoryNavigationRight.UpdateIconAndKey(controllerType);
	}

	public void OnBackButtonClicked()
	{
		ModulesButton.onClick?.Invoke();
	}

	public void ResetButtonsAndTextPosition()
	{
		OnHomeCLicked();
		HomeButton.interactable = true;
		ModulesButton.interactable = true;
		RelicsButton.interactable = true;
		GeneralButton.interactable = true;
		SetCloseToCompletion();
		SetSelectedItem(closeToUnlockContainer.transform.GetChild(0).GetComponent<CloseToUnlock>().UnlockButton.gameObject);
	}

	private void OnHomeCLicked()
	{
		SetCategoryButtonDown(HomeText.transform);
		SetCategoryButtonUp(ModulesText.transform);
		SetCategoryButtonUp(RelicsText.transform);
		SetCategoryButtonUp(GeneralText.transform);
		_currentEnhancementType = EnhancementType.Home;
	}

	private void OnModulesClicked()
	{
		SetCategoryButtonDown(ModulesText.transform);
		SetCategoryButtonUp(HomeText.transform);
		SetCategoryButtonUp(RelicsText.transform);
		SetCategoryButtonUp(GeneralText.transform);
		_currentEnhancementType = EnhancementType.Module;
	}

	private void OnRelicsClicked()
	{
		SetCategoryButtonDown(RelicsText.transform);
		SetCategoryButtonUp(HomeText.transform);
		SetCategoryButtonUp(ModulesText.transform);
		SetCategoryButtonUp(GeneralText.transform);
		_currentEnhancementType = EnhancementType.Relic;
	}

	private void OnGeneralClicked()
	{
		SetCategoryButtonDown(GeneralText.transform);
		SetCategoryButtonUp(HomeText.transform);
		SetCategoryButtonUp(ModulesText.transform);
		SetCategoryButtonUp(RelicsText.transform);
		_currentEnhancementType = EnhancementType.General;
	}

	private void SetCategoryButtonDown(Transform buttonTf)
	{
		Vector3 localPosition = buttonTf.localPosition;
		localPosition.y = _categoryButtonDownHeight;
		buttonTf.localPosition = localPosition;
	}

	private void SetCategoryButtonUp(Transform buttonTf)
	{
		Vector3 localPosition = buttonTf.localPosition;
		localPosition.y = _categoryButtonUpHeight;
		buttonTf.localPosition = localPosition;
	}

	private void HandleInputRB(int arg1, InputAction.CallbackContext context)
	{
		isItemSelected = false;
		switch (_currentEnhancementType)
		{
		case EnhancementType.None:
			HomeButton.onClick?.Invoke();
			break;
		case EnhancementType.Home:
			ModulesButton.onClick?.Invoke();
			break;
		case EnhancementType.Module:
			RelicsButton.onClick?.Invoke();
			break;
		case EnhancementType.Relic:
			GeneralButton.onClick?.Invoke();
			break;
		}
	}

	private void HandleInputLB(int arg1, InputAction.CallbackContext context)
	{
		isItemSelected = false;
		switch (_currentEnhancementType)
		{
		case EnhancementType.None:
			HomeButton.onClick?.Invoke();
			break;
		case EnhancementType.Module:
			HomeButton.onClick?.Invoke();
			break;
		case EnhancementType.Relic:
			ModulesButton.onClick?.Invoke();
			break;
		case EnhancementType.General:
			RelicsButton.onClick?.Invoke();
			break;
		case EnhancementType.Home:
			break;
		}
	}

	private void SetBackButtonActive(bool active)
	{
		BackButtonImage.enabled = active;
		BackButtonText.SetActive(active);
	}

	public void SetCloseToCompletion()
	{
		SetBackButtonActive(active: false);
		top5 = new List<Milestone>();
		top5 = (from milestone in MilestoneManager.Instance.milestones
			where !milestone.Completed && milestone.Unlock != null
			orderby milestone.ProgressPercent descending
			select milestone).Take(5).ToList();
		int count = top5.Count;
		closeToUnlockBars = new Slider[count];
		closeToUnlockNames = new TextMeshProUGUI[count];
		closeToUnlockProgressPercentages = new TextMeshProUGUI[count];
		closeToUnlockButtons = new Button[count];
		closeToUnlockBorders = new Image[count];
		closeToUnlockMasks = new Image[count];
		closeToUnlockIcons = new Image[count];
		for (int num = 0; num < top5.Count; num++)
		{
			CloseToUnlock component = closeToUnlockGOs[num].GetComponent<CloseToUnlock>();
			closeToUnlockBars[num] = component.Slider;
			closeToUnlockNames[num] = component.Name;
			closeToUnlockProgressPercentages[num] = component.ProgressPercentage;
			closeToUnlockButtons[num] = component.UnlockButton;
			closeToUnlockBorders[num] = component.UnlockBorder;
			closeToUnlockMasks[num] = component.UnlockMask;
			closeToUnlockIcons[num] = component.UnlockIcon;
		}
		for (int num2 = 0; num2 < 5 && !(top5[num2] == null); num2++)
		{
			CloseToUnlockSetup(num2);
		}
		if (top5[0] != null)
		{
			lockedBar.value = top5[0].ProgressPercent;
			lockedText.text = top5[0].DescriptionKey.GetLocalizedString();
			lockedPercent.text = top5[0].ProgressPercent + "%";
			SetShowcase(top5[0]);
		}
		else
		{
			lockedPage.SetActive(value: false);
		}
		TrySetSelectedItem(closeToUnlockContainer.transform.GetChild(0).GetComponent<CloseToUnlock>().UnlockButton.gameObject, InputManager.Instance.LastControllerTypeUsed);
	}

	public void CloseToUnlockSetup(int i)
	{
		closeToUnlockGOs[i].SetActive(value: true);
		closeToUnlockBars[i].value = top5[i].ProgressPercent;
		closeToUnlockNames[i].text = top5[i].Unlock.NameKey.GetLocalizedString();
		closeToUnlockProgressPercentages[i].text = top5[i].ProgressPercent + "%";
		closeToUnlockButtons[i].onClick.AddListener(delegate
		{
			SetShowcase(top5[i]);
		});
		closeToUnlockIcons[i].sprite = top5[i].Unlock.Icon;
		if (top5[i].Unlock is EnhancementModule)
		{
			closeToUnlockBorders[i].sprite = moduleBorders[(int)top5[i].Unlock.Rarity];
			closeToUnlockMasks[i].sprite = moduleMask;
			SpriteState spriteState = closeToUnlockButtons[i].spriteState;
			spriteState.highlightedSprite = modulesHoverSprite;
			spriteState.selectedSprite = modulesSelectedSprite;
			closeToUnlockButtons[i].spriteState = spriteState;
		}
		else if (top5[i].Unlock is EnhancementUpgrade { IsRelic: not false })
		{
			closeToUnlockBorders[i].sprite = relicBorders[(int)top5[i].Unlock.Rarity];
			closeToUnlockMasks[i].sprite = relicMask;
			SpriteState spriteState2 = closeToUnlockButtons[i].spriteState;
			spriteState2.highlightedSprite = relicsHoverSprite;
			spriteState2.selectedSprite = relicsSelectedSprite;
			closeToUnlockButtons[i].spriteState = spriteState2;
		}
		else
		{
			closeToUnlockBorders[i].sprite = upgradeBorders[(int)top5[i].Unlock.Rarity];
			closeToUnlockMasks[i].sprite = upgradeMask;
			SpriteState spriteState3 = closeToUnlockButtons[i].spriteState;
			spriteState3.highlightedSprite = upgradeHoverSprite;
			spriteState3.selectedSprite = upgradeSelectedSprite;
			closeToUnlockButtons[i].spriteState = spriteState3;
		}
	}

	public void SetShowcase(Milestone milestone)
	{
		lockedBar.value = milestone.ProgressPercent;
		lockedText.text = milestone.DescriptionKey.GetLocalizedString();
		lockedPercent.text = milestone.ProgressPercent + "%";
		lockedIcon.sprite = milestone.Unlock.Icon;
		if (milestone.Unlock is EnhancementModule)
		{
			lockedRarity.text = StringFormatHelper.GetRarityString(milestone.Unlock) + moduleExtraLocalized.GetLocalizedString();
			lockedBorder.sprite = moduleBorders[(int)milestone.Unlock.Rarity];
			lockedMask.sprite = moduleMask;
		}
		else if (milestone.Unlock is EnhancementUpgrade enhancementUpgrade)
		{
			if (enhancementUpgrade.IsRelic)
			{
				lockedRarity.text = StringFormatHelper.GetRarityString(milestone.Unlock) + relicExtraLocalized.GetLocalizedString();
				lockedBorder.sprite = relicBorders[(int)milestone.Unlock.Rarity];
				lockedMask.sprite = relicMask;
			}
			else
			{
				lockedRarity.text = StringFormatHelper.GetRarityString(milestone.Unlock) + upgradeExtraLocalized.GetLocalizedString();
				lockedBorder.sprite = upgradeBorders[(int)milestone.Unlock.Rarity];
				lockedMask.sprite = upgradeMask;
			}
		}
		lockedRarity.color = UIManager.Instance.RarityColor(milestone.Unlock.Rarity);
		lockedName.text = milestone.Unlock.NameKey.GetLocalizedString();
		lockedPage.SetActive(value: true);
		unlockedPage.SetActive(value: false);
	}

	public void AddModules()
	{
		SetBackButtonActive(active: false);
		StartCoroutine(AddModulesCoroutine());
	}

	private IEnumerator AddModulesCoroutine()
	{
		foreach (KeyValuePair<GameObject, Enhancement> item in content)
		{
			UnityEngine.Object.Destroy(item.Key);
		}
		content.Clear();
		yield return new WaitUntil(() => contentGroup.transform.childCount == 0);
		contentHeader.text = moduleHeaderLocalized.GetLocalizedString();
		foreach (EnhancementModule startingModule in UpgradeManager.Instance.StartingModules)
		{
			if (startingModule.Name != "Player And General Stats" && !startingModule.Locked)
			{
				GameObject newContent = UnityEngine.Object.Instantiate(contentPrefab, contentGroup.GetComponent<RectTransform>());
				content.Add(newContent, startingModule);
				newContent.GetComponentInChildren<TextMeshProUGUI>().text = startingModule.NameKey.GetLocalizedString();
				newContent.GetComponent<Button>().onClick.AddListener(delegate
				{
					OpenEnhancement(newContent);
				});
				NoticeBoardContent component = newContent.GetComponent<NoticeBoardContent>();
				component.icon.sprite = startingModule.Icon;
				component.name.text = startingModule.NameKey.GetLocalizedString();
				component.iconBorder.sprite = moduleBorders[(int)startingModule.Rarity];
				component.mask.sprite = moduleMask;
				component.slotImg.sprite = moduleSlot;
				component.hoverSprite = moduleHover;
				component.selectedSprite = moduleSelected;
				component.Unlock();
				SpriteState spriteState = newContent.GetComponent<Button>().spriteState;
				spriteState.highlightedSprite = modulesHoverSprite;
				spriteState.selectedSprite = modulesSelectedSprite;
				newContent.GetComponent<Button>().spriteState = spriteState;
			}
		}
		foreach (EnhancementModule module in UpgradeManager.Instance.Modules)
		{
			if (!(module.Name != "Player And General Stats"))
			{
				continue;
			}
			if (!module.Locked)
			{
				GameObject newContent2 = UnityEngine.Object.Instantiate(contentPrefab, contentGroup.GetComponent<RectTransform>());
				content.Add(newContent2, module);
				newContent2.GetComponentInChildren<TextMeshProUGUI>().text = module.NameKey.GetLocalizedString();
				newContent2.GetComponent<Button>().onClick.AddListener(delegate
				{
					OpenEnhancement(newContent2);
				});
				NoticeBoardContent component2 = newContent2.GetComponent<NoticeBoardContent>();
				component2.icon.sprite = module.Icon;
				component2.name.text = module.NameKey.GetLocalizedString();
				component2.iconBorder.sprite = moduleBorders[(int)module.Rarity];
				component2.mask.sprite = moduleMask;
				component2.slotImg.sprite = moduleSlot;
				component2.hoverSprite = moduleHover;
				component2.selectedSprite = moduleSelected;
				component2.Unlock();
				SpriteState spriteState2 = newContent2.GetComponent<Button>().spriteState;
				spriteState2.highlightedSprite = modulesHoverSprite;
				spriteState2.selectedSprite = modulesSelectedSprite;
				newContent2.GetComponent<Button>().spriteState = spriteState2;
			}
			else
			{
				GameObject newContent3 = UnityEngine.Object.Instantiate(contentPrefab, contentGroup.GetComponent<RectTransform>());
				content.Add(newContent3, module);
				newContent3.GetComponentInChildren<TextMeshProUGUI>().text = module.NameKey.GetLocalizedString();
				newContent3.GetComponent<Button>().onClick.AddListener(delegate
				{
					OpenEnhancement(newContent3);
				});
				NoticeBoardContent component3 = newContent3.GetComponent<NoticeBoardContent>();
				component3.name.text = module.NameKey.GetLocalizedString();
				component3.iconBorder.sprite = moduleBorders[(int)module.Rarity];
				component3.mask.sprite = moduleMask;
				component3.slotImg.sprite = moduleSlot;
				component3.hoverSprite = moduleHover;
				component3.selectedSprite = moduleSelected;
				component3.icon.sprite = module.Icon;
				component3.Lock();
				SpriteState spriteState3 = newContent3.GetComponent<Button>().spriteState;
				spriteState3.highlightedSprite = modulesHoverSprite;
				spriteState3.selectedSprite = modulesSelectedSprite;
				newContent3.GetComponent<Button>().spriteState = spriteState3;
			}
		}
		contentScrollbar.value = 0f;
		contentScrollRect.horizontalNormalizedPosition = 0f;
		SetNavigationForGrid(contentGroup);
		isItemSelected = false;
		SetSelectedItem(contentGroup.transform.GetChild(0).gameObject);
		contentScrollRect.verticalNormalizedPosition = 0f;
	}

	public void AddRelics()
	{
		SetBackButtonActive(active: false);
		StartCoroutine(AddRelicsCoroutine());
	}

	private IEnumerator AddRelicsCoroutine()
	{
		foreach (KeyValuePair<GameObject, Enhancement> item in content)
		{
			UnityEngine.Object.Destroy(item.Key);
		}
		content.Clear();
		yield return new WaitUntil(() => contentGroup.transform.childCount == 0);
		contentHeader.text = relicHeaderLocalized.GetLocalizedString();
		foreach (EnhancementUpgrade relic in UpgradeManager.Instance.Relics)
		{
			if (!relic.Locked)
			{
				GameObject newContent = UnityEngine.Object.Instantiate(contentPrefab, contentGroup.GetComponent<RectTransform>());
				content.Add(newContent, relic);
				newContent.GetComponentInChildren<TextMeshProUGUI>().text = relic.NameKey.GetLocalizedString();
				newContent.GetComponent<Button>().onClick.AddListener(delegate
				{
					OpenEnhancement(newContent);
				});
				NoticeBoardContent component = newContent.GetComponent<NoticeBoardContent>();
				component.icon.sprite = relic.Icon;
				component.name.text = relic.NameKey.GetLocalizedString();
				component.iconBorder.sprite = relicBorders[(int)relic.Rarity];
				component.mask.sprite = relicMask;
				component.slotImg.sprite = relicSlot;
				component.hoverSprite = relicHover;
				component.selectedSprite = relicSelected;
				component.Unlock();
				SpriteState spriteState = newContent.GetComponent<Button>().spriteState;
				spriteState.highlightedSprite = relicsHoverSprite;
				spriteState.selectedSprite = relicsSelectedSprite;
				newContent.GetComponent<Button>().spriteState = spriteState;
			}
			else
			{
				GameObject newContent2 = UnityEngine.Object.Instantiate(contentPrefab, contentGroup.GetComponent<RectTransform>());
				content.Add(newContent2, relic);
				newContent2.GetComponentInChildren<TextMeshProUGUI>().text = relic.NameKey.GetLocalizedString();
				newContent2.GetComponent<Button>().onClick.AddListener(delegate
				{
					OpenEnhancement(newContent2);
				});
				NoticeBoardContent component2 = newContent2.GetComponent<NoticeBoardContent>();
				component2.name.text = relic.NameKey.GetLocalizedString();
				component2.iconBorder.sprite = relicBorders[(int)relic.Rarity];
				component2.mask.sprite = relicMask;
				component2.slotImg.sprite = relicSlot;
				component2.hoverSprite = relicHover;
				component2.selectedSprite = relicSelected;
				component2.icon.sprite = relic.Icon;
				component2.Lock();
				SpriteState spriteState2 = newContent2.GetComponent<Button>().spriteState;
				spriteState2.highlightedSprite = relicsHoverSprite;
				spriteState2.selectedSprite = relicsSelectedSprite;
				newContent2.GetComponent<Button>().spriteState = spriteState2;
			}
		}
		contentScrollbar.value = 0f;
		contentScrollRect.horizontalNormalizedPosition = 0f;
		SetNavigationForGrid(contentGroup);
		SetSelectedItem(contentGroup.transform.GetChild(0).gameObject);
		contentScrollRect.verticalNormalizedPosition = 0f;
	}

	public void AddGeneral()
	{
		SetBackButtonActive(active: false);
		StartCoroutine(AddGeneralCoroutine());
	}

	private IEnumerator AddGeneralCoroutine()
	{
		foreach (KeyValuePair<GameObject, Enhancement> item in content)
		{
			UnityEngine.Object.Destroy(item.Key);
		}
		content.Clear();
		yield return new WaitUntil(() => contentGroup.transform.childCount == 0);
		contentHeader.text = generalHeaderLocalized.GetLocalizedString();
		int num = 0;
		EnhancementUpgrade[] upgrades = UpgradeManager.Instance.Upgrades;
		foreach (EnhancementUpgrade enhancementUpgrade in upgrades)
		{
			if (enhancementUpgrade.IsRelic)
			{
				break;
			}
			Stats[] statsObjectsToUpgrade = enhancementUpgrade.StatsObjectsToUpgrade;
			for (int num3 = 0; num3 < statsObjectsToUpgrade.Length; num3++)
			{
				if (!(statsObjectsToUpgrade[num3] == GeneralStats))
				{
					continue;
				}
				if (!enhancementUpgrade.Locked)
				{
					GameObject newContent = UnityEngine.Object.Instantiate(contentPrefab, contentGroup.GetComponent<RectTransform>());
					content.Add(newContent, enhancementUpgrade);
					newContent.GetComponentInChildren<TextMeshProUGUI>().text = enhancementUpgrade.NameKey.GetLocalizedString();
					newContent.GetComponent<Button>().onClick.AddListener(delegate
					{
						OpenEnhancement(newContent);
					});
					NoticeBoardContent component = newContent.GetComponent<NoticeBoardContent>();
					component.Index = num++;
					component.icon.sprite = enhancementUpgrade.Icon;
					component.name.text = enhancementUpgrade.NameKey.GetLocalizedString();
					component.iconBorder.sprite = upgradeBorders[(int)enhancementUpgrade.Rarity];
					component.mask.sprite = upgradeMask;
					component.slotImg.sprite = upgradeSlot;
					component.hoverSprite = upgradeHover;
					component.selectedSprite = upgradeSelected;
					component.Unlock();
					SpriteState spriteState = newContent.GetComponent<Button>().spriteState;
					spriteState.highlightedSprite = upgradeHoverSprite;
					spriteState.selectedSprite = upgradeSelectedSprite;
					newContent.GetComponent<Button>().spriteState = spriteState;
				}
				else
				{
					GameObject newContent2 = UnityEngine.Object.Instantiate(contentPrefab, contentGroup.GetComponent<RectTransform>());
					content.Add(newContent2, enhancementUpgrade);
					newContent2.GetComponentInChildren<TextMeshProUGUI>().text = enhancementUpgrade.NameKey.GetLocalizedString();
					newContent2.GetComponent<Button>().onClick.AddListener(delegate
					{
						OpenEnhancement(newContent2);
					});
					NoticeBoardContent component2 = newContent2.GetComponent<NoticeBoardContent>();
					component2.Index = num++;
					component2.name.text = enhancementUpgrade.NameKey.GetLocalizedString();
					component2.iconBorder.sprite = upgradeBorders[(int)enhancementUpgrade.Rarity];
					component2.mask.sprite = upgradeMask;
					component2.slotImg.sprite = upgradeSlot;
					component2.hoverSprite = upgradeHover;
					component2.selectedSprite = upgradeSelected;
					component2.icon.sprite = enhancementUpgrade.Icon;
					component2.Lock();
					SpriteState spriteState2 = newContent2.GetComponent<Button>().spriteState;
					spriteState2.highlightedSprite = upgradeHoverSprite;
					spriteState2.selectedSprite = upgradeSelectedSprite;
					newContent2.GetComponent<Button>().spriteState = spriteState2;
				}
			}
		}
		contentScrollbar.value = 0f;
		contentScrollRect.horizontalNormalizedPosition = 0f;
		SetNavigationForGrid(contentGroup);
		SetSelectedItem(contentGroup.transform.GetChild(0).gameObject);
		contentScrollRect.verticalNormalizedPosition = 0f;
	}

	public void AddUpgrades(EnhancementModule module, bool skipNavigation = false)
	{
		SetBackButtonActive(active: true);
		StartCoroutine(AddUpgradesCoroutine(module, skipNavigation));
	}

	private IEnumerator AddUpgradesCoroutine(EnhancementModule module, bool skipNavigation = false)
	{
		yield return new WaitUntil(() => moduleContentGroup.transform.childCount == 0);
		int num = 0;
		EnhancementUpgrade[] upgrades = UpgradeManager.Instance.Upgrades;
		foreach (EnhancementUpgrade enhancementUpgrade in upgrades)
		{
			if (enhancementUpgrade.IsRelic)
			{
				break;
			}
			Stats[] statsObjectsToUpgrade = enhancementUpgrade.StatsObjectsToUpgrade;
			for (int num3 = 0; num3 < statsObjectsToUpgrade.Length; num3++)
			{
				if (!(statsObjectsToUpgrade[num3] == module.ModulePrefab.GetComponent<Module>().StatsSO))
				{
					continue;
				}
				if (!enhancementUpgrade.Locked)
				{
					GameObject newContent = UnityEngine.Object.Instantiate(contentPrefab, moduleContentGroup.GetComponent<RectTransform>());
					content.Add(newContent, enhancementUpgrade);
					newContent.GetComponentInChildren<TextMeshProUGUI>().text = enhancementUpgrade.NameKey.GetLocalizedString();
					newContent.GetComponent<Button>().onClick.AddListener(delegate
					{
						OpenEnhancement(newContent);
					});
					NoticeBoardContent component = newContent.GetComponent<NoticeBoardContent>();
					component.Index = num++;
					component.icon.sprite = enhancementUpgrade.Icon;
					component.name.text = enhancementUpgrade.NameKey.GetLocalizedString();
					component.iconBorder.sprite = upgradeBorders[(int)enhancementUpgrade.Rarity];
					component.mask.sprite = upgradeMask;
					component.slotImg.sprite = upgradeSlot;
					component.hoverSprite = upgradeHover;
					component.selectedSprite = upgradeSelected;
					component.Unlock();
					SpriteState spriteState = newContent.GetComponent<Button>().spriteState;
					spriteState.highlightedSprite = upgradeHoverSprite;
					spriteState.selectedSprite = upgradeSelectedSprite;
					newContent.GetComponent<Button>().spriteState = spriteState;
				}
				else
				{
					GameObject newContent2 = UnityEngine.Object.Instantiate(contentPrefab, moduleContentGroup.GetComponent<RectTransform>());
					content.Add(newContent2, enhancementUpgrade);
					newContent2.GetComponentInChildren<TextMeshProUGUI>().text = enhancementUpgrade.NameKey.GetLocalizedString();
					newContent2.GetComponent<Button>().onClick.AddListener(delegate
					{
						OpenEnhancement(newContent2);
					});
					NoticeBoardContent component2 = newContent2.GetComponent<NoticeBoardContent>();
					component2.Index = num++;
					component2.name.text = enhancementUpgrade.NameKey.GetLocalizedString();
					component2.iconBorder.sprite = upgradeBorders[(int)enhancementUpgrade.Rarity];
					component2.mask.sprite = upgradeMask;
					component2.slotImg.sprite = upgradeSlot;
					component2.hoverSprite = upgradeHover;
					component2.selectedSprite = upgradeSelected;
					component2.icon.sprite = enhancementUpgrade.Icon;
					component2.Lock();
					SpriteState spriteState2 = newContent2.GetComponent<Button>().spriteState;
					spriteState2.highlightedSprite = upgradeHoverSprite;
					spriteState2.selectedSprite = upgradeSelectedSprite;
					newContent2.GetComponent<Button>().spriteState = spriteState2;
				}
			}
		}
		contentScrollbar.value = 0f;
		contentScrollRect.horizontalNormalizedPosition = 0f;
		if (!skipNavigation)
		{
			SetNavigationForGrid(moduleContentGroup);
		}
		SetSelectedItem(moduleContentGroup.transform.GetChild(0).gameObject);
		enhancementScrollRect.verticalNormalizedPosition = 0f;
	}

	public void OpenEnhancement(GameObject c)
	{
		if (content[c].Locked)
		{
			lockedPage.SetActive(value: true);
			unlockedPage.SetActive(value: false);
			{
				foreach (Milestone milestone in MilestoneManager.Instance.milestones)
				{
					if (content[c] == milestone.Unlock)
					{
						lockedBar.value = milestone.ProgressPercent;
						lockedName.text = content[c].NameKey.GetLocalizedString();
						lockedPercent.text = milestone.ProgressPercent + "%";
						lockedRarity.text = StringFormatHelper.GetRarityString(content[c]);
						lockedRarity.color = UIManager.Instance.RarityColor(content[c].Rarity);
						lockedIcon.sprite = milestone.Unlock.Icon;
						if (content[c] is EnhancementModule)
						{
							lockedBorder.sprite = moduleBorders[(int)milestone.Unlock.Rarity];
							lockedMask.sprite = moduleMask;
						}
						else if (content[c] is EnhancementUpgrade { IsRelic: not false })
						{
							lockedBorder.sprite = relicBorders[(int)milestone.Unlock.Rarity];
							lockedMask.sprite = relicMask;
						}
						else
						{
							lockedBorder.sprite = upgradeBorders[(int)milestone.Unlock.Rarity];
							lockedMask.sprite = upgradeMask;
						}
						lockedText.text = milestone.DescriptionKey.GetLocalizedString();
					}
				}
				return;
			}
		}
		unlockedText.text = content[c].DescriptionKey.GetLocalizedString();
		unlockedIcon.sprite = content[c].Icon;
		unlockedName.text = content[c].NameKey.GetLocalizedString();
		unlockedRarity.text = StringFormatHelper.GetRarityString(content[c]);
		unlockedRarity.color = UIManager.Instance.RarityColor(content[c].Rarity);
		if (content[c] is EnhancementModule)
		{
			unlockedBorder.sprite = moduleBorders[(int)content[c].Rarity];
			unlockedMask.sprite = moduleMask;
		}
		else if (content[c] is EnhancementUpgrade { IsRelic: not false })
		{
			unlockedBorder.sprite = relicBorders[(int)content[c].Rarity];
			unlockedMask.sprite = relicMask;
		}
		else
		{
			unlockedBorder.sprite = upgradeBorders[(int)content[c].Rarity];
			unlockedMask.sprite = upgradeMask;
		}
		lockedPage.SetActive(value: false);
		unlockedPage.SetActive(value: true);
		Enhancement enhancement = content[c];
		EnhancementModule enhModule = enhancement as EnhancementModule;
		if ((object)enhModule != null)
		{
			isItemSelected = false;
			SetBackButtonActive(active: true);
			enhancementsPage.SetActive(value: true);
			AddUpgrades(enhModule, skipNavigation: true);
			headerIcon.sprite = enhModule.Icon;
			headerName.text = enhModule.NameKey.GetLocalizedString();
			headerButton.onClick.AddListener(delegate
			{
				SetModuleHeaderInfo(enhModule);
			});
			headerBorder.sprite = moduleBorders[(int)enhModule.Rarity];
			headerMask.sprite = moduleMask;
			enhancementScrollbar.value = 0f;
			enhancementScrollRect.horizontalNormalizedPosition = 0f;
			SpriteState spriteState = headerButton.GetComponent<Button>().spriteState;
			spriteState.highlightedSprite = modulesHoverSprite;
			spriteState.selectedSprite = modulesSelectedSprite;
			headerButton.GetComponent<Button>().spriteState = spriteState;
			enhancementScrollbar.value = 0f;
			enhancementScrollRect.horizontalNormalizedPosition = 0f;
			SetNavigationForGrid(enhancementsPageItemContainer, hasBackButton: true);
		}
	}

	private void SetNavigationForGrid(GameObject gridContainer, bool hasBackButton = false)
	{
		StartCoroutine(SetNavForGridCrtn(gridContainer, hasBackButton));
	}

	private IEnumerator WaitForGridChildren(GameObject gridContainer)
	{
		gridChildrenFound = false;
		yield return new WaitUntil(() => gridContainer != null && gridContainer.transform.childCount > 0);
		gridChildrenFound = true;
	}

	private IEnumerator WaitForGridSearchTimeout(float timeout)
	{
		gridSearchTimeout = false;
		yield return new WaitForSeconds(timeout);
		gridSearchTimeout = true;
	}

	private IEnumerator SetNavForGridCrtn(GameObject gridContainer, bool hasBackButton = false)
	{
		if (hasBackButton)
		{
			Coroutine wfcc = StartCoroutine(WaitForGridChildren(gridContainer));
			StartCoroutine(WaitForGridSearchTimeout(0.1f));
			yield return new WaitUntil(() => gridChildrenFound || gridSearchTimeout);
			StopCoroutine(wfcc);
		}
		new WaitUntil(() => gridContainer.transform.childCount > 0);
		new WaitForSeconds(0.1f);
		int childCount = gridContainer.transform.childCount;
		GridLayoutGroup component = gridContainer.GetComponent<GridLayoutGroup>();
		columns = component.constraintCount;
		rows = Mathf.CeilToInt((float)childCount / (float)columns);
		for (int num = 0; num < rows; num++)
		{
			for (int num2 = 0; num2 < columns; num2++)
			{
				int num3 = num * columns + num2;
				if (num3 >= childCount)
				{
					break;
				}
				TryGetGridButtonAtIndex(gridContainer.transform, num3).gameObject.GetComponent<NoticeBoardContent>().Index = num3;
				Navigation navigation = new Navigation
				{
					mode = Navigation.Mode.Explicit
				};
				if (num > 0)
				{
					navigation.selectOnUp = TryGetGridButtonAtIndex(gridContainer.transform, num3 - columns);
				}
				if (num < rows - 1)
				{
					navigation.selectOnDown = TryGetGridButtonAtIndex(gridContainer.transform, num3 + columns);
				}
				if (num2 > 0)
				{
					navigation.selectOnLeft = TryGetGridButtonAtIndex(gridContainer.transform, num3 - 1);
				}
				if (num2 < columns - 1)
				{
					navigation.selectOnRight = TryGetGridButtonAtIndex(gridContainer.transform, num3 + 1);
				}
				gridContainer.transform.GetChild(num3).GetComponent<Button>().navigation = navigation;
			}
		}
		if (childCount > 0 && hasBackButton)
		{
			Button button = TryGetGridButtonAtIndex(gridContainer.transform, 0);
			Navigation navigation2 = button.navigation;
			navigation2.selectOnUp = BackButton;
			button.navigation = navigation2;
			Navigation navigation3 = BackButton.navigation;
			navigation3.mode = Navigation.Mode.Explicit;
			navigation3.selectOnDown = button;
			BackButton.navigation = navigation3;
		}
	}

	private Button TryGetGridButtonAtIndex(Transform gridTf, int index)
	{
		try
		{
			return gridTf.GetChild(index).GetComponent<Button>();
		}
		catch
		{
			return null;
		}
	}

	public void SetModuleHeaderInfo(EnhancementModule module)
	{
		unlockedIcon.sprite = module.Icon;
		unlockedName.text = module.NameKey.GetLocalizedString();
		unlockedRarity.text = StringFormatHelper.GetRarityString(module);
		unlockedRarity.color = UIManager.Instance.RarityColor(module.Rarity);
		unlockedBorder.sprite = moduleBorders[(int)module.Rarity];
		unlockedMask.sprite = moduleMask;
		unlockedText.text = module.DescriptionKey.GetLocalizedString();
	}

	private void PlayMainSound()
	{
		HomeButton.GetComponent<UnitAudioController>().PlayMain();
	}
}
