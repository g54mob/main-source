public class CarGuidsPerTrackId
{
	public string trackId;

	public string[] carGuids;

	public CarGuidsPerTrackId(string trackId, string[] carGuids)
	{
		this.trackId = trackId;
		this.carGuids = carGuids;
	}
}
