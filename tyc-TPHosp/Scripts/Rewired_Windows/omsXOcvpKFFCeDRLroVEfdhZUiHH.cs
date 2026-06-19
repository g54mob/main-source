using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class omsXOcvpKFFCeDRLroVEfdhZUiHH
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int SWBaziEQSMISuDcKKjKwAbEiyRlH(void* deviceInstance, IntPtr data);

	private readonly IntPtr gBbLrXrPAfTbPiLRobgphErqzjOU;

	private readonly SWBaziEQSMISuDcKKjKwAbEiyRlH iWJLmGxRkATRajaGxiTgAzQvcIb;

	[CompilerGenerated]
	private List<bgSbmTijKGbYwVcPOsdOEuZoNgrU> TrfEMYAxAXsekTOzehvyyywUoUzT;

	public IntPtr NativePointer => gBbLrXrPAfTbPiLRobgphErqzjOU;

	public List<bgSbmTijKGbYwVcPOsdOEuZoNgrU> Effects
	{
		[CompilerGenerated]
		get
		{
			return TrfEMYAxAXsekTOzehvyyywUoUzT;
		}
		[CompilerGenerated]
		private set
		{
			TrfEMYAxAXsekTOzehvyyywUoUzT = value;
		}
	}

	public unsafe omsXOcvpKFFCeDRLroVEfdhZUiHH()
	{
		iWJLmGxRkATRajaGxiTgAzQvcIb = wyZwLyMKdsLJJXgCRvnebYGZCDv;
		gBbLrXrPAfTbPiLRobgphErqzjOU = Marshal.GetFunctionPointerForDelegate((Delegate)iWJLmGxRkATRajaGxiTgAzQvcIb);
		Effects = new List<bgSbmTijKGbYwVcPOsdOEuZoNgrU>();
	}

	[MonoPInvokeCallback(typeof(SWBaziEQSMISuDcKKjKwAbEiyRlH))]
	private unsafe static int wyZwLyMKdsLJJXgCRvnebYGZCDv(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<omsXOcvpKFFCeDRLroVEfdhZUiHH>(instanceId, out var instance))
		{
			return 1;
		}
		bgSbmTijKGbYwVcPOsdOEuZoNgrU item = new bgSbmTijKGbYwVcPOsdOEuZoNgrU((IntPtr)P_0);
		instance.Effects.Add(item);
		return 1;
	}
}
