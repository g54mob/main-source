namespace Gh.Tk
{
	public class Bar : Prop
	{
		public override Job UseService(Actor actor, ActorBehaviour behaviour, string usageKeyOverride = null, GameItem item = null, float duration = -1f)
		{
			return null;
		}

		public override void OnCustomSetDown(Actor actor, GameItem itemToSetDown, int position)
		{
		}

		public override void Awake()
		{
		}
	}
}
