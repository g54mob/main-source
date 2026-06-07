using DV.Logic.Job;

public class TrackReservation
{
	public readonly Track track;

	public readonly float reservedLength;

	public TrackReservation(Track track, float reservedLength)
	{
		this.track = track;
		this.reservedLength = reservedLength;
	}
}
