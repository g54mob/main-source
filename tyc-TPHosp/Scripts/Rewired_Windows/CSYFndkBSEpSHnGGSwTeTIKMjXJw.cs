using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal class CSYFndkBSEpSHnGGSwTeTIKMjXJw : IEnumerable<byte>, IDisposable, IEnumerable
{
	private struct XvSdTTkHXxPmXWtBbRCibuCHophB : IEnumerator<byte>, IDisposable, IEnumerator
	{
		private CSYFndkBSEpSHnGGSwTeTIKMjXJw MqWENqHMzruOtwrmnDsNoyyWGJK;

		private int RUivDbwSxCosmplAljLeCbaDSmaq;

		public byte Current => MqWENqHMzruOtwrmnDsNoyyWGJK[RUivDbwSxCosmplAljLeCbaDSmaq];

		object IEnumerator.Current => MqWENqHMzruOtwrmnDsNoyyWGJK[RUivDbwSxCosmplAljLeCbaDSmaq];

		public XvSdTTkHXxPmXWtBbRCibuCHophB(CSYFndkBSEpSHnGGSwTeTIKMjXJw array)
		{
			MqWENqHMzruOtwrmnDsNoyyWGJK = array;
			RUivDbwSxCosmplAljLeCbaDSmaq = -1;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (RUivDbwSxCosmplAljLeCbaDSmaq >= MqWENqHMzruOtwrmnDsNoyyWGJK.qHbYWrgTCguIMVDkMGGdBRJkMDQd - 1)
			{
				return false;
			}
			RUivDbwSxCosmplAljLeCbaDSmaq++;
			return true;
		}

		public void Reset()
		{
			RUivDbwSxCosmplAljLeCbaDSmaq = 0;
		}
	}

	private int qHbYWrgTCguIMVDkMGGdBRJkMDQd;

	private unsafe byte* qQYuLTZsgJCxImVGAnRthYmmwjT;

	public int Length => qHbYWrgTCguIMVDkMGGdBRJkMDQd;

	public unsafe bool IsValid
	{
		get
		{
			if (qHbYWrgTCguIMVDkMGGdBRJkMDQd <= 0)
			{
				return true;
			}
			return qQYuLTZsgJCxImVGAnRthYmmwjT != null;
		}
	}

	public unsafe byte this[int index]
	{
		get
		{
			if (index < 0 || index >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
			{
				throw new IndexOutOfRangeException();
			}
			return qQYuLTZsgJCxImVGAnRthYmmwjT[index];
		}
		set
		{
			if (index < 0 || index >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
			{
				throw new IndexOutOfRangeException();
			}
			qQYuLTZsgJCxImVGAnRthYmmwjT[index] = value;
		}
	}

	public CSYFndkBSEpSHnGGSwTeTIKMjXJw(int length)
	{
		zkwAQVnfzqfJaCfPOplLVkfflWk(length);
	}

	public unsafe CSYFndkBSEpSHnGGSwTeTIKMjXJw(params byte[] source)
		: this(source.Length)
	{
		Marshal.Copy(source, 0, (IntPtr)qQYuLTZsgJCxImVGAnRthYmmwjT, source.Length);
	}

	public CSYFndkBSEpSHnGGSwTeTIKMjXJw(CSYFndkBSEpSHnGGSwTeTIKMjXJw source)
		: this(source.qHbYWrgTCguIMVDkMGGdBRJkMDQd)
	{
		source.ryMNHgtDQgtiTLPrKNZKuPzxuYp(this, 0, source.qHbYWrgTCguIMVDkMGGdBRJkMDQd);
	}

	public unsafe CSYFndkBSEpSHnGGSwTeTIKMjXJw(byte* source, int sourceLength)
		: this(sourceLength)
	{
		oCGEXVhAHCOVsdbcLXOHRPRMXp.jMquLSbqoOKLzeBecvZYwYcJcSl(source, qQYuLTZsgJCxImVGAnRthYmmwjT, 0, 0, sourceLength);
	}

	public unsafe bool ryMNHgtDQgtiTLPrKNZKuPzxuYp(byte* P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd || P_2 >= P_1)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > qHbYWrgTCguIMVDkMGGdBRJkMDQd || P_3 > P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_3 + P_2;
		if (num >= qHbYWrgTCguIMVDkMGGdBRJkMDQd || num >= P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return oCGEXVhAHCOVsdbcLXOHRPRMXp.jMquLSbqoOKLzeBecvZYwYcJcSl(qQYuLTZsgJCxImVGAnRthYmmwjT, P_0, P_2, P_2, P_3);
	}

	public unsafe bool ryMNHgtDQgtiTLPrKNZKuPzxuYp(CSYFndkBSEpSHnGGSwTeTIKMjXJw P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return ryMNHgtDQgtiTLPrKNZKuPzxuYp(P_0.qQYuLTZsgJCxImVGAnRthYmmwjT, P_0.qHbYWrgTCguIMVDkMGGdBRJkMDQd, P_1, P_2, P_3);
	}

	public unsafe bool ryMNHgtDQgtiTLPrKNZKuPzxuYp(byte[] P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd || P_1 >= P_0.Length)
		{
			if (P_3)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 <= 0 || P_2 > qHbYWrgTCguIMVDkMGGdBRJkMDQd || P_2 > P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_2 + P_1;
		if (num >= qHbYWrgTCguIMVDkMGGdBRJkMDQd || num >= P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)qQYuLTZsgJCxImVGAnRthYmmwjT, P_0, P_1, P_1, P_2, P_3);
	}

	public unsafe bool ryMNHgtDQgtiTLPrKNZKuPzxuYp(byte* P_0, int P_1, int P_2, int P_3, int P_4, bool P_5 = true)
	{
		if (P_0 == null)
		{
			if (P_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
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
		if (P_4 <= 0 || P_4 > qHbYWrgTCguIMVDkMGGdBRJkMDQd || P_4 > P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_4 + P_2 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
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
		return oCGEXVhAHCOVsdbcLXOHRPRMXp.jMquLSbqoOKLzeBecvZYwYcJcSl(qQYuLTZsgJCxImVGAnRthYmmwjT, P_0, P_2, P_3, P_4);
	}

	public unsafe bool ryMNHgtDQgtiTLPrKNZKuPzxuYp(CSYFndkBSEpSHnGGSwTeTIKMjXJw P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return ryMNHgtDQgtiTLPrKNZKuPzxuYp(P_0.qQYuLTZsgJCxImVGAnRthYmmwjT, P_0.qHbYWrgTCguIMVDkMGGdBRJkMDQd, P_1, P_2, P_3, P_4);
	}

	public unsafe bool ryMNHgtDQgtiTLPrKNZKuPzxuYp(byte[] P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
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
		if (P_3 <= 0 || P_3 > qHbYWrgTCguIMVDkMGGdBRJkMDQd || P_3 > P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_3 + P_1 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
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
		return NativeTools.CopyMemory((IntPtr)qQYuLTZsgJCxImVGAnRthYmmwjT, P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool vgWNKLrnljXrgbtRxkmawFjpHxfF(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd || P_2 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		int num = P_3 + P_2;
		if (num >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
		{
			P_3 = qHbYWrgTCguIMVDkMGGdBRJkMDQd - P_2;
		}
		if (num >= P_1)
		{
			P_3 = P_1 - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return oCGEXVhAHCOVsdbcLXOHRPRMXp.jMquLSbqoOKLzeBecvZYwYcJcSl(qQYuLTZsgJCxImVGAnRthYmmwjT, P_0, P_2, P_2, P_3);
	}

	public unsafe bool vgWNKLrnljXrgbtRxkmawFjpHxfF(CSYFndkBSEpSHnGGSwTeTIKMjXJw P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		return vgWNKLrnljXrgbtRxkmawFjpHxfF(P_0.qQYuLTZsgJCxImVGAnRthYmmwjT, P_0.qHbYWrgTCguIMVDkMGGdBRJkMDQd, P_1, P_2);
	}

	public unsafe bool vgWNKLrnljXrgbtRxkmawFjpHxfF(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd || P_1 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		int num = P_2 + P_1;
		if (num >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
		{
			P_2 = qHbYWrgTCguIMVDkMGGdBRJkMDQd - P_1;
		}
		if (num >= P_0.Length)
		{
			P_2 = P_0.Length - P_1;
		}
		if (P_2 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)qQYuLTZsgJCxImVGAnRthYmmwjT, P_0, P_1, P_1, P_2, throwOnError: false);
	}

	public unsafe bool vgWNKLrnljXrgbtRxkmawFjpHxfF(byte* P_0, int P_1, int P_2, int P_3, int P_4)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
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
		if (P_4 + P_2 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
		{
			P_4 = qHbYWrgTCguIMVDkMGGdBRJkMDQd - P_2;
		}
		if (P_4 + P_3 >= P_1)
		{
			P_4 = P_1 - P_3;
		}
		if (P_4 <= 0)
		{
			return false;
		}
		return oCGEXVhAHCOVsdbcLXOHRPRMXp.jMquLSbqoOKLzeBecvZYwYcJcSl(qQYuLTZsgJCxImVGAnRthYmmwjT, P_0, P_2, P_3, P_4);
	}

	public unsafe bool vgWNKLrnljXrgbtRxkmawFjpHxfF(CSYFndkBSEpSHnGGSwTeTIKMjXJw P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		return vgWNKLrnljXrgbtRxkmawFjpHxfF(P_0.qQYuLTZsgJCxImVGAnRthYmmwjT, P_0.qHbYWrgTCguIMVDkMGGdBRJkMDQd, P_1, P_2, P_3);
	}

	public unsafe bool vgWNKLrnljXrgbtRxkmawFjpHxfF(byte[] P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
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
		if (P_3 + P_1 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
		{
			P_3 = qHbYWrgTCguIMVDkMGGdBRJkMDQd - P_1;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			P_3 = P_0.Length - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)qQYuLTZsgJCxImVGAnRthYmmwjT, P_0, P_1, P_2, P_3, throwOnError: false);
	}

	public void OzBqWySwcghOwQUvdbhpKDAOcuF(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("length must be >= 0");
		}
		if (qHbYWrgTCguIMVDkMGGdBRJkMDQd != P_0)
		{
			zkwAQVnfzqfJaCfPOplLVkfflWk(P_0);
		}
	}

	public unsafe void rKJfCRBWFLQsKCjGykmcumzKLPwE()
	{
		if (qHbYWrgTCguIMVDkMGGdBRJkMDQd != 0 && qQYuLTZsgJCxImVGAnRthYmmwjT != null)
		{
			oCGEXVhAHCOVsdbcLXOHRPRMXp.zbXcjYVUEMeyWwienlZHtNPzsup(qQYuLTZsgJCxImVGAnRthYmmwjT, qHbYWrgTCguIMVDkMGGdBRJkMDQd);
		}
	}

	private unsafe void zkwAQVnfzqfJaCfPOplLVkfflWk(int P_0)
	{
		if (P_0 == qHbYWrgTCguIMVDkMGGdBRJkMDQd)
		{
			rKJfCRBWFLQsKCjGykmcumzKLPwE();
			return;
		}
		if (qHbYWrgTCguIMVDkMGGdBRJkMDQd > 0)
		{
			qWYZYRwVrMbVhvKZXuaonpXVTIE();
		}
		qQYuLTZsgJCxImVGAnRthYmmwjT = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		if (qQYuLTZsgJCxImVGAnRthYmmwjT == null)
		{
			throw new Exception("Could not allocate memory for array.");
		}
		qHbYWrgTCguIMVDkMGGdBRJkMDQd = P_0;
		rKJfCRBWFLQsKCjGykmcumzKLPwE();
	}

	private unsafe void qWYZYRwVrMbVhvKZXuaonpXVTIE()
	{
		if (qQYuLTZsgJCxImVGAnRthYmmwjT != null)
		{
			Marshal.FreeHGlobal((IntPtr)qQYuLTZsgJCxImVGAnRthYmmwjT);
		}
		qQYuLTZsgJCxImVGAnRthYmmwjT = null;
		qHbYWrgTCguIMVDkMGGdBRJkMDQd = 0;
	}

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~CSYFndkBSEpSHnGGSwTeTIKMjXJw()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	protected void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		qWYZYRwVrMbVhvKZXuaonpXVTIE();
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return new XvSdTTkHXxPmXWtBbRCibuCHophB(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new XvSdTTkHXxPmXWtBbRCibuCHophB(this);
	}
}
