using I2.Loc;
using TMPro;
using UnityEngine;

public class PassiveModeGUI : MonoBehaviour
{
	public GUIManagerPens guiRef;

	public GameObject collapseUIButton;

	public GameObject restoreUIButton;

	public Transform mainUIObject;

	public GameObject closeButton;

	public OptionsMenuToggle cleanPuddlesToggle;

	public OptionsMenuToggle cleanPoopToggle;

	public OptionsMenuToggle cleanEmptyCocoonsToggle;

	public OptionsMenuToggle cleanHalfEatenFoodToggle;

	public OptionsMenuToggle cleanBabyTeethToggle;

	public OptionsMenuToggle cleanDirtToggle;

	public OptionsMenuToggle cleanSnowToggle;

	public OptionsMenuToggle clearHoleToggle;

	public OptionsMenuToggle collectSeedsToggle;

	public OptionsMenuToggle collecetUpgradesToggle;

	public OptionsMenuToggle unwrapGiftsToggle;

	public OptionsMenuToggle openCapsulesToggle;

	public OptionsMenuToggle collectCoresToggle;

	public OptionsMenuToggle collectEggsToggle;

	public OptionsMenuToggle randomDogToggle;

	public OptionsMenuToggle randomPenToggle;

	public OptionsMenuToggle autoCameraRotationToggle;

	public OptionsMenuToggle focusOnDyingDogsToggle;

	public OptionsMenuToggle focusOnHatchingCocoonsToggle;

	public OptionsMenuToggle focusOnHatchingEggsToggle;

	public TextMeshProUGUI autoBreedingDisplay;

	public TextMeshProUGUI autoBreedingRelationshipDisplay;

	public TextMeshProUGUI eggMutationRateDisplay;

	public TextMeshProUGUI pupationMutationRateDisplay;

	public TextMeshProUGUI floraMutationEffectsDisplay;

	public OptionsMenuToggle autoHideUIToggle;

	public OptionsMenuToggle autoHideCursorToggle;

	public OptionsMenuToggle deathByStarvationToggle;

	public OptionsMenuToggle autoPupateToggle;

	public OptionsMenuToggle autoCocoonHatchToggle;

	public OptionsMenuToggle autoEggHatchToggle;

	public TextMeshProUGUI deathNotifDisplay;

	public TextMeshProUGUI eggNotifDisplay;

	public TextMeshProUGUI mutationNotifDisplay;

	private string windowOpenSound = "incubator_window_open";

	private string windowCloseSound = "incubator_window_close";

	private Vector3 localUIPosRestored = Vector3.zero;

	private Vector3 localUIPosCollapsed = new Vector3(1560f, 0f, 0f);

	private bool UICollapsed;

	private void Update()
	{
		if (!UICollapsed && GameControls.actions.CloseMenu.WasPressed)
		{
			OnCollapseUIButtonPressed();
		}
	}

	public void OnEnterPassiveMode()
	{
		Initialize();
	}

	private void Initialize()
	{
		SyncUIStates();
		OnCollapseUIButtonPressed(fromInit: true);
	}

	public void OnCollapseUIButtonPressed(bool fromInit = false)
	{
		UICollapsed = true;
		closeButton.SetActive(value: false);
		collapseUIButton.SetActive(value: false);
		restoreUIButton.SetActive(value: true);
		if (!fromInit && mainUIObject.localPosition != localUIPosCollapsed)
		{
			AudioController.Play(windowCloseSound);
		}
		mainUIObject.localPosition = localUIPosCollapsed;
		guiRef.EnableBG(LockReason.PASSIVE_MODE_MENU);
	}

	public void OnRestoreUIButtonPressed()
	{
		SyncUIStates();
		UICollapsed = false;
		closeButton.SetActive(value: true);
		collapseUIButton.SetActive(value: true);
		restoreUIButton.SetActive(value: false);
		mainUIObject.localPosition = localUIPosRestored;
		AudioController.Play(windowOpenSound);
		guiRef.DisableBG(LockReason.PASSIVE_MODE_MENU);
	}

	public void OnExitPassiveModeButtonPressed()
	{
		GameSettings.SetPassiveModeEnabled(val: false);
		guiRef.ExitPassiveMode();
		guiRef.EnableBG(LockReason.PASSIVE_MODE_MENU);
	}

