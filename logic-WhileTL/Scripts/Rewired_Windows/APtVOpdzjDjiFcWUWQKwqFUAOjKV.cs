using System;
using System.Runtime.InteropServices;

internal class APtVOpdzjDjiFcWUWQKwqFUAOjKV : IDisposable
{
	public struct gmUElDAmKitdOWuKxnsyGrRxGFKBA
	{
		private byte ZoUQBuFLkjUBOakdcCQDwOJQsSHI;

		private uint XPPoplfAOEtVBtfDKuosluzFSof;

		private int UrBCeIhKaawIpPYPUCSoRIQLeJQFb;

		private static gmUElDAmKitdOWuKxnsyGrRxGFKBA DcQhlULHhWVEoaeAEYzFvTgVGOJg;

		public byte JhNSmsAsUwOEgLORwutBefSLnAEC => ZoUQBuFLkjUBOakdcCQDwOJQsSHI;

		public uint BkCCRoCAlOkhzgIhSBhlxcEDOjsWA => XPPoplfAOEtVBtfDKuosluzFSof;

		public int MjlfOHCqHCxSEEcyLojwQICwQkyr => UrBCeIhKaawIpPYPUCSoRIQLeJQFb;

		public static gmUElDAmKitdOWuKxnsyGrRxGFKBA YGPCJkerCdFzIaYpHULesgLscKhFb => DcQhlULHhWVEoaeAEYzFvTgVGOJg;

		public gmUElDAmKitdOWuKxnsyGrRxGFKBA(byte P_0, uint P_1, int P_2)
		{
			ZoUQBuFLkjUBOakdcCQDwOJQsSHI = P_0;
			XPPoplfAOEtVBtfDKuosluzFSof = P_1;
			UrBCeIhKaawIpPYPUCSoRIQLeJQFb = P_2;
			if (UrBCeIhKaawIpPYPUCSoRIQLeJQFb < 0)
			{
				UrBCeIhKaawIpPYPUCSoRIQLeJQFb = 0;
			}
		}
	}

	private const byte DCmNZNwObkDzKXYhrSKUSKbSqik = 254;

	private uint htanRGoqUKDOsXPAKBxEafEfHsZab;

	private int lnbPMXNVpjjcuWAYwENrAjhUFKwOA;

	private unsafe byte* QBQwoTdKykkMDDGyUuYpjURrYzLg;

	private byte ZoUQBuFLkjUBOakdcCQDwOJQsSHI;

	private bool NakIAXWSTNyAyurTisHbnrhZueDR;

	private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

	public int FfDDSSPkoVyXSlRGlShrtpjBTkxH => lnbPMXNVpjjcuWAYwENrAjhUFKwOA;

	public unsafe APtVOpdzjDjiFcWUWQKwqFUAOjKV(int P_0)
	{
		if (P_0 <= 0)
		{
			throw new Exception("size must be > 0!");
		}
		lnbPMXNVpjjcuWAYwENrAjhUFKwOA = P_0;
		htanRGoqUKDOsXPAKBxEafEfHsZab = 0u;
		QBQwoTdKykkMDDGyUuYpjURrYzLg = (byte*)(void*)Marshal.AllocHGlobal(P_0);
	}

	public unsafe bool EGngQqDBRXlpYmNfKVeBqXohueYWA(IntPtr P_0, int P_1, out gmUElDAmKitdOWuKxnsyGrRxGFKBA P_2)
	{
		if (QBQwoTdKykkMDDGyUuYpjURrYzLg == null || P_1 <= 0)
		{
			P_2 = default(gmUElDAmKitdOWuKxnsyGrRxGFKBA);
			return false;
		}
		if (P_1 > lnbPMXNVpjjcuWAYwENrAjhUFKwOA)
		{
			throw new Exception("Length is larger than the buffer.");
		}
		if ((uint)((int)htanRGoqUKDOsXPAKBxEafEfHsZab + P_1) >= lnbPMXNVpjjcuWAYwENrAjhUFKwOA)
		{
			htanRGoqUKDOsXPAKBxEafEfHsZab = 0u;
			if (ZoUQBuFLkjUBOakdcCQDwOJQsSHI == 254)
			{
				ZoUQBuFLkjUBOakdcCQDwOJQsSHI = 0;
				NakIAXWSTNyAyurTisHbnrhZueDR = true;
			}
			else
			{
				ZoUQBuFLkjUBOakdcCQDwOJQsSHI++;
			}
		}
		nxzMUSyCaMfSlEuvKxUcjBKIXFKl.LcaEYeAdvayPwpGOFBoudhPaVNWK(QBQwoTdKykkMDDGyUuYpjURrYzLg + htanRGoqUKDOsXPAKBxEafEfHsZab, (void*)P_0, new UIntPtr((uint)P_1));
		P_2 = new gmUElDAmKitdOWuKxnsyGrRxGFKBA(ZoUQBuFLkjUBOakdcCQDwOJQsSHI, htanRGoqUKDOsXPAKBxEafEfHsZab, P_1);
		htanRGoqUKDOsXPAKBxEafEfHsZab += (uint)P_1;
		return true;
	}

