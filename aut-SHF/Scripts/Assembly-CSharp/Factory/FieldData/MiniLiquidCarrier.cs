using System.Collections.Generic;
using Factory.FieldObject;
using Factory.Mech;
using Models;
using UnityEngine;

namespace Factory.FieldData
{
	public class MiniLiquidCarrier : ILiquidCarrier, IBlendMaterial
	{
		private FactoryMap _factoryMap;

		private FactoryMap factoryMap => null;

		public StructureAddr TankAddr { get; private set; }

		public bool InternalTank { get; }

		public StructureAddr? MechAddr => null;

		public int? StreamLayer { get; }

		public Liquid Liquid { get; set; }

		public double LiquidCapacity { get; set; }

		public double LiquidCreateTime { get; set; }

		public double LoadingTime { get; set; }

		public Vector2Int[] PipeAddrs { get; private set; }

		public List<Vector2Int> PipeFromAddrList { get; private set; }

		public Vector2Int PipeFromAddrFirst { get; private set; }

		public Vector2Int[] PipeFromAddrs { get; private set; }

		public List<Vector2Int> PipeToAddrList { get; private set; }

		public Vector2Int PipeToAddrFirst { get; private set; }

		public Vector2Int[] PipeToAddrs { get; private set; }

		public MechBase ParentMech { get; set; }

		public Structure ParentStructure { get; private set; }

		public eLuggage HasLiquidId => default(eLuggage);

		public double LiquidMeasure => 0.0;

		public eLuggage HasLuggageId => default(eLuggage);

		public MiniLiquidCarrier(Structure baseStr, MechBase parentMech)
		{
		}

		public MiniLiquidCarrier(MechBase baseMech)
		{
		}

		public MiniLiquidCarrier(StructureAddr? pseudoAddr, MechBase parentMech, Structure initStructure = null, int? streamLayer = null)
		{
		}

		private void InitAddrData(Structure parentStructure)
		{
		}

		private void InitAddrData(StructureAddr? pseudoAddr, Structure initStructure)
		{
		}

		public void RefreshData(Structure parentStructure)
		{
		}

		private void UpdatePipePortAddrs(Structure initStructure, int? streamLayer)
		{
		}

		public static MiniLiquidCarrier[] CreateArray(int count, MechBase baseMech)
		{
			return null;
		}

		public static MiniLiquidCarrier[] CreateArray(Structure[] baseStrs, int count, MechBase baseMech)
		{
			return null;
		}

		public void Vanish()
		{
		}

		private void RemoveAllLiquidLiquidLink()
		{
		}

		public void RemoveLiquid()
		{
		}

		public void ChangePipeTileVariations(eLuggage ink, bool ignoreMechBase = true)
		{
		}

		public void DisconnectFromPipesOfSpecificColor(eLuggage specificColor, Vector2Int? exceptAddr = null)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public string ToStringLiquid()
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

		public bool IsLuggageFlag(LuggageFlag deflated)
		{
			return false;
		}

		public void RecordJamInkLog(LiquidFeedResult feedResult)
		{
		}

		public void UpdateJamInkIcon()
		{
		}

		public void UpdateJamInkOutIcon()
		{
		}
	}
}