	public void OnRestoreDefaultsButtonPressed()
	{
		GameSettings.RestoreDefaultPassiveModeSettings();
		GameSettings.SetPassiveModeEnabled(val: true);
		SyncUIStates();
	}

	private void SyncUIStates()
	{
		SyncClearDirt();
		SyncClearSnow();
		SyncCleanPoop();
		SyncClearHoles();
		SyncUnwrapGifts();
		SyncCollectEggs();
		SyncCleanPuddles();
		SyncCollectSeeds();
		SyncOpenCapsules();
		SyncCollectCores();
		SyncClearBabyTeeth();
		SyncCollectUpgrades();
		SyncClearEmptyCocoons();
		SyncClearHalfEatenFood();
		SyncRandomDogFocus();
		SyncRandomPenFocus();
		SyncAutoCamRotation();
		SyncFocusOnDyingDogs();
		SyncFocusOnHatchingEggs();
		SyncFocusOnHatchingCocoons();
		SyncAutoBreeding();
		SyncEggMutationRate();
		SyncPupationMutationRate();
		SyncFloraMutationEffects();
		SyncAutoBreedingRelationshipRequirements();
		SyncAutoPupate();
		SyncAutoHideGUI();
		SyncAutoEggHatch();
		SyncAutoHideCursor();
		SyncAutoCocoonHatch();
		SyncEggNotifications();
		SyncDeathByStarvation();
		SyncDeathNotifications();
		SyncMutationNotifications();
	}

	private void SyncCleanPuddles()
	{
		cleanPuddlesToggle.SetToggleState(GameSettings.PassiveModeAutoCleanPuddles());
	}

	public void ToggleCleanPuddles()
	{
		GameSettings.SetPassiveModeAutoCleanPuddles(!GameSettings.PassiveModeAutoCleanPuddles());
		SyncCleanPuddles();
	}

	private void SyncCleanPoop()
	{
		cleanPoopToggle.SetToggleState(GameSettings.PassiveModeAutoCleanPoop());
	}

	public void ToggleCleanPoop()
	{
		GameSettings.SetPassiveModeAutoCleanPoop(!GameSettings.PassiveModeAutoCleanPoop());
		SyncCleanPoop();
	}

	private void SyncClearHoles()
	{
		clearHoleToggle.SetToggleState(GameSettings.PassiveModeAutoClearHole());
	}

	public void ToggleClearHoles()
	{
		GameSettings.SetPassiveModeAutoClearHole(!GameSettings.PassiveModeAutoClearHole());
		SyncClearHoles();
	}

	private void SyncCollectSeeds()
	{
		collectSeedsToggle.SetToggleState(GameSettings.PassiveModeAutoCollectSeeds());
	}

	public void ToggleCollectSeeds()
	{
		GameSettings.SetPassiveModeAutoCollectSeeds(!GameSettings.PassiveModeAutoCollectSeeds());
		SyncCollectSeeds();
	}

	private void SyncCollectUpgrades()
	{
		collecetUpgradesToggle.SetToggleState(GameSettings.PassiveModeAutoCollectUpgrades());
	}

	public void ToggleCollectUpgrades()
	{
		GameSettings.SetPassiveModeAutoCollectUpgrades(!GameSettings.PassiveModeAutoCollectUpgrades());
		SyncCollectUpgrades();
	}

	private void SyncUnwrapGifts()
	{
		unwrapGiftsToggle.SetToggleState(GameSettings.PassiveModeAutoUnwrapGifts());
	}

	public void ToggleUnwrapGifts()
	{
		GameSettings.SetPassiveModeAutoUnwrapGifts(!GameSettings.PassiveModeAutoUnwrapGifts());
		SyncUnwrapGifts();
	}

	private void SyncOpenCapsules()
	{
		openCapsulesToggle.SetToggleState(GameSettings.PassiveModeAutoCapsuleOpen());
	}

	public void ToggleOpenCapsules()
	{
		GameSettings.SetPassiveModeAutoCapsuleOpen(!GameSettings.PassiveModeAutoCapsuleOpen());
		SyncOpenCapsules();
	}

	private void SyncCollectCores()
	{
		collectCoresToggle.SetToggleState(GameSettings.PassiveModeAutoCollectCores());
	}

	public void ToggleCollectCores()
	{
		GameSettings.SetPassiveModeAutoCollectCores(!GameSettings.PassiveModeAutoCollectCores());
		SyncCollectCores();
	}

