using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class nLTSNxieksGyvmfAfHbtKooTjAEd
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int KKRBgAGZcTCpHjlxxVayQPadgOC(void* deviceInstance, IntPtr data);

	private readonly IntPtr oQrDIzabSXnJeReNAUCNWaVKrkpV;

	private readonly KKRBgAGZcTCpHjlxxVayQPadgOC gcSCuQrNDUgbabBuaIMfeSRwgnvd;

	[CompilerGenerated]
	private List<vgUDhfmgAmAsRjRuQJnGENONMljC> uPgoWvWXkaonnssDROtMlWDGjWb;

	public IntPtr NativePointer
	{
		get
		{
			return oQrDIzabSXnJeReNAUCNWaVKrkpV;
		}
	}

	public List<vgUDhfmgAmAsRjRuQJnGENONMljC> DeviceInstances
	{
		[CompilerGenerated]
		get
		{
			return uPgoWvWXkaonnssDROtMlWDGjWb;
		}
		[CompilerGenerated]
		private set
		{
			uPgoWvWXkaonnssDROtMlWDGjWb = value;
		}
	}

	public unsafe nLTSNxieksGyvmfAfHbtKooTjAEd()
	{
		gcSCuQrNDUgbabBuaIMfeSRwgnvd = bZUWpuPNxLVnmGZRsGXXLjAFbya;
		oQrDIzabSXnJeReNAUCNWaVKrkpV = Marshal.GetFunctionPointerForDelegate((Delegate)gcSCuQrNDUgbabBuaIMfeSRwgnvd);
		DeviceInstances = new List<vgUDhfmgAmAsRjRuQJnGENONMljC>();
	}

	[MonoPInvokeCallback(typeof(KKRBgAGZcTCpHjlxxVayQPadgOC))]
	private unsafe static int bZUWpuPNxLVnmGZRsGXXLjAFbya(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		nLTSNxieksGyvmfAfHbtKooTjAEd instance;
		if (!ObjectInstanceTracker.Default.TryGetInstance<nLTSNxieksGyvmfAfHbtKooTjAEd>(instanceId, out instance))
		{
			return 1;
		}
		vgUDhfmgAmAsRjRuQJnGENONMljC vgUDhfmgAmAsRjRuQJnGENONMljC2 = new vgUDhfmgAmAsRjRuQJnGENONMljC();
		vgUDhfmgAmAsRjRuQJnGENONMljC2.YlftNbjDTaOHNaMzVFmdceqqrvk(ref *(vgUDhfmgAmAsRjRuQJnGENONMljC.QxYzdPHxAsVkDbJFdSmbwheZfCB*)P_0);
		instance.DeviceInstances.Add(vgUDhfmgAmAsRjRuQJnGENONMljC2);
		return 1;
	}
}
