using System;
using System.Runtime.InteropServices;

internal class gsLthQSgwHRfpvSxfHlrVHBWaMbF : IDisposable
{
	public struct xgbseFAPAuqrVBpnyaLQGajhKPuJA
	{
		private byte QoMLtaxLgGOgJiMzcmwhMAzmzIoJ;

		private uint iJVUPIznWrDBpPjMFgkHtkHcvien;

		private int ToNCAYGRRKMfSSgiteTvnbPffyoDb;

		private static xgbseFAPAuqrVBpnyaLQGajhKPuJA ITNGeYwWGeGFXjhSNlAJfZhVnhSUA;

		public byte QHslRWZmbTsBXdgwxNhQIyZbNsUc => QoMLtaxLgGOgJiMzcmwhMAzmzIoJ;

		public uint ctbDRmCSerlgSmUlfDYzYyLdsKVN => iJVUPIznWrDBpPjMFgkHtkHcvien;

		public int pfefkNhMmJmjotwKXzaFRnFPhUSj => ToNCAYGRRKMfSSgiteTvnbPffyoDb;

		public static xgbseFAPAuqrVBpnyaLQGajhKPuJA BcdjsvshWcnhfVsBMuJEAFIGuCyd => ITNGeYwWGeGFXjhSNlAJfZhVnhSUA;

		public xgbseFAPAuqrVBpnyaLQGajhKPuJA(byte P_0, uint P_1, int P_2)
		{
			QoMLtaxLgGOgJiMzcmwhMAzmzIoJ = P_0;
			iJVUPIznWrDBpPjMFgkHtkHcvien = P_1;
			ToNCAYGRRKMfSSgiteTvnbPffyoDb = P_2;
			if (ToNCAYGRRKMfSSgiteTvnbPffyoDb < 0)
			{
				ToNCAYGRRKMfSSgiteTvnbPffyoDb = 0;
			}
		}
	}

	private const byte gNzsrkvqiPDNaggaSNFwZHOQHauSA = 254;

	private uint SyTZoQtbEHhbWNjoaAMjjaSHWDWC;

	private int twXyRTOaUNIILzqatjuMbzfCaBFIA;

	private unsafe byte* nHEgHSVGfeJplajUbDXpGOSDJjQeb;

	private byte vVfhIQQPlAJovrzyTmkZyEWMVZXb;

	private bool HaVANQBoNdxmErnajWkoVvcmTxToA;

	private bool FzEzrtafmdGcJRkNjXQbyoUgdMZT;

	public int FiuwIKYPXkcIGcCpvfBJFgjZLDBq => twXyRTOaUNIILzqatjuMbzfCaBFIA;

	public unsafe gsLthQSgwHRfpvSxfHlrVHBWaMbF(int P_0)
	{
		if (P_0 <= 0)
		{
			throw new Exception("size must be > 0!");
		}
		twXyRTOaUNIILzqatjuMbzfCaBFIA = P_0;
		SyTZoQtbEHhbWNjoaAMjjaSHWDWC = 0u;
		nHEgHSVGfeJplajUbDXpGOSDJjQeb = (byte*)(void*)Marshal.AllocHGlobal(P_0);
	}

	public unsafe bool CPerYApEVvTNUdgzhFLzmHeHCRkB(IntPtr P_0, int P_1, out xgbseFAPAuqrVBpnyaLQGajhKPuJA P_2)
	{
		if (nHEgHSVGfeJplajUbDXpGOSDJjQeb == null || P_1 <= 0)
		{
			P_2 = default(xgbseFAPAuqrVBpnyaLQGajhKPuJA);
			return false;
		}
		if (P_1 > twXyRTOaUNIILzqatjuMbzfCaBFIA)
		{
			throw new Exception("Length is larger than the buffer.");
		}
		if ((uint)((int)SyTZoQtbEHhbWNjoaAMjjaSHWDWC + P_1) > twXyRTOaUNIILzqatjuMbzfCaBFIA)
		{
			SyTZoQtbEHhbWNjoaAMjjaSHWDWC = 0u;
			if (vVfhIQQPlAJovrzyTmkZyEWMVZXb == 254)
			{
				vVfhIQQPlAJovrzyTmkZyEWMVZXb = 0;
				HaVANQBoNdxmErnajWkoVvcmTxToA = true;
			}
			else
			{
				vVfhIQQPlAJovrzyTmkZyEWMVZXb++;
			}
		}
		NtPSOxELPOOaKLQRVmbwGRgHcLOL.AtrcrHDgyKmIoZKDjZATIZvvitKAA(nHEgHSVGfeJplajUbDXpGOSDJjQeb + SyTZoQtbEHhbWNjoaAMjjaSHWDWC, (void*)P_0, new UIntPtr((uint)P_1));
		P_2 = new xgbseFAPAuqrVBpnyaLQGajhKPuJA(vVfhIQQPlAJovrzyTmkZyEWMVZXb, SyTZoQtbEHhbWNjoaAMjjaSHWDWC, P_1);
		SyTZoQtbEHhbWNjoaAMjjaSHWDWC += (uint)P_1;
		return true;
	}

