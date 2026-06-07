using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Libraries.SharpDX.DirectInput
{
	[Guid("bf798031-483a-4da2-aa99-5d64ed369700")]
	internal class DirectInput : wTffSbnzKKVYFFadbCeIXFvuFVC
	{
		private static class GetDeviceCountHelper
		{
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private unsafe delegate int DirectInputEnumDevicesDelegate(void* deviceInstance, IntPtr data);

			private static DirectInputEnumDevicesDelegate _callback;

			private static IntPtr _callbackPointer;

			private static int _count;

			public static IntPtr callbackPointer
			{
				get
				{
					return _callbackPointer;
				}
			}

			public static int count
			{
				get
				{
					return _count;
				}
			}

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
			IntPtr nativePointer;
			ZiTGOLCWZKYlAXioGVHsmqTUHqg.CrDHDhwgozfFmciiEehyINXkhIQG(hqRAtWkFwRMrUFQFfrqkRHWrrJl.RUtOyDvBfqcIhiehjqJqIuNUMbr(null), 2048, QiyhMeApbloIAQYCjGAvUEQIhAz.eJGRPSwwoFMekYKtfHcXZcReBes(typeof(DirectInput)), out nativePointer, null);
			base.NativePointer = nativePointer;
		}

		public IList<vgUDhfmgAmAsRjRuQJnGENONMljC> GetDevices()
		{
			return GetDevices(RSViiCwWYViTGbHemxBsoBfasVd.vvyijmZOzRFtTdippDQZhtsZhGJC, zGfVlsImnYjabwVEyjlINqRCfqKj.MqpnNQSArwvBbxBPWPUNDFAfflD);
		}

		public IList<vgUDhfmgAmAsRjRuQJnGENONMljC> GetDevices(RSViiCwWYViTGbHemxBsoBfasVd deviceClass, zGfVlsImnYjabwVEyjlINqRCfqKj deviceEnumFlags)
		{
			using (ObjectInstanceTracker.Wrapper<nLTSNxieksGyvmfAfHbtKooTjAEd> wrapper = new ObjectInstanceTracker.Wrapper<nLTSNxieksGyvmfAfHbtKooTjAEd>(new nLTSNxieksGyvmfAfHbtKooTjAEd()))
			{
				nLTSNxieksGyvmfAfHbtKooTjAEd instance = wrapper.instance;
				EnumDevices((int)deviceClass, instance.NativePointer, new IntPtr((int)wrapper.instanceId), deviceEnumFlags);
				return instance.DeviceInstances;
			}
		}

		public IList<vgUDhfmgAmAsRjRuQJnGENONMljC> GetDevices(DeviceType deviceType, zGfVlsImnYjabwVEyjlINqRCfqKj deviceEnumFlags)
		{
			using (ObjectInstanceTracker.Wrapper<nLTSNxieksGyvmfAfHbtKooTjAEd> wrapper = new ObjectInstanceTracker.Wrapper<nLTSNxieksGyvmfAfHbtKooTjAEd>(new nLTSNxieksGyvmfAfHbtKooTjAEd()))
			{
				nLTSNxieksGyvmfAfHbtKooTjAEd instance = wrapper.instance;
				EnumDevices((int)deviceType, instance.NativePointer, new IntPtr((int)wrapper.instanceId), deviceEnumFlags);
				return instance.DeviceInstances;
			}
		}

		public int GetDeviceCount(RSViiCwWYViTGbHemxBsoBfasVd deviceClass, zGfVlsImnYjabwVEyjlINqRCfqKj deviceEnumFlags)
		{
			GetDeviceCountHelper.Clear();
			EnumDevices((int)deviceClass, GetDeviceCountHelper.callbackPointer, IntPtr.Zero, deviceEnumFlags);
			return GetDeviceCountHelper.GetCountAndClear();
		}

		public int GetDeviceCount(DeviceType deviceType, zGfVlsImnYjabwVEyjlINqRCfqKj deviceEnumFlags)
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

		internal unsafe void CreateDevice(Guid arg0, out IntPtr arg1, wTffSbnzKKVYFFadbCeIXFvuFVC arg2)
		{
			hbpFHugbKyodFCJCiZcKFruzcGvs hbpFHugbKyodFCJCiZcKFruzcGvs2;
			fixed (IntPtr* lplpDirectInputDevice = &arg1)
			{
				hbpFHugbKyodFCJCiZcKFruzcGvs2 = CreateDevice_(oQrDIzabSXnJeReNAUCNWaVKrkpV, &arg0, lplpDirectInputDevice, (void*)((arg2 == null) ? IntPtr.Zero : arg2.NativePointer));
			}
			hbpFHugbKyodFCJCiZcKFruzcGvs2.moUKMvtdvMYFxCOFvigNjjXmpVy();
		}

		internal unsafe void EnumDevices(int arg0, SeAGUniomhRcypKqLPpGBMfcfTx arg1, IntPtr arg2, zGfVlsImnYjabwVEyjlINqRCfqKj arg3)
		{
			((hbpFHugbKyodFCJCiZcKFruzcGvs)EnumDevices_(oQrDIzabSXnJeReNAUCNWaVKrkpV, arg0, arg1, (void*)arg2, (int)arg3)).moUKMvtdvMYFxCOFvigNjjXmpVy();
		}

		internal unsafe hbpFHugbKyodFCJCiZcKFruzcGvs GetDeviceStatus(Guid arg0)
		{
			return GetDeviceStatus_(oQrDIzabSXnJeReNAUCNWaVKrkpV, &arg0);
		}

		internal unsafe void RunControlPanel(IntPtr arg0, int arg1)
		{
			((hbpFHugbKyodFCJCiZcKFruzcGvs)RunControlPanel_(oQrDIzabSXnJeReNAUCNWaVKrkpV, (void*)arg0, arg1)).moUKMvtdvMYFxCOFvigNjjXmpVy();
		}

		internal unsafe void Initialize(IntPtr arg0, int arg1)
		{
			((hbpFHugbKyodFCJCiZcKFruzcGvs)Initialize_(oQrDIzabSXnJeReNAUCNWaVKrkpV, (void*)arg0, arg1)).moUKMvtdvMYFxCOFvigNjjXmpVy();
		}

		public unsafe Guid FindDevice(Guid arg0, string arg1)
		{
			Guid result = default(Guid);
			((hbpFHugbKyodFCJCiZcKFruzcGvs)FindDevice_(oQrDIzabSXnJeReNAUCNWaVKrkpV, &arg0, arg1, &result)).moUKMvtdvMYFxCOFvigNjjXmpVy();
			return result;
		}

		internal unsafe void EnumDevicesBySemantics(string arg0, ref vEBhnlAVwrpEPIoPBAppKPbqALV arg1, SeAGUniomhRcypKqLPpGBMfcfTx arg2, IntPtr arg3, int arg4)
		{
			vEBhnlAVwrpEPIoPBAppKPbqALV.TNkuUpEDuNCWVINUdUHJoDUoEAXh tNkuUpEDuNCWVINUdUHJoDUoEAXh = default(vEBhnlAVwrpEPIoPBAppKPbqALV.TNkuUpEDuNCWVINUdUHJoDUoEAXh);
			arg1.HcrwktGifgIdRsltvHRKdCoBbCuB(ref tNkuUpEDuNCWVINUdUHJoDUoEAXh);
			hbpFHugbKyodFCJCiZcKFruzcGvs hbpFHugbKyodFCJCiZcKFruzcGvs2 = EnumDevicesBySemantics_(oQrDIzabSXnJeReNAUCNWaVKrkpV, arg0, &tNkuUpEDuNCWVINUdUHJoDUoEAXh, arg2, (void*)arg3, arg4);
			arg1.iUPMOOuRIVgRQsDoMjvIhAmnSUHl(ref tNkuUpEDuNCWVINUdUHJoDUoEAXh);
			hbpFHugbKyodFCJCiZcKFruzcGvs2.moUKMvtdvMYFxCOFvigNjjXmpVy();
		}
	}
}
