namespace Gh.Tk
{
	public abstract class ActorTrait : GameObjectXTrait
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

		protected ActorTrait()
		{
		}

		public ActorTrait(Actor owner, bool canOwnerBeNull = false, bool expectCodexTooltip = true)
		{
		}

		public void FlashTraitIcon(GameObjectX target = null, float secondsToShow = 3.5f, string backer = "none")
		{
		}
	}
}
