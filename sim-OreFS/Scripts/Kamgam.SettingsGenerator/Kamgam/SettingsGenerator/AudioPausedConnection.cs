using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class AudioPausedConnection : Connection<bool>
	{
		public bool Invert;

		public AudioPausedConnection(bool invert = true)
		{
			Invert = invert;
		}

		public override bool Get()
		{
			if (!Invert)
			{
				return AudioListener.pause;
			}
			return !AudioListener.pause;
		}

		public override void Set(bool pause)
		{
			AudioListener.pause = (Invert ? (!pause) : pause);
		}
	}
}
