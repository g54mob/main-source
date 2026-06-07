using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadedRingReportBuffer : IDisposable
	{
		private readonly int TKfgJeBFWygMjbKxhiJlNqauevFc;

		private readonly int xOQrpAbgnZfYGZVCsYaCFMeiyZTs;

		private readonly int dcaAblfEITpCLqoilpbWZEHDmrGXA;

		private readonly int hxJsHpTeyGtCiRiQqtXGaDfvzAUE;

		private readonly int tEYEzSAlVDHULfihhDaEuFJTEMEmc;

		private readonly bool MkzhCiZPvxdtJnHnjesHmARDFDyl;

		private ThreadHelper eKQGpdJtteKICMftlcMkFxiGiMVK;

		private NativeRingBuffer INXGIyfvcjxqoOuDVLzEbDZgexMIA;

		private NativeRingBuffer nBWKnAQvZZhSGYMUQZAtZiFNKEpJ;

		private Action<byte[]> DSrDnmqUGkgAJekxRyelGcMufRNjA;

		private byte[] mZyNTEtCdcNZLEKpSLgbZDFAPvFM;

		private byte[] NxQginzWCPvJUkJehEjsIpUTBUhg;

		private bool jQrjcmHfoPjDbPZLxSZkdthKjuBu;

		private bool GXiDDINfUZqtOTDrRwWsLaVABDEQ;

		private int BUtAbhDBLWccSobqDRnEKtZjkyP;

		private bool cNPCNqdkuEYHZKFhgAbxgXIjufzz;

		public bool IsRunning => eKQGpdJtteKICMftlcMkFxiGiMVK.isRunning;

		public int BufferLength => TKfgJeBFWygMjbKxhiJlNqauevFc;

		public int BytesInBuffer => nBWKnAQvZZhSGYMUQZAtZiFNKEpJ.BytesInBuffer;

		public int EntriesInBuffer => nBWKnAQvZZhSGYMUQZAtZiFNKEpJ.BytesInBuffer / xOQrpAbgnZfYGZVCsYaCFMeiyZTs;

		public byte[] ReadBuffer => NxQginzWCPvJUkJehEjsIpUTBUhg;

		public int LastNumBytesRead => BUtAbhDBLWccSobqDRnEKtZjkyP;

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
			xOQrpAbgnZfYGZVCsYaCFMeiyZTs = P_0;
			dcaAblfEITpCLqoilpbWZEHDmrGXA = P_1;
			TKfgJeBFWygMjbKxhiJlNqauevFc = P_0 * P_1;
			hxJsHpTeyGtCiRiQqtXGaDfvzAUE = P_2;
			tEYEzSAlVDHULfihhDaEuFJTEMEmc = P_3;
			MkzhCiZPvxdtJnHnjesHmARDFDyl = P_4;
			DSrDnmqUGkgAJekxRyelGcMufRNjA = P_5;
			INXGIyfvcjxqoOuDVLzEbDZgexMIA = new NativeRingBuffer(TKfgJeBFWygMjbKxhiJlNqauevFc);
			nBWKnAQvZZhSGYMUQZAtZiFNKEpJ = new NativeRingBuffer(TKfgJeBFWygMjbKxhiJlNqauevFc);
			mZyNTEtCdcNZLEKpSLgbZDFAPvFM = new byte[P_0];
			NxQginzWCPvJUkJehEjsIpUTBUhg = new byte[P_0];
			if (!rKiPCQbuPyANevOPoFEXpURlgbpr())
			{
				throw new Exception("Could not initialize thread.");
			}
		}

		public int Read()
		{
			int num = 0;
			lock (nBWKnAQvZZhSGYMUQZAtZiFNKEpJ)
			{
				num = nBWKnAQvZZhSGYMUQZAtZiFNKEpJ.Read(NxQginzWCPvJUkJehEjsIpUTBUhg, xOQrpAbgnZfYGZVCsYaCFMeiyZTs);
			}
			BUtAbhDBLWccSobqDRnEKtZjkyP = num;
			return num;
		}

		public int Read(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int num = 0;
			lock (nBWKnAQvZZhSGYMUQZAtZiFNKEpJ)
			{
				num = nBWKnAQvZZhSGYMUQZAtZiFNKEpJ.Read(buffer, buffer.Length);
			}
			BUtAbhDBLWccSobqDRnEKtZjkyP = num;
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
			lock (nBWKnAQvZZhSGYMUQZAtZiFNKEpJ)
			{
				num = nBWKnAQvZZhSGYMUQZAtZiFNKEpJ.Read(buffer, bufferLength, bufferLength);
			}
			BUtAbhDBLWccSobqDRnEKtZjkyP = num;
			return num;
		}

		public int StartRead()
		{
			dCtCshVRgzVOeUcsBAwzpOmcOhmA();
			return nBWKnAQvZZhSGYMUQZAtZiFNKEpJ.BytesInBuffer;
		}

		public void StartThread()
		{
			if (eKQGpdJtteKICMftlcMkFxiGiMVK.isRunning)
			{
				return;
			}
			try
			{
				eKQGpdJtteKICMftlcMkFxiGiMVK.Start(MkzhCiZPvxdtJnHnjesHmARDFDyl);
			}
			catch
			{
			}
		}

		public void StopThread()
		{
			if (eKQGpdJtteKICMftlcMkFxiGiMVK.isStopped)
			{
				return;
			}
			try
			{
				eKQGpdJtteKICMftlcMkFxiGiMVK.Stop(MkzhCiZPvxdtJnHnjesHmARDFDyl);
			}
			catch
			{
			}
		}

		private bool rKiPCQbuPyANevOPoFEXpURlgbpr()
		{
			if (jQrjcmHfoPjDbPZLxSZkdthKjuBu)
			{
				return false;
			}
			if (!jCiBjYbmOMrzEUZOpRGVHRFvUGgp())
			{
				return false;
			}
			if (GXiDDINfUZqtOTDrRwWsLaVABDEQ)
			{
				return true;
			}
			GXiDDINfUZqtOTDrRwWsLaVABDEQ = true;
			return true;
		}

		private bool jCiBjYbmOMrzEUZOpRGVHRFvUGgp()
		{
			if (jQrjcmHfoPjDbPZLxSZkdthKjuBu)
			{
				return false;
			}
			if (eKQGpdJtteKICMftlcMkFxiGiMVK == null)
			{
				try
				{
					eKQGpdJtteKICMftlcMkFxiGiMVK = ThreadHelper.CreateFixedTimeStep(hxJsHpTeyGtCiRiQqtXGaDfvzAUE, tEYEzSAlVDHULfihhDaEuFJTEMEmc);
					eKQGpdJtteKICMftlcMkFxiGiMVK.ThreadUpdateEvent += CmYiwupUgsahVkhpbpGryLEYvgyq;
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (eKQGpdJtteKICMftlcMkFxiGiMVK != null)
					{
						eKQGpdJtteKICMftlcMkFxiGiMVK.Stop(MkzhCiZPvxdtJnHnjesHmARDFDyl);
					}
					jQrjcmHfoPjDbPZLxSZkdthKjuBu = true;
					return false;
				}
			}
			if (!eKQGpdJtteKICMftlcMkFxiGiMVK.isRunning)
			{
				eKQGpdJtteKICMftlcMkFxiGiMVK.Start(MkzhCiZPvxdtJnHnjesHmARDFDyl);
			}
			else if (tEYEzSAlVDHULfihhDaEuFJTEMEmc > 0)
			{
				eKQGpdJtteKICMftlcMkFxiGiMVK.ResetTimeout();
			}
			return true;
		}

		private void dCtCshVRgzVOeUcsBAwzpOmcOhmA()
		{
			lock (INXGIyfvcjxqoOuDVLzEbDZgexMIA)
			{
				lock (nBWKnAQvZZhSGYMUQZAtZiFNKEpJ)
				{
					MiscTools.Swap(ref INXGIyfvcjxqoOuDVLzEbDZgexMIA, ref nBWKnAQvZZhSGYMUQZAtZiFNKEpJ);
				}
			}
		}

		private void CmYiwupUgsahVkhpbpGryLEYvgyq()
		{
			try
			{
				lock (INXGIyfvcjxqoOuDVLzEbDZgexMIA)
				{
					DSrDnmqUGkgAJekxRyelGcMufRNjA(mZyNTEtCdcNZLEKpSLgbZDFAPvFM);
					INXGIyfvcjxqoOuDVLzEbDZgexMIA.Write(mZyNTEtCdcNZLEKpSLgbZDFAPvFM, xOQrpAbgnZfYGZVCsYaCFMeiyZTs);
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
			if (!cNPCNqdkuEYHZKFhgAbxgXIjufzz)
			{
				if (disposing && eKQGpdJtteKICMftlcMkFxiGiMVK != null)
				{
					eKQGpdJtteKICMftlcMkFxiGiMVK.Dispose();
				}
				cNPCNqdkuEYHZKFhgAbxgXIjufzz = true;
			}
		}
	}
}
