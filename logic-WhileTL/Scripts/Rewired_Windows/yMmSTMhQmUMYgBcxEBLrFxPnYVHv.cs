using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class yMmSTMhQmUMYgBcxEBLrFxPnYVHv : IEnumerable<byte>, IDisposable, IEnumerable
{
	private struct GDRoGgVjDcEWUTGxoyPHXdGnupTP : IEnumerator<byte>, IDisposable, IEnumerator
	{
		private yMmSTMhQmUMYgBcxEBLrFxPnYVHv wvqqjLpgJjBOUipXnKDUptxhoSQGA;

		private int hZAbfEaIVUqgRLyftfHrQszcqiobA;

		public byte Current => wvqqjLpgJjBOUipXnKDUptxhoSQGA.kgwdsbyPYraFCzTnGhgMYpoQdzaC(hZAbfEaIVUqgRLyftfHrQszcqiobA);

		object IEnumerator.Current => wvqqjLpgJjBOUipXnKDUptxhoSQGA.kgwdsbyPYraFCzTnGhgMYpoQdzaC(hZAbfEaIVUqgRLyftfHrQszcqiobA);

		public GDRoGgVjDcEWUTGxoyPHXdGnupTP(yMmSTMhQmUMYgBcxEBLrFxPnYVHv P_0)
		{
			wvqqjLpgJjBOUipXnKDUptxhoSQGA = P_0;
			hZAbfEaIVUqgRLyftfHrQszcqiobA = -1;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (hZAbfEaIVUqgRLyftfHrQszcqiobA >= wvqqjLpgJjBOUipXnKDUptxhoSQGA.UrBCeIhKaawIpPYPUCSoRIQLeJQFb - 1)
			{
				return false;
			}
			hZAbfEaIVUqgRLyftfHrQszcqiobA++;
			return true;
		}

		public void Reset()
		{
			hZAbfEaIVUqgRLyftfHrQszcqiobA = 0;
		}
	}

	private int UrBCeIhKaawIpPYPUCSoRIQLeJQFb;

	private unsafe byte* CAwQSgnEMPQXllGnSidiuDnNgeFBA;

	public int eohFsdVkRvyEdEIhDuGsBlzpfOFx => UrBCeIhKaawIpPYPUCSoRIQLeJQFb;

	public unsafe bool RWcjmtEWOihCnICrbgbyOHewqpcW
	{
		get
		{
			if (UrBCeIhKaawIpPYPUCSoRIQLeJQFb <= 0)
			{
				return true;
			}
			return CAwQSgnEMPQXllGnSidiuDnNgeFBA != null;
		}
	}

	public unsafe byte uwmaNFaseKnqmacVHofPxXyRyWCh
	{
		get
		{
			if (P_0 < 0 || P_0 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
			{
				throw new IndexOutOfRangeException();
			}
			return CAwQSgnEMPQXllGnSidiuDnNgeFBA[P_0];
		}
		set
		{
			if (num < 0 || num >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
			{
				throw new IndexOutOfRangeException();
			}
			CAwQSgnEMPQXllGnSidiuDnNgeFBA[num] = b;
		}
	}

	public yMmSTMhQmUMYgBcxEBLrFxPnYVHv(int P_0)
	{
		PoWuVwNQVuFqVDDyMvfSIHoGGBqj(P_0);
	}

	public unsafe yMmSTMhQmUMYgBcxEBLrFxPnYVHv(params byte[] P_0)
		: this(P_0.Length)
	{
		Marshal.Copy(P_0, 0, (IntPtr)CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0.Length);
	}

	public yMmSTMhQmUMYgBcxEBLrFxPnYVHv(yMmSTMhQmUMYgBcxEBLrFxPnYVHv P_0)
		: this(P_0.UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
	{
		P_0.FGqhXVBebyjeuIECYFFtboOMwbIb(this, 0, P_0.UrBCeIhKaawIpPYPUCSoRIQLeJQFb);
	}

	public unsafe yMmSTMhQmUMYgBcxEBLrFxPnYVHv(byte* P_0, int P_1)
		: this(P_1)
	{
		OLserehNWHIbghIOsZgXEwMqColl.NsKFffFPSKzDQTlXyLHVFzjeGUrUA(P_0, CAwQSgnEMPQXllGnSidiuDnNgeFBA, 0, 0, P_1);
	}

	public unsafe bool FGqhXVBebyjeuIECYFFtboOMwbIb(byte* P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb || P_2 >= P_1)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > UrBCeIhKaawIpPYPUCSoRIQLeJQFb || P_3 > P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_3 + P_2;
		if (num >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb || num >= P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return OLserehNWHIbghIOsZgXEwMqColl.NsKFffFPSKzDQTlXyLHVFzjeGUrUA(CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0, P_2, P_2, P_3);
	}

	public unsafe bool FGqhXVBebyjeuIECYFFtboOMwbIb(yMmSTMhQmUMYgBcxEBLrFxPnYVHv P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return FGqhXVBebyjeuIECYFFtboOMwbIb(P_0.CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0.UrBCeIhKaawIpPYPUCSoRIQLeJQFb, P_1, P_2, P_3);
	}

	public unsafe bool FGqhXVBebyjeuIECYFFtboOMwbIb(byte[] P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb || P_1 >= P_0.Length)
		{
			if (P_3)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 <= 0 || P_2 > UrBCeIhKaawIpPYPUCSoRIQLeJQFb || P_2 > P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_2 + P_1;
		if (num >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb || num >= P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0, P_1, P_1, P_2, P_3);
	}

	public unsafe bool FGqhXVBebyjeuIECYFFtboOMwbIb(byte* P_0, int P_1, int P_2, int P_3, int P_4, bool P_5 = true)
	{
		if (P_0 == null)
		{
			if (P_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
		{
			if (P_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 < 0 || P_3 >= P_1)
		{
			if (P_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_4 <= 0 || P_4 > UrBCeIhKaawIpPYPUCSoRIQLeJQFb || P_4 > P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_4 + P_2 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex + length must be < source.Length");
			}
			return false;
		}
		if (P_4 + P_3 >= P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex + length must be < destination.Length");
			}
			return false;
		}
		return OLserehNWHIbghIOsZgXEwMqColl.NsKFffFPSKzDQTlXyLHVFzjeGUrUA(CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0, P_2, P_3, P_4);
	}

	public unsafe bool FGqhXVBebyjeuIECYFFtboOMwbIb(yMmSTMhQmUMYgBcxEBLrFxPnYVHv P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return FGqhXVBebyjeuIECYFFtboOMwbIb(P_0.CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0.UrBCeIhKaawIpPYPUCSoRIQLeJQFb, P_1, P_2, P_3, P_4);
	}

	public unsafe bool FGqhXVBebyjeuIECYFFtboOMwbIb(byte[] P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= P_0.Length)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > UrBCeIhKaawIpPYPUCSoRIQLeJQFb || P_3 > P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_3 + P_1 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex + length must be < source.Length");
			}
			return false;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex + length must be < destination.Length");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool JWyhooPrBpStFsawhewjbnsMNnlBb(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb || P_2 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		int num = P_3 + P_2;
		if (num >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
		{
			P_3 = UrBCeIhKaawIpPYPUCSoRIQLeJQFb - P_2;
		}
		if (num >= P_1)
		{
			P_3 = P_1 - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return OLserehNWHIbghIOsZgXEwMqColl.NsKFffFPSKzDQTlXyLHVFzjeGUrUA(CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0, P_2, P_2, P_3);
	}

	public unsafe bool JWyhooPrBpStFsawhewjbnsMNnlBb(yMmSTMhQmUMYgBcxEBLrFxPnYVHv P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		return JWyhooPrBpStFsawhewjbnsMNnlBb(P_0.CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0.UrBCeIhKaawIpPYPUCSoRIQLeJQFb, P_1, P_2);
	}

	public unsafe bool JWyhooPrBpStFsawhewjbnsMNnlBb(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb || P_1 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		int num = P_2 + P_1;
		if (num >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
		{
			P_2 = UrBCeIhKaawIpPYPUCSoRIQLeJQFb - P_1;
		}
		if (num >= P_0.Length)
		{
			P_2 = P_0.Length - P_1;
		}
		if (P_2 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0, P_1, P_1, P_2, throwOnError: false);
	}

	public unsafe bool JWyhooPrBpStFsawhewjbnsMNnlBb(byte* P_0, int P_1, int P_2, int P_3, int P_4)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
		{
			return false;
		}
		if (P_3 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 + P_2 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
		{
			P_4 = UrBCeIhKaawIpPYPUCSoRIQLeJQFb - P_2;
		}
		if (P_4 + P_3 >= P_1)
		{
			P_4 = P_1 - P_3;
		}
		if (P_4 <= 0)
		{
			return false;
		}
		return OLserehNWHIbghIOsZgXEwMqColl.NsKFffFPSKzDQTlXyLHVFzjeGUrUA(CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0, P_2, P_3, P_4);
	}

	public unsafe bool JWyhooPrBpStFsawhewjbnsMNnlBb(yMmSTMhQmUMYgBcxEBLrFxPnYVHv P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		return JWyhooPrBpStFsawhewjbnsMNnlBb(P_0.CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0.UrBCeIhKaawIpPYPUCSoRIQLeJQFb, P_1, P_2, P_3);
	}

	public unsafe bool JWyhooPrBpStFsawhewjbnsMNnlBb(byte[] P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
		{
			return false;
		}
		if (P_2 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 + P_1 >= UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
		{
			P_3 = UrBCeIhKaawIpPYPUCSoRIQLeJQFb - P_1;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			P_3 = P_0.Length - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)CAwQSgnEMPQXllGnSidiuDnNgeFBA, P_0, P_1, P_2, P_3, throwOnError: false);
	}

	public void cCjKuDgROonfNLMAfvwwFPJvqRHJ(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("length must be >= 0");
		}
		if (UrBCeIhKaawIpPYPUCSoRIQLeJQFb != P_0)
		{
			PoWuVwNQVuFqVDDyMvfSIHoGGBqj(P_0);
		}
	}

	public unsafe void PNnwosyJbZAkbwObisgdtMytZJol()
	{
		if (UrBCeIhKaawIpPYPUCSoRIQLeJQFb != 0 && CAwQSgnEMPQXllGnSidiuDnNgeFBA != null)
		{
			OLserehNWHIbghIOsZgXEwMqColl.FJjDIrhOqYyHrnbHvbLOaYKUEctM(CAwQSgnEMPQXllGnSidiuDnNgeFBA, UrBCeIhKaawIpPYPUCSoRIQLeJQFb);
		}
	}

	private unsafe void PoWuVwNQVuFqVDDyMvfSIHoGGBqj(int P_0)
	{
		if (P_0 == UrBCeIhKaawIpPYPUCSoRIQLeJQFb)
		{
			PNnwosyJbZAkbwObisgdtMytZJol();
			return;
		}
		if (UrBCeIhKaawIpPYPUCSoRIQLeJQFb > 0)
		{
			CAaBasOtTMEDGEayDzkjtcGwZWCTA();
		}
		CAwQSgnEMPQXllGnSidiuDnNgeFBA = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		if (CAwQSgnEMPQXllGnSidiuDnNgeFBA == null)
		{
			throw new Exception("Could not allocate memory for array.");
		}
		UrBCeIhKaawIpPYPUCSoRIQLeJQFb = P_0;
		PNnwosyJbZAkbwObisgdtMytZJol();
	}

	private unsafe void CAaBasOtTMEDGEayDzkjtcGwZWCTA()
	{
		if (CAwQSgnEMPQXllGnSidiuDnNgeFBA != null)
		{
			Marshal.FreeHGlobal((IntPtr)CAwQSgnEMPQXllGnSidiuDnNgeFBA);
		}
		CAwQSgnEMPQXllGnSidiuDnNgeFBA = null;
		UrBCeIhKaawIpPYPUCSoRIQLeJQFb = 0;
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

	protected void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
	{
		CAaBasOtTMEDGEayDzkjtcGwZWCTA();
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return new GDRoGgVjDcEWUTGxoyPHXdGnupTP(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new GDRoGgVjDcEWUTGxoyPHXdGnupTP(this);
	}
}
