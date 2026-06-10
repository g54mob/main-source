using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Rendering;

public class NewBuilding : Controller
{
	public enum AlarmTargetMode
	{
		illegalActivities = 0,
		notPlayer = 1,
		nonResidents = 2,
		everybody = 3,
		nobody = 4
	}

	public class DuctPlacementData
	{
		public AirDuctGroup.AirVent originVent;

		public AirDuctGroup.AirVent destinationVent;

		public Vector3Int previous;

		public Vector3Int next;
	}

	[Serializable]
	public class SideSign
	{
		public int anchorPointIndex;

		public int signPrefabIndex;
	}

	public enum Direction
	{
		North = 0,
		East = 1,
		South = 2,
		West = 3
	}

	[CompilerGenerated]
	private sealed class _003CPayLostAndFoundReward_003Ed__130 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GameplayController.LostAndFound f;

		private float _003Ctimer_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CPayLostAndFoundReward_003Ed__130(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("ID")]
	public int buildingID;

	public static int assignID;

	public string seed;

	[Header("Custom Editor Flags")]
	public bool isPlayerEditedName;

	public string playerEditedBuildingName;

	[Header("Building Contents")]
	public Dictionary<int, NewFloor> floors;

	public List<NewAddress> lobbies;

	public List<GameObject> spawnedCables;

	public List<SideSign> sideSigns;

	public List<AirDuctGroup> airDucts;

	public Dictionary<Vector3Int, AirDuctGroup.AirDuctSection> ductMap;

	[Header("Alarms")]
	public List<Interactable> alarms;

	public List<Interactable> sentryGuns;

	public List<Interactable> otherSecurity;

	public bool alarmActive;

	public AlarmTargetMode targetMode;

	public float targetModeSetAt;

	public List<Human> alarmTargets;

	public float alarmTimer;

	public List<Interactable> securityCameras;

	public float wantedInBuilding;

	public List<AudioController.LoopingSoundInfo> alarmPALoops;

	public Dictionary<Vector2, Dictionary<NewRoom, List<NewRoom.CullTreeEntry>>> directionalCullingTrees;

	[Header("Exterior Data")]
	public MaterialGroupPreset extWallMaterial;

	public Material extMat;

	public Dictionary<Vector3Int, NewNode> validVentSpace;

	[Header("Culling: Mesh")]
	public GameObject buildingModelBase;

	public List<GameObject> buildingModelsActual;

	public List<GameObject> buildingModelsLights;

	public List<Collider> colliders;

	public Transform environmentalSettingsObject;

	public bool displayBuildingModel;

	public bool activeColliders;

	private List<GameObject> selectivelyHidden;

	public List<Collider> snowColliders;

	[Space(7f)]
	public GameObject cityEditorGroundFloorRepresentation;

	[Header("Culling: Lighting")]
	public int interiorLightCullingLayer;

	public List<LightController> allInteriorMainLights;

	[Header("Location")]
	public BuildingPreset preset;

	public int rotations;

	public Direction facing;

	public CityTile cityTile;

	public Vector3Int globalTileCoords;

	public bool isInaccessible;

	private float distance;

	public Vector3 worldPosition;

	[Header("Entrances")]
	public NewWall mainEntrance;

	public StreetController street;

	public List<NewWall> additionalEntrances;

	[Header("Stairwells")]
	public Dictionary<NewTile, Elevator> stairwells;

	[Header("Emission")]
	public Texture2D emissionTextureInstanced;

	public Texture2D emissionTextureUnlit;

	[Header("Environmental")]
	public Volume volume;

	[NonSerialized]
	[Header("Evidence")]
	public EvidenceBuilding evidenceEntry;

	[NonSerialized]
	public EvidenceMultiPage residentRoster;

	public List<TelephoneController.PhoneCall> callLog;

	[Header("Decor")]
	public DesignStylePreset designStyle;

	public Color wood;

	public MaterialGroupPreset floorMaterial;

	public Toolbox.MaterialKey floorMatKey;

	public MaterialGroupPreset ceilingMaterial;

	public Toolbox.MaterialKey ceilingMatKey;

	public MaterialGroupPreset defaultWallMaterial;

	public Toolbox.MaterialKey defaultWallKey;

	public ColourSchemePreset colourScheme;

	public NewAddress nameOverride;

	private Material weatherMaterial;

	[Header("Lost & Found")]
	public List<GameplayController.LostAndFound> lostAndFound;

	[Header("Debug")]
	public List<string> debugDecor;

	public static Comparison<NewBuilding> DistanceComparison;

	public void AddNewFloor(NewFloor newFloor)
	{
	}

