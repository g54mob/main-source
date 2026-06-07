using System;
using System.Runtime.InteropServices;

internal struct zkecjMAmkFhnnXucLpohHMNQgFWI
{
	private IntPtr mbrZOyeYrEAEkmkkheNxrAJDQDO;

	private int RcHNottKUOdzaggbpxokYlghORj;

	private IntPtr xfoqUkciakrORRACXDGNEkvPGqFQ;

	private IntPtr lhZcbujiDXhQnBnMiVftnbdQaWSg;

	private IntPtr UPQobslazaQoVUMKaJUfoVttqtA;

	public IntPtr HWnd
	{
		get
		{
			return mbrZOyeYrEAEkmkkheNxrAJDQDO;
		}
		set
		{
			mbrZOyeYrEAEkmkkheNxrAJDQDO = value;
		}
	}

	public int Msg
	{
		get
		{
			return RcHNottKUOdzaggbpxokYlghORj;
		}
		set
		{
			RcHNottKUOdzaggbpxokYlghORj = value;
		}
	}

	public IntPtr WParam
	{
		get
		{
			return xfoqUkciakrORRACXDGNEkvPGqFQ;
		}
		set
		{
			xfoqUkciakrORRACXDGNEkvPGqFQ = value;
		}
	}

	public IntPtr LParam
	{
		get
		{
			return lhZcbujiDXhQnBnMiVftnbdQaWSg;
		}
		set
		{
			lhZcbujiDXhQnBnMiVftnbdQaWSg = value;
		}
	}

	public IntPtr Result
	{
		get
		{
			return UPQobslazaQoVUMKaJUfoVttqtA;
		}
		set
		{
			UPQobslazaQoVUMKaJUfoVttqtA = value;
		}
	}

	public object omRHYvkhWQJIKeKLNzjJrPgLSUo(Type P_0)
	{
		return Marshal.PtrToStructure(lhZcbujiDXhQnBnMiVftnbdQaWSg, P_0);
	}

	public static zkecjMAmkFhnnXucLpohHMNQgFWI QGMHznQHkHQnTPTBloqkWdrurHv(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3)
	{
		return new zkecjMAmkFhnnXucLpohHMNQgFWI
		{
			mbrZOyeYrEAEkmkkheNxrAJDQDO = P_0,
			RcHNottKUOdzaggbpxokYlghORj = P_1,
			xfoqUkciakrORRACXDGNEkvPGqFQ = P_2,
			lhZcbujiDXhQnBnMiVftnbdQaWSg = P_3,
			UPQobslazaQoVUMKaJUfoVttqtA = IntPtr.Zero
		};
	}

	public override bool Equals(object o)
	{
		if (!(o is zkecjMAmkFhnnXucLpohHMNQgFWI))
		{
			return false;
		}
		zkecjMAmkFhnnXucLpohHMNQgFWI zkecjMAmkFhnnXucLpohHMNQgFWI2 = (zkecjMAmkFhnnXucLpohHMNQgFWI)o;
		if (mbrZOyeYrEAEkmkkheNxrAJDQDO == zkecjMAmkFhnnXucLpohHMNQgFWI2.mbrZOyeYrEAEkmkkheNxrAJDQDO && RcHNottKUOdzaggbpxokYlghORj == zkecjMAmkFhnnXucLpohHMNQgFWI2.RcHNottKUOdzaggbpxokYlghORj && xfoqUkciakrORRACXDGNEkvPGqFQ == zkecjMAmkFhnnXucLpohHMNQgFWI2.xfoqUkciakrORRACXDGNEkvPGqFQ && lhZcbujiDXhQnBnMiVftnbdQaWSg == zkecjMAmkFhnnXucLpohHMNQgFWI2.lhZcbujiDXhQnBnMiVftnbdQaWSg)
		{
			return UPQobslazaQoVUMKaJUfoVttqtA == zkecjMAmkFhnnXucLpohHMNQgFWI2.UPQobslazaQoVUMKaJUfoVttqtA;
		}
		return false;
	}

	public static bool operator !=(zkecjMAmkFhnnXucLpohHMNQgFWI a, zkecjMAmkFhnnXucLpohHMNQgFWI b)
	{
		return !a.Equals(b);
	}

	public static bool operator ==(zkecjMAmkFhnnXucLpohHMNQgFWI a, zkecjMAmkFhnnXucLpohHMNQgFWI b)
	{
		return a.Equals(b);
	}

	public override int GetHashCode()
	{
		return ((int)mbrZOyeYrEAEkmkkheNxrAJDQDO << 4) | RcHNottKUOdzaggbpxokYlghORj;
	}

	public override string ToString()
	{
		return string.Empty;
	}
}
