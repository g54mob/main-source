using Kitchen.Layouts;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class StreetDecorator : Decorator
	{
		public class DecorationsConfiguration : IDecorationConfiguration
		{
			public Appliance StreetPiece;

			public Appliance WallPiece;

			public Appliance InternalWallPiece;

			public IDecorator Decorator => new StreetDecorator();
		}

		private int MinPlacementPos = -20;

		private int MaxPlacementPos = 20;

		public override bool Decorate(Room room)
		{
			if (Configuration is DecorationsConfiguration decorationsConfiguration)
			{
				Bounds bounds = Blueprint.GetBounds();
				Vector3 frontDoor = Blueprint.GetFrontDoor();
				for (int i = MinPlacementPos; i < MaxPlacementPos; i += 2)
				{
					NewPiece(decorationsConfiguration.StreetPiece, i, bounds.min.y - 1.5f);
				}
				for (float num = bounds.min.x - 1.5f; num > (float)MinPlacementPos; num -= 2f)
				{
					NewPiece(decorationsConfiguration.WallPiece, num, bounds.min.y - 0.5f);
					NewPiece(decorationsConfiguration.InternalWallPiece, num, bounds.min.y - 0.5f);
				}
				for (float num2 = bounds.max.x + 1.5f; num2 < (float)MaxPlacementPos; num2 += 2f)
				{
					NewPiece(decorationsConfiguration.WallPiece, num2, bounds.min.y - 0.5f);
					NewPiece(decorationsConfiguration.InternalWallPiece, num2, bounds.min.y - 0.5f);
				}
				for (float num3 = bounds.min.x - 1f; num3 <= bounds.max.x + 1f; num3 += 2f)
				{
					NewPiece(decorationsConfiguration.InternalWallPiece, num3, bounds.max.y + 0.65f);
				}
				for (float num4 = bounds.min.x - 1f; num4 <= bounds.max.x + 1f; num4 += 1f)
				{
					NewPiece(AssetReference.OutdoorMovementBlocker, num4, bounds.min.y - 3f);
				}
				Vector3 nameplateTile = Decorator.GetNameplateTile(frontDoor);
				NewPiece(AssetReference.Nameplate, nameplateTile.x, nameplateTile.z);
				NewPiece(AssetReference.OutdoorMovementBlocker, bounds.min.x - 1f, bounds.min.y - 1f);
				NewPiece(AssetReference.OutdoorMovementBlocker, bounds.min.x - 1f, bounds.min.y - 2f);
				NewPiece(AssetReference.OutdoorMovementBlocker, bounds.max.x + 1f, bounds.min.y - 1f);
				NewPiece(AssetReference.OutdoorMovementBlocker, bounds.max.x + 1f, bounds.min.y - 2f);
				NewPiece(Profile.ExternalBin, frontDoor.x, frontDoor.z - 3f);
				return true;
			}
			return false;
		}
	}
}
