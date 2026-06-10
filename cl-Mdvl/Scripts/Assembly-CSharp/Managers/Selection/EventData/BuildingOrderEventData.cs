using NSMedieval.Enums;
using NSMedieval.Types;
using UnityEngine;

namespace Managers.Selection.EventData
{
	public class BuildingOrderEventData : OrderEventData
	{
		public BuildingType BuildingTypes { get; private set; }

		public BuildingOrderEventData(float y, Vector2Int minPoint, Vector2Int maxPoint, OrderType orderType, bool affectOnlyOneLayer, BuildingType buildingTypes, OrderAllowType orderAllowType)
			: base(y, minPoint, maxPoint, orderType, affectOnlyOneLayer, orderAllowType)
		{
			BuildingTypes = buildingTypes;
		}

		public BuildingOrderEventData(OrderEventData orderEventData, BuildingType buildingTypes, OrderAllowType orderAllowType)
			: base(orderEventData.Y, orderEventData.MinPoint, orderEventData.MaxPoint, orderEventData.OrderType, orderEventData.AffectOnlyOneLayer, orderAllowType)
		{
			BuildingTypes = buildingTypes;
		}

		public static BuildingOrderEventData Zeros(OrderType orderType, BuildingType buildingTypes, bool affectOnlyOneLayer)
		{
			return new BuildingOrderEventData(OrderEventData.MinusOne(orderType, affectOnlyOneLayer), buildingTypes, OrderAllowType.All);
		}
	}
}
