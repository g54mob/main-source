using System.Collections.Generic;
using DarkTonic.MasterAudio;

namespace Audio
{
	public class HDRController
	{
		public class HDRData
		{
			public MasterAudioGroup group;

			public int range;

			public int ratio;

			public int attackTime;

			public int holdTime;

			public int releaseTime;

			public float volume;

			public bool mute;

			private HDRData target;

			private float deltaTime;

			private bool _isPlaying;

			private bool _isActive;

			public int elapsedTime => 0;

			public bool isPlaying => false;

			public bool isActive => false;

			public bool isOutOfRange => false;

			public HDRData(MasterAudioGroup group, int range, int ratio, int attackTime, int holdTime, int releaseTime)
			{
			}

			public double GetHDRPercent()
			{
				return 0.0;
			}

			public double GetVolumeReductionRate()
			{
				return 0.0;
			}

			public double GetHDRVolumePercent()
			{
				return 0.0;
			}

			public void Update(float deltaTime)
			{
			}

			public void SetTarget(HDRData target)
			{
			}

			public void Reset()
			{
			}
		}

		private List<HDRData> hdrDatas;

		private int hdrRange;

		private int HDR_RANGE => 0;

		public void Initialize(int hdrRange)
		{
		}

		public void Update()
		{
		}

		public void AddHDRData(MasterAudioGroup group, bool mute = false)
		{
		}

		public void SetMuteAll(bool mute)
		{
		}

		public List<HDRData> GetHDRDatas()
		{
			return null;
		}
	}
}
