using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal sealed class rGTufSEvzKmfZlsGyeEgiRgfMDU : IElementIdentifierTool
{
	private Rewired.Internal.GUIText sCXrcRxxEvSNPlFSyjevCbwjDpDE;

	private string GSZGHGdaQFfWDPcQvhvdfRFjiIiV;

	private int DcXhJciIRzxmOJhYUnuTDChztuP;

	private hhwTHKlniCMKoBzWDzyznYMwDzW yuVdsmfyNnpmsPViwqbiAHkqsVe;

	private iKlolGPnHgrjtsiEOOZxcLUhJOe IAYCyCCfxLADdcDSjhLuqwShOQyR;

	private Guid uIxglbDvQxIdHtidiaJZRSFHviO;

	private IList<oavsBCpkURSQZhuDFrqXELCmmrM> UiueHXbfdzXSDcdtjqILFukiDRXY;

	private IList<oavsBCpkURSQZhuDFrqXELCmmrM> WBjWOBmzQcswasSCOOBgHbMGIpI;

	private bool AAZkfGnNpnzmxHESABcweKtNqMKc;

	private bool AJeirwxBSXczjCmdbGIsmyYYVER;

	private bool pfiWixHBjQdcaVlrVnqrgVIxusv;

	private int ShpKpoHKriIeImWuNfVctWPuOhb;

	private TimerRealTime IsLEnDVVrbdFbqVEnPhvPRYEfVA;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		sCXrcRxxEvSNPlFSyjevCbwjDpDE = text;
	}

	public void Start()
	{
		if (ReInput.isEditor && ReInput.editorPlatform != EditorPlatform.Windows)
		{
			Rewired.Logger.LogError("Direct Input cannot be run on this platform. You must be running the editor in Windows.");
			return;
		}
		if (ReInput.currentPlatform != Platform.Windows)
		{
			Rewired.Logger.LogError("Direct Input cannot be run on this build target. Be sure Unity's build target is set to Windows Standalone.");
			return;
		}
		if (!(ReInput.primaryInputManager.inputSource is InputSourceWrapper<hhwTHKlniCMKoBzWDzyznYMwDzW> inputSourceWrapper) || inputSourceWrapper.source == null)
		{
			Rewired.Logger.LogError("Unable to initialize Direct Input! You must add a Rewired Input Manager to the scene and set the input mode to Direct Input.");
			return;
		}
		yuVdsmfyNnpmsPViwqbiAHkqsVe = inputSourceWrapper.source;
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += CnTKZWfhtJJAtxjcyslTcfkrqOH;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += EfsXOmpDhUnNPXNISrmnfnXFdTW;
		IsLEnDVVrbdFbqVEnPhvPRYEfVA = new TimerRealTime(1.0);
		IsLEnDVVrbdFbqVEnPhvPRYEfVA.Start();
		gLAITACQupcsXaeprKsFOosklIl();
		pfiWixHBjQdcaVlrVnqrgVIxusv = true;
	}

	public void Update()
	{
		if (!pfiWixHBjQdcaVlrVnqrgVIxusv)
		{
			return;
		}
		GSZGHGdaQFfWDPcQvhvdfRFjiIiV = "Direct Input Joystick Element Identifier\n\n";
		sCXrcRxxEvSNPlFSyjevCbwjDpDE.text = GSZGHGdaQFfWDPcQvhvdfRFjiIiV;
		if (Input.GetKeyDown(KeyCode.A))
		{
			AAZkfGnNpnzmxHESABcweKtNqMKc = !AAZkfGnNpnzmxHESABcweKtNqMKc;
		}
		if (AAZkfGnNpnzmxHESABcweKtNqMKc)
		{
			sCXrcRxxEvSNPlFSyjevCbwjDpDE.text += "All Devices:\n";
			foreach (oavsBCpkURSQZhuDFrqXELCmmrM item in WBjWOBmzQcswasSCOOBgHbMGIpI)
			{
				Rewired.Internal.GUIText gUIText = sCXrcRxxEvSNPlFSyjevCbwjDpDE;
				object text = gUIText.text;
				gUIText.text = string.Concat(text, item.DgEhJocJJkZoJBLmmHdIFnYalFtw, ", ", item.IsHumanInterfaceDevice, ", ", new PidVid(item.oeNdQWoDfdJZbQNVIMHzlNMZeJp), ", ", item.Subtype, ", ", item.ZYGeQPjXCaJVJLnAiYGNJFbZgfk, ", ", item.NmQhBtQCcgcHDaWeaCjxXfWGcIGd, "\n");
			}
			sCXrcRxxEvSNPlFSyjevCbwjDpDE.text += "\n";
		}
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
		if (IsLEnDVVrbdFbqVEnPhvPRYEfVA.Update())
		{
			int num = yuVdsmfyNnpmsPViwqbiAHkqsVe.tRnqqsboVUqGBCogAlxstdlVGjpa(QyuEnlbUowDKQRpThenvnYsTHrA.cXEeBjOXiiTJnTtduUOyunqeJia, acSaGRXzHfCbnAZWrzgPGuGjden.xycNSjFEVhRECdalUfBPpVOeFZng);
			if (num != ShpKpoHKriIeImWuNfVctWPuOhb)
			{
				ShpKpoHKriIeImWuNfVctWPuOhb = num;
				AJeirwxBSXczjCmdbGIsmyYYVER = true;
			}
			IsLEnDVVrbdFbqVEnPhvPRYEfVA.Start();
		}
		if (AJeirwxBSXczjCmdbGIsmyYYVER)
		{
			gLAITACQupcsXaeprKsFOosklIl();
			AJeirwxBSXczjCmdbGIsmyYYVER = false;
		}
		int num2 = ((UiueHXbfdzXSDcdtjqILFukiDRXY != null) ? UiueHXbfdzXSDcdtjqILFukiDRXY.Count : 0);
		if (num2 == 0)
		{
			return;
		}
		if (DcXhJciIRzxmOJhYUnuTDChztuP < 0)
		{
			DcXhJciIRzxmOJhYUnuTDChztuP = num2 - 1;
		}
		else if (DcXhJciIRzxmOJhYUnuTDChztuP >= num2)
		{
			DcXhJciIRzxmOJhYUnuTDChztuP = 0;
		}
		uIxglbDvQxIdHtidiaJZRSFHviO = UiueHXbfdzXSDcdtjqILFukiDRXY[DcXhJciIRzxmOJhYUnuTDChztuP].rShFIeIDKVTszLkmTmIZgIPGwGWB;
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
			IAYCyCCfxLADdcDSjhLuqwShOQyR = new iKlolGPnHgrjtsiEOOZxcLUhJOe(yuVdsmfyNnpmsPViwqbiAHkqsVe, UiueHXbfdzXSDcdtjqILFukiDRXY[DcXhJciIRzxmOJhYUnuTDChztuP].rShFIeIDKVTszLkmTmIZgIPGwGWB);
			if (IAYCyCCfxLADdcDSjhLuqwShOQyR == null)
			{
				return;
			}
			IList<HMxBjwmUHlBNPuNunDJFOGXNgBM> list = IAYCyCCfxLADdcDSjhLuqwShOQyR.IFFbiNRSHlxwESfkhJMQeVdlaxt();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if ((list[i].UVnyDmtbPFbaoFixbwSAhHizrTQ.Flags & pYDUQtFWywMKELdMLkqFCiEuGzi.UAwdzUChrEKCiSlcRUpBPrHWtId) != pYDUQtFWywMKELdMLkqFCiEuGzi.cXEeBjOXiiTJnTtduUOyunqeJia)
					{
						IAYCyCCfxLADdcDSjhLuqwShOQyR.Properties.Range = new IEgwOtJfzUHOcmGCEHySfandPNq(-65535, 65535);
					}
				}
			}
			IAYCyCCfxLADdcDSjhLuqwShOQyR.DfoHKTaxZzJSYcaLwTWUBUINGoo();
		}
		WdUgpcVePDxEWRCUGSnBbePWAHU wdUgpcVePDxEWRCUGSnBbePWAHU;
		try
		{
			wdUgpcVePDxEWRCUGSnBbePWAHU = IAYCyCCfxLADdcDSjhLuqwShOQyR.eBxlwDCIOedWxmHmoDvPZNlEMHf();
		}
		catch
		{
			wdUgpcVePDxEWRCUGSnBbePWAHU = null;
		}
		if (wdUgpcVePDxEWRCUGSnBbePWAHU == null)
		{
			return;
		}
		if (num2 > 0)
		{
			GSZGHGdaQFfWDPcQvhvdfRFjiIiV = GSZGHGdaQFfWDPcQvhvdfRFjiIiV + num2 + " connected devices:\n";
		}
		for (int j = 0; j < num2; j++)
		{
			GSZGHGdaQFfWDPcQvhvdfRFjiIiV = GSZGHGdaQFfWDPcQvhvdfRFjiIiV + UiueHXbfdzXSDcdtjqILFukiDRXY[j].DgEhJocJJkZoJBLmmHdIFnYalFtw + "\n";
		}
		GSZGHGdaQFfWDPcQvhvdfRFjiIiV += "\n";
		object gSZGHGdaQFfWDPcQvhvdfRFjiIiV = GSZGHGdaQFfWDPcQvhvdfRFjiIiV;
		GSZGHGdaQFfWDPcQvhvdfRFjiIiV = string.Concat(gSZGHGdaQFfWDPcQvhvdfRFjiIiV, "Current DI device ", DcXhJciIRzxmOJhYUnuTDChztuP, ": ", UiueHXbfdzXSDcdtjqILFukiDRXY[DcXhJciIRzxmOJhYUnuTDChztuP].DgEhJocJJkZoJBLmmHdIFnYalFtw, "\n");
		GSZGHGdaQFfWDPcQvhvdfRFjiIiV += "(Press + or - to change monitored device id.)\n\n";
		NCScKtADzeppzSpslQSpTRFVnWmX("Identifier", new PidVid(IAYCyCCfxLADdcDSjhLuqwShOQyR.Information.oeNdQWoDfdJZbQNVIMHzlNMZeJp));
		NCScKtADzeppzSpslQSpTRFVnWmX("Instance GUID", IAYCyCCfxLADdcDSjhLuqwShOQyR.Information.rShFIeIDKVTszLkmTmIZgIPGwGWB);
		NCScKtADzeppzSpslQSpTRFVnWmX("Product Id", IAYCyCCfxLADdcDSjhLuqwShOQyR.Properties.ProductId);
		NCScKtADzeppzSpslQSpTRFVnWmX("Device Type", IAYCyCCfxLADdcDSjhLuqwShOQyR.Capabilities.Type.ToString());
		GSZGHGdaQFfWDPcQvhvdfRFjiIiV += "\n";
		NCScKtADzeppzSpslQSpTRFVnWmX("Axis Count", IAYCyCCfxLADdcDSjhLuqwShOQyR.Capabilities.wbsCjjmacTLyfxArQKRouMOsODD);
		NCScKtADzeppzSpslQSpTRFVnWmX("Button Count", IAYCyCCfxLADdcDSjhLuqwShOQyR.Capabilities.qcyHpxgSpKtegmJpDPmnhYbZINb);
		NCScKtADzeppzSpslQSpTRFVnWmX("Hat Count", IAYCyCCfxLADdcDSjhLuqwShOQyR.Capabilities.NqgfKCdrcZpooGlIRIZbRyRYknzC);
		GSZGHGdaQFfWDPcQvhvdfRFjiIiV += "\n";
		if (flag)
		{
			Rewired.Logger.Log("Device Name: \"" + UiueHXbfdzXSDcdtjqILFukiDRXY[DcXhJciIRzxmOJhYUnuTDChztuP].DgEhJocJJkZoJBLmmHdIFnYalFtw + "\"");
			Rewired.Logger.Log("Identifier: " + new PidVid(IAYCyCCfxLADdcDSjhLuqwShOQyR.Information.oeNdQWoDfdJZbQNVIMHzlNMZeJp));
		}
		for (int k = 0; k < 32; k++)
		{
			int num3 = TgLPLRPKTlXSaoodLpemjkZzehs((DirectInputAxis)k, wdUgpcVePDxEWRCUGSnBbePWAHU);
			string text2 = ((DirectInputAxis)k).ToString();
			NCScKtADzeppzSpslQSpTRFVnWmX(text2, num3 + " (" + gGNoAhCUXzgDbDcskWksokriYti(num3) + ")");
		}
		int[] pointOfViewControllers = wdUgpcVePDxEWRCUGSnBbePWAHU.PointOfViewControllers;
		for (int l = 0; l < 4; l++)
		{
			int num4 = pointOfViewControllers[l];
			string text3 = "Hat " + l;
			NCScKtADzeppzSpslQSpTRFVnWmX(text3, num4);
		}
		bool[] buttons = wdUgpcVePDxEWRCUGSnBbePWAHU.Buttons;
		string text4 = "";
		for (int m = 0; m < 128; m++)
		{
			if (buttons[m])
			{
				if (text4 != "")
				{
					text4 += ", ";
				}
				text4 += m;
			}
		}
		NCScKtADzeppzSpslQSpTRFVnWmX("Buttons ", text4);
		sCXrcRxxEvSNPlFSyjevCbwjDpDE.text = GSZGHGdaQFfWDPcQvhvdfRFjiIiV;
	}

	private void gLAITACQupcsXaeprKsFOosklIl()
	{
		UiueHXbfdzXSDcdtjqILFukiDRXY = yuVdsmfyNnpmsPViwqbiAHkqsVe.yDqiGSkMQYxYBcosfJNCvDgVcTXc(QyuEnlbUowDKQRpThenvnYsTHrA.HGdLkhkeXxQgpeHxfXiEbkQICSv, acSaGRXzHfCbnAZWrzgPGuGjden.xycNSjFEVhRECdalUfBPpVOeFZng);
		WBjWOBmzQcswasSCOOBgHbMGIpI = yuVdsmfyNnpmsPViwqbiAHkqsVe.yDqiGSkMQYxYBcosfJNCvDgVcTXc(QyuEnlbUowDKQRpThenvnYsTHrA.cXEeBjOXiiTJnTtduUOyunqeJia, acSaGRXzHfCbnAZWrzgPGuGjden.xycNSjFEVhRECdalUfBPpVOeFZng);
		ShpKpoHKriIeImWuNfVctWPuOhb = ((WBjWOBmzQcswasSCOOBgHbMGIpI != null) ? WBjWOBmzQcswasSCOOBgHbMGIpI.Count : 0);
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
		WBjWOBmzQcswasSCOOBgHbMGIpI = null;
		AAZkfGnNpnzmxHESABcweKtNqMKc = false;
		AJeirwxBSXczjCmdbGIsmyYYVER = false;
		ShpKpoHKriIeImWuNfVctWPuOhb = 0;
	}

	private void NCScKtADzeppzSpslQSpTRFVnWmX(string P_0, object P_1)
	{
		string gSZGHGdaQFfWDPcQvhvdfRFjiIiV = GSZGHGdaQFfWDPcQvhvdfRFjiIiV;
		GSZGHGdaQFfWDPcQvhvdfRFjiIiV = gSZGHGdaQFfWDPcQvhvdfRFjiIiV + P_0 + " = " + P_1.ToString() + "\n";
	}

	private int TgLPLRPKTlXSaoodLpemjkZzehs(DirectInputAxis P_0, WdUgpcVePDxEWRCUGSnBbePWAHU P_1)
	{
		return P_0 switch
		{
			DirectInputAxis.X => P_1.X, 
			DirectInputAxis.Y => P_1.Y, 
			DirectInputAxis.Z => P_1.Z, 
			DirectInputAxis.RotationX => P_1.RotationX, 
			DirectInputAxis.RotationY => P_1.RotationY, 
			DirectInputAxis.RotationZ => P_1.RotationZ, 
			DirectInputAxis.Slider0 => P_1.Sliders[0], 
			DirectInputAxis.Slider1 => P_1.Sliders[1], 
			DirectInputAxis.VelocityX => P_1.VelocityX, 
			DirectInputAxis.VelocityY => P_1.VelocityY, 
			DirectInputAxis.VelocityZ => P_1.VelocityZ, 
			DirectInputAxis.AngularVelocityX => P_1.AngularVelocityX, 
			DirectInputAxis.AngularVelocityY => P_1.AngularVelocityY, 
			DirectInputAxis.AngularVelocityZ => P_1.AngularVelocityZ, 
			DirectInputAxis.VelocitySlider0 => P_1.VelocitySliders[0], 
			DirectInputAxis.VelocitySlider1 => P_1.VelocitySliders[1], 
			DirectInputAxis.AccelerationX => P_1.AccelerationX, 
			DirectInputAxis.AccelerationY => P_1.AccelerationY, 
			DirectInputAxis.AccelerationZ => P_1.AccelerationZ, 
			DirectInputAxis.AngularAccelerationX => P_1.AngularAccelerationX, 
			DirectInputAxis.AngularAccelerationY => P_1.AngularAccelerationY, 
			DirectInputAxis.AngularAccelerationZ => P_1.AngularAccelerationZ, 
			DirectInputAxis.AccelerationSlider0 => P_1.AccelerationSliders[0], 
			DirectInputAxis.AccelerationSlider1 => P_1.AccelerationSliders[1], 
			DirectInputAxis.ForceX => P_1.ForceX, 
			DirectInputAxis.ForceY => P_1.ForceY, 
			DirectInputAxis.ForceZ => P_1.ForceZ, 
			DirectInputAxis.TorqueX => P_1.TorqueX, 
			DirectInputAxis.TorqueY => P_1.TorqueY, 
			DirectInputAxis.TorqueZ => P_1.TorqueZ, 
			DirectInputAxis.ForceSlider0 => P_1.ForceSliders[0], 
			DirectInputAxis.ForceSlider1 => P_1.ForceSliders[1], 
			_ => 0, 
		};
	}

	private float gGNoAhCUXzgDbDcskWksokriYti(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}

	public void OnDestroy()
	{
		if (IAYCyCCfxLADdcDSjhLuqwShOQyR != null)
		{
			IAYCyCCfxLADdcDSjhLuqwShOQyR.SdCpHXCeCCZSBrMShYjjsXEWWgu();
		}
	}
}
