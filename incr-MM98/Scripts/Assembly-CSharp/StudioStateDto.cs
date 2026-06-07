using System;
using MessagePack;

[MessagePackObject(false)]
public class StudioStateDto
{
	[Key(0)]
	public string Name = "";

	[Key(1)]
	public double Time;

	[Key(2)]
	public bool Tutorial;

	[Key(3)]
	public bool Paused;

	[Key(4)]
	public EndingState Ending;

	[Key(5)]
	public DateTime EndingAchieved;
}
