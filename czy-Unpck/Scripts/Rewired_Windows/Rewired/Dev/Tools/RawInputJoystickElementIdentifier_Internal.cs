using System;
using System.Collections.Generic;
using Rewired.HID;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	internal sealed class RawInputJoystickElementIdentifier_Internal : IElementIdentifierTool
	{
		private Rewired.Internal.GUIText text;

		private string textBuffer;

		private int currentDeviceId;

		private YkKIPPiCWZeAzAfNMTiDRgJXluDN dgeymjwCdGAtHTMwapVjdBigBLF;

		private TPOFglCEUenQueqhakDnrjLmVbgq AUIdfqdotGKPVLbiMbUhWyorbHfX;

		private Guid deviceInstanceGuid;

		private IList<TPOFglCEUenQueqhakDnrjLmVbgq> MciGSvBuvceUrKFLCLFInuEHfOYj;

		private bool showAllDevices;

		private bool refreshNow;

		private bool ready;

		private string[] axisNames;

		private int[] axisValues;

		public void Initialize(Rewired.Internal.GUIText text)
		{
			this.text = text;
			axisNames = Enum.GetNames(typeof(RawInputAxis));
			axisValues = (int[])Enum.GetValues(typeof(RawInputAxis));
		}

		public void Start()
		{
			if (ReInput.isEditor && ReInput.editorPlatform != EditorPlatform.Windows)
			{
				Logger.LogError("Raw Input cannot be run on this platform. You must be running the editor in Windows.");
				return;
			}
			if (ReInput.currentPlatform != Platform.Windows)
			{
				Logger.LogError("Raw Input cannot be run on this build target. Be sure Unity's build target is set to Windows Standalone.");
				return;
			}
			dgeymjwCdGAtHTMwapVjdBigBLF = ReInput.primaryInputManager.inputSource as YkKIPPiCWZeAzAfNMTiDRgJXluDN;
			if (dgeymjwCdGAtHTMwapVjdBigBLF == null)
			{
				Logger.LogError("Unable to initialize Raw Input! You must add a Rewired Input Manager to the scene and set the input mode to Raw Input.");
				return;
			}
			ReInput.primaryInputManager.SystemDeviceConnectedEvent += SystemDeviceConnected;
			ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += SystemDeviceDisconnected;
			UpdateDeviceList();
			ready = true;
		}

		public void Update()
		{
			if (!ready)
			{
				return;
			}
			textBuffer = "Raw Input Joystick Element Identifier\n\n";
			this.text.text = textBuffer;
			int num = currentDeviceId;
			Guid guid = deviceInstanceGuid;
			if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
			{
				currentDeviceId++;
			}
			if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
			{
				currentDeviceId--;
			}
			if (refreshNow)
			{
				UpdateDeviceList();
				refreshNow = false;
			}
			int num2 = ((MciGSvBuvceUrKFLCLFInuEHfOYj != null) ? MciGSvBuvceUrKFLCLFInuEHfOYj.Count : 0);
			if (num2 == 0)
			{
				return;
			}
			if (currentDeviceId < 0)
			{
				currentDeviceId = num2 - 1;
			}
			else if (currentDeviceId >= num2)
			{
				currentDeviceId = 0;
			}
			deviceInstanceGuid = MciGSvBuvceUrKFLCLFInuEHfOYj[currentDeviceId].InstanceGuid;
			bool flag = false;
			if (num != currentDeviceId || guid != deviceInstanceGuid)
			{
				flag = true;
			}
			if (AUIdfqdotGKPVLbiMbUhWyorbHfX == null || flag)
			{
				if (AUIdfqdotGKPVLbiMbUhWyorbHfX != null)
				{
					AUIdfqdotGKPVLbiMbUhWyorbHfX.UWOOMlZOWZtWbNikUvqswMufgfx();
				}
				AUIdfqdotGKPVLbiMbUhWyorbHfX = MciGSvBuvceUrKFLCLFInuEHfOYj[currentDeviceId];
				if (AUIdfqdotGKPVLbiMbUhWyorbHfX == null)
				{
					return;
				}
				AUIdfqdotGKPVLbiMbUhWyorbHfX.HyqAXbAgFcqWiYfxZzBDTyqsqlp();
			}
			bool flag2 = false;
			if (AUIdfqdotGKPVLbiMbUhWyorbHfX.AxesState is tWkKNCXIrnFwxZTVcetdQCqcJSr)
			{
				flag2 = true;
			}
			else if (!(AUIdfqdotGKPVLbiMbUhWyorbHfX.AxesState is btyGStVvEsLNfhSsaBhklVtiGypg))
			{
				return;
			}
			if (num2 > 0)
			{
				textBuffer = textBuffer + num2 + " connected devices:\n";
			}
			for (int i = 0; i < num2; i++)
			{
				textBuffer = textBuffer + MciGSvBuvceUrKFLCLFInuEHfOYj[i].ProductName + "\n";
			}
			textBuffer += "\n";
			object obj = textBuffer;
			textBuffer = string.Concat(obj, "Current RI device ", currentDeviceId, ": \"", AUIdfqdotGKPVLbiMbUhWyorbHfX.ProductName, "\"\n");
			textBuffer += "(Press + or - to change monitored device id.)\n\n";
			Log("Product Name", "\"" + AUIdfqdotGKPVLbiMbUhWyorbHfX.ProductName + "\"");
			Log("Is Bluetooth Device", AUIdfqdotGKPVLbiMbUhWyorbHfX.IsBluetoothDevice);
			if (AUIdfqdotGKPVLbiMbUhWyorbHfX.IsBluetoothDevice)
			{
				Log("Bluetooth Device Name", "\"" + AUIdfqdotGKPVLbiMbUhWyorbHfX.BluetoothDeviceName + "\"");
			}
			if (flag2)
			{
				Log("Using Custom Driver", "TRUE");
			}
			Log("Device Type", AUIdfqdotGKPVLbiMbUhWyorbHfX.DeviceType.ToString());
			Log("Identifier", new PidVid(AUIdfqdotGKPVLbiMbUhWyorbHfX.ProductGuid));
			Log("Product Id", AUIdfqdotGKPVLbiMbUhWyorbHfX.ProductId);
			Log("Vendor Id", AUIdfqdotGKPVLbiMbUhWyorbHfX.VendorId);
			textBuffer += "\n";
			Log("Axis Count", AUIdfqdotGKPVLbiMbUhWyorbHfX.AxisCount);
			Log("Button Count", AUIdfqdotGKPVLbiMbUhWyorbHfX.ButtonCount);
			Log("Hat Count", AUIdfqdotGKPVLbiMbUhWyorbHfX.HatCount);
			textBuffer += "\n";
			if (flag)
			{
				string text = "";
				text = text + "Device Name: \"" + MciGSvBuvceUrKFLCLFInuEHfOYj[currentDeviceId].ProductName + "\"\n";
				if (AUIdfqdotGKPVLbiMbUhWyorbHfX.IsBluetoothDevice)
				{
					text = text + "Bluetooth Device Name: \"" + AUIdfqdotGKPVLbiMbUhWyorbHfX.BluetoothDeviceName + "\"\n";
				}
				object obj2 = text;
				text = string.Concat(obj2, "Identifier: ", new PidVid(AUIdfqdotGKPVLbiMbUhWyorbHfX.ProductGuid), "\n");
				Logger.Log(text);
			}
			if (!flag2)
			{
				btyGStVvEsLNfhSsaBhklVtiGypg btyGStVvEsLNfhSsaBhklVtiGypg2 = AUIdfqdotGKPVLbiMbUhWyorbHfX.AxesState as btyGStVvEsLNfhSsaBhklVtiGypg;
				for (int j = 1; j < axisNames.Length - 1; j++)
				{
					int num3 = LaNWitWQqyZMqUSPioBpzBMOpwf((RawInputAxis)axisValues[j], 0, btyGStVvEsLNfhSsaBhklVtiGypg2);
					string key = axisNames[j];
					try
					{
						Log(key, num3 + " (" + NormalizeAxis(num3) + ")");
					}
					catch
					{
						Log(key, "FAILED! Axis value = " + num3);
					}
				}
				if (btyGStVvEsLNfhSsaBhklVtiGypg2.otherAxisCount > 0)
				{
					for (int k = 0; k < btyGStVvEsLNfhSsaBhklVtiGypg2.otherAxisCount; k++)
					{
						int num4 = LaNWitWQqyZMqUSPioBpzBMOpwf(RawInputAxis.Other, k, btyGStVvEsLNfhSsaBhklVtiGypg2);
						string key2 = "Other Axis " + k;
						try
						{
							Log(key2, num4 + " (" + NormalizeAxis(num4) + ")");
						}
						catch
						{
							Log(key2, "FAILED! Axis value = " + num4);
						}
					}
				}
				int[] hatValues = AUIdfqdotGKPVLbiMbUhWyorbHfX.HatValues;
				for (int l = 0; l < hatValues.Length; l++)
				{
					int num5 = hatValues[l];
					string key3 = "Hat " + l;
					Log(key3, num5);
				}
				bool[] buttons = AUIdfqdotGKPVLbiMbUhWyorbHfX.Buttons;
				string text2 = "";
				for (int m = 0; m < buttons.Length; m++)
				{
					if (buttons[m])
					{
						if (text2 != "")
						{
							text2 += ", ";
						}
						text2 += m;
					}
				}
				Log("Buttons ", text2);
			}
			else
			{
				tWkKNCXIrnFwxZTVcetdQCqcJSr tWkKNCXIrnFwxZTVcetdQCqcJSr2 = AUIdfqdotGKPVLbiMbUhWyorbHfX.AxesState as tWkKNCXIrnFwxZTVcetdQCqcJSr;
				for (int n = 0; n < AUIdfqdotGKPVLbiMbUhWyorbHfX.AxisCount; n++)
				{
					float num6 = tWkKNCXIrnFwxZTVcetdQCqcJSr2.LaNWitWQqyZMqUSPioBpzBMOpwf(n);
					string key4 = n.ToString();
					try
					{
						Log(key4, num6.ToString() + " (" + tWkKNCXIrnFwxZTVcetdQCqcJSr2.zPyoQbZsbhrGwxLWYeqdGHaGfFs(n) + ")");
					}
					catch
					{
						Log(key4, "FAILED! Axis value = " + num6);
					}
				}
				int[] hatValues2 = AUIdfqdotGKPVLbiMbUhWyorbHfX.HatValues;
				for (int num7 = 0; num7 < AUIdfqdotGKPVLbiMbUhWyorbHfX.HatCount; num7++)
				{
					int num8 = hatValues2[num7];
					string key5 = "Hat " + num7;
					Log(key5, num8);
				}
				for (int num9 = 0; num9 < AUIdfqdotGKPVLbiMbUhWyorbHfX.Driver.GyroscopeCount; num9++)
				{
					int valueLength = AUIdfqdotGKPVLbiMbUhWyorbHfX.Driver.gyroscopes[num9].valueLength;
					string text3 = "";
					for (int num10 = 0; num10 < valueLength; num10++)
					{
						float num11 = AUIdfqdotGKPVLbiMbUhWyorbHfX.Driver.gyroscopes[num9].rawValue[num10];
						object obj6 = text3;
						text3 = string.Concat(obj6, "[", num10, "]: ", num11.ToString("f3"));
						if (num10 < valueLength - 1)
						{
							text3 += " ";
						}
					}
					Log("Gyro " + num9, text3);
				}
				for (int num12 = 0; num12 < AUIdfqdotGKPVLbiMbUhWyorbHfX.Driver.AccelerometerCount; num12++)
				{
					int valueLength2 = AUIdfqdotGKPVLbiMbUhWyorbHfX.Driver.accelerometers[num12].valueLength;
					string text4 = "";
					for (int num13 = 0; num13 < valueLength2; num13++)
					{
						float num14 = AUIdfqdotGKPVLbiMbUhWyorbHfX.Driver.accelerometers[num12].rawValue[num13];
						object obj7 = text4;
						text4 = string.Concat(obj7, "[", num13, "]: ", num14.ToString("f3"));
						if (num13 < valueLength2 - 1)
						{
							text4 += " ";
						}
					}
					Log("Accelerometer " + num12, text4);
				}
				for (int num15 = 0; num15 < AUIdfqdotGKPVLbiMbUhWyorbHfX.Driver.TouchpadCount; num15++)
				{
					HIDTouchpad hIDTouchpad = AUIdfqdotGKPVLbiMbUhWyorbHfX.Driver.touchpads[num15];
					int num16 = hIDTouchpad.values.Length;
					string text5 = "";
					for (int num17 = 0; num17 < num16; num17++)
					{
						HIDTouchpad.TouchData touchData = hIDTouchpad.values[num17];
						obj = text5;
						text5 = string.Concat(obj, "Touch ", num17, ": Is Touching = ", touchData.isTouching, "\n");
						obj = text5;
						text5 = string.Concat(obj, "Touch ", num17, ": Touch Id = ", touchData.touchId, "\n");
						obj = text5;
						text5 = string.Concat(obj, "Touch ", num17, ": Position = ", touchData.positionX, ", ", touchData.positionY, "\n");
						obj = text5;
						text5 = string.Concat(obj, "Touch ", num17, ": Abs Position = ", touchData.positionAbsX, ", ", touchData.positionAbsY, " (", touchData.positionRawX, ", ", touchData.positionRawY, ")\n");
					}
					LogSet("Touchpad " + num15, text5);
				}
				bool[] buttons2 = AUIdfqdotGKPVLbiMbUhWyorbHfX.Buttons;
				string text6 = "";
				for (int num18 = 0; num18 < buttons2.Length; num18++)
				{
					if (buttons2[num18])
					{
						if (text6 != "")
						{
							text6 += ", ";
						}
						text6 += num18;
					}
				}
				Log("Buttons ", text6);
			}
			this.text.text = textBuffer;
		}

		public void OnDestroy()
		{
			if (AUIdfqdotGKPVLbiMbUhWyorbHfX != null)
			{
				AUIdfqdotGKPVLbiMbUhWyorbHfX.UWOOMlZOWZtWbNikUvqswMufgfx();
			}
		}

		private void UpdateDeviceList()
		{
			MciGSvBuvceUrKFLCLFInuEHfOYj = dgeymjwCdGAtHTMwapVjdBigBLF.GetJoysticks<TPOFglCEUenQueqhakDnrjLmVbgq>();
		}

		private void SystemDeviceConnected()
		{
			Refresh();
		}

		private void SystemDeviceDisconnected()
		{
			Refresh();
		}

		private void Refresh()
		{
			Clear();
			refreshNow = true;
		}

		private void Clear()
		{
			currentDeviceId = 0;
			AUIdfqdotGKPVLbiMbUhWyorbHfX = null;
			deviceInstanceGuid = Guid.Empty;
			MciGSvBuvceUrKFLCLFInuEHfOYj = null;
			showAllDevices = false;
			refreshNow = false;
		}

		private void Log(string key, object value)
		{
			string text = textBuffer;
			textBuffer = text + key + " = " + value.ToString() + "\n";
		}

		private void LogSet(string label, object value)
		{
			string text = textBuffer;
			textBuffer = text + label + ":\n" + value.ToString() + "\n";
		}

		private int LaNWitWQqyZMqUSPioBpzBMOpwf(RawInputAxis P_0, int P_1, btyGStVvEsLNfhSsaBhklVtiGypg P_2)
		{
			return P_2.LaNWitWQqyZMqUSPioBpzBMOpwf(P_0, P_1);
		}

		private float NormalizeAxis(int value)
		{
			if (value == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(value) / 65535f * (float)MathTools.Sign(value), -1f, 1f);
		}
	}
}
