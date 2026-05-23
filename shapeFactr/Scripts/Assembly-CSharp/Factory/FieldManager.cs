using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using DG.Tweening;
using Factory.FieldData;
using Factory.FieldObject;
using Factory.Mech;
using Libs;
using Models;
using ScriptableObjects.ScriptableObjectScripts.ExtendData;
using ScriptableObjects.ScriptableObjectScripts.Tile;
using UnityEngine;
using UnityEngine.Serialization;

namespace Factory
{
	[RequireComponent(typeof(Grid))]
	public class FieldManager : SingletonMonoBehaviour<FieldManager>
	{
		public class FactoryRegulation
		{
			public enum eMode
			{
				None = 0,
				GridRot = 1,
				Bridge = 2,
				Mask = 3,
				CameraMove = 4,
				CameraZoom = 5,
				ArriveMechDrawStream = 6,
				RepairBelt = 7,
				CheckJamIcon = 8,
				Keep = 9
			}

			public enum Clockwise
			{
				Clockwise = 0,
				Anticlockwise = 1
			}

			public record ConnectPair(Vector2Int FromAddr, Vector2Int ToAddr, Clockwise Clockwise, float Degree)
			{
				[CompilerGenerated]
				protected virtual Type EqualityContract
				{
					[CompilerGenerated]
					get
					{
						return null;
					}
				}

				public Vector2Int FromAddr { get; set; }

				public Vector2Int ToAddr { get; set; }

				public Clockwise Clockwise { get; set; }

				public float Degree { get; set; }

				[CompilerGenerated]
				public override string ToString()
				{
					return null;
				}

				[CompilerGenerated]
				protected virtual bool PrintMembers(StringBuilder builder)
				{
					return false;
				}

				[CompilerGenerated]
				public virtual bool Equals(ConnectPair? other)
				{
					return false;
				}

				[CompilerGenerated]
				protected ConnectPair(ConnectPair original)
				{
				}

				[CompilerGenerated]
				public void Deconstruct(out Vector2Int FromAddr, out Vector2Int ToAddr, out Clockwise Clockwise, out float Degree)
				{
					FromAddr = default(Vector2Int);
					ToAddr = default(Vector2Int);
					Clockwise = default(Clockwise);
					Degree = default(float);
				}
			}

			private static int idcounter;

			public readonly int id;

			public readonly eMode Mode;

			public eMachine MachineID;

			public eLuggage LuggageID;

			public Dir.Rot? Rot;

			public Vector2Int Addr;

			public RectInt GridRect;

			public RectInt AddrRect;

			public RectInt GridRect2;

			public RectInt AddrRect2;

			public RectInt GridRect3;

			public RectInt AddrRect3;

			public ExtMachineData extMachineData;

			public Vector2Int size;

			public string GuideTileName;

			public string GuideTileName2;

			public int ConnectBeltNum;

			public Vector2Int MechAddr;

			public ePrimaryMachineCategory primaryCategory;

			public Vector3 CameraPos;

			public float OrthographicSize;

			public float FieldOfView;

			public float CameraMoveTotal;

			public Vector2IntBundle AddrBundle;

			public Vector2IntBundle GridBundle;

			public List<ConnectPair> ConnectPairs;

			public List<bool> partialClear;

			public eTutorialId TutorialId;

			private int _fulfillCounter;

			public int DrawLength;

			public List<TileDetail> TileDetails;

			private readonly string _initString;

			public int? tutorialOrderBackup;

			public Vector2Int DrawGridTail => default(Vector2Int);

			public FactoryRegulation(eMode mode, string initString)
			{
			}

			public override string ToString()
			{
				return null;
			}

			public string ToDump()
			{
				return null;
			}

			public void AddFulfill()
			{
			}

			public bool CheckCondition()
			{
				return false;
			}

			public void SetGuideTile(bool arrowOrderChange = false)
			{
			}

			public void SetGuideTileBundle()
			{
			}

