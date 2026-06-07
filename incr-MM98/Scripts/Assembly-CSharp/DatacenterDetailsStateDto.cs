using MessagePack;

[MessagePackObject(false)]
public class DatacenterDetailsStateDto
{
	[Key(0)]
	public DatacenterState State;

	[Key(1)]
	public int Engineers;

	[Key(2)]
	public float ReprovisionProgress;
}
