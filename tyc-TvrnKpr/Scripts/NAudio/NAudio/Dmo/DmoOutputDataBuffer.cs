using System;
using System.Runtime.InteropServices;

namespace NAudio.Dmo
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	public struct DmoOutputDataBuffer : IDisposable
	{
		private IMediaBuffer pBuffer;

		private DmoOutputDataBufferFlags dwStatus;

		private long rtTimestamp;

		private long referenceTimeDuration;

		public IMediaBuffer MediaBuffer
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public int Length => 0;

		public DmoOutputDataBufferFlags StatusFlags
		{
			get
			{
				return default(DmoOutputDataBufferFlags);
			}
			internal set
			{
			}
		}

		public long Timestamp
		{
			get
			{
				return 0L;
			}
			internal set
			{
			}
		}

		public long Duration
		{
			get
			{
				return 0L;
			}
			internal set
			{
			}
		}

		public bool MoreDataAvailable => false;

		public DmoOutputDataBuffer(int maxBufferSize)
		{
			pBuffer = null;
			dwStatus = default(DmoOutputDataBufferFlags);
			rtTimestamp = 0L;
			referenceTimeDuration = 0L;
		}

		public void Dispose()
		{
		}

		public void RetrieveData(byte[] data, int offset)
		{
		}
	}
}
