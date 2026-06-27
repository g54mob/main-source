using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Microsoft.WindowsGamingInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class WindowsGamingInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class qLTWnUTopyfGVaLBFEwXiNGAGwgs : IControllerExtensionSource
		{
			private FbLBdpdENtbItJFSSeBTXLBvWCbvA HRdGcWqpENaQJkgkGEzfNaWgYvMd;

			public FbLBdpdENtbItJFSSeBTXLBvWCbvA qOheumECqlPnWyMlZahOqKFpLZVx => HRdGcWqpENaQJkgkGEzfNaWgYvMd;

			public qLTWnUTopyfGVaLBFEwXiNGAGwgs(FbLBdpdENtbItJFSSeBTXLBvWCbvA P_0)
			{
				HRdGcWqpENaQJkgkGEzfNaWgYvMd = P_0;
			}
		}

		private qLTWnUTopyfGVaLBFEwXiNGAGwgs cAZwXWuekvskZJaRjleNbcMZAsZEA;

		private bool igKWrpEdijTKruOFcLmSOKeuebYt;

		private Joystick joystick => GetController<Joystick>();

		public DeviceType deviceType => (DeviceType)cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx.agXfFGjAzlpCcJtjOaahmezCwKYFA;

		public IntPtr nativePointer
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return IntPtr.Zero;
				}
				if (!igKWrpEdijTKruOFcLmSOKeuebYt || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx == null)
				{
					return IntPtr.Zero;
				}
				return cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx.qiElMOhjAwwprXfRemRFacMlbNul;
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
				if (!igKWrpEdijTKruOFcLmSOKeuebYt || !base.enabled)
				{
					return string.Empty;
				}
				if (cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx == null)
				{
					return string.Empty;
				}
				return cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx.nnRvUjKHXPHldIUFuueEQrRIXftR;
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
				if (!igKWrpEdijTKruOFcLmSOKeuebYt || !base.enabled)
				{
					return false;
				}
				if (cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx == null)
				{
					return false;
				}
				return cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx.TivKunAgefcRsdcslHRUblglWDnab;
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
				if (!igKWrpEdijTKruOFcLmSOKeuebYt || !base.enabled)
				{
					return string.Empty;
				}
				if (cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx == null)
				{
					return string.Empty;
				}
				return cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx.utzWgnDQlqYhpZrKDUTtChzEzwsE;
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
				if (!igKWrpEdijTKruOFcLmSOKeuebYt || !base.enabled)
				{
					return 0;
				}
				if (cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx == null)
				{
					return 0;
				}
				return cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx.EkSkBRZXDxzwXtaRFDsXSjRMTqNr.vendorId;
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
				if (!igKWrpEdijTKruOFcLmSOKeuebYt || !base.enabled)
				{
					return 0;
				}
				if (cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx == null)
				{
					return 0;
				}
				return cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx.EkSkBRZXDxzwXtaRFDsXSjRMTqNr.productId;
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
				if (!igKWrpEdijTKruOFcLmSOKeuebYt || !base.enabled)
				{
					return 0;
				}
				if (cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx == null)
				{
					return 0;
				}
				return cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx.ZqXaLSdewiJmomfMLCKKotahPDwX;
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
				if (!igKWrpEdijTKruOFcLmSOKeuebYt || !base.enabled)
				{
					return 0;
				}
				if (cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx == null)
				{
					return 0;
				}
				return cAZwXWuekvskZJaRjleNbcMZAsZEA.qOheumECqlPnWyMlZahOqKFpLZVx.szMrduUyhiAgFMyoQeEsGBCUeDbB;
			}
		}

		internal WindowsGamingInputControllerExtension(FbLBdpdENtbItJFSSeBTXLBvWCbvA P_0)
			: base(new qLTWnUTopyfGVaLBFEwXiNGAGwgs(P_0))
		{
		}

		private WindowsGamingInputControllerExtension(WindowsGamingInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (igKWrpEdijTKruOFcLmSOKeuebYt)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			cAZwXWuekvskZJaRjleNbcMZAsZEA = source as qLTWnUTopyfGVaLBFEwXiNGAGwgs;
			igKWrpEdijTKruOFcLmSOKeuebYt = cAZwXWuekvskZJaRjleNbcMZAsZEA != null;
		}

		internal override Controller.Extension Clone()
		{
			return new WindowsGamingInputControllerExtension(this);
		}
	}
}
