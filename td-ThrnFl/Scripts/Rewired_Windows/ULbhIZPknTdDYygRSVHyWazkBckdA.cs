using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal sealed class ULbhIZPknTdDYygRSVHyWazkBckdA : IElementIdentifierTool
{
	private Rewired.Internal.GUIText NWCMohVgPAaCKKezIohzuDZElWVPA;

	private string kUfIHzohzDNRSLjZbZruHeEvfSPeA;

	private int BomaOCmdkLdABTcUeDFRbNZWJGiv;

	private EDFdvGfovhQrLKAgmMSedZFXctJPA nEMlbxZnFWjSqrhVGaIZrpvjoJfj;

	private DiJVETKbnrpIufzFejttIwRifnEK bUqgrjORPgrSuaVtKPvIjAEjOgcL;

	private Guid rEsZItsrbkHszrlaESQsrwrVBvpn;

	private IList<TtTEWPAmgCXtCiwlxHCRLqWtUGyz> YbccsgZRiuDdiihdUhHiAFUnPqJMA;

	private IList<TtTEWPAmgCXtCiwlxHCRLqWtUGyz> AsFAogcogpTxdOdmOiusaAiGmRfCA;

	private bool PVAFdYYDYabmSNxDeWpQiRExmQDx;

	private bool HIWgzMavKoZBODeGVrmEsdADfgXJA;

	private bool DSJywuxFNGeCRDBnSkHSAJlOLHbr;

	private int txdSXZGAUMQNanmFihbTeykwhQmD;

	private TimerRealTime JYGUcFUEYZzYuvurtgYNaHPUQfiv;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		NWCMohVgPAaCKKezIohzuDZElWVPA = text;
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
		else if (ReInput.primaryInputManager.inputSource is InputSourceWrapper<EDFdvGfovhQrLKAgmMSedZFXctJPA> { source: not null } inputSourceWrapper)
		{
			nEMlbxZnFWjSqrhVGaIZrpvjoJfj = inputSourceWrapper.source;
			ReInput.primaryInputManager.SystemDeviceConnectedEvent += lEckmaMNdPXNfGfEpWOyzzRHWczB;
			ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += pXzdbgXKfLjlrrlwjyqPqJIlaCXaA;
			JYGUcFUEYZzYuvurtgYNaHPUQfiv = new TimerRealTime(1.0);
			JYGUcFUEYZzYuvurtgYNaHPUQfiv.Start();
			vInpPmGmuDIWthiqobCTJXqVHChG();
			DSJywuxFNGeCRDBnSkHSAJlOLHbr = true;
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
		if (!DSJywuxFNGeCRDBnSkHSAJlOLHbr)
		{
			return;
		}
		kUfIHzohzDNRSLjZbZruHeEvfSPeA = "Direct Input Joystick Element Identifier\n\n";
		NWCMohVgPAaCKKezIohzuDZElWVPA.text = kUfIHzohzDNRSLjZbZruHeEvfSPeA;
		if (Input.GetKeyDown(KeyCode.A))
		{
			PVAFdYYDYabmSNxDeWpQiRExmQDx = !PVAFdYYDYabmSNxDeWpQiRExmQDx;
		}
		if (PVAFdYYDYabmSNxDeWpQiRExmQDx)
		{
			NWCMohVgPAaCKKezIohzuDZElWVPA.text += "All Devices:\n";
			foreach (TtTEWPAmgCXtCiwlxHCRLqWtUGyz item in AsFAogcogpTxdOdmOiusaAiGmRfCA)
			{
				Rewired.Internal.GUIText nWCMohVgPAaCKKezIohzuDZElWVPA = NWCMohVgPAaCKKezIohzuDZElWVPA;
				nWCMohVgPAaCKKezIohzuDZElWVPA.text = nWCMohVgPAaCKKezIohzuDZElWVPA.text + item.QidLEIgLoaLuSNjoxjFLWLcoNNFF + ", " + item.ylHjzqkgNSOFAzGfoHRYibnwDDhab + ", " + new PidVid(item.ZRPrStnqNFGUgSDUzouORCQogvNA).ToString() + ", " + item.iBUPBcpskyYswytxvkDABVtnRjnA + ", " + item.tlLiCdvUDwpUriSsqPpjrnRYxiTO + ", " + item.RNyjNMgXUiBDyPozxjmMcRrjoysk + "\n";
			}
			NWCMohVgPAaCKKezIohzuDZElWVPA.text += "\n";
		}
		int bomaOCmdkLdABTcUeDFRbNZWJGiv = BomaOCmdkLdABTcUeDFRbNZWJGiv;
		Guid guid = rEsZItsrbkHszrlaESQsrwrVBvpn;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			BomaOCmdkLdABTcUeDFRbNZWJGiv++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			BomaOCmdkLdABTcUeDFRbNZWJGiv--;
		}
		if (JYGUcFUEYZzYuvurtgYNaHPUQfiv.Update())
		{
			int num = nEMlbxZnFWjSqrhVGaIZrpvjoJfj.pLNNpvznVdGOlAGOcGGpDudxdVeHA(ruYRpisEghgnBUWQDMCzFKdYMDaM.All, VruoKSWLPeRfmJpNHaCJctBwRVFp.AttachedOnly);
			if (num != txdSXZGAUMQNanmFihbTeykwhQmD)
			{
				txdSXZGAUMQNanmFihbTeykwhQmD = num;
				HIWgzMavKoZBODeGVrmEsdADfgXJA = true;
			}
			JYGUcFUEYZzYuvurtgYNaHPUQfiv.Start();
		}
		if (HIWgzMavKoZBODeGVrmEsdADfgXJA)
		{
			vInpPmGmuDIWthiqobCTJXqVHChG();
			HIWgzMavKoZBODeGVrmEsdADfgXJA = false;
		}
		int num2 = ((YbccsgZRiuDdiihdUhHiAFUnPqJMA != null) ? YbccsgZRiuDdiihdUhHiAFUnPqJMA.Count : 0);
		if (num2 == 0)
		{
			return;
		}
		if (BomaOCmdkLdABTcUeDFRbNZWJGiv < 0)
		{
			BomaOCmdkLdABTcUeDFRbNZWJGiv = num2 - 1;
		}
		else if (BomaOCmdkLdABTcUeDFRbNZWJGiv >= num2)
		{
			BomaOCmdkLdABTcUeDFRbNZWJGiv = 0;
		}
		rEsZItsrbkHszrlaESQsrwrVBvpn = YbccsgZRiuDdiihdUhHiAFUnPqJMA[BomaOCmdkLdABTcUeDFRbNZWJGiv].tLUoFBXwbtDPnYjcetOHmmDLIghT;
		bool flag = false;
		if (bomaOCmdkLdABTcUeDFRbNZWJGiv != BomaOCmdkLdABTcUeDFRbNZWJGiv || guid != rEsZItsrbkHszrlaESQsrwrVBvpn)
		{
			flag = true;
		}
		if (bUqgrjORPgrSuaVtKPvIjAEjOgcL == null || flag)
		{
			if (bUqgrjORPgrSuaVtKPvIjAEjOgcL != null)
			{
				bUqgrjORPgrSuaVtKPvIjAEjOgcL.VmaqNrYBgZEfmTiwaupLiygsIZLf();
			}
			bUqgrjORPgrSuaVtKPvIjAEjOgcL = new DiJVETKbnrpIufzFejttIwRifnEK(nEMlbxZnFWjSqrhVGaIZrpvjoJfj, YbccsgZRiuDdiihdUhHiAFUnPqJMA[BomaOCmdkLdABTcUeDFRbNZWJGiv].tLUoFBXwbtDPnYjcetOHmmDLIghT);
			if (bUqgrjORPgrSuaVtKPvIjAEjOgcL == null)
			{
				return;
			}
			IList<agXldjjcDkpqUxQdFPyLgCAMtRsl> list = bUqgrjORPgrSuaVtKPvIjAEjOgcL.XKQlsWmfuDhJyeSampHQJsgQANK();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if ((list[i].KSbjVyCcpaougzdqlecPRwfRNJhS.UWpOyWLwHKPlYFYBrpyIxICBRkrM & SBgCiXgUYzMrBAKimxFgjcthAaBfb.Axis) != SBgCiXgUYzMrBAKimxFgjcthAaBfb.All)
					{
						bUqgrjORPgrSuaVtKPvIjAEjOgcL.WpkGQjixRyPHkhsmQcvmwSYOeJHr.FbdBqJuPwzsMSjzjHUfGFgKPIUSY = new doKHYmOpzFAsttGDulJYTWiuFxQt(-65535, 65535);
					}
				}
			}
			bUqgrjORPgrSuaVtKPvIjAEjOgcL.sJEXKhTDzjFmWWXehgEkbpPDPJQA();
		}
		ppyUYlIAyEDIFFGNqqfLGHCTQykdb ppyUYlIAyEDIFFGNqqfLGHCTQykdb2;
		try
		{
			ppyUYlIAyEDIFFGNqqfLGHCTQykdb2 = bUqgrjORPgrSuaVtKPvIjAEjOgcL.rBuZwhkQTAYoGaJYUIVpTvXmsSRh();
		}
		catch
		{
			ppyUYlIAyEDIFFGNqqfLGHCTQykdb2 = null;
		}
		if (ppyUYlIAyEDIFFGNqqfLGHCTQykdb2 == null)
		{
			return;
		}
		if (num2 > 0)
		{
			kUfIHzohzDNRSLjZbZruHeEvfSPeA = kUfIHzohzDNRSLjZbZruHeEvfSPeA + num2 + " connected devices:\n";
		}
		for (int j = 0; j < num2; j++)
		{
			kUfIHzohzDNRSLjZbZruHeEvfSPeA = kUfIHzohzDNRSLjZbZruHeEvfSPeA + YbccsgZRiuDdiihdUhHiAFUnPqJMA[j].QidLEIgLoaLuSNjoxjFLWLcoNNFF + "\n";
		}
		kUfIHzohzDNRSLjZbZruHeEvfSPeA += "\n";
		kUfIHzohzDNRSLjZbZruHeEvfSPeA = kUfIHzohzDNRSLjZbZruHeEvfSPeA + "Current DI device " + BomaOCmdkLdABTcUeDFRbNZWJGiv + ": " + YbccsgZRiuDdiihdUhHiAFUnPqJMA[BomaOCmdkLdABTcUeDFRbNZWJGiv].QidLEIgLoaLuSNjoxjFLWLcoNNFF + "\n";
		kUfIHzohzDNRSLjZbZruHeEvfSPeA += "(Press + or - to change monitored device id.)\n\n";
		TzQUmUyqxmxPzgUMjinFpPQNHeDW("Identifier", new PidVid(bUqgrjORPgrSuaVtKPvIjAEjOgcL.AOrVrFnqKcbZlZfZNeCcJQIpMABf.ZRPrStnqNFGUgSDUzouORCQogvNA));
		TzQUmUyqxmxPzgUMjinFpPQNHeDW("Instance GUID", bUqgrjORPgrSuaVtKPvIjAEjOgcL.AOrVrFnqKcbZlZfZNeCcJQIpMABf.tLUoFBXwbtDPnYjcetOHmmDLIghT);
		TzQUmUyqxmxPzgUMjinFpPQNHeDW("Product Id", bUqgrjORPgrSuaVtKPvIjAEjOgcL.WpkGQjixRyPHkhsmQcvmwSYOeJHr.qiORUvXtBOJJIANnzdWeEoyAlZsd);
		TzQUmUyqxmxPzgUMjinFpPQNHeDW("Device Type", bUqgrjORPgrSuaVtKPvIjAEjOgcL.ayiHuvHMyVEmPiMCbctPWGfezqmE.mHeDShJPddSHcsNwMRzVjfNKNHNT.ToString());
		kUfIHzohzDNRSLjZbZruHeEvfSPeA += "\n";
		TzQUmUyqxmxPzgUMjinFpPQNHeDW("Axis Count", bUqgrjORPgrSuaVtKPvIjAEjOgcL.ayiHuvHMyVEmPiMCbctPWGfezqmE.fpMgJMdSfAnvhgmdsAtVcYshLYWKc);
		TzQUmUyqxmxPzgUMjinFpPQNHeDW("Button Count", bUqgrjORPgrSuaVtKPvIjAEjOgcL.ayiHuvHMyVEmPiMCbctPWGfezqmE.rBMrmVqLlmcCwyghsLRupBaRlCgP);
		TzQUmUyqxmxPzgUMjinFpPQNHeDW("Hat Count", bUqgrjORPgrSuaVtKPvIjAEjOgcL.ayiHuvHMyVEmPiMCbctPWGfezqmE.WjLAuaXmjSjgxfsuAKElCtaGUCkD);
		kUfIHzohzDNRSLjZbZruHeEvfSPeA += "\n";
		if (flag)
		{
			Rewired.Logger.Log("Device Name: \"" + YbccsgZRiuDdiihdUhHiAFUnPqJMA[BomaOCmdkLdABTcUeDFRbNZWJGiv].QidLEIgLoaLuSNjoxjFLWLcoNNFF + "\"");
			Rewired.Logger.Log("Identifier: " + new PidVid(bUqgrjORPgrSuaVtKPvIjAEjOgcL.AOrVrFnqKcbZlZfZNeCcJQIpMABf.ZRPrStnqNFGUgSDUzouORCQogvNA).ToString());
		}
		for (int k = 0; k < 32; k++)
		{
			int num3 = kOXajcYaFrUTMKvuSEzDZRLaqJtb((DirectInputAxis)k, ppyUYlIAyEDIFFGNqqfLGHCTQykdb2);
			DirectInputAxis directInputAxis = (DirectInputAxis)k;
			string text = directInputAxis.ToString();
			TzQUmUyqxmxPzgUMjinFpPQNHeDW(text, num3 + " (" + jvxyDTUrwnzuufRqeyiZRNUJLMiK(num3) + ")");
		}
		int[] array = ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.zwwYiEDefXbIjMelwAAjSwmyIsxF;
		for (int l = 0; l < 4; l++)
		{
			int num4 = array[l];
			string text2 = "Hat " + l;
			TzQUmUyqxmxPzgUMjinFpPQNHeDW(text2, num4);
		}
		bool[] array2 = ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.XbQZoaMPpaDKKEtGcyekRldbtHpV;
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
		TzQUmUyqxmxPzgUMjinFpPQNHeDW("Buttons ", text3);
		NWCMohVgPAaCKKezIohzuDZElWVPA.text = kUfIHzohzDNRSLjZbZruHeEvfSPeA;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	private void vInpPmGmuDIWthiqobCTJXqVHChG()
	{
		YbccsgZRiuDdiihdUhHiAFUnPqJMA = nEMlbxZnFWjSqrhVGaIZrpvjoJfj.vidXVffTImmFJHJCUkFTqKzQCfkL(ruYRpisEghgnBUWQDMCzFKdYMDaM.GameControl, VruoKSWLPeRfmJpNHaCJctBwRVFp.AttachedOnly);
		AsFAogcogpTxdOdmOiusaAiGmRfCA = nEMlbxZnFWjSqrhVGaIZrpvjoJfj.vidXVffTImmFJHJCUkFTqKzQCfkL(ruYRpisEghgnBUWQDMCzFKdYMDaM.All, VruoKSWLPeRfmJpNHaCJctBwRVFp.AttachedOnly);
		txdSXZGAUMQNanmFihbTeykwhQmD = ((AsFAogcogpTxdOdmOiusaAiGmRfCA != null) ? AsFAogcogpTxdOdmOiusaAiGmRfCA.Count : 0);
	}

	private void lEckmaMNdPXNfGfEpWOyzzRHWczB()
	{
		BNmsOnlTxFHIDrwhiKmfwIDweTG();
	}

	private void pXzdbgXKfLjlrrlwjyqPqJIlaCXaA()
	{
		BNmsOnlTxFHIDrwhiKmfwIDweTG();
	}

	private void BNmsOnlTxFHIDrwhiKmfwIDweTG()
	{
		dTArIGtEKemiSpKrGyebXNBLPHPV();
		HIWgzMavKoZBODeGVrmEsdADfgXJA = true;
	}

	private void dTArIGtEKemiSpKrGyebXNBLPHPV()
	{
		BomaOCmdkLdABTcUeDFRbNZWJGiv = 0;
		bUqgrjORPgrSuaVtKPvIjAEjOgcL = null;
		rEsZItsrbkHszrlaESQsrwrVBvpn = Guid.Empty;
		YbccsgZRiuDdiihdUhHiAFUnPqJMA = null;
		AsFAogcogpTxdOdmOiusaAiGmRfCA = null;
		PVAFdYYDYabmSNxDeWpQiRExmQDx = false;
		HIWgzMavKoZBODeGVrmEsdADfgXJA = false;
		txdSXZGAUMQNanmFihbTeykwhQmD = 0;
	}

	private void TzQUmUyqxmxPzgUMjinFpPQNHeDW(string P_0, object P_1)
	{
		kUfIHzohzDNRSLjZbZruHeEvfSPeA = kUfIHzohzDNRSLjZbZruHeEvfSPeA + P_0 + " = " + P_1.ToString() + "\n";
	}

	private int kOXajcYaFrUTMKvuSEzDZRLaqJtb(DirectInputAxis P_0, ppyUYlIAyEDIFFGNqqfLGHCTQykdb P_1)
	{
		return P_0 switch
		{
			DirectInputAxis.X => P_1.djmmitcMmZoJbPYrYVFybvKddNnR, 
			DirectInputAxis.Y => P_1.UnlvwUIYvgwemCBLyHITrxWZGDaN, 
			DirectInputAxis.Z => P_1.XQfZcygjntbsSSRQJjLcoGttavMb, 
			DirectInputAxis.RotationX => P_1.FZPurDPxWjTJzDEnBUkGUkiiGSzo, 
			DirectInputAxis.RotationY => P_1.XEIsOXPlOCUSXoGHByInlDjNfXMZ, 
			DirectInputAxis.RotationZ => P_1.CEcCyLXzQxfpKAAyIfINnhuleVNH, 
			DirectInputAxis.Slider0 => P_1.xhGRoDOrzInljAMDeuDNTcmdrbPp[0], 
			DirectInputAxis.Slider1 => P_1.xhGRoDOrzInljAMDeuDNTcmdrbPp[1], 
			DirectInputAxis.VelocityX => P_1.IirdBwKSGHhNjnnGGCnZFWewEqLo, 
			DirectInputAxis.VelocityY => P_1.cxXgqcBmcfknsEIcDQlLgaLqUCNKb, 
			DirectInputAxis.VelocityZ => P_1.tXXcsgMqIWhWKawKFOqCmyjZumzh, 
			DirectInputAxis.AngularVelocityX => P_1.aRGLlfdbSzisEjBDFdwplMqvrfoj, 
			DirectInputAxis.AngularVelocityY => P_1.tVLbQpHggEGgBDBXvecwpAbuQTjO, 
			DirectInputAxis.AngularVelocityZ => P_1.ctOnaunvrcqmwuTOLyJEoaYAYqzj, 
			DirectInputAxis.VelocitySlider0 => P_1.sukgxNMGEtSDFMtxkRfANBooWpjr[0], 
			DirectInputAxis.VelocitySlider1 => P_1.sukgxNMGEtSDFMtxkRfANBooWpjr[1], 
			DirectInputAxis.AccelerationX => P_1.kOmObIdJdSnMIqyRiDjPNljJWXGR, 
			DirectInputAxis.AccelerationY => P_1.dfbWWpHBxdSqDLEwywRnoHWhwhFR, 
			DirectInputAxis.AccelerationZ => P_1.nLegDadVzYooxORbUifrckVhZgqFB, 
			DirectInputAxis.AngularAccelerationX => P_1.mkUVInqZAIkZVetBpHcINFuFbaOL, 
			DirectInputAxis.AngularAccelerationY => P_1.jlrsXxSiyalTuuwoCkbTBdWPAEon, 
			DirectInputAxis.AngularAccelerationZ => P_1.bQFoAiSsgktHmcWWNdepXkhIKqgt, 
			DirectInputAxis.AccelerationSlider0 => P_1.WcXRbpMJwwdWoHunYoCOSjzBFdrcb[0], 
			DirectInputAxis.AccelerationSlider1 => P_1.WcXRbpMJwwdWoHunYoCOSjzBFdrcb[1], 
			DirectInputAxis.ForceX => P_1.GaixrBoNhNKdHQrryOkmbPyjwaws, 
			DirectInputAxis.ForceY => P_1.mEzautgCFQVUtkvPkTEcImvrtGffA, 
			DirectInputAxis.ForceZ => P_1.WjTyPuBJQGheHPdHNmBrKNzKagUZ, 
			DirectInputAxis.TorqueX => P_1.jvKYSwqbxuDHYekbFwzGNQliclHXA, 
			DirectInputAxis.TorqueY => P_1.YNkwuyhSVXHQFQoPsmRkxLBiXUqe, 
			DirectInputAxis.TorqueZ => P_1.WrsrVcMOnZdoViEDrmmXlnNwJBqdA, 
			DirectInputAxis.ForceSlider0 => P_1.BBrXCczdJNTGAnmqOJdqPOcjIYBX[0], 
			DirectInputAxis.ForceSlider1 => P_1.BBrXCczdJNTGAnmqOJdqPOcjIYBX[1], 
			_ => 0, 
		};
	}

	private float jvxyDTUrwnzuufRqeyiZRNUJLMiK(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}

	public void OnDestroy()
	{
		if (bUqgrjORPgrSuaVtKPvIjAEjOgcL != null)
		{
			bUqgrjORPgrSuaVtKPvIjAEjOgcL.VmaqNrYBgZEfmTiwaupLiygsIZLf();
		}
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}
}
