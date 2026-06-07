using Factory.FieldObject;
using Models;

namespace Factory.FieldData
{
	public interface ILiquidCarrier
	{
		StructureAddr TankAddr { get; }

		StructureAddr? MechAddr { get; }

		int? StreamLayer { get; }

		Liquid Liquid { get; set; }

		eLuggage HasLiquidId { get; }

		double LiquidCapacity { get; set; }

		double LiquidCreateTime { get; set; }

		void Vanish();

		void RemoveLiquid();

		void ChangePipeTileVariations(eLuggage ink, bool ignoreMechBase = true);

		string ToMinimum();

		string ToMinimumWithID();

		string ToStringLiquid();
	}
}
