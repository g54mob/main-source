using Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnCounterChanged : NimbatusEvent
	{
		private CounterBehaviour _counter;

		protected override void Subscribe()
		{
			_counter = Behaviour.GetCoreBehaviour<CounterBehaviour>();
			_counter.OnCountChanged += CountChanged;
		}

		private void CountChanged()
		{
			RaiseEvent();
		}

		protected override void Unsubscribe()
		{
			_counter.OnCountChanged -= CountChanged;
		}
	}
}
