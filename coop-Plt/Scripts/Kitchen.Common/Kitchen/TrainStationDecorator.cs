using Kitchen.Layouts;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class TrainStationDecorator : Decorator
	{
		public class DecorationsConfiguration : IDecorationConfiguration
		{
			public Appliance FrontBorder;

			public float BorderSpacing;

			public IDecorator Decorator => new TrainStationDecorator();
		}

		public override bool Decorate(Room room)
		{
			if (Configuration is DecorationsConfiguration decorationsConfiguration)
			{
				Bounds bounds = Blueprint.GetBounds();
				Vector3 frontDoor = Blueprint.GetFrontDoor();
				if (decorationsConfiguration.FrontBorder != null)
				{
					for (float num = bounds.min.x; num <= bounds.max.x; num += decorationsConfiguration.BorderSpacing)
					{
						if (!(Mathf.Abs(num - frontDoor.x) < 0.7f) && Blueprint[(int)num, (int)bounds.min.y].Type != RoomType.Garden)
						{
							NewPiece(decorationsConfiguration.FrontBorder, num, bounds.min.y - 0.5f);
						}
					}
				}
				return true;
			}
			return false;
		}
	}
}
