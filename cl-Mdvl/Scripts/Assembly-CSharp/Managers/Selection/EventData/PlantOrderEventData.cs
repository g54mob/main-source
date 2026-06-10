using NSMedieval.Model;
using NSMedieval.Types;
using UnityEngine;

namespace Managers.Selection.EventData
{
	public class PlantOrderEventData : OrderEventData
	{
		public PlantLifePhaseType PlantLifePhase { get; private set; }

		public PlantOrderEventData(float y, Vector2Int minPoint, Vector2Int maxPoint, OrderType orderType, bool affectOnlyOneLayer, PlantLifePhaseType plantLifePhase, OrderAllowType orderAllowType)
			: base(y, minPoint, maxPoint, orderType, affectOnlyOneLayer, orderAllowType)
		{
			PlantLifePhase = plantLifePhase;
		}

		public PlantOrderEventData(OrderEventData orderEventData, PlantLifePhaseType plantLifePhase, OrderAllowType orderAllowType)
			: base(orderEventData.Y, orderEventData.MinPoint, orderEventData.MaxPoint, orderEventData.OrderType, orderEventData.AffectOnlyOneLayer, orderAllowType)
		{
			PlantLifePhase = plantLifePhase;
		}

		public static PlantOrderEventData Zeros(OrderType orderType, PlantLifePhaseType plantLifePhase, bool affectOnlyOneLayer)
		{
			return new PlantOrderEventData(OrderEventData.MinusOne(orderType, affectOnlyOneLayer), plantLifePhase, OrderAllowType.All);
		}
	}
}
