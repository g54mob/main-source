using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal sealed class zzRRrbuQaUGboReIDmRemUJRstYN : IElementIdentifierTool
{
	private Rewired.Internal.GUIText mbeIRHcQONrucZIkBOdnnjftBThhA;

	private string DqBpiFDwiEfpwczWeshqxycErVnW;

	private int uMhTuyNxOwVrayZbmJHZTnrfRMiA;

	private tQhzEkPAiyaHrgrdhRCmrtbuAchaA SVkStJybSBJVOWFYHagNdNDSznJuA;

	private anbhbdfzsmouOkCCbStpOglBHmiHb OJKmILhVYlHHIVCoDhDQhDsAuZKRA;

	private Guid AjUDpVAZchKYBtYzFwWoaFJcccFNA;

	private IList<oAfWbvFtzBgLaRIiknILWPaYvJGR> rSGZdIyRdjZoQTUaJLKehbuKfRrG;

	private IList<oAfWbvFtzBgLaRIiknILWPaYvJGR> bJpFaATuhiHxBtalZuMomYWzGfLh;

	private bool kmsqsmpcTlGOskLSdWjSWiwSfXzDA;

	private bool mScSCyJnDpHdyqGRYOaYCjogcppFA;

	private bool scxcDOONEDOAzgQeZaJQstLpJUPN;

	private int STVzJzvZUDyrsGvJjpRyMIBDoAKB;

	private TimerRealTime ewwfTvfrXWNkQMIgiwMTJWfnYmCUA;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		mbeIRHcQONrucZIkBOdnnjftBThhA = text;
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
		else if (ReInput.primaryInputManager.inputSource is InputSourceWrapper<tQhzEkPAiyaHrgrdhRCmrtbuAchaA> { source: not null } inputSourceWrapper)
		{
			SVkStJybSBJVOWFYHagNdNDSznJuA = inputSourceWrapper.source;
			ReInput.primaryInputManager.SystemDeviceConnectedEvent += QGkXmQxeSgxKnxeqaQRIZMHaLQEG;
			ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += KkHGlGmlgMXUHUifgkKDQHuMFXnQ;
			ewwfTvfrXWNkQMIgiwMTJWfnYmCUA = new TimerRealTime(1.0);
			ewwfTvfrXWNkQMIgiwMTJWfnYmCUA.Start();
			GOVEYPdxZMgXCAfttjLGxjqcEZmB();
			scxcDOONEDOAzgQeZaJQstLpJUPN = true;
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
		if (!scxcDOONEDOAzgQeZaJQstLpJUPN)
		{
			return;
		}
		DqBpiFDwiEfpwczWeshqxycErVnW = "Direct Input Joystick Element Identifier\n\n";
		mbeIRHcQONrucZIkBOdnnjftBThhA.text = DqBpiFDwiEfpwczWeshqxycErVnW;
		if (Input.GetKeyDown(KeyCode.A))
		{
			kmsqsmpcTlGOskLSdWjSWiwSfXzDA = !kmsqsmpcTlGOskLSdWjSWiwSfXzDA;
		}
		if (kmsqsmpcTlGOskLSdWjSWiwSfXzDA)
		{
			mbeIRHcQONrucZIkBOdnnjftBThhA.text += "All Devices:\n";
			foreach (oAfWbvFtzBgLaRIiknILWPaYvJGR item in bJpFaATuhiHxBtalZuMomYWzGfLh)
			{
				Rewired.Internal.GUIText gUIText = mbeIRHcQONrucZIkBOdnnjftBThhA;
				gUIText.text = gUIText.text + item.psVmskHZzblxuamlundDsEQNHEjW + ", " + item.FFdPGINVALSvaASyljVGFpHBlOLn + ", " + new PidVid(item.yPlEBmQDdIgFczWAPigatngdjYFF).ToString() + ", " + item.JMpqktIGzbeRYPBkimpLzZvMUDTI + ", " + item.AaxSvBIJGptkHBQjnsztPHrlWpzn + ", " + item.ieSpusZtTvEbYkziujkOQiBSFxMBA + "\n";
			}
			mbeIRHcQONrucZIkBOdnnjftBThhA.text += "\n";
		}
		int num = uMhTuyNxOwVrayZbmJHZTnrfRMiA;
		Guid ajUDpVAZchKYBtYzFwWoaFJcccFNA = AjUDpVAZchKYBtYzFwWoaFJcccFNA;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			uMhTuyNxOwVrayZbmJHZTnrfRMiA++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			uMhTuyNxOwVrayZbmJHZTnrfRMiA--;
		}
		if (ewwfTvfrXWNkQMIgiwMTJWfnYmCUA.Update())
		{
			int num2 = SVkStJybSBJVOWFYHagNdNDSznJuA.YYlJGBUmAucmJnDNlzGpnPFGtCMV(OaagXIZrfeDFhvWXSIZbhwFlMfQK.All, eMAFjwbvQxnHIqzOYhMTOmlFgCfn.AttachedOnly);
			if (num2 != STVzJzvZUDyrsGvJjpRyMIBDoAKB)
			{
				STVzJzvZUDyrsGvJjpRyMIBDoAKB = num2;
				mScSCyJnDpHdyqGRYOaYCjogcppFA = true;
			}
			ewwfTvfrXWNkQMIgiwMTJWfnYmCUA.Start();
		}
		if (mScSCyJnDpHdyqGRYOaYCjogcppFA)
		{
			GOVEYPdxZMgXCAfttjLGxjqcEZmB();
			mScSCyJnDpHdyqGRYOaYCjogcppFA = false;
		}
		int num3 = ((rSGZdIyRdjZoQTUaJLKehbuKfRrG != null) ? rSGZdIyRdjZoQTUaJLKehbuKfRrG.Count : 0);
		if (num3 == 0)
		{
			return;
		}
		if (uMhTuyNxOwVrayZbmJHZTnrfRMiA < 0)
		{
			uMhTuyNxOwVrayZbmJHZTnrfRMiA = num3 - 1;
		}
		else if (uMhTuyNxOwVrayZbmJHZTnrfRMiA >= num3)
		{
			uMhTuyNxOwVrayZbmJHZTnrfRMiA = 0;
		}
		AjUDpVAZchKYBtYzFwWoaFJcccFNA = rSGZdIyRdjZoQTUaJLKehbuKfRrG[uMhTuyNxOwVrayZbmJHZTnrfRMiA].KzwkcdaJgmrrHxFfbAIZCYxqvfXZ;
		bool flag = false;
		if (num != uMhTuyNxOwVrayZbmJHZTnrfRMiA || ajUDpVAZchKYBtYzFwWoaFJcccFNA != AjUDpVAZchKYBtYzFwWoaFJcccFNA)
		{
			flag = true;
		}
		if (OJKmILhVYlHHIVCoDhDQhDsAuZKRA == null || flag)
		{
			if (OJKmILhVYlHHIVCoDhDQhDsAuZKRA != null)
			{
				OJKmILhVYlHHIVCoDhDQhDsAuZKRA.qUSLHdlhISyIgybstyFDACYBVvCc();
			}
			OJKmILhVYlHHIVCoDhDQhDsAuZKRA = new anbhbdfzsmouOkCCbStpOglBHmiHb(SVkStJybSBJVOWFYHagNdNDSznJuA, rSGZdIyRdjZoQTUaJLKehbuKfRrG[uMhTuyNxOwVrayZbmJHZTnrfRMiA].KzwkcdaJgmrrHxFfbAIZCYxqvfXZ);
			if (OJKmILhVYlHHIVCoDhDQhDsAuZKRA == null)
			{
				return;
			}
			IList<PyvhEXOOIhgSeIwyAsaBOIoxukWy> list = OJKmILhVYlHHIVCoDhDQhDsAuZKRA.eVgvcOjHtltmfBoVtaXBosCZZLtf();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if ((list[i].rIJOgGdoahKmEQbbieuTfbHeEGPAA.pGDeHoojINfTkjqOcpkEWPcgsbLeA & vSIYNxlhLuRVvxutxhRoERRIotdU.Axis) != vSIYNxlhLuRVvxutxhRoERRIotdU.All)
					{
						OJKmILhVYlHHIVCoDhDQhDsAuZKRA.hVGspDTKQbBpKbSbBEbmoAmxyKlmA.qTLFClLwrsoQgWHqGfHWrpakJzwF = new KWcqbYjQsKhCDApIfHPKAlCTmmekA(-65535, 65535);
					}
				}
			}
			OJKmILhVYlHHIVCoDhDQhDsAuZKRA.JFtgQeubYmhwWhIMlgFUXXNcOVpf();
		}
		IzQgfDkzjTmspgxWvNpFitmeknESA izQgfDkzjTmspgxWvNpFitmeknESA;
		try
		{
			izQgfDkzjTmspgxWvNpFitmeknESA = OJKmILhVYlHHIVCoDhDQhDsAuZKRA.UtWqqHTGAXkikFWVTMttxatLIbbv();
		}
		catch
		{
			izQgfDkzjTmspgxWvNpFitmeknESA = null;
		}
		if (izQgfDkzjTmspgxWvNpFitmeknESA == null)
		{
			return;
		}
		if (num3 > 0)
		{
			DqBpiFDwiEfpwczWeshqxycErVnW = DqBpiFDwiEfpwczWeshqxycErVnW + num3 + " connected devices:\n";
		}
		for (int j = 0; j < num3; j++)
		{
			DqBpiFDwiEfpwczWeshqxycErVnW = DqBpiFDwiEfpwczWeshqxycErVnW + rSGZdIyRdjZoQTUaJLKehbuKfRrG[j].psVmskHZzblxuamlundDsEQNHEjW + "\n";
		}
		DqBpiFDwiEfpwczWeshqxycErVnW += "\n";
		DqBpiFDwiEfpwczWeshqxycErVnW = DqBpiFDwiEfpwczWeshqxycErVnW + "Current DI device " + uMhTuyNxOwVrayZbmJHZTnrfRMiA + ": " + rSGZdIyRdjZoQTUaJLKehbuKfRrG[uMhTuyNxOwVrayZbmJHZTnrfRMiA].psVmskHZzblxuamlundDsEQNHEjW + "\n";
		DqBpiFDwiEfpwczWeshqxycErVnW += "(Press + or - to change monitored device id.)\n\n";
		qimbDykFmxEjDnBFgzzFNTmoffzfb("Identifier", new PidVid(OJKmILhVYlHHIVCoDhDQhDsAuZKRA.bdVaajAzOxNDLwewCgAedokAZQfg.yPlEBmQDdIgFczWAPigatngdjYFF));
		qimbDykFmxEjDnBFgzzFNTmoffzfb("Instance GUID", OJKmILhVYlHHIVCoDhDQhDsAuZKRA.bdVaajAzOxNDLwewCgAedokAZQfg.KzwkcdaJgmrrHxFfbAIZCYxqvfXZ);
		qimbDykFmxEjDnBFgzzFNTmoffzfb("Product Id", OJKmILhVYlHHIVCoDhDQhDsAuZKRA.hVGspDTKQbBpKbSbBEbmoAmxyKlmA.FMguLFyIWTEbghmkaAjeiaMjEuQNA);
		qimbDykFmxEjDnBFgzzFNTmoffzfb("Device Type", OJKmILhVYlHHIVCoDhDQhDsAuZKRA.RNKyTXsPFKaezXBNcgSTeyzDkSYD.DWWObHggmqbvMJuzFzbDPNttFSrU.ToString());
		DqBpiFDwiEfpwczWeshqxycErVnW += "\n";
		qimbDykFmxEjDnBFgzzFNTmoffzfb("Axis Count", OJKmILhVYlHHIVCoDhDQhDsAuZKRA.RNKyTXsPFKaezXBNcgSTeyzDkSYD.SfuUiqbrwXRNHBrwvOpZqKYoXHay);
		qimbDykFmxEjDnBFgzzFNTmoffzfb("Button Count", OJKmILhVYlHHIVCoDhDQhDsAuZKRA.RNKyTXsPFKaezXBNcgSTeyzDkSYD.CVceVtZHyzfaUReonVZsPJOuiPIp);
		qimbDykFmxEjDnBFgzzFNTmoffzfb("Hat Count", OJKmILhVYlHHIVCoDhDQhDsAuZKRA.RNKyTXsPFKaezXBNcgSTeyzDkSYD.pVdfUEkkbRTxAIwzRWQKgBPlHpKJ);
		DqBpiFDwiEfpwczWeshqxycErVnW += "\n";
		if (flag)
		{
			Rewired.Logger.Log("Device Name: \"" + rSGZdIyRdjZoQTUaJLKehbuKfRrG[uMhTuyNxOwVrayZbmJHZTnrfRMiA].psVmskHZzblxuamlundDsEQNHEjW + "\"");
			Rewired.Logger.Log("Identifier: " + new PidVid(OJKmILhVYlHHIVCoDhDQhDsAuZKRA.bdVaajAzOxNDLwewCgAedokAZQfg.yPlEBmQDdIgFczWAPigatngdjYFF).ToString());
		}
		for (int k = 0; k < 32; k++)
		{
			int num4 = HmcLMZplrwkXprapPEdfvjiVvgvg((DirectInputAxis)k, izQgfDkzjTmspgxWvNpFitmeknESA);
			DirectInputAxis directInputAxis = (DirectInputAxis)k;
			string text = directInputAxis.ToString();
			qimbDykFmxEjDnBFgzzFNTmoffzfb(text, num4 + " (" + CaNBJpnnzmmJEMZzvbkXhesiLYKk(num4) + ")");
		}
		int[] array = izQgfDkzjTmspgxWvNpFitmeknESA.CjEnaageEMHiJpyZhSEjoCRTJnLC;
		for (int l = 0; l < 4; l++)
		{
			int num5 = array[l];
			string text2 = "Hat " + l;
			qimbDykFmxEjDnBFgzzFNTmoffzfb(text2, num5);
		}
		bool[] array2 = izQgfDkzjTmspgxWvNpFitmeknESA.anoDPUijofMmwdpNjuiyAbLOZQHHA;
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
		qimbDykFmxEjDnBFgzzFNTmoffzfb("Buttons ", text3);
		mbeIRHcQONrucZIkBOdnnjftBThhA.text = DqBpiFDwiEfpwczWeshqxycErVnW;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	private void GOVEYPdxZMgXCAfttjLGxjqcEZmB()
	{
		rSGZdIyRdjZoQTUaJLKehbuKfRrG = SVkStJybSBJVOWFYHagNdNDSznJuA.ISZAaZHIFxTftdsVBLTLCQFbqLWYA(OaagXIZrfeDFhvWXSIZbhwFlMfQK.GameControl, eMAFjwbvQxnHIqzOYhMTOmlFgCfn.AttachedOnly);
		bJpFaATuhiHxBtalZuMomYWzGfLh = SVkStJybSBJVOWFYHagNdNDSznJuA.ISZAaZHIFxTftdsVBLTLCQFbqLWYA(OaagXIZrfeDFhvWXSIZbhwFlMfQK.All, eMAFjwbvQxnHIqzOYhMTOmlFgCfn.AttachedOnly);
		STVzJzvZUDyrsGvJjpRyMIBDoAKB = ((bJpFaATuhiHxBtalZuMomYWzGfLh != null) ? bJpFaATuhiHxBtalZuMomYWzGfLh.Count : 0);
	}

	private void QGkXmQxeSgxKnxeqaQRIZMHaLQEG()
	{
		qwnJzkCaostdkqikcewiHClcfTne();
	}

	private void KkHGlGmlgMXUHUifgkKDQHuMFXnQ()
	{
		qwnJzkCaostdkqikcewiHClcfTne();
	}

	private void qwnJzkCaostdkqikcewiHClcfTne()
	{
		AXiFhgMsVnuGwGAsZfirbrlycQhHA();
		mScSCyJnDpHdyqGRYOaYCjogcppFA = true;
	}

	private void AXiFhgMsVnuGwGAsZfirbrlycQhHA()
	{
		uMhTuyNxOwVrayZbmJHZTnrfRMiA = 0;
		OJKmILhVYlHHIVCoDhDQhDsAuZKRA = null;
		AjUDpVAZchKYBtYzFwWoaFJcccFNA = Guid.Empty;
		rSGZdIyRdjZoQTUaJLKehbuKfRrG = null;
		bJpFaATuhiHxBtalZuMomYWzGfLh = null;
		kmsqsmpcTlGOskLSdWjSWiwSfXzDA = false;
		mScSCyJnDpHdyqGRYOaYCjogcppFA = false;
		STVzJzvZUDyrsGvJjpRyMIBDoAKB = 0;
	}

	private void qimbDykFmxEjDnBFgzzFNTmoffzfb(string P_0, object P_1)
	{
		DqBpiFDwiEfpwczWeshqxycErVnW = DqBpiFDwiEfpwczWeshqxycErVnW + P_0 + " = " + P_1.ToString() + "\n";
	}

	private int HmcLMZplrwkXprapPEdfvjiVvgvg(DirectInputAxis P_0, IzQgfDkzjTmspgxWvNpFitmeknESA P_1)
	{
		return P_0 switch
		{
			DirectInputAxis.X => P_1.WUWgLBZzdSHtJsNgVyVeDQwQDMRW, 
			DirectInputAxis.Y => P_1.fUNSCshvabYYSlFQlEDDDUmcSRCf, 
			DirectInputAxis.Z => P_1.aHBiMKVabkBMSbQQGrPBCusQpIVC, 
			DirectInputAxis.RotationX => P_1.cUhFMvjuFmIvVIeaGWaCRsYXnDZcA, 
			DirectInputAxis.RotationY => P_1.mSsentqWVPLijLZQEVErZiXebQgbA, 
			DirectInputAxis.RotationZ => P_1.nPSRwlwHveRxatrqLvjTXAAAjTnF, 
			DirectInputAxis.Slider0 => P_1.MqqDNzzWsJtVRfBEbBLJbbOWigtab[0], 
			DirectInputAxis.Slider1 => P_1.MqqDNzzWsJtVRfBEbBLJbbOWigtab[1], 
			DirectInputAxis.VelocityX => P_1.hmBqYGdIFIdePUrFPzZZvSKRlvhj, 
			DirectInputAxis.VelocityY => P_1.PQbvBQFGdcURMfrdJVtRGnhlxDtr, 
			DirectInputAxis.VelocityZ => P_1.MKxaZEvsDBDFmBwZWkIYIxFetzTU, 
			DirectInputAxis.AngularVelocityX => P_1.BmVuNqKTaeQiTMYYJtpHVGAZeCuA, 
			DirectInputAxis.AngularVelocityY => P_1.IJzAPVmvGJgdhcYVscuYBRfPQNVB, 
			DirectInputAxis.AngularVelocityZ => P_1.DPgGRWYyixWRILmRGevGYRmpVyDG, 
			DirectInputAxis.VelocitySlider0 => P_1.HJGMEnfWBkObtvxczCvYphWHkrJl[0], 
			DirectInputAxis.VelocitySlider1 => P_1.HJGMEnfWBkObtvxczCvYphWHkrJl[1], 
			DirectInputAxis.AccelerationX => P_1.ZWSISyKTeLjkmPOAhDhNtTNqWSkK, 
			DirectInputAxis.AccelerationY => P_1.AqPEnJCkauiInCatAlJdbEgzSwlub, 
			DirectInputAxis.AccelerationZ => P_1.GPUScCsscLNIRcoqJHnvIlnybxMEA, 
			DirectInputAxis.AngularAccelerationX => P_1.FNcyNtHMLJSpGDmjuZcGnAOcybme, 
			DirectInputAxis.AngularAccelerationY => P_1.KwNDwJphpfgBEAPhXLuXstksTVObA, 
			DirectInputAxis.AngularAccelerationZ => P_1.IvnKtIjEdjPfKVuNMFurlbPxljUX, 
			DirectInputAxis.AccelerationSlider0 => P_1.xUnEIVdijlauGELuTyMSTVBiTeTLA[0], 
			DirectInputAxis.AccelerationSlider1 => P_1.xUnEIVdijlauGELuTyMSTVBiTeTLA[1], 
			DirectInputAxis.ForceX => P_1.xUAFGlHVcGyBvtUiffmwFKMWSbWm, 
			DirectInputAxis.ForceY => P_1.BkBETNIjUBRgLbEWfDMqrAXEgFXMA, 
			DirectInputAxis.ForceZ => P_1.rrlBeEqTTHzCvwhQQJNpawJbUjeT, 
			DirectInputAxis.TorqueX => P_1.OzoapQJHcjKvcMVeKrjMmiZRugnoA, 
			DirectInputAxis.TorqueY => P_1.dDIVAKIHMAzxpflGtoDcFKhPGVEj, 
			DirectInputAxis.TorqueZ => P_1.naCGwGjFoMaMbepAyEeZOBvXRKSOA, 
			DirectInputAxis.ForceSlider0 => P_1.cFJbdSIxCCaoqcAbLxjehxKIKZbDA[0], 
			DirectInputAxis.ForceSlider1 => P_1.cFJbdSIxCCaoqcAbLxjehxKIKZbDA[1], 
			_ => 0, 
		};
	}

	private float CaNBJpnnzmmJEMZzvbkXhesiLYKk(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}

	public void OnDestroy()
	{
		if (OJKmILhVYlHHIVCoDhDQhDsAuZKRA != null)
		{
			OJKmILhVYlHHIVCoDhDQhDsAuZKRA.qUSLHdlhISyIgybstyFDACYBVvCc();
		}
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}
}
