using System;
using System.Collections.Generic;
using System.Reflection;
using NaughtyAttributes;
using UnityEngine;

public class StatusController : MonoBehaviour
{
	[Serializable]
	public class FineRecord
	{
		public int addressID;

		public int objectID;

		public CrimeType crime;

		public bool confirmed;

		public int forcedPenalty;

		public FineRecord(NewAddress ad, Interactable obj, CrimeType newCrime)
		{
		}

		public void SetConfirmed(bool val)
		{
		}
	}

	public enum CrimeType
	{
		assault = 0,
		theft = 1,
		breakingAndEntering = 2,
		trespassing = 3,
		tampering = 4,
		vandalism = 5
	}

	public struct StatusInstance
	{
		public StatusPreset preset;

		public NewBuilding building;

		public NewAddress address;
	}

	public class StatusCount
	{
		public StatusInstance statusInstance;

		public StatusPreset preset;

		public StatusPreset.StatusCountConfig statusCountConfig;

		public FineRecord fineRecord;

		public float amount;

		public StatusCount(StatusInstance newInstance)
		{
		}

		public StatusCount(StatusInstance newInstance, StatusPreset.StatusCountConfig newConfig)
		{
		}

		public void Remove()
		{
		}

		public int GetPenaltyAmount()
		{
			return 0;
		}
	}

	[Header("References")]
	public RectTransform statusParent;

	[Header("Settings")]
	public float elementDefaultWdith;

	public float elementMinimizedWidth;

	public float elementDefaultHeight;

	public float elementYInterval;

	public AnimationCurve detailTextFadeInCurve;

	[Header("State")]
	[ReadOnly]
	public bool disabledRecovery;

	[ReadOnly]
	public bool disabledSprint;

	[ReadOnly]
	public bool disabledJump;

	[ReadOnly]
	public float recoveryRateMultiplier;

	[ReadOnly]
	public float maxHealthMultiplier;

	[ReadOnly]
	public float movementSpeedMultiplier;

	[ReadOnly]
	public float temperatureGainMultiplier;

	[ReadOnly]
	public float damageIncomingMultiplier;

	[ReadOnly]
	public float damageOutgoingMultiplier;

	[ReadOnly]
	public float drunkControls;

	public Dictionary<AnimationCurve, float> affectHeadBobs;

	[ReadOnly]
	public float drunkVision;

	[ReadOnly]
	public float shiverVision;

	[ReadOnly]
	public float headacheVision;

	[ReadOnly]
	public float drunkLensDistort;

	[ReadOnly]
	public float tripChanceWet;

	[ReadOnly]
	public float tripChanceDrunk;

	[ReadOnly]
	public float bloomIntensityMultiplier;

	[ReadOnly]
	public float motionBlurMultiplier;

	[ReadOnly]
	public float chromaticAbberationAmount;

	[ReadOnly]
	public float vignetteAmount;

	[ReadOnly]
	public float exposureAmount;

	[ReadOnly]
	public float channelRedR;

	[ReadOnly]
	public float channelRedG;

	[ReadOnly]
	public float channelRedB;

	[ReadOnly]
	public float channelGreenR;

	[ReadOnly]
	public float channelGreenG;

	[ReadOnly]
	public float channelGreenB;

	[ReadOnly]
	public float channelBlueR;

	[ReadOnly]
	public float channelBlueG;

	[ReadOnly]
	public float channelBlueB;

	[Header("Interface")]
	public List<StateElementController> spawnedControllers;

	public Dictionary<StatusInstance, List<StatusCount>> activeStatusCounts;

	public HashSet<StatusPreset> activeStatuses;

	public List<FineRecord> activeFineRecords;

	private Dictionary<StatusPreset, MethodInfo> checkingRef;

	private static StatusController _instance;

	public static StatusController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void DisplayCheck()
	{
	}

	public void RemoveAllCounts(StatusInstance inst)
	{
	}

	public void RemoveAllCounts(StatusPreset preset)
	{
	}

	public void ForceStatusCheck()
	{
	}

	public void ForceStatusCheck(bool bypassKOCheck = false)
	{
	}

	private void Update()
	{
	}

	public void AddFineRecord(NewAddress address, Interactable obj, CrimeType crime, bool confirm = false, int forcedPenalty = -1, bool ignoreDuplicates = false)
	{
	}

	public void RemoveFineRecord(NewAddress address, Interactable obj, CrimeType crime, bool onlyUnconfirmed = false, bool matchAddress = true)
	{
	}

	public void FineEscapeCheck()
	{
	}

	public void SetWantedInBuilding(NewBuilding b, float time)
	{
	}

	public void SetDetainedInBuilding(NewBuilding b, bool val)
	{
	}

	public bool GetCurrentDetainedStatus()
	{
		return false;
	}

	public void ConfirmFinesAtLocation(NewAddress address, CrimeType crime)
	{
	}

	public void ConfirmFine(NewAddress address, Interactable obj, CrimeType crime)
	{
	}

	public void PayActiveFines()
	{
	}

	public void Trespassing(StatusInstance inst)
	{
	}

	public void AlarmActive(StatusInstance inst)
	{
	}

	public void IllegalAction(StatusInstance inst)
	{
	}

	public void CaptureRisk(StatusInstance inst)
	{
	}

	public void ImageCaptured(StatusInstance inst)
	{
	}

	public void Wanted(StatusInstance inst)
	{
	}

	public void GuestPass(StatusInstance inst)
	{
	}

	public void Detained(StatusInstance inst)
	{
	}

	public void Echelons(StatusInstance inst)
	{
	}

	public void Hiding(StatusInstance inst)
	{
	}

	public void Stinky(StatusInstance inst)
	{
	}

	public void Cold(StatusInstance inst)
	{
	}

	public void Hungry(StatusInstance inst)
	{
	}

	public void Energized(StatusInstance inst)
	{
	}

	public void Thirsty(StatusInstance inst)
	{
	}

	public void Hydrated(StatusInstance inst)
	{
	}

	public void Drunk(StatusInstance inst)
	{
	}

	public void Sick(StatusInstance inst)
	{
	}

	public void StarchAddiction(StatusInstance inst)
	{
	}

	public void Headache(StatusInstance inst)
	{
	}

	public void Wet(StatusInstance inst)
	{
	}

	public void BrokenLeg(StatusInstance inst)
	{
	}

	public void Bruised(StatusInstance inst)
	{
	}

	public void BlackEye(StatusInstance inst)
	{
	}

	public void BlackedOut(StatusInstance inst)
	{
	}

	public void Numb(StatusInstance inst)
	{
	}

	public void Poisoned(StatusInstance inst)
	{
	}

	public void Blinded(StatusInstance inst)
	{
	}

	public void Bleeding(StatusInstance inst)
	{
	}

	public void Tired(StatusInstance inst)
	{
	}

	public void Focused(StatusInstance inst)
	{
	}

	public void Pursued(StatusInstance inst)
	{
	}

	public void WellRested(StatusInstance inst)
	{
	}

	public void SyncDiskInstall(StatusInstance inst)
	{
	}

	public void ToxicGas(StatusInstance inst)
	{
	}
}
