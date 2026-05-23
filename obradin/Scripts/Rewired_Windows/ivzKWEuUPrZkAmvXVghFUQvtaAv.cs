using System;
using System.Runtime.InteropServices;

internal class ivzKWEuUPrZkAmvXVghFUQvtaAv : IDisposable
{
	public struct jBGQbJrWlivxkPopxkktnSOxGWu
	{
		private byte zYKeONCJvFVdLkSazRiiAkczMzm;

		private uint xxJGNOiVoegxIFlaWEoPAHLKCWDd;

		private int iUHbgjNVCGChwQiUTfqPepfoqGj;

		private static jBGQbJrWlivxkPopxkktnSOxGWu dZANfpEydypsxuaZJsmuRSHkhBi;

		public byte pass
		{
			get
			{
				return zYKeONCJvFVdLkSazRiiAkczMzm;
			}
		}

		public uint offset
		{
			get
			{
				return xxJGNOiVoegxIFlaWEoPAHLKCWDd;
			}
		}

		public int length
		{
			get
			{
				return iUHbgjNVCGChwQiUTfqPepfoqGj;
			}
		}

		public static jBGQbJrWlivxkPopxkktnSOxGWu Invalid
		{
			get
			{
				return dZANfpEydypsxuaZJsmuRSHkhBi;
			}
		}

		public jBGQbJrWlivxkPopxkktnSOxGWu(byte pass, uint offset, int length)
		{
			zYKeONCJvFVdLkSazRiiAkczMzm = pass;
			xxJGNOiVoegxIFlaWEoPAHLKCWDd = offset;
			iUHbgjNVCGChwQiUTfqPepfoqGj = length;
			if (iUHbgjNVCGChwQiUTfqPepfoqGj < 0)
			{
				iUHbgjNVCGChwQiUTfqPepfoqGj = 0;
			}
		}
	}

	private const byte zVKHyaSCaFWLyIpTqrFrgefGNPN = 254;

	private uint ZckTUzfataxYhFHMHRgpZdnKrDk;

	private int XVnIVwOfVXTkdEoDpphKDCMddTX;

	private unsafe byte* gTGLesoZMYBDKBozPgCQHnmQINch;

	private byte zYKeONCJvFVdLkSazRiiAkczMzm;

	private bool zLwOxaRgnfcvfwJWxEbMDREyljg;

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	public int size
	{
		get
		{
			return XVnIVwOfVXTkdEoDpphKDCMddTX;
		}
	}

	public unsafe ivzKWEuUPrZkAmvXVghFUQvtaAv(int size)
	{
		while (true)
		{
			switch (-2115729996 ^ -2115729995)
			{
			case 2:
				continue;
			case 1:
				if (size <= 0)
				{
					throw new Exception("size must be > 0!");
				}
				break;
			}
			break;
		}
		XVnIVwOfVXTkdEoDpphKDCMddTX = size;
		ZckTUzfataxYhFHMHRgpZdnKrDk = 0u;
		gTGLesoZMYBDKBozPgCQHnmQINch = (byte*)(void*)Marshal.AllocHGlobal(size);
	}

