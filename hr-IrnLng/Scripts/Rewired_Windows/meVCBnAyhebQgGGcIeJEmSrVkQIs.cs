using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class meVCBnAyhebQgGGcIeJEmSrVkQIs
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int bWdDaarUjhGKovMrKcqVKaJJEZa(void* deviceInstance, IntPtr data);

	private readonly IntPtr fRSdJIinkkjfuOwZLyQSrdGfQnO;

	private readonly bWdDaarUjhGKovMrKcqVKaJJEZa tIfcxbGihlHDauFsvXKgPfSPacGb;

	[CompilerGenerated]
	private List<hEReAzXHsNbdNVsbqcWPprgKPaZ> RzWbFllsiDiYYLPCykZPTFDPhlX;

	public IntPtr NativePointer => fRSdJIinkkjfuOwZLyQSrdGfQnO;

	public List<hEReAzXHsNbdNVsbqcWPprgKPaZ> EffectsInFile
	{
		[CompilerGenerated]
		get
		{
			return RzWbFllsiDiYYLPCykZPTFDPhlX;
		}
		[CompilerGenerated]
		private set
		{
			RzWbFllsiDiYYLPCykZPTFDPhlX = value;
		}
	}

	public unsafe meVCBnAyhebQgGGcIeJEmSrVkQIs()
	{
		tIfcxbGihlHDauFsvXKgPfSPacGb = JsbCYVhnLDDykqHedaLfTlNrMiw;
		fRSdJIinkkjfuOwZLyQSrdGfQnO = Marshal.GetFunctionPointerForDelegate((Delegate)tIfcxbGihlHDauFsvXKgPfSPacGb);
		EffectsInFile = new List<hEReAzXHsNbdNVsbqcWPprgKPaZ>();
	}

	[MonoPInvokeCallback(typeof(bWdDaarUjhGKovMrKcqVKaJJEZa))]
	private unsafe static int JsbCYVhnLDDykqHedaLfTlNrMiw(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<meVCBnAyhebQgGGcIeJEmSrVkQIs>(instanceId, out var instance))
		{
			return 1;
		}
		hEReAzXHsNbdNVsbqcWPprgKPaZ hEReAzXHsNbdNVsbqcWPprgKPaZ2 = new hEReAzXHsNbdNVsbqcWPprgKPaZ();
		hEReAzXHsNbdNVsbqcWPprgKPaZ2.RRYnwCwWhPouHIqMSeRibznJNqB(ref *(hEReAzXHsNbdNVsbqcWPprgKPaZ.FkngOuDWWESUqzIzHdBTgAcoHKFH*)P_0);
		instance.EffectsInFile.Add(hEReAzXHsNbdNVsbqcWPprgKPaZ2);
		return 1;
	}
}
