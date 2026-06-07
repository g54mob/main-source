namespace Motorways.Views
{
	public class TileViewNode
	{
		public RoadState roadState;

		public bool isDynamic;

		public DeadEndRoadView deadEndRoad;

		public bool isDeadEndConnectedToMotorway;

		public bool isDeadEndConnectedToEditingMotorway;

		public void Reset()
		{
			roadState = RoadState.None;
			isDynamic = false;
			deadEndRoad = null;
			isDeadEndConnectedToMotorway = false;
			isDeadEndConnectedToEditingMotorway = false;
		}
	}
}