	public unsafe bool mszIJNECfxEuJZasPAYwzZDCgpx(IntPtr P_0, int P_1, out jBGQbJrWlivxkPopxkktnSOxGWu P_2)
	{
		if (gTGLesoZMYBDKBozPgCQHnmQINch != null)
		{
			if (P_1 <= 0)
			{
				goto IL_000e;
			}
			if (P_1 > XVnIVwOfVXTkdEoDpphKDCMddTX)
			{
				throw new Exception("Length is larger than the buffer.");
			}
			goto IL_0051;
		}
		goto IL_0061;
		IL_0013:
		int num;
		uint num2 = default(uint);
		while (true)
		{
			switch (num ^ 0x10186421)
			{
			case 2:
				break;
			case 5:
				zYKeONCJvFVdLkSazRiiAkczMzm++;
				num = 270033954;
				continue;
			case 0:
				goto IL_0051;
			case 1:
				goto IL_0061;
			case 4:
				if (num2 >= XVnIVwOfVXTkdEoDpphKDCMddTX)
				{
					ZckTUzfataxYhFHMHRgpZdnKrDk = 0u;
					if (zYKeONCJvFVdLkSazRiiAkczMzm == 254)
					{
						zYKeONCJvFVdLkSazRiiAkczMzm = 0;
						zLwOxaRgnfcvfwJWxEbMDREyljg = true;
						num = 270033954;
						continue;
					}
					goto case 5;
				}
				goto default;
			default:
				FTnXWfjUOcgIwWIoVmLFTvfzpAl.xAoyAHJdFUADrInDWUpVTFeRMMfa(gTGLesoZMYBDKBozPgCQHnmQINch + (int)ZckTUzfataxYhFHMHRgpZdnKrDk, (void*)P_0, new UIntPtr((uint)P_1));
				P_2 = new jBGQbJrWlivxkPopxkktnSOxGWu(zYKeONCJvFVdLkSazRiiAkczMzm, ZckTUzfataxYhFHMHRgpZdnKrDk, P_1);
				ZckTUzfataxYhFHMHRgpZdnKrDk += (uint)P_1;
				return true;
			}
			break;
		}
		goto IL_000e;
		IL_0051:
		num2 = ZckTUzfataxYhFHMHRgpZdnKrDk + (uint)P_1;
		num = 270033957;
		goto IL_0013;
		IL_0061:
		P_2 = default(jBGQbJrWlivxkPopxkktnSOxGWu);
		return false;
		IL_000e:
		num = 270033952;
		goto IL_0013;
	}

