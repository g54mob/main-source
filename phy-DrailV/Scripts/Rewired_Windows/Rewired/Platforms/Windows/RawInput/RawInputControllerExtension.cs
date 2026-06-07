using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.RawInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RawInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class ZmPwBHsQGcQyLxWHQWySHPwTVZF : IControllerExtensionSource
		{
			private ZqcNHBiAbMAIiSHdlbUgIVanoAWG eeosXMBpFqrdKwdEVgrGvnPkTOkf;

			public ZqcNHBiAbMAIiSHdlbUgIVanoAWG ayUvCXyCfGuQLrCsZWEOwszCfnBD => eeosXMBpFqrdKwdEVgrGvnPkTOkf;

			public ZmPwBHsQGcQyLxWHQWySHPwTVZF(ZqcNHBiAbMAIiSHdlbUgIVanoAWG P_0)
			{
				eeosXMBpFqrdKwdEVgrGvnPkTOkf = P_0;
			}
		}

		private ZmPwBHsQGcQyLxWHQWySHPwTVZF pevTJohhKkGzDfpISkzPqrlKrhcMA;

		private bool VvzWdNIirpRaHTuTnEMaaLgmoKlC;

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
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return IntPtr.Zero;
				}
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.lnKkcpRubXrKAKFIUTbYZjNnFZHeA.nEsfysuWNaHxWWYdgAKIhfFNxAtO;
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
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return IntPtr.Zero;
				}
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.cVKgFmURdDDsIZveDtqVVQRvpgYo;
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
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return string.Empty;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return string.Empty;
				}
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.lnKkcpRubXrKAKFIUTbYZjNnFZHeA.bHXXIaSXftOsLmRzVkIpzmMPLvPk;
			}
		}

		public string productName
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return string.Empty;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return string.Empty;
				}
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.mqjctEYgXEfZnYIDMMngJxDYpBhU;
			}
		}

		public string manufacturer
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return string.Empty;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return string.Empty;
				}
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.hjKJnzLrHHJuMHKXDBoYDoKhMPDgb;
			}
		}

		public ushort vendorId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return 0;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return 0;
				}
				return (ushort)pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.rQMHGWBVRINpDkLJvWbkZIiKbMlE;
			}
		}

		public ushort productId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return 0;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return 0;
				}
				return (ushort)pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.nKaqOeNeXtRFQyIiPrSeMOBlIXKe;
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
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return Guid.Empty;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return Guid.Empty;
				}
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.RqoeGgcphJkoXcPusfFTyPTciRntA;
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
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return false;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return false;
				}
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.MpuQBNhsGfnlifDQFONVPCMzxEIi;
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
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return string.Empty;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return string.Empty;
				}
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.iAlThlvTdFBnLFoKOqPsWaWpHQQV;
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
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return -1;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return -1;
				}
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.JXMjYfICPQNpsgKiWhPQLZvNFnkU;
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
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return -1;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return -1;
				}
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.vhLexAlwrxPMJUqylKKRBGvDXZUr;
			}
		}

		public ushort usagePage
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return 0;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return 0;
				}
				return (ushort)pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.lnKkcpRubXrKAKFIUTbYZjNnFZHeA.gSKbQhPhCcxFkHCLeYWmJrvPjhbK.mfmnPLnoKcRvXQLIfmBFbZvcCOM;
			}
		}

		public ushort usage
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return 0;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return 0;
				}
				return (ushort)pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.lnKkcpRubXrKAKFIUTbYZjNnFZHeA.gSKbQhPhCcxFkHCLeYWmJrvPjhbK.cWhBJpdcIExibSMjYHItMpewxpwkA;
			}
		}

		internal RawInputControllerExtension(ZqcNHBiAbMAIiSHdlbUgIVanoAWG P_0)
			: base(new ZmPwBHsQGcQyLxWHQWySHPwTVZF(P_0))
		{
		}

		private RawInputControllerExtension(RawInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (VvzWdNIirpRaHTuTnEMaaLgmoKlC)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			pevTJohhKkGzDfpISkzPqrlKrhcMA = source as ZmPwBHsQGcQyLxWHQWySHPwTVZF;
			VvzWdNIirpRaHTuTnEMaaLgmoKlC = pevTJohhKkGzDfpISkzPqrlKrhcMA != null;
		}

		internal override Controller.Extension Clone()
		{
			return new RawInputControllerExtension(this);
		}
	}
}
