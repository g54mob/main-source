using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class MDgQJXaPDREXzdAgoXYjRupaRrCv : IEnumerable<byte>, IEnumerable, IDisposable
{
	private struct eonCKeQUqvwlVwGgMyjYVbemAuWF : IEnumerator<byte>, IEnumerator, IDisposable
	{
		private MDgQJXaPDREXzdAgoXYjRupaRrCv fCOSpTPFxoMteWsKPvpmSVZZuYtr;

		private int WsWmqahIZHDEKsGrlUzkVAhNCqFc;

		byte IEnumerator<byte>.Current => fCOSpTPFxoMteWsKPvpmSVZZuYtr.vNuZdjtKwtGEsTEIiDuNoTMkdwRg(WsWmqahIZHDEKsGrlUzkVAhNCqFc);

		object IEnumerator.Current => fCOSpTPFxoMteWsKPvpmSVZZuYtr.vNuZdjtKwtGEsTEIiDuNoTMkdwRg(WsWmqahIZHDEKsGrlUzkVAhNCqFc);

		public eonCKeQUqvwlVwGgMyjYVbemAuWF(MDgQJXaPDREXzdAgoXYjRupaRrCv P_0)
		{
			fCOSpTPFxoMteWsKPvpmSVZZuYtr = P_0;
			WsWmqahIZHDEKsGrlUzkVAhNCqFc = -1;
		}

		public void Dispose()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		public bool MoveNext()
		{
			if (WsWmqahIZHDEKsGrlUzkVAhNCqFc >= fCOSpTPFxoMteWsKPvpmSVZZuYtr.ZcvatluldXmTdFFGvAyOvhDbrCgD - 1)
			{
				return false;
			}
			WsWmqahIZHDEKsGrlUzkVAhNCqFc++;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		public void Reset()
		{
			WsWmqahIZHDEKsGrlUzkVAhNCqFc = 0;
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Reset
			this.Reset();
		}
	}

	private int ZcvatluldXmTdFFGvAyOvhDbrCgD;

	private unsafe byte* dYQRAJMyGQJPcPbiNkkWZmCdBOjM;

	public int qLfoDNrfIvNKsWVHHlfNchbeytDT => ZcvatluldXmTdFFGvAyOvhDbrCgD;

	public unsafe bool AzrrxwmdHRIpdHUufGnvZArzmJLY
	{
		get
		{
			if (ZcvatluldXmTdFFGvAyOvhDbrCgD <= 0)
			{
				return true;
			}
			return dYQRAJMyGQJPcPbiNkkWZmCdBOjM != null;
		}
	}

	public unsafe byte cypEOrXSgaJcQDGUJzgMhGbipNmDA
	{
		get
		{
			if (P_0 < 0 || P_0 >= ZcvatluldXmTdFFGvAyOvhDbrCgD)
			{
				throw new IndexOutOfRangeException();
			}
			return dYQRAJMyGQJPcPbiNkkWZmCdBOjM[P_0];
		}
		set
		{
			if (num < 0 || num >= ZcvatluldXmTdFFGvAyOvhDbrCgD)
			{
				throw new IndexOutOfRangeException();
			}
			dYQRAJMyGQJPcPbiNkkWZmCdBOjM[num] = b;
		}
	}

	public MDgQJXaPDREXzdAgoXYjRupaRrCv(int P_0)
	{
		MSTfNcakgsURYdEnYTRSTJttMbGGb(P_0);
	}

	public unsafe MDgQJXaPDREXzdAgoXYjRupaRrCv(params byte[] P_0)
		: this(P_0.Length)
	{
		Marshal.Copy(P_0, 0, (IntPtr)dYQRAJMyGQJPcPbiNkkWZmCdBOjM, P_0.Length);
	}

	public MDgQJXaPDREXzdAgoXYjRupaRrCv(MDgQJXaPDREXzdAgoXYjRupaRrCv P_0)
		: this(P_0.ZcvatluldXmTdFFGvAyOvhDbrCgD)
	{
		P_0.ddkplCWxldRLxYkGgwJmMbnrDJNU(this, 0, P_0.ZcvatluldXmTdFFGvAyOvhDbrCgD);
	}

	public unsafe MDgQJXaPDREXzdAgoXYjRupaRrCv(byte* P_0, int P_1)
		: this(P_1)
	{
		TbAntJIfSSmAyfyyGIMdtrdGaNBT.NyfaVQAUWOlhoNLqqrnFuAjfaNfr(P_0, dYQRAJMyGQJPcPbiNkkWZmCdBOjM, 0, 0, P_1);
	}

	public unsafe bool DStSgQjtDpwKyxNDogEAaFKVDHMbb(byte* P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= ZcvatluldXmTdFFGvAyOvhDbrCgD || P_2 >= P_1)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > ZcvatluldXmTdFFGvAyOvhDbrCgD || P_3 > P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_3 + P_2;
		if (num >= ZcvatluldXmTdFFGvAyOvhDbrCgD || num >= P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return TbAntJIfSSmAyfyyGIMdtrdGaNBT.NyfaVQAUWOlhoNLqqrnFuAjfaNfr(dYQRAJMyGQJPcPbiNkkWZmCdBOjM, P_0, P_2, P_2, P_3);
	}

	public unsafe bool ddkplCWxldRLxYkGgwJmMbnrDJNU(MDgQJXaPDREXzdAgoXYjRupaRrCv P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return DStSgQjtDpwKyxNDogEAaFKVDHMbb(P_0.dYQRAJMyGQJPcPbiNkkWZmCdBOjM, P_0.ZcvatluldXmTdFFGvAyOvhDbrCgD, P_1, P_2, P_3);
	}

	public unsafe bool yTLttaUdRoAdVJqrieIJACmAtFebA(byte[] P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= ZcvatluldXmTdFFGvAyOvhDbrCgD || P_1 >= P_0.Length)
		{
			if (P_3)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 <= 0 || P_2 > ZcvatluldXmTdFFGvAyOvhDbrCgD || P_2 > P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_2 + P_1;
		if (num >= ZcvatluldXmTdFFGvAyOvhDbrCgD || num >= P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)dYQRAJMyGQJPcPbiNkkWZmCdBOjM, P_0, P_1, P_1, P_2, P_3);
	}

	public unsafe bool LiecPhZYNtnkmVWEzFpfCtlNLrOD(byte* P_0, int P_1, int P_2, int P_3, int P_4, bool P_5 = true)
	{
		if (P_0 == null)
		{
			if (P_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= ZcvatluldXmTdFFGvAyOvhDbrCgD)
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
		if (P_4 <= 0 || P_4 > ZcvatluldXmTdFFGvAyOvhDbrCgD || P_4 > P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_4 + P_2 >= ZcvatluldXmTdFFGvAyOvhDbrCgD)
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
		return TbAntJIfSSmAyfyyGIMdtrdGaNBT.NyfaVQAUWOlhoNLqqrnFuAjfaNfr(dYQRAJMyGQJPcPbiNkkWZmCdBOjM, P_0, P_2, P_3, P_4);
	}

	public unsafe bool bEziEODmBZaiirljyHzhBFTHjPyH(MDgQJXaPDREXzdAgoXYjRupaRrCv P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return LiecPhZYNtnkmVWEzFpfCtlNLrOD(P_0.dYQRAJMyGQJPcPbiNkkWZmCdBOjM, P_0.ZcvatluldXmTdFFGvAyOvhDbrCgD, P_1, P_2, P_3, P_4);
	}

	public unsafe bool KVdCMWhkNzXFoTUfqkXMTGYDmZOEA(byte[] P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= ZcvatluldXmTdFFGvAyOvhDbrCgD)
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
		if (P_3 <= 0 || P_3 > ZcvatluldXmTdFFGvAyOvhDbrCgD || P_3 > P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_3 + P_1 >= ZcvatluldXmTdFFGvAyOvhDbrCgD)
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
		return NativeTools.CopyMemory((IntPtr)dYQRAJMyGQJPcPbiNkkWZmCdBOjM, P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool paVtuNzqwtqlsNomajCVhoriYYHd(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= ZcvatluldXmTdFFGvAyOvhDbrCgD || P_2 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		int num = P_3 + P_2;
		if (num >= ZcvatluldXmTdFFGvAyOvhDbrCgD)
		{
			P_3 = ZcvatluldXmTdFFGvAyOvhDbrCgD - P_2;
		}
		if (num >= P_1)
		{
			P_3 = P_1 - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return TbAntJIfSSmAyfyyGIMdtrdGaNBT.NyfaVQAUWOlhoNLqqrnFuAjfaNfr(dYQRAJMyGQJPcPbiNkkWZmCdBOjM, P_0, P_2, P_2, P_3);
	}

	public unsafe bool dOXNfmzAIbeAYaHmuOkcJeoWFZuyA(MDgQJXaPDREXzdAgoXYjRupaRrCv P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		return paVtuNzqwtqlsNomajCVhoriYYHd(P_0.dYQRAJMyGQJPcPbiNkkWZmCdBOjM, P_0.ZcvatluldXmTdFFGvAyOvhDbrCgD, P_1, P_2);
	}

	public unsafe bool CrEDIIbGxcQieQGxvDzzzkLzJYZJ(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= ZcvatluldXmTdFFGvAyOvhDbrCgD || P_1 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		int num = P_2 + P_1;
		if (num >= ZcvatluldXmTdFFGvAyOvhDbrCgD)
		{
			P_2 = ZcvatluldXmTdFFGvAyOvhDbrCgD - P_1;
		}
		if (num >= P_0.Length)
		{
			P_2 = P_0.Length - P_1;
		}
		if (P_2 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)dYQRAJMyGQJPcPbiNkkWZmCdBOjM, P_0, P_1, P_1, P_2, throwOnError: false);
	}

	public unsafe bool HWQRdNRkTVZYZkwuFkReRAtHAFLn(byte* P_0, int P_1, int P_2, int P_3, int P_4)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= ZcvatluldXmTdFFGvAyOvhDbrCgD)
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
		if (P_4 + P_2 >= ZcvatluldXmTdFFGvAyOvhDbrCgD)
		{
			P_4 = ZcvatluldXmTdFFGvAyOvhDbrCgD - P_2;
		}
		if (P_4 + P_3 >= P_1)
		{
			P_4 = P_1 - P_3;
		}
		if (P_4 <= 0)
		{
			return false;
		}
		return TbAntJIfSSmAyfyyGIMdtrdGaNBT.NyfaVQAUWOlhoNLqqrnFuAjfaNfr(dYQRAJMyGQJPcPbiNkkWZmCdBOjM, P_0, P_2, P_3, P_4);
	}

	public unsafe bool wrhDpoSWqbghicmJlhEmGYKEGGVfc(MDgQJXaPDREXzdAgoXYjRupaRrCv P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		return HWQRdNRkTVZYZkwuFkReRAtHAFLn(P_0.dYQRAJMyGQJPcPbiNkkWZmCdBOjM, P_0.ZcvatluldXmTdFFGvAyOvhDbrCgD, P_1, P_2, P_3);
	}

	public unsafe bool rmwbbJyqzGiRquDIVfRUMkCgtjur(byte[] P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= ZcvatluldXmTdFFGvAyOvhDbrCgD)
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
		if (P_3 + P_1 >= ZcvatluldXmTdFFGvAyOvhDbrCgD)
		{
			P_3 = ZcvatluldXmTdFFGvAyOvhDbrCgD - P_1;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			P_3 = P_0.Length - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)dYQRAJMyGQJPcPbiNkkWZmCdBOjM, P_0, P_1, P_2, P_3, throwOnError: false);
	}

	public void ZauihJXmPFtSuufffhbfuuCOGpcN(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("length must be >= 0");
		}
		if (ZcvatluldXmTdFFGvAyOvhDbrCgD != P_0)
		{
			MSTfNcakgsURYdEnYTRSTJttMbGGb(P_0);
		}
	}

	public unsafe void RCpSaQLUnKuCpHYICwwgCskJNtPt()
	{
		if (ZcvatluldXmTdFFGvAyOvhDbrCgD != 0 && dYQRAJMyGQJPcPbiNkkWZmCdBOjM != null)
		{
			TbAntJIfSSmAyfyyGIMdtrdGaNBT.oZggRQgOfULUnGHOdGGtmCQIzwaVe(dYQRAJMyGQJPcPbiNkkWZmCdBOjM, ZcvatluldXmTdFFGvAyOvhDbrCgD);
		}
	}

	private unsafe void MSTfNcakgsURYdEnYTRSTJttMbGGb(int P_0)
	{
		if (P_0 == ZcvatluldXmTdFFGvAyOvhDbrCgD)
		{
			RCpSaQLUnKuCpHYICwwgCskJNtPt();
			return;
		}
		if (ZcvatluldXmTdFFGvAyOvhDbrCgD > 0)
		{
			WVpBVVTpUWZOHckIYYBzCSgZMuiH();
		}
		dYQRAJMyGQJPcPbiNkkWZmCdBOjM = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		if (dYQRAJMyGQJPcPbiNkkWZmCdBOjM == null)
		{
			throw new Exception("Could not allocate memory for array.");
		}
		ZcvatluldXmTdFFGvAyOvhDbrCgD = P_0;
		RCpSaQLUnKuCpHYICwwgCskJNtPt();
	}

	private unsafe void WVpBVVTpUWZOHckIYYBzCSgZMuiH()
	{
		if (dYQRAJMyGQJPcPbiNkkWZmCdBOjM != null)
		{
			Marshal.FreeHGlobal((IntPtr)dYQRAJMyGQJPcPbiNkkWZmCdBOjM);
		}
		dYQRAJMyGQJPcPbiNkkWZmCdBOjM = null;
		ZcvatluldXmTdFFGvAyOvhDbrCgD = 0;
	}

	public void Dispose()
	{
		SVbqAjTVhXATpWterxtdHPRDMEJE(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void FJWcSvuTbvUOfEBPSRxEteKrtemM()
	{
		try
		{
			SVbqAjTVhXATpWterxtdHPRDMEJE(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void SVbqAjTVhXATpWterxtdHPRDMEJE(bool P_0)
	{
		WVpBVVTpUWZOHckIYYBzCSgZMuiH();
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return new eonCKeQUqvwlVwGgMyjYVbemAuWF(this);
	}

	IEnumerator<byte> IEnumerable<byte>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
		return this.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new eonCKeQUqvwlVwGgMyjYVbemAuWF(this);
	}
}
