using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "cruncherapp_data", menuName = "Database/Cruncher App")]
public class CruncherAppPreset : SoCustomComparison
{
	[Serializable]
	public class AppAccess
	{
		public CharacterTrait.RuleType rule;

		public List<CharacterTrait> traitList;
	}

	[Header("App Settings")]
	[Tooltip("The background image to display on load")]
	public Material loadBackground;

	[Tooltip("The background image to display once app has loaded")]
	public Material loadedBackground;

	[Tooltip("Use the cursor if the player is controlling the computer")]
	public bool useCursor;

	[Tooltip("The cursor to use")]
	public Sprite cursorSprite;

	[Tooltip("Use timer to exit: The app will exit on this timer")]
	public bool useTimer;

	[EnableIf("useTimer")]
	[Tooltip("Timer length in seconds")]
	public float timerLength;

	[Tooltip("Take this time to load in")]
	public float loadTime;

	[Tooltip("How heavy this is on loading the machine (1 = constant)")]
	[Range(0f, 1f)]
	public float loadDemand;

	[Tooltip("Always load during the duration of this app")]
	public bool alwaysLoad;

	[Range(0f, 1f)]
	[Tooltip("How heavy this is on loading the machine (1 = constant)")]
	public float alwaysLoadDemand;

	[Tooltip("App Icon displayed on desktop")]
	public Sprite desktopIcon;

	[Tooltip("Computer light emmits this colour")]
	public Color screenLightColourOnLoad;

	[Tooltip("Computer light emmits this colour")]
	public Color screenLightColourOnFinishLoad;

	[Header("Access")]
	public bool alwaysInstalled;

	[DisableIf("alwaysInstalled")]
	public bool onlyIfCorporateSabotageSkill;

	[DisableIf("alwaysInstalled")]
	public bool companyOnly;

	[DisableIf("alwaysInstalled")]
	public bool salesRecordsOnly;

	[Tooltip("Only installed if the login is an owner of the address")]
	[DisableIf("alwaysInstalled")]
	public bool onlyIfOwner;

	[ReorderableList]
	[DisableIf("alwaysInstalled")]
	public List<AppAccess> installationConditions;

	[DisableIf("alwaysInstalled")]
	public List<AddressPreset> onlyInAddresses;

	[DisableIf("alwaysInstalled")]
	public bool onlyIfResidential;

	[ReorderableList]
	[Header("Content")]
	public List<GameObject> appContent;

	[Tooltip("Played when the app is started")]
	[Header("Audio")]
	public AudioEvent onStartSound;

	[Tooltip("Played when the app is ended")]
	public AudioEvent onExitSound;

	[Tooltip("Played when the app has finished loading")]
	public AudioEvent onFinishedLoadingSound;

	[Tooltip("Open this app on end")]
	[Header("On Exit")]
	public CruncherAppPreset openOnEnd;
}
