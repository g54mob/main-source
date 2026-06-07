using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.DirectInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class DirectInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class hldkpLJbJhunQMROVLJAzcfoAowA : IControllerExtensionSource
		{
			private AZmRVMBCLWjdSJdmldWMNaRORDDE RzmjLocLhyrFZyqNXBgNzfYaMgYX;

			private hlOkjDeqVWQCgnqAjZMKnjtRaEFeA sYQImuwCPUuQQiOdRUIwKNFxEpwO;

			public AZmRVMBCLWjdSJdmldWMNaRORDDE dueXJEryHhxpNBjuzDnHoYoPhcJT => RzmjLocLhyrFZyqNXBgNzfYaMgYX;

			public hlOkjDeqVWQCgnqAjZMKnjtRaEFeA euvWAABsjtIZReUtYVgjkZbWMLdAA => sYQImuwCPUuQQiOdRUIwKNFxEpwO;

			public hldkpLJbJhunQMROVLJAzcfoAowA(AZmRVMBCLWjdSJdmldWMNaRORDDE P_0, hlOkjDeqVWQCgnqAjZMKnjtRaEFeA P_1)
			{
				RzmjLocLhyrFZyqNXBgNzfYaMgYX = P_0;
				sYQImuwCPUuQQiOdRUIwKNFxEpwO = P_1;
			}
		}

		private hldkpLJbJhunQMROVLJAzcfoAowA JtmrtBEPjdpoaglPfHMeSdEcixjq;

		private bool pfbVDJNgModbtsUAulDpLUMhqLuN;

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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return Guid.Empty;
				}
				if (JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA == null)
				{
					return Guid.Empty;
				}
				return JtmrtBEPjdpoaglPfHMeSdEcixjq.dueXJEryHhxpNBjuzDnHoYoPhcJT.sVtcKAcULxFXrzLoatpWBhluUdUs;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return Guid.Empty;
				}
				if (JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA == null)
				{
					return Guid.Empty;
				}
				return JtmrtBEPjdpoaglPfHMeSdEcixjq.dueXJEryHhxpNBjuzDnHoYoPhcJT.EbuxgXKWWFMAMpYFAvRpwowfDfQCA;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return string.Empty;
				}
				return JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA.JANJnqDdtgdZeQdaCCMdLNmlQEuP.GaJCpADKPTlcgmRCJfFvAaHyJvykA;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return string.Empty;
				}
				return JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA.JANJnqDdtgdZeQdaCCMdLNmlQEuP.jylQTjZiUCZzLSJBZIvTnKIRkKcv;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return Guid.Empty;
				}
				if (JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA == null)
				{
					return Guid.Empty;
				}
				return JtmrtBEPjdpoaglPfHMeSdEcixjq.dueXJEryHhxpNBjuzDnHoYoPhcJT.hkVnrNEDPjiwNgrYzJbQlGQRMSon;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return 0;
				}
				if (JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA == null)
				{
					return 0;
				}
				return JtmrtBEPjdpoaglPfHMeSdEcixjq.dueXJEryHhxpNBjuzDnHoYoPhcJT.AZDSATNUswZqkwVvzNYRJeLWxVJG;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return 0;
				}
				if (JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA == null)
				{
					return 0;
				}
				return JtmrtBEPjdpoaglPfHMeSdEcixjq.dueXJEryHhxpNBjuzDnHoYoPhcJT.svoXuyQtjqEufBoeaMucAjnxlHmg;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return DirectInputDeviceType.Device;
				}
				if (JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA == null)
				{
					return DirectInputDeviceType.Device;
				}
				return (DirectInputDeviceType)JtmrtBEPjdpoaglPfHMeSdEcixjq.dueXJEryHhxpNBjuzDnHoYoPhcJT.gOzLOVUgXaIyOqBoDfRdJlrcdmUb;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return 0;
				}
				if (JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA == null)
				{
					return 0;
				}
				return JtmrtBEPjdpoaglPfHMeSdEcixjq.dueXJEryHhxpNBjuzDnHoYoPhcJT.btuyAUEvUkAMyZRtddLAqBfMcOGZ;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return 0;
				}
				if (JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA == null)
				{
					return 0;
				}
				return JtmrtBEPjdpoaglPfHMeSdEcixjq.dueXJEryHhxpNBjuzDnHoYoPhcJT.wGWVgvhCxPSVMFmFigYDxsRXgVpu;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return false;
				}
				if (JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA == null)
				{
					return false;
				}
				return JtmrtBEPjdpoaglPfHMeSdEcixjq.dueXJEryHhxpNBjuzDnHoYoPhcJT.xVuiCnTVhQXwQCNlaulBSNTHOOAL;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return DirectInputDeviceAxisMode.Absolute;
				}
				return (DirectInputDeviceAxisMode)JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA.JANJnqDdtgdZeQdaCCMdLNmlQEuP.iBqHGliOheNFwWHmnsWBkPqkElLz;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return 0;
				}
				return JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA.JANJnqDdtgdZeQdaCCMdLNmlQEuP.slEdHiSHRphGecFuTRveRRqGdNfGA;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return Guid.Empty;
				}
				return JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA.JANJnqDdtgdZeQdaCCMdLNmlQEuP.CkBFDcOIlFBViUAYRFoPJTqjyTEd;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return 0;
				}
				return JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA.JANJnqDdtgdZeQdaCCMdLNmlQEuP.EOmoZHYaKLojxdEZNjEuGonRGgCK;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (pfbVDJNgModbtsUAulDpLUMhqLuN && base.enabled)
				{
					JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA.JANJnqDdtgdZeQdaCCMdLNmlQEuP.EOmoZHYaKLojxdEZNjEuGonRGgCK = value;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return string.Empty;
				}
				return JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA.JANJnqDdtgdZeQdaCCMdLNmlQEuP.HeRpsBDulZaNQpVQvddLIpbrNOiD;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return 0;
				}
				return JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA.JANJnqDdtgdZeQdaCCMdLNmlQEuP.EFIYTukNYVILZhyuoxRMmEdXppDF;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return 0;
				}
				return (ushort)JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA.JANJnqDdtgdZeQdaCCMdLNmlQEuP.hUdFIigItAsRWpFvbtCrpHQlLcXo;
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
				if (!pfbVDJNgModbtsUAulDpLUMhqLuN || !base.enabled)
				{
					return 0;
				}
				return (ushort)JtmrtBEPjdpoaglPfHMeSdEcixjq.euvWAABsjtIZReUtYVgjkZbWMLdAA.JANJnqDdtgdZeQdaCCMdLNmlQEuP.cfOdAfTfPQHiScPSUPDbGfIAyhqlB;
			}
		}

		string IHIDControllerExtension.manufacturer => string.Empty;

		internal DirectInputControllerExtension(AZmRVMBCLWjdSJdmldWMNaRORDDE P_0, hlOkjDeqVWQCgnqAjZMKnjtRaEFeA P_1)
			: base(new hldkpLJbJhunQMROVLJAzcfoAowA(P_0, P_1))
		{
		}

		private DirectInputControllerExtension(DirectInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (pfbVDJNgModbtsUAulDpLUMhqLuN)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			JtmrtBEPjdpoaglPfHMeSdEcixjq = source as hldkpLJbJhunQMROVLJAzcfoAowA;
			pfbVDJNgModbtsUAulDpLUMhqLuN = JtmrtBEPjdpoaglPfHMeSdEcixjq != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DirectInputControllerExtension(this);
		}
	}
}
