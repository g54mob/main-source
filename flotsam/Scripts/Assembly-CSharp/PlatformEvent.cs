using System;

public class PlatformEvent : GameEvent
{
	[Flags]
	public enum Platforms
	{
		None = 0,
		Steam = 1,
		XboxOne = 2,
		Switch = 4
	}

	protected PlatformEvent(GameEventType type)
		: base(type)
	{
	}
}
