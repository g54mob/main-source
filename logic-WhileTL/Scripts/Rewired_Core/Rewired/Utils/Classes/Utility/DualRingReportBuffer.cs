using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class DualRingReportBuffer : IDisposable
	{
		private readonly int lhXEwXroTQFwqaOtVoSrijfOBHRC;

		private readonly int jykoAtdBnUMtuLDXndqvohnBLrWO;

		private readonly int yxpcTagvcVatNaJUezzbHFUkDKaK;

		private NativeRingBuffer qVxFaKdNuwbxIQEFNlVZzeKdQiGHA;

		private NativeRingBuffer HzAELOPWtxLdsiASyumWBJRNirjL;

		private byte[] PYVfBWvoPFnquolKyLEtbtlJwOcJ;

		private byte[] QZyftLxKfVFJmCVNuFyMwubXhaGHb;

		private int bZvpJDjETpCswHMKMuFVroAQTorhA;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

		public int BufferLength => lhXEwXroTQFwqaOtVoSrijfOBHRC;

		public int BytesInBuffer => HzAELOPWtxLdsiASyumWBJRNirjL.BytesInBuffer;

		public int EntriesInBuffer => HzAELOPWtxLdsiASyumWBJRNirjL.BytesInBuffer / jykoAtdBnUMtuLDXndqvohnBLrWO;

		public byte[] ReadBuffer => QZyftLxKfVFJmCVNuFyMwubXhaGHb;

		public int LastNumBytesRead => bZvpJDjETpCswHMKMuFVroAQTorhA;

		public DualRingReportBuffer(int P_0, int P_1)
		{
			if (P_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("entryByteLength must be > 0.");
			}
			if (P_1 < 1)
			{
				throw new ArgumentOutOfRangeException("entryCapacity must be >= 1.");
			}
			jykoAtdBnUMtuLDXndqvohnBLrWO = P_0;
			yxpcTagvcVatNaJUezzbHFUkDKaK = P_1;
			lhXEwXroTQFwqaOtVoSrijfOBHRC = P_0 * P_1;
			qVxFaKdNuwbxIQEFNlVZzeKdQiGHA = new NativeRingBuffer(lhXEwXroTQFwqaOtVoSrijfOBHRC);
			HzAELOPWtxLdsiASyumWBJRNirjL = new NativeRingBuffer(lhXEwXroTQFwqaOtVoSrijfOBHRC);
			PYVfBWvoPFnquolKyLEtbtlJwOcJ = new byte[P_0];
			QZyftLxKfVFJmCVNuFyMwubXhaGHb = new byte[P_0];
		}

		public int StartRead()
		{
			mvXLpokPgbbEydyeWnYFLVtLSAIuA();
			return HzAELOPWtxLdsiASyumWBJRNirjL.BytesInBuffer;
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
			int result = 0;
			lock (HzAELOPWtxLdsiASyumWBJRNirjL)
			{
				result = HzAELOPWtxLdsiASyumWBJRNirjL.Read(buffer, numBytesToRead);
			}
			bZvpJDjETpCswHMKMuFVroAQTorhA = result;
			return result;
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
			int result = 0;
			lock (HzAELOPWtxLdsiASyumWBJRNirjL)
			{
				result = HzAELOPWtxLdsiASyumWBJRNirjL.Read(buffer, bufferLength, bufferLength);
			}
			bZvpJDjETpCswHMKMuFVroAQTorhA = result;
			return result;
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
			lock (qVxFaKdNuwbxIQEFNlVZzeKdQiGHA)
			{
				return qVxFaKdNuwbxIQEFNlVZzeKdQiGHA.Write(buffer, numBytesToWrite);
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
			lock (qVxFaKdNuwbxIQEFNlVZzeKdQiGHA)
			{
				return qVxFaKdNuwbxIQEFNlVZzeKdQiGHA.Write(buffer, bufferLength, numBytesToWrite);
			}
		}

		public void Clear()
		{
			lock (qVxFaKdNuwbxIQEFNlVZzeKdQiGHA)
			{
				lock (HzAELOPWtxLdsiASyumWBJRNirjL)
				{
					HzAELOPWtxLdsiASyumWBJRNirjL.Reset();
					qVxFaKdNuwbxIQEFNlVZzeKdQiGHA.Reset();
				}
			}
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
			if (!JChPmMbeaoLOGQvosPYqDDInSiCs)
			{
				JChPmMbeaoLOGQvosPYqDDInSiCs = true;
			}
		}
	}
}
