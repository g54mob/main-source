using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Microsoft.WindowsGamingInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class WindowsGamingInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class lyCnLTPmNrLMTfWHaKpYubSYuPAL : IControllerExtensionSource
		{
			private MeGehmGvtoXRlfGQhxxMoBPtYUNiA QkaFAJklPMidTbDydlouHbseCUgCA;

			public MeGehmGvtoXRlfGQhxxMoBPtYUNiA rRmuvxOYKgqqALNziBJXCaPlNwbg => QkaFAJklPMidTbDydlouHbseCUgCA;

			public lyCnLTPmNrLMTfWHaKpYubSYuPAL(MeGehmGvtoXRlfGQhxxMoBPtYUNiA P_0)
			{
				QkaFAJklPMidTbDydlouHbseCUgCA = P_0;
			}
		}

		private lyCnLTPmNrLMTfWHaKpYubSYuPAL zeOFUXsPEknJZWYLSWvUbHIXqlvF;

		private bool dCTxUaEwCuDQrheDReUFYVugafap;

		private Joystick joystick => GetController<Joystick>();

		public DeviceType deviceType => (DeviceType)zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg.zfKAPPUGTkSDwuUzdnCkeMvYkEqT;

		public IntPtr nativePointer
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return IntPtr.Zero;
				}
				if (!dCTxUaEwCuDQrheDReUFYVugafap || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg == null)
				{
					return IntPtr.Zero;
				}
				return zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg.xTDnpDbRuddnzKqFLCSKooAzGtAs;
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
				if (!dCTxUaEwCuDQrheDReUFYVugafap || !base.enabled)
				{
					return string.Empty;
				}
				if (zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg == null)
				{
					return string.Empty;
				}
				return zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg.axCezkHAzUCsdSXPJfWDsSTIznFpA;
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
				if (!dCTxUaEwCuDQrheDReUFYVugafap || !base.enabled)
				{
					return false;
				}
				if (zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg == null)
				{
					return false;
				}
				return zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg.EkRosCSWgyEikbkSCzRhpiqpJTYB;
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
				if (!dCTxUaEwCuDQrheDReUFYVugafap || !base.enabled)
				{
					return string.Empty;
				}
				if (zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg == null)
				{
					return string.Empty;
				}
				return zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg.nmueGiNzabkHvAozaBaeKArAmtMcb;
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
				if (!dCTxUaEwCuDQrheDReUFYVugafap || !base.enabled)
				{
					return 0;
				}
				if (zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg == null)
				{
					return 0;
				}
				return zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg.PZhHSABdhmuDfsDZiEIuMLJMqfdB.vendorId;
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
				if (!dCTxUaEwCuDQrheDReUFYVugafap || !base.enabled)
				{
					return 0;
				}
				if (zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg == null)
				{
					return 0;
				}
				return zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg.PZhHSABdhmuDfsDZiEIuMLJMqfdB.productId;
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
				if (!dCTxUaEwCuDQrheDReUFYVugafap || !base.enabled)
				{
					return 0;
				}
				if (zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg == null)
				{
					return 0;
				}
				return zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg.AvKEkJFpGrzEmPxQqlsNgcubHPIjA;
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
				if (!dCTxUaEwCuDQrheDReUFYVugafap || !base.enabled)
				{
					return 0;
				}
				if (zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg == null)
				{
					return 0;
				}
				return zeOFUXsPEknJZWYLSWvUbHIXqlvF.rRmuvxOYKgqqALNziBJXCaPlNwbg.jCHiboWhOlvXeNcanXSHQYBSwczV;
			}
		}

		internal WindowsGamingInputControllerExtension(MeGehmGvtoXRlfGQhxxMoBPtYUNiA P_0)
			: base(new lyCnLTPmNrLMTfWHaKpYubSYuPAL(P_0))
		{
		}

		private WindowsGamingInputControllerExtension(WindowsGamingInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (dCTxUaEwCuDQrheDReUFYVugafap)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			zeOFUXsPEknJZWYLSWvUbHIXqlvF = source as lyCnLTPmNrLMTfWHaKpYubSYuPAL;
			dCTxUaEwCuDQrheDReUFYVugafap = zeOFUXsPEknJZWYLSWvUbHIXqlvF != null;
		}

		internal override Controller.Extension Clone()
		{
			return new WindowsGamingInputControllerExtension(this);
		}
	}
}
