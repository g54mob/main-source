using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.DirectInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class DirectInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class ehTQgFkWDeVkQxmnMIXefICcttnfb : IControllerExtensionSource
		{
			private VrUjHkyKwlgfxGiNlmxxLiWLUcYKA LIyzPoIactkwHnXylHiVCAiJjkox;

			private wVonnxJrAjOgBYCmpMMfUyLSdsGh eeosXMBpFqrdKwdEVgrGvnPkTOkf;

			public VrUjHkyKwlgfxGiNlmxxLiWLUcYKA EJqnnacIsWkFjtZCidzSDEtnLNNd => LIyzPoIactkwHnXylHiVCAiJjkox;

			public wVonnxJrAjOgBYCmpMMfUyLSdsGh ayUvCXyCfGuQLrCsZWEOwszCfnBD => eeosXMBpFqrdKwdEVgrGvnPkTOkf;

			public ehTQgFkWDeVkQxmnMIXefICcttnfb(VrUjHkyKwlgfxGiNlmxxLiWLUcYKA P_0, wVonnxJrAjOgBYCmpMMfUyLSdsGh P_1)
			{
				LIyzPoIactkwHnXylHiVCAiJjkox = P_0;
				eeosXMBpFqrdKwdEVgrGvnPkTOkf = P_1;
			}
		}

		private ehTQgFkWDeVkQxmnMIXefICcttnfb pevTJohhKkGzDfpISkzPqrlKrhcMA;

		private bool VvzWdNIirpRaHTuTnEMaaLgmoKlC;

		private Joystick joystick => GetController<Joystick>();

		public Guid instanceGuid
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.EJqnnacIsWkFjtZCidzSDEtnLNNd.SCGcrIIDMjURHdkJjDIzHoMbvWQHA;
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.EJqnnacIsWkFjtZCidzSDEtnLNNd.RqoeGgcphJkoXcPusfFTyPTciRntA;
			}
		}

		public string instanceName
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.MRgfRfyrShjIzBYFIfiuqlDRKHEK.uDkFaTaDVTBjdRSJBdsDCFFkfZpzb;
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.MRgfRfyrShjIzBYFIfiuqlDRKHEK.mqjctEYgXEfZnYIDMMngJxDYpBhU;
			}
		}

		public Guid forceFeedbackDriverGuid
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.EJqnnacIsWkFjtZCidzSDEtnLNNd.DbgefvVxWdauebYJunQTBDWhHAbg;
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.EJqnnacIsWkFjtZCidzSDEtnLNNd.mfmnPLnoKcRvXQLIfmBFbZvcCOM;
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.EJqnnacIsWkFjtZCidzSDEtnLNNd.cWhBJpdcIExibSMjYHItMpewxpwkA;
			}
		}

		public DirectInputDeviceType deviceType
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return DirectInputDeviceType.Device;
				}
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return DirectInputDeviceType.Device;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return DirectInputDeviceType.Device;
				}
				return (DirectInputDeviceType)pevTJohhKkGzDfpISkzPqrlKrhcMA.EJqnnacIsWkFjtZCidzSDEtnLNNd.dTqvRoWTYLcyxOCegaoAeiVZAPTAb;
			}
		}

		public int deviceSubtype
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.EJqnnacIsWkFjtZCidzSDEtnLNNd.ebFCTPkOlEnQbCtJKheCoOJZNVFj;
			}
		}

		public int rawType
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.EJqnnacIsWkFjtZCidzSDEtnLNNd.NZDEzjphQfkOfvPlOfjUrhXxxjIW;
			}
		}

		public bool isHumanInterfaceDevice
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.EJqnnacIsWkFjtZCidzSDEtnLNNd.gKjYCDHpPPLRttviHQXHXyGrCneo;
			}
		}

		public DirectInputDeviceAxisMode axisMode
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return DirectInputDeviceAxisMode.Absolute;
				}
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return DirectInputDeviceAxisMode.Absolute;
				}
				return (DirectInputDeviceAxisMode)pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.MRgfRfyrShjIzBYFIfiuqlDRKHEK.jxfJmdiVXshlqKpBlHLQatSYpnVb;
			}
		}

		public int bufferSize
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.MRgfRfyrShjIzBYFIfiuqlDRKHEK.WoxRNpwZTblCbWBdvbwlpgPEefrR;
			}
		}

		public Guid classGuid
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.MRgfRfyrShjIzBYFIfiuqlDRKHEK.erHofbdepGArVYYBmMkTGmEBfVae;
			}
		}

		public int forceFeedbackGain
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.MRgfRfyrShjIzBYFIfiuqlDRKHEK.nmTZNUQEZlIHxGxraloeSnuzVBKM;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (VvzWdNIirpRaHTuTnEMaaLgmoKlC && base.enabled)
				{
					pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.MRgfRfyrShjIzBYFIfiuqlDRKHEK.nmTZNUQEZlIHxGxraloeSnuzVBKM = value;
				}
			}
		}

		public string interfacePath
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.MRgfRfyrShjIzBYFIfiuqlDRKHEK.aGTEZUlonAkHkKOAbHOsSHTWgeRP;
			}
		}

		public int joystickId
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
				return pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.MRgfRfyrShjIzBYFIfiuqlDRKHEK.BEwuJlSgrzvnNiHAkXqrckJVpxbD;
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
				return (ushort)pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.MRgfRfyrShjIzBYFIfiuqlDRKHEK.nKaqOeNeXtRFQyIiPrSeMOBlIXKe;
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
				return (ushort)pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.MRgfRfyrShjIzBYFIfiuqlDRKHEK.rQMHGWBVRINpDkLJvWbkZIiKbMlE;
			}
		}

		string IHIDControllerExtension.manufacturer => string.Empty;

		internal DirectInputControllerExtension(VrUjHkyKwlgfxGiNlmxxLiWLUcYKA P_0, wVonnxJrAjOgBYCmpMMfUyLSdsGh P_1)
			: base(new ehTQgFkWDeVkQxmnMIXefICcttnfb(P_0, P_1))
		{
		}

		private DirectInputControllerExtension(DirectInputControllerExtension P_0)
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
			pevTJohhKkGzDfpISkzPqrlKrhcMA = source as ehTQgFkWDeVkQxmnMIXefICcttnfb;
			VvzWdNIirpRaHTuTnEMaaLgmoKlC = pevTJohhKkGzDfpISkzPqrlKrhcMA != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DirectInputControllerExtension(this);
		}
	}
}
