namespace Gh.Tk
{
	public class Table : Prop
	{
		public override bool CanBeUsedForBehaviour(ActorBehaviour behaviour, bool ignoreOpeningHours = false)
		{
			return false;
		}

		public override float RateDesirability(Actor actor, ActorBehaviour behaviour)
		{
			return 0f;
		}

		public override Job UseService(Actor actor, ActorBehaviour behaviour, string usageKeyOverride = null, GameItem item = null, float duration = -1f)
		{
			return null;
		}

		public override void Awake()
		{
		}
	}
}