	public int lpzCMyRwfnpZCqiMQhipRjGrjZfC(gmUElDAmKitdOWuKxnsyGrRxGFKBA P_0, byte[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_1.Length < P_0.MjlfOHCqHCxSEEcyLojwQICwQkyr)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!mWoPXVFssGCHKUdaswoQNBWTLqFV(ref P_0))
		{
			return -1;
		}
		Marshal.Copy(FnOpUWBfNjxXtflJSWkGzVfQFQVe(P_0), P_1, 0, P_0.MjlfOHCqHCxSEEcyLojwQICwQkyr);
		return P_0.MjlfOHCqHCxSEEcyLojwQICwQkyr;
	}

	public unsafe int lpzCMyRwfnpZCqiMQhipRjGrjZfC(gmUElDAmKitdOWuKxnsyGrRxGFKBA P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new Exception("Buffer pointer is invalid.");
		}
		if (P_2 <= 0)
		{
			return -1;
		}
		if (P_2 < P_0.MjlfOHCqHCxSEEcyLojwQICwQkyr)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!mWoPXVFssGCHKUdaswoQNBWTLqFV(ref P_0))
		{
			return -1;
		}
		nxzMUSyCaMfSlEuvKxUcjBKIXFKl.LcaEYeAdvayPwpGOFBoudhPaVNWK((void*)P_1, QBQwoTdKykkMDDGyUuYpjURrYzLg, new UIntPtr((uint)P_0.MjlfOHCqHCxSEEcyLojwQICwQkyr));
		return P_0.MjlfOHCqHCxSEEcyLojwQICwQkyr;
	}

	public unsafe IntPtr FnOpUWBfNjxXtflJSWkGzVfQFQVe(gmUElDAmKitdOWuKxnsyGrRxGFKBA P_0)
	{
		if (QBQwoTdKykkMDDGyUuYpjURrYzLg == null || !mWoPXVFssGCHKUdaswoQNBWTLqFV(ref P_0))
		{
			return IntPtr.Zero;
		}
		return (IntPtr)(QBQwoTdKykkMDDGyUuYpjURrYzLg + P_0.BkCCRoCAlOkhzgIhSBhlxcEDOjsWA);
	}

	public unsafe bool XegzSjIvdJUApYQaEEVyDBtsCaSk(gmUElDAmKitdOWuKxnsyGrRxGFKBA P_0, out IntPtr P_1)
	{
		if (QBQwoTdKykkMDDGyUuYpjURrYzLg == null || !mWoPXVFssGCHKUdaswoQNBWTLqFV(ref P_0))
		{
			P_1 = IntPtr.Zero;
			return false;
		}
		P_1 = (IntPtr)(QBQwoTdKykkMDDGyUuYpjURrYzLg + P_0.BkCCRoCAlOkhzgIhSBhlxcEDOjsWA);
		return true;
	}

	private bool mWoPXVFssGCHKUdaswoQNBWTLqFV(ref gmUElDAmKitdOWuKxnsyGrRxGFKBA P_0)
	{
		int num = P_0.MjlfOHCqHCxSEEcyLojwQICwQkyr;
		if (num <= 0)
		{
			return false;
		}
		uint num2 = P_0.JhNSmsAsUwOEgLORwutBefSLnAEC;
		if (num2 > 254)
		{
			return false;
		}
		if (num2 != ZoUQBuFLkjUBOakdcCQDwOJQsSHI)
		{
			if (!NakIAXWSTNyAyurTisHbnrhZueDR)
			{
				if (num2 + 1 != ZoUQBuFLkjUBOakdcCQDwOJQsSHI)
				{
					return false;
				}
			}
			else if (num2 > ZoUQBuFLkjUBOakdcCQDwOJQsSHI)
			{
				if (ZoUQBuFLkjUBOakdcCQDwOJQsSHI != 0 || num2 != 254)
				{
					return false;
				}
			}
			else if (num2 + 1 != ZoUQBuFLkjUBOakdcCQDwOJQsSHI)
			{
				return false;
			}
			if (P_0.BkCCRoCAlOkhzgIhSBhlxcEDOjsWA < htanRGoqUKDOsXPAKBxEafEfHsZab)
			{
				return false;
			}
		}
		else if (P_0.BkCCRoCAlOkhzgIhSBhlxcEDOjsWA + num > htanRGoqUKDOsXPAKBxEafEfHsZab)
		{
			return false;
		}
		if (P_0.BkCCRoCAlOkhzgIhSBhlxcEDOjsWA + num > lnbPMXNVpjjcuWAYwENrAjhUFKwOA)
		{
			return false;
		}
		return true;
	}

	public void Dispose()
	{
		hIlanWXkrCYfgvCyascUuCUOCBcL(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
	{
		try
		{
			hIlanWXkrCYfgvCyascUuCUOCBcL(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected unsafe virtual void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
	{
		if (!TExNvhkEWsBWipIUjadCDaTpNNDG)
		{
			if (QBQwoTdKykkMDDGyUuYpjURrYzLg != null)
			{
				Marshal.FreeHGlobal((IntPtr)QBQwoTdKykkMDDGyUuYpjURrYzLg);
			}
			TExNvhkEWsBWipIUjadCDaTpNNDG = true;
		}
	}
}
