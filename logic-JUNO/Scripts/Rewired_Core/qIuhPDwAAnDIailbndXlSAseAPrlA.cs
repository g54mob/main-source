using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class qIuhPDwAAnDIailbndXlSAseAPrlA : IElementIdentifierTool
{
	private Rewired.Internal.GUIText MIPegnebkMeMDXjvCWzdFrYZLKKgA;

	private string yESyHYVdWDsmEQZnxukWNWvdymZF;

	private int JFGOJrSnIjwwWUtmeksTonsReXsW = 1;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		MIPegnebkMeMDXjvCWzdFrYZLKKgA = text;
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
			JFGOJrSnIjwwWUtmeksTonsReXsW++;
		}
		if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
		{
			JFGOJrSnIjwwWUtmeksTonsReXsW--;
		}
		if (JFGOJrSnIjwwWUtmeksTonsReXsW <= 0)
		{
			JFGOJrSnIjwwWUtmeksTonsReXsW = 16;
		}
		else if (JFGOJrSnIjwwWUtmeksTonsReXsW > 16)
		{
			JFGOJrSnIjwwWUtmeksTonsReXsW = 1;
		}
		yESyHYVdWDsmEQZnxukWNWvdymZF = "Unity Joystick Element Identifier:\n\n";
		string[] joystickNames = Input.GetJoystickNames();
		if (joystickNames.Length != 0)
		{
			yESyHYVdWDsmEQZnxukWNWvdymZF += "Connected joysticks:\n";
		}
		else
		{
			yESyHYVdWDsmEQZnxukWNWvdymZF += "No joysticks detected.\n";
		}
		for (int i = 0; i < joystickNames.Length; i++)
		{
			yESyHYVdWDsmEQZnxukWNWvdymZF = yESyHYVdWDsmEQZnxukWNWvdymZF + "[" + i + "] \"" + joystickNames[i] + "\"";
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(joystickNames[i]))
			{
				yESyHYVdWDsmEQZnxukWNWvdymZF += " [UNITY PRE-CONFIGURED]";
			}
			yESyHYVdWDsmEQZnxukWNWvdymZF += "\n";
		}
		yESyHYVdWDsmEQZnxukWNWvdymZF += "\n";
		yESyHYVdWDsmEQZnxukWNWvdymZF = yESyHYVdWDsmEQZnxukWNWvdymZF + "Current Unity Joystick Id: " + JFGOJrSnIjwwWUtmeksTonsReXsW + "\n";
		yESyHYVdWDsmEQZnxukWNWvdymZF += "(Press + or - to change monitored joystick id.)\n\n";
		for (int j = 0; j < 29; j++)
		{
			string text = "Axis " + j;
			float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(JFGOJrSnIjwwWUtmeksTonsReXsW, j);
			RUfghEavrvUqgRXXoeSyzmOgaIkmA(text, joystickAxisValueByJoystickId);
		}
		for (int k = 0; k < 20; k++)
		{
			string text2 = "Button " + k;
			bool joystickButtonValueByJoystickId = UnityInputHelper.GetJoystickButtonValueByJoystickId(JFGOJrSnIjwwWUtmeksTonsReXsW, k);
			RUfghEavrvUqgRXXoeSyzmOgaIkmA(text2, joystickButtonValueByJoystickId);
		}
		MIPegnebkMeMDXjvCWzdFrYZLKKgA.text = yESyHYVdWDsmEQZnxukWNWvdymZF;
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

	private void RUfghEavrvUqgRXXoeSyzmOgaIkmA(string P_0, object P_1)
	{
		yESyHYVdWDsmEQZnxukWNWvdymZF = yESyHYVdWDsmEQZnxukWNWvdymZF + P_0 + " = " + P_1.ToString() + "\n";
	}
}
