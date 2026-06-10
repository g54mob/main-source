using NSMedieval.State;

namespace NSMedieval.CommanderAI.Orders
{
	public class CutPlantOrder : OrderBase
	{
		public readonly PlantMapResourceInstance PlantToChop;

		public CutPlantOrder(PlantMapResourceInstance plantToChop)
		{
			PlantToChop = plantToChop;
		}

		public override bool Equals(OrderBase order)
		{
			if (!(order is CutPlantOrder cutPlantOrder))
			{
				return false;
			}
			return PlantToChop == cutPlantOrder.PlantToChop;
		}

		public override string ToString()
		{
			return string.Format("{0}, Plant to chop: {1},position: {2}", "CutPlantOrder", PlantToChop.BlueprintId, PlantToChop.GridDataPosition);
		}
	}
}
