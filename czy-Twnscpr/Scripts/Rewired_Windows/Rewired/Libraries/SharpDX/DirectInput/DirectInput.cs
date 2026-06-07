using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Rewired.Libraries.SharpDX.DirectInput
{
	internal class DirectInput : nPqfRGHNLzRAGjqsZGckWWPlpCgP
	{
		private static class GetDeviceCountHelper
		{
			private unsafe delegate int DirectInputEnumDevicesDelegate(void* deviceInstance, IntPtr data);

			private static DirectInputEnumDevicesDelegate _callback;

			private static IntPtr _callbackPointer;

			private static int _count;

			public static IntPtr callbackPointer => (IntPtr)0;

			static GetDeviceCountHelper()
			{
			}

			public static int GetCountAndClear()
			{
				return 0;
			}

			public static void Clear()
			{
			}

			private unsafe static int DirectInputEnumDevicesImpl(void* deviceInstance, IntPtr data)
			{
				return 0;
			}
		}

		public DirectInput()
			: base((IntPtr)0)
		{
		}

		public IList<iYRHfEQTvTrbEozKoZeVOgHWeAB> GetDevices()
		{
			return null;
		}

		public IList<iYRHfEQTvTrbEozKoZeVOgHWeAB> GetDevices(OJKEKxCfLqBxZdESWvJYUrRbxxPi deviceClass, gDsBcVmGebEfuDhDYaLckUfDyjuu deviceEnumFlags)
		{
			return null;
		}

		public int GetDeviceCount(OJKEKxCfLqBxZdESWvJYUrRbxxPi deviceClass, gDsBcVmGebEfuDhDYaLckUfDyjuu deviceEnumFlags)
		{
			return 0;
		}

		[PreserveSig]
		private unsafe static extern int CreateDevice_(void* pIDirectInput8, void* rguid, void* lplpDirectInputDevice, void* pUnkOuter);

		[PreserveSig]
		private unsafe static extern int EnumDevices_(void* pIDirectInput8, int dwDevType, void* lpCallback, void* pvRef, int dwFlags);

		internal void CreateDevice(Guid arg0, out IntPtr arg1, nPqfRGHNLzRAGjqsZGckWWPlpCgP arg2)
		{
			arg1 = default(IntPtr);
		}

		internal void EnumDevices(int arg0, LAJcfQGzQIxhbKngpZEmYTSnGGP arg1, IntPtr arg2, gDsBcVmGebEfuDhDYaLckUfDyjuu arg3)
		{
		}
	}
}
