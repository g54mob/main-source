using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ThreadedRingReportBuffer : IDisposable
	{
		private readonly int ThylOPILKCFDPpDDBADWbGEbbOPdA;

		private readonly int fVJFyOHoozQbThRZWePPlxWtPzxlA;

		private readonly int lVbkkbFVXnfjAwpjBzMTgZtSoTms;

		private readonly int dTUdhRAMngMxFPAdAKwYSQzoNXkj;

		private readonly int xiTRmQwBCbNjSefixrHThnbDfaqn;

		private readonly bool YuoJsQTqDEpKxCmTFFUUcbQcjCO;

		private ThreadHelper sQFcVzIlgSazLSqsPCZzdkILAShu;

		private NativeRingBuffer SQUPLuekhTaTfJqAbgOFRtvfEXcdb;

		private NativeRingBuffer vDaRGbDEGpGPWQRLisgXphuQoXJB;

		private Action<byte[]> TpcUeyhnJAtjGkbsvTPmuawflrxO;

		private byte[] iwfeWYaiaCzwKYpwsgLagpzFONnQA;

		private byte[] ZQVfbNyTAvYbJavRPfIxkhyWlkZH;

		private bool rkqqwuWfEbiguNWaTyfdZXFBWLvd;

		private bool CrzKAQILOvDwDHgRbTtfzhPVlbsh;

		private int RFDDBrcWAfHnzUdiYfcgqnTIvMMW;

		private bool qQYQKuaAxqgsQKiaWMaqbEaoRsFk;

		public bool IsRunning => sQFcVzIlgSazLSqsPCZzdkILAShu.isRunning;

		public int BufferLength => ThylOPILKCFDPpDDBADWbGEbbOPdA;

		public int BytesInBuffer => vDaRGbDEGpGPWQRLisgXphuQoXJB.BytesInBuffer;

		public int EntriesInBuffer => vDaRGbDEGpGPWQRLisgXphuQoXJB.BytesInBuffer / fVJFyOHoozQbThRZWePPlxWtPzxlA;

		public byte[] ReadBuffer => ZQVfbNyTAvYbJavRPfIxkhyWlkZH;

		public int LastNumBytesRead => RFDDBrcWAfHnzUdiYfcgqnTIvMMW;

		public ThreadedRingReportBuffer(int P_0, int P_1, int P_2, int P_3, bool P_4, Action<byte[]> P_5)
		{
			if (P_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("entryByteLength must be > 0.");
			}
			if (P_1 < 1)
			{
				throw new ArgumentOutOfRangeException("entryCapacity must be >= 1.");
			}
			if (P_2 < 0)
			{
				P_2 = 0;
			}
			if (P_3 < 0)
			{
				P_3 = 0;
			}
			if (P_5 == null)
			{
				throw new ArgumentNullException("threadRetrieveDataDelegate");
			}
			fVJFyOHoozQbThRZWePPlxWtPzxlA = P_0;
			lVbkkbFVXnfjAwpjBzMTgZtSoTms = P_1;
			ThylOPILKCFDPpDDBADWbGEbbOPdA = P_0 * P_1;
			dTUdhRAMngMxFPAdAKwYSQzoNXkj = P_2;
			xiTRmQwBCbNjSefixrHThnbDfaqn = P_3;
			YuoJsQTqDEpKxCmTFFUUcbQcjCO = P_4;
			TpcUeyhnJAtjGkbsvTPmuawflrxO = P_5;
			SQUPLuekhTaTfJqAbgOFRtvfEXcdb = new NativeRingBuffer(ThylOPILKCFDPpDDBADWbGEbbOPdA);
			vDaRGbDEGpGPWQRLisgXphuQoXJB = new NativeRingBuffer(ThylOPILKCFDPpDDBADWbGEbbOPdA);
			iwfeWYaiaCzwKYpwsgLagpzFONnQA = new byte[P_0];
			ZQVfbNyTAvYbJavRPfIxkhyWlkZH = new byte[P_0];
			if (!vrvcNQByGEwgpQrYUYnEHPriWVJGA())
			{
				throw new Exception("Could not initialize thread.");
			}
		}

		public int Read()
		{
			int num = 0;
			lock (vDaRGbDEGpGPWQRLisgXphuQoXJB)
			{
				num = vDaRGbDEGpGPWQRLisgXphuQoXJB.Read(ZQVfbNyTAvYbJavRPfIxkhyWlkZH, fVJFyOHoozQbThRZWePPlxWtPzxlA);
			}
			RFDDBrcWAfHnzUdiYfcgqnTIvMMW = num;
			return num;
		}

		public int Read(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int num = 0;
			lock (vDaRGbDEGpGPWQRLisgXphuQoXJB)
			{
				num = vDaRGbDEGpGPWQRLisgXphuQoXJB.Read(buffer, buffer.Length);
			}
			RFDDBrcWAfHnzUdiYfcgqnTIvMMW = num;
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
			lock (vDaRGbDEGpGPWQRLisgXphuQoXJB)
			{
				num = vDaRGbDEGpGPWQRLisgXphuQoXJB.Read(buffer, bufferLength, bufferLength);
			}
			RFDDBrcWAfHnzUdiYfcgqnTIvMMW = num;
			return num;
		}

		public int StartRead()
		{
			ruJLXqQiWSwtDQHxSltlZcutcEZH();
			return vDaRGbDEGpGPWQRLisgXphuQoXJB.BytesInBuffer;
		}

		public void StartThread()
		{
			if (sQFcVzIlgSazLSqsPCZzdkILAShu.isRunning)
			{
				return;
			}
			try
			{
				sQFcVzIlgSazLSqsPCZzdkILAShu.Start(YuoJsQTqDEpKxCmTFFUUcbQcjCO);
			}
			catch
			{
			}
		}

		public void StopThread()
		{
			if (sQFcVzIlgSazLSqsPCZzdkILAShu.isStopped)
			{
				return;
			}
			try
			{
				sQFcVzIlgSazLSqsPCZzdkILAShu.Stop(YuoJsQTqDEpKxCmTFFUUcbQcjCO);
			}
			catch
			{
			}
		}

		private bool vrvcNQByGEwgpQrYUYnEHPriWVJGA()
		{
			if (rkqqwuWfEbiguNWaTyfdZXFBWLvd)
			{
				return false;
			}
			if (!jgngrSagXkOqBYqVDhxMtblckoUF())
			{
				return false;
			}
			if (CrzKAQILOvDwDHgRbTtfzhPVlbsh)
			{
				return true;
			}
			CrzKAQILOvDwDHgRbTtfzhPVlbsh = true;
			return true;
		}

		private bool jgngrSagXkOqBYqVDhxMtblckoUF()
		{
			if (rkqqwuWfEbiguNWaTyfdZXFBWLvd)
			{
				return false;
			}
			if (sQFcVzIlgSazLSqsPCZzdkILAShu == null)
			{
				try
				{
					sQFcVzIlgSazLSqsPCZzdkILAShu = ThreadHelper.CreateFixedTimeStep(dTUdhRAMngMxFPAdAKwYSQzoNXkj, xiTRmQwBCbNjSefixrHThnbDfaqn);
					sQFcVzIlgSazLSqsPCZzdkILAShu.ThreadUpdateEvent += GSFZfycJlSAIAsSaRFlwfIaXVGOKA;
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (sQFcVzIlgSazLSqsPCZzdkILAShu != null)
					{
						sQFcVzIlgSazLSqsPCZzdkILAShu.Stop(YuoJsQTqDEpKxCmTFFUUcbQcjCO);
					}
					rkqqwuWfEbiguNWaTyfdZXFBWLvd = true;
					return false;
				}
			}
			if (!sQFcVzIlgSazLSqsPCZzdkILAShu.isRunning)
			{
				sQFcVzIlgSazLSqsPCZzdkILAShu.Start(YuoJsQTqDEpKxCmTFFUUcbQcjCO);
			}
			else if (xiTRmQwBCbNjSefixrHThnbDfaqn > 0)
			{
				sQFcVzIlgSazLSqsPCZzdkILAShu.ResetTimeout();
			}
			return true;
		}

		private void ruJLXqQiWSwtDQHxSltlZcutcEZH()
		{
			lock (SQUPLuekhTaTfJqAbgOFRtvfEXcdb)
			{
				lock (vDaRGbDEGpGPWQRLisgXphuQoXJB)
				{
					MiscTools.Swap(ref SQUPLuekhTaTfJqAbgOFRtvfEXcdb, ref vDaRGbDEGpGPWQRLisgXphuQoXJB);
				}
			}
		}

		private void GSFZfycJlSAIAsSaRFlwfIaXVGOKA()
		{
			try
			{
				lock (SQUPLuekhTaTfJqAbgOFRtvfEXcdb)
				{
					TpcUeyhnJAtjGkbsvTPmuawflrxO(iwfeWYaiaCzwKYpwsgLagpzFONnQA);
					SQUPLuekhTaTfJqAbgOFRtvfEXcdb.Write(iwfeWYaiaCzwKYpwsgLagpzFONnQA, fVJFyOHoozQbThRZWePPlxWtPzxlA);
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

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~ThreadedRingReportBuffer()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!qQYQKuaAxqgsQKiaWMaqbEaoRsFk)
			{
				if (disposing && sQFcVzIlgSazLSqsPCZzdkILAShu != null)
				{
					sQFcVzIlgSazLSqsPCZzdkILAShu.Dispose();
				}
				qQYQKuaAxqgsQKiaWMaqbEaoRsFk = true;
			}
		}
	}
}
