using System;
using System.Collections.Generic;
using Rewired;
using Rewired.HID;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class YbQNplXBvPJYJvZbPAxsJBsfHUx : IElementIdentifierTool
{
	private Rewired.Internal.GUIText vVwNRYmxiqFQsVlAFkECrFJoNrL;

	private string RXoxPsjwFUIfgQWMIHeCesmxKsg;

	private int KWiwVtjcbaUptzhIrmTesQCcxnP;

	private TnbctswGyXOsohdhCkTtNqIlEbQG gBFcFEjcuYMKWkPeeMELlKKAWMAI;

	private UzKBIaEyudSpXeLmfwTkGCYvktG PFnOTHqJnYDWzxCOYtTyZdOVMyq;

	private Guid tVCUIwIKXkQOKHmeFaKweatIKpKx;

	private IList<UzKBIaEyudSpXeLmfwTkGCYvktG> LmBfMWqHGmQaOJfTCmwmVNNdPTl;

	private bool DQgTsBsHBsEsEpUIpcYNvgCYLSQ;

	private bool LXNyCvqHsWRkEovtIKsRXNxReHF;

	private bool maDGezkYlRAxTrnfiBNQuPayqytk;

	private string[] QvCgfIgJETfOpaQYLaaiGJLJwBu;

	private int[] tYsrmWYljgyiuPeNcaSXzQxduHg;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		vVwNRYmxiqFQsVlAFkECrFJoNrL = text;
		QvCgfIgJETfOpaQYLaaiGJLJwBu = Enum.GetNames(typeof(RawInputAxis));
		tYsrmWYljgyiuPeNcaSXzQxduHg = (int[])Enum.GetValues(typeof(RawInputAxis));
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
		gBFcFEjcuYMKWkPeeMELlKKAWMAI = ReInput.primaryInputManager.inputSource as TnbctswGyXOsohdhCkTtNqIlEbQG;
		if (gBFcFEjcuYMKWkPeeMELlKKAWMAI == null)
		{
			Rewired.Logger.LogError("Unable to initialize Raw Input! You must add a Rewired Input Manager to the scene and set the input mode to Raw Input.");
			return;
		}
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += HWybtVeZZUDEUVZkTRDyLxFgrON;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += VQNmCjqHHJHMkrdAfOzYWMyKBMA;
		pvhdfRPuYoBmeUzxAGGmjRPxTIr();
		maDGezkYlRAxTrnfiBNQuPayqytk = true;
	}

	public void Update()
	{
		if (!maDGezkYlRAxTrnfiBNQuPayqytk)
		{
			return;
		}
		RXoxPsjwFUIfgQWMIHeCesmxKsg = "Raw Input Joystick Element Identifier\n\n";
		vVwNRYmxiqFQsVlAFkECrFJoNrL.text = RXoxPsjwFUIfgQWMIHeCesmxKsg;
		int kWiwVtjcbaUptzhIrmTesQCcxnP = KWiwVtjcbaUptzhIrmTesQCcxnP;
		Guid guid = tVCUIwIKXkQOKHmeFaKweatIKpKx;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			KWiwVtjcbaUptzhIrmTesQCcxnP++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			KWiwVtjcbaUptzhIrmTesQCcxnP--;
		}
		if (LXNyCvqHsWRkEovtIKsRXNxReHF)
		{
			pvhdfRPuYoBmeUzxAGGmjRPxTIr();
			LXNyCvqHsWRkEovtIKsRXNxReHF = false;
		}
		int num = ((LmBfMWqHGmQaOJfTCmwmVNNdPTl != null) ? LmBfMWqHGmQaOJfTCmwmVNNdPTl.Count : 0);
		if (num == 0)
		{
			return;
		}
		if (KWiwVtjcbaUptzhIrmTesQCcxnP < 0)
		{
			KWiwVtjcbaUptzhIrmTesQCcxnP = num - 1;
		}
		else if (KWiwVtjcbaUptzhIrmTesQCcxnP >= num)
		{
			KWiwVtjcbaUptzhIrmTesQCcxnP = 0;
		}
		tVCUIwIKXkQOKHmeFaKweatIKpKx = LmBfMWqHGmQaOJfTCmwmVNNdPTl[KWiwVtjcbaUptzhIrmTesQCcxnP].InstanceGuid;
		bool flag = false;
		if (kWiwVtjcbaUptzhIrmTesQCcxnP != KWiwVtjcbaUptzhIrmTesQCcxnP || guid != tVCUIwIKXkQOKHmeFaKweatIKpKx)
		{
			flag = true;
		}
		if (PFnOTHqJnYDWzxCOYtTyZdOVMyq == null || flag)
		{
			if (PFnOTHqJnYDWzxCOYtTyZdOVMyq != null)
			{
				PFnOTHqJnYDWzxCOYtTyZdOVMyq.JkxbMOPQiVSbeNRGETMYZahHimc();
			}
			PFnOTHqJnYDWzxCOYtTyZdOVMyq = LmBfMWqHGmQaOJfTCmwmVNNdPTl[KWiwVtjcbaUptzhIrmTesQCcxnP];
			if (PFnOTHqJnYDWzxCOYtTyZdOVMyq == null)
			{
				return;
			}
			PFnOTHqJnYDWzxCOYtTyZdOVMyq.QqViEWwhZaWrvATfPuWfqnkWwbi();
		}
		bool flag2 = false;
		if (PFnOTHqJnYDWzxCOYtTyZdOVMyq.AxesState is saLjtbZSBxlqoNzvuSJHtknSlTo)
		{
			flag2 = true;
		}
		else if (!(PFnOTHqJnYDWzxCOYtTyZdOVMyq.AxesState is gjXrWEFBmmfJodbKaRYGCXcWpVk))
		{
			return;
		}
		if (num > 0)
		{
			RXoxPsjwFUIfgQWMIHeCesmxKsg = RXoxPsjwFUIfgQWMIHeCesmxKsg + num + " connected devices:\n";
		}
		for (int i = 0; i < num; i++)
		{
			RXoxPsjwFUIfgQWMIHeCesmxKsg = RXoxPsjwFUIfgQWMIHeCesmxKsg + LmBfMWqHGmQaOJfTCmwmVNNdPTl[i].ProductName + "\n";
		}
		RXoxPsjwFUIfgQWMIHeCesmxKsg += "\n";
		object rXoxPsjwFUIfgQWMIHeCesmxKsg = RXoxPsjwFUIfgQWMIHeCesmxKsg;
		RXoxPsjwFUIfgQWMIHeCesmxKsg = string.Concat(rXoxPsjwFUIfgQWMIHeCesmxKsg, "Current RI device ", KWiwVtjcbaUptzhIrmTesQCcxnP, ": \"", PFnOTHqJnYDWzxCOYtTyZdOVMyq.ProductName, "\"\n");
		RXoxPsjwFUIfgQWMIHeCesmxKsg += "(Press + or - to change monitored device id.)\n\n";
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Product Name", "\"" + PFnOTHqJnYDWzxCOYtTyZdOVMyq.ProductName + "\"");
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Is Bluetooth Device", PFnOTHqJnYDWzxCOYtTyZdOVMyq.IsBluetoothDevice);
		if (PFnOTHqJnYDWzxCOYtTyZdOVMyq.IsBluetoothDevice)
		{
			YgtqqyMBxpnWhXqnMcSwkqoAUek("Bluetooth Device Name", "\"" + PFnOTHqJnYDWzxCOYtTyZdOVMyq.BluetoothDeviceName + "\"");
		}
		if (flag2)
		{
			YgtqqyMBxpnWhXqnMcSwkqoAUek("Using Custom Driver", "TRUE");
		}
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Device Type", PFnOTHqJnYDWzxCOYtTyZdOVMyq.DeviceType.ToString());
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Identifier", new PidVid(PFnOTHqJnYDWzxCOYtTyZdOVMyq.ProductGuid));
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Product Id", PFnOTHqJnYDWzxCOYtTyZdOVMyq.ProductId);
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Vendor Id", PFnOTHqJnYDWzxCOYtTyZdOVMyq.VendorId);
		RXoxPsjwFUIfgQWMIHeCesmxKsg += "\n";
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Axis Count", PFnOTHqJnYDWzxCOYtTyZdOVMyq.AxisCount);
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Button Count", PFnOTHqJnYDWzxCOYtTyZdOVMyq.ButtonCount);
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Hat Count", PFnOTHqJnYDWzxCOYtTyZdOVMyq.HatCount);
		RXoxPsjwFUIfgQWMIHeCesmxKsg += "\n";
		if (flag)
		{
			string text = "";
			text = text + "Device Name: \"" + LmBfMWqHGmQaOJfTCmwmVNNdPTl[KWiwVtjcbaUptzhIrmTesQCcxnP].ProductName + "\"\n";
			if (PFnOTHqJnYDWzxCOYtTyZdOVMyq.IsBluetoothDevice)
			{
				text = text + "Bluetooth Device Name: \"" + PFnOTHqJnYDWzxCOYtTyZdOVMyq.BluetoothDeviceName + "\"\n";
			}
			object obj = text;
			text = string.Concat(obj, "Identifier: ", new PidVid(PFnOTHqJnYDWzxCOYtTyZdOVMyq.ProductGuid), "\n");
			Rewired.Logger.Log(text);
		}
		if (!flag2)
		{
			gjXrWEFBmmfJodbKaRYGCXcWpVk gjXrWEFBmmfJodbKaRYGCXcWpVk2 = PFnOTHqJnYDWzxCOYtTyZdOVMyq.AxesState as gjXrWEFBmmfJodbKaRYGCXcWpVk;
			for (int j = 1; j < QvCgfIgJETfOpaQYLaaiGJLJwBu.Length - 1; j++)
			{
				int num2 = CCwCnYhEmaFZrOQeiMBHgUHikwcc((RawInputAxis)tYsrmWYljgyiuPeNcaSXzQxduHg[j], 0, gjXrWEFBmmfJodbKaRYGCXcWpVk2);
				string text2 = QvCgfIgJETfOpaQYLaaiGJLJwBu[j];
				try
				{
					YgtqqyMBxpnWhXqnMcSwkqoAUek(text2, num2 + " (" + jBwGMgeXcypsIUbeXmoFAFFnKCeq(num2) + ")");
				}
				catch
				{
					YgtqqyMBxpnWhXqnMcSwkqoAUek(text2, "FAILED! Axis value = " + num2);
				}
			}
			if (gjXrWEFBmmfJodbKaRYGCXcWpVk2.otherAxisCount > 0)
			{
				for (int k = 0; k < gjXrWEFBmmfJodbKaRYGCXcWpVk2.otherAxisCount; k++)
				{
					int num3 = CCwCnYhEmaFZrOQeiMBHgUHikwcc(RawInputAxis.Other, k, gjXrWEFBmmfJodbKaRYGCXcWpVk2);
					string text3 = "Other Axis " + k;
					try
					{
						YgtqqyMBxpnWhXqnMcSwkqoAUek(text3, num3 + " (" + jBwGMgeXcypsIUbeXmoFAFFnKCeq(num3) + ")");
					}
					catch
					{
						YgtqqyMBxpnWhXqnMcSwkqoAUek(text3, "FAILED! Axis value = " + num3);
					}
				}
			}
			int[] hatValues = PFnOTHqJnYDWzxCOYtTyZdOVMyq.HatValues;
			for (int l = 0; l < hatValues.Length; l++)
			{
				int num4 = hatValues[l];
				string text4 = "Hat " + l;
				YgtqqyMBxpnWhXqnMcSwkqoAUek(text4, num4);
			}
			bool[] buttons = PFnOTHqJnYDWzxCOYtTyZdOVMyq.Buttons;
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
			YgtqqyMBxpnWhXqnMcSwkqoAUek("Buttons ", text5);
		}
		else
		{
			saLjtbZSBxlqoNzvuSJHtknSlTo saLjtbZSBxlqoNzvuSJHtknSlTo2 = PFnOTHqJnYDWzxCOYtTyZdOVMyq.AxesState as saLjtbZSBxlqoNzvuSJHtknSlTo;
			for (int n = 0; n < PFnOTHqJnYDWzxCOYtTyZdOVMyq.AxisCount; n++)
			{
				float num5 = saLjtbZSBxlqoNzvuSJHtknSlTo2.CCwCnYhEmaFZrOQeiMBHgUHikwcc(n);
				string text6 = n.ToString();
				try
				{
					YgtqqyMBxpnWhXqnMcSwkqoAUek(text6, num5.ToString() + " (" + saLjtbZSBxlqoNzvuSJHtknSlTo2.gWNdpELwLzAIjnXgQVPDfgfuiQr(n) + ")");
				}
				catch
				{
					YgtqqyMBxpnWhXqnMcSwkqoAUek(text6, "FAILED! Axis value = " + num5);
				}
			}
			int[] hatValues2 = PFnOTHqJnYDWzxCOYtTyZdOVMyq.HatValues;
			for (int num6 = 0; num6 < PFnOTHqJnYDWzxCOYtTyZdOVMyq.HatCount; num6++)
			{
				int num7 = hatValues2[num6];
				string text7 = "Hat " + num6;
				YgtqqyMBxpnWhXqnMcSwkqoAUek(text7, num7);
			}
			for (int num8 = 0; num8 < PFnOTHqJnYDWzxCOYtTyZdOVMyq.Driver.GyroscopeCount; num8++)
			{
				int valueLength = PFnOTHqJnYDWzxCOYtTyZdOVMyq.Driver.gyroscopes[num8].valueLength;
				string text8 = "";
				for (int num9 = 0; num9 < valueLength; num9++)
				{
					float num10 = PFnOTHqJnYDWzxCOYtTyZdOVMyq.Driver.gyroscopes[num8].rawValue[num9];
					object obj5 = text8;
					text8 = string.Concat(obj5, "[", num9, "]: ", num10.ToString("f3"));
					if (num9 < valueLength - 1)
					{
						text8 += " ";
					}
				}
				YgtqqyMBxpnWhXqnMcSwkqoAUek("Gyro " + num8, text8);
			}
			for (int num11 = 0; num11 < PFnOTHqJnYDWzxCOYtTyZdOVMyq.Driver.AccelerometerCount; num11++)
			{
				int valueLength2 = PFnOTHqJnYDWzxCOYtTyZdOVMyq.Driver.accelerometers[num11].valueLength;
				string text9 = "";
				for (int num12 = 0; num12 < valueLength2; num12++)
				{
					float num13 = PFnOTHqJnYDWzxCOYtTyZdOVMyq.Driver.accelerometers[num11].rawValue[num12];
					object obj6 = text9;
					text9 = string.Concat(obj6, "[", num12, "]: ", num13.ToString("f3"));
					if (num12 < valueLength2 - 1)
					{
						text9 += " ";
					}
				}
				YgtqqyMBxpnWhXqnMcSwkqoAUek("Accelerometer " + num11, text9);
			}
			for (int num14 = 0; num14 < PFnOTHqJnYDWzxCOYtTyZdOVMyq.Driver.TouchpadCount; num14++)
			{
				HIDTouchpad hIDTouchpad = PFnOTHqJnYDWzxCOYtTyZdOVMyq.Driver.touchpads[num14];
				int num15 = hIDTouchpad.values.Length;
				string text10 = "";
				for (int num16 = 0; num16 < num15; num16++)
				{
					HIDTouchpad.TouchData touchData = hIDTouchpad.values[num16];
					rXoxPsjwFUIfgQWMIHeCesmxKsg = text10;
					text10 = string.Concat(rXoxPsjwFUIfgQWMIHeCesmxKsg, "Touch ", num16, ": Is Touching = ", touchData.isTouching, "\n");
					rXoxPsjwFUIfgQWMIHeCesmxKsg = text10;
					text10 = string.Concat(rXoxPsjwFUIfgQWMIHeCesmxKsg, "Touch ", num16, ": Touch Id = ", touchData.touchId, "\n");
					rXoxPsjwFUIfgQWMIHeCesmxKsg = text10;
					text10 = string.Concat(rXoxPsjwFUIfgQWMIHeCesmxKsg, "Touch ", num16, ": Position = ", touchData.positionX, ", ", touchData.positionY, "\n");
					rXoxPsjwFUIfgQWMIHeCesmxKsg = text10;
					text10 = string.Concat(rXoxPsjwFUIfgQWMIHeCesmxKsg, "Touch ", num16, ": Abs Position = ", touchData.positionAbsX, ", ", touchData.positionAbsY, " (", touchData.positionRawX, ", ", touchData.positionRawY, ")\n");
				}
				MXOMmBMoxMbBVJtnRLJaNInanHR("Touchpad " + num14, text10);
			}
			bool[] buttons2 = PFnOTHqJnYDWzxCOYtTyZdOVMyq.Buttons;
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
			YgtqqyMBxpnWhXqnMcSwkqoAUek("Buttons ", text11);
		}
		vVwNRYmxiqFQsVlAFkECrFJoNrL.text = RXoxPsjwFUIfgQWMIHeCesmxKsg;
	}

	public void OnDestroy()
	{
		if (PFnOTHqJnYDWzxCOYtTyZdOVMyq != null)
		{
			PFnOTHqJnYDWzxCOYtTyZdOVMyq.JkxbMOPQiVSbeNRGETMYZahHimc();
		}
	}

	private void pvhdfRPuYoBmeUzxAGGmjRPxTIr()
	{
		LmBfMWqHGmQaOJfTCmwmVNNdPTl = gBFcFEjcuYMKWkPeeMELlKKAWMAI.GetJoysticks<UzKBIaEyudSpXeLmfwTkGCYvktG>();
	}

	private void HWybtVeZZUDEUVZkTRDyLxFgrON()
	{
		VsfvDyXqZIMuiFHDXHZBjZyCAyO();
	}

	private void VQNmCjqHHJHMkrdAfOzYWMyKBMA()
	{
		VsfvDyXqZIMuiFHDXHZBjZyCAyO();
	}

	private void VsfvDyXqZIMuiFHDXHZBjZyCAyO()
	{
		rKJfCRBWFLQsKCjGykmcumzKLPwE();
		LXNyCvqHsWRkEovtIKsRXNxReHF = true;
	}

	private void rKJfCRBWFLQsKCjGykmcumzKLPwE()
	{
		KWiwVtjcbaUptzhIrmTesQCcxnP = 0;
		PFnOTHqJnYDWzxCOYtTyZdOVMyq = null;
		tVCUIwIKXkQOKHmeFaKweatIKpKx = Guid.Empty;
		LmBfMWqHGmQaOJfTCmwmVNNdPTl = null;
		DQgTsBsHBsEsEpUIpcYNvgCYLSQ = false;
		LXNyCvqHsWRkEovtIKsRXNxReHF = false;
	}

	private void YgtqqyMBxpnWhXqnMcSwkqoAUek(string P_0, object P_1)
	{
		string rXoxPsjwFUIfgQWMIHeCesmxKsg = RXoxPsjwFUIfgQWMIHeCesmxKsg;
		RXoxPsjwFUIfgQWMIHeCesmxKsg = rXoxPsjwFUIfgQWMIHeCesmxKsg + P_0 + " = " + P_1.ToString() + "\n";
	}

	private void MXOMmBMoxMbBVJtnRLJaNInanHR(string P_0, object P_1)
	{
		string rXoxPsjwFUIfgQWMIHeCesmxKsg = RXoxPsjwFUIfgQWMIHeCesmxKsg;
		RXoxPsjwFUIfgQWMIHeCesmxKsg = rXoxPsjwFUIfgQWMIHeCesmxKsg + P_0 + ":\n" + P_1.ToString() + "\n";
	}

	private int CCwCnYhEmaFZrOQeiMBHgUHikwcc(RawInputAxis P_0, int P_1, gjXrWEFBmmfJodbKaRYGCXcWpVk P_2)
	{
		return P_2.CCwCnYhEmaFZrOQeiMBHgUHikwcc(P_0, P_1);
	}

	private float jBwGMgeXcypsIUbeXmoFAFFnKCeq(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
