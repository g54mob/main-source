using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualRingReportBuffer : IDisposable
	{
		private readonly int cyuPLlrZYqCOMeOrNfSrgPvJYcmUA;

		private readonly int QwuaqTmkDDpxkfeTVdsTOptYVeHi;

		private readonly int iSlyAHpOrKIlbNfmwkeBaZXmyIOd;

		private NativeRingBuffer UcKhEGgXtVrNuFyRjXUJhpGdtbyLA;

		private NativeRingBuffer HDoDyrPJuHdqFIhFRRCtDDaekAXcb;

		private byte[] YYHcccHtyzTpyJYgFAzPdflPPdAR;

		private byte[] SuBikqsTCUpahavWuEhpctiSoufw;

		private int yYOdXhlaiwhYjuPJuugYkZWliBDh;

		private bool UHkcvXaBbEcowMhgCiUTzayJdzwU;

		public int BufferLength => cyuPLlrZYqCOMeOrNfSrgPvJYcmUA;

		public int BytesInBuffer => HDoDyrPJuHdqFIhFRRCtDDaekAXcb.BytesInBuffer;

		public int EntriesInBuffer => HDoDyrPJuHdqFIhFRRCtDDaekAXcb.BytesInBuffer / QwuaqTmkDDpxkfeTVdsTOptYVeHi;

		public byte[] ReadBuffer => SuBikqsTCUpahavWuEhpctiSoufw;

		public int LastNumBytesRead => yYOdXhlaiwhYjuPJuugYkZWliBDh;

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
			QwuaqTmkDDpxkfeTVdsTOptYVeHi = P_0;
			iSlyAHpOrKIlbNfmwkeBaZXmyIOd = P_1;
			cyuPLlrZYqCOMeOrNfSrgPvJYcmUA = P_0 * P_1;
			UcKhEGgXtVrNuFyRjXUJhpGdtbyLA = new NativeRingBuffer(cyuPLlrZYqCOMeOrNfSrgPvJYcmUA);
			HDoDyrPJuHdqFIhFRRCtDDaekAXcb = new NativeRingBuffer(cyuPLlrZYqCOMeOrNfSrgPvJYcmUA);
			YYHcccHtyzTpyJYgFAzPdflPPdAR = new byte[P_0];
			SuBikqsTCUpahavWuEhpctiSoufw = new byte[P_0];
		}

		public int StartRead()
		{
			rxSUwloAJIPDDwuWmNWXPqYKetnQ();
			return HDoDyrPJuHdqFIhFRRCtDDaekAXcb.BytesInBuffer;
		}

		public int Read()
		{
			int result = 0;
			lock (HDoDyrPJuHdqFIhFRRCtDDaekAXcb)
			{
				result = HDoDyrPJuHdqFIhFRRCtDDaekAXcb.Read(SuBikqsTCUpahavWuEhpctiSoufw, QwuaqTmkDDpxkfeTVdsTOptYVeHi);
			}
			yYOdXhlaiwhYjuPJuugYkZWliBDh = result;
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
			lock (HDoDyrPJuHdqFIhFRRCtDDaekAXcb)
			{
				result = HDoDyrPJuHdqFIhFRRCtDDaekAXcb.Read(buffer, numBytesToRead);
			}
			yYOdXhlaiwhYjuPJuugYkZWliBDh = result;
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
			lock (HDoDyrPJuHdqFIhFRRCtDDaekAXcb)
			{
				result = HDoDyrPJuHdqFIhFRRCtDDaekAXcb.Read(buffer, bufferLength, bufferLength);
			}
			yYOdXhlaiwhYjuPJuugYkZWliBDh = result;
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
			lock (UcKhEGgXtVrNuFyRjXUJhpGdtbyLA)
			{
				return UcKhEGgXtVrNuFyRjXUJhpGdtbyLA.Write(buffer, numBytesToWrite);
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
			lock (UcKhEGgXtVrNuFyRjXUJhpGdtbyLA)
			{
				return UcKhEGgXtVrNuFyRjXUJhpGdtbyLA.Write(buffer, bufferLength, numBytesToWrite);
			}
		}

		public void Clear()
		{
			lock (UcKhEGgXtVrNuFyRjXUJhpGdtbyLA)
			{
				lock (HDoDyrPJuHdqFIhFRRCtDDaekAXcb)
				{
					HDoDyrPJuHdqFIhFRRCtDDaekAXcb.Reset();
					UcKhEGgXtVrNuFyRjXUJhpGdtbyLA.Reset();
				}
			}
		}

		private void rxSUwloAJIPDDwuWmNWXPqYKetnQ()
		{
			lock (UcKhEGgXtVrNuFyRjXUJhpGdtbyLA)
			{
				lock (HDoDyrPJuHdqFIhFRRCtDDaekAXcb)
				{
					MiscTools.Swap(ref UcKhEGgXtVrNuFyRjXUJhpGdtbyLA, ref HDoDyrPJuHdqFIhFRRCtDDaekAXcb);
				}
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

		~DualRingReportBuffer()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!UHkcvXaBbEcowMhgCiUTzayJdzwU)
			{
				UHkcvXaBbEcowMhgCiUTzayJdzwU = true;
			}
		}
	}
}
