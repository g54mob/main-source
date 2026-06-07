using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Microsoft.WindowsGamingInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class WindowsGamingInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class zCuEIbkipQIAtQRTPvPNPaZnfubTA : IControllerExtensionSource
		{
			private WJaANAIwLZIFNgGMKouLXECODEmu MnIrrlFhxvoIjHwXMfMtZlPDGLRc;

			public WJaANAIwLZIFNgGMKouLXECODEmu rJQxBVtNkRNlinWnJdMQCnCQZLQq => null;

			public zCuEIbkipQIAtQRTPvPNPaZnfubTA(WJaANAIwLZIFNgGMKouLXECODEmu P_0)
			{
			}
		}

		private zCuEIbkipQIAtQRTPvPNPaZnfubTA xWodqbePmFFmhXwXrsPHtnRgGaAWA;

		private bool lYpcEMGhsLFEFxJBgVZIpInTlpDAA;

		private Joystick joystick => null;

		public DeviceType deviceType => default(DeviceType);

		public IntPtr nativePointer => (IntPtr)0;

		public string nonRoamableId => null;

		public bool isWireless => false;

		public string productName => null;

		string IHIDControllerExtension.manufacturer => null;

		public ushort vendorId => 0;

		public ushort productId => 0;

		ushort IHIDControllerExtension.usagePage => 0;

		ushort IHIDControllerExtension.usage => 0;

		internal WindowsGamingInputControllerExtension(WJaANAIwLZIFNgGMKouLXECODEmu P_0)
		{
		}

		private WindowsGamingInputControllerExtension(WindowsGamingInputControllerExtension P_0)
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
