using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class GIpFgoBUMndhxdBpEKDYQlhhhMuVA
{
	public unsafe static int WgsQFYjWinUUzHufsPRtzSRJCtBo(ttGTJvCLWyopGRqwuMdUrXnsniOo[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (ttGTJvCLWyopGRqwuMdUrXnsniOo* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = VugPQNNooTflACQrZhfLbuXJimXab(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int VugPQNNooTflACQrZhfLbuXJimXab(void* P_0, void* P_1, int P_2);

	public unsafe static int QMTRQSGXuxzlpJbzvadrzBgGmTZK(rZhfmmGHDlbujHltFJrKypNLZgzkA[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (rZhfmmGHDlbujHltFJrKypNLZgzkA* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = cqNJyreMqodTTHxQIVTxNOFMaHQw(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int cqNJyreMqodTTHxQIVTxNOFMaHQw(void* P_0, void* P_1, int P_2);

	public unsafe static int KuBAqsubzfMFeJEDMSDRnDftihRQ(IntPtr P_0, JPPfkZiSxzFGdJrSzrIRLxEIsideA P_1, IntPtr P_2, ref int P_3)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = kiVLULrXYnhJSKXZOQmwFhKKCTuG((void*)P_0, (int)P_1, (void*)P_2, ptr2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int kiVLULrXYnhJSKXZOQmwFhKKCTuG(void* P_0, int P_1, void* P_2, void* P_3);

	public unsafe static BicPxZfWIPNacckpNSxKcxfbKgVe ZCxYTjObpgtjtlQiDpWsyqFAdyoD(rZhfmmGHDlbujHltFJrKypNLZgzkA[] P_0, int P_1, int P_2)
	{
		BicPxZfWIPNacckpNSxKcxfbKgVe result;
		fixed (rZhfmmGHDlbujHltFJrKypNLZgzkA* ptr = P_0)
		{
			void* ptr2 = ptr;
			result = IRQjJTuEePfqlFGIieLrvyvoOgQg(ptr2, P_1, P_2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern BicPxZfWIPNacckpNSxKcxfbKgVe IRQjJTuEePfqlFGIieLrvyvoOgQg(void* P_0, int P_1, int P_2);

	public unsafe static int mRlDUYxlcDGXzAHBiieKZtRxOFsZ(BjCvnoOtWqGefptWAQkEdQCXvsRk[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (BjCvnoOtWqGefptWAQkEdQCXvsRk* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = ACPzDmETWMDpzfSJcSMcHTNKMFYS(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ACPzDmETWMDpzfSJcSMcHTNKMFYS(void* P_0, void* P_1, int P_2);

	public unsafe static int TpbcwRVxQaDlcaiRFoRqjAoDFEdWA(IntPtr P_0, EJiRCZEzxLDjAKCeBSfwFPOenHyc P_1, IntPtr P_2, ref int P_3, int P_4)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = ewoVlffovUlEdsHFKgruWRbVCrYi((void*)P_0, (int)P_1, (void*)P_2, ptr2, P_4);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ewoVlffovUlEdsHFKgruWRbVCrYi(void* P_0, int P_1, void* P_2, void* P_3, int P_4);
}
