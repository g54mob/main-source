using Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours;
using Assets.Nimbatus.Scripts.Common.Helpers;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class CheckCounterCondition : NimbatusCondition
	{
		public EIntegerCompareType CompareType;

		public int Value;

		private CounterBehaviour _counter;

		protected override void OnInit()
		{
			_counter = Behaviour.GetCoreBehaviour<CounterBehaviour>();
		}

		public override bool IsTrue()
		{
			return NumberCompare.Compare(_counter.GetCount(), CompareType, Value);
		}
	}
}
