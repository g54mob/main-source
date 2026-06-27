using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal sealed class AFVsRLyupOGKMSmPhJGuhQDXKxxq : IElementIdentifierTool
{
	private Rewired.Internal.GUIText FDeepjeiBHsFAgWztMozbypdhXSkc;

	private string uxRVItNcfWwYKzjFEPigmtwMhJOu;

	private int XBWdzMBVmWoQTlVSTMhRMvbxZjhJ;

	private MWxKeWPstqLsHiooDoLaaAhoicECA xlswrgsLYVucfRPwphPTYRiUbcNc;

	private NQheDZtFtwtPwXhJJkvldbrPekPu dfQagrbWDxgomEAfjyEMAvgGGJrkA;

	private Guid nUEhRrJmvnbtnJHynDRkClXkmcaM;

	private IList<RCbrBLDngHgaSCZnWWTNJSaCQXlM> YoSrhwwyGrsDiYBndGIkidkWfdKo;

	private IList<RCbrBLDngHgaSCZnWWTNJSaCQXlM> WXznqsZutkqYnsiezvBklICvUeiJ;

	private bool FveSULfQDffdYjXBJuGKFgQGVpUC;

	private bool BlyRcMNVUnHMUfbKyrbMRoqmUrWV;

	private bool FfaxcaQXgFfXihlUxSGZpBQpIemB;

	private int jOFTdHzdAFDRBJweBQyHVcONdcvFA;

	private TimerRealTime NSwEvVjiWGtZyZZxGJvNXOrzcnfm;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		FDeepjeiBHsFAgWztMozbypdhXSkc = text;
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
		else if (ReInput.primaryInputManager.inputSource is InputSourceWrapper<MWxKeWPstqLsHiooDoLaaAhoicECA> { source: not null } inputSourceWrapper)
		{
			xlswrgsLYVucfRPwphPTYRiUbcNc = inputSourceWrapper.source;
			ReInput.primaryInputManager.SystemDeviceConnectedEvent += zakbNexMLkCXZkfREXfYOHNuBYdj;
			ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += fxRiCwkffCmtvHkyQrmTXerCZhUG;
			NSwEvVjiWGtZyZZxGJvNXOrzcnfm = new TimerRealTime(1.0);
			NSwEvVjiWGtZyZZxGJvNXOrzcnfm.Start();
			rIJavuhziGPmjRPmZevXqRpqQKmj();
			FfaxcaQXgFfXihlUxSGZpBQpIemB = true;
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
		if (!FfaxcaQXgFfXihlUxSGZpBQpIemB)
		{
			return;
		}
		uxRVItNcfWwYKzjFEPigmtwMhJOu = "Direct Input Joystick Element Identifier\n\n";
		FDeepjeiBHsFAgWztMozbypdhXSkc.text = uxRVItNcfWwYKzjFEPigmtwMhJOu;
		if (Input.GetKeyDown(KeyCode.A))
		{
			FveSULfQDffdYjXBJuGKFgQGVpUC = !FveSULfQDffdYjXBJuGKFgQGVpUC;
		}
		if (FveSULfQDffdYjXBJuGKFgQGVpUC)
		{
			FDeepjeiBHsFAgWztMozbypdhXSkc.text += "All Devices:\n";
			foreach (RCbrBLDngHgaSCZnWWTNJSaCQXlM item in WXznqsZutkqYnsiezvBklICvUeiJ)
			{
				Rewired.Internal.GUIText fDeepjeiBHsFAgWztMozbypdhXSkc = FDeepjeiBHsFAgWztMozbypdhXSkc;
				fDeepjeiBHsFAgWztMozbypdhXSkc.text = fDeepjeiBHsFAgWztMozbypdhXSkc.text + item.QfDOMnZwbpIBMfcjGivHtILHKTYC + ", " + item.ejfXgwZzTJSKETXdVvUIQNHFgAgs + ", " + new PidVid(item.HHnyOAQmqKRfIepNrbhokTmxpHaK).ToString() + ", " + item.amhYgHQpmfLeaCvzYdGRgEvIWBql + ", " + item.xnfTVlMnVrtBrUxwNPqlISnbdbUs + ", " + item.PjQxUGDcKbwKobrxKbkIHeZUfJbK + "\n";
			}
			FDeepjeiBHsFAgWztMozbypdhXSkc.text += "\n";
		}
		int xBWdzMBVmWoQTlVSTMhRMvbxZjhJ = XBWdzMBVmWoQTlVSTMhRMvbxZjhJ;
		Guid guid = nUEhRrJmvnbtnJHynDRkClXkmcaM;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			XBWdzMBVmWoQTlVSTMhRMvbxZjhJ++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			XBWdzMBVmWoQTlVSTMhRMvbxZjhJ--;
		}
		if (NSwEvVjiWGtZyZZxGJvNXOrzcnfm.Update())
		{
			int num = xlswrgsLYVucfRPwphPTYRiUbcNc.zotaefACDkyTdrsEVrNfSgZAGGrWA(rxoCQyLeXikLCiACyHfjyDszEnHc.All, NcIhHWHlNfssiPdJoxBFHDvPFCIoA.AttachedOnly);
			if (num != jOFTdHzdAFDRBJweBQyHVcONdcvFA)
			{
				jOFTdHzdAFDRBJweBQyHVcONdcvFA = num;
				BlyRcMNVUnHMUfbKyrbMRoqmUrWV = true;
			}
			NSwEvVjiWGtZyZZxGJvNXOrzcnfm.Start();
		}
		if (BlyRcMNVUnHMUfbKyrbMRoqmUrWV)
		{
			rIJavuhziGPmjRPmZevXqRpqQKmj();
			BlyRcMNVUnHMUfbKyrbMRoqmUrWV = false;
		}
		int num2 = ((YoSrhwwyGrsDiYBndGIkidkWfdKo != null) ? YoSrhwwyGrsDiYBndGIkidkWfdKo.Count : 0);
		if (num2 == 0)
		{
			return;
		}
		if (XBWdzMBVmWoQTlVSTMhRMvbxZjhJ < 0)
		{
			XBWdzMBVmWoQTlVSTMhRMvbxZjhJ = num2 - 1;
		}
		else if (XBWdzMBVmWoQTlVSTMhRMvbxZjhJ >= num2)
		{
			XBWdzMBVmWoQTlVSTMhRMvbxZjhJ = 0;
		}
		nUEhRrJmvnbtnJHynDRkClXkmcaM = YoSrhwwyGrsDiYBndGIkidkWfdKo[XBWdzMBVmWoQTlVSTMhRMvbxZjhJ].vooZCRenfowGvkjwBdPFIBfsSrucA;
		bool flag = false;
		if (xBWdzMBVmWoQTlVSTMhRMvbxZjhJ != XBWdzMBVmWoQTlVSTMhRMvbxZjhJ || guid != nUEhRrJmvnbtnJHynDRkClXkmcaM)
		{
			flag = true;
		}
		if (dfQagrbWDxgomEAfjyEMAvgGGJrkA == null || flag)
		{
			if (dfQagrbWDxgomEAfjyEMAvgGGJrkA != null)
			{
				dfQagrbWDxgomEAfjyEMAvgGGJrkA.ZiYbrvzqaSrBafdyVkpZBZMJaFMU();
			}
			dfQagrbWDxgomEAfjyEMAvgGGJrkA = new NQheDZtFtwtPwXhJJkvldbrPekPu(xlswrgsLYVucfRPwphPTYRiUbcNc, YoSrhwwyGrsDiYBndGIkidkWfdKo[XBWdzMBVmWoQTlVSTMhRMvbxZjhJ].vooZCRenfowGvkjwBdPFIBfsSrucA);
			if (dfQagrbWDxgomEAfjyEMAvgGGJrkA == null)
			{
				return;
			}
			IList<qpzCcdMUThEhWJJvcjvJGTijXwxeb> list = dfQagrbWDxgomEAfjyEMAvgGGJrkA.LLsViclNqjIKNOhMNrWJbgYLeJGu();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if ((list[i].KZVgksxHjhfZqLxwYnjTaPVmMueh.QWXGfOKoRPqaKxdTGIdQAIsbirqIB & WVKLnHnnIsWeFoDkVmYeRlTOGpEs.Axis) != WVKLnHnnIsWeFoDkVmYeRlTOGpEs.All)
					{
						dfQagrbWDxgomEAfjyEMAvgGGJrkA.SjKSPnBOTzwGcHPolOscJNmhgYScA.TOFrNDPDewPCUZJjeaFWmDqyeJRn = new piquBkdKfEhtpTjFPXYUqGEHvoRv(-65535, 65535);
					}
				}
			}
			dfQagrbWDxgomEAfjyEMAvgGGJrkA.oBlOMMyTLkQVgySBVdHMQILwEDKk();
		}
		fEIEHzfgwHXLRiMTFeeLDuigNlxcb fEIEHzfgwHXLRiMTFeeLDuigNlxcb2;
		try
		{
			fEIEHzfgwHXLRiMTFeeLDuigNlxcb2 = dfQagrbWDxgomEAfjyEMAvgGGJrkA.hpQOAdNHaNRtYYOHbBpbapvHlnOD();
		}
		catch
		{
			fEIEHzfgwHXLRiMTFeeLDuigNlxcb2 = null;
		}
		if (fEIEHzfgwHXLRiMTFeeLDuigNlxcb2 == null)
		{
			return;
		}
		if (num2 > 0)
		{
			uxRVItNcfWwYKzjFEPigmtwMhJOu = uxRVItNcfWwYKzjFEPigmtwMhJOu + num2 + " connected devices:\n";
		}
		for (int j = 0; j < num2; j++)
		{
			uxRVItNcfWwYKzjFEPigmtwMhJOu = uxRVItNcfWwYKzjFEPigmtwMhJOu + YoSrhwwyGrsDiYBndGIkidkWfdKo[j].QfDOMnZwbpIBMfcjGivHtILHKTYC + "\n";
		}
		uxRVItNcfWwYKzjFEPigmtwMhJOu += "\n";
		uxRVItNcfWwYKzjFEPigmtwMhJOu = uxRVItNcfWwYKzjFEPigmtwMhJOu + "Current DI device " + XBWdzMBVmWoQTlVSTMhRMvbxZjhJ + ": " + YoSrhwwyGrsDiYBndGIkidkWfdKo[XBWdzMBVmWoQTlVSTMhRMvbxZjhJ].QfDOMnZwbpIBMfcjGivHtILHKTYC + "\n";
		uxRVItNcfWwYKzjFEPigmtwMhJOu += "(Press + or - to change monitored device id.)\n\n";
		PvwjfYNIzzDAhcQUWNoNGSefwjCGB("Identifier", new PidVid(dfQagrbWDxgomEAfjyEMAvgGGJrkA.IFZASJSlsdMmnninmQjaibeAuJWP.HHnyOAQmqKRfIepNrbhokTmxpHaK));
		PvwjfYNIzzDAhcQUWNoNGSefwjCGB("Instance GUID", dfQagrbWDxgomEAfjyEMAvgGGJrkA.IFZASJSlsdMmnninmQjaibeAuJWP.vooZCRenfowGvkjwBdPFIBfsSrucA);
		PvwjfYNIzzDAhcQUWNoNGSefwjCGB("Product Id", dfQagrbWDxgomEAfjyEMAvgGGJrkA.SjKSPnBOTzwGcHPolOscJNmhgYScA.alqObbwDKJKsSylNOkbghYMtuDvC);
		PvwjfYNIzzDAhcQUWNoNGSefwjCGB("Device Type", dfQagrbWDxgomEAfjyEMAvgGGJrkA.gTMAPzeAKWLVPWzSMtAZlxaTsatl.crMVBtuxxaMGgMTczHoZYYznnOSs.ToString());
		uxRVItNcfWwYKzjFEPigmtwMhJOu += "\n";
		PvwjfYNIzzDAhcQUWNoNGSefwjCGB("Axis Count", dfQagrbWDxgomEAfjyEMAvgGGJrkA.gTMAPzeAKWLVPWzSMtAZlxaTsatl.zjoRIGrKpTucrUYjNriVpXIajHDV);
		PvwjfYNIzzDAhcQUWNoNGSefwjCGB("Button Count", dfQagrbWDxgomEAfjyEMAvgGGJrkA.gTMAPzeAKWLVPWzSMtAZlxaTsatl.vRwGtTDXnbGJiUVbNyQcGtUoPLlM);
		PvwjfYNIzzDAhcQUWNoNGSefwjCGB("Hat Count", dfQagrbWDxgomEAfjyEMAvgGGJrkA.gTMAPzeAKWLVPWzSMtAZlxaTsatl.QBlDxugBsTcxwPpepXPQzCNfaXdT);
		uxRVItNcfWwYKzjFEPigmtwMhJOu += "\n";
		if (flag)
		{
			Rewired.Logger.Log("Device Name: \"" + YoSrhwwyGrsDiYBndGIkidkWfdKo[XBWdzMBVmWoQTlVSTMhRMvbxZjhJ].QfDOMnZwbpIBMfcjGivHtILHKTYC + "\"");
			Rewired.Logger.Log("Identifier: " + new PidVid(dfQagrbWDxgomEAfjyEMAvgGGJrkA.IFZASJSlsdMmnninmQjaibeAuJWP.HHnyOAQmqKRfIepNrbhokTmxpHaK).ToString());
		}
		for (int k = 0; k < 32; k++)
		{
			int num3 = ylezblrTqmBwRyfzbXXfmlbRfFSI((DirectInputAxis)k, fEIEHzfgwHXLRiMTFeeLDuigNlxcb2);
			DirectInputAxis directInputAxis = (DirectInputAxis)k;
			string text = directInputAxis.ToString();
			PvwjfYNIzzDAhcQUWNoNGSefwjCGB(text, num3 + " (" + vZkdBCxuemmqMNeTVjPTueakAjYb(num3) + ")");
		}
		int[] array = fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.vyIFxMkEvMfudkrbPAVtanSVxZeqA;
		for (int l = 0; l < 4; l++)
		{
			int num4 = array[l];
			string text2 = "Hat " + l;
			PvwjfYNIzzDAhcQUWNoNGSefwjCGB(text2, num4);
		}
		bool[] array2 = fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.NQchruvyvxIFUojERLboovROTOsS;
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
		PvwjfYNIzzDAhcQUWNoNGSefwjCGB("Buttons ", text3);
		FDeepjeiBHsFAgWztMozbypdhXSkc.text = uxRVItNcfWwYKzjFEPigmtwMhJOu;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	private void rIJavuhziGPmjRPmZevXqRpqQKmj()
	{
		YoSrhwwyGrsDiYBndGIkidkWfdKo = xlswrgsLYVucfRPwphPTYRiUbcNc.jmFjCvWVKtqWJbZYtHCFLKPdBXpCA(rxoCQyLeXikLCiACyHfjyDszEnHc.GameControl, NcIhHWHlNfssiPdJoxBFHDvPFCIoA.AttachedOnly);
		WXznqsZutkqYnsiezvBklICvUeiJ = xlswrgsLYVucfRPwphPTYRiUbcNc.jmFjCvWVKtqWJbZYtHCFLKPdBXpCA(rxoCQyLeXikLCiACyHfjyDszEnHc.All, NcIhHWHlNfssiPdJoxBFHDvPFCIoA.AttachedOnly);
		jOFTdHzdAFDRBJweBQyHVcONdcvFA = ((WXznqsZutkqYnsiezvBklICvUeiJ != null) ? WXznqsZutkqYnsiezvBklICvUeiJ.Count : 0);
	}

	private void zakbNexMLkCXZkfREXfYOHNuBYdj()
	{
		LmbxTUKRlmUYSxLbCjggOSMubpIj();
	}

	private void fxRiCwkffCmtvHkyQrmTXerCZhUG()
	{
		LmbxTUKRlmUYSxLbCjggOSMubpIj();
	}

	private void LmbxTUKRlmUYSxLbCjggOSMubpIj()
	{
		zhsEFMEUYzOnUPBlfHvpeexboGEqb();
		BlyRcMNVUnHMUfbKyrbMRoqmUrWV = true;
	}

	private void zhsEFMEUYzOnUPBlfHvpeexboGEqb()
	{
		XBWdzMBVmWoQTlVSTMhRMvbxZjhJ = 0;
		dfQagrbWDxgomEAfjyEMAvgGGJrkA = null;
		nUEhRrJmvnbtnJHynDRkClXkmcaM = Guid.Empty;
		YoSrhwwyGrsDiYBndGIkidkWfdKo = null;
		WXznqsZutkqYnsiezvBklICvUeiJ = null;
		FveSULfQDffdYjXBJuGKFgQGVpUC = false;
		BlyRcMNVUnHMUfbKyrbMRoqmUrWV = false;
		jOFTdHzdAFDRBJweBQyHVcONdcvFA = 0;
	}

	private void PvwjfYNIzzDAhcQUWNoNGSefwjCGB(string P_0, object P_1)
	{
		uxRVItNcfWwYKzjFEPigmtwMhJOu = uxRVItNcfWwYKzjFEPigmtwMhJOu + P_0 + " = " + P_1.ToString() + "\n";
	}

	private int ylezblrTqmBwRyfzbXXfmlbRfFSI(DirectInputAxis P_0, fEIEHzfgwHXLRiMTFeeLDuigNlxcb P_1)
	{
		return P_0 switch
		{
			DirectInputAxis.X => P_1.vJUejbdRgGqWdfjtifIqNGqSMSgpb, 
			DirectInputAxis.Y => P_1.MeDwLMtzNbtoqcHSRBHXCaCgMSfC, 
			DirectInputAxis.Z => P_1.XZHEDoZEhyDmcwkXaogNRfsQnbiR, 
			DirectInputAxis.RotationX => P_1.PulfoTuoYkXOrvQtoixSfXUNTFkN, 
			DirectInputAxis.RotationY => P_1.FwagLTHgAXlPNqEXcGTnOENcPAPxA, 
			DirectInputAxis.RotationZ => P_1.WIKtTVgFIuusSepcleuHYJGUhCIK, 
			DirectInputAxis.Slider0 => P_1.nOkGlBgptVNgbviPFbEXIkMiGyISB[0], 
			DirectInputAxis.Slider1 => P_1.nOkGlBgptVNgbviPFbEXIkMiGyISB[1], 
			DirectInputAxis.VelocityX => P_1.KMHYOstcQMCsnZAEvccDkLMXdJIG, 
			DirectInputAxis.VelocityY => P_1.iWbPbeFpqaUggozynjsTBndbDDUO, 
			DirectInputAxis.VelocityZ => P_1.fohnmIfOlPyCKKMjoFgKVDYkfCgD, 
			DirectInputAxis.AngularVelocityX => P_1.wdkBYvWOKktlMZhBwEahECOEUqbWA, 
			DirectInputAxis.AngularVelocityY => P_1.bzxAitkJuVXBNbIPWCjqKMZVICuZ, 
			DirectInputAxis.AngularVelocityZ => P_1.ySskkYAjllnqPSAfmbbIZidvDoee, 
			DirectInputAxis.VelocitySlider0 => P_1.kfQAcRHnGgxIZuXzFesGFgMFnykOA[0], 
			DirectInputAxis.VelocitySlider1 => P_1.kfQAcRHnGgxIZuXzFesGFgMFnykOA[1], 
			DirectInputAxis.AccelerationX => P_1.gGYBqYcGzDXXOlELHnaRSsFyAKJtA, 
			DirectInputAxis.AccelerationY => P_1.rOFFPfqWdiCfDpasDWOpHnyYBsEP, 
			DirectInputAxis.AccelerationZ => P_1.tpMsCsmmlTlzvjstjaozXxpmkzvU, 
			DirectInputAxis.AngularAccelerationX => P_1.sJcQVvLwXDvuHKHdQUmAsKGqwvJj, 
			DirectInputAxis.AngularAccelerationY => P_1.hIXGYdvgexhsaEQiphzJuDisNTbM, 
			DirectInputAxis.AngularAccelerationZ => P_1.rJfaRkBlglLSqITOwBbzjeBpbbduA, 
			DirectInputAxis.AccelerationSlider0 => P_1.MTvggvkdofkLsHGfjnBIdQHjgcsXB[0], 
			DirectInputAxis.AccelerationSlider1 => P_1.MTvggvkdofkLsHGfjnBIdQHjgcsXB[1], 
			DirectInputAxis.ForceX => P_1.MTAfiJJUbQekHuSxNCdaIcUAojvO, 
			DirectInputAxis.ForceY => P_1.qUZgvhjnJFfXvCJVZhXuFtJAfPedA, 
			DirectInputAxis.ForceZ => P_1.INjIGcoSKBdtFbsFsCVldjFrAxJO, 
			DirectInputAxis.TorqueX => P_1.resKRmJGrrxICUlriacQfWHHUyKK, 
			DirectInputAxis.TorqueY => P_1.MDMAnkUjUCvAVcveBahaMlzNOhdL, 
			DirectInputAxis.TorqueZ => P_1.MEChUihzvOvfXwWPIppLMjdFcIfaA, 
			DirectInputAxis.ForceSlider0 => P_1.DyTjFsWhTANuQPyovsjgaFIIEPMO[0], 
			DirectInputAxis.ForceSlider1 => P_1.DyTjFsWhTANuQPyovsjgaFIIEPMO[1], 
			_ => 0, 
		};
	}

	private float vZkdBCxuemmqMNeTVjPTueakAjYb(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}

	public void OnDestroy()
	{
		if (dfQagrbWDxgomEAfjyEMAvgGGJrkA != null)
		{
			dfQagrbWDxgomEAfjyEMAvgGGJrkA.ZiYbrvzqaSrBafdyVkpZBZMJaFMU();
		}
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}
}
