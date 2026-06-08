namespace Duskers.EnemyStates
{
	public class StateGlobalCommon : BaseEnemyState
	{
		public override string StateId
		{
			get
			{
				return "GlobalCommon";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateGlobalCommon(BaseEnemyBrain brain)
			: base(brain)
		{
		}

		public override void Update()
		{
			if ((_brain.ThisEnemy.IsDead || GlobalSettings.GameIsOver) && _brain.CurrentState != "Nil")
			{
				ChangeState(_brain.StateNil);
			}
			else if (_brain.ThisEnemy.IsStunned && _brain.CurrentState != "Stunned")
			{
				_brain.StateStunned.Initialize(GetStunReturnState());
				ChangeState(_brain.StateStunned);
			}
		}

		public override void EnterState()
		{
		}

		public override void ExitState()
		{
		}

		public virtual IState GetStunReturnState()
		{
			return _brain.StatePatrol;
		}
	}
}
