using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.RawInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RawInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class iuXvqMeuTiOlxeBfItVWcArlgaTR : IControllerExtensionSource
		{
			private iiXzYQFbNcalvxmkeCTYyitoFEOm XVsEJyGQlHhrrvpJNxaLZCqCBckg;

			public iiXzYQFbNcalvxmkeCTYyitoFEOm ieEBfSwaQMEjVyCKFydLDlELTLfK => XVsEJyGQlHhrrvpJNxaLZCqCBckg;

			public iuXvqMeuTiOlxeBfItVWcArlgaTR(iiXzYQFbNcalvxmkeCTYyitoFEOm P_0)
			{
				XVsEJyGQlHhrrvpJNxaLZCqCBckg = P_0;
			}
		}

		private iuXvqMeuTiOlxeBfItVWcArlgaTR NMSQooPSEObAZLSWzfhuXluJakOIA;

		private bool mXRsGcpnOgmlUmjrUZMTYhkgfxuB;

		private Joystick joystick => GetController<Joystick>();

		public IntPtr hidDeviceHandle
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return IntPtr.Zero;
				}
				if (!mXRsGcpnOgmlUmjrUZMTYhkgfxuB || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK == null)
				{
					return IntPtr.Zero;
				}
				return NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK.jOQkRswFrCCFXpFwYrylhXfRLjlw.znTfGmDhBQGUCaTBjJNuppDUVJneA;
			}
		}

		public IntPtr rawInputDeviceHandle
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return IntPtr.Zero;
				}
				if (!mXRsGcpnOgmlUmjrUZMTYhkgfxuB || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK == null)
				{
					return IntPtr.Zero;
				}
				return NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK.sWaCzIhlukJJoEiYfNNIPJhqCBpaA;
			}
		}

		public string devicePath
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!mXRsGcpnOgmlUmjrUZMTYhkgfxuB || !base.enabled)
				{
					return string.Empty;
				}
				if (NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK == null)
				{
					return string.Empty;
				}
				return NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK.jOQkRswFrCCFXpFwYrylhXfRLjlw.lePotDuUSxrPjLKGzjvifAeCInWNA;
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
				if (!mXRsGcpnOgmlUmjrUZMTYhkgfxuB || !base.enabled)
				{
					return string.Empty;
				}
				if (NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK == null)
				{
					return string.Empty;
				}
				return NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK.kHVLroZdzgYbmtCjUQBkmLNvwIAh;
			}
		}

		string IHIDControllerExtension.manufacturer
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!mXRsGcpnOgmlUmjrUZMTYhkgfxuB || !base.enabled)
				{
					return string.Empty;
				}
				if (NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK == null)
				{
					return string.Empty;
				}
				return NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK.bhbTQcjskdtfDavuRdrdXfxlUsnC;
			}
		}

		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!mXRsGcpnOgmlUmjrUZMTYhkgfxuB || !base.enabled)
				{
					return 0;
				}
				if (NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK == null)
				{
					return 0;
				}
				return (ushort)NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK.izTxynPZFQvOiNEtBAmqobeGLRIL;
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
				if (!mXRsGcpnOgmlUmjrUZMTYhkgfxuB || !base.enabled)
				{
					return 0;
				}
				if (NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK == null)
				{
					return 0;
				}
				return (ushort)NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK.yJPKDzzdTMFNGOBOQDLASYBxbecU;
			}
		}

		public Guid productGuid
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return Guid.Empty;
				}
				if (!mXRsGcpnOgmlUmjrUZMTYhkgfxuB || !base.enabled)
				{
					return Guid.Empty;
				}
				if (NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK == null)
				{
					return Guid.Empty;
				}
				return NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK.GwyBEvfTEZeyGrFtYNdeBRCHzPAOb;
			}
		}

		public bool isBluetoothDevice
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (!mXRsGcpnOgmlUmjrUZMTYhkgfxuB || !base.enabled)
				{
					return false;
				}
				if (NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK == null)
				{
					return false;
				}
				return NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK.cmRjyxmQtZdaHTctAEloLaRHsWhh;
			}
		}

		public string bluetoothDeviceName
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!mXRsGcpnOgmlUmjrUZMTYhkgfxuB || !base.enabled)
				{
					return string.Empty;
				}
				if (NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK == null)
				{
					return string.Empty;
				}
				return NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK.xXjjzJOGKVAUsURDmlmlbuXJFSkP;
			}
		}

		public int hubId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				if (!mXRsGcpnOgmlUmjrUZMTYhkgfxuB || !base.enabled)
				{
					return -1;
				}
				if (NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK == null)
				{
					return -1;
				}
				return NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK.fLahaEcsXPMigDjgHetzmeJaMELMc;
			}
		}

		public int portId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				if (!mXRsGcpnOgmlUmjrUZMTYhkgfxuB || !base.enabled)
				{
					return -1;
				}
				if (NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK == null)
				{
					return -1;
				}
				return NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK.wFyfcfCpFVdLnapxaDXatNkaKnDYB;
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
				if (!mXRsGcpnOgmlUmjrUZMTYhkgfxuB || !base.enabled)
				{
					return 0;
				}
				if (NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK == null)
				{
					return 0;
				}
				return (ushort)NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK.jOQkRswFrCCFXpFwYrylhXfRLjlw.yscAgOEnDQymzkLegUfhNMNFaBrSA.uibcHDfzhdqRZANUrvbfmeMNinmCA;
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
				if (!mXRsGcpnOgmlUmjrUZMTYhkgfxuB || !base.enabled)
				{
					return 0;
				}
				if (NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK == null)
				{
					return 0;
				}
				return (ushort)NMSQooPSEObAZLSWzfhuXluJakOIA.ieEBfSwaQMEjVyCKFydLDlELTLfK.jOQkRswFrCCFXpFwYrylhXfRLjlw.yscAgOEnDQymzkLegUfhNMNFaBrSA.jtsrEUxcqofKldDlfSgWjlEzmlTMA;
			}
		}

		internal RawInputControllerExtension(iiXzYQFbNcalvxmkeCTYyitoFEOm P_0)
			: base(new iuXvqMeuTiOlxeBfItVWcArlgaTR(P_0))
		{
		}

		private RawInputControllerExtension(RawInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (mXRsGcpnOgmlUmjrUZMTYhkgfxuB)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			NMSQooPSEObAZLSWzfhuXluJakOIA = source as iuXvqMeuTiOlxeBfItVWcArlgaTR;
			mXRsGcpnOgmlUmjrUZMTYhkgfxuB = NMSQooPSEObAZLSWzfhuXluJakOIA != null;
		}

		internal override Controller.Extension Clone()
		{
			return new RawInputControllerExtension(this);
		}
	}
}
