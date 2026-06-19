using System;
using System.Runtime.InteropServices;

internal class imHGwUVrRBakgbxhQeIjPjJfybEF : IDisposable
{
	public struct uPpHoSbAkTtTrSpAkjALzLUdIey
	{
		private byte zFomSPxtMfWndxMEiUgMliOdinH;

		private uint pilpsQJkuAWKsQKSHUTxbhbWJLk;

		private int qHbYWrgTCguIMVDkMGGdBRJkMDQd;

		private static uPpHoSbAkTtTrSpAkjALzLUdIey bloJEpfpJONUBdrBMMeGmdnqSXL;

		public byte pass => zFomSPxtMfWndxMEiUgMliOdinH;

		public uint offset => pilpsQJkuAWKsQKSHUTxbhbWJLk;

		public int length => qHbYWrgTCguIMVDkMGGdBRJkMDQd;

		public static uPpHoSbAkTtTrSpAkjALzLUdIey Invalid => bloJEpfpJONUBdrBMMeGmdnqSXL;

		public uPpHoSbAkTtTrSpAkjALzLUdIey(byte pass, uint offset, int length)
		{
			zFomSPxtMfWndxMEiUgMliOdinH = pass;
			pilpsQJkuAWKsQKSHUTxbhbWJLk = offset;
			qHbYWrgTCguIMVDkMGGdBRJkMDQd = length;
			if (qHbYWrgTCguIMVDkMGGdBRJkMDQd < 0)
			{
				qHbYWrgTCguIMVDkMGGdBRJkMDQd = 0;
			}
		}
	}

	private const byte nJoOlerEwtoOYXcrffFBTADUGQi = 254;

	private uint PBEmhlMheClGNYQjGAjFkKVGBcRG;

	private int RiJJwonoFtegPDbhiqPwweexFSgf;

	private unsafe byte* wEuKkANUgckCmAXoEgqcyAbKCWL;

	private byte zFomSPxtMfWndxMEiUgMliOdinH;

	private bool nPUsyeeAjXtQHnQogUFqqWmyVkD;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	public int size => RiJJwonoFtegPDbhiqPwweexFSgf;

	public unsafe imHGwUVrRBakgbxhQeIjPjJfybEF(int size)
	{
		if (size <= 0)
		{
			throw new Exception("size must be > 0!");
		}
		RiJJwonoFtegPDbhiqPwweexFSgf = size;
		PBEmhlMheClGNYQjGAjFkKVGBcRG = 0u;
		wEuKkANUgckCmAXoEgqcyAbKCWL = (byte*)(void*)Marshal.AllocHGlobal(size);
	}

	public unsafe bool ujTUoJrkpPHtthAWMneMiOxOImEn(IntPtr P_0, int P_1, out uPpHoSbAkTtTrSpAkjALzLUdIey P_2)
	{
		if (wEuKkANUgckCmAXoEgqcyAbKCWL == null || P_1 <= 0)
		{
			P_2 = default(uPpHoSbAkTtTrSpAkjALzLUdIey);
			return false;
		}
		if (P_1 > RiJJwonoFtegPDbhiqPwweexFSgf)
		{
			throw new Exception("Length is larger than the buffer.");
		}
		uint num = PBEmhlMheClGNYQjGAjFkKVGBcRG + (uint)P_1;
		if (num >= RiJJwonoFtegPDbhiqPwweexFSgf)
		{
			PBEmhlMheClGNYQjGAjFkKVGBcRG = 0u;
			if (zFomSPxtMfWndxMEiUgMliOdinH == 254)
			{
				zFomSPxtMfWndxMEiUgMliOdinH = 0;
				nPUsyeeAjXtQHnQogUFqqWmyVkD = true;
			}
			else
			{
				zFomSPxtMfWndxMEiUgMliOdinH++;
			}
		}
		HuTamtUgOYxfCNLWEcbrfgTfOVKO.lMSdiLkkXoQiJoufHQZtgXITTsA(wEuKkANUgckCmAXoEgqcyAbKCWL + (int)PBEmhlMheClGNYQjGAjFkKVGBcRG, (void*)P_0, new UIntPtr((uint)P_1));
		P_2 = new uPpHoSbAkTtTrSpAkjALzLUdIey(zFomSPxtMfWndxMEiUgMliOdinH, PBEmhlMheClGNYQjGAjFkKVGBcRG, P_1);
		PBEmhlMheClGNYQjGAjFkKVGBcRG += (uint)P_1;
		return true;
	}

