using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class DOvVhFXvgXJAtWWoeIMmoVfqSFtA : IDisposable, IEnumerable<byte>, IEnumerable
{
	private struct rCToOQdUkYdeuVtcMCgzcGEtQlBQ : IDisposable, IEnumerator<byte>, IEnumerator
	{
		private DOvVhFXvgXJAtWWoeIMmoVfqSFtA wPQCQXCFRCIjiXBJcwdKErQkHIMcb;

		private int xrosEEyXLlvTzQlfyIhzHqIxLyyvA;

		public byte Current => wPQCQXCFRCIjiXBJcwdKErQkHIMcb.qrIASlMGLGnVwTSBFkDWOwAXcvax(xrosEEyXLlvTzQlfyIhzHqIxLyyvA);

		object IEnumerator.Current => wPQCQXCFRCIjiXBJcwdKErQkHIMcb.qrIASlMGLGnVwTSBFkDWOwAXcvax(xrosEEyXLlvTzQlfyIhzHqIxLyyvA);

		public rCToOQdUkYdeuVtcMCgzcGEtQlBQ(DOvVhFXvgXJAtWWoeIMmoVfqSFtA P_0)
		{
			wPQCQXCFRCIjiXBJcwdKErQkHIMcb = P_0;
			xrosEEyXLlvTzQlfyIhzHqIxLyyvA = -1;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (xrosEEyXLlvTzQlfyIhzHqIxLyyvA >= wPQCQXCFRCIjiXBJcwdKErQkHIMcb.AZhQJGaSuJAjHcWRLuegYXjYvVYw - 1)
			{
				return false;
			}
			xrosEEyXLlvTzQlfyIhzHqIxLyyvA++;
			return true;
		}

		public void Reset()
		{
			xrosEEyXLlvTzQlfyIhzHqIxLyyvA = 0;
		}
	}

	private int AZhQJGaSuJAjHcWRLuegYXjYvVYw;

	private unsafe byte* UPGvMgRDWwlhHHpXHBIuibQSseTK;

	public int yIVYFnpBLClvFaTdWwokHpQgDIPu => AZhQJGaSuJAjHcWRLuegYXjYvVYw;

	public unsafe bool LOAKUriHGZEbByAroDTyQAHhOjqU
	{
		get
		{
			if (AZhQJGaSuJAjHcWRLuegYXjYvVYw <= 0)
			{
				return true;
			}
			return UPGvMgRDWwlhHHpXHBIuibQSseTK != null;
		}
	}

	public unsafe byte uYZQJGUmbMuICFZWSqJprRCobGI
	{
		get
		{
			if (P_0 < 0 || P_0 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
			{
				throw new IndexOutOfRangeException();
			}
			return UPGvMgRDWwlhHHpXHBIuibQSseTK[P_0];
		}
		set
		{
			if (num < 0 || num >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
			{
				throw new IndexOutOfRangeException();
			}
			UPGvMgRDWwlhHHpXHBIuibQSseTK[num] = b;
		}
	}

	public DOvVhFXvgXJAtWWoeIMmoVfqSFtA(int P_0)
	{
		LucPkylTTXgrBjaDzRQoCLFlGsmA(P_0);
	}

	public unsafe DOvVhFXvgXJAtWWoeIMmoVfqSFtA(params byte[] P_0)
		: this(P_0.Length)
	{
		Marshal.Copy(P_0, 0, (IntPtr)UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0.Length);
	}

	public DOvVhFXvgXJAtWWoeIMmoVfqSFtA(DOvVhFXvgXJAtWWoeIMmoVfqSFtA P_0)
		: this(P_0.AZhQJGaSuJAjHcWRLuegYXjYvVYw)
	{
		P_0.VbEOiRdfeNOtSeESPhtPtdVLDibdA(this, 0, P_0.AZhQJGaSuJAjHcWRLuegYXjYvVYw);
	}

	public unsafe DOvVhFXvgXJAtWWoeIMmoVfqSFtA(byte* P_0, int P_1)
		: this(P_1)
	{
		MjelBjbhahSaBQQQQOiKWfHHDoKR.XzyKQtjTUtOkyLWLbIpJnkSlLGhP(P_0, UPGvMgRDWwlhHHpXHBIuibQSseTK, 0, 0, P_1);
	}

	public unsafe bool VbEOiRdfeNOtSeESPhtPtdVLDibdA(byte* P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw || P_2 >= P_1)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > AZhQJGaSuJAjHcWRLuegYXjYvVYw || P_3 > P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_3 + P_2;
		if (num >= AZhQJGaSuJAjHcWRLuegYXjYvVYw || num >= P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return MjelBjbhahSaBQQQQOiKWfHHDoKR.XzyKQtjTUtOkyLWLbIpJnkSlLGhP(UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0, P_2, P_2, P_3);
	}

	public unsafe bool VbEOiRdfeNOtSeESPhtPtdVLDibdA(DOvVhFXvgXJAtWWoeIMmoVfqSFtA P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return VbEOiRdfeNOtSeESPhtPtdVLDibdA(P_0.UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0.AZhQJGaSuJAjHcWRLuegYXjYvVYw, P_1, P_2, P_3);
	}

	public unsafe bool VbEOiRdfeNOtSeESPhtPtdVLDibdA(byte[] P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw || P_1 >= P_0.Length)
		{
			if (P_3)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 <= 0 || P_2 > AZhQJGaSuJAjHcWRLuegYXjYvVYw || P_2 > P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_2 + P_1;
		if (num >= AZhQJGaSuJAjHcWRLuegYXjYvVYw || num >= P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0, P_1, P_1, P_2, P_3);
	}

	public unsafe bool VbEOiRdfeNOtSeESPhtPtdVLDibdA(byte* P_0, int P_1, int P_2, int P_3, int P_4, bool P_5 = true)
	{
		if (P_0 == null)
		{
			if (P_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
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
		if (P_4 <= 0 || P_4 > AZhQJGaSuJAjHcWRLuegYXjYvVYw || P_4 > P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_4 + P_2 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
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
		return MjelBjbhahSaBQQQQOiKWfHHDoKR.XzyKQtjTUtOkyLWLbIpJnkSlLGhP(UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0, P_2, P_3, P_4);
	}

	public unsafe bool VbEOiRdfeNOtSeESPhtPtdVLDibdA(DOvVhFXvgXJAtWWoeIMmoVfqSFtA P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return VbEOiRdfeNOtSeESPhtPtdVLDibdA(P_0.UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0.AZhQJGaSuJAjHcWRLuegYXjYvVYw, P_1, P_2, P_3, P_4);
	}

	public unsafe bool VbEOiRdfeNOtSeESPhtPtdVLDibdA(byte[] P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
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
		if (P_3 <= 0 || P_3 > AZhQJGaSuJAjHcWRLuegYXjYvVYw || P_3 > P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_3 + P_1 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
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
		return NativeTools.CopyMemory((IntPtr)UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool TEEUXyjILIGQzELmaKQrnbHTQnjN(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw || P_2 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		int num = P_3 + P_2;
		if (num >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
		{
			P_3 = AZhQJGaSuJAjHcWRLuegYXjYvVYw - P_2;
		}
		if (num >= P_1)
		{
			P_3 = P_1 - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return MjelBjbhahSaBQQQQOiKWfHHDoKR.XzyKQtjTUtOkyLWLbIpJnkSlLGhP(UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0, P_2, P_2, P_3);
	}

	public unsafe bool TEEUXyjILIGQzELmaKQrnbHTQnjN(DOvVhFXvgXJAtWWoeIMmoVfqSFtA P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		return TEEUXyjILIGQzELmaKQrnbHTQnjN(P_0.UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0.AZhQJGaSuJAjHcWRLuegYXjYvVYw, P_1, P_2);
	}

	public unsafe bool TEEUXyjILIGQzELmaKQrnbHTQnjN(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw || P_1 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		int num = P_2 + P_1;
		if (num >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
		{
			P_2 = AZhQJGaSuJAjHcWRLuegYXjYvVYw - P_1;
		}
		if (num >= P_0.Length)
		{
			P_2 = P_0.Length - P_1;
		}
		if (P_2 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0, P_1, P_1, P_2, throwOnError: false);
	}

	public unsafe bool TEEUXyjILIGQzELmaKQrnbHTQnjN(byte* P_0, int P_1, int P_2, int P_3, int P_4)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
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
		if (P_4 + P_2 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
		{
			P_4 = AZhQJGaSuJAjHcWRLuegYXjYvVYw - P_2;
		}
		if (P_4 + P_3 >= P_1)
		{
			P_4 = P_1 - P_3;
		}
		if (P_4 <= 0)
		{
			return false;
		}
		return MjelBjbhahSaBQQQQOiKWfHHDoKR.XzyKQtjTUtOkyLWLbIpJnkSlLGhP(UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0, P_2, P_3, P_4);
	}

	public unsafe bool TEEUXyjILIGQzELmaKQrnbHTQnjN(DOvVhFXvgXJAtWWoeIMmoVfqSFtA P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		return TEEUXyjILIGQzELmaKQrnbHTQnjN(P_0.UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0.AZhQJGaSuJAjHcWRLuegYXjYvVYw, P_1, P_2, P_3);
	}

	public unsafe bool TEEUXyjILIGQzELmaKQrnbHTQnjN(byte[] P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
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
		if (P_3 + P_1 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
		{
			P_3 = AZhQJGaSuJAjHcWRLuegYXjYvVYw - P_1;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			P_3 = P_0.Length - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)UPGvMgRDWwlhHHpXHBIuibQSseTK, P_0, P_1, P_2, P_3, throwOnError: false);
	}

	public void ciNxePQCaXGCndIQgJjmJfiyBgXv(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("length must be >= 0");
		}
		if (AZhQJGaSuJAjHcWRLuegYXjYvVYw != P_0)
		{
			LucPkylTTXgrBjaDzRQoCLFlGsmA(P_0);
		}
	}

	public unsafe void DwNKXiEShimVDUzntAObjUXyaFmo()
	{
		if (AZhQJGaSuJAjHcWRLuegYXjYvVYw != 0 && UPGvMgRDWwlhHHpXHBIuibQSseTK != null)
		{
			MjelBjbhahSaBQQQQOiKWfHHDoKR.BzPycdFeBjNYJTPswhmQgfDRwXxd(UPGvMgRDWwlhHHpXHBIuibQSseTK, AZhQJGaSuJAjHcWRLuegYXjYvVYw);
		}
	}

	private unsafe void LucPkylTTXgrBjaDzRQoCLFlGsmA(int P_0)
	{
		if (P_0 == AZhQJGaSuJAjHcWRLuegYXjYvVYw)
		{
			DwNKXiEShimVDUzntAObjUXyaFmo();
			return;
		}
		if (AZhQJGaSuJAjHcWRLuegYXjYvVYw > 0)
		{
			CiWHJawzNztuqMnuKuQditzhrUSt();
		}
		UPGvMgRDWwlhHHpXHBIuibQSseTK = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		if (UPGvMgRDWwlhHHpXHBIuibQSseTK == null)
		{
			throw new Exception("Could not allocate memory for array.");
		}
		AZhQJGaSuJAjHcWRLuegYXjYvVYw = P_0;
		DwNKXiEShimVDUzntAObjUXyaFmo();
	}

	private unsafe void CiWHJawzNztuqMnuKuQditzhrUSt()
	{
		if (UPGvMgRDWwlhHHpXHBIuibQSseTK != null)
		{
			Marshal.FreeHGlobal((IntPtr)UPGvMgRDWwlhHHpXHBIuibQSseTK);
		}
		UPGvMgRDWwlhHHpXHBIuibQSseTK = null;
		AZhQJGaSuJAjHcWRLuegYXjYvVYw = 0;
	}

	public void Dispose()
	{
		vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
	{
		try
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		CiWHJawzNztuqMnuKuQditzhrUSt();
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return new rCToOQdUkYdeuVtcMCgzcGEtQlBQ(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new rCToOQdUkYdeuVtcMCgzcGEtQlBQ(this);
	}
}
