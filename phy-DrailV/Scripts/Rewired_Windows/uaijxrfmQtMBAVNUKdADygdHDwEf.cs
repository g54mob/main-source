using System;
using System.Runtime.InteropServices;

internal class uaijxrfmQtMBAVNUKdADygdHDwEf : IDisposable
{
	public struct jlSKscvPIQmsaphLREfgBPXgEuVgb
	{
		private byte LzwnVylJWIpxoYxhbsGNsykDsEDh;

		private uint ZXvaGfLpIvryxtKpCwvisFNkPoeg;

		private int AZhQJGaSuJAjHcWRLuegYXjYvVYw;

		private static jlSKscvPIQmsaphLREfgBPXgEuVgb TUyMUUhXZzuQOQcQZoJFvyPCQkDh;

		public byte NPvbTgwjmPFvWzBKpuEXmBUUrzAs => LzwnVylJWIpxoYxhbsGNsykDsEDh;

		public uint ZBktiowjvpXMZgFzRtDzwijYEfohA => ZXvaGfLpIvryxtKpCwvisFNkPoeg;

		public int OsTWxRwhRxJpeyxmILLwKEftpqsu => AZhQJGaSuJAjHcWRLuegYXjYvVYw;

		public static jlSKscvPIQmsaphLREfgBPXgEuVgb AptqaiIcUScAeJupUylgGcutQGtqA => TUyMUUhXZzuQOQcQZoJFvyPCQkDh;

		public jlSKscvPIQmsaphLREfgBPXgEuVgb(byte P_0, uint P_1, int P_2)
		{
			LzwnVylJWIpxoYxhbsGNsykDsEDh = P_0;
			ZXvaGfLpIvryxtKpCwvisFNkPoeg = P_1;
			AZhQJGaSuJAjHcWRLuegYXjYvVYw = P_2;
			if (AZhQJGaSuJAjHcWRLuegYXjYvVYw < 0)
			{
				AZhQJGaSuJAjHcWRLuegYXjYvVYw = 0;
			}
		}
	}

	private const byte ZWwFQRhTGGJcPudSiiXYCVbiJCuU = 254;

	private uint neOgwOeGAtabKXdYBjZGpGhyzsXm;

	private int jyNgjBKjtMOBIAeWfwbzXvGJrEsnA;

	private unsafe byte* KTwZEVJzqLJlhtEmLCnxpNyoODZj;

	private byte LzwnVylJWIpxoYxhbsGNsykDsEDh;

	private bool ROAPjVaeLaXrQMjTdUjxxuKWeyBN;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	public int TnbqoUvYgoTtgZoGauUtjgKQTcti => jyNgjBKjtMOBIAeWfwbzXvGJrEsnA;

	public unsafe uaijxrfmQtMBAVNUKdADygdHDwEf(int P_0)
	{
		if (P_0 <= 0)
		{
			throw new Exception("size must be > 0!");
		}
		jyNgjBKjtMOBIAeWfwbzXvGJrEsnA = P_0;
		neOgwOeGAtabKXdYBjZGpGhyzsXm = 0u;
		KTwZEVJzqLJlhtEmLCnxpNyoODZj = (byte*)(void*)Marshal.AllocHGlobal(P_0);
	}

	public unsafe bool EvDntuhsTubUqbxfRrKDVdXsLcYv(IntPtr P_0, int P_1, out jlSKscvPIQmsaphLREfgBPXgEuVgb P_2)
	{
		if (KTwZEVJzqLJlhtEmLCnxpNyoODZj == null || P_1 <= 0)
		{
			P_2 = default(jlSKscvPIQmsaphLREfgBPXgEuVgb);
			return false;
		}
		if (P_1 > jyNgjBKjtMOBIAeWfwbzXvGJrEsnA)
		{
			throw new Exception("Length is larger than the buffer.");
		}
		if ((uint)((int)neOgwOeGAtabKXdYBjZGpGhyzsXm + P_1) > jyNgjBKjtMOBIAeWfwbzXvGJrEsnA)
		{
			neOgwOeGAtabKXdYBjZGpGhyzsXm = 0u;
			if (LzwnVylJWIpxoYxhbsGNsykDsEDh == 254)
			{
				LzwnVylJWIpxoYxhbsGNsykDsEDh = 0;
				ROAPjVaeLaXrQMjTdUjxxuKWeyBN = true;
			}
			else
			{
				LzwnVylJWIpxoYxhbsGNsykDsEDh++;
			}
		}
		VBqfSSvUBwCRtzUpeUWIfCWGfXliA.VuAtacyvSDBAOFEJIxkefiuxVUOb(KTwZEVJzqLJlhtEmLCnxpNyoODZj + neOgwOeGAtabKXdYBjZGpGhyzsXm, (void*)P_0, new UIntPtr((uint)P_1));
		P_2 = new jlSKscvPIQmsaphLREfgBPXgEuVgb(LzwnVylJWIpxoYxhbsGNsykDsEDh, neOgwOeGAtabKXdYBjZGpGhyzsXm, P_1);
		neOgwOeGAtabKXdYBjZGpGhyzsXm += (uint)P_1;
		return true;
	}

