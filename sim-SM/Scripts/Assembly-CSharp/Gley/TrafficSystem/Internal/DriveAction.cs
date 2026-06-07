namespace Gley.TrafficSystem.Internal
{
	internal readonly struct DriveAction
	{
		private readonly DriveActions _actionType;

		private readonly RoadSide _side;

		internal RoadSide Side => default(RoadSide);

		internal DriveActions ActionType => default(DriveActions);

		public DriveAction(DriveActions actionType, RoadSide side)
		{
			_actionType = default(DriveActions);
			_side = default(RoadSide);
		}
	}
}
