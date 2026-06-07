using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.DirectInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class DirectInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class aHUxhqknJDLqzbGXCPkGAZYCrBXw : IControllerExtensionSource
		{
			private TtTEWPAmgCXtCiwlxHCRLqWtUGyz MmDGRpLqFqVKHRWDVHyOKEgBjtbF;

			private qWdiYCPczUKCkYRGxlqRQmHeVzkG fijhPlZOxQEIEBkpBzJvnlpCiBPI;

			public TtTEWPAmgCXtCiwlxHCRLqWtUGyz qKLrGBUThrdsJeGmzISUTFGyifmEA => MmDGRpLqFqVKHRWDVHyOKEgBjtbF;

			public qWdiYCPczUKCkYRGxlqRQmHeVzkG YmPHDaLnfDREvvBIDqoaZGfWUgB => fijhPlZOxQEIEBkpBzJvnlpCiBPI;

			public aHUxhqknJDLqzbGXCPkGAZYCrBXw(TtTEWPAmgCXtCiwlxHCRLqWtUGyz P_0, qWdiYCPczUKCkYRGxlqRQmHeVzkG P_1)
			{
				MmDGRpLqFqVKHRWDVHyOKEgBjtbF = P_0;
				fijhPlZOxQEIEBkpBzJvnlpCiBPI = P_1;
			}
		}

		private aHUxhqknJDLqzbGXCPkGAZYCrBXw WHNiyAvdJxCzoBHPrPstHnuFluSZA;

		private bool qSQeQSwkwwqjlXsSoNeaoPyGDGJM;

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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return Guid.Empty;
				}
				if (WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB == null)
				{
					return Guid.Empty;
				}
				return WHNiyAvdJxCzoBHPrPstHnuFluSZA.qKLrGBUThrdsJeGmzISUTFGyifmEA.tLUoFBXwbtDPnYjcetOHmmDLIghT;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return Guid.Empty;
				}
				if (WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB == null)
				{
					return Guid.Empty;
				}
				return WHNiyAvdJxCzoBHPrPstHnuFluSZA.qKLrGBUThrdsJeGmzISUTFGyifmEA.ZRPrStnqNFGUgSDUzouORCQogvNA;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return string.Empty;
				}
				return WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB.WpkGQjixRyPHkhsmQcvmwSYOeJHr.BJuwQXdhlRyZgTUaLkMgHteZmcLF;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return string.Empty;
				}
				return WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB.WpkGQjixRyPHkhsmQcvmwSYOeJHr.sJSaAgkeqAfpJvVDDfKKEMckqJNEb;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return Guid.Empty;
				}
				if (WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB == null)
				{
					return Guid.Empty;
				}
				return WHNiyAvdJxCzoBHPrPstHnuFluSZA.qKLrGBUThrdsJeGmzISUTFGyifmEA.wyiskSboxjuuPLDStcSVSWuykPBO;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return 0;
				}
				if (WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB == null)
				{
					return 0;
				}
				return WHNiyAvdJxCzoBHPrPstHnuFluSZA.qKLrGBUThrdsJeGmzISUTFGyifmEA.RNyjNMgXUiBDyPozxjmMcRrjoysk;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return 0;
				}
				if (WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB == null)
				{
					return 0;
				}
				return WHNiyAvdJxCzoBHPrPstHnuFluSZA.qKLrGBUThrdsJeGmzISUTFGyifmEA.tlLiCdvUDwpUriSsqPpjrnRYxiTO;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return DirectInputDeviceType.Device;
				}
				if (WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB == null)
				{
					return DirectInputDeviceType.Device;
				}
				return (DirectInputDeviceType)WHNiyAvdJxCzoBHPrPstHnuFluSZA.qKLrGBUThrdsJeGmzISUTFGyifmEA.lHQWSBfUCkkMyFLPPlIAkmZRDgPw;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return 0;
				}
				if (WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB == null)
				{
					return 0;
				}
				return WHNiyAvdJxCzoBHPrPstHnuFluSZA.qKLrGBUThrdsJeGmzISUTFGyifmEA.iBUPBcpskyYswytxvkDABVtnRjnA;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return 0;
				}
				if (WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB == null)
				{
					return 0;
				}
				return WHNiyAvdJxCzoBHPrPstHnuFluSZA.qKLrGBUThrdsJeGmzISUTFGyifmEA.fptrDoCFbHTvQwZIahaQOdGuEzOe;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return false;
				}
				if (WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB == null)
				{
					return false;
				}
				return WHNiyAvdJxCzoBHPrPstHnuFluSZA.qKLrGBUThrdsJeGmzISUTFGyifmEA.ylHjzqkgNSOFAzGfoHRYibnwDDhab;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return DirectInputDeviceAxisMode.Absolute;
				}
				return (DirectInputDeviceAxisMode)WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB.WpkGQjixRyPHkhsmQcvmwSYOeJHr.bLVVeifAXcDiycqafbbEHCENIigo;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return 0;
				}
				return WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB.WpkGQjixRyPHkhsmQcvmwSYOeJHr.jZnpcxphvbSwmXjoVkOfaFGvtKAV;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return Guid.Empty;
				}
				return WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB.WpkGQjixRyPHkhsmQcvmwSYOeJHr.HdowShjbsVSTgtGSZtgEapbQDbtHA;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return 0;
				}
				return WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB.WpkGQjixRyPHkhsmQcvmwSYOeJHr.JHVblSbxOTxmtWANNHYrlfBkoFdGb;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (qSQeQSwkwwqjlXsSoNeaoPyGDGJM && base.enabled)
				{
					WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB.WpkGQjixRyPHkhsmQcvmwSYOeJHr.JHVblSbxOTxmtWANNHYrlfBkoFdGb = value;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return string.Empty;
				}
				return WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB.WpkGQjixRyPHkhsmQcvmwSYOeJHr.MWqdaUhgUFqkCCxPtdUKbzFSyMJT;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return 0;
				}
				return WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB.WpkGQjixRyPHkhsmQcvmwSYOeJHr.ZlKAvERyBpGHhOmBaAFqHXhmuGqe;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return 0;
				}
				return (ushort)WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB.WpkGQjixRyPHkhsmQcvmwSYOeJHr.qiORUvXtBOJJIANnzdWeEoyAlZsd;
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
				if (!qSQeQSwkwwqjlXsSoNeaoPyGDGJM || !base.enabled)
				{
					return 0;
				}
				return (ushort)WHNiyAvdJxCzoBHPrPstHnuFluSZA.YmPHDaLnfDREvvBIDqoaZGfWUgB.WpkGQjixRyPHkhsmQcvmwSYOeJHr.dvblTkkExKwsGeFMARkeKPqPJoLQ;
			}
		}

		string IHIDControllerExtension.manufacturer => string.Empty;

		internal DirectInputControllerExtension(TtTEWPAmgCXtCiwlxHCRLqWtUGyz P_0, qWdiYCPczUKCkYRGxlqRQmHeVzkG P_1)
			: base(new aHUxhqknJDLqzbGXCPkGAZYCrBXw(P_0, P_1))
		{
		}

		private DirectInputControllerExtension(DirectInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (qSQeQSwkwwqjlXsSoNeaoPyGDGJM)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			WHNiyAvdJxCzoBHPrPstHnuFluSZA = source as aHUxhqknJDLqzbGXCPkGAZYCrBXw;
			qSQeQSwkwwqjlXsSoNeaoPyGDGJM = WHNiyAvdJxCzoBHPrPstHnuFluSZA != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DirectInputControllerExtension(this);
		}
	}
}
