using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class nqutJJyNNmXBgLOZrfDPoNWhxEw : efmrLSrolSjovsfxfjCVLLJRnGz
{
	[CompilerGenerated]
	private int cxATEBlKVdvcfcFTeNRvRZXttLp;

	public int Magnitude
	{
		[CompilerGenerated]
		get
		{
			return cxATEBlKVdvcfcFTeNRvRZXttLp;
		}
		[CompilerGenerated]
		set
		{
			cxATEBlKVdvcfcFTeNRvRZXttLp = value;
		}
	}

	public override int Size => QvyMHYIdbHWMtWGQBjyLybggaNAi.PVPOiGJSBGvoBbaMPpcfSPOcCOq<TMUlsOraXoTrLCEHfTQqHJzCDWW>();

	protected unsafe override efmrLSrolSjovsfxfjCVLLJRnGz jgUKJdlhVlbmjmcGcqukHIxicKDF(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(TMUlsOraXoTrLCEHfTQqHJzCDWW))
		{
			return null;
		}
		Magnitude = ((TMUlsOraXoTrLCEHfTQqHJzCDWW*)(void*)P_1)->GZQEsynxELRuselvHylVlxQwtBL;
		return this;
	}

	internal unsafe override IntPtr ytPODbihcgKkYwOfQIFAEFNEgkj()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((TMUlsOraXoTrLCEHfTQqHJzCDWW*)(void*)intPtr)->GZQEsynxELRuselvHylVlxQwtBL = Magnitude;
		return intPtr;
	}
}
