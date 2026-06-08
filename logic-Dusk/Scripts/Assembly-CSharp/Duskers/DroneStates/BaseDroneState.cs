namespace Duskers.DroneStates
{
	public abstract class BaseDroneState : IState
	{
		protected DroneBrain _brain;

		public virtual string StateId
		{
			get
			{
				return string.Empty;
			}
		}

		public virtual event ChangeStateDelegate ChangeState;

		public BaseDroneState(DroneBrain brain)
		{
			_brain = brain;
		}

		public virtual void Update()
		{
		}

		public virtual void EnterState()
		{
		}

		public virtual void ExitState()
		{
		}
	}
}
