using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Microsoft.WindowsGamingInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class WindowsGamingInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class JtJNNiDUiskxjxPUzepDvrGWlaDx : IControllerExtensionSource
		{
			private sFFXXFtEebhJcIFEaMaPQTQrWwKC khxokawHqNhXftYjigHjWleesAfn;

			public sFFXXFtEebhJcIFEaMaPQTQrWwKC TZfgWGQSjbRCoZQmrFaYTeHdUJaq => khxokawHqNhXftYjigHjWleesAfn;

			public JtJNNiDUiskxjxPUzepDvrGWlaDx(sFFXXFtEebhJcIFEaMaPQTQrWwKC P_0)
			{
				khxokawHqNhXftYjigHjWleesAfn = P_0;
			}
		}

		private JtJNNiDUiskxjxPUzepDvrGWlaDx XeZQxmiAztsBlYQOBShFmKONJceX;

		private bool PhYPRBCxdlJbVnuQAVdAFGsyfntAA;

		private Joystick joystick => GetController<Joystick>();

		public DeviceType deviceType => (DeviceType)XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq.RYXEhaYponftQkccoSjnHvzGrSxiA;

		public IntPtr nativePointer
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return IntPtr.Zero;
				}
				if (!PhYPRBCxdlJbVnuQAVdAFGsyfntAA || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq == null)
				{
					return IntPtr.Zero;
				}
				return XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq.HpKZbyrpVsXbLQmWWjBLpcEhCpLX;
			}
		}

		public string nonRoamableId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!PhYPRBCxdlJbVnuQAVdAFGsyfntAA || !base.enabled)
				{
					return string.Empty;
				}
				if (XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq == null)
				{
					return string.Empty;
				}
				return XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq.CuRDJQSCuLGRAZEyAhMJLLYUtIkb;
			}
		}

		public bool isWireless
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (!PhYPRBCxdlJbVnuQAVdAFGsyfntAA || !base.enabled)
				{
					return false;
				}
				if (XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq == null)
				{
					return false;
				}
				return XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq.qglCSRJCjlygWerpHoAWVcelQXAjA;
			}
		}

		string IHIDControllerExtension.productName
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!PhYPRBCxdlJbVnuQAVdAFGsyfntAA || !base.enabled)
				{
					return string.Empty;
				}
				if (XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq == null)
				{
					return string.Empty;
				}
				return XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq.DermERFDDuknNAWqrwNxFHjOdvDY;
			}
		}

		string IHIDControllerExtension.manufacturer => string.Empty;

		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!PhYPRBCxdlJbVnuQAVdAFGsyfntAA || !base.enabled)
				{
					return 0;
				}
				if (XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq == null)
				{
					return 0;
				}
				return XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq.nEIczxaNOfZCxCgYfmrTLVPGboagA.vendorId;
			}
		}

		ushort IHIDControllerExtension.productId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!PhYPRBCxdlJbVnuQAVdAFGsyfntAA || !base.enabled)
				{
					return 0;
				}
				if (XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq == null)
				{
					return 0;
				}
				return XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq.nEIczxaNOfZCxCgYfmrTLVPGboagA.productId;
			}
		}

		ushort IHIDControllerExtension.usagePage
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!PhYPRBCxdlJbVnuQAVdAFGsyfntAA || !base.enabled)
				{
					return 0;
				}
				if (XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq == null)
				{
					return 0;
				}
				return XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq.kiDSdkbzMqkDGxBHzZPUxeefBILG;
			}
		}

		ushort IHIDControllerExtension.usage
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!PhYPRBCxdlJbVnuQAVdAFGsyfntAA || !base.enabled)
				{
					return 0;
				}
				if (XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq == null)
				{
					return 0;
				}
				return XeZQxmiAztsBlYQOBShFmKONJceX.TZfgWGQSjbRCoZQmrFaYTeHdUJaq.ZzENLLMftgjvWPitmqzCZEBAcsyT;
			}
		}

		internal WindowsGamingInputControllerExtension(sFFXXFtEebhJcIFEaMaPQTQrWwKC P_0)
			: base(new JtJNNiDUiskxjxPUzepDvrGWlaDx(P_0))
		{
		}

		private WindowsGamingInputControllerExtension(WindowsGamingInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (PhYPRBCxdlJbVnuQAVdAFGsyfntAA)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			XeZQxmiAztsBlYQOBShFmKONJceX = source as JtJNNiDUiskxjxPUzepDvrGWlaDx;
			PhYPRBCxdlJbVnuQAVdAFGsyfntAA = XeZQxmiAztsBlYQOBShFmKONJceX != null;
		}

		internal override Controller.Extension Clone()
		{
			return new WindowsGamingInputControllerExtension(this);
		}
	}
}
