using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class AlFqrkavYgyolvcvzAGGMvPAQZnT
{
	public unsafe static int OnKEUQFCeuhVhddhhDGnUSdGesCHB(xfmiKjheOnWgYdmqHzcEOIBRNxHo[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (xfmiKjheOnWgYdmqHzcEOIBRNxHo* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = JeUiRZGykQoyUAmtkTqTeHjuhbMCb(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int JeUiRZGykQoyUAmtkTqTeHjuhbMCb(void* P_0, void* P_1, int P_2);

	public unsafe static int WcdKqOxyhqqwpbdQKhkdEOGflVAC(bWLufulkZwEbdiZtcleSvIpaupcHA[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (bWLufulkZwEbdiZtcleSvIpaupcHA* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = gcxzbtXQstGGLxSMfVUzioztAQXGA(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int gcxzbtXQstGGLxSMfVUzioztAQXGA(void* P_0, void* P_1, int P_2);

	public unsafe static int OyvBsyVEtgDNqfhFhiBJKSTSguSq(IntPtr P_0, ZIlqvPLQjcBRrFiWIuVNWsadVdsu P_1, IntPtr P_2, ref int P_3)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = gslcLZcOCiNyYXgTvWPoJawblVnMA((void*)P_0, (int)P_1, (void*)P_2, ptr2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int gslcLZcOCiNyYXgTvWPoJawblVnMA(void* P_0, int P_1, void* P_2, void* P_3);

	public unsafe static DKIIzhMACWIemCHikiFxBDRSyXEo PmTaZtjOdjtydDuIsAasDpQrkchT(bWLufulkZwEbdiZtcleSvIpaupcHA[] P_0, int P_1, int P_2)
	{
		DKIIzhMACWIemCHikiFxBDRSyXEo result;
		fixed (bWLufulkZwEbdiZtcleSvIpaupcHA* ptr = P_0)
		{
			void* ptr2 = ptr;
			result = OduBcJDXuUDqddCGJXzxWaWPDPVt(ptr2, P_1, P_2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern DKIIzhMACWIemCHikiFxBDRSyXEo OduBcJDXuUDqddCGJXzxWaWPDPVt(void* P_0, int P_1, int P_2);

	public unsafe static int chTVXKCWmCmShlcRVmxEGlpWWYhO(RimEuuxNErdnjPQCnGxQMDsacwIeA[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (RimEuuxNErdnjPQCnGxQMDsacwIeA* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = IPlkAunwANaahXJDPELkCkrzvIPpA(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int IPlkAunwANaahXJDPELkCkrzvIPpA(void* P_0, void* P_1, int P_2);

	public unsafe static int FDPObJstCfkugAiTedUqxhIqgRgV(IntPtr P_0, ShGMVLjSrQUHrixWsXXusOhZkZbg P_1, IntPtr P_2, ref int P_3, int P_4)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = oYUUvbMEaDEupYEFnRdgxrZwINLT((void*)P_0, (int)P_1, (void*)P_2, ptr2, P_4);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int oYUUvbMEaDEupYEFnRdgxrZwINLT(void* P_0, int P_1, void* P_2, void* P_3, int P_4);
}
