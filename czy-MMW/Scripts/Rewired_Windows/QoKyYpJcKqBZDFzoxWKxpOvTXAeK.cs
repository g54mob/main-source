using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal sealed class QoKyYpJcKqBZDFzoxWKxpOvTXAeK : IElementIdentifierTool
{
	private GUIText NunDcXgVktLCBUJAtpumXqRvIbROA;

	private string uGOUBJoRAcRNVkjuEnknawACluZL;

	private int DkFagkgqHeGdWonlDISMMlFrGjibA;

	private SBstrsiLWYqpWzQLDLNlmFTmzMXs rdtfePTcUfnRvWiundMCKtUIFopC;

	private TVmjOvMzQEcAxIasZNmofQFDPCSt pUNSxZOhmJavrRHOnPINGDQEOvgM;

	private Guid fzRDYVkVATiumWRFrTgfCjfsIWdw;

	private IList<NmeNOpqJNpvsXZGMMFZCJOCAUrey> EKVyNADXjJzrbDGErUmziCdWDdRC;

	private IList<NmeNOpqJNpvsXZGMMFZCJOCAUrey> UTmqTEiDXYxawnTtzlpvjuHzkpfC;

	private bool JnxPqdMdjRkTeemTJmHsLCMGtPgc;

	private bool ZGhMvkmPrLCJVgfnwwzZBiEuHtXJ;

	private bool ZRqgKMjqHzsSWkScvCNFxlbpkahD;

	private int zjUCChIxhvUgIAAXPeiAPBiLdIuT;

	private TimerRealTime DBtnifCVdeoKrYjGUgHSDRTpQrwJ;

	public void Initialize(GUIText text)
	{
		NunDcXgVktLCBUJAtpumXqRvIbROA = text;
	}

	void IElementIdentifierTool.Initialize(GUIText text)
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
		else if (ReInput.primaryInputManager.inputSource is InputSourceWrapper<SBstrsiLWYqpWzQLDLNlmFTmzMXs> { source: not null } inputSourceWrapper)
		{
			rdtfePTcUfnRvWiundMCKtUIFopC = inputSourceWrapper.source;
			ReInput.primaryInputManager.SystemDeviceConnectedEvent += txfesCUreGViEzBIQaFJSMtedvaP;
			ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += jBKnhMFKIwhPyUaHGchOXOGYvnFW;
			DBtnifCVdeoKrYjGUgHSDRTpQrwJ = new TimerRealTime(1.0);
			DBtnifCVdeoKrYjGUgHSDRTpQrwJ.Start();
			lAUBnYAIHkHIsgKLNRiCaTHqBwrgA();
			ZRqgKMjqHzsSWkScvCNFxlbpkahD = true;
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
		if (!ZRqgKMjqHzsSWkScvCNFxlbpkahD)
		{
			return;
		}
		uGOUBJoRAcRNVkjuEnknawACluZL = "Direct Input Joystick Element Identifier\n\n";
		NunDcXgVktLCBUJAtpumXqRvIbROA.text = uGOUBJoRAcRNVkjuEnknawACluZL;
		if (Input.GetKeyDown(KeyCode.A))
		{
			JnxPqdMdjRkTeemTJmHsLCMGtPgc = !JnxPqdMdjRkTeemTJmHsLCMGtPgc;
		}
		if (JnxPqdMdjRkTeemTJmHsLCMGtPgc)
		{
			NunDcXgVktLCBUJAtpumXqRvIbROA.text += "All Devices:\n";
			foreach (NmeNOpqJNpvsXZGMMFZCJOCAUrey item in UTmqTEiDXYxawnTtzlpvjuHzkpfC)
			{
				GUIText nunDcXgVktLCBUJAtpumXqRvIbROA = NunDcXgVktLCBUJAtpumXqRvIbROA;
				nunDcXgVktLCBUJAtpumXqRvIbROA.text = nunDcXgVktLCBUJAtpumXqRvIbROA.text + item.CcIThwmTsDNNPaZoGiiOvJkXqSXj + ", " + item.sryvpQkQoxNHFMVUBQEPWqvZOebV + ", " + new PidVid(item.XzcjuqdPVmKDLdysprgdoAWdbHpv).ToString() + ", " + item.cviBAjbzRNEAzDEGGFtAcJDSLwtU + ", " + item.lSyzIDnfyTyMkDuDNniwYINrQFJv + ", " + item.PNNVHweFrVOZhuGGCEdTBHdUIHmX + "\n";
			}
			NunDcXgVktLCBUJAtpumXqRvIbROA.text += "\n";
		}
		int dkFagkgqHeGdWonlDISMMlFrGjibA = DkFagkgqHeGdWonlDISMMlFrGjibA;
		Guid guid = fzRDYVkVATiumWRFrTgfCjfsIWdw;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			DkFagkgqHeGdWonlDISMMlFrGjibA++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			DkFagkgqHeGdWonlDISMMlFrGjibA--;
		}
		if (DBtnifCVdeoKrYjGUgHSDRTpQrwJ.Update())
		{
			int num = rdtfePTcUfnRvWiundMCKtUIFopC.rTafxJabeGPEmcdtfTJoAqbeQuIyC(hppHiYuBLSrbOpyrsLdssPhrgBgl.All, ZWJASgfSgFZfrrcyiiPYhRZfDwHYB.AttachedOnly);
			if (num != zjUCChIxhvUgIAAXPeiAPBiLdIuT)
			{
				zjUCChIxhvUgIAAXPeiAPBiLdIuT = num;
				ZGhMvkmPrLCJVgfnwwzZBiEuHtXJ = true;
			}
			DBtnifCVdeoKrYjGUgHSDRTpQrwJ.Start();
		}
		if (ZGhMvkmPrLCJVgfnwwzZBiEuHtXJ)
		{
			lAUBnYAIHkHIsgKLNRiCaTHqBwrgA();
			ZGhMvkmPrLCJVgfnwwzZBiEuHtXJ = false;
		}
		int num2 = ((EKVyNADXjJzrbDGErUmziCdWDdRC != null) ? EKVyNADXjJzrbDGErUmziCdWDdRC.Count : 0);
		if (num2 == 0)
		{
			return;
		}
		if (DkFagkgqHeGdWonlDISMMlFrGjibA < 0)
		{
			DkFagkgqHeGdWonlDISMMlFrGjibA = num2 - 1;
		}
		else if (DkFagkgqHeGdWonlDISMMlFrGjibA >= num2)
		{
			DkFagkgqHeGdWonlDISMMlFrGjibA = 0;
		}
		fzRDYVkVATiumWRFrTgfCjfsIWdw = EKVyNADXjJzrbDGErUmziCdWDdRC[DkFagkgqHeGdWonlDISMMlFrGjibA].fTfFNbdDSSLPqvlVRRFMhJFkkRjdb;
		bool flag = false;
		if (dkFagkgqHeGdWonlDISMMlFrGjibA != DkFagkgqHeGdWonlDISMMlFrGjibA || guid != fzRDYVkVATiumWRFrTgfCjfsIWdw)
		{
			flag = true;
		}
		if (pUNSxZOhmJavrRHOnPINGDQEOvgM == null || flag)
		{
			if (pUNSxZOhmJavrRHOnPINGDQEOvgM != null)
			{
				pUNSxZOhmJavrRHOnPINGDQEOvgM.DnPkULQcHkJOjeTDBFfGVUqFIbFS();
			}
			pUNSxZOhmJavrRHOnPINGDQEOvgM = new TVmjOvMzQEcAxIasZNmofQFDPCSt(rdtfePTcUfnRvWiundMCKtUIFopC, EKVyNADXjJzrbDGErUmziCdWDdRC[DkFagkgqHeGdWonlDISMMlFrGjibA].fTfFNbdDSSLPqvlVRRFMhJFkkRjdb);
			if (pUNSxZOhmJavrRHOnPINGDQEOvgM == null)
			{
				return;
			}
			IList<cmifrNlvyBXuXIoQyzrEFMGvtUuO> list = pUNSxZOhmJavrRHOnPINGDQEOvgM.FIhCvOKLXVJZOTFtTxaSbmgZjQTj();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if ((list[i].IPIhNCYKZLyPpYVHEpNKmhjgkbxE.SSKbqaHTsdHnXFaeBStVuCKuyFvFc & UZXqahMfdCepAdfDNKUfbPnbUVDIc.Axis) != UZXqahMfdCepAdfDNKUfbPnbUVDIc.All)
					{
						pUNSxZOhmJavrRHOnPINGDQEOvgM.MnVXAVaMmRDTbdMZjFuxcTUfryHdb.FJYumlqBoGWHFUEMqgvTyMkubiOD = new jmdzOYOJAgcgiCGqPaQBHuqZjCCQA(-65535, 65535);
					}
				}
			}
			pUNSxZOhmJavrRHOnPINGDQEOvgM.aYqFHcXuqKZKpdHgTlGFMRbumjPj();
		}
		hOLISXUwDrSOMvpaDjmGamYaKHaDA hOLISXUwDrSOMvpaDjmGamYaKHaDA2;
		try
		{
			hOLISXUwDrSOMvpaDjmGamYaKHaDA2 = pUNSxZOhmJavrRHOnPINGDQEOvgM.bPZUHuZuxAsJVKdtPWqoMRZZnVi();
		}
		catch
		{
			hOLISXUwDrSOMvpaDjmGamYaKHaDA2 = null;
		}
		if (hOLISXUwDrSOMvpaDjmGamYaKHaDA2 == null)
		{
			return;
		}
		if (num2 > 0)
		{
			uGOUBJoRAcRNVkjuEnknawACluZL = uGOUBJoRAcRNVkjuEnknawACluZL + num2 + " connected devices:\n";
		}
		for (int j = 0; j < num2; j++)
		{
			uGOUBJoRAcRNVkjuEnknawACluZL = uGOUBJoRAcRNVkjuEnknawACluZL + EKVyNADXjJzrbDGErUmziCdWDdRC[j].CcIThwmTsDNNPaZoGiiOvJkXqSXj + "\n";
		}
		uGOUBJoRAcRNVkjuEnknawACluZL += "\n";
		uGOUBJoRAcRNVkjuEnknawACluZL = uGOUBJoRAcRNVkjuEnknawACluZL + "Current DI device " + DkFagkgqHeGdWonlDISMMlFrGjibA + ": " + EKVyNADXjJzrbDGErUmziCdWDdRC[DkFagkgqHeGdWonlDISMMlFrGjibA].CcIThwmTsDNNPaZoGiiOvJkXqSXj + "\n";
		uGOUBJoRAcRNVkjuEnknawACluZL += "(Press + or - to change monitored device id.)\n\n";
		RrhDskeIUPYRcLJtOisAMLCoRDDQ("Identifier", new PidVid(pUNSxZOhmJavrRHOnPINGDQEOvgM.IwEaLrfSXFRzswkKgVhxajWSbrLS.XzcjuqdPVmKDLdysprgdoAWdbHpv));
		RrhDskeIUPYRcLJtOisAMLCoRDDQ("Instance GUID", pUNSxZOhmJavrRHOnPINGDQEOvgM.IwEaLrfSXFRzswkKgVhxajWSbrLS.fTfFNbdDSSLPqvlVRRFMhJFkkRjdb);
		RrhDskeIUPYRcLJtOisAMLCoRDDQ("Product Id", pUNSxZOhmJavrRHOnPINGDQEOvgM.MnVXAVaMmRDTbdMZjFuxcTUfryHdb.crLXZVmyxBVSvQRSerZjqHbWkfB);
		RrhDskeIUPYRcLJtOisAMLCoRDDQ("Device Type", pUNSxZOhmJavrRHOnPINGDQEOvgM.qYRCFXXsnorCIBmlEHrWlxCTPAuU.oIRxMXRgAEuDfRqZxHiMQEDzHiBCA.ToString());
		uGOUBJoRAcRNVkjuEnknawACluZL += "\n";
		RrhDskeIUPYRcLJtOisAMLCoRDDQ("Axis Count", pUNSxZOhmJavrRHOnPINGDQEOvgM.qYRCFXXsnorCIBmlEHrWlxCTPAuU.jMzORmQWMbdpkVsOLwgOrrucazEp);
		RrhDskeIUPYRcLJtOisAMLCoRDDQ("Button Count", pUNSxZOhmJavrRHOnPINGDQEOvgM.qYRCFXXsnorCIBmlEHrWlxCTPAuU.xNlbavAaABzUlIRMZXWbTUwuNbkWA);
		RrhDskeIUPYRcLJtOisAMLCoRDDQ("Hat Count", pUNSxZOhmJavrRHOnPINGDQEOvgM.qYRCFXXsnorCIBmlEHrWlxCTPAuU.SLqQvYJjPnbYjWJsxPGHtatjjHak);
		uGOUBJoRAcRNVkjuEnknawACluZL += "\n";
		if (flag)
		{
			Rewired.Logger.Log("Device Name: \"" + EKVyNADXjJzrbDGErUmziCdWDdRC[DkFagkgqHeGdWonlDISMMlFrGjibA].CcIThwmTsDNNPaZoGiiOvJkXqSXj + "\"");
			Rewired.Logger.Log("Identifier: " + new PidVid(pUNSxZOhmJavrRHOnPINGDQEOvgM.IwEaLrfSXFRzswkKgVhxajWSbrLS.XzcjuqdPVmKDLdysprgdoAWdbHpv).ToString());
		}
		for (int k = 0; k < 32; k++)
		{
			int num3 = eVvuCTUGTWgCArTEpGXoqqFHJXZn((DirectInputAxis)k, hOLISXUwDrSOMvpaDjmGamYaKHaDA2);
			DirectInputAxis directInputAxis = (DirectInputAxis)k;
			string text = directInputAxis.ToString();
			RrhDskeIUPYRcLJtOisAMLCoRDDQ(text, num3 + " (" + tpMaxJGBjUhEtEDKPfMCkYcauiqG(num3) + ")");
		}
		int[] array = hOLISXUwDrSOMvpaDjmGamYaKHaDA2.rCHURyRdAoajapNUTyZqlWyDfvjr;
		for (int l = 0; l < 4; l++)
		{
			int num4 = array[l];
			string text2 = "Hat " + l;
			RrhDskeIUPYRcLJtOisAMLCoRDDQ(text2, num4);
		}
		bool[] array2 = hOLISXUwDrSOMvpaDjmGamYaKHaDA2.BabgiQCGMFCYDBtnZlpzwktASgfoA;
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
		RrhDskeIUPYRcLJtOisAMLCoRDDQ("Buttons ", text3);
		NunDcXgVktLCBUJAtpumXqRvIbROA.text = uGOUBJoRAcRNVkjuEnknawACluZL;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	private void lAUBnYAIHkHIsgKLNRiCaTHqBwrgA()
	{
		EKVyNADXjJzrbDGErUmziCdWDdRC = rdtfePTcUfnRvWiundMCKtUIFopC.dhYDLFvkhRlJGgJbluKAJtjtthyu(hppHiYuBLSrbOpyrsLdssPhrgBgl.GameControl, ZWJASgfSgFZfrrcyiiPYhRZfDwHYB.AttachedOnly);
		UTmqTEiDXYxawnTtzlpvjuHzkpfC = rdtfePTcUfnRvWiundMCKtUIFopC.dhYDLFvkhRlJGgJbluKAJtjtthyu(hppHiYuBLSrbOpyrsLdssPhrgBgl.All, ZWJASgfSgFZfrrcyiiPYhRZfDwHYB.AttachedOnly);
		zjUCChIxhvUgIAAXPeiAPBiLdIuT = ((UTmqTEiDXYxawnTtzlpvjuHzkpfC != null) ? UTmqTEiDXYxawnTtzlpvjuHzkpfC.Count : 0);
	}

	private void txfesCUreGViEzBIQaFJSMtedvaP()
	{
		PHwkzkzwQUDoFwcGAlGxWMsoBTPF();
	}

	private void jBKnhMFKIwhPyUaHGchOXOGYvnFW()
	{
		PHwkzkzwQUDoFwcGAlGxWMsoBTPF();
	}

	private void PHwkzkzwQUDoFwcGAlGxWMsoBTPF()
	{
		jKpdQmbjbTIoNdUOtTnsHaXiqyTIB();
		ZGhMvkmPrLCJVgfnwwzZBiEuHtXJ = true;
	}

	private void jKpdQmbjbTIoNdUOtTnsHaXiqyTIB()
	{
		DkFagkgqHeGdWonlDISMMlFrGjibA = 0;
		pUNSxZOhmJavrRHOnPINGDQEOvgM = null;
		fzRDYVkVATiumWRFrTgfCjfsIWdw = Guid.Empty;
		EKVyNADXjJzrbDGErUmziCdWDdRC = null;
		UTmqTEiDXYxawnTtzlpvjuHzkpfC = null;
		JnxPqdMdjRkTeemTJmHsLCMGtPgc = false;
		ZGhMvkmPrLCJVgfnwwzZBiEuHtXJ = false;
		zjUCChIxhvUgIAAXPeiAPBiLdIuT = 0;
	}

	private void RrhDskeIUPYRcLJtOisAMLCoRDDQ(string P_0, object P_1)
	{
		uGOUBJoRAcRNVkjuEnknawACluZL = uGOUBJoRAcRNVkjuEnknawACluZL + P_0 + " = " + P_1.ToString() + "\n";
	}

	private int eVvuCTUGTWgCArTEpGXoqqFHJXZn(DirectInputAxis P_0, hOLISXUwDrSOMvpaDjmGamYaKHaDA P_1)
	{
		return P_0 switch
		{
			DirectInputAxis.X => P_1.zfVFwJCmHgMNitmEtBSjuOCUhszOA, 
			DirectInputAxis.Y => P_1.KiAlpiCKWFgyjjowDNDECiYqbkwy, 
			DirectInputAxis.Z => P_1.ZQSJcYiQMGpijpZgyqJCHBKYVirL, 
			DirectInputAxis.RotationX => P_1.FdoMbzNktCfZsAkCittVFdoDSrvtA, 
			DirectInputAxis.RotationY => P_1.VLhcWlfDjhRMWeTmaLZwKCpyTyKiA, 
			DirectInputAxis.RotationZ => P_1.QDRcqrPbmWnvHhHntgIYYwzGBCLe, 
			DirectInputAxis.Slider0 => P_1.vjxbwfESKzhjginidLUGakiaWMNPc[0], 
			DirectInputAxis.Slider1 => P_1.vjxbwfESKzhjginidLUGakiaWMNPc[1], 
			DirectInputAxis.VelocityX => P_1.ACEXUEIhvyDhoWzTfgiYwyOJJWPd, 
			DirectInputAxis.VelocityY => P_1.egepiWoENOPlvjsBjQcUTQThQtXy, 
			DirectInputAxis.VelocityZ => P_1.laEaAyWbbFpPsHrsqLXCVfyRNtOA, 
			DirectInputAxis.AngularVelocityX => P_1.wHdTULrgtMuvDSbwsgsmCugAkAeP, 
			DirectInputAxis.AngularVelocityY => P_1.lcgarTHSBjtWUmvgEVjtSzrZsujU, 
			DirectInputAxis.AngularVelocityZ => P_1.ibfxAWfIrRanqTdyqtTqLUbtxhXB, 
			DirectInputAxis.VelocitySlider0 => P_1.wUDSrnSPhOTZMnhYZHwBuycDpKlU[0], 
			DirectInputAxis.VelocitySlider1 => P_1.wUDSrnSPhOTZMnhYZHwBuycDpKlU[1], 
			DirectInputAxis.AccelerationX => P_1.uQTFfyFfSlfIByTwDPkCWozmwcGRA, 
			DirectInputAxis.AccelerationY => P_1.pXMkCZTiUEuiEegDZDEoFVYUpSFRA, 
			DirectInputAxis.AccelerationZ => P_1.ffTmPAXXGzguywpKjCekFRTqRQsl, 
			DirectInputAxis.AngularAccelerationX => P_1.qBlbBPaAwlscGTqAUQCDsKagsACU, 
			DirectInputAxis.AngularAccelerationY => P_1.peEIRXSSBVcxvHHTnhxAeNMcfnaY, 
			DirectInputAxis.AngularAccelerationZ => P_1.lNofEYDYZLdVbLDxeGfseyvexPwlB, 
			DirectInputAxis.AccelerationSlider0 => P_1.COmBpFHGPXnWfRBCvUNRAKryoWpEA[0], 
			DirectInputAxis.AccelerationSlider1 => P_1.COmBpFHGPXnWfRBCvUNRAKryoWpEA[1], 
			DirectInputAxis.ForceX => P_1.KCPnxpqQEkjzObfGNaxvYugOiRaT, 
			DirectInputAxis.ForceY => P_1.eyWecBSSojXCiSRaPqBtLRtIOzlR, 
			DirectInputAxis.ForceZ => P_1.UdkEZUHSpdiwOssyscQwnYtlGRSw, 
			DirectInputAxis.TorqueX => P_1.vIxhYIkyWDqFTTmMiCuHnOvFAQPHA, 
			DirectInputAxis.TorqueY => P_1.GVRauKxSrsPPYlMZBCjnCBBJwowW, 
			DirectInputAxis.TorqueZ => P_1.OMDDJIICIyneIUjyGgzQeETJPuueB, 
			DirectInputAxis.ForceSlider0 => P_1.JpAeSQrMmaGUXIxPrEopiXoIdjXw[0], 
			DirectInputAxis.ForceSlider1 => P_1.JpAeSQrMmaGUXIxPrEopiXoIdjXw[1], 
			_ => 0, 
		};
	}

	private float tpMaxJGBjUhEtEDKPfMCkYcauiqG(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}

	public void OnDestroy()
	{
		if (pUNSxZOhmJavrRHOnPINGDQEOvgM != null)
		{
			pUNSxZOhmJavrRHOnPINGDQEOvgM.DnPkULQcHkJOjeTDBFfGVUqFIbFS();
		}
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}
}
