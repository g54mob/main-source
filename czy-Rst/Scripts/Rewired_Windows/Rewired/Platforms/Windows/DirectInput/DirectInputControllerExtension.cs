using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.DirectInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class DirectInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class iKcJiaRwNYFjfDJRxBtCdhifSMAJA : IControllerExtensionSource
		{
			private RCbrBLDngHgaSCZnWWTNJSaCQXlM UdLKvcLLvGhTpFNeWNAhSkoiBiF;

			private uLDfSnelVFXiseOKzoZQrdXjKrpA bBpabihzJRRGnNfscwhcCNjWfKFA;

			public RCbrBLDngHgaSCZnWWTNJSaCQXlM oqvGNZjtfoDsTkMeUEPSXoaBamrZA => UdLKvcLLvGhTpFNeWNAhSkoiBiF;

			public uLDfSnelVFXiseOKzoZQrdXjKrpA xKaWmHDUTsGRXDNtdQxcPHzWHCZf => bBpabihzJRRGnNfscwhcCNjWfKFA;

			public iKcJiaRwNYFjfDJRxBtCdhifSMAJA(RCbrBLDngHgaSCZnWWTNJSaCQXlM P_0, uLDfSnelVFXiseOKzoZQrdXjKrpA P_1)
			{
				UdLKvcLLvGhTpFNeWNAhSkoiBiF = P_0;
				bBpabihzJRRGnNfscwhcCNjWfKFA = P_1;
			}
		}

		private iKcJiaRwNYFjfDJRxBtCdhifSMAJA SLhThIQFHaZaobKRQEnpOQGgIjLP;

		private bool eYoSPGRgszycrfkUBabqIVGhRVMLA;

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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return Guid.Empty;
				}
				if (SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf == null)
				{
					return Guid.Empty;
				}
				return SLhThIQFHaZaobKRQEnpOQGgIjLP.oqvGNZjtfoDsTkMeUEPSXoaBamrZA.vooZCRenfowGvkjwBdPFIBfsSrucA;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return Guid.Empty;
				}
				if (SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf == null)
				{
					return Guid.Empty;
				}
				return SLhThIQFHaZaobKRQEnpOQGgIjLP.oqvGNZjtfoDsTkMeUEPSXoaBamrZA.HHnyOAQmqKRfIepNrbhokTmxpHaK;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return string.Empty;
				}
				return SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf.SjKSPnBOTzwGcHPolOscJNmhgYScA.BGSCxHSRlIdfqliUkSbeiuRcOvGM;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return string.Empty;
				}
				return SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf.SjKSPnBOTzwGcHPolOscJNmhgYScA.mkwLTeJuqReQJFPNoVUtjGIZGUMc;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return Guid.Empty;
				}
				if (SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf == null)
				{
					return Guid.Empty;
				}
				return SLhThIQFHaZaobKRQEnpOQGgIjLP.oqvGNZjtfoDsTkMeUEPSXoaBamrZA.kaAgrGAMlyMbTjzAhQVTFfMVZUKwA;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return 0;
				}
				if (SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf == null)
				{
					return 0;
				}
				return SLhThIQFHaZaobKRQEnpOQGgIjLP.oqvGNZjtfoDsTkMeUEPSXoaBamrZA.PjQxUGDcKbwKobrxKbkIHeZUfJbK;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return 0;
				}
				if (SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf == null)
				{
					return 0;
				}
				return SLhThIQFHaZaobKRQEnpOQGgIjLP.oqvGNZjtfoDsTkMeUEPSXoaBamrZA.xnfTVlMnVrtBrUxwNPqlISnbdbUs;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return DirectInputDeviceType.Device;
				}
				if (SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf == null)
				{
					return DirectInputDeviceType.Device;
				}
				return (DirectInputDeviceType)SLhThIQFHaZaobKRQEnpOQGgIjLP.oqvGNZjtfoDsTkMeUEPSXoaBamrZA.brofLJGMGjbNcpQJiXRSFspoutUU;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return 0;
				}
				if (SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf == null)
				{
					return 0;
				}
				return SLhThIQFHaZaobKRQEnpOQGgIjLP.oqvGNZjtfoDsTkMeUEPSXoaBamrZA.amhYgHQpmfLeaCvzYdGRgEvIWBql;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return 0;
				}
				if (SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf == null)
				{
					return 0;
				}
				return SLhThIQFHaZaobKRQEnpOQGgIjLP.oqvGNZjtfoDsTkMeUEPSXoaBamrZA.pBDmEetIJQGOIYzVBgiWxANFsJHy;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return false;
				}
				if (SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf == null)
				{
					return false;
				}
				return SLhThIQFHaZaobKRQEnpOQGgIjLP.oqvGNZjtfoDsTkMeUEPSXoaBamrZA.ejfXgwZzTJSKETXdVvUIQNHFgAgs;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return DirectInputDeviceAxisMode.Absolute;
				}
				return (DirectInputDeviceAxisMode)SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf.SjKSPnBOTzwGcHPolOscJNmhgYScA.nDbMqwYeNnjYsYqaOTiQyPiqRxpo;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return 0;
				}
				return SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf.SjKSPnBOTzwGcHPolOscJNmhgYScA.zYJgzraSvgQBqclisTHdsPiKPNHeb;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return Guid.Empty;
				}
				return SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf.SjKSPnBOTzwGcHPolOscJNmhgYScA.JVYFBlSimGOYiFOQehzKHpLroWcL;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return 0;
				}
				return SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf.SjKSPnBOTzwGcHPolOscJNmhgYScA.NNvpuQEdEIwzpqnZeKLnElxLeQqfA;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (eYoSPGRgszycrfkUBabqIVGhRVMLA && base.enabled)
				{
					SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf.SjKSPnBOTzwGcHPolOscJNmhgYScA.NNvpuQEdEIwzpqnZeKLnElxLeQqfA = value;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return string.Empty;
				}
				return SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf.SjKSPnBOTzwGcHPolOscJNmhgYScA.SeCSvIFISGlfYwHVYQJAKxfxrBCv;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return 0;
				}
				return SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf.SjKSPnBOTzwGcHPolOscJNmhgYScA.LdZRgtsMwYBEFoqkVXdPisfRzzhG;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return 0;
				}
				return (ushort)SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf.SjKSPnBOTzwGcHPolOscJNmhgYScA.alqObbwDKJKsSylNOkbghYMtuDvC;
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
				if (!eYoSPGRgszycrfkUBabqIVGhRVMLA || !base.enabled)
				{
					return 0;
				}
				return (ushort)SLhThIQFHaZaobKRQEnpOQGgIjLP.xKaWmHDUTsGRXDNtdQxcPHzWHCZf.SjKSPnBOTzwGcHPolOscJNmhgYScA.taJdSoHJrTOxUaKAjOtwuzMwNzIpA;
			}
		}

		string IHIDControllerExtension.manufacturer => string.Empty;

		internal DirectInputControllerExtension(RCbrBLDngHgaSCZnWWTNJSaCQXlM P_0, uLDfSnelVFXiseOKzoZQrdXjKrpA P_1)
			: base(new iKcJiaRwNYFjfDJRxBtCdhifSMAJA(P_0, P_1))
		{
		}

		private DirectInputControllerExtension(DirectInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (eYoSPGRgszycrfkUBabqIVGhRVMLA)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			SLhThIQFHaZaobKRQEnpOQGgIjLP = source as iKcJiaRwNYFjfDJRxBtCdhifSMAJA;
			eYoSPGRgszycrfkUBabqIVGhRVMLA = SLhThIQFHaZaobKRQEnpOQGgIjLP != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DirectInputControllerExtension(this);
		}
	}
}
