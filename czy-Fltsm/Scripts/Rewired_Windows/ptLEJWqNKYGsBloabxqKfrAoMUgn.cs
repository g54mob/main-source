using System;
using System.Runtime.CompilerServices;

internal struct ptLEJWqNKYGsBloabxqKfrAoMUgn : IEquatable<ptLEJWqNKYGsBloabxqKfrAoMUgn>
{
	public IntPtr IjFwUCwhTVEzsfqrNMwYeEhZlxaH;

	public bool XswVhxUAOPikJowiTXELsplpsiwP => IjFwUCwhTVEzsfqrNMwYeEhZlxaH != IntPtr.Zero;

	public ptLEJWqNKYGsBloabxqKfrAoMUgn(IntPtr P_0)
	{
		IjFwUCwhTVEzsfqrNMwYeEhZlxaH = P_0;
	}

	public ptLEJWqNKYGsBloabxqKfrAoMUgn(YEddRxIQmgTYEowryWdPAJlNvhwRA P_0)
	{
		IjFwUCwhTVEzsfqrNMwYeEhZlxaH = P_0.yINGamblibFxfaelkmgDTpWGVRqM;
	}

	public void vFuHGivmniALoFFZgGVLtrkClKKQ()
	{
		if (!(IjFwUCwhTVEzsfqrNMwYeEhZlxaH == IntPtr.Zero))
		{
			tsCBxloSjtavBHHVzKUqIGsQvsPTA.fIEeMPaEGMGCGddFfswIVwaMRpKnB(IjFwUCwhTVEzsfqrNMwYeEhZlxaH);
			IjFwUCwhTVEzsfqrNMwYeEhZlxaH = IntPtr.Zero;
		}
	}

	[SpecialName]
	public static IntPtr UjjASFShffxbnKNsywDaWCubBiVD(ptLEJWqNKYGsBloabxqKfrAoMUgn P_0)
	{
		return P_0.IjFwUCwhTVEzsfqrNMwYeEhZlxaH;
	}

	public bool AfdCSJPLQsfdpixySNPqWjDabbCeb(object P_0)
	{
		if (!(P_0 is ptLEJWqNKYGsBloabxqKfrAoMUgn))
		{
			return false;
		}
		return ((ptLEJWqNKYGsBloabxqKfrAoMUgn)P_0).IjFwUCwhTVEzsfqrNMwYeEhZlxaH == IjFwUCwhTVEzsfqrNMwYeEhZlxaH;
	}

	public int anCDBefiQDzzBAqqxmrMXGlLSWPGA()
	{
		return GetHashCode();
	}

	public bool Equals(ptLEJWqNKYGsBloabxqKfrAoMUgn other)
	{
		return IjFwUCwhTVEzsfqrNMwYeEhZlxaH == other.IjFwUCwhTVEzsfqrNMwYeEhZlxaH;
	}

	bool IEquatable<ptLEJWqNKYGsBloabxqKfrAoMUgn>.Equals(ptLEJWqNKYGsBloabxqKfrAoMUgn other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	[SpecialName]
	public static bool QfIffuSpTqAqCgpeEIbhJtujazqH(ptLEJWqNKYGsBloabxqKfrAoMUgn P_0, ptLEJWqNKYGsBloabxqKfrAoMUgn P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool rDFzULGJemRAnWeUEGzfCbecNZaO(ptLEJWqNKYGsBloabxqKfrAoMUgn P_0, ptLEJWqNKYGsBloabxqKfrAoMUgn P_1)
	{
		return !P_0.Equals(P_1);
	}
}
