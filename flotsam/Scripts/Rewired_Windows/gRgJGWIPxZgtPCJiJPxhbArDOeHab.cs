using System;
using System.Runtime.InteropServices;

internal class gRgJGWIPxZgtPCJiJPxhbArDOeHab : IDisposable
{
	public struct lSYVcDSVwwJLzroMSdmUxDHqPmMD
	{
		private byte IUzdiuDzfIGgjdWeFIWfRTZtzlEyb;

		private uint qxmAbGJjPdYnLOxLbtGHPqpxEuQab;

		private int XMyhBGVNWOXBeMAfNDfdmDfkhwOHA;

		private static lSYVcDSVwwJLzroMSdmUxDHqPmMD EqaVMYmqBopRfJTutwgXWcFWbmgH;

		public byte MyXOQVDpjTLKrREvTDjCCLYiWZMaA => IUzdiuDzfIGgjdWeFIWfRTZtzlEyb;

		public uint gVSVckExdvgUsQKuLymzNlzsCUbQ => qxmAbGJjPdYnLOxLbtGHPqpxEuQab;

		public int vvRbWNlQvJXUCNAJrhTJAKvKHtqBb => XMyhBGVNWOXBeMAfNDfdmDfkhwOHA;

		public static lSYVcDSVwwJLzroMSdmUxDHqPmMD FHRoGamKcGeJTvIjgwATZqbTcqIhA => EqaVMYmqBopRfJTutwgXWcFWbmgH;

		public lSYVcDSVwwJLzroMSdmUxDHqPmMD(byte P_0, uint P_1, int P_2)
		{
			IUzdiuDzfIGgjdWeFIWfRTZtzlEyb = P_0;
			qxmAbGJjPdYnLOxLbtGHPqpxEuQab = P_1;
			XMyhBGVNWOXBeMAfNDfdmDfkhwOHA = P_2;
			if (XMyhBGVNWOXBeMAfNDfdmDfkhwOHA < 0)
			{
				XMyhBGVNWOXBeMAfNDfdmDfkhwOHA = 0;
			}
		}
	}

	private const byte czIOLotHxNabWWNvspWwGFeLJyGu = 254;

	private uint WEurckhhcVaNoiliUCsnBwGGOEqmb;

	private int rgudcDCyLFSsrTCpNOEKacZRdZrDA;

	private unsafe byte* tZtTDEHfmqAHRBQZPujrmHgUMjujb;

	private byte zcUQMMGNMKHjJIHwpcALRniHmZfAA;

	private bool HHudeIyWUxsYiPUxRECuccEjnjxn;

	private bool DovtCfkFtrvUdlWSPekztLezdOhgA;

	public int RFBbjGYEMcGYiEhuJarLQhNCHFzcA => rgudcDCyLFSsrTCpNOEKacZRdZrDA;

	public unsafe gRgJGWIPxZgtPCJiJPxhbArDOeHab(int P_0)
	{
		if (P_0 <= 0)
		{
			throw new Exception("size must be > 0!");
		}
		rgudcDCyLFSsrTCpNOEKacZRdZrDA = P_0;
		WEurckhhcVaNoiliUCsnBwGGOEqmb = 0u;
		tZtTDEHfmqAHRBQZPujrmHgUMjujb = (byte*)(void*)Marshal.AllocHGlobal(P_0);
	}

	public unsafe bool GpVJQWjvPdBrnNObBCvDfxrUPMlPA(IntPtr P_0, int P_1, out lSYVcDSVwwJLzroMSdmUxDHqPmMD P_2)
	{
		if (tZtTDEHfmqAHRBQZPujrmHgUMjujb == null || P_1 <= 0)
		{
			P_2 = default(lSYVcDSVwwJLzroMSdmUxDHqPmMD);
			return false;
		}
		if (P_1 > rgudcDCyLFSsrTCpNOEKacZRdZrDA)
		{
			throw new Exception("Length is larger than the buffer.");
		}
		if ((uint)((int)WEurckhhcVaNoiliUCsnBwGGOEqmb + P_1) > rgudcDCyLFSsrTCpNOEKacZRdZrDA)
		{
			WEurckhhcVaNoiliUCsnBwGGOEqmb = 0u;
			if (zcUQMMGNMKHjJIHwpcALRniHmZfAA == 254)
			{
				zcUQMMGNMKHjJIHwpcALRniHmZfAA = 0;
				HHudeIyWUxsYiPUxRECuccEjnjxn = true;
			}
			else
			{
				zcUQMMGNMKHjJIHwpcALRniHmZfAA++;
			}
		}
		JUcffnbUUIpygcbMFvGmfZKcYwgXc.UOKWaJeyzSaZIkUMJyULADjuxfsG(tZtTDEHfmqAHRBQZPujrmHgUMjujb + WEurckhhcVaNoiliUCsnBwGGOEqmb, (void*)P_0, new UIntPtr((uint)P_1));
		P_2 = new lSYVcDSVwwJLzroMSdmUxDHqPmMD(zcUQMMGNMKHjJIHwpcALRniHmZfAA, WEurckhhcVaNoiliUCsnBwGGOEqmb, P_1);
		WEurckhhcVaNoiliUCsnBwGGOEqmb += (uint)P_1;
		return true;
	}