	private void SyncCollectEggs()
	{
		collectEggsToggle.SetToggleState(GameSettings.PassiveModeAutoEggCollect());
	}

	public void ToggleCollectEggs()
	{
		GameSettings.SetPassiveModeAutoEggCollection(!GameSettings.PassiveModeAutoEggCollect());
		SyncCollectEggs();
	}

	private void SyncClearEmptyCocoons()
	{
		cleanEmptyCocoonsToggle.SetToggleState(GameSettings.PassiveModeAutoCleanEmptyCocoons());
	}

	public void ToggleClearEmptyCocoons()
	{
		GameSettings.SetPassiveModeAutoCleanEmptyCocoons(!GameSettings.PassiveModeAutoCleanEmptyCocoons());
		SyncClearEmptyCocoons();
	}

	private void SyncClearHalfEatenFood()
	{
		cleanHalfEatenFoodToggle.SetToggleState(GameSettings.PassiveModeAutoCleanHalfEatenFood());
	}

	public void ToggleClearHalfEatenFood()
	{
		GameSettings.SetPassiveModeAutoCleanHalfEatenFood(!GameSettings.PassiveModeAutoCleanHalfEatenFood());
		SyncClearHalfEatenFood();
	}

	private void SyncClearBabyTeeth()
	{
		cleanBabyTeethToggle.SetToggleState(GameSettings.PassiveModeAutoCleanBabyTeeth());
	}

	public void ToggleClearBabyTeeth()
	{
		GameSettings.SetPassiveModeAutoCleanBabyTeeth(!GameSettings.PassiveModeAutoCleanBabyTeeth());
		SyncClearBabyTeeth();
	}

	private void SyncClearDirt()
	{
		cleanDirtToggle.SetToggleState(GameSettings.PassiveModeAutoCleanDirt());
	}

	public void ToggleClearDirt()
	{
		GameSettings.SetPassiveModeAutoCleanDirt(!GameSettings.PassiveModeAutoCleanDirt());
		SyncClearDirt();
	}

	private void SyncClearSnow()
	{
		cleanSnowToggle.SetToggleState(GameSettings.PassiveModeAutoCleanSnow());
	}

	public void ToggleClearSnow()
	{
		GameSettings.SetPassiveModeAutoCleanSnow(!GameSettings.PassiveModeAutoCleanSnow());
		SyncClearSnow();
	}

	private void SyncRandomDogFocus()
	{
		randomDogToggle.SetToggleState(GameSettings.PassiveModeRandomDogFocus());
	}

	public void ToggleRandomDogFocus()
	{
		GameSettings.SetPassiveModeRandomDogFocus(!GameSettings.PassiveModeRandomDogFocus());
		SyncRandomDogFocus();
	}

	private void SyncRandomPenFocus()
	{
		randomPenToggle.SetToggleState(GameSettings.PassiveModeRandomPenFocus());
	}

	public void ToggleRandomPenFocus()
	{
		GameSettings.SetPassiveModeRandomPenFocus(!GameSettings.PassiveModeRandomPenFocus());
		SyncRandomPenFocus();
	}

	private void SyncAutoCamRotation()
	{
		autoCameraRotationToggle.SetToggleState(GameSettings.PassiveModeRandomPenFocusRotation());
	}

	public void ToggleAutoCamRotation()
	{
		GameSettings.SetPassiveModeRandomPenFocusRotation(!GameSettings.PassiveModeRandomPenFocusRotation());
		SyncAutoCamRotation();
	}

	private void SyncFocusOnDyingDogs()
	{
		focusOnDyingDogsToggle.SetToggleState(GameSettings.PassiveModeFocusOnDyingDogs());
	}

	public void ToggleFocusOnDyingDogs()
	{
		GameSettings.SetPassiveModeFocusOnDyingDogs(!GameSettings.PassiveModeFocusOnDyingDogs());
		SyncFocusOnDyingDogs();
	}

	private void SyncFocusOnHatchingCocoons()
	{
		focusOnHatchingCocoonsToggle.SetToggleState(GameSettings.PassiveModeFocusOnHatchingCocoons());
	}

	public void ToggleFocusOnHatchingCocoons()
	{
		GameSettings.SetPassiveModeFocusOnHatchingCocoons(!GameSettings.PassiveModeFocusOnHatchingCocoons());
		SyncFocusOnHatchingCocoons();
	}

