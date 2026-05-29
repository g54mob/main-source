using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Factory.Mech;
using Libs;
using Models;
using UnityEngine;

namespace Factory.FieldData
{
	public class FactoryMap
	{
		public record MachineAndGroupID(eMachine Mid, StructureGroupID Gid)
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

			public eMachine Mid { get; set; }

			public StructureGroupID Gid { get; set; }

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
			public virtual bool Equals(MachineAndGroupID? other)
			{
				return false;
			}

			[CompilerGenerated]
			protected MachineAndGroupID(MachineAndGroupID original)
			{
			}

			[CompilerGenerated]
			public void Deconstruct(out eMachine Mid, out StructureGroupID Gid)
			{
				Mid = default(eMachine);
				Gid = default(StructureGroupID);
			}
		}

		public record PreviewedPipe(StructureAddr pipeAddr, StructureAddr? linkAddr, eLuggage inkColor, bool OverwriteColor, bool Upgrade = false)
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

			public StructureAddr pipeAddr { get; set; }

			public StructureAddr? linkAddr { get; set; }

			public eLuggage inkColor { get; set; }

			public bool OverwriteColor { get; set; }

			public bool Upgrade { get; set; }

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
			public virtual bool Equals(PreviewedPipe? other)
			{
				return false;
			}

			[CompilerGenerated]
			protected PreviewedPipe(PreviewedPipe original)
			{
			}

