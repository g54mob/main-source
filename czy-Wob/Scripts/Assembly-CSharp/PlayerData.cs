using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
	public bool newSave = true;

	public bool initialEggCollected;

	public bool hasGeneratedCorePortraits;

	public SaveableDogs dogs;

	public SaveableGoals goals;

	public SaveableDateTime dateTime;

	public SaveableInventory inventory;

	public SaveableResearchStatus research;

	public ulong IDCounter;

	public SaveableTaggedObjects worldTaggedObjectsHome;

	public SaveableDogHome dogPenHome;

	public SaveableDogHome dogPenBreedingCenter;

	public List<SaveableFloraUnlock> floraUnlocks;

	public TutorialState tutorialState;

	public bool needsHomeLoad;

	public GameMode currentGameMode;

	public SaveableDogDenManager dogDenManager;

	public SaveableDog dogToBreedA;

	public SaveableDog dogToBreedB;

	public bool dogDeathEnabled = true;

	public bool cappedGenetics;

	public bool passiveModeDataEverSaved;

	public bool passiveModeEnabled;

	public bool passive_autoPupate = true;

	public bool passive_autoHatch = true;

	public bool passive_autoCleanPoop = true;

	public bool passive_autoClearHole = true;

	public bool passive_autoCleanPuddles = true;

	public bool passive_autoCleanEmptyCocoons;

	public bool passive_autoCleanHalfEatenFood;

	public bool passive_autoCleanBabyTeeth;

	public bool passive_autoCleanDirt;

	public bool passive_autoCleanSnow;

	public bool passive_autoCollectSeeds = true;

	public bool passive_autoCollectUpgrades = true;

	public bool passive_autoUnwrapGifts = true;

	public bool passive_autoCapsuleOpen = true;

	public bool passive_autoCollectCores = true;

	public bool passive_autoEggCollection = true;

	public bool passive_autoEggHatch = true;

	public bool passive_autoHideGUI = true;

	public bool passive_autoHideCursor = true;

	public GameSettings.PassiveNotificationsOption passive_DeathNotifications;

	public GameSettings.PassiveNotificationsOption passive_EggNotifications;

	public GameSettings.PassiveNotificationsOption passive_MutationNotifications;

	public GameSettings.PassiveBreedingOption passive_autoBreedingOption = GameSettings.PassiveBreedingOption.PROXIMAL_PARENT;

	public GameSettings.PassiveBreedingRelationshipRequirement passive_autoBreedingRelationshipRequirement = GameSettings.PassiveBreedingRelationshipRequirement.REQUIRED;

	public GameSettings.PassiveMutationRate passive_eggMutationRate;

	public GameSettings.PassiveMutationRate passive_pupationMutationRate;

	public GameSettings.PassiveMutationRate passive_floraMutationEffects;

	public bool passive_cam_randomPenFocus = true;

	public bool passive_cam_randomDogFocus = true;

	public bool passive_cam_randomPenFocusRotation = true;

	public bool passive_cam_focusOnDyingDogs = true;

	public bool passive_cam_focusOnHatchingCocoons = true;

	public bool passive_cam_focusOnHatchingEggs = true;

	public bool passive_deathByStarvation = true;

	public bool ghostAutoSpawnDisabled;

	public bool customAverageAdultDogLifespan;

	public int customAverageAdultDogLifespanInMinutes = 35;
}
