using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class DualRingReportBuffer : IDisposable
	{
		private readonly int NsXnNTBKkhclPUnqdcpVWRAaJHx;

		private readonly int LmkTbrFqttHkVpQnDupyAyOlTpy;

		private readonly int MMtszkOkeijIyABqQsiytdjOMBM;

		private NativeRingBuffer UsxtKMpXeRLDfsnvzAxEWRdTuly;

		private NativeRingBuffer vbWUbUjzbMNIVIAwAjDTnqunaBN;

		private byte[] tcRYqIVzRioDPOjcOICsGZIjlmCm;

		private byte[] uysmVyZltixLtdbkOnVGMGzlkyF;

		private int ZjzYEXVVHSYfNafeaECSEZbcqOL;

		private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

		public int BufferLength => NsXnNTBKkhclPUnqdcpVWRAaJHx;

		public int BytesInBuffer => vbWUbUjzbMNIVIAwAjDTnqunaBN.BytesInBuffer;

		public int EntriesInBuffer => vbWUbUjzbMNIVIAwAjDTnqunaBN.BytesInBuffer / LmkTbrFqttHkVpQnDupyAyOlTpy;

		public byte[] ReadBuffer => uysmVyZltixLtdbkOnVGMGzlkyF;

		public int LastNumBytesRead => ZjzYEXVVHSYfNafeaECSEZbcqOL;

		public DualRingReportBuffer(int entryByteLength, int entryCapacity)
		{
			if (entryByteLength <= 0)
			{
				throw new ArgumentOutOfRangeException("entryByteLength must be > 0.");
			}
			if (entryCapacity < 1)
			{
				throw new ArgumentOutOfRangeException("entryCapacity must be >= 1.");
			}
			LmkTbrFqttHkVpQnDupyAyOlTpy = entryByteLength;
			MMtszkOkeijIyABqQsiytdjOMBM = entryCapacity;
			NsXnNTBKkhclPUnqdcpVWRAaJHx = entryByteLength * entryCapacity;
			UsxtKMpXeRLDfsnvzAxEWRdTuly = new NativeRingBuffer(NsXnNTBKkhclPUnqdcpVWRAaJHx);
			vbWUbUjzbMNIVIAwAjDTnqunaBN = new NativeRingBuffer(NsXnNTBKkhclPUnqdcpVWRAaJHx);
			tcRYqIVzRioDPOjcOICsGZIjlmCm = new byte[entryByteLength];
			uysmVyZltixLtdbkOnVGMGzlkyF = new byte[entryByteLength];
		}

		public int StartRead()
		{
			ENPyMqCAmWcuJGuQuHmWpgOtUOi();
			return vbWUbUjzbMNIVIAwAjDTnqunaBN.BytesInBuffer;
		}

		public int Read()
		{
			int num = 0;
			lock (vbWUbUjzbMNIVIAwAjDTnqunaBN)
			{
				num = vbWUbUjzbMNIVIAwAjDTnqunaBN.Read(uysmVyZltixLtdbkOnVGMGzlkyF, LmkTbrFqttHkVpQnDupyAyOlTpy);
			}
			ZjzYEXVVHSYfNafeaECSEZbcqOL = num;
			return num;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (numBytesToRead < 0 || numBytesToRead > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite");
			}
			int num = 0;
			lock (vbWUbUjzbMNIVIAwAjDTnqunaBN)
			{
				num = vbWUbUjzbMNIVIAwAjDTnqunaBN.Read(buffer, numBytesToRead);
			}
			ZjzYEXVVHSYfNafeaECSEZbcqOL = num;
			return num;
		}

		public int Read(IntPtr buffer, int bufferLength, int numBytesToRead)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			if (bufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferLength");
			}
			if (numBytesToRead < 0 || numBytesToRead > bufferLength)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite");
			}
			int num = 0;
			lock (vbWUbUjzbMNIVIAwAjDTnqunaBN)
			{
				num = vbWUbUjzbMNIVIAwAjDTnqunaBN.Read(buffer, bufferLength, bufferLength);
			}
			ZjzYEXVVHSYfNafeaECSEZbcqOL = num;
			return num;
		}

		public int Write(byte[] buffer, int numBytesToWrite)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (numBytesToWrite < 0 || numBytesToWrite > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite");
			}
			int num = 0;
			lock (UsxtKMpXeRLDfsnvzAxEWRdTuly)
			{
				return UsxtKMpXeRLDfsnvzAxEWRdTuly.Write(buffer, numBytesToWrite);
			}
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			if (bufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferLength");
			}
			if (numBytesToWrite < 0 || numBytesToWrite > bufferLength)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite");
			}
			int num = 0;
			lock (UsxtKMpXeRLDfsnvzAxEWRdTuly)
			{
				return UsxtKMpXeRLDfsnvzAxEWRdTuly.Write(buffer, bufferLength, numBytesToWrite);
			}
		}

		public void Clear()
		{
			lock (UsxtKMpXeRLDfsnvzAxEWRdTuly)
			{
				lock (vbWUbUjzbMNIVIAwAjDTnqunaBN)
				{
					vbWUbUjzbMNIVIAwAjDTnqunaBN.Reset();
					UsxtKMpXeRLDfsnvzAxEWRdTuly.Reset();
				}
			}
		}

		private void ENPyMqCAmWcuJGuQuHmWpgOtUOi()
		{
			lock (UsxtKMpXeRLDfsnvzAxEWRdTuly)
			{
				lock (vbWUbUjzbMNIVIAwAjDTnqunaBN)
				{
					MiscTools.Swap(ref UsxtKMpXeRLDfsnvzAxEWRdTuly, ref vbWUbUjzbMNIVIAwAjDTnqunaBN);
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~DualRingReportBuffer()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!jgbpvYJovPcfzmcAEJzdxdrBmcm)
			{
				jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
			}
		}
	}
}
