using MessagePack;

[MessagePackObject(false)]
public class SequelStateDto
{
	[Key(0)]
	public string Name = "";

	[Key(1)]
	public BoxArt BoxArt;

	[Key(3)]
	public bool Developing;

	[Key(4)]
	public float Time;

	[Key(5)]
	public float Duration;

	[Key(6)]
	public int Round;

	[Key(7)]
	public double Cost;

	[Key(8)]
	public SequelProgressStateDto Progress = new SequelProgressStateDto();
}