	public int getzhXvuUJbvmkapUNMHWbDUxqnC(xgbseFAPAuqrVBpnyaLQGajhKPuJA P_0, byte[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_1.Length < P_0.pfefkNhMmJmjotwKXzaFRnFPhUSj)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!XiiToCGwmTPGsRlVIBLHyXvxbgIl(ref P_0))
		{
			return -1;
		}
		Marshal.Copy(cQgLBiJhaQoosOAYqbaHrOJjyFNH(P_0), P_1, 0, P_0.pfefkNhMmJmjotwKXzaFRnFPhUSj);
		return P_0.pfefkNhMmJmjotwKXzaFRnFPhUSj;
	}

	public unsafe int IbUJtlgZWyEHBcjTibgnIBxAMnDd(xgbseFAPAuqrVBpnyaLQGajhKPuJA P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new Exception("Buffer pointer is invalid.");
		}
		if (P_2 <= 0)
		{
			return -1;
		}
		if (P_2 < P_0.pfefkNhMmJmjotwKXzaFRnFPhUSj)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!XiiToCGwmTPGsRlVIBLHyXvxbgIl(ref P_0))
		{
			return -1;
		}
		NtPSOxELPOOaKLQRVmbwGRgHcLOL.AtrcrHDgyKmIoZKDjZATIZvvitKAA((void*)P_1, (void*)cQgLBiJhaQoosOAYqbaHrOJjyFNH(P_0), new UIntPtr((uint)P_0.pfefkNhMmJmjotwKXzaFRnFPhUSj));
		return P_0.pfefkNhMmJmjotwKXzaFRnFPhUSj;
	}

	public unsafe IntPtr cQgLBiJhaQoosOAYqbaHrOJjyFNH(xgbseFAPAuqrVBpnyaLQGajhKPuJA P_0)
	{
		if (nHEgHSVGfeJplajUbDXpGOSDJjQeb == null || !XiiToCGwmTPGsRlVIBLHyXvxbgIl(ref P_0))
		{
			return IntPtr.Zero;
		}
		return (IntPtr)(nHEgHSVGfeJplajUbDXpGOSDJjQeb + P_0.ctbDRmCSerlgSmUlfDYzYyLdsKVN);
	}

	public unsafe bool rVuKOowIgDhwmLZUxpjhYnqtDLDKA(xgbseFAPAuqrVBpnyaLQGajhKPuJA P_0, out IntPtr P_1)
	{
		if (nHEgHSVGfeJplajUbDXpGOSDJjQeb == null || !XiiToCGwmTPGsRlVIBLHyXvxbgIl(ref P_0))
		{
			P_1 = IntPtr.Zero;
			return false;
		}
		P_1 = (IntPtr)(nHEgHSVGfeJplajUbDXpGOSDJjQeb + P_0.ctbDRmCSerlgSmUlfDYzYyLdsKVN);
		return true;
	}

	private bool XiiToCGwmTPGsRlVIBLHyXvxbgIl(ref xgbseFAPAuqrVBpnyaLQGajhKPuJA P_0)
	{
		int num = P_0.pfefkNhMmJmjotwKXzaFRnFPhUSj;
		if (num <= 0)
		{
			return false;
		}
		uint num2 = P_0.QHslRWZmbTsBXdgwxNhQIyZbNsUc;
		if (num2 > 254)
		{
			return false;
		}
		if (num2 != vVfhIQQPlAJovrzyTmkZyEWMVZXb)
		{
			if (!HaVANQBoNdxmErnajWkoVvcmTxToA)
			{
				if (num2 + 1 != vVfhIQQPlAJovrzyTmkZyEWMVZXb)
				{
					return false;
				}
			}
			else if (num2 > vVfhIQQPlAJovrzyTmkZyEWMVZXb)
			{
				if (vVfhIQQPlAJovrzyTmkZyEWMVZXb != 0 || num2 != 254)
				{
					return false;
				}
			}
			else if (num2 + 1 != vVfhIQQPlAJovrzyTmkZyEWMVZXb)
			{
				return false;
			}
			if (P_0.ctbDRmCSerlgSmUlfDYzYyLdsKVN < SyTZoQtbEHhbWNjoaAMjjaSHWDWC)
			{
				return false;
			}
		}
		else if (P_0.ctbDRmCSerlgSmUlfDYzYyLdsKVN + num > SyTZoQtbEHhbWNjoaAMjjaSHWDWC)
		{
			return false;
		}
		if (P_0.ctbDRmCSerlgSmUlfDYzYyLdsKVN + num > twXyRTOaUNIILzqatjuMbzfCaBFIA)
		{
			return false;
		}
		return true;
	}

	public void Dispose()
	{
		IrBZxmiQvrIETREDAnDqXrLkghdG(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void oVkjdLDCbjCkyyTBymKSQvBDIwWb()
	{
		try
		{
			IrBZxmiQvrIETREDAnDqXrLkghdG(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected unsafe virtual void IrBZxmiQvrIETREDAnDqXrLkghdG(bool P_0)
	{
		if (!FzEzrtafmdGcJRkNjXQbyoUgdMZT)
		{
			if (nHEgHSVGfeJplajUbDXpGOSDJjQeb != null)
			{
				Marshal.FreeHGlobal((IntPtr)nHEgHSVGfeJplajUbDXpGOSDJjQeb);
			}
			FzEzrtafmdGcJRkNjXQbyoUgdMZT = true;
		}
	}
}