			public void SetMaskTile()
			{
			}

			public void SetGuideDragTile()
			{
			}

			public void HollowOutTile(RectInt gridRect)
			{
			}
		}

		public class CheckParamModeResult
		{
			public readonly FactoryRegulation.eMode mode;

			public List<Vector2Int> v2iList;

			public eMachine machineId;

			public Dir.Rot? rot;

			public eLuggage luggageId;

			public ePrimaryMachineCategory arriveMechPrimaryCategory;

			public Vector2Int arriveMechAddr;

			public eTutorialId tutorialId;

			public FactoryRegulation.Clockwise Clockwise;

			public float Degree;

			public CheckParamModeResult(FactoryRegulation.eMode mode)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class PreviewStructureResult
		{
			public TileDetailPack TileDetailPack;

			public bool SetOk;

			public bool SoldOut;

			public Vector2IntBundle PreviewGrid;

			public int LineDifference;

			public bool BeltRouteTurnoutOnly;

			public bool PipeRouteTurnoutOnly;

			public eErrorId? ReservedError;

			public bool NeedRouteGuide;

			public List<MechBase.TileAppendsContainer> previousTileAppendsContainers;

			public bool IsProhibitRemoveMachine;

			public eMachine prevMachineId;

			public bool prevRelocatable;

			public bool prevSettingMenu;

			public bool prevUpgradable;
		}

		public GameObject luggagePrefab;

		public BillboardTextEffectCtrl labPointUp;

		public float labPointUpDuration;

		public Ease labPointUpEase;

		public GoalEffectCtrl goalEffect;

		public GoalEffectCtrl goalEffectLow;

		public float goalEffectDuration;

		[FormerlySerializedAs("goalEffectEase")]
		public Ease goalEffectMoveEase;

		public Ease goalEffectScaleEase;

		public GameObject Ef_SweetsSupply_give;

		public GameObject Ef_SweetsSupply_get;

		public GameObject[] Ef_InkSprinklers;

		public GameObject[] Ef_InkCatchers;

		[Header("主にデバッグ用、現状のマップ")]
		[SerializeField]
		public MapData mapData;

		public string lastLoadMapFileName;

		private FactoryMap _factoryMap;

		public static FactoryContext Fc;

		public static string defaultLoadMapForEditor;

		public static bool useDefaultMapForEditor;

		public bool isOnWorkSound;

		public static readonly RectInt FieldGridRect;

		public static List<FactoryRegulation> TutorialFactoryRegulation;

		private eMachine prevSetStructure;

		public FixedQueue<string> CursorModeLog;

		private double? profileStartTime;

		public bool IsPause => false;

		public static RectInt FieldAddrRect => default(RectInt);

		public static List<RectInt> FieldPlayGridRect { get; private set; }

		public static List<RectInt> FieldPlayAddrRect { get; private set; }

		[Conditional("UNITY_EDITOR")]
		public static void LoadAndRestartMapForEditor(string path)
		{
		}

		public static void UpdateFieldPlayArea(eMapExtension area, bool init = false)
		{
		}

		public static void UpdateFieldPlayArea(RectInt playArea, bool init = false)
		{
		}

		public static bool AppendMap(eMapExtension area)
		{
			return false;
		}

		public static bool CheckExtendArea(eMapExtension area)
		{
			return false;
		}

		public static bool CheckFullOpenMap()
		{
			return false;
		}

		public static bool IsPlayArea(eMapExtension area)
		{
			return false;
		}

		public static eMapExtension GetMapArea(Vector3Int gridPos)
		{
			return default(eMapExtension);
		}

		public static (eLuggage[], eMachine[]) GetMapResources(eMapExtension area)
		{
			return default((eLuggage[], eMachine[]));
		}

		public static FactoryMap GetCurrentFactoryMap(bool force = false, bool clear = false)
		{
			return null;
		}

		[Conditional("UNITY_EDITOR")]
		public static void SerializeFactoryMapToStructureList()
		{
		}

