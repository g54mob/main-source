namespace Gh.Tk
{
	public class EventCamData : NarratorData
	{
		[PersistenceOptIn]
		public string CameraId { get; set; }
	}
}
