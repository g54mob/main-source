namespace Gh.Tk
{
	public abstract class PropTraitBase : GameObjectXTrait
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

		protected PropTraitBase()
		{
		}

		public PropTraitBase(Prop owner)
		{
		}
	}
}
