namespace Gh.Tk
{
	public class PanickedTrait : ActorTrait
	{
		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _wasRunning;

		protected PanickedTrait()
		{
		}

		public PanickedTrait(Actor owner)
		{
		}

		public override void OnRemoving()
		{
		}
	}
}
