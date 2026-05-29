using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class tzkbQUfJPRfomdywbBPLDuyFVHx
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int qUGeNGMzDrPRRpQWDwLeITgKUpW(void* deviceInstance, IntPtr data);

	private readonly IntPtr oQrDIzabSXnJeReNAUCNWaVKrkpV;

	private readonly qUGeNGMzDrPRRpQWDwLeITgKUpW gcSCuQrNDUgbabBuaIMfeSRwgnvd;

	[CompilerGenerated]
	private List<eLkqbAYZUujJDpuzhSuCedtbTEw> OehdMWJcYyPwSrxSzcJWuIEgpugv;

	public IntPtr NativePointer
	{
		get
		{
			return oQrDIzabSXnJeReNAUCNWaVKrkpV;
		}
	}

	public List<eLkqbAYZUujJDpuzhSuCedtbTEw> EffectsInFile
	{
		[CompilerGenerated]
		get
		{
			return OehdMWJcYyPwSrxSzcJWuIEgpugv;
		}
		[CompilerGenerated]
		private set
		{
			OehdMWJcYyPwSrxSzcJWuIEgpugv = value;
		}
	}

	public unsafe tzkbQUfJPRfomdywbBPLDuyFVHx()
	{
		gcSCuQrNDUgbabBuaIMfeSRwgnvd = ISKeTwgkrwRQmREkozXiLSYUJfLi;
		oQrDIzabSXnJeReNAUCNWaVKrkpV = Marshal.GetFunctionPointerForDelegate((Delegate)gcSCuQrNDUgbabBuaIMfeSRwgnvd);
		EffectsInFile = new List<eLkqbAYZUujJDpuzhSuCedtbTEw>();
	}

	[MonoPInvokeCallback(typeof(qUGeNGMzDrPRRpQWDwLeITgKUpW))]
	private unsafe static int ISKeTwgkrwRQmREkozXiLSYUJfLi(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		tzkbQUfJPRfomdywbBPLDuyFVHx instance;
		if (!ObjectInstanceTracker.Default.TryGetInstance<tzkbQUfJPRfomdywbBPLDuyFVHx>(instanceId, out instance))
		{
			return 1;
		}
		eLkqbAYZUujJDpuzhSuCedtbTEw eLkqbAYZUujJDpuzhSuCedtbTEw2 = new eLkqbAYZUujJDpuzhSuCedtbTEw();
		eLkqbAYZUujJDpuzhSuCedtbTEw2.YlftNbjDTaOHNaMzVFmdceqqrvk(ref *(eLkqbAYZUujJDpuzhSuCedtbTEw.lCOssYdhgtHKPPDOJBitABQODsHC*)P_0);
		instance.EffectsInFile.Add(eLkqbAYZUujJDpuzhSuCedtbTEw2);
		return 1;
	}
}
