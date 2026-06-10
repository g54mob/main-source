using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "status_data", menuName = "Database/Status Preset")]
public class StatusPreset : SoCustomComparison
{
	public enum ProgressBarTrack
	{
		none = 0,
		witnesses = 1,
		wantedInBuilding = 2,
		alarmTime = 3,
		guestPassTime = 4
	}

	public enum StatusCountType
	{
		none = 0,
		crime = 1
	}

	[Serializable]
	public class StatusCountConfig
	{
		public string name;

		public Sprite icon;

		public Color colour;

		public PenaltyRule penaltyRule;

		public float penalty;

		public AudioEvent onAcquire;
	}

	public enum PenaltyRule
	{
		fixedValue = 0,
		percentageValue = 1,
		objectValueMultiplied = 2
	}

	[Header("Interface")]
	public Color color;

	public Color alternateColour;

	public Sprite icon;

	public Sprite alternateIcon;

	[Tooltip("After creation, minimize this to an icon for the in-game UI")]
	public bool minimizeToIcon;

	[Tooltip("Glow when active")]
	public bool pulseBackground;

	public bool pulseIcon;

	public Color pulseIconAdditiveColour;

	[Tooltip("Include a description on the detail text")]
	public bool includeDescription;

	[Space(7f)]
	[Tooltip("Automatically display a message when this is activated")]
	public bool autoNotificationMessage;

	[Range(0f, 10f)]
	[Tooltip("Where this appears on the right side menu hierarchy")]
	public int priority;

	[Header("Progress")]
	[Tooltip("Fade to white the closer the amount is to 0")]
	public bool fadeToWhite;

	[Tooltip("Use progress bar")]
	public bool enableProgressBar;

	[EnableIf("enableProgressBar")]
	public ProgressBarTrack barTracking;

	[Header("Checking")]
	[Tooltip("Use the custom named method to check the status of this")]
	public bool useCustomMethod;

	[Header("Audio")]
	public AudioEvent onAcquire;

	public AudioEvent onRemove;

	[Header("Counts")]
	public StatusCountType countType;

	[Tooltip("Override the base colour with the highest count's colour")]
	public bool overrrideColorWithCount;

	[Tooltip("Display the count number in the main text")]
	public bool displayCountCountsInMainText;

	[Tooltip("Replace description based on counts")]
	public bool replaceDescriptionBasedOnCounts;

	[Tooltip("Display the address at the end of the detail text")]
	public bool displayAddressInDetailText;

	[Tooltip("Display the building at the end of the detail text")]
	public bool displayBuildingInDetailText;

	[Tooltip("List counts in detail text")]
	public bool listCountsInDetailText;

	[Tooltip("Display the fine total in the main text")]
	public bool displayFineTotalInMainText;

	[Tooltip("Alert when new count is added")]
	public bool alertWhenNewCountIsAdded;

	[Tooltip("Display total fine when minimized")]
	public bool displayTotalFineWhenMinimized;

	[ReorderableList]
	public List<StatusCountConfig> countConfig;

	[Header("Attribute Effects (Binary)")]
	public bool stopsRecovery;

	public bool stopsSprint;

	public bool stopsJump;

	[Header("Attribute Effects (Gradual)")]
	[Space(7f)]
	public float recoveryRatePlusMP;

	public float maxHealthPlusMP;

	public float movementSpeedPlusMP;

	public float temperatureGainPlusMP;

	public float damageIncomingPlusMP;

	public float damageOutgoingPlusMP;

	[Space(7f)]
	public float drunkControls;

	public float tripChanceWet;

	public float tripChanceDrunk;

	public float affectHeadBob;

	public AnimationCurve headBob;

	[Space(7f)]
	public float drunkVision;

	public float shiverVision;

	public float drunkLensDistort;

	public float headacheVision;

	[Space(7f)]
	public float bloomIntensityPlusMP;

	public float motionBlurPlusMP;

	public float chromaticAbberationAmount;

	public float vignetteAmount;

	public float expsosure;

	[Space(7f)]
	public bool useChannelMixer;

	[ShowIf("useChannelMixer")]
	[Range(-200f, 200f)]
	[Space(7f)]
	public int redR;

	[ShowIf("useChannelMixer")]
	[Range(-200f, 200f)]
	public int redG;

	[Range(-200f, 200f)]
	[ShowIf("useChannelMixer")]
	public int redB;

	[Range(-200f, 200f)]
	[ShowIf("useChannelMixer")]
	[Space(7f)]
	public int greenR;

	[ShowIf("useChannelMixer")]
	[Range(-200f, 200f)]
	public int greenG;

	[ShowIf("useChannelMixer")]
	[Range(-200f, 200f)]
	public int greenB;

	[ShowIf("useChannelMixer")]
	[Space(7f)]
	[Range(-200f, 200f)]
	public int blueR;

	[Range(-200f, 200f)]
	[ShowIf("useChannelMixer")]
	public int blueG;

	[ShowIf("useChannelMixer")]
	[Range(-200f, 200f)]
	public int blueB;
}
