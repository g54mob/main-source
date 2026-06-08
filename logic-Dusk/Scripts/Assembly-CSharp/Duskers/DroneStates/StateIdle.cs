namespace Duskers.DroneStates
{
	public class StateIdle : BaseDroneState
	{
		public override string StateId
		{
			get
			{
				return "Idle";
			}
		}

		public StateIdle(DroneBrain brain)
			: base(brain)
		{
		}

		public override void EnterState()
		{
			base.EnterState();
			_brain.ThisDrone.CurrentRawSpeed = 0f;
		}

		public override void ExitState()
		{
			base.ExitState();
		}
	}
}
