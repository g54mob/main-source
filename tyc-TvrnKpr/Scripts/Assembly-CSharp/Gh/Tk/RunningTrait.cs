namespace Gh.Tk
{
	public class RunningTrait : ActorTrait
	{
		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _hadAdrenalin;

		protected RunningTrait()
		{
		}

		public RunningTrait(Actor owner)
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
