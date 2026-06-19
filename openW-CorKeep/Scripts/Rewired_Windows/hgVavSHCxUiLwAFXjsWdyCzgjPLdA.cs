using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class hgVavSHCxUiLwAFXjsWdyCzgjPLdA
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int oMeYQqkOeoQRaOyEjtsvpotUTrew(void* deviceInstance, IntPtr data);

	private readonly IntPtr rNwfIDDbjPrmmuQPTRjGdthuxsgkA;

	private readonly oMeYQqkOeoQRaOyEjtsvpotUTrew vIfuPYphLCfWMAsMLeMWWYRcohjJA;

	[CompilerGenerated]
	private List<imrYLdMubFmPmyTHGiyrTyLXNBvn> cyiUxQQzMNMljXnITRVGxjIiGNuI;

	public IntPtr TVVdRQolQDHOaaCEmHiEzYYOCnBP => rNwfIDDbjPrmmuQPTRjGdthuxsgkA;

	public List<imrYLdMubFmPmyTHGiyrTyLXNBvn> uECZoMokOxIZoqnBLbnrXlpgDnQHA
	{
		[CompilerGenerated]
		get
		{
			return cyiUxQQzMNMljXnITRVGxjIiGNuI;
		}
		[CompilerGenerated]
		private set
		{
			cyiUxQQzMNMljXnITRVGxjIiGNuI = list;
		}
	}

	public unsafe hgVavSHCxUiLwAFXjsWdyCzgjPLdA()
	{
		vIfuPYphLCfWMAsMLeMWWYRcohjJA = IXMwknEDlGPckOfaDdKEApDRVekWA;
		rNwfIDDbjPrmmuQPTRjGdthuxsgkA = Marshal.GetFunctionPointerForDelegate(vIfuPYphLCfWMAsMLeMWWYRcohjJA);
		uECZoMokOxIZoqnBLbnrXlpgDnQHA = new List<imrYLdMubFmPmyTHGiyrTyLXNBvn>();
	}

	[MonoPInvokeCallback(typeof(oMeYQqkOeoQRaOyEjtsvpotUTrew))]
	private unsafe static int IXMwknEDlGPckOfaDdKEApDRVekWA(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<hgVavSHCxUiLwAFXjsWdyCzgjPLdA>(instanceId, out var instance))
		{
			return 1;
		}
		imrYLdMubFmPmyTHGiyrTyLXNBvn item = new imrYLdMubFmPmyTHGiyrTyLXNBvn((IntPtr)P_0);
		instance.uECZoMokOxIZoqnBLbnrXlpgDnQHA.Add(item);
		return 1;
	}
}
