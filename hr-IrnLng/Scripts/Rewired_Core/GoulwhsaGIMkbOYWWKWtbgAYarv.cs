using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class GoulwhsaGIMkbOYWWKWtbgAYarv : IElementIdentifierTool
{
	private Rewired.Internal.GUIText TMuPukIeFUTOAWaVpBttCVZLVIW;

	private string pGiSdrFZbwYgAFVDisHlXqvEfIv;

	private int xfxfYbdZbWPHZUiPOYouFIaWgNSf = 1;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		TMuPukIeFUTOAWaVpBttCVZLVIW = text;
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
			xfxfYbdZbWPHZUiPOYouFIaWgNSf++;
		}
		if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
		{
			xfxfYbdZbWPHZUiPOYouFIaWgNSf--;
		}
		if (xfxfYbdZbWPHZUiPOYouFIaWgNSf <= 0)
		{
			xfxfYbdZbWPHZUiPOYouFIaWgNSf = 16;
		}
		else if (xfxfYbdZbWPHZUiPOYouFIaWgNSf > 16)
		{
			xfxfYbdZbWPHZUiPOYouFIaWgNSf = 1;
		}
		pGiSdrFZbwYgAFVDisHlXqvEfIv = "Unity Joystick Element Identifier:\n\n";
		string[] joystickNames = Input.GetJoystickNames();
		if (joystickNames.Length > 0)
		{
			pGiSdrFZbwYgAFVDisHlXqvEfIv += "Connected joysticks:\n";
		}
		else
		{
			pGiSdrFZbwYgAFVDisHlXqvEfIv += "No joysticks detected.\n";
		}
		for (int i = 0; i < joystickNames.Length; i++)
		{
			object obj = pGiSdrFZbwYgAFVDisHlXqvEfIv;
			pGiSdrFZbwYgAFVDisHlXqvEfIv = string.Concat(obj, "[", i, "] \"", joystickNames[i], "\"");
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(joystickNames[i]))
			{
				pGiSdrFZbwYgAFVDisHlXqvEfIv += " [UNITY PRE-CONFIGURED]";
			}
			pGiSdrFZbwYgAFVDisHlXqvEfIv += "\n";
		}
		pGiSdrFZbwYgAFVDisHlXqvEfIv += "\n";
		object obj2 = pGiSdrFZbwYgAFVDisHlXqvEfIv;
		pGiSdrFZbwYgAFVDisHlXqvEfIv = string.Concat(obj2, "Current Unity Joystick Id: ", xfxfYbdZbWPHZUiPOYouFIaWgNSf, "\n");
		pGiSdrFZbwYgAFVDisHlXqvEfIv += "(Press + or - to change monitored joystick id.)\n\n";
		for (int j = 0; j < 29; j++)
		{
			string text = "Axis " + j;
			float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(xfxfYbdZbWPHZUiPOYouFIaWgNSf, j);
			ghZLWwtaRkxoGhhqpJvHByjLpv(text, joystickAxisValueByJoystickId);
		}
		for (int k = 0; k < 20; k++)
		{
			string text2 = "Button " + k;
			bool joystickButtonValueByJoystickId = UnityInputHelper.GetJoystickButtonValueByJoystickId(xfxfYbdZbWPHZUiPOYouFIaWgNSf, k);
			ghZLWwtaRkxoGhhqpJvHByjLpv(text2, joystickButtonValueByJoystickId);
		}
		TMuPukIeFUTOAWaVpBttCVZLVIW.text = pGiSdrFZbwYgAFVDisHlXqvEfIv;
	}

	public void OnDestroy()
	{
	}

	private void ghZLWwtaRkxoGhhqpJvHByjLpv(string P_0, object P_1)
	{
		string text = pGiSdrFZbwYgAFVDisHlXqvEfIv;
		pGiSdrFZbwYgAFVDisHlXqvEfIv = text + P_0 + " = " + P_1.ToString() + "\n";
	}
}
