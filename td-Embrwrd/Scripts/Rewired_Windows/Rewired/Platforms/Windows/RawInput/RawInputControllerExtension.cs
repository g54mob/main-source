using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.RawInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RawInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class DLwBkYTTKTyEQDiGxnENxtwsOcUg : IControllerExtensionSource
		{
			private RaoPqCmhRPKMGQDvLBQFhMvjOjFR kWXiFsrBYqXxOOcsuJtASPKNpths;

			public RaoPqCmhRPKMGQDvLBQFhMvjOjFR LDhhMYRVmpehwJUFoaSYAPKIxWsg => null;

			public DLwBkYTTKTyEQDiGxnENxtwsOcUg(RaoPqCmhRPKMGQDvLBQFhMvjOjFR P_0)
			{
			}
		}

		private DLwBkYTTKTyEQDiGxnENxtwsOcUg aPfwCkuhSzzgcgZFMExlScoSIOXFA;

		private bool TiwEMAOetNjGSVOwfOXBZvbvdVeR;

		private Joystick joystick => null;

		public IntPtr hidDeviceHandle => (IntPtr)0;

		public IntPtr rawInputDeviceHandle => (IntPtr)0;

		public string devicePath => null;

		public string productName => null;

		public string manufacturer => null;

		public ushort vendorId => 0;

		public ushort productId => 0;

		public Guid productGuid => default(Guid);

		public bool isBluetoothDevice => false;

		public string bluetoothDeviceName => null;

		public int hubId => 0;

		public int portId => 0;

		public ushort usagePage => 0;

		public ushort usage => 0;

		internal RawInputControllerExtension(RaoPqCmhRPKMGQDvLBQFhMvjOjFR P_0)
		{
		}

		private RawInputControllerExtension(RawInputControllerExtension P_0)
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