	public void Setup(CityTile newGroundmap, BuildingPreset newpreset, bool setupExistingBuilding = false, int replaceBuildingID = 0)
	{
	}

	public void RemoveBuilding()
	{
	}

	public void Load(CitySaveData.BuildingCitySave data, CityTile newCityTile)
	{
	}

	private void SetupModel()
	{
	}

	public void DrawGroundFloorBuildingModel()
	{
	}

	private GameObject CombineGroundFloorMeshes(ref List<MeshFilter> childMeshes, string objectName)
	{
		return null;
	}

	private List<NewWall.FrontageSetting> SelectFrontage(RoomConfiguration roomConfig, DoorPairPreset wallPreset)
	{
		return null;
	}

	public void RemoveGroundFloorBuildingModel()
	{
	}

	private void SetupEmissionTexture()
	{
	}

	public void SetTargetMode(AlarmTargetMode newMode, bool setResetTimer = true)
	{
	}

	private void SetupEnvironment()
	{
	}

	public void UpdateColourSchemeAndMaterials()
	{
	}

	public void LoadInterior()
	{
	}

	public void AddBuildingEntrance(NewWall wallTile, bool isMain = false)
	{
	}

	public Vector2Int FaceLocalTileVector(Vector2Int r)
	{
		return default(Vector2Int);
	}

	public Vector2Int FaceLocalNodeVector(Vector2Int r)
	{
		return default(Vector2Int);
	}

	public Vector2 FaceWallOffsetVector(Vector2 r)
	{
		return default(Vector2);
	}

	public Vector2 GetOriginalWallOffset(Vector2 r)
	{
		return default(Vector2);
	}

	public Vector3 LocalToGlobalPathmap(Vector3 r)
	{
		return default(Vector3);
	}

	public void CalculateFacing()
	{
	}

	private void CalculateRotations()
	{
	}

	public void SetFacing(Direction face, bool updateBuildingModel = true)
	{
	}

	public Vector3 GetBuildingEuler()
	{
		return default(Vector3);
	}

	public void SetInaccessible()
	{
	}

	public override void SetupEvidence()
	{
	}

	public void AddLobby(NewAddress newLob)
	{
	}

	public void SetDisplayBuildingModel(bool vis, bool coll, List<string> hideModelChildOverride = null)
	{
	}

	public void SelectivelyHideModels(List<string> hideModelChildOverride)
	{
	}

	public void ResetSelectivelyHidden()
	{
	}

	public void SpawnStreetCables()
	{
	}

	public void SpawnNeonSideSigns()
	{
	}

	public void GenerateAirDucts()
	{
	}

	public Elevator AddStairwellSystem(NewTile newTile, StairwellPreset stairPreset)
	{
		return null;
	}

	public int CompareTo(NewBuilding otherObject)
	{
		return 0;
	}

	public CitySaveData.BuildingCitySave GenerateSaveData()
	{
		return null;
	}

	public void UpdateName(bool forceTrueRandom = false)
	{
	}

	public override void CreateEvidence()
	{
	}

	public void SetAlarm(bool newVal, Human target, NewFloor forFloor)
	{
	}

	public float GetAlarmTime()
	{
		return 0f;
	}

	public bool IsAlarmSystemTarget(Human human)
	{
		return false;
	}

	public void AddSecurityCamera(Interactable newInteractable)
	{
	}

	public void AddSentryGun(Interactable newInteractable)
	{
	}

	public void AddOtherSecurity(Interactable newInteractable)
	{
	}

	public void SetExteriorWallMaterialDefault(MaterialGroupPreset newMat)
	{
	}

	public List<Vector3Int> GetVentRoute(Vector3Int origin, Vector3Int destination, ref Dictionary<Vector3Int, DuctPlacementData> placedDucts)
	{
		return null;
	}

	public void CalculateDirectionalCullingTrees()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CountResidences()
	{
	}

	public void TriggerAlarmPASounds()
	{
	}

	public void UpdateAlarmPAWindowDistance(float val)
	{
	}

	public void UpdateAlarmPAExternalDoorDistance(float val)
	{
	}

	public void UpdateAlarmPAIntExt(float val)
	{
	}

	private List<AudioController.FMODParam> GetAlarmPAParams()
	{
		return null;
	}

	public void StopAlarmPASounds()
	{
	}

	public void TriggerNewLostAndFound()
	{
	}

	public void CompleteLostAndFound(Citizen owner, InteractablePreset itemType, bool giveReward = true)
	{
	}

	[IteratorStateMachine(typeof(_003CPayLostAndFoundReward_003Ed__130))]
	private IEnumerator PayLostAndFoundReward(GameplayController.LostAndFound f)
	{
		return null;
	}

	private void OnDestroy()
	{
	}
}
