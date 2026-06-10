using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[Serializable]
public class ModdedInteractable
{
	[Tooltip("Copy all data from this pre-existing interactable; so we can quickly make versions of different objects etc.")]
	public string copyDataFrom;

	public string spawnable;

	[Tooltip("The name of the item")]
	public string presetName;

	[Tooltip("Search for this name as a prefab within the game's files")]
	public string model;

	[Tooltip("Object pooling will not be used for this")]
	public string excludeFromObjectPooling;

	[Tooltip("If true, the mesh renderers on this object won't get turned on and off with range or room visibility.")]
	public string excludeFromVisibilityRangeChecks;

	[Tooltip("Spawn the model in at this range")]
	public string spawnRange;

	[Tooltip("If true the same material colours will be shared over all instances of this furniture for the room. Does not apply to integrated interactables which will be coloured by their parent furniture.")]
	public string inheritColouringFromDecor;

	[Tooltip("If true the same material colours will be shared over all instances of this furniture for the room. Difference from furniture: This cannot 'create' a material key, so furniture with it must already exist in the room.")]
	public string shareColoursWithFurniture;

	[Tooltip("If this object needs custom colours...")]
	public string useOwnColourSettings;

	public string mainColour;

	public string customColour1;

	public string customColour2;

	public string customColour3;

	public string inheritGrubValue;

	[Tooltip("Include belongs to name in interactable name")]
	public string includeBelongsTo;

	[Tooltip("Use a shorthand version of the name (Initial + Surname)")]
	public string useNameShorthand;

	public string useApartmentName;

	[Tooltip("Is this a light?")]
	public string isLight;

	public string lightswitch;

	public string iconOverride;

	public string itemClass;

	public string allowInApartmentStorage;

	public string allowInApartmentShop;

	public string disableMoveToStorage;

	[Tooltip("The method of placement used when the player uses the apartment editor to place this")]
	public string apartmentPlacementMode;

	public List<string> mustTouchFurniture;

	public string useMaterialOverride;

	public List<float> materialOverride;

	[Tooltip("Setup of actions able to be performed")]
	public List<string> actionsPreset;

	[Tooltip("Illegal actions are only classed as illegal if the item is in a non-public space")]
	public string onlyIllegalIfInNonPublic;

	[Tooltip("This modifier will be added to the interactable distance")]
	public string rangeModifier;

	public string physicsProfile;

	public string overrideMass;

	public string forcePhysicsAlwaysOn;

	[Tooltip("If true this object will react with doors, damage impacts etc")]
	public string reactWithExternalStimuli;

	public string mass;

	public string breakable;

	public string particleProfile;

	public string overrideShatterSettings;

	[Tooltip("The size of the shards created")]
	public string shardSize;

	[Tooltip("Create a shard every this amount of pixels on the texture")]
	public string shardEveryXPixels;

	public string overrideSpatterSettings;

	public string spatterSimulation;

	public string spatterCountMultiplier;

	[Tooltip("Trigger audio on these switch events")]
	public List<string> switchSFX1;

	[Tooltip("Set the switch state to this on start")]
	public string startingSwitchState;

	[Tooltip("Set the switch state to this on start")]
	public string startingCustomState1;

	[Tooltip("Set the switch state to this on start")]
	public string startingCustomState2;

	[Tooltip("Set the switch state to this on start")]
	public string startingCustomState3;

	[Tooltip("Set the lock state to this on start")]
	public string startingLockState;

	[Tooltip("Monetary value of this object. Min/Max.")]
	public string valueMin;

	public string valueMax;

	[Tooltip("Will the AI notice if this is moved?")]
	public string tamperEnabled;

	[Tooltip("If within reading range then display text contained in this evidence")]
	public string readingEnabled;

	[Tooltip("Reading mode is only active while switch status is true")]
	public string readingEnabledOnlyWithSwitchIsTue;

	[Tooltip("Reading mode is only active while switch status is true")]
	public string readingEnabledOnlyWithKaizenSkill;

	[Tooltip("Where to pull the text info from")]
	public string readingSource;

	[Tooltip("Discover evidence upon read")]
	public string discoverOnRead;

	[Tooltip("A delay to reading when a page is turned")]
	public string pageTurnReadingDelay;

	[Tooltip("If within a certain range, then display a grey-ed out interaction icon with name text")]
	public string distanceRecognitionEnabled;

	public string distanceRecognitionOnly;

	public string recognitionRange;

	[Tooltip("Spawn this object using this sub object group")]
	public List<string> subObjectClasses;

