using System;

internal class GdceyYbNMgAeklPyKJvKdpKJSuEsB : IDisposable
{
	private readonly sGsLByENMOOLPRqYgWkgmPquaqHj pshxLsVBaxPobdRQOPmmlqHPIgYt;

	private bool[] VfckIpWlneXqwIgFNFRrIChBCQyfA;

	protected readonly int tBNKFvwogRmmryotTOCAYRUNWLes;

	protected readonly int UrBCeIhKaawIpPYPUCSoRIQLeJQFb;

	private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

	public int FMxfkNbNwJGhLsNmCzvCLMBCAGyQ => tBNKFvwogRmmryotTOCAYRUNWLes;

	public int eohFsdVkRvyEdEIhDuGsBlzpfOFx => UrBCeIhKaawIpPYPUCSoRIQLeJQFb;

	public bool[] ZWOCRaHYxNwcEkSZCwQXNxBcVtGO => VfckIpWlneXqwIgFNFRrIChBCQyfA ?? (VfckIpWlneXqwIgFNFRrIChBCQyfA = new bool[tBNKFvwogRmmryotTOCAYRUNWLes]);

	public GdceyYbNMgAeklPyKJvKdpKJSuEsB(int P_0, int P_1)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("entryBitSize");
		}
		UrBCeIhKaawIpPYPUCSoRIQLeJQFb = P_0;
		tBNKFvwogRmmryotTOCAYRUNWLes = P_1;
		int num = P_0 * P_1;
		pshxLsVBaxPobdRQOPmmlqHPIgYt = new sGsLByENMOOLPRqYgWkgmPquaqHj(num / 8 + ((num % 8 != 0) ? 1 : 0));
	}

	public unsafe void jBeadTndiITwAWHVgGNrnfDNGje(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 < tBNKFvwogRmmryotTOCAYRUNWLes)
		{
			int num = tBNKFvwogRmmryotTOCAYRUNWLes;
			throw new Exception("Buffer is too small to hold the data. Must be at least " + num + " bits.");
		}
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < tBNKFvwogRmmryotTOCAYRUNWLes; i++)
		{
			PENghYJGTCrLAWXJShJTIdXCPcWEb(P_0, i, out var num4, out var b);
			P_1[i] = (pshxLsVBaxPobdRQOPmmlqHPIgYt.oOHyUBktSMJXfbCdChgYfvxvbFGf(num4, b) ? ((byte)(P_1[num2] | (1 << num3))) : ((byte)(P_1[num2] & ~(1 << num3))));
			num3++;
			if (num3 >= 8)
			{
				num2++;
				num3 = 0;
			}
		}
	}

	public unsafe void jBeadTndiITwAWHVgGNrnfDNGje(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		jBeadTndiITwAWHVgGNrnfDNGje(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void jBeadTndiITwAWHVgGNrnfDNGje(int P_0, out byte P_1)
	{
		byte b = 0;
		byte* ptr = &b;
		jBeadTndiITwAWHVgGNrnfDNGje(P_0, ptr, 64);
		P_1 = b;
	}

	public void jBeadTndiITwAWHVgGNrnfDNGje(int P_0, out sbyte P_1)
	{
		jBeadTndiITwAWHVgGNrnfDNGje(P_0, out byte b);
		P_1 = (sbyte)b;
	}

	public unsafe void jBeadTndiITwAWHVgGNrnfDNGje(int P_0, out short P_1)
	{
		short num = 0;
		byte* ptr = (byte*)(&num);
		jBeadTndiITwAWHVgGNrnfDNGje(P_0, ptr, 64);
		P_1 = num;
	}

	public void jBeadTndiITwAWHVgGNrnfDNGje(int P_0, out ushort P_1)
	{
		jBeadTndiITwAWHVgGNrnfDNGje(P_0, out short num);
		P_1 = (ushort)num;
	}

	public unsafe void jBeadTndiITwAWHVgGNrnfDNGje(int P_0, out int P_1)
	{
		int num = 0;
		byte* ptr = (byte*)(&num);
		jBeadTndiITwAWHVgGNrnfDNGje(P_0, ptr, 64);
		P_1 = num;
	}

	public void jBeadTndiITwAWHVgGNrnfDNGje(int P_0, out uint P_1)
	{
		jBeadTndiITwAWHVgGNrnfDNGje(P_0, out int num);
		P_1 = (uint)num;
	}

	public unsafe void jBeadTndiITwAWHVgGNrnfDNGje(int P_0, out long P_1)
	{
		long num = 0L;
		byte* ptr = (byte*)(&num);
		jBeadTndiITwAWHVgGNrnfDNGje(P_0, ptr, 64);
		P_1 = num;
	}

	public void jBeadTndiITwAWHVgGNrnfDNGje(int P_0, out ulong P_1)
	{
		jBeadTndiITwAWHVgGNrnfDNGje(P_0, out long num);
		P_1 = (ulong)num;
	}

	public void jBeadTndiITwAWHVgGNrnfDNGje(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < tBNKFvwogRmmryotTOCAYRUNWLes)
		{
			int num = tBNKFvwogRmmryotTOCAYRUNWLes;
			throw new Exception("valueBuffer.Length must be >= " + num);
		}
		for (int i = 0; i < tBNKFvwogRmmryotTOCAYRUNWLes; i++)
		{
			PENghYJGTCrLAWXJShJTIdXCPcWEb(P_0, i, out var num2, out var b);
			P_1[i] = pshxLsVBaxPobdRQOPmmlqHPIgYt.oOHyUBktSMJXfbCdChgYfvxvbFGf(num2, b);
		}
	}

	public unsafe void NUzFOceieRtYgUBucdKscULgKGluB(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 <= 0)
		{
			throw new Exception("bufferSize must be >= 0");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < tBNKFvwogRmmryotTOCAYRUNWLes; i++)
		{
			PENghYJGTCrLAWXJShJTIdXCPcWEb(P_0, i, out var num3, out var b);
			bool flag = i < P_2 && (flag = (P_1[num] & (1 << num2)) != 0);
			pshxLsVBaxPobdRQOPmmlqHPIgYt.KfPSZwqWNtVwJjVAFSAYVlVIHIub(num3, b, flag);
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void NUzFOceieRtYgUBucdKscULgKGluB(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		NUzFOceieRtYgUBucdKscULgKGluB(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void NUzFOceieRtYgUBucdKscULgKGluB(int P_0, byte P_1)
	{
		byte* ptr = &P_1;
		NUzFOceieRtYgUBucdKscULgKGluB(P_0, ptr, 8);
	}

	public void NUzFOceieRtYgUBucdKscULgKGluB(int P_0, sbyte P_1)
	{
		NUzFOceieRtYgUBucdKscULgKGluB(P_0, (byte)P_1);
	}

	public unsafe void NUzFOceieRtYgUBucdKscULgKGluB(int P_0, short P_1)
	{
		byte* ptr = (byte*)(&P_1);
		NUzFOceieRtYgUBucdKscULgKGluB(P_0, ptr, 16);
	}

	public void NUzFOceieRtYgUBucdKscULgKGluB(int P_0, ushort P_1)
	{
		NUzFOceieRtYgUBucdKscULgKGluB(P_0, (short)P_1);
	}

	public unsafe void NUzFOceieRtYgUBucdKscULgKGluB(int P_0, int P_1)
	{
		byte* ptr = (byte*)(&P_1);
		NUzFOceieRtYgUBucdKscULgKGluB(P_0, ptr, 32);
	}

	public void NUzFOceieRtYgUBucdKscULgKGluB(int P_0, uint P_1)
	{
		NUzFOceieRtYgUBucdKscULgKGluB(P_0, (int)P_1);
	}

	public unsafe void NUzFOceieRtYgUBucdKscULgKGluB(int P_0, long P_1)
	{
		byte* ptr = (byte*)(&P_1);
		NUzFOceieRtYgUBucdKscULgKGluB(P_0, ptr, 64);
	}

	public void NUzFOceieRtYgUBucdKscULgKGluB(int P_0, ulong P_1)
	{
		NUzFOceieRtYgUBucdKscULgKGluB(P_0, (long)P_1);
	}

	public void NUzFOceieRtYgUBucdKscULgKGluB(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < tBNKFvwogRmmryotTOCAYRUNWLes)
		{
			int num = tBNKFvwogRmmryotTOCAYRUNWLes;
			throw new Exception("valueBuffer.Length must be >= " + num);
		}
		for (int i = 0; i < tBNKFvwogRmmryotTOCAYRUNWLes; i++)
		{
			PENghYJGTCrLAWXJShJTIdXCPcWEb(P_0, i, out var num2, out var b);
			pshxLsVBaxPobdRQOPmmlqHPIgYt.KfPSZwqWNtVwJjVAFSAYVlVIHIub(num2, b, P_1[i]);
		}
	}

	private void PENghYJGTCrLAWXJShJTIdXCPcWEb(int P_0, int P_1, out int P_2, out byte P_3)
	{
		if (P_0 < 0 || P_0 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
		{
			throw new IndexOutOfRangeException("entryIndex");
		}
		if (P_1 < 0 || P_1 >= tBNKFvwogRmmryotTOCAYRUNWLes)
		{
			throw new ArgumentOutOfRangeException("bitOffset");
		}
		int num = P_0 * tBNKFvwogRmmryotTOCAYRUNWLes + P_1;
		P_2 = num / tBNKFvwogRmmryotTOCAYRUNWLes;
		P_3 = (byte)(num - P_2 * tBNKFvwogRmmryotTOCAYRUNWLes);
	}

	private int PDqifcgEkfXcDcbjiVZZbzDdhnzuA(int P_0, out byte P_1)
	{
		if (P_0 < 0 || P_0 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb * tBNKFvwogRmmryotTOCAYRUNWLes)
		{
			throw new IndexOutOfRangeException("bitIndex");
		}
		int num = P_0 / tBNKFvwogRmmryotTOCAYRUNWLes;
		P_1 = (byte)(P_0 - num * tBNKFvwogRmmryotTOCAYRUNWLes);
		return num;
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

	protected virtual void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
	{
		if (!TExNvhkEWsBWipIUjadCDaTpNNDG)
		{
			if (P_0 && pshxLsVBaxPobdRQOPmmlqHPIgYt != null)
			{
				pshxLsVBaxPobdRQOPmmlqHPIgYt.Dispose();
			}
			TExNvhkEWsBWipIUjadCDaTpNNDG = true;
		}
	}
}
