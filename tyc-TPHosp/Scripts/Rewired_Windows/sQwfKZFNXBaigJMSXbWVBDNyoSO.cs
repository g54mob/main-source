using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal sealed class sQwfKZFNXBaigJMSXbWVBDNyoSO : IElementIdentifierTool
{
	private Rewired.Internal.GUIText vVwNRYmxiqFQsVlAFkECrFJoNrL;

	private string RXoxPsjwFUIfgQWMIHeCesmxKsg;

	private int KWiwVtjcbaUptzhIrmTesQCcxnP;

	private qlIBtAfuFtdSnDfdAlXLqIlaFZjt hmoIGvwuxwJiZhNwPsZPjZFhpVy;

	private rfGUKNICXjMvSKkObEqIFzzuSJa PFnOTHqJnYDWzxCOYtTyZdOVMyq;

	private Guid tVCUIwIKXkQOKHmeFaKweatIKpKx;

	private IList<rwUDYNAmSWwCoTDiwmZsStufkqWe> LmBfMWqHGmQaOJfTCmwmVNNdPTl;

	private IList<rwUDYNAmSWwCoTDiwmZsStufkqWe> NTSPaOhzwnEyLAbIbEgXeHzNbNW;

	private bool DQgTsBsHBsEsEpUIpcYNvgCYLSQ;

	private bool LXNyCvqHsWRkEovtIKsRXNxReHF;

	private bool maDGezkYlRAxTrnfiBNQuPayqytk;

	private int HAWXqjWpZjOnhWymcHsJOFyrHIt;

	private TimerRealTime RDcQyMEdXmKzMILKWClGmenXmfM;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		vVwNRYmxiqFQsVlAFkECrFJoNrL = text;
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
		if (!(ReInput.primaryInputManager.inputSource is InputSourceWrapper<qlIBtAfuFtdSnDfdAlXLqIlaFZjt> inputSourceWrapper) || inputSourceWrapper.source == null)
		{
			Rewired.Logger.LogError("Unable to initialize Direct Input! You must add a Rewired Input Manager to the scene and set the input mode to Direct Input.");
			return;
		}
		hmoIGvwuxwJiZhNwPsZPjZFhpVy = inputSourceWrapper.source;
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += HWybtVeZZUDEUVZkTRDyLxFgrON;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += VQNmCjqHHJHMkrdAfOzYWMyKBMA;
		RDcQyMEdXmKzMILKWClGmenXmfM = new TimerRealTime(1.0);
		RDcQyMEdXmKzMILKWClGmenXmfM.Start();
		pvhdfRPuYoBmeUzxAGGmjRPxTIr();
		maDGezkYlRAxTrnfiBNQuPayqytk = true;
	}

	public void Update()
	{
		if (!maDGezkYlRAxTrnfiBNQuPayqytk)
		{
			return;
		}
		RXoxPsjwFUIfgQWMIHeCesmxKsg = "Direct Input Joystick Element Identifier\n\n";
		vVwNRYmxiqFQsVlAFkECrFJoNrL.text = RXoxPsjwFUIfgQWMIHeCesmxKsg;
		if (Input.GetKeyDown(KeyCode.A))
		{
			DQgTsBsHBsEsEpUIpcYNvgCYLSQ = !DQgTsBsHBsEsEpUIpcYNvgCYLSQ;
		}
		if (DQgTsBsHBsEsEpUIpcYNvgCYLSQ)
		{
			vVwNRYmxiqFQsVlAFkECrFJoNrL.text += "All Devices:\n";
			foreach (rwUDYNAmSWwCoTDiwmZsStufkqWe item in NTSPaOhzwnEyLAbIbEgXeHzNbNW)
			{
				Rewired.Internal.GUIText gUIText = vVwNRYmxiqFQsVlAFkECrFJoNrL;
				object text = gUIText.text;
				gUIText.text = string.Concat(text, item.MqxtgbOxQtaHwdixZLQxCzOqPIb, ", ", item.IsHumanInterfaceDevice, ", ", new PidVid(item.jogDTTzPLkSRUmADdmtAWGdKeHhB), ", ", item.Subtype, ", ", item.MkpgUCmmoxVNynCIXjswJwYMVbor, ", ", item.YAzbvqReGlaZigycDwVUEsjDMOM, "\n");
			}
			vVwNRYmxiqFQsVlAFkECrFJoNrL.text += "\n";
		}
		int kWiwVtjcbaUptzhIrmTesQCcxnP = KWiwVtjcbaUptzhIrmTesQCcxnP;
		Guid guid = tVCUIwIKXkQOKHmeFaKweatIKpKx;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			KWiwVtjcbaUptzhIrmTesQCcxnP++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			KWiwVtjcbaUptzhIrmTesQCcxnP--;
		}
		if (RDcQyMEdXmKzMILKWClGmenXmfM.Update())
		{
			int num = hmoIGvwuxwJiZhNwPsZPjZFhpVy.uYEAGtqGpXGOqyYytMRHARWYrtv(HiBJWeyeWfhElzlDChLUgQROjnAq.lKcDIMfHrbBBgTzhXBojeBKdnPsp, zTnRQWEjlkWYSgeKMuNijZncOjb.mfDsciKEpiiAxZMfjwhaCIxnzBt);
			if (num != HAWXqjWpZjOnhWymcHsJOFyrHIt)
			{
				HAWXqjWpZjOnhWymcHsJOFyrHIt = num;
				LXNyCvqHsWRkEovtIKsRXNxReHF = true;
			}
			RDcQyMEdXmKzMILKWClGmenXmfM.Start();
		}
		if (LXNyCvqHsWRkEovtIKsRXNxReHF)
		{
			pvhdfRPuYoBmeUzxAGGmjRPxTIr();
			LXNyCvqHsWRkEovtIKsRXNxReHF = false;
		}
		int num2 = ((LmBfMWqHGmQaOJfTCmwmVNNdPTl != null) ? LmBfMWqHGmQaOJfTCmwmVNNdPTl.Count : 0);
		if (num2 == 0)
		{
			return;
		}
		if (KWiwVtjcbaUptzhIrmTesQCcxnP < 0)
		{
			KWiwVtjcbaUptzhIrmTesQCcxnP = num2 - 1;
		}
		else if (KWiwVtjcbaUptzhIrmTesQCcxnP >= num2)
		{
			KWiwVtjcbaUptzhIrmTesQCcxnP = 0;
		}
		tVCUIwIKXkQOKHmeFaKweatIKpKx = LmBfMWqHGmQaOJfTCmwmVNNdPTl[KWiwVtjcbaUptzhIrmTesQCcxnP].wXKmhfCcjUksYEsLiiQybuQLGQI;
		bool flag = false;
		if (kWiwVtjcbaUptzhIrmTesQCcxnP != KWiwVtjcbaUptzhIrmTesQCcxnP || guid != tVCUIwIKXkQOKHmeFaKweatIKpKx)
		{
			flag = true;
		}
		if (PFnOTHqJnYDWzxCOYtTyZdOVMyq == null || flag)
		{
			if (PFnOTHqJnYDWzxCOYtTyZdOVMyq != null)
			{
				PFnOTHqJnYDWzxCOYtTyZdOVMyq.JkxbMOPQiVSbeNRGETMYZahHimc();
			}
			PFnOTHqJnYDWzxCOYtTyZdOVMyq = new rfGUKNICXjMvSKkObEqIFzzuSJa(hmoIGvwuxwJiZhNwPsZPjZFhpVy, LmBfMWqHGmQaOJfTCmwmVNNdPTl[KWiwVtjcbaUptzhIrmTesQCcxnP].wXKmhfCcjUksYEsLiiQybuQLGQI);
			if (PFnOTHqJnYDWzxCOYtTyZdOVMyq == null)
			{
				return;
			}
			IList<QFSOxzhPpyaLqYMwQgtmifgAXZG> list = PFnOTHqJnYDWzxCOYtTyZdOVMyq.TVaiIWKNfoNxveKqEumdFXOwUxn();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if ((list[i].PNUPKdsUxQjgBzrtMqUfGFBqDTO.Flags & qLlbkJgSwnsGlOrbhfONlbVdJMjX.RsTgZXXBZHrKFqBmaGTodiwVlGzD) != qLlbkJgSwnsGlOrbhfONlbVdJMjX.lKcDIMfHrbBBgTzhXBojeBKdnPsp)
					{
						PFnOTHqJnYDWzxCOYtTyZdOVMyq.Properties.Range = new LORDAuECNFpRPQHKhdIzDKYopLmA(-65535, 65535);
					}
				}
			}
			PFnOTHqJnYDWzxCOYtTyZdOVMyq.QqViEWwhZaWrvATfPuWfqnkWwbi();
		}
		PRfuElMMOSGhxJbUbIuaBSoRrQWL pRfuElMMOSGhxJbUbIuaBSoRrQWL;
		try
		{
			pRfuElMMOSGhxJbUbIuaBSoRrQWL = PFnOTHqJnYDWzxCOYtTyZdOVMyq.hLSGVQNOyzELOWjeFiJiwuWDSHd();
		}
		catch
		{
			pRfuElMMOSGhxJbUbIuaBSoRrQWL = null;
		}
		if (pRfuElMMOSGhxJbUbIuaBSoRrQWL == null)
		{
			return;
		}
		if (num2 > 0)
		{
			RXoxPsjwFUIfgQWMIHeCesmxKsg = RXoxPsjwFUIfgQWMIHeCesmxKsg + num2 + " connected devices:\n";
		}
		for (int j = 0; j < num2; j++)
		{
			RXoxPsjwFUIfgQWMIHeCesmxKsg = RXoxPsjwFUIfgQWMIHeCesmxKsg + LmBfMWqHGmQaOJfTCmwmVNNdPTl[j].MqxtgbOxQtaHwdixZLQxCzOqPIb + "\n";
		}
		RXoxPsjwFUIfgQWMIHeCesmxKsg += "\n";
		object rXoxPsjwFUIfgQWMIHeCesmxKsg = RXoxPsjwFUIfgQWMIHeCesmxKsg;
		RXoxPsjwFUIfgQWMIHeCesmxKsg = string.Concat(rXoxPsjwFUIfgQWMIHeCesmxKsg, "Current DI device ", KWiwVtjcbaUptzhIrmTesQCcxnP, ": ", LmBfMWqHGmQaOJfTCmwmVNNdPTl[KWiwVtjcbaUptzhIrmTesQCcxnP].MqxtgbOxQtaHwdixZLQxCzOqPIb, "\n");
		RXoxPsjwFUIfgQWMIHeCesmxKsg += "(Press + or - to change monitored device id.)\n\n";
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Identifier", new PidVid(PFnOTHqJnYDWzxCOYtTyZdOVMyq.Information.jogDTTzPLkSRUmADdmtAWGdKeHhB));
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Instance GUID", PFnOTHqJnYDWzxCOYtTyZdOVMyq.Information.wXKmhfCcjUksYEsLiiQybuQLGQI);
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Product Id", PFnOTHqJnYDWzxCOYtTyZdOVMyq.Properties.ProductId);
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Device Type", PFnOTHqJnYDWzxCOYtTyZdOVMyq.Capabilities.Type.ToString());
		RXoxPsjwFUIfgQWMIHeCesmxKsg += "\n";
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Axis Count", PFnOTHqJnYDWzxCOYtTyZdOVMyq.Capabilities.hXFCmadnASzZQEPEdeoHmBdlTIJA);
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Button Count", PFnOTHqJnYDWzxCOYtTyZdOVMyq.Capabilities.vKVJSofBVFDiPCcbycKCGKIUjJfL);
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Hat Count", PFnOTHqJnYDWzxCOYtTyZdOVMyq.Capabilities.OvHajLmABQoxBJCUifQOFcNVxft);
		RXoxPsjwFUIfgQWMIHeCesmxKsg += "\n";
		if (flag)
		{
			Rewired.Logger.Log("Device Name: \"" + LmBfMWqHGmQaOJfTCmwmVNNdPTl[KWiwVtjcbaUptzhIrmTesQCcxnP].MqxtgbOxQtaHwdixZLQxCzOqPIb + "\"");
			Rewired.Logger.Log("Identifier: " + new PidVid(PFnOTHqJnYDWzxCOYtTyZdOVMyq.Information.jogDTTzPLkSRUmADdmtAWGdKeHhB));
		}
		for (int k = 0; k < 32; k++)
		{
			int num3 = CCwCnYhEmaFZrOQeiMBHgUHikwcc((DirectInputAxis)k, pRfuElMMOSGhxJbUbIuaBSoRrQWL);
			string text2 = ((DirectInputAxis)k).ToString();
			YgtqqyMBxpnWhXqnMcSwkqoAUek(text2, num3 + " (" + jBwGMgeXcypsIUbeXmoFAFFnKCeq(num3) + ")");
		}
		int[] pointOfViewControllers = pRfuElMMOSGhxJbUbIuaBSoRrQWL.PointOfViewControllers;
		for (int l = 0; l < 4; l++)
		{
			int num4 = pointOfViewControllers[l];
			string text3 = "Hat " + l;
			YgtqqyMBxpnWhXqnMcSwkqoAUek(text3, num4);
		}
		bool[] buttons = pRfuElMMOSGhxJbUbIuaBSoRrQWL.Buttons;
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
		YgtqqyMBxpnWhXqnMcSwkqoAUek("Buttons ", text4);
		vVwNRYmxiqFQsVlAFkECrFJoNrL.text = RXoxPsjwFUIfgQWMIHeCesmxKsg;
	}

	private void pvhdfRPuYoBmeUzxAGGmjRPxTIr()
	{
		LmBfMWqHGmQaOJfTCmwmVNNdPTl = hmoIGvwuxwJiZhNwPsZPjZFhpVy.npLwcPNqCJKIqEewEfYdgbDGPcD(HiBJWeyeWfhElzlDChLUgQROjnAq.UOIGbizuvcghCQGjQAUpIizRcQjG, zTnRQWEjlkWYSgeKMuNijZncOjb.mfDsciKEpiiAxZMfjwhaCIxnzBt);
		NTSPaOhzwnEyLAbIbEgXeHzNbNW = hmoIGvwuxwJiZhNwPsZPjZFhpVy.npLwcPNqCJKIqEewEfYdgbDGPcD(HiBJWeyeWfhElzlDChLUgQROjnAq.lKcDIMfHrbBBgTzhXBojeBKdnPsp, zTnRQWEjlkWYSgeKMuNijZncOjb.mfDsciKEpiiAxZMfjwhaCIxnzBt);
		HAWXqjWpZjOnhWymcHsJOFyrHIt = ((NTSPaOhzwnEyLAbIbEgXeHzNbNW != null) ? NTSPaOhzwnEyLAbIbEgXeHzNbNW.Count : 0);
	}

	private void HWybtVeZZUDEUVZkTRDyLxFgrON()
	{
		VsfvDyXqZIMuiFHDXHZBjZyCAyO();
	}

	private void VQNmCjqHHJHMkrdAfOzYWMyKBMA()
	{
		VsfvDyXqZIMuiFHDXHZBjZyCAyO();
	}

	private void VsfvDyXqZIMuiFHDXHZBjZyCAyO()
	{
		rKJfCRBWFLQsKCjGykmcumzKLPwE();
		LXNyCvqHsWRkEovtIKsRXNxReHF = true;
	}

	private void rKJfCRBWFLQsKCjGykmcumzKLPwE()
	{
		KWiwVtjcbaUptzhIrmTesQCcxnP = 0;
		PFnOTHqJnYDWzxCOYtTyZdOVMyq = null;
		tVCUIwIKXkQOKHmeFaKweatIKpKx = Guid.Empty;
		LmBfMWqHGmQaOJfTCmwmVNNdPTl = null;
		NTSPaOhzwnEyLAbIbEgXeHzNbNW = null;
		DQgTsBsHBsEsEpUIpcYNvgCYLSQ = false;
		LXNyCvqHsWRkEovtIKsRXNxReHF = false;
		HAWXqjWpZjOnhWymcHsJOFyrHIt = 0;
	}

	private void YgtqqyMBxpnWhXqnMcSwkqoAUek(string P_0, object P_1)
	{
		string rXoxPsjwFUIfgQWMIHeCesmxKsg = RXoxPsjwFUIfgQWMIHeCesmxKsg;
		RXoxPsjwFUIfgQWMIHeCesmxKsg = rXoxPsjwFUIfgQWMIHeCesmxKsg + P_0 + " = " + P_1.ToString() + "\n";
	}

	private int CCwCnYhEmaFZrOQeiMBHgUHikwcc(DirectInputAxis P_0, PRfuElMMOSGhxJbUbIuaBSoRrQWL P_1)
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

	private float jBwGMgeXcypsIUbeXmoFAFFnKCeq(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}

	public void OnDestroy()
	{
		if (PFnOTHqJnYDWzxCOYtTyZdOVMyq != null)
		{
			PFnOTHqJnYDWzxCOYtTyZdOVMyq.JkxbMOPQiVSbeNRGETMYZahHimc();
		}
	}
}
