using System;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class SimpleAudioVolume : IDisposable
	{
		private readonly ISimpleAudioVolume simpleAudioVolume;

		public float Volume
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool Mute
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal SimpleAudioVolume(ISimpleAudioVolume realSimpleVolume)
		{
		}

		public void Dispose()
		{
		}

		~SimpleAudioVolume()
		{
		}
	}
}
