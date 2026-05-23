using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class kpDhpqDOpflhbpqcXmUaqQLlTBq : IElementIdentifierTool
{
	private Rewired.Internal.GUIText nwBcvbvCejFhAlVhwKhyXpYsEfBd;

	private string NzNXKkqawRbnKarvdCweEYntVYiL;

	private int FBYMQwALOpmzRxvrXuYbGBjhwPV = 1;

	public void Initialize(Rewired.Internal.GUIText P_0)
	{
		nwBcvbvCejFhAlVhwKhyXpYsEfBd = P_0;
	}

	public void Start()
	{
		string[] joystickNames = Input.GetJoystickNames();
		string text = "Detected " + joystickNames.Length + " attached joysticks";
		if (joystickNames.Length > 0)
		{
			text += ":\n";
			goto IL_0030;
		}
		goto IL_0081;
		IL_0081:
		string[] array = joystickNames;
		int num = 0;
		int num2 = 1998499869;
		goto IL_0035;
		IL_0030:
		num2 = 1998499864;
		goto IL_0035;
		IL_0035:
		while (true)
		{
			switch (num2 ^ 0x771EB01C)
			{
			case 0:
				break;
			case 3:
			{
				string text2 = array[num];
				text = text + "\"" + text2 + "\"\n";
				num++;
				num2 = 1998499870;
				continue;
			}
			case 1:
				num2 = 1998499870;
				continue;
			case 4:
				goto IL_0081;
			default:
				if (num >= array.Length)
				{
					Rewired.Logger.Log(text);
					return;
				}
				goto case 3;
			}
			break;
		}
		goto IL_0030;
	}

	public void Update()
	{
		if (!Input.GetKeyDown(KeyCode.Equals))
		{
			goto IL_000c;
		}
		goto IL_01db;
		IL_000c:
		int num = -1424580054;
		goto IL_0011;
		IL_0011:
		int num4 = default(int);
		int num2 = default(int);
		int num3 = default(int);
		string[] joystickNames = default(string[]);
		while (true)
		{
			switch (num ^ -1424580064)
			{
			case 17:
				break;
			default:
				return;
			case 3:
				if (num4 >= 29)
				{
					num2 = 0;
					num = -1424580051;
					continue;
				}
				goto case 0;
			case 14:
				FBYMQwALOpmzRxvrXuYbGBjhwPV--;
				num = -1424580049;
				continue;
			case 7:
				NzNXKkqawRbnKarvdCweEYntVYiL += "No joysticks detected.\n";
				num = -1424580060;
				continue;
			case 2:
				if (Input.GetKeyDown(KeyCode.KeypadMinus))
				{
					goto case 14;
				}
				goto IL_00d3;
			case 13:
				goto IL_00f0;
			case 0:
			{
				string text2 = "Axis " + num4;
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(FBYMQwALOpmzRxvrXuYbGBjhwPV, num4);
				OoQWHLFmBazOunoXflNqIRjOvQe(text2, joystickAxisValueByJoystickId);
				num4++;
				num = -1424580061;
				continue;
			}
			case 20:
			{
				object nzNXKkqawRbnKarvdCweEYntVYiL2 = NzNXKkqawRbnKarvdCweEYntVYiL;
				NzNXKkqawRbnKarvdCweEYntVYiL = string.Concat(nzNXKkqawRbnKarvdCweEYntVYiL2, "[", num3, "] \"", joystickNames[num3], "\"");
				if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(joystickNames[num3]))
				{
					NzNXKkqawRbnKarvdCweEYntVYiL += " [UNITY PRE-CONFIGURED]";
					num = -1424580043;
					continue;
				}
				goto case 21;
			}
			case 6:
				num = -1424580060;
				continue;
			case 22:
				goto IL_01db;
			case 12:
				if (num3 >= joystickNames.Length)
				{
					NzNXKkqawRbnKarvdCweEYntVYiL += "\n";
					object nzNXKkqawRbnKarvdCweEYntVYiL = NzNXKkqawRbnKarvdCweEYntVYiL;
					NzNXKkqawRbnKarvdCweEYntVYiL = string.Concat(nzNXKkqawRbnKarvdCweEYntVYiL, "Current Unity Joystick Id: ", FBYMQwALOpmzRxvrXuYbGBjhwPV, "\n");
					NzNXKkqawRbnKarvdCweEYntVYiL += "(Press + or - to change monitored joystick id.)\n\n";
					num = -1424580063;
					continue;
				}
				goto case 20;
			case 9:
				goto IL_0276;
			case 5:
				num = -1424580052;
				continue;
			case 10:
				goto IL_02a0;
			case 1:
				num4 = 0;
				num = -1424580061;
				continue;
			case 4:
				num3 = 0;
				num = -1424580059;
				continue;
			case 15:
				if (FBYMQwALOpmzRxvrXuYbGBjhwPV <= 0)
				{
					FBYMQwALOpmzRxvrXuYbGBjhwPV = 11;
					num = -1424580056;
					continue;
				}
				goto case 11;
			case 18:
			{
				string text = "Button " + num2;
				bool joystickButtonValueByJoystickId = UnityInputHelper.GetJoystickButtonValueByJoystickId(FBYMQwALOpmzRxvrXuYbGBjhwPV, num2);
				OoQWHLFmBazOunoXflNqIRjOvQe(text, joystickButtonValueByJoystickId);
				num2++;
				num = -1424580051;
				continue;
			}
			case 11:
				if (FBYMQwALOpmzRxvrXuYbGBjhwPV > 11)
				{
					FBYMQwALOpmzRxvrXuYbGBjhwPV = 1;
					num = -1424580056;
					continue;
				}
				goto case 8;
			case 8:
				NzNXKkqawRbnKarvdCweEYntVYiL = "Unity Joystick Element Identifier:\n\n";
				joystickNames = Input.GetJoystickNames();
				if (joystickNames.Length > 0)
				{
					NzNXKkqawRbnKarvdCweEYntVYiL += "Connected joysticks:\n";
					num = -1424580058;
					continue;
				}
				goto case 7;
			case 16:
				nwBcvbvCejFhAlVhwKhyXpYsEfBd.text = NzNXKkqawRbnKarvdCweEYntVYiL;
				num = -1424580045;
				continue;
			case 21:
				NzNXKkqawRbnKarvdCweEYntVYiL += "\n";
				num3++;
				num = -1424580052;
				continue;
			case 19:
				return;
			}
			break;
			IL_02a0:
			int num5;
			if (Input.GetKeyDown(KeyCode.Plus))
			{
				num = -1424580042;
				num5 = num;
			}
			else
			{
				num = -1424580055;
				num5 = num;
			}
			continue;
			IL_00f0:
			int num6;
			if (num2 >= 20)
			{
				num = -1424580048;
				num6 = num;
			}
			else
			{
				num = -1424580046;
				num6 = num;
			}
			continue;
			IL_00d3:
			int num7;
			if (!Input.GetKeyDown(KeyCode.Minus))
			{
				num = -1424580049;
				num7 = num;
			}
			else
			{
				num = -1424580050;
				num7 = num;
			}
			continue;
			IL_0276:
			int num8;
			if (Input.GetKeyDown(KeyCode.KeypadPlus))
			{
				num = -1424580042;
				num8 = num;
			}
			else
			{
				num = -1424580062;
				num8 = num;
			}
		}
		goto IL_000c;
		IL_01db:
		FBYMQwALOpmzRxvrXuYbGBjhwPV++;
		num = -1424580062;
		goto IL_0011;
	}

	public void OnDestroy()
	{
	}

	private void OoQWHLFmBazOunoXflNqIRjOvQe(string P_0, object P_1)
	{
		string nzNXKkqawRbnKarvdCweEYntVYiL = NzNXKkqawRbnKarvdCweEYntVYiL;
		NzNXKkqawRbnKarvdCweEYntVYiL = nzNXKkqawRbnKarvdCweEYntVYiL + P_0 + " = " + P_1.ToString() + "\n";
	}
}
