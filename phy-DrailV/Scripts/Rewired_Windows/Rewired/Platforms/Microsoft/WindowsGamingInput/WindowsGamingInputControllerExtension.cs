using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Microsoft.WindowsGamingInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class WindowsGamingInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class qncBrfjubQuLwAAzmcQtEPucXDReB : IControllerExtensionSource
		{
			private NPcbXYOMZTPjQpCotxkrcLlyrqWf eeosXMBpFqrdKwdEVgrGvnPkTOkf;

			public NPcbXYOMZTPjQpCotxkrcLlyrqWf ayUvCXyCfGuQLrCsZWEOwszCfnBD => eeosXMBpFqrdKwdEVgrGvnPkTOkf;

			public qncBrfjubQuLwAAzmcQtEPucXDReB(NPcbXYOMZTPjQpCotxkrcLlyrqWf P_0)
			{
				eeosXMBpFqrdKwdEVgrGvnPkTOkf = P_0;
			}
		}

		private qncBrfjubQuLwAAzmcQtEPucXDReB pevTJohhKkGzDfpISkzPqrlKrhcMA;

		private bool VvzWdNIirpRaHTuTnEMaaLgmoKlC;

		private Joystick joystick => GetController<Joystick>();

		public DeviceType deviceType => (DeviceType)pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.mgfmGZeLtXcIMfABdmrEeVZBiEBOB;

		public IntPtr nativePointer
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.GMaPHoiZAJyngdXeSoVFwLOeWHKm;
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
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return string.Empty;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return string.Empty;
				}
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.OSGjBtbldsvIQyOXzCJTrPKUUWsJ;
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
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return false;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return false;
				}
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.eLlcrJOwFlViywbcvjzhiitnzokq;
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.ZyBJVlNnRXiQSTOwYGZhHQaVFLJNA;
			}
		}

		string IHIDControllerExtension.manufacturer => string.Empty;

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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.XBuLKAjGqIEkVdiRHWjHoeXsEiVeA.vendorId;
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.XBuLKAjGqIEkVdiRHWjHoeXsEiVeA.productId;
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
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return 0;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return 0;
				}
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.mfmnPLnoKcRvXQLIfmBFbZvcCOM;
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
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return 0;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return 0;
				}
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.cWhBJpdcIExibSMjYHItMpewxpwkA;
			}
		}

		internal WindowsGamingInputControllerExtension(NPcbXYOMZTPjQpCotxkrcLlyrqWf P_0)
			: base(new qncBrfjubQuLwAAzmcQtEPucXDReB(P_0))
		{
		}

		private WindowsGamingInputControllerExtension(WindowsGamingInputControllerExtension P_0)
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
			pevTJohhKkGzDfpISkzPqrlKrhcMA = source as qncBrfjubQuLwAAzmcQtEPucXDReB;
			VvzWdNIirpRaHTuTnEMaaLgmoKlC = pevTJohhKkGzDfpISkzPqrlKrhcMA != null;
		}

		internal override Controller.Extension Clone()
		{
			return new WindowsGamingInputControllerExtension(this);
		}
	}
}