	private void SyncFocusOnHatchingEggs()
	{
		focusOnHatchingEggsToggle.SetToggleState(GameSettings.PassiveModeFocusOnHatchingEggs());
	}

	public void ToggleFocusOnHatchingEggs()
	{
		GameSettings.SetPassiveModeFocusOnHatchingEggs(!GameSettings.PassiveModeFocusOnHatchingEggs());
		SyncFocusOnHatchingEggs();
	}

	private void SyncAutoHideGUI()
	{
		autoHideUIToggle.SetToggleState(GameSettings.PassiveModeAutoHideGUI());
	}

	public void ToggleAutoHideGUI()
	{
		GameSettings.SetPassiveModeAutoHideGUI(!GameSettings.PassiveModeAutoHideGUI());
		SyncAutoHideGUI();
	}

	private void SyncAutoHideCursor()
	{
		autoHideCursorToggle.SetToggleState(GameSettings.PassiveModeAutoHideCursor());
	}

	public void ToggleAutoHideCursor()
	{
		GameSettings.SetPassiveModeAutoHideCursor(!GameSettings.PassiveModeAutoHideCursor());
		SyncAutoHideCursor();
	}

	private void SyncDeathByStarvation()
	{
		deathByStarvationToggle.SetToggleState(GameSettings.PassiveModeDeathByStarvation());
	}

	public void ToggleAutoPupate()
	{
		GameSettings.SetPassiveModeAutoPupate(!GameSettings.PassiveModeAutoPupate());
		SyncAutoPupate();
	}

	private void SyncAutoPupate()
	{
		autoPupateToggle.SetToggleState(GameSettings.PassiveModeAutoPupate());
	}

	public void ToggleAutoCocoonHatch()
	{
		GameSettings.SetPassiveModeAutoHatch(!GameSettings.PassiveModeAutoHatch());
		SyncAutoCocoonHatch();
	}

	private void SyncAutoCocoonHatch()
	{
		autoCocoonHatchToggle.SetToggleState(GameSettings.PassiveModeAutoHatch());
	}

	public void ToggleAutoEggHatch()
	{
		GameSettings.SetPassiveModeAutoEggHatch(!GameSettings.PassiveModeAutoEggHatch());
		SyncAutoEggHatch();
	}

	private void SyncAutoEggHatch()
	{
		autoEggHatchToggle.SetToggleState(GameSettings.PassiveModeAutoEggHatch());
	}

	public void ToggleDeathByStarvation()
	{
		GameSettings.SetPassiveModeDeathByStarvation(!GameSettings.PassiveModeDeathByStarvation());
		SyncDeathByStarvation();
	}

	private void SyncAutoBreeding()
	{
		autoBreedingDisplay.text = GetTextForBreedingOption(GameSettings.PassiveModeAutoBreedingOption());
	}

	private void SyncAutoBreedingRelationshipRequirements()
	{
		autoBreedingRelationshipDisplay.text = GetTextForBreedingRelationshipRequirementsOption(GameSettings.PassiveModeAutoBreedingRelationshipRequirement());
	}

	private void SyncEggMutationRate()
	{
		eggMutationRateDisplay.text = GetTextForMutationRate(GameSettings.PassiveEggMutationRate());
	}

	private void SyncPupationMutationRate()
	{
		pupationMutationRateDisplay.text = GetTextForMutationRate(GameSettings.PassivePupationMutationRate());
	}

	private void SyncFloraMutationEffects()
	{
		floraMutationEffectsDisplay.text = GetTextForMutationRate(GameSettings.PassiveFloraMutationEffects());
	}

	private void SyncDeathNotifications()
	{
		deathNotifDisplay.text = GetTextForNotificationOption(GameSettings.PassiveModeDeathNotificationOption());
	}

	private void SyncEggNotifications()
	{
		eggNotifDisplay.text = GetTextForNotificationOption(GameSettings.PassiveModeEggNotificationOption());
	}

	private void SyncMutationNotifications()
	{
		mutationNotifDisplay.text = GetTextForNotificationOption(GameSettings.PassiveModeMutationNotificationOption());
	}

