namespace Gh.Tk
{
	public class ConfusedTrait : ActorTrait
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameObjectX _source;

		[PersistenceOptIn]
		private ConfusionReason _reason;

		protected ConfusedTrait()
		{
		}

		public ConfusedTrait(Actor owner, GameObjectX source, ConfusionReason reason)
		{
		}

		public override void Init()
		{
		}

		public override void OnRemoving()
		{
		}
	}
}
