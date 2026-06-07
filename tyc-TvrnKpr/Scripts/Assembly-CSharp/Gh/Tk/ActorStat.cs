namespace Gh.Tk
{
	public abstract class ActorStat : GameObjectXStat
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new Actor Owner
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		protected ActorStat()
		{
		}

		public ActorStat(Actor owner, string name, string displayNameKey, float startingValue, string meterColor)
		{
		}
	}
}
