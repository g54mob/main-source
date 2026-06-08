using System.Collections.Generic;
using Kitchen.Layouts;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class WitchDecorator : Decorator
	{
		public class DecorationsConfiguration : IDecorationConfiguration
		{
			public struct Scatter
			{
				public float Probability;

				public Appliance Appliance;
			}

			public List<Scatter> Scatters;

			public Appliance Cobblestone;

			public Appliance FrontBorder;

			public float BorderSpacing;

			public Appliance Ground;

			public bool HasRiver;

			public List<Appliance> DecorOverrides = new List<Appliance>();

			public IDecorator Decorator => new WitchDecorator();
		}

		private int PathStartLocation = -20;

		public override bool Decorate(Room room)
		{
			if (Configuration is DecorationsConfiguration decorationsConfiguration)
			{
				Bounds bounds = Blueprint.GetBounds();
				Vector3 frontDoor = Blueprint.GetFrontDoor();
				NewPiece(decorationsConfiguration.Ground, bounds.min.x, bounds.min.y);
				Bounds bounds2 = bounds;
				bounds2.Expand(new Vector3(16f, 4f));
				Bounds bounds3 = bounds;
				bounds3.Expand(new Vector3(2f, 2f));
				bounds3.Encapsulate(new Vector3(bounds.center.x, bounds.min.y - 10f));
				Bounds bounds4 = new Bounds(new Vector3(frontDoor.x, bounds.min.y - 1.2f, 0f), new Vector3(3f, 3f, 3f));
				bounds4.Encapsulate(new Vector3(PathStartLocation, bounds.min.y - 1.2f));
				for (float num = bounds2.min.x; num <= bounds2.max.x; num += 1f)
				{
					for (float num2 = bounds2.min.y; num2 <= bounds2.max.y; num2 += 1f)
					{
						if ((decorationsConfiguration.HasRiver && num < bounds.min.x) || bounds3.Contains(new Vector3(num, num2)) || bounds4.Contains(new Vector3(num, num2)))
						{
							continue;
						}
						foreach (DecorationsConfiguration.Scatter scatter in decorationsConfiguration.Scatters)
						{
							if (Random.value < scatter.Probability)
							{
								NewPiece(scatter.Appliance, num, num2);
							}
						}
					}
				}
				if (decorationsConfiguration.Cobblestone != null)
				{
					for (float num3 = PathStartLocation; num3 <= bounds.max.x; num3 += 0.8f)
					{
						NewPiece(decorationsConfiguration.Cobblestone, num3, bounds.min.y - 1.2f);
						NewPiece(decorationsConfiguration.Cobblestone, num3, bounds.min.y - 2.2f);
					}
				}
				if (decorationsConfiguration.FrontBorder != null)
				{
					for (float num4 = bounds.min.x; num4 <= bounds.max.x; num4 += decorationsConfiguration.BorderSpacing)
					{
						if (!(Mathf.Abs(num4 - frontDoor.x) < 0.7f) && Blueprint[(int)num4, (int)bounds.min.y].Type != RoomType.Garden)
						{
							NewPiece(decorationsConfiguration.FrontBorder, num4, bounds.min.y - 0.7f);
						}
					}
				}
				for (float num5 = bounds.min.x - 1f; num5 <= bounds.max.x + 1f; num5 += 1f)
				{
					NewPiece(AssetReference.OutdoorMovementBlocker, num5, bounds.min.y - 3f);
				}
				Vector3 nameplateTile = Decorator.GetNameplateTile(frontDoor);
				NewPiece(AssetReference.Nameplate, nameplateTile.x, nameplateTile.z);
				NewPiece(AssetReference.OutdoorMovementBlocker, bounds.min.x - 1f, bounds.min.y - 1f);
				NewPiece(AssetReference.OutdoorMovementBlocker, bounds.min.x - 1f, bounds.min.y - 2f);
				NewPiece(AssetReference.OutdoorMovementBlocker, bounds.max.x + 1f, bounds.min.y - 1f);
				NewPiece(AssetReference.OutdoorMovementBlocker, bounds.max.x + 1f, bounds.min.y - 2f);
				NewPiece(Profile.ExternalBin, frontDoor.x, frontDoor.z - 3f);
				foreach (Appliance decorOverride in decorationsConfiguration.DecorOverrides)
				{
					NewPiece(decorOverride.ID, 100f, 0f);
				}
				return true;
			}
			return false;
		}
	}
}
