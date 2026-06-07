using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal sealed class quSSJqRRJxlNxOnstFlgPukSuCvR : IElementIdentifierTool
{
	private Rewired.Internal.GUIText dSdEzWGHhcKEfTAQjeRlDMIjykYPb;

	private string YBGyGEaOZdAXfdIoYLNmMMDZCaCiA;

	private int bWBAbtiqQxvjavlnNJrZuEMqTynr;

	private kHulolaiHHHtqEyPXwgoOKOviJQAb NngaAcDjGavDSRaDfOZseooTOsOb;

	private jmiDTsUKFPYQFBYgXXnbDNCMRcXj RqRykIKAxYppNEmAdOlAckDPxudW;

	private Guid XIFjJWaJJOVuWJPLhgcmEigjaHiZA;

	private IList<zxeoTygAWuodzEbOIdaTbdNJPkfzA> ctRjkNFAUGdgLGcOffbkGdPFlMMM;

	private IList<zxeoTygAWuodzEbOIdaTbdNJPkfzA> eJqhQDaAUPriAmfRzFMiJUrgDbor;

	private bool zZnUjOGqyOshrpoJDTMcpBPXgWrB;

	private bool lafUmvmecWMPfzehevUAtnTpNAIw;

	private bool hkghLinlPgggJhEahfQyDsAsvuzb;

	private int JtCLgwScewGSkHUJVMTRbSzKaVdp;

	private TimerRealTime beffxiWyyxIANRNEEHiRdvMuoXnr;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		dSdEzWGHhcKEfTAQjeRlDMIjykYPb = text;
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
		else if (ReInput.primaryInputManager.inputSource is InputSourceWrapper<kHulolaiHHHtqEyPXwgoOKOviJQAb> { source: not null } inputSourceWrapper)
		{
			NngaAcDjGavDSRaDfOZseooTOsOb = inputSourceWrapper.source;
			ReInput.primaryInputManager.SystemDeviceConnectedEvent += TftloVILtXVJqcMAUklUsgixiqfF;
			ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += ZBWaPNZgFhjACTxPWQfVnMZLmIMH;
			beffxiWyyxIANRNEEHiRdvMuoXnr = new TimerRealTime(1.0);
			beffxiWyyxIANRNEEHiRdvMuoXnr.Start();
			ZdKasFEyAnEwCPoDNXPHUfOlazmk();
			hkghLinlPgggJhEahfQyDsAsvuzb = true;
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
		if (!hkghLinlPgggJhEahfQyDsAsvuzb)
		{
			return;
		}
		YBGyGEaOZdAXfdIoYLNmMMDZCaCiA = "Direct Input Joystick Element Identifier\n\n";
		dSdEzWGHhcKEfTAQjeRlDMIjykYPb.text = YBGyGEaOZdAXfdIoYLNmMMDZCaCiA;
		if (Input.GetKeyDown(KeyCode.A))
		{
			zZnUjOGqyOshrpoJDTMcpBPXgWrB = !zZnUjOGqyOshrpoJDTMcpBPXgWrB;
		}
		if (zZnUjOGqyOshrpoJDTMcpBPXgWrB)
		{
			dSdEzWGHhcKEfTAQjeRlDMIjykYPb.text += "All Devices:\n";
			foreach (zxeoTygAWuodzEbOIdaTbdNJPkfzA item in eJqhQDaAUPriAmfRzFMiJUrgDbor)
			{
				Rewired.Internal.GUIText gUIText = dSdEzWGHhcKEfTAQjeRlDMIjykYPb;
				gUIText.text = gUIText.text + item.uOXIriiYjCRnxlHeUPJeHhWUdUCB + ", " + item.YTyUqFgnbsXJvRwGPRbOehgSzhyS + ", " + new PidVid(item.hdueOrdlMvKpdcNivQkyMEDscIuS).ToString() + ", " + item.IHiQdwloQQYqRGuUEOYNQFWBhwag + ", " + item.DScuXYnAzUUCGQyBHmFpcOMshEWEA + ", " + item.bvRvAxabqGnNVdSSOdEEjayZCUpaA + "\n";
			}
			dSdEzWGHhcKEfTAQjeRlDMIjykYPb.text += "\n";
		}
		int num = bWBAbtiqQxvjavlnNJrZuEMqTynr;
		Guid xIFjJWaJJOVuWJPLhgcmEigjaHiZA = XIFjJWaJJOVuWJPLhgcmEigjaHiZA;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			bWBAbtiqQxvjavlnNJrZuEMqTynr++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			bWBAbtiqQxvjavlnNJrZuEMqTynr--;
		}
		if (beffxiWyyxIANRNEEHiRdvMuoXnr.Update())
		{
			int num2 = NngaAcDjGavDSRaDfOZseooTOsOb.DtqAgSdbdXCUSQwtJpyjQSeTFtdjA(VLvQcNuaSLlqeeafybsvEUaykbhq.All, pnJfJlKSvYRtZdzwwioLpnYQNhYbb.AttachedOnly);
			if (num2 != JtCLgwScewGSkHUJVMTRbSzKaVdp)
			{
				JtCLgwScewGSkHUJVMTRbSzKaVdp = num2;
				lafUmvmecWMPfzehevUAtnTpNAIw = true;
			}
			beffxiWyyxIANRNEEHiRdvMuoXnr.Start();
		}
		if (lafUmvmecWMPfzehevUAtnTpNAIw)
		{
			ZdKasFEyAnEwCPoDNXPHUfOlazmk();
			lafUmvmecWMPfzehevUAtnTpNAIw = false;
		}
		int num3 = ((ctRjkNFAUGdgLGcOffbkGdPFlMMM != null) ? ctRjkNFAUGdgLGcOffbkGdPFlMMM.Count : 0);
		if (num3 == 0)
		{
			return;
		}
		if (bWBAbtiqQxvjavlnNJrZuEMqTynr < 0)
		{
			bWBAbtiqQxvjavlnNJrZuEMqTynr = num3 - 1;
		}
		else if (bWBAbtiqQxvjavlnNJrZuEMqTynr >= num3)
		{
			bWBAbtiqQxvjavlnNJrZuEMqTynr = 0;
		}
		XIFjJWaJJOVuWJPLhgcmEigjaHiZA = ctRjkNFAUGdgLGcOffbkGdPFlMMM[bWBAbtiqQxvjavlnNJrZuEMqTynr].HtnaQuDxVHZJAgkNHGcRfsCbXIkP;
		bool flag = false;
		if (num != bWBAbtiqQxvjavlnNJrZuEMqTynr || xIFjJWaJJOVuWJPLhgcmEigjaHiZA != XIFjJWaJJOVuWJPLhgcmEigjaHiZA)
		{
			flag = true;
		}
		if (RqRykIKAxYppNEmAdOlAckDPxudW == null || flag)
		{
			if (RqRykIKAxYppNEmAdOlAckDPxudW != null)
			{
				RqRykIKAxYppNEmAdOlAckDPxudW.jTTjSKChCviCLdBVBoGJfznYQoYU();
			}
			RqRykIKAxYppNEmAdOlAckDPxudW = new jmiDTsUKFPYQFBYgXXnbDNCMRcXj(NngaAcDjGavDSRaDfOZseooTOsOb, ctRjkNFAUGdgLGcOffbkGdPFlMMM[bWBAbtiqQxvjavlnNJrZuEMqTynr].HtnaQuDxVHZJAgkNHGcRfsCbXIkP);
			if (RqRykIKAxYppNEmAdOlAckDPxudW == null)
			{
				return;
			}
			IList<IAgdmKbxxCierJHKqWSFAjDwBDjEb> list = RqRykIKAxYppNEmAdOlAckDPxudW.fWtXYVUCSWZikKkfLUGZZPfKcqQG();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if ((list[i].aLWciJOjBCisHJVTCYpDOCixDlsO.yrYglbiJtyhblKhgSIEStyVbbMuYA & ohTLfsCnqDzhumcBDNxmtssJOYWS.Axis) != ohTLfsCnqDzhumcBDNxmtssJOYWS.All)
					{
						RqRykIKAxYppNEmAdOlAckDPxudW.sXDSFEegzIGHJfFPzuVoJnPazfEEA.vTMlomscYJERfBLYoLyKSSDbmdHI = new ZwzuTTMVBnDuEVKaTDvIbKtEjZPCb(-65535, 65535);
					}
				}
			}
			RqRykIKAxYppNEmAdOlAckDPxudW.AGcUmdNvzDHZZmFwBKCGcWkvflUG();
		}
		VtLeNKSsCaVMweNoLHJHDUNhwUvFA vtLeNKSsCaVMweNoLHJHDUNhwUvFA;
		try
		{
			vtLeNKSsCaVMweNoLHJHDUNhwUvFA = RqRykIKAxYppNEmAdOlAckDPxudW.DUJUaMkruaChpArrretnAMeQAhSF();
		}
		catch
		{
			vtLeNKSsCaVMweNoLHJHDUNhwUvFA = null;
		}
		if (vtLeNKSsCaVMweNoLHJHDUNhwUvFA == null)
		{
			return;
		}
		if (num3 > 0)
		{
			YBGyGEaOZdAXfdIoYLNmMMDZCaCiA = YBGyGEaOZdAXfdIoYLNmMMDZCaCiA + num3 + " connected devices:\n";
		}
		for (int j = 0; j < num3; j++)
		{
			YBGyGEaOZdAXfdIoYLNmMMDZCaCiA = YBGyGEaOZdAXfdIoYLNmMMDZCaCiA + ctRjkNFAUGdgLGcOffbkGdPFlMMM[j].uOXIriiYjCRnxlHeUPJeHhWUdUCB + "\n";
		}
		YBGyGEaOZdAXfdIoYLNmMMDZCaCiA += "\n";
		YBGyGEaOZdAXfdIoYLNmMMDZCaCiA = YBGyGEaOZdAXfdIoYLNmMMDZCaCiA + "Current DI device " + bWBAbtiqQxvjavlnNJrZuEMqTynr + ": " + ctRjkNFAUGdgLGcOffbkGdPFlMMM[bWBAbtiqQxvjavlnNJrZuEMqTynr].uOXIriiYjCRnxlHeUPJeHhWUdUCB + "\n";
		YBGyGEaOZdAXfdIoYLNmMMDZCaCiA += "(Press + or - to change monitored device id.)\n\n";
		tQpjntulBWRBWGzzWGXLarDraMSX("Identifier", new PidVid(RqRykIKAxYppNEmAdOlAckDPxudW.qkAAUqzwIMWlCpJIqWIiGbHLysIq.hdueOrdlMvKpdcNivQkyMEDscIuS));
		tQpjntulBWRBWGzzWGXLarDraMSX("Instance GUID", RqRykIKAxYppNEmAdOlAckDPxudW.qkAAUqzwIMWlCpJIqWIiGbHLysIq.HtnaQuDxVHZJAgkNHGcRfsCbXIkP);
		tQpjntulBWRBWGzzWGXLarDraMSX("Product Id", RqRykIKAxYppNEmAdOlAckDPxudW.sXDSFEegzIGHJfFPzuVoJnPazfEEA.UZzQBKRfDcFxdsMfUJUcNtScDBte);
		tQpjntulBWRBWGzzWGXLarDraMSX("Device Type", RqRykIKAxYppNEmAdOlAckDPxudW.OfVKqIDBopiIsKkbUgUZRuDOHWzK.QcFVTAVKDXIHRAMJlqDVOiIgbvSrA.ToString());
		YBGyGEaOZdAXfdIoYLNmMMDZCaCiA += "\n";
		tQpjntulBWRBWGzzWGXLarDraMSX("Axis Count", RqRykIKAxYppNEmAdOlAckDPxudW.OfVKqIDBopiIsKkbUgUZRuDOHWzK.BUpPQbOPJqabGYXEBvJDNXdjPmFu);
		tQpjntulBWRBWGzzWGXLarDraMSX("Button Count", RqRykIKAxYppNEmAdOlAckDPxudW.OfVKqIDBopiIsKkbUgUZRuDOHWzK.VwzgdefkBUxKPQWWTBdoFkdfOyhWA);
		tQpjntulBWRBWGzzWGXLarDraMSX("Hat Count", RqRykIKAxYppNEmAdOlAckDPxudW.OfVKqIDBopiIsKkbUgUZRuDOHWzK.gQcLwFJCKehJFBEPbcXGPRqyaJhH);
		YBGyGEaOZdAXfdIoYLNmMMDZCaCiA += "\n";
		if (flag)
		{
			Rewired.Logger.Log("Device Name: \"" + ctRjkNFAUGdgLGcOffbkGdPFlMMM[bWBAbtiqQxvjavlnNJrZuEMqTynr].uOXIriiYjCRnxlHeUPJeHhWUdUCB + "\"");
			Rewired.Logger.Log("Identifier: " + new PidVid(RqRykIKAxYppNEmAdOlAckDPxudW.qkAAUqzwIMWlCpJIqWIiGbHLysIq.hdueOrdlMvKpdcNivQkyMEDscIuS).ToString());
		}
		for (int k = 0; k < 32; k++)
		{
			int num4 = YGdvdUSPMDQKisQIrmdzEWUMSHYi((DirectInputAxis)k, vtLeNKSsCaVMweNoLHJHDUNhwUvFA);
			DirectInputAxis directInputAxis = (DirectInputAxis)k;
			string text = directInputAxis.ToString();
			tQpjntulBWRBWGzzWGXLarDraMSX(text, num4 + " (" + NMIdaUUMJHlDLPVBBGgXYZOvvexe(num4) + ")");
		}
		int[] array = vtLeNKSsCaVMweNoLHJHDUNhwUvFA.NDZBTtFPBnBrMKyEDKqzTRtGtgqiA;
		for (int l = 0; l < 4; l++)
		{
			int num5 = array[l];
			string text2 = "Hat " + l;
			tQpjntulBWRBWGzzWGXLarDraMSX(text2, num5);
		}
		bool[] array2 = vtLeNKSsCaVMweNoLHJHDUNhwUvFA.dFtjxHIKBEVCbiMbVRQgOXuRBzsR;
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
		tQpjntulBWRBWGzzWGXLarDraMSX("Buttons ", text3);
		dSdEzWGHhcKEfTAQjeRlDMIjykYPb.text = YBGyGEaOZdAXfdIoYLNmMMDZCaCiA;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	private void ZdKasFEyAnEwCPoDNXPHUfOlazmk()
	{
		ctRjkNFAUGdgLGcOffbkGdPFlMMM = NngaAcDjGavDSRaDfOZseooTOsOb.LbAmUIpjiYaToBfvvmjVybogrgveA(VLvQcNuaSLlqeeafybsvEUaykbhq.GameControl, pnJfJlKSvYRtZdzwwioLpnYQNhYbb.AttachedOnly);
		eJqhQDaAUPriAmfRzFMiJUrgDbor = NngaAcDjGavDSRaDfOZseooTOsOb.LbAmUIpjiYaToBfvvmjVybogrgveA(VLvQcNuaSLlqeeafybsvEUaykbhq.All, pnJfJlKSvYRtZdzwwioLpnYQNhYbb.AttachedOnly);
		JtCLgwScewGSkHUJVMTRbSzKaVdp = ((eJqhQDaAUPriAmfRzFMiJUrgDbor != null) ? eJqhQDaAUPriAmfRzFMiJUrgDbor.Count : 0);
	}

	private void TftloVILtXVJqcMAUklUsgixiqfF()
	{
		rxuhElltZTRvpdAQMMacyTtzGoKF();
	}

	private void ZBWaPNZgFhjACTxPWQfVnMZLmIMH()
	{
		rxuhElltZTRvpdAQMMacyTtzGoKF();
	}

	private void rxuhElltZTRvpdAQMMacyTtzGoKF()
	{
		DcbfNbhVsMbmlDFEnMMppCYfLtOCb();
		lafUmvmecWMPfzehevUAtnTpNAIw = true;
	}

	private void DcbfNbhVsMbmlDFEnMMppCYfLtOCb()
	{
		bWBAbtiqQxvjavlnNJrZuEMqTynr = 0;
		RqRykIKAxYppNEmAdOlAckDPxudW = null;
		XIFjJWaJJOVuWJPLhgcmEigjaHiZA = Guid.Empty;
		ctRjkNFAUGdgLGcOffbkGdPFlMMM = null;
		eJqhQDaAUPriAmfRzFMiJUrgDbor = null;
		zZnUjOGqyOshrpoJDTMcpBPXgWrB = false;
		lafUmvmecWMPfzehevUAtnTpNAIw = false;
		JtCLgwScewGSkHUJVMTRbSzKaVdp = 0;
	}

	private void tQpjntulBWRBWGzzWGXLarDraMSX(string P_0, object P_1)
	{
		YBGyGEaOZdAXfdIoYLNmMMDZCaCiA = YBGyGEaOZdAXfdIoYLNmMMDZCaCiA + P_0 + " = " + P_1.ToString() + "\n";
	}

	private int YGdvdUSPMDQKisQIrmdzEWUMSHYi(DirectInputAxis P_0, VtLeNKSsCaVMweNoLHJHDUNhwUvFA P_1)
	{
		return P_0 switch
		{
			DirectInputAxis.X => P_1.TENehSAyWbvDAjjMvQzuBsPVqjiHA, 
			DirectInputAxis.Y => P_1.qSKuldKLVMsLXacLJccJyXFrxNjE, 
			DirectInputAxis.Z => P_1.fLEEGFsIZNelNuIasMPNbCTFCEwfA, 
			DirectInputAxis.RotationX => P_1.xEcfeeHdsZCPWxwYgdWCHXdOCioZ, 
			DirectInputAxis.RotationY => P_1.rAhIFgKJaimOmCYghykrAysyhrJVb, 
			DirectInputAxis.RotationZ => P_1.sxNxRkJGaRdlzcNZtBaRoUzRUXOe, 
			DirectInputAxis.Slider0 => P_1.NdrjfoIIXymlEIgkZrfLAQzLKBOaA[0], 
			DirectInputAxis.Slider1 => P_1.NdrjfoIIXymlEIgkZrfLAQzLKBOaA[1], 
			DirectInputAxis.VelocityX => P_1.yACOeBGNsrPMSDyphNKBEAjGEZOi, 
			DirectInputAxis.VelocityY => P_1.IbgszZkpGTjxZaAXjdZRpzIivsAO, 
			DirectInputAxis.VelocityZ => P_1.PdghcNGsQsvEzCtLekPObwhjIrsD, 
			DirectInputAxis.AngularVelocityX => P_1.KYlWxKddsHBmdBjqmgNdEajTCHjVA, 
			DirectInputAxis.AngularVelocityY => P_1.TewCoEFYEevYejUmSWGegUmAhlsn, 
			DirectInputAxis.AngularVelocityZ => P_1.UyrgNinDeOiFNOhXaQsMlJWmoGed, 
			DirectInputAxis.VelocitySlider0 => P_1.IqVXoiINmNjLeaoKTDXMpIhQIRgAb[0], 
			DirectInputAxis.VelocitySlider1 => P_1.IqVXoiINmNjLeaoKTDXMpIhQIRgAb[1], 
			DirectInputAxis.AccelerationX => P_1.YVRBytjmLcaAdBAcZRHHaOsgrrFbc, 
			DirectInputAxis.AccelerationY => P_1.VkMFFQZjXVfgirBPJabjJlBZpDABb, 
			DirectInputAxis.AccelerationZ => P_1.ZeNuSHBMTijwOnrIzbHzbvMxoShv, 
			DirectInputAxis.AngularAccelerationX => P_1.UEvMTKqxnamMwQcWMdzCQCtlwDBs, 
			DirectInputAxis.AngularAccelerationY => P_1.ZDOGQIGbYKPvRKnZhgSTGRRzWclr, 
			DirectInputAxis.AngularAccelerationZ => P_1.XYwZBNOnSMJTLANxeCJxQBsoAOfU, 
			DirectInputAxis.AccelerationSlider0 => P_1.mywFmMiUAUSKTuEGtFgWQwatGHkOA[0], 
			DirectInputAxis.AccelerationSlider1 => P_1.mywFmMiUAUSKTuEGtFgWQwatGHkOA[1], 
			DirectInputAxis.ForceX => P_1.yfJfkqydDrSnwaPAZASqocrXhSzQ, 
			DirectInputAxis.ForceY => P_1.EkYidYWzrkoASROuXOwuzVcTnkqp, 
			DirectInputAxis.ForceZ => P_1.icolILJBmaRuyzqagDtxXOiefOVY, 
			DirectInputAxis.TorqueX => P_1.TzxHHFyvJQVHxAiGybTGXYiYRQCL, 
			DirectInputAxis.TorqueY => P_1.cIVAlXrVyztDayVBPDKomEYUenzz, 
			DirectInputAxis.TorqueZ => P_1.sZHeSVeYRrqcmTaoWUYFJyWYPbbmA, 
			DirectInputAxis.ForceSlider0 => P_1.btAJPHhXnljIfHkPxPRkCNpPYyAM[0], 
			DirectInputAxis.ForceSlider1 => P_1.btAJPHhXnljIfHkPxPRkCNpPYyAM[1], 
			_ => 0, 
		};
	}

	private float NMIdaUUMJHlDLPVBBGgXYZOvvexe(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}

	public void OnDestroy()
	{
		if (RqRykIKAxYppNEmAdOlAckDPxudW != null)
		{
			RqRykIKAxYppNEmAdOlAckDPxudW.jTTjSKChCviCLdBVBoGJfznYQoYU();
		}
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}
}
