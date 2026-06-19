using System;
using System.Collections.Generic;
using ModIOBrowser;
using Pug.UnityExtensions;
using Rewired;
using Unity.Profiling;
using UnityEngine;

public class UIManager : ManagerBase
{
	[Serializable]
	public class CraftingUITheme
	{
		public CraftingUIThemeType craftingUIThemeType;

		public string leftWindowTitleTerm;

		public string midWindowTitleTerm;

		public string rightWindowTitleTerm;

		public Color textColor;

		public Color textOutlineColor;

		public Sprite background;

		public Sprite categoryBackground;

		public Color backgroundColor;

		public Sprite outputSlotBackground;

		public Sprite inventorySlotBackground;

		public Sprite inventorySlotTiledDecorationBackground;

		public Sprite slotHoverSprite;

		public Sprite slotSelectSprite;

		public Sprite arrowSprite;
	}

	public enum CraftingUIThemeType
	{
		Wood = 0,
		Stone = 1,
		Merchant = 2,
		UpgradeForge = 3,
		DangerousUsage = 4
	}

	[Serializable]
	public class InventoryUIStateTheme
	{
		public InventoryUIStateThemeType inventoryUIStateThemeType;

		public Color backgroundColor;

		public Color slotBackgroundColor;

		public Color slotBorderColor;
	}

	public enum InventoryUIStateThemeType
	{
		Default = 0,
		Locking = 1,
		QuickTrash = 2
	}

	[Serializable]
	public class SkillColor
	{
		public SkillID skillID;

		public Color color;
	}

	[Serializable]
	public class ObjectCategoryTagColor
	{
		public ObjectCategoryTag categoryTag;

		public Color backgroundColor;
	}

	[Serializable]
	public class CategoryTagSprite
	{
		public ObjectCategoryTag tag;

		public Sprite sprite;
	}

	[Header("UI container references:")]
	public PlayerHealthBarUI playerHealthBarUI;

	public CastBarUI castbar;

	public CastBarUI equipmentConditionBar;

	public GameObject UICamera;

	public List<Color> playerColors;

	public CharacterWindowUI characterWindow;

	public ItemSlotsBarUI itemSlotsBar;

	public InventoryButton inventoryButton;

	public MapButton mapButton;

	public RightClickActionButton rightClickActionButton;

	public ItemSlotsUIContainer playerInventoryUI;

	public TrashCanInventoryUI trashCanUI;

	public ChestInventoryUI chestInventoryUI;

	public ItemSlotsUIContainer salvageAndRepairUI;

	public ItemSlotsUIContainer upgradeForgeUI;

	public SellUI sellUI;

	public BuyUI buyUI;

	public CraftingSelectorUI creativeModeUI;

	public CreativeModeOptionsUI creativeModeOptionsUI;

	public CattleUI cattleUI;

	public SignTextUI signUI;

	public CraftingUIBase bossStatueUI;

	public CraftingUIBase biomeBossStatueUI;

	public CraftingUIBase biomeBossHydraStatueUI;

	public CraftingUIBase cookingCraftingUI;

	public ProcessResourcesCraftingUI processResourcesCraftingUI;

	public ExtractResourcesCraftingUI extractResourcesCraftingUI;

	public FishingCraftingUI fishingCraftingUI;

	public FilteringUI filteringUI;

	public SimpleCraftingUIContainer simpleCraftingUIContainer;

	public EquipmentInventoryUI equipmentInventoryUI;

	public VanityUI vanityUI;

	public InstrumentUI instrumentUI;

	public ChatWindow chatWindow;

	public ShortCutsWindow shortCutsWindow;

	public StreamIntegrationInfoText streamIntegrationInfoText;

	public List<Color> slotBorderRarityColors;

	public Color itemLevelColor = new Color(1f, 0.9041561f, 0.2862746f);

	public Color manaTextColor = new Color(0.427451f, 41f / 51f, 1f);

	public Color electricityColor = new Color(1f, 1f, 0f);

	[ArrayElementTitle("craftingUIThemeType")]
	public List<CraftingUITheme> craftingUIThemes;

	[HideInInspector]
	public bool craftingMaterialsAreNotRequired;

	[ArrayElementTitle("inventoryUIStateTheme")]
	public List<InventoryUIStateTheme> inventoryUIStateThemes;

	public List<SkillColor> skillColors;

	public List<ObjectCategoryTagColor> objectCategoryTagColors;

	public Color brokenColor;

	public Color reinforcedColor;

	public Color previewReinforcedColor;

	public Color xpAndLevelTextColor;

	public List<CategoryTagSprite> categoryTagSprites;

	public ControllerButtonToCharTable controllerButtonToCharTable;

	private int inventoryActiveState;

	public MapUI mapUI;

	private int mapActiveState;

	public UIMouse mouse;

	public UISpecialAim specialAim;

	[ClearOnReload(false)]
	public static bool ShowOutdatedVersionPopUp = false;

	[ClearOnReload(true)]
	public static bool ShowInputMappingResetPopup = true;

	public UIelement currentSelectedUIElement;

	public InteractButton interactHintButton;

	public ConditionsTable conditionsIconsTable;

	public PetInfosTable petInfosTable;

	public ItemOverridesTable itemOverridesTable;

	public ItemDiscoveryUI ItemDiscoveryUI;

	private Fader gameplayUIFader;

	private Fader mouseFader;

