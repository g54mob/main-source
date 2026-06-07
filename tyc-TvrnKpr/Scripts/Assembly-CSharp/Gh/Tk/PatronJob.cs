namespace Gh.Tk
{
	public abstract class PatronJob : ActorJob
	{
		public new Patron Owner
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected PatronJob()
		{
		}

		protected PatronJob(GameObjectX source, GameObjectX target = null, ActorBehaviour behaviour = null, string usageKeyOverride = null)
		{
		}

		internal override void ForceCompleteReset(bool removeOwner = true, bool forceDestroy = false)
		{
		}
	}
}
