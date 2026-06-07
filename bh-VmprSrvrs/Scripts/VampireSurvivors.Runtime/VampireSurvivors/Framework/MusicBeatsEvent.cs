using System;

namespace VampireSurvivors.Framework
{
	public class MusicBeatsEvent
	{
		public float startDelayMS;

		public float beatEveryMS;

		public float resetDelayMS;

		public Action beatAction;
	}
}
