using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class kOgVqfOcjKNquuTyxQzAGtlWqeGB : IElementIdentifierTool
{
	private Rewired.Internal.GUIText IiNCcQHoQraDDJcBKbwfUbDtKvZeA;

	private string wZIfaljfuemdUEFZDhpQEHiiZPSQc;

	private int LFGZvCkBqInxCLcWopsPqErhkZzH = 1;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		IiNCcQHoQraDDJcBKbwfUbDtKvZeA = text;
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
			LFGZvCkBqInxCLcWopsPqErhkZzH++;
		}
		if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
		{
			LFGZvCkBqInxCLcWopsPqErhkZzH--;
		}
		if (LFGZvCkBqInxCLcWopsPqErhkZzH <= 0)
		{
			LFGZvCkBqInxCLcWopsPqErhkZzH = 16;
		}
		else if (LFGZvCkBqInxCLcWopsPqErhkZzH > 16)
		{
			LFGZvCkBqInxCLcWopsPqErhkZzH = 1;
		}
		wZIfaljfuemdUEFZDhpQEHiiZPSQc = "Unity Joystick Element Identifier:\n\n";
		string[] joystickNames = Input.GetJoystickNames();
		if (joystickNames.Length != 0)
		{
			wZIfaljfuemdUEFZDhpQEHiiZPSQc += "Connected joysticks:\n";
		}
		else
		{
			wZIfaljfuemdUEFZDhpQEHiiZPSQc += "No joysticks detected.\n";
		}
		for (int i = 0; i < joystickNames.Length; i++)
		{
			wZIfaljfuemdUEFZDhpQEHiiZPSQc = wZIfaljfuemdUEFZDhpQEHiiZPSQc + "[" + i + "] \"" + joystickNames[i] + "\"";
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(joystickNames[i]))
			{
				wZIfaljfuemdUEFZDhpQEHiiZPSQc += " [UNITY PRE-CONFIGURED]";
			}
			wZIfaljfuemdUEFZDhpQEHiiZPSQc += "\n";
		}
		wZIfaljfuemdUEFZDhpQEHiiZPSQc += "\n";
		wZIfaljfuemdUEFZDhpQEHiiZPSQc = wZIfaljfuemdUEFZDhpQEHiiZPSQc + "Current Unity Joystick Id: " + LFGZvCkBqInxCLcWopsPqErhkZzH + "\n";
		wZIfaljfuemdUEFZDhpQEHiiZPSQc += "(Press + or - to change monitored joystick id.)\n\n";
		for (int j = 0; j < 29; j++)
		{
			string text = "Axis " + j;
			float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(LFGZvCkBqInxCLcWopsPqErhkZzH, j);
			HTvtPdFDPUJvaYhpumFqqeVSMdfr(text, joystickAxisValueByJoystickId);
		}
		for (int k = 0; k < 20; k++)
		{
			string text2 = "Button " + k;
			bool joystickButtonValueByJoystickId = UnityInputHelper.GetJoystickButtonValueByJoystickId(LFGZvCkBqInxCLcWopsPqErhkZzH, k);
			HTvtPdFDPUJvaYhpumFqqeVSMdfr(text2, joystickButtonValueByJoystickId);
		}
		IiNCcQHoQraDDJcBKbwfUbDtKvZeA.text = wZIfaljfuemdUEFZDhpQEHiiZPSQc;
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

	private void HTvtPdFDPUJvaYhpumFqqeVSMdfr(string P_0, object P_1)
	{
		wZIfaljfuemdUEFZDhpQEHiiZPSQc = wZIfaljfuemdUEFZDhpQEHiiZPSQc + P_0 + " = " + P_1.ToString() + "\n";
	}
}
