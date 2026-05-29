using System;
using Rewired.Utils;

internal class XgfhmksxlThdyWjNKixlzEZZYFT : IDisposable
{
	private readonly SbUIvncwPygDdWhgMeEVPFknbZc BnTkMddEMRIYxgTpcAWVDYoOLbph;

	private readonly int FzAmpSZwvsQQZPESwsEyCMKYILd;

	private long kQoodDABZWLFiJPbfsVBGArgbvs;

	private long jlwsqalivRgSqHIiZUoArTWNOQL;

	private int rmFPnOooJhJQGTunxbPgEWOmRZj;

	private bool LCQQjzalaexdPEdNBJrvGeREiCGX;

	private uint EjUdJjkkVaKmBHJeWJajAXxObnd;

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	public int Capacity
	{
		get
		{
			return FzAmpSZwvsQQZPESwsEyCMKYILd;
		}
	}

	public int BytesInBuffer
	{
		get
		{
			return rmFPnOooJhJQGTunxbPgEWOmRZj;
		}
	}

	public bool BufferOverrun
	{
		get
		{
			return LCQQjzalaexdPEdNBJrvGeREiCGX;
		}
	}

	public XgfhmksxlThdyWjNKixlzEZZYFT(int capacity)
	{
		FzAmpSZwvsQQZPESwsEyCMKYILd = capacity;
		if (capacity <= 0)
		{
			throw new ArgumentOutOfRangeException("sizeInBytes");
		}
		BnTkMddEMRIYxgTpcAWVDYoOLbph = new SbUIvncwPygDdWhgMeEVPFknbZc(capacity);
	}

	public unsafe int uwRrXbrytlKXYWIOmlUkwmZqEzx(byte* P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		P_3 = (int)kQoodDABZWLFiJPbfsVBGArgbvs;
		P_4 = EjUdJjkkVaKmBHJeWJajAXxObnd;
		if (P_0 == null || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		int num = BnTkMddEMRIYxgTpcAWVDYoOLbph.wZGHqvpqurPSaSLhSFRcXnpjBkE(P_0, P_1, P_2, (int)kQoodDABZWLFiJPbfsVBGArgbvs);
		if (num == 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += BnTkMddEMRIYxgTpcAWVDYoOLbph.wZGHqvpqurPSaSLhSFRcXnpjBkE(P_0 + num, P_1 - num, P_2 - num);
		}
		VsAuuDDRVUVBmKcnVnHITXAnoZs(num);
		return num;
	}

	public unsafe int uwRrXbrytlKXYWIOmlUkwmZqEzx(IntPtr P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			P_3 = (int)kQoodDABZWLFiJPbfsVBGArgbvs;
			P_4 = EjUdJjkkVaKmBHJeWJajAXxObnd;
			return 0;
		}
		return uwRrXbrytlKXYWIOmlUkwmZqEzx((byte*)(void*)P_0, P_1, P_2, out P_3, out P_4);
	}

