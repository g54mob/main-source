using System;
using System.Runtime.InteropServices;

internal class mwJeBmPUThOYNffxcFyXBDnRHad : IDisposable
{
	public struct EtabdtgPNpThcoNZdEAuUPjmybUC
	{
		private byte tucVmdxslVyOExXCAukmFvwJbEi;

		private uint pvfCYcRkucoSBGCEbeLTBRTcSHD;

		private int othlrJwXEOggtDFssdiPbwxSvUx;

		private static EtabdtgPNpThcoNZdEAuUPjmybUC jauoSBxfdyGhgbzxqqomCgPStXy;

		public byte pass
		{
			get
			{
				return tucVmdxslVyOExXCAukmFvwJbEi;
			}
		}

		public uint offset
		{
			get
			{
				return pvfCYcRkucoSBGCEbeLTBRTcSHD;
			}
		}

		public int length
		{
			get
			{
				return othlrJwXEOggtDFssdiPbwxSvUx;
			}
		}

		public static EtabdtgPNpThcoNZdEAuUPjmybUC Invalid
		{
			get
			{
				return jauoSBxfdyGhgbzxqqomCgPStXy;
			}
		}

		public EtabdtgPNpThcoNZdEAuUPjmybUC(byte pass, uint offset, int length)
		{
			tucVmdxslVyOExXCAukmFvwJbEi = pass;
			pvfCYcRkucoSBGCEbeLTBRTcSHD = offset;
			othlrJwXEOggtDFssdiPbwxSvUx = length;
			if (othlrJwXEOggtDFssdiPbwxSvUx < 0)
			{
				othlrJwXEOggtDFssdiPbwxSvUx = 0;
			}
		}
	}

	private const byte bXqfbOnPwRIifFizFJMbnMdsXTJ = 254;

	private uint RqUeWFiYuiTaynMxwWJvgSjkhhuS;

	private int HXZBBGGxVZMEqLJvYexIQUAFWLRR;

	private unsafe byte* avwBdYLqKIiSROITmGIKcEeiOZes;

	private byte tucVmdxslVyOExXCAukmFvwJbEi;

	private bool nCQrVMmKhjGcaItoMprCIWMUmdmG;

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	public int size
	{
		get
		{
			return HXZBBGGxVZMEqLJvYexIQUAFWLRR;
		}
	}

	public unsafe mwJeBmPUThOYNffxcFyXBDnRHad(int size)
	{
		if (size <= 0)
		{
			throw new Exception("size must be > 0!");
		}
		HXZBBGGxVZMEqLJvYexIQUAFWLRR = size;
		RqUeWFiYuiTaynMxwWJvgSjkhhuS = 0u;
		avwBdYLqKIiSROITmGIKcEeiOZes = (byte*)(void*)Marshal.AllocHGlobal(size);
	}

