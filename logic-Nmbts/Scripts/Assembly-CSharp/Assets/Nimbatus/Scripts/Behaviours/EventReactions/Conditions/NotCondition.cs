namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class NotCondition : NimbatusCondition
	{
		public NimbatusCondition Condition;

		protected override void OnInit()
		{
			base.OnInit();
			Condition.Init(Behaviour, EventReaction, OwnWorldObject);
		}

		public override bool IsTrue()
		{
			return !Condition.IsTrue();
		}
	}
}
