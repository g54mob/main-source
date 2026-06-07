using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Microsoft.WindowsGamingInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class WindowsGamingInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class kUmUjikGqLCBGeEVYYzGsgGPqIOhA : IControllerExtensionSource
		{
			private XbaEpBIOGYBPgtOGNMMQHPHcmwDV XgUACiViSgvDIMefXZCuVqXpiAmg;

			public XbaEpBIOGYBPgtOGNMMQHPHcmwDV etWBsKbbbUrcVAwjUwcZYCDuvppLA => null;

			public kUmUjikGqLCBGeEVYYzGsgGPqIOhA(XbaEpBIOGYBPgtOGNMMQHPHcmwDV P_0)
			{
			}
		}

		private kUmUjikGqLCBGeEVYYzGsgGPqIOhA ommTZgLobKUvAdqNiadAzZUKbMxu;

		private bool aGfUbZpebQFFckCVlGjLDAkBzRwUB;

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

		internal WindowsGamingInputControllerExtension(XbaEpBIOGYBPgtOGNMMQHPHcmwDV P_0)
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