	private const float GAMEPLAY_UI_FADE_IN_DURATION = 0.3f;

	private const float GAMEPLAY_UI_FADE_OUT_DURATION = 0.3f;

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("UIManager.Init");

	private Vector3 gameplayUIEnabledScaleMultipler = new Vector3(1f, 1f, 1f);

	private Vector3 targetScaleSceneMultipler = new Vector3(1f, 1f, 1f);

	private float gameplayUITargetScaleMultiplierCachedTime;

	private Vector3 cachedGameplayUITargetScaleMultiplier = Vector3.one;

	private bool _creativeModeUIShouldBeOn = true;

	private static readonly int GradientMap = Shader.PropertyToID("_GradientMap");

	private const string GRADIENT_MAP_KEYWORD = "USE_GRADIENT_MAP";

	private static Dictionary<GradientMapDataBlock, Texture2D> s_runtimeGradientCache = new Dictionary<GradientMapDataBlock, Texture2D>();

	private Dictionary<ObjectID, int> currentCategoryIndices = new Dictionary<ObjectID, int>();

	public bool inventoryOrMapWasActiveThisFrame { get; private set; }

	public CraftingUIBase activeCraftingUI => GetActiveCraftingUI();

	public bool isChestInventoryUIShowing => chestInventoryUI.isShowing;

	public bool isPlayerInventoryShowing => playerInventoryUI.isShowing;

	public bool isSalvageAndRepairUIShowing => salvageAndRepairUI.isShowing;

	public bool isUpgradeForgeUIShowing => upgradeForgeUI.isShowing;

	public bool isCraftingUIShowing
	{
		get
		{
			if (activeCraftingUI != null)
			{
				return activeCraftingUI.isShowing;
			}
			return false;
		}
	}

	public bool isSellUIShowing => sellUI.isShowing;

	public bool isBuyUIShowing => buyUI.isShowing;

	public bool isAnyInventoryShowing
	{
		get
		{
			if (!isPlayerInventoryShowing && !isChestInventoryUIShowing && !isSellUIShowing)
			{
				return isBuyUIShowing;
			}
			return true;
		}
	}

	public bool isPlayerEquipmentShowing => equipmentInventoryUI.isShowing;

	public bool isVanitySlotsShowing => vanityUI.isShowing;

	public bool inventoryWasActiveThisFrame => inventoryActiveState >= 1;

	public bool isShowingMap => mapUI.IsShowingBigMap;

	public bool mapWasActiveThisFrame => mapActiveState >= 1;

	public bool isMouseShowing
	{
		get
		{
			if (!Manager.input.SystemPrefersKeyboardAndMouse() && !isAnyInventoryShowing && !isShowingMap)
			{
				if (currentSelectedUIElement != null)
				{
					return currentSelectedUIElement.keepMouseActiveButHiddenOnHoverWhenUsingController;
				}
				return false;
			}
			return true;
		}
	}

	private float time => Time.unscaledTime;

	public Color GetSlotBorderRarityColor(Rarity rarity, bool useDefaultColorForCommon, Color defaultColor)
	{
		if (useDefaultColorForCommon && (rarity == Rarity.Common || rarity == Rarity.Poor))
		{
			return defaultColor;
		}
		return Manager.ui.slotBorderRarityColors[(int)(rarity + 1)];
	}

	public CraftingUITheme GetCraftingUITheme(CraftingUIThemeType craftingUIThemeType)
	{
		for (int i = 0; i < craftingUIThemes.Count; i++)
		{
			if (craftingUIThemes[i].craftingUIThemeType == craftingUIThemeType)
			{
				return craftingUIThemes[i];
			}
		}
		Debug.LogError("Missing crafting ui theme setup for " + craftingUIThemeType);
		return null;
	}

	public InventoryUIStateTheme GetInventoryUIStateTheme(InventoryUIStateThemeType inventoryUIStateThemeType)
	{
		for (int i = 0; i < craftingUIThemes.Count; i++)
		{
			if (inventoryUIStateThemes[i].inventoryUIStateThemeType == inventoryUIStateThemeType)
			{
				return inventoryUIStateThemes[i];
			}
		}
		Debug.LogError("Missing inventory ui state theme setup for " + inventoryUIStateThemeType);
		return null;
	}

	public Color GetSkillColor(SkillID skillID)
	{
		foreach (SkillColor skillColor in Manager.ui.skillColors)
		{
			if (skillColor.skillID == skillID)
			{
				return skillColor.color;
			}
		}
		return Color.white;
	}

	public ObjectCategoryTagColor GetObjectCategoryTagColors(ObjectCategoryTag categoryTag)
	{
		foreach (ObjectCategoryTagColor objectCategoryTagColor in objectCategoryTagColors)
		{
			if (objectCategoryTagColor.categoryTag == categoryTag)
			{
				return objectCategoryTagColor;
			}
		}
		return null;
	}

	public Sprite GetCategoryTagSprite(ObjectCategoryTag categoryTag)
	{
		foreach (CategoryTagSprite categoryTagSprite in categoryTagSprites)
		{
			if (categoryTagSprite.tag == categoryTag)
			{
				return categoryTagSprite.sprite;
			}
		}
		return null;
	}