		public static void InitTutorialFactoryRegulation()
		{
		}

		public static Vector2Int? GetVector2Int(List<string> param)
		{
			return null;
		}

		public static Dir.Rot? GetDirRot(List<string> param)
		{
			return null;
		}

		public static RectInt? GetRectInt(List<string> param)
		{
			return null;
		}

		public static void RegisterTutorialFactoryRegulationGridRot(eTutorialId? tutorialId, eMachine machineID, Vector2Int addr, Dir.Rot? rot = null)
		{
		}

		private static void RegisterTutorialFactoryRegulationArriveMechDrawStream(eTutorialId? tutorialId, eMachine machineID, eLuggage? luggageId, List<Vector2Int> v2ilist, ePrimaryMachineCategory pc, Vector2Int? mechAddr)
		{
		}

		public static void RegisterTutorialFactoryRegulationBridge(eTutorialId? tutorialId, eMachine machineID, Vector2Int addr1, Vector2Int addr2, string guideTileName1, string guideTileName2)
		{
		}

		public static void RegisterTutorialFactoryRegulationMask(eTutorialId? tutorialId, RectInt addrRect1, RectInt addrRect2, RectInt addrRect3)
		{
		}

		public static void RegisterTutorialFactoryRegulationCameraMove()
		{
		}

		public static void RegisterTutorialFactoryRegulationCameraZoom()
		{
		}

		public static void RegisterTutorialFactoryRegulationCheckJamIcon(eTutorialId? tutorialId, Vector2Int addr)
		{
		}

		public static void RegisterTutorialFactoryRegulationKeep(eTutorialId? tutorialId, eTutorialId targetTutorialId)
		{
		}

		private static CheckParamModeResult CheckParamMode(List<string> param)
		{
			return null;
		}

		public static void RegisterTutorialFactoryRegulationAuto(eTutorialId tutorialId)
		{
		}

		public static void RegisterTutorialFactoryRegulationRepairBelt(eTutorialId? tutorialId, List<FactoryRegulation.ConnectPair> pairs)
		{
		}

		public static bool CheckTutorialFactoryRegulation()
		{
			return false;
		}

		public static void CheckAndClearTutorialFactoryRegulation()
		{
		}

		public static void ForceInitTutorialFactoryRegulation()
		{
		}

		public static bool IsCameraTutorial()
		{
			return false;
		}

		public static bool IsRepairBeltTutorial()
		{
			return false;
		}

		private bool UpdateTutorialRegulation(Goal goal)
		{
			return false;
		}

		private bool UpdateTutorialRegulation(Factory.Mech.Canvas canvas)
		{
			return false;
		}

		private bool UpdateTutorialRegulation(Extractor extractor)
		{
			return false;
		}

		private bool IsConstraintMachineTutorialRegulation(eMachine machineId)
		{
			return false;
		}

		private bool IsUseMaskTutorialRegulation(out FactoryRegulation resultReg)
		{
			resultReg = null;
			return false;
		}

		private bool ContainTutorialRegulation(FactoryRegulation.eMode mode, FactoryRegulation.eMode? mode2, eMachine machineId, out List<FactoryRegulation> regs)
		{
			regs = null;
			return false;
		}

		private bool CheckNeighbor(ePrimaryMachineCategory? neighborExtractorPrimaryCategory, ExtMachineData extMachineData, Vector2IntBundle addrRect, bool isUpgrade, ref Dir.Rot? forceRot, bool ignoreForceRot, Dir.Rot paletteRot)
		{
			return false;
		}

		private bool CheckFromStructureToBelt(Structure fromStr, Vector2Int toAddr)
		{
			return false;
		}

		private bool CheckToStructureFromBelt(Structure toStr, Vector2Int fromAddr)
		{
			return false;
		}

		private void ReserveConnectedPort(Vector2IntBundle addrRect, TileDetailPack tileDetailPack, MstMachineDataEntities mstMachineData, bool overwrite, eLuggage inkColor)
		{
		}

