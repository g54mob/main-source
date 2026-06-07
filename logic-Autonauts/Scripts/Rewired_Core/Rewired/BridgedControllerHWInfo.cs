using System;
using Rewired.Platforms;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
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

		public BridgedControllerHWInfo()
		{
		}

		public BridgedControllerHWInfo(BridgedControllerHWInfo source)
		{
			source.MKBsBaTcNzVorUQrataFreMUgjP(this);
		}

		private void MKBsBaTcNzVorUQrataFreMUgjP(BridgedControllerHWInfo P_0)
		{
			P_0.isMock = isMock;
			P_0.inputManagerSource = inputManagerSource;
			while (true)
			{
				int num = 625262551;
				while (true)
				{
					switch (num ^ 0x2544BFD1)
					{
					case 2:
						break;
					case 6:
						P_0.inputSource = inputSource;
						P_0.deviceType = deviceType;
						P_0.hardwareIdentifier = hardwareIdentifier;
						P_0.hardwareAxisCount = hardwareAxisCount;
						num = 625262548;
						continue;
					case 1:
						P_0.hw_localVibrationMotorCount = hw_localVibrationMotorCount;
						num = 625262546;
						continue;
					case 8:
						P_0.hw_version = hw_version;
						P_0.hw_isSDL2Gamepad = hw_isSDL2Gamepad;
						P_0.webGL_webBrowserType = webGL_webBrowserType;
						P_0.webGL_osType = webGL_osType;
						P_0.webGL_mappingType = webGL_mappingType;
						num = 625262544;
						continue;
					case 5:
						P_0.hardwareButtonCount = hardwareButtonCount;
						P_0.hardwareHatCount = hardwareHatCount;
						P_0.hw_productName = hw_productName;
						P_0.hw_pidVid = hw_pidVid;
						P_0.hw_deviceGuid = hw_deviceGuid;
						num = 625262545;
						continue;
					case 9:
						P_0.hw_bluetoothDeviceName = hw_bluetoothDeviceName;
						num = 625262555;
						continue;
					case 4:
						P_0.hw_supportsVoice = hw_supportsVoice;
						num = 625262550;
						continue;
					case 7:
						P_0.hw_supportsVibration = hw_supportsVibration;
						P_0.hw_xInputSubType = hw_xInputSubType;
						P_0.hw_manufacturer = hw_manufacturer;
						P_0.hw_serialNumber = hw_serialNumber;
						P_0.hw_vendorId = hw_vendorId;
						num = 625262553;
						continue;
					case 10:
						P_0.hw_isBluetoothDevice = hw_isBluetoothDevice;
						num = 625262549;
						continue;
					case 0:
						P_0.hw_productId = hw_productId;
						num = 625262552;
						continue;
					default:
						P_0.definitionMatchTag = definitionMatchTag;
						return;
					}
					break;
				}
			}
		}
	}
}
