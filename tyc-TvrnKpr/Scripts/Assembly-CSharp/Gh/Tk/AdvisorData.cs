namespace Gh.Tk
{
	public class AdvisorData : NarratorData
	{
		[PersistenceOptIn]
		public float DisplaySeconds { get; set; }

		[PersistenceOptIn]
		public AdvisorState AdvisorState { get; set; }

		[PersistenceOptIn]
		public int CameraEventId { get; set; }

		[PersistenceOptIn]
		public string EventId { get; set; }
	}
}
