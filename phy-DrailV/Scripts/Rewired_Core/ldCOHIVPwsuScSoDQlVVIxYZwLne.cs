using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class ldCOHIVPwsuScSoDQlVVIxYZwLne : IElementIdentifierTool
{
	private Rewired.Internal.GUIText miWeTBJzAasgTwIpzkGTbWcSgGKaA;

	private string OMEzGKcRIOkkLZDnmeZDqwNJBbdR;

	private int IAJXlKGyqoalSWYzGNVWcWDXLHOr = 1;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		miWeTBJzAasgTwIpzkGTbWcSgGKaA = text;
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
			IAJXlKGyqoalSWYzGNVWcWDXLHOr++;
		}
		if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
		{
			IAJXlKGyqoalSWYzGNVWcWDXLHOr--;
		}
		if (IAJXlKGyqoalSWYzGNVWcWDXLHOr <= 0)
		{
			IAJXlKGyqoalSWYzGNVWcWDXLHOr = 16;
		}
		else if (IAJXlKGyqoalSWYzGNVWcWDXLHOr > 16)
		{
			IAJXlKGyqoalSWYzGNVWcWDXLHOr = 1;
		}
		OMEzGKcRIOkkLZDnmeZDqwNJBbdR = "Unity Joystick Element Identifier:\n\n";
		string[] joystickNames = Input.GetJoystickNames();
		if (joystickNames.Length != 0)
		{
			OMEzGKcRIOkkLZDnmeZDqwNJBbdR += "Connected joysticks:\n";
		}
		else
		{
			OMEzGKcRIOkkLZDnmeZDqwNJBbdR += "No joysticks detected.\n";
		}
		for (int i = 0; i < joystickNames.Length; i++)
		{
			OMEzGKcRIOkkLZDnmeZDqwNJBbdR = OMEzGKcRIOkkLZDnmeZDqwNJBbdR + "[" + i + "] \"" + joystickNames[i] + "\"";
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(joystickNames[i]))
			{
				OMEzGKcRIOkkLZDnmeZDqwNJBbdR += " [UNITY PRE-CONFIGURED]";
			}
			OMEzGKcRIOkkLZDnmeZDqwNJBbdR += "\n";
		}
		OMEzGKcRIOkkLZDnmeZDqwNJBbdR += "\n";
		OMEzGKcRIOkkLZDnmeZDqwNJBbdR = OMEzGKcRIOkkLZDnmeZDqwNJBbdR + "Current Unity Joystick Id: " + IAJXlKGyqoalSWYzGNVWcWDXLHOr + "\n";
		OMEzGKcRIOkkLZDnmeZDqwNJBbdR += "(Press + or - to change monitored joystick id.)\n\n";
		for (int j = 0; j < 29; j++)
		{
			string text = "Axis " + j;
			float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(IAJXlKGyqoalSWYzGNVWcWDXLHOr, j);
			LhTauhLUnlFMpKnHuenDeGLkjOpJ(text, joystickAxisValueByJoystickId);
		}
		for (int k = 0; k < 20; k++)
		{
			string text2 = "Button " + k;
			bool joystickButtonValueByJoystickId = UnityInputHelper.GetJoystickButtonValueByJoystickId(IAJXlKGyqoalSWYzGNVWcWDXLHOr, k);
			LhTauhLUnlFMpKnHuenDeGLkjOpJ(text2, joystickButtonValueByJoystickId);
		}
		miWeTBJzAasgTwIpzkGTbWcSgGKaA.text = OMEzGKcRIOkkLZDnmeZDqwNJBbdR;
	}

	public void OnDestroy()
	{
	}

	private void LhTauhLUnlFMpKnHuenDeGLkjOpJ(string P_0, object P_1)
	{
		OMEzGKcRIOkkLZDnmeZDqwNJBbdR = OMEzGKcRIOkkLZDnmeZDqwNJBbdR + P_0 + " = " + P_1.ToString() + "\n";
	}
}
