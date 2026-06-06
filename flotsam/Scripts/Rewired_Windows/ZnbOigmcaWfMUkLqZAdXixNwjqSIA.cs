using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal abstract class ZnbOigmcaWfMUkLqZAdXixNwjqSIA : eTtmQDwyoxAetdIcSOeqAFAMIFcS
{
	[CompilerGenerated]
	private txfTVBNIrejVWwElagqNkOgVlMqGb YpvhPFYKEjbLsDETuQvZhLPUohgC;

	public txfTVBNIrejVWwElagqNkOgVlMqGb VnIfALFWomwLHOujNsSsAWlHjsKtA
	{
		[CompilerGenerated]
		get
		{
			return YpvhPFYKEjbLsDETuQvZhLPUohgC;
		}
		[CompilerGenerated]
		private set
		{
			YpvhPFYKEjbLsDETuQvZhLPUohgC = ypvhPFYKEjbLsDETuQvZhLPUohgC;
		}
	}

	protected abstract sRGwxsXtuchvcBDkZpnIRLIgIIzg EfFGsLTOawnVNNhAmzIJsFHaVrOO { get; }

	public unsafe virtual void hWiRTIOOIdLPdbERuThEEqmfjCWi(txfTVBNIrejVWwElagqNkOgVlMqGb P_0)
	{
		VnIfALFWomwLHOujNsSsAWlHjsKtA = P_0;
		base.cOaLXRsqVRuSojLsgpkROlcJOCEr = Marshal.AllocHGlobal(IntPtr.Size * 2);
		GCHandle value = GCHandle.Alloc(this);
		Marshal.WriteIntPtr(base.cOaLXRsqVRuSojLsgpkROlcJOCEr, EfFGsLTOawnVNNhAmzIJsFHaVrOO.vHtdpQslyYwHTvqjgkvlPCdFvmHF);
		((IntPtr*)(void*)base.cOaLXRsqVRuSojLsgpkROlcJOCEr)[1] = GCHandle.ToIntPtr(value);
	}

	protected unsafe virtual void YzEYCvlOoKEHadSXWYwtjtndaozg(bool P_0)
	{
		if (base.cOaLXRsqVRuSojLsgpkROlcJOCEr != IntPtr.Zero)
		{
			GCHandle.FromIntPtr(((IntPtr*)(void*)base.cOaLXRsqVRuSojLsgpkROlcJOCEr)[1]).Free();
			Marshal.FreeHGlobal(base.cOaLXRsqVRuSojLsgpkROlcJOCEr);
			base.cOaLXRsqVRuSojLsgpkROlcJOCEr = IntPtr.Zero;
		}
		VnIfALFWomwLHOujNsSsAWlHjsKtA = null;
		iftfQczMLBGrPupOKFOaZoplAiHs(P_0);
	}

	internal unsafe static _0001 ooAjxZhtSIhWqmjPjGBrrlFfiNjS<_0001>(IntPtr P_0) where _0001 : ZnbOigmcaWfMUkLqZAdXixNwjqSIA
	{
		return (_0001)GCHandle.FromIntPtr(((IntPtr*)(void*)P_0)[1]).Target;
	}
}
