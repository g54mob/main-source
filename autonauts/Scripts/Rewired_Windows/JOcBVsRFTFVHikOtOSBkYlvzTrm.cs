using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class JOcBVsRFTFVHikOtOSBkYlvzTrm
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int ZrezheAdCIJYfhzqToRepXRlzkL(void* deviceInstance, IntPtr data);

	private readonly IntPtr oQrDIzabSXnJeReNAUCNWaVKrkpV;

	private readonly ZrezheAdCIJYfhzqToRepXRlzkL gcSCuQrNDUgbabBuaIMfeSRwgnvd;

	[CompilerGenerated]
	private List<xKIJQuPRJUZmFRXApMqoqktQTCm> uusRhoTmnMzXyNQXEJtnVhbNNBy;

	public IntPtr NativePointer
	{
		get
		{
			return oQrDIzabSXnJeReNAUCNWaVKrkpV;
		}
	}

	public List<xKIJQuPRJUZmFRXApMqoqktQTCm> EffectInfos
	{
		[CompilerGenerated]
		get
		{
			return uusRhoTmnMzXyNQXEJtnVhbNNBy;
		}
		[CompilerGenerated]
		private set
		{
			uusRhoTmnMzXyNQXEJtnVhbNNBy = value;
		}
	}

	public unsafe JOcBVsRFTFVHikOtOSBkYlvzTrm()
	{
		gcSCuQrNDUgbabBuaIMfeSRwgnvd = jfarfMvxPyWqblfGWPsWbAehlWD;
		oQrDIzabSXnJeReNAUCNWaVKrkpV = Marshal.GetFunctionPointerForDelegate((Delegate)gcSCuQrNDUgbabBuaIMfeSRwgnvd);
		EffectInfos = new List<xKIJQuPRJUZmFRXApMqoqktQTCm>();
	}

	[MonoPInvokeCallback(typeof(ZrezheAdCIJYfhzqToRepXRlzkL))]
	private unsafe static int jfarfMvxPyWqblfGWPsWbAehlWD(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		JOcBVsRFTFVHikOtOSBkYlvzTrm instance;
		if (!ObjectInstanceTracker.Default.TryGetInstance<JOcBVsRFTFVHikOtOSBkYlvzTrm>(instanceId, out instance))
		{
			return 1;
		}
		xKIJQuPRJUZmFRXApMqoqktQTCm xKIJQuPRJUZmFRXApMqoqktQTCm2 = new xKIJQuPRJUZmFRXApMqoqktQTCm();
		xKIJQuPRJUZmFRXApMqoqktQTCm2.YlftNbjDTaOHNaMzVFmdceqqrvk(ref *(xKIJQuPRJUZmFRXApMqoqktQTCm.LYNtVeNmSwWMkPNrSlgZZzICfXt*)P_0);
		instance.EffectInfos.Add(xKIJQuPRJUZmFRXApMqoqktQTCm2);
		return 1;
	}
}