	public void CycleAutoBreedingRight()
	{
		switch (GameSettings.PassiveModeAutoBreedingOption())
		{
		case GameSettings.PassiveBreedingOption.PROXIMAL_PARENT:
			GameSettings.SetPassiveModeAutoBreedingOption(GameSettings.PassiveBreedingOption.DISABLED);
			break;
		case GameSettings.PassiveBreedingOption.DISABLED:
			GameSettings.SetPassiveModeAutoBreedingOption(GameSettings.PassiveBreedingOption.SINGLE_PARENT);
			break;
		case GameSettings.PassiveBreedingOption.SINGLE_PARENT:
			GameSettings.SetPassiveModeAutoBreedingOption(GameSettings.PassiveBreedingOption.RANDOM_PARENT);
			break;
		case GameSettings.PassiveBreedingOption.RANDOM_PARENT:
			GameSettings.SetPassiveModeAutoBreedingOption(GameSettings.PassiveBreedingOption.PROXIMAL_PARENT);
			break;
		}
		SyncAutoBreeding();
	}

	public void CycleAutoBreedingLeft()
	{
		switch (GameSettings.PassiveModeAutoBreedingOption())
		{
		case GameSettings.PassiveBreedingOption.PROXIMAL_PARENT:
			GameSettings.SetPassiveModeAutoBreedingOption(GameSettings.PassiveBreedingOption.RANDOM_PARENT);
			break;
		case GameSettings.PassiveBreedingOption.RANDOM_PARENT:
			GameSettings.SetPassiveModeAutoBreedingOption(GameSettings.PassiveBreedingOption.SINGLE_PARENT);
			break;
		case GameSettings.PassiveBreedingOption.SINGLE_PARENT:
			GameSettings.SetPassiveModeAutoBreedingOption(GameSettings.PassiveBreedingOption.DISABLED);
			break;
		case GameSettings.PassiveBreedingOption.DISABLED:
			GameSettings.SetPassiveModeAutoBreedingOption(GameSettings.PassiveBreedingOption.PROXIMAL_PARENT);
			break;
		}
		SyncAutoBreeding();
	}

	private string GetTextForBreedingOption(GameSettings.PassiveBreedingOption option)
	{
		switch (option)
		{
		case GameSettings.PassiveBreedingOption.SINGLE_PARENT:
			return ScriptLocalization.AutomationOptions.AUTO_BREEDINGOPTION_SINGLEP;
		case GameSettings.PassiveBreedingOption.RANDOM_PARENT:
			return ScriptLocalization.AutomationOptions.AUTO_BREEDINGOPTION_RANDOMP;
		case GameSettings.PassiveBreedingOption.PROXIMAL_PARENT:
			return ScriptLocalization.AutomationOptions.AUTO_BREEDINGOPTION_PROXIMALP;
		default:
			return ScriptLocalization.AutomationOptions.AUTO_OPTION_DISABLED;
		}
	}

	public void CycleAutoBreedingRelationshipRequirementsRight()
	{
		switch (GameSettings.PassiveModeAutoBreedingRelationshipRequirement())
		{
		case GameSettings.PassiveBreedingRelationshipRequirement.REQUIRED:
			GameSettings.SetPassiveModeAutoBreedingRelationshipRequirement(GameSettings.PassiveBreedingRelationshipRequirement.NOT_CONSIDERED);
			break;
		case GameSettings.PassiveBreedingRelationshipRequirement.NOT_CONSIDERED:
			GameSettings.SetPassiveModeAutoBreedingRelationshipRequirement(GameSettings.PassiveBreedingRelationshipRequirement.CONSIDERED_NOT_REQUIRED);
			break;
		case GameSettings.PassiveBreedingRelationshipRequirement.CONSIDERED_NOT_REQUIRED:
			GameSettings.SetPassiveModeAutoBreedingRelationshipRequirement(GameSettings.PassiveBreedingRelationshipRequirement.REQUIRED);
			break;
		}
		SyncAutoBreedingRelationshipRequirements();
	}

	public void CycleAutoBreedingRelationshipRequirementsLeft()
	{
		switch (GameSettings.PassiveModeAutoBreedingRelationshipRequirement())
		{
		case GameSettings.PassiveBreedingRelationshipRequirement.REQUIRED:
			GameSettings.SetPassiveModeAutoBreedingRelationshipRequirement(GameSettings.PassiveBreedingRelationshipRequirement.CONSIDERED_NOT_REQUIRED);
			break;
		case GameSettings.PassiveBreedingRelationshipRequirement.CONSIDERED_NOT_REQUIRED:
			GameSettings.SetPassiveModeAutoBreedingRelationshipRequirement(GameSettings.PassiveBreedingRelationshipRequirement.NOT_CONSIDERED);
			break;
		case GameSettings.PassiveBreedingRelationshipRequirement.NOT_CONSIDERED:
			GameSettings.SetPassiveModeAutoBreedingRelationshipRequirement(GameSettings.PassiveBreedingRelationshipRequirement.REQUIRED);
			break;
		}
		SyncAutoBreedingRelationshipRequirements();
	}

