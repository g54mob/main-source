using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class NewAddress : NewGameLocation
{
	[Serializable]
	public class Vandalism
	{
		public float time;

		public int fine;

		public int obj;

		public Vector3 win;
	}

	public struct PathKey : IEquatable<PathKey>
	{
		public NewNode origin;

		public NewNode destination;

		private bool hasHash;

		private int hash;

		public PathKey(NewNode locOne, NewNode locTwo)
		{
			origin = null;
			destination = null;
			hasHash = false;
			hash = 0;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		bool IEquatable<PathKey>.Equals(PathKey other)
		{
			return false;
		}
	}

	public enum AirVent
	{
		ceiling = 0,
		wallUpper = 1,
		wallLower = 2
	}

	public struct AirVentLocation
	{
		public NewRoom room;

		public AirVent location;
	}

	public class AddressCalc
	{
		public AddressPreset preset;

		public float score;
	}

	[Header("Address Contents")]
	public AddressSaveData saveData;

	public int loadedVarIndex;

	public List<NewWall> generatedInteriorEntrances;

	public List<NewNode> protectedNodes;

	public bool featuresNeonSignageHorizontal;

	public bool featuresNeonSignageVertical;

	public NeonSignCharacters neonFont;

	public int neonColour;

	public GameObject neonSignHorizontal;

	public GameObject neonSignVertical;

	public int neonVerticalIndex;

	public bool featuresBrokenSign;

	public bool generatedRoomConfigs;

	public List<Vandalism> vandalism;

	[Header("Details")]
	public int id;

	public static int assignID;

	public int editorID;

	public static int assignEditorID;

	public LayoutConfiguration preset;

	public Color editorColour;

	public Color wood;

	public bool isOutsideAddress;

	public bool isLobbyAddress;

	public float normalizedLandValue;

	public bool hiddenSpareKey;

	[Header("Inhabitants")]
	public List<Human> owners;

	public List<Human> inhabitants;

	public List<Human> favouredCustomers;

	public AddressPreset addressPreset;

	public ResidenceController residence;

	public Company company;

	public bool interiorLightsEnabled;

	public Dictionary<RoomTypePreset, Dictionary<NewRoom, List<Human>>> roomsBelongTo;

	[Space(7f)]
	public float averageHumility;

	public float averageEmotionality;

	public float averageExtraversion;

	public float averageAgreeableness;

	public float averageConscientiousness;

	public float maxConscientiousness;

	public float averageCreativity;

	[NonSerialized]
	[Header("For Sale")]
	public Interactable saleNote;

	[Header("Alarms")]
	public List<Interactable> alarms;

	public List<Interactable> sentryGuns;

	public List<Interactable> otherSecurity;

	public bool alarmActive;

	public NewBuilding.AlarmTargetMode targetMode;

	public float targetModeSetAt;

	public List<Human> alarmTargets;

	public float alarmTimer;

	public int breakerSecurityID;

	public int breakerDoorsID;

	public int breakerLightsID;

	[NonSerialized]
	public Interactable breakerSecurity;

	[NonSerialized]
	public Interactable breakerDoors;

	[NonSerialized]
	public Interactable breakerLights;

	[Header("AI Navigation")]
	public Dictionary<PathKey, List<NewNode.NodeAccess>> internalRoutes;

	public bool generatedEntranceWeights;

	public NativeMultiHashMap<int3, int> accessRef;

	public NativeHashMap<int, float3> accessPositions;

	public NativeHashMap<int, int3> toNodeReference;

	public NativeList<int3> noPassRef;

	[Header("Passwords")]
	public GameplayController.Passcode passcode;

	public EvidenceMultiPage calendar;

	private List<Material> instancedMaterials;

	[Header("Debug")]
	public GameObject floorEditDebugParent;

	public List<CompanyOpenHoursPreset.CompanyShift> debugCompanyShifts;

	public MurderMO denDecorDebug;

	public void Setup(NewFloor newFloor, LayoutConfiguration newType, DesignStylePreset newDefaultStyle)
	{
	}

	public void GenerateRoomConfigs()
	{
	}

	public void CalculateLandValue()
	{
	}

	public void SetTargetMode(NewBuilding.AlarmTargetMode newMode, bool setResetTimer = true)
	{
	}

	public bool FindInteractableInHouse(string interactablePresetName)
	{
		return false;
	}

	public void Load(CitySaveData.AddressCitySave data, NewFloor newFloor)
	{
	}

	public void AssignPurpose()
	{
	}

	public void SetupNeonSigns()
	{
	}

	private int GetNeon()
	{
		return 0;
	}

	public void AddOwner(Human newOwner)
	{
	}

	public void AddInhabitant(Human newInhabitant)
	{
	}

	public void RemoveInhabitant(Human newInhabitant)
	{
	}

	public void RemoveOwner(Human newOwner)
	{
	}

	public void UpdateDesignStyle()
	{
	}

	public void SetName()
	{
	}

	public void SetName(string newName)
	{
	}

	public void SetAddressType(LayoutConfiguration newType)
	{
	}

	private void OnDestroy()
	{
	}

	public void OnDoorKnockByActor(NewDoor dc, float urgency, Actor byWho)
	{
	}

	public override void CreateEvidence()
	{
	}

	public override void SetupEvidence()
	{
	}

	public EvidenceMultiPage CreateCalendar()
	{
		return null;
	}

	public CitySaveData.AddressCitySave GenerateSaveData()
	{
		return null;
	}

	public void CreateSignageHorizontal()
	{
	}

	public void CreateSignageVertical()
	{
	}

	public void GenerateJobPathingData()
	{
	}

	public void CalculateRoomOwnership()
	{
	}

	public void SelectAirVentLocations()
	{
	}

	public void PickPassword()
	{
	}

	public void SetAlarm(bool newVal, Human target)
	{
	}

	public float GetAlarmTime()
	{
		return 0f;
	}

	public override bool IsAlarmSystemTarget(Human human)
	{
		return false;
	}

	public override bool IsAlarmActive(out float retAlarmTimer, out NewBuilding.AlarmTargetMode retTargetMode, out List<Human> retTargets)
	{
		retAlarmTimer = default(float);
		retTargetMode = default(NewBuilding.AlarmTargetMode);
		retTargets = null;
		return false;
	}

	public void AddSentryGun(Interactable newInteractable)
	{
	}

	public void AddOtherSecurity(Interactable newInteractable)
	{
	}

	public void SetBreakerSecurity(Interactable newObject)
	{
	}

	public void SetBreakerLights(Interactable newObject)
	{
	}

	public void SetBreakerDoors(Interactable newObject)
	{
	}

	public override bool IsOutside()
	{
		return false;
	}

	public Interactable GetBreakerSecurity()
	{
		return null;
	}

	public Interactable GetBreakerLights()
	{
		return null;
	}

	public Interactable GetBreakerDoors()
	{
		return null;
	}

	public NewNode GetDestinationNode()
	{
		return null;
	}

	private void OnDisable()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void IsThisOpen()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SetPlayerResidence()
	{
	}

	public void AddVandalism(Interactable interactable)
	{
	}

	public void AddVandalism(Vector3 window)
	{
	}

	public void AddVandalism(int fine)
	{
	}

	private void SideJobObjectiveCheck()
	{
	}

	public void RemoveVandalism(Interactable interactable)
	{
	}

	public void RemoveVandalism(Vector3 window)
	{
	}

	public int GetVandalismDamage(bool includeObjects = true, bool includeWindows = true, bool includeMisc = true)
	{
		return 0;
	}

	public override void AddOccupant(Actor newOcc)
	{
	}

	public override void RemoveOccupant(Actor remOcc)
	{
	}

	public string GetPassword()
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DecorateAsDen()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GetOpeningDays()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void UpdateCompanyOpenDays()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CloseBusiness()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void AddGuestPass()
	{
	}
}
