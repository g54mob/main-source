using System;
using System.Collections.Generic;
using Rewired;
using Rewired.HID;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class FJjFSiKxTOUEcBSveasXiHwaIyj : IElementIdentifierTool
{
	private Rewired.Internal.GUIText sCXrcRxxEvSNPlFSyjevCbwjDpDE;

	private string GSZGHGdaQFfWDPcQvhvdfRFjiIiV;

	private int DcXhJciIRzxmOJhYUnuTDChztuP;

	private CDUDUtloSCOYNTanpthEeshuCdC pnktKZzYVXGXdrcxDcbedpHLExC;

	private XISatJdVArtMUkOXRoGcIhpgBatq IAYCyCCfxLADdcDSjhLuqwShOQyR;

	private Guid uIxglbDvQxIdHtidiaJZRSFHviO;

	private IList<XISatJdVArtMUkOXRoGcIhpgBatq> UiueHXbfdzXSDcdtjqILFukiDRXY;

	private bool AAZkfGnNpnzmxHESABcweKtNqMKc;

	private bool AJeirwxBSXczjCmdbGIsmyYYVER;

	private bool pfiWixHBjQdcaVlrVnqrgVIxusv;

	private string[] LqlgUZghlQDjUTUQwgAXDregGueP;

	private int[] uRZODPFIHhFcRebPBGmcTCCqFywb;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		sCXrcRxxEvSNPlFSyjevCbwjDpDE = text;
		LqlgUZghlQDjUTUQwgAXDregGueP = Enum.GetNames(typeof(RawInputAxis));
		uRZODPFIHhFcRebPBGmcTCCqFywb = (int[])Enum.GetValues(typeof(RawInputAxis));
	}

	public void Start()
	{
		if (ReInput.isEditor && ReInput.editorPlatform != EditorPlatform.Windows)
		{
			Rewired.Logger.LogError("Raw Input cannot be run on this platform. You must be running the editor in Windows.");
			return;
		}
		if (ReInput.currentPlatform != Platform.Windows)
		{
			Rewired.Logger.LogError("Raw Input cannot be run on this build target. Be sure Unity's build target is set to Windows Standalone.");
			return;
		}
		pnktKZzYVXGXdrcxDcbedpHLExC = ReInput.primaryInputManager.inputSource as CDUDUtloSCOYNTanpthEeshuCdC;
		if (pnktKZzYVXGXdrcxDcbedpHLExC == null)
		{
			Rewired.Logger.LogError("Unable to initialize Raw Input! You must add a Rewired Input Manager to the scene and set the input mode to Raw Input.");
			return;
		}
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += CnTKZWfhtJJAtxjcyslTcfkrqOH;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += EfsXOmpDhUnNPXNISrmnfnXFdTW;
		gLAITACQupcsXaeprKsFOosklIl();
		pfiWixHBjQdcaVlrVnqrgVIxusv = true;
	}

	public void Update()
	{
		if (!pfiWixHBjQdcaVlrVnqrgVIxusv)
		{
			return;
		}
		GSZGHGdaQFfWDPcQvhvdfRFjiIiV = "Raw Input Joystick Element Identifier\n\n";
		sCXrcRxxEvSNPlFSyjevCbwjDpDE.text = GSZGHGdaQFfWDPcQvhvdfRFjiIiV;
		int dcXhJciIRzxmOJhYUnuTDChztuP = DcXhJciIRzxmOJhYUnuTDChztuP;
		Guid guid = uIxglbDvQxIdHtidiaJZRSFHviO;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			DcXhJciIRzxmOJhYUnuTDChztuP++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			DcXhJciIRzxmOJhYUnuTDChztuP--;
		}
		if (AJeirwxBSXczjCmdbGIsmyYYVER)
		{
			gLAITACQupcsXaeprKsFOosklIl();
			AJeirwxBSXczjCmdbGIsmyYYVER = false;
		}
		int num = ((UiueHXbfdzXSDcdtjqILFukiDRXY != null) ? UiueHXbfdzXSDcdtjqILFukiDRXY.Count : 0);
		if (num == 0)
		{
			return;
		}
		if (DcXhJciIRzxmOJhYUnuTDChztuP < 0)
		{
			DcXhJciIRzxmOJhYUnuTDChztuP = num - 1;
		}
		else if (DcXhJciIRzxmOJhYUnuTDChztuP >= num)
		{
			DcXhJciIRzxmOJhYUnuTDChztuP = 0;
		}
		uIxglbDvQxIdHtidiaJZRSFHviO = UiueHXbfdzXSDcdtjqILFukiDRXY[DcXhJciIRzxmOJhYUnuTDChztuP].InstanceGuid;
		bool flag = false;
		if (dcXhJciIRzxmOJhYUnuTDChztuP != DcXhJciIRzxmOJhYUnuTDChztuP || guid != uIxglbDvQxIdHtidiaJZRSFHviO)
		{
			flag = true;
		}
		if (IAYCyCCfxLADdcDSjhLuqwShOQyR == null || flag)
		{
			if (IAYCyCCfxLADdcDSjhLuqwShOQyR != null)
			{
				IAYCyCCfxLADdcDSjhLuqwShOQyR.SdCpHXCeCCZSBrMShYjjsXEWWgu();
			}
			IAYCyCCfxLADdcDSjhLuqwShOQyR = UiueHXbfdzXSDcdtjqILFukiDRXY[DcXhJciIRzxmOJhYUnuTDChztuP];
			if (IAYCyCCfxLADdcDSjhLuqwShOQyR == null)
			{
				return;
			}
			IAYCyCCfxLADdcDSjhLuqwShOQyR.DfoHKTaxZzJSYcaLwTWUBUINGoo();
		}
		bool flag2 = false;
		if (IAYCyCCfxLADdcDSjhLuqwShOQyR.AxesState is vqgaTeSNhmAyVtJlBJtiEGOLEPoO)
		{
			flag2 = true;
		}
		else if (!(IAYCyCCfxLADdcDSjhLuqwShOQyR.AxesState is zzueNJUhUtGPFEHSXaerdfBbDbiW))
		{
			return;
		}
		if (num > 0)
		{
			GSZGHGdaQFfWDPcQvhvdfRFjiIiV = GSZGHGdaQFfWDPcQvhvdfRFjiIiV + num + " connected devices:\n";
		}
		for (int i = 0; i < num; i++)
		{
			GSZGHGdaQFfWDPcQvhvdfRFjiIiV = GSZGHGdaQFfWDPcQvhvdfRFjiIiV + UiueHXbfdzXSDcdtjqILFukiDRXY[i].ProductName + "\n";
		}
		GSZGHGdaQFfWDPcQvhvdfRFjiIiV += "\n";
		object gSZGHGdaQFfWDPcQvhvdfRFjiIiV = GSZGHGdaQFfWDPcQvhvdfRFjiIiV;
		GSZGHGdaQFfWDPcQvhvdfRFjiIiV = string.Concat(gSZGHGdaQFfWDPcQvhvdfRFjiIiV, "Current RI device ", DcXhJciIRzxmOJhYUnuTDChztuP, ": \"", IAYCyCCfxLADdcDSjhLuqwShOQyR.ProductName, "\"\n");
		GSZGHGdaQFfWDPcQvhvdfRFjiIiV += "(Press + or - to change monitored device id.)\n\n";
		NCScKtADzeppzSpslQSpTRFVnWmX("Product Name", "\"" + IAYCyCCfxLADdcDSjhLuqwShOQyR.ProductName + "\"");
		NCScKtADzeppzSpslQSpTRFVnWmX("Is Bluetooth Device", IAYCyCCfxLADdcDSjhLuqwShOQyR.IsBluetoothDevice);
		if (IAYCyCCfxLADdcDSjhLuqwShOQyR.IsBluetoothDevice)
		{
			NCScKtADzeppzSpslQSpTRFVnWmX("Bluetooth Device Name", "\"" + IAYCyCCfxLADdcDSjhLuqwShOQyR.BluetoothDeviceName + "\"");
		}
		if (flag2)
		{
			NCScKtADzeppzSpslQSpTRFVnWmX("Using Custom Driver", "TRUE");
		}
		NCScKtADzeppzSpslQSpTRFVnWmX("Device Type", IAYCyCCfxLADdcDSjhLuqwShOQyR.DeviceType.ToString());
		NCScKtADzeppzSpslQSpTRFVnWmX("Identifier", new PidVid(IAYCyCCfxLADdcDSjhLuqwShOQyR.ProductGuid));
		NCScKtADzeppzSpslQSpTRFVnWmX("Product Id", IAYCyCCfxLADdcDSjhLuqwShOQyR.ProductId);
		NCScKtADzeppzSpslQSpTRFVnWmX("Vendor Id", IAYCyCCfxLADdcDSjhLuqwShOQyR.VendorId);
		GSZGHGdaQFfWDPcQvhvdfRFjiIiV += "\n";
		NCScKtADzeppzSpslQSpTRFVnWmX("Axis Count", IAYCyCCfxLADdcDSjhLuqwShOQyR.AxisCount);
		NCScKtADzeppzSpslQSpTRFVnWmX("Button Count", IAYCyCCfxLADdcDSjhLuqwShOQyR.ButtonCount);
		NCScKtADzeppzSpslQSpTRFVnWmX("Hat Count", IAYCyCCfxLADdcDSjhLuqwShOQyR.HatCount);
		GSZGHGdaQFfWDPcQvhvdfRFjiIiV += "\n";
		if (flag)
		{
			string text = "";
			text = text + "Device Name: \"" + UiueHXbfdzXSDcdtjqILFukiDRXY[DcXhJciIRzxmOJhYUnuTDChztuP].ProductName + "\"\n";
			if (IAYCyCCfxLADdcDSjhLuqwShOQyR.IsBluetoothDevice)
			{
				text = text + "Bluetooth Device Name: \"" + IAYCyCCfxLADdcDSjhLuqwShOQyR.BluetoothDeviceName + "\"\n";
			}
			object obj = text;
			text = string.Concat(obj, "Identifier: ", new PidVid(IAYCyCCfxLADdcDSjhLuqwShOQyR.ProductGuid), "\n");
			Rewired.Logger.Log(text);
		}
		if (!flag2)
		{
			zzueNJUhUtGPFEHSXaerdfBbDbiW zzueNJUhUtGPFEHSXaerdfBbDbiW2 = IAYCyCCfxLADdcDSjhLuqwShOQyR.AxesState as zzueNJUhUtGPFEHSXaerdfBbDbiW;
			for (int j = 1; j < LqlgUZghlQDjUTUQwgAXDregGueP.Length - 1; j++)
			{
				int num2 = TgLPLRPKTlXSaoodLpemjkZzehs((RawInputAxis)uRZODPFIHhFcRebPBGmcTCCqFywb[j], 0, zzueNJUhUtGPFEHSXaerdfBbDbiW2);
				string text2 = LqlgUZghlQDjUTUQwgAXDregGueP[j];
				try
				{
					NCScKtADzeppzSpslQSpTRFVnWmX(text2, num2 + " (" + gGNoAhCUXzgDbDcskWksokriYti(num2) + ")");
				}
				catch
				{
					NCScKtADzeppzSpslQSpTRFVnWmX(text2, "FAILED! Axis value = " + num2);
				}
			}
			if (zzueNJUhUtGPFEHSXaerdfBbDbiW2.otherAxisCount > 0)
			{
				for (int k = 0; k < zzueNJUhUtGPFEHSXaerdfBbDbiW2.otherAxisCount; k++)
				{
					int num3 = TgLPLRPKTlXSaoodLpemjkZzehs(RawInputAxis.Other, k, zzueNJUhUtGPFEHSXaerdfBbDbiW2);
					string text3 = "Other Axis " + k;
					try
					{
						NCScKtADzeppzSpslQSpTRFVnWmX(text3, num3 + " (" + gGNoAhCUXzgDbDcskWksokriYti(num3) + ")");
					}
					catch
					{
						NCScKtADzeppzSpslQSpTRFVnWmX(text3, "FAILED! Axis value = " + num3);
					}
				}
			}
			int[] hatValues = IAYCyCCfxLADdcDSjhLuqwShOQyR.HatValues;
			for (int l = 0; l < hatValues.Length; l++)
			{
				int num4 = hatValues[l];
				string text4 = "Hat " + l;
				NCScKtADzeppzSpslQSpTRFVnWmX(text4, num4);
			}
			bool[] buttons = IAYCyCCfxLADdcDSjhLuqwShOQyR.Buttons;
			string text5 = "";
			for (int m = 0; m < buttons.Length; m++)
			{
				if (buttons[m])
				{
					if (text5 != "")
					{
						text5 += ", ";
					}
					text5 += m;
				}
			}
			NCScKtADzeppzSpslQSpTRFVnWmX("Buttons ", text5);
		}
		else
		{
			vqgaTeSNhmAyVtJlBJtiEGOLEPoO vqgaTeSNhmAyVtJlBJtiEGOLEPoO2 = IAYCyCCfxLADdcDSjhLuqwShOQyR.AxesState as vqgaTeSNhmAyVtJlBJtiEGOLEPoO;
			for (int n = 0; n < IAYCyCCfxLADdcDSjhLuqwShOQyR.AxisCount; n++)
			{
				float num5 = vqgaTeSNhmAyVtJlBJtiEGOLEPoO2.TgLPLRPKTlXSaoodLpemjkZzehs(n);
				string text6 = n.ToString();
				try
				{
					NCScKtADzeppzSpslQSpTRFVnWmX(text6, num5.ToString() + " (" + vqgaTeSNhmAyVtJlBJtiEGOLEPoO2.bJeQDLCZhwsCMRQohStcMgMhoQx(n) + ")");
				}
				catch
				{
					NCScKtADzeppzSpslQSpTRFVnWmX(text6, "FAILED! Axis value = " + num5);
				}
			}
			int[] hatValues2 = IAYCyCCfxLADdcDSjhLuqwShOQyR.HatValues;
			for (int num6 = 0; num6 < IAYCyCCfxLADdcDSjhLuqwShOQyR.HatCount; num6++)
			{
				int num7 = hatValues2[num6];
				string text7 = "Hat " + num6;
				NCScKtADzeppzSpslQSpTRFVnWmX(text7, num7);
			}
			for (int num8 = 0; num8 < IAYCyCCfxLADdcDSjhLuqwShOQyR.Driver.GyroscopeCount; num8++)
			{
				int valueLength = IAYCyCCfxLADdcDSjhLuqwShOQyR.Driver.gyroscopes[num8].valueLength;
				string text8 = "";
				for (int num9 = 0; num9 < valueLength; num9++)
				{
					float num10 = IAYCyCCfxLADdcDSjhLuqwShOQyR.Driver.gyroscopes[num8].rawValue[num9];
					object obj5 = text8;
					text8 = string.Concat(obj5, "[", num9, "]: ", num10.ToString("f3"));
					if (num9 < valueLength - 1)
					{
						text8 += " ";
					}
				}
				NCScKtADzeppzSpslQSpTRFVnWmX("Gyro " + num8, text8);
			}
			for (int num11 = 0; num11 < IAYCyCCfxLADdcDSjhLuqwShOQyR.Driver.AccelerometerCount; num11++)
			{
				int valueLength2 = IAYCyCCfxLADdcDSjhLuqwShOQyR.Driver.accelerometers[num11].valueLength;
				string text9 = "";
				for (int num12 = 0; num12 < valueLength2; num12++)
				{
					float num13 = IAYCyCCfxLADdcDSjhLuqwShOQyR.Driver.accelerometers[num11].rawValue[num12];
					object obj6 = text9;
					text9 = string.Concat(obj6, "[", num12, "]: ", num13.ToString("f3"));
					if (num12 < valueLength2 - 1)
					{
						text9 += " ";
					}
				}
				NCScKtADzeppzSpslQSpTRFVnWmX("Accelerometer " + num11, text9);
			}
			for (int num14 = 0; num14 < IAYCyCCfxLADdcDSjhLuqwShOQyR.Driver.TouchpadCount; num14++)
			{
				HIDTouchpad hIDTouchpad = IAYCyCCfxLADdcDSjhLuqwShOQyR.Driver.touchpads[num14];
				int num15 = hIDTouchpad.values.Length;
				string text10 = "";
				for (int num16 = 0; num16 < num15; num16++)
				{
					HIDTouchpad.TouchData touchData = hIDTouchpad.values[num16];
					gSZGHGdaQFfWDPcQvhvdfRFjiIiV = text10;
					text10 = string.Concat(gSZGHGdaQFfWDPcQvhvdfRFjiIiV, "Touch ", num16, ": Is Touching = ", touchData.isTouching, "\n");
					gSZGHGdaQFfWDPcQvhvdfRFjiIiV = text10;
					text10 = string.Concat(gSZGHGdaQFfWDPcQvhvdfRFjiIiV, "Touch ", num16, ": Touch Id = ", touchData.touchId, "\n");
					gSZGHGdaQFfWDPcQvhvdfRFjiIiV = text10;
					text10 = string.Concat(gSZGHGdaQFfWDPcQvhvdfRFjiIiV, "Touch ", num16, ": Position = ", touchData.positionX, ", ", touchData.positionY, "\n");
					gSZGHGdaQFfWDPcQvhvdfRFjiIiV = text10;
					text10 = string.Concat(gSZGHGdaQFfWDPcQvhvdfRFjiIiV, "Touch ", num16, ": Abs Position = ", touchData.positionAbsX, ", ", touchData.positionAbsY, " (", touchData.positionRawX, ", ", touchData.positionRawY, ")\n");
				}
				XFvQGSZLZBZMgvkzsfDDeCYnFXR("Touchpad " + num14, text10);
			}
			bool[] buttons2 = IAYCyCCfxLADdcDSjhLuqwShOQyR.Buttons;
			string text11 = "";
			for (int num17 = 0; num17 < buttons2.Length; num17++)
			{
				if (buttons2[num17])
				{
					if (text11 != "")
					{
						text11 += ", ";
					}
					text11 += num17;
				}
			}
			NCScKtADzeppzSpslQSpTRFVnWmX("Buttons ", text11);
		}
		sCXrcRxxEvSNPlFSyjevCbwjDpDE.text = GSZGHGdaQFfWDPcQvhvdfRFjiIiV;
	}

	public void OnDestroy()
	{
		if (IAYCyCCfxLADdcDSjhLuqwShOQyR != null)
		{
			IAYCyCCfxLADdcDSjhLuqwShOQyR.SdCpHXCeCCZSBrMShYjjsXEWWgu();
		}
	}

	private void gLAITACQupcsXaeprKsFOosklIl()
	{
		UiueHXbfdzXSDcdtjqILFukiDRXY = pnktKZzYVXGXdrcxDcbedpHLExC.GetJoysticks<XISatJdVArtMUkOXRoGcIhpgBatq>();
	}

	private void CnTKZWfhtJJAtxjcyslTcfkrqOH()
	{
		YYIbizKGxLGaVnJRqxHgOoZTMpK();
	}

	private void EfsXOmpDhUnNPXNISrmnfnXFdTW()
	{
		YYIbizKGxLGaVnJRqxHgOoZTMpK();
	}

	private void YYIbizKGxLGaVnJRqxHgOoZTMpK()
	{
		avkcOhFlGGeHrNSdTQlLZUnJDbw();
		AJeirwxBSXczjCmdbGIsmyYYVER = true;
	}

	private void avkcOhFlGGeHrNSdTQlLZUnJDbw()
	{
		DcXhJciIRzxmOJhYUnuTDChztuP = 0;
		IAYCyCCfxLADdcDSjhLuqwShOQyR = null;
		uIxglbDvQxIdHtidiaJZRSFHviO = Guid.Empty;
		UiueHXbfdzXSDcdtjqILFukiDRXY = null;
		AAZkfGnNpnzmxHESABcweKtNqMKc = false;
		AJeirwxBSXczjCmdbGIsmyYYVER = false;
	}

	private void NCScKtADzeppzSpslQSpTRFVnWmX(string P_0, object P_1)
	{
		string gSZGHGdaQFfWDPcQvhvdfRFjiIiV = GSZGHGdaQFfWDPcQvhvdfRFjiIiV;
		GSZGHGdaQFfWDPcQvhvdfRFjiIiV = gSZGHGdaQFfWDPcQvhvdfRFjiIiV + P_0 + " = " + P_1.ToString() + "\n";
	}

	private void XFvQGSZLZBZMgvkzsfDDeCYnFXR(string P_0, object P_1)
	{
		string gSZGHGdaQFfWDPcQvhvdfRFjiIiV = GSZGHGdaQFfWDPcQvhvdfRFjiIiV;
		GSZGHGdaQFfWDPcQvhvdfRFjiIiV = gSZGHGdaQFfWDPcQvhvdfRFjiIiV + P_0 + ":\n" + P_1.ToString() + "\n";
	}

	private int TgLPLRPKTlXSaoodLpemjkZzehs(RawInputAxis P_0, int P_1, zzueNJUhUtGPFEHSXaerdfBbDbiW P_2)
	{
		return P_2.TgLPLRPKTlXSaoodLpemjkZzehs(P_0, P_1);
	}

	private float gGNoAhCUXzgDbDcskWksokriYti(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
