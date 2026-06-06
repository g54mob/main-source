using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal sealed class SCugXTcGgQeaugsEHNkauvnIVnHo : IElementIdentifierTool
{
	private Rewired.Internal.GUIText DJXWWxyBIPvAeivyFUYhxHKkNUwd;

	private string yKmdldLZmCpqyFlOmJCsvlSTzVgu;

	private int BBtASCiXpEbAxtJLvWyJBPHiONTKA;

	private CGQDElZkrsIdyOndrzkMvJbpsuKb lRDmHdyRKJyWKpfKDLDBFHfZmrIy;

	private XLCyFVnacsfmCzPCdExtsrFUiHrH lCddLzvIYfWYUmhwXEeURlMDbRDFA;

	private Guid hPnyvdLCqtRgNdqnXhMaFGfnmpUJ;

	private IList<JwOsKFPjPBIlckyhencRQGSXVgXH> QQrhIcajzhDAIkugVacsnuOJbbeFA;

	private IList<JwOsKFPjPBIlckyhencRQGSXVgXH> EAOIGqDVxuDMPSSjPbTmgJakJYOm;

	private bool HpHQlSvwFpFuyVAMhdSSIkQBqFou;

	private bool RTNHMHHZolwyDXPvUNOaMECzrfsE;

	private bool RIQMQsUGOZQZnHmcDpuSyexuRKGN;

	private int xUsCsNCxPZQftexfvPIBlSuWmcRAA;

	private TimerRealTime NgHMyBbDQKjpYtqykdNcEZsgaBtc;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		DJXWWxyBIPvAeivyFUYhxHKkNUwd = text;
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
			Rewired.Logger.LogError("Direct Input cannot be run on this platform. You must be running the editor in Windows.");
		}
		else if (ReInput.currentPlatform != Platform.Windows)
		{
			Rewired.Logger.LogError("Direct Input cannot be run on this build target. Be sure Unity's build target is set to Windows Standalone.");
		}
		else if (ReInput.primaryInputManager.inputSource is InputSourceWrapper<CGQDElZkrsIdyOndrzkMvJbpsuKb> { source: not null } inputSourceWrapper)
		{
			lRDmHdyRKJyWKpfKDLDBFHfZmrIy = inputSourceWrapper.source;
			ReInput.primaryInputManager.SystemDeviceConnectedEvent += hhVZYozvKkvcdQmaaKxWRhplNFZX;
			ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += hniIVweZqGUAVfZngDNXGOUVgLkdA;
			NgHMyBbDQKjpYtqykdNcEZsgaBtc = new TimerRealTime(1.0);
			NgHMyBbDQKjpYtqykdNcEZsgaBtc.Start();
			vxcuZypipUGjJfLzhGiPrBZbBAMt();
			RIQMQsUGOZQZnHmcDpuSyexuRKGN = true;
		}
		else
		{
			Rewired.Logger.LogError("Unable to initialize Direct Input! You must add a Rewired Input Manager to the scene and set the input mode to Direct Input.");
		}
	}

	void IElementIdentifierTool.Start()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Start
		this.Start();
	}

	public void Update()
	{
		if (!RIQMQsUGOZQZnHmcDpuSyexuRKGN)
		{
			return;
		}
		yKmdldLZmCpqyFlOmJCsvlSTzVgu = "Direct Input Joystick Element Identifier\n\n";
		DJXWWxyBIPvAeivyFUYhxHKkNUwd.text = yKmdldLZmCpqyFlOmJCsvlSTzVgu;
		if (Input.GetKeyDown(KeyCode.A))
		{
			HpHQlSvwFpFuyVAMhdSSIkQBqFou = !HpHQlSvwFpFuyVAMhdSSIkQBqFou;
		}
		if (HpHQlSvwFpFuyVAMhdSSIkQBqFou)
		{
			DJXWWxyBIPvAeivyFUYhxHKkNUwd.text += "All Devices:\n";
			foreach (JwOsKFPjPBIlckyhencRQGSXVgXH item in EAOIGqDVxuDMPSSjPbTmgJakJYOm)
			{
				Rewired.Internal.GUIText dJXWWxyBIPvAeivyFUYhxHKkNUwd = DJXWWxyBIPvAeivyFUYhxHKkNUwd;
				dJXWWxyBIPvAeivyFUYhxHKkNUwd.text = dJXWWxyBIPvAeivyFUYhxHKkNUwd.text + item.CtmLpENCzrjmcHsdewIXiMiUeIqIA + ", " + item.kuKCNoZcYNNeknkqvbgGTnjAAGSz + ", " + new PidVid(item.HySZBGMwhUkvgQxYHLwubwCwnhMF).ToString() + ", " + item.uPQdfZGCbrTbUwygmSZXlHPHYCCS + ", " + item.zyMqfdMgYfclRqhxxhKlVFDcghgZ + ", " + item.FxtczQJNHhOaYLZkwsZWOkdVWtFP + "\n";
			}
			DJXWWxyBIPvAeivyFUYhxHKkNUwd.text += "\n";
		}
		int bBtASCiXpEbAxtJLvWyJBPHiONTKA = BBtASCiXpEbAxtJLvWyJBPHiONTKA;
		Guid guid = hPnyvdLCqtRgNdqnXhMaFGfnmpUJ;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			BBtASCiXpEbAxtJLvWyJBPHiONTKA++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			BBtASCiXpEbAxtJLvWyJBPHiONTKA--;
		}
		if (NgHMyBbDQKjpYtqykdNcEZsgaBtc.Update())
		{
			int num = lRDmHdyRKJyWKpfKDLDBFHfZmrIy.dyKBFfCvIwdJXCWJplnbpVvNKFNL(pmRDleZVtcRYlUxVUfzrdFpkQOVP.All, LbziXCvUMpGuSDqUEbtTQoRYShyk.AttachedOnly);
			if (num != xUsCsNCxPZQftexfvPIBlSuWmcRAA)
			{
				xUsCsNCxPZQftexfvPIBlSuWmcRAA = num;
				RTNHMHHZolwyDXPvUNOaMECzrfsE = true;
			}
			NgHMyBbDQKjpYtqykdNcEZsgaBtc.Start();
		}
		if (RTNHMHHZolwyDXPvUNOaMECzrfsE)
		{
			vxcuZypipUGjJfLzhGiPrBZbBAMt();
			RTNHMHHZolwyDXPvUNOaMECzrfsE = false;
		}
		int num2 = ((QQrhIcajzhDAIkugVacsnuOJbbeFA != null) ? QQrhIcajzhDAIkugVacsnuOJbbeFA.Count : 0);
		if (num2 == 0)
		{
			return;
		}
		if (BBtASCiXpEbAxtJLvWyJBPHiONTKA < 0)
		{
			BBtASCiXpEbAxtJLvWyJBPHiONTKA = num2 - 1;
		}
		else if (BBtASCiXpEbAxtJLvWyJBPHiONTKA >= num2)
		{
			BBtASCiXpEbAxtJLvWyJBPHiONTKA = 0;
		}
		hPnyvdLCqtRgNdqnXhMaFGfnmpUJ = QQrhIcajzhDAIkugVacsnuOJbbeFA[BBtASCiXpEbAxtJLvWyJBPHiONTKA].pyDhcNgRqogBXYMltfkVKgTlhbSI;
		bool flag = false;
		if (bBtASCiXpEbAxtJLvWyJBPHiONTKA != BBtASCiXpEbAxtJLvWyJBPHiONTKA || guid != hPnyvdLCqtRgNdqnXhMaFGfnmpUJ)
		{
			flag = true;
		}
		if (lCddLzvIYfWYUmhwXEeURlMDbRDFA == null || flag)
		{
			if (lCddLzvIYfWYUmhwXEeURlMDbRDFA != null)
			{
				lCddLzvIYfWYUmhwXEeURlMDbRDFA.BYrYCjhRrQTlEFuhxTXDEQoMUZuU();
			}
			lCddLzvIYfWYUmhwXEeURlMDbRDFA = new XLCyFVnacsfmCzPCdExtsrFUiHrH(lRDmHdyRKJyWKpfKDLDBFHfZmrIy, QQrhIcajzhDAIkugVacsnuOJbbeFA[BBtASCiXpEbAxtJLvWyJBPHiONTKA].pyDhcNgRqogBXYMltfkVKgTlhbSI);
			if (lCddLzvIYfWYUmhwXEeURlMDbRDFA == null)
			{
				return;
			}
			IList<aLSDFxIIAnFGinWoAXLDQXOymMRJ> list = lCddLzvIYfWYUmhwXEeURlMDbRDFA.FPJBgaJxxjjqpmcPzAFFOkuUiRuSA();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if ((list[i].QEikRsxCylwHAxbliXPPtbpjgMWAA.MfuKxYoSWBOzmTFQkZMEBFQpIhEP & YHfQBlzXCaSKvSbTpixeOhmZfxid.Axis) != YHfQBlzXCaSKvSbTpixeOhmZfxid.All)
					{
						lCddLzvIYfWYUmhwXEeURlMDbRDFA.CElaehVUMlHqGjcbRjWuKvIezImN.LrgiEJTZtgkzudaaUmIIjYAxqBvs = new hFBwXspWgUHMXbSilyaWzGyAcelG(-65535, 65535);
					}
				}
			}
			lCddLzvIYfWYUmhwXEeURlMDbRDFA.yFWBlSAiUeHwYaAAdQRMvZfnNUaGA();
		}
		zzpcvdrriRvjvEAadMHZzAdpbEDf zzpcvdrriRvjvEAadMHZzAdpbEDf2;
		try
		{
			zzpcvdrriRvjvEAadMHZzAdpbEDf2 = lCddLzvIYfWYUmhwXEeURlMDbRDFA.lVzOnbJLWBjqecHVVbxlpYHIGvkS();
		}
		catch
		{
			zzpcvdrriRvjvEAadMHZzAdpbEDf2 = null;
		}
		if (zzpcvdrriRvjvEAadMHZzAdpbEDf2 == null)
		{
			return;
		}
		if (num2 > 0)
		{
			yKmdldLZmCpqyFlOmJCsvlSTzVgu = yKmdldLZmCpqyFlOmJCsvlSTzVgu + num2 + " connected devices:\n";
		}
		for (int j = 0; j < num2; j++)
		{
			yKmdldLZmCpqyFlOmJCsvlSTzVgu = yKmdldLZmCpqyFlOmJCsvlSTzVgu + QQrhIcajzhDAIkugVacsnuOJbbeFA[j].CtmLpENCzrjmcHsdewIXiMiUeIqIA + "\n";
		}
		yKmdldLZmCpqyFlOmJCsvlSTzVgu += "\n";
		yKmdldLZmCpqyFlOmJCsvlSTzVgu = yKmdldLZmCpqyFlOmJCsvlSTzVgu + "Current DI device " + BBtASCiXpEbAxtJLvWyJBPHiONTKA + ": " + QQrhIcajzhDAIkugVacsnuOJbbeFA[BBtASCiXpEbAxtJLvWyJBPHiONTKA].CtmLpENCzrjmcHsdewIXiMiUeIqIA + "\n";
		yKmdldLZmCpqyFlOmJCsvlSTzVgu += "(Press + or - to change monitored device id.)\n\n";
		FdDKTGJEihksJmADgAOLVKwvzyid("Identifier", new PidVid(lCddLzvIYfWYUmhwXEeURlMDbRDFA.MiytbXAKnzrCVJwuKTuypXODJgui.HySZBGMwhUkvgQxYHLwubwCwnhMF));
		FdDKTGJEihksJmADgAOLVKwvzyid("Instance GUID", lCddLzvIYfWYUmhwXEeURlMDbRDFA.MiytbXAKnzrCVJwuKTuypXODJgui.pyDhcNgRqogBXYMltfkVKgTlhbSI);
		FdDKTGJEihksJmADgAOLVKwvzyid("Product Id", lCddLzvIYfWYUmhwXEeURlMDbRDFA.CElaehVUMlHqGjcbRjWuKvIezImN.mYVplrejAZAiyBMuwTOaigakCoZNA);
		FdDKTGJEihksJmADgAOLVKwvzyid("Device Type", lCddLzvIYfWYUmhwXEeURlMDbRDFA.gmfVdhqMXIrfduYDkRPNaFCKPmJN.kOvcphabkgfeYcxfFMCVDkZyTOgx.ToString());
		yKmdldLZmCpqyFlOmJCsvlSTzVgu += "\n";
		FdDKTGJEihksJmADgAOLVKwvzyid("Axis Count", lCddLzvIYfWYUmhwXEeURlMDbRDFA.gmfVdhqMXIrfduYDkRPNaFCKPmJN.rVFrcEvmoXESZcgHnMJLqiPtXpze);
		FdDKTGJEihksJmADgAOLVKwvzyid("Button Count", lCddLzvIYfWYUmhwXEeURlMDbRDFA.gmfVdhqMXIrfduYDkRPNaFCKPmJN.zqXGMBRtghfrGclgpgSsVLqrBoXH);
		FdDKTGJEihksJmADgAOLVKwvzyid("Hat Count", lCddLzvIYfWYUmhwXEeURlMDbRDFA.gmfVdhqMXIrfduYDkRPNaFCKPmJN.QfKDioekvPLGCSnfDlzCAezCsTBec);
		yKmdldLZmCpqyFlOmJCsvlSTzVgu += "\n";
		if (flag)
		{
			Rewired.Logger.Log("Device Name: \"" + QQrhIcajzhDAIkugVacsnuOJbbeFA[BBtASCiXpEbAxtJLvWyJBPHiONTKA].CtmLpENCzrjmcHsdewIXiMiUeIqIA + "\"");
			Rewired.Logger.Log("Identifier: " + new PidVid(lCddLzvIYfWYUmhwXEeURlMDbRDFA.MiytbXAKnzrCVJwuKTuypXODJgui.HySZBGMwhUkvgQxYHLwubwCwnhMF).ToString());
		}
		for (int k = 0; k < 32; k++)
		{
			int num3 = spLcIxhrbsTdliGkNJxlevNAOfuoB((DirectInputAxis)k, zzpcvdrriRvjvEAadMHZzAdpbEDf2);
			DirectInputAxis directInputAxis = (DirectInputAxis)k;
			string text = directInputAxis.ToString();
			FdDKTGJEihksJmADgAOLVKwvzyid(text, num3 + " (" + xlclKTdgfcwYEhBvzXBBbgEbqYRM(num3) + ")");
		}
		int[] array = zzpcvdrriRvjvEAadMHZzAdpbEDf2.xovzsCuhmGMGHYAoxUvpsKsKdDCIA;
		for (int l = 0; l < 4; l++)
		{
			int num4 = array[l];
			string text2 = "Hat " + l;
			FdDKTGJEihksJmADgAOLVKwvzyid(text2, num4);
		}
		bool[] array2 = zzpcvdrriRvjvEAadMHZzAdpbEDf2.FoZARmvbojxwsQLFpBVqxvvLMtKG;
		string text3 = "";
		for (int m = 0; m < 128; m++)
		{
			if (array2[m])
			{
				if (text3 != "")
				{
					text3 += ", ";
				}
				text3 += m;
			}
		}
		FdDKTGJEihksJmADgAOLVKwvzyid("Buttons ", text3);
		DJXWWxyBIPvAeivyFUYhxHKkNUwd.text = yKmdldLZmCpqyFlOmJCsvlSTzVgu;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	private void vxcuZypipUGjJfLzhGiPrBZbBAMt()
	{
		QQrhIcajzhDAIkugVacsnuOJbbeFA = lRDmHdyRKJyWKpfKDLDBFHfZmrIy.nTqzftUbZriLrXFuVscZSEnmNnXI(pmRDleZVtcRYlUxVUfzrdFpkQOVP.GameControl, LbziXCvUMpGuSDqUEbtTQoRYShyk.AttachedOnly);
		EAOIGqDVxuDMPSSjPbTmgJakJYOm = lRDmHdyRKJyWKpfKDLDBFHfZmrIy.nTqzftUbZriLrXFuVscZSEnmNnXI(pmRDleZVtcRYlUxVUfzrdFpkQOVP.All, LbziXCvUMpGuSDqUEbtTQoRYShyk.AttachedOnly);
		xUsCsNCxPZQftexfvPIBlSuWmcRAA = ((EAOIGqDVxuDMPSSjPbTmgJakJYOm != null) ? EAOIGqDVxuDMPSSjPbTmgJakJYOm.Count : 0);
	}

	private void hhVZYozvKkvcdQmaaKxWRhplNFZX()
	{
		RqGAWSaGqmGaaQFcgcRuVPmrohgHA();
	}

	private void hniIVweZqGUAVfZngDNXGOUVgLkdA()
	{
		RqGAWSaGqmGaaQFcgcRuVPmrohgHA();
	}

	private void RqGAWSaGqmGaaQFcgcRuVPmrohgHA()
	{
		vAFyMIGaBbAZuxokDeBbzINbTOwX();
		RTNHMHHZolwyDXPvUNOaMECzrfsE = true;
	}

	private void vAFyMIGaBbAZuxokDeBbzINbTOwX()
	{
		BBtASCiXpEbAxtJLvWyJBPHiONTKA = 0;
		lCddLzvIYfWYUmhwXEeURlMDbRDFA = null;
		hPnyvdLCqtRgNdqnXhMaFGfnmpUJ = Guid.Empty;
		QQrhIcajzhDAIkugVacsnuOJbbeFA = null;
		EAOIGqDVxuDMPSSjPbTmgJakJYOm = null;
		HpHQlSvwFpFuyVAMhdSSIkQBqFou = false;
		RTNHMHHZolwyDXPvUNOaMECzrfsE = false;
		xUsCsNCxPZQftexfvPIBlSuWmcRAA = 0;
	}

	private void FdDKTGJEihksJmADgAOLVKwvzyid(string P_0, object P_1)
	{
		yKmdldLZmCpqyFlOmJCsvlSTzVgu = yKmdldLZmCpqyFlOmJCsvlSTzVgu + P_0 + " = " + P_1.ToString() + "\n";
	}

	private int spLcIxhrbsTdliGkNJxlevNAOfuoB(DirectInputAxis P_0, zzpcvdrriRvjvEAadMHZzAdpbEDf P_1)
	{
		return P_0 switch
		{
			DirectInputAxis.X => P_1.hSnAadBVdKyqNVOiZmuoHfYRCWKi, 
			DirectInputAxis.Y => P_1.EGaHVUnncvvFWOiYtwnTLcIhPODp, 
			DirectInputAxis.Z => P_1.FGofhmdZeyPYMLSKIcIPcSCiDvESB, 
			DirectInputAxis.RotationX => P_1.RfITxXmRBqkYLLopKJcKqGyMDsIg, 
			DirectInputAxis.RotationY => P_1.FSBqIHgWNZjhneACCGfxXwzvMYzO, 
			DirectInputAxis.RotationZ => P_1.EXhhWVqaZyUSuIhhPTMFBJeJptyM, 
			DirectInputAxis.Slider0 => P_1.bvDOlPvliHOMZCCKrorXpqLJcimF[0], 
			DirectInputAxis.Slider1 => P_1.bvDOlPvliHOMZCCKrorXpqLJcimF[1], 
			DirectInputAxis.VelocityX => P_1.UYcgvudvTORwBdzRLWIPtDoCvhqS, 
			DirectInputAxis.VelocityY => P_1.gIKYccLdyeYUIWjSVQAHSBYwBQmC, 
			DirectInputAxis.VelocityZ => P_1.zRKsUujTTJsWmaVRGCtCSaplhhYjA, 
			DirectInputAxis.AngularVelocityX => P_1.wCJBttcGNeGJeovWAuMlHLoHCgNDb, 
			DirectInputAxis.AngularVelocityY => P_1.dpWyLhqnlLebxJJOulRqJJpGKEIS, 
			DirectInputAxis.AngularVelocityZ => P_1.wMDQVgQOyfsVSgFRYqZGAqKgJTGL, 
			DirectInputAxis.VelocitySlider0 => P_1.idzdPLbdTgrafWgctYQAtWeWecON[0], 
			DirectInputAxis.VelocitySlider1 => P_1.idzdPLbdTgrafWgctYQAtWeWecON[1], 
			DirectInputAxis.AccelerationX => P_1.sajJmIASaVfxkyBQpYMPljbxCkfi, 
			DirectInputAxis.AccelerationY => P_1.bkkqbbmAumTLnLinfimnIMIJcooz, 
			DirectInputAxis.AccelerationZ => P_1.hVffyNcwmVJHqDuhRIlAEPEhfkBD, 
			DirectInputAxis.AngularAccelerationX => P_1.swFUhfLhKVeXvHwyineAvlsdhgtYA, 
			DirectInputAxis.AngularAccelerationY => P_1.lqilxxntFrMrCiztHDkBhMNzTBBC, 
			DirectInputAxis.AngularAccelerationZ => P_1.zdQgOuxOzvyQYglFYXjzxCveczPv, 
			DirectInputAxis.AccelerationSlider0 => P_1.SPMVidzwrpjiGmusLhvCNibbgEWK[0], 
			DirectInputAxis.AccelerationSlider1 => P_1.SPMVidzwrpjiGmusLhvCNibbgEWK[1], 
			DirectInputAxis.ForceX => P_1.EfdZzFNmIGMbtKiahZqyZyqBhIJH, 
			DirectInputAxis.ForceY => P_1.aqgWQhrgYRnzVpKwfpPsUdGBJqQe, 
			DirectInputAxis.ForceZ => P_1.WXQxewkENFDPrZfEIiwleWncWjzQ, 
			DirectInputAxis.TorqueX => P_1.fZXemmTwuxwwayyQMQtKkrqCytid, 
			DirectInputAxis.TorqueY => P_1.OIftGyIlLOgkvULdhUFkLPBAiIHCA, 
			DirectInputAxis.TorqueZ => P_1.EypvxijpmKHUnIvGmNOBPEFEHUFq, 
			DirectInputAxis.ForceSlider0 => P_1.TFqmtsGaSGbkcdolXEfcfQwJLWkh[0], 
			DirectInputAxis.ForceSlider1 => P_1.TFqmtsGaSGbkcdolXEfcfQwJLWkh[1], 
			_ => 0, 
		};
	}

	private float xlclKTdgfcwYEhBvzXBBbgEbqYRM(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}

	public void OnDestroy()
	{
		if (lCddLzvIYfWYUmhwXEeURlMDbRDFA != null)
		{
			lCddLzvIYfWYUmhwXEeURlMDbRDFA.BYrYCjhRrQTlEFuhxTXDEQoMUZuU();
		}
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}
}
