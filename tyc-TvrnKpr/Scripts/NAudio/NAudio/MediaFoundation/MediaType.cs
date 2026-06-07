using System;
using NAudio.Wave;

namespace NAudio.MediaFoundation
{
	public class MediaType
	{
		private readonly IMFMediaType mediaType;

		public int SampleRate
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int ChannelCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int BitsPerSample
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int AverageBytesPerSecond => 0;

		public Guid SubType
		{
			get
			{
				return default(Guid);
			}
			set
			{
			}
		}

		public Guid MajorType
		{
			get
			{
				return default(Guid);
			}
			set
			{
			}
		}

		public IMFMediaType MediaFoundationObject => null;

		public MediaType(IMFMediaType mediaType)
		{
		}

		public MediaType()
		{
		}

		public MediaType(WaveFormat waveFormat)
		{
		}

		private int GetUInt32(Guid key)
		{
			return 0;
		}

		private Guid GetGuid(Guid key)
		{
			return default(Guid);
		}

		public int TryGetUInt32(Guid key, int defaultValue = -1)
		{
			return 0;
		}
	}
}
