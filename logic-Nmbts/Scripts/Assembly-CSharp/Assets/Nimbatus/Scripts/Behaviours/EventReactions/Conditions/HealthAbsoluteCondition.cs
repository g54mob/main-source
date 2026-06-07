using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class HealthAbsoluteCondition : NimbatusCondition
	{
		public bool CustomHealthPool;

		[ShowIf("CustomHealthPool", true)]
		public HealthPool HealthPool;

		public EIntegerCompareType CompareType;

		public float AbsoluteValue;

		protected override void OnInit()
		{
			HealthPool = HealthPool ?? OwnWorldObject.HealthPool;
		}

		public override bool IsTrue()
		{
			return NumberCompare.Compare(HealthPool.CurrentHealth, CompareType, AbsoluteValue);
		}
	}
}
