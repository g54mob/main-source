using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ThreadedRingReportBuffer : IDisposable
	{
		private readonly int NsXnNTBKkhclPUnqdcpVWRAaJHx;

		private readonly int LmkTbrFqttHkVpQnDupyAyOlTpy;

		private readonly int MMtszkOkeijIyABqQsiytdjOMBM;

		private readonly int AiYhYTyUdUvTPqXhgEBAttAVLMj;

		private readonly int eShvfUORtFLHmKcHjFIDMuFuFLQ;

		private readonly bool VZijzTBKzRCWddelKZbNaAaukbD;

		private ThreadHelper byleSGZFcwgUJDntkRImTcwmoehC;

		private NativeRingBuffer UsxtKMpXeRLDfsnvzAxEWRdTuly;

		private NativeRingBuffer vbWUbUjzbMNIVIAwAjDTnqunaBN;

		private Action<byte[]> pvBPcUsRiPRWGIFBOaEtiaJgomyt;

		private byte[] tcRYqIVzRioDPOjcOICsGZIjlmCm;

		private byte[] uysmVyZltixLtdbkOnVGMGzlkyF;

		private bool VtteUzfdCsVSSGvXPAslsAmeQmik;

		private bool XrAXpRFFCZWxSkTUXpVlgetwinP;

		private int ZjzYEXVVHSYfNafeaECSEZbcqOL;

		private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

		public bool IsRunning => byleSGZFcwgUJDntkRImTcwmoehC.isRunning;

		public int BufferLength => NsXnNTBKkhclPUnqdcpVWRAaJHx;

		public int BytesInBuffer => vbWUbUjzbMNIVIAwAjDTnqunaBN.BytesInBuffer;

		public int EntriesInBuffer => vbWUbUjzbMNIVIAwAjDTnqunaBN.BytesInBuffer / LmkTbrFqttHkVpQnDupyAyOlTpy;

		public byte[] ReadBuffer => uysmVyZltixLtdbkOnVGMGzlkyF;

		public int LastNumBytesRead => ZjzYEXVVHSYfNafeaECSEZbcqOL;

		public ThreadedRingReportBuffer(int entryByteLength, int entryCapacity, int threadRefreshRateFPS, int threadAutoKillTimeoutMS, bool threadBlockOnStartAndStop, Action<byte[]> threadRetrieveDataDelegate)
		{
			if (entryByteLength <= 0)
			{
				throw new ArgumentOutOfRangeException("entryByteLength must be > 0.");
			}
			if (entryCapacity < 1)
			{
				throw new ArgumentOutOfRangeException("entryCapacity must be >= 1.");
			}
			if (threadRefreshRateFPS < 0)
			{
				threadRefreshRateFPS = 0;
			}
			if (threadAutoKillTimeoutMS < 0)
			{
				threadAutoKillTimeoutMS = 0;
			}
			if (threadRetrieveDataDelegate == null)
			{
				throw new ArgumentNullException("threadRetrieveDataDelegate");
			}
			LmkTbrFqttHkVpQnDupyAyOlTpy = entryByteLength;
			MMtszkOkeijIyABqQsiytdjOMBM = entryCapacity;
			NsXnNTBKkhclPUnqdcpVWRAaJHx = entryByteLength * entryCapacity;
			AiYhYTyUdUvTPqXhgEBAttAVLMj = threadRefreshRateFPS;
			eShvfUORtFLHmKcHjFIDMuFuFLQ = threadAutoKillTimeoutMS;
			VZijzTBKzRCWddelKZbNaAaukbD = threadBlockOnStartAndStop;
			pvBPcUsRiPRWGIFBOaEtiaJgomyt = threadRetrieveDataDelegate;
			UsxtKMpXeRLDfsnvzAxEWRdTuly = new NativeRingBuffer(NsXnNTBKkhclPUnqdcpVWRAaJHx);
			vbWUbUjzbMNIVIAwAjDTnqunaBN = new NativeRingBuffer(NsXnNTBKkhclPUnqdcpVWRAaJHx);
			tcRYqIVzRioDPOjcOICsGZIjlmCm = new byte[entryByteLength];
			uysmVyZltixLtdbkOnVGMGzlkyF = new byte[entryByteLength];
			if (!BlPUAqMlztMmaYIlhKUlkimOHBj())
			{
				throw new Exception("Could not initialize thread.");
			}
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

		public int Read(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int num = 0;
			lock (vbWUbUjzbMNIVIAwAjDTnqunaBN)
			{
				num = vbWUbUjzbMNIVIAwAjDTnqunaBN.Read(buffer, buffer.Length);
			}
			ZjzYEXVVHSYfNafeaECSEZbcqOL = num;
			return num;
		}

		public int Read(IntPtr buffer, int bufferLength)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			if (bufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferLength");
			}
			int num = 0;
			lock (vbWUbUjzbMNIVIAwAjDTnqunaBN)
			{
				num = vbWUbUjzbMNIVIAwAjDTnqunaBN.Read(buffer, bufferLength, bufferLength);
			}
			ZjzYEXVVHSYfNafeaECSEZbcqOL = num;
			return num;
		}

		public int StartRead()
		{
			ENPyMqCAmWcuJGuQuHmWpgOtUOi();
			return vbWUbUjzbMNIVIAwAjDTnqunaBN.BytesInBuffer;
		}

		public void StartThread()
		{
			if (byleSGZFcwgUJDntkRImTcwmoehC.isRunning)
			{
				return;
			}
			try
			{
				byleSGZFcwgUJDntkRImTcwmoehC.Start(VZijzTBKzRCWddelKZbNaAaukbD);
			}
			catch
			{
			}
		}

		public void StopThread()
		{
			if (byleSGZFcwgUJDntkRImTcwmoehC.isStopped)
			{
				return;
			}
			try
			{
				byleSGZFcwgUJDntkRImTcwmoehC.Stop(VZijzTBKzRCWddelKZbNaAaukbD);
			}
			catch
			{
			}
		}

		private bool BlPUAqMlztMmaYIlhKUlkimOHBj()
		{
			if (VtteUzfdCsVSSGvXPAslsAmeQmik)
			{
				return false;
			}
			if (!XdxHDhCKhBXYWFkaXYOIfioqteCp())
			{
				return false;
			}
			if (XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				return true;
			}
			XrAXpRFFCZWxSkTUXpVlgetwinP = true;
			return true;
		}

		private bool XdxHDhCKhBXYWFkaXYOIfioqteCp()
		{
			if (VtteUzfdCsVSSGvXPAslsAmeQmik)
			{
				return false;
			}
			if (byleSGZFcwgUJDntkRImTcwmoehC == null)
			{
				try
				{
					byleSGZFcwgUJDntkRImTcwmoehC = ThreadHelper.CreateFixedTimeStep(AiYhYTyUdUvTPqXhgEBAttAVLMj, eShvfUORtFLHmKcHjFIDMuFuFLQ);
					byleSGZFcwgUJDntkRImTcwmoehC.ThreadUpdateEvent += ZpVyDeRjVCfmFgyOwuILBqYMSsP;
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (byleSGZFcwgUJDntkRImTcwmoehC != null)
					{
						byleSGZFcwgUJDntkRImTcwmoehC.Stop(VZijzTBKzRCWddelKZbNaAaukbD);
					}
					VtteUzfdCsVSSGvXPAslsAmeQmik = true;
					return false;
				}
			}
			if (!byleSGZFcwgUJDntkRImTcwmoehC.isRunning)
			{
				byleSGZFcwgUJDntkRImTcwmoehC.Start(VZijzTBKzRCWddelKZbNaAaukbD);
			}
			else if (eShvfUORtFLHmKcHjFIDMuFuFLQ > 0)
			{
				byleSGZFcwgUJDntkRImTcwmoehC.ResetTimeout();
			}
			return true;
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

		private void ZpVyDeRjVCfmFgyOwuILBqYMSsP()
		{
			try
			{
				lock (UsxtKMpXeRLDfsnvzAxEWRdTuly)
				{
					pvBPcUsRiPRWGIFBOaEtiaJgomyt(tcRYqIVzRioDPOjcOICsGZIjlmCm);
					UsxtKMpXeRLDfsnvzAxEWRdTuly.Write(tcRYqIVzRioDPOjcOICsGZIjlmCm, LmkTbrFqttHkVpQnDupyAyOlTpy);
				}
			}
			catch
			{
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~ThreadedRingReportBuffer()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!jgbpvYJovPcfzmcAEJzdxdrBmcm)
			{
				if (disposing && byleSGZFcwgUJDntkRImTcwmoehC != null)
				{
					byleSGZFcwgUJDntkRImTcwmoehC.Dispose();
				}
				jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
			}
		}
	}
}
