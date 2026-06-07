using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal abstract class DyPpCHzzjNgMpKeBBzFjSPgpNvDK : yxRdsaIzxkQQMrVJOqoAjufBHmjzB
{
	[CompilerGenerated]
	private xQLmLqOkyxmFpIYGyTSzgNJWCdnJA xExuncrOnNOIKoWFDNMnEjtUgQhZ;

	public xQLmLqOkyxmFpIYGyTSzgNJWCdnJA lzzfSrAGswbboaKzCWLuAYUbfadje
	{
		[CompilerGenerated]
		get
		{
			return xExuncrOnNOIKoWFDNMnEjtUgQhZ;
		}
		[CompilerGenerated]
		private set
		{
			xExuncrOnNOIKoWFDNMnEjtUgQhZ = xQLmLqOkyxmFpIYGyTSzgNJWCdnJA2;
		}
	}

	protected abstract eYgciNgYmxwbRDlsLLLmjhuDtfefB bHqcAbFVbBwaioNkCIBbvqcChbVq { get; }

	public unsafe virtual void qPhGjuHRNEfrkMynCGIBKdbFaOxF(xQLmLqOkyxmFpIYGyTSzgNJWCdnJA P_0)
	{
		lzzfSrAGswbboaKzCWLuAYUbfadje = P_0;
		base.EEEaoiMKSwLCOBgsTjMBeDlbgYMaA = Marshal.AllocHGlobal(IntPtr.Size * 2);
		GCHandle value = GCHandle.Alloc(this);
		Marshal.WriteIntPtr(base.EEEaoiMKSwLCOBgsTjMBeDlbgYMaA, bHqcAbFVbBwaioNkCIBbvqcChbVq.kWRTOHULzKpCRgNuSFABYNYVScy);
		((IntPtr*)(void*)base.EEEaoiMKSwLCOBgsTjMBeDlbgYMaA)[1] = GCHandle.ToIntPtr(value);
	}

	protected unsafe override void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
	{
		if (base.EEEaoiMKSwLCOBgsTjMBeDlbgYMaA != IntPtr.Zero)
		{
			GCHandle.FromIntPtr(((IntPtr*)(void*)base.EEEaoiMKSwLCOBgsTjMBeDlbgYMaA)[1]).Free();
			Marshal.FreeHGlobal(base.EEEaoiMKSwLCOBgsTjMBeDlbgYMaA);
			base.EEEaoiMKSwLCOBgsTjMBeDlbgYMaA = IntPtr.Zero;
		}
		lzzfSrAGswbboaKzCWLuAYUbfadje = null;
		base.hIlanWXkrCYfgvCyascUuCUOCBcL(P_0);
	}

	internal unsafe static _0001 YRJiubUanIlkcfBRdXffpadYSRzj<_0001>(IntPtr P_0) where _0001 : DyPpCHzzjNgMpKeBBzFjSPgpNvDK
	{
		return (_0001)GCHandle.FromIntPtr(((IntPtr*)(void*)P_0)[1]).Target;
	}
}
