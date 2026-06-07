using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class YFyirHXCUIAtMLuBQgkkBdrFZkIvA
{
	public unsafe static int lcHRDtPeeFSnTRRvSWLuRlgzMSRf(bsNnECEFMHdldJJWacMcQltGyCqmA[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (bsNnECEFMHdldJJWacMcQltGyCqmA* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = IqBLDDLhQoupUTqauZHZyNVwnusq(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int IqBLDDLhQoupUTqauZHZyNVwnusq(void* P_0, void* P_1, int P_2);

	public unsafe static int DwprhCsqxIuxtfZspjUdJuzGeGjf(dBoezRaOXKAyUcnLKZAgWnDGhYPsb[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (dBoezRaOXKAyUcnLKZAgWnDGhYPsb* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = mfXgUxofvTzkZlOVWWFdFsImidHt(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int mfXgUxofvTzkZlOVWWFdFsImidHt(void* P_0, void* P_1, int P_2);

	public unsafe static int TWIVxbWnNHuSJyVnpHZKjqVUhvRW(IntPtr P_0, LNCjvqsZnUmKGzQejOzrfoGyiMNs P_1, IntPtr P_2, ref int P_3)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = LWebTjenugicOFzpjaCgMenwiZqR((void*)P_0, (int)P_1, (void*)P_2, ptr2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int LWebTjenugicOFzpjaCgMenwiZqR(void* P_0, int P_1, void* P_2, void* P_3);

	public unsafe static FKpUUKpxWqVWVqLSTppLuedJkJtg WpMgPVjlzoPHpVzOOoruGMkUFzcI(dBoezRaOXKAyUcnLKZAgWnDGhYPsb[] P_0, int P_1, int P_2)
	{
		FKpUUKpxWqVWVqLSTppLuedJkJtg result;
		fixed (dBoezRaOXKAyUcnLKZAgWnDGhYPsb* ptr = P_0)
		{
			void* ptr2 = ptr;
			result = ziVZlyefQtNdtEwBJveAHrnbjtKG(ptr2, P_1, P_2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern FKpUUKpxWqVWVqLSTppLuedJkJtg ziVZlyefQtNdtEwBJveAHrnbjtKG(void* P_0, int P_1, int P_2);

	public unsafe static int hMeScaxaRxNWFiESpdaHIdXWuMMJA(TiTouRGUQDLgWdlwKFrcffKhCPnU[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (TiTouRGUQDLgWdlwKFrcffKhCPnU* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = DxZlKpEBSTfwBeUgWBsxQwYPgNeAA(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int DxZlKpEBSTfwBeUgWBsxQwYPgNeAA(void* P_0, void* P_1, int P_2);

	public unsafe static int YUXaaUNBjBGBuRoEbFqJjwUEnGCNA(IntPtr P_0, UmfBUgKdfqwLGKigPatEDBXClFKtA P_1, IntPtr P_2, ref int P_3, int P_4)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = umqtToVOCBsFiNFLtbxDxWJpulDF((void*)P_0, (int)P_1, (void*)P_2, ptr2, P_4);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int umqtToVOCBsFiNFLtbxDxWJpulDF(void* P_0, int P_1, void* P_2, void* P_3, int P_4);
}
