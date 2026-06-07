using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class QTuQcRcLMwIPBReYViUMBbOLXJOb
{
	public unsafe static int KVbdoOMttsviDJmulaXhZpFduHsL(vdTfpntROrYfsHgrrUOEDVdOhXdj[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (vdTfpntROrYfsHgrrUOEDVdOhXdj* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = RCncSHmOhYUpqQdiGGSLEdVfSzok(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int RCncSHmOhYUpqQdiGGSLEdVfSzok(void* P_0, void* P_1, int P_2);

	public unsafe static int McSidKtnvkxKHRMuwcVlTHqgRlaM(rkqUtypeSubNTlqsMGSMNuHnInUv[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (rkqUtypeSubNTlqsMGSMNuHnInUv* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = yzEcSfVszdAgnNwDLaufntNaCMfhA(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int yzEcSfVszdAgnNwDLaufntNaCMfhA(void* P_0, void* P_1, int P_2);

	public unsafe static int UqGYaeFToaldQRxCNMvLHTrFmkco(IntPtr P_0, XUCAiJZoWsxlJnDQwvPTPAvadnOd P_1, IntPtr P_2, ref int P_3)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = moEwcJAtVoQtyIOWZrvizOZcPeHe((void*)P_0, (int)P_1, (void*)P_2, ptr2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int moEwcJAtVoQtyIOWZrvizOZcPeHe(void* P_0, int P_1, void* P_2, void* P_3);

	public unsafe static HcjebfGWBEygWckvSivzbOnNcDqbb DOsSubdbcpLQNhoZIrUgSxiwmcDO(rkqUtypeSubNTlqsMGSMNuHnInUv[] P_0, int P_1, int P_2)
	{
		HcjebfGWBEygWckvSivzbOnNcDqbb result;
		fixed (rkqUtypeSubNTlqsMGSMNuHnInUv* ptr = P_0)
		{
			void* ptr2 = ptr;
			result = EdPBPBgDjUJEPfVRbBTbuTwYYNpKA(ptr2, P_1, P_2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern HcjebfGWBEygWckvSivzbOnNcDqbb EdPBPBgDjUJEPfVRbBTbuTwYYNpKA(void* P_0, int P_1, int P_2);

	public unsafe static int afeerGIyxSqMPFWShRSSLqNHIRFh(LwLPWqtLAhTwTnToPNxMTOsfkimd[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (LwLPWqtLAhTwTnToPNxMTOsfkimd* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = OPUhzyjBCBStHnGmbdfytTcuQlbE(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int OPUhzyjBCBStHnGmbdfytTcuQlbE(void* P_0, void* P_1, int P_2);

	public unsafe static int JgGZLqZirKzWwOkEyuqkmvfHRCE(IntPtr P_0, AbhIfZEzkMioLOYPIxzyrpPUngLVA P_1, IntPtr P_2, ref int P_3, int P_4)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = aOtzffKqvBhCNknKLgNcgaxlpLpEb((void*)P_0, (int)P_1, (void*)P_2, ptr2, P_4);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int aOtzffKqvBhCNknKLgNcgaxlpLpEb(void* P_0, int P_1, void* P_2, void* P_3, int P_4);
}