	public int gVAQWZdFpHsBAAgzaAbREPDZsbRZA(lSYVcDSVwwJLzroMSdmUxDHqPmMD P_0, byte[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_1.Length < P_0.vvRbWNlQvJXUCNAJrhTJAKvKHtqBb)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!DYXZgICqxDlvSzuAynpXrRJmbvql(ref P_0))
		{
			return -1;
		}
		Marshal.Copy(gqFKuqRqlAhOGmaXWsJFsoduTwpp(P_0), P_1, 0, P_0.vvRbWNlQvJXUCNAJrhTJAKvKHtqBb);
		return P_0.vvRbWNlQvJXUCNAJrhTJAKvKHtqBb;
	}

	public unsafe int ADvGcjwyQsumvSNyEFXtDyjDVOjR(lSYVcDSVwwJLzroMSdmUxDHqPmMD P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new Exception("Buffer pointer is invalid.");
		}
		if (P_2 <= 0)
		{
			return -1;
		}
		if (P_2 < P_0.vvRbWNlQvJXUCNAJrhTJAKvKHtqBb)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!DYXZgICqxDlvSzuAynpXrRJmbvql(ref P_0))
		{
			return -1;
		}
		JUcffnbUUIpygcbMFvGmfZKcYwgXc.UOKWaJeyzSaZIkUMJyULADjuxfsG((void*)P_1, (void*)gqFKuqRqlAhOGmaXWsJFsoduTwpp(P_0), new UIntPtr((uint)P_0.vvRbWNlQvJXUCNAJrhTJAKvKHtqBb));
		return P_0.vvRbWNlQvJXUCNAJrhTJAKvKHtqBb;
	}

	public unsafe IntPtr gqFKuqRqlAhOGmaXWsJFsoduTwpp(lSYVcDSVwwJLzroMSdmUxDHqPmMD P_0)
	{
		if (tZtTDEHfmqAHRBQZPujrmHgUMjujb == null || !DYXZgICqxDlvSzuAynpXrRJmbvql(ref P_0))
		{
			return IntPtr.Zero;
		}
		return (IntPtr)(tZtTDEHfmqAHRBQZPujrmHgUMjujb + P_0.gVSVckExdvgUsQKuLymzNlzsCUbQ);
	}

	public unsafe bool pLNVtmadzRVEOhPXDuTjHNGqFVjt(lSYVcDSVwwJLzroMSdmUxDHqPmMD P_0, out IntPtr P_1)
	{
		if (tZtTDEHfmqAHRBQZPujrmHgUMjujb == null || !DYXZgICqxDlvSzuAynpXrRJmbvql(ref P_0))
		{
			P_1 = IntPtr.Zero;
			return false;
		}
		P_1 = (IntPtr)(tZtTDEHfmqAHRBQZPujrmHgUMjujb + P_0.gVSVckExdvgUsQKuLymzNlzsCUbQ);
		return true;
	}

	private bool DYXZgICqxDlvSzuAynpXrRJmbvql(ref lSYVcDSVwwJLzroMSdmUxDHqPmMD P_0)
	{
		int num = P_0.vvRbWNlQvJXUCNAJrhTJAKvKHtqBb;
		if (num <= 0)
		{
			return false;
		}
		uint num2 = P_0.MyXOQVDpjTLKrREvTDjCCLYiWZMaA;
		if (num2 > 254)
		{
			return false;
		}
		if (num2 != zcUQMMGNMKHjJIHwpcALRniHmZfAA)
		{
			if (!HHudeIyWUxsYiPUxRECuccEjnjxn)
			{
				if (num2 + 1 != zcUQMMGNMKHjJIHwpcALRniHmZfAA)
				{
					return false;
				}
			}
			else if (num2 > zcUQMMGNMKHjJIHwpcALRniHmZfAA)
			{
				if (zcUQMMGNMKHjJIHwpcALRniHmZfAA != 0 || num2 != 254)
				{
					return false;
				}
			}
			else if (num2 + 1 != zcUQMMGNMKHjJIHwpcALRniHmZfAA)
			{
				return false;
			}
			if (P_0.gVSVckExdvgUsQKuLymzNlzsCUbQ < WEurckhhcVaNoiliUCsnBwGGOEqmb)
			{
				return false;
			}
		}
		else if (P_0.gVSVckExdvgUsQKuLymzNlzsCUbQ + num > WEurckhhcVaNoiliUCsnBwGGOEqmb)
		{
			return false;
		}
		if (P_0.gVSVckExdvgUsQKuLymzNlzsCUbQ + num > rgudcDCyLFSsrTCpNOEKacZRdZrDA)
		{
			return false;
		}
		return true;
	}

	public void Dispose()
	{
		KtyJiiaHZfaiiejFgUZqSEXzdcXDb(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void qPPrCdTsZxXcWEXIEVAYNMHWGMKP()
	{
		try
		{
			KtyJiiaHZfaiiejFgUZqSEXzdcXDb(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected unsafe virtual void KtyJiiaHZfaiiejFgUZqSEXzdcXDb(bool P_0)
	{
		if (!DovtCfkFtrvUdlWSPekztLezdOhgA)
		{
			if (tZtTDEHfmqAHRBQZPujrmHgUMjujb != null)
			{
				Marshal.FreeHGlobal((IntPtr)tZtTDEHfmqAHRBQZPujrmHgUMjujb);
			}
			DovtCfkFtrvUdlWSPekztLezdOhgA = true;
		}
	}
}
