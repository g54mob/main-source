using MessagePack;

[MessagePackObject(false)]
public class GameStateDto
{
	[Key(0)]
	public string Name = "";

	[Key(1)]
	public double Time;

	[Key(2)]
	public bool Launched;

	[Key(3)]
	public BoxArt BoxArt;

	[Key(4)]
	public WorldType World;
}