	private CraftingUIBase GetActiveCraftingUI()
	{
		if (simpleCraftingUIContainer.isShowing)
		{
			return simpleCraftingUIContainer;
		}
		if (bossStatueUI.isShowing)
		{
			return bossStatueUI;
		}
		if (biomeBossStatueUI.isShowing)
		{
			return biomeBossStatueUI;
		}
		if (biomeBossHydraStatueUI.isShowing)
		{
			return biomeBossHydraStatueUI;
		}
		if (cookingCraftingUI.isShowing)
		{
			return cookingCraftingUI;
		}
		if (processResourcesCraftingUI.isShowing)
		{
			return processResourcesCraftingUI;
		}
		if (extractResourcesCraftingUI.isShowing)
		{
			return extractResourcesCraftingUI;
		}
		if (fishingCraftingUI.isShowing)
		{
			return fishingCraftingUI;
		}
		return null;
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			gameplayUIFader = new Fader(0f, Fader.FadeFunction.SmoothStep);
			gameplayUIFader.delayFadeInTime = 0.5f;
			gameplayUIFader.delayFadeOutTime = 0.15f;
			mouseFader = new Fader(0f, Fader.FadeFunction.SmoothStep);
			mouseFader.delayFadeInTime = 0.5f;
			mouseFader.delayFadeOutTime = 0.15f;
			itemOverridesTable.Init();
			return true;
		}
	}

	public override void Deinit()
	{
		OnSceneUnload();
		base.Deinit();
	}

	protected override void Start()
	{
	}

	private void Update()
	{
		UpdateFrameDelayStates();
		if (Manager.sceneHandler == null || !Manager.sceneHandler.isInGame)
		{
			if (isAnyInventoryShowing)
			{
				HideAllInventoryAndCraftingUI();
			}
			if (isShowingMap)
			{
				mapUI.ToggleMap();
			}
		}
		if (Manager.main.player != null && Manager.main.player.inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.TOGGLE_UI) && (Manager.menu.quantumConsole == null || !Manager.menu.quantumConsole.IsActive))
		{
			Manager.prefs.hideInGameUI = !Manager.prefs.hideInGameUI;
		}
	}

	private void LateUpdate()
	{
		inventoryOrMapWasActiveThisFrame = isShowingMap || isAnyInventoryShowing;
		Cursor.visible = (byte)(0u | (Browser.IsOpen ? 1u : 0u)) != 0;
	}

	private void UpdateFrameDelayStates()
	{
		if (isShowingMap)
		{
			mapActiveState = 2;
		}
		else if (mapActiveState > 0)
		{
			mapActiveState--;
		}
		if (isAnyInventoryShowing)
		{
			inventoryActiveState = 2;
		}
		else if (inventoryActiveState > 0)
		{
			inventoryActiveState--;
		}
	}

	public float CalcMouseFadeValue()
	{
		if (Manager.menu.IsAnyMenuActive())
		{
			return 1f;
		}
		return Manager.load.GetFadeValue() * mouseFader.UpdateFadeValue(time);
	}

	public Vector3 CalcGameplayUITargetScaleMultiplier()
	{
		if (Time.unscaledTime <= gameplayUITargetScaleMultiplierCachedTime)
		{
			return cachedGameplayUITargetScaleMultiplier;
		}
		gameplayUITargetScaleMultiplierCachedTime = Time.unscaledTime;
		if (Manager.prefs.hideInGameUI || Manager.load.GetFadeDirection() == Fader.FadeDirection.Out || Manager.load.GetFadeValue() < 0.05f)
		{
			cachedGameplayUITargetScaleMultiplier = Vector3.zero;
			return cachedGameplayUITargetScaleMultiplier;
		}
		Vector3 vector = new Vector3(gameplayUIEnabledScaleMultipler.x * targetScaleSceneMultipler.x, gameplayUIEnabledScaleMultipler.y * targetScaleSceneMultipler.y, gameplayUIEnabledScaleMultipler.z * targetScaleSceneMultipler.z);
		float a = gameplayUIFader.UpdateFadeValue(time);
		float num = 0.25f;
		Vector3 vector2 = new Vector3(0f - num, 0f - num, 0f - num) + (1f + num) * vector * Mathf.Min(a, Manager.load.GetFadeValue());
		float x = Mathf.Clamp01(vector2.x);
		float y = Mathf.Clamp01(vector2.y);
		float z = Mathf.Clamp01(vector2.z);
		cachedGameplayUITargetScaleMultiplier = new Vector3(x, y, z);
		return cachedGameplayUITargetScaleMultiplier;
	}

	public void OnNewSceneHandler(SceneHandler sceneHandler)
	{
		if (sceneHandler.isInGame)
		{
			mapUI.gameObject.SetActive(value: true);
			mapUI.Init();
			FadeInAllGameplayUI();
			targetScaleSceneMultipler = new Vector3(1f, 1f, 1f);
		}
		else
		{
			targetScaleSceneMultipler = new Vector3(0f, 0f, 1f);
		}
		if (!sceneHandler.isIntro && !sceneHandler.isOutro && !sceneHandler.isGameStartUpLoading)
		{
			FadeInMouse();
		}
	}

	public void OnEquipmentSlotUpdated(int index)
	{
		itemSlotsBar.OnSlotUpdated(index);
	}

	public void OnEquipmentSlotActivated(int index)
	{
		itemSlotsBar.OnEquipmentSlotActivated(index);
		playerInventoryUI.OnEquipmentSlotActivated(index);
	}

	public void ShowBagLightUpHint()
	{
		inventoryButton.ShowLightUpHint();
	}

	public void HideBagLightUpHint()
	{
		inventoryButton.HideLightUpHint();
	}

	public void ShowMapLightUpHint()
	{
		mapButton.ShowLightUpHint();
	}

	public void ShowSoulsTabLightUpHint()
	{
		characterWindow.windowTabs[2].ShowLightUpHint();
	}

	public void ShowRecipeLightUpHint(ObjectID recipe)
	{
		CraftingUIBase craftingUIBase = GetActiveCraftingUI();
		if (craftingUIBase != null)
		{
			craftingUIBase.HighlightRecipe(recipe);
		}
	}

	public void ClearRecipeHighlights()
	{
		CraftingUIBase craftingUIBase = GetActiveCraftingUI();
		if (craftingUIBase != null)
		{
			craftingUIBase.ClearRecipeHighlights();
		}
	}

	public void OnPlayerInventoryOpen()
	{
		if (mapUI.IsShowingBigMap)
		{
			OnMapToggle();
		}
		inventoryButton.HideLightUpHint();
		playerInventoryUI.ShowContainerUI();
		trashCanUI.ShowContainerUI();
		PlayerController player = Manager.main.player;
		CraftingHandler craftingHandler = Manager.main.player.activeCraftingHandler;
		bool flag = isChestInventoryUIShowing || isSellUIShowing || isBuyUIShowing || isVanitySlotsShowing || cattleUI.isShowing || signUI.isShowing || filteringUI.isShowing;
		bool flag2 = craftingHandler != null && craftingHandler != player.playerCraftingHandler;
		if (_creativeModeUIShouldBeOn && Manager.saves.IsCreativeModeWorld() && !flag && !flag2)
		{
			creativeModeUI.ShowContainerUI();
		}
		else
		{
			creativeModeUI.HideContainerUI();
		}
		bool isShowing = creativeModeUI.isShowing;
		if (isShowing)
		{
			craftingHandler = null;
		}
		else if (craftingHandler != null && !flag)
		{
			switch (craftingHandler.craftingType)
			{
			case CraftingType.Simple:
				UpdateCurrentCategoryIndexToShow();
				simpleCraftingUIContainer.ShowCraftingUI();
				break;
			case CraftingType.ProcessResources:
				processResourcesCraftingUI.ShowCraftingUI();
				break;
			case CraftingType.BossStatue:
				bossStatueUI.ShowCraftingUI();
				break;
			case CraftingType.BiomeBossStatue:
				biomeBossStatueUI.ShowCraftingUI();
				break;
			case CraftingType.BiomeBossHydraStatue:
				biomeBossHydraStatueUI.ShowCraftingUI();
				break;
			case CraftingType.Cooking:
				cookingCraftingUI.ShowCraftingUI();
				break;
			case CraftingType.Extract:
				extractResourcesCraftingUI.ShowCraftingUI();
				break;
			case CraftingType.Incinerate:
				extractResourcesCraftingUI.ShowCraftingUI();
				break;
			case CraftingType.Fishing:
				fishingCraftingUI.ShowCraftingUI();
				break;
			case CraftingType.CritterCatching:
				fishingCraftingUI.ShowCraftingUI();
				break;
			}
		}
		bool flag3 = ((craftingHandler == player.playerCraftingHandler && player.activeInventoryHandler == null) || isSalvageAndRepairUIShowing || isUpgradeForgeUIShowing) && !isVanitySlotsShowing && !cattleUI.isShowing && !signUI.isShowing && !filteringUI.isShowing;
		if (flag3)
		{
			characterWindow.Show();
			AudioManager.SfxUI(SfxID.inventoryOpen, 1f, reuse: true, 0.5f, 0.15f, playOnGamepad: true);
		}
		else
		{
			characterWindow.Hide();
			AudioManager.SfxUI(SfxID.chestopen, 1f, reuse: true, 0.5f, 0.15f, playOnGamepad: true);
		}
		if (Manager.saves.IsCreativeModeWorld() && (flag3 || isShowing))
		{
			creativeModeOptionsUI.Show();
		}
		else
		{
			creativeModeOptionsUI.Hide();
			creativeModeUI.HideContainerUI();
		}
		if (!isSalvageAndRepairUIShowing && !isUpgradeForgeUIShowing && !isShowing)
		{
			simpleCraftingUIContainer.UpdatePosition(flag3);
		}
		else
		{
			simpleCraftingUIContainer.HideCraftingUI();
		}
		if (Manager.ui.currentSelectedUIElement != null && !Manager.ui.currentSelectedUIElement.gameObject.activeInHierarchy)
		{
			Manager.ui.DeselectAnySelectedUIElement();
			mouse.UpdateMouseUIInput(out var leftClickWasUsed, out leftClickWasUsed);
		}
	}

	public void OnChestInventoryOpen()
	{
		chestInventoryUI.ShowContainerUI();
		OnPlayerInventoryOpen();
	}

	public void OnSalvageAndRepairOpen()
	{
		salvageAndRepairUI.ShowContainerUI();
		OnPlayerInventoryOpen();
	}

	public void OnUpgradeForgeOpen()
	{
		upgradeForgeUI.ShowContainerUI();
		OnPlayerInventoryOpen();
	}

	public void OnVanitySlotsOpen()
	{
		vanityUI.Show();
		OnPlayerInventoryOpen();
	}

	public void OnVendorOpen()
	{
		sellUI.ShowContainerUI();
		buyUI.ShowContainerUI();
		OnPlayerInventoryOpen();
	}

	public void OnBuyWindowOpen()
	{
		buyUI.ShowContainerUI();
		OnPlayerInventoryOpen();
	}

	public void OnCattleWindowOpen()
	{
		cattleUI.ShowUI();
		OnPlayerInventoryOpen();
	}

	public void OnSignWindowOpen()
	{
		signUI.ShowUI();
		OnPlayerInventoryOpen();
	}

	public void OnFilterWindowOpen()
	{
		filteringUI.ShowUI();
		OnPlayerInventoryOpen();
	}

	public void OnCreativeModeUIOpen()
	{
		_creativeModeUIShouldBeOn = true;
		OnPlayerInventoryOpen();
	}

	public void OnCreativeModeUIClose()
	{
		_creativeModeUIShouldBeOn = false;
		OnPlayerInventoryOpen();
	}

	public void OnStreamIntegrationOpen(string text)
	{
		streamIntegrationInfoText.ShowText(text);
	}

	public void OnStreamIntegrationShowGiftCount(string text)
	{
		streamIntegrationInfoText.ShowGiftCountText(text);
	}

	public void OnStreamIntegrationClose()
	{
		streamIntegrationInfoText.HideText();
	}

	public void HideAllInventoryAndCraftingUI(bool forceClose = true)
	{
		bool flag = false;
		switch (mouse.mouseMode)
		{
		case UIMouse.MouseMode.QuickTrash:
			flag = true;
			mouse.ToggleQuickTrashMouseMode();
			break;
		case UIMouse.MouseMode.Locking:
			flag = true;
			mouse.ToggleLockingMouseMode();
			break;
		}
		if (!flag || forceClose)
		{
			if (characterWindow.isShowing)
			{
				AudioManager.SfxUI(SfxID.inventoryClose, 1f, reuse: true, 0.5f, 0.15f, playOnGamepad: true);
			}
			else if (playerInventoryUI.isShowing)
			{
				AudioManager.SfxUI(SfxID.chestclose, 1f, reuse: true, 0.3f, 0.1f, playOnGamepad: true);
			}
			characterWindow.Hide();
			playerInventoryUI.HideContainerUI();
			trashCanUI.HideContainerUI();
			chestInventoryUI.HideContainerUI();
			salvageAndRepairUI.HideContainerUI();
			upgradeForgeUI.HideContainerUI();
			vanityUI.Hide();
			if (Manager.main.player != null && isSellUIShowing)
			{
				Manager.main.player.sellSlotsHandler.MoveAllSlotsToPlayerInventoryOrDrop(Manager.main.player.RenderPosition);
			}
			sellUI.HideContainerUI();
			buyUI.HideContainerUI();
			cattleUI.HideUI();
			signUI.HideUI();
			creativeModeOptionsUI.Hide();
			creativeModeUI.HideContainerUI();
			if (activeCraftingUI != null)
			{
				activeCraftingUI.HideCraftingUI();
			}
			filteringUI.HideUI();
			if (Manager.input.textInputIsActive)
			{
				Manager.input.activeInputField.SetInputText("");
				Manager.input.activeInputField.Deactivate(commit: false);
			}
			PlayerController player = Manager.main.player;
			if (player != null)
			{
				player.SetActiveInventoryHandler(null);
			}
		}
	}

	public void OnMapToggle()
	{
		mapUI.ToggleMap();
		mapButton.HideLightUpHint();
	}

	public void HideMap()
	{
		_ = mapUI.IsShowingBigMap;
		mapUI.HideBigMap();
	}

	public void ToggleInventoryShortCuts()
	{
		shortCutsWindow.ToggleUI();
	}

	public void OnUIElementSelected(UIelement uiElement)
	{
		if (currentSelectedUIElement != null && !currentSelectedUIElement.isMenuOption)
		{
			currentSelectedUIElement.OnDeselected();
		}
		currentSelectedUIElement = uiElement;
		if (!currentSelectedUIElement.isMenuOption)
		{
			currentSelectedUIElement.OnSelected();
		}
		if (currentSelectedUIElement.isMenuOption)
		{
			Manager.menu.SelectOption(currentSelectedUIElement);
		}
	}

	public void DeselectAnySelectedUIElement()
	{
		if (currentSelectedUIElement != null)
		{
			if (!currentSelectedUIElement.isMenuOption)
			{
				currentSelectedUIElement.OnDeselected();
			}
			currentSelectedUIElement = null;
			Manager.menu.DeselectAnyCurrentOption();
		}
	}

	public bool AttemptToMoveToHotbar(InventoryHandler inventoryHandler, int index)
	{
		ObjectDataCD objectData = inventoryHandler.GetObjectData(index);
		if (objectData.objectID != ObjectID.None)
		{
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo(objectData.objectID);
			if (objectInfo != null)
			{
				InventorySlotUI inventorySlotUI = null;
				List<SlotUIBase> itemSlots = playerInventoryUI.itemSlots;
				for (int i = 0; i < 10; i++)
				{
					if ((itemSlots[i].GetContainedObject().objectID == ObjectID.None || itemSlots[i].GetContainedObject().objectID == objectInfo.objectID) && i < index)
					{
						inventorySlotUI = (InventorySlotUI)itemSlots[i];
						break;
					}
				}
				if (inventorySlotUI != null && inventorySlotUI.GetInventoryHandler() != null)
				{
					inventoryHandler.MoveAllToOrDrop(Manager.main.player, index, Manager.main.player.playerInventoryHandler, Manager.main.player.transform.position, inventorySlotUI.inventorySlotIndex);
					return true;
				}
				return true;
			}
		}
		return false;
	}

	public bool AttemptToEquipItem(InventoryHandler inventoryHandler, int index, bool isVanity)
	{
		ObjectDataCD objectData = inventoryHandler.GetObjectData(index);
		if (objectData.objectID != ObjectID.None)
		{
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo(objectData.objectID);
			if (objectInfo != null)
			{
				InventorySlotUI inventorySlotUI = null;
				foreach (SlotUIBase item in isVanity ? vanityUI.itemSlots : equipmentInventoryUI.itemSlots)
				{
					if ((item.slotType == ItemSlotsUIType.HelmSlot && objectInfo.objectType == ObjectType.Helm) || (item.slotType == ItemSlotsUIType.BreastSlot && objectInfo.objectType == ObjectType.BreastArmor) || (item.slotType == ItemSlotsUIType.PantsSlot && objectInfo.objectType == ObjectType.PantsArmor) || (item.slotType == ItemSlotsUIType.NecklaceSlot && objectInfo.objectType == ObjectType.Necklace) || (item.slotType == ItemSlotsUIType.OffhandSlot && objectInfo.objectType == ObjectType.Offhand) || (item.slotType == ItemSlotsUIType.BagSlot && objectInfo.objectType == ObjectType.Bag) || (item.slotType == ItemSlotsUIType.PetSlot && objectInfo.objectType == ObjectType.Pet) || (item.slotType == ItemSlotsUIType.LanternSlot && objectInfo.objectType == ObjectType.Lantern) || (item.slotType == ItemSlotsUIType.HelmVanitySlot && objectInfo.objectType == ObjectType.Helm) || (item.slotType == ItemSlotsUIType.BreastVanitySlot && objectInfo.objectType == ObjectType.BreastArmor) || (item.slotType == ItemSlotsUIType.PantsVanitySlot && objectInfo.objectType == ObjectType.PantsArmor))
					{
						inventorySlotUI = (InventorySlotUI)item;
						break;
					}
					if (objectInfo.objectType == ObjectType.Pouch && (item.slotType == ItemSlotsUIType.Pouch1 || item.slotType == ItemSlotsUIType.Pouch2 || item.slotType == ItemSlotsUIType.Pouch3 || item.slotType == ItemSlotsUIType.Pouch4))
					{
						if (inventorySlotUI == null)
						{
							inventorySlotUI = (InventorySlotUI)item;
							if (item.GetContainedObject().objectID == ObjectID.None)
							{
								break;
							}
							continue;
						}
						if (item.GetContainedObject().objectID == ObjectID.None)
						{
							inventorySlotUI = (InventorySlotUI)item;
							break;
						}
						if (inventorySlotUI.GetContainedObject().objectID == objectInfo.objectID && ((InventorySlotUI)item).GetContainedObject().objectID != objectInfo.objectID)
						{
							inventorySlotUI = (InventorySlotUI)item;
							break;
						}
					}
					else
					{
						if (objectInfo.objectType != ObjectType.Ring || (item.slotType != ItemSlotsUIType.RingSlot1 && item.slotType != ItemSlotsUIType.RingSlot2))
						{
							continue;
						}
						if (inventorySlotUI == null)
						{
							inventorySlotUI = (InventorySlotUI)item;
							if (item.GetContainedObject().objectID == ObjectID.None)
							{
								break;
							}
							continue;
						}
						if (item.GetContainedObject().objectID == ObjectID.None)
						{
							inventorySlotUI = (InventorySlotUI)item;
							break;
						}
						if (inventorySlotUI.GetContainedObject().objectID == objectInfo.objectID && ((InventorySlotUI)item).GetContainedObject().objectID != objectInfo.objectID)
						{
							inventorySlotUI = (InventorySlotUI)item;
							break;
						}
					}
				}
				if (inventorySlotUI != null && inventorySlotUI.GetInventoryHandler() != null)
				{
					if (objectInfo.isStackable && inventorySlotUI.GetObjectData().objectID == objectData.objectID)
					{
						inventoryHandler.MoveTo(Manager.main.player, index, inventorySlotUI.GetInventoryHandler(), objectData.amount);
					}
					else
					{
						inventoryHandler.Swap(Manager.main.player, index, inventorySlotUI.GetInventoryHandler(), 0);
					}
					return true;
				}
			}
		}
		return false;
	}

	public void ApplyAnyIconGradientMap(ContainedObjectsBuffer containedObject, SpriteRenderer sr)
	{
		if (PugDatabase.HasComponent<PetCD>(containedObject.objectID))
		{
			PetInfosTable.PetSkinInfo petSkinInfo = Manager.ui.petInfosTable.GetPetSkinInfo(containedObject.objectID);
			int num = 0;
			if (InventoryHandler.TryGetExtraInventoryData<PetSkinCD>(containedObject, out var data))
			{
				num = data.skinIndex;
			}
			if (petSkinInfo != null && petSkinInfo.skins.Count > num)
			{
				GradientMapDataBlock primaryGradientMap = petSkinInfo.skins[num].primaryGradientMap;
				if (primaryGradientMap != null && primaryGradientMap.hasData)
				{
					Texture2D value = null;
					if (!s_runtimeGradientCache.TryGetValue(primaryGradientMap, out value) || value == null)
					{
						value = new Texture2D(primaryGradientMap.textureWidth, 1, TextureFormat.ARGB32, mipChain: false);
						Color32[] array = new Color32[value.width];
						for (int i = 0; i < value.width; i++)
						{
							array[i] = primaryGradientMap.GetPixel(i);
						}
						value.SetPixels32(array);
						value.Apply();
						s_runtimeGradientCache[primaryGradientMap] = value;
					}
					if (value != null)
					{
						sr.material.EnableKeyword("USE_GRADIENT_MAP");
						sr.material.SetTexture(GradientMap, value);
						return;
					}
				}
			}
		}
		sr.material.DisableKeyword("USE_GRADIENT_MAP");
	}

	public bool ShouldShowCageOverlay(ContainedObjectsBuffer containedObject)
	{
		if (containedObject.auxDataIndex != 0)
		{
			return PugDatabase.HasComponent<CattleCD>(containedObject.objectData);
		}
		return false;
	}

	private void UpdateCurrentCategoryIndexToShow()
	{
		CraftingBuilding craftingBuilding = GetCraftingBuilding();
		if (craftingBuilding == null)
		{
			return;
		}
		List<CraftingBuilding.CraftingCategoryWindowInfo> craftingCategoryWindowInfos = GetCraftingCategoryWindowInfos();
		if (craftingCategoryWindowInfos == null || craftingCategoryWindowInfos.Count == 0)
		{
			return;
		}
		ObjectID objectID = craftingBuilding.objectData.objectID;
		if (currentCategoryIndices.ContainsKey(objectID))
		{
			return;
		}
		Season season = Manager.prefs.season;
		currentCategoryIndices.Add(objectID, 0);
		if (season == Season.None)
		{
			return;
		}
		for (int i = 0; i < craftingCategoryWindowInfos.Count; i++)
		{
			if (craftingCategoryWindowInfos[i].showAsDefaultDuringSeason == season)
			{
				currentCategoryIndices[objectID] = i;
				break;
			}
		}
	}

	public void ChangeCraftingCategoryWindowInfo(bool moveForward)
	{
		CraftingBuilding craftingBuilding = GetCraftingBuilding();
		List<CraftingBuilding.CraftingCategoryWindowInfo> craftingCategoryWindowInfos = GetCraftingCategoryWindowInfos();
		if (craftingCategoryWindowInfos == null)
		{
			return;
		}
		ObjectID objectID = craftingBuilding.objectData.objectID;
		currentCategoryIndices.TryAdd(objectID, 0);
		if (moveForward)
		{
			currentCategoryIndices[objectID] = (currentCategoryIndices[objectID] + 1) % craftingCategoryWindowInfos.Count;
		}
		else
		{
			currentCategoryIndices[objectID]--;
			if (currentCategoryIndices[objectID] < 0)
			{
				currentCategoryIndices[objectID] = craftingCategoryWindowInfos.Count - 1;
			}
		}
		simpleCraftingUIContainer.ShowCraftingUI();
	}

	public List<CraftingBuilding.CraftingCategoryWindowInfo> GetCraftingCategoryWindowInfos()
	{
		CraftingBuilding craftingBuilding = GetCraftingBuilding();
		if (craftingBuilding != null)
		{
			return craftingBuilding.GetCraftingCategoryWindowInfos();
		}
		return null;
	}

	public CraftingBuilding.CraftingCategoryWindowInfo GetCraftingCategoryWindowInfo()
	{
		CraftingBuilding craftingBuilding = GetCraftingBuilding();
		if (craftingBuilding == null)
		{
			return null;
		}
		if (!currentCategoryIndices.TryGetValue(craftingBuilding.objectData.objectID, out var value))
		{
			return null;
		}
		return craftingBuilding.GetCraftingCategoryWindowInfo(value);
	}

	public static CraftingBuilding GetCraftingBuilding()
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return null;
		}
		InteractableObject currentInteractableObject = player.GetCurrentInteractableObject();
		if (currentInteractableObject == null || player.activeCraftingHandler == player.playerCraftingHandler)
		{
			return null;
		}
		CraftingBuilding component = currentInteractableObject.transform.parent.GetComponent<CraftingBuilding>();
		if (component != null && component.entityExist)
		{
			return component;
		}
		return null;
	}

	public int GetCategoryWindowInfoStartIndex()
	{
		return GetCraftingCategoryWindowInfo()?.startSlotIndex ?? 0;
	}

	public void FadeInAllGameplayUI()
	{
		gameplayUIFader.FadeIn(0.3f, time);
	}

	public void FadeOutAllGameplayUI()
	{
		gameplayUIFader.FadeOut(0.3f, time);
	}

	public void TemporarilyDisableGameplayUI()
	{
		gameplayUIEnabledScaleMultipler = new Vector3(0f, 0f, 1f);
	}

	public void EnableTemporarilyDisabledGameplayUI()
	{
		gameplayUIEnabledScaleMultipler = new Vector3(1f, 1f, 1f);
	}

	public void FadeInMouse()
	{
		mouseFader.FadeIn(0.3f, time);
	}

	public void FadeOutMouse()
	{
		mouseFader.FadeOut(0.3f, time);
	}

	public void ShowDiscoveredItemText(List<string> texts, Rarity rarity)
	{
		ItemDiscoveryUI.ShowDiscoveredItem(texts, rarity);
	}

	public void OnSceneUnload()
	{
		if (Manager.sceneHandler.isInGame)
		{
			mapUI.SaveAllMaps();
			mapUI.Clear();
			mapUI.gameObject.SetActive(value: false);
		}
	}

	public static float PositionElementBeneath(Transform trans, float previousBottom, float elementHeight, float paddingFromPrevious, bool moveDownHalfOfHeight = true, bool setXToZero = false)
	{
		if (moveDownHalfOfHeight)
		{
			float num = elementHeight / 2f;
			float num2 = ((num % 0.0625f > 0f) ? (0.0625f - num % 0.0625f) : 0f);
			trans.localPosition = new Vector3(setXToZero ? 0f : trans.localPosition.x, previousBottom - num - num2 - paddingFromPrevious, 0f);
			previousBottom -= elementHeight + paddingFromPrevious;
		}
		else
		{
			trans.localPosition = new Vector3(setXToZero ? 0f : trans.localPosition.x, previousBottom - paddingFromPrevious, 0f);
			previousBottom -= elementHeight + paddingFromPrevious;
		}
		return previousBottom;
	}

	public static float PositionElementAbove(Transform trans, float previousTop, float elementHeight, float paddingFromPrevious, bool moveUpHalfOfHeight = true, bool setXToZero = false, bool moveUpFullHeight = false)
	{
		if (moveUpFullHeight || moveUpHalfOfHeight)
		{
			float num = (moveUpFullHeight ? elementHeight : (elementHeight / 2f));
			float num2 = ((num % 0.0625f > 0f) ? (0.0625f - num % 0.0625f) : 0f);
			trans.localPosition = new Vector3(setXToZero ? trans.localPosition.x : 0f, previousTop + num + num2 + paddingFromPrevious, 0f);
			previousTop += elementHeight + paddingFromPrevious;
		}
		else
		{
			trans.localPosition = new Vector3(setXToZero ? trans.localPosition.x : 0f, previousTop + paddingFromPrevious, 0f);
			previousTop += elementHeight + paddingFromPrevious;
		}
		return previousTop;
	}

	public static float PositionElementToRight(Transform trans, float previousLeft, float elementWidth, float paddingFromPrevious, float elementHeight = 0f, bool moveDownHalfOfHeight = true, bool moveRightHalfOfWidth = false)
	{
		float num = 0f;
		if (moveDownHalfOfHeight)
		{
			num = elementHeight / 2f;
			float num2 = ((num % 0.0625f > 0f) ? (0.0625f - num % 0.0625f) : 0f);
			num += num2;
		}
		if (moveRightHalfOfWidth)
		{
			float num3 = elementWidth / 2f;
			float num4 = ((num3 % 0.0625f > 0f) ? (0.0625f - num3 % 0.0625f) : 0f);
			num3 += num4;
			trans.localPosition = new Vector3(previousLeft + num3 + paddingFromPrevious, 0f - num, 0f);
			previousLeft += elementWidth + paddingFromPrevious;
		}
		else
		{
			trans.localPosition = new Vector3(previousLeft + paddingFromPrevious, 0f - num, 0f);
			previousLeft += elementWidth + paddingFromPrevious;
		}
		return previousLeft;
	}

	public string GetShortCutString(int keyId, bool prefersJoystick, bool onlyReturnShortCutForActiveController = false)
	{
		return GetShortCutString(ReInput.mapping.GetAction(keyId).name, prefersJoystick, onlyReturnShortCutForActiveController);
	}

	public string GetShortCutString(string keybind, bool prefersJoystick, bool onlyReturnShortCutForActiveController = false)
	{
		Player rewiredPlayer = Manager.input.singleplayerInputModule.rewiredPlayer;
		Controller lastActiveController = rewiredPlayer.controllers.GetLastActiveController();
		ActionElementMap actionElementMap = null;
		if (lastActiveController != null)
		{
			actionElementMap = rewiredPlayer.controllers.maps.GetFirstElementMapWithAction(lastActiveController, keybind, skipDisabledMaps: true);
		}
		if ((!onlyReturnShortCutForActiveController && (actionElementMap == null || actionElementMap.controllerMap.controllerType == ControllerType.Mouse)) || (lastActiveController != null && lastActiveController.type == ControllerType.Mouse && actionElementMap == null))
		{
			actionElementMap = rewiredPlayer.controllers.maps.GetFirstElementMapWithAction(keybind, skipDisabledMaps: true);
			List<ActionElementMap> list = new List<ActionElementMap>();
			rewiredPlayer.controllers.maps.GetElementMapsWithAction(keybind, skipDisabledMaps: true, list);
			foreach (ActionElementMap item in list)
			{
				if (prefersJoystick && item.controllerMap.controllerType == ControllerType.Joystick)
				{
					actionElementMap = item;
					break;
				}
				if (!prefersJoystick && item.controllerMap.controllerType != ControllerType.Joystick)
				{
					actionElementMap = item;
					break;
				}
			}
		}
		if (actionElementMap != null)
		{
			return controllerButtonToCharTable.GetControllerButtonCharacter(actionElementMap.controllerMap.controllerType, actionElementMap.controllerMap.controller.name, actionElementMap.elementIdentifierName);
		}
		return null;
	}
}