	public int NanoMDSNERLILwGbZOVIzaIWByQA(jBGQbJrWlivxkPopxkktnSOxGWu P_0, byte[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_1.Length < P_0.length)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!QfyJToQSVyeDDIpHpWSvnztitsu(ref P_0))
		{
			return -1;
		}
		Marshal.Copy(dkCXvjWqBRgCwptgHacfDiyzXOc(P_0), P_1, 0, P_0.length);
		return P_0.length;
	}

	public unsafe int NanoMDSNERLILwGbZOVIzaIWByQA(jBGQbJrWlivxkPopxkktnSOxGWu P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			while (true)
			{
				switch (-1103089916 ^ -1103089915)
				{
				case 2:
					break;
				case 1:
					throw new Exception("Buffer pointer is invalid.");
				case 0:
					goto end_IL_000d;
				default:
					goto IL_0063;
				}
				continue;
				end_IL_000d:
				break;
			}
		}
		if (P_2 <= 0)
		{
			return -1;
		}
		if (P_2 < P_0.length)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		goto IL_0063;
		IL_0063:
		if (!QfyJToQSVyeDDIpHpWSvnztitsu(ref P_0))
		{
			return -1;
		}
		FTnXWfjUOcgIwWIoVmLFTvfzpAl.xAoyAHJdFUADrInDWUpVTFeRMMfa((void*)P_1, gTGLesoZMYBDKBozPgCQHnmQINch, new UIntPtr((uint)P_0.length));
		return P_0.length;
	}

	public unsafe IntPtr dkCXvjWqBRgCwptgHacfDiyzXOc(jBGQbJrWlivxkPopxkktnSOxGWu P_0)
	{
		if (gTGLesoZMYBDKBozPgCQHnmQINch == null || !QfyJToQSVyeDDIpHpWSvnztitsu(ref P_0))
		{
			return IntPtr.Zero;
		}
		return (IntPtr)(gTGLesoZMYBDKBozPgCQHnmQINch + (int)P_0.offset);
	}

	public unsafe bool dMqzdENkNfbjccYnDhkRUnMXzJjF(jBGQbJrWlivxkPopxkktnSOxGWu P_0, out IntPtr P_1)
	{
		int num;
		if (gTGLesoZMYBDKBozPgCQHnmQINch != null)
		{
			if (!QfyJToQSVyeDDIpHpWSvnztitsu(ref P_0))
			{
				goto IL_0014;
			}
			P_1 = (IntPtr)(gTGLesoZMYBDKBozPgCQHnmQINch + (int)P_0.offset);
			num = 2034481381;
			goto IL_0019;
		}
		goto IL_0036;
		IL_0019:
		switch (num ^ 0x7943B8E5)
		{
		case 2:
			break;
		case 1:
			goto IL_0036;
		case 3:
			return false;
		default:
			return true;
		}
		goto IL_0014;
		IL_0036:
		P_1 = IntPtr.Zero;
		num = 2034481382;
		goto IL_0019;
		IL_0014:
		num = 2034481380;
		goto IL_0019;
	}

	private bool QfyJToQSVyeDDIpHpWSvnztitsu(ref jBGQbJrWlivxkPopxkktnSOxGWu P_0)
	{
		int length = P_0.length;
		if (length <= 0)
		{
			goto IL_000b;
		}
		uint pass = P_0.pass;
		if (pass > 254)
		{
			return false;
		}
		int num;
		if (pass == zYKeONCJvFVdLkSazRiiAkczMzm)
		{
			if (P_0.offset + length > ZckTUzfataxYhFHMHRgpZdnKrDk)
			{
				num = -545638769;
				goto IL_0010;
			}
			goto IL_00de;
		}
		if (!zLwOxaRgnfcvfwJWxEbMDREyljg)
		{
			if (pass + 1 != zYKeONCJvFVdLkSazRiiAkczMzm)
			{
				return false;
			}
		}
		else
		{
			if (pass > zYKeONCJvFVdLkSazRiiAkczMzm)
			{
				int num2;
				if (zYKeONCJvFVdLkSazRiiAkczMzm != 0)
				{
					num = -545638771;
					num2 = num;
				}
				else
				{
					num = -545638773;
					num2 = num;
				}
				goto IL_0010;
			}
			if (pass + 1 != zYKeONCJvFVdLkSazRiiAkczMzm)
			{
				return false;
			}
		}
		goto IL_0047;
		IL_00de:
		if (P_0.offset + length > XVnIVwOfVXTkdEoDpphKDCMddTX)
		{
			num = -545638774;
			goto IL_0010;
		}
		return true;
		IL_000b:
		num = -545638772;
		goto IL_0010;
		IL_0010:
		while (true)
		{
			switch (num ^ -545638770)
			{
			case 0:
				break;
			case 3:
				return false;
			case 5:
				goto IL_0074;
			case 2:
				return false;
			case 1:
				return false;
			default:
				return false;
			}
			break;
			IL_0074:
			if (pass != 254)
			{
				num = -545638771;
				continue;
			}
			goto IL_0047;
		}
		goto IL_000b;
		IL_0047:
		if (P_0.offset < ZckTUzfataxYhFHMHRgpZdnKrDk)
		{
			return false;
		}
		goto IL_00de;
	}

	public void Dispose()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~ivzKWEuUPrZkAmvXVghFUQvtaAv()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
	}

	protected unsafe virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
	{
		if (nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			goto IL_0008;
		}
		goto IL_003a;
		IL_0008:
		int num = -281454006;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ -281454005)
			{
			case 5:
				break;
			default:
				return;
			case 1:
				return;
			case 3:
				goto IL_003a;
			case 4:
				Marshal.FreeHGlobal((IntPtr)gTGLesoZMYBDKBozPgCQHnmQINch);
				num = -281454007;
				continue;
			case 2:
				nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
				num = -281454005;
				continue;
			case 0:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_003a:
		int num2;
		if (gTGLesoZMYBDKBozPgCQHnmQINch == null)
		{
			num = -281454007;
			num2 = num;
		}
		else
		{
			num = -281454001;
			num2 = num;
		}
		goto IL_000d;
	}
}
