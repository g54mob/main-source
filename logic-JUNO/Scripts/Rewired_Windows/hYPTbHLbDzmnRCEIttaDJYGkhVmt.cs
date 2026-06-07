using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal abstract class hYPTbHLbDzmnRCEIttaDJYGkhVmt : OeTgTiFqZEzjmRoCwPVubuPOrkUn
{
	[CompilerGenerated]
	private JEPBkoFoKXnaFOUZIttNtjjJjbESA kXBFEogptGMApedwGeZDxAMERJKKA;

	public JEPBkoFoKXnaFOUZIttNtjjJjbESA lAyzYgbxTVyfCSwNnNmuroRHHIaG
	{
		[CompilerGenerated]
		get
		{
			return kXBFEogptGMApedwGeZDxAMERJKKA;
		}
		[CompilerGenerated]
		private set
		{
			kXBFEogptGMApedwGeZDxAMERJKKA = jEPBkoFoKXnaFOUZIttNtjjJjbESA;
		}
	}

	protected abstract SWakJJwcOXdUlDvznHmUSuWuXrJtA wThTqsmVnRaoSdkfWHmPRAqqAGsE { get; }

	public unsafe virtual void BfKHizrUzUBaobNxIjQMDtpDzYeDb(JEPBkoFoKXnaFOUZIttNtjjJjbESA P_0)
	{
		lAyzYgbxTVyfCSwNnNmuroRHHIaG = P_0;
		base.ACFwmzDwqOrdlJWEMfNgthgFfemb = Marshal.AllocHGlobal(IntPtr.Size * 2);
		GCHandle value = GCHandle.Alloc(this);
		Marshal.WriteIntPtr(base.ACFwmzDwqOrdlJWEMfNgthgFfemb, wThTqsmVnRaoSdkfWHmPRAqqAGsE.LjVZYhXVTjJPIVhRCSpdiNaZpGzq);
		((IntPtr*)(void*)base.ACFwmzDwqOrdlJWEMfNgthgFfemb)[1] = GCHandle.ToIntPtr(value);
	}

	protected unsafe virtual void sRkadAcGLxVdpRTvohFzUAyjIJZfb(bool P_0)
	{
		if (base.ACFwmzDwqOrdlJWEMfNgthgFfemb != IntPtr.Zero)
		{
			GCHandle.FromIntPtr(((IntPtr*)(void*)base.ACFwmzDwqOrdlJWEMfNgthgFfemb)[1]).Free();
			Marshal.FreeHGlobal(base.ACFwmzDwqOrdlJWEMfNgthgFfemb);
			base.ACFwmzDwqOrdlJWEMfNgthgFfemb = IntPtr.Zero;
		}
		lAyzYgbxTVyfCSwNnNmuroRHHIaG = null;
		UfTbwHUwXkCCSUwOwZUccwahTZde(P_0);
	}

	internal unsafe static _0001 AAeUPiQkfzttrUonZWOlYIIxajVK<_0001>(IntPtr P_0) where _0001 : hYPTbHLbDzmnRCEIttaDJYGkhVmt
	{
		return (_0001)GCHandle.FromIntPtr(((IntPtr*)(void*)P_0)[1]).Target;
	}
}
