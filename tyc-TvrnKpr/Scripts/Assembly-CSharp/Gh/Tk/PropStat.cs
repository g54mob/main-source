namespace Gh.Tk
{
	public abstract class PropStat : GameObjectXStat
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new Prop Owner
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		protected PropStat()
		{
		}

		public PropStat(Prop owner, string name, string displayNameKey, float startingValue, string meterColor)
		{
		}
	}
}
