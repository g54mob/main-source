using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class nSXuRAqOTwCZXyXcDRQCJHZOFUUJ
{
	public unsafe static int dRAFwmWlfgokPyRuvPJxXxriEehQ(AicfiLBzLnbLmEahFvhGePZzVboqb[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (AicfiLBzLnbLmEahFvhGePZzVboqb* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = ojOettgDvIZLkdmeUItRQPxiezvM(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ojOettgDvIZLkdmeUItRQPxiezvM(void* P_0, void* P_1, int P_2);

	public unsafe static int jvbkcynwfyVpNcCuoAijVUAjKvtm(IsTPFKdGGcfKBEUkKZpMPRxeppFfA[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (IsTPFKdGGcfKBEUkKZpMPRxeppFfA* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = HBlNBFTnfrGrxeNJPLHrvWdhJOis(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int HBlNBFTnfrGrxeNJPLHrvWdhJOis(void* P_0, void* P_1, int P_2);

	public unsafe static int vkddCMNyeymYiiSaXQHDTTROcjUc(IntPtr P_0, yexWVfBKqkmUHOgBcdCLJqahQlRW P_1, IntPtr P_2, ref int P_3)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = ZvtHnzEUPqkVktFWNtKutVyvgHCt((void*)P_0, (int)P_1, (void*)P_2, ptr2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ZvtHnzEUPqkVktFWNtKutVyvgHCt(void* P_0, int P_1, void* P_2, void* P_3);

	public unsafe static uWOqpRQeRUtDCJArQdGhUlVIEJbt ivDnBNpsMpZNuEXAIzkMGYapeGSE(IsTPFKdGGcfKBEUkKZpMPRxeppFfA[] P_0, int P_1, int P_2)
	{
		uWOqpRQeRUtDCJArQdGhUlVIEJbt result;
		fixed (IsTPFKdGGcfKBEUkKZpMPRxeppFfA* ptr = P_0)
		{
			void* ptr2 = ptr;
			result = jsVYfMDlEgDTVmJlTkpHPQPJRiiA(ptr2, P_1, P_2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern uWOqpRQeRUtDCJArQdGhUlVIEJbt jsVYfMDlEgDTVmJlTkpHPQPJRiiA(void* P_0, int P_1, int P_2);

	public unsafe static int DGFRxuKazUyjRakOnToKRplMdGCT(gfsISYAhFdyAJBCRFvaCqFciesnfb[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (gfsISYAhFdyAJBCRFvaCqFciesnfb* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = xXpAyAAdNBYNRWMIpmIujdvjpGgzA(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int xXpAyAAdNBYNRWMIpmIujdvjpGgzA(void* P_0, void* P_1, int P_2);

	public unsafe static int elDyBzgKXjBPIRYMIFVimqImlRJt(IntPtr P_0, rbEsiznakKlgFtbPMCXubElJJeMx P_1, IntPtr P_2, ref int P_3, int P_4)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = BIUcVsGdqXVPWFUJVgyByLDuZAyc((void*)P_0, (int)P_1, (void*)P_2, ptr2, P_4);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int BIUcVsGdqXVPWFUJVgyByLDuZAyc(void* P_0, int P_1, void* P_2, void* P_3, int P_4);
}
