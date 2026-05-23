using System;
using System.Runtime.InteropServices;

internal class qCzEuYnmmIJIbDCvWxCniprzOhcn : IDisposable
{
	public struct pnTFfDBrShdsDDtxXTUQZLXElWliA
	{
		private byte GXwAaaKupJFPzOxGJnhupViJmdKc;

		private uint yfrJEUTOobObzoGqspTKAnRRxhM;

		private int FErLVQmrFNVcOMhqQFGtGUlIynxRA;

		private static pnTFfDBrShdsDDtxXTUQZLXElWliA ACjRpOLlSlSWHLyWeBSNkJRygqBl;

		public byte KeWevXgLyWzrLHmVWWfWpKIWEFtG => GXwAaaKupJFPzOxGJnhupViJmdKc;

		public uint uBROQkdgkibNYOPrSNFbfWnIThUL => yfrJEUTOobObzoGqspTKAnRRxhM;

		public int zMBsHCnaGYlcZqEicyDkovoiyHo => FErLVQmrFNVcOMhqQFGtGUlIynxRA;

		public static pnTFfDBrShdsDDtxXTUQZLXElWliA HXGuCgNstBwchdNqzlfFpsthjnfk => ACjRpOLlSlSWHLyWeBSNkJRygqBl;

		public pnTFfDBrShdsDDtxXTUQZLXElWliA(byte P_0, uint P_1, int P_2)
		{
			GXwAaaKupJFPzOxGJnhupViJmdKc = P_0;
			yfrJEUTOobObzoGqspTKAnRRxhM = P_1;
			FErLVQmrFNVcOMhqQFGtGUlIynxRA = P_2;
			if (FErLVQmrFNVcOMhqQFGtGUlIynxRA < 0)
			{
				FErLVQmrFNVcOMhqQFGtGUlIynxRA = 0;
			}
		}
	}

	private const byte elFhskYYiGlAqIKgveUiewkxyppeA = 254;

	private uint ESzSicSTvGmGCbxhPPGhAPQsBZBi;

	private int rVpgYNdFQUrRVTogYWjUMUPpnUSx;

	private unsafe byte* dfelAYedfjarbUOEYYWznKkgcvRg;

	private byte hqZwKSjLZHSEfZxlixuPNbcvKkAL;

	private bool XzpgWEXGPywjCFSmAZroSKSBEiYO;

	private bool DSusQbXegidRHtVhOXArFcJZJMMc;

	public int HQYfRMflTrEzGKfhEeKBkyZqNIWAA => rVpgYNdFQUrRVTogYWjUMUPpnUSx;

	public unsafe qCzEuYnmmIJIbDCvWxCniprzOhcn(int P_0)
	{
		if (P_0 <= 0)
		{
			throw new Exception("size must be > 0!");
		}
		rVpgYNdFQUrRVTogYWjUMUPpnUSx = P_0;
		ESzSicSTvGmGCbxhPPGhAPQsBZBi = 0u;
		dfelAYedfjarbUOEYYWznKkgcvRg = (byte*)(void*)Marshal.AllocHGlobal(P_0);
	}

	public unsafe bool UaKEuAINYmOQTTRuMGKPHhnapBKN(IntPtr P_0, int P_1, out pnTFfDBrShdsDDtxXTUQZLXElWliA P_2)
	{
		if (dfelAYedfjarbUOEYYWznKkgcvRg == null || P_1 <= 0)
		{
			P_2 = default(pnTFfDBrShdsDDtxXTUQZLXElWliA);
			return false;
		}
		if (P_1 > rVpgYNdFQUrRVTogYWjUMUPpnUSx)
		{
			throw new Exception("Length is larger than the buffer.");
		}
		if ((uint)((int)ESzSicSTvGmGCbxhPPGhAPQsBZBi + P_1) > rVpgYNdFQUrRVTogYWjUMUPpnUSx)
		{
			ESzSicSTvGmGCbxhPPGhAPQsBZBi = 0u;
			if (hqZwKSjLZHSEfZxlixuPNbcvKkAL == 254)
			{
				hqZwKSjLZHSEfZxlixuPNbcvKkAL = 0;
				XzpgWEXGPywjCFSmAZroSKSBEiYO = true;
			}
			else
			{
				hqZwKSjLZHSEfZxlixuPNbcvKkAL++;
			}
		}
		FanHTnvZmXVTOfDHuteqdkMyhpJj.GAVtaXBBmDYDssYPScFVumZWBcXN(dfelAYedfjarbUOEYYWznKkgcvRg + ESzSicSTvGmGCbxhPPGhAPQsBZBi, (void*)P_0, new UIntPtr((uint)P_1));
		P_2 = new pnTFfDBrShdsDDtxXTUQZLXElWliA(hqZwKSjLZHSEfZxlixuPNbcvKkAL, ESzSicSTvGmGCbxhPPGhAPQsBZBi, P_1);
		ESzSicSTvGmGCbxhPPGhAPQsBZBi += (uint)P_1;
		return true;
	}

