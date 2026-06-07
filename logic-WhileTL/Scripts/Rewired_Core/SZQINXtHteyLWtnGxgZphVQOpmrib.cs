using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class SZQINXtHteyLWtnGxgZphVQOpmrib : IElementIdentifierTool
{
	private Rewired.Internal.GUIText XlESKKNDuaCDfpWHQgajoeFFEKCfA;

	private string jJYVyLMywCPJpwTZDIfxviqQAtlIA;

	private int rrNgZTsuAmUvqtwPbxksvvoGPLAF = 1;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		XlESKKNDuaCDfpWHQgajoeFFEKCfA = text;
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

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			rrNgZTsuAmUvqtwPbxksvvoGPLAF++;
		}
		if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
		{
			rrNgZTsuAmUvqtwPbxksvvoGPLAF--;
		}
		if (rrNgZTsuAmUvqtwPbxksvvoGPLAF <= 0)
		{
			rrNgZTsuAmUvqtwPbxksvvoGPLAF = 16;
		}
		else if (rrNgZTsuAmUvqtwPbxksvvoGPLAF > 16)
		{
			rrNgZTsuAmUvqtwPbxksvvoGPLAF = 1;
		}
		jJYVyLMywCPJpwTZDIfxviqQAtlIA = "Unity Joystick Element Identifier:\n\n";
		string[] joystickNames = Input.GetJoystickNames();
		if (joystickNames.Length != 0)
		{
			jJYVyLMywCPJpwTZDIfxviqQAtlIA += "Connected joysticks:\n";
		}
		else
		{
			jJYVyLMywCPJpwTZDIfxviqQAtlIA += "No joysticks detected.\n";
		}
		for (int i = 0; i < joystickNames.Length; i++)
		{
			jJYVyLMywCPJpwTZDIfxviqQAtlIA = jJYVyLMywCPJpwTZDIfxviqQAtlIA + "[" + i + "] \"" + joystickNames[i] + "\"";
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(joystickNames[i]))
			{
				jJYVyLMywCPJpwTZDIfxviqQAtlIA += " [UNITY PRE-CONFIGURED]";
			}
			jJYVyLMywCPJpwTZDIfxviqQAtlIA += "\n";
		}
		jJYVyLMywCPJpwTZDIfxviqQAtlIA += "\n";
		jJYVyLMywCPJpwTZDIfxviqQAtlIA = jJYVyLMywCPJpwTZDIfxviqQAtlIA + "Current Unity Joystick Id: " + rrNgZTsuAmUvqtwPbxksvvoGPLAF + "\n";
		jJYVyLMywCPJpwTZDIfxviqQAtlIA += "(Press + or - to change monitored joystick id.)\n\n";
		for (int j = 0; j < 29; j++)
		{
			string text = "Axis " + j;
			float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(rrNgZTsuAmUvqtwPbxksvvoGPLAF, j);
			sDLblserRrugFMxhDNObUduvbtfzA(text, joystickAxisValueByJoystickId);
		}
		for (int k = 0; k < 20; k++)
		{
			string text2 = "Button " + k;
			bool joystickButtonValueByJoystickId = UnityInputHelper.GetJoystickButtonValueByJoystickId(rrNgZTsuAmUvqtwPbxksvvoGPLAF, k);
			sDLblserRrugFMxhDNObUduvbtfzA(text2, joystickButtonValueByJoystickId);
		}
		XlESKKNDuaCDfpWHQgajoeFFEKCfA.text = jJYVyLMywCPJpwTZDIfxviqQAtlIA;
	}

	public void OnDestroy()
	{
	}

	private void sDLblserRrugFMxhDNObUduvbtfzA(string P_0, object P_1)
	{
		jJYVyLMywCPJpwTZDIfxviqQAtlIA = jJYVyLMywCPJpwTZDIfxviqQAtlIA + P_0 + " = " + P_1.ToString() + "\n";
	}
}
