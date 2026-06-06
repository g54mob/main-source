using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class ooqJkpsBSWIDQBazgNVCPOfbzfkO : IElementIdentifierTool
{
	private Rewired.Internal.GUIText WRSaPdBinAZdfLzLXlWqsLYxwXfA;

	private string iZEfasRwIuPxagGnmYmzYEcgNIGo;

	private int DkOTZHYBYQjVewiybwSqldrUdmrl = 1;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		WRSaPdBinAZdfLzLXlWqsLYxwXfA = text;
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
			DkOTZHYBYQjVewiybwSqldrUdmrl++;
		}
		if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
		{
			DkOTZHYBYQjVewiybwSqldrUdmrl--;
		}
		if (DkOTZHYBYQjVewiybwSqldrUdmrl <= 0)
		{
			DkOTZHYBYQjVewiybwSqldrUdmrl = 16;
		}
		else if (DkOTZHYBYQjVewiybwSqldrUdmrl > 16)
		{
			DkOTZHYBYQjVewiybwSqldrUdmrl = 1;
		}
		iZEfasRwIuPxagGnmYmzYEcgNIGo = "Unity Joystick Element Identifier:\n\n";
		string[] joystickNames = Input.GetJoystickNames();
		if (joystickNames.Length != 0)
		{
			iZEfasRwIuPxagGnmYmzYEcgNIGo += "Connected joysticks:\n";
		}
		else
		{
			iZEfasRwIuPxagGnmYmzYEcgNIGo += "No joysticks detected.\n";
		}
		for (int i = 0; i < joystickNames.Length; i++)
		{
			iZEfasRwIuPxagGnmYmzYEcgNIGo = iZEfasRwIuPxagGnmYmzYEcgNIGo + "[" + i + "] \"" + joystickNames[i] + "\"";
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(joystickNames[i]))
			{
				iZEfasRwIuPxagGnmYmzYEcgNIGo += " [UNITY PRE-CONFIGURED]";
			}
			iZEfasRwIuPxagGnmYmzYEcgNIGo += "\n";
		}
		iZEfasRwIuPxagGnmYmzYEcgNIGo += "\n";
		iZEfasRwIuPxagGnmYmzYEcgNIGo = iZEfasRwIuPxagGnmYmzYEcgNIGo + "Current Unity Joystick Id: " + DkOTZHYBYQjVewiybwSqldrUdmrl + "\n";
		iZEfasRwIuPxagGnmYmzYEcgNIGo += "(Press + or - to change monitored joystick id.)\n\n";
		for (int j = 0; j < 29; j++)
		{
			string text = "Axis " + j;
			float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(DkOTZHYBYQjVewiybwSqldrUdmrl, j);
			JVdjiQlnRMzCstTljWTenNxlkfHc(text, joystickAxisValueByJoystickId);
		}
		for (int k = 0; k < 20; k++)
		{
			string text2 = "Button " + k;
			bool joystickButtonValueByJoystickId = UnityInputHelper.GetJoystickButtonValueByJoystickId(DkOTZHYBYQjVewiybwSqldrUdmrl, k);
			JVdjiQlnRMzCstTljWTenNxlkfHc(text2, joystickButtonValueByJoystickId);
		}
		WRSaPdBinAZdfLzLXlWqsLYxwXfA.text = iZEfasRwIuPxagGnmYmzYEcgNIGo;
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

	private void JVdjiQlnRMzCstTljWTenNxlkfHc(string P_0, object P_1)
	{
		iZEfasRwIuPxagGnmYmzYEcgNIGo = iZEfasRwIuPxagGnmYmzYEcgNIGo + P_0 + " = " + P_1.ToString() + "\n";
	}
}