			[CompilerGenerated]
			public void Deconstruct(out StructureAddr pipeAddr, out StructureAddr? linkAddr, out eLuggage inkColor, out bool OverwriteColor, out bool Upgrade)
			{
				pipeAddr = default(StructureAddr);
				linkAddr = null;
				inkColor = default(eLuggage);
				OverwriteColor = default(bool);
				Upgrade = default(bool);
			}
		}

		private readonly Structure[,] _structures;

		private readonly Structure[] _structuresLinear;

		private HashSet<eMapExtension> _mapExtendState;

		public Belt BeltInstance;

		public Pipe PipeInstance;

		public BridgeConveyer[] allBridgeConveyerGroups;

		public BridgePipe[] allBridgePipeGroups;

		public CrossBridgeConveyer[] allCrossBridgeConveyerGroups;

		public CrossPipe[] allCrossPipeGroups;

		public Teleporter[] allTeleporterGroups;

		public Manhole[] allManholeGroups;

		public Mine[] allMineGroups;

		public Ink[] allInkGroups;

		public Extractor[] allExtractorGroups;

		public Factory.Mech.Canvas[] allCanvasGroups;

		public Cutter[] allCutterGroups;

		public Repainter[] allRepainterGroups;

		public ChuChuHouse[] allChuChuHouseGroups;

		public Statue[] allStatueGroups;

		public MiracleOrb[] allMiracleOrbGroups;

		public MixColor[] allMixColorGroups;

		public Albedo[] allAlbedoGroups;

		public InkChanger[] allInkChangerGroups;

		public InkBottleProcessor[] allInkBottleProcessorGroups;

		public InkBottleReverse[] allInkBottleReverseGroups;

		public ColorCoating[] allColorCoatingGroups;

		public Splitter[] allSplitterGroups;

		public Composite[] allCompositeGroups;

		public Combiner[] allCombinerGroups;

		public InversionPipe[] allInversionPipeGroups;

		public Inserter[] allInserterGroups;

		public TemporaryTable[] allTemporaryTableGroups;

		public Engine[] allEngineGroups;

		public SweetsSupply[] allSweetsSupplyGroups;

		public InkCatcher[] allInkCatcherGroups;

		public SweetsStorage[] allSweetsStorageGroups;

		public InkSprinkler[] allInkSprinklerGroups;

		public RecycleBox[] allRecycleBoxGroups;

		public RecycleFacility[] allRecycleFacilityGroups;

		public Copier[] allCopierGroups;

		public UniqueHeroGenerator[] allUniqueHeroGeneratorGroups;

		public Goal[] allGoalGroups;

		public MineShaft[] allMineShaftGroups;

		public TrashCan[] allTrashCanGroups;

		public AltarOfSpirit[] allAltarOfSpiritGroups;

		public List<(StructureAddr addr, StructureAddr? inAddr, StructureAddr? outAddr)> PreviewedBelts { get; set; }

		public List<PreviewedPipe> PreviewedPipes { get; set; }

		public FactoryMap(Version mapVersion)
		{
		}

		private void UpdateFromStructureList(MapData map, bool checkSpace = false, bool noWarning = false)
		{
		}

		private bool IsValid(StructurePack strPack)
		{
			return false;
		}

		private IEnumerable<Structure> GetAreaStructures(RectInt? targetAddrRect = null)
		{
			return null;
		}

		public List<SerializableStructure> SerializeFactoryMapToStructureList(RectInt? targetAddrRect = null)
		{
			return null;
		}

		public List<SerializableLuggage> SerializeFactoryMapToLuggageList()
		{
			return null;
		}

		public List<SerializableLiquid> SerializeFactoryMapToPipeLiquidList()
		{
			return null;
		}

		public List<SerializableLiquid> SerializeFactoryMapToTankLiquidList()
		{
			return null;
		}

		public List<SerializableStructureContext> SerializeFactoryMapToStructureContextList()
		{
			return null;
		}

		public List<SerializableMechBase> SerializeFactoryMapToMechBaseList()
		{
			return null;
		}

		public List<MapResource> SerializeFactoryMapToResourceList(RectInt? targetAddrRect = null)
		{
			return null;
		}

		private List<eMapExtension> SerializeFactoryMapToMapExtensionList()
		{
			return null;
		}

		public static MapData LoadMapForEditor(string path, out TextAsset asset)
		{
			asset = null;
			return null;
		}

		public static MapData LoadMap(TextAsset mapAsset)
		{
			return null;
		}

		public static MapData LoadMap(string mapAssetText)
		{
			return null;
		}

		public void InitMap(MapData map)
		{
		}

		public void AppendMap(MapData map, MapAsset.ExtraMachine extraPortal, MapAsset.ExtraMachine extraChuChu)
		{
		}

		public bool AppendExtraMachine(eMapExtension area, MapAsset.ExtraMachine extra)
		{
			return false;
		}

		public void AppendMapForTutorial(string mapPath)
		{
		}

		private void UpdatePlayArea(eMapExtension area)
		{
		}

		public void SetTemporaryPlayArea()
		{
		}

		public eMapExtension[] GetMapExtendStatesForEditor()
		{
			return null;
		}

		public static MapContextData LoadMapContextForEditor(string path)
		{
			return null;
		}

		public static MapContextData LoadMapContext(TextAsset mapAsset)
		{
			return null;
		}

		public static MapContextData LoadMapContext(string mapContextJson)
		{
			return null;
		}

		public void RestoreMapContext(MapContextData mapContextData)
		{
		}

		public bool CheckExtendArea(eMapExtension area)
		{
			return false;
		}

		public bool IsPlayArea(eMapExtension area)
		{
			return false;
		}

		public List<eMapExtension> GetExtendAreas(eMapExtension area)
		{
			return null;
		}

		public string PrepareSaveMap(eMapExtension mapExtension = eMapExtension.None, bool prettyPrint = false)
		{
			return null;
		}

		[Conditional("UNITY_EDITOR")]
		public void SaveMapForEditor(string path, eMapExtension mapExtension = eMapExtension.None)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public void SaveMapForEditor(string path, bool everyArea)
		{
		}

		public string PrepareSaveMapContext(bool prettyPrint = false)
		{
			return null;
		}

		[Conditional("UNITY_EDITOR")]
		public void SaveMapContextForEditor(string path)
		{
		}

		public void SetStructure(int x, int y, Structure str)
		{
		}

		public void SetStructure(StructureAddr addr, Structure str)
		{
		}

		public void SetStructurePack(RectInt addrRect, StructurePack pack)
		{
		}

		public void SetStructurePack(StructurePack pack)
		{
		}

		private eMachine ClearStructureMono(StructureAddr addr)
		{
			return default(eMachine);
		}

		public (List<StructureAddr>, HashSet<MachineAndGroupID>) ClearStructure(StructureAddr addr)
		{
			return default((List<StructureAddr>, HashSet<MachineAndGroupID>));
		}

		public (List<StructureAddr>, HashSet<MachineAndGroupID>) ClearStructure(RectInt addrRect)
		{
			return default((List<StructureAddr>, HashSet<MachineAndGroupID>));
		}

		public (List<StructureAddr>, HashSet<MachineAndGroupID>) ClearStructure(StructurePack strPack)
		{
			return default((List<StructureAddr>, HashSet<MachineAndGroupID>));
		}

		public void ClearAllStructures()
		{
		}

		public Structure GetStructure(StructureAddr addr)
		{
			return null;
		}

		public ILiquidCarrier GetTank(StructureAddr tankAddr, StructureAddr mechAddr, int? streamLayer)
		{
			return null;
		}

		public List<ILiquidCarrier> GetAllTanksForSerialize()
		{
			return null;
		}

		public MechBase GetMechBase(StructureAddr mechAddr)
		{
			return null;
		}

		public Structure GetStructure(int x, int y)
		{
			return null;
		}

		private Structure[] GetStructures(RectInt addrRect)
		{
			return null;
		}

		public Structure[] GetStructures(List<StructureAddr> strAddrs)
		{
			return null;
		}

		private IEnumerable<Structure> GetAllStructures()
		{
			return null;
		}

		public Span<Structure> GetAllStructuresAsSpan()
		{
			return default(Span<Structure>);
		}

		private IEnumerable<Structure> GetAllStructuresForUpdateCircuitData(bool init = false)
		{
			return null;
		}

		public MachineInformation GetMachineInformation(Vector2Int addr)
		{
			return null;
		}

		public (StructureGroupID, MechBase)? GetMachineInformationMinimum(Vector2Int addr)
		{
			return null;
		}

		public eMachine GetMapMachineID(Vector2Int addr)
		{
			return default(eMachine);
		}

		public (StructureGroupID, eMachine)? GetMapMachineIdAndGroupId(Vector2Int addr)
		{
			return null;
		}

		public int GetMinionCost()
		{
			return 0;
		}

		public int CountAllMinion()
		{
			return 0;
		}

		public int CountStructures(eMachine machineId)
		{
			return 0;
		}

		public int CountTypicalStructures(eMachine machineId)
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

		public bool CheckStructureUnbreakable(Structure str)
		{
			return false;
		}

		public bool CheckStructuresUnbreakable(Structure[] strs)
		{
			return false;
		}

		public bool CheckStructureByHand(Structure str)
		{
			return false;
		}

		public bool CheckStructureByHand(RectInt addrRect)
		{
			return false;
		}

		public bool CheckStructureByHand(Vector2IntBundle addrRect)
		{
			return false;
		}

		public bool CheckSpace(RectInt addrRect)
		{
			return false;
		}

		public bool CheckSpace(Vector2IntBundle addrRect)
		{
			return false;
		}

		[Obsolete]
		public bool IsOverwritable(eSecondaryMachineCategory overwriteSecondaryMachineCategory, RectInt addrRect)
		{
			return false;
		}

		public bool CheckSpace(StructureAddr strAddr)
		{
			return false;
		}

		public bool CheckSpace(List<StructureAddr> strAddrs)
		{
			return false;
		}

		public bool IsOverwritable(eSecondaryMachineCategory overwriteSecondaryMachineCategory, List<StructureAddr> strAddrs)
		{
			return false;
		}

		public bool IsOverwritable(eSecondaryMachineCategory overwriteSecondaryMachineCategory, Vector2IntBundle addrRect)
		{
			return false;
		}

		public bool CheckNeighborPrimaryCategoryType(Vector2IntBundle addrRect, ePrimaryMachineCategory type)
		{
			return false;
		}

		private void UpdateMapViewMono(StructureAddr addr)
		{
		}

		public void UpdateMapAllView()
		{
		}

		public void UpdateMapView(RectInt addrRect)
		{
		}

		public void UpdateMapView(StructureAddr addr)
		{
		}

		public void UpdateMapView(List<StructureAddr> addrList)
		{
		}

		public void UpdateMapView(StructureAddr[] addrList)
		{
		}

		public IEnumerable<(StructureAddr, StructureAddr)> GetStructuresAroundStructuresWithCenter(IEnumerable<StructureAddr> strs)
		{
			return null;
		}

		public IEnumerable<(StructureAddr, StructureAddr)> GetStructuresAroundStructuresWithCenter2(IEnumerable<StructureAddr> strs)
		{
			return null;
		}

		public IEnumerable<StructureAddr> GetStructuresAroundStructures(IEnumerable<StructureAddr> strs)
		{
			return null;
		}

		public IEnumerable<StructureAddr> GetStructuresAroundStructures2(IEnumerable<StructureAddr> strs)
		{
			return null;
		}

		public IEnumerable<StructureAddr> GetStructuresAroundStructures(RectInt addrRect)
		{
			return null;
		}

		public IEnumerable<StructureAddr> GetStructuresAroundStructures(Vector2IntBundle addrRect)
		{
			return null;
		}

		public IEnumerable<StructureAddr> GetStructuresAroundStructures2(RectInt addrRect)
		{
			return null;
		}

		public IEnumerable<StructureAddr> GetStructuresAroundStructures2(Vector2IntBundle addrRect)
		{
			return null;
		}

		public IEnumerable<(Structure, Structure)> GetStructuresRoundAddresses(IEnumerable<Vector2Int> addrs)
		{
			return null;
		}

		public List<StructureAddr> ApplyPreviewedBelts(bool cancel = false)
		{
			return null;
		}

		public List<StructureAddr> AffectAroundBelts(List<StructureAddr> strAddrs)
		{
			return null;
		}

		public List<StructureAddr> ApplyPreviewedPipes(bool cancel = false)
		{
			return null;
		}

		public List<StructureAddr> AffectAroundPipes(List<StructureAddr> strAddrs, StructureAddr? exceptPipeAddr = null)
		{
			return null;
		}

		public void UpdateCircuitData(bool updateAttachment = false, bool recalcStream = false)
		{
		}

		private bool ContainsRect(RectInt rect, MechBase mb)
		{
			return false;
		}

		private TMb GetOrNewMechBase<TMb>(Func<Structure[], TMb> func, Structure[] strs) where TMb : MechBase
		{
			return null;
		}
	}
}
