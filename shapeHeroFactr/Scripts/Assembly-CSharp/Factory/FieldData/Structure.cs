using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Factory.FieldObject;
using Factory.Mech;
using Libs;
using Models;
using ScriptableObjects.ScriptableObjectScripts.ExtendData;
using ScriptableObjects.ScriptableObjectScripts.Tile;
using UnityEngine;

namespace Factory.FieldData
{
	public class Structure : ILuggageCarrier, ILiquidCarrier
	{
		public record JamInkLogPrim(LiquidFeedResult Result)
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

			public LiquidFeedResult Result { get; set; }

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
			public virtual bool Equals(JamInkLogPrim? other)
			{
				return false;
			}

			[CompilerGenerated]
			protected JamInkLogPrim(JamInkLogPrim original)
			{
			}

			[CompilerGenerated]
			public void Deconstruct(out LiquidFeedResult Result)
			{
				Result = null;
			}
		}

		public record JamLogPrim(double ReadyTime, double CycleTime)
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

			public double ReadyTime { get; set; }

			public double CycleTime { get; set; }

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
			public virtual bool Equals(JamLogPrim? other)
			{
				return false;
			}

			[CompilerGenerated]
			protected JamLogPrim(JamLogPrim original)
			{
			}

			[CompilerGenerated]
			public void Deconstruct(out double ReadyTime, out double CycleTime)
			{
				ReadyTime = default(double);
				CycleTime = default(double);
			}
		}

		private FactoryMap _factoryMap;

		private TileDetail _tileDetail;

		private eMachine _machineID;

		private ExtMachineData _extMachineData;

		private MstMachineDataEntities _mstMachineData;

		private Version _saveMapVersion;

		private readonly LuggageSettings luggageSettings;

		private Color LiquidLevelColor;

		private StructureAddr? _outputRouteAddr;

		private eLuggage _lastOutputProduct;

		private StructureAddr? _inputRouteAddr;

		public string PartsName;

		private bool _isAnimation;

		public bool HasBillboard;

		public Dir.Rot Rot;

		private TileContext _tileContext;

		public bool FirstCreateDone;

		public MechBase MechBase;

		private int _minionNum;

		private bool _isEliteMinion;

		private int _counterSignboardNumerator;

		private int _counterSignboardDenominator;

		private Vector2 fromVectorCache;

		private Vector2 toVectorCache;

		public DTileBase2[] PipeTileVariations;

		public DTileBase2[] InkLevelTileVariations;

		public DTileBase2[] PipeFunnelTileVariations;

		public int PipeTileVariationIndex;

		public int InkLevelTileVariationIndex;

		public int PipeFunnelTileVariationIndex;

		private bool _cautionIcon;

		private bool _settingMenuBubbleIcon;

		private TileContext _settingMenuBubbleIconContext;

		private ScriptableObjectReader.JamIconStatus _jamIconOut;

		private double? lastRecordJamInkLogTime;

		private double _lastJamInkInFeedRate;

		private double _lastJamInkInExhaustionRate;

		private ScriptableObjectReader.JamIconStatus _jamInkIconIn;

		private TileContext _jamInkIconContext;

		private SpriteAnimeCtrl _jamInkIconBarCtrl;

		internal double jamCycleStartTime;

		internal double jamCycleCheckTime;

		internal double jamCycleEndTime;

		private FactoryMap factoryMap => null;

		public List<TileAppend> TileAppendsList => null;

		public StructureAddr Addr { get; set; }

		public Vector3Int GridPos => default(Vector3Int);

		public StructureGroupID StructureGroupID { get; set; }

		public bool IsTypical => false;

		public eMachine MachineID => default(eMachine);

		public ExtMachineData ExtMachineData => null;

		public MstMachineDataEntities MachineData => null;

		public Luggage Luggage { get; set; }

		public bool LuggageVisible
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public double LuggageRate { get; set; }

		public int LuggageCount { get; set; }

		public int LuggageOmakeCount { get; set; }

		public double LoadingTime { get; set; }

		public double CreateTime { get; set; }

		public double LiquidCreateTime { get; set; }

		public bool IsLuggageGoal => false;

		public bool HasUnitLuggage => false;

		public bool HasUnitOrMiracleLuggage => false;

		public bool IsLuggageOverflow => false;

		public bool IsLuggagePickup => false;

		public bool IsLuggageEntranceLine => false;

		public bool IsLuggageEntranceLineEq => false;

		public bool IsPushBacked { get; set; }

		public double CarHornLevel { get; set; }

		public double UpdateLuggageSpeedForDebug { get; set; }

		public eLuggage HasLuggageId => default(eLuggage);

		public Liquid Liquid { get; set; }

		public double LiquidCapacity { get; set; }

		public eLuggage HasLiquidId => default(eLuggage);

		public double LiquidMeasure => 0.0;

		public StructureAddr GetAddr => default(StructureAddr);

		public StructureAddr TankAddr => default(StructureAddr);

		public StructureAddr? MechAddr => null;

		public int? StreamLayer => null;

		public eBroadMachineCategory BroadMachineCategory => default(eBroadMachineCategory);

		public ePrimaryMachineCategory PrimaryMachineCategory => default(ePrimaryMachineCategory);

		public eSecondaryMachineCategory SecondaryMachineCategory => default(eSecondaryMachineCategory);

		public string ThirdMachineCategory => null;

		public bool TransportLuggage => false;

		public bool Unbreakable => false;

		public int ReqMinionMin => 0;

		public int ReqHandMinionMax => 0;

		public bool ReqEliteMinion => false;

		public bool BoostInkEngine => false;

		public bool BoostSweetsSupply => false;

		public bool ConnectableRecycleBox => false;

		public bool HasOutPort => false;

		public int OutPortPriority => 0;

		public Vector2Int[] ToAddrs { get; private set; }

		public Vector2Int ToAddrFirst { get; private set; }

		public List<Vector2Int> ToAddrList { get; private set; }

		public Vector2Int[] BeltToAddrs { get; private set; }

		public Vector2Int BeltToAddrFirst { get; private set; }

		public List<Vector2Int> BeltToAddrList { get; private set; }

		public Dir.DirFlag OutDirFlag => default(Dir.DirFlag);

		public StructureAddr? OutputRouteAddr
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private eLuggage OutputProduct { get; set; }

		public eLuggage LastOutputProduct => default(eLuggage);

		public eLuggage Product => default(eLuggage);

		public bool HasInPort => false;

		public int InPortPriority => 0;

		public Vector2Int[] FromAddrs { get; private set; }

		public Vector2Int FromAddrFirst { get; private set; }

		public List<Vector2Int> FromAddrList { get; private set; }

		public Vector2Int[] BeltFromAddrs { get; private set; }

		public Vector2Int BeltFromAddrFirst { get; private set; }

		public List<Vector2Int> BeltFromAddrList { get; private set; }

		public StructureAddr? InputRouteAddr
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2Int[] PipeAddrs { get; private set; }

		public List<Vector2Int> PipeFromAddrList { get; private set; }

		public Vector2Int PipeFromAddrFirst { get; private set; }

		public Vector2Int[] PipeFromAddrs { get; private set; }

		public List<Vector2Int> PipeToAddrList { get; private set; }

		public Vector2Int PipeToAddrFirst { get; private set; }

		public Vector2Int[] PipeToAddrs { get; private set; }

		public bool HasPipePort => false;

		public Dir.DirFlag PipeLinkDir { get; set; }

		public bool PipeFunnel { get; set; }

		public bool Stream => false;

		public bool Kakou => false;

		public bool Pipe => false;

		public bool Belt => false;

		public bool Relocatable => false;

		public bool HasSettingMenu => false;

		public MechBase GetMechBaseWithLogWarning => null;

		public MechBase GroupMechBase => null;

		public int MinionNum
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool IsEliteMinion
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsWorkingByMinion => false;

		public int CounterSignboardNumerator
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int CounterSignboardDenominator
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int CounterSignboardDenominatorMaster => 0;

		public double DeliverySpeed { get; set; }

		public double BuffRate { get; set; }

		public Vector2 FromVector => default(Vector2);

		public Vector2 ToVector => default(Vector2);

		public bool IsCautionIcon => false;

		public FixedQueue<JamInkLogPrim> JamInkLog { get; set; }

		public double JamUtilizationAve { get; internal set; }

		public FixedQueue<JamLogPrim> JamLog { get; set; }

		public double NowJamUtilization => 0.0;

		private double NowJamRate => 0.0;

		public bool IsEmptyTile => false;

		public StructureAddr? OutputSuggestRouteAddr => null;

		public StructureAddr? InputSuggestRouteAddr => null;

		public bool ComeFromInserter { get; set; }

		public Structure GetGroupTypicalStructure()
		{
			return null;
		}

		public bool IsLuggageGoalAndIsEmptyNext(ILuggageCarrier next)
		{
			return false;
		}

		public void PushBackLuggageEntranceLine()
		{
		}

		public void InfectionCarHornLevel(ILuggageCarrier from)
		{
		}

		public bool CheckRequirements(bool isUpgrade)
		{
			return false;
		}

		public bool IsPermitOutputAddr(StructureAddr addr)
		{
			return false;
		}

		public bool ClearOutputProduct()
		{
			return false;
		}

		public void CreateOutputProduct(eLuggage product, int craftCount, int omakeCount = 0, bool luggageVisible = true, float? scale = null, LuggageFlag flag = (LuggageFlag)0, bool noRecord = false)
		{
		}

		public void TractionOutputProduct<T>(T from, bool forceVisible = true, bool noRecord = false) where T : ILuggageCarrier
		{
		}

		public void PrepareOutputProduct()
		{
		}

		public bool SetOutputProductFromLuggage(bool addManufacture = true)
		{
			return false;
		}

		public bool HasOutputProduct(StructureAddr toAddr, out ILuggageCarrier adjustedFrom)
		{
			adjustedFrom = null;
			return false;
		}

		public ILuggageCarrier AdjustLuggageCarrierForOutputProduct(StructureAddr toAddr)
		{
			return null;
		}

		public bool CheckProductIconNameRelativeAddr(string iconName, Vector2Int targetAddr)
		{
			return false;
		}

		public bool HasTankWithPipePort(Vector2Int pipeLinkAddr)
		{
			return false;
		}

		public MiniLiquidCarrier GetTankWithPipePort(Vector2Int pipeLinkAddr)
		{
			return null;
		}

		public MiniLiquidCarrier GetTankToOutPort(Vector2Int pipeLinkAddr)
		{
			return null;
		}

		public MiniLiquidCarrier GetTankFromInPort(Vector2Int pipeLinkAddr)
		{
			return null;
		}

		public bool HasTankSpecificAddr()
		{
			return false;
		}

		public List<ILiquidCarrier> GetTanksThisAddr()
		{
			return null;
		}

		public void UpdateFtVectorCache()
		{
		}

		public Structure(StructureAddr addr, TileDetail tile, bool hasBillboard, StructureAddr typicalAddr, Version saveMapVersion = null)
		{
		}

		public void UpdateTileDetail(TileDetail tile)
		{
		}

		public void Decide()
		{
		}

		private void _UpdatePortAddrs()
		{
		}

		public Vector2Int[] GetPipeAddrs(int? streamLayer = null)
		{
			return null;
		}

		public Vector2Int[] GetPipeFromAddrs(int? streamLayer = null)
		{
			return null;
		}

		public Vector2Int GetPipeFromAddrFirst(int? streamLayer = null)
		{
			return default(Vector2Int);
		}

		public List<Vector2Int> GetPipeFromAddrList(int? streamLayer = null)
		{
			return null;
		}

		public Vector2Int[] GetPipeToAddrs(int? streamLayer = null)
		{
			return null;
		}

		public Vector2Int GetPipeToAddrFirst(int? streamLayer = null)
		{
			return default(Vector2Int);
		}

		public List<Vector2Int> GetPipeToAddrList(int? streamLayer = null)
		{
			return null;
		}

		private DTileBase2 GetTileBase(bool inkLevel = false, bool pipeFunnel = false)
		{
			return null;
		}

		public void ClearAppendTileView()
		{
		}

		public void UpdateStructureView()
		{
		}

		private void SetPipeTileVariations(DTileBase2[] tileVariations, DTileBase2[] inkLevelTileVariations, DTileBase2[] pipeFunnelTileVariations)
		{
		}

		private void ClearPipeTileVariations()
		{
		}

		public void ChangePipeTileVariations(eLuggage ink, bool ignoreMechBase = true)
		{
		}

		private void _ChangePipeTileVariation(int index)
		{
		}

		private void ChangeLiquidColor(ILiquidCarrier targetStr, eLuggage inkColor)
		{
		}

		public void UpdateCautionIcon(bool enable, Vector2Int targetAddr)
		{
		}

		public void ClearCautionIcon()
		{
		}

		public void UpdateSettingMenuBubbleIcon(eLuggage luggage = eLuggage.None, int priority = 0)
		{
		}

		public void ClearSettingMenuBubbleIcon()
		{
		}

		public void UpdateJamIcon(ScriptableObjectReader.JamIconStatus? forceStatus = null)
		{
		}

		public void ClearJamIcon()
		{
		}

		public void RecordJamInkLog(LiquidFeedResult resultFlag)
		{
		}

		private (ScriptableObjectReader.JamIconStatus, double) GetJamInkInIconStatus()
		{
			return default((ScriptableObjectReader.JamIconStatus, double));
		}

		public ScriptableObjectReader.JamIconStatus GetJamInkOutIconStatus()
		{
			return default(ScriptableObjectReader.JamIconStatus);
		}

		public void UpdateJamInkIcon()
		{
		}

		public void ClearJamInkIcon(bool force = false)
		{
		}

		private void RecordOutputProductCreateForJam(bool noRecord)
		{
		}

		private void RecordOutputProductReadyForJam()
		{
		}

		private JamLogPrim GetCurrentJamUtilization(double endTime)
		{
			return null;
		}

		private double CalcNowJamUtilization(double endTime)
		{
			return 0.0;
		}

		private void RecordOutputProductCleanForJam()
		{
		}

		public ScriptableObjectReader.JamIconStatus GetJamIconStatus()
		{
			return default(ScriptableObjectReader.JamIconStatus);
		}

		public void RefreshBeltTile()
		{
		}

		public void RefreshPipeTile()
		{
		}

		public void RefreshPipeTileInkLevel()
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

		public string ToMinimum()
		{
			return null;
		}

		public string ToMinimumWithID()
		{
			return null;
		}

		public string ToStringLiquid()
		{
			return null;
		}

		public string ToSerialize()
		{
			return null;
		}

		public bool SameID(Structure other)
		{
			return false;
		}

		public bool SameID(eMachine other)
		{
			return false;
		}

		public bool IsConnectableBelt(Structure other)
		{
			return false;
		}

		public bool IsOverwritable(eSecondaryMachineCategory overwriteSecondaryMachineCategory)
		{
			return false;
		}

		public bool IsUpgradable(Structure other)
		{
			return false;
		}

		public bool IsUpgradable(StructureAddr addr, eSecondaryMachineCategory secondaryMachineCategory, eMachine machine, bool isStream, bool isKakou)
		{
			return false;
		}

		public bool IsUpgradable(eSecondaryMachineCategory secondaryMachineCategory)
		{
			return false;
		}

		public void Vanish()
		{
		}

		public void RemoveOutputRouteLink()
		{
		}

		public void RemoveInputRouteLink()
		{
		}

		public void RemoveAllPipeLink()
		{
		}

		public void RemoveSpecificPipeLink(StructureAddr lStrAddr, bool ignoreColor = false, bool cleanTank = false, eLuggage? pipeColor = null)
		{
		}

		public void OverwriteInputRouteLink(StructureAddr inAddr)
		{
		}

		public void OverwriteOutputRouteLink(StructureAddr outAddr)
		{
		}

		public void OverwritePipeLink(StructureAddr linkAddr, eLuggage inkColor, bool ignoreInkTank = false, bool overwriteColor = false)
		{
		}

		public void AutoLinkBrokenBelts()
		{
		}

		public void AutoLinkBrokenPipes(StructureAddr? exceptPipeAddr = null)
		{
		}

		public void RemoveLuggage(bool force = false, bool exceptInserter = false)
		{
		}

		public void RemoveLiquid()
		{
		}

		public void SetUvTiles(UvAnimationTile[] uvAnimeTiles)
		{
		}

		public void SetOverrideAnimationTile(DTileBase2 animeTile)
		{
		}

		public void PlayBillboardAnimation(bool play, string partsName0 = null, string partsName1 = null, string partsName2 = null, bool? loopOnce = null, float? specificRate = null, bool keepIndex = false)
		{
		}

		public void PlayBillboardManualAnimation(int manualIndex, string partsName0 = null, string partsName1 = null, string partsName2 = null, bool? loopOnce = null)
		{
		}

		public void PlayBillboardAnimationSeparately(BillboardAnimationSpecificLayer[] animationSpecificLayers)
		{
		}

		public void PlayTileArriveAnimation()
		{
		}

		public void SetBillboardPartsName(string partsName, int layer = 0)
		{
		}

		public void SetMinionBillboardPartsName(string partsName, int minionLayer)
		{
		}

		public void ForceSetBillboardOffset(Vector2 billboardOffsetXY, int billboardLayer = 0)
		{
		}

		public void UpdateTilePortAndPortAddrs()
		{
		}

		public static bool IsNullOrEmpty(Structure str)
		{
			return false;
		}
	}
}
