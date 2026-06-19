namespace TH20
{
	public class MonoBeastPanic : MonoBeastNav
	{
		public MonoBeastPanic(MonoBeast beast)
			: base(beast)
		{
		}

		public override void Enter()
		{
			base.Enter();
			MoveToRandomLocation();
		}

		private void MoveToRandomLocation()
		{
			if (RoomAlgorithms.GetRandomFreeTileWithinRadius(_beast.Room.FloorPlan, _beast.Position, _beast.Definition.MaxScamperDistance, out var worldPositionOut))
			{
				MoveTo(worldPositionOut);
			}
		}

		public override void ReachedDestination()
		{
			base.ReachedDestination();
			PopState();
		}

		public override void Update()
		{
			base.Update();
			_beast.PanicTime += GameTime.deltaTime;
			if (_beast.PanicTime >= _beast.Definition.NowhereToHideTime)
			{
				_beast.Level.MonoBeastManager.DestroyBeast(_beast, timedOut: true);
			}
		}
	}
}
