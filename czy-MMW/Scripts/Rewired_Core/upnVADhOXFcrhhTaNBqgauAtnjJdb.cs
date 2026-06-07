using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class upnVADhOXFcrhhTaNBqgauAtnjJdb : IElementIdentifierTool
{
	private GUIText UcONjrcHbcklExccggQccHwANecyA;

	private string iiLbSGQVerLGDIhmFPnNfgZqUtrH;

	private int VcPdGvARXBRPHxEnUGXAIUKSZzGDA = 1;

	public void Initialize(GUIText text)
	{
		UcONjrcHbcklExccggQccHwANecyA = text;
	}

	void IElementIdentifierTool.Initialize(GUIText text)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Initialize
		this.Initialize(text);
	}

	public void Start()
	{
		string[] joystickNames = Input.GetJoystickNames();
		string text = "Detected " + joystickNames.Length + " attached joysticks";
		if (joystickNames.Length != 0)
		{
			text += ":\n";
		}
		string[] array = joystickNames;
		foreach (string text2 in array)
		{
			text = text + "\"" + text2 + "\"\n";
		}
		Rewired.Logger.Log(text);
	}

	void IElementIdentifierTool.Start()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Start
		this.Start();
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			VcPdGvARXBRPHxEnUGXAIUKSZzGDA++;
		}
		if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
		{
			VcPdGvARXBRPHxEnUGXAIUKSZzGDA--;
		}
		if (VcPdGvARXBRPHxEnUGXAIUKSZzGDA <= 0)
		{
			VcPdGvARXBRPHxEnUGXAIUKSZzGDA = 16;
		}
		else if (VcPdGvARXBRPHxEnUGXAIUKSZzGDA > 16)
		{
			VcPdGvARXBRPHxEnUGXAIUKSZzGDA = 1;
		}
		iiLbSGQVerLGDIhmFPnNfgZqUtrH = "Unity Joystick Element Identifier:\n\n";
		string[] joystickNames = Input.GetJoystickNames();
		if (joystickNames.Length != 0)
		{
			iiLbSGQVerLGDIhmFPnNfgZqUtrH += "Connected joysticks:\n";
		}
		else
		{
			iiLbSGQVerLGDIhmFPnNfgZqUtrH += "No joysticks detected.\n";
		}
		for (int i = 0; i < joystickNames.Length; i++)
		{
			iiLbSGQVerLGDIhmFPnNfgZqUtrH = iiLbSGQVerLGDIhmFPnNfgZqUtrH + "[" + i + "] \"" + joystickNames[i] + "\"";
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(joystickNames[i]))
			{
				iiLbSGQVerLGDIhmFPnNfgZqUtrH += " [UNITY PRE-CONFIGURED]";
			}
			iiLbSGQVerLGDIhmFPnNfgZqUtrH += "\n";
		}
		iiLbSGQVerLGDIhmFPnNfgZqUtrH += "\n";
		iiLbSGQVerLGDIhmFPnNfgZqUtrH = iiLbSGQVerLGDIhmFPnNfgZqUtrH + "Current Unity Joystick Id: " + VcPdGvARXBRPHxEnUGXAIUKSZzGDA + "\n";
		iiLbSGQVerLGDIhmFPnNfgZqUtrH += "(Press + or - to change monitored joystick id.)\n\n";
		for (int j = 0; j < 29; j++)
		{
			string text = "Axis " + j;
			float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(VcPdGvARXBRPHxEnUGXAIUKSZzGDA, j);
			ZouQiMuqeZoDlPNIAbvnGbszFoEV(text, joystickAxisValueByJoystickId);
		}
		for (int k = 0; k < 20; k++)
		{
			string text2 = "Button " + k;
			bool joystickButtonValueByJoystickId = UnityInputHelper.GetJoystickButtonValueByJoystickId(VcPdGvARXBRPHxEnUGXAIUKSZzGDA, k);
			ZouQiMuqeZoDlPNIAbvnGbszFoEV(text2, joystickButtonValueByJoystickId);
		}
		UcONjrcHbcklExccggQccHwANecyA.text = iiLbSGQVerLGDIhmFPnNfgZqUtrH;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void OnDestroy()
	{
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}

	private void ZouQiMuqeZoDlPNIAbvnGbszFoEV(string P_0, object P_1)
	{
		iiLbSGQVerLGDIhmFPnNfgZqUtrH = iiLbSGQVerLGDIhmFPnNfgZqUtrH + P_0 + " = " + P_1.ToString() + "\n";
	}
}