	private string GetTextForBreedingRelationshipRequirementsOption(GameSettings.PassiveBreedingRelationshipRequirement option)
	{
		switch (option)
		{
		case GameSettings.PassiveBreedingRelationshipRequirement.CONSIDERED_NOT_REQUIRED:
			return ScriptLocalization.AutomationOptions.AUTO_RELOPTION_NOTREQ;
		case GameSettings.PassiveBreedingRelationshipRequirement.REQUIRED:
			return ScriptLocalization.AutomationOptions.AUTO_RELOPTION_REQ;
		case GameSettings.PassiveBreedingRelationshipRequirement.NOT_CONSIDERED:
			return ScriptLocalization.AutomationOptions.AUTO_RELOPTION_NOTCONS;
		default:
			return ScriptLocalization.AutomationOptions.AUTO_RELOPTION_NOTCONS;
		}
	}

	public void CycleMutationRateRight()
	{
		switch (GameSettings.PassiveEggMutationRate())
		{
		case GameSettings.PassiveMutationRate.DEFAULT:
			GameSettings.SetPassiveEggMutationRate(GameSettings.PassiveMutationRate.HIGH);
			break;
		case GameSettings.PassiveMutationRate.HIGH:
			GameSettings.SetPassiveEggMutationRate(GameSettings.PassiveMutationRate.VERY_HIGH);
			break;
		case GameSettings.PassiveMutationRate.VERY_HIGH:
			GameSettings.SetPassiveEggMutationRate(GameSettings.PassiveMutationRate.NONE);
			break;
		case GameSettings.PassiveMutationRate.NONE:
			GameSettings.SetPassiveEggMutationRate(GameSettings.PassiveMutationRate.DEFAULT);
			break;
		}
		SyncEggMutationRate();
	}

	public void CycleMutationRateLeft()
	{
		switch (GameSettings.PassiveEggMutationRate())
		{
		case GameSettings.PassiveMutationRate.DEFAULT:
			GameSettings.SetPassiveEggMutationRate(GameSettings.PassiveMutationRate.NONE);
			break;
		case GameSettings.PassiveMutationRate.NONE:
			GameSettings.SetPassiveEggMutationRate(GameSettings.PassiveMutationRate.VERY_HIGH);
			break;
		case GameSettings.PassiveMutationRate.VERY_HIGH:
			GameSettings.SetPassiveEggMutationRate(GameSettings.PassiveMutationRate.HIGH);
			break;
		case GameSettings.PassiveMutationRate.HIGH:
			GameSettings.SetPassiveEggMutationRate(GameSettings.PassiveMutationRate.DEFAULT);
			break;
		}
		SyncEggMutationRate();
	}

	public void CyclePupationMutationRateRight()
	{
		switch (GameSettings.PassivePupationMutationRate())
		{
		case GameSettings.PassiveMutationRate.DEFAULT:
			GameSettings.SetPassivePupationMutationRate(GameSettings.PassiveMutationRate.HIGH);
			break;
		case GameSettings.PassiveMutationRate.HIGH:
			GameSettings.SetPassivePupationMutationRate(GameSettings.PassiveMutationRate.VERY_HIGH);
			break;
		case GameSettings.PassiveMutationRate.VERY_HIGH:
			GameSettings.SetPassivePupationMutationRate(GameSettings.PassiveMutationRate.NONE);
			break;
		case GameSettings.PassiveMutationRate.NONE:
			GameSettings.SetPassivePupationMutationRate(GameSettings.PassiveMutationRate.DEFAULT);
			break;
		}
		SyncPupationMutationRate();
	}

