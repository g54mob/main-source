using MessagePack;

[MessagePackObject(false)]
public class PrestigeStateDto
{
	[Key(0)]
	public double Fans;

	[Key(1)]
	public double LastReleaseFansGain;

	[Key(2)]
	public double Data;

	[Key(3)]
	public double LastReleaseDataGain;
}
