using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class ChoiceWindow : Menu
{
	[SerializeField]
	private Transform choiceCardsTf;

	[SerializeField]
	private GameObject cardPrefab;

	private List<CardContainer> cardContainers;

	private LevelLoot currentLoot;

	private List<Enhancement> _enhancements;

	private List<Enhancement> _oldEnhancements;

	[SerializeField]
	private Button rerollButton;

	[SerializeField]
	private TextMeshProUGUI rerollText;

	[SerializeField]
	private TextMeshProUGUI gamepadRerollText;

	[SerializeField]
	private GameObject gamepadReroll;

	[SerializeField]
	private Button skipButton;

	[SerializeField]
	private TextMeshProUGUI skipText;

	private float skipScrap;

	[SerializeField]
	[Tooltip("When you skip a choice you get scrap equal to the most expensive card multiplied by this value.")]
	private float skipScrapMult;

	[SerializeField]
	private GameObject reopenButtonGo;

	[SerializeField]
	private GameObject reopenGamepadInput;

	private const string LOCALE_TABLE = "LocalizationTable";

	private const string REROLL_KEY = "Reroll";

	private const string SCRAP_KEY = "Recycle All";

	[SerializeField]
	private AudioClip snapAudio;

	private AudioSource audioSource;

	private int frameOpened;

	private int lootCount;

	private LootType generatedLootType;

	[SerializeField]
	private Stats ModuleCannonStats;

	[SerializeField]
	private TextMeshProUGUI mainText;

	[SerializeField]
	private GameObject continueButton;

	private bool canSkip;

	private bool preventReroll;

	private bool preventRecycle;

	private bool canReroll;

	private Rarity highestRarity;

	public bool CanRecycleLoot { get; set; }

	[field: SerializeField]
	public LocalizedString noUpgradesLeftKey { get; private set; }

	public override void Init()
	{
		base.Init();
		audioSource = GetComponent<AudioSource>();
		choiceCardsTf = base.transform.Find("ChoiceCards");
		cardContainers = new List<CardContainer>();
		rerollButton.onClick.AddListener(RerollLoot);
		skipButton.onClick.AddListener(SkipLoot);
		LevelManager.Instance.DestinationReached += HandleDestinationReached;
		LevelManager.Instance.NextLevelSelected += delegate
		{
			HandleNextLevelSelected();
		};
	}

	protected override void OnOpen()
	{
		if (canSkip)
		{
			mainText.text = noUpgradesLeftKey.GetLocalizedString();
			continueButton.SetActive(value: true);
			return;
		}
		continueButton.SetActive(value: false);
		UpdateRerollText(ResourceManager.Instance.Rerolls.Value);
		skipButton.gameObject.SetActive(CanRecycleLoot && ZoneManager.Instance.CurrentZoneIndex > 0);
		frameOpened = Time.frameCount;
		DisplayEnhancements();
	}

	private void Update()
	{
		if (!PlayerManager.Instance.IsCoop && base.gameObject.activeSelf && (bool)InputManager.Instance.LastPlayerControllerUsed && InputManager.Instance.LastPlayerControllerUsed.Reroll && frameOpened != Time.frameCount)
		{
			RerollLoot();
		}
		else if (PlayerManager.Instance.IsCoop && base.gameObject.activeSelf && (PlayerManager.Instance.Players[0].Reroll || PlayerManager.Instance.Players[1].Reroll) && frameOpened != Time.frameCount)
		{
			RerollLoot();
		}
	}

	private void ShowRerollButton()
	{
		if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "T0_Tutorial" || currentLoot.LootType == LootType.Module)
		{
			HideRerollButton();
			return;
		}
		preventReroll = false;
		if (InputManager.Instance.IsLastInputGamepad)
		{
			gamepadReroll.SetActive(value: true);
			rerollButton.gameObject.SetActive(value: false);
		}
		else
		{
			gamepadReroll.SetActive(value: false);
			rerollButton.gameObject.SetActive(value: true);
		}
	}

	private void HideRerollButton()
	{
		preventReroll = true;
		rerollButton.gameObject.SetActive(value: false);
		gamepadReroll.SetActive(value: false);
	}

	private void HandleDestinationReached()
	{
		if ((!LevelManager.Instance.DestinationReachedOnLoad || !SaveManager.Instance.ColectedLevelReward) && LevelManager.Instance.CurrentLevel.LevelType != LevelType.Boss && LevelManager.Instance.CurrentLevel.Index != 0)
		{
			LootType lootType = LevelManager.Instance.CurrentLevel.LootType;
			if (lootType != LootType.Shop && lootType != LootType.MysteryLocation)
			{
				SetLoot(LevelManager.Instance.CurrentLevel.Loot);
				MenuManager.Instance.OpenMenu(MenuType.Choice);
				MenuManager.Instance.MenuClosed += HandleMenuClosed;
				MenuManager.Instance.MenuOpened += HandleMenuOpened;
			}
		}
	}

	private void HandleNextLevelSelected()
	{
		reopenButtonGo.gameObject.SetActive(value: false);
		reopenGamepadInput.gameObject.SetActive(value: false);
		Debug.Log("disabled from handlenextlevelselected");
		MenuManager.Instance.MenuClosed -= HandleMenuClosed;
		MenuManager.Instance.MenuOpened -= HandleMenuOpened;
	}

	private void HandleMenuClosed(Menu menu)
	{
		InputManager.Instance.OnYPressed -= OnReopenPressed;
		LootType lootType = LevelManager.Instance.CurrentLevel.LootType;
		bool flag = LevelManager.Instance.IsAtDestination && !LevelManager.Instance.CurrentLevel.IsLooted && lootType != LootType.Shop && lootType != LootType.None && LevelManager.Instance.NextLevel == null;
		if (canSkip)
		{
			return;
		}
		if (InputManager.Instance.IsLastInputGamepad)
		{
			reopenGamepadInput.SetActive(flag);
		}
		else
		{
			reopenButtonGo.SetActive(flag);
		}
		if (flag)
		{
			InputManager.Instance.OnYPressed += OnReopenPressed;
		}
		if (cardContainers.Count <= 0)
		{
			return;
		}
		foreach (CardContainer cardContainer in cardContainers)
		{
			cardContainer.gameObject.SetActive(value: false);
		}
	}

	private void OnReopenPressed(int _, InputAction.CallbackContext __)
	{
		if (!base.gameObject.activeSelf && LevelManager.Instance.CurrentLevel.LootType != LootType.Shop)
		{
			MenuManager.Instance.OpenMenu(base.MenuType);
		}
	}

	private void HandleMenuOpened(Menu menu)
	{
		reopenButtonGo.SetActive(value: false);
		reopenGamepadInput.SetActive(value: false);
	}

	private void NewEnhancements()
	{
		if (_enhancements == null)
		{
			_oldEnhancements = new List<Enhancement>();
		}
		else
		{
			_oldEnhancements = _enhancements;
		}
		_enhancements = new List<Enhancement>();
		Enhancement enhancement = null;
		lootCount = 0;
		if (LevelManager.Instance.CurrentLevel.LootType == LootType.Lever || LevelManager.Instance.CurrentLevel.LootType == LootType.Claw || LevelManager.Instance.CurrentLevel.LootType == LootType.Cannon)
		{
			enhancement = LootUtils.GetTutorialLoot(LevelManager.Instance.CurrentLevel.LootType);
			if (!(enhancement == null))
			{
				_enhancements.Add(enhancement);
				_oldEnhancements.Add(enhancement);
				lootCount++;
			}
			return;
		}
		for (int i = 0; i < LevelManager.Instance.CurrentLevel.Difficulty.GetLootCount(); i++)
		{
			enhancement = LootUtils.GetRandomLoot(currentLoot.LootType, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), _oldEnhancements);
			if (currentLoot.LootType == LootType.Relic && UpgradeManager.Instance.RelicsInInventory[8] != null)
			{
				enhancement = LootUtils.GetRandomLoot(LootType.Upgrade, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), _oldEnhancements);
			}
			else if (currentLoot.LootType == LootType.Module && !Train.Instance.GetFirstEmptyModuleSlot())
			{
				enhancement = LootUtils.GetRandomLoot(LootType.Upgrade, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), _oldEnhancements);
			}
			if (enhancement == null && lootCount == 0)
			{
				enhancement = GenerateAnyLoot(enhancement, _oldEnhancements);
			}
			else if (enhancement == null && lootCount > 0)
			{
				enhancement = GenerateAnyLoot(enhancement, _oldEnhancements);
				if (GetLootType(enhancement) != generatedLootType)
				{
					break;
				}
			}
			if (enhancement == null)
			{
				break;
			}
			_enhancements.Add(enhancement);
			_oldEnhancements.Add(enhancement);
			lootCount++;
			generatedLootType = GetLootType(enhancement);
			canReroll = CheckForLoot(generatedLootType, _oldEnhancements);
			if (!canReroll)
			{
				HideRerollButton();
			}
		}
	}

	public bool CheckForLoot(LootType lootType, List<Enhancement> blacklist)
	{
		switch (lootType)
		{
		case LootType.Relic:
			if (lootCount >= UpgradeManager.Instance.Relics.Count - UpgradeManager.Instance.RelicsInInventory.Length)
			{
				return false;
			}
			return true;
		case LootType.Module:
			if (lootCount >= UpgradeManager.Instance.Modules.Count - UpgradeManager.Instance.ModulesInInventory.Count)
			{
				return false;
			}
			return true;
		case LootType.CannonUpgrade:
		{
			List<EnhancementUpgrade> list2 = LootUtils.ViableUpgrades();
			int num2 = 0;
			foreach (EnhancementUpgrade item in list2)
			{
				Stats[] statsObjectsToUpgrade = item.StatsObjectsToUpgrade;
				for (int i = 0; i < statsObjectsToUpgrade.Length; i++)
				{
					if (statsObjectsToUpgrade[i] == ModuleCannonStats)
					{
						num2++;
					}
				}
			}
			if (lootCount >= num2)
			{
				return false;
			}
			return true;
		}
		case LootType.Upgrade:
		{
			List<EnhancementUpgrade> list = LootUtils.ViableUpgrades();
			int num = 0;
			foreach (EnhancementUpgrade item2 in list)
			{
				Stats[] statsObjectsToUpgrade = item2.StatsObjectsToUpgrade;
				for (int i = 0; i < statsObjectsToUpgrade.Length; i++)
				{
					if (statsObjectsToUpgrade[i] != ModuleCannonStats)
					{
						num++;
					}
				}
			}
			if (lootCount >= num)
			{
				return false;
			}
			return true;
		}
		default:
			return false;
		}
	}

	public LootType GetLootType(Enhancement en)
	{
		if (en is EnhancementModule)
		{
			return LootType.Module;
		}
		if (en is EnhancementUpgrade { IsRelic: not false })
		{
			return LootType.Relic;
		}
		if (en is EnhancementUpgrade { StatsObjectsToUpgrade: var statsObjectsToUpgrade })
		{
			for (int i = 0; i < statsObjectsToUpgrade.Length; i++)
			{
				if (statsObjectsToUpgrade[i] == ModuleCannonStats)
				{
					return LootType.CannonUpgrade;
				}
			}
		}
		return LootType.Upgrade;
	}

	public Enhancement GenerateAnyLoot(Enhancement en, List<Enhancement> oldEnhancements)
	{
		en = LootUtils.GetRandomLoot(LootType.Upgrade, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), oldEnhancements);
		if (en == null)
		{
			en = LootUtils.GetRandomLoot(LootType.CannonUpgrade, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), oldEnhancements);
		}
		if (en == null && UpgradeManager.Instance.RelicsInInventory[8] == null)
		{
			en = LootUtils.GetRandomLoot(LootType.Relic, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), oldEnhancements);
		}
		if (en == null && (bool)Train.Instance.GetFirstEmptyModuleSlot())
		{
			en = LootUtils.GetRandomLoot(LootType.Module, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), oldEnhancements);
		}
		if (en == null)
		{
			return null;
		}
		return en;
	}

	public void SetLoot(LevelLoot loot)
	{
		currentLoot = loot;
		_enhancements = null;
		List<Enhancement> rewards = SaveManager.Instance.GetRewards();
		if (rewards != null && rewards.Count > 0)
		{
			LoadLoot();
		}
		else
		{
			NewLoot();
		}
	}

	public void RerollLoot()
	{
		if (!preventReroll && ZoneManager.Instance.CurrentZoneIndex > 0 && !LevelManager.Instance.CurrentLevel.IsLooted && (currentLoot.LootType != LootType.Module || !Train.Instance.GetFirstEmptyModuleSlot()) && ResourceManager.Instance.Rerolls.TrySpend(1f))
		{
			UpdateRerollText(ResourceManager.Instance.Rerolls.Value);
			Reroll();
		}
	}

	public void SkipLoot()
	{
		if (!(MenuManager.Instance.CurrentMenu != this))
		{
			ResourceManager.Instance.Scrap.AddValue(skipScrap);
			MenuManager.Instance.CloseAllMenus();
			LevelManager.Instance.CurrentLevel.IsLooted = true;
			SaveManager.Instance.SaveJourney();
		}
	}

	private void UpdateRerollText(float rerolls)
	{
		if (currentLoot.LootType == LootType.Module && (bool)Train.Instance.GetFirstEmptyModuleSlot())
		{
			HideRerollButton();
			return;
		}
		rerolls = Mathf.FloorToInt(rerolls);
		string[] arguments = new string[1] { rerolls.ToString() };
		if (InputManager.Instance.IsLastInputGamepad)
		{
			AsyncOperationHandle<string> localizedStringAsync = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("LocalizationTable", "Reroll", arguments);
			localizedStringAsync.Completed += delegate(AsyncOperationHandle<string> handle)
			{
				gamepadRerollText.text = handle.Result;
			};
		}
		else
		{
			AsyncOperationHandle<string> localizedStringAsync = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("LocalizationTable", "Reroll", arguments);
			localizedStringAsync.Completed += delegate(AsyncOperationHandle<string> handle)
			{
				rerollText.text = handle.Result;
			};
		}
	}

	public void NewLoot()
	{
		GenerateNewLoot();
	}

	private void GenerateNewLoot(CargoContainer container = null)
	{
		canSkip = false;
		SaveManager.Instance.ClearRewards();
		NewEnhancements();
		ClearChoiceCards();
		UpdateSkip();
		foreach (Enhancement enhancement in _enhancements)
		{
			SaveManager.Instance.AddReward(enhancement);
		}
		if (lootCount == 0)
		{
			canSkip = true;
		}
		if (container != null)
		{
			DisplayEnhancements();
			container.OnContainerDropped -= GenerateNewLoot;
		}
	}

	private void Reroll()
	{
		if (cardContainers.Count > 0)
		{
			foreach (CardContainer cardContainer in cardContainers)
			{
				cardContainer.Anim.Play("Raise");
				if (cardContainers.IndexOf(cardContainer) == cardContainers.Count - 1)
				{
					cardContainer.OnContainerDropped += GenerateNewLoot;
				}
			}
			return;
		}
		GenerateNewLoot();
	}

	public void LoadLoot()
	{
		canSkip = false;
		_enhancements = SaveManager.Instance.GetRewards();
		lootCount = _enhancements.Count;
		canReroll = true;
		ClearChoiceCards();
		UpdateSkip();
		if (lootCount == 0)
		{
			canSkip = true;
		}
	}

	private void DisplayEnhancements()
	{
		base.gameObject.SetActive(value: true);
		if (lootCount != 0)
		{
			StartCoroutine(SpawnCardsCoroutine());
		}
	}

	private IEnumerator SpawnCardsCoroutine()
	{
		if (canReroll)
		{
			ShowRerollButton();
		}
		else
		{
			HideRerollButton();
		}
		cardContainers.Clear();
		if (LevelManager.Instance.CurrentLevel.LootType == LootType.Lever || LevelManager.Instance.CurrentLevel.LootType == LootType.Claw || LevelManager.Instance.CurrentLevel.LootType == LootType.Cannon)
		{
			Enhancement enhancement = _enhancements[0];
			if (enhancement != null)
			{
				GameObject obj = Object.Instantiate(cardPrefab, choiceCardsTf);
				obj.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
				CardContainer component = obj.GetComponent<CardContainer>();
				cardContainers.Add(component);
				EnhancementCard card = component.Card;
				card.Initialize(enhancement, 0);
				card.Obtained += delegate
				{
					HandleCardObtained(0);
				};
				Canvas.ForceUpdateCanvases();
				LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)obj.transform);
			}
			yield return new WaitForSecondsRealtime(0.1f);
		}
		else
		{
			highestRarity = Rarity.Common;
			for (int i = 0; i < lootCount; i++)
			{
				Enhancement enhancement2 = _enhancements[i];
				if (enhancement2 != null)
				{
					GameObject obj2 = Object.Instantiate(cardPrefab, choiceCardsTf);
					obj2.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
					CardContainer component2 = obj2.GetComponent<CardContainer>();
					cardContainers.Add(component2);
					EnhancementCard card2 = component2.Card;
					card2.Initialize(enhancement2, 0);
					int ii = i;
					card2.Obtained += delegate
					{
						HandleCardObtained(ii);
					};
					Canvas.ForceUpdateCanvases();
					LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)obj2.transform);
					if (enhancement2.Rarity > highestRarity)
					{
						highestRarity = enhancement2.Rarity;
					}
					if (i == lootCount - 1)
					{
						card2.Container.OnContainerOpened += SelectCenterCard;
						card2.Container.OnContainerOpened += PlayContainerRaritySFX;
					}
				}
				yield return new WaitForSecondsRealtime(0.1f);
			}
		}
		foreach (CardContainer cardContainer in cardContainers)
		{
			cardContainer.Card.GetComponent<Button>().interactable = true;
		}
		SetupNavigation();
	}

	private void HandleCardObtained(int selectedIndex)
	{
		for (int i = 0; i < cardContainers.Count; i++)
		{
			cardContainers[i].Card.GetComponent<Button>().interactable = false;
			if (i == selectedIndex)
			{
				cardContainers[i].Anim.Play("Chosen");
				if (cardContainers.Count > 1)
				{
					cardContainers[i].PlayChainBreakSound();
				}
			}
			else
			{
				cardContainers[i].Anim.Play("Raise");
				audioSource.PlayOneShot(snapAudio);
			}
		}
		HideRerollButton();
		LevelManager.Instance.CurrentLevel.IsLooted = true;
		SaveManager.Instance.ColectedLevelReward = true;
		StartCoroutine(CloseMenusAfterDelay(1.5f));
	}

	private IEnumerator CloseMenusAfterDelay(float delay)
	{
		yield return new WaitForSecondsRealtime(delay);
		MenuManager.Instance.CloseAllMenus();
	}

	private void SelectCenterCard(CargoContainer container)
	{
		if (cardContainers.Count != 0)
		{
			int index = Mathf.FloorToInt(cardContainers.Count / 2);
			cardContainers[index].Card.containerOutlineImage.gameObject.SetActive(value: true);
			EventSystem.current.SetSelectedGameObject(cardContainers[index].Card.gameObject);
		}
	}

	private void UpdateSkip()
	{
		if (_enhancements == null || _enhancements.Count == 0)
		{
			return;
		}
		skipScrap = 0f;
		foreach (Enhancement enhancement in _enhancements)
		{
			if (!(enhancement == null) && (float)enhancement.Cost > skipScrap)
			{
				skipScrap = enhancement.Cost;
			}
		}
		skipScrap = Mathf.CeilToInt(skipScrap * skipScrapMult);
		string[] arguments = new string[1] { skipScrap.ToString() };
		AsyncOperationHandle<string> localizedStringAsync = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("LocalizationTable", "Recycle All", arguments);
		localizedStringAsync.Completed += delegate(AsyncOperationHandle<string> handle)
		{
			skipText.text = handle.Result;
		};
	}

	public void ClearChoiceCards()
	{
		for (int i = 0; i < choiceCardsTf.childCount; i++)
		{
			if (i == choiceCardsTf.childCount - 1)
			{
				choiceCardsTf.GetChild(i).gameObject.GetComponent<CargoContainer>().Card.Container.OnContainerOpened -= SelectCenterCard;
				choiceCardsTf.GetChild(i).gameObject.GetComponent<CargoContainer>().Card.Container.OnContainerOpened -= PlayContainerRaritySFX;
			}
			Object.Destroy(choiceCardsTf.GetChild(i).gameObject);
		}
		cardContainers.Clear();
	}

	private void SetupNavigation()
	{
		if (!canSkip)
		{
			int index = cardContainers.Count / 2;
			for (int i = 0; i < cardContainers.Count; i++)
			{
				Button component = cardContainers[i].Card.GetComponent<Button>();
				Navigation navigation = new Navigation
				{
					mode = Navigation.Mode.Explicit
				};
				navigation.selectOnLeft = ((i > 0) ? cardContainers[i - 1].Card.GetComponent<Button>() : null);
				navigation.selectOnRight = ((i < cardContainers.Count - 1) ? cardContainers[i + 1].Card.GetComponent<Button>() : null);
				navigation.selectOnDown = rerollButton;
				component.navigation = navigation;
			}
			Navigation navigation2 = new Navigation
			{
				mode = Navigation.Mode.Explicit
			};
			navigation2.selectOnUp = cardContainers[index].Card.GetComponent<Button>();
			navigation2.selectOnDown = skipButton;
			rerollButton.navigation = navigation2;
			Navigation navigation3 = new Navigation
			{
				mode = Navigation.Mode.Explicit
			};
			navigation3.selectOnUp = rerollButton;
			skipButton.navigation = navigation3;
			EventSystem.current.SetSelectedGameObject(cardContainers[index].Card.gameObject);
		}
	}

	private void PlayContainerRaritySFX(CargoContainer cont)
	{
		cont.gameObject.GetComponent<CardContainer>().PlayBackgroundSFX(highestRarity);
	}
}
