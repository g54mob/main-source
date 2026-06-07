namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class AndCondition : NimbatusCondition
	{
		public NimbatusCondition A;

		public NimbatusCondition B;

		protected override void OnInit()
		{
			base.OnInit();
			A.Init(Behaviour, EventReaction, OwnWorldObject);
			B.Init(Behaviour, EventReaction, OwnWorldObject);
		}

		public override bool IsTrue()
		{
			if (A.IsTrue())
			{
				return B.IsTrue();
			}
			return false;
		}
	}
}