		private void CalcBeltPreviewAndReserve(Vector2Int addr, Structure inStr, Structure outStr, out string partsName)
		{
			partsName = null;
		}

		private void CalcBeltPreviewAndReserve(Vector2Int addr, Structure inStr, Vector2Int? outAddr, out string partsName)
		{
			partsName = null;
		}

		private void CalcBeltPreviewAndReserve(Vector2Int addr, Vector2Int? inAddr, Structure outStr, out string partsName)
		{
			partsName = null;
		}

		private void CalcBeltPreviewAndReserve(Vector2Int addr, Vector2Int? inAddr, Vector2Int? outAddr, out string partsName)
		{
			partsName = null;
		}

		private bool CalcBeltPartsNameForPreview(Vector2IntBundle addrRect, eMachine cursorMachineId, ClickStartInfo clickStartInfo, out string partsName)
		{
			partsName = null;
			return false;
		}

		private void CalcStraightBeltPartsName(StructureAddr[] addrs, out string[] partsNames, ClickStartInfo clickStartInfo)
		{
			partsNames = null;
		}

		private void CalcStraightBeltPartsName(Dir.Rot? forceRot, Vector2IntBundle addrRect, out string[] partsNames, ClickStartInfo clickStartInfo)
		{
			partsNames = null;
		}

		private bool CalcPipePartsNameForPreview(Vector2Int addr, eMachine cursorMachineId, ClickStartInfo clickStartInfo, out string partsName)
		{
			partsName = null;
			return false;
		}

		private void CalcPipePreviewAndReserve(StructureAddr nowAddr, List<Structure> aroundStructures, Vector2Int? justBefore, ref eLuggage? inkColor, out string partsName)
		{
			partsName = null;
		}

		private void CalcPipePreview(StructureAddr nowAddr, StructureAddr? prevAddr, StructureAddr? nextAddr, out string partsName)
		{
			partsName = null;
		}

		private void CalcStraightPipePartsName(StructureAddr[] addrs, out string[] partsNames, bool reverse = false)
		{
			partsNames = null;
		}

		private void CalcStraightPipePartsName(Dir.Rot? forceRot, Vector2IntBundle addrRect, out string[] partsNames)
		{
			partsNames = null;
		}

		public PreviewStructureResult PreviewStructure(PaletteManager palette, Vector2IntBundle gridRect, ClickStartInfo clickStartInfo, bool ignoreForceRot)
		{
			return null;
		}

		public (bool, bool) UpdateStructure(Vector2IntBundle gridRect, TileDetailPack tileDetailPack, bool vanish = false)
		{
			return default((bool, bool));
		}

		private void UpdateMassProductionMachineCost(eMachine machineID)
		{
		}

		public void UpdateStructureWithoutPut(bool updateBelt, bool updatePipe)
		{
		}

		private int? UpdateMinion(Structure targetStructure, int addNum, bool isEliteAdd)
		{
			return null;
		}

		public void SwitchToggle(Vector2Int addr)
		{
		}

		public void Rotate(Vector2Int addr)
		{
		}

		public bool CheckMapSpace(IEnumerable<Vector2Int> gridAddrs)
		{
			return false;
		}

		public bool CheckMapWorkplace(RectInt gridRect)
		{
			return false;
		}

		public bool CheckMapWorkplace(Vector2IntBundle gridRect)
		{
			return false;
		}

		public bool CheckMapNeighborType(Vector2IntBundle gridRect, ePrimaryMachineCategory type)
		{
			return false;
		}

		public bool CheckMapRelocatable(Vector2IntBundle newGridPos, out eMachine machine)
		{
			machine = default(eMachine);
			return false;
		}

		public void GetMapInfo(Vector2IntBundle newGridPos, eMachine paletteMachineId, out ClickMapInfo mapInfo)
		{
			mapInfo = null;
		}

		public void GetMapErasingInfo(Vector2IntBundle newGridPos, ref ErasingInfo erasingInfo)
		{
		}

