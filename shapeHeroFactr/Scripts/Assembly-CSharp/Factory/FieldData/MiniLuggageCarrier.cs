using Factory.FieldObject;
using Factory.Mech;
using Models;
using UnityEngine;

namespace Factory.FieldData
{
	public class MiniLuggageCarrier : ILuggageCarrier, IBlendMaterial
	{
		public StructureAddr? OutputToAddr;

		public StructureAddr GetAddr { get; }

		public Luggage Luggage { get; set; }

		public double LuggageRate { get; set; }

		public int LuggageCount { get; set; }

		public int LuggageOmakeCount { get; set; }

		public double CreateTime { get; set; }

		public double LoadingTime { get; set; }

		public bool IsLuggageGoal => false;

		public Vector2 FromVector => default(Vector2);

		public Vector2 ToVector => default(Vector2);

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

		public bool IsPushBacked { get; set; }

		public double CarHornLevel { get; set; }

		public double UpdateLuggageSpeedForDebug { get; set; }

		public MechBase ParentMech { get; set; }

		public bool ComeFromInserter { get; set; }

		public eLuggage HasLuggageId => default(eLuggage);

		private eLuggage OutputProduct { get; set; }

		public bool IsLuggageGoalAndIsEmptyNext(ILuggageCarrier next)
		{
			return false;
		}

		public void InfectionCarHornLevel(ILuggageCarrier from)
		{
		}

		public MiniLuggageCarrier(StructureAddr pseudoAddr, MechBase parentMech)
		{
		}

		public static MiniLuggageCarrier[] CreateArray(StructureAddr[] addrs, int count, MechBase baseMech)
		{
			return null;
		}

		public static MiniLuggageCarrier[] CreateArray(StructureAddr[] addrs, StructureAddr[] toAddrs, int count, MechBase baseMech)
		{
			return null;
		}

		public void Vanish()
		{
		}

		public void RemoveLuggage(bool force = false, bool exceptInserter = false)
		{
		}

		public void ChangePipeTileVariations(eLuggage ink, bool ignoreMechBase = true)
		{
		}

		public bool HasOutputProduct()
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

		public bool SetOutputProductFromLuggage(bool addManufacture = true)
		{
			return false;
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

		public bool IsLuggageFlag(LuggageFlag deflated)
		{
			return false;
		}
	}
}
