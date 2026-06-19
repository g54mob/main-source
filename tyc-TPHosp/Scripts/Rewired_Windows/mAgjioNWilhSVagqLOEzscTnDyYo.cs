using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal static class mAgjioNWilhSVagqLOEzscTnDyYo
{
	public unsafe static int HdDWzONQvcthSwCYPgLtEpUHQDZ(LNHvDvYjaclMyuJxhDyrbuVyHQyf[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (IntPtr* ptr = P_0)
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_1))
			{
				result = qoBxIcHKiPbMHIkVvGrSerngQyst(ptr, ptr2, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qoBxIcHKiPbMHIkVvGrSerngQyst(void* P_0, void* P_1, int P_2);

	public unsafe static int pjtXujuwBtsRiMeRyEPuKQToZilB(NjgDgiAgnvzFTOeaIiqziqbZmSHd[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (IntPtr* ptr = P_0)
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_1))
			{
				result = KHFcPOayTaCHSUYwZjliKGcEqjFI(ptr, ptr2, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int KHFcPOayTaCHSUYwZjliKGcEqjFI(void* P_0, void* P_1, int P_2);

	public unsafe static int brIreOMwrgdtONdGsTbBcOjqghRD(IntPtr P_0, baSGeTkrHxGjHeWTiJXsSekEbWXI P_1, IntPtr P_2, ref int P_3)
	{
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_3))
		{
			result = zjgkkEoiORFbXouKmWdvNfVGiNo((void*)P_0, (int)P_1, (void*)P_2, ptr);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int zjgkkEoiORFbXouKmWdvNfVGiNo(void* P_0, int P_1, void* P_2, void* P_3);

	public unsafe static rlZVbCdeVmsWkNfGXJCirTzWorR wpIBQqJdJPZuwpmvLlIjARAAsLgY(NjgDgiAgnvzFTOeaIiqziqbZmSHd[] P_0, int P_1, int P_2)
	{
		rlZVbCdeVmsWkNfGXJCirTzWorR result;
		fixed (IntPtr* ptr = P_0)
		{
			result = JyZKPDeMsEicodwwWVsPUJRNjdE(ptr, P_1, P_2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern rlZVbCdeVmsWkNfGXJCirTzWorR JyZKPDeMsEicodwwWVsPUJRNjdE(void* P_0, int P_1, int P_2);

	public unsafe static int VzsMjFhSpSHvAgTnaPYMiUpwaAIF(dyBuhgITgugHFQsBNbztydiZyDp[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (IntPtr* ptr = P_0)
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_1))
			{
				result = vIDxBWWHgmNZQRsPVdWoPDazFZyE(ptr, ptr2, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int vIDxBWWHgmNZQRsPVdWoPDazFZyE(void* P_0, void* P_1, int P_2);

	public unsafe static int keNzndDKTkcofuxsaWZKrkjmEAI(IntPtr P_0, euhXPmINiTmiVjNaKTyPGrFaVlA P_1, IntPtr P_2, ref int P_3, int P_4)
	{
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_3))
		{
			result = AnaqjBJnucVpbuemwGLSsMrTZeB((void*)P_0, (int)P_1, (void*)P_2, ptr, P_4);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int AnaqjBJnucVpbuemwGLSsMrTZeB(void* P_0, int P_1, void* P_2, void* P_3, int P_4);
}
