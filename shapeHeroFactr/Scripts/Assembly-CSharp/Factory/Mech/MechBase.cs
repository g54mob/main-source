using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Factory.FieldData;
using Libs;
using Models;
using ScriptableObjects.ScriptableObjectScripts.ExtendData;
using ScriptableObjects.ScriptableObjectScripts.Tile;
using UI;
using UnityEngine;

namespace Factory.Mech
{
	public class MechBase
	{
		protected record ArrivePair(StructureAddr Addr, eLuggage Luggage)
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

			public StructureAddr Addr { get; set; }

			public eLuggage Luggage { get; set; }

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
			public virtual bool Equals(ArrivePair? other)
			{
				return false;
			}

			[CompilerGenerated]
			protected ArrivePair(ArrivePair original)
			{
			}

			[CompilerGenerated]
			public void Deconstruct(out StructureAddr Addr, out eLuggage Luggage)
			{
				Addr = default(StructureAddr);
				Luggage = default(eLuggage);
			}
		}

		protected record PipeLinkPairInMechBase(ILiquidCarrier A, ILiquidCarrier B, bool NoBalance)
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

			public ILiquidCarrier A { get; set; }

			public ILiquidCarrier B { get; set; }

			public bool NoBalance { get; set; }

			public string ToMinimum()
			{
				return null;
			}

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
			public virtual bool Equals(PipeLinkPairInMechBase? other)
			{
				return false;
			}

			[CompilerGenerated]
			protected PipeLinkPairInMechBase(PipeLinkPairInMechBase original)
			{
			}

