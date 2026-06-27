namespace Restory.Gameplay.Equipment.Ultrasonic.States
{
	public class DisabledUltrasonicState : UltrasonicStateBase
	{
		public DisabledUltrasonicState(UltrasonicStateContext stateContext, UltrasonicStateMachine stateMachine)
			: base(stateContext, stateMachine)
		{
		}

		public override void Enter()
		{
			Subscribe();
		}

		public override void Exit()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			base.SonicBath.OnUltrasonicToolActivated += ResolveUltrasonicToolActivated;
		}

		private void Unsubscribe()
		{
			base.SonicBath.OnUltrasonicToolActivated -= ResolveUltrasonicToolActivated;
		}

		private void ResolveUltrasonicToolActivated()
		{
			base.StateSwitcher.EnterIdleState();
		}
	}
}
