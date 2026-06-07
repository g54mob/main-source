namespace Gh.Tk
{
	public class AccommodationBehaviour : PatronBehaviour, IAiComponentVisualInfo, IAiComponentIsDoneInfo
	{
		private AccommodationStat _accommodationStat;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public RoomReservation RoomReservation { get; set; }

		[PersistenceOptIn]
		public bool HasGoneToBed { get; set; }

		[PersistenceOptIn]
		public int NightsStayed { get; set; }

		protected AccommodationBehaviour()
		{
		}

		public AccommodationBehaviour(Patron owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}

		public override void Init()
		{
		}

		protected override bool TriggerInternal()
		{
			return false;
		}

		public bool HasBookedRoom()
		{
			return false;
		}
	}
}
