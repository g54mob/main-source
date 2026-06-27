using System;
using System.Runtime.CompilerServices;

internal struct NjwImPuVlIWyUgfMDRGuJasMBDyg
{
	private uint NwEPmJWbRnBijvzDGDGMeNtZiilU;

	private ulong zYzYXAbpWdijBXMmOhnMFknelxgDb;

	private static readonly bool qdAkcjCKLthOgJIvATzEajhvzwKtA;

	public static readonly int WBTyJRCGsvpFjMeqowrNBUyHKGSB;

	static NjwImPuVlIWyUgfMDRGuJasMBDyg()
	{
		qdAkcjCKLthOgJIvATzEajhvzwKtA = IntPtr.Size == 8;
		WBTyJRCGsvpFjMeqowrNBUyHKGSB = (qdAkcjCKLthOgJIvATzEajhvzwKtA ? 8 : 4);
	}

	public static NjwImPuVlIWyUgfMDRGuJasMBDyg mRyBkaQMuHNataQsQRpiQgCeoqlA(byte[] P_0, int P_1)
	{
		NjwImPuVlIWyUgfMDRGuJasMBDyg result = default(NjwImPuVlIWyUgfMDRGuJasMBDyg);
		if (qdAkcjCKLthOgJIvATzEajhvzwKtA)
		{
			result.zYzYXAbpWdijBXMmOhnMFknelxgDb = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.NwEPmJWbRnBijvzDGDGMeNtZiilU = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint OcMYzypbNGWoGkLflLjMneXvaEED(NjwImPuVlIWyUgfMDRGuJasMBDyg P_0)
	{
		if (qdAkcjCKLthOgJIvATzEajhvzwKtA)
		{
			return (uint)P_0.zYzYXAbpWdijBXMmOhnMFknelxgDb;
		}
		return P_0.NwEPmJWbRnBijvzDGDGMeNtZiilU;
	}

	[SpecialName]
	public static ulong OcMYzypbNGWoGkLflLjMneXvaEED(NjwImPuVlIWyUgfMDRGuJasMBDyg P_0)
	{
		if (qdAkcjCKLthOgJIvATzEajhvzwKtA)
		{
			return P_0.zYzYXAbpWdijBXMmOhnMFknelxgDb;
		}
		return P_0.NwEPmJWbRnBijvzDGDGMeNtZiilU;
	}

	public string jCITwHTfJzAPQFtpBVNImocNnYblA()
	{
		if (qdAkcjCKLthOgJIvATzEajhvzwKtA)
		{
			return zYzYXAbpWdijBXMmOhnMFknelxgDb.ToString();
		}
		return NwEPmJWbRnBijvzDGDGMeNtZiilU.ToString();
	}
}
