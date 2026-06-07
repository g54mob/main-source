namespace Gh.Tk
{
	public abstract class CritterJob : ActorJob
	{
		public new Critter Owner
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected CritterJob()
		{
		}

		protected CritterJob(GameObjectX source, GameObjectX target = null, ActorBehaviour behaviour = null, string usageKeyOverride = null, int priority = 0)
		{
		}
	}
}
