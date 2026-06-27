using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class pXEMtXAjzAdSPdYHscBwifOaLqDkA<_0001> : IDisposable where _0001 : struct
{
	private static readonly int yPdCpiXQcIzfzKSImetEAHjYiHLcA = Marshal.SizeOf(typeof(_0001));

	private WCkkisRdteszJrItqAKVBwrIDACB KtrGDJXdnvwbDzuyBycCknMbPSDL;

	private bool lovzXoXlsgtSOsFQnhpcXirvmOrQ;

	public WCkkisRdteszJrItqAKVBwrIDACB dSbaYNVaWvdDoJwzbusNEPGxxkhu => KtrGDJXdnvwbDzuyBycCknMbPSDL;

	public bool NpJlKhobdnrSfvOUmMxrgspzoiFh
	{
		get
		{
			if (KtrGDJXdnvwbDzuyBycCknMbPSDL != null)
			{
				return KtrGDJXdnvwbDzuyBycCknMbPSDL.QutFGsgABgGPfQNiUrMvVJIqbUBsA != IntPtr.Zero;
			}
			return false;
		}
	}

	public unsafe _0001 DBBavThFHOYrxmjQYwmxgRtwFMUmA
	{
		get
		{
			gnGnWLzicosfIvOiHJyiPmNmrUKg();
			return Unsafe.Read<_0001>((void*)KtrGDJXdnvwbDzuyBycCknMbPSDL.QutFGsgABgGPfQNiUrMvVJIqbUBsA);
		}
		set
		{
			gnGnWLzicosfIvOiHJyiPmNmrUKg();
			_0001* ptr = &val;
			KtrGDJXdnvwbDzuyBycCknMbPSDL.dGMbKeBdSrhuZJvBHWiKxPDtjLCRA((IntPtr)ptr, yPdCpiXQcIzfzKSImetEAHjYiHLcA, yPdCpiXQcIzfzKSImetEAHjYiHLcA);
		}
	}

	public pXEMtXAjzAdSPdYHscBwifOaLqDkA()
	{
		KtrGDJXdnvwbDzuyBycCknMbPSDL = new WCkkisRdteszJrItqAKVBwrIDACB(yPdCpiXQcIzfzKSImetEAHjYiHLcA);
	}

	private void wELXJOBKWsNhyqCQlugnolGrISwm()
	{
		if (KtrGDJXdnvwbDzuyBycCknMbPSDL == null)
		{
			KtrGDJXdnvwbDzuyBycCknMbPSDL.Dispose();
			KtrGDJXdnvwbDzuyBycCknMbPSDL = null;
		}
	}

	private void gnGnWLzicosfIvOiHJyiPmNmrUKg()
	{
		if (!NpJlKhobdnrSfvOUmMxrgspzoiFh)
		{
			throw new Exception("Memory not allocated.");
		}
	}

	private void EXkXbGmDeOCDbIwijCEnlhdAbPet(bool P_0)
	{
		if (!lovzXoXlsgtSOsFQnhpcXirvmOrQ)
		{
			if (P_0)
			{
				wELXJOBKWsNhyqCQlugnolGrISwm();
			}
			lovzXoXlsgtSOsFQnhpcXirvmOrQ = true;
		}
	}

	public void Dispose()
	{
		EXkXbGmDeOCDbIwijCEnlhdAbPet(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
