using NSMedieval.BuildingComponents;

namespace NSMedieval.CommanderAI.Orders
{
	public class ConstructBuildingOrder : OrderBase
	{
		public readonly string BlueprintId;

		public readonly Vec3Int Position;

		public readonly int YAngle;

		public readonly bool IsSiegeWeapon;

		public ConstructBuildingOrder(string blueprintId, Vec3Int position, int yAngle, bool isSiegeWeapon)
		{
			BlueprintId = blueprintId;
			Position = position;
			YAngle = yAngle;
			IsSiegeWeapon = isSiegeWeapon;
		}

		public override bool Equals(OrderBase order)
		{
			if (!(order is ConstructBuildingOrder constructBuildingOrder))
			{
				return false;
			}
			if (BlueprintId == constructBuildingOrder.BlueprintId && Position == constructBuildingOrder.Position && YAngle == constructBuildingOrder.YAngle)
			{
				return IsSiegeWeapon == constructBuildingOrder.IsSiegeWeapon;
			}
			return false;
		}

		public override string ToString()
		{
			return string.Format("{0}, {1}: {2}, {3}: {4}, {5}: {6}", "ConstructBuildingOrder", "BlueprintId", BlueprintId, "Position", Position, "YAngle", YAngle);
		}

		public bool IsForBuilding(BaseBuildingInstance building)
		{
			if (BlueprintId == building.BlueprintId)
			{
				return Position == building.GridDataPosition;
			}
			return false;
		}
	}
}
