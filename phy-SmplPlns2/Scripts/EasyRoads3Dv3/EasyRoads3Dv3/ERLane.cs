using System;

namespace EasyRoads3Dv3
{
	[Serializable]
	public struct ERLane
	{
		public float position;

		public ERLaneDirection direction;

		public ERDirectionType turnDirection;

		public ERLaneDirectionOptions TurnOptions;

		public int laneIndex;

		public ERLane(float position, ERLaneDirection direction, int index)
		{
			this.position = position;
			this.direction = direction;
			turnDirection = ERDirectionType.Straight;
			TurnOptions = ERLaneDirectionOptions.AllDirections;
			laneIndex = index;
		}

		public ERLane(ERLane lane)
		{
			position = lane.position;
			direction = lane.direction;
			turnDirection = lane.turnDirection;
			TurnOptions = ERLaneDirectionOptions.AllDirections;
			laneIndex = lane.laneIndex;
		}

		public void Copy(ERLane lane)
		{
			position = lane.position;
			direction = lane.direction;
			turnDirection = lane.turnDirection;
			laneIndex = lane.laneIndex;
		}

		public static ERLaneDirectionOptions ODQQCOOCOQ(bool left, bool right, bool straight)
		{
			if (left && !right && !straight)
			{
				return ERLaneDirectionOptions.Left;
			}
			if (left && right && !straight)
			{
				return ERLaneDirectionOptions.LeftRight;
			}
			if (left && right && straight)
			{
				return ERLaneDirectionOptions.AllDirections;
			}
			if (left && !right && straight)
			{
				return ERLaneDirectionOptions.StraightLeft;
			}
			if (!left && right && !straight)
			{
				return ERLaneDirectionOptions.Right;
			}
			if (!left && right && straight)
			{
				return ERLaneDirectionOptions.StraightRight;
			}
			if (!left && !right && straight)
			{
				return ERLaneDirectionOptions.Straight;
			}
			return ERLaneDirectionOptions.Straight;
		}
	}
}
