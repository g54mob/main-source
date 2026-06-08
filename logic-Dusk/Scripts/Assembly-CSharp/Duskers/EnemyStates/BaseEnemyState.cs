namespace Duskers.EnemyStates
{
	public abstract class BaseEnemyState : IState
	{
		protected BaseEnemyBrain _brain;

		public virtual string StateId
		{
			get
			{
				return string.Empty;
			}
		}

		public virtual event ChangeStateDelegate ChangeState;

		public BaseEnemyState(BaseEnemyBrain brain)
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