	[Tooltip("If the object fails to be placed in the above, use this class as a fall-back placement option. This is irrelevent for auto placement, as objects are spawned by the individual placements upon furniture, these places won't be considered.")]
	public List<string> backupClasses;

	[Tooltip("Whether this will be automatically placed along with furniture...")]
	public string autoPlacement;

	[Tooltip("If true, these objects will be placed with no owners at every gamelocation (based on other filters in this section).")]
	public string alwaysPlaceAtGameLocation;

	[Tooltip("The minimum number of objects that will be auto-placed at every gamelocation")]
	public string frequencyPerGamelocationMin;

	[Tooltip("The minimum number of objects that will be auto-placed at every gamelocation")]
	public string frequencyPerGameLocationMax;

	[Tooltip("Dictates in what order objects should be placed in...")]
	public string perGameLocationObjectPriority;

	[Tooltip("If true, owners/inhabitants/employees will be scanned for these traits and items will be placed accordingly...")]
	public string placeIfFiltersPresentInOwner;

	[Tooltip("Place if this is the citizen's home")]
	public string placeAtHome;

	[Tooltip("Place if this is the citizen's place of work")]
	public string placeAtWork;

	public List<string> traitModifier1;

	public List<string> traitModifier2;

	public List<string> traitModifier3;

	[Tooltip("The minimum number of objects that will be auto-placed for each owner")]
	public string frequencyPerOwnerMin;

	[Tooltip("The minimum number of objects that will be auto-placed for each owner")]
	public string frequencyPerOwnerMax;

	[Tooltip("If true, the overall frequency range will be multiplied by the inverse of conscientiousness (untidy = more)")]
	public string multiplyByMessiness;

	[Tooltip("Dictates in what order objects should be placed in...")]
	public string perOwnerObjectPriority;

	public string writerIs;

	public string receiverIs;

	[Tooltip("If the above two options are different, is this allowed to be from the same person to the same person?")]
	public string canBeFromSelf;

	[Header("Placement Limits")]
	public string limitPerObject;

	[Tooltip("How many of these objects can be spawned per object?")]
	public string perObjectLimit;

	public string limitPerRoom;

	[Tooltip("How many of these objects can be spawned per room?")]
	public string perRoomLimit;

	public string limitPerAddress;

	[Tooltip("How many of these objects can be spawned per address?")]
	public string perAddressLimit;

	public string limitInResidential;

	[Tooltip("How many of these objects can be spawned if residential?")]
	public string perResidentialLimit;

	public string limitInCommercial;

	[Tooltip("How many of these objects can be spawned if residential?")]
	public string perCommercialLimit;

	[Tooltip("Ban this item from being placed in certain room types")]
	public List<string> banFromRooms;

	[Tooltip("Only feature this item in certain room types")]
	public string limitToCertainRooms;

	public List<string> onlyInRooms;

	[Tooltip("Only feature this item in certain building types")]
	public string limitToCertainBuildings;

	public List<string> onlyInBuildings;

	[Tooltip("If this is not null, it will attempt to place this evidence inside a folder matching this evidence type.")]
	public string attemptToStoreInFolder;

	[Tooltip("If the above is not null, the chance of being placed in the folder.")]
	public string folderPlacementChance;

	[Tooltip("If unable to place in folder, then don't place at all")]
	public string dontPlaceIfNoFolder;

	[Tooltip("Folder's ownership must match")]
	public string folderOwnershipMustMatch;

	[Tooltip("If true this will also look to spawn upon on other objects (and prioritize them)")]
	public string useSubSpawning;

	[Tooltip("This will try to be placed in a place of security matching this, if not higher...")]
	public string securityLevel;

	[Tooltip("Rules about being placed in owned vs non-owned locations. 'Prioritise' settings will favour owned locations but sill place in non-owned, while 'only' settings will only place in that location.")]
	public string ownedRule;

	[Tooltip("Override with ownedOnly if at work")]
	public string overrideWithOnlyOwnedSpawnAtWork;

	[Tooltip("If the object is moved by this person, also set the spawn point so it doesn't get reset.")]
	public string relocationAuthority;

	[Tooltip("Will not reset if placed in the player's home")]
	public string relocateIfPlacedInPlayersHome;

	[Tooltip("AI will attempt to put back this if it is out of place")]
	public string AIWillCorrectPosition;

	[Tooltip("On create evidence: Use the item's location as evidence parent")]
	public string locationIsParent;

	[Tooltip("Use this DDS message ID for the summary")]
	public string summaryMessageSource;

	[Tooltip("Is this a computer (cruncher)?")]
	public string isComputer;

	[Tooltip("The boot application")]
	public string bootApp;

