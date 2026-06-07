using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class GOwQuODgGyQbIPeyyssTIOngfPqT : IEnumerable<byte>, IEnumerable, IDisposable
{
	private struct aTTvjstmxMfjejFiSOqjNAsqulinA : IEnumerator<byte>, IEnumerator, IDisposable
	{
		private GOwQuODgGyQbIPeyyssTIOngfPqT vqYXPZmYObQeWUPjMjXqEsdKcfRI;

		private int iacarRdWhHLXBtYKrQsCHsJXqMhU;

		byte IEnumerator<byte>.Current => vqYXPZmYObQeWUPjMjXqEsdKcfRI.NMlbrdOdwyUaoFjJZeRWxddPdbfv(iacarRdWhHLXBtYKrQsCHsJXqMhU);

		object IEnumerator.Current => vqYXPZmYObQeWUPjMjXqEsdKcfRI.NMlbrdOdwyUaoFjJZeRWxddPdbfv(iacarRdWhHLXBtYKrQsCHsJXqMhU);

		public aTTvjstmxMfjejFiSOqjNAsqulinA(GOwQuODgGyQbIPeyyssTIOngfPqT P_0)
		{
			vqYXPZmYObQeWUPjMjXqEsdKcfRI = P_0;
			iacarRdWhHLXBtYKrQsCHsJXqMhU = -1;
		}

		public void Dispose()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		public bool MoveNext()
		{
			if (iacarRdWhHLXBtYKrQsCHsJXqMhU >= vqYXPZmYObQeWUPjMjXqEsdKcfRI.CphcPIkWFlQttDAWxoBjKhjaWvfm - 1)
			{
				return false;
			}
			iacarRdWhHLXBtYKrQsCHsJXqMhU++;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		public void Reset()
		{
			iacarRdWhHLXBtYKrQsCHsJXqMhU = 0;
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Reset
			this.Reset();
		}
	}

	private int CphcPIkWFlQttDAWxoBjKhjaWvfm;

	private unsafe byte* sUsBYKBKhzuzOXzhfIGFLhayVDPI;

	public int RMBCvnofOmkhdsTFtJhkevHydUmb => CphcPIkWFlQttDAWxoBjKhjaWvfm;

	public unsafe bool LHuefiMmEIwQKXzwdhwgEiXROyQH
	{
		get
		{
			if (CphcPIkWFlQttDAWxoBjKhjaWvfm <= 0)
			{
				return true;
			}
			return sUsBYKBKhzuzOXzhfIGFLhayVDPI != null;
		}
	}

	public unsafe byte qguCjPVgTbFrqhUotGtQaGxJMgxgb
	{
		get
		{
			if (P_0 < 0 || P_0 >= CphcPIkWFlQttDAWxoBjKhjaWvfm)
			{
				throw new IndexOutOfRangeException();
			}
			return sUsBYKBKhzuzOXzhfIGFLhayVDPI[P_0];
		}
		set
		{
			if (num < 0 || num >= CphcPIkWFlQttDAWxoBjKhjaWvfm)
			{
				throw new IndexOutOfRangeException();
			}
			sUsBYKBKhzuzOXzhfIGFLhayVDPI[num] = b;
		}
	}

	public GOwQuODgGyQbIPeyyssTIOngfPqT(int P_0)
	{
		oIVTubLMUijamYgabXnOvKpeUGXO(P_0);
	}

	public unsafe GOwQuODgGyQbIPeyyssTIOngfPqT(params byte[] P_0)
		: this(P_0.Length)
	{
		Marshal.Copy(P_0, 0, (IntPtr)sUsBYKBKhzuzOXzhfIGFLhayVDPI, P_0.Length);
	}

	public GOwQuODgGyQbIPeyyssTIOngfPqT(GOwQuODgGyQbIPeyyssTIOngfPqT P_0)
		: this(P_0.CphcPIkWFlQttDAWxoBjKhjaWvfm)
	{
		P_0.DajiSKjMKMJZbSHloogLSPNhOSJT(this, 0, P_0.CphcPIkWFlQttDAWxoBjKhjaWvfm);
	}

	public unsafe GOwQuODgGyQbIPeyyssTIOngfPqT(byte* P_0, int P_1)
		: this(P_1)
	{
		gkeZAoVSdvnpEhiPWCalNOchbIMDA.gYqFkmTQPWPIZwbFWoQVKNfGqTtI(P_0, sUsBYKBKhzuzOXzhfIGFLhayVDPI, 0, 0, P_1);
	}

	public unsafe bool dMkNQIxPHnYyYVBRtPWcqlEtDxmI(byte* P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= CphcPIkWFlQttDAWxoBjKhjaWvfm || P_2 >= P_1)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > CphcPIkWFlQttDAWxoBjKhjaWvfm || P_3 > P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_3 + P_2;
		if (num >= CphcPIkWFlQttDAWxoBjKhjaWvfm || num >= P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return gkeZAoVSdvnpEhiPWCalNOchbIMDA.gYqFkmTQPWPIZwbFWoQVKNfGqTtI(sUsBYKBKhzuzOXzhfIGFLhayVDPI, P_0, P_2, P_2, P_3);
	}

	public unsafe bool DajiSKjMKMJZbSHloogLSPNhOSJT(GOwQuODgGyQbIPeyyssTIOngfPqT P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return dMkNQIxPHnYyYVBRtPWcqlEtDxmI(P_0.sUsBYKBKhzuzOXzhfIGFLhayVDPI, P_0.CphcPIkWFlQttDAWxoBjKhjaWvfm, P_1, P_2, P_3);
	}

	public unsafe bool uQKbaFlCKPWggOLPdvNSvjIzRTjG(byte[] P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= CphcPIkWFlQttDAWxoBjKhjaWvfm || P_1 >= P_0.Length)
		{
			if (P_3)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 <= 0 || P_2 > CphcPIkWFlQttDAWxoBjKhjaWvfm || P_2 > P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_2 + P_1;
		if (num >= CphcPIkWFlQttDAWxoBjKhjaWvfm || num >= P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)sUsBYKBKhzuzOXzhfIGFLhayVDPI, P_0, P_1, P_1, P_2, P_3);
	}

	public unsafe bool neHHdpjwAACvxdENNPNzpPyskrItA(byte* P_0, int P_1, int P_2, int P_3, int P_4, bool P_5 = true)
	{
		if (P_0 == null)
		{
			if (P_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= CphcPIkWFlQttDAWxoBjKhjaWvfm)
		{
			if (P_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 < 0 || P_3 >= P_1)
		{
			if (P_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_4 <= 0 || P_4 > CphcPIkWFlQttDAWxoBjKhjaWvfm || P_4 > P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_4 + P_2 >= CphcPIkWFlQttDAWxoBjKhjaWvfm)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex + length must be < source.Length");
			}
			return false;
		}
		if (P_4 + P_3 >= P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex + length must be < destination.Length");
			}
			return false;
		}
		return gkeZAoVSdvnpEhiPWCalNOchbIMDA.gYqFkmTQPWPIZwbFWoQVKNfGqTtI(sUsBYKBKhzuzOXzhfIGFLhayVDPI, P_0, P_2, P_3, P_4);
	}

	public unsafe bool UhxQjQdErdWHOYxTeBIamzNneAFp(GOwQuODgGyQbIPeyyssTIOngfPqT P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return neHHdpjwAACvxdENNPNzpPyskrItA(P_0.sUsBYKBKhzuzOXzhfIGFLhayVDPI, P_0.CphcPIkWFlQttDAWxoBjKhjaWvfm, P_1, P_2, P_3, P_4);
	}

	public unsafe bool LqSHqfgMdudGljfQgcuUeaVdbgjrA(byte[] P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= CphcPIkWFlQttDAWxoBjKhjaWvfm)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= P_0.Length)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > CphcPIkWFlQttDAWxoBjKhjaWvfm || P_3 > P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_3 + P_1 >= CphcPIkWFlQttDAWxoBjKhjaWvfm)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex + length must be < source.Length");
			}
			return false;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex + length must be < destination.Length");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)sUsBYKBKhzuzOXzhfIGFLhayVDPI, P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool HqjVPfSKzFILXSLhcjozKtmgnhtd(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= CphcPIkWFlQttDAWxoBjKhjaWvfm || P_2 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		int num = P_3 + P_2;
		if (num >= CphcPIkWFlQttDAWxoBjKhjaWvfm)
		{
			P_3 = CphcPIkWFlQttDAWxoBjKhjaWvfm - P_2;
		}
		if (num >= P_1)
		{
			P_3 = P_1 - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return gkeZAoVSdvnpEhiPWCalNOchbIMDA.gYqFkmTQPWPIZwbFWoQVKNfGqTtI(sUsBYKBKhzuzOXzhfIGFLhayVDPI, P_0, P_2, P_2, P_3);
	}

	public unsafe bool eVUeVodVjovUQsXxlvwByKjewCXg(GOwQuODgGyQbIPeyyssTIOngfPqT P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		return HqjVPfSKzFILXSLhcjozKtmgnhtd(P_0.sUsBYKBKhzuzOXzhfIGFLhayVDPI, P_0.CphcPIkWFlQttDAWxoBjKhjaWvfm, P_1, P_2);
	}

	public unsafe bool MfFVVMXEixXSYxFGLZflYceMocFd(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= CphcPIkWFlQttDAWxoBjKhjaWvfm || P_1 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		int num = P_2 + P_1;
		if (num >= CphcPIkWFlQttDAWxoBjKhjaWvfm)
		{
			P_2 = CphcPIkWFlQttDAWxoBjKhjaWvfm - P_1;
		}
		if (num >= P_0.Length)
		{
			P_2 = P_0.Length - P_1;
		}
		if (P_2 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)sUsBYKBKhzuzOXzhfIGFLhayVDPI, P_0, P_1, P_1, P_2, throwOnError: false);
	}

	public unsafe bool ogIRvMWLVDfQfAdJUlLrzpGbrEYNA(byte* P_0, int P_1, int P_2, int P_3, int P_4)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= CphcPIkWFlQttDAWxoBjKhjaWvfm)
		{
			return false;
		}
		if (P_3 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 + P_2 >= CphcPIkWFlQttDAWxoBjKhjaWvfm)
		{
			P_4 = CphcPIkWFlQttDAWxoBjKhjaWvfm - P_2;
		}
		if (P_4 + P_3 >= P_1)
		{
			P_4 = P_1 - P_3;
		}
		if (P_4 <= 0)
		{
			return false;
		}
		return gkeZAoVSdvnpEhiPWCalNOchbIMDA.gYqFkmTQPWPIZwbFWoQVKNfGqTtI(sUsBYKBKhzuzOXzhfIGFLhayVDPI, P_0, P_2, P_3, P_4);
	}

	public unsafe bool gMnGiSknBvfxjjaLzPURdukaTFYCB(GOwQuODgGyQbIPeyyssTIOngfPqT P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		return ogIRvMWLVDfQfAdJUlLrzpGbrEYNA(P_0.sUsBYKBKhzuzOXzhfIGFLhayVDPI, P_0.CphcPIkWFlQttDAWxoBjKhjaWvfm, P_1, P_2, P_3);
	}

	public unsafe bool QJUZBukqobxjDnQEYmswlflDIago(byte[] P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= CphcPIkWFlQttDAWxoBjKhjaWvfm)
		{
			return false;
		}
		if (P_2 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 + P_1 >= CphcPIkWFlQttDAWxoBjKhjaWvfm)
		{
			P_3 = CphcPIkWFlQttDAWxoBjKhjaWvfm - P_1;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			P_3 = P_0.Length - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)sUsBYKBKhzuzOXzhfIGFLhayVDPI, P_0, P_1, P_2, P_3, throwOnError: false);
	}

	public void bCbuXcOnllsWvEpljUTaZOJNcfWg(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("length must be >= 0");
		}
		if (CphcPIkWFlQttDAWxoBjKhjaWvfm != P_0)
		{
			oIVTubLMUijamYgabXnOvKpeUGXO(P_0);
		}
	}

	public unsafe void kdNUVNlLIANVFPXFbMpdYnhyIiuT()
	{
		if (CphcPIkWFlQttDAWxoBjKhjaWvfm != 0 && sUsBYKBKhzuzOXzhfIGFLhayVDPI != null)
		{
			gkeZAoVSdvnpEhiPWCalNOchbIMDA.FIpRwqifBWkeENHkDcWIQXtqBdtR(sUsBYKBKhzuzOXzhfIGFLhayVDPI, CphcPIkWFlQttDAWxoBjKhjaWvfm);
		}
	}

	private unsafe void oIVTubLMUijamYgabXnOvKpeUGXO(int P_0)
	{
		if (P_0 == CphcPIkWFlQttDAWxoBjKhjaWvfm)
		{
			kdNUVNlLIANVFPXFbMpdYnhyIiuT();
			return;
		}
		if (CphcPIkWFlQttDAWxoBjKhjaWvfm > 0)
		{
			jBtCBJKrUsEjXZMLjZHyPhhONvtP();
		}
		sUsBYKBKhzuzOXzhfIGFLhayVDPI = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		if (sUsBYKBKhzuzOXzhfIGFLhayVDPI == null)
		{
			throw new Exception("Could not allocate memory for array.");
		}
		CphcPIkWFlQttDAWxoBjKhjaWvfm = P_0;
		kdNUVNlLIANVFPXFbMpdYnhyIiuT();
	}

	private unsafe void jBtCBJKrUsEjXZMLjZHyPhhONvtP()
	{
		if (sUsBYKBKhzuzOXzhfIGFLhayVDPI != null)
		{
			Marshal.FreeHGlobal((IntPtr)sUsBYKBKhzuzOXzhfIGFLhayVDPI);
		}
		sUsBYKBKhzuzOXzhfIGFLhayVDPI = null;
		CphcPIkWFlQttDAWxoBjKhjaWvfm = 0;
	}

	public void Dispose()
	{
		rkcEkzAeCzixzFXcAUOJxOGDnvUt(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void OerAtRzBFJJuLGlFzqZhesZRapXw()
	{
		try
		{
			rkcEkzAeCzixzFXcAUOJxOGDnvUt(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void rkcEkzAeCzixzFXcAUOJxOGDnvUt(bool P_0)
	{
		jBtCBJKrUsEjXZMLjZHyPhhONvtP();
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return new aTTvjstmxMfjejFiSOqjNAsqulinA(this);
	}

	IEnumerator<byte> IEnumerable<byte>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
		return this.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new aTTvjstmxMfjejFiSOqjNAsqulinA(this);
	}
}
