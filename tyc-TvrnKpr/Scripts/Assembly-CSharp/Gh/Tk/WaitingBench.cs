namespace Gh.Tk
{
	public class WaitingBench : Prop
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		private Actor _lastUsedBy;

		public override void Start()
		{
		}

		private void ActorOnActorDespawned(object sender, EventArgs<Actor> e)
		{
		}

		public override void EndUse(string usageKey, Actor actor)
		{
		}

		public override void BeginUse(string usageKey, Actor actor)
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
