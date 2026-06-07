using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal sealed class CwQQgszhjJTqRGLxFXKCQvGLnAWo : IElementIdentifierTool
{
	private Rewired.Internal.GUIText JzAfbtKxCwASVKtjZrSXugCJMlLP;

	private string buIZqcLMLGSCBHddADdLhqrMOhcm;

	private int wbGCxIBPLgZzEuVdzcFrrXZHEhPP;

	private KuoyRxKqdxAGSEgGhZDEQTygELlnA RiImwGEzLgryksoRLxZMcAAATvck;

	private NPufsuAcvrnrrERzkxwVUAyhBNeCc rCJaKsAexMPepwMrQdSYEBasCTuF;

	private Guid BBoHkLsQpuXGjSPFBUTxdCwfabIr;

	private IList<TzaSquScqQuKBKfZmMDjyRhGfmGP> vepFprKAxiCaHIEACJmtUUSQOPXX;

	private IList<TzaSquScqQuKBKfZmMDjyRhGfmGP> rjefQdDWEdkXyLadxjqCvfamahEeA;

	private bool tyQrCqEQvegNlcffrOwMkhLvdMUO;

	private bool huhBeEUxCGzsbrpUSeqSJQsaRXNpA;

	private bool WdpVKQkoHJlfycdWktHLALrVKudV;

	private int bFueEYdgdroCSNRVoBFSaBbCOSxSb;

	private TimerRealTime hGMiCfiVnsFbjNfzGWzPfIsunlMT;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		JzAfbtKxCwASVKtjZrSXugCJMlLP = text;
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
		else if (ReInput.primaryInputManager.inputSource is InputSourceWrapper<KuoyRxKqdxAGSEgGhZDEQTygELlnA> { source: not null } inputSourceWrapper)
		{
			RiImwGEzLgryksoRLxZMcAAATvck = inputSourceWrapper.source;
			ReInput.primaryInputManager.SystemDeviceConnectedEvent += fMETbuWJvSMkxSEBJPpdAdARbGDW;
			ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += lzsOMpAlDaVTdmbDtGNXTjFtLYEc;
			hGMiCfiVnsFbjNfzGWzPfIsunlMT = new TimerRealTime(1.0);
			hGMiCfiVnsFbjNfzGWzPfIsunlMT.Start();
			PPVHYajegyyiBHeOCeEfwVISqOnu();
			WdpVKQkoHJlfycdWktHLALrVKudV = true;
		}
		else
		{
			Rewired.Logger.LogError("Unable to initialize Direct Input! You must add a Rewired Input Manager to the scene and set the input mode to Direct Input.");
		}
	}

	public void Update()
	{
		if (!WdpVKQkoHJlfycdWktHLALrVKudV)
		{
			return;
		}
		buIZqcLMLGSCBHddADdLhqrMOhcm = "Direct Input Joystick Element Identifier\n\n";
		JzAfbtKxCwASVKtjZrSXugCJMlLP.text = buIZqcLMLGSCBHddADdLhqrMOhcm;
		if (Input.GetKeyDown(KeyCode.A))
		{
			tyQrCqEQvegNlcffrOwMkhLvdMUO = !tyQrCqEQvegNlcffrOwMkhLvdMUO;
		}
		if (tyQrCqEQvegNlcffrOwMkhLvdMUO)
		{
			JzAfbtKxCwASVKtjZrSXugCJMlLP.text += "All Devices:\n";
			foreach (TzaSquScqQuKBKfZmMDjyRhGfmGP item in rjefQdDWEdkXyLadxjqCvfamahEeA)
			{
				Rewired.Internal.GUIText jzAfbtKxCwASVKtjZrSXugCJMlLP = JzAfbtKxCwASVKtjZrSXugCJMlLP;
				jzAfbtKxCwASVKtjZrSXugCJMlLP.text = jzAfbtKxCwASVKtjZrSXugCJMlLP.text + item.ohZDoCmVQxaTHsROXZdsVHeLPMzH + ", " + item.aPLFvXtwXsloLNQwKGpFLHdwPtyQ + ", " + new PidVid(item.NYYrpoJmrmXNddXgbOtXNRapBPrR).ToString() + ", " + item.aJjpDXKzohQTJiPsVTtMuaiGZILh + ", " + item.ccJRqzCgYjAPXCgrDoojypVxFhkTA + ", " + item.cWHHTJlxwbBqFnpPZJxJBVsoCWYF + "\n";
			}
			JzAfbtKxCwASVKtjZrSXugCJMlLP.text += "\n";
		}
		int num = wbGCxIBPLgZzEuVdzcFrrXZHEhPP;
		Guid bBoHkLsQpuXGjSPFBUTxdCwfabIr = BBoHkLsQpuXGjSPFBUTxdCwfabIr;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			wbGCxIBPLgZzEuVdzcFrrXZHEhPP++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			wbGCxIBPLgZzEuVdzcFrrXZHEhPP--;
		}
		if (hGMiCfiVnsFbjNfzGWzPfIsunlMT.Update())
		{
			int num2 = RiImwGEzLgryksoRLxZMcAAATvck.OUaaKWCEJPcSHrzTbdRQXHZfBbdkA(dDhbELSjqhcCUiWkUKZPJfEfslYO.All, LJBEmnyHDkeMvFhrEqThAoqbJbfhc.AttachedOnly);
			if (num2 != bFueEYdgdroCSNRVoBFSaBbCOSxSb)
			{
				bFueEYdgdroCSNRVoBFSaBbCOSxSb = num2;
				huhBeEUxCGzsbrpUSeqSJQsaRXNpA = true;
			}
			hGMiCfiVnsFbjNfzGWzPfIsunlMT.Start();
		}
		if (huhBeEUxCGzsbrpUSeqSJQsaRXNpA)
		{
			PPVHYajegyyiBHeOCeEfwVISqOnu();
			huhBeEUxCGzsbrpUSeqSJQsaRXNpA = false;
		}
		int num3 = ((vepFprKAxiCaHIEACJmtUUSQOPXX != null) ? vepFprKAxiCaHIEACJmtUUSQOPXX.Count : 0);
		if (num3 == 0)
		{
			return;
		}
		if (wbGCxIBPLgZzEuVdzcFrrXZHEhPP < 0)
		{
			wbGCxIBPLgZzEuVdzcFrrXZHEhPP = num3 - 1;
		}
		else if (wbGCxIBPLgZzEuVdzcFrrXZHEhPP >= num3)
		{
			wbGCxIBPLgZzEuVdzcFrrXZHEhPP = 0;
		}
		BBoHkLsQpuXGjSPFBUTxdCwfabIr = vepFprKAxiCaHIEACJmtUUSQOPXX[wbGCxIBPLgZzEuVdzcFrrXZHEhPP].UTgEnYwMzKwvhFVWmadoqnWiKGQb;
		bool flag = false;
		if (num != wbGCxIBPLgZzEuVdzcFrrXZHEhPP || bBoHkLsQpuXGjSPFBUTxdCwfabIr != BBoHkLsQpuXGjSPFBUTxdCwfabIr)
		{
			flag = true;
		}
		if (rCJaKsAexMPepwMrQdSYEBasCTuF == null || flag)
		{
			if (rCJaKsAexMPepwMrQdSYEBasCTuF != null)
			{
				rCJaKsAexMPepwMrQdSYEBasCTuF.dhLdDvddMTgCNjGzWILLRMacMuyTA();
			}
			rCJaKsAexMPepwMrQdSYEBasCTuF = new NPufsuAcvrnrrERzkxwVUAyhBNeCc(RiImwGEzLgryksoRLxZMcAAATvck, vepFprKAxiCaHIEACJmtUUSQOPXX[wbGCxIBPLgZzEuVdzcFrrXZHEhPP].UTgEnYwMzKwvhFVWmadoqnWiKGQb);
			if (rCJaKsAexMPepwMrQdSYEBasCTuF == null)
			{
				return;
			}
			IList<awcGNSLeBwuDDBpLMflzghvdBTKv> list = rCJaKsAexMPepwMrQdSYEBasCTuF.tfYomlqRRaGhMnlRGRyqOAJJTfvN();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if ((list[i].fDgfaWOhJQCmyJmQMlsgoVOPKXAeA.VLbBlajDRCKlfsUoYsvoOwmKeETSA & QuRXCgqlOlcEEHiUdqMIjqUfOWncc.Axis) != QuRXCgqlOlcEEHiUdqMIjqUfOWncc.All)
					{
						rCJaKsAexMPepwMrQdSYEBasCTuF.IAuAbQrGWvQNzOHPAVkmBeYjMOY.GXtibfRyHqeeopjuZwKGRdZVboyW = new rYjRqVoExZTJsBoxzGMqHeJLWFmy(-65535, 65535);
					}
				}
			}
			rCJaKsAexMPepwMrQdSYEBasCTuF.qHxGlnQRAsSaIJbkHgsmtVcjeViF();
		}
		zWTEmCicuAKxKkmbtygtuBfcmGGib zWTEmCicuAKxKkmbtygtuBfcmGGib2;
		try
		{
			zWTEmCicuAKxKkmbtygtuBfcmGGib2 = rCJaKsAexMPepwMrQdSYEBasCTuF.JImslblFKprIrHRNDKHnpTRgrNzs();
		}
		catch
		{
			zWTEmCicuAKxKkmbtygtuBfcmGGib2 = null;
		}
		if (zWTEmCicuAKxKkmbtygtuBfcmGGib2 == null)
		{
			return;
		}
		if (num3 > 0)
		{
			buIZqcLMLGSCBHddADdLhqrMOhcm = buIZqcLMLGSCBHddADdLhqrMOhcm + num3 + " connected devices:\n";
		}
		for (int j = 0; j < num3; j++)
		{
			buIZqcLMLGSCBHddADdLhqrMOhcm = buIZqcLMLGSCBHddADdLhqrMOhcm + vepFprKAxiCaHIEACJmtUUSQOPXX[j].ohZDoCmVQxaTHsROXZdsVHeLPMzH + "\n";
		}
		buIZqcLMLGSCBHddADdLhqrMOhcm += "\n";
		buIZqcLMLGSCBHddADdLhqrMOhcm = buIZqcLMLGSCBHddADdLhqrMOhcm + "Current DI device " + wbGCxIBPLgZzEuVdzcFrrXZHEhPP + ": " + vepFprKAxiCaHIEACJmtUUSQOPXX[wbGCxIBPLgZzEuVdzcFrrXZHEhPP].ohZDoCmVQxaTHsROXZdsVHeLPMzH + "\n";
		buIZqcLMLGSCBHddADdLhqrMOhcm += "(Press + or - to change monitored device id.)\n\n";
		wyRUZJuhpprevQEDYmBXvxppUQaF("Identifier", new PidVid(rCJaKsAexMPepwMrQdSYEBasCTuF.gUwpjDZSOdfhnCxRGfUfMygkpGmoA.NYYrpoJmrmXNddXgbOtXNRapBPrR));
		wyRUZJuhpprevQEDYmBXvxppUQaF("Instance GUID", rCJaKsAexMPepwMrQdSYEBasCTuF.gUwpjDZSOdfhnCxRGfUfMygkpGmoA.UTgEnYwMzKwvhFVWmadoqnWiKGQb);
		wyRUZJuhpprevQEDYmBXvxppUQaF("Product Id", rCJaKsAexMPepwMrQdSYEBasCTuF.IAuAbQrGWvQNzOHPAVkmBeYjMOY.tFEBVepOaIieiWoMKdBqOityhAYt);
		wyRUZJuhpprevQEDYmBXvxppUQaF("Device Type", rCJaKsAexMPepwMrQdSYEBasCTuF.geaDUjjlzHzYCxADxvyiTkUWizbp.fIOegccOCicVLevenXOIwaeUcNZY.ToString());
		buIZqcLMLGSCBHddADdLhqrMOhcm += "\n";
		wyRUZJuhpprevQEDYmBXvxppUQaF("Axis Count", rCJaKsAexMPepwMrQdSYEBasCTuF.geaDUjjlzHzYCxADxvyiTkUWizbp.BAhwYHJRoEhFvAddfVsWSJyYDAZkA);
		wyRUZJuhpprevQEDYmBXvxppUQaF("Button Count", rCJaKsAexMPepwMrQdSYEBasCTuF.geaDUjjlzHzYCxADxvyiTkUWizbp.RgbfDDRzjDqkoFkQgCKPVHBbPkbi);
		wyRUZJuhpprevQEDYmBXvxppUQaF("Hat Count", rCJaKsAexMPepwMrQdSYEBasCTuF.geaDUjjlzHzYCxADxvyiTkUWizbp.kMdMoqAgCOwzqEvNitrDQjsgbCxe);
		buIZqcLMLGSCBHddADdLhqrMOhcm += "\n";
		if (flag)
		{
			Rewired.Logger.Log("Device Name: \"" + vepFprKAxiCaHIEACJmtUUSQOPXX[wbGCxIBPLgZzEuVdzcFrrXZHEhPP].ohZDoCmVQxaTHsROXZdsVHeLPMzH + "\"");
			Rewired.Logger.Log("Identifier: " + new PidVid(rCJaKsAexMPepwMrQdSYEBasCTuF.gUwpjDZSOdfhnCxRGfUfMygkpGmoA.NYYrpoJmrmXNddXgbOtXNRapBPrR).ToString());
		}
		for (int k = 0; k < 32; k++)
		{
			int num4 = gtExFxcpYcZTABrBeLFEPTMTniaw((DirectInputAxis)k, zWTEmCicuAKxKkmbtygtuBfcmGGib2);
			DirectInputAxis directInputAxis = (DirectInputAxis)k;
			string text = directInputAxis.ToString();
			wyRUZJuhpprevQEDYmBXvxppUQaF(text, num4 + " (" + ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(num4) + ")");
		}
		int[] array = zWTEmCicuAKxKkmbtygtuBfcmGGib2.QgGjYkmIgymqIEEWGNpCPiRHlTJ;
		for (int l = 0; l < 4; l++)
		{
			int num5 = array[l];
			string text2 = "Hat " + l;
			wyRUZJuhpprevQEDYmBXvxppUQaF(text2, num5);
		}
		bool[] array2 = zWTEmCicuAKxKkmbtygtuBfcmGGib2.cSTdYhCfOIlkyjUlxiceJHSyagLSA;
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
		wyRUZJuhpprevQEDYmBXvxppUQaF("Buttons ", text3);
		JzAfbtKxCwASVKtjZrSXugCJMlLP.text = buIZqcLMLGSCBHddADdLhqrMOhcm;
	}

	private void PPVHYajegyyiBHeOCeEfwVISqOnu()
	{
		vepFprKAxiCaHIEACJmtUUSQOPXX = RiImwGEzLgryksoRLxZMcAAATvck.XglCxuhEeHOHNPhBEpaixSIvFGFH(dDhbELSjqhcCUiWkUKZPJfEfslYO.GameControl, LJBEmnyHDkeMvFhrEqThAoqbJbfhc.AttachedOnly);
		rjefQdDWEdkXyLadxjqCvfamahEeA = RiImwGEzLgryksoRLxZMcAAATvck.XglCxuhEeHOHNPhBEpaixSIvFGFH(dDhbELSjqhcCUiWkUKZPJfEfslYO.All, LJBEmnyHDkeMvFhrEqThAoqbJbfhc.AttachedOnly);
		bFueEYdgdroCSNRVoBFSaBbCOSxSb = ((rjefQdDWEdkXyLadxjqCvfamahEeA != null) ? rjefQdDWEdkXyLadxjqCvfamahEeA.Count : 0);
	}

	private void fMETbuWJvSMkxSEBJPpdAdARbGDW()
	{
		dcVdxJdzxMZSZROeXTVCUmflVKQLA();
	}

	private void lzsOMpAlDaVTdmbDtGNXTjFtLYEc()
	{
		dcVdxJdzxMZSZROeXTVCUmflVKQLA();
	}

	private void dcVdxJdzxMZSZROeXTVCUmflVKQLA()
	{
		PNnwosyJbZAkbwObisgdtMytZJol();
		huhBeEUxCGzsbrpUSeqSJQsaRXNpA = true;
	}

	private void PNnwosyJbZAkbwObisgdtMytZJol()
	{
		wbGCxIBPLgZzEuVdzcFrrXZHEhPP = 0;
		rCJaKsAexMPepwMrQdSYEBasCTuF = null;
		BBoHkLsQpuXGjSPFBUTxdCwfabIr = Guid.Empty;
		vepFprKAxiCaHIEACJmtUUSQOPXX = null;
		rjefQdDWEdkXyLadxjqCvfamahEeA = null;
		tyQrCqEQvegNlcffrOwMkhLvdMUO = false;
		huhBeEUxCGzsbrpUSeqSJQsaRXNpA = false;
		bFueEYdgdroCSNRVoBFSaBbCOSxSb = 0;
	}

	private void wyRUZJuhpprevQEDYmBXvxppUQaF(string P_0, object P_1)
	{
		buIZqcLMLGSCBHddADdLhqrMOhcm = buIZqcLMLGSCBHddADdLhqrMOhcm + P_0 + " = " + P_1.ToString() + "\n";
	}

	private int gtExFxcpYcZTABrBeLFEPTMTniaw(DirectInputAxis P_0, zWTEmCicuAKxKkmbtygtuBfcmGGib P_1)
	{
		return P_0 switch
		{
			DirectInputAxis.X => P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, 
			DirectInputAxis.Y => P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA, 
			DirectInputAxis.Z => P_1.vmuQckHIsdYcQHmrIqHKUcokekox, 
			DirectInputAxis.RotationX => P_1.wMdGboVhDBarTiKoLKOjWBHjoyqWA, 
			DirectInputAxis.RotationY => P_1.jxokepaipAiqiVsGIzkhgPyCZDNq, 
			DirectInputAxis.RotationZ => P_1.iftKowlYbHRMbPxhyzhMsXAdCGug, 
			DirectInputAxis.Slider0 => P_1.WjfkewtPxCltNPMtrEljvfKtFRfT[0], 
			DirectInputAxis.Slider1 => P_1.WjfkewtPxCltNPMtrEljvfKtFRfT[1], 
			DirectInputAxis.VelocityX => P_1.SFmlySFIEsRNzPDiWZXTAhhvohbG, 
			DirectInputAxis.VelocityY => P_1.TjADOULJTdcCQeIEymZFJEIPPeHM, 
			DirectInputAxis.VelocityZ => P_1.qGDsEtUpIdFmdgyGbEKXtNnucyiv, 
			DirectInputAxis.AngularVelocityX => P_1.KTZEXWgfRGCdYijECToXTmvYPMDr, 
			DirectInputAxis.AngularVelocityY => P_1.gpfLBcYvlqBFcBmgkCrFzqiDEqcgA, 
			DirectInputAxis.AngularVelocityZ => P_1.NvFBGhnQqjTFqBGAIEbLfqZAZhxnA, 
			DirectInputAxis.VelocitySlider0 => P_1.hktMoEskItpMSsfoHJvIMKApJQZh[0], 
			DirectInputAxis.VelocitySlider1 => P_1.hktMoEskItpMSsfoHJvIMKApJQZh[1], 
			DirectInputAxis.AccelerationX => P_1.idObMaJUsqabskBIGBaGJRAfYEiC, 
			DirectInputAxis.AccelerationY => P_1.EoRWrjXiKbuBqXLDrSoRbkWSitZp, 
			DirectInputAxis.AccelerationZ => P_1.xQLztSqylcBifgjBydHnuzBajPoK, 
			DirectInputAxis.AngularAccelerationX => P_1.iDPXBljKNZIKgcwWtxojcaZUjqAM, 
			DirectInputAxis.AngularAccelerationY => P_1.UHizTcGyhQWKnFcrKeGokOyvvJvIA, 
			DirectInputAxis.AngularAccelerationZ => P_1.zxRdRcmiAqTQZAIBSMawPlnCIwc, 
			DirectInputAxis.AccelerationSlider0 => P_1.pZAQseQHCUijFFatyvPWieLlQzQI[0], 
			DirectInputAxis.AccelerationSlider1 => P_1.pZAQseQHCUijFFatyvPWieLlQzQI[1], 
			DirectInputAxis.ForceX => P_1.rvKzOwbLlHySTQIFyUPUxNgzhxVCA, 
			DirectInputAxis.ForceY => P_1.vmbaIskOICHYOJhiiIAlSIWqyyWQ, 
			DirectInputAxis.ForceZ => P_1.wxMTSkNjaXwUGpncSRpxTLXoFziBA, 
			DirectInputAxis.TorqueX => P_1.bmrbkGBPilfHOQJBnpwrbtPfAjwXB, 
			DirectInputAxis.TorqueY => P_1.reCUHqxZEspcgAWzobAnyMgRBQwjA, 
			DirectInputAxis.TorqueZ => P_1.WIEcQbJFuagIBjGfmcPakCeAFitP, 
			DirectInputAxis.ForceSlider0 => P_1.xvFSjAKRKUvtKDIaufPQgwmrjpelA[0], 
			DirectInputAxis.ForceSlider1 => P_1.xvFSjAKRKUvtKDIaufPQgwmrjpelA[1], 
			_ => 0, 
		};
	}

	private float ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}

	public void OnDestroy()
	{
		if (rCJaKsAexMPepwMrQdSYEBasCTuF != null)
		{
			rCJaKsAexMPepwMrQdSYEBasCTuF.dhLdDvddMTgCNjGzWILLRMacMuyTA();
		}
	}
}
