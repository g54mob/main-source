using MessagePack;

[MessagePackObject(false)]
public class HistoryEntryDto
{
	[Key(0)]
	public int Release;

	[Key(1)]
	public string Title = "";

	[Key(2)]
	public BoxArt BoxArt;

	[Key(3)]
	public double Money;

	[Key(4)]
	public double Players;

	[Key(5)]
	public double Time;
}
