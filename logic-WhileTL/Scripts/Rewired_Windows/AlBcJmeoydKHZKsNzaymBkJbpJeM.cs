using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Libraries.SharpDX.XInput;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class AlBcJmeoydKHZKsNzaymBkJbpJeM : PlatformInputManager
{
	private class ACOcLkgGurhTOYETKAjhVHJlVlLe : IInputManagerJoystick, IInputManagerJoystickPublic, IDisposable
	{
		private bool QsjrNMZqcorlgZdpqcVmiyybgFwaA;

		private int xvLwpzRxEqetsJjstnBxHhLaFxQp;

		private readonly int nQtsCOZbkrbzDaVPqzKlFIiwZcNF;

		public Guid dPMadqhvuBRgljDGjUtDIjoGIjQT;

		public string duWoKglBKGEpffcLstnRbzVStlDhA;

		public Guid MLvLlmCarLCofsbmoqbKmtCymXhQ;

		public Rewired.Libraries.SharpDX.XInput.DeviceType iYPcpRBIbkMpiAuJdcVKBJstrIPDc;

		public XInputDeviceSubType ClGfQcfYdCIhmkzaBYYhpMItsoDGA;

		public bool CxdmZJFkiTFxYWsHLfVdndaLjLIp;

		public bool DFteSypXJbqiaSnhmqQPDhbqoyFd;

		public bool AwCtvCYsTuZCenQqibbhoKFTILPf;

		public bool khuHbEfjZduWJkBMZYZFiKyXZnzg;

		private int hvwjkIdJOqsdxXdyCXVTrxEfxpfh;

		private int qQTSvktDXBHwVTTLqwcJnpGZRobC;

		private int VoWZngliXonIzcwhdgDwbBjKENjE;

		private int QuzTRGrrwUDmZKKoxoEmRnZQaQrEA;

		private readonly float[] lMBOzesBmklbuZRpFYcRpzoxCCSg;

		private readonly bool[] FSlHLPPornJarrBYtTZNwaDNeTEy;

		private HardwareJoystickMap_InputManager hrWFokKRfePnjNhvOPIDFxJfIhDv;

		public readonly MXjQTSwfhbbDAHCCQVSmWHvmqHDp UOFqirErmvMNabjsFWtrdaqLdGmG;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> TGhMfMpddOgpnflvcRUCHgmAPREiA;

		private Action PfwsaGXBhZfXtSWdLDJIoxuvtTPO;

		private bool VXFchhgZprPPRfoDkcRFDtcsXLKU;

		private bool xVYllnapIihKZtPcCvQiCCkKaTWz;

		private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

		public string QamwaQQOPPlBpZemmRFSsepNDSwgA
		{
			get
			{
				string text = amzBQgIbgHOYPYUlHRjTPwlDSBVT;
				if (text == string.Empty)
				{
					return string.Empty;
				}
				int num = nQtsCOZbkrbzDaVPqzKlFIiwZcNF;
				return text + " " + num;
			}
		}

		public string amzBQgIbgHOYPYUlHRjTPwlDSBVT
		{
			get
			{
				if (!BsTbQiLDoBaYGMAdfeupOTOZRNIo)
				{
					return string.Empty;
				}
				return ClGfQcfYdCIhmkzaBYYhpMItsoDGA.ToString();
			}
		}

		public bool BsTbQiLDoBaYGMAdfeupOTOZRNIo
		{
			get
			{
				if (UOFqirErmvMNabjsFWtrdaqLdGmG == null || !khuHbEfjZduWJkBMZYZFiKyXZnzg)
				{
					return false;
				}
				if (VXFchhgZprPPRfoDkcRFDtcsXLKU && !gFLZckFGkHnsjvdbqckVQwGjdfVc(spbeDCiOjyKxwEbuAMzSFPUGbPmwc.Asynchronous))
				{
					GeGiwpdxSwbQTByOKPpjKwELraeQ();
				}
				return VXFchhgZprPPRfoDkcRFDtcsXLKU;
			}
		}

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return xvLwpzRxEqetsJjstnBxHhLaFxQp;
			}
			set
			{
				xvLwpzRxEqetsJjstnBxHhLaFxQp = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId => nQtsCOZbkrbzDaVPqzKlFIiwZcNF;

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (QsjrNMZqcorlgZdpqcVmiyybgFwaA)
				{
					return ClGfQcfYdCIhmkzaBYYhpMItsoDGA.ToString() + " " + (nQtsCOZbkrbzDaVPqzKlFIiwZcNF + 1);
				}
				return "XInput " + ClGfQcfYdCIhmkzaBYYhpMItsoDGA.ToString() + " " + (nQtsCOZbkrbzDaVPqzKlFIiwZcNF + 1);
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId => nQtsCOZbkrbzDaVPqzKlFIiwZcNF;

		[CustomObfuscation(rename = false)]
		public int unityId => 0;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension => null;

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => MLvLlmCarLCofsbmoqbKmtCymXhQ;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			UOFqirErmvMNabjsFWtrdaqLdGmG.KeeyIKLQkPbPFVEWaXWwIXfxNgPR(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			UOFqirErmvMNabjsFWtrdaqLdGmG.FzWygGohSJyHLwshwCzTbKavemTj();
		}

		public ACOcLkgGurhTOYETKAjhVHJlVlLe(int P_0, bool P_1, MXjQTSwfhbbDAHCCQVSmWHvmqHDp P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Action P_4)
		{
			UOFqirErmvMNabjsFWtrdaqLdGmG = P_2;
			QsjrNMZqcorlgZdpqcVmiyybgFwaA = P_1;
			nQtsCOZbkrbzDaVPqzKlFIiwZcNF = P_0;
			TGhMfMpddOgpnflvcRUCHgmAPREiA = P_3;
			PfwsaGXBhZfXtSWdLDJIoxuvtTPO = P_4;
			xvLwpzRxEqetsJjstnBxHhLaFxQp = -1;
			hvwjkIdJOqsdxXdyCXVTrxEfxpfh = 6;
			qQTSvktDXBHwVTTLqwcJnpGZRobC = 15;
			VoWZngliXonIzcwhdgDwbBjKENjE = hvwjkIdJOqsdxXdyCXVTrxEfxpfh;
			QuzTRGrrwUDmZKKoxoEmRnZQaQrEA = qQTSvktDXBHwVTTLqwcJnpGZRobC;
			lMBOzesBmklbuZRpFYcRpzoxCCSg = new float[hvwjkIdJOqsdxXdyCXVTrxEfxpfh];
			FSlHLPPornJarrBYtTZNwaDNeTEy = new bool[qQTSvktDXBHwVTTLqwcJnpGZRobC];
			zcRemXbcLIzabLElYDpEOtQwSsSV();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			UOFqirErmvMNabjsFWtrdaqLdGmG.wxRHVHUefMPqgxWWKhUyJOTMdQqY();
			bool[] array = UOFqirErmvMNabjsFWtrdaqLdGmG.pzwnMkEQwHIEQDwpbEuYAwGFTDFM;
			qQBpUfKcENfkDgKnrxrAJYEFaUtgb(array, ref UOFqirErmvMNabjsFWtrdaqLdGmG.DjeEgPODUVXTfazkakXFdZXdoFNE);
			LypwQqzNcDJwwFDlDCnxBriUiWiHA(array, ref UOFqirErmvMNabjsFWtrdaqLdGmG.DjeEgPODUVXTfazkakXFdZXdoFNE);
			UOFqirErmvMNabjsFWtrdaqLdGmG.AAkveQLPaxEaDKEXsosCHmnfCXLT();
		}

		public void dcVdxJdzxMZSZROeXTVCUmflVKQLA(bool P_0)
		{
			if (UOFqirErmvMNabjsFWtrdaqLdGmG != null)
			{
				AwCtvCYsTuZCenQqibbhoKFTILPf = P_0;
			}
		}

		public bool gFLZckFGkHnsjvdbqckVQwGjdfVc(spbeDCiOjyKxwEbuAMzSFPUGbPmwc P_0)
		{
			mTfufOEOomEvhlwobtrEajOXjzGz(dXWPcvhfowRxKmrxYQyXsyoYkCGo(P_0));
			return VXFchhgZprPPRfoDkcRFDtcsXLKU;
		}

		public bool dXWPcvhfowRxKmrxYQyXsyoYkCGo(spbeDCiOjyKxwEbuAMzSFPUGbPmwc P_0)
		{
			if (UOFqirErmvMNabjsFWtrdaqLdGmG == null)
			{
				return false;
			}
			return UOFqirErmvMNabjsFWtrdaqLdGmG.dXWPcvhfowRxKmrxYQyXsyoYkCGo(P_0);
		}

		public void mTfufOEOomEvhlwobtrEajOXjzGz(bool P_0)
		{
			VXFchhgZprPPRfoDkcRFDtcsXLKU = P_0;
		}

		public void OJJbNGKbXLBCewpyECSlTIZgSEyK()
		{
			if (!khuHbEfjZduWJkBMZYZFiKyXZnzg || PomyZPuVQzKGNHlvPQsKeNOmQOSF())
			{
				zcRemXbcLIzabLElYDpEOtQwSsSV();
			}
			if (khuHbEfjZduWJkBMZYZFiKyXZnzg && VXFchhgZprPPRfoDkcRFDtcsXLKU)
			{
				UOFqirErmvMNabjsFWtrdaqLdGmG.gwxczgEzKSIFvbBcZDZivuSJgfdN();
			}
		}

		public void tSwwwFGareGchBJHJUQeejanEedLA()
		{
			xvLwpzRxEqetsJjstnBxHhLaFxQp = -1;
			khuHbEfjZduWJkBMZYZFiKyXZnzg = false;
			UOFqirErmvMNabjsFWtrdaqLdGmG.NasvgdDgFIMWCyvFQbIDtpxNXERU();
			Array.Clear(lMBOzesBmklbuZRpFYcRpzoxCCSg, 0, lMBOzesBmklbuZRpFYcRpzoxCCSg.Length);
			Array.Clear(FSlHLPPornJarrBYtTZNwaDNeTEy, 0, FSlHLPPornJarrBYtTZNwaDNeTEy.Length);
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (hvwjkIdJOqsdxXdyCXVTrxEfxpfh != dataUpdater.axisCount || qQTSvktDXBHwVTTLqwcJnpGZRobC != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < hvwjkIdJOqsdxXdyCXVTrxEfxpfh; i++)
			{
				dataUpdater.axisValues[i] = lMBOzesBmklbuZRpFYcRpzoxCCSg[i];
			}
			for (int j = 0; j < qQTSvktDXBHwVTTLqwcJnpGZRobC; j++)
			{
				dataUpdater.buttonValues[j] = FSlHLPPornJarrBYtTZNwaDNeTEy[j];
			}
			if (xVYllnapIihKZtPcCvQiCCkKaTWz && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public BridgedControllerHWInfo rTVVkYwcBzPcSjgQNEJEDKXoKAcdA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			AnvVmXkzaGotHQSsrLViRKpQvMhJ(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			AnvVmXkzaGotHQSsrLViRKpQvMhJ(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(xvLwpzRxEqetsJjstnBxHhLaFxQp);
		}

		private void zcRemXbcLIzabLElYDpEOtQwSsSV()
		{
			if (UOFqirErmvMNabjsFWtrdaqLdGmG == null || !gFLZckFGkHnsjvdbqckVQwGjdfVc(spbeDCiOjyKxwEbuAMzSFPUGbPmwc.Synchronous))
			{
				return;
			}
			try
			{
				hEsdLqHTUjiWbzYqdvRncPtpedYf();
				pLDfuOLDVkQentqphmwptMRCAfor pLDfuOLDVkQentqphmwptMRCAfor2 = UOFqirErmvMNabjsFWtrdaqLdGmG.KrWFilfNHTwhkEluwjGDFIcbxXdn.aGehTbxZsejkPxinFgCVSPPehGWF(KFiOsXgXzCqGOJdSZfosebVofTizA.Any);
				iYPcpRBIbkMpiAuJdcVKBJstrIPDc = pLDfuOLDVkQentqphmwptMRCAfor2.fIOegccOCicVLevenXOIwaeUcNZY;
				ClGfQcfYdCIhmkzaBYYhpMItsoDGA = (XInputDeviceSubType)pLDfuOLDVkQentqphmwptMRCAfor2.xdpgjrtgmzUidRuFCwkEttWImySf;
				if (UOFqirErmvMNabjsFWtrdaqLdGmG.KrWFilfNHTwhkEluwjGDFIcbxXdn.KeeyIKLQkPbPFVEWaXWwIXfxNgPR(default(tpSNqCAYHsNToWutFORZokHrSgaV)).YZFGHfjOtOLQQxVFaBVjgomUbMSxA)
				{
					CxdmZJFkiTFxYWsHLfVdndaLjLIp = true;
				}
				DFteSypXJbqiaSnhmqQPDhbqoyFd = (pLDfuOLDVkQentqphmwptMRCAfor2.VLbBlajDRCKlfsUoYsvoOwmKeETSA & HtOsArSixeGIefFyNUiQwMqDjnlj.VoiceSupported) == HtOsArSixeGIefFyNUiQwMqDjnlj.VoiceSupported;
				bKOJiVJxFDkRpxUXrQUwrkhXlNCR();
				dPMadqhvuBRgljDGjUtDIjoGIjQT = hrWFokKRfePnjNhvOPIDFxJfIhDv.hardwareMapIdentifier.guid;
				duWoKglBKGEpffcLstnRbzVStlDhA = hrWFokKRfePnjNhvOPIDFxJfIhDv.controllerName;
				UOFqirErmvMNabjsFWtrdaqLdGmG.gwxczgEzKSIFvbBcZDZivuSJgfdN();
				MLvLlmCarLCofsbmoqbKmtCymXhQ = MiscTools.CreateGuidHashSHA1(string.Concat(iYPcpRBIbkMpiAuJdcVKBJstrIPDc, ClGfQcfYdCIhmkzaBYYhpMItsoDGA, nQtsCOZbkrbzDaVPqzKlFIiwZcNF));
				khuHbEfjZduWJkBMZYZFiKyXZnzg = true;
			}
			catch (Exception)
			{
				khuHbEfjZduWJkBMZYZFiKyXZnzg = false;
				VXFchhgZprPPRfoDkcRFDtcsXLKU = false;
				MLvLlmCarLCofsbmoqbKmtCymXhQ = Guid.Empty;
			}
		}

		private bool PomyZPuVQzKGNHlvPQsKeNOmQOSF()
		{
			try
			{
				if (ClGfQcfYdCIhmkzaBYYhpMItsoDGA != (XInputDeviceSubType)UOFqirErmvMNabjsFWtrdaqLdGmG.KrWFilfNHTwhkEluwjGDFIcbxXdn.aGehTbxZsejkPxinFgCVSPPehGWF(KFiOsXgXzCqGOJdSZfosebVofTizA.Any).xdpgjrtgmzUidRuFCwkEttWImySf)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private void hEsdLqHTUjiWbzYqdvRncPtpedYf()
		{
			DFteSypXJbqiaSnhmqQPDhbqoyFd = false;
			CxdmZJFkiTFxYWsHLfVdndaLjLIp = false;
			AwCtvCYsTuZCenQqibbhoKFTILPf = false;
			khuHbEfjZduWJkBMZYZFiKyXZnzg = false;
		}

		private void GeGiwpdxSwbQTByOKPpjKwELraeQ()
		{
			if (PfwsaGXBhZfXtSWdLDJIoxuvtTPO != null)
			{
				PfwsaGXBhZfXtSWdLDJIoxuvtTPO();
			}
			UOFqirErmvMNabjsFWtrdaqLdGmG.NasvgdDgFIMWCyvFQbIDtpxNXERU();
		}

		private void qQBpUfKcENfkDgKnrxrAJYEFaUtgb(bool[] P_0, ref KwLFwWWKyvWXyoQWCPtDBogWXkmP P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_XInput_Base)hrWFokKRfePnjNhvOPIDFxJfIhDv.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (i >= hvwjkIdJOqsdxXdyCXVTrxEfxpfh)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				lMBOzesBmklbuZRpFYcRpzoxCCSg[i] = gtExFxcpYcZTABrBeLFEPTMTniaw(axes_orig[i], P_0, ref P_1);
				if (!xVYllnapIihKZtPcCvQiCCkKaTWz && lMBOzesBmklbuZRpFYcRpzoxCCSg[i] != 0f)
				{
					xVYllnapIihKZtPcCvQiCCkKaTWz = true;
				}
			}
		}

		private void LypwQqzNcDJwwFDlDCnxBriUiWiHA(bool[] P_0, ref KwLFwWWKyvWXyoQWCPtDBogWXkmP P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_XInput_Base)hrWFokKRfePnjNhvOPIDFxJfIhDv.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= qQTSvktDXBHwVTTLqwcJnpGZRobC)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				FSlHLPPornJarrBYtTZNwaDNeTEy[i] = KXJdWAAUxLBpMBYcIbLVuKxtomne(buttons_orig[i], P_0, ref P_1);
				if (!xVYllnapIihKZtPcCvQiCCkKaTWz && FSlHLPPornJarrBYtTZNwaDNeTEy[i])
				{
					xVYllnapIihKZtPcCvQiCCkKaTWz = true;
				}
			}
		}

		private float gtExFxcpYcZTABrBeLFEPTMTniaw(HardwareJoystickMap.Platform_XInput_Base.Axis P_0, bool[] P_1, ref KwLFwWWKyvWXyoQWCPtDBogWXkmP P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return 0f;
				}
				return gtExFxcpYcZTABrBeLFEPTMTniaw(P_0.sourceAxis, ref P_2);
			}
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return 0f;
				}
				if (!KXJdWAAUxLBpMBYcIbLVuKxtomne(P_0.sourceButton, P_1))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			return 0f;
		}

		private float gtExFxcpYcZTABrBeLFEPTMTniaw(XInputAxis P_0, ref KwLFwWWKyvWXyoQWCPtDBogWXkmP P_1)
		{
			return P_0 switch
			{
				XInputAxis.LeftThumbX => MXjQTSwfhbbDAHCCQVSmWHvmqHDp.ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(P_1.CzuCVsZkpSKDosLOsezXUOXPomNI), 
				XInputAxis.LeftThumbY => MXjQTSwfhbbDAHCCQVSmWHvmqHDp.ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(P_1.eGUcMdLMelxbHAjzVlvoKihhNMDP), 
				XInputAxis.RightThumbX => MXjQTSwfhbbDAHCCQVSmWHvmqHDp.ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(P_1.owAqmSzHlxlGDLHsNDmtbOVrryMdA), 
				XInputAxis.RightThumbY => MXjQTSwfhbbDAHCCQVSmWHvmqHDp.ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(P_1.GizhhenNHKGkvhQLQxvWiPIhvrxvA), 
				XInputAxis.LeftTrigger => MXjQTSwfhbbDAHCCQVSmWHvmqHDp.IxmDarhiptkJlWnBGteATRHaUaONA(P_1.uomPdVhcfRwHqwxnQChGTrDEWgYo), 
				XInputAxis.RightTrigger => MXjQTSwfhbbDAHCCQVSmWHvmqHDp.IxmDarhiptkJlWnBGteATRHaUaONA(P_1.WRydEHyKeHXYmnwYdTjudHETOFtU), 
				_ => 0f, 
			};
		}

		private bool KXJdWAAUxLBpMBYcIbLVuKxtomne(HardwareJoystickMap.Platform_XInput_Base.Button P_0, bool[] P_1, ref KwLFwWWKyvWXyoQWCPtDBogWXkmP P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return false;
				}
				return KXJdWAAUxLBpMBYcIbLVuKxtomne(P_0.sourceButton, P_1);
			}
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return false;
				}
				float num = gtExFxcpYcZTABrBeLFEPTMTniaw(P_0.sourceAxis, ref P_2);
				if (MathTools.Abs(num) <= P_0.axisDeadZone)
				{
					return false;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num < 0f)
					{
						return false;
					}
				}
				else if (num > 0f)
				{
					return false;
				}
				return true;
			}
			return false;
		}

		private bool KXJdWAAUxLBpMBYcIbLVuKxtomne(XInputButton P_0, bool[] P_1)
		{
			return P_0 switch
			{
				XInputButton.DPadUp => P_1[0], 
				XInputButton.DPadDown => P_1[1], 
				XInputButton.DPadLeft => P_1[2], 
				XInputButton.DPadRight => P_1[3], 
				XInputButton.Start => P_1[4], 
				XInputButton.Back => P_1[5], 
				XInputButton.LeftThumb => P_1[6], 
				XInputButton.RightThumb => P_1[7], 
				XInputButton.LeftShoulder => P_1[8], 
				XInputButton.RightShoulder => P_1[9], 
				XInputButton.Guide => P_1[10], 
				XInputButton.A => P_1[11], 
				XInputButton.B => P_1[12], 
				XInputButton.X => P_1[13], 
				XInputButton.Y => P_1[14], 
				_ => false, 
			};
		}

		private void bKOJiVJxFDkRpxUXrQUwrkhXlNCR()
		{
			hrWFokKRfePnjNhvOPIDFxJfIhDv = TGhMfMpddOgpnflvcRUCHgmAPREiA(rTVVkYwcBzPcSjgQNEJEDKXoKAcdA());
			if (hrWFokKRfePnjNhvOPIDFxJfIhDv == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			hvwjkIdJOqsdxXdyCXVTrxEfxpfh = hrWFokKRfePnjNhvOPIDFxJfIhDv.axisCount;
			qQTSvktDXBHwVTTLqwcJnpGZRobC = hrWFokKRfePnjNhvOPIDFxJfIhDv.buttonCount;
		}

		private bool lBvESsMwmnEVPlVoqsmWUDWBbefJA(ref tpSNqCAYHsNToWutFORZokHrSgaV P_0)
		{
			if (P_0.twMMEFHycxgAYJLBlCScBbJCqtnU > 0 || P_0.asAgYBSdlYaJQfJwQtPmfXAscXCS > 0)
			{
				return true;
			}
			return false;
		}

		private void QWTTJeSZznPvAEvTWIvJhVtiHiFh(ref tpSNqCAYHsNToWutFORZokHrSgaV P_0)
		{
			P_0.twMMEFHycxgAYJLBlCScBbJCqtnU = 0;
			P_0.asAgYBSdlYaJQfJwQtPmfXAscXCS = 0;
		}

		private void EaqsFtyjfVuJZcYVkMFpFmWQtGBD(ref tpSNqCAYHsNToWutFORZokHrSgaV P_0, ref tpSNqCAYHsNToWutFORZokHrSgaV P_1)
		{
			P_1.twMMEFHycxgAYJLBlCScBbJCqtnU = P_0.twMMEFHycxgAYJLBlCScBbJCqtnU;
			P_1.asAgYBSdlYaJQfJwQtPmfXAscXCS = P_0.asAgYBSdlYaJQfJwQtPmfXAscXCS;
		}

		private string xBXCjGoFEAXUazpkvpqEVOgasIRK()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.XInput.ToString()}{iYPcpRBIbkMpiAuJdcVKBJstrIPDc.ToString()}{ClGfQcfYdCIhmkzaBYYhpMItsoDGA.ToString()}");
		}

		private void AnvVmXkzaGotHQSsrLViRKpQvMhJ(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.XInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = ControlDeviceType.Unknown;
			P_0.hardwareIdentifier = xBXCjGoFEAXUazpkvpqEVOgasIRK();
			P_0.hardwareAxisCount = VoWZngliXonIzcwhdgDwbBjKENjE;
			P_0.hardwareButtonCount = QuzTRGrrwUDmZKKoxoEmRnZQaQrEA;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = amzBQgIbgHOYPYUlHRjTPwlDSBVT;
			P_0.hw_supportsVoice = DFteSypXJbqiaSnhmqQPDhbqoyFd;
			P_0.hw_supportsVibration = CxdmZJFkiTFxYWsHLfVdndaLjLIp;
			P_0.hw_localVibrationMotorCount = (CxdmZJFkiTFxYWsHLfVdndaLjLIp ? 2 : 0);
			P_0.hw_xInputSubType = ClGfQcfYdCIhmkzaBYYhpMItsoDGA;
		}

		private void AnvVmXkzaGotHQSsrLViRKpQvMhJ(BridgedController P_0)
		{
			AnvVmXkzaGotHQSsrLViRKpQvMhJ((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = hrWFokKRfePnjNhvOPIDFxJfIhDv.ToGameHardwareControllerMap();
			P_0.instanceName = "XInput " + QamwaQQOPPlBpZemmRFSsepNDSwgA;
			P_0.productName = "XInput " + amzBQgIbgHOYPYUlHRjTPwlDSBVT;
			P_0.isXInputDevice = true;
			P_0.axisCount = hvwjkIdJOqsdxXdyCXVTrxEfxpfh;
			P_0.buttonCount = qQTSvktDXBHwVTTLqwcJnpGZRobC;
			P_0.controllerTypeGuid = dPMadqhvuBRgljDGjUtDIjoGIjQT;
			P_0.controllerExtension = extension;
		}

		public void Dispose()
		{
			hIlanWXkrCYfgvCyascUuCUOCBcL(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
		{
			try
			{
				hIlanWXkrCYfgvCyascUuCUOCBcL(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
		{
			if (TExNvhkEWsBWipIUjadCDaTpNNDG)
			{
				return;
			}
			if (P_0)
			{
				if (BsTbQiLDoBaYGMAdfeupOTOZRNIo)
				{
					UOFqirErmvMNabjsFWtrdaqLdGmG.mJQJIvcLRCCDtcTWCxYfYKqwMfqH();
				}
				if (UOFqirErmvMNabjsFWtrdaqLdGmG != null)
				{
					UOFqirErmvMNabjsFWtrdaqLdGmG.Dispose();
				}
			}
			TExNvhkEWsBWipIUjadCDaTpNNDG = true;
		}
	}

	private class drnOdHnekozxRkzqNvGrccuYvPPv
	{
		private class sObBYXPILKGlvAPPieyCZkfkOCVbA
		{
			public bool ROKbGNhIKIGpNdPGNByAZbsbZNVz;

			public int sxHAgKaSFAVQVcgbYbUKBppQIIupA;

			public XInputDeviceSubType ClGfQcfYdCIhmkzaBYYhpMItsoDGA;

			public void cmTGFsRmXJEFbLoGhVUXbOoqUnNg(ACOcLkgGurhTOYETKAjhVHJlVlLe P_0, bool P_1)
			{
				ROKbGNhIKIGpNdPGNByAZbsbZNVz = P_1;
				sxHAgKaSFAVQVcgbYbUKBppQIIupA = P_0.rewiredId;
				ClGfQcfYdCIhmkzaBYYhpMItsoDGA = P_0.ClGfQcfYdCIhmkzaBYYhpMItsoDGA;
			}

			public sObBYXPILKGlvAPPieyCZkfkOCVbA(int P_0, XInputDeviceSubType P_1)
			{
				sxHAgKaSFAVQVcgbYbUKBppQIIupA = P_0;
				ClGfQcfYdCIhmkzaBYYhpMItsoDGA = P_1;
			}
		}

		private List<sObBYXPILKGlvAPPieyCZkfkOCVbA> TLhELvHYSwEeYQEneYzAwjQcfGke;

		public drnOdHnekozxRkzqNvGrccuYvPPv()
		{
			TLhELvHYSwEeYQEneYzAwjQcfGke = new List<sObBYXPILKGlvAPPieyCZkfkOCVbA>();
		}

		public void ZFKolpVPgjBQcEcyTyAveVytVnXCA(ACOcLkgGurhTOYETKAjhVHJlVlLe P_0, bool P_1)
		{
			if (aTrbXeANmagDWpbUFhssjZPOGFfnA(P_0.rewiredId, P_0.ClGfQcfYdCIhmkzaBYYhpMItsoDGA, true) < 0)
			{
				sObBYXPILKGlvAPPieyCZkfkOCVbA sObBYXPILKGlvAPPieyCZkfkOCVbA2 = new sObBYXPILKGlvAPPieyCZkfkOCVbA(P_0.rewiredId, P_0.ClGfQcfYdCIhmkzaBYYhpMItsoDGA);
				sObBYXPILKGlvAPPieyCZkfkOCVbA2.ROKbGNhIKIGpNdPGNByAZbsbZNVz = P_1;
				TLhELvHYSwEeYQEneYzAwjQcfGke.Add(sObBYXPILKGlvAPPieyCZkfkOCVbA2);
			}
		}

		public void cmTGFsRmXJEFbLoGhVUXbOoqUnNg(int P_0, ACOcLkgGurhTOYETKAjhVHJlVlLe P_1, bool P_2)
		{
			if (P_0 >= 0 && P_0 < TLhELvHYSwEeYQEneYzAwjQcfGke.Count)
			{
				TLhELvHYSwEeYQEneYzAwjQcfGke[P_0].cmTGFsRmXJEFbLoGhVUXbOoqUnNg(P_1, P_2);
			}
		}

		public int RDCzMSHXWFyViTJuihvIPriROuje(XInputDeviceSubType P_0, bool P_1)
		{
			int count = TLhELvHYSwEeYQEneYzAwjQcfGke.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_1 || !TLhELvHYSwEeYQEneYzAwjQcfGke[i].ROKbGNhIKIGpNdPGNByAZbsbZNVz) && TLhELvHYSwEeYQEneYzAwjQcfGke[i].ClGfQcfYdCIhmkzaBYYhpMItsoDGA == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		public int aTrbXeANmagDWpbUFhssjZPOGFfnA(int P_0, XInputDeviceSubType P_1, bool P_2)
		{
			int count = TLhELvHYSwEeYQEneYzAwjQcfGke.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_2 || !TLhELvHYSwEeYQEneYzAwjQcfGke[i].ROKbGNhIKIGpNdPGNByAZbsbZNVz) && TLhELvHYSwEeYQEneYzAwjQcfGke[i].sxHAgKaSFAVQVcgbYbUKBppQIIupA == P_0 && TLhELvHYSwEeYQEneYzAwjQcfGke[i].ClGfQcfYdCIhmkzaBYYhpMItsoDGA == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		public int kmLZxaQvWLsuVMFWfYLXcOOTRCpK(int P_0)
		{
			if (P_0 < 0 || P_0 >= TLhELvHYSwEeYQEneYzAwjQcfGke.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return TLhELvHYSwEeYQEneYzAwjQcfGke[P_0].sxHAgKaSFAVQVcgbYbUKBppQIIupA;
		}

		public void FnXFcueWFLyfBmuxQPrWRwBTYuRk(int P_0, bool P_1)
		{
			if (P_0 >= 0 && P_0 < TLhELvHYSwEeYQEneYzAwjQcfGke.Count)
			{
				TLhELvHYSwEeYQEneYzAwjQcfGke[P_0].ROKbGNhIKIGpNdPGNByAZbsbZNVz = P_1;
			}
		}
	}

	private class SsVMxtTTqojwOMnYBCShhuTLqsTt
	{
		public bool yLkFhSpOUdpEGLqRRFdpDdvgYhURA;

		private double oypBtcQUKtHWGxryYPkNSMuyWwRC;

		public float MjlfOHCqHCxSEEcyLojwQICwQkyr;

		public SsVMxtTTqojwOMnYBCShhuTLqsTt()
		{
		}

		public SsVMxtTTqojwOMnYBCShhuTLqsTt(float P_0)
		{
			MjlfOHCqHCxSEEcyLojwQICwQkyr = P_0;
		}

		public void pBzxWNdMLjyMGydncxVfXziaTAvG()
		{
			yLkFhSpOUdpEGLqRRFdpDdvgYhURA = true;
			oypBtcQUKtHWGxryYPkNSMuyWwRC = (double)MjlfOHCqHCxSEEcyLojwQICwQkyr + ReInput.unscaledTime;
		}

		public void pBzxWNdMLjyMGydncxVfXziaTAvG(float P_0)
		{
			yLkFhSpOUdpEGLqRRFdpDdvgYhURA = true;
			MjlfOHCqHCxSEEcyLojwQICwQkyr = P_0;
			oypBtcQUKtHWGxryYPkNSMuyWwRC = (double)MjlfOHCqHCxSEEcyLojwQICwQkyr + ReInput.unscaledTime;
		}

		public bool cmTGFsRmXJEFbLoGhVUXbOoqUnNg()
		{
			if (!yLkFhSpOUdpEGLqRRFdpDdvgYhURA)
			{
				return false;
			}
			if (ReInput.unscaledTime >= oypBtcQUKtHWGxryYPkNSMuyWwRC)
			{
				yLkFhSpOUdpEGLqRRFdpDdvgYhURA = false;
				return true;
			}
			return false;
		}

		public void PNnwosyJbZAkbwObisgdtMytZJol()
		{
			yLkFhSpOUdpEGLqRRFdpDdvgYhURA = false;
			oypBtcQUKtHWGxryYPkNSMuyWwRC = 0.0;
		}

		public void uHXwuEyrmXaYmbsNXhoybsteaDkuB(float P_0)
		{
			MjlfOHCqHCxSEEcyLojwQICwQkyr = P_0;
		}

		public SsVMxtTTqojwOMnYBCShhuTLqsTt oTaENuTDCGQwSSYftAoVqRAiXssi()
		{
			return (SsVMxtTTqojwOMnYBCShhuTLqsTt)MemberwiseClone();
		}
	}

	public class MXjQTSwfhbbDAHCCQVSmWHvmqHDp : IDisposable
	{
		public readonly MfBGKQHiQJSofUpHMtinVyKcMQYE KrWFilfNHTwhkEluwjGDFIcbxXdn;

		public KwLFwWWKyvWXyoQWCPtDBogWXkmP DjeEgPODUVXTfazkakXFdZXdoFNE;

		private bool VXFchhgZprPPRfoDkcRFDtcsXLKU;

		private readonly ButtonLoopSet FIqcWdZNNfrCDgUvGqnVgbtVFHFl;

		private KwLFwWWKyvWXyoQWCPtDBogWXkmP jXmfNGvxZHqvDwatGppJrtiFcOXV;

		private bool ftfcHlpAwwGedyOdZDQcVnVHGEccA;

		private DualThreadLowLevelInputEventQueue PirJWhvyCfrpVEFiYCjtFrHaJZtt;

		private readonly object cCndHwpyhmiyUcAhGQdqlqtbgioX;

		private RingBuffer<tpSNqCAYHsNToWutFORZokHrSgaV> qyZfapAUoQrrUnWfRMXRIGcnRZKKA = new RingBuffer<tpSNqCAYHsNToWutFORZokHrSgaV>(5);

		private RingBuffer<tpSNqCAYHsNToWutFORZokHrSgaV> ocUjFjxdDSZyTYliuoNRIKSsGleG = new RingBuffer<tpSNqCAYHsNToWutFORZokHrSgaV>(5);

		private readonly object AKiFpQwqNnuQKaddTHBmDMrRXnGA = new object();

		private readonly object LXdFMSjHDOcpBbnreTkdjDawQPIlA = new object();

		private tpSNqCAYHsNToWutFORZokHrSgaV feEUqVJlELaBwwOdJUWnGOeglFJA;

		private double ZHKBUTfnfihZiTnbEnKliwxCzsYwA;

		private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

		public bool[] pzwnMkEQwHIEQDwpbEuYAwGFTDFM => FIqcWdZNNfrCDgUvGqnVgbtVFHFl.Current.effectiveValue;

		public MXjQTSwfhbbDAHCCQVSmWHvmqHDp(int P_0, UpdateLoopSetting P_1)
		{
			KrWFilfNHTwhkEluwjGDFIcbxXdn = new MfBGKQHiQJSofUpHMtinVyKcMQYE((qyRchGJurxpnXCGunLCbcAvoTUIuA)P_0);
			FIqcWdZNNfrCDgUvGqnVgbtVFHFl = new ButtonLoopSet(P_1, 15);
			cCndHwpyhmiyUcAhGQdqlqtbgioX = new object();
			PirJWhvyCfrpVEFiYCjtFrHaJZtt = new DualThreadLowLevelInputEventQueue((int)((float)FAsHqxeBatkZAlvOYNBwGTMPNyEq.JtkmrSfvKeyVdzOmZkiZGQIKPRUi * 0.25f), 15, 6, 0);
		}

		public void wxRHVHUefMPqgxWWKhUyJOTMdQqY()
		{
			FIqcWdZNNfrCDgUvGqnVgbtVFHFl.SetUpdateLoop(ReInput.currentUpdateLoop);
			eNJqQDJyYsmvqLYnrwYyXbAtImgU(ref DjeEgPODUVXTfazkakXFdZXdoFNE);
		}

		public void AAkveQLPaxEaDKEXsosCHmnfCXLT()
		{
			LTyNrzpGtKvNwfqkGiUTMoJfNUpV();
			FIqcWdZNNfrCDgUvGqnVgbtVFHFl.Current.ClearWasTrueThisFrame();
		}

		public void gwxczgEzKSIFvbBcZDZivuSJgfdN()
		{
			clOavfCHpNeTPfcwzgPdNbzmHFpz();
			VXFchhgZprPPRfoDkcRFDtcsXLKU = true;
			ftfcHlpAwwGedyOdZDQcVnVHGEccA = KrWFilfNHTwhkEluwjGDFIcbxXdn.HssrrySHiNxIjRzaAsLIdCHlpsIn;
		}

		public void NasvgdDgFIMWCyvFQbIDtpxNXERU()
		{
			VXFchhgZprPPRfoDkcRFDtcsXLKU = false;
			ftfcHlpAwwGedyOdZDQcVnVHGEccA = false;
			clOavfCHpNeTPfcwzgPdNbzmHFpz();
		}

		public bool dXWPcvhfowRxKmrxYQyXsyoYkCGo(spbeDCiOjyKxwEbuAMzSFPUGbPmwc P_0)
		{
			return P_0 switch
			{
				spbeDCiOjyKxwEbuAMzSFPUGbPmwc.Synchronous => ftfcHlpAwwGedyOdZDQcVnVHGEccA = KrWFilfNHTwhkEluwjGDFIcbxXdn.HssrrySHiNxIjRzaAsLIdCHlpsIn, 
				spbeDCiOjyKxwEbuAMzSFPUGbPmwc.Asynchronous => ftfcHlpAwwGedyOdZDQcVnVHGEccA, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void KeeyIKLQkPbPFVEWaXWwIXfxNgPR(float P_0, int P_1)
		{
			switch (P_1)
			{
			case 0:
				feEUqVJlELaBwwOdJUWnGOeglFJA.twMMEFHycxgAYJLBlCScBbJCqtnU = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			case 1:
				feEUqVJlELaBwwOdJUWnGOeglFJA.asAgYBSdlYaJQfJwQtPmfXAscXCS = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			}
			ObLriTcKxrBoswgGxmrnCIVOewEx();
		}

		public void FzWygGohSJyHLwshwCzTbKavemTj()
		{
			feEUqVJlELaBwwOdJUWnGOeglFJA.twMMEFHycxgAYJLBlCScBbJCqtnU = 0;
			feEUqVJlELaBwwOdJUWnGOeglFJA.asAgYBSdlYaJQfJwQtPmfXAscXCS = 0;
			ObLriTcKxrBoswgGxmrnCIVOewEx();
		}

		public void mJQJIvcLRCCDtcTWCxYfYKqwMfqH()
		{
			feEUqVJlELaBwwOdJUWnGOeglFJA.twMMEFHycxgAYJLBlCScBbJCqtnU = 0;
			feEUqVJlELaBwwOdJUWnGOeglFJA.asAgYBSdlYaJQfJwQtPmfXAscXCS = 0;
			lock (LXdFMSjHDOcpBbnreTkdjDawQPIlA)
			{
				lock (AKiFpQwqNnuQKaddTHBmDMrRXnGA)
				{
					qyZfapAUoQrrUnWfRMXRIGcnRZKKA.Clear();
					ocUjFjxdDSZyTYliuoNRIKSsGleG.Clear();
					dodBMLHGQzvmxvRoRbPHCrewAJJF(KrWFilfNHTwhkEluwjGDFIcbxXdn, feEUqVJlELaBwwOdJUWnGOeglFJA, ref ZHKBUTfnfihZiTnbEnKliwxCzsYwA);
				}
			}
		}

		public void hmnJKqrTZQrMgrqfnuUGuVMzamsB()
		{
			if (!VXFchhgZprPPRfoDkcRFDtcsXLKU || !ftfcHlpAwwGedyOdZDQcVnVHGEccA)
			{
				return;
			}
			urijYWHRYDjHpUIBTAkzPvMbdjsX urijYWHRYDjHpUIBTAkzPvMbdjsX2;
			double realTime;
			try
			{
				if (!KrWFilfNHTwhkEluwjGDFIcbxXdn.AMoOAFENmEgsvRpFkInzHKeXIMHMA(out urijYWHRYDjHpUIBTAkzPvMbdjsX2))
				{
					ftfcHlpAwwGedyOdZDQcVnVHGEccA = false;
					return;
				}
				realTime = ReInput.realTime;
			}
			catch
			{
				ftfcHlpAwwGedyOdZDQcVnVHGEccA = false;
				return;
			}
			lock (cCndHwpyhmiyUcAhGQdqlqtbgioX)
			{
				if (!lsLJccfJgrWYSkQiBhsoxKcyTvDA(urijYWHRYDjHpUIBTAkzPvMbdjsX2.PXKClQeOFJmukCTcYOiaGvvcQGGFb, jXmfNGvxZHqvDwatGppJrtiFcOXV))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = PirJWhvyCfrpVEFiYCjtFrHaJZtt.T_CreateEvent())
					{
						vSAUCjAtfcslMESvUHCfrrjYakZL(ref urijYWHRYDjHpUIBTAkzPvMbdjsX2.PXKClQeOFJmukCTcYOiaGvvcQGGFb, realTime, newEventWrapper.Event);
					}
					jXmfNGvxZHqvDwatGppJrtiFcOXV = urijYWHRYDjHpUIBTAkzPvMbdjsX2.PXKClQeOFJmukCTcYOiaGvvcQGGFb;
				}
			}
		}

		public void KWiFoHHELyoSUiDkTBtUYnuMVsIg()
		{
			if (!VXFchhgZprPPRfoDkcRFDtcsXLKU || !ftfcHlpAwwGedyOdZDQcVnVHGEccA || ReInput.realTime < ZHKBUTfnfihZiTnbEnKliwxCzsYwA + 0.009999999776482582)
			{
				return;
			}
			lock (LXdFMSjHDOcpBbnreTkdjDawQPIlA)
			{
				lock (AKiFpQwqNnuQKaddTHBmDMrRXnGA)
				{
					MiscTools.Swap(ref qyZfapAUoQrrUnWfRMXRIGcnRZKKA, ref ocUjFjxdDSZyTYliuoNRIKSsGleG);
				}
				NrGsRZTIicSNNPtRVstGhDknpNeO(ocUjFjxdDSZyTYliuoNRIKSsGleG, KrWFilfNHTwhkEluwjGDFIcbxXdn, ref ZHKBUTfnfihZiTnbEnKliwxCzsYwA);
			}
		}

		private void LTyNrzpGtKvNwfqkGiUTMoJfNUpV()
		{
			upCGldhsWhvwMpzBrFaajEtGwpizb();
		}

		private void upCGldhsWhvwMpzBrFaajEtGwpizb()
		{
			if (!(ReInput.realTime < ZHKBUTfnfihZiTnbEnKliwxCzsYwA + 1.5) && (!Mathf.Approximately((int)feEUqVJlELaBwwOdJUWnGOeglFJA.twMMEFHycxgAYJLBlCScBbJCqtnU, 0f) || !Mathf.Approximately((int)feEUqVJlELaBwwOdJUWnGOeglFJA.asAgYBSdlYaJQfJwQtPmfXAscXCS, 0f)))
			{
				ObLriTcKxrBoswgGxmrnCIVOewEx();
			}
		}

		private void ObLriTcKxrBoswgGxmrnCIVOewEx()
		{
			lock (AKiFpQwqNnuQKaddTHBmDMrRXnGA)
			{
				qyZfapAUoQrrUnWfRMXRIGcnRZKKA.Enqueue(feEUqVJlELaBwwOdJUWnGOeglFJA);
			}
		}

		private static void NrGsRZTIicSNNPtRVstGhDknpNeO(RingBuffer<tpSNqCAYHsNToWutFORZokHrSgaV> P_0, MfBGKQHiQJSofUpHMtinVyKcMQYE P_1, ref double P_2)
		{
			if (P_0.Count > 0)
			{
				dodBMLHGQzvmxvRoRbPHCrewAJJF(P_1, P_0[P_0.Count - 1], ref P_2);
				P_0.Clear();
			}
		}

		private static void dodBMLHGQzvmxvRoRbPHCrewAJJF(MfBGKQHiQJSofUpHMtinVyKcMQYE P_0, tpSNqCAYHsNToWutFORZokHrSgaV P_1, ref double P_2)
		{
			try
			{
				P_0.KeeyIKLQkPbPFVEWaXWwIXfxNgPR(P_1);
			}
			catch
			{
			}
			P_2 = ReInput.realTime;
		}

		private void eNJqQDJyYsmvqLYnrwYyXbAtImgU(ref KwLFwWWKyvWXyoQWCPtDBogWXkmP P_0)
		{
			while (PirJWhvyCfrpVEFiYCjtFrHaJZtt.ProcessNewEvents())
			{
				IBgVnTQMOcExZFLDMffxOXibaKdLA(ref P_0, ref PirJWhvyCfrpVEFiYCjtFrHaJZtt.currentEvent);
				for (int i = 0; i < 15; i++)
				{
					FIqcWdZNNfrCDgUvGqnVgbtVFHFl.SetValue(i, KXJdWAAUxLBpMBYcIbLVuKxtomne((int)P_0.cSTdYhCfOIlkyjUlxiceJHSyagLSA, i), PirJWhvyCfrpVEFiYCjtFrHaJZtt.currentEvent.GetTimestamp());
				}
			}
		}

		private void vSAUCjAtfcslMESvUHCfrrjYakZL(ref KwLFwWWKyvWXyoQWCPtDBogWXkmP P_0, double P_1, LowLevelInputEvent P_2)
		{
			P_2.SetTimestamp(P_1);
			int cSTdYhCfOIlkyjUlxiceJHSyagLSA = (int)P_0.cSTdYhCfOIlkyjUlxiceJHSyagLSA;
			P_2.SetButtonsBitMask((cSTdYhCfOIlkyjUlxiceJHSyagLSA & 0x7FF) | ((cSTdYhCfOIlkyjUlxiceJHSyagLSA & (cSTdYhCfOIlkyjUlxiceJHSyagLSA & -4096)) >> 1), 0);
			P_2.SetAxisValue(0, ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(P_0.CzuCVsZkpSKDosLOsezXUOXPomNI));
			P_2.SetAxisValue(1, ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(P_0.eGUcMdLMelxbHAjzVlvoKihhNMDP));
			P_2.SetAxisValue(2, ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(P_0.owAqmSzHlxlGDLHsNDmtbOVrryMdA));
			P_2.SetAxisValue(3, ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(P_0.GizhhenNHKGkvhQLQxvWiPIhvrxvA));
			P_2.SetAxisValue(4, IxmDarhiptkJlWnBGteATRHaUaONA(P_0.uomPdVhcfRwHqwxnQChGTrDEWgYo));
			P_2.SetAxisValue(5, IxmDarhiptkJlWnBGteATRHaUaONA(P_0.WRydEHyKeHXYmnwYdTjudHETOFtU));
		}

		private void IBgVnTQMOcExZFLDMffxOXibaKdLA(ref KwLFwWWKyvWXyoQWCPtDBogWXkmP P_0, ref LowLevelInputEvent P_1)
		{
			int buttonsBitMask = P_1.GetButtonsBitMask(0);
			P_0.cSTdYhCfOIlkyjUlxiceJHSyagLSA = (FeToqdkGuxqmCOfisNUppgXYBHhZ)((buttonsBitMask & 0x7FF) | ((buttonsBitMask & (buttonsBitMask & -2048)) << 1));
			P_0.CzuCVsZkpSKDosLOsezXUOXPomNI = (short)(P_1.GetAxisValue(0) * 32768f);
			P_0.eGUcMdLMelxbHAjzVlvoKihhNMDP = (short)(P_1.GetAxisValue(1) * 32768f);
			P_0.owAqmSzHlxlGDLHsNDmtbOVrryMdA = (short)(P_1.GetAxisValue(2) * 32768f);
			P_0.GizhhenNHKGkvhQLQxvWiPIhvrxvA = (short)(P_1.GetAxisValue(3) * 32768f);
			P_0.uomPdVhcfRwHqwxnQChGTrDEWgYo = (byte)(P_1.GetAxisValue(4) * 255f);
			P_0.WRydEHyKeHXYmnwYdTjudHETOFtU = (byte)(P_1.GetAxisValue(5) * 255f);
		}

		private static bool KXJdWAAUxLBpMBYcIbLVuKxtomne(int P_0, int P_1)
		{
			if (P_1 > 10)
			{
				P_1++;
			}
			return (P_0 & (1 << P_1)) != 0;
		}

		private void clOavfCHpNeTPfcwzgPdNbzmHFpz()
		{
			lock (cCndHwpyhmiyUcAhGQdqlqtbgioX)
			{
				DjeEgPODUVXTfazkakXFdZXdoFNE = default(KwLFwWWKyvWXyoQWCPtDBogWXkmP);
				jXmfNGvxZHqvDwatGppJrtiFcOXV = default(KwLFwWWKyvWXyoQWCPtDBogWXkmP);
				FIqcWdZNNfrCDgUvGqnVgbtVFHFl.Clear();
				PirJWhvyCfrpVEFiYCjtFrHaJZtt.Clear();
			}
		}

		public void Dispose()
		{
			hIlanWXkrCYfgvCyascUuCUOCBcL(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
		{
			try
			{
				hIlanWXkrCYfgvCyascUuCUOCBcL(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
		{
			if (!TExNvhkEWsBWipIUjadCDaTpNNDG)
			{
				if (P_0)
				{
					PirJWhvyCfrpVEFiYCjtFrHaJZtt.Dispose();
				}
				TExNvhkEWsBWipIUjadCDaTpNNDG = true;
			}
		}

		public static float ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 32768f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		public static float IxmDarhiptkJlWnBGteATRHaUaONA(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 255f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private static bool lsLJccfJgrWYSkQiBhsoxKcyTvDA(KwLFwWWKyvWXyoQWCPtDBogWXkmP P_0, KwLFwWWKyvWXyoQWCPtDBogWXkmP P_1)
		{
			if (P_0.cSTdYhCfOIlkyjUlxiceJHSyagLSA == P_1.cSTdYhCfOIlkyjUlxiceJHSyagLSA && P_0.uomPdVhcfRwHqwxnQChGTrDEWgYo == P_1.uomPdVhcfRwHqwxnQChGTrDEWgYo && P_0.WRydEHyKeHXYmnwYdTjudHETOFtU == P_1.WRydEHyKeHXYmnwYdTjudHETOFtU && P_0.CzuCVsZkpSKDosLOsezXUOXPomNI == P_1.CzuCVsZkpSKDosLOsezXUOXPomNI && P_0.eGUcMdLMelxbHAjzVlvoKihhNMDP == P_1.eGUcMdLMelxbHAjzVlvoKihhNMDP && P_0.owAqmSzHlxlGDLHsNDmtbOVrryMdA == P_1.owAqmSzHlxlGDLHsNDmtbOVrryMdA)
			{
				return P_0.GizhhenNHKGkvhQLQxvWiPIhvrxvA == P_1.GizhhenNHKGkvhQLQxvWiPIhvrxvA;
			}
			return false;
		}
	}

	public enum spbeDCiOjyKxwEbuAMzSFPUGbPmwc
	{
		Synchronous = 0,
		Asynchronous = 1
	}

	public const int mejiqteeOsxfZoujljyvJGGevdsk = 4;

	public const int UMkzIFAyRhbDzpzRoBTvdRPXCTSe = 32768;

	public const int ZwRPMGiQPRctetiawAZAsEHriaxj = -32768;

	public const int VHBpbSIToXaMVoqGhSTUYDDHktd = 255;

	public const int qBHEGbciRoESMdlFuIrIooubgbapA = 0;

	public const int tWFPKahYBLfpSZUuReObMBOzCQhZ = 18;

	public const int GuIGWhAcpbFSaBkoLDfNlASqfoYdA = 14;

	public const int fkGFHROLTZEkcsRyRXJEmEByGUrm = 6;

	public const int MyKlXhaAcChYIUwXqJIsnWdPGdMB = 15;

	private ACOcLkgGurhTOYETKAjhVHJlVlLe[] RHKEWKctABMVYyFOglRsKLBCyFRtA;

	private bool orcHwwUjlcDiYVGkjHxZAkDgQZSHA;

	private SsVMxtTTqojwOMnYBCShhuTLqsTt MuUAjHLdcEGPlcGBmobwdVpuEYRj;

	private drnOdHnekozxRkzqNvGrccuYvPPv MCeEFHtwKtTNwyWoYGpJogRmYkuS;

	private rYcHdEeFHXdSOaPSvrmsYhfAgjun<bool> ENyIOUKJlvWrpqqmOrdSzhznfOFI;

	private bool[] EaSETHUiUnHKfLEepQiUHEPsZvgi;

	private bool[] tUsDyFHiZQaTqKfWBLTTlGDVenpzA;

	private bool QsjrNMZqcorlgZdpqcVmiyybgFwaA;

	private readonly bool yzbCRBIOQWyHDDurgheyztjtnHHNA;

	private readonly UpdateLoopSetting ytCcFeAijSeIwHLedhGDhZrEkmKS;

	private UpdateLoopType FgDbimaWffRoYLppBYTPvDhnttby;

	private UpdateLoopType jxnAMGwkASCMEhcUQhOdeQENAzCj;

	private Action<int, ControllerDataUpdater> gIbTlsSrKDMpanbmCiYbwdiijXPD;

	private bool bGpwFckAaXMUNjifpUbFQuwZoRFj;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> TGhMfMpddOgpnflvcRUCHgmAPREiA;

	private Func<int> CGMcJfJcoaSZisGLhxSsARZLqayx;

	private static Guid[] UAWrCmjPQNfKduCIpYhURWxlvtIj;

	private static string[] mhQeHpAXrRQzsaRNCQzbThRvIjyqA;

	private static string[] uUWfNASqBUsGxDWhwUAXRFyLQiGJ;

	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (RHKEWKctABMVYyFOglRsKLBCyFRtA[i].BsTbQiLDoBaYGMAdfeupOTOZRNIo)
				{
					num++;
				}
			}
			return num;
		}
	}

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => this;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => null;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.XInput;

	public AlBcJmeoydKHZKsNzaymBkJbpJeM(bool P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3)
	{
		yzbCRBIOQWyHDDurgheyztjtnHHNA = P_0;
		ytCcFeAijSeIwHLedhGDhZrEkmKS = P_1;
		bGpwFckAaXMUNjifpUbFQuwZoRFj = true;
		try
		{
			if (!jltqidpcseDngtzbGSRBkcseLdeY.zcRemXbcLIzabLElYDpEOtQwSsSV(out var vptKaDMnFSuEIXNdBaSgiToTnjpHb2, out var text, out var _))
			{
				throw new Exception("XInput is not available.");
			}
			if (vptKaDMnFSuEIXNdBaSgiToTnjpHb2 < vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_3)
			{
				Rewired.Logger.LogWarning("The version of XInput (" + text + ") detected on your system is out of date. Please update to the latest version of XInput. Input will still function, but all features may not be available. See the documentation for required dependencies.");
			}
			else
			{
				_ = 4;
			}
			TGhMfMpddOgpnflvcRUCHgmAPREiA = P_2;
			CGMcJfJcoaSZisGLhxSsARZLqayx = P_3;
			QsjrNMZqcorlgZdpqcVmiyybgFwaA = UnityTools.platform == Platform.WindowsAppStore;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(ytCcFeAijSeIwHLedhGDhZrEkmKS, list);
				int num2 = 0;
				if (num2 < list.Count)
				{
					jxnAMGwkASCMEhcUQhOdeQENAzCj = list[num2];
				}
			}
			ENyIOUKJlvWrpqqmOrdSzhznfOFI = new rYcHdEeFHXdSOaPSvrmsYhfAgjun<bool>(true, UskDTljVuwcMxmYIAFRkMVXlnAiFb);
			EaSETHUiUnHKfLEepQiUHEPsZvgi = new bool[4];
			tUsDyFHiZQaTqKfWBLTTlGDVenpzA = new bool[4];
			gIbTlsSrKDMpanbmCiYbwdiijXPD = UpdateControllerData;
			if (QsjrNMZqcorlgZdpqcVmiyybgFwaA)
			{
				LvDYeWUNZcrGdlGoaAMNtnmeBIDJA();
			}
		}
		catch (Exception)
		{
			OnDestroy();
			throw;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (bGpwFckAaXMUNjifpUbFQuwZoRFj)
		{
			MuUAjHLdcEGPlcGBmobwdVpuEYRj = new SsVMxtTTqojwOMnYBCShhuTLqsTt(1f);
		}
		MCeEFHtwKtTNwyWoYGpJogRmYkuS = new drnOdHnekozxRkzqNvGrccuYvPPv();
		if (RHKEWKctABMVYyFOglRsKLBCyFRtA == null)
		{
			RHKEWKctABMVYyFOglRsKLBCyFRtA = new ACOcLkgGurhTOYETKAjhVHJlVlLe[4];
			for (int i = 0; i < 4; i++)
			{
				MXjQTSwfhbbDAHCCQVSmWHvmqHDp mXjQTSwfhbbDAHCCQVSmWHvmqHDp = new MXjQTSwfhbbDAHCCQVSmWHvmqHDp(i, ytCcFeAijSeIwHLedhGDhZrEkmKS);
				FAsHqxeBatkZAlvOYNBwGTMPNyEq.BMQiaDhybxWjplrhGBweujjxXQSA.ThreadUpdateEvent += mXjQTSwfhbbDAHCCQVSmWHvmqHDp.hmnJKqrTZQrMgrqfnuUGuVMzamsB;
				FAsHqxeBatkZAlvOYNBwGTMPNyEq.svZOfWRkbIfRnkonNMcLizvfKloK.ThreadUpdateEvent += mXjQTSwfhbbDAHCCQVSmWHvmqHDp.KWiFoHHELyoSUiDkTBtUYnuMVsIg;
				RHKEWKctABMVYyFOglRsKLBCyFRtA[i] = new ACOcLkgGurhTOYETKAjhVHJlVlLe(i, QsjrNMZqcorlgZdpqcVmiyybgFwaA, mXjQTSwfhbbDAHCCQVSmWHvmqHDp, TGhMfMpddOgpnflvcRUCHgmAPREiA, SystemDeviceDisconnected);
			}
		}
		EKKGftFTATKBfkkxOyoOwvhqVVDZ(true);
		Update(UpdateLoopType.Update);
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		FgDbimaWffRoYLppBYTPvDhnttby = currentUpdateLoop;
		HODzlMaPftnmgXcYnyuSBkYqAMTg();
		for (int i = 0; i < 4; i++)
		{
			if (RHKEWKctABMVYyFOglRsKLBCyFRtA[i] != null && RHKEWKctABMVYyFOglRsKLBCyFRtA[i].BsTbQiLDoBaYGMAdfeupOTOZRNIo)
			{
				RHKEWKctABMVYyFOglRsKLBCyFRtA[i].Update();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (ENyIOUKJlvWrpqqmOrdSzhznfOFI != null)
		{
			ENyIOUKJlvWrpqqmOrdSzhznfOFI.hIlanWXkrCYfgvCyascUuCUOCBcL();
		}
		if (RHKEWKctABMVYyFOglRsKLBCyFRtA != null)
		{
			for (int i = 0; i < 4; i++)
			{
				if (RHKEWKctABMVYyFOglRsKLBCyFRtA[i] != null)
				{
					if (FAsHqxeBatkZAlvOYNBwGTMPNyEq.BMQiaDhybxWjplrhGBweujjxXQSA != null)
					{
						FAsHqxeBatkZAlvOYNBwGTMPNyEq.BMQiaDhybxWjplrhGBweujjxXQSA.ThreadUpdateEvent -= RHKEWKctABMVYyFOglRsKLBCyFRtA[i].UOFqirErmvMNabjsFWtrdaqLdGmG.hmnJKqrTZQrMgrqfnuUGuVMzamsB;
					}
					if (FAsHqxeBatkZAlvOYNBwGTMPNyEq.svZOfWRkbIfRnkonNMcLizvfKloK != null)
					{
						FAsHqxeBatkZAlvOYNBwGTMPNyEq.svZOfWRkbIfRnkonNMcLizvfKloK.ThreadUpdateEvent -= RHKEWKctABMVYyFOglRsKLBCyFRtA[i].UOFqirErmvMNabjsFWtrdaqLdGmG.KWiFoHHELyoSUiDkTBtUYnuMVsIg;
					}
					RHKEWKctABMVYyFOglRsKLBCyFRtA[i].Dispose();
				}
			}
		}
		jltqidpcseDngtzbGSRBkcseLdeY.LAhexqcezVSVmKRXymkcEAngYMQCc();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return gIbTlsSrKDMpanbmCiYbwdiijXPD;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		RHKEWKctABMVYyFOglRsKLBCyFRtA[assignedControllerId].FillData(data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		EKKGftFTATKBfkkxOyoOwvhqVVDZ(true);
		GwmBgWEpbYsvqdOkWUdOQtmTYRwcA();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		EKKGftFTATKBfkkxOyoOwvhqVVDZ(true);
		GwmBgWEpbYsvqdOkWUdOQtmTYRwcA();
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return null;
	}

	private bool qyHzFXSDmtAGFCqTkJTvyeuVGtxEb()
	{
		if (FgDbimaWffRoYLppBYTPvDhnttby != jxnAMGwkASCMEhcUQhOdeQENAzCj)
		{
			return false;
		}
		bool num = MuUAjHLdcEGPlcGBmobwdVpuEYRj.cmTGFsRmXJEFbLoGhVUXbOoqUnNg();
		if (num)
		{
			EKKGftFTATKBfkkxOyoOwvhqVVDZ(true);
		}
		return num;
	}

	private void EKKGftFTATKBfkkxOyoOwvhqVVDZ(bool P_0)
	{
		orcHwwUjlcDiYVGkjHxZAkDgQZSHA = P_0;
		if (bGpwFckAaXMUNjifpUbFQuwZoRFj)
		{
			MuUAjHLdcEGPlcGBmobwdVpuEYRj.pBzxWNdMLjyMGydncxVfXziaTAvG();
		}
	}

	private void GwmBgWEpbYsvqdOkWUdOQtmTYRwcA()
	{
		if (ENyIOUKJlvWrpqqmOrdSzhznfOFI != null)
		{
			ENyIOUKJlvWrpqqmOrdSzhznfOFI.PNnwosyJbZAkbwObisgdtMytZJol();
		}
	}

	private void LvDYeWUNZcrGdlGoaAMNtnmeBIDJA()
	{
		_ = new MfBGKQHiQJSofUpHMtinVyKcMQYE().HssrrySHiNxIjRzaAsLIdCHlpsIn;
	}

	private void HODzlMaPftnmgXcYnyuSBkYqAMTg()
	{
		bool flag = false;
		if (bGpwFckAaXMUNjifpUbFQuwZoRFj)
		{
			flag = qyHzFXSDmtAGFCqTkJTvyeuVGtxEb();
		}
		if (!flag && orcHwwUjlcDiYVGkjHxZAkDgQZSHA)
		{
			uQeknhtHZKZGbdImFYXLXKrceswr(GRxsuRCjpsLelMewERlAGDzQQnRC());
			EKKGftFTATKBfkkxOyoOwvhqVVDZ(false);
			GwmBgWEpbYsvqdOkWUdOQtmTYRwcA();
			return;
		}
		if (orcHwwUjlcDiYVGkjHxZAkDgQZSHA)
		{
			tfrLabgoapHNWyuiuIOXOGTDsOhd();
		}
		if (ENyIOUKJlvWrpqqmOrdSzhznfOFI.FjVRScdpFKyLClYRKhdeqgbPmktV && ENyIOUKJlvWrpqqmOrdSzhznfOFI.FAEdLIDaqiJrNwIazMvgidHfLWFNA())
		{
			ijTbKadNXkDMqiCyFnZVNwlMceYRb();
		}
	}

	private void tfrLabgoapHNWyuiuIOXOGTDsOhd()
	{
		orcHwwUjlcDiYVGkjHxZAkDgQZSHA = false;
		if (!ENyIOUKJlvWrpqqmOrdSzhznfOFI.FjVRScdpFKyLClYRKhdeqgbPmktV)
		{
			ENyIOUKJlvWrpqqmOrdSzhznfOFI.mPdlIFqjoxqpXUXmLokOkbcVfbGkA();
		}
	}

	private void ijTbKadNXkDMqiCyFnZVNwlMceYRb()
	{
		lock (EaSETHUiUnHKfLEepQiUHEPsZvgi)
		{
			Array.Copy(EaSETHUiUnHKfLEepQiUHEPsZvgi, tUsDyFHiZQaTqKfWBLTTlGDVenpzA, 4);
		}
		uQeknhtHZKZGbdImFYXLXKrceswr(tUsDyFHiZQaTqKfWBLTTlGDVenpzA);
	}

	private bool UskDTljVuwcMxmYIAFRkMVXlnAiFb()
	{
		lock (EaSETHUiUnHKfLEepQiUHEPsZvgi)
		{
			for (int i = 0; i < 4; i++)
			{
				if (RHKEWKctABMVYyFOglRsKLBCyFRtA[i] != null)
				{
					EaSETHUiUnHKfLEepQiUHEPsZvgi[i] = RHKEWKctABMVYyFOglRsKLBCyFRtA[i].dXWPcvhfowRxKmrxYQyXsyoYkCGo(spbeDCiOjyKxwEbuAMzSFPUGbPmwc.Synchronous);
				}
			}
		}
		return true;
	}

	private bool[] GRxsuRCjpsLelMewERlAGDzQQnRC()
	{
		for (int i = 0; i < 4; i++)
		{
			tUsDyFHiZQaTqKfWBLTTlGDVenpzA[i] = RHKEWKctABMVYyFOglRsKLBCyFRtA[i].dXWPcvhfowRxKmrxYQyXsyoYkCGo(spbeDCiOjyKxwEbuAMzSFPUGbPmwc.Synchronous);
		}
		return tUsDyFHiZQaTqKfWBLTTlGDVenpzA;
	}

	private void uQeknhtHZKZGbdImFYXLXKrceswr(bool[] P_0)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (RHKEWKctABMVYyFOglRsKLBCyFRtA[i] != null && RHKEWKctABMVYyFOglRsKLBCyFRtA[i].AwCtvCYsTuZCenQqibbhoKFTILPf)
			{
				bool flag = P_0[i];
				RHKEWKctABMVYyFOglRsKLBCyFRtA[i].mTfufOEOomEvhlwobtrEajOXjzGz(flag);
				if (!flag)
				{
					RlrkdWyAazsPUoHZdgVMpdPwxjfg(RHKEWKctABMVYyFOglRsKLBCyFRtA[i], false);
				}
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (RHKEWKctABMVYyFOglRsKLBCyFRtA[j] != null && !RHKEWKctABMVYyFOglRsKLBCyFRtA[j].AwCtvCYsTuZCenQqibbhoKFTILPf)
			{
				bool flag2 = P_0[j];
				RHKEWKctABMVYyFOglRsKLBCyFRtA[j].mTfufOEOomEvhlwobtrEajOXjzGz(flag2);
				if (flag2 && !RlrkdWyAazsPUoHZdgVMpdPwxjfg(RHKEWKctABMVYyFOglRsKLBCyFRtA[j], true))
				{
					num |= ((j == 0) ? 1 : (1 << j));
				}
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (RHKEWKctABMVYyFOglRsKLBCyFRtA[k] != null)
			{
				int num2 = ((k == 0) ? 1 : (1 << k));
				if ((num & num2) != 1 << k)
				{
					RHKEWKctABMVYyFOglRsKLBCyFRtA[k].dcVdxJdzxMZSZROeXTVCUmflVKQLA(P_0[k]);
				}
			}
		}
	}

	private bool RlrkdWyAazsPUoHZdgVMpdPwxjfg(ACOcLkgGurhTOYETKAjhVHJlVlLe P_0, bool P_1)
	{
		if (P_1)
		{
			P_0.OJJbNGKbXLBCewpyECSlTIZgSEyK();
			if (!P_0.khuHbEfjZduWJkBMZYZFiKyXZnzg)
			{
				return false;
			}
			int num = MCeEFHtwKtTNwyWoYGpJogRmYkuS.RDCzMSHXWFyViTJuihvIPriROuje(P_0.ClGfQcfYdCIhmkzaBYYhpMItsoDGA, false);
			if (num >= 0)
			{
				P_0.rewiredId = MCeEFHtwKtTNwyWoYGpJogRmYkuS.kmLZxaQvWLsuVMFWfYLXcOOTRCpK(num);
				MCeEFHtwKtTNwyWoYGpJogRmYkuS.cmTGFsRmXJEFbLoGhVUXbOoqUnNg(num, P_0, true);
			}
			else
			{
				P_0.rewiredId = CGMcJfJcoaSZisGLhxSsARZLqayx();
				MCeEFHtwKtTNwyWoYGpJogRmYkuS.ZFKolpVPgjBQcEcyTyAveVytVnXCA(P_0, true);
			}
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(P_0));
			}
			BridgedController obj = P_0.ToBridgedController();
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(obj);
			}
		}
		else
		{
			int num2 = MCeEFHtwKtTNwyWoYGpJogRmYkuS.aTrbXeANmagDWpbUFhssjZPOGFfnA(P_0.rewiredId, P_0.ClGfQcfYdCIhmkzaBYYhpMItsoDGA, true);
			if (num2 >= 0)
			{
				MCeEFHtwKtTNwyWoYGpJogRmYkuS.FnXFcueWFLyfBmuxQPrWRwBTYuRk(num2, false);
			}
			ControllerDisconnectedEventArgs obj2 = P_0.ToControllerDisconnectedEventArgs();
			P_0.tSwwwFGareGchBJHJUQeejanEedLA();
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(obj2);
			}
		}
		return true;
	}

	static AlBcJmeoydKHZKsNzaymBkJbpJeM()
	{
		UAWrCmjPQNfKduCIpYhURWxlvtIj = new Guid[2]
		{
			new Guid("72100955-0000-0000-0000-504944564944"),
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		mhQeHpAXrRQzsaRNCQzbThRvIjyqA = new string[1] { "Xbox Bluetooth Gamepad" };
		uUWfNASqBUsGxDWhwUAXRFyLQiGJ = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool xRVGrgIyFzerNsjGEJEreivMIxvpA(string P_0, string P_1, string P_2, Guid P_3)
	{
		if (ArrayTools.Contains(UAWrCmjPQNfKduCIpYhURWxlvtIj, P_3))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < mhQeHpAXrRQzsaRNCQzbThRvIjyqA.Length; i++)
			{
				if (P_1.Equals(mhQeHpAXrRQzsaRNCQzbThRvIjyqA[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		if (!string.IsNullOrEmpty(P_2))
		{
			for (int j = 0; j < uUWfNASqBUsGxDWhwUAXRFyLQiGJ.Length; j++)
			{
				if (Regex.IsMatch(P_2, uUWfNASqBUsGxDWhwUAXRFyLQiGJ[j], RegexOptions.IgnoreCase))
				{
					return true;
				}
			}
		}
		P_0 = P_0.ToLower();
		int num = P_0.IndexOf("vid_");
		if (num < 0)
		{
			return false;
		}
		if (P_0.IndexOf("ig_") < num)
		{
			return false;
		}
		return true;
	}
}
