using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ThreadedRingReportBuffer : IDisposable
	{
		private readonly int rijFcvcuNuYYRJPEuwvSPEbGeRTw;

		private readonly int rPWFQLuVOujTRshHCSznCAdDHbI;

		private readonly int aQFEYMxCBbxrgNzMJHqnhhWacJsk;

		private readonly int sEexrfZtAXWkVvfZfKZLdwrloCT;

		private readonly int OjFdEclQoQsTiZfdsXWYSBgKHDq;

		private readonly bool dnYSrHeSeWfhmgPMXPOngPfSvfk;

		private ThreadHelper TOLvxyiiNhqpXirBdtAdqoJEeaJ;

		private NativeRingBuffer ycJGxwIPoAiqvjZPmYYDAEEbmBQ;

		private NativeRingBuffer HXmvGcSqIBclXBhETbsYnxDFmax;

		private Action<byte[]> BLtgTuZTHGFdIIBjTVCslgiEGcWo;

		private byte[] BVzHZgqJolPuLPZOHqIdLqdLiso;

		private byte[] YuUDNpcmUbKfXoKBDzkUGEdFikA;

		private bool jhLrtTQylzmdSwmxOgocATNSjcGf;

		private bool rXobafaxvUDrItlgWahiaYSKJqn;

		private int rwVtMdoGgJcjLdaAxUOXOqSUbyhD;

		private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

		public bool IsRunning => TOLvxyiiNhqpXirBdtAdqoJEeaJ.isRunning;

		public int BufferLength => rijFcvcuNuYYRJPEuwvSPEbGeRTw;

		public int BytesInBuffer => HXmvGcSqIBclXBhETbsYnxDFmax.BytesInBuffer;

		public int EntriesInBuffer => HXmvGcSqIBclXBhETbsYnxDFmax.BytesInBuffer / rPWFQLuVOujTRshHCSznCAdDHbI;

		public byte[] ReadBuffer => YuUDNpcmUbKfXoKBDzkUGEdFikA;

		public int LastNumBytesRead => rwVtMdoGgJcjLdaAxUOXOqSUbyhD;

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
			rPWFQLuVOujTRshHCSznCAdDHbI = entryByteLength;
			aQFEYMxCBbxrgNzMJHqnhhWacJsk = entryCapacity;
			rijFcvcuNuYYRJPEuwvSPEbGeRTw = entryByteLength * entryCapacity;
			sEexrfZtAXWkVvfZfKZLdwrloCT = threadRefreshRateFPS;
			OjFdEclQoQsTiZfdsXWYSBgKHDq = threadAutoKillTimeoutMS;
			dnYSrHeSeWfhmgPMXPOngPfSvfk = threadBlockOnStartAndStop;
			BLtgTuZTHGFdIIBjTVCslgiEGcWo = threadRetrieveDataDelegate;
			ycJGxwIPoAiqvjZPmYYDAEEbmBQ = new NativeRingBuffer(rijFcvcuNuYYRJPEuwvSPEbGeRTw);
			HXmvGcSqIBclXBhETbsYnxDFmax = new NativeRingBuffer(rijFcvcuNuYYRJPEuwvSPEbGeRTw);
			BVzHZgqJolPuLPZOHqIdLqdLiso = new byte[entryByteLength];
			YuUDNpcmUbKfXoKBDzkUGEdFikA = new byte[entryByteLength];
			if (!zptlECrQiHzwILTuMWcaXVcgZFC())
			{
				throw new Exception("Could not initialize thread.");
			}
		}

		public int Read()
		{
			int result = 0;
			lock (HXmvGcSqIBclXBhETbsYnxDFmax)
			{
				result = HXmvGcSqIBclXBhETbsYnxDFmax.Read(YuUDNpcmUbKfXoKBDzkUGEdFikA, rPWFQLuVOujTRshHCSznCAdDHbI);
			}
			rwVtMdoGgJcjLdaAxUOXOqSUbyhD = result;
			return result;
		}

		public int Read(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int result = 0;
			lock (HXmvGcSqIBclXBhETbsYnxDFmax)
			{
				result = HXmvGcSqIBclXBhETbsYnxDFmax.Read(buffer, buffer.Length);
			}
			rwVtMdoGgJcjLdaAxUOXOqSUbyhD = result;
			return result;
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
			int result = 0;
			lock (HXmvGcSqIBclXBhETbsYnxDFmax)
			{
				result = HXmvGcSqIBclXBhETbsYnxDFmax.Read(buffer, bufferLength, bufferLength);
			}
			rwVtMdoGgJcjLdaAxUOXOqSUbyhD = result;
			return result;
		}

		public int StartRead()
		{
			oulbBMnBJHRTZTVibPJPbSvVRUQ();
			return HXmvGcSqIBclXBhETbsYnxDFmax.BytesInBuffer;
		}

		public void StartThread()
		{
			if (TOLvxyiiNhqpXirBdtAdqoJEeaJ.isRunning)
			{
				return;
			}
			try
			{
				TOLvxyiiNhqpXirBdtAdqoJEeaJ.Start(dnYSrHeSeWfhmgPMXPOngPfSvfk);
			}
			catch
			{
			}
		}

		public void StopThread()
		{
			if (TOLvxyiiNhqpXirBdtAdqoJEeaJ.isStopped)
			{
				return;
			}
			try
			{
				TOLvxyiiNhqpXirBdtAdqoJEeaJ.Stop(dnYSrHeSeWfhmgPMXPOngPfSvfk);
			}
			catch
			{
			}
		}

		private bool zptlECrQiHzwILTuMWcaXVcgZFC()
		{
			if (jhLrtTQylzmdSwmxOgocATNSjcGf)
			{
				return false;
			}
			if (!dnRqmZnjIMrsAjyACIgZsOXCkfi())
			{
				return false;
			}
			if (rXobafaxvUDrItlgWahiaYSKJqn)
			{
				return true;
			}
			rXobafaxvUDrItlgWahiaYSKJqn = true;
			return true;
		}

		private bool dnRqmZnjIMrsAjyACIgZsOXCkfi()
		{
			if (jhLrtTQylzmdSwmxOgocATNSjcGf)
			{
				return false;
			}
			if (TOLvxyiiNhqpXirBdtAdqoJEeaJ == null)
			{
				try
				{
					TOLvxyiiNhqpXirBdtAdqoJEeaJ = ThreadHelper.CreateFixedTimeStep(sEexrfZtAXWkVvfZfKZLdwrloCT, OjFdEclQoQsTiZfdsXWYSBgKHDq);
					TOLvxyiiNhqpXirBdtAdqoJEeaJ.ThreadUpdateEvent += fdflmMgrgHwHTbCydBMWJejqPcdh;
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (TOLvxyiiNhqpXirBdtAdqoJEeaJ != null)
					{
						TOLvxyiiNhqpXirBdtAdqoJEeaJ.Stop(dnYSrHeSeWfhmgPMXPOngPfSvfk);
					}
					jhLrtTQylzmdSwmxOgocATNSjcGf = true;
					return false;
				}
			}
			if (!TOLvxyiiNhqpXirBdtAdqoJEeaJ.isRunning)
			{
				TOLvxyiiNhqpXirBdtAdqoJEeaJ.Start(dnYSrHeSeWfhmgPMXPOngPfSvfk);
			}
			else if (OjFdEclQoQsTiZfdsXWYSBgKHDq > 0)
			{
				TOLvxyiiNhqpXirBdtAdqoJEeaJ.ResetTimeout();
			}
			return true;
		}

		private void oulbBMnBJHRTZTVibPJPbSvVRUQ()
		{
			lock (ycJGxwIPoAiqvjZPmYYDAEEbmBQ)
			{
				lock (HXmvGcSqIBclXBhETbsYnxDFmax)
				{
					MiscTools.Swap(ref ycJGxwIPoAiqvjZPmYYDAEEbmBQ, ref HXmvGcSqIBclXBhETbsYnxDFmax);
				}
			}
		}

		private void fdflmMgrgHwHTbCydBMWJejqPcdh()
		{
			try
			{
				lock (ycJGxwIPoAiqvjZPmYYDAEEbmBQ)
				{
					BLtgTuZTHGFdIIBjTVCslgiEGcWo(BVzHZgqJolPuLPZOHqIdLqdLiso);
					ycJGxwIPoAiqvjZPmYYDAEEbmBQ.Write(BVzHZgqJolPuLPZOHqIdLqdLiso, rPWFQLuVOujTRshHCSznCAdDHbI);
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
			if (!JtZAxieDBYjDdfBgPPJgrNSxYmS)
			{
				if (disposing && TOLvxyiiNhqpXirBdtAdqoJEeaJ != null)
				{
					TOLvxyiiNhqpXirBdtAdqoJEeaJ.Dispose();
				}
				JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
			}
		}
	}
}