	public int skRabXQAkOGciOumvSYDpyFpeksn(pnTFfDBrShdsDDtxXTUQZLXElWliA P_0, byte[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_1.Length < P_0.zMBsHCnaGYlcZqEicyDkovoiyHo)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!NOnKEhYcGMKavMPvjAXHWVAFuHT(ref P_0))
		{
			return -1;
		}
		Marshal.Copy(uzCBGmyEmLelseuIFLsFNOjCIxMLA(P_0), P_1, 0, P_0.zMBsHCnaGYlcZqEicyDkovoiyHo);
		return P_0.zMBsHCnaGYlcZqEicyDkovoiyHo;
	}

	public unsafe int CLqaYfXFDpVXVWyfNMarrpvrBZMGA(pnTFfDBrShdsDDtxXTUQZLXElWliA P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new Exception("Buffer pointer is invalid.");
		}
		if (P_2 <= 0)
		{
			return -1;
		}
		if (P_2 < P_0.zMBsHCnaGYlcZqEicyDkovoiyHo)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!NOnKEhYcGMKavMPvjAXHWVAFuHT(ref P_0))
		{
			return -1;
		}
		FanHTnvZmXVTOfDHuteqdkMyhpJj.GAVtaXBBmDYDssYPScFVumZWBcXN((void*)P_1, (void*)uzCBGmyEmLelseuIFLsFNOjCIxMLA(P_0), new UIntPtr((uint)P_0.zMBsHCnaGYlcZqEicyDkovoiyHo));
		return P_0.zMBsHCnaGYlcZqEicyDkovoiyHo;
	}

	public unsafe IntPtr uzCBGmyEmLelseuIFLsFNOjCIxMLA(pnTFfDBrShdsDDtxXTUQZLXElWliA P_0)
	{
		if (dfelAYedfjarbUOEYYWznKkgcvRg == null || !NOnKEhYcGMKavMPvjAXHWVAFuHT(ref P_0))
		{
			return IntPtr.Zero;
		}
		return (IntPtr)(dfelAYedfjarbUOEYYWznKkgcvRg + P_0.uBROQkdgkibNYOPrSNFbfWnIThUL);
	}

	public unsafe bool tyKXPeLcgUvTczKHYefpfHUEIlYl(pnTFfDBrShdsDDtxXTUQZLXElWliA P_0, out IntPtr P_1)
	{
		if (dfelAYedfjarbUOEYYWznKkgcvRg == null || !NOnKEhYcGMKavMPvjAXHWVAFuHT(ref P_0))
		{
			P_1 = IntPtr.Zero;
			return false;
		}
		P_1 = (IntPtr)(dfelAYedfjarbUOEYYWznKkgcvRg + P_0.uBROQkdgkibNYOPrSNFbfWnIThUL);
		return true;
	}

	private bool NOnKEhYcGMKavMPvjAXHWVAFuHT(ref pnTFfDBrShdsDDtxXTUQZLXElWliA P_0)
	{
		int num = P_0.zMBsHCnaGYlcZqEicyDkovoiyHo;
		if (num <= 0)
		{
			return false;
		}
		uint num2 = P_0.KeWevXgLyWzrLHmVWWfWpKIWEFtG;
		if (num2 > 254)
		{
			return false;
		}
		if (num2 != hqZwKSjLZHSEfZxlixuPNbcvKkAL)
		{
			if (!XzpgWEXGPywjCFSmAZroSKSBEiYO)
			{
				if (num2 + 1 != hqZwKSjLZHSEfZxlixuPNbcvKkAL)
				{
					return false;
				}
			}
			else if (num2 > hqZwKSjLZHSEfZxlixuPNbcvKkAL)
			{
				if (hqZwKSjLZHSEfZxlixuPNbcvKkAL != 0 || num2 != 254)
				{
					return false;
				}
			}
			else if (num2 + 1 != hqZwKSjLZHSEfZxlixuPNbcvKkAL)
			{
				return false;
			}
			if (P_0.uBROQkdgkibNYOPrSNFbfWnIThUL < ESzSicSTvGmGCbxhPPGhAPQsBZBi)
			{
				return false;
			}
		}
		else if (P_0.uBROQkdgkibNYOPrSNFbfWnIThUL + num > ESzSicSTvGmGCbxhPPGhAPQsBZBi)
		{
			return false;
		}
		if (P_0.uBROQkdgkibNYOPrSNFbfWnIThUL + num > rVpgYNdFQUrRVTogYWjUMUPpnUSx)
		{
			return false;
		}
		return true;
	}

	public void Dispose()
	{
		MbhESsVqQaCNAfAUbrqsyATDankAA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void evSgxxsNYgRGmEqRThwEfjXeBTxE()
	{
		try
		{
			MbhESsVqQaCNAfAUbrqsyATDankAA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected unsafe virtual void MbhESsVqQaCNAfAUbrqsyATDankAA(bool P_0)
	{
		if (!DSusQbXegidRHtVhOXArFcJZJMMc)
		{
			if (dfelAYedfjarbUOEYYWznKkgcvRg != null)
			{
				Marshal.FreeHGlobal((IntPtr)dfelAYedfjarbUOEYYWznKkgcvRg);
			}
			DSusQbXegidRHtVhOXArFcJZJMMc = true;
		}
	}
}
