using NSMedieval.Types;
using UnityEngine;

namespace Managers.Selection.EventData
{
	public class OrderEventData
	{
		public float Y { get; private set; }

		public Vector2Int MinPoint { get; private set; }

		public Vector2Int MaxPoint { get; private set; }

		public OrderType OrderType { get; private set; }

		public bool AffectOnlyOneLayer { get; private set; }

		public OrderAllowType OrderAllowType { get; private set; }

		public OrderEventData(float y, Vector2Int minPoint, Vector2Int maxPoint, OrderType orderType, bool affectOnlyOneLayer, OrderAllowType orderAllowType = OrderAllowType.All)
		{
			Y = y;
			MinPoint = minPoint;
			MaxPoint = maxPoint;
			OrderType = orderType;
			AffectOnlyOneLayer = affectOnlyOneLayer;
			OrderAllowType = orderAllowType;
		}

		public static OrderEventData MinusOne(OrderType orderType, bool affectOnlyOneLayer)
		{
			return new OrderEventData(-1f, Vector2Int.left, Vector2Int.left, orderType, affectOnlyOneLayer);
		}
	}
}