	public int xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(jlSKscvPIQmsaphLREfgBPXgEuVgb P_0, byte[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_1.Length < P_0.OsTWxRwhRxJpeyxmILLwKEftpqsu)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!wGCbmRDzstaygqaalbQOZNpGugRrA(ref P_0))
		{
			return -1;
		}
		Marshal.Copy(FCcWDSlxbIQbTHkhZiFIrvyFFURI(P_0), P_1, 0, P_0.OsTWxRwhRxJpeyxmILLwKEftpqsu);
		return P_0.OsTWxRwhRxJpeyxmILLwKEftpqsu;
	}

	public unsafe int xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(jlSKscvPIQmsaphLREfgBPXgEuVgb P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new Exception("Buffer pointer is invalid.");
		}
		if (P_2 <= 0)
		{
			return -1;
		}
		if (P_2 < P_0.OsTWxRwhRxJpeyxmILLwKEftpqsu)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!wGCbmRDzstaygqaalbQOZNpGugRrA(ref P_0))
		{
			return -1;
		}
		VBqfSSvUBwCRtzUpeUWIfCWGfXliA.VuAtacyvSDBAOFEJIxkefiuxVUOb((void*)P_1, (void*)FCcWDSlxbIQbTHkhZiFIrvyFFURI(P_0), new UIntPtr((uint)P_0.OsTWxRwhRxJpeyxmILLwKEftpqsu));
		return P_0.OsTWxRwhRxJpeyxmILLwKEftpqsu;
	}

	public unsafe IntPtr FCcWDSlxbIQbTHkhZiFIrvyFFURI(jlSKscvPIQmsaphLREfgBPXgEuVgb P_0)
	{
		if (KTwZEVJzqLJlhtEmLCnxpNyoODZj == null || !wGCbmRDzstaygqaalbQOZNpGugRrA(ref P_0))
		{
			return IntPtr.Zero;
		}
		return (IntPtr)(KTwZEVJzqLJlhtEmLCnxpNyoODZj + P_0.ZBktiowjvpXMZgFzRtDzwijYEfohA);
	}

	public unsafe bool TJOIFtszJgnKHiaeNqWsZKebOxYd(jlSKscvPIQmsaphLREfgBPXgEuVgb P_0, out IntPtr P_1)
	{
		if (KTwZEVJzqLJlhtEmLCnxpNyoODZj == null || !wGCbmRDzstaygqaalbQOZNpGugRrA(ref P_0))
		{
			P_1 = IntPtr.Zero;
			return false;
		}
		P_1 = (IntPtr)(KTwZEVJzqLJlhtEmLCnxpNyoODZj + P_0.ZBktiowjvpXMZgFzRtDzwijYEfohA);
		return true;
	}

	private bool wGCbmRDzstaygqaalbQOZNpGugRrA(ref jlSKscvPIQmsaphLREfgBPXgEuVgb P_0)
	{
		int num = P_0.OsTWxRwhRxJpeyxmILLwKEftpqsu;
		if (num <= 0)
		{
			return false;
		}
		uint num2 = P_0.NPvbTgwjmPFvWzBKpuEXmBUUrzAs;
		if (num2 > 254)
		{
			return false;
		}
		if (num2 != LzwnVylJWIpxoYxhbsGNsykDsEDh)
		{
			if (!ROAPjVaeLaXrQMjTdUjxxuKWeyBN)
			{
				if (num2 + 1 != LzwnVylJWIpxoYxhbsGNsykDsEDh)
				{
					return false;
				}
			}
			else if (num2 > LzwnVylJWIpxoYxhbsGNsykDsEDh)
			{
				if (LzwnVylJWIpxoYxhbsGNsykDsEDh != 0 || num2 != 254)
				{
					return false;
				}
			}
			else if (num2 + 1 != LzwnVylJWIpxoYxhbsGNsykDsEDh)
			{
				return false;
			}
			if (P_0.ZBktiowjvpXMZgFzRtDzwijYEfohA < neOgwOeGAtabKXdYBjZGpGhyzsXm)
			{
				return false;
			}
		}
		else if (P_0.ZBktiowjvpXMZgFzRtDzwijYEfohA + num > neOgwOeGAtabKXdYBjZGpGhyzsXm)
		{
			return false;
		}
		if (P_0.ZBktiowjvpXMZgFzRtDzwijYEfohA + num > jyNgjBKjtMOBIAeWfwbzXvGJrEsnA)
		{
			return false;
		}
		return true;
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

	protected unsafe virtual void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (!JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			if (KTwZEVJzqLJlhtEmLCnxpNyoODZj != null)
			{
				Marshal.FreeHGlobal((IntPtr)KTwZEVJzqLJlhtEmLCnxpNyoODZj);
			}
			JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
		}
	}
}
