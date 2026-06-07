using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Microsoft.WindowsGamingInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class WindowsGamingInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class aKrfuOsSjnLWBYbFaEjFZiurGnxgA : IControllerExtensionSource
		{
			private TOhoLhSgVsNthvwMxYIJmahKNXwF RuDDjYDUzOzJXODozFTnqIINBVLH;

			public TOhoLhSgVsNthvwMxYIJmahKNXwF geFMfcdeyyZeQmTxqdoUtyfEeOGO => RuDDjYDUzOzJXODozFTnqIINBVLH;

			public aKrfuOsSjnLWBYbFaEjFZiurGnxgA(TOhoLhSgVsNthvwMxYIJmahKNXwF P_0)
			{
				RuDDjYDUzOzJXODozFTnqIINBVLH = P_0;
			}
		}

		private aKrfuOsSjnLWBYbFaEjFZiurGnxgA mtdFOIZYqsarTrIPOrRLOcywpUCm;

		private bool eqifyfrXseRvzCGLRbvOlbKXmwRl;

		private Joystick joystick => GetController<Joystick>();

		public DeviceType deviceType => (DeviceType)mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO.cStqYEtEvcZLoVslppdbJHPhzBDv;

		public IntPtr nativePointer
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return IntPtr.Zero;
				}
				if (!eqifyfrXseRvzCGLRbvOlbKXmwRl || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO == null)
				{
					return IntPtr.Zero;
				}
				return mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO.ifcBgWQjOdqfdfvTRalBTjkWQwnt;
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
				if (!eqifyfrXseRvzCGLRbvOlbKXmwRl || !base.enabled)
				{
					return string.Empty;
				}
				if (mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO == null)
				{
					return string.Empty;
				}
				return mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO.vepomlzZYYodpoZbXfgCbnXrcVwC;
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
				if (!eqifyfrXseRvzCGLRbvOlbKXmwRl || !base.enabled)
				{
					return false;
				}
				if (mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO == null)
				{
					return false;
				}
				return mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO.NONYxxnAwofWcaGqYvECUYYUwAwR;
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
				if (!eqifyfrXseRvzCGLRbvOlbKXmwRl || !base.enabled)
				{
					return string.Empty;
				}
				if (mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO == null)
				{
					return string.Empty;
				}
				return mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO.yxZTnxkqUzRonrKnuDPxleLneJlI;
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
				if (!eqifyfrXseRvzCGLRbvOlbKXmwRl || !base.enabled)
				{
					return 0;
				}
				if (mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO == null)
				{
					return 0;
				}
				return mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO.UpqYCFgQVcecVDHViDhXrufjGfOU.vendorId;
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
				if (!eqifyfrXseRvzCGLRbvOlbKXmwRl || !base.enabled)
				{
					return 0;
				}
				if (mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO == null)
				{
					return 0;
				}
				return mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO.UpqYCFgQVcecVDHViDhXrufjGfOU.productId;
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
				if (!eqifyfrXseRvzCGLRbvOlbKXmwRl || !base.enabled)
				{
					return 0;
				}
				if (mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO == null)
				{
					return 0;
				}
				return mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO.HDdljMAbudAjeQSSqLBMTOQSYLtG;
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
				if (!eqifyfrXseRvzCGLRbvOlbKXmwRl || !base.enabled)
				{
					return 0;
				}
				if (mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO == null)
				{
					return 0;
				}
				return mtdFOIZYqsarTrIPOrRLOcywpUCm.geFMfcdeyyZeQmTxqdoUtyfEeOGO.gpiyUpfxejBViyDgjljKnLpttnUK;
			}
		}

		internal WindowsGamingInputControllerExtension(TOhoLhSgVsNthvwMxYIJmahKNXwF P_0)
			: base(new aKrfuOsSjnLWBYbFaEjFZiurGnxgA(P_0))
		{
		}

		private WindowsGamingInputControllerExtension(WindowsGamingInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (eqifyfrXseRvzCGLRbvOlbKXmwRl)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			mtdFOIZYqsarTrIPOrRLOcywpUCm = source as aKrfuOsSjnLWBYbFaEjFZiurGnxgA;
			eqifyfrXseRvzCGLRbvOlbKXmwRl = mtdFOIZYqsarTrIPOrRLOcywpUCm != null;
		}

		internal override Controller.Extension Clone()
		{
			return new WindowsGamingInputControllerExtension(this);
		}
	}
}
