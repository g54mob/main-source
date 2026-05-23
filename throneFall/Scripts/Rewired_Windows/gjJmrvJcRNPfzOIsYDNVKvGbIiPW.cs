using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class gjJmrvJcRNPfzOIsYDNVKvGbIiPW : IElementIdentifierTool
{
	private Rewired.Internal.GUIText yGGrtxFbgDGkDDQOYsKpeyiUtplhA;

	private string xTbPeNnnLlWCMfptkFODicEXeMlBb;

	private int sCwCzrdBDFTjwRYIaveJgMWvAWKe;

	private TLpaAyfjQfVEHNKGQCySwHFUzfaqA IIGcjvGEnkZdCAhAKzzxuSgULtpt;

	private OzySGGBmBYhYxgwfTlyHImbOUOXkA KkRUiSMUToJzgqBxPuMNXxbUWmbv;

	private Guid WbZlKXOMgdKTSefBmhhKLCzAGKQFA;

	private IList<OzySGGBmBYhYxgwfTlyHImbOUOXkA> ZOlgOXAqVtNXqfldwnIIVvfyPgYtA;

	private bool PwDPBoRLOEydhkEYQxCMHyuiexiL;

	private bool RTXPkjmfkMGAdaOhZwTAeEFmcZEFA;

	private bool LgQZtfuJuncoDLVimoluNaMjhEAl;

	private string[] BGPvmodgOYaANxUFYwaeTfCWrcHN;

	private int[] ynuxJzwnwipqjLbubjcVVnWqwgcI;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		yGGrtxFbgDGkDDQOYsKpeyiUtplhA = text;
		BGPvmodgOYaANxUFYwaeTfCWrcHN = Enum.GetNames(typeof(RawInputAxis));
		ynuxJzwnwipqjLbubjcVVnWqwgcI = (int[])Enum.GetValues(typeof(RawInputAxis));
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
		IIGcjvGEnkZdCAhAKzzxuSgULtpt = ReInput.primaryInputManager.inputSource as TLpaAyfjQfVEHNKGQCySwHFUzfaqA;
		if (IIGcjvGEnkZdCAhAKzzxuSgULtpt == null)
		{
			Rewired.Logger.LogError("Unable to initialize Raw Input! You must add a Rewired Input Manager to the scene and set the input mode to Raw Input.");
			return;
		}
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += RsExIZsFjVbFPWIhlXRGVkxkaQbP;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += WGCnvtTVPzpMgFHClgZJudOgBHUe;
		ctZHVuVgtriWhrzMJGJMOGmBMKUu();
		LgQZtfuJuncoDLVimoluNaMjhEAl = true;
	}

	void IElementIdentifierTool.Start()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Start
		this.Start();
	}

	public void Update()
	{
		if (!LgQZtfuJuncoDLVimoluNaMjhEAl)
		{
			return;
		}
		xTbPeNnnLlWCMfptkFODicEXeMlBb = "Raw Input Joystick Element Identifier\n\n";
		yGGrtxFbgDGkDDQOYsKpeyiUtplhA.text = xTbPeNnnLlWCMfptkFODicEXeMlBb;
		int num = sCwCzrdBDFTjwRYIaveJgMWvAWKe;
		Guid wbZlKXOMgdKTSefBmhhKLCzAGKQFA = WbZlKXOMgdKTSefBmhhKLCzAGKQFA;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			sCwCzrdBDFTjwRYIaveJgMWvAWKe++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			sCwCzrdBDFTjwRYIaveJgMWvAWKe--;
		}
		if (RTXPkjmfkMGAdaOhZwTAeEFmcZEFA)
		{
			ctZHVuVgtriWhrzMJGJMOGmBMKUu();
			RTXPkjmfkMGAdaOhZwTAeEFmcZEFA = false;
		}
		int num2 = ((ZOlgOXAqVtNXqfldwnIIVvfyPgYtA != null) ? ZOlgOXAqVtNXqfldwnIIVvfyPgYtA.Count : 0);
		if (num2 == 0)
		{
			return;
		}
		if (sCwCzrdBDFTjwRYIaveJgMWvAWKe < 0)
		{
			sCwCzrdBDFTjwRYIaveJgMWvAWKe = num2 - 1;
		}
		else if (sCwCzrdBDFTjwRYIaveJgMWvAWKe >= num2)
		{
			sCwCzrdBDFTjwRYIaveJgMWvAWKe = 0;
		}
		WbZlKXOMgdKTSefBmhhKLCzAGKQFA = ZOlgOXAqVtNXqfldwnIIVvfyPgYtA[sCwCzrdBDFTjwRYIaveJgMWvAWKe].nsyavkgcgbuRFXdlgcChhxcpfICc;
		bool flag = false;
		if (num != sCwCzrdBDFTjwRYIaveJgMWvAWKe || wbZlKXOMgdKTSefBmhhKLCzAGKQFA != WbZlKXOMgdKTSefBmhhKLCzAGKQFA)
		{
			flag = true;
		}
		if (KkRUiSMUToJzgqBxPuMNXxbUWmbv == null || flag)
		{
			if (KkRUiSMUToJzgqBxPuMNXxbUWmbv != null)
			{
				KkRUiSMUToJzgqBxPuMNXxbUWmbv.RbFzknuaRbYFdMGXLdVfCOBelTYb();
			}
			KkRUiSMUToJzgqBxPuMNXxbUWmbv = ZOlgOXAqVtNXqfldwnIIVvfyPgYtA[sCwCzrdBDFTjwRYIaveJgMWvAWKe];
			if (KkRUiSMUToJzgqBxPuMNXxbUWmbv == null)
			{
				return;
			}
			KkRUiSMUToJzgqBxPuMNXxbUWmbv.bHXoMueoAGhhLFPCEawLezHslAnxA();
		}
		bool flag2 = false;
		if (KkRUiSMUToJzgqBxPuMNXxbUWmbv.zRFtBzLHJIBsKaNUKFxRdrZsuZXq is gHDldKZwkuMzyeVpZkScEkEvRLzo)
		{
			flag2 = true;
		}
		else if (!(KkRUiSMUToJzgqBxPuMNXxbUWmbv.zRFtBzLHJIBsKaNUKFxRdrZsuZXq is nYpnZgtHaQPSwPsapFlTmgDlfAMU))
		{
			return;
		}
		if (num2 > 0)
		{
			xTbPeNnnLlWCMfptkFODicEXeMlBb = xTbPeNnnLlWCMfptkFODicEXeMlBb + num2 + " connected devices:\n";
		}
		for (int i = 0; i < num2; i++)
		{
			xTbPeNnnLlWCMfptkFODicEXeMlBb = xTbPeNnnLlWCMfptkFODicEXeMlBb + ZOlgOXAqVtNXqfldwnIIVvfyPgYtA[i].XxyuMkMmhKoIInyRDWsCmtKGdgHA + "\n";
		}
		xTbPeNnnLlWCMfptkFODicEXeMlBb += "\n";
		xTbPeNnnLlWCMfptkFODicEXeMlBb = xTbPeNnnLlWCMfptkFODicEXeMlBb + "Current RI device " + sCwCzrdBDFTjwRYIaveJgMWvAWKe + ": \"" + KkRUiSMUToJzgqBxPuMNXxbUWmbv.XxyuMkMmhKoIInyRDWsCmtKGdgHA + "\"\n";
		xTbPeNnnLlWCMfptkFODicEXeMlBb += "(Press + or - to change monitored device id.)\n\n";
		DLjgXvaJoHfKKgPwNawBDKxRlUhEb("Product Name", "\"" + KkRUiSMUToJzgqBxPuMNXxbUWmbv.XxyuMkMmhKoIInyRDWsCmtKGdgHA + "\"");
		DLjgXvaJoHfKKgPwNawBDKxRlUhEb("Is Bluetooth Device", KkRUiSMUToJzgqBxPuMNXxbUWmbv.NifCQRRuHIWBzkmqZsWwxbpaExFX);
		if (KkRUiSMUToJzgqBxPuMNXxbUWmbv.NifCQRRuHIWBzkmqZsWwxbpaExFX)
		{
			DLjgXvaJoHfKKgPwNawBDKxRlUhEb("Bluetooth Device Name", "\"" + KkRUiSMUToJzgqBxPuMNXxbUWmbv.GnJPWfnpLSjeStgIxhadEXfgmXOY + "\"");
		}
		if (flag2)
		{
			DLjgXvaJoHfKKgPwNawBDKxRlUhEb("Using Custom Driver", "TRUE");
		}
		DLjgXvaJoHfKKgPwNawBDKxRlUhEb("Device Type", KkRUiSMUToJzgqBxPuMNXxbUWmbv.qpTuqoVyPHjOpAAoABLJbutlJrPG.ToString());
		DLjgXvaJoHfKKgPwNawBDKxRlUhEb("Identifier", new PidVid(KkRUiSMUToJzgqBxPuMNXxbUWmbv.reWXjJyHHSNMukjgXBpwrUuUBMeJA));
		DLjgXvaJoHfKKgPwNawBDKxRlUhEb("Product Id", KkRUiSMUToJzgqBxPuMNXxbUWmbv.HUvbaPYWVHzaxnHiJXMScbcOrkSC);
		DLjgXvaJoHfKKgPwNawBDKxRlUhEb("Vendor Id", KkRUiSMUToJzgqBxPuMNXxbUWmbv.FPpDVFqxOBHVOBsaIxIwdAOjqEkzA);
		xTbPeNnnLlWCMfptkFODicEXeMlBb += "\n";
		DLjgXvaJoHfKKgPwNawBDKxRlUhEb("Axis Count", KkRUiSMUToJzgqBxPuMNXxbUWmbv.sLBGBBvNdfCmXzXTXupKenKTeLpEA);
		DLjgXvaJoHfKKgPwNawBDKxRlUhEb("Button Count", KkRUiSMUToJzgqBxPuMNXxbUWmbv.UWMmOITifkPGgSIqTnqobHtqhqIC);
		DLjgXvaJoHfKKgPwNawBDKxRlUhEb("Hat Count", KkRUiSMUToJzgqBxPuMNXxbUWmbv.gkfgipYbCVtOctmsVuhoVRGUdEpp);
		xTbPeNnnLlWCMfptkFODicEXeMlBb += "\n";
		if (flag)
		{
			string text = "";
			text = text + "Device Name: \"" + ZOlgOXAqVtNXqfldwnIIVvfyPgYtA[sCwCzrdBDFTjwRYIaveJgMWvAWKe].XxyuMkMmhKoIInyRDWsCmtKGdgHA + "\"\n";
			if (KkRUiSMUToJzgqBxPuMNXxbUWmbv.NifCQRRuHIWBzkmqZsWwxbpaExFX)
			{
				text = text + "Bluetooth Device Name: \"" + KkRUiSMUToJzgqBxPuMNXxbUWmbv.GnJPWfnpLSjeStgIxhadEXfgmXOY + "\"\n";
			}
			text = text + "Identifier: " + new PidVid(KkRUiSMUToJzgqBxPuMNXxbUWmbv.reWXjJyHHSNMukjgXBpwrUuUBMeJA).ToString() + "\n";
			Rewired.Logger.Log(text);
		}
		if (!flag2)
		{
			nYpnZgtHaQPSwPsapFlTmgDlfAMU nYpnZgtHaQPSwPsapFlTmgDlfAMU2 = KkRUiSMUToJzgqBxPuMNXxbUWmbv.zRFtBzLHJIBsKaNUKFxRdrZsuZXq as nYpnZgtHaQPSwPsapFlTmgDlfAMU;
			for (int j = 1; j < BGPvmodgOYaANxUFYwaeTfCWrcHN.Length - 1; j++)
			{
				int num3 = PRcYRgbashIbNETfHaUNZHoZfYPiA((RawInputAxis)ynuxJzwnwipqjLbubjcVVnWqwgcI[j], 0, nYpnZgtHaQPSwPsapFlTmgDlfAMU2);
				string text2 = BGPvmodgOYaANxUFYwaeTfCWrcHN[j];
				try
				{
					DLjgXvaJoHfKKgPwNawBDKxRlUhEb(text2, num3 + " (" + pbPLGTkuVtUdpsaXcBSOAfHUnRmM(num3) + ")");
				}
				catch
				{
					DLjgXvaJoHfKKgPwNawBDKxRlUhEb(text2, "FAILED! Axis value = " + num3);
				}
			}
			if (nYpnZgtHaQPSwPsapFlTmgDlfAMU2.BORHtNjwBaZUWnvidpEruciYEiNc > 0)
			{
				for (int k = 0; k < nYpnZgtHaQPSwPsapFlTmgDlfAMU2.BORHtNjwBaZUWnvidpEruciYEiNc; k++)
				{
					int num4 = PRcYRgbashIbNETfHaUNZHoZfYPiA(RawInputAxis.Other, k, nYpnZgtHaQPSwPsapFlTmgDlfAMU2);
					string text3 = "Other Axis " + k;
					try
					{
						DLjgXvaJoHfKKgPwNawBDKxRlUhEb(text3, num4 + " (" + pbPLGTkuVtUdpsaXcBSOAfHUnRmM(num4) + ")");
					}
					catch
					{
						DLjgXvaJoHfKKgPwNawBDKxRlUhEb(text3, "FAILED! Axis value = " + num4);
					}
				}
			}
			int[] array = KkRUiSMUToJzgqBxPuMNXxbUWmbv.agMgBsulKeFEUKxbyMYzjAYaJqljA;
			for (int l = 0; l < array.Length; l++)
			{
				int num5 = array[l];
				string text4 = "Hat " + l;
				DLjgXvaJoHfKKgPwNawBDKxRlUhEb(text4, num5);
			}
			bool[] array2 = KkRUiSMUToJzgqBxPuMNXxbUWmbv.nfulUzEzTLPuprbLuElbHvwsLQVkA;
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
			DLjgXvaJoHfKKgPwNawBDKxRlUhEb("Buttons ", text5);
		}
		else
		{
			gHDldKZwkuMzyeVpZkScEkEvRLzo gHDldKZwkuMzyeVpZkScEkEvRLzo2 = KkRUiSMUToJzgqBxPuMNXxbUWmbv.zRFtBzLHJIBsKaNUKFxRdrZsuZXq as gHDldKZwkuMzyeVpZkScEkEvRLzo;
			for (int n = 0; n < KkRUiSMUToJzgqBxPuMNXxbUWmbv.sLBGBBvNdfCmXzXTXupKenKTeLpEA; n++)
			{
				float num6 = gHDldKZwkuMzyeVpZkScEkEvRLzo2.JsdLJuvJFWtMNMRkkyWGxZdvTLbL(n);
				string text6 = n.ToString();
				try
				{
					DLjgXvaJoHfKKgPwNawBDKxRlUhEb(text6, num6 + " (" + gHDldKZwkuMzyeVpZkScEkEvRLzo2.wOBdZzzDmWRbEIeJdqAwLuVvhCDL(n) + ")");
				}
				catch
				{
					DLjgXvaJoHfKKgPwNawBDKxRlUhEb(text6, "FAILED! Axis value = " + num6);
				}
			}
			int[] array3 = KkRUiSMUToJzgqBxPuMNXxbUWmbv.agMgBsulKeFEUKxbyMYzjAYaJqljA;
			for (int num7 = 0; num7 < KkRUiSMUToJzgqBxPuMNXxbUWmbv.gkfgipYbCVtOctmsVuhoVRGUdEpp; num7++)
			{
				int num8 = array3[num7];
				string text7 = "Hat " + num7;
				DLjgXvaJoHfKKgPwNawBDKxRlUhEb(text7, num8);
			}
			for (int num9 = 0; num9 < KkRUiSMUToJzgqBxPuMNXxbUWmbv.KalRSGqHTzKnJkTISFnZkGzaHthW.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EGyroscopeCount; num9++)
			{
				int tfEKDzEReXNMloUDbgGNuvSyQnPK = KkRUiSMUToJzgqBxPuMNXxbUWmbv.KalRSGqHTzKnJkTISFnZkGzaHthW.gyroscopes[num9].tfEKDzEReXNMloUDbgGNuvSyQnPK;
				string text8 = "";
				for (int num10 = 0; num10 < tfEKDzEReXNMloUDbgGNuvSyQnPK; num10++)
				{
					float num11 = KkRUiSMUToJzgqBxPuMNXxbUWmbv.KalRSGqHTzKnJkTISFnZkGzaHthW.gyroscopes[num9].ZCKmYdzExBcrTEdbLYeNBVgDsXZH[num10];
					text8 = text8 + "[" + num10 + "]: " + num11.ToString("f3");
					if (num10 < tfEKDzEReXNMloUDbgGNuvSyQnPK - 1)
					{
						text8 += " ";
					}
				}
				DLjgXvaJoHfKKgPwNawBDKxRlUhEb("Gyro " + num9, text8);
			}
			for (int num12 = 0; num12 < KkRUiSMUToJzgqBxPuMNXxbUWmbv.KalRSGqHTzKnJkTISFnZkGzaHthW.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EAccelerometerCount; num12++)
			{
				int wOztpLQlIpHKxzhjAokRaILGmKWK = KkRUiSMUToJzgqBxPuMNXxbUWmbv.KalRSGqHTzKnJkTISFnZkGzaHthW.accelerometers[num12].WOztpLQlIpHKxzhjAokRaILGmKWK;
				string text9 = "";
				for (int num13 = 0; num13 < wOztpLQlIpHKxzhjAokRaILGmKWK; num13++)
				{
					float num14 = KkRUiSMUToJzgqBxPuMNXxbUWmbv.KalRSGqHTzKnJkTISFnZkGzaHthW.accelerometers[num12].VNYkooeoXLtNVzxyiQWNaRkcrEnm[num13];
					text9 = text9 + "[" + num13 + "]: " + num14.ToString("f3");
					if (num13 < wOztpLQlIpHKxzhjAokRaILGmKWK - 1)
					{
						text9 += " ";
					}
				}
				DLjgXvaJoHfKKgPwNawBDKxRlUhEb("Accelerometer " + num12, text9);
			}
			for (int num15 = 0; num15 < KkRUiSMUToJzgqBxPuMNXxbUWmbv.KalRSGqHTzKnJkTISFnZkGzaHthW.Rewired_002EHID_002EDrivers_002EIControllerDriver_002ETouchpadCount; num15++)
			{
				SRlmwzCpkDCiOPGALkZGROsZKGfx sRlmwzCpkDCiOPGALkZGROsZKGfx = KkRUiSMUToJzgqBxPuMNXxbUWmbv.KalRSGqHTzKnJkTISFnZkGzaHthW.touchpads[num15];
				int num16 = sRlmwzCpkDCiOPGALkZGROsZKGfx.NjrKDEoRljbTLZdbSWZHjMXESqOB.Length;
				string text10 = "";
				for (int num17 = 0; num17 < num16; num17++)
				{
					SRlmwzCpkDCiOPGALkZGROsZKGfx.TouchData touchData = sRlmwzCpkDCiOPGALkZGROsZKGfx.NjrKDEoRljbTLZdbSWZHjMXESqOB[num17];
					text10 = text10 + "Touch " + num17 + ": Is Touching = " + touchData.isTouching + "\n";
					text10 = text10 + "Touch " + num17 + ": Touch Id = " + touchData.touchId + "\n";
					text10 = text10 + "Touch " + num17 + ": Position = " + touchData.positionX + ", " + touchData.positionY + "\n";
					text10 = text10 + "Touch " + num17 + ": Abs Position = " + touchData.positionAbsX + ", " + touchData.positionAbsY + " (" + touchData.positionRawX + ", " + touchData.positionRawY + ")\n";
				}
				rMBpXPqaXSkYvbhJCVrDvfhBwAdn("Touchpad " + num15, text10);
			}
			bool[] array4 = KkRUiSMUToJzgqBxPuMNXxbUWmbv.nfulUzEzTLPuprbLuElbHvwsLQVkA;
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
			DLjgXvaJoHfKKgPwNawBDKxRlUhEb("Buttons ", text11);
		}
		yGGrtxFbgDGkDDQOYsKpeyiUtplhA.text = xTbPeNnnLlWCMfptkFODicEXeMlBb;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void OnDestroy()
	{
		if (KkRUiSMUToJzgqBxPuMNXxbUWmbv != null)
		{
			KkRUiSMUToJzgqBxPuMNXxbUWmbv.RbFzknuaRbYFdMGXLdVfCOBelTYb();
		}
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}

	private void ctZHVuVgtriWhrzMJGJMOGmBMKUu()
	{
		ZOlgOXAqVtNXqfldwnIIVvfyPgYtA = IIGcjvGEnkZdCAhAKzzxuSgULtpt.GetJoysticks<OzySGGBmBYhYxgwfTlyHImbOUOXkA>();
	}

	private void RsExIZsFjVbFPWIhlXRGVkxkaQbP()
	{
		bbnefqSijvFiJcvqGIeFOTkNSrQS();
	}

	private void WGCnvtTVPzpMgFHClgZJudOgBHUe()
	{
		bbnefqSijvFiJcvqGIeFOTkNSrQS();
	}

	private void bbnefqSijvFiJcvqGIeFOTkNSrQS()
	{
		rMWILPxZnlfKePAVmBljEDSOighIA();
		RTXPkjmfkMGAdaOhZwTAeEFmcZEFA = true;
	}

	private void rMWILPxZnlfKePAVmBljEDSOighIA()
	{
		sCwCzrdBDFTjwRYIaveJgMWvAWKe = 0;
		KkRUiSMUToJzgqBxPuMNXxbUWmbv = null;
		WbZlKXOMgdKTSefBmhhKLCzAGKQFA = Guid.Empty;
		ZOlgOXAqVtNXqfldwnIIVvfyPgYtA = null;
		PwDPBoRLOEydhkEYQxCMHyuiexiL = false;
		RTXPkjmfkMGAdaOhZwTAeEFmcZEFA = false;
	}

	private void DLjgXvaJoHfKKgPwNawBDKxRlUhEb(string P_0, object P_1)
	{
		xTbPeNnnLlWCMfptkFODicEXeMlBb = xTbPeNnnLlWCMfptkFODicEXeMlBb + P_0 + " = " + P_1.ToString() + "\n";
	}

	private void rMBpXPqaXSkYvbhJCVrDvfhBwAdn(string P_0, object P_1)
	{
		xTbPeNnnLlWCMfptkFODicEXeMlBb = xTbPeNnnLlWCMfptkFODicEXeMlBb + P_0 + ":\n" + P_1.ToString() + "\n";
	}

	private int PRcYRgbashIbNETfHaUNZHoZfYPiA(RawInputAxis P_0, int P_1, nYpnZgtHaQPSwPsapFlTmgDlfAMU P_2)
	{
		return P_2.hRhinkLYTiROeOdHlyUupdGxydfl(P_0, P_1);
	}

	private float pbPLGTkuVtUdpsaXcBSOAfHUnRmM(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
