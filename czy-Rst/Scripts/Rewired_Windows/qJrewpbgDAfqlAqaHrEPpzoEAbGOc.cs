using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class qJrewpbgDAfqlAqaHrEPpzoEAbGOc : IElementIdentifierTool
{
	private Rewired.Internal.GUIText mMqGodIqiOjjXVmItEJfNTKzqgeIA;

	private string hEVIfVbUPgnHCHJvFsHZRxsoeFefA;

	private int oOCFKdEEZWSuahCKDJcVZWiIATHt;

	private ZjPoFuIZYwHPNsNOdhdEqslfjobcA OmwgjbpgvbcDGmAIbAaxJkGpfkov;

	private GsUDZCmUBPrPbKzjcofTPGFpCXQHA IJbEhYpOVvNykQhdskBNcIJxszgT;

	private Guid IVhVTNzRiwETWGpFRhgCmNJbSBLv;

	private IList<GsUDZCmUBPrPbKzjcofTPGFpCXQHA> JJNRJDNmHiJQaBQfFCZIWRXFErHDA;

	private bool XxtFGiIwEHtuphSYtVJYjoYFIhheb;

	private bool VXfIVzDeCNBIpQrqgOECBgjNWpXl;

	private bool XmwQnWDagoxDIhuZQpkAiqhYmFsB;

	private string[] JNpoFcIfIVTYBDoNxzNcwIknzVMm;

	private int[] gIsKvDGcjaWvfmyEwbTkluNjpxJ;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		mMqGodIqiOjjXVmItEJfNTKzqgeIA = text;
		JNpoFcIfIVTYBDoNxzNcwIknzVMm = Enum.GetNames(typeof(RawInputAxis));
		gIsKvDGcjaWvfmyEwbTkluNjpxJ = (int[])Enum.GetValues(typeof(RawInputAxis));
	}

	void IElementIdentifierTool.Initialize(Rewired.Internal.GUIText text)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Initialize
		this.Initialize(text);
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
		OmwgjbpgvbcDGmAIbAaxJkGpfkov = ReInput.primaryInputManager.inputSource as ZjPoFuIZYwHPNsNOdhdEqslfjobcA;
		if (OmwgjbpgvbcDGmAIbAaxJkGpfkov == null)
		{
			Rewired.Logger.LogError("Unable to initialize Raw Input! You must add a Rewired Input Manager to the scene and set the input mode to Raw Input.");
			return;
		}
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += TWgupVFrfUERBkzAWMnGuXIBDrcd;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += MiscVpuzJwcYwbuRKpwJTCBJUmJj;
		wzfWTwsctaXynVSseQbOhcEuLZZf();
		XmwQnWDagoxDIhuZQpkAiqhYmFsB = true;
	}

	void IElementIdentifierTool.Start()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Start
		this.Start();
	}

	public void Update()
	{
		if (!XmwQnWDagoxDIhuZQpkAiqhYmFsB)
		{
			return;
		}
		hEVIfVbUPgnHCHJvFsHZRxsoeFefA = "Raw Input Joystick Element Identifier\n\n";
		mMqGodIqiOjjXVmItEJfNTKzqgeIA.text = hEVIfVbUPgnHCHJvFsHZRxsoeFefA;
		int num = oOCFKdEEZWSuahCKDJcVZWiIATHt;
		Guid iVhVTNzRiwETWGpFRhgCmNJbSBLv = IVhVTNzRiwETWGpFRhgCmNJbSBLv;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			oOCFKdEEZWSuahCKDJcVZWiIATHt++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			oOCFKdEEZWSuahCKDJcVZWiIATHt--;
		}
		if (VXfIVzDeCNBIpQrqgOECBgjNWpXl)
		{
			wzfWTwsctaXynVSseQbOhcEuLZZf();
			VXfIVzDeCNBIpQrqgOECBgjNWpXl = false;
		}
		int num2 = ((JJNRJDNmHiJQaBQfFCZIWRXFErHDA != null) ? JJNRJDNmHiJQaBQfFCZIWRXFErHDA.Count : 0);
		if (num2 == 0)
		{
			return;
		}
		if (oOCFKdEEZWSuahCKDJcVZWiIATHt < 0)
		{
			oOCFKdEEZWSuahCKDJcVZWiIATHt = num2 - 1;
		}
		else if (oOCFKdEEZWSuahCKDJcVZWiIATHt >= num2)
		{
			oOCFKdEEZWSuahCKDJcVZWiIATHt = 0;
		}
		IVhVTNzRiwETWGpFRhgCmNJbSBLv = JJNRJDNmHiJQaBQfFCZIWRXFErHDA[oOCFKdEEZWSuahCKDJcVZWiIATHt].xAWvHzNsedfjPxDtWkxSEBHQVgBW;
		bool flag = false;
		if (num != oOCFKdEEZWSuahCKDJcVZWiIATHt || iVhVTNzRiwETWGpFRhgCmNJbSBLv != IVhVTNzRiwETWGpFRhgCmNJbSBLv)
		{
			flag = true;
		}
		if (IJbEhYpOVvNykQhdskBNcIJxszgT == null || flag)
		{
			if (IJbEhYpOVvNykQhdskBNcIJxszgT != null)
			{
				IJbEhYpOVvNykQhdskBNcIJxszgT.VBRmigAQyUDsBoTSuiGZtjuLgpGF();
			}
			IJbEhYpOVvNykQhdskBNcIJxszgT = JJNRJDNmHiJQaBQfFCZIWRXFErHDA[oOCFKdEEZWSuahCKDJcVZWiIATHt];
			if (IJbEhYpOVvNykQhdskBNcIJxszgT == null)
			{
				return;
			}
			IJbEhYpOVvNykQhdskBNcIJxszgT.xlrZFmLgYZbgFavYdXzNOKrLhXkZ();
		}
		bool flag2 = false;
		if (IJbEhYpOVvNykQhdskBNcIJxszgT.tezgYziPBLJfGEyQpFkBAclTsKUQ is gSldsSEmupMsqVSjeuDcObuSeWgYA)
		{
			flag2 = true;
		}
		else if (!(IJbEhYpOVvNykQhdskBNcIJxszgT.tezgYziPBLJfGEyQpFkBAclTsKUQ is xPFyyPUiZiUqzpsMQENmLtKtJHqA))
		{
			return;
		}
		if (num2 > 0)
		{
			hEVIfVbUPgnHCHJvFsHZRxsoeFefA = hEVIfVbUPgnHCHJvFsHZRxsoeFefA + num2 + " connected devices:\n";
		}
		for (int i = 0; i < num2; i++)
		{
			hEVIfVbUPgnHCHJvFsHZRxsoeFefA = hEVIfVbUPgnHCHJvFsHZRxsoeFefA + JJNRJDNmHiJQaBQfFCZIWRXFErHDA[i].RABxiAVVwipZGmKaoXbehHJfgqrt + "\n";
		}
		hEVIfVbUPgnHCHJvFsHZRxsoeFefA += "\n";
		hEVIfVbUPgnHCHJvFsHZRxsoeFefA = hEVIfVbUPgnHCHJvFsHZRxsoeFefA + "Current RI device " + oOCFKdEEZWSuahCKDJcVZWiIATHt + ": \"" + IJbEhYpOVvNykQhdskBNcIJxszgT.RABxiAVVwipZGmKaoXbehHJfgqrt + "\"\n";
		hEVIfVbUPgnHCHJvFsHZRxsoeFefA += "(Press + or - to change monitored device id.)\n\n";
		PFVtYfZgiSTRAUGeaepPnBBihNcJA("Product Name", "\"" + IJbEhYpOVvNykQhdskBNcIJxszgT.RABxiAVVwipZGmKaoXbehHJfgqrt + "\"");
		PFVtYfZgiSTRAUGeaepPnBBihNcJA("Is Bluetooth Device", IJbEhYpOVvNykQhdskBNcIJxszgT.HMNLVHyHJVIKpOWqwNsiKWPBghCm);
		if (IJbEhYpOVvNykQhdskBNcIJxszgT.HMNLVHyHJVIKpOWqwNsiKWPBghCm)
		{
			PFVtYfZgiSTRAUGeaepPnBBihNcJA("Bluetooth Device Name", "\"" + IJbEhYpOVvNykQhdskBNcIJxszgT.QFdbXlQHBRejChBEMExhCsHLvAJyA + "\"");
		}
		if (flag2)
		{
			PFVtYfZgiSTRAUGeaepPnBBihNcJA("Using Custom Driver", "TRUE");
		}
		PFVtYfZgiSTRAUGeaepPnBBihNcJA("Device Type", IJbEhYpOVvNykQhdskBNcIJxszgT.qchneqkeLKiVpepkfWLDWwLYYTGG.ToString());
		PFVtYfZgiSTRAUGeaepPnBBihNcJA("Identifier", new PidVid(IJbEhYpOVvNykQhdskBNcIJxszgT.lSsIgVJkZJTNmYjmcPooWFWpvBlw));
		PFVtYfZgiSTRAUGeaepPnBBihNcJA("Product Id", IJbEhYpOVvNykQhdskBNcIJxszgT.LYBimHvVYSopcHwXwMVKTeVfskNi);
		PFVtYfZgiSTRAUGeaepPnBBihNcJA("Vendor Id", IJbEhYpOVvNykQhdskBNcIJxszgT.RFTMYXVFWYcEOWJetBxadGkAgDfQ);
		hEVIfVbUPgnHCHJvFsHZRxsoeFefA += "\n";
		PFVtYfZgiSTRAUGeaepPnBBihNcJA("Axis Count", IJbEhYpOVvNykQhdskBNcIJxszgT.yfhtYJOVzqgzFDENiGoAbRycqWisA);
		PFVtYfZgiSTRAUGeaepPnBBihNcJA("Button Count", IJbEhYpOVvNykQhdskBNcIJxszgT.AWcbZWiPgnCSuekIikduGUhZekVF);
		PFVtYfZgiSTRAUGeaepPnBBihNcJA("Hat Count", IJbEhYpOVvNykQhdskBNcIJxszgT.kmRthdpjWUMHeHImgGqwhgiziTcoA);
		hEVIfVbUPgnHCHJvFsHZRxsoeFefA += "\n";
		if (flag)
		{
			string text = "";
			text = text + "Device Name: \"" + JJNRJDNmHiJQaBQfFCZIWRXFErHDA[oOCFKdEEZWSuahCKDJcVZWiIATHt].RABxiAVVwipZGmKaoXbehHJfgqrt + "\"\n";
			if (IJbEhYpOVvNykQhdskBNcIJxszgT.HMNLVHyHJVIKpOWqwNsiKWPBghCm)
			{
				text = text + "Bluetooth Device Name: \"" + IJbEhYpOVvNykQhdskBNcIJxszgT.QFdbXlQHBRejChBEMExhCsHLvAJyA + "\"\n";
			}
			text = text + "Identifier: " + new PidVid(IJbEhYpOVvNykQhdskBNcIJxszgT.lSsIgVJkZJTNmYjmcPooWFWpvBlw).ToString() + "\n";
			Rewired.Logger.Log(text);
		}
		if (!flag2)
		{
			xPFyyPUiZiUqzpsMQENmLtKtJHqA xPFyyPUiZiUqzpsMQENmLtKtJHqA2 = IJbEhYpOVvNykQhdskBNcIJxszgT.tezgYziPBLJfGEyQpFkBAclTsKUQ as xPFyyPUiZiUqzpsMQENmLtKtJHqA;
			for (int j = 1; j < JNpoFcIfIVTYBDoNxzNcwIknzVMm.Length - 1; j++)
			{
				int num3 = XUSJRmWqfaiFLyelmTOVacGaLBSl((RawInputAxis)gIsKvDGcjaWvfmyEwbTkluNjpxJ[j], 0, xPFyyPUiZiUqzpsMQENmLtKtJHqA2);
				string text2 = JNpoFcIfIVTYBDoNxzNcwIknzVMm[j];
				try
				{
					PFVtYfZgiSTRAUGeaepPnBBihNcJA(text2, num3 + " (" + znVQTLAPooVxYsRXNPCjOpxMYnK(num3) + ")");
				}
				catch
				{
					PFVtYfZgiSTRAUGeaepPnBBihNcJA(text2, "FAILED! Axis value = " + num3);
				}
			}
			if (xPFyyPUiZiUqzpsMQENmLtKtJHqA2.BXhAbnKAgpfIAZRfSdmpcJQhjHrHA > 0)
			{
				for (int k = 0; k < xPFyyPUiZiUqzpsMQENmLtKtJHqA2.BXhAbnKAgpfIAZRfSdmpcJQhjHrHA; k++)
				{
					int num4 = XUSJRmWqfaiFLyelmTOVacGaLBSl(RawInputAxis.Other, k, xPFyyPUiZiUqzpsMQENmLtKtJHqA2);
					string text3 = "Other Axis " + k;
					try
					{
						PFVtYfZgiSTRAUGeaepPnBBihNcJA(text3, num4 + " (" + znVQTLAPooVxYsRXNPCjOpxMYnK(num4) + ")");
					}
					catch
					{
						PFVtYfZgiSTRAUGeaepPnBBihNcJA(text3, "FAILED! Axis value = " + num4);
					}
				}
			}
			int[] array = IJbEhYpOVvNykQhdskBNcIJxszgT.kSytIaPqIpBNQENbJLZffjmZVzkfb;
			for (int l = 0; l < array.Length; l++)
			{
				int num5 = array[l];
				string text4 = "Hat " + l;
				PFVtYfZgiSTRAUGeaepPnBBihNcJA(text4, num5);
			}
			bool[] array2 = IJbEhYpOVvNykQhdskBNcIJxszgT.fqWCRbjfZUOvpeNXHJsvNUYXQZUgb;
			string text5 = "";
			for (int m = 0; m < array2.Length; m++)
			{
				if (array2[m])
				{
					if (text5 != "")
					{
						text5 += ", ";
					}
					text5 += m;
				}
			}
			PFVtYfZgiSTRAUGeaepPnBBihNcJA("Buttons ", text5);
		}
		else
		{
			gSldsSEmupMsqVSjeuDcObuSeWgYA gSldsSEmupMsqVSjeuDcObuSeWgYA2 = IJbEhYpOVvNykQhdskBNcIJxszgT.tezgYziPBLJfGEyQpFkBAclTsKUQ as gSldsSEmupMsqVSjeuDcObuSeWgYA;
			for (int n = 0; n < IJbEhYpOVvNykQhdskBNcIJxszgT.yfhtYJOVzqgzFDENiGoAbRycqWisA; n++)
			{
				float num6 = gSldsSEmupMsqVSjeuDcObuSeWgYA2.FiZcIydOFFkBDRoaLKdIbAHURWmAA(n);
				string text6 = n.ToString();
				try
				{
					PFVtYfZgiSTRAUGeaepPnBBihNcJA(text6, num6 + " (" + gSldsSEmupMsqVSjeuDcObuSeWgYA2.ibvalSINfXCSBsTXQnuQyzTYwSNb(n) + ")");
				}
				catch
				{
					PFVtYfZgiSTRAUGeaepPnBBihNcJA(text6, "FAILED! Axis value = " + num6);
				}
			}
			int[] array3 = IJbEhYpOVvNykQhdskBNcIJxszgT.kSytIaPqIpBNQENbJLZffjmZVzkfb;
			for (int num7 = 0; num7 < IJbEhYpOVvNykQhdskBNcIJxszgT.kmRthdpjWUMHeHImgGqwhgiziTcoA; num7++)
			{
				int num8 = array3[num7];
				string text7 = "Hat " + num7;
				PFVtYfZgiSTRAUGeaepPnBBihNcJA(text7, num8);
			}
			for (int num9 = 0; num9 < IJbEhYpOVvNykQhdskBNcIJxszgT.QPJCQODFVsUXHWfIdWGDJCFDteoW.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EGyroscopeCount; num9++)
			{
				int pneJdEjqeOMHpSHlCbWHFwyXNOGC = IJbEhYpOVvNykQhdskBNcIJxszgT.QPJCQODFVsUXHWfIdWGDJCFDteoW.gyroscopes[num9].pneJdEjqeOMHpSHlCbWHFwyXNOGC;
				string text8 = "";
				for (int num10 = 0; num10 < pneJdEjqeOMHpSHlCbWHFwyXNOGC; num10++)
				{
					float num11 = IJbEhYpOVvNykQhdskBNcIJxszgT.QPJCQODFVsUXHWfIdWGDJCFDteoW.gyroscopes[num9].NKyhjzEpAZtHNcjqwLDpmKcEdGoA[num10];
					text8 = text8 + "[" + num10 + "]: " + num11.ToString("f3");
					if (num10 < pneJdEjqeOMHpSHlCbWHFwyXNOGC - 1)
					{
						text8 += " ";
					}
				}
				PFVtYfZgiSTRAUGeaepPnBBihNcJA("Gyro " + num9, text8);
			}
			for (int num12 = 0; num12 < IJbEhYpOVvNykQhdskBNcIJxszgT.QPJCQODFVsUXHWfIdWGDJCFDteoW.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EAccelerometerCount; num12++)
			{
				int axZgiZxWGmEqfZhchlYBXtthfuZc = IJbEhYpOVvNykQhdskBNcIJxszgT.QPJCQODFVsUXHWfIdWGDJCFDteoW.accelerometers[num12].AxZgiZxWGmEqfZhchlYBXtthfuZc;
				string text9 = "";
				for (int num13 = 0; num13 < axZgiZxWGmEqfZhchlYBXtthfuZc; num13++)
				{
					float num14 = IJbEhYpOVvNykQhdskBNcIJxszgT.QPJCQODFVsUXHWfIdWGDJCFDteoW.accelerometers[num12].JLwYhuHtTQDoTLjyTSPTHSWTgggN[num13];
					text9 = text9 + "[" + num13 + "]: " + num14.ToString("f3");
					if (num13 < axZgiZxWGmEqfZhchlYBXtthfuZc - 1)
					{
						text9 += " ";
					}
				}
				PFVtYfZgiSTRAUGeaepPnBBihNcJA("Accelerometer " + num12, text9);
			}
			for (int num15 = 0; num15 < IJbEhYpOVvNykQhdskBNcIJxszgT.QPJCQODFVsUXHWfIdWGDJCFDteoW.Rewired_002EHID_002EDrivers_002EIControllerDriver_002ETouchpadCount; num15++)
			{
				YbNvcxfeAOXeGxhYaCCOmgMgdTsT ybNvcxfeAOXeGxhYaCCOmgMgdTsT = IJbEhYpOVvNykQhdskBNcIJxszgT.QPJCQODFVsUXHWfIdWGDJCFDteoW.touchpads[num15];
				int num16 = ybNvcxfeAOXeGxhYaCCOmgMgdTsT.XBRNyXRXsysdNperzXpLQXmtHcpj.Length;
				string text10 = "";
				for (int num17 = 0; num17 < num16; num17++)
				{
					YbNvcxfeAOXeGxhYaCCOmgMgdTsT.TouchData touchData = ybNvcxfeAOXeGxhYaCCOmgMgdTsT.XBRNyXRXsysdNperzXpLQXmtHcpj[num17];
					text10 = text10 + "Touch " + num17 + ": Is Touching = " + touchData.isTouching + "\n";
					text10 = text10 + "Touch " + num17 + ": Touch Id = " + touchData.touchId + "\n";
					text10 = text10 + "Touch " + num17 + ": Position = " + touchData.positionX + ", " + touchData.positionY + "\n";
					text10 = text10 + "Touch " + num17 + ": Abs Position = " + touchData.positionAbsX + ", " + touchData.positionAbsY + " (" + touchData.positionRawX + ", " + touchData.positionRawY + ")\n";
				}
				hghBMHdNDTMLfiTJKrgXCQHwmFwwb("Touchpad " + num15, text10);
			}
			bool[] array4 = IJbEhYpOVvNykQhdskBNcIJxszgT.fqWCRbjfZUOvpeNXHJsvNUYXQZUgb;
			string text11 = "";
			for (int num18 = 0; num18 < array4.Length; num18++)
			{
				if (array4[num18])
				{
					if (text11 != "")
					{
						text11 += ", ";
					}
					text11 += num18;
				}
			}
			PFVtYfZgiSTRAUGeaepPnBBihNcJA("Buttons ", text11);
		}
		mMqGodIqiOjjXVmItEJfNTKzqgeIA.text = hEVIfVbUPgnHCHJvFsHZRxsoeFefA;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void OnDestroy()
	{
		if (IJbEhYpOVvNykQhdskBNcIJxszgT != null)
		{
			IJbEhYpOVvNykQhdskBNcIJxszgT.VBRmigAQyUDsBoTSuiGZtjuLgpGF();
		}
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}

	private void wzfWTwsctaXynVSseQbOhcEuLZZf()
	{
		JJNRJDNmHiJQaBQfFCZIWRXFErHDA = OmwgjbpgvbcDGmAIbAaxJkGpfkov.GetJoysticks<GsUDZCmUBPrPbKzjcofTPGFpCXQHA>();
	}

	private void TWgupVFrfUERBkzAWMnGuXIBDrcd()
	{
		vrNqXozfZefORQsRhzmHpYbokIZG();
	}

	private void MiscVpuzJwcYwbuRKpwJTCBJUmJj()
	{
		vrNqXozfZefORQsRhzmHpYbokIZG();
	}

	private void vrNqXozfZefORQsRhzmHpYbokIZG()
	{
		pkayIPYQjelFutqRRBkbBimjNpwGA();
		VXfIVzDeCNBIpQrqgOECBgjNWpXl = true;
	}

	private void pkayIPYQjelFutqRRBkbBimjNpwGA()
	{
		oOCFKdEEZWSuahCKDJcVZWiIATHt = 0;
		IJbEhYpOVvNykQhdskBNcIJxszgT = null;
		IVhVTNzRiwETWGpFRhgCmNJbSBLv = Guid.Empty;
		JJNRJDNmHiJQaBQfFCZIWRXFErHDA = null;
		XxtFGiIwEHtuphSYtVJYjoYFIhheb = false;
		VXfIVzDeCNBIpQrqgOECBgjNWpXl = false;
	}

	private void PFVtYfZgiSTRAUGeaepPnBBihNcJA(string P_0, object P_1)
	{
		hEVIfVbUPgnHCHJvFsHZRxsoeFefA = hEVIfVbUPgnHCHJvFsHZRxsoeFefA + P_0 + " = " + P_1.ToString() + "\n";
	}

	private void hghBMHdNDTMLfiTJKrgXCQHwmFwwb(string P_0, object P_1)
	{
		hEVIfVbUPgnHCHJvFsHZRxsoeFefA = hEVIfVbUPgnHCHJvFsHZRxsoeFefA + P_0 + ":\n" + P_1.ToString() + "\n";
	}

	private int XUSJRmWqfaiFLyelmTOVacGaLBSl(RawInputAxis P_0, int P_1, xPFyyPUiZiUqzpsMQENmLtKtJHqA P_2)
	{
		return P_2.fvPvwwqVOtILciBbKtVcIgHWpmoE(P_0, P_1);
	}

	private float znVQTLAPooVxYsRXNPCjOpxMYnK(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
