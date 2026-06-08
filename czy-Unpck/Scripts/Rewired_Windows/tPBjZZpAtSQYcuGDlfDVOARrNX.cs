using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal static class tPBjZZpAtSQYcuGDlfDVOARrNX
{
	public unsafe static int IxiRznNLccenLgseDrJPlJNbHPI(StoefIABSsMqhewHfXAHNOAILfl[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (IntPtr* ptr = P_0)
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_1))
			{
				result = lvutwPPOXDSeCerJjGniIqYcpqn(ptr, ptr2, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int lvutwPPOXDSeCerJjGniIqYcpqn(void* P_0, void* P_1, int P_2);

	public unsafe static int kCAXFYidwvFFfAGvqsKCviGEfdu(OaNFBPKsHpSFCWOWEBKJZAsfEHE[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (IntPtr* ptr = P_0)
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_1))
			{
				result = FSgehxqjfuRBZIYHHIwIrlUqwqC(ptr, ptr2, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int FSgehxqjfuRBZIYHHIwIrlUqwqC(void* P_0, void* P_1, int P_2);

	public unsafe static int iQnRybWcRmvuFPuoyUcrJruCuhM(IntPtr P_0, gkbFimuvDpjWkMhCqsGoDzviJIQ P_1, IntPtr P_2, ref int P_3)
	{
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_3))
		{
			result = qQPuBvipsFhNYenkopdVulAyyYb((void*)P_0, (int)P_1, (void*)P_2, ptr);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qQPuBvipsFhNYenkopdVulAyyYb(void* P_0, int P_1, void* P_2, void* P_3);

	public unsafe static sRQFoGahINekTbXVfEgedOObPzBo pHnvaNnnFPmWlaVvBjvXgLOWQjM(OaNFBPKsHpSFCWOWEBKJZAsfEHE[] P_0, int P_1, int P_2)
	{
		sRQFoGahINekTbXVfEgedOObPzBo result;
		fixed (IntPtr* ptr = P_0)
		{
			result = OqwnnawVOSGypjpWYHindlCfGaFH(ptr, P_1, P_2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern sRQFoGahINekTbXVfEgedOObPzBo OqwnnawVOSGypjpWYHindlCfGaFH(void* P_0, int P_1, int P_2);

	public unsafe static int OaDCwmvVVApBRFPFwpleZKoSRTT(arkOMRMkUkHvASjfJYFFLEtfKOm[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (IntPtr* ptr = P_0)
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_1))
			{
				result = qoskvnCAooTJJFlYDzwQmlLVStz(ptr, ptr2, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qoskvnCAooTJJFlYDzwQmlLVStz(void* P_0, void* P_1, int P_2);

	public unsafe static int rfgwCKTpfyFagEyFmXtgoAlKtVFI(IntPtr P_0, dqOcqyIOzZdgAppdMDyzipoAeQVv P_1, IntPtr P_2, ref int P_3, int P_4)
	{
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_3))
		{
			result = FZLPBqHuSobRcuJQicuwHRidtrG((void*)P_0, (int)P_1, (void*)P_2, ptr, P_4);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int FZLPBqHuSobRcuJQicuwHRidtrG(void* P_0, int P_1, void* P_2, void* P_3, int P_4);
}
