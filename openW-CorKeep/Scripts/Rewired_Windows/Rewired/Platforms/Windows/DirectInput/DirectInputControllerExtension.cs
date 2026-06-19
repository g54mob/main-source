using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.DirectInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class DirectInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class XSwbGECPYIeMHGCUEJmKocidfQHbD : IControllerExtensionSource
		{
			private oAfWbvFtzBgLaRIiknILWPaYvJGR dwrblPgnGbenvbqOQOFWcaMAuaBBB;

			private PRXdJyyNuPDkSfKTastHetnREKMo AAFEARaYoLHacaisWZzpJaRzCxpAA;

			public oAfWbvFtzBgLaRIiknILWPaYvJGR ZnxDpxlsgckFpBLbkXUCfpkDLgWm => dwrblPgnGbenvbqOQOFWcaMAuaBBB;

			public PRXdJyyNuPDkSfKTastHetnREKMo EXoyDvFUXsbhdGjkTRsqWpfOFAuk => AAFEARaYoLHacaisWZzpJaRzCxpAA;

			public XSwbGECPYIeMHGCUEJmKocidfQHbD(oAfWbvFtzBgLaRIiknILWPaYvJGR P_0, PRXdJyyNuPDkSfKTastHetnREKMo P_1)
			{
				dwrblPgnGbenvbqOQOFWcaMAuaBBB = P_0;
				AAFEARaYoLHacaisWZzpJaRzCxpAA = P_1;
			}
		}

		private XSwbGECPYIeMHGCUEJmKocidfQHbD rCdtHwUjAqePSawAydapGZYqixujA;

		private bool JfkspsRXjnOTFooHfCssdSKrlBzCb;

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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return Guid.Empty;
				}
				if (rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk == null)
				{
					return Guid.Empty;
				}
				return rCdtHwUjAqePSawAydapGZYqixujA.ZnxDpxlsgckFpBLbkXUCfpkDLgWm.KzwkcdaJgmrrHxFfbAIZCYxqvfXZ;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return Guid.Empty;
				}
				if (rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk == null)
				{
					return Guid.Empty;
				}
				return rCdtHwUjAqePSawAydapGZYqixujA.ZnxDpxlsgckFpBLbkXUCfpkDLgWm.yPlEBmQDdIgFczWAPigatngdjYFF;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return string.Empty;
				}
				return rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk.hVGspDTKQbBpKbSbBEbmoAmxyKlmA.acILlIIovAYGigNaOiAchLCcpQpC;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return string.Empty;
				}
				return rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk.hVGspDTKQbBpKbSbBEbmoAmxyKlmA.XysvtKXvdNRBzUPMIEyIyJCTGjhg;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return Guid.Empty;
				}
				if (rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk == null)
				{
					return Guid.Empty;
				}
				return rCdtHwUjAqePSawAydapGZYqixujA.ZnxDpxlsgckFpBLbkXUCfpkDLgWm.NnQGTgWMqqhQfiyHerEPidQHEGbCA;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return 0;
				}
				if (rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk == null)
				{
					return 0;
				}
				return rCdtHwUjAqePSawAydapGZYqixujA.ZnxDpxlsgckFpBLbkXUCfpkDLgWm.ieSpusZtTvEbYkziujkOQiBSFxMBA;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return 0;
				}
				if (rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk == null)
				{
					return 0;
				}
				return rCdtHwUjAqePSawAydapGZYqixujA.ZnxDpxlsgckFpBLbkXUCfpkDLgWm.AaxSvBIJGptkHBQjnsztPHrlWpzn;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return DirectInputDeviceType.Device;
				}
				if (rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk == null)
				{
					return DirectInputDeviceType.Device;
				}
				return (DirectInputDeviceType)rCdtHwUjAqePSawAydapGZYqixujA.ZnxDpxlsgckFpBLbkXUCfpkDLgWm.MMkFjnAWHbUsAtgKCDCWRWroaldrA;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return 0;
				}
				if (rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk == null)
				{
					return 0;
				}
				return rCdtHwUjAqePSawAydapGZYqixujA.ZnxDpxlsgckFpBLbkXUCfpkDLgWm.JMpqktIGzbeRYPBkimpLzZvMUDTI;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return 0;
				}
				if (rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk == null)
				{
					return 0;
				}
				return rCdtHwUjAqePSawAydapGZYqixujA.ZnxDpxlsgckFpBLbkXUCfpkDLgWm.QVTSlAnIkMbOmFGhzfxWyJYJFkwe;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return false;
				}
				if (rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk == null)
				{
					return false;
				}
				return rCdtHwUjAqePSawAydapGZYqixujA.ZnxDpxlsgckFpBLbkXUCfpkDLgWm.FFdPGINVALSvaASyljVGFpHBlOLn;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return DirectInputDeviceAxisMode.Absolute;
				}
				return (DirectInputDeviceAxisMode)rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk.hVGspDTKQbBpKbSbBEbmoAmxyKlmA.KTzmYoCEDrvCANpIqnRGxyJulhWe;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return 0;
				}
				return rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk.hVGspDTKQbBpKbSbBEbmoAmxyKlmA.GEBEBPWxooimOeLhEAAlSxeEfFgy;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return Guid.Empty;
				}
				return rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk.hVGspDTKQbBpKbSbBEbmoAmxyKlmA.wRIfzRCWrAJfALQLCxoUeSDhsuLHA;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return 0;
				}
				return rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk.hVGspDTKQbBpKbSbBEbmoAmxyKlmA.kZzUUgCxJCfOTnSCOWMdVEbZMEXX;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (JfkspsRXjnOTFooHfCssdSKrlBzCb && base.enabled)
				{
					rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk.hVGspDTKQbBpKbSbBEbmoAmxyKlmA.kZzUUgCxJCfOTnSCOWMdVEbZMEXX = value;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return string.Empty;
				}
				return rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk.hVGspDTKQbBpKbSbBEbmoAmxyKlmA.rkWuVsHOLGNOufCAarCQDPzfHNbX;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return 0;
				}
				return rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk.hVGspDTKQbBpKbSbBEbmoAmxyKlmA.meXdRJiGzEiIvjhdlADLlbjBJzAo;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return 0;
				}
				return (ushort)rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk.hVGspDTKQbBpKbSbBEbmoAmxyKlmA.FMguLFyIWTEbghmkaAjeiaMjEuQNA;
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
				if (!JfkspsRXjnOTFooHfCssdSKrlBzCb || !base.enabled)
				{
					return 0;
				}
				return (ushort)rCdtHwUjAqePSawAydapGZYqixujA.EXoyDvFUXsbhdGjkTRsqWpfOFAuk.hVGspDTKQbBpKbSbBEbmoAmxyKlmA.MdHkuOXVoHvIuHjZLCewaiUoLddQ;
			}
		}

		string IHIDControllerExtension.manufacturer => string.Empty;

		internal DirectInputControllerExtension(oAfWbvFtzBgLaRIiknILWPaYvJGR P_0, PRXdJyyNuPDkSfKTastHetnREKMo P_1)
			: base(new XSwbGECPYIeMHGCUEJmKocidfQHbD(P_0, P_1))
		{
		}

		private DirectInputControllerExtension(DirectInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (JfkspsRXjnOTFooHfCssdSKrlBzCb)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			rCdtHwUjAqePSawAydapGZYqixujA = source as XSwbGECPYIeMHGCUEJmKocidfQHbD;
			JfkspsRXjnOTFooHfCssdSKrlBzCb = rCdtHwUjAqePSawAydapGZYqixujA != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DirectInputControllerExtension(this);
		}
	}
}
