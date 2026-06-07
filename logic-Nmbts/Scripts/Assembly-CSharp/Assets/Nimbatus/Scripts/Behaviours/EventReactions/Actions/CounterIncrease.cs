using Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class CounterIncrease : NimbatusAction
	{
		public int Amount;

		private CounterBehaviour _counter;

		protected override void OnInit()
		{
			_counter = Behaviour.GetCoreBehaviour<CounterBehaviour>();
		}

		public override void Execute()
		{
			CounterBehaviour counter = _counter;
			if (counter != null)
			{
				counter.IncreaseCount(Amount);
			}
		}
	}
}
