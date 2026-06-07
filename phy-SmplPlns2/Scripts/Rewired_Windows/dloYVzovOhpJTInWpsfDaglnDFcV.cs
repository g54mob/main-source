using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct dloYVzovOhpJTInWpsfDaglnDFcV
{
	private int XgLnpXEYlnoLgFBgGdRcxkYUXpuy;

	private const int EKSaMMBKTsLqRaljGMHchnxEvWrrA = 65534;

	private const int dvTDsmYwIYdNUAxCGgPelXfLfthbA = 16776960;

	public ZmXltWbhqdfqHdQeeybxZILIjOaj FISdKDwGlUgdCydNnzZTSNmsChCo => (ZmXltWbhqdfqHdQeeybxZILIjOaj)(XgLnpXEYlnoLgFBgGdRcxkYUXpuy & -16776961);

	public int PDtLxAPTSYnLgAoFqhidKJthcbKfA => (XgLnpXEYlnoLgFBgGdRcxkYUXpuy >> 8) & 0xFFFF;

	public dloYVzovOhpJTInWpsfDaglnDFcV(ZmXltWbhqdfqHdQeeybxZILIjOaj P_0, int P_1)
	{
		this = default(dloYVzovOhpJTInWpsfDaglnDFcV);
		XgLnpXEYlnoLgFBgGdRcxkYUXpuy = (int)(P_0 & ~ZmXltWbhqdfqHdQeeybxZILIjOaj.AnyInstance) | ((!(P_1 < 0 || P_1 > 65534)) ? ((P_1 & 0xFFFF) << 8) : 0);
	}

	[SpecialName]
	public static int NLGihHkWvjrUAHJfbebyuTNqBtpI(dloYVzovOhpJTInWpsfDaglnDFcV P_0)
	{
		return P_0.XgLnpXEYlnoLgFBgGdRcxkYUXpuy;
	}

	public bool PCzBmgdfquvLDqTxmkSugfJGksqbB(dloYVzovOhpJTInWpsfDaglnDFcV P_0)
	{
		return P_0.XgLnpXEYlnoLgFBgGdRcxkYUXpuy == XgLnpXEYlnoLgFBgGdRcxkYUXpuy;
	}

	public bool VdXOEfWitllQazXjmNCEhoOejWrg(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(dloYVzovOhpJTInWpsfDaglnDFcV))
		{
			return false;
		}
		return PCzBmgdfquvLDqTxmkSugfJGksqbB((dloYVzovOhpJTInWpsfDaglnDFcV)P_0);
	}

	public int RQnwRaaeXVwjvjmErMtrGZxrJzHp()
	{
		return XgLnpXEYlnoLgFBgGdRcxkYUXpuy;
	}

	public string RhIlcAeHxGKYkwxnwYmQoJOwRtSh()
	{
		return string.Format(CultureInfo.InvariantCulture, "Flags: {0} InstanceNumber: {1} RawId: 0x{2:X8}", FISdKDwGlUgdCydNnzZTSNmsChCo, PDtLxAPTSYnLgAoFqhidKJthcbKfA, XgLnpXEYlnoLgFBgGdRcxkYUXpuy);
	}
}