			[CompilerGenerated]
			public void Deconstruct(out ILiquidCarrier A, out ILiquidCarrier B, out bool NoBalance)
			{
				A = null;
				B = null;
				NoBalance = default(bool);
			}
		}

		public enum ChangeRotType
		{
			None = 0,
			Swap = 1,
			Next = 2,
			NextIn = 3,
			NextOut = 4
		}

		public class TileAppendsContainer
		{
			public StructureAddr addr;

			public List<TileAppend> tileAppends;
		}

		public readonly Structure[] Structures;

		private readonly StructureAddr[] StructureAddrs;

		protected readonly StructureAddr[] AroundStructureAddrs;

		protected Structure[] Entrances;

		protected StructureAddr[] EntranceAddrs;

		protected Structure[] Exits;

		protected StructureAddr[] ExitAddrs;

		protected StructureAddr[] FromAddrs;

		protected StructureAddr[] ToAddrs;

		protected readonly StructureGroupID GroupID;

		public readonly Structure TypicalStructure;

		protected MiniLuggageCarrier[] Stocks;

		protected MiniLuggageCarrier[] OutputStocks;

		protected MiniLiquidCarrier[] InternalTanks;

		protected MiniLiquidCarrier[] Tanks;

		protected int I0;

		protected int I1;

		protected int I2;

		protected int I3;

		protected int I4;

		protected int I5;

		protected int I6;

		protected int I7;

		protected double D0;

		protected double D1;

		protected double D2;

		protected double D3;

		internal double[] MultiMinionTable;

		internal readonly FactoryMap factoryMap;

		internal readonly FactoryContext Fc;

		internal bool toggleSwitch;

		private double _boostInkEngineSpeed;

		private double _boostInkEngineSpeedCache;

		private int _boostInkEngineSpeedCacheFrame;

		internal int inkEngineEffectProductCounter;

		private double _boostSweetsSupplySpeed;

		private double _boostSweetsSupplySpeedCache;

		private int _boostSweetsSupplySpeedCacheFrame;

		internal int SweetsSupplyEffectProductCounter;

		private GameObject _deliciousEffectObject;

		private ParticleSystem _deliciousParticleSystem;

		private bool _isDeliciousAnimation;

		internal bool withinSprinklerCoverage;

		internal eOutputPriorityMode _outputPriorityMode;

		internal eInputPriorityMode _inputPriorityMode;

		internal eLuggage _filterLuggage;

		internal double? _productionTime;

		internal double? _productionSpeed;

		public double LiquidConsumption;

		protected eLuggage LiquidProduct;

		internal double? operatingPreviousCycleEndTime;

		internal double operatingCycleStartTime;

		internal double operatingCycleEndTime;

		internal bool isOperating;

		private double? AllSmartMachine_OverwriteBuffRate;

		private double? AllSmartMachine_OverwriteAttenuationRate;

		internal StructureAddr TypicalAddr => default(StructureAddr);

		public StructureAddr GetAddr => default(StructureAddr);

		public double CreateTime { get; set; }

		internal double MechSpeed { get; set; }

		internal double MechSpeed2 { get; set; }

		internal double BaseSpeed => 0.0;

		internal double BaseSpeed2 => 0.0;

		public int MinionNum => 0;

		public bool IsEliteMinion => false;

		public double EliteSpeed => 0.0;

		public double EliteProbUp => 0.0;

		public bool IsWorkingByMinion => false;

		public eMachine MachineID => default(eMachine);

		internal MstMachineDataEntities MachineData => null;

		internal eSecondaryMachineCategory SecondaryMachineCategory => default(eSecondaryMachineCategory);

		private double ProcessingSpeedRate => 0.0;

		public double ProcessingSpeedAdd => 0.0;

		public virtual int MinionLayer { get; set; }

		public double BoostInkEngineSpeed
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public eEngineAdditionalEffect AddInkEngineEffect { get; set; }

		public Engine ConnectedInkEngine { get; set; }

		public double BoostSweetsSupplySpeed
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public SweetsSupply ConnectedSweetsSupply { get; set; }

		public RecycleBox ConnectedRecycleBox { get; set; }

		public double Sprinkler_UseInk_SpeedUp => 0.0;

		public virtual bool HasToggleSwitch => false;

		public virtual bool HasRotateSwitch { get; }

		public virtual bool HasOutputPriority { get; }

		public virtual StructureAddr? OutputPriorityToAddr => null;

		public virtual int InputPriorityCount { get; }

		public virtual StructureAddr? InputPriorityFromAddr => null;

		public virtual bool HasLuggageFilter { get; }

		public virtual bool UseLuggageFilterIcon => false;

		public virtual bool IsLiquidFilter { get; }

		public virtual bool HasMultiOutputProduct { get; }

		public virtual bool IsSerialize => false;

		public virtual double OutputSpeedPerSec => 0.0;

		public virtual double Efficiency => 0.0;

		public int ConnectExtractorNum
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int ConnectExtractorMax
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal int ConnectExtractorMaxMaster => 0;

		public double ProductionTime
		{
			get
			{
				return 0.0;
			}
			internal set
			{
			}
		}

		public virtual double FixedProductionTime => 0.0;

		public double ProductionSpeed
		{
			get
			{
				return 0.0;
			}
			internal set
			{
			}
		}

		public int ProductionQuantity { get; internal set; }

		public double BuffRate
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double DeliverySpeed
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public virtual eLuggage Product => default(eLuggage);

		protected virtual bool isLiquidProduct => false;

		public double Utilization { get; internal set; }

		internal FixedQueue<double> utilizationLog { get; set; }

		public virtual double outputPortUtilizationAverageMain => 0.0;

		public virtual double outputPortUtilizationAverageSub => 0.0;

		public virtual bool inserterError => false;

		public eMachine ExtractorSource { get; internal set; }

		public double SourceCorrection { get; internal set; }

		public double SourceCorrectionAdd { get; internal set; }

		public int ConvertionRateBefore { get; internal set; }

		public int ConvertionRateAfter { get; internal set; }

		public int HumanEfficiency { get; internal set; }

		public virtual List<MachineInformation.CollectItemInfo> GetCollectItemInfos => null;

		public double CollectionEfficiency => 0.0;

		public double SweetsEffectiveTime { get; internal set; }

		public virtual eLuggage GetLiquidId => default(eLuggage);

		public virtual double GetLiquidMeasure => 0.0;

		public virtual double GetLiquidCapacity => 0.0;

		public virtual List<MachineInformation.MeasureInfo> GetMeasureInfos => null;

		public bool HasTankFromInPort(StructureAddr fromAddr, StructureAddr tankAddr)
		{
			return false;
		}

		public MiniLiquidCarrier GetTankFromInPort(StructureAddr fromAddr, StructureAddr tankAddr)
		{
			return null;
		}

		public bool HasTankToOutPort(StructureAddr tankAddr, StructureAddr toAddr)
		{
			return false;
		}

		public MiniLiquidCarrier GetTankToOutPort(StructureAddr tankAddr, StructureAddr toAddr)
		{
			return null;
		}

		public bool HasTankWithPipePort(StructureAddr tankAddr, StructureAddr pipeLinkAddr)
		{
			return false;
		}

		public MiniLiquidCarrier GetTankWithPipePort(StructureAddr tankAddr, StructureAddr pipeLinkAddr)
		{
			return null;
		}

		public bool HasTankSpecificAddr(StructureAddr tankAddr)
		{
			return false;
		}

		public MiniLiquidCarrier GetTankSpecificAddr(StructureAddr tankAddr, int? streamLayer)
		{
			return null;
		}

		public List<MiniLiquidCarrier> GetTanksSpecificAddr(StructureAddr tankAddr)
		{
			return null;
		}

		public List<ILiquidCarrier> GetLiquidCarriersSpecificAddr(StructureAddr tankAddr)
		{
			return null;
		}

		protected void UpdateInternalPipeCircuitData(MiniLiquidCarrier tank1, MiniLiquidCarrier tank2, out List<PipeLinkPairInMechBase> pipeLinkPair, out List<ILiquidCarrier> liquidCarriers, bool manhole = false)
		{
			pipeLinkPair = null;
			liquidCarriers = null;
		}

		protected void UpdateInternalPipe(ref List<PipeLinkPairInMechBase> pipeLinkPair, ref List<ILiquidCarrier> liquidCarriers, double dProcess)
		{
		}

		internal bool ReCreateIfNewInk(MiniLiquidCarrier target, eLuggage newInk, bool disconnectFromPipesOfOldColor = false)
		{
			return false;
		}

		public double MultiMinionSpeedUp(double[] table)
		{
			return 0.0;
		}

		public void PlayDeliciousAnimation(bool play, bool force = false)
		{
		}

		public void ClearDeliciousAnimation()
		{
		}

		public int CountDeliciousMinion()
		{
			return 0;
		}

		public virtual bool CheckRequirements(bool isUpgrade)
		{
			return false;
		}

		public MechBase(Structure[] structures, bool noPrepareMechView = false, bool arriveTile = false)
		{
		}

		private void _UpdatePorts()
		{
		}

		public virtual void Update(double deltaTime)
		{
		}

		public virtual void UpdateCircuitData(bool updateAttachment = false)
		{
		}

		internal void UpdateAttachmentForSmart()
		{
		}

		public virtual void SwitchToggle()
		{
		}

		public virtual void SwitchRotate(StructureAddr addr)
		{
		}

		public virtual void SetOutputPriority(eOutputPriorityMode mode)
		{
		}

		public virtual eOutputPriorityMode GetOutputPriority()
		{
			return default(eOutputPriorityMode);
		}

		public virtual void SetInputPriority(eInputPriorityMode mode)
		{
		}

		public virtual eInputPriorityMode GetInputPriority()
		{
			return default(eInputPriorityMode);
		}

		public virtual void SetFilterLuggage(eLuggage luggage)
		{
		}

		public virtual void RestoreFilterLuggage()
		{
		}

		private bool IsEnableFilterIcon()
		{
			return false;
		}

		public virtual eLuggage GetFilterLuggage()
		{
			return default(eLuggage);
		}

		public virtual List<eLuggage> GetFilterLuggageList()
		{
			return null;
		}

		public virtual MiniLuggageCarrier GetTargetStock(StructureAddr toAddr)
		{
			return null;
		}

		internal virtual void ChangeRot(ChangeRotType rotType = ChangeRotType.None, bool refreshTile = true)
		{
		}

		private void RefreshTiles(ExtMachineData extDat, Dir.Rot oldRot, Dir.Rot newRot)
		{
		}

		internal void RefreshMech()
		{
		}

		private static int[] GetTileIndexes(Structure[] structures, List<TileDetail> tileDetails)
		{
			return null;
		}

		private void PrepareMechView(bool arriveTile = false)
		{
		}

		public virtual void UpdateMechView(bool prepare = true)
		{
		}

		public virtual void Vanish()
		{
		}

		public void ChangePipeTileVariations(eLuggage index)
		{
		}

		internal Structure[] GetAroundStructures(ePrimaryMachineCategory? primaryMachineCategory = null)
		{
			return null;
		}

		internal Structure[] GetAroundStructures(eSecondaryMachineCategory? secondaryMachineCategory = null)
		{
			return null;
		}

		internal Structure SelectMostHungryOutput()
		{
			return null;
		}

		internal void UpdateOverallPortData()
		{
		}

		internal void PlayInkEngineAdditionalEffect(ILuggageCarrier luggageCarrier)
		{
		}

		public virtual int[] GetIntArray()
		{
			return null;
		}

		public virtual void SetIntArray(int[] array)
		{
		}

		public virtual double[] GetDoubleArray()
		{
			return null;
		}

		public virtual void SetDoubleArray(double[] array)
		{
		}

		public virtual Vector2IntBundle GetAddrBundle()
		{
			return default(Vector2IntBundle);
		}

		public List<TileAppendsContainer> GetTileAppendsContainerList()
		{
			return null;
		}

		protected void SetOutputProductFromLiquid(eLuggage liquidId)
		{
		}

		internal void RecordOperationStart()
		{
		}

		internal void RecordOperationEnd()
		{
		}

		public virtual Vector2IntBundle? GetRouteAddrBundle()
		{
			return null;
		}

		public static Vector2IntBundle? GetVector2IntBundleFromSerializableStructures(eMachine machineId, List<SerializableStructure> sames, Dir.Rot rot, out int? joint)
		{
			joint = null;
			return null;
		}

		public static bool IsValidBridge(Vector2IntBundle gridRect, TileDetailPack tileDetailPack)
		{
			return false;
		}

		public static bool IsValidBridge(StructurePack pack)
		{
			return false;
		}

		internal void ClearJamIcon()
		{
		}

		internal MstBlendDataEntities SearchBlueprint(IBlendMaterial[] fromStrs, int needMaterialCount, out MstLuggageDataEntities luggageData, out PlayUnlockData playUnlockData)
		{
			luggageData = null;
			playUnlockData = null;
			return null;
		}

		internal bool IsFullUnlockRecipe()
		{
			return false;
		}

		internal int CountParallelMech(eSecondaryMachineCategory? secondaryMachineCategory = null, eMachine? machine = null)
		{
			return 0;
		}

		internal double UpdateParallelCircuitSmart()
		{
			return 0.0;
		}

		public virtual bool IsPickupable(Structure to, out ILuggageCarrier carrier)
		{
			carrier = null;
			return false;
		}

		public virtual bool IsInsertable(ILuggageCarrier fromCarrier, Structure to, out ILuggageCarrier toCarrier, out double luggageRate, out bool visible, out bool? cautionIcon, out Action<ILuggageCarrier> successCallback)
		{
			toCarrier = null;
			luggageRate = default(double);
			visible = default(bool);
			cautionIcon = null;
			successCallback = null;
			return false;
		}

		public virtual string ToDump()
		{
			return null;
		}

		public void PlayOperationSE()
		{
		}

		public void PlayProductionSuccessSE()
		{
		}

		public void PlayProductionFailSE()
		{
		}

		public void PlayUniqueAction01SE()
		{
		}

		public void PlayUniqueAction02SE()
		{
		}

		public void PlayUniqueAction03SE()
		{
		}

		public void PlayUniqueAction04SE()
		{
		}

		public void PlayUniqueAction05SE()
		{
		}

		public void PlayUniqueAction06SE()
		{
		}

		public void PlayUniqueAction07SE()
		{
		}

		public void PlayUniqueAction08SE()
		{
		}

		public void PlayUniqueAction09SE()
		{
		}

		public void PlayUniqueAction10SE()
		{
		}
	}
}
