using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal class HpWGIHVkYuQGrUmOfeQuhZiBOSu : IEnumerable<byte>, IDisposable, IEnumerable
{
	private struct NEaUZsWgqIXQXsdJrCmhEtrEmuW : IEnumerator<byte>, IDisposable, IEnumerator
	{
		private HpWGIHVkYuQGrUmOfeQuhZiBOSu VLpcsTDyDvnMyypMfSktLlfshRLg;

		private int WHNefGskPEeMbzxyrcfSYHxphMn;

		public byte Current => VLpcsTDyDvnMyypMfSktLlfshRLg[WHNefGskPEeMbzxyrcfSYHxphMn];

		object IEnumerator.Current => VLpcsTDyDvnMyypMfSktLlfshRLg[WHNefGskPEeMbzxyrcfSYHxphMn];

		public NEaUZsWgqIXQXsdJrCmhEtrEmuW(HpWGIHVkYuQGrUmOfeQuhZiBOSu array)
		{
			VLpcsTDyDvnMyypMfSktLlfshRLg = array;
			WHNefGskPEeMbzxyrcfSYHxphMn = -1;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (WHNefGskPEeMbzxyrcfSYHxphMn >= VLpcsTDyDvnMyypMfSktLlfshRLg.tZUnOAwcHyObLXQsSrSXeWYWQaD - 1)
			{
				return false;
			}
			WHNefGskPEeMbzxyrcfSYHxphMn++;
			return true;
		}

		public void Reset()
		{
			WHNefGskPEeMbzxyrcfSYHxphMn = 0;
		}
	}

	private int tZUnOAwcHyObLXQsSrSXeWYWQaD;

	private unsafe byte* tIxoTeFDQZYEDabsYWCNYmpEcjU;

	public int Length => tZUnOAwcHyObLXQsSrSXeWYWQaD;

	public unsafe bool IsValid
	{
		get
		{
			if (tZUnOAwcHyObLXQsSrSXeWYWQaD <= 0)
			{
				return true;
			}
			return tIxoTeFDQZYEDabsYWCNYmpEcjU != null;
		}
	}

	public unsafe byte this[int index]
	{
		get
		{
			if (index < 0 || index >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
			{
				throw new IndexOutOfRangeException();
			}
			return tIxoTeFDQZYEDabsYWCNYmpEcjU[index];
		}
		set
		{
			if (index < 0 || index >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
			{
				throw new IndexOutOfRangeException();
			}
			tIxoTeFDQZYEDabsYWCNYmpEcjU[index] = value;
		}
	}

	public HpWGIHVkYuQGrUmOfeQuhZiBOSu(int length)
	{
		aBXKlqdeXmyNlMpjIGSxjikZDLlO(length);
	}

	public unsafe HpWGIHVkYuQGrUmOfeQuhZiBOSu(params byte[] source)
		: this(source.Length)
	{
		Marshal.Copy(source, 0, (IntPtr)tIxoTeFDQZYEDabsYWCNYmpEcjU, source.Length);
	}

	public HpWGIHVkYuQGrUmOfeQuhZiBOSu(HpWGIHVkYuQGrUmOfeQuhZiBOSu source)
		: this(source.tZUnOAwcHyObLXQsSrSXeWYWQaD)
	{
		source.aZbSaXpneabjMFSLOmquREaDnzu(this, 0, source.tZUnOAwcHyObLXQsSrSXeWYWQaD);
	}

	public unsafe HpWGIHVkYuQGrUmOfeQuhZiBOSu(byte* source, int sourceLength)
		: this(sourceLength)
	{
		vyfgviDXVLbCEkuBsyiiCaQjLPmW.qzVukddgYEFywyhAwohqPAzjNic(source, tIxoTeFDQZYEDabsYWCNYmpEcjU, 0, 0, sourceLength);
	}

	public unsafe bool aZbSaXpneabjMFSLOmquREaDnzu(byte* P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= tZUnOAwcHyObLXQsSrSXeWYWQaD || P_2 >= P_1)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > tZUnOAwcHyObLXQsSrSXeWYWQaD || P_3 > P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_3 + P_2;
		if (num >= tZUnOAwcHyObLXQsSrSXeWYWQaD || num >= P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return vyfgviDXVLbCEkuBsyiiCaQjLPmW.qzVukddgYEFywyhAwohqPAzjNic(tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0, P_2, P_2, P_3);
	}

	public unsafe bool aZbSaXpneabjMFSLOmquREaDnzu(HpWGIHVkYuQGrUmOfeQuhZiBOSu P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return aZbSaXpneabjMFSLOmquREaDnzu(P_0.tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0.tZUnOAwcHyObLXQsSrSXeWYWQaD, P_1, P_2, P_3);
	}

	public unsafe bool aZbSaXpneabjMFSLOmquREaDnzu(byte[] P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= tZUnOAwcHyObLXQsSrSXeWYWQaD || P_1 >= P_0.Length)
		{
			if (P_3)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 <= 0 || P_2 > tZUnOAwcHyObLXQsSrSXeWYWQaD || P_2 > P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_2 + P_1;
		if (num >= tZUnOAwcHyObLXQsSrSXeWYWQaD || num >= P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0, P_1, P_1, P_2, P_3);
	}

	public unsafe bool aZbSaXpneabjMFSLOmquREaDnzu(byte* P_0, int P_1, int P_2, int P_3, int P_4, bool P_5 = true)
	{
		if (P_0 == null)
		{
			if (P_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
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
		if (P_4 <= 0 || P_4 > tZUnOAwcHyObLXQsSrSXeWYWQaD || P_4 > P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_4 + P_2 >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
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
		return vyfgviDXVLbCEkuBsyiiCaQjLPmW.qzVukddgYEFywyhAwohqPAzjNic(tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0, P_2, P_3, P_4);
	}

	public unsafe bool aZbSaXpneabjMFSLOmquREaDnzu(HpWGIHVkYuQGrUmOfeQuhZiBOSu P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return aZbSaXpneabjMFSLOmquREaDnzu(P_0.tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0.tZUnOAwcHyObLXQsSrSXeWYWQaD, P_1, P_2, P_3, P_4);
	}

	public unsafe bool aZbSaXpneabjMFSLOmquREaDnzu(byte[] P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
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
		if (P_3 <= 0 || P_3 > tZUnOAwcHyObLXQsSrSXeWYWQaD || P_3 > P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_3 + P_1 >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
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
		return NativeTools.CopyMemory((IntPtr)tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool cinzdypcLxiltnPhdnTOZzqHlmi(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= tZUnOAwcHyObLXQsSrSXeWYWQaD || P_2 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		int num = P_3 + P_2;
		if (num >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
		{
			P_3 = tZUnOAwcHyObLXQsSrSXeWYWQaD - P_2;
		}
		if (num >= P_1)
		{
			P_3 = P_1 - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return vyfgviDXVLbCEkuBsyiiCaQjLPmW.qzVukddgYEFywyhAwohqPAzjNic(tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0, P_2, P_2, P_3);
	}

	public unsafe bool cinzdypcLxiltnPhdnTOZzqHlmi(HpWGIHVkYuQGrUmOfeQuhZiBOSu P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		return cinzdypcLxiltnPhdnTOZzqHlmi(P_0.tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0.tZUnOAwcHyObLXQsSrSXeWYWQaD, P_1, P_2);
	}

	public unsafe bool cinzdypcLxiltnPhdnTOZzqHlmi(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= tZUnOAwcHyObLXQsSrSXeWYWQaD || P_1 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		int num = P_2 + P_1;
		if (num >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
		{
			P_2 = tZUnOAwcHyObLXQsSrSXeWYWQaD - P_1;
		}
		if (num >= P_0.Length)
		{
			P_2 = P_0.Length - P_1;
		}
		if (P_2 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0, P_1, P_1, P_2, throwOnError: false);
	}

	public unsafe bool cinzdypcLxiltnPhdnTOZzqHlmi(byte* P_0, int P_1, int P_2, int P_3, int P_4)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
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
		if (P_4 + P_2 >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
		{
			P_4 = tZUnOAwcHyObLXQsSrSXeWYWQaD - P_2;
		}
		if (P_4 + P_3 >= P_1)
		{
			P_4 = P_1 - P_3;
		}
		if (P_4 <= 0)
		{
			return false;
		}
		return vyfgviDXVLbCEkuBsyiiCaQjLPmW.qzVukddgYEFywyhAwohqPAzjNic(tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0, P_2, P_3, P_4);
	}

	public unsafe bool cinzdypcLxiltnPhdnTOZzqHlmi(HpWGIHVkYuQGrUmOfeQuhZiBOSu P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		return cinzdypcLxiltnPhdnTOZzqHlmi(P_0.tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0.tZUnOAwcHyObLXQsSrSXeWYWQaD, P_1, P_2, P_3);
	}

	public unsafe bool cinzdypcLxiltnPhdnTOZzqHlmi(byte[] P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
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
		if (P_3 + P_1 >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
		{
			P_3 = tZUnOAwcHyObLXQsSrSXeWYWQaD - P_1;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			P_3 = P_0.Length - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)tIxoTeFDQZYEDabsYWCNYmpEcjU, P_0, P_1, P_2, P_3, throwOnError: false);
	}

	public void PPkHTNAsCiNvnCMJzlWHndDevhO(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("length must be >= 0");
		}
		if (tZUnOAwcHyObLXQsSrSXeWYWQaD != P_0)
		{
			aBXKlqdeXmyNlMpjIGSxjikZDLlO(P_0);
		}
	}

	public unsafe void ibajyEOvcZaAVvqbaVIEPkwcIqx()
	{
		if (tZUnOAwcHyObLXQsSrSXeWYWQaD != 0 && tIxoTeFDQZYEDabsYWCNYmpEcjU != null)
		{
			vyfgviDXVLbCEkuBsyiiCaQjLPmW.kyyeCfFkgWJaJsXOxIgdYqEZXby(tIxoTeFDQZYEDabsYWCNYmpEcjU, tZUnOAwcHyObLXQsSrSXeWYWQaD);
		}
	}

	private unsafe void aBXKlqdeXmyNlMpjIGSxjikZDLlO(int P_0)
	{
		if (P_0 == tZUnOAwcHyObLXQsSrSXeWYWQaD)
		{
			ibajyEOvcZaAVvqbaVIEPkwcIqx();
			return;
		}
		if (tZUnOAwcHyObLXQsSrSXeWYWQaD > 0)
		{
			jpntIwyRqOZgcppDTZsQOSGnJjP();
		}
		tIxoTeFDQZYEDabsYWCNYmpEcjU = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		if (tIxoTeFDQZYEDabsYWCNYmpEcjU == null)
		{
			throw new Exception("Could not allocate memory for array.");
		}
		tZUnOAwcHyObLXQsSrSXeWYWQaD = P_0;
		ibajyEOvcZaAVvqbaVIEPkwcIqx();
	}

	private unsafe void jpntIwyRqOZgcppDTZsQOSGnJjP()
	{
		if (tIxoTeFDQZYEDabsYWCNYmpEcjU != null)
		{
			Marshal.FreeHGlobal((IntPtr)tIxoTeFDQZYEDabsYWCNYmpEcjU);
		}
		tIxoTeFDQZYEDabsYWCNYmpEcjU = null;
		tZUnOAwcHyObLXQsSrSXeWYWQaD = 0;
	}

	public void Dispose()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~HpWGIHVkYuQGrUmOfeQuhZiBOSu()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	protected void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		jpntIwyRqOZgcppDTZsQOSGnJjP();
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return new NEaUZsWgqIXQXsdJrCmhEtrEmuW(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new NEaUZsWgqIXQXsdJrCmhEtrEmuW(this);
	}
}
