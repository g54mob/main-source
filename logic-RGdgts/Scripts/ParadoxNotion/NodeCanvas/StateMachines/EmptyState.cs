namespace NodeCanvas.StateMachines
{
	public class EmptyState : FSMState
	{
		public override string name => null;

		protected override void OnEnter()
		{
		}
	}
}
