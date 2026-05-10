namespace CTS.BBT.AI
{
	public sealed class ContextualStateStuck : ContextualState
	{
		public ContextualStateStuck()
			: base(0f)
		{
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();
			if (base.parent is Customer customer)
			{
				customer.CrimeWitness.enabled = false;
			}
		}

		public override void OnStateExit()
		{
			if (base.parent is Customer customer)
			{
				customer.CrimeWitness.enabled = true;
			}
		}
	}
}