	public unsafe bool uwRrXbrytlKXYWIOmlUkwmZqEzx(IntPtr P_0, int P_1, out EtabdtgPNpThcoNZdEAuUPjmybUC P_2)
	{
		int num;
		if (avwBdYLqKIiSROITmGIKcEeiOZes != null)
		{
			if (P_1 <= 0)
			{
				goto IL_000e;
			}
			int num2;
			if (P_1 <= HXZBBGGxVZMEqLJvYexIQUAFWLRR)
			{
				num = 1728812016;
				num2 = num;
			}
			else
			{
				num = 1728812017;
				num2 = num;
			}
			goto IL_0013;
		}
		goto IL_004b;
		IL_0013:
		uint num3 = default(uint);
		while (true)
		{
			switch (num ^ 0x670B93F3)
			{
			case 8:
				break;
			case 9:
				goto IL_004b;
			case 4:
				if (num3 >= HXZBBGGxVZMEqLJvYexIQUAFWLRR)
				{
					RqUeWFiYuiTaynMxwWJvgSjkhhuS = 0u;
					num = 1728812020;
					continue;
				}
				goto case 0;
			case 6:
				tucVmdxslVyOExXCAukmFvwJbEi++;
				num = 1728812019;
				continue;
			case 7:
				if (tucVmdxslVyOExXCAukmFvwJbEi == 254)
				{
					tucVmdxslVyOExXCAukmFvwJbEi = 0;
					num = 1728812022;
					continue;
				}
				goto case 6;
			case 5:
				nCQrVMmKhjGcaItoMprCIWMUmdmG = true;
				num = 1728812019;
				continue;
			case 3:
				num3 = RqUeWFiYuiTaynMxwWJvgSjkhhuS + (uint)P_1;
				num = 1728812023;
				continue;
			case 2:
				throw new Exception("Length is larger than the buffer.");
			case 0:
				JBXHRSYUePslTBUiRmNOkdLSed.nWkFphaDHQGcvihSpxZHGwhfGBn(avwBdYLqKIiSROITmGIKcEeiOZes + (int)RqUeWFiYuiTaynMxwWJvgSjkhhuS, (void*)P_0, new UIntPtr((uint)P_1));
				P_2 = new EtabdtgPNpThcoNZdEAuUPjmybUC(tucVmdxslVyOExXCAukmFvwJbEi, RqUeWFiYuiTaynMxwWJvgSjkhhuS, P_1);
				num = 1728812018;
				continue;
			default:
				RqUeWFiYuiTaynMxwWJvgSjkhhuS += (uint)P_1;
				return true;
			}
			break;
		}
		goto IL_000e;
		IL_000e:
		num = 1728812026;
		goto IL_0013;
		IL_004b:
		P_2 = default(EtabdtgPNpThcoNZdEAuUPjmybUC);
		return false;
	}

	public int BzRDvjvAQHKNUfdBiARKBsCcKkSL(EtabdtgPNpThcoNZdEAuUPjmybUC P_0, byte[] P_1)
	{
		if (P_1 == null)
		{
			while (true)
			{
				switch (-2368214 ^ -2368215)
				{
				case 0:
					break;
				case 3:
					throw new ArgumentNullException("buffer");
				case 2:
					goto end_IL_0003;
				default:
					goto IL_0055;
				}
				continue;
				end_IL_0003:
				break;
			}
		}
		if (P_1.Length < P_0.length)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		goto IL_0055;
		IL_0055:
		if (!WTCGQQhjEiTpQITPKoUpEgnKEzgT(ref P_0))
		{
			return -1;
		}
		Marshal.Copy(phwoPMfJjZHvTmWUsajASuNTIsc(P_0), P_1, 0, P_0.length);
		return P_0.length;
	}