	public int DTWqTxyQfjlbrIFGzfuUHiIHdt(uPpHoSbAkTtTrSpAkjALzLUdIey P_0, byte[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_1.Length < P_0.length)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!YeSGnwnBIEWDvBDFmDkVeOZwowB(ref P_0))
		{
			return -1;
		}
		Marshal.Copy(txgCPphKDpadCgaWUWINMaMzzNRR(P_0), P_1, 0, P_0.length);
		return P_0.length;
	}

	public unsafe int DTWqTxyQfjlbrIFGzfuUHiIHdt(uPpHoSbAkTtTrSpAkjALzLUdIey P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new Exception("Buffer pointer is invalid.");
		}
		if (P_2 <= 0)
		{
			return -1;
		}
		if (P_2 < P_0.length)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!YeSGnwnBIEWDvBDFmDkVeOZwowB(ref P_0))
		{
			return -1;
		}
		HuTamtUgOYxfCNLWEcbrfgTfOVKO.lMSdiLkkXoQiJoufHQZtgXITTsA((void*)P_1, wEuKkANUgckCmAXoEgqcyAbKCWL, new UIntPtr((uint)P_0.length));
		return P_0.length;
	}

	public unsafe IntPtr txgCPphKDpadCgaWUWINMaMzzNRR(uPpHoSbAkTtTrSpAkjALzLUdIey P_0)
	{
		if (wEuKkANUgckCmAXoEgqcyAbKCWL == null || !YeSGnwnBIEWDvBDFmDkVeOZwowB(ref P_0))
		{
			return IntPtr.Zero;
		}
		return (IntPtr)(wEuKkANUgckCmAXoEgqcyAbKCWL + (int)P_0.offset);
	}

	public unsafe bool jwYHtQiCHThMYHNLYBWdaEaDNIQq(uPpHoSbAkTtTrSpAkjALzLUdIey P_0, out IntPtr P_1)
	{
		if (wEuKkANUgckCmAXoEgqcyAbKCWL == null || !YeSGnwnBIEWDvBDFmDkVeOZwowB(ref P_0))
		{
			P_1 = IntPtr.Zero;
			return false;
		}
		P_1 = (IntPtr)(wEuKkANUgckCmAXoEgqcyAbKCWL + (int)P_0.offset);
		return true;
	}

	private bool YeSGnwnBIEWDvBDFmDkVeOZwowB(ref uPpHoSbAkTtTrSpAkjALzLUdIey P_0)
	{
		int length = P_0.length;
		if (length <= 0)
		{
			return false;
		}
		uint pass = P_0.pass;
		if (pass > 254)
		{
			return false;
		}
		if (pass != zFomSPxtMfWndxMEiUgMliOdinH)
		{
			if (!nPUsyeeAjXtQHnQogUFqqWmyVkD)
			{
				if (pass + 1 != zFomSPxtMfWndxMEiUgMliOdinH)
				{
					return false;
				}
			}
			else if (pass > zFomSPxtMfWndxMEiUgMliOdinH)
			{
				if (zFomSPxtMfWndxMEiUgMliOdinH != 0 || pass != 254)
				{
					return false;
				}
			}
			else if (pass + 1 != zFomSPxtMfWndxMEiUgMliOdinH)
			{
				return false;
			}
			if (P_0.offset < PBEmhlMheClGNYQjGAjFkKVGBcRG)
			{
				return false;
			}
		}
		else if (P_0.offset + length > PBEmhlMheClGNYQjGAjFkKVGBcRG)
		{
			return false;
		}
		if (P_0.offset + length > RiJJwonoFtegPDbhiqPwweexFSgf)
		{
			return false;
		}
		return true;
	}

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~imHGwUVrRBakgbxhQeIjPjJfybEF()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	protected unsafe virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			if (wEuKkANUgckCmAXoEgqcyAbKCWL != null)
			{
				Marshal.FreeHGlobal((IntPtr)wEuKkANUgckCmAXoEgqcyAbKCWL);
			}
			dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
		}
	}
}
