public struct TrackState
{
	public double reservedLength;

	public double occupiedLength;

	public double freeLength;

	public TrackState(double reservedLength, double occupiedLength, double freeLength)
	{
		this.reservedLength = reservedLength;
		this.occupiedLength = occupiedLength;
		this.freeLength = freeLength;
	}
}
