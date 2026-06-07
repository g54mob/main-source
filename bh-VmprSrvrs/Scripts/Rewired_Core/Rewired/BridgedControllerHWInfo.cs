using System;
using Rewired.Platforms;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class BridgedControllerHWInfo
	{
		public bool isMock;

		public InputSource inputManagerSource;

		public InputSource inputSource;

		public ControlDeviceType deviceType;

		public string hardwareIdentifier;

		public int hardwareAxisCount;

		public int hardwareButtonCount;

		public int hardwareHatCount;

		public string hw_productName;

		public PidVid hw_pidVid;

		public Guid hw_deviceGuid;

		public int hw_productId;

		public string hw_bluetoothDeviceName;

		public bool hw_isBluetoothDevice;

		public bool hw_supportsVoice;

		public bool hw_supportsVibration;

		public XInputDeviceSubType hw_xInputSubType;

		public string hw_manufacturer;

		public string hw_serialNumber;

		public int hw_vendorId;

		public int hw_version;

		public string hw_systemDeviceName;

		public bool hw_isSDL2Gamepad;

		public WebGLWebBrowserType webGL_webBrowserType;

		public WebGLOSType webGL_osType;

		public WebGLGamepadMappingType webGL_mappingType;

		public string[] webGL_webBrowserVersionSplit;

		public string[] webGL_osVersionSplit;

		public int hw_localVibrationMotorCount;

		public string definitionMatchTag;

		public object userCustomIdentifier;

		public BridgedControllerHWInfo()
		{
		}

		public BridgedControllerHWInfo(BridgedControllerHWInfo P_0)
		{
		}

		private void AdXcdIQIFhVkzMqGXodYYeJBfebBA(BridgedControllerHWInfo P_0)
		{
		}
	}
}
