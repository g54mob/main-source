namespace Gh.Tk
{
	public class RoomReservation : GameItem
	{
		public int amountPaid;

		[PersistenceObjectReference]
		public Bed TargetBed { get; set; }

		[PersistenceObjectReference]
		public GameItem Key { get; set; }

		[PersistenceObjectReference]
		public Patron Patron { get; set; }

		private RoomReservation()
		{
		}

		public RoomReservation(GameItemTemplate template, bool representsTemplate = false)
		{
		}
	}
}
