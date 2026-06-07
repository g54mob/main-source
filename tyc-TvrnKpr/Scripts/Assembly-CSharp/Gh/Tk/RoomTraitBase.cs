namespace Gh.Tk
{
	public class RoomTraitBase : GameObjectXTrait
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new Room Owner
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		protected RoomTraitBase()
		{
		}

		public RoomTraitBase(Room owner)
		{
		}
	}
}
