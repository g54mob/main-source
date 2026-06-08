using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class spBBieTDEjAXVoJIoAvlDgncYNW : IElementIdentifierTool
{
	private Rewired.Internal.GUIText hLVjSfvXBhNJmmNBXyOzuJevnvj;

	private string FhBoqkkGJRRzonEFAPzvzuHaGZY;

	private int XfYmeaSijfRMtexJwnPatAHuWen = 1;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		hLVjSfvXBhNJmmNBXyOzuJevnvj = text;
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
		goto IL_005a;
		IL_005a:
		string[] array = joystickNames;
		int num = 0;
		int num2 = 1049779947;
		goto IL_0035;
		IL_0030:
		num2 = 1049779951;
		goto IL_0035;
		IL_0035:
		while (true)
		{
			switch (num2 ^ 0x3E925EEE)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_005a;
			case 2:
			{
				string text2 = array[num];
				text = text + "\"" + text2 + "\"\n";
				num++;
				num2 = 1049779949;
				continue;
			}
			case 5:
				num2 = 1049779949;
				continue;
			case 3:
				if (num >= array.Length)
				{
					Rewired.Logger.Log(text);
					num2 = 1049779946;
					continue;
				}
				goto case 2;
			case 4:
				return;
			}
			break;
		}
		goto IL_0030;
	}

	public void Update()
	{
		if (!Input.GetKeyDown(KeyCode.Equals) && !Input.GetKeyDown(KeyCode.Plus))
		{
			goto IL_0018;
		}
		goto IL_02f1;
		IL_02f1:
		XfYmeaSijfRMtexJwnPatAHuWen++;
		int num = 2032439500;
		goto IL_001d;
		IL_0018:
		num = 2032439516;
		goto IL_001d;
		IL_001d:
		string text = default(string);
		int num3 = default(int);
		int num4 = default(int);
		int num2 = default(int);
		string text2 = default(string);
		string[] joystickNames = default(string[]);
		while (true)
		{
			switch (num ^ 0x792490CF)
			{
			case 9:
				break;
			case 12:
				text = "Axis " + num3;
				num = 2032439515;
				continue;
			case 15:
				FhBoqkkGJRRzonEFAPzvzuHaGZY += "No joysticks detected.\n";
				num = 2032439513;
				continue;
			case 17:
				if (num3 >= 29)
				{
					num4 = 0;
					num = 2032439498;
					continue;
				}
				goto case 12;
			case 19:
				goto IL_00ee;
			case 22:
				num2 = 0;
				num = 2032439492;
				continue;
			case 27:
				num3 = 0;
				num = 2032439518;
				continue;
			case 28:
				FhBoqkkGJRRzonEFAPzvzuHaGZY += "(Press + or - to change monitored joystick id.)\n\n";
				num = 2032439508;
				continue;
			case 24:
				text2 = "Button " + num4;
				num = 2032439490;
				continue;
			case 4:
			{
				object fhBoqkkGJRRzonEFAPzvzuHaGZY2 = FhBoqkkGJRRzonEFAPzvzuHaGZY;
				FhBoqkkGJRRzonEFAPzvzuHaGZY = string.Concat(fhBoqkkGJRRzonEFAPzvzuHaGZY2, "[", num2, "] \"", joystickNames[num2], "\"");
				num = 2032439497;
				continue;
			}
			case 18:
				FhBoqkkGJRRzonEFAPzvzuHaGZY = "Unity Joystick Element Identifier:\n\n";
				joystickNames = Input.GetJoystickNames();
				if (joystickNames.Length > 0)
				{
					FhBoqkkGJRRzonEFAPzvzuHaGZY += "Connected joysticks:\n";
					num = 2032439513;
					continue;
				}
				goto case 15;
			case 3:
				goto IL_01f6;
			case 11:
				num = 2032439503;
				continue;
			case 6:
				goto IL_0220;
			case 0:
				goto IL_023c;
			case 13:
			{
				bool joystickButtonValueByJoystickId = UnityInputHelper.GetJoystickButtonValueByJoystickId(XfYmeaSijfRMtexJwnPatAHuWen, num4);
				SlUfsNNegekRSmbkYsdxdTGRWMY(text2, joystickButtonValueByJoystickId);
				num4++;
				num = 2032439498;
				continue;
			}
			case 1:
				goto IL_0284;
			case 20:
			{
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(XfYmeaSijfRMtexJwnPatAHuWen, num3);
				SlUfsNNegekRSmbkYsdxdTGRWMY(text, joystickAxisValueByJoystickId);
				num3++;
				num = 2032439518;
				continue;
			}
			case 16:
				FhBoqkkGJRRzonEFAPzvzuHaGZY += " [UNITY PRE-CONFIGURED]";
				num = 2032439514;
				continue;
			case 23:
				goto IL_02f1;
			case 7:
			{
				FhBoqkkGJRRzonEFAPzvzuHaGZY += "\n";
				object fhBoqkkGJRRzonEFAPzvzuHaGZY = FhBoqkkGJRRzonEFAPzvzuHaGZY;
				FhBoqkkGJRRzonEFAPzvzuHaGZY = string.Concat(fhBoqkkGJRRzonEFAPzvzuHaGZY, "Current Unity Joystick Id: ", XfYmeaSijfRMtexJwnPatAHuWen, "\n");
				num = 2032439507;
				continue;
			}
			case 8:
				XfYmeaSijfRMtexJwnPatAHuWen = 1;
				num = 2032439517;
				continue;
			case 2:
				goto IL_037e;
			case 5:
				goto IL_039b;
			case 14:
				goto IL_03b5;
			case 25:
				if (XfYmeaSijfRMtexJwnPatAHuWen <= 0)
				{
					XfYmeaSijfRMtexJwnPatAHuWen = 16;
					num = 2032439517;
					continue;
				}
				goto IL_03b5;
			case 21:
				FhBoqkkGJRRzonEFAPzvzuHaGZY += "\n";
				num2++;
				num = 2032439503;
				continue;
			case 10:
				XfYmeaSijfRMtexJwnPatAHuWen--;
				num = 2032439510;
				continue;
			default:
				hLVjSfvXBhNJmmNBXyOzuJevnvj.text = FhBoqkkGJRRzonEFAPzvzuHaGZY;
				return;
			}
			break;
			IL_03b5:
			int num5;
			if (XfYmeaSijfRMtexJwnPatAHuWen <= 16)
			{
				num = 2032439517;
				num5 = num;
			}
			else
			{
				num = 2032439495;
				num5 = num;
			}
			continue;
			IL_01f6:
			int num6;
			if (Input.GetKeyDown(KeyCode.KeypadMinus))
			{
				num = 2032439493;
				num6 = num;
			}
			else
			{
				num = 2032439501;
				num6 = num;
			}
			continue;
			IL_0284:
			int num7;
			if (UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(joystickNames[num2]))
			{
				num = 2032439519;
				num7 = num;
			}
			else
			{
				num = 2032439514;
				num7 = num;
			}
			continue;
			IL_039b:
			int num8;
			if (num4 >= 20)
			{
				num = 2032439509;
				num8 = num;
			}
			else
			{
				num = 2032439511;
				num8 = num;
			}
			continue;
			IL_00ee:
			int num9;
			if (!Input.GetKeyDown(KeyCode.KeypadPlus))
			{
				num = 2032439500;
				num9 = num;
			}
			else
			{
				num = 2032439512;
				num9 = num;
			}
			continue;
			IL_0220:
			int num10;
			if (UnityTools.platform == Platform.Linux)
			{
				num = 2032439502;
				num10 = num;
			}
			else
			{
				num = 2032439514;
				num10 = num;
			}
			continue;
			IL_037e:
			int num11;
			if (Input.GetKeyDown(KeyCode.Minus))
			{
				num = 2032439493;
				num11 = num;
			}
			else
			{
				num = 2032439510;
				num11 = num;
			}
			continue;
			IL_023c:
			int num12;
			if (num2 >= joystickNames.Length)
			{
				num = 2032439496;
				num12 = num;
			}
			else
			{
				num = 2032439499;
				num12 = num;
			}
		}
		goto IL_0018;
	}

	public void OnDestroy()
	{
	}

	private void SlUfsNNegekRSmbkYsdxdTGRWMY(string P_0, object P_1)
	{
		string fhBoqkkGJRRzonEFAPzvzuHaGZY = FhBoqkkGJRRzonEFAPzvzuHaGZY;
		FhBoqkkGJRRzonEFAPzvzuHaGZY = fhBoqkkGJRRzonEFAPzvzuHaGZY + P_0 + " = " + P_1.ToString() + "\n";
	}
}
