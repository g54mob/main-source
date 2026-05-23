using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal static class iGAQYgiqmZxitbBUEopFVczljWt
{
	public unsafe static int VEjecGimSYjMoHvgIPCJUvyVLXwm(XNntnjjGeGIlCzyTsKEBZzhavVF[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (IntPtr* ptr = P_0)
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_1))
			{
				result = qnjoJwgekpHnldffyLTuYaPKVjR(ptr, ptr2, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qnjoJwgekpHnldffyLTuYaPKVjR(void* P_0, void* P_1, int P_2);

	public unsafe static int hyXCInTsFRbuYDvtlexSlnriFjW(HVKWqsxdqPihzNaMTESPTPFRVXw[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (IntPtr* ptr = P_0)
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_1))
			{
				result = MavbnKVNJUybuNtOMJbAnRQIqQa(ptr, ptr2, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int MavbnKVNJUybuNtOMJbAnRQIqQa(void* P_0, void* P_1, int P_2);

	public unsafe static int hOcQWqdnfUGueIyBpJgnVPuogJo(IntPtr P_0, lIkUYDLVPDAgfNWlndTCZGEKHKa P_1, IntPtr P_2, ref int P_3)
	{
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_3))
		{
			result = jwCHWCRmIhuktjhibWuXqWtEaKH((void*)P_0, (int)P_1, (void*)P_2, ptr);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int jwCHWCRmIhuktjhibWuXqWtEaKH(void* P_0, int P_1, void* P_2, void* P_3);

	public unsafe static rIDNnnMXkrSTyWtFHFduSktzqvC omyaIaMsFnFkAlMDQenLkhosERR(HVKWqsxdqPihzNaMTESPTPFRVXw[] P_0, int P_1, int P_2)
	{
		rIDNnnMXkrSTyWtFHFduSktzqvC result;
		fixed (IntPtr* ptr = P_0)
		{
			result = ZphFuNiPsgnRCXyKNYphpbhRCwbN(ptr, P_1, P_2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern rIDNnnMXkrSTyWtFHFduSktzqvC ZphFuNiPsgnRCXyKNYphpbhRCwbN(void* P_0, int P_1, int P_2);

	public unsafe static int ZQHTVGwhcCnaIJXrwuuDTLqRGt(fIfDvwvvsOcXtZCxSBYBVEQFUcW[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (IntPtr* ptr = P_0)
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_1))
			{
				result = rSlxKGrIyEeuqEHvSJcAooIbdCT(ptr, ptr2, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int rSlxKGrIyEeuqEHvSJcAooIbdCT(void* P_0, void* P_1, int P_2);

	public unsafe static int kvhKHhgxRGGFJnqFhveyEJWkyVp(IntPtr P_0, cLPQxJvERvRJxsvxRzinhGLijYd P_1, IntPtr P_2, ref int P_3, int P_4)
	{
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_3))
		{
			result = CTKbATiksEukZmpUtBpcXTDFBdmP((void*)P_0, (int)P_1, (void*)P_2, ptr, P_4);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int CTKbATiksEukZmpUtBpcXTDFBdmP(void* P_0, int P_1, void* P_2, void* P_3, int P_4);
}
