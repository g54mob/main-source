using System;

namespace VampireSurvivors.Framework;

public class MusicBeatsEvent
{
	public float startDelayMS;

	public float beatEveryMS = 1000f;

	public float resetDelayMS;

	public Action beatAction;
}
