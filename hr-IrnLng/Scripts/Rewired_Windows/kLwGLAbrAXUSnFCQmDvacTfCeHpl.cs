using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class kLwGLAbrAXUSnFCQmDvacTfCeHpl
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int NcFJVjVtvcWKURUQCbVuQIjoFoi(void* deviceInstance, IntPtr data);

	private readonly IntPtr fRSdJIinkkjfuOwZLyQSrdGfQnO;

	private readonly NcFJVjVtvcWKURUQCbVuQIjoFoi tIfcxbGihlHDauFsvXKgPfSPacGb;

	[CompilerGenerated]
	private List<oavsBCpkURSQZhuDFrqXELCmmrM> vpXDHMHaCFTrxYaDGvHNaLOpDAK;

	public IntPtr NativePointer => fRSdJIinkkjfuOwZLyQSrdGfQnO;

	public List<oavsBCpkURSQZhuDFrqXELCmmrM> DeviceInstances
	{
		[CompilerGenerated]
		get
		{
			return vpXDHMHaCFTrxYaDGvHNaLOpDAK;
		}
		[CompilerGenerated]
		private set
		{
			vpXDHMHaCFTrxYaDGvHNaLOpDAK = value;
		}
	}

	public unsafe kLwGLAbrAXUSnFCQmDvacTfCeHpl()
	{
		tIfcxbGihlHDauFsvXKgPfSPacGb = oTpuAHKvPmJCkwoPnPVGKMTwbDB;
		fRSdJIinkkjfuOwZLyQSrdGfQnO = Marshal.GetFunctionPointerForDelegate((Delegate)tIfcxbGihlHDauFsvXKgPfSPacGb);
		DeviceInstances = new List<oavsBCpkURSQZhuDFrqXELCmmrM>();
	}

	[MonoPInvokeCallback(typeof(NcFJVjVtvcWKURUQCbVuQIjoFoi))]
	private unsafe static int oTpuAHKvPmJCkwoPnPVGKMTwbDB(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<kLwGLAbrAXUSnFCQmDvacTfCeHpl>(instanceId, out var instance))
		{
			return 1;
		}
		oavsBCpkURSQZhuDFrqXELCmmrM oavsBCpkURSQZhuDFrqXELCmmrM2 = new oavsBCpkURSQZhuDFrqXELCmmrM();
		oavsBCpkURSQZhuDFrqXELCmmrM2.RRYnwCwWhPouHIqMSeRibznJNqB(ref *(oavsBCpkURSQZhuDFrqXELCmmrM.OiFiFaQyfKOvstAnyQaoVgPuHRq*)P_0);
		instance.DeviceInstances.Add(oavsBCpkURSQZhuDFrqXELCmmrM2);
		return 1;
	}
}
