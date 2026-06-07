using System;
using System.Runtime.CompilerServices;

internal struct fTdetHoZcdRUbkTwkogFXUoufns : IEquatable<fTdetHoZcdRUbkTwkogFXUoufns>
{
	public IntPtr gpRRWpNgaNJmzGbrEaNwChwYyxtY;

	public bool LOAKUriHGZEbByAroDTyQAHhOjqU => gpRRWpNgaNJmzGbrEaNwChwYyxtY != IntPtr.Zero;

	public fTdetHoZcdRUbkTwkogFXUoufns(IntPtr P_0)
	{
		gpRRWpNgaNJmzGbrEaNwChwYyxtY = P_0;
	}

	public fTdetHoZcdRUbkTwkogFXUoufns(AMdAgCritGErRioCrkbrBpbFGYbUA P_0)
	{
		gpRRWpNgaNJmzGbrEaNwChwYyxtY = P_0.SfodONvYhDkCOPbxNxfznmGnoyyQ;
	}

	public void hldVlmZiYtOAMBUhZgNvxGgZETbs()
	{
		if (!(gpRRWpNgaNJmzGbrEaNwChwYyxtY == IntPtr.Zero))
		{
			lgYKhAZykBItMBLqoSTMmewCDmYI.IHzBOdMalmXDaoDeeDFutVrkTlGn(gpRRWpNgaNJmzGbrEaNwChwYyxtY);
			gpRRWpNgaNJmzGbrEaNwChwYyxtY = IntPtr.Zero;
		}
	}

	[SpecialName]
	public static IntPtr bPhBTDiXwPSGeHgqUdzKHurTqKRxA(fTdetHoZcdRUbkTwkogFXUoufns P_0)
	{
		return P_0.gpRRWpNgaNJmzGbrEaNwChwYyxtY;
	}

	public bool JRxBWnhQlwwPGktFTDexAbegXFrzB(object P_0)
	{
		if (!(P_0 is fTdetHoZcdRUbkTwkogFXUoufns))
		{
			return false;
		}
		return ((fTdetHoZcdRUbkTwkogFXUoufns)P_0).gpRRWpNgaNJmzGbrEaNwChwYyxtY == gpRRWpNgaNJmzGbrEaNwChwYyxtY;
	}

	public int fEwcDhFDzGumYFCZRxsMimpbheAt()
	{
		return GetHashCode();
	}

	public bool Equals(fTdetHoZcdRUbkTwkogFXUoufns other)
	{
		return gpRRWpNgaNJmzGbrEaNwChwYyxtY == other.gpRRWpNgaNJmzGbrEaNwChwYyxtY;
	}

	[SpecialName]
	public static bool KnRQEmwHYQnLlhpqQiYLhcNhPfug(fTdetHoZcdRUbkTwkogFXUoufns P_0, fTdetHoZcdRUbkTwkogFXUoufns P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool aVrCGbDxOYyGJCHKjqMUEaQwsGZeb(fTdetHoZcdRUbkTwkogFXUoufns P_0, fTdetHoZcdRUbkTwkogFXUoufns P_1)
	{
		return !P_0.Equals(P_1);
	}
}