	public void CyclePupationMutationRateLeft()
	{
		switch (GameSettings.PassivePupationMutationRate())
		{
		case GameSettings.PassiveMutationRate.DEFAULT:
			GameSettings.SetPassivePupationMutationRate(GameSettings.PassiveMutationRate.NONE);
			break;
		case GameSettings.PassiveMutationRate.NONE:
			GameSettings.SetPassivePupationMutationRate(GameSettings.PassiveMutationRate.VERY_HIGH);
			break;
		case GameSettings.PassiveMutationRate.VERY_HIGH:
			GameSettings.SetPassivePupationMutationRate(GameSettings.PassiveMutationRate.HIGH);
			break;
		case GameSettings.PassiveMutationRate.HIGH:
			GameSettings.SetPassivePupationMutationRate(GameSettings.PassiveMutationRate.DEFAULT);
			break;
		}
		SyncPupationMutationRate();
	}

	public void CycleFloraMutationEffectsRight()
	{
		switch (GameSettings.PassiveFloraMutationEffects())
		{
		case GameSettings.PassiveMutationRate.DEFAULT:
			GameSettings.SetPassiveFloraMutationEffects(GameSettings.PassiveMutationRate.HIGH);
			break;
		case GameSettings.PassiveMutationRate.HIGH:
			GameSettings.SetPassiveFloraMutationEffects(GameSettings.PassiveMutationRate.VERY_HIGH);
			break;
		case GameSettings.PassiveMutationRate.VERY_HIGH:
			GameSettings.SetPassiveFloraMutationEffects(GameSettings.PassiveMutationRate.NONE);
			break;
		case GameSettings.PassiveMutationRate.NONE:
			GameSettings.SetPassiveFloraMutationEffects(GameSettings.PassiveMutationRate.DEFAULT);
			break;
		}
		SyncFloraMutationEffects();
	}

	public void CycleFloraMutationEffectsLeft()
	{
		switch (GameSettings.PassiveFloraMutationEffects())
		{
		case GameSettings.PassiveMutationRate.DEFAULT:
			GameSettings.SetPassiveFloraMutationEffects(GameSettings.PassiveMutationRate.NONE);
			break;
		case GameSettings.PassiveMutationRate.NONE:
			GameSettings.SetPassiveFloraMutationEffects(GameSettings.PassiveMutationRate.VERY_HIGH);
			break;
		case GameSettings.PassiveMutationRate.VERY_HIGH:
			GameSettings.SetPassiveFloraMutationEffects(GameSettings.PassiveMutationRate.HIGH);
			break;
		case GameSettings.PassiveMutationRate.HIGH:
			GameSettings.SetPassiveFloraMutationEffects(GameSettings.PassiveMutationRate.DEFAULT);
			break;
		}
		SyncFloraMutationEffects();
	}

	private string GetTextForMutationRate(GameSettings.PassiveMutationRate option)
	{
		switch (option)
		{
		case GameSettings.PassiveMutationRate.DEFAULT:
			return ScriptLocalization.AutomationOptions.AUTO_OPTION_DEFAULT;
		case GameSettings.PassiveMutationRate.HIGH:
			return ScriptLocalization.AutomationOptions.AUTO_MUTATIONOPTION_HIGH;
		case GameSettings.PassiveMutationRate.VERY_HIGH:
			return ScriptLocalization.AutomationOptions.AUTO_MUTATIONOPTION_VERYHIGH;
		case GameSettings.PassiveMutationRate.NONE:
			return ScriptLocalization.AutomationOptions.AUTO_MUTATIONOPTION_NONE;
		default:
			return ScriptLocalization.AutomationOptions.AUTO_OPTION_DEFAULT;
		}
	}

	public void CycleDeathNotifRight()
	{
		switch (GameSettings.PassiveModeDeathNotificationOption())
		{
		case GameSettings.PassiveNotificationsOption.DISABLED:
			GameSettings.SetPassiveModeDeathNotificationOption(GameSettings.PassiveNotificationsOption.SMALL_NOTIF);
			break;
		case GameSettings.PassiveNotificationsOption.SMALL_NOTIF:
			GameSettings.SetPassiveModeDeathNotificationOption(GameSettings.PassiveNotificationsOption.FULL_NOTIF);
			break;
		case GameSettings.PassiveNotificationsOption.FULL_NOTIF:
			GameSettings.SetPassiveModeDeathNotificationOption(GameSettings.PassiveNotificationsOption.DISABLED);
			break;
		}
		SyncDeathNotifications();
	}