		private bool CheckMapStructureGridRot(eMachine machineId, RectInt gridRect, Dir.Rot? rot = null)
		{
			return false;
		}

		private bool CheckMapStructureStreams(eMachine machineId, Vector2IntBundle gridBundle, int length)
		{
			return false;
		}

		private bool CheckMapStructureJamIconStatus(RectInt gridRect)
		{
			return false;
		}

		private int CountMapStructures(eMachine machineId)
		{
			return 0;
		}

		private int CountMapTypicalStructures(eMachine machineId)
		{
			return 0;
		}

		public int CountSweetsEffectedMinion()
		{
			return 0;
		}

		public int CountStatues()
		{
			return 0;
		}

		public int CountAllMinion()
		{
			return 0;
		}

		public (eMachine, Dir.Rot) GetMapStructureMachineIdRot(Vector3Int gridPos)
		{
			return default((eMachine, Dir.Rot));
		}

		public MachineInformation GetMapMachineInformation(Vector3Int gridPos)
		{
			return null;
		}

		public (StructureGroupID, MechBase)? GetMapMachineInformationMinimum(Vector3Int gridPos)
		{
			return null;
		}

		public eMachine GetMapMachineID(Vector3Int gridPos)
		{
			return default(eMachine);
		}

		public (StructureGroupID, eMachine)? GetMapMachineIdAndGroupId(Vector3Int gridPos)
		{
			return null;
		}

		public eLuggage GetCoveredSprinklerColor(Vector3Int gridPos)
		{
			return default(eLuggage);
		}

		public eLuggage? GetStartInkColor(Vector2Int gridPos, out Vector2Int? inkSourceAddr)
		{
			inkSourceAddr = null;
			return null;
		}

		public int GetMinionCost()
		{
			return 0;
		}

		private Structure GetStructureFromMap(Vector3Int gridPos)
		{
			return null;
		}

		private Structure GetStructureFromMap(Vector2Int gridPos)
		{
			return null;
		}

		private Structure[] GetStructuresFromMap(RectInt gridRect)
		{
			return null;
		}

		private Structure[] GetStructuresFromMap(Vector2IntBundle gridArray)
		{
			return null;
		}

		public static Vector3Int Addr2Grid(Vector2Int addr)
		{
			return default(Vector3Int);
		}

		public static Vector3Int Addr2Grid(StructureAddr addr)
		{
			return default(Vector3Int);
		}

		public static Vector2Int Addr2Grid2(Vector2Int addr)
		{
			return default(Vector2Int);
		}

		public static Vector2Int Grid2Addr(Vector3Int gridPos)
		{
			return default(Vector2Int);
		}

		public static Vector2Int Grid2Addr(Vector2Int gridPos)
		{
			return default(Vector2Int);
		}

		public static RectInt Addr2Grid(RectInt addrRect)
		{
			return default(RectInt);
		}

		public static Vector2IntBundle Addr2Grid(Vector2IntBundle addrArray)
		{
			return default(Vector2IntBundle);
		}

		public static RectInt Grid2Addr(RectInt gridRect)
		{
			return default(RectInt);
		}

		public static Vector2IntBundle Grid2Addr(Vector2IntBundle gridArray)
		{
			return default(Vector2IntBundle);
		}

		public static Vector2IntBundle Grid2Addr(Vector2IntBundle? gridArray)
		{
			return default(Vector2IntBundle);
		}

		private void UpdateCircuitData(bool updateAttachment = false, bool recalcStream = false)
		{
		}

		public string DumpGrid(Vector3Int gridPos, bool verbose = false)
		{
			return null;
		}

		public string DumpGrid(RectInt gridRect, bool verbose = false)
		{
			return null;
		}

		public string DumpGrid(Vector2IntBundle gridRect, bool verbose = false)
		{
			return null;
		}

		public string DumpTutorial()
		{
			return null;
		}

