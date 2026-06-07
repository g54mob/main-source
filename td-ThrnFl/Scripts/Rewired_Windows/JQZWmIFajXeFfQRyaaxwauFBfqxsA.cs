using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class JQZWmIFajXeFfQRyaaxwauFBfqxsA : IEnumerable<byte>, IEnumerable, IDisposable
{
	private struct zdCvLdfOcfUqFJrYIiNLcXMTAJbr : IEnumerator<byte>, IEnumerator, IDisposable
	{
		private JQZWmIFajXeFfQRyaaxwauFBfqxsA aPnAyAcfRsEjmftOVOGpdVlwjTUEA;

		private int BLhStjCMwRwXEXsKzivccjccpVXw;

		byte IEnumerator<byte>.Current => aPnAyAcfRsEjmftOVOGpdVlwjTUEA.ceRHWkiSuzzCwMqWuHeErDaBpkoY(BLhStjCMwRwXEXsKzivccjccpVXw);

		object IEnumerator.Current => aPnAyAcfRsEjmftOVOGpdVlwjTUEA.ceRHWkiSuzzCwMqWuHeErDaBpkoY(BLhStjCMwRwXEXsKzivccjccpVXw);

		public zdCvLdfOcfUqFJrYIiNLcXMTAJbr(JQZWmIFajXeFfQRyaaxwauFBfqxsA P_0)
		{
			aPnAyAcfRsEjmftOVOGpdVlwjTUEA = P_0;
			BLhStjCMwRwXEXsKzivccjccpVXw = -1;
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
			if (BLhStjCMwRwXEXsKzivccjccpVXw >= aPnAyAcfRsEjmftOVOGpdVlwjTUEA.STEzluZWLhDkPoJLfPzzSTJUgoFw - 1)
			{
				return false;
			}
			BLhStjCMwRwXEXsKzivccjccpVXw++;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		public void Reset()
		{
			BLhStjCMwRwXEXsKzivccjccpVXw = 0;
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Reset
			this.Reset();
		}
	}

	private int STEzluZWLhDkPoJLfPzzSTJUgoFw;

	private unsafe byte* qnjGWQpccOXRsmhgVrJLawwMNTUN;

	public int rVICWMSxapiCkbTZBNEWZLZJLwqs => STEzluZWLhDkPoJLfPzzSTJUgoFw;

	public unsafe bool ZjMyWdPzlTbohtKcfSukrOHGAwmg
	{
		get
		{
			if (STEzluZWLhDkPoJLfPzzSTJUgoFw <= 0)
			{
				return true;
			}
			return qnjGWQpccOXRsmhgVrJLawwMNTUN != null;
		}
	}

	public unsafe byte xfOPiikkKiaKOlBMXPJPnhNJCZTg
	{
		get
		{
			if (P_0 < 0 || P_0 >= STEzluZWLhDkPoJLfPzzSTJUgoFw)
			{
				throw new IndexOutOfRangeException();
			}
			return qnjGWQpccOXRsmhgVrJLawwMNTUN[P_0];
		}
		set
		{
			if (num < 0 || num >= STEzluZWLhDkPoJLfPzzSTJUgoFw)
			{
				throw new IndexOutOfRangeException();
			}
			qnjGWQpccOXRsmhgVrJLawwMNTUN[num] = b;
		}
	}

	public JQZWmIFajXeFfQRyaaxwauFBfqxsA(int P_0)
	{
		HauQdxZBAwPkMjHbOyqDuVZOkmji(P_0);
	}

	public unsafe JQZWmIFajXeFfQRyaaxwauFBfqxsA(params byte[] P_0)
		: this(P_0.Length)
	{
		Marshal.Copy(P_0, 0, (IntPtr)qnjGWQpccOXRsmhgVrJLawwMNTUN, P_0.Length);
	}

	public JQZWmIFajXeFfQRyaaxwauFBfqxsA(JQZWmIFajXeFfQRyaaxwauFBfqxsA P_0)
		: this(P_0.STEzluZWLhDkPoJLfPzzSTJUgoFw)
	{
		P_0.eSHOqZrqBlrBtlkKcrHxpEXMcKoiA(this, 0, P_0.STEzluZWLhDkPoJLfPzzSTJUgoFw);
	}

	public unsafe JQZWmIFajXeFfQRyaaxwauFBfqxsA(byte* P_0, int P_1)
		: this(P_1)
	{
		EKnkiWpmsWIwmATuShvoOkPhQPyF.AnUHzRflyKdroulueRYYDxZIQpAg(P_0, qnjGWQpccOXRsmhgVrJLawwMNTUN, 0, 0, P_1);
	}

	public unsafe bool KAYtiPMzGbEcqMKDuznTifsqkQfp(byte* P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= STEzluZWLhDkPoJLfPzzSTJUgoFw || P_2 >= P_1)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > STEzluZWLhDkPoJLfPzzSTJUgoFw || P_3 > P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_3 + P_2;
		if (num >= STEzluZWLhDkPoJLfPzzSTJUgoFw || num >= P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return EKnkiWpmsWIwmATuShvoOkPhQPyF.AnUHzRflyKdroulueRYYDxZIQpAg(qnjGWQpccOXRsmhgVrJLawwMNTUN, P_0, P_2, P_2, P_3);
	}

	public unsafe bool eSHOqZrqBlrBtlkKcrHxpEXMcKoiA(JQZWmIFajXeFfQRyaaxwauFBfqxsA P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return KAYtiPMzGbEcqMKDuznTifsqkQfp(P_0.qnjGWQpccOXRsmhgVrJLawwMNTUN, P_0.STEzluZWLhDkPoJLfPzzSTJUgoFw, P_1, P_2, P_3);
	}

	public unsafe bool bHwMgdjCbqvvTwbjajhWhxWbRGHOA(byte[] P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= STEzluZWLhDkPoJLfPzzSTJUgoFw || P_1 >= P_0.Length)
		{
			if (P_3)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 <= 0 || P_2 > STEzluZWLhDkPoJLfPzzSTJUgoFw || P_2 > P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_2 + P_1;
		if (num >= STEzluZWLhDkPoJLfPzzSTJUgoFw || num >= P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)qnjGWQpccOXRsmhgVrJLawwMNTUN, P_0, P_1, P_1, P_2, P_3);
	}

	public unsafe bool CcLgloicqlwdkgcMjpemXtHuyIxPA(byte* P_0, int P_1, int P_2, int P_3, int P_4, bool P_5 = true)
	{
		if (P_0 == null)
		{
			if (P_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= STEzluZWLhDkPoJLfPzzSTJUgoFw)
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
		if (P_4 <= 0 || P_4 > STEzluZWLhDkPoJLfPzzSTJUgoFw || P_4 > P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_4 + P_2 >= STEzluZWLhDkPoJLfPzzSTJUgoFw)
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
		return EKnkiWpmsWIwmATuShvoOkPhQPyF.AnUHzRflyKdroulueRYYDxZIQpAg(qnjGWQpccOXRsmhgVrJLawwMNTUN, P_0, P_2, P_3, P_4);
	}

	public unsafe bool ovEgxNqcrBeeqjUhaKscjsfmfwPkA(JQZWmIFajXeFfQRyaaxwauFBfqxsA P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return CcLgloicqlwdkgcMjpemXtHuyIxPA(P_0.qnjGWQpccOXRsmhgVrJLawwMNTUN, P_0.STEzluZWLhDkPoJLfPzzSTJUgoFw, P_1, P_2, P_3, P_4);
	}

	public unsafe bool DFOBUZFjhhTTedxmmoiZnhowAvxE(byte[] P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= STEzluZWLhDkPoJLfPzzSTJUgoFw)
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
		if (P_3 <= 0 || P_3 > STEzluZWLhDkPoJLfPzzSTJUgoFw || P_3 > P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_3 + P_1 >= STEzluZWLhDkPoJLfPzzSTJUgoFw)
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
		return NativeTools.CopyMemory((IntPtr)qnjGWQpccOXRsmhgVrJLawwMNTUN, P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool iPsvqUSiUjnaeoEkqoYQAmUVNPeV(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= STEzluZWLhDkPoJLfPzzSTJUgoFw || P_2 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		int num = P_3 + P_2;
		if (num >= STEzluZWLhDkPoJLfPzzSTJUgoFw)
		{
			P_3 = STEzluZWLhDkPoJLfPzzSTJUgoFw - P_2;
		}
		if (num >= P_1)
		{
			P_3 = P_1 - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return EKnkiWpmsWIwmATuShvoOkPhQPyF.AnUHzRflyKdroulueRYYDxZIQpAg(qnjGWQpccOXRsmhgVrJLawwMNTUN, P_0, P_2, P_2, P_3);
	}

	public unsafe bool cYgdodUlcvcIUmVoeHFdBLEjXGZdA(JQZWmIFajXeFfQRyaaxwauFBfqxsA P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		return iPsvqUSiUjnaeoEkqoYQAmUVNPeV(P_0.qnjGWQpccOXRsmhgVrJLawwMNTUN, P_0.STEzluZWLhDkPoJLfPzzSTJUgoFw, P_1, P_2);
	}

	public unsafe bool HelRGPAiLujGqihblrSkcMrkORchB(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= STEzluZWLhDkPoJLfPzzSTJUgoFw || P_1 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		int num = P_2 + P_1;
		if (num >= STEzluZWLhDkPoJLfPzzSTJUgoFw)
		{
			P_2 = STEzluZWLhDkPoJLfPzzSTJUgoFw - P_1;
		}
		if (num >= P_0.Length)
		{
			P_2 = P_0.Length - P_1;
		}
		if (P_2 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)qnjGWQpccOXRsmhgVrJLawwMNTUN, P_0, P_1, P_1, P_2, throwOnError: false);
	}

	public unsafe bool SFxsRKiCxBFGBVnsNFDpaGTiWAwo(byte* P_0, int P_1, int P_2, int P_3, int P_4)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= STEzluZWLhDkPoJLfPzzSTJUgoFw)
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
		if (P_4 + P_2 >= STEzluZWLhDkPoJLfPzzSTJUgoFw)
		{
			P_4 = STEzluZWLhDkPoJLfPzzSTJUgoFw - P_2;
		}
		if (P_4 + P_3 >= P_1)
		{
			P_4 = P_1 - P_3;
		}
		if (P_4 <= 0)
		{
			return false;
		}
		return EKnkiWpmsWIwmATuShvoOkPhQPyF.AnUHzRflyKdroulueRYYDxZIQpAg(qnjGWQpccOXRsmhgVrJLawwMNTUN, P_0, P_2, P_3, P_4);
	}

	public unsafe bool rAUaZlbFAzlWwTATphwxbeodFFkJ(JQZWmIFajXeFfQRyaaxwauFBfqxsA P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		return SFxsRKiCxBFGBVnsNFDpaGTiWAwo(P_0.qnjGWQpccOXRsmhgVrJLawwMNTUN, P_0.STEzluZWLhDkPoJLfPzzSTJUgoFw, P_1, P_2, P_3);
	}

	public unsafe bool qcRpsSNZVEiisNrGTWqTpHiJeeHS(byte[] P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= STEzluZWLhDkPoJLfPzzSTJUgoFw)
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
		if (P_3 + P_1 >= STEzluZWLhDkPoJLfPzzSTJUgoFw)
		{
			P_3 = STEzluZWLhDkPoJLfPzzSTJUgoFw - P_1;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			P_3 = P_0.Length - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)qnjGWQpccOXRsmhgVrJLawwMNTUN, P_0, P_1, P_2, P_3, throwOnError: false);
	}

	public void MrVKrSwDvHvtcBMnhFEiHTwvJmNxA(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("length must be >= 0");
		}
		if (STEzluZWLhDkPoJLfPzzSTJUgoFw != P_0)
		{
			HauQdxZBAwPkMjHbOyqDuVZOkmji(P_0);
		}
	}

	public unsafe void AOMAtZeMTAXKlkwISrXftsEgDwcs()
	{
		if (STEzluZWLhDkPoJLfPzzSTJUgoFw != 0 && qnjGWQpccOXRsmhgVrJLawwMNTUN != null)
		{
			EKnkiWpmsWIwmATuShvoOkPhQPyF.viXKbDlkVMGfteQQGzswfJwIvJei(qnjGWQpccOXRsmhgVrJLawwMNTUN, STEzluZWLhDkPoJLfPzzSTJUgoFw);
		}
	}

	private unsafe void HauQdxZBAwPkMjHbOyqDuVZOkmji(int P_0)
	{
		if (P_0 == STEzluZWLhDkPoJLfPzzSTJUgoFw)
		{
			AOMAtZeMTAXKlkwISrXftsEgDwcs();
			return;
		}
		if (STEzluZWLhDkPoJLfPzzSTJUgoFw > 0)
		{
			LKAiYMoPaCJRTBqMMabgbnEmcFZJA();
		}
		qnjGWQpccOXRsmhgVrJLawwMNTUN = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		if (qnjGWQpccOXRsmhgVrJLawwMNTUN == null)
		{
			throw new Exception("Could not allocate memory for array.");
		}
		STEzluZWLhDkPoJLfPzzSTJUgoFw = P_0;
		AOMAtZeMTAXKlkwISrXftsEgDwcs();
	}

	private unsafe void LKAiYMoPaCJRTBqMMabgbnEmcFZJA()
	{
		if (qnjGWQpccOXRsmhgVrJLawwMNTUN != null)
		{
			Marshal.FreeHGlobal((IntPtr)qnjGWQpccOXRsmhgVrJLawwMNTUN);
		}
		qnjGWQpccOXRsmhgVrJLawwMNTUN = null;
		STEzluZWLhDkPoJLfPzzSTJUgoFw = 0;
	}

	public void Dispose()
	{
		XOYWpwgXdBNAvvHjxMEskhzgADaEA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void EZtLZyPQPzMGnbePKWWHAGmSdzRX()
	{
		try
		{
			XOYWpwgXdBNAvvHjxMEskhzgADaEA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void XOYWpwgXdBNAvvHjxMEskhzgADaEA(bool P_0)
	{
		LKAiYMoPaCJRTBqMMabgbnEmcFZJA();
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return new zdCvLdfOcfUqFJrYIiNLcXMTAJbr(this);
	}

	IEnumerator<byte> IEnumerable<byte>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
		return this.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new zdCvLdfOcfUqFJrYIiNLcXMTAJbr(this);
	}
}
