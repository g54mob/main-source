using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.XInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class XInputControllerExtension : Controller.Extension
	{
		private class SMgVLtQonsjUgotTJVnQOKwoZXTS : IControllerExtensionSource
		{
			private YRWshAzrzpyrkrqnhWtbeAGqyKfV.VHgaDakdqWdcmvuykvNEAklCFnKv eBPjjNAkBnXxeKnGgfvzEqLjBjJib;

			public YRWshAzrzpyrkrqnhWtbeAGqyKfV.VHgaDakdqWdcmvuykvNEAklCFnKv vwmxzlGsalxEPrraHHpoIcrfnrTd => eBPjjNAkBnXxeKnGgfvzEqLjBjJib;

			public SMgVLtQonsjUgotTJVnQOKwoZXTS(YRWshAzrzpyrkrqnhWtbeAGqyKfV.VHgaDakdqWdcmvuykvNEAklCFnKv P_0)
			{
				eBPjjNAkBnXxeKnGgfvzEqLjBjJib = P_0;
			}
		}

		private SMgVLtQonsjUgotTJVnQOKwoZXTS HZbBkUdkHTlFjhqlIHHEqtTWVMby;

		private bool zagqoMfxqaxYQeXDyOvjyxhomeLO;

		private Joystick joystick => GetController<Joystick>();

		public int userIndex
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!zagqoMfxqaxYQeXDyOvjyxhomeLO || !base.enabled)
				{
					return 0;
				}
				if (HZbBkUdkHTlFjhqlIHHEqtTWVMby.vwmxzlGsalxEPrraHHpoIcrfnrTd == null)
				{
					return 0;
				}
				return (int)HZbBkUdkHTlFjhqlIHHEqtTWVMby.vwmxzlGsalxEPrraHHpoIcrfnrTd.nQVneCwOOYujmDNTyDoSQFAitjLk.SOESINZMSAfLwinVHNgGANoAatZPc;
			}
		}

		public CapabilityFlags capabilityFlags
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return CapabilityFlags.None;
				}
				if (!zagqoMfxqaxYQeXDyOvjyxhomeLO || !base.enabled)
				{
					return CapabilityFlags.None;
				}
				if (HZbBkUdkHTlFjhqlIHHEqtTWVMby.vwmxzlGsalxEPrraHHpoIcrfnrTd == null)
				{
					return CapabilityFlags.None;
				}
				HZbBkUdkHTlFjhqlIHHEqtTWVMby.vwmxzlGsalxEPrraHHpoIcrfnrTd.nQVneCwOOYujmDNTyDoSQFAitjLk.QFtuuaWeDDigXkKIoYCFgQMuAOb(YVCcwitYsBdSvvMxHdOQeNajSotYA.Any, out var hdvoYbCLQdebKTTSvQwTBcsTYXti2);
				return (CapabilityFlags)hdvoYbCLQdebKTTSvQwTBcsTYXti2.wCGfeKBfAmwpbUIcAmFsChHHuEIXB;
			}
		}

		public DeviceType deviceType
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return (DeviceType)0;
				}
				if (!zagqoMfxqaxYQeXDyOvjyxhomeLO || !base.enabled)
				{
					return (DeviceType)0;
				}
				if (HZbBkUdkHTlFjhqlIHHEqtTWVMby.vwmxzlGsalxEPrraHHpoIcrfnrTd == null)
				{
					return (DeviceType)0;
				}
				HZbBkUdkHTlFjhqlIHHEqtTWVMby.vwmxzlGsalxEPrraHHpoIcrfnrTd.nQVneCwOOYujmDNTyDoSQFAitjLk.QFtuuaWeDDigXkKIoYCFgQMuAOb(YVCcwitYsBdSvvMxHdOQeNajSotYA.Any, out var hdvoYbCLQdebKTTSvQwTBcsTYXti2);
				return (DeviceType)hdvoYbCLQdebKTTSvQwTBcsTYXti2.GgkVMuqaMlWMZdwjaIXYLFDEjqHr;
			}
		}

		public DeviceSubType deviceSubType
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return (DeviceSubType)0;
				}
				if (!zagqoMfxqaxYQeXDyOvjyxhomeLO || !base.enabled)
				{
					return (DeviceSubType)0;
				}
				if (HZbBkUdkHTlFjhqlIHHEqtTWVMby.vwmxzlGsalxEPrraHHpoIcrfnrTd == null)
				{
					return (DeviceSubType)0;
				}
				HZbBkUdkHTlFjhqlIHHEqtTWVMby.vwmxzlGsalxEPrraHHpoIcrfnrTd.nQVneCwOOYujmDNTyDoSQFAitjLk.QFtuuaWeDDigXkKIoYCFgQMuAOb(YVCcwitYsBdSvvMxHdOQeNajSotYA.Any, out var hdvoYbCLQdebKTTSvQwTBcsTYXti2);
				return (DeviceSubType)hdvoYbCLQdebKTTSvQwTBcsTYXti2.dEFIXUOJKWDUBBorzicSIXXgqBYC;
			}
		}

		internal XInputControllerExtension(YRWshAzrzpyrkrqnhWtbeAGqyKfV.VHgaDakdqWdcmvuykvNEAklCFnKv P_0)
			: base(new SMgVLtQonsjUgotTJVnQOKwoZXTS(P_0))
		{
		}

		private XInputControllerExtension(XInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (zagqoMfxqaxYQeXDyOvjyxhomeLO)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			HZbBkUdkHTlFjhqlIHHEqtTWVMby = source as SMgVLtQonsjUgotTJVnQOKwoZXTS;
			zagqoMfxqaxYQeXDyOvjyxhomeLO = HZbBkUdkHTlFjhqlIHHEqtTWVMby != null;
		}

		internal override Controller.Extension Clone()
		{
			return new XInputControllerExtension(this);
		}
	}
}