		public void RefreshField(bool updateAttachment = false, bool recalcStream = false)
		{
		}

		public void RefreshPlayAreaGridTile()
		{
		}

		public static bool Contains(Vector3Int gridPos)
		{
			return false;
		}

		public static bool Contains(RectInt gridRect, bool dump = false)
		{
			return false;
		}

		public static bool Contains(Vector2IntBundle gridRect, bool dump = false)
		{
			return false;
		}

		public static bool Contains(Vector2Int gridPos)
		{
			return false;
		}

		public static Vector3 GetWorldPosition(Vector3Int gridPos)
		{
			return default(Vector3);
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void UpdateMine(double deltaTime)
		{
		}

		private void UpdateExtractor(double deltaTime)
		{
		}

		private void UpdateBelts(double deltaTime)
		{
		}

		private void UpdatePipes(double deltaTime)
		{
		}

		private void UpdateBridgeConveyer(double deltaTime)
		{
		}

		private void UpdateBridgePipe(double deltaTime)
		{
		}

		private void UpdateCrossBridgeConveyer(double deltaTime)
		{
		}

		private void UpdateCrossPipe(double deltaTime)
		{
		}

		private void UpdateTeleporter(double deltaTime)
		{
		}

		private void UpdateManhole(double deltaTime)
		{
		}

		private void UpdateCanvas(double deltaTime)
		{
		}

		private void UpdateCutter(double deltaTime)
		{
		}

		private void UpdateRepainter(double deltaTime)
		{
		}

		private void UpdateChuChuHouse(double deltaTime)
		{
		}

		private void UpdateStatue(double deltaTime)
		{
		}

		private void UpdateMiracleOrb(double deltaTime)
		{
		}

		private void UpdateColor(double deltaTime)
		{
		}

		private void UpdateAlbedo(double deltaTime)
		{
		}

		private void UpdateInkChanger(double deltaTime)
		{
		}

		private void UpdateInkBottleProcessor(double deltaTime)
		{
		}

		private void UpdateInkBottleReverse(double deltaTime)
		{
		}

		private void UpdateColorCoating(double deltaTime)
		{
		}

		private void UpdateSplitter(double deltaTime)
		{
		}

		private void UpdateComposite(double deltaTime)
		{
		}

		private void UpdateCombiner(double deltaTime)
		{
		}

		private void UpdateInversionPipe(double deltaTime)
		{
		}

		private void UpdateInserter(double deltaTime)
		{
		}

		private void UpdateTemporaryTable(double deltaTime)
		{
		}

		private void UpdateEngine(double deltaTime)
		{
		}

		private void UpdateSweetsStorage(double deltaTime)
		{
		}

		private void UpdateInkSprinkler(double deltaTime)
		{
		}

		private void UpdateSweetsSupply(double deltaTime)
		{
		}

		private void UpdateInkCatcher(double deltaTime)
		{
		}

		private void UpdateRecycleBox(double deltaTime)
		{
		}

		private void UpdateRecycleFacility(double deltaTime)
		{
		}

		private void UpdateCopier(double deltaTime)
		{
		}

		private void UpdateUniqueHeroGenerator(double deltaTime)
		{
		}

		private void UpdateMineShaft(double deltaTime)
		{
		}

		private void UpdateGoal(double deltaTime)
		{
		}

		private void UpdateTrashCan(double deltaTime)
		{
		}

		private void UpdateAltarOfSpirit(double deltaTime)
		{
		}

		private void UpdateFactory()
		{
		}

		public static void AdjustCursor(ref Vector2IntBundle bundle, out Vector2IntBundle pos)
		{
			pos = default(Vector2IntBundle);
		}

		private static Vector2Int GetNearestPlayField(RectInt rectInt)
		{
			return default(Vector2Int);
		}

		public Vector2IntBundle GetBeltAutoUpgradeGrid(Vector2IntBundle clickInfoGridRect)
		{
			return default(Vector2IntBundle);
		}
	}
}
