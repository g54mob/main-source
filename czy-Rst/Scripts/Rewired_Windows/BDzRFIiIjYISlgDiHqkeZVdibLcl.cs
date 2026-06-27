using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class BDzRFIiIjYISlgDiHqkeZVdibLcl : IEnumerable<byte>, IEnumerable, IDisposable
{
	private struct tNmEIlAwwkLlHpeAbxMTPmcwNAkS : IEnumerator<byte>, IEnumerator, IDisposable
	{
		private BDzRFIiIjYISlgDiHqkeZVdibLcl iELzuKTJzbmiuFQymPMpEXKPQaVE;

		private int TiHGubxvuGqQGzfESUewXYMRGXUK;

		byte IEnumerator<byte>.Current => iELzuKTJzbmiuFQymPMpEXKPQaVE.eUrNHahLkyYHsYpILnfOccEyzblP(TiHGubxvuGqQGzfESUewXYMRGXUK);

		object IEnumerator.Current => iELzuKTJzbmiuFQymPMpEXKPQaVE.eUrNHahLkyYHsYpILnfOccEyzblP(TiHGubxvuGqQGzfESUewXYMRGXUK);

		public tNmEIlAwwkLlHpeAbxMTPmcwNAkS(BDzRFIiIjYISlgDiHqkeZVdibLcl P_0)
		{
			iELzuKTJzbmiuFQymPMpEXKPQaVE = P_0;
			TiHGubxvuGqQGzfESUewXYMRGXUK = -1;
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
			if (TiHGubxvuGqQGzfESUewXYMRGXUK >= iELzuKTJzbmiuFQymPMpEXKPQaVE.IdakiikSDiMlPUINYBmnGvrrtvSEA - 1)
			{
				return false;
			}
			TiHGubxvuGqQGzfESUewXYMRGXUK++;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		public void Reset()
		{
			TiHGubxvuGqQGzfESUewXYMRGXUK = 0;
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Reset
			this.Reset();
		}
	}

	private int IdakiikSDiMlPUINYBmnGvrrtvSEA;

	private unsafe byte* ygJSVEUjeXdGeJAysKQNANEgrOTgc;

	public int jWmXfOffweZNePFHoNhMqmrofCvh => IdakiikSDiMlPUINYBmnGvrrtvSEA;

	public unsafe bool JiebMfwldSugxVEgIRsaMmpjVTrh
	{
		get
		{
			if (IdakiikSDiMlPUINYBmnGvrrtvSEA <= 0)
			{
				return true;
			}
			return ygJSVEUjeXdGeJAysKQNANEgrOTgc != null;
		}
	}

	public unsafe byte thiWmiBbObffGDkGqCvRIDxyHxCm
	{
		get
		{
			if (P_0 < 0 || P_0 >= IdakiikSDiMlPUINYBmnGvrrtvSEA)
			{
				throw new IndexOutOfRangeException();
			}
			return ygJSVEUjeXdGeJAysKQNANEgrOTgc[P_0];
		}
		set
		{
			if (num < 0 || num >= IdakiikSDiMlPUINYBmnGvrrtvSEA)
			{
				throw new IndexOutOfRangeException();
			}
			ygJSVEUjeXdGeJAysKQNANEgrOTgc[num] = b;
		}
	}

	public BDzRFIiIjYISlgDiHqkeZVdibLcl(int P_0)
	{
		JMATOvcFQzFQKBtvldlZVanvIjsDA(P_0);
	}

	public unsafe BDzRFIiIjYISlgDiHqkeZVdibLcl(params byte[] P_0)
		: this(P_0.Length)
	{
		Marshal.Copy(P_0, 0, (IntPtr)ygJSVEUjeXdGeJAysKQNANEgrOTgc, P_0.Length);
	}

	public BDzRFIiIjYISlgDiHqkeZVdibLcl(BDzRFIiIjYISlgDiHqkeZVdibLcl P_0)
		: this(P_0.IdakiikSDiMlPUINYBmnGvrrtvSEA)
	{
		P_0.eDnjnRGAVaqWbjBWDyUfLUjbtXdfA(this, 0, P_0.IdakiikSDiMlPUINYBmnGvrrtvSEA);
	}

	public unsafe BDzRFIiIjYISlgDiHqkeZVdibLcl(byte* P_0, int P_1)
		: this(P_1)
	{
		IPpGxGoGPNwPwoVzosbzleQVdbB.OGuTaHYPqVjisIEoZDZQGoxjHDJcb(P_0, ygJSVEUjeXdGeJAysKQNANEgrOTgc, 0, 0, P_1);
	}

	public unsafe bool IqwobFlZlgVtgqrZBuCJBCULDJas(byte* P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= IdakiikSDiMlPUINYBmnGvrrtvSEA || P_2 >= P_1)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > IdakiikSDiMlPUINYBmnGvrrtvSEA || P_3 > P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_3 + P_2;
		if (num >= IdakiikSDiMlPUINYBmnGvrrtvSEA || num >= P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return IPpGxGoGPNwPwoVzosbzleQVdbB.OGuTaHYPqVjisIEoZDZQGoxjHDJcb(ygJSVEUjeXdGeJAysKQNANEgrOTgc, P_0, P_2, P_2, P_3);
	}

	public unsafe bool eDnjnRGAVaqWbjBWDyUfLUjbtXdfA(BDzRFIiIjYISlgDiHqkeZVdibLcl P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return IqwobFlZlgVtgqrZBuCJBCULDJas(P_0.ygJSVEUjeXdGeJAysKQNANEgrOTgc, P_0.IdakiikSDiMlPUINYBmnGvrrtvSEA, P_1, P_2, P_3);
	}

	public unsafe bool tqSDdfeStdiuLeYxFRiUYIerMRQob(byte[] P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= IdakiikSDiMlPUINYBmnGvrrtvSEA || P_1 >= P_0.Length)
		{
			if (P_3)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 <= 0 || P_2 > IdakiikSDiMlPUINYBmnGvrrtvSEA || P_2 > P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_2 + P_1;
		if (num >= IdakiikSDiMlPUINYBmnGvrrtvSEA || num >= P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)ygJSVEUjeXdGeJAysKQNANEgrOTgc, P_0, P_1, P_1, P_2, P_3);
	}

	public unsafe bool CznRoaHKcoTqmEYUMtxmAzxJjBsU(byte* P_0, int P_1, int P_2, int P_3, int P_4, bool P_5 = true)
	{
		if (P_0 == null)
		{
			if (P_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= IdakiikSDiMlPUINYBmnGvrrtvSEA)
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
		if (P_4 <= 0 || P_4 > IdakiikSDiMlPUINYBmnGvrrtvSEA || P_4 > P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_4 + P_2 >= IdakiikSDiMlPUINYBmnGvrrtvSEA)
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
		return IPpGxGoGPNwPwoVzosbzleQVdbB.OGuTaHYPqVjisIEoZDZQGoxjHDJcb(ygJSVEUjeXdGeJAysKQNANEgrOTgc, P_0, P_2, P_3, P_4);
	}

	public unsafe bool oekAsZjFxOinsDqjVWreJwXHEnEAA(BDzRFIiIjYISlgDiHqkeZVdibLcl P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return CznRoaHKcoTqmEYUMtxmAzxJjBsU(P_0.ygJSVEUjeXdGeJAysKQNANEgrOTgc, P_0.IdakiikSDiMlPUINYBmnGvrrtvSEA, P_1, P_2, P_3, P_4);
	}

	public unsafe bool DOkaALgqzsUUoFBbBcdThYKBkNwQA(byte[] P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= IdakiikSDiMlPUINYBmnGvrrtvSEA)
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
		if (P_3 <= 0 || P_3 > IdakiikSDiMlPUINYBmnGvrrtvSEA || P_3 > P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_3 + P_1 >= IdakiikSDiMlPUINYBmnGvrrtvSEA)
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
		return NativeTools.CopyMemory((IntPtr)ygJSVEUjeXdGeJAysKQNANEgrOTgc, P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool iGWepElEUyClyCAcNkDEapiDiGxnc(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= IdakiikSDiMlPUINYBmnGvrrtvSEA || P_2 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		int num = P_3 + P_2;
		if (num >= IdakiikSDiMlPUINYBmnGvrrtvSEA)
		{
			P_3 = IdakiikSDiMlPUINYBmnGvrrtvSEA - P_2;
		}
		if (num >= P_1)
		{
			P_3 = P_1 - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return IPpGxGoGPNwPwoVzosbzleQVdbB.OGuTaHYPqVjisIEoZDZQGoxjHDJcb(ygJSVEUjeXdGeJAysKQNANEgrOTgc, P_0, P_2, P_2, P_3);
	}

	public unsafe bool wOEzgffKkmPMOAioDjSnulcWoBCS(BDzRFIiIjYISlgDiHqkeZVdibLcl P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		return iGWepElEUyClyCAcNkDEapiDiGxnc(P_0.ygJSVEUjeXdGeJAysKQNANEgrOTgc, P_0.IdakiikSDiMlPUINYBmnGvrrtvSEA, P_1, P_2);
	}

	public unsafe bool BUJgXXipHjXZgTVjASFoonNdMOjZA(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= IdakiikSDiMlPUINYBmnGvrrtvSEA || P_1 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		int num = P_2 + P_1;
		if (num >= IdakiikSDiMlPUINYBmnGvrrtvSEA)
		{
			P_2 = IdakiikSDiMlPUINYBmnGvrrtvSEA - P_1;
		}
		if (num >= P_0.Length)
		{
			P_2 = P_0.Length - P_1;
		}
		if (P_2 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)ygJSVEUjeXdGeJAysKQNANEgrOTgc, P_0, P_1, P_1, P_2, throwOnError: false);
	}

	public unsafe bool SGBfpWVjhALEXbuUkEIpJjGFNlhe(byte* P_0, int P_1, int P_2, int P_3, int P_4)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= IdakiikSDiMlPUINYBmnGvrrtvSEA)
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
		if (P_4 + P_2 >= IdakiikSDiMlPUINYBmnGvrrtvSEA)
		{
			P_4 = IdakiikSDiMlPUINYBmnGvrrtvSEA - P_2;
		}
		if (P_4 + P_3 >= P_1)
		{
			P_4 = P_1 - P_3;
		}
		if (P_4 <= 0)
		{
			return false;
		}
		return IPpGxGoGPNwPwoVzosbzleQVdbB.OGuTaHYPqVjisIEoZDZQGoxjHDJcb(ygJSVEUjeXdGeJAysKQNANEgrOTgc, P_0, P_2, P_3, P_4);
	}

	public unsafe bool huqtrvCZGcoEelbNIBufOcQMyYxU(BDzRFIiIjYISlgDiHqkeZVdibLcl P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		return SGBfpWVjhALEXbuUkEIpJjGFNlhe(P_0.ygJSVEUjeXdGeJAysKQNANEgrOTgc, P_0.IdakiikSDiMlPUINYBmnGvrrtvSEA, P_1, P_2, P_3);
	}

	public unsafe bool wXrbzCdeDVXfaMtSsDjZHMOdsbOMB(byte[] P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= IdakiikSDiMlPUINYBmnGvrrtvSEA)
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
		if (P_3 + P_1 >= IdakiikSDiMlPUINYBmnGvrrtvSEA)
		{
			P_3 = IdakiikSDiMlPUINYBmnGvrrtvSEA - P_1;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			P_3 = P_0.Length - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)ygJSVEUjeXdGeJAysKQNANEgrOTgc, P_0, P_1, P_2, P_3, throwOnError: false);
	}

	public void QdnYoCXlnGDqoFppSRFuFiQEPzSVA(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("length must be >= 0");
		}
		if (IdakiikSDiMlPUINYBmnGvrrtvSEA != P_0)
		{
			JMATOvcFQzFQKBtvldlZVanvIjsDA(P_0);
		}
	}

	public unsafe void IFkmuZPNbZJFlGEErCshYaJXxgpf()
	{
		if (IdakiikSDiMlPUINYBmnGvrrtvSEA != 0 && ygJSVEUjeXdGeJAysKQNANEgrOTgc != null)
		{
			IPpGxGoGPNwPwoVzosbzleQVdbB.lLrZFPAbPDJHtUcGzegsjYKhiovqA(ygJSVEUjeXdGeJAysKQNANEgrOTgc, IdakiikSDiMlPUINYBmnGvrrtvSEA);
		}
	}

	private unsafe void JMATOvcFQzFQKBtvldlZVanvIjsDA(int P_0)
	{
		if (P_0 == IdakiikSDiMlPUINYBmnGvrrtvSEA)
		{
			IFkmuZPNbZJFlGEErCshYaJXxgpf();
			return;
		}
		if (IdakiikSDiMlPUINYBmnGvrrtvSEA > 0)
		{
			BoauBKPliDdKTpfOzmykCggDKSYV();
		}
		ygJSVEUjeXdGeJAysKQNANEgrOTgc = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		if (ygJSVEUjeXdGeJAysKQNANEgrOTgc == null)
		{
			throw new Exception("Could not allocate memory for array.");
		}
		IdakiikSDiMlPUINYBmnGvrrtvSEA = P_0;
		IFkmuZPNbZJFlGEErCshYaJXxgpf();
	}

	private unsafe void BoauBKPliDdKTpfOzmykCggDKSYV()
	{
		if (ygJSVEUjeXdGeJAysKQNANEgrOTgc != null)
		{
			Marshal.FreeHGlobal((IntPtr)ygJSVEUjeXdGeJAysKQNANEgrOTgc);
		}
		ygJSVEUjeXdGeJAysKQNANEgrOTgc = null;
		IdakiikSDiMlPUINYBmnGvrrtvSEA = 0;
	}

	public void Dispose()
	{
		TEqEqqPjvAuBrVnhKADyDHFRaMzO(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void QVLZGamYLqtVdPrNrkLVtQOhkoWo()
	{
		try
		{
			TEqEqqPjvAuBrVnhKADyDHFRaMzO(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void TEqEqqPjvAuBrVnhKADyDHFRaMzO(bool P_0)
	{
		BoauBKPliDdKTpfOzmykCggDKSYV();
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return new tNmEIlAwwkLlHpeAbxMTPmcwNAkS(this);
	}

	IEnumerator<byte> IEnumerable<byte>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
		return this.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new tNmEIlAwwkLlHpeAbxMTPmcwNAkS(this);
	}
}
