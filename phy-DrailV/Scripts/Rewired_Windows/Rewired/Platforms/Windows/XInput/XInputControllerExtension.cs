using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.XInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class XInputControllerExtension : Controller.Extension
	{
		private class MymcFQtVuYrKpqeoYhoyiGgmsTQI : IControllerExtensionSource
		{
			private QFMIdjQvuHEqbdqAsbQLKYQulzoJ.InJVokOseTgqLZHyEMIbgxKoqhby eeosXMBpFqrdKwdEVgrGvnPkTOkf;

			public QFMIdjQvuHEqbdqAsbQLKYQulzoJ.InJVokOseTgqLZHyEMIbgxKoqhby ayUvCXyCfGuQLrCsZWEOwszCfnBD => eeosXMBpFqrdKwdEVgrGvnPkTOkf;

			public MymcFQtVuYrKpqeoYhoyiGgmsTQI(QFMIdjQvuHEqbdqAsbQLKYQulzoJ.InJVokOseTgqLZHyEMIbgxKoqhby P_0)
			{
				eeosXMBpFqrdKwdEVgrGvnPkTOkf = P_0;
			}
		}

		private MymcFQtVuYrKpqeoYhoyiGgmsTQI pevTJohhKkGzDfpISkzPqrlKrhcMA;

		private bool VvzWdNIirpRaHTuTnEMaaLgmoKlC;

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
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return 0;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return 0;
				}
				return (int)pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.CJeYTfPxPoWWWqokfOiFFdVgtDvr.jdGISnQRDmvBhPpbLIZtxmruSLeH;
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
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return CapabilityFlags.None;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return CapabilityFlags.None;
				}
				pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.CJeYTfPxPoWWWqokfOiFFdVgtDvr.gRAAWjVSHXhMhFHqQLSDIlsxPtMR(UQWGHLeQbjehaNbCUbKmUdkhLDyEA.Any, out var jUbxDShELFCTFDJtkkSnWnyRGvoLA2);
				return (CapabilityFlags)jUbxDShELFCTFDJtkkSnWnyRGvoLA2.PRRpOkhGRpmYTaxqZbRqgXTDKOHx;
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
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return (DeviceType)0;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return (DeviceType)0;
				}
				pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.CJeYTfPxPoWWWqokfOiFFdVgtDvr.gRAAWjVSHXhMhFHqQLSDIlsxPtMR(UQWGHLeQbjehaNbCUbKmUdkhLDyEA.Any, out var jUbxDShELFCTFDJtkkSnWnyRGvoLA2);
				return (DeviceType)jUbxDShELFCTFDJtkkSnWnyRGvoLA2.dTqvRoWTYLcyxOCegaoAeiVZAPTAb;
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
				if (!VvzWdNIirpRaHTuTnEMaaLgmoKlC || !base.enabled)
				{
					return (DeviceSubType)0;
				}
				if (pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD == null)
				{
					return (DeviceSubType)0;
				}
				pevTJohhKkGzDfpISkzPqrlKrhcMA.ayUvCXyCfGuQLrCsZWEOwszCfnBD.CJeYTfPxPoWWWqokfOiFFdVgtDvr.gRAAWjVSHXhMhFHqQLSDIlsxPtMR(UQWGHLeQbjehaNbCUbKmUdkhLDyEA.Any, out var jUbxDShELFCTFDJtkkSnWnyRGvoLA2);
				return (DeviceSubType)jUbxDShELFCTFDJtkkSnWnyRGvoLA2.vmVcBnLgqUqtRjkJPXEUbgjHbkEhA;
			}
		}

		internal XInputControllerExtension(QFMIdjQvuHEqbdqAsbQLKYQulzoJ.InJVokOseTgqLZHyEMIbgxKoqhby P_0)
			: base(new MymcFQtVuYrKpqeoYhoyiGgmsTQI(P_0))
		{
		}

		private XInputControllerExtension(XInputControllerExtension P_0)
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
			pevTJohhKkGzDfpISkzPqrlKrhcMA = source as MymcFQtVuYrKpqeoYhoyiGgmsTQI;
			VvzWdNIirpRaHTuTnEMaaLgmoKlC = pevTJohhKkGzDfpISkzPqrlKrhcMA != null;
		}

		internal override Controller.Extension Clone()
		{
			return new XInputControllerExtension(this);
		}
	}
}
