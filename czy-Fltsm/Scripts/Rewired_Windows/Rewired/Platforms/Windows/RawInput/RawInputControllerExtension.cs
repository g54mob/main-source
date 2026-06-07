using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.RawInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RawInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class VpkfcmoyLuLLbBfdUnOWiYNmeqCP : IControllerExtensionSource
		{
			private JewImaRENcAhriGkgPvGEgPfnJHyb ibBWPKIjOLrmzCRjRBUTLdiTcRxhA;

			public JewImaRENcAhriGkgPvGEgPfnJHyb VjpSWeuaqOnJRDCGXMBHNjoOsRkn => ibBWPKIjOLrmzCRjRBUTLdiTcRxhA;

			public VpkfcmoyLuLLbBfdUnOWiYNmeqCP(JewImaRENcAhriGkgPvGEgPfnJHyb P_0)
			{
				ibBWPKIjOLrmzCRjRBUTLdiTcRxhA = P_0;
			}
		}

		private VpkfcmoyLuLLbBfdUnOWiYNmeqCP mOxnSODcWODZFckQvTUcDOKYLcHW;

		private bool LmysretWngCbrJezKgwUCEVvPneUA;

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
				if (!LmysretWngCbrJezKgwUCEVvPneUA || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn == null)
				{
					return IntPtr.Zero;
				}
				return mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn.IMnQrWwmjOrMJOpkYIBxGzJAmxkgA.CWePsONqFYJrIiPJfggylSnHDami;
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
				if (!LmysretWngCbrJezKgwUCEVvPneUA || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn == null)
				{
					return IntPtr.Zero;
				}
				return mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn.RdBPumndyiTIaxpKvywIPlRdSDeQ;
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
				if (!LmysretWngCbrJezKgwUCEVvPneUA || !base.enabled)
				{
					return string.Empty;
				}
				if (mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn == null)
				{
					return string.Empty;
				}
				return mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn.IMnQrWwmjOrMJOpkYIBxGzJAmxkgA.GxobafabAbpYxyCInTMkSLSRAzZbA;
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
				if (!LmysretWngCbrJezKgwUCEVvPneUA || !base.enabled)
				{
					return string.Empty;
				}
				if (mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn == null)
				{
					return string.Empty;
				}
				return mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn.VhebEQKXpmCJgYSzUThqlsfqMoVkA;
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
				if (!LmysretWngCbrJezKgwUCEVvPneUA || !base.enabled)
				{
					return string.Empty;
				}
				if (mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn == null)
				{
					return string.Empty;
				}
				return mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn.KGKfSGfhihPoTaTvZpYhkVDulWsxA;
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
				if (!LmysretWngCbrJezKgwUCEVvPneUA || !base.enabled)
				{
					return 0;
				}
				if (mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn == null)
				{
					return 0;
				}
				return (ushort)mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn.ZmTpVjBHdSymNuhkHzqHwAFRNBHe;
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
				if (!LmysretWngCbrJezKgwUCEVvPneUA || !base.enabled)
				{
					return 0;
				}
				if (mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn == null)
				{
					return 0;
				}
				return (ushort)mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn.ZPmGRXCxBEwOQOdOWCuUXGtyzwneA;
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
				if (!LmysretWngCbrJezKgwUCEVvPneUA || !base.enabled)
				{
					return Guid.Empty;
				}
				if (mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn == null)
				{
					return Guid.Empty;
				}
				return mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn.vSXXdZFcWHtbAwOjUQJqVgkyjHVT;
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
				if (!LmysretWngCbrJezKgwUCEVvPneUA || !base.enabled)
				{
					return false;
				}
				if (mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn == null)
				{
					return false;
				}
				return mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn.RYehePePOJhoDoBdQdzwgDtYfmccb;
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
				if (!LmysretWngCbrJezKgwUCEVvPneUA || !base.enabled)
				{
					return string.Empty;
				}
				if (mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn == null)
				{
					return string.Empty;
				}
				return mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn.WBMgidYMSTZBedYHaRzndjzWWXzi;
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
				if (!LmysretWngCbrJezKgwUCEVvPneUA || !base.enabled)
				{
					return -1;
				}
				if (mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn == null)
				{
					return -1;
				}
				return mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn.CcFjusiPCDrcqAdueYjvoynTMnAl;
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
				if (!LmysretWngCbrJezKgwUCEVvPneUA || !base.enabled)
				{
					return -1;
				}
				if (mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn == null)
				{
					return -1;
				}
				return mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn.TGDnMXhNOFSHvAzlRqbwVGKVbpGL;
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
				if (!LmysretWngCbrJezKgwUCEVvPneUA || !base.enabled)
				{
					return 0;
				}
				if (mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn == null)
				{
					return 0;
				}
				return (ushort)mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn.IMnQrWwmjOrMJOpkYIBxGzJAmxkgA.JuBzyupRnChnVoqFgGehMxJGZJqC.HFQlMhnHnhNAVzmIloAhwpeYEtvCA;
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
				if (!LmysretWngCbrJezKgwUCEVvPneUA || !base.enabled)
				{
					return 0;
				}
				if (mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn == null)
				{
					return 0;
				}
				return (ushort)mOxnSODcWODZFckQvTUcDOKYLcHW.VjpSWeuaqOnJRDCGXMBHNjoOsRkn.IMnQrWwmjOrMJOpkYIBxGzJAmxkgA.JuBzyupRnChnVoqFgGehMxJGZJqC.AhJAPyxVgqBvfsytfXQWrPiqjOAh;
			}
		}

		internal RawInputControllerExtension(JewImaRENcAhriGkgPvGEgPfnJHyb P_0)
			: base(new VpkfcmoyLuLLbBfdUnOWiYNmeqCP(P_0))
		{
		}

		private RawInputControllerExtension(RawInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (LmysretWngCbrJezKgwUCEVvPneUA)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			mOxnSODcWODZFckQvTUcDOKYLcHW = source as VpkfcmoyLuLLbBfdUnOWiYNmeqCP;
			LmysretWngCbrJezKgwUCEVvPneUA = mOxnSODcWODZFckQvTUcDOKYLcHW != null;
		}

		internal override Controller.Extension Clone()
		{
			return new RawInputControllerExtension(this);
		}
	}
}