	[Tooltip("The booted app (what this boots to)")]
	public string logInApp;

	[Tooltip("The desktop app")]
	public string desktopApp;

	[Tooltip("Additional apps")]
	public List<string> additionalApps;

	[Tooltip("Should there be fingerprints here?")]
	public string fingerprintsEnabled;

	[Tooltip("The source of the prints")]
	public string printsSource;

	[Tooltip("Fingerprint density")]
	public string fingerprintDensity;

	[Tooltip("Dynamic fingerprints will be left when an AI uses this")]
	public string enableDynamicFingerprints;

	public string disableDynamicFingerprintsFromStaticPrintsSources;

	[Tooltip("Override the default fingerprint maximum")]
	public string overrideMaxDynamicFingerprints;

	[EnableIf("overrideMaxDynamicFingerprints")]
	public string maxDynamicFingerprints;

	[Tooltip("If this is a first person item, the corresponding item ID")]
	public string fpsItem;

	public string isInventoryItem;

	[Tooltip("Offset of held item")]
	public string fpsItemOffsetX;

	public string fpsItemOffsetY;

	public string fpsItemOffsetZ;

	public string fpsItemRotationX;

	public string fpsItemRotationY;

	public string fpsItemRotationZ;

	[Tooltip("Added to the FPS item scale (default usually 4100 in all dimensions)")]
	public string fpsItemScaleModifier;

	[Tooltip("The amount of consumable; consumed at 1 per second by the player")]
	public string consumableAmount;

	[Tooltip("Destroy when this is all consumed")]
	public string destroyWhenAllConsumed;

	[Tooltip("Trash object")]
	public string useSameModelAsTrash;

	public string trashItem;

	public string disposal;

	public string chanceOfDroppedAngle;

	public string droppedAngleHeightBoost;

	public string weapon;

	[Tooltip("If in inventory, display object")]
	public string inventoryCarryItem;

	[Tooltip("This required a carrying animation")]
	public string requiredCarryAnimation;

	[Tooltip("If an AI can carry this, which carrying animation to play")]
	public string aiCarryAnimation;

	[Tooltip("position object by this when AI is holding")]
	public string aiHeldObjectPositionX;

	public string aiHeldObjectPositionY;

	public string aiHeldObjectPositionZ;

	[Tooltip("Rotate object by this when AI is holding")]
	public string aiHeldObjectRotationX;

	public string aiHeldObjectRotationY;

	public string aiHeldObjectRotationZ;

	[Tooltip("The AI will put this down when at home")]
	public string putDownAtHome;

	[Tooltip("The AI will take this when they leave home")]
	public string takeWith;

	public List<string> putDownPositions;

	public List<string> backupPutDownPositions;

	public string specialCaseFlag;

	[Tooltip("Affect room steam amount with switch state 1")]
	public string affectRoomSteamLevel;

	[Tooltip("This is a payphone")]
	public string isPayphone;

	[Tooltip("This is a clock; use hourly chimes")]
	public string isClock;

	[Tooltip("If true this will be a naming special case.")]
	public string isMoney;

	[Tooltip("According to AI, only 1 entertainment source should be active in a room")]
	public string entertainmentSource;

	[Tooltip("Is this a heat source? Only active when switch 0 is on")]
	public string isHeatSource;

	[Tooltip("Mark this as trash as soon as it is created, for removal as soon as possible")]
	public string markAsTrashOnCreate;

	[Tooltip("If picked up, the AI will seek to put this in a bin/gets added to their carrying trash")]
	public string isLitter;

	[Tooltip("Will require an art asset sent to a decal projector")]
	public string isDecal;

	[Tooltip("Used for detecting work positions/animations mostly")]
	public string isMovableChair;

	[Tooltip("This is the right side of a double bed")]
	public string bedRightSide;

	[Tooltip("Resets switch states to starting configuration after x amount of time")]
	public string resetSwitchStates;

	public string resetTimer;

	[Tooltip("Don't save switch states")]
	public string dontSaveSwitchStates;

	[Tooltip("Don't load switch states")]
	public string dontLoadSwitchStates;

	[Tooltip("If true, the game will record the creation time of this in passed variables")]
	public string recordCreationTime;

	[Tooltip("Is this a retailItem? If so here's the reference. This is set by having a RetailItem Preset that points to this.")]
	public string retailItem;

	[Tooltip("If this is associated with a shop interface, override the location's menu with this one (useful for vending machines)")]
	public string menuOverride;

	[Tooltip("Do as many chimes as the hour dictates")]
	public string chimeEqualToHour;

	[Tooltip("Delay between chimes if above is true")]
	public string chimeDelay;
}