	public unsafe int uwRrXbrytlKXYWIOmlUkwmZqEzx(byte[] P_0, int P_1, out int P_2, out uint P_3)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = (int)kQoodDABZWLFiJPbfsVBGArgbvs;
			P_3 = EjUdJjkkVaKmBHJeWJajAXxObnd;
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return uwRrXbrytlKXYWIOmlUkwmZqEzx(ptr, P_0.Length, P_1, out P_2, out P_3);
		}
	}

	public unsafe int uwRrXbrytlKXYWIOmlUkwmZqEzx(byte* P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return uwRrXbrytlKXYWIOmlUkwmZqEzx(P_0, P_1, P_2, out num, out num2);
	}

	public int uwRrXbrytlKXYWIOmlUkwmZqEzx(IntPtr P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return uwRrXbrytlKXYWIOmlUkwmZqEzx(P_0, P_1, P_2, out num, out num2);
	}

	public int uwRrXbrytlKXYWIOmlUkwmZqEzx(byte[] P_0, int P_1)
	{
		int num;
		uint num2;
		return uwRrXbrytlKXYWIOmlUkwmZqEzx(P_0, P_1, out num, out num2);
	}

	public unsafe int BzRDvjvAQHKNUfdBiARKBsCcKkSL(byte* P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || rmFPnOooJhJQGTunxbPgEWOmRZj == 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > rmFPnOooJhJQGTunxbPgEWOmRZj)
		{
			P_2 = rmFPnOooJhJQGTunxbPgEWOmRZj;
		}
		int num = BnTkMddEMRIYxgTpcAWVDYoOLbph.KOXpOMjFyJDqRjvdDHjWBnAkNgXn(P_0, P_1, P_2, (int)jlwsqalivRgSqHIiZUoArTWNOQL);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += BnTkMddEMRIYxgTpcAWVDYoOLbph.KOXpOMjFyJDqRjvdDHjWBnAkNgXn(P_0 + num, P_1 - num, P_2 - num);
		}
		vcKpQqwuQuTAYXQwJgmKIvacPEn(num);
		return num;
	}

	public unsafe int BzRDvjvAQHKNUfdBiARKBsCcKkSL(byte[] P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return BzRDvjvAQHKNUfdBiARKBsCcKkSL(ptr, P_0.Length, P_1);
		}
	}

	public unsafe int BzRDvjvAQHKNUfdBiARKBsCcKkSL(IntPtr P_0, int P_1, int P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		return BzRDvjvAQHKNUfdBiARKBsCcKkSL((byte*)(void*)P_0, P_1, P_2);
	}

	public unsafe int mDbGZXyamQbHzAiWYgtFDajZiMvy(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || rmFPnOooJhJQGTunxbPgEWOmRZj == 0 || P_3 < 0 || P_3 >= FzAmpSZwvsQQZPESwsEyCMKYILd)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > rmFPnOooJhJQGTunxbPgEWOmRZj)
		{
			P_2 = rmFPnOooJhJQGTunxbPgEWOmRZj;
		}
		int num = BnTkMddEMRIYxgTpcAWVDYoOLbph.KOXpOMjFyJDqRjvdDHjWBnAkNgXn(P_0, P_1, P_2, P_3);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += BnTkMddEMRIYxgTpcAWVDYoOLbph.KOXpOMjFyJDqRjvdDHjWBnAkNgXn(P_0 + num, P_1 - num, P_2 - num);
		}
		return num;
	}

	public unsafe int mDbGZXyamQbHzAiWYgtFDajZiMvy(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return mDbGZXyamQbHzAiWYgtFDajZiMvy(ptr, P_0.Length, P_1, P_2);
		}
	}

	public unsafe int mDbGZXyamQbHzAiWYgtFDajZiMvy(IntPtr P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_3 <= 0)
		{
			return 0;
		}
		return mDbGZXyamQbHzAiWYgtFDajZiMvy((byte*)(void*)P_0, P_1, P_2, P_3);
	}

	public bool jeWmRmokDYDPjTWrXHsFdDYnkvH(int P_0, uint P_1)
	{
		if (P_0 < 0 || P_0 >= FzAmpSZwvsQQZPESwsEyCMKYILd)
		{
			return false;
		}
		if (P_0 < kQoodDABZWLFiJPbfsVBGArgbvs)
		{
			if (P_1 == EjUdJjkkVaKmBHJeWJajAXxObnd)
			{
				return true;
			}
		}
		else if (P_0 >= kQoodDABZWLFiJPbfsVBGArgbvs)
		{
			if (EjUdJjkkVaKmBHJeWJajAXxObnd == 0)
			{
				return false;
			}
			if (EjUdJjkkVaKmBHJeWJajAXxObnd - 1 == P_1)
			{
				return true;
			}
		}
		return false;
	}

	public void AWzoUVGHSxWLxpNvJinAivnlHuG()
	{
		kQoodDABZWLFiJPbfsVBGArgbvs = 0L;
		jlwsqalivRgSqHIiZUoArTWNOQL = 0L;
		rmFPnOooJhJQGTunxbPgEWOmRZj = 0;
		LCQQjzalaexdPEdNBJrvGeREiCGX = false;
		EjUdJjkkVaKmBHJeWJajAXxObnd = 0u;
	}

	private void VsAuuDDRVUVBmKcnVnHITXAnoZs(int P_0)
	{
		if (P_0 <= 0)
		{
			return;
		}
		int num = (int)kQoodDABZWLFiJPbfsVBGArgbvs;
		kQoodDABZWLFiJPbfsVBGArgbvs += P_0;
		bool flag = false;
		if (num < jlwsqalivRgSqHIiZUoArTWNOQL)
		{
			if (kQoodDABZWLFiJPbfsVBGArgbvs > jlwsqalivRgSqHIiZUoArTWNOQL)
			{
				flag = true;
			}
		}
		else if (num > jlwsqalivRgSqHIiZUoArTWNOQL)
		{
			if (kQoodDABZWLFiJPbfsVBGArgbvs - FzAmpSZwvsQQZPESwsEyCMKYILd > jlwsqalivRgSqHIiZUoArTWNOQL)
			{
				flag = true;
			}
		}
		else if (rmFPnOooJhJQGTunxbPgEWOmRZj > 0)
		{
			flag = true;
		}
		if (flag)
		{
			LCQQjzalaexdPEdNBJrvGeREiCGX = true;
			jlwsqalivRgSqHIiZUoArTWNOQL = kQoodDABZWLFiJPbfsVBGArgbvs;
			if (jlwsqalivRgSqHIiZUoArTWNOQL >= FzAmpSZwvsQQZPESwsEyCMKYILd)
			{
				jlwsqalivRgSqHIiZUoArTWNOQL -= FzAmpSZwvsQQZPESwsEyCMKYILd;
			}
		}
		if (kQoodDABZWLFiJPbfsVBGArgbvs >= FzAmpSZwvsQQZPESwsEyCMKYILd)
		{
			kQoodDABZWLFiJPbfsVBGArgbvs -= FzAmpSZwvsQQZPESwsEyCMKYILd;
			tlKNdkeCVpXrYPhOAxfbdcUvrjm();
		}
		rmFPnOooJhJQGTunxbPgEWOmRZj = (int)MathTools.Clamp((long)rmFPnOooJhJQGTunxbPgEWOmRZj + (long)P_0, 0L, FzAmpSZwvsQQZPESwsEyCMKYILd);
	}

	private void vcKpQqwuQuTAYXQwJgmKIvacPEn(int P_0)
	{
		if (P_0 > 0)
		{
			if (LCQQjzalaexdPEdNBJrvGeREiCGX)
			{
				LCQQjzalaexdPEdNBJrvGeREiCGX = false;
			}
			jlwsqalivRgSqHIiZUoArTWNOQL += P_0;
			if (jlwsqalivRgSqHIiZUoArTWNOQL >= FzAmpSZwvsQQZPESwsEyCMKYILd)
			{
				jlwsqalivRgSqHIiZUoArTWNOQL -= FzAmpSZwvsQQZPESwsEyCMKYILd;
			}
			long num = (long)rmFPnOooJhJQGTunxbPgEWOmRZj - (long)P_0;
			rmFPnOooJhJQGTunxbPgEWOmRZj = (int)((num >= 0) ? num : 0);
		}
	}

	private void tlKNdkeCVpXrYPhOAxfbdcUvrjm()
	{
		if (EjUdJjkkVaKmBHJeWJajAXxObnd == uint.MaxValue)
		{
			EjUdJjkkVaKmBHJeWJajAXxObnd = 0u;
		}
		else
		{
			EjUdJjkkVaKmBHJeWJajAXxObnd++;
		}
	}

	public void Dispose()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~XgfhmksxlThdyWjNKixlzEZZYFT()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	protected void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		if (!nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			if (P_0 && BnTkMddEMRIYxgTpcAWVDYoOLbph != null)
			{
				BnTkMddEMRIYxgTpcAWVDYoOLbph.Dispose();
			}
			nNxUslIcGUpqKgpPZYhuimcvWyC = true;
		}
	}
}
