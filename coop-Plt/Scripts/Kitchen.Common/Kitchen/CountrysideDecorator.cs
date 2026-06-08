using System.Collections.Generic;
using Kitchen.Layouts;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class CountrysideDecorator : Decorator
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

			public bool OnlyDecorateLowerHalf;

			public IDecorator Decorator => new CountrysideDecorator();
		}

		private int PathStartLocation = -20;

		public override bool Decorate(Room room)
		{
			if (Configuration is DecorationsConfiguration decorationsConfiguration)
			{
				Bounds bounds = Blueprint.GetBounds();
				Vector3 frontDoor = Blueprint.GetFrontDoor();
				NewPiece(decorationsConfiguration.Ground, 0f, 0f);
				for (float num = bounds.min.x - 4f; num <= bounds.max.x + 4f; num += 1f)
				{
					foreach (DecorationsConfiguration.Scatter scatter in decorationsConfiguration.Scatters)
					{
						if (Random.value < scatter.Probability)
						{
							NewPiece(scatter.Appliance, num, bounds.min.y - 6f);
						}
						if (!decorationsConfiguration.OnlyDecorateLowerHalf && Random.value < scatter.Probability)
						{
							NewPiece(scatter.Appliance, num, bounds.max.y + 3f);
						}
					}
				}
				for (float num2 = bounds.min.y - 2f; num2 <= bounds.max.y + 2f; num2 += 1f)
				{
					if (decorationsConfiguration.OnlyDecorateLowerHalf && num2 >= 0f)
					{
						continue;
					}
					foreach (DecorationsConfiguration.Scatter scatter2 in decorationsConfiguration.Scatters)
					{
						if (num2 > bounds.min.y && Random.value < scatter2.Probability)
						{
							NewPiece(scatter2.Appliance, bounds.min.x - 3f, num2);
						}
						if (Random.value < scatter2.Probability)
						{
							NewPiece(scatter2.Appliance, bounds.max.x + 4f, num2);
						}
					}
				}
				if (decorationsConfiguration.Cobblestone != null)
				{
					for (float num3 = PathStartLocation; num3 <= frontDoor.x; num3 += 0.8f)
					{
						NewPiece(decorationsConfiguration.Cobblestone, num3, bounds.min.y - 1.2f);
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
				return true;
			}
			return false;
		}
	}
}