	public unsafe int BzRDvjvAQHKNUfdBiARKBsCcKkSL(EtabdtgPNpThcoNZdEAuUPjmybUC P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			goto IL_000d;
		}
		goto IL_0086;
		IL_000d:
		int num = 725931345;
		goto IL_0012;
		IL_0012:
		switch (num ^ 0x2B44D553)
		{
		case 4:
			break;
		case 0:
			goto IL_0037;
		case 1:
			return -1;
		case 5:
			goto IL_0086;
		case 2:
			throw new Exception("Buffer pointer is invalid.");
		default:
			return P_0.length;
		}
		goto IL_000d;
		IL_0037:
		if (!WTCGQQhjEiTpQITPKoUpEgnKEzgT(ref P_0))
		{
			return -1;
		}
		JBXHRSYUePslTBUiRmNOkdLSed.nWkFphaDHQGcvihSpxZHGwhfGBn((void*)P_1, avwBdYLqKIiSROITmGIKcEeiOZes, new UIntPtr((uint)P_0.length));
		num = 725931344;
		goto IL_0012;
		IL_0086:
		if (P_2 > 0)
		{
			if (P_2 < P_0.length)
			{
				throw new Exception("Buffer is not large enough to hold the data.");
			}
			goto IL_0037;
		}
		num = 725931346;
		goto IL_0012;
	}

	public unsafe IntPtr phwoPMfJjZHvTmWUsajASuNTIsc(EtabdtgPNpThcoNZdEAuUPjmybUC P_0)
	{
		if (avwBdYLqKIiSROITmGIKcEeiOZes != null)
		{
			while (true)
			{
				int num = -1480494269;
				while (true)
				{
					switch (num ^ -1480494270)
					{
					case 0:
						break;
					case 1:
						goto IL_0028;
					default:
						goto end_IL_000a;
					}
					break;
					IL_0028:
					if (!WTCGQQhjEiTpQITPKoUpEgnKEzgT(ref P_0))
					{
						num = -1480494272;
						continue;
					}
					return (IntPtr)(avwBdYLqKIiSROITmGIKcEeiOZes + (int)P_0.offset);
				}
				continue;
				end_IL_000a:
				break;
			}
		}
		return IntPtr.Zero;
	}

	public unsafe bool nYfsckqFnSovXyXkjwVwECvLXf(EtabdtgPNpThcoNZdEAuUPjmybUC P_0, out IntPtr P_1)
	{
		if (avwBdYLqKIiSROITmGIKcEeiOZes == null || !WTCGQQhjEiTpQITPKoUpEgnKEzgT(ref P_0))
		{
			P_1 = IntPtr.Zero;
			return false;
		}
		P_1 = (IntPtr)(avwBdYLqKIiSROITmGIKcEeiOZes + (int)P_0.offset);
		return true;
	}

	private bool WTCGQQhjEiTpQITPKoUpEgnKEzgT(ref EtabdtgPNpThcoNZdEAuUPjmybUC P_0)
	{
		int length = P_0.length;
		uint pass = default(uint);
		while (true)
		{
			int num = -1627708637;
			while (true)
			{
				switch (num ^ -1627708634)
				{
				case 4:
					break;
				case 7:
					if (pass != 254)
					{
						num = -1627708633;
						continue;
					}
					goto IL_00d9;
				case 1:
					return false;
				case 0:
				{
					int num2;
					if (tucVmdxslVyOExXCAukmFvwJbEi != 0)
					{
						num = -1627708633;
						num2 = num;
					}
					else
					{
						num = -1627708639;
						num2 = num;
					}
					continue;
				}
				case 6:
					if (nCQrVMmKhjGcaItoMprCIWMUmdmG)
					{
						if (pass > tucVmdxslVyOExXCAukmFvwJbEi)
						{
							num = -1627708634;
							continue;
						}
						if (pass + 1 != tucVmdxslVyOExXCAukmFvwJbEi)
						{
							num = -1627708635;
							continue;
						}
					}
					else if (pass + 1 != tucVmdxslVyOExXCAukmFvwJbEi)
					{
						return false;
					}
					goto IL_00d9;
				case 5:
					if (length <= 0)
					{
						num = -1627708636;
						continue;
					}
					pass = P_0.pass;
					if (pass > 254)
					{
						return false;
					}
					if (pass != tucVmdxslVyOExXCAukmFvwJbEi)
					{
						num = -1627708640;
						continue;
					}
					if (P_0.offset + length > RqUeWFiYuiTaynMxwWJvgSjkhhuS)
					{
						return false;
					}
					goto IL_00fe;
				case 2:
					return false;
				default:
					{
						return false;
					}
					IL_00fe:
					if (P_0.offset + length > HXZBBGGxVZMEqLJvYexIQUAFWLRR)
					{
						return false;
					}
					return true;
					IL_00d9:
					if (P_0.offset < RqUeWFiYuiTaynMxwWJvgSjkhhuS)
					{
						return false;
					}
					goto IL_00fe;
				}
				break;
			}
		}
	}

	public void Dispose()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~mwJeBmPUThOYNffxcFyXBDnRHad()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	protected unsafe virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		if (nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			return;
		}
		while (avwBdYLqKIiSROITmGIKcEeiOZes != null)
		{
			Marshal.FreeHGlobal((IntPtr)avwBdYLqKIiSROITmGIKcEeiOZes);
			int num = 2087532578;
			while (true)
			{
				switch (num ^ 0x7C6D3823)
				{
				case 0:
					num = 2087532577;
					continue;
				case 2:
					break;
				default:
					goto end_IL_0027;
				}
				break;
			}
			continue;
			end_IL_0027:
			break;
		}
		nNxUslIcGUpqKgpPZYhuimcvWyC = true;
	}
}
