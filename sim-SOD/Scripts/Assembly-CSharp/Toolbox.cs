using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Toolbox : MonoBehaviour
{
	[Serializable]
	public class MaterialKey
	{
		public Material baseMaterial;

		public Color mainColour;

		public Color colour1;

		public Color colour2;

		public Color colour3;

		public float grubiness;

		public bool Equals(MaterialKey other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		private bool Approximately(Color colour1, Color colour2)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(MaterialKey c1, MaterialKey c2)
		{
			return false;
		}

		public static bool operator !=(MaterialKey c1, MaterialKey c2)
		{
			return false;
		}
	}

	public struct SpecialItemPlacement
	{
		public string reference;

		public InteractablePreset preset;

		public Human belongsTo;

		public object passedObject;
	}

	public enum LayerMaskMode
	{
		castAllExcept = 0,
		onlyCast = 1
	}

	[CompilerGenerated]
	private sealed class _003CExeEndOfFrame_003Ed__112 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Toolbox _003C_003E4__this;

		private bool _003Cwait_003E5__2;

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
		public _003CExeEndOfFrame_003Ed__112(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CSpawnTelephoneEntryWindow_003Ed__205 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Evidence ev;

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
		public _003CSpawnTelephoneEntryWindow_003Ed__205(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CExecuteScrollScrollRectOLD_003Ed__211 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CustomScrollRect scrollRect;

		public Vector3 targetPos;

		public bool allowHorizontal;

		public float extraScrollThreshold;

		public bool allowVertical;

		public float timeTaken;

		private float _003Cprogress_003E5__2;

		private Vector2 _003CnewPos_003E5__3;

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
		public _003CExecuteScrollScrollRectOLD_003Ed__211(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CLerpScrollRect_003Ed__213 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float timeTaken;

		public CustomScrollRect scrollRect;

		public Vector2 anchoredPos;

		private float _003Cprogress_003E5__2;

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
		public _003CLerpScrollRect_003Ed__213(int _003C_003E1__state)
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

	private bool endOfFrameInvoke;

	private HashSet<Action> invokeEndOfFrame;

	private List<string> debugInvokeEndOfFrame;

	public Censor censor;

	public List<Human.ShoeType> allShoeTypes;

	public List<Evidence.DataKey> allDataKeys;

	public List<Descriptors.EthnicGroup> allEthnicities;

	public List<DDSSaveClasses.TreeTriggers> allTreeTriggers;

	public List<Acquaintance.ConnectionType> allConnectionTypes;

	public List<CompanyPreset.CompanyCategory> allCompanyCategories;

	public List<ClothesPreset.OutfitCategory> allOutfitCategories;

	public List<CitizenOutfitController.CharacterAnchor> allCharacterAnchors;

	public List<ArtPreset> allArt;

	public List<OccupationPreset> allCriminalJobs;

	public List<StreetTilePreset> allStreetTiles;

	public List<SyncDiskPreset> allSyncDisks;

	public List<JobPreset> allSideJobs;

	public List<DistrictPreset> allDistricts;

	public List<HandwritingPreset> allHandwriting;

	public List<InteractablePreset> allBasBouleCards;

	public List<BookPreset> allBooks;

	public Dictionary<string, EvidencePreset> evidencePresetDictionary;

	public Dictionary<string, FactPreset> factPresetDictionary;

	public Dictionary<string, GroupPreset> groupsDictionary;

	public Dictionary<string, DDSScope> scopeDictionary;

	public Dictionary<string, DDSScope> globalScopeDictionary;

	public Dictionary<string, InteractablePreset> objectPresetDictionary;

	public List<InteractablePreset> placeAtGameLocationInteractables;

	public List<InteractablePreset> placePerOwnerInteractables;

	public Dictionary<SubObjectClassPreset, List<InteractablePreset>> subObjectsDictionary;

	public Dictionary<string, AudioEvent> voiceActedDictionary;

	public List<CharacterTrait> allCharacterTraits;

	public List<CharacterTrait> stage0Traits;

	public List<CharacterTrait> stage1Traits;

	public List<CharacterTrait> stage2Traits;

	public List<CharacterTrait> stage3Traits;

	public List<CharacterTrait> reasons;

	public List<AddressPreset> allAddressPresets;

	public List<DesignStylePreset> allDesignStyles;

	public List<MaterialGroupPreset> allMaterialGroups;

	public Dictionary<DesignStylePreset, List<FurniturePreset>> furnitureDesignStyleRef;

	public Dictionary<RoomClassPreset, HashSet<FurniturePreset>> furnitureRoomTypeRef;

	public Dictionary<DesignStylePreset, Dictionary<MaterialGroupPreset.MaterialType, List<MaterialGroupPreset>>> materialDesignStyleRef;

	public Dictionary<DesignStylePreset, Dictionary<WallFrontageClass, List<WallFrontagePreset>>> wallFrontageStyleRef;

	public List<FurnitureCluster> allFurnitureClusters;

	public List<FurniturePreset> allFurniture;

	public List<AIGoalPreset> allGoals;

	public List<DialogPreset> allDialog;

	public List<DialogPreset> defaultDialogOptions;

	public List<InteractablePreset> allWeapons;

	public Dictionary<string, DDSSaveClasses.DDSBlockSave> allDDSBlocks;

	public Dictionary<string, DDSSaveClasses.DDSMessageSave> allDDSMessages;

	public Dictionary<string, DDSSaveClasses.DDSTreeSave> allDDSTrees;

	public List<DDSSaveClasses.DDSTreeSave> allArticleTrees;

	public Dictionary<DDSSaveClasses.DDSMessageSettings, DialogPreset> constructedDialogPresets;

	public Dictionary<string, HelpContentPage> allHelpContent;

	public List<ClothesPreset> allClothes;

	public Dictionary<string, ClothesPreset> clothesDictionary;

	public List<StatusPreset> allStatuses;

	public int aiSightingLayerMask;

	public int interactionRayLayerMask;

	public int interactionRayLayerMaskNoRoomMesh;

	public int printDetectionRayLayerMask;

	public int sceneCaptureLayerMask;

	public int mugShotCaptureLayerMask;

	public int physicalObjectsLayerMask;

	public int playerMovementLayerMask;

	public int autoTravelMovementLayerMask;

	public int heldObjectsObjectsLayerMask;

	public int spatterLayerMask;

	public int textToImageMask;

	public int lightCullingMask;

	public int sniperLOSMask;

	private List<Descriptors.EthnicGroup> rEthnicity;

	public char[] alphabet;

	public Dictionary<Type, Dictionary<string, ScriptableObject>> resourcesCache;

	public Dictionary<Material, MaterialGroupPreset> materialProperties;

	public Dictionary<Mesh, FurniturePreset> furnitureMeshReference;

	public string lastRandomNumberKey;

	private char[] seedLetters;

	private char[] seedNumbers;

	[Header("Debug")]
	public Vector2 debugTimeRange1;

	public Vector2 debugTimeRange2;

	private static Toolbox _instance;

	public static GameObject PoolingGroup { get; private set; }

	public static Toolbox Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void LoadDDS()
	{
	}

	public void LoadModdedDDSFiles()
	{
	}

	public void LoadDDSFilesFromPath(string path)
	{
	}

	public void ProcessLoadedScriptableObject(ScriptableObject so)
	{
	}

	private void LoadAll()
	{
	}

	public bool TryReplaceInResourcesCache(ScriptableObject so)
	{
		return false;
	}

	public float RoundToPlaces(float input, int decimals)
	{
		return 0f;
	}

	public string AddZeros(float num, int decimals)
	{
		return null;
	}

	public float RoundToPlaces(double input, int decimals)
	{
		return 0f;
	}

	public float TravelTimeEstimate(Human cc, NewNode origin, NewNode destination)
	{
		return 0f;
	}

	public void AddToTravelTimeRecords(Actor cc, float discrepency)
	{
	}

	public int TravelTimeEstimateMinutes(Citizen cc, NewNode origin, NewNode destination)
	{
		return 0;
	}

	public float RandomRangeWeighted(float minimum, float maximum, float weightedValue, int stepResolution = 5)
	{
		return 0f;
	}

	public float RandomRangeWeightedSeedContained(float minimum, float maximum, float weightedValue, ref string inputSeed, int stepResolution = 5)
	{
		return 0f;
	}

	public float MinDistanceFromPath(NewNode pathOrigin, NewNode pathDestination, Vector3 inputPosition)
	{
		return 0f;
	}

	public Rect RectTransformToScreenSpace(RectTransform transform)
	{
		return default(Rect);
	}

	public void InvokeEndOfFrame(Action action, string newDebug)
	{
	}

	[IteratorStateMachine(typeof(_003CExeEndOfFrame_003Ed__112))]
	private IEnumerator ExeEndOfFrame()
	{
		return null;
	}

	public void UpdateButtonListPositions(List<ButtonController> buttons, float edgeMargin = 5f, float iconMargin = 4f)
	{
	}

	public bool GameTimeRangeOverlap(Vector2 range1, Vector2 range2, bool equalsIsOverlapping = true)
	{
		return false;
	}

	public bool DecimalTimeRangeOverlap(Vector2 range1, Vector2 range2, bool equalsIsOverlapping = true)
	{
		return false;
	}

	public Vector2 RotateVector2ACW(Vector2 v, float degrees)
	{
		return default(Vector2);
	}

	public Vector2 RotateVector2CW(Vector2 v, float degrees)
	{
		return default(Vector2);
	}

	public Descriptors.EthnicGroup RandomEthnicGroup(ref string seed)
	{
		return default(Descriptors.EthnicGroup);
	}

	public Color GetRenderTexturePixel(RenderTexture rt)
	{
		return default(Color);
	}

	public void SetLightLayer(GameObject objectWithMesh, NewBuilding building, bool includeStreetLighting = false)
	{
	}

	public void SetLightLayer(MeshRenderer meshRend, NewBuilding building, bool includeStreetLighting = false)
	{
	}

	public bool LoadDataFromResources<T>(string searchName, out T output) where T : ScriptableObject
	{
		output = null;
		return false;
	}

	public List<T> GetList<T>(params T[] elements)
	{
		return null;
	}

	public float HeuristicCostEstimate(NewNode start, NewNode goal)
	{
		return 0f;
	}

	public List<NewNode> ConstructPathAccurate(Dictionary<NewNode, NewNode> cameFrom, NewNode current)
	{
		return null;
	}

	public Evidence GetOrCreateEvidenceForInteractable(InteractablePreset preset, string newID, Interactable interactable, Human belongsTo, Human writer, Human reciever, SideJob jobParent, NewGameLocation gameLocation, RetailItemPreset retailItem, List<Interactable.Passed> passedVars)
	{
		return null;
	}

	public bool TryGetEvidence(string evID, out Evidence evidence)
	{
		evidence = null;
		return false;
	}

	public Interactable SpawnSpareKey(NewAddress ad, string loadGUID = null)
	{
		return null;
	}

	public float GetAngleForOffset(Vector2 offset1)
	{
		return 0f;
	}

	public Vector2 GetOffsetFromAngle(int angle)
	{
		return default(Vector2);
	}

	public float GetAngleBetween(Vector3 origin, Vector3 lookAt)
	{
		return 0f;
	}

	private Vector3 GetAveragePosition(List<NewNode> nodes)
	{
		return default(Vector3);
	}

	public bool IsWorkDay(int day, Citizen cit)
	{
		return false;
	}

	public Interactable FindNearestWithAction(AIActionPreset action, NewRoom startRoom, Human person, AIActionPreset.FindSetting findSetting, bool overrideWithHome = true, HashSet<NewRoom> ignore = null, NewGameLocation restrictTo = null, NewBuilding restrictToBuilding = null, bool useSpecialCasesOnly = false, InteractablePreset.SpecialCase mustBeSpecial = InteractablePreset.SpecialCase.none, bool filterWithRoomType = false, List<RoomTypePreset> roomTypeFilter = null, bool preferUnused = true, bool enforcersAllowedEverywhere = false, float robberyPriority = 0f, List<Interactable> avoidInteractables = null, List<InteractablePreset> shopItems = null, bool printDebug = false, bool mustContainDesireCategory = false, CompanyPreset.CompanyCategory containDesireCategory = CompanyPreset.CompanyCategory.meal, bool excludeAIUsingThis = false, bool useToiletSettings = false)
	{
		return null;
	}

	public Company FindNearestThatSells(InteractablePreset sellsItem, NewGameLocation startLocation, bool checkOpen = true)
	{
		return null;
	}

	public string GetNumbericalStringReference(int number)
	{
		return null;
	}

	public Vector2 Rotate(Vector2 aPoint, float aDegree)
	{
		return default(Vector2);
	}

	public List<Vector2> PlotLine(Vector2 point1, Vector2 point2)
	{
		return null;
	}

	public Quaternion ClampRotation(Quaternion q, float minimumUpDown, float maximumUpDown, float minimumLeftRight, float maximumLeftRight)
	{
		return default(Quaternion);
	}

	public float ClampAngle(float angle, float min, float max)
	{
		return 0f;
	}

	public void ShuffleList(ref List<CharacterTrait> list)
	{
	}

	public void ShuffleListSeedContained(ref List<CharacterTrait> list, string input, out string output)
	{
		output = null;
	}

	public void ShuffleList(ref List<Human.WalletItem> list)
	{
	}

	public GameObject SpawnObject(GameObject newObj, Transform newParent)
	{
		return null;
	}

	public GameObject SpawnObject(GameObject newObj, Vector3 newPos, Quaternion newRot, Transform newParent)
	{
		return null;
	}

	public void DestroyObject(GameObject newObj)
	{
	}

	public Material SpawnMaterial(Material newObj)
	{
		return null;
	}

	public Vector3 GetLocalEulerAtRotation(Transform transform, Quaternion targetRotation)
	{
		return default(Vector3);
	}

	public List<int> GetKeyCodeFromString(string str)
	{
		return null;
	}

	public string GenerateEvidenceIdentifier(Evidence ev)
	{
		return null;
	}

	public string GenerateUniqueID()
	{
		return null;
	}

	public Interactable FindClosestObjectTo(InteractablePreset objectType, Vector3 closestTo, NewBuilding constrainToBuilding, NewGameLocation constrainToLocation, NewRoom constrainToRoom, out float distance, bool publicOnly = false)
	{
		distance = default(float);
		return null;
	}

	public FurnitureLocation FindFurnitureWithinGameLocation(NewGameLocation location, FurnitureClass furnitureClass, out NewRoom room)
	{
		room = null;
		return null;
	}

	public void SetRectSize(RectTransform trs, float left, float top, float right, float bottom)
	{
	}

	public Rect GetWorldRect(RectTransform rt, Vector2 scale)
	{
		return default(Rect);
	}

	public int CreateLayerMask(LayerMaskMode castMode, params int[] aLayers)
	{
		return 0;
	}

	public NewNode FindClosestValidNodeToWorldPosition(Vector3 worldPos, bool onlyAccessibleNodes = false, bool checkUpAndDown = true, bool limitToDirection = false, Vector3Int limitedDirection = default(Vector3Int), bool limitToFloor = false, int limitedToFloor = 0, bool outsideOnly = false, int safety = 200)
	{
		return null;
	}

	public MaterialGroupPreset GetMaterialProperties(Material mat)
	{
		return null;
	}

	public FurniturePreset GetFurnitureFromMesh(Mesh mesh)
	{
		return null;
	}

	public FurniturePreset GetFurnitureFromGameObject(NewNode currentNode, GameObject gameObj)
	{
		return null;
	}

	public InteractablePreset GetInteractablePreset(string interactableName)
	{
		return null;
	}

	public Quaternion TransformRotation(Quaternion worldRotation, Transform targetsLocal)
	{
		return default(Quaternion);
	}

	public Quaternion InverseTransformRotation(Quaternion localRotation, Transform target)
	{
		return default(Quaternion);
	}

	public void Shoot(Actor fromThis, Vector3 muzzlePoint, Vector3 aimPoint, float aimRange, float accuracy, float damage, MurderWeaponPreset weapon, bool ejectBrass, Vector3 ejectBrassPoint, bool forcePhysicsEjectBrass, bool firstShot = true)
	{
	}

	public void CreateBulletSurfaceContactFX(MurderWeaponPreset weapon, RaycastHit hit)
	{
	}

	public float GetPsuedoRandomNumber(float lowerRange, float upperRange, ref string seedInput, bool updateLastKey = false, bool addCitySeed = false)
	{
		return 0f;
	}

	public int GetPsuedoRandomNumber(int lowerRange, int upperRange, ref string seedInput, bool updateLastKey = false, bool addCitySeed = false)
	{
		return 0;
	}

	public float GetPsuedoRandomNumber(float lowerRange, float upperRange, ref int seedInput, bool updateLastKey = false, bool addCitySeed = false)
	{
		return 0f;
	}

	public int GetPsuedoRandomNumber(int lowerRange, int upperRange, ref int seedInput, bool updateLastKey = false, bool addCitySeed = false)
	{
		return 0;
	}

	public float Rand(float min, float max, bool definitelyNotPartOfCityGeneration = false)
	{
		return 0f;
	}

	public int Rand(int min, int max, bool definitelyNotPartOfCityGeneration = false)
	{
		return 0;
	}

	public float SeedRand(float min, float max)
	{
		return 0f;
	}

	public int SeedRand(int min, int max)
	{
		return 0;
	}

	public float VectorToRandom(Vector2 vec)
	{
		return 0f;
	}

	public float VectorToRandomSeedContained(Vector2 vec, ref string seedInput)
	{
		return 0f;
	}

	public float RandContained(float min, float max, ref string seedInput)
	{
		return 0f;
	}

	public int RandContained(int min, int max, ref string seedInput)
	{
		return 0;
	}

	public float GetPsuedoRandomNumberContained(float lowerRange, float upperRange, ref string seedInput)
	{
		return 0f;
	}

	public int GetPsuedoRandomNumberContained(int lowerRange, int upperRange, ref string seedInput)
	{
		return 0;
	}

	public bool DDSTraitConditionLogicAcquaintance(Human thisPerson, Acquaintance acquaintance, DDSSaveClasses.TraitConditionType logic, ref List<string> traitList)
	{
		return false;
	}

	public bool DDSTraitConditionLogic(Human thisPerson, Human otherPerson, DDSSaveClasses.TraitConditionType logic, ref List<string> traitList)
	{
		return false;
	}

	public void LoadInteractableToWorld()
	{
	}

	public string ToBase26(int myNumber)
	{
		return null;
	}

	public string GenerateSeed(int digits = 16, bool useSeed = false, string newSeed = "")
	{
		return null;
	}

	public bool RaycastCheck(Transform from, Transform to, float maxRange, out RaycastHit hit)
	{
		hit = default(RaycastHit);
		return false;
	}

	public bool RaycastCheck(Vector3 from, Transform to, float maxRange, out RaycastHit hit)
	{
		hit = default(RaycastHit);
		return false;
	}

	public bool RaycastCheck(Vector3 from, Collider to, float maxRange, out RaycastHit hit)
	{
		hit = default(RaycastHit);
		return false;
	}

	public void SetPivot(RectTransform rectTransform, Vector2 pivot)
	{
	}

	public void SetAnchor(RectTransform rectTransform, Vector2 anchorMin, Vector2 anchorMax)
	{
	}

	public Transform[] GetAllTransforms(Transform t)
	{
		return null;
	}

	public Transform SearchForTransform(Transform parent, string search, bool printDebug = false)
	{
		return null;
	}

	public List<Transform> GetTagsWithinTransform(Transform parent, string tag)
	{
		return null;
	}

	public void NewVmailThread(Human from, List<Human> otherParticipiants, string treeID, float timeStamp, int progress = 999, StateSaveData.CustomDataSource overrideDataSource = StateSaveData.CustomDataSource.sender, int newDataSourceID = -1)
	{
	}

	public StateSaveData.MessageThreadSave NewVmailThread(Human from, Human to1, Human to2, Human to3, List<Human> cc, string treeID, float timeStamp, int progress = 999, StateSaveData.CustomDataSource overrideDataSource = StateSaveData.CustomDataSource.sender, int newDataSourceID = -1)
	{
		return null;
	}

	public List<Human.DDSRank> GetMessageTreeLinkRankings(StateSaveData.MessageThreadSave thread, DDSSaveClasses.DDSMessageSettings thisMsg)
	{
		return null;
	}

	public void ProgressVmailThread(StateSaveData.MessageThreadSave thread, int addProgress)
	{
	}

	public bool GetVmailParticipant(Human initiator, DDSSaveClasses.DDSParticipant participant, List<Human> banned, out Human chosen)
	{
		chosen = null;
		return false;
	}

	public MaterialGroupPreset SelectMaterial(RoomClassPreset roomType, float wealthLevel, DesignStylePreset designStyle, MaterialGroupPreset.MaterialType materialType, ref string seedInput)
	{
		return null;
	}

	public WallFrontagePreset SelectWallFrontage(DesignStylePreset designStyle, WallFrontageClass frontageClass, string seed)
	{
		return null;
	}

	public float GetNormalizedLandValue(NewGameLocation location, bool print = false)
	{
		return 0f;
	}

	public float GetNormalizedLandValue(NewBuilding location)
	{
		return 0f;
	}

	public List<Human> GetFingerprintOwnerPool(NewRoom room, FurnitureLocation furn, Interactable inter, RoomConfiguration.PrintsSource source, Vector3 worldPos, bool forceFind)
	{
		return null;
	}

	public void SpawnWindowAfterSeconds(Evidence ev, float after)
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnTelephoneEntryWindow_003Ed__205))]
	private IEnumerator SpawnTelephoneEntryWindow(Evidence ev, float after)
	{
		return null;
	}

	public CityInfoData GenerateCityInfoFile(FileInfo citySave)
	{
		return null;
	}

	public string GetTelephoneNumberString(int number)
	{
		return null;
	}

	public int GetLockpicksNeeded(float lockStrength)
	{
		return 0;
	}

	public Vector2 CreateTimeRange(float actualTime, float accuracyMargin, bool limitToNow, bool round, int roundToMinutes)
	{
		return default(Vector2);
	}

	public void ScrollScrollRectOLD(CustomScrollRect scrollRect, Vector3 targetPos, bool allowHorizontal, bool allowVertical, float timeTaken = 0.2f, float extraScrollThreshold = 0.2f)
	{
	}

	[IteratorStateMachine(typeof(_003CExecuteScrollScrollRectOLD_003Ed__211))]
	private IEnumerator ExecuteScrollScrollRectOLD(CustomScrollRect scrollRect, Vector3 targetPos, bool allowHorizontal, bool allowVertical, float timeTaken = 0.2f, float extraScrollThreshold = 0.2f)
	{
		return null;
	}

	public void ScrollRectPosition(CustomScrollRect scrollRect, RectTransform target, bool allowHorizontal, bool allowVertical, float timeTaken = 0.2f)
	{
	}

	[IteratorStateMachine(typeof(_003CLerpScrollRect_003Ed__213))]
	private IEnumerator LerpScrollRect(CustomScrollRect scrollRect, Vector2 anchoredPos, float timeTaken = 0.2f)
	{
		return null;
	}

	public NewNode PickNearbyNode(NewNode toThis)
	{
		return null;
	}

	public NewNode GetDoorSideNode(NewNode currentNode, NewDoor door)
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TestTimeRangeOverlap()
	{
	}

	public void AutomaticNavigationSetup(ref List<Button> selectables, float differenceBuffer = 2f)
	{
	}

	public void AddNavigationInput(Selectable selectable, Selectable newLeft = null, Selectable newRight = null, Selectable newUp = null, Selectable newDown = null, bool clearOld = false)
	{
	}

	public static void SetTextureImporterFormat(Texture2D texture, bool isReadable)
	{
	}

	public bool GetRelocateAuthority(Actor actor, Interactable obj)
	{
		return false;
	}

	public NewNode GetNearestGroundLevelOutside(Vector3 pos)
	{
		return null;
	}

	public void HandleLaserBehaviour(SecuritySystem secSystem, GameObject laser, Light laserLight, float maxRange = 16f)
	{
	}

	public Interactable GetLocalizedSnapshot(Interactable obj)
	{
		return null;
	}

	public void RetroactiveSurveillanceAddition(Human who, NewNode routeFrom, NewNode routeTo, bool addReturnJourney, NewNode returnTo, float arrivalTime, float stayTime, ClothesPreset.OutfitCategory outfit)
	{
	}

	public void ExplodeGrenade(Interactable grenade)
	{
	}

	public Dictionary<NewNode, float> GetNodeCoverageFromRadius(Interactable grenade, float radius, out Dictionary<Human, float> humanOutput)
	{
		humanOutput = null;
		return null;
	}

	public bool RankRoomShadiness(NewRoom room, out float score)
	{
		score = default(float);
		return false;
	}

	public bool RankNodeShadiness(NewNode node, out float score)
	{
		score = default(float);
		return false;
	}

	public void TriggerBriefcaseBomb(Interactable briefcase, Human actor)
	{
	}

	public Interactable GetMailbox(Human forHuman)
	{
		return null;
	}

	public bool IsStoryMissionActive(out Chapter script, out int chapter)
	{
		script = null;
		chapter = default(int);
		return false;
	}

	public string GetShareCode(ref CitySaveData cityData)
	{
		return null;
	}

	public string GetShareCode(string cityName, int citySizeX, int citySizeY, string version, string seed)
	{
		return null;
	}

	public void ParseShareCode(string input, out string cityName, out int citySizeX, out int citySizeY, out string version, out string seed)
	{
		cityName = null;
		citySizeX = default(int);
		citySizeY = default(int);
		version = null;
		seed = null;
	}

	public int VersionToNumbers(string version)
	{
		return 0;
	}

	public string NumbersToVersion(int numbers)
	{
		return null;
	}

	public Vector2 GetCitySizeFromValue(int val)
	{
		return default(Vector2);
	}

	public Vector3 ToVector3(Vector3Int input)
	{
		return default(Vector3);
	}

	public Vector3 ToVector3(int3 input)
	{
		return default(Vector3);
	}

	public float3 ToFloat3(Vector3Int input)
	{
		return default(float3);
	}

	public int3 ToInt3(Vector3Int input)
	{
		return default(int3);
	}

	public Vector3Int toVector3Int(int3 input)
	{
		return default(Vector3Int);
	}

	public Vector2 ToVector2(Vector2Int input)
	{
		return default(Vector2);
	}

	public GameplayController.HotelGuest GetHotelRoom(Human person)
	{
		return null;
	}

	public FileInfo GetCityFile(string code, out string codeVersion, out string codeSeed)
	{
		codeVersion = null;
		codeSeed = null;
		return null;
	}

	public FileInfo GetCityFile(string codeName, string codeSeed, int codeSizeX, int codeSizeY, string codeVersion)
	{
		return null;
	}

	public bool IsConsoleBuild()
	{
		return false;
	}

	public string CensorText(string inputText)
	{
		return null;
	}

	public bool TryGetSniperVantagePoint(Human sniper, NewGameLocation requiredTargetSite, out NewWall vantagePoint, out float vantageScore, List<NewNode.NodeAccess> accessCheckList = null)
	{
		vantagePoint = null;
		vantageScore = default(float);
		return false;
	}

	private bool ScanBuildingForSniperVantagePoints(Human sniper, NewBuilding building, NewGameLocation requiredTargetSite, out NewWall vantagePoint, out float vantageScore, ref List<NewNode.NodeAccess> accessCheckList)
	{
		vantagePoint = null;
		vantageScore = default(float);
		return false;
	}

	public bool TryGetSniperVantagePoint(NewGameLocation vantageLocation, out NewWall vantagePoint, out float vantageScore, out List<NewGameLocation> possibleTargetSites, NewGameLocation requiredTargetSite = null)
	{
		vantagePoint = null;
		vantageScore = default(float);
		possibleTargetSites = null;
		return false;
	}

	public bool TryGetSniperVantagePoint(NewRoom vantageRoom, out NewWall vantagePoint, out float vantageScore, out List<NewGameLocation> possibleTargetSites, NewGameLocation requiredTargetSite = null)
	{
		vantagePoint = null;
		vantageScore = default(float);
		possibleTargetSites = null;
		return false;
	}

	private NewBuilding GetFacingBuildingFromWindow(NewNode.NodeAccess windowAccess, out Vector3 windowDir)
	{
		windowDir = default(Vector3);
		return null;
	}

	public Telephone GetClosestTelephone(Actor toActor, float maxDistance = 18f, bool prioritiseSameLocation = true, bool payPhonesOnly = false, bool mustHaveValidAccess = true)
	{
		return null;
	}

	public SceneRecorder.SceneCapture GetSceneCaptureFromID(int captureID)
	{
		return null;
	}

	public int GetNearestFactorOf(int inputValue, int factor = 4)
	{
		return 0;
	}

	public int AddDigits(int n1, int n2)
	{
		return 0;
	}

	public bool CheckForLatin(string stringToCheck)
	{
		return false;
	}

	public bool ColorsAreClose(Color a, Color z, float threshold)
	{
		return false;
	}

	public DialogPreset ConstructDialogPresetFromDDSMessage(DDSSaveClasses.DDSTreeSave tree, DDSSaveClasses.DDSMessageSettings msgInstance, DDSSaveClasses.DDSMessageSave msg)
	{
		return null;
	}

	public InteractablePreset PickItemFromDDSStringPool(DDSSaveClasses.DDSTreeSave tree)
	{
		return null;
	}
}
