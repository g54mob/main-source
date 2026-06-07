using MessagePack;

[MessagePackObject(false)]
public class MetaFileDto
{
	[Key(0)]
	public int Version = 3;

	[Key(1)]
	public long SavedAtUnixSecondsUtc;

	[Key(2)]
	public string StudioName;

	[Key(3)]
	public double PlayTime;

	[Key(4)]
	public int Releases;
}
