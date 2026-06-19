using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class mQlGRRnbLWhhTtcJnIqlEtsWmB : IElementIdentifierTool
{
	private Rewired.Internal.GUIText dDGiBMcxcXzdMtFbyWrueSmpMSib;

	private string ZtQplVasmrxKEGPbfkzoBTNqpPN;

	private int TvZTrPYJEBpoZZMlRZklLcNiTFw = 1;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		dDGiBMcxcXzdMtFbyWrueSmpMSib = text;
	}

	public void Start()
	{
		string[] joystickNames = Input.GetJoystickNames();
		string text = "Detected " + joystickNames.Length + " attached joysticks";
		if (joystickNames.Length > 0)
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

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			TvZTrPYJEBpoZZMlRZklLcNiTFw++;
		}
		if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
		{
			TvZTrPYJEBpoZZMlRZklLcNiTFw--;
		}
		if (TvZTrPYJEBpoZZMlRZklLcNiTFw <= 0)
		{
			TvZTrPYJEBpoZZMlRZklLcNiTFw = 16;
		}
		else if (TvZTrPYJEBpoZZMlRZklLcNiTFw > 16)
		{
			TvZTrPYJEBpoZZMlRZklLcNiTFw = 1;
		}
		ZtQplVasmrxKEGPbfkzoBTNqpPN = "Unity Joystick Element Identifier:\n\n";
		string[] joystickNames = Input.GetJoystickNames();
		if (joystickNames.Length > 0)
		{
			ZtQplVasmrxKEGPbfkzoBTNqpPN += "Connected joysticks:\n";
		}
		else
		{
			ZtQplVasmrxKEGPbfkzoBTNqpPN += "No joysticks detected.\n";
		}
		for (int i = 0; i < joystickNames.Length; i++)
		{
			object ztQplVasmrxKEGPbfkzoBTNqpPN = ZtQplVasmrxKEGPbfkzoBTNqpPN;
			ZtQplVasmrxKEGPbfkzoBTNqpPN = string.Concat(ztQplVasmrxKEGPbfkzoBTNqpPN, "[", i, "] \"", joystickNames[i], "\"");
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(joystickNames[i]))
			{
				ZtQplVasmrxKEGPbfkzoBTNqpPN += " [UNITY PRE-CONFIGURED]";
			}
			ZtQplVasmrxKEGPbfkzoBTNqpPN += "\n";
		}
		ZtQplVasmrxKEGPbfkzoBTNqpPN += "\n";
		object ztQplVasmrxKEGPbfkzoBTNqpPN2 = ZtQplVasmrxKEGPbfkzoBTNqpPN;
		ZtQplVasmrxKEGPbfkzoBTNqpPN = string.Concat(ztQplVasmrxKEGPbfkzoBTNqpPN2, "Current Unity Joystick Id: ", TvZTrPYJEBpoZZMlRZklLcNiTFw, "\n");
		ZtQplVasmrxKEGPbfkzoBTNqpPN += "(Press + or - to change monitored joystick id.)\n\n";
		for (int j = 0; j < 29; j++)
		{
			string text = "Axis " + j;
			float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(TvZTrPYJEBpoZZMlRZklLcNiTFw, j);
			QGJwAwZrJECKgTIZfVXwPALPczB(text, joystickAxisValueByJoystickId);
		}
		for (int k = 0; k < 20; k++)
		{
			string text2 = "Button " + k;
			bool joystickButtonValueByJoystickId = UnityInputHelper.GetJoystickButtonValueByJoystickId(TvZTrPYJEBpoZZMlRZklLcNiTFw, k);
			QGJwAwZrJECKgTIZfVXwPALPczB(text2, joystickButtonValueByJoystickId);
		}
		dDGiBMcxcXzdMtFbyWrueSmpMSib.text = ZtQplVasmrxKEGPbfkzoBTNqpPN;
	}

	public void OnDestroy()
	{
	}

	private void QGJwAwZrJECKgTIZfVXwPALPczB(string P_0, object P_1)
	{
		string ztQplVasmrxKEGPbfkzoBTNqpPN = ZtQplVasmrxKEGPbfkzoBTNqpPN;
		ZtQplVasmrxKEGPbfkzoBTNqpPN = ztQplVasmrxKEGPbfkzoBTNqpPN + P_0 + " = " + P_1.ToString() + "\n";
	}
}