	public void CycleDeathNotifLeft()
	{
		switch (GameSettings.PassiveModeDeathNotificationOption())
		{
		case GameSettings.PassiveNotificationsOption.DISABLED:
			GameSettings.SetPassiveModeDeathNotificationOption(GameSettings.PassiveNotificationsOption.FULL_NOTIF);
			break;
		case GameSettings.PassiveNotificationsOption.SMALL_NOTIF:
			GameSettings.SetPassiveModeDeathNotificationOption(GameSettings.PassiveNotificationsOption.DISABLED);
			break;
		case GameSettings.PassiveNotificationsOption.FULL_NOTIF:
			GameSettings.SetPassiveModeDeathNotificationOption(GameSettings.PassiveNotificationsOption.SMALL_NOTIF);
			break;
		}
		SyncDeathNotifications();
	}

	public void CycleEggNotifRight()
	{
		switch (GameSettings.PassiveModeEggNotificationOption())
		{
		case GameSettings.PassiveNotificationsOption.DISABLED:
			GameSettings.SetPassiveModeEggNotificationOption(GameSettings.PassiveNotificationsOption.SMALL_NOTIF);
			break;
		case GameSettings.PassiveNotificationsOption.SMALL_NOTIF:
			GameSettings.SetPassiveModeEggNotificationOption(GameSettings.PassiveNotificationsOption.DISABLED);
			break;
		}
		SyncEggNotifications();
	}

	public void CycleEggNotifLeft()
	{
		switch (GameSettings.PassiveModeEggNotificationOption())
		{
		case GameSettings.PassiveNotificationsOption.DISABLED:
			GameSettings.SetPassiveModeEggNotificationOption(GameSettings.PassiveNotificationsOption.SMALL_NOTIF);
			break;
		case GameSettings.PassiveNotificationsOption.SMALL_NOTIF:
			GameSettings.SetPassiveModeEggNotificationOption(GameSettings.PassiveNotificationsOption.DISABLED);
			break;
		}
		SyncEggNotifications();
	}

	public void CycleMutationNotifRight()
	{
		switch (GameSettings.PassiveModeMutationNotificationOption())
		{
		case GameSettings.PassiveNotificationsOption.DISABLED:
			GameSettings.SetPassiveModeMutationNotificationOption(GameSettings.PassiveNotificationsOption.SMALL_NOTIF);
			break;
		case GameSettings.PassiveNotificationsOption.SMALL_NOTIF:
			GameSettings.SetPassiveModeMutationNotificationOption(GameSettings.PassiveNotificationsOption.FULL_NOTIF);
			break;
		case GameSettings.PassiveNotificationsOption.FULL_NOTIF:
			GameSettings.SetPassiveModeMutationNotificationOption(GameSettings.PassiveNotificationsOption.DISABLED);
			break;
		}
		SyncMutationNotifications();
	}

	public void CycleMutationNotifLeft()
	{
		switch (GameSettings.PassiveModeMutationNotificationOption())
		{
		case GameSettings.PassiveNotificationsOption.DISABLED:
			GameSettings.SetPassiveModeMutationNotificationOption(GameSettings.PassiveNotificationsOption.FULL_NOTIF);
			break;
		case GameSettings.PassiveNotificationsOption.SMALL_NOTIF:
			GameSettings.SetPassiveModeMutationNotificationOption(GameSettings.PassiveNotificationsOption.DISABLED);
			break;
		case GameSettings.PassiveNotificationsOption.FULL_NOTIF:
			GameSettings.SetPassiveModeMutationNotificationOption(GameSettings.PassiveNotificationsOption.SMALL_NOTIF);
			break;
		}
		SyncMutationNotifications();
	}

	private string GetTextForNotificationOption(GameSettings.PassiveNotificationsOption option)
	{
		switch (option)
		{
		case GameSettings.PassiveNotificationsOption.DISABLED:
			return ScriptLocalization.AutomationOptions.AUTO_OPTION_DISABLED;
		case GameSettings.PassiveNotificationsOption.SMALL_NOTIF:
			return ScriptLocalization.AutomationOptions.AUTO_NOTIFOPTION_SMALL;
		case GameSettings.PassiveNotificationsOption.FULL_NOTIF:
			return ScriptLocalization.AutomationOptions.AUTO_NOTIFOPTION_FULL;
		default:
			return ScriptLocalization.AutomationOptions.AUTO_OPTION_DISABLED;
		}
	}
}
