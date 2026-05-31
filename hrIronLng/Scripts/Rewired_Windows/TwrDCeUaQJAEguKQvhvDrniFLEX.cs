using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal class TwrDCeUaQJAEguKQvhvDrniFLEX : IEnumerable<byte>, IDisposable, IEnumerable
{
	private struct KAEsuWOLwziWCOXIEsoBCWYNZXm : IEnumerator<byte>, IDisposable, IEnumerator
	{
		private TwrDCeUaQJAEguKQvhvDrniFLEX ZEpdjxEVNcOpMKmaOhscBFRDUeM;

		private int YbLhTsnFXFgkJBESYpTNOuLIqPk;

		public byte Current => ZEpdjxEVNcOpMKmaOhscBFRDUeM[YbLhTsnFXFgkJBESYpTNOuLIqPk];

		object IEnumerator.Current => ZEpdjxEVNcOpMKmaOhscBFRDUeM[YbLhTsnFXFgkJBESYpTNOuLIqPk];

		public KAEsuWOLwziWCOXIEsoBCWYNZXm(TwrDCeUaQJAEguKQvhvDrniFLEX array)
		{
			ZEpdjxEVNcOpMKmaOhscBFRDUeM = array;
			YbLhTsnFXFgkJBESYpTNOuLIqPk = -1;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (YbLhTsnFXFgkJBESYpTNOuLIqPk >= ZEpdjxEVNcOpMKmaOhscBFRDUeM.vtIobczDotOpllyixsFUaAwldJS - 1)
			{
				return false;
			}
			YbLhTsnFXFgkJBESYpTNOuLIqPk++;
			return true;
		}

		public void Reset()
		{
			YbLhTsnFXFgkJBESYpTNOuLIqPk = 0;
		}
	}

	private int vtIobczDotOpllyixsFUaAwldJS;

	private unsafe byte* vchQMUGnIIHSpgACjOTIdULpWgNC;

	public int Length => vtIobczDotOpllyixsFUaAwldJS;

	public unsafe bool IsValid
	{
		get
		{
			if (vtIobczDotOpllyixsFUaAwldJS <= 0)
			{
				return true;
			}
			return vchQMUGnIIHSpgACjOTIdULpWgNC != null;
		}
	}

	public unsafe byte this[int index]
	{
		get
		{
			if (index < 0 || index >= vtIobczDotOpllyixsFUaAwldJS)
			{
				throw new IndexOutOfRangeException();
			}
			return vchQMUGnIIHSpgACjOTIdULpWgNC[index];
		}
		set
		{
			if (index < 0 || index >= vtIobczDotOpllyixsFUaAwldJS)
			{
				throw new IndexOutOfRangeException();
			}
			vchQMUGnIIHSpgACjOTIdULpWgNC[index] = value;
		}
	}

	public TwrDCeUaQJAEguKQvhvDrniFLEX(int length)
	{
		eUHeyUyORxWRVoiDvPZqazEckWe(length);
	}

	public unsafe TwrDCeUaQJAEguKQvhvDrniFLEX(params byte[] source)
		: this(source.Length)
	{
		Marshal.Copy(source, 0, (IntPtr)vchQMUGnIIHSpgACjOTIdULpWgNC, source.Length);
	}

	public TwrDCeUaQJAEguKQvhvDrniFLEX(TwrDCeUaQJAEguKQvhvDrniFLEX source)
		: this(source.vtIobczDotOpllyixsFUaAwldJS)
	{
		source.ctjvvtiIwfhzgbadzHvdiDCyUsrT(this, 0, source.vtIobczDotOpllyixsFUaAwldJS);
	}

	public unsafe TwrDCeUaQJAEguKQvhvDrniFLEX(byte* source, int sourceLength)
		: this(sourceLength)
	{
		jrpbiUWSBQEMcGMhBQbhkaeULUlm.esVdJDaUiZZdCOdqRfdjVzLEMDz(source, vchQMUGnIIHSpgACjOTIdULpWgNC, 0, 0, sourceLength);
	}

	public unsafe bool ctjvvtiIwfhzgbadzHvdiDCyUsrT(byte* P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= vtIobczDotOpllyixsFUaAwldJS || P_2 >= P_1)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > vtIobczDotOpllyixsFUaAwldJS || P_3 > P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_3 + P_2;
		if (num >= vtIobczDotOpllyixsFUaAwldJS || num >= P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return jrpbiUWSBQEMcGMhBQbhkaeULUlm.esVdJDaUiZZdCOdqRfdjVzLEMDz(vchQMUGnIIHSpgACjOTIdULpWgNC, P_0, P_2, P_2, P_3);
	}

	public unsafe bool ctjvvtiIwfhzgbadzHvdiDCyUsrT(TwrDCeUaQJAEguKQvhvDrniFLEX P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return ctjvvtiIwfhzgbadzHvdiDCyUsrT(P_0.vchQMUGnIIHSpgACjOTIdULpWgNC, P_0.vtIobczDotOpllyixsFUaAwldJS, P_1, P_2, P_3);
	}

	public unsafe bool ctjvvtiIwfhzgbadzHvdiDCyUsrT(byte[] P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= vtIobczDotOpllyixsFUaAwldJS || P_1 >= P_0.Length)
		{
			if (P_3)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 <= 0 || P_2 > vtIobczDotOpllyixsFUaAwldJS || P_2 > P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_2 + P_1;
		if (num >= vtIobczDotOpllyixsFUaAwldJS || num >= P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)vchQMUGnIIHSpgACjOTIdULpWgNC, P_0, P_1, P_1, P_2, P_3);
	}

	public unsafe bool ctjvvtiIwfhzgbadzHvdiDCyUsrT(byte* P_0, int P_1, int P_2, int P_3, int P_4, bool P_5 = true)
	{
		if (P_0 == null)
		{
			if (P_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= vtIobczDotOpllyixsFUaAwldJS)
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
		if (P_4 <= 0 || P_4 > vtIobczDotOpllyixsFUaAwldJS || P_4 > P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_4 + P_2 >= vtIobczDotOpllyixsFUaAwldJS)
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
		return jrpbiUWSBQEMcGMhBQbhkaeULUlm.esVdJDaUiZZdCOdqRfdjVzLEMDz(vchQMUGnIIHSpgACjOTIdULpWgNC, P_0, P_2, P_3, P_4);
	}

	public unsafe bool ctjvvtiIwfhzgbadzHvdiDCyUsrT(TwrDCeUaQJAEguKQvhvDrniFLEX P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return ctjvvtiIwfhzgbadzHvdiDCyUsrT(P_0.vchQMUGnIIHSpgACjOTIdULpWgNC, P_0.vtIobczDotOpllyixsFUaAwldJS, P_1, P_2, P_3, P_4);
	}

	public unsafe bool ctjvvtiIwfhzgbadzHvdiDCyUsrT(byte[] P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= vtIobczDotOpllyixsFUaAwldJS)
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
		if (P_3 <= 0 || P_3 > vtIobczDotOpllyixsFUaAwldJS || P_3 > P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_3 + P_1 >= vtIobczDotOpllyixsFUaAwldJS)
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
		return NativeTools.CopyMemory((IntPtr)vchQMUGnIIHSpgACjOTIdULpWgNC, P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool aOzoQYmSHspMHVoFOEfBLEYehsx(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= vtIobczDotOpllyixsFUaAwldJS || P_2 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		int num = P_3 + P_2;
		if (num >= vtIobczDotOpllyixsFUaAwldJS)
		{
			P_3 = vtIobczDotOpllyixsFUaAwldJS - P_2;
		}
		if (num >= P_1)
		{
			P_3 = P_1 - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return jrpbiUWSBQEMcGMhBQbhkaeULUlm.esVdJDaUiZZdCOdqRfdjVzLEMDz(vchQMUGnIIHSpgACjOTIdULpWgNC, P_0, P_2, P_2, P_3);
	}

	public unsafe bool aOzoQYmSHspMHVoFOEfBLEYehsx(TwrDCeUaQJAEguKQvhvDrniFLEX P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		return aOzoQYmSHspMHVoFOEfBLEYehsx(P_0.vchQMUGnIIHSpgACjOTIdULpWgNC, P_0.vtIobczDotOpllyixsFUaAwldJS, P_1, P_2);
	}

	public unsafe bool aOzoQYmSHspMHVoFOEfBLEYehsx(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= vtIobczDotOpllyixsFUaAwldJS || P_1 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		int num = P_2 + P_1;
		if (num >= vtIobczDotOpllyixsFUaAwldJS)
		{
			P_2 = vtIobczDotOpllyixsFUaAwldJS - P_1;
		}
		if (num >= P_0.Length)
		{
			P_2 = P_0.Length - P_1;
		}
		if (P_2 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)vchQMUGnIIHSpgACjOTIdULpWgNC, P_0, P_1, P_1, P_2, throwOnError: false);
	}

	public unsafe bool aOzoQYmSHspMHVoFOEfBLEYehsx(byte* P_0, int P_1, int P_2, int P_3, int P_4)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= vtIobczDotOpllyixsFUaAwldJS)
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
		if (P_4 + P_2 >= vtIobczDotOpllyixsFUaAwldJS)
		{
			P_4 = vtIobczDotOpllyixsFUaAwldJS - P_2;
		}
		if (P_4 + P_3 >= P_1)
		{
			P_4 = P_1 - P_3;
		}
		if (P_4 <= 0)
		{
			return false;
		}
		return jrpbiUWSBQEMcGMhBQbhkaeULUlm.esVdJDaUiZZdCOdqRfdjVzLEMDz(vchQMUGnIIHSpgACjOTIdULpWgNC, P_0, P_2, P_3, P_4);
	}

	public unsafe bool aOzoQYmSHspMHVoFOEfBLEYehsx(TwrDCeUaQJAEguKQvhvDrniFLEX P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		return aOzoQYmSHspMHVoFOEfBLEYehsx(P_0.vchQMUGnIIHSpgACjOTIdULpWgNC, P_0.vtIobczDotOpllyixsFUaAwldJS, P_1, P_2, P_3);
	}

	public unsafe bool aOzoQYmSHspMHVoFOEfBLEYehsx(byte[] P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= vtIobczDotOpllyixsFUaAwldJS)
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
		if (P_3 + P_1 >= vtIobczDotOpllyixsFUaAwldJS)
		{
			P_3 = vtIobczDotOpllyixsFUaAwldJS - P_1;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			P_3 = P_0.Length - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)vchQMUGnIIHSpgACjOTIdULpWgNC, P_0, P_1, P_2, P_3, throwOnError: false);
	}

	public void RjqJMpDJGfDpTKkpEeJAjxfFqoVz(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("length must be >= 0");
		}
		if (vtIobczDotOpllyixsFUaAwldJS != P_0)
		{
			eUHeyUyORxWRVoiDvPZqazEckWe(P_0);
		}
	}

	public unsafe void avkcOhFlGGeHrNSdTQlLZUnJDbw()
	{
		if (vtIobczDotOpllyixsFUaAwldJS != 0 && vchQMUGnIIHSpgACjOTIdULpWgNC != null)
		{
			jrpbiUWSBQEMcGMhBQbhkaeULUlm.mRuGPTMmoPyrhOguOAfkSRsaMuj(vchQMUGnIIHSpgACjOTIdULpWgNC, vtIobczDotOpllyixsFUaAwldJS);
		}
	}

	private unsafe void eUHeyUyORxWRVoiDvPZqazEckWe(int P_0)
	{
		if (P_0 == vtIobczDotOpllyixsFUaAwldJS)
		{
			avkcOhFlGGeHrNSdTQlLZUnJDbw();
			return;
		}
		if (vtIobczDotOpllyixsFUaAwldJS > 0)
		{
			ntpyYfYZDZaEJHVwEFPKHmOQQI();
		}
		vchQMUGnIIHSpgACjOTIdULpWgNC = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		if (vchQMUGnIIHSpgACjOTIdULpWgNC == null)
		{
			throw new Exception("Could not allocate memory for array.");
		}
		vtIobczDotOpllyixsFUaAwldJS = P_0;
		avkcOhFlGGeHrNSdTQlLZUnJDbw();
	}

	private unsafe void ntpyYfYZDZaEJHVwEFPKHmOQQI()
	{
		if (vchQMUGnIIHSpgACjOTIdULpWgNC != null)
		{
			Marshal.FreeHGlobal((IntPtr)vchQMUGnIIHSpgACjOTIdULpWgNC);
		}
		vchQMUGnIIHSpgACjOTIdULpWgNC = null;
		vtIobczDotOpllyixsFUaAwldJS = 0;
	}

	public void Dispose()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~TwrDCeUaQJAEguKQvhvDrniFLEX()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		ntpyYfYZDZaEJHVwEFPKHmOQQI();
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return new KAEsuWOLwziWCOXIEsoBCWYNZXm(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new KAEsuWOLwziWCOXIEsoBCWYNZXm(this);
	}
}
