using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.DirectInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class DirectInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class cUzfKQHwKRcpiuGhfQXdlxVnqBYc : IControllerExtensionSource
		{
			private JicQzfZFGYlDzHeOEuuFHdMrnbQA USyOIBiQeioDYSvCqfxhlWNyhCcR;

			private iiCQkmclKKOKpHlRAXXyhYgZVknX rZUphVozAMlOZOTmaUZQYoQhkTCv;

			public JicQzfZFGYlDzHeOEuuFHdMrnbQA uzkACtptSrplChdnIwCdsFdTCGfx => null;

			public iiCQkmclKKOKpHlRAXXyhYgZVknX hczhRxVRutXTYmQilntDLyqKtrDs => null;

			public cUzfKQHwKRcpiuGhfQXdlxVnqBYc(JicQzfZFGYlDzHeOEuuFHdMrnbQA P_0, iiCQkmclKKOKpHlRAXXyhYgZVknX P_1)
			{
			}
		}

		private cUzfKQHwKRcpiuGhfQXdlxVnqBYc EWwAeiUpgvtlbQdUWtEOOaRinRPw;

		private bool kJpBSqRNXqDtiASRXMMPJrBnlpOR;

		private Joystick joystick => null;

		public Guid instanceGuid => default(Guid);

		public Guid productGuid => default(Guid);

		public string instanceName => null;

		public string productName => null;

		public Guid forceFeedbackDriverGuid => default(Guid);

		public ushort usagePage => 0;

		public ushort usage => 0;

		public DirectInputDeviceType deviceType => default(DirectInputDeviceType);

		public int deviceSubtype => 0;

		public int rawType => 0;

		public bool isHumanInterfaceDevice => false;

		public DirectInputDeviceAxisMode axisMode => default(DirectInputDeviceAxisMode);

		public int bufferSize => 0;

		public Guid classGuid => default(Guid);

		public int forceFeedbackGain
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string interfacePath => null;

		public int joystickId => 0;

		public ushort productId => 0;

		public ushort vendorId => 0;

		string IHIDControllerExtension.manufacturer => null;

		internal DirectInputControllerExtension(JicQzfZFGYlDzHeOEuuFHdMrnbQA P_0, iiCQkmclKKOKpHlRAXXyhYgZVknX P_1)
		{
		}

		private DirectInputControllerExtension(DirectInputControllerExtension P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
		}

		internal override Controller.Extension Clone()
		{
			return null;
		}
	}
}
