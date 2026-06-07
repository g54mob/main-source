using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ThreadedRingReportBuffer : IDisposable
	{
		private readonly int lhXEwXroTQFwqaOtVoSrijfOBHRC;

		private readonly int jykoAtdBnUMtuLDXndqvohnBLrWO;

		private readonly int yxpcTagvcVatNaJUezzbHFUkDKaK;

		private readonly int uRUVTJOznzjyCGHjOALWLzBtUGPE;

		private readonly int KIhpsEocJmixLgopVeIYlmuYJFyz;

		private readonly bool vdaywPrThyrcIZGHizKEUpVKyhny;

		private ThreadHelper FBhTBCloRTksrXPdIRhzYVUCiBYB;

		private NativeRingBuffer qVxFaKdNuwbxIQEFNlVZzeKdQiGHA;

		private NativeRingBuffer HzAELOPWtxLdsiASyumWBJRNirjL;

		private Action<byte[]> ZgTrGGEaaeaLlyTniNKoYbcUfqEO;

		private byte[] PYVfBWvoPFnquolKyLEtbtlJwOcJ;

		private byte[] QZyftLxKfVFJmCVNuFyMwubXhaGHb;

		private bool titAFvTkOTJqbZwzzviokBDGEiIM;

		private bool juAmOHdlEuZcdEbopfsigKMAJgtHb;

		private int bZvpJDjETpCswHMKMuFVroAQTorhA;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

		public bool IsRunning => FBhTBCloRTksrXPdIRhzYVUCiBYB.isRunning;

		public int BufferLength => lhXEwXroTQFwqaOtVoSrijfOBHRC;

		public int BytesInBuffer => HzAELOPWtxLdsiASyumWBJRNirjL.BytesInBuffer;

		public int EntriesInBuffer => HzAELOPWtxLdsiASyumWBJRNirjL.BytesInBuffer / jykoAtdBnUMtuLDXndqvohnBLrWO;

		public byte[] ReadBuffer => QZyftLxKfVFJmCVNuFyMwubXhaGHb;

		public int LastNumBytesRead => bZvpJDjETpCswHMKMuFVroAQTorhA;

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
			jykoAtdBnUMtuLDXndqvohnBLrWO = P_0;
			yxpcTagvcVatNaJUezzbHFUkDKaK = P_1;
			lhXEwXroTQFwqaOtVoSrijfOBHRC = P_0 * P_1;
			uRUVTJOznzjyCGHjOALWLzBtUGPE = P_2;
			KIhpsEocJmixLgopVeIYlmuYJFyz = P_3;
			vdaywPrThyrcIZGHizKEUpVKyhny = P_4;
			ZgTrGGEaaeaLlyTniNKoYbcUfqEO = P_5;
			qVxFaKdNuwbxIQEFNlVZzeKdQiGHA = new NativeRingBuffer(lhXEwXroTQFwqaOtVoSrijfOBHRC);
			HzAELOPWtxLdsiASyumWBJRNirjL = new NativeRingBuffer(lhXEwXroTQFwqaOtVoSrijfOBHRC);
			PYVfBWvoPFnquolKyLEtbtlJwOcJ = new byte[P_0];
			QZyftLxKfVFJmCVNuFyMwubXhaGHb = new byte[P_0];
			if (!zBFbVgFivIFkRriBBSLwgWJemDVY())
			{
				throw new Exception("Could not initialize thread.");
			}
		}

		public int Read()
		{
			int result = 0;
			lock (HzAELOPWtxLdsiASyumWBJRNirjL)
			{
				result = HzAELOPWtxLdsiASyumWBJRNirjL.Read(QZyftLxKfVFJmCVNuFyMwubXhaGHb, jykoAtdBnUMtuLDXndqvohnBLrWO);
			}
			bZvpJDjETpCswHMKMuFVroAQTorhA = result;
			return result;
		}

		public int Read(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int result = 0;
			lock (HzAELOPWtxLdsiASyumWBJRNirjL)
			{
				result = HzAELOPWtxLdsiASyumWBJRNirjL.Read(buffer, buffer.Length);
			}
			bZvpJDjETpCswHMKMuFVroAQTorhA = result;
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
			lock (HzAELOPWtxLdsiASyumWBJRNirjL)
			{
				result = HzAELOPWtxLdsiASyumWBJRNirjL.Read(buffer, bufferLength, bufferLength);
			}
			bZvpJDjETpCswHMKMuFVroAQTorhA = result;
			return result;
		}

		public int StartRead()
		{
			mvXLpokPgbbEydyeWnYFLVtLSAIuA();
			return HzAELOPWtxLdsiASyumWBJRNirjL.BytesInBuffer;
		}

		public void StartThread()
		{
			if (FBhTBCloRTksrXPdIRhzYVUCiBYB.isRunning)
			{
				return;
			}
			try
			{
				FBhTBCloRTksrXPdIRhzYVUCiBYB.Start(vdaywPrThyrcIZGHizKEUpVKyhny);
			}
			catch
			{
			}
		}

		public void StopThread()
		{
			if (FBhTBCloRTksrXPdIRhzYVUCiBYB.isStopped)
			{
				return;
			}
			try
			{
				FBhTBCloRTksrXPdIRhzYVUCiBYB.Stop(vdaywPrThyrcIZGHizKEUpVKyhny);
			}
			catch
			{
			}
		}

		private bool zBFbVgFivIFkRriBBSLwgWJemDVY()
		{
			if (titAFvTkOTJqbZwzzviokBDGEiIM)
			{
				return false;
			}
			if (!nlzQIjcaveGwfYRGjIPPWvHGvgmu())
			{
				return false;
			}
			if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				return true;
			}
			juAmOHdlEuZcdEbopfsigKMAJgtHb = true;
			return true;
		}

		private bool nlzQIjcaveGwfYRGjIPPWvHGvgmu()
		{
			if (titAFvTkOTJqbZwzzviokBDGEiIM)
			{
				return false;
			}
			if (FBhTBCloRTksrXPdIRhzYVUCiBYB == null)
			{
				try
				{
					FBhTBCloRTksrXPdIRhzYVUCiBYB = ThreadHelper.CreateFixedTimeStep(uRUVTJOznzjyCGHjOALWLzBtUGPE, KIhpsEocJmixLgopVeIYlmuYJFyz);
					FBhTBCloRTksrXPdIRhzYVUCiBYB.ThreadUpdateEvent += tnVCzszeDfIDeEoeMJVWGUzaiznE;
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (FBhTBCloRTksrXPdIRhzYVUCiBYB != null)
					{
						FBhTBCloRTksrXPdIRhzYVUCiBYB.Stop(vdaywPrThyrcIZGHizKEUpVKyhny);
					}
					titAFvTkOTJqbZwzzviokBDGEiIM = true;
					return false;
				}
			}
			if (!FBhTBCloRTksrXPdIRhzYVUCiBYB.isRunning)
			{
				FBhTBCloRTksrXPdIRhzYVUCiBYB.Start(vdaywPrThyrcIZGHizKEUpVKyhny);
			}
			else if (KIhpsEocJmixLgopVeIYlmuYJFyz > 0)
			{
				FBhTBCloRTksrXPdIRhzYVUCiBYB.ResetTimeout();
			}
			return true;
		}

		private void mvXLpokPgbbEydyeWnYFLVtLSAIuA()
		{
			lock (qVxFaKdNuwbxIQEFNlVZzeKdQiGHA)
			{
				lock (HzAELOPWtxLdsiASyumWBJRNirjL)
				{
					MiscTools.Swap(ref qVxFaKdNuwbxIQEFNlVZzeKdQiGHA, ref HzAELOPWtxLdsiASyumWBJRNirjL);
				}
			}
		}

		private void tnVCzszeDfIDeEoeMJVWGUzaiznE()
		{
			try
			{
				lock (qVxFaKdNuwbxIQEFNlVZzeKdQiGHA)
				{
					ZgTrGGEaaeaLlyTniNKoYbcUfqEO(PYVfBWvoPFnquolKyLEtbtlJwOcJ);
					qVxFaKdNuwbxIQEFNlVZzeKdQiGHA.Write(PYVfBWvoPFnquolKyLEtbtlJwOcJ, jykoAtdBnUMtuLDXndqvohnBLrWO);
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
			if (!JChPmMbeaoLOGQvosPYqDDInSiCs)
			{
				if (disposing && FBhTBCloRTksrXPdIRhzYVUCiBYB != null)
				{
					FBhTBCloRTksrXPdIRhzYVUCiBYB.Dispose();
				}
				JChPmMbeaoLOGQvosPYqDDInSiCs = true;
			}
		}
	}
}
