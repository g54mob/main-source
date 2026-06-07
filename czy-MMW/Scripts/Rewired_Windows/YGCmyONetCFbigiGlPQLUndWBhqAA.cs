using System;
using System.Runtime.InteropServices;

internal static class YGCmyONetCFbigiGlPQLUndWBhqAA
{
	public unsafe static int EiJANmhfBMCGoEiIbFWyoQPAcEZoc(rxphZVKbvVptFaqFDBqNaAjHALYHb[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (rxphZVKbvVptFaqFDBqNaAjHALYHb* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = TvVBEdIHNaFlVmlQoxqUuZHsjNHiA(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	private unsafe static extern int TvVBEdIHNaFlVmlQoxqUuZHsjNHiA(void* P_0, void* P_1, int P_2);

	public unsafe static int UbkOxCiFYSSezuBwfiTAIzfWGxBK(IntPtr P_0, ZneocjsUCUIUwUKbKuTCCpWvKVtq P_1, IntPtr P_2, ref int P_3)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = sJgFCzFlnKHnXNbqzvDtsqQtoliVA((void*)P_0, (int)P_1, (void*)P_2, ptr2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	private unsafe static extern int sJgFCzFlnKHnXNbqzvDtsqQtoliVA(void* P_0, int P_1, void* P_2, void* P_3);

	public unsafe static NPJJVDbRziHVpFFVsJeqXajCKrBx XIIdMFUDWVXvqAqvsdslZXmjOxek(dAQbqMKIcEMmcHGQegkBuEPgeVvvA[] P_0, int P_1, int P_2)
	{
		NPJJVDbRziHVpFFVsJeqXajCKrBx result;
		fixed (dAQbqMKIcEMmcHGQegkBuEPgeVvvA* ptr = P_0)
		{
			void* ptr2 = ptr;
			result = OHjrtbcBBijveogtZbrkShcHplOO(ptr2, P_1, P_2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterRawInputDevices")]
	private unsafe static extern NPJJVDbRziHVpFFVsJeqXajCKrBx OHjrtbcBBijveogtZbrkShcHplOO(void* P_0, int P_1, int P_2);

	public unsafe static int JzQPozRPxZDblToiyMEfzOwmOblM(IntPtr P_0, YkTLJvGtMaZLmrDjuVxfwVZNSqoI P_1, IntPtr P_2, ref int P_3, int P_4)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = sdLHvLrFFfJhqTNurktbtmxaHjUt((void*)P_0, (int)P_1, (void*)P_2, ptr2, P_4);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	private unsafe static extern int sdLHvLrFFfJhqTNurktbtmxaHjUt(void* P_0, int P_1, void* P_2, void* P_3, int P_4);
}
