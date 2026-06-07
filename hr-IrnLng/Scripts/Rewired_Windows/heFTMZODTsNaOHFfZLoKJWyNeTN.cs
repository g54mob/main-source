using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class heFTMZODTsNaOHFfZLoKJWyNeTN
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int CqyyhkAdbwGezIomyqIFqOLnJaRP(void* deviceInstance, IntPtr data);

	private readonly IntPtr fRSdJIinkkjfuOwZLyQSrdGfQnO;

	private readonly CqyyhkAdbwGezIomyqIFqOLnJaRP tIfcxbGihlHDauFsvXKgPfSPacGb;

	[CompilerGenerated]
	private List<HMxBjwmUHlBNPuNunDJFOGXNgBM> ceJXdmQXjRhIiZIEMfBPAgOaryX;

	public IntPtr NativePointer => fRSdJIinkkjfuOwZLyQSrdGfQnO;

	public List<HMxBjwmUHlBNPuNunDJFOGXNgBM> Objects
	{
		[CompilerGenerated]
		get
		{
			return ceJXdmQXjRhIiZIEMfBPAgOaryX;
		}
		[CompilerGenerated]
		private set
		{
			ceJXdmQXjRhIiZIEMfBPAgOaryX = value;
		}
	}

	public unsafe heFTMZODTsNaOHFfZLoKJWyNeTN()
	{
		tIfcxbGihlHDauFsvXKgPfSPacGb = zBmVtqhJZCXdXIOupbOMVAJuHKr;
		fRSdJIinkkjfuOwZLyQSrdGfQnO = Marshal.GetFunctionPointerForDelegate((Delegate)tIfcxbGihlHDauFsvXKgPfSPacGb);
		Objects = new List<HMxBjwmUHlBNPuNunDJFOGXNgBM>();
	}

	[MonoPInvokeCallback(typeof(CqyyhkAdbwGezIomyqIFqOLnJaRP))]
	private unsafe static int zBmVtqhJZCXdXIOupbOMVAJuHKr(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<heFTMZODTsNaOHFfZLoKJWyNeTN>(instanceId, out var instance))
		{
			return 1;
		}
		HMxBjwmUHlBNPuNunDJFOGXNgBM hMxBjwmUHlBNPuNunDJFOGXNgBM = new HMxBjwmUHlBNPuNunDJFOGXNgBM();
		hMxBjwmUHlBNPuNunDJFOGXNgBM.RRYnwCwWhPouHIqMSeRibznJNqB(ref *(HMxBjwmUHlBNPuNunDJFOGXNgBM.IesfNXWMtMiAiCQLemrrfeVfEtAg*)P_0);
		instance.Objects.Add(hMxBjwmUHlBNPuNunDJFOGXNgBM);
		return 1;
	}
}
