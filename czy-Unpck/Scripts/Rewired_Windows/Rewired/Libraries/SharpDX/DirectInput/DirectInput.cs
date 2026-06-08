using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Libraries.SharpDX.DirectInput
{
	[Guid("bf798031-483a-4da2-aa99-5d64ed369700")]
	internal class DirectInput : thUdjkhtsoEtlHZFTxVMIBAaDZoG
	{
		private static class GetDeviceCountHelper
		{
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private unsafe delegate int DirectInputEnumDevicesDelegate(void* deviceInstance, IntPtr data);

			private static DirectInputEnumDevicesDelegate _callback;

			private static IntPtr _callbackPointer;

			private static int _count;

			public static IntPtr callbackPointer => _callbackPointer;

			public static int count => _count;

			unsafe static GetDeviceCountHelper()
			{
				_callback = DirectInputEnumDevicesImpl;
				_callbackPointer = Marshal.GetFunctionPointerForDelegate((Delegate)_callback);
			}

			public static int GetCountAndClear()
			{
				int result = _count;
				Clear();
				return result;
			}

			public static void Clear()
			{
				_count = 0;
			}

			[MonoPInvokeCallback(typeof(DirectInputEnumDevicesDelegate))]
			private unsafe static int DirectInputEnumDevicesImpl(void* deviceInstance, IntPtr data)
			{
				_count++;
				return 1;
			}
		}

		public DirectInput()
			: base(IntPtr.Zero)
		{
			OhsuESEQbitcqTuIgjUyjXyCUNE.ZjczBieoCLMtQmOWoyxmCYkiEKs(ixegfHBaMxnBoCPrkXxioKnitVNp.IuAwvUdBDYyPPecBZcYuZGwOpdP(null), 2048, XhNUbpKnHPBQaARiBNUpPFpGECJ.fptDFZDgIbRuErYVNLSLMGyyTaQi(typeof(DirectInput)), out var nativePointer, null);
			base.NativePointer = nativePointer;
		}

		public IList<wgrxsaianMUzjNMhgoWaIreVzBL> GetDevices()
		{
			return GetDevices(IskHyHopihCGsdgjIPsutxCiveF.ePJfrrDTvzTxHjRlLDJUwDDFEdY, evIrXdYCByIHJkTsSgfSGumEcIq.TxQKbEMMgIITdfFrgOISMeidQbB);
		}

		public IList<wgrxsaianMUzjNMhgoWaIreVzBL> GetDevices(IskHyHopihCGsdgjIPsutxCiveF deviceClass, evIrXdYCByIHJkTsSgfSGumEcIq deviceEnumFlags)
		{
			using (ObjectInstanceTracker.Wrapper<sRgeWweVKGXQPqleXxsdDRFRGKuK> wrapper = new ObjectInstanceTracker.Wrapper<sRgeWweVKGXQPqleXxsdDRFRGKuK>(new sRgeWweVKGXQPqleXxsdDRFRGKuK()))
			{
				sRgeWweVKGXQPqleXxsdDRFRGKuK instance = wrapper.instance;
				EnumDevices((int)deviceClass, instance.NativePointer, new IntPtr((int)wrapper.instanceId), deviceEnumFlags);
				return instance.DeviceInstances;
			}
		}

		public IList<wgrxsaianMUzjNMhgoWaIreVzBL> GetDevices(DeviceType deviceType, evIrXdYCByIHJkTsSgfSGumEcIq deviceEnumFlags)
		{
			using (ObjectInstanceTracker.Wrapper<sRgeWweVKGXQPqleXxsdDRFRGKuK> wrapper = new ObjectInstanceTracker.Wrapper<sRgeWweVKGXQPqleXxsdDRFRGKuK>(new sRgeWweVKGXQPqleXxsdDRFRGKuK()))
			{
				sRgeWweVKGXQPqleXxsdDRFRGKuK instance = wrapper.instance;
				EnumDevices((int)deviceType, instance.NativePointer, new IntPtr((int)wrapper.instanceId), deviceEnumFlags);
				return instance.DeviceInstances;
			}
		}

		public int GetDeviceCount(IskHyHopihCGsdgjIPsutxCiveF deviceClass, evIrXdYCByIHJkTsSgfSGumEcIq deviceEnumFlags)
		{
			GetDeviceCountHelper.Clear();
			EnumDevices((int)deviceClass, GetDeviceCountHelper.callbackPointer, IntPtr.Zero, deviceEnumFlags);
			return GetDeviceCountHelper.GetCountAndClear();
		}

		public int GetDeviceCount(DeviceType deviceType, evIrXdYCByIHJkTsSgfSGumEcIq deviceEnumFlags)
		{
			GetDeviceCountHelper.Clear();
			EnumDevices((int)deviceType, GetDeviceCountHelper.callbackPointer, IntPtr.Zero, deviceEnumFlags);
			return GetDeviceCountHelper.GetCountAndClear();
		}

		public bool IsDeviceAttached(Guid deviceGuid)
		{
			return GetDeviceStatus(deviceGuid).Code == 0;
		}

		public void RunControlPanel()
		{
			RunControlPanel(IntPtr.Zero);
		}

		public void RunControlPanel(IntPtr handle)
		{
			RunControlPanel(handle, 0);
		}

		[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_Create")]
		[SuppressUnmanagedCodeSecurity]
		private unsafe static extern int Create_(void* hinst, int dwVersion, void* riidltf, void* ppvOut, void* punkOuter);

		[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_Release")]
		[SuppressUnmanagedCodeSecurity]
		private unsafe static extern void Release_(void* pIDirectInput8);

		[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_CreateDevice")]
		[SuppressUnmanagedCodeSecurity]
		private unsafe static extern int CreateDevice_(void* pIDirectInput8, void* rguid, void* lplpDirectInputDevice, void* pUnkOuter);

		[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_EnumDevices")]
		[SuppressUnmanagedCodeSecurity]
		private unsafe static extern int EnumDevices_(void* pIDirectInput8, int dwDevType, void* lpCallback, void* pvRef, int dwFlags);

		[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_GetDeviceStatus")]
		[SuppressUnmanagedCodeSecurity]
		private unsafe static extern int GetDeviceStatus_(void* pIDirectInput8, void* rguidInstance);

		[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_RunControlPanel")]
		[SuppressUnmanagedCodeSecurity]
		private unsafe static extern int RunControlPanel_(void* pIDirectInput8, void* hwndOwner, int dwFlags);

		[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_Initialize")]
		[SuppressUnmanagedCodeSecurity]
		private unsafe static extern int Initialize_(void* pIDirectInput8, void* hinst, int dwVersion);

		[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_FindDevice")]
		[SuppressUnmanagedCodeSecurity]
		private unsafe static extern int FindDevice_(void* pIDirectInput8, void* rguidClass, string ptszName, void* pguidInstance);

		[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_EnumDevicesBySemantics")]
		[SuppressUnmanagedCodeSecurity]
		private unsafe static extern int EnumDevicesBySemantics_(void* pIDirectInput8, string ptszUserName, void* lpdiActionFormat, void* lpCallback, void* pvRef, int dwFlags);

		[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_ConfigureDevices")]
		[SuppressUnmanagedCodeSecurity]
		private unsafe static extern int ConfigureDevices_(void* pIDirectInput8, void* lpdiCallback, void* lpdiCDParams, int dwFlags, void* pvRefData);

		public DirectInput(IntPtr nativePtr)
			: base(nativePtr)
		{
		}

		public static explicit operator DirectInput(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new DirectInput(nativePointer);
			}
			return null;
		}

		internal unsafe void CreateDevice(Guid arg0, out IntPtr arg1, thUdjkhtsoEtlHZFTxVMIBAaDZoG arg2)
		{
			oAEDXrvvcKPxxNzmMhHOiHFnkWH oAEDXrvvcKPxxNzmMhHOiHFnkWH2;
			fixed (IntPtr* lplpDirectInputDevice = &arg1)
			{
				oAEDXrvvcKPxxNzmMhHOiHFnkWH2 = CreateDevice_(tkIGqgtIwxjuCkXnyDpVvseOkZD, &arg0, lplpDirectInputDevice, (void*)(arg2?.NativePointer ?? IntPtr.Zero));
			}
			oAEDXrvvcKPxxNzmMhHOiHFnkWH2.rBjEEuvDwijxDKhOHvBTwwhsJGG();
		}

		internal unsafe void EnumDevices(int arg0, JrlAepcSXTIIqpSjqaGLMMoxDFC arg1, IntPtr arg2, evIrXdYCByIHJkTsSgfSGumEcIq arg3)
		{
			((oAEDXrvvcKPxxNzmMhHOiHFnkWH)EnumDevices_(tkIGqgtIwxjuCkXnyDpVvseOkZD, arg0, arg1, (void*)arg2, (int)arg3)).rBjEEuvDwijxDKhOHvBTwwhsJGG();
		}

		internal unsafe oAEDXrvvcKPxxNzmMhHOiHFnkWH GetDeviceStatus(Guid arg0)
		{
			return GetDeviceStatus_(tkIGqgtIwxjuCkXnyDpVvseOkZD, &arg0);
		}

		internal unsafe void RunControlPanel(IntPtr arg0, int arg1)
		{
			((oAEDXrvvcKPxxNzmMhHOiHFnkWH)RunControlPanel_(tkIGqgtIwxjuCkXnyDpVvseOkZD, (void*)arg0, arg1)).rBjEEuvDwijxDKhOHvBTwwhsJGG();
		}

		internal unsafe void Initialize(IntPtr arg0, int arg1)
		{
			((oAEDXrvvcKPxxNzmMhHOiHFnkWH)Initialize_(tkIGqgtIwxjuCkXnyDpVvseOkZD, (void*)arg0, arg1)).rBjEEuvDwijxDKhOHvBTwwhsJGG();
		}

		public unsafe Guid FindDevice(Guid arg0, string arg1)
		{
			Guid result = default(Guid);
			((oAEDXrvvcKPxxNzmMhHOiHFnkWH)FindDevice_(tkIGqgtIwxjuCkXnyDpVvseOkZD, &arg0, arg1, &result)).rBjEEuvDwijxDKhOHvBTwwhsJGG();
			return result;
		}

		internal unsafe void EnumDevicesBySemantics(string arg0, ref osixgNMAFgmzIEbffszGFUvmJbo arg1, JrlAepcSXTIIqpSjqaGLMMoxDFC arg2, IntPtr arg3, int arg4)
		{
			osixgNMAFgmzIEbffszGFUvmJbo.gwUBPksJFQkXEHpyMfvYGgWoicG gwUBPksJFQkXEHpyMfvYGgWoicG = default(osixgNMAFgmzIEbffszGFUvmJbo.gwUBPksJFQkXEHpyMfvYGgWoicG);
			arg1.MqUkfoKMJIDnrkqFTUMSmSTDSPE(ref gwUBPksJFQkXEHpyMfvYGgWoicG);
			oAEDXrvvcKPxxNzmMhHOiHFnkWH oAEDXrvvcKPxxNzmMhHOiHFnkWH2 = EnumDevicesBySemantics_(tkIGqgtIwxjuCkXnyDpVvseOkZD, arg0, &gwUBPksJFQkXEHpyMfvYGgWoicG, arg2, (void*)arg3, arg4);
			arg1.xAiYGFiksjbMgmeEcyaSPpLxCyz(ref gwUBPksJFQkXEHpyMfvYGgWoicG);
			oAEDXrvvcKPxxNzmMhHOiHFnkWH2.rBjEEuvDwijxDKhOHvBTwwhsJGG();
		}
	}
}
