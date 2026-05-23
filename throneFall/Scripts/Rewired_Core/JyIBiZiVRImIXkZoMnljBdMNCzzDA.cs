using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class JyIBiZiVRImIXkZoMnljBdMNCzzDA : IElementIdentifierTool
{
	private Rewired.Internal.GUIText hJbHEvxvLbKvggyXlTHzoeNseMtc;

	private string JaiKDSBLLgpejPWaIEKEMUVAHMLU;

	private int kMgcVdKRNWqazNAzXBWDrMEqqpyR = 1;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		hJbHEvxvLbKvggyXlTHzoeNseMtc = text;
	}

	void IElementIdentifierTool.Initialize(Rewired.Internal.GUIText text)
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
			kMgcVdKRNWqazNAzXBWDrMEqqpyR++;
		}
		if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
		{
			kMgcVdKRNWqazNAzXBWDrMEqqpyR--;
		}
		if (kMgcVdKRNWqazNAzXBWDrMEqqpyR <= 0)
		{
			kMgcVdKRNWqazNAzXBWDrMEqqpyR = 16;
		}
		else if (kMgcVdKRNWqazNAzXBWDrMEqqpyR > 16)
		{
			kMgcVdKRNWqazNAzXBWDrMEqqpyR = 1;
		}
		JaiKDSBLLgpejPWaIEKEMUVAHMLU = "Unity Joystick Element Identifier:\n\n";
		string[] joystickNames = Input.GetJoystickNames();
		if (joystickNames.Length != 0)
		{
			JaiKDSBLLgpejPWaIEKEMUVAHMLU += "Connected joysticks:\n";
		}
		else
		{
			JaiKDSBLLgpejPWaIEKEMUVAHMLU += "No joysticks detected.\n";
		}
		for (int i = 0; i < joystickNames.Length; i++)
		{
			JaiKDSBLLgpejPWaIEKEMUVAHMLU = JaiKDSBLLgpejPWaIEKEMUVAHMLU + "[" + i + "] \"" + joystickNames[i] + "\"";
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(joystickNames[i]))
			{
				JaiKDSBLLgpejPWaIEKEMUVAHMLU += " [UNITY PRE-CONFIGURED]";
			}
			JaiKDSBLLgpejPWaIEKEMUVAHMLU += "\n";
		}
		JaiKDSBLLgpejPWaIEKEMUVAHMLU += "\n";
		JaiKDSBLLgpejPWaIEKEMUVAHMLU = JaiKDSBLLgpejPWaIEKEMUVAHMLU + "Current Unity Joystick Id: " + kMgcVdKRNWqazNAzXBWDrMEqqpyR + "\n";
		JaiKDSBLLgpejPWaIEKEMUVAHMLU += "(Press + or - to change monitored joystick id.)\n\n";
		for (int j = 0; j < 29; j++)
		{
			string text = "Axis " + j;
			float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(kMgcVdKRNWqazNAzXBWDrMEqqpyR, j);
			uNJEUXjaGJqJFAQDxkaNhgBPsoEA(text, joystickAxisValueByJoystickId);
		}
		for (int k = 0; k < 20; k++)
		{
			string text2 = "Button " + k;
			bool joystickButtonValueByJoystickId = UnityInputHelper.GetJoystickButtonValueByJoystickId(kMgcVdKRNWqazNAzXBWDrMEqqpyR, k);
			uNJEUXjaGJqJFAQDxkaNhgBPsoEA(text2, joystickButtonValueByJoystickId);
		}
		hJbHEvxvLbKvggyXlTHzoeNseMtc.text = JaiKDSBLLgpejPWaIEKEMUVAHMLU;
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

	private void uNJEUXjaGJqJFAQDxkaNhgBPsoEA(string P_0, object P_1)
	{
		JaiKDSBLLgpejPWaIEKEMUVAHMLU = JaiKDSBLLgpejPWaIEKEMUVAHMLU + P_0 + " = " + P_1.ToString() + "\n";
	}
}
