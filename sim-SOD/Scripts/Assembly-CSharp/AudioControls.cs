using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioControls : MonoBehaviour
{
	[Header("Footsteps")]
	public AudioEvent footstepShoe;

	public AudioEvent footstepBoot;

	public AudioEvent footstepHeel;

	public AudioEvent footstepWaterWade;

	[Space(5f)]
	public AudioEvent playerFootstepShoe;

	public AudioEvent playerFootstepBoot;

	public AudioEvent playerFootstepHeel;

	public AudioEvent playerFootstepDuct;

	public AudioEvent playerWaterWade;

	[Space(5f)]
	public AudioEvent playerLandImpactMetal;

	public AudioEvent playerLandImpactConcrete;

	public AudioEvent playerLandImpactWood;

	[Space(5f)]
	public AudioEvent playerTripSound;

	[Header("AI: Sleeping")]
	public AudioEvent maleSnoreLight;

	public AudioEvent maleSnoreHeavy;

	public AudioEvent maleYawn;

	public AudioEvent maleSnort;

	[Space(5f)]
	public AudioEvent femaleSnoreLight;

	public AudioEvent femaleSnoreHeavy;

	public AudioEvent femaleYawn;

	public AudioEvent femaleSnort;

	[Header("Objects")]
	public AudioEvent fridgeClose;

	public AudioEvent fridegOpen;

	[Space(5f)]
	public AudioEvent tvShow;

	[Space(5f)]
	public List<AudioEvent> keypadButtons;

	public AudioEvent keypadPress;

	public AudioEvent keypadClear;

	public AudioEvent keypadAccept;

	public AudioEvent keypadDeny;

	public AudioEvent keypadArm;

	public AudioEvent payphoneMoneyIn;

	[Space(5f)]
	public AudioEvent dialTone;

	public AudioEvent hangUp;

	public AudioEvent phoneLineActive;

	public AudioEvent phoneLineRing;

	public AudioEvent phoneLineEngaged;

	public AudioEvent phoneConnect;

	[Space(5f)]
	public AudioEvent bargeDoorContact;

	public AudioEvent bargeDoorBreak;

	[Space(5f)]
	public AudioEvent elevatorDing;

	[Space(5f)]
	public AudioEvent neonSignLoopSmall;

	[Space(5f)]
	public AudioEvent codebreakerSuccess;

	[Space(5f)]
	public AudioEvent elevatorMovement;

	[Space(5f)]
	public AudioEvent alarmPA;

	public AudioEvent drinkLoop;

	[Header("Player Actions")]
	public AudioEvent spawnPlayer;

	public AudioEvent throwObject;

	public AudioEvent pickUpItemHeld;

	public AudioEvent lockpick;

	public AudioEvent lockpickMetal;

	public AudioEvent rummage;

	public AudioEvent flashlightOn;

	public AudioEvent flashlightOff;

	public AudioEvent handcuff;

	public AudioEvent handcuffArrestEnd;

	[FormerlySerializedAs("waterCoolerDrinkShort")]
	public AudioEvent waterCoolerRefillShort;

	[FormerlySerializedAs("waterCoolerDrinkLong")]
	public AudioEvent waterCoolerRefill;

	public AudioEvent moveObjectsToStorage;

	[Header("Player effects")]
	public AudioEvent brokenBone;

	[Header("Ambience")]
	public AudioEvent ambienceWind;

	public AudioEvent ambienceRain;

	public AudioEvent ambienceCity;

	public AudioEvent ambiencePA;

	[Header("Weather")]
	public AudioEvent thunder;

	[Header("Interface: FPS")]
	public AudioEvent gameMessage;

	public AudioEvent socialLevelUp;

	public AudioEvent revealCaseResults;

	public AudioEvent gainSocialCredit;

	public AudioEvent newMessage;

	public AudioEvent bountyAdded;

	public AudioEvent bountyEscapeComplete;

	public AudioEvent enforcerScannerMsg;

	[Space(5f)]
	public AudioEvent speakEvent;

	public AudioEvent shoutEvent;

	public AudioEvent screamEvent;

	[Space(5f)]
	public AudioEvent threatLoop;

	[Space(5f)]
	public AudioEvent typewriter;

	[Tooltip("The delay between audio event typewriter keystrokes.")]
	public float typewriterKeystrokeEventDelay;

	[Tooltip("The delay between audio event typewriter keystrokes.")]
	public float typewriterSpaceEventDelay;

	[Header("Snapshots")]
	public AudioEvent interfaceEvent;

	public AudioEvent combatSnapshot;

	public AudioEvent trespassingSnapshot;

	public AudioEvent syncMachineSnapshot;

	public AudioEvent musicOnlySnapshot;

	[Space(5f)]
	public AudioEvent hyperacusisHeavy;

	public AudioEvent hyperacusisMedium;

	public AudioEvent hyperacusisLight;

	[Space(5f)]
	public AudioEvent bassReductionHeavy;

	public AudioEvent bassReductionLight;

	[Header("Interface: Case Board")]
	[Tooltip("Three main buttons in top left of case board")]
	public AudioEvent panelIconButton;

	[Tooltip("Create stick note button next to panel icons in case board")]
	public AudioEvent stickyNoteCreateButton;

	[Tooltip("Grabbing a folder by the pin")]
	public AudioEvent folderPickUp;

	[Tooltip("Placing a folder back down")]
	public AudioEvent folderPutDown;

	[Tooltip("Grabbing a sticky note by the pin")]
	public AudioEvent stickyNotePickUp;

	[Tooltip("Placing a sticky note back down")]
	public AudioEvent stickyNotePutDown;

	[Tooltip("Whenever the map slides into view")]
	public AudioEvent mapSlideIn;

	[Tooltip("Whenever the map slides out of view")]
	public AudioEvent mapSlideOut;

	[Tooltip("Crossing out an item on the caseboard")]
	public AudioEvent crossOut;

	[Tooltip("Unpinning an item (effectively deleting it)")]
	public AudioEvent unPin;

	[Tooltip("'x' in the corner of items")]
	[Header("Interface: Folder")]
	public AudioEvent closeButton;

	[Tooltip("Large vertically aligned tabs on the right of an open note or folder")]
	public AudioEvent tab;

	[Tooltip("Open a folder")]
	public AudioEvent folderOpen;

	[Tooltip("Close a folder")]
	public AudioEvent folderClose;

	[Tooltip("Open a sticky note")]
	public AudioEvent stickyOpen;

	[Tooltip("Close a sticky note")]
	public AudioEvent stickyClose;

	[Tooltip("Forward through a multipage document")]
	public AudioEvent pageForward;

	[Tooltip("Back through a multipage document")]
	public AudioEvent pageBack;

	[Tooltip("Minimise a folder")]
	public AudioEvent minimiseButton;

	[Tooltip("Right click on an item top line header to bring-up a pop-up list of vertically stacked buttons")]
	public AudioEvent itemEditAppear;

	[Tooltip("ItemEditButton")]
	public AudioEvent itemEditButton;

	[Tooltip("Central (set route) button at the bottom of a location folder page")]
	public AudioEvent locationSetRouteButton;

	[Tooltip("Left and Right hand side buttons at the bottom of a location folder page")]
	public AudioEvent locationButton;

	[Tooltip("Red highlighted links that appear within a page")]
	public AudioEvent inLineLink;

	[Header("Interface: Sticky Note")]
	[Tooltip("Vertical strip of icons in top left of a note (drawing colours etc.)")]
	public AudioEvent stickyNoteEdit;

	[Tooltip("Wiping a drawing from an item")]
	public AudioEvent clearDrawing;

	[Tooltip("tickbox")]
	[Header("Interface: Menus")]
	public AudioEvent tickbox;

	[Tooltip("e.g. cancel")]
	public AudioEvent mainButtonBack;

	[Tooltip("e.g. continue")]
	public AudioEvent mainButtonForward;

	[Tooltip("same style as ButtonMainBack/Forward but for buttons that don't have that back/forward paradigm attached")]
	public AudioEvent mainButton;

	[Tooltip("Vertical column of small buttons within map panel")]
	[Header("Interface: Map")]
	public AudioEvent mapControlButton;

	[Header("Interface: Upgrades")]
	public AudioEvent syncDiskInstall;

	public AudioEvent syncDiskUninstall;

	public AudioEvent syncDiskUpgrade;

	public AudioEvent syncDiskInstallStatus;

	[Header("Interface: Inventory")]
	public AudioEvent pickUpMoney;

	public AudioEvent pickUpItem;

	public AudioEvent pickUpLockpicks;

	public AudioEvent dropItem;

	public AudioEvent purchaseItem;

	public AudioEvent motionTrackerPing;

	public AudioEvent printScannerLoop;

	public AudioEvent printScannerHolster;

	public AudioEvent printScannerSelect;

	[Header("Interface: Misc")]
	public AudioEvent caseComplete;

	public AudioEvent caseUnsolved;

	public AudioEvent newMurderCase;

	public AudioEvent newApartment;

	public AudioEvent furniturePlacement;

	[Header("Interface: Case Processing")]
	public AudioEvent caseResultCorrect;

	public AudioEvent caseResultIncorrect;

	public AudioEvent caseProcessing;

	public AudioEvent caseSubmitted;

	[Header("In-Game Computers")]
	public AudioEvent computerHDDLoading;

	public AudioEvent computerCursorClick;

	public AudioEvent computerKeyboardKey;

	public AudioEvent computerInvalidPasscode;

	public AudioEvent computerValidPasscode;

	public AudioEvent computerPrint;

	[Header("Watch")]
	public AudioEvent watchAlarm;

	public AudioEvent timeForward;

	public AudioEvent timeBackward;

	public AudioEvent watchToggleHoursMinutes;

	public AudioEvent setAlarm;

	public AudioEvent wristwatchTickTimeLoop;

	[Header("Security Systems")]
	public AudioEvent sentryGunFire;

	public AudioEvent sentryGunSearchPulse;

	public AudioEvent sentryGunTargetAcquire;

	public AudioEvent sentryGunTurnLoop;

	public AudioEvent securityCameraAlert;

	[Header("Combat")]
	public AudioEvent collapseOnFloor;

	[Space(5f)]
	public AudioEvent punchHitFabric;

	public AudioEvent punchHitWood;

	public AudioEvent punchHitCarpet;

	public AudioEvent punchHitPlaster;

	public AudioEvent punchHitConcrete;

	public AudioEvent punchHitTile;

	public AudioEvent punchHitGlass;

	public AudioEvent punchHitMetal;

	public AudioEvent punchHitFlesh;

	public AudioEvent punchHitPlayer;

	public AudioEvent punchHitWall;

	[Space(5f)]
	public AudioEvent sniperKillShot;

	public AudioEvent sniperStreetShot;

	[Header("Grenades")]
	public AudioEvent grenadeBeep;

	public AudioEvent flashBombDetonate;

	public AudioEvent incapacitatorDetonate;

	[Header("Camera")]
	public AudioEvent cameraFlash;

	[Header("Ocean Impacts")]
	public AudioEvent oceanSplashSmall;

	public AudioEvent oceanSplashMedium;

	public AudioEvent oceanSplashLarge;

	[Header("Dragging Bodies")]
	public AudioEvent dragBody;

	[Header("Misc")]
	public AudioEvent umbrellaOpenNPC;

	public AudioEvent umbrellaCloseNPC;

	public AudioEvent playerEnterVent;

	public AudioEvent snailLoop;

	[NonSerialized]
	public AudioController.LoopingSoundInfo caseProcessingLoop;

	private static AudioControls _instance;

	public static AudioControls Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}
}
