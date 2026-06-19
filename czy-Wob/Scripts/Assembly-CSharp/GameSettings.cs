using I2.Loc;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public static class GameSettings
{
	public enum PassiveBreedingOption
	{
		SINGLE_PARENT = 0,
		RANDOM_PARENT = 1,
		PROXIMAL_PARENT = 2,
		DISABLED = 3
	}

	public enum PassiveBreedingRelationshipRequirement
	{
		NOT_CONSIDERED = 0,
		CONSIDERED_NOT_REQUIRED = 1,
		REQUIRED = 2
	}

	public enum PassiveMutationRate
	{
		DEFAULT = 0,
		HIGH = 1,
		VERY_HIGH = 2,
		NONE = 3
	}

	public enum PassiveNotificationsOption
	{
		SMALL_NOTIF = 0,
		FULL_NOTIF = 1,
		DISABLED = 2
	}

	private static string borderlessFullscreenKey = "borderless";

	private static string vsyncKey = "vsync";

	private static string aoKey = "AO";

	private static string postFXKey = "postFX";

	private static string textureQualityKey = "textureQuality";

	private static string motionBlurKey = "motionBlur";

	private static string dofKey = "DOF";

	private static string xInvertKey = "XInvert";

	private static string yInvertKey = "YInvert";

	private static string camSensitivityKey = "camSensitivity";

	private static string scrollSensitivityKey = "scrollSensitivity";

	private static string UIScrollSensitivityKey = "UIScrollSensitivity";

	private static string gamepadSensitivityKey = "gamepadSensitivity";

	private static string sfxVolumeKey = "sfxVolume";

	private static string musicVolumeKey = "musicVolume";

	private static string gameLanguageKey = "gameLanguage";

	private static bool borderlessFullscreenDefault = false;

	private static bool vsyncDefault = true;

	private static bool aoDefault = true;

	private static bool postFXDefault = true;

	private static bool postFXDefaultMacOS = false;

	private static int textureQualityDefault = 0;

	private static bool motionBlurDefault = true;

	private static bool depthOfFieldDefault = true;

	private static bool xAxisInvertDefault = true;

	private static bool yAxisInvertDefault = true;

	private static float camSensitivityDefault = 0.5f;

	private static float scrollSensitivityDefault = 0.5f;

	private static float UIScrollSensitivityDefault = 0.5f;

	private static float gamepadSensitivityDefault = 0.5f;

	private static float sfxVolumeDefault = 1f;

	private static float musicVolumeDefault = 1f;

	private static Language gameLanguageDefault = Language.DEFAULT;

	private static bool dogDeathEnabled = true;

	private static bool cappedGenetics = false;

	private static bool ghostAutoSpawnEnabled = true;

	private static bool customAverageAdultDogLifespan = false;

	private static int averageAdultDogLifespanInMinutes = 35;

	private static bool passiveModeEnabled = false;

	private static bool passiveModeEnabledDefault = false;

	private static bool passive_autoPupate = true;

	private static bool passive_autoPupateDefault = true;

	private static bool passive_autoHatch = true;

	private static bool passive_autoHatchDefault = true;

	private static bool passive_autoCleanPoop = true;

	private static bool passive_autoCleanPoopDefault = true;

	private static bool passive_autoClearHole = true;

	private static bool passive_autoClearHoleDefault = true;

	private static bool passive_autoCleanPuddles = true;

	private static bool passive_autoCleanPuddlesDefault = true;

	private static bool passive_autoCleanEmptyCocoons = false;

	private static bool passive_autoCleanEmptyCocoonsDefault = false;

	private static bool passive_autoCleanHalfEatenFood = false;

	private static bool passive_autoCleanHalfEatenFoodDefault = false;

	private static bool passive_autoCleanBabyTeeth = false;

	private static bool passive_autoCleanBabyTeethDefault = false;

	private static bool passive_autoCleanDirt = false;

	private static bool passive_autoCleanDirtDefault = false;

	private static bool passive_autoCleanSnow = false;

	private static bool passive_autoCleanSnowDefault = false;

	private static bool passive_autoCollectSeeds = true;

	private static bool passive_autoCollectSeedsDefault = true;

	private static bool passive_autoCollectUpgrades = true;

	private static bool passive_autoCollectUpgradesDefault = true;

	private static bool passive_autoUnwrapGifts = true;

	private static bool passive_autoUnwrapGiftsDefault = true;

	private static bool passive_autoCapsuleOpen = true;

	private static bool passive_autoCapsuleOpenDefault = true;

	private static bool passive_autoCollectCores = true;

	private static bool passive_autoCollectCoresDefault = true;

	private static bool passive_autoEggCollection = true;

	private static bool passive_autoEggCollectionDefault = true;

	private static bool passive_autoEggHatch = true;

	private static bool passive_autoEggHatchDefault = true;

	private static bool passive_autoHideGUI = true;

	private static bool passive_autoHideGUIDefault = true;

	private static bool passive_autoHideCursor = true;

	private static bool passive_autoHideCursorDefault = true;

	private static PassiveNotificationsOption passive_DeathNotifications = PassiveNotificationsOption.SMALL_NOTIF;

	private static PassiveNotificationsOption passive_DeathNotificationsDefault = PassiveNotificationsOption.SMALL_NOTIF;

	private static PassiveNotificationsOption passive_EggNotifications = PassiveNotificationsOption.SMALL_NOTIF;

	private static PassiveNotificationsOption passive_EggNotificationsDefault = PassiveNotificationsOption.SMALL_NOTIF;

	private static PassiveNotificationsOption passive_MutationNotifications = PassiveNotificationsOption.SMALL_NOTIF;

	private static PassiveNotificationsOption passive_MutationNotificationsDefault = PassiveNotificationsOption.SMALL_NOTIF;

	private static PassiveBreedingOption passive_autoBreedingOption = PassiveBreedingOption.PROXIMAL_PARENT;

	private static PassiveBreedingOption passive_autoBreedingOptionDefault = PassiveBreedingOption.PROXIMAL_PARENT;

	private static PassiveBreedingRelationshipRequirement passive_autoBreedingRelationshipRequirement = PassiveBreedingRelationshipRequirement.REQUIRED;

	private static PassiveBreedingRelationshipRequirement passive_autoBreedingRelationshipRequirementDefault = PassiveBreedingRelationshipRequirement.REQUIRED;

	private static PassiveMutationRate passive_eggMutationRate = PassiveMutationRate.DEFAULT;

	private static PassiveMutationRate passive_eggMutationRateDefault = PassiveMutationRate.DEFAULT;

	private static PassiveMutationRate passive_pupationMutationRate = PassiveMutationRate.DEFAULT;

	private static PassiveMutationRate passive_pupationMutationRateDefault = PassiveMutationRate.DEFAULT;

	private static PassiveMutationRate passive_floraMutationEffects = PassiveMutationRate.DEFAULT;

	private static PassiveMutationRate passive_floraMutationEffectsDefault = PassiveMutationRate.DEFAULT;

	private static bool passive_cam_randomPenFocus = true;

	private static bool passive_cam_randomPenFocusDefault = true;

	private static bool passive_cam_randomDogFocus = true;

	private static bool passive_cam_randomDogFocusDefault = true;

	private static bool passive_cam_randomPenFocusRotation = true;

	private static bool passive_cam_randomPenFocusRotationDefault = true;

	private static bool passive_cam_focusOnDyingDogs = true;

	private static bool passive_cam_focusOnDyingDogsDefault = true;

	private static bool passive_cam_focusOnHatchingCocoons = true;

	private static bool passive_cam_focusOnHatchingCocoonsDefault = true;

	private static bool passive_cam_focusOnHatchingEggs = true;

	private static bool passive_cam_focusOnHatchingEggsDefault = true;

	private static bool passive_deathByStarvation = true;

	private static bool passive_deathByStarvationDefault = true;

	private static Vector2 minimumResolution = new Vector2(350f, 350f);

	private static AmbientOcclusion aoRef;

	private static DogFocus dogFocusRef;

	private static PenFocus penFocusRef;

	private static CursorController cursorRef;

	public static void RestoreDefaultPassiveModeSettings()
	{
		passiveModeEnabled = passiveModeEnabledDefault;
		passive_autoPupate = passive_autoPupateDefault;
		passive_autoHatch = passive_autoHatchDefault;
		passive_autoCleanPoop = passive_autoCleanPoopDefault;
		passive_autoClearHole = passive_autoClearHoleDefault;
		passive_autoCleanPuddles = passive_autoCleanPuddlesDefault;
		passive_autoCleanEmptyCocoons = passive_autoCleanEmptyCocoonsDefault;
		passive_autoCleanHalfEatenFood = passive_autoCleanHalfEatenFoodDefault;
		passive_autoCleanBabyTeeth = passive_autoCleanBabyTeethDefault;
		passive_autoCleanDirt = passive_autoCleanDirtDefault;
		passive_autoCleanSnow = passive_autoCleanSnowDefault;
		passive_autoCollectSeeds = passive_autoCollectSeedsDefault;
		passive_autoCollectUpgrades = passive_autoCollectUpgradesDefault;
		passive_autoUnwrapGifts = passive_autoUnwrapGiftsDefault;
		passive_autoCapsuleOpen = passive_autoCapsuleOpenDefault;
		passive_autoCollectCores = passive_autoCollectCoresDefault;
		passive_autoEggCollection = passive_autoEggCollectionDefault;
		passive_autoEggHatch = passive_autoEggHatchDefault;
		passive_autoHideGUI = passive_autoHideGUIDefault;
		passive_autoHideCursor = passive_autoHideCursorDefault;
		passive_DeathNotifications = passive_DeathNotificationsDefault;
		passive_EggNotifications = passive_EggNotificationsDefault;
		passive_MutationNotifications = passive_MutationNotificationsDefault;
		passive_autoBreedingOption = passive_autoBreedingOptionDefault;
		passive_autoBreedingRelationshipRequirement = passive_autoBreedingRelationshipRequirementDefault;
		passive_eggMutationRate = passive_eggMutationRateDefault;
		passive_pupationMutationRate = passive_pupationMutationRateDefault;
		passive_floraMutationEffects = passive_floraMutationEffectsDefault;
		passive_cam_randomPenFocus = passive_cam_randomPenFocusDefault;
		passive_cam_randomDogFocus = passive_cam_randomDogFocusDefault;
		passive_cam_randomPenFocusRotation = passive_cam_randomPenFocusRotationDefault;
		passive_cam_focusOnDyingDogs = passive_cam_focusOnDyingDogsDefault;
		passive_cam_focusOnHatchingCocoons = passive_cam_focusOnHatchingCocoonsDefault;
		passive_cam_focusOnHatchingEggs = passive_cam_focusOnHatchingEggsDefault;
		passive_deathByStarvation = passive_deathByStarvationDefault;
	}

	public static void SetDogDeathEnabled(bool val)
	{
		dogDeathEnabled = val;
	}

	public static bool IsDogDeathEnabled()
	{
		return dogDeathEnabled;
	}

	public static void SetCappedGenetics(bool val)
	{
		cappedGenetics = val;
	}

	public static bool AreGeneticsCapped()
	{
		return cappedGenetics;
	}

	public static void SetPassiveModeEnabled(bool val)
	{
		passiveModeEnabled = val;
	}

	public static bool IsPassiveModeEnabled()
	{
		return passiveModeEnabled;
	}

	public static void SetPassiveModeAutoPupate(bool val)
	{
		passive_autoPupate = val;
	}

	public static bool PassiveModeAutoPupate()
	{
		return passive_autoPupate;
	}

	public static void SetPassiveModeAutoHatch(bool val)
	{
		passive_autoHatch = val;
	}

	public static bool PassiveModeAutoHatch()
	{
		return passive_autoHatch;
	}

	public static void SetPassiveModeAutoCleanPoop(bool val)
	{
		passive_autoCleanPoop = val;
	}

	public static bool PassiveModeAutoCleanPoop()
	{
		return passive_autoCleanPoop;
	}

	public static void SetPassiveModeAutoClearHole(bool val)
	{
		passive_autoClearHole = val;
	}

	public static bool PassiveModeAutoClearHole()
	{
		return passive_autoClearHole;
	}

	public static void SetPassiveModeAutoCleanPuddles(bool val)
	{
		passive_autoCleanPuddles = val;
	}

	public static bool PassiveModeAutoCleanPuddles()
	{
		return passive_autoCleanPuddles;
	}

	public static void SetPassiveModeAutoCleanEmptyCocoons(bool val)
	{
		passive_autoCleanEmptyCocoons = val;
	}

	public static bool PassiveModeAutoCleanEmptyCocoons()
	{
		return passive_autoCleanEmptyCocoons;
	}

	public static void SetPassiveModeAutoCleanHalfEatenFood(bool val)
	{
		passive_autoCleanHalfEatenFood = val;
	}

	public static bool PassiveModeAutoCleanHalfEatenFood()
	{
		return passive_autoCleanHalfEatenFood;
	}

	public static void SetPassiveModeAutoCleanBabyTeeth(bool val)
	{
		passive_autoCleanBabyTeeth = val;
	}

	public static bool PassiveModeAutoCleanBabyTeeth()
	{
		return passive_autoCleanBabyTeeth;
	}

	public static void SetPassiveModeAutoCleanDirt(bool val)
	{
		passive_autoCleanDirt = val;
	}

	public static bool PassiveModeAutoCleanDirt()
	{
		return passive_autoCleanDirt;
	}

	public static void SetPassiveModeAutoCleanSnow(bool val)
	{
		passive_autoCleanSnow = val;
	}

	public static bool PassiveModeAutoCleanSnow()
	{
		return passive_autoCleanSnow;
	}

	public static void SetPassiveModeAutoCollectSeeds(bool val)
	{
		passive_autoCollectSeeds = val;
	}

	public static bool PassiveModeAutoCollectSeeds()
	{
		return passive_autoCollectSeeds;
	}

	public static void SetPassiveModeAutoCollectUpgrades(bool val)
	{
		passive_autoCollectUpgrades = val;
	}

	public static bool PassiveModeAutoCollectUpgrades()
	{
		return passive_autoCollectUpgrades;
	}

	public static void SetPassiveModeAutoCollectCores(bool val)
	{
		passive_autoCollectCores = val;
	}

	public static bool PassiveModeAutoCollectCores()
	{
		return passive_autoCollectCores;
	}

	public static void SetPassiveModeAutoUnwrapGifts(bool val)
	{
		passive_autoUnwrapGifts = val;
	}

	public static bool PassiveModeAutoUnwrapGifts()
	{
		return passive_autoUnwrapGifts;
	}

	public static void SetPassiveModeAutoCapsuleOpen(bool val)
	{
		passive_autoCapsuleOpen = val;
	}

	public static bool PassiveModeAutoCapsuleOpen()
	{
		return passive_autoCapsuleOpen;
	}

	public static void SetPassiveModeAutoEggCollection(bool val)
	{
		passive_autoEggCollection = val;
	}

	public static bool PassiveModeAutoEggCollect()
	{
		return passive_autoEggCollection;
	}

	public static void SetPassiveModeAutoEggHatch(bool val)
	{
		passive_autoEggHatch = val;
	}

	public static bool PassiveModeAutoEggHatch()
	{
		return passive_autoEggHatch;
	}

	public static void SetPassiveModeAutoHideGUI(bool val)
	{
		passive_autoHideGUI = val;
	}

	public static bool PassiveModeAutoHideGUI()
	{
		return passive_autoHideGUI;
	}

	public static void SetPassiveModeAutoHideCursor(bool val)
	{
		passive_autoHideCursor = val;
	}

	public static bool PassiveModeAutoHideCursor()
	{
		return passive_autoHideCursor;
	}

	public static void SetPassiveModeDeathNotificationOption(PassiveNotificationsOption val)
	{
		passive_DeathNotifications = val;
	}

	public static PassiveNotificationsOption PassiveModeDeathNotificationOption()
	{
		return passive_DeathNotifications;
	}

	public static void SetPassiveModeMutationNotificationOption(PassiveNotificationsOption val)
	{
		passive_MutationNotifications = val;
	}

	public static PassiveNotificationsOption PassiveModeMutationNotificationOption()
	{
		return passive_MutationNotifications;
	}

	public static void SetPassiveModeEggNotificationOption(PassiveNotificationsOption val)
	{
		if (val == PassiveNotificationsOption.FULL_NOTIF)
		{
			val = PassiveNotificationsOption.SMALL_NOTIF;
		}
		passive_EggNotifications = val;
	}

	public static PassiveNotificationsOption PassiveModeEggNotificationOption()
	{
		return passive_EggNotifications;
	}

	public static void SetPassiveModeAutoBreedingOption(PassiveBreedingOption val)
	{
		passive_autoBreedingOption = val;
	}

	public static PassiveBreedingOption PassiveModeAutoBreedingOption()
	{
		return passive_autoBreedingOption;
	}

	public static void SetPassiveModeAutoBreedingRelationshipRequirement(PassiveBreedingRelationshipRequirement val)
	{
		passive_autoBreedingRelationshipRequirement = val;
	}

	public static PassiveBreedingRelationshipRequirement PassiveModeAutoBreedingRelationshipRequirement()
	{
		return passive_autoBreedingRelationshipRequirement;
	}

	public static void SetPassiveEggMutationRate(PassiveMutationRate val)
	{
		passive_eggMutationRate = val;
	}

	public static PassiveMutationRate PassiveEggMutationRate()
	{
		return passive_eggMutationRate;
	}

	public static void SetPassivePupationMutationRate(PassiveMutationRate val)
	{
		passive_pupationMutationRate = val;
	}

	public static PassiveMutationRate PassivePupationMutationRate()
	{
		return passive_pupationMutationRate;
	}

	public static void SetPassiveFloraMutationEffects(PassiveMutationRate val)
	{
		passive_floraMutationEffects = val;
	}

	public static PassiveMutationRate PassiveFloraMutationEffects()
	{
		return passive_floraMutationEffects;
	}

	public static void SetPassiveModeRandomPenFocus(bool val)
	{
		passive_cam_randomPenFocus = val;
	}

	public static bool PassiveModeRandomPenFocus()
	{
		return passive_cam_randomPenFocus;
	}

	public static void SetPassiveModeRandomDogFocus(bool val)
	{
		passive_cam_randomDogFocus = val;
	}

	public static bool PassiveModeRandomDogFocus()
	{
		return passive_cam_randomDogFocus;
	}

	public static void SetPassiveModeRandomPenFocusRotation(bool val)
	{
		passive_cam_randomPenFocusRotation = val;
	}

	public static bool PassiveModeRandomPenFocusRotation()
	{
		return passive_cam_randomPenFocusRotation;
	}

	public static void SetPassiveModeFocusOnDyingDogs(bool val)
	{
		passive_cam_focusOnDyingDogs = val;
	}

	public static bool PassiveModeFocusOnDyingDogs()
	{
		return passive_cam_focusOnDyingDogs;
	}

	public static void SetPassiveModeFocusOnHatchingCocoons(bool val)
	{
		passive_cam_focusOnHatchingCocoons = val;
	}

	public static bool PassiveModeFocusOnHatchingCocoons()
	{
		return passive_cam_focusOnHatchingCocoons;
	}

	public static void SetPassiveModeFocusOnHatchingEggs(bool val)
	{
		passive_cam_focusOnHatchingEggs = val;
	}

	public static bool PassiveModeFocusOnHatchingEggs()
	{
		return passive_cam_focusOnHatchingEggs;
	}

	public static void SetPassiveModeDeathByStarvation(bool val)
	{
		passive_deathByStarvation = val;
	}

	public static bool PassiveModeDeathByStarvation()
	{
		return passive_deathByStarvation;
	}

	public static void SetGhostAutoSpawnEnabled(bool val)
	{
		ghostAutoSpawnEnabled = val;
	}

	public static bool IsGhostAutoSpawnEnabled()
	{
		return ghostAutoSpawnEnabled;
	}

	public static void UseDefaultAdultDogLifespanInMinutes()
	{
		customAverageAdultDogLifespan = false;
		averageAdultDogLifespanInMinutes = Mathf.RoundToInt(DoggyBrain.dogAgeToTimeDict[DogAge.ADULT] / 60f);
	}

	public static void SetAverageAdultDogLifespanInMinutes(int newVal)
	{
		customAverageAdultDogLifespan = true;
		averageAdultDogLifespanInMinutes = newVal;
	}

	public static bool IsCustomAverageAdultDogLifespanSet()
	{
		return customAverageAdultDogLifespan;
	}

	public static int GetAverageAdultDogLifespanInMinutes()
	{
		return averageAdultDogLifespanInMinutes;
	}

	public static void ApplyStoredSettings(bool fromMainMenu = false)
	{
		ApplySFXVolume(GetStoredSFXVolume(), save: false);
		ApplyMusicVolume(GetStoredMusicVolume(), save: false);
		ApplyTextureQuality(GetStoredTextureQuality(), save: false);
		ApplyVsync(GetStoredVsync(), save: false);
		ApplyGameLanguage(GetStoredGameLanguage(), save: false);
		Resolution currentResolution = Screen.currentResolution;
		if (Screen.fullScreenMode != FullScreenMode.ExclusiveFullScreen)
		{
			currentResolution.width = Screen.width;
			currentResolution.height = Screen.height;
		}
		if ((float)currentResolution.width < minimumResolution.x && (float)currentResolution.height < minimumResolution.y)
		{
			Debug.LogError("The game seems to be running at a resolution that should not be possible... forcing to something valid.");
			if (Screen.resolutions.Length != 0)
			{
				ApplyResolution(Screen.resolutions[Screen.resolutions.Length - 1], Screen.fullScreenMode);
				return;
			}
			ApplyResolution(new Resolution
			{
				width = 800,
				height = 600
			}, Screen.fullScreenMode);
		}
		else if (!fromMainMenu)
		{
			ApplyPostFX(GetStoredPostFX(), save: false);
			ApplyAO(GetStoredAO(), save: false);
			ApplyMotionBlur(GetStoredMotionBlur(), save: false);
			ApplyDOF(GetStoredDOF(), save: false);
			ApplyXAxisInvert(GetStoredXAxisInvert(), save: false);
			ApplyYAxisInvert(GetStoredYAxisInvert(), save: false);
			ApplyCameraSensitivity(GetStoredCameraSensitivity(), save: false);
			ApplyScrollSensitivity(GetStoredScrollSensitivity(), save: false);
			ApplyUIScrollSensitivity(GetStoredUIScrollSensitivity(), save: false);
			ApplyGamepadSensitivity(GetStoredGamepadSensitivity(), save: false);
		}
	}

	public static void RestoreDefaultSettings()
	{
		ApplyPostFX(postFXDefault, save: true);
		ApplyVsync(vsyncDefault, save: true);
		ApplyTextureQuality((OptionsMenuController.TextureQuality)textureQualityDefault, save: true);
		ApplyAO(aoDefault, save: true);
		ApplyMotionBlur(motionBlurDefault, save: true);
		ApplyDOF(depthOfFieldDefault, save: true);
		ApplyXAxisInvert(xAxisInvertDefault, save: true);
		ApplyYAxisInvert(yAxisInvertDefault, save: true);
		ApplyCameraSensitivity(camSensitivityDefault, save: true);
		ApplyScrollSensitivity(scrollSensitivityDefault, save: true);
		ApplyUIScrollSensitivity(UIScrollSensitivityDefault, save: true);
		ApplyGamepadSensitivity(gamepadSensitivityDefault, save: true);
		ApplySFXVolume(sfxVolumeDefault, save: true);
		ApplyMusicVolume(musicVolumeDefault, save: true);
	}

	public static bool GetStoredBorderlessFullscreen()
	{
		if (PlayerPrefs.GetInt(borderlessFullscreenKey, borderlessFullscreenDefault ? 1 : 0) != 1)
		{
			return false;
		}
		return true;
	}

	public static void StoreBorderlessFullscreen(bool val)
	{
		PlayerPrefs.SetInt(borderlessFullscreenKey, val ? 1 : 0);
	}

	public static bool GetStoredVsync()
	{
		if (PlayerPrefs.GetInt(vsyncKey, vsyncDefault ? 1 : 0) != 1)
		{
			return false;
		}
		return true;
	}

	public static void ApplyVsync(bool val, bool save)
	{
		if (save)
		{
			PlayerPrefs.SetInt(vsyncKey, val ? 1 : 0);
		}
		if (val)
		{
			QualitySettings.vSyncCount = 1;
		}
		else
		{
			QualitySettings.vSyncCount = 0;
		}
	}

	public static void ApplyResolution(Resolution res, FullScreenMode mode)
	{
		Screen.SetResolution(res.width, res.height, mode, res.refreshRate);
	}

	public static void ApplyPostFX(bool value, bool save)
	{
		if (save)
		{
			PlayerPrefs.SetInt(postFXKey, value ? 1 : 0);
		}
		Camera[] array = Object.FindObjectsOfType<Camera>();
		for (int i = 0; i < array.Length; i++)
		{
			CameraOptionsHelper cameraOptionsHelper = array[i].GetComponent<CameraOptionsHelper>();
			if (cameraOptionsHelper == null)
			{
				Debug.LogError(string.Concat("Camera: ", array[i], " does not have a CameraOptionsHelper component."));
				cameraOptionsHelper = array[i].gameObject.AddComponent<CameraOptionsHelper>();
			}
			cameraOptionsHelper.SyncPostFX();
		}
	}

	public static bool GetStoredPostFX()
	{
		bool flag = postFXDefault;
		if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX)
		{
			flag = postFXDefaultMacOS;
		}
		if (PlayerPrefs.GetInt(postFXKey, flag ? 1 : 0) != 1)
		{
			return false;
		}
		return true;
	}

	public static void ApplyStoredTextureQuality()
	{
		ApplyTextureQuality(GetStoredTextureQuality(), save: false);
	}

	public static void ApplyTextureQuality(OptionsMenuController.TextureQuality quality, bool save)
	{
		if (save)
		{
			PlayerPrefs.SetInt(textureQualityKey, (int)quality);
		}
		QualitySettings.masterTextureLimit = (int)quality;
	}

	public static OptionsMenuController.TextureQuality GetStoredTextureQuality()
	{
		return (OptionsMenuController.TextureQuality)PlayerPrefs.GetInt(textureQualityKey, textureQualityDefault);
	}

	public static void ApplyAO(bool value, bool save)
	{
		if (save)
		{
			PlayerPrefs.SetInt(aoKey, value ? 1 : 0);
		}
		if (!(aoRef == null) || TryStoreAORef())
		{
			aoRef.active = value;
		}
	}

	public static bool GetStoredAO()
	{
		if (PlayerPrefs.GetInt(aoKey, aoDefault ? 1 : 0) != 1)
		{
			return false;
		}
		return true;
	}

	public static void ApplyMotionBlur(bool value, bool save)
	{
		if (save)
		{
			PlayerPrefs.SetInt(motionBlurKey, value ? 1 : 0);
		}
		if (!(penFocusRef == null) || TryStoreCameraRefs())
		{
			if (value)
			{
				penFocusRef.EnableMotionBlur(MotionBlurLockReason.OPTIONS_MENU);
			}
			else
			{
				penFocusRef.DisableMotionBlur(MotionBlurLockReason.OPTIONS_MENU);
			}
		}
	}

	public static bool GetStoredMotionBlur()
	{
		if (PlayerPrefs.GetInt(motionBlurKey, motionBlurDefault ? 1 : 0) != 1)
		{
			return false;
		}
		return true;
	}

	public static void ApplyDOF(bool value, bool save)
	{
		if (save)
		{
			PlayerPrefs.SetInt(dofKey, value ? 1 : 0);
		}
		if (!(dogFocusRef == null) || TryStoreCameraRefs())
		{
			dogFocusRef.SetDOFOptionEnabled(value);
		}
	}

	public static bool GetStoredDOF()
	{
		if (PlayerPrefs.GetInt(dofKey, depthOfFieldDefault ? 1 : 0) != 1)
		{
			return false;
		}
		return true;
	}

	public static void ApplyXAxisInvert(bool value, bool save)
	{
		if (save)
		{
			PlayerPrefs.SetInt(xInvertKey, value ? 1 : 0);
		}
		if (!(penFocusRef == null) || TryStoreCameraRefs())
		{
			penFocusRef.UpdateXCamInversion(value);
		}
	}

	public static bool GetStoredXAxisInvert()
	{
		if (PlayerPrefs.GetInt(xInvertKey, xAxisInvertDefault ? 1 : 0) != 1)
		{
			return false;
		}
		return true;
	}

	public static void ApplyYAxisInvert(bool value, bool save)
	{
		if (save)
		{
			PlayerPrefs.SetInt(yInvertKey, value ? 1 : 0);
		}
		if (!(penFocusRef == null) || TryStoreCameraRefs())
		{
			penFocusRef.UpdateYCamInversion(value);
		}
	}

	public static bool GetStoredYAxisInvert()
	{
		if (PlayerPrefs.GetInt(yInvertKey, yAxisInvertDefault ? 1 : 0) != 1)
		{
			return false;
		}
		return true;
	}

	public static void ApplyCameraSensitivity(float value, bool save)
	{
		if (save)
		{
			PlayerPrefs.SetFloat(camSensitivityKey, value);
		}
		if (!(penFocusRef == null) || TryStoreCameraRefs())
		{
			penFocusRef.SetCamSensitivity(value);
		}
	}

	public static float GetStoredCameraSensitivity()
	{
		return PlayerPrefs.GetFloat(camSensitivityKey, camSensitivityDefault);
	}

	public static void ApplyGamepadSensitivity(float value, bool save)
	{
		if (save)
		{
			PlayerPrefs.SetFloat(gamepadSensitivityKey, value);
		}
		if (!(cursorRef == null) || TryStoreCursorRefs())
		{
			cursorRef.SetGamepadSensitivity(value);
		}
	}

	public static float GetStoredGamepadSensitivity()
	{
		return PlayerPrefs.GetFloat(gamepadSensitivityKey, gamepadSensitivityDefault);
	}

	public static void ApplyScrollSensitivity(float value, bool save)
	{
		if (save)
		{
			PlayerPrefs.SetFloat(scrollSensitivityKey, value);
		}
		if (!(cursorRef == null) || TryStoreCursorRefs())
		{
			cursorRef.SetScrollSensitivity(value);
		}
	}

	public static float GetStoredScrollSensitivity()
	{
		return PlayerPrefs.GetFloat(scrollSensitivityKey, scrollSensitivityDefault);
	}

	public static void ApplyUIScrollSensitivity(float value, bool save)
	{
		if (save)
		{
			PlayerPrefs.SetFloat(UIScrollSensitivityKey, value);
		}
		if (!(cursorRef == null) || TryStoreCursorRefs())
		{
			cursorRef.SetUIScrollSensitivity(value);
		}
	}

	public static float GetStoredUIScrollSensitivity()
	{
		return PlayerPrefs.GetFloat(UIScrollSensitivityKey, UIScrollSensitivityDefault);
	}

	public static void ApplySFXVolume(float value, bool save)
	{
		SFXOverlord.SetSFXVolume(value);
		if (save)
		{
			PlayerPrefs.SetFloat(sfxVolumeKey, value);
		}
	}

	public static float GetStoredSFXVolume()
	{
		return PlayerPrefs.GetFloat(sfxVolumeKey, sfxVolumeDefault);
	}

	public static void ApplyMusicVolume(float value, bool save)
	{
		SFXOverlord.SetMusicVolume(value);
		if (save)
		{
			PlayerPrefs.SetFloat(musicVolumeKey, value);
		}
	}

	public static float GetStoredMusicVolume()
	{
		return PlayerPrefs.GetFloat(musicVolumeKey, musicVolumeDefault);
	}

	public static void ApplyGameLanguage(Language value, bool save)
	{
		if (value == Language.DEFAULT)
		{
			value = GetSupportedSystemLanguage();
		}
		if (save)
		{
			PlayerPrefs.SetInt(gameLanguageKey, (int)value);
		}
		LocalizationManager.CurrentLanguage = GetLanguageStringForLanguage(value);
	}

	public static string GetLanguageStringForLanguage(Language language)
	{
		switch (language)
		{
		case Language.ENGLISH:
			return "english";
		case Language.FRENCH:
			return "french";
		case Language.ITALIAN:
			return "italian";
		case Language.GERMAN:
			return "german";
		case Language.SPANISH:
			return "spanish";
		case Language.CHINESE_TRAD:
			return "chinese (traditional)";
		case Language.CHINESE_SIMP:
			return "chinese (simplified)";
		case Language.KOREAN:
			return "korean";
		case Language.RUSSIAN:
			return "russian";
		case Language.JAPANESE:
			return "japanese";
		default:
			Debug.LogError("No language code present for language: " + language);
			return "english";
		}
	}

	public static Language GetSupportedSystemLanguage()
	{
		Language result = Language.ENGLISH;
		switch (Application.systemLanguage)
		{
		case SystemLanguage.French:
			result = Language.FRENCH;
			break;
		case SystemLanguage.Italian:
			result = Language.ITALIAN;
			break;
		case SystemLanguage.German:
			result = Language.GERMAN;
			break;
		case SystemLanguage.Spanish:
			result = Language.SPANISH;
			break;
		case SystemLanguage.Chinese:
			result = Language.CHINESE_SIMP;
			break;
		case SystemLanguage.ChineseSimplified:
			result = Language.CHINESE_SIMP;
			break;
		case SystemLanguage.ChineseTraditional:
			result = Language.CHINESE_TRAD;
			break;
		case SystemLanguage.Korean:
			result = Language.KOREAN;
			break;
		case SystemLanguage.Russian:
			result = Language.RUSSIAN;
			break;
		case SystemLanguage.Japanese:
			result = Language.JAPANESE;
			break;
		}
		return result;
	}

	public static Language GetStoredGameLanguage()
	{
		Language language = (Language)PlayerPrefs.GetInt(gameLanguageKey, (int)gameLanguageDefault);
		if (language == Language.DEFAULT)
		{
			language = Language.ENGLISH;
		}
		return language;
	}

	private static bool TryStoreCameraRefs()
	{
		if (penFocusRef != null && dogFocusRef != null)
		{
			return true;
		}
		Camera main = Camera.main;
		if (main == null)
		{
			return false;
		}
		penFocusRef = main.GetComponent<PenFocus>();
		dogFocusRef = main.GetComponent<DogFocus>();
		if (penFocusRef == null || dogFocusRef == null)
		{
			return false;
		}
		return true;
	}

	private static bool TryStoreCursorRefs()
	{
		if (cursorRef != null)
		{
			return true;
		}
		cursorRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		if (cursorRef == null)
		{
			return false;
		}
		return true;
	}

	private static bool TryStoreAORef()
	{
		if (aoRef != null)
		{
			return true;
		}
		if ((penFocusRef == null || dogFocusRef == null) && !TryStoreCameraRefs())
		{
			return false;
		}
		penFocusRef.GetPostFXProfile().TryGetSettings<AmbientOcclusion>(out aoRef);
		return aoRef != null;
	}
}
