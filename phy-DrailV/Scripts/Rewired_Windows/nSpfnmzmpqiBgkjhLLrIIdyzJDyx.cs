using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class nSpfnmzmpqiBgkjhLLrIIdyzJDyx<_0001> : IDisposable where _0001 : struct
{
	private static readonly int bKFjyRTrjUCZHtswQeOEtYaivvKq = Marshal.SizeOf(typeof(_0001));

	private SoDaUPyxhCljCRyOJyRmuMKFqYxD njPEqelkqUAXHcVOBySkfuuGgySaA;

	private bool sUYxTWukhNwMlCPAKIvxlIFzprku;

	public SoDaUPyxhCljCRyOJyRmuMKFqYxD dXHcFyHeaDiigomrUnUCJYjMNGxM => njPEqelkqUAXHcVOBySkfuuGgySaA;

	public bool VlGuCyNnxFMrFgTRmuBvnTxvszhG
	{
		get
		{
			if (njPEqelkqUAXHcVOBySkfuuGgySaA != null)
			{
				return njPEqelkqUAXHcVOBySkfuuGgySaA.eRuooOpUXUMNyxAVfhJQXVsDGDql != IntPtr.Zero;
			}
			return false;
		}
	}

	public unsafe _0001 pWRdAJigDslyLjNIYbVMMkTWOPgC
	{
		get
		{
			UbhfitmqSnghzNQmEETmhVEHDLpf();
			return System.Runtime.CompilerServices.Unsafe.Read<_0001>((void*)njPEqelkqUAXHcVOBySkfuuGgySaA.eRuooOpUXUMNyxAVfhJQXVsDGDql);
		}
		set
		{
			UbhfitmqSnghzNQmEETmhVEHDLpf();
			_0001* ptr = &val;
			njPEqelkqUAXHcVOBySkfuuGgySaA.SXQFQqvxMovHIpJOhLVDcMlbtntt((IntPtr)ptr, bKFjyRTrjUCZHtswQeOEtYaivvKq, bKFjyRTrjUCZHtswQeOEtYaivvKq);
		}
	}

	public nSpfnmzmpqiBgkjhLLrIIdyzJDyx()
	{
		njPEqelkqUAXHcVOBySkfuuGgySaA = new SoDaUPyxhCljCRyOJyRmuMKFqYxD(bKFjyRTrjUCZHtswQeOEtYaivvKq);
	}

	private void yLZjIbuoIPgdDnORPUhHJFvwOVWR()
	{
		if (njPEqelkqUAXHcVOBySkfuuGgySaA == null)
		{
			njPEqelkqUAXHcVOBySkfuuGgySaA.Dispose();
			njPEqelkqUAXHcVOBySkfuuGgySaA = null;
		}
	}

	private void UbhfitmqSnghzNQmEETmhVEHDLpf()
	{
		if (!VlGuCyNnxFMrFgTRmuBvnTxvszhG)
		{
			throw new Exception("Memory not allocated.");
		}
	}

	private void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (!sUYxTWukhNwMlCPAKIvxlIFzprku)
		{
			if (P_0)
			{
				yLZjIbuoIPgdDnORPUhHJFvwOVWR();
			}
			sUYxTWukhNwMlCPAKIvxlIFzprku = true;
		}
	}

	public void Dispose()
	{
		vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
		GC.SuppressFinalize(this);
	}
}
