using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class ZoBmmpfqvlKEIRhdhNYsNLNprUb : IElementIdentifierTool
{
	private Rewired.Internal.GUIText SmLrwyNKmhOxtDckCbdycmMwcgW;

	private string kjBfLpiQcLXGhLWcZFokDnldsRvg;

	private int cGALRdkbStEVaVdylxyhrvjxCdI = 1;

	public void Initialize(Rewired.Internal.GUIText P_0)
	{
		SmLrwyNKmhOxtDckCbdycmMwcgW = P_0;
	}

	public void Start()
	{
		string[] joystickNames = Input.GetJoystickNames();
		string text = "Detected " + joystickNames.Length + " attached joysticks";
		string[] array = default(string[]);
		int num2 = default(int);
		while (true)
		{
			int num = -632055454;
			while (true)
			{
				switch (num ^ -632055455)
				{
				case 5:
					break;
				case 3:
				{
					int num3;
					if (joystickNames.Length <= 0)
					{
						num = -632055453;
						num3 = num;
					}
					else
					{
						num = -632055456;
						num3 = num;
					}
					continue;
				}
				case 1:
					text += ":\n";
					num = -632055453;
					continue;
				case 2:
					array = joystickNames;
					num2 = 0;
					num = -632055451;
					continue;
				case 0:
				{
					string text2 = array[num2];
					text = text + "\"" + text2 + "\"\n";
					num2++;
					num = -632055451;
					continue;
				}
				default:
					if (num2 >= array.Length)
					{
						Rewired.Logger.Log(text);
						return;
					}
					goto case 0;
				}
				break;
			}
		}
	}

	public void Update()
	{
		if (!Input.GetKeyDown(KeyCode.Equals) && !Input.GetKeyDown(KeyCode.Plus))
		{
			if (Input.GetKeyDown(KeyCode.KeypadPlus))
			{
				goto IL_0027;
			}
			goto IL_00b9;
		}
		goto IL_024b;
		IL_00b9:
		int num;
		int num2;
		if (!Input.GetKeyDown(KeyCode.KeypadMinus))
		{
			num = -288597108;
			num2 = num;
		}
		else
		{
			num = -288597105;
			num2 = num;
		}
		goto IL_002c;
		IL_024b:
		cGALRdkbStEVaVdylxyhrvjxCdI++;
		num = -288597106;
		goto IL_002c;
		IL_0027:
		num = -288597096;
		goto IL_002c;
		IL_002c:
		int num4 = default(int);
		int num3 = default(int);
		int num5 = default(int);
		string[] joystickNames = default(string[]);
		while (true)
		{
			switch (num ^ -288597092)
			{
			case 15:
				break;
			case 3:
				if (num4 >= 29)
				{
					num3 = 0;
					num = -288597103;
					continue;
				}
				goto case 12;
			case 18:
				goto IL_00b9;
			case 19:
				cGALRdkbStEVaVdylxyhrvjxCdI--;
				num = -288597100;
				continue;
			case 16:
				goto IL_00f1;
			case 21:
			{
				object obj2 = kjBfLpiQcLXGhLWcZFokDnldsRvg;
				kjBfLpiQcLXGhLWcZFokDnldsRvg = string.Concat(obj2, "[", num5, "] \"", joystickNames[num5], "\"");
				if (UnityTools.platform == Platform.Linux)
				{
					goto IL_0168;
				}
				goto case 5;
			}
			case 0:
				num4++;
				num = -288597089;
				continue;
			case 24:
				num5 = 0;
				num = -288597109;
				continue;
			case 8:
				if (cGALRdkbStEVaVdylxyhrvjxCdI <= 0)
				{
					cGALRdkbStEVaVdylxyhrvjxCdI = 16;
					num = -288597090;
					continue;
				}
				goto case 14;
			case 6:
				kjBfLpiQcLXGhLWcZFokDnldsRvg = "Unity Joystick Element Identifier:\n\n";
				num = -288597110;
				continue;
			case 1:
				kjBfLpiQcLXGhLWcZFokDnldsRvg += " [UNITY PRE-CONFIGURED]";
				num = -288597095;
				continue;
			case 13:
				num = -288597093;
				continue;
			case 9:
				num5++;
				num = -288597109;
				continue;
			case 10:
			{
				string text = "Button " + num3;
				bool joystickButtonValueByJoystickId = UnityInputHelper.GetJoystickButtonValueByJoystickId(cGALRdkbStEVaVdylxyhrvjxCdI, num3);
				zsGBKYkpPoIfFUZODmNcqvxUrZf(text, joystickButtonValueByJoystickId);
				num = -288597107;
				continue;
			}
			case 4:
				goto IL_024b;
			case 20:
			{
				kjBfLpiQcLXGhLWcZFokDnldsRvg += "\n";
				object obj = kjBfLpiQcLXGhLWcZFokDnldsRvg;
				kjBfLpiQcLXGhLWcZFokDnldsRvg = string.Concat(obj, "Current Unity Joystick Id: ", cGALRdkbStEVaVdylxyhrvjxCdI, "\n");
				kjBfLpiQcLXGhLWcZFokDnldsRvg += "(Press + or - to change monitored joystick id.)\n\n";
				num4 = 0;
				num = -288597089;
				continue;
			}
			case 25:
				kjBfLpiQcLXGhLWcZFokDnldsRvg += "No joysticks detected.\n";
				num = -288597116;
				continue;
			case 17:
				num3++;
				num = -288597093;
				continue;
			case 11:
				num = -288597116;
				continue;
			case 14:
				if (cGALRdkbStEVaVdylxyhrvjxCdI > 16)
				{
					cGALRdkbStEVaVdylxyhrvjxCdI = 1;
					num = -288597094;
					continue;
				}
				goto case 6;
			case 2:
				num = -288597094;
				continue;
			case 12:
			{
				string text2 = "Axis " + num4;
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(cGALRdkbStEVaVdylxyhrvjxCdI, num4);
				zsGBKYkpPoIfFUZODmNcqvxUrZf(text2, joystickAxisValueByJoystickId);
				num = -288597092;
				continue;
			}
			case 22:
				joystickNames = Input.GetJoystickNames();
				if (joystickNames.Length > 0)
				{
					kjBfLpiQcLXGhLWcZFokDnldsRvg += "Connected joysticks:\n";
					num = -288597097;
					continue;
				}
				goto case 25;
			case 23:
				goto IL_03a7;
			case 5:
				kjBfLpiQcLXGhLWcZFokDnldsRvg += "\n";
				num = -288597099;
				continue;
			default:
				if (num3 >= 20)
				{
					SmLrwyNKmhOxtDckCbdycmMwcgW.text = kjBfLpiQcLXGhLWcZFokDnldsRvg;
					return;
				}
				goto case 10;
			}
			break;
			IL_03a7:
			int num6;
			if (num5 >= joystickNames.Length)
			{
				num = -288597112;
				num6 = num;
			}
			else
			{
				num = -288597111;
				num6 = num;
			}
			continue;
			IL_0168:
			int num7;
			if (UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(joystickNames[num5]))
			{
				num = -288597091;
				num7 = num;
			}
			else
			{
				num = -288597095;
				num7 = num;
			}
			continue;
			IL_00f1:
			int num8;
			if (Input.GetKeyDown(KeyCode.Minus))
			{
				num = -288597105;
				num8 = num;
			}
			else
			{
				num = -288597100;
				num8 = num;
			}
		}
		goto IL_0027;
	}

	public void OnDestroy()
	{
	}

	private void zsGBKYkpPoIfFUZODmNcqvxUrZf(string P_0, object P_1)
	{
		string text = kjBfLpiQcLXGhLWcZFokDnldsRvg;
		kjBfLpiQcLXGhLWcZFokDnldsRvg = text + P_0 + " = " + P_1.ToString() + "\n";
	}
}
