using System;
using Rewired;

internal static class zRJHFfVYpYamSokTjXZVUKlCnAG
{
	public static ControllerElementType MuLiOAWIhTPZfOhvnDqSQEksgWmc(ElementAssignmentType P_0)
	{
		if (P_0 != ElementAssignmentType.Button)
		{
			while (true)
			{
				int num = 1569995578;
				while (true)
				{
					switch (num ^ 0x5D943B38)
					{
					case 3:
						break;
					case 2:
						goto IL_0026;
					case 1:
						goto end_IL_0004;
					default:
						goto IL_0041;
					}
					break;
					IL_0026:
					switch (P_0)
					{
					case ElementAssignmentType.KeyboardKey:
						num = 1569995577;
						continue;
					case ElementAssignmentType.SplitAxis:
						num = 1569995576;
						continue;
					case ElementAssignmentType.FullAxis:
						break;
					default:
						throw new NotImplementedException();
					}
					goto IL_0041;
					IL_0041:
					return ControllerElementType.Axis;
				}
				continue;
				end_IL_0004:
				break;
			}
		}
		return ControllerElementType.Button;
	}

	public static ElementAssignmentType tIBgwfGQinhMgctFnXEUlgKGCdOK(ControllerType P_0, ControllerElementType P_1, AxisRange P_2)
	{
		ElementAssignmentType result = default(ElementAssignmentType);
		if (P_0 == ControllerType.Keyboard)
		{
			result = ElementAssignmentType.KeyboardKey;
			goto IL_0005;
		}
		goto IL_0046;
		IL_0033:
		if (P_1 == ControllerElementType.Button)
		{
			return ElementAssignmentType.Button;
		}
		throw new NotImplementedException();
		IL_0005:
		int num = 15276130;
		goto IL_000a;
		IL_000a:
		while (true)
		{
			switch (num ^ 0xE91861)
			{
			case 5:
				break;
			case 2:
				goto IL_0033;
			case 6:
				goto IL_0046;
			case 1:
				result = ElementAssignmentType.SplitAxis;
				num = 15276129;
				continue;
			case 3:
				num = 15276129;
				continue;
			case 4:
				result = ElementAssignmentType.FullAxis;
				num = 15276129;
				continue;
			default:
				return result;
			}
			break;
		}
		goto IL_0005;
		IL_0046:
		if (P_1 == ControllerElementType.Axis)
		{
			int num2;
			if (P_2 != AxisRange.Full)
			{
				num = 15276128;
				num2 = num;
			}
			else
			{
				num = 15276133;
				num2 = num;
			}
			goto IL_000a;
		}
		goto IL_0033;
	}

	public static AxisRange rAoGiSQDMgNpsSnnEZfLVSbBmcI(Pole P_0)
	{
		if (P_0 == Pole.Positive)
		{
			goto IL_0003;
		}
		int num;
		if (P_0 == Pole.Negative)
		{
			num = -1043751357;
			goto IL_0008;
		}
		throw new NotImplementedException();
		IL_0003:
		num = -1043751358;
		goto IL_0008;
		IL_0008:
		switch (num ^ -1043751357)
		{
		case 2:
			break;
		case 1:
			return AxisRange.Positive;
		default:
			return AxisRange.Negative;
		}
		goto IL_0003;
	}

	public static Type OiUKSNNsMiDmpJqicFfFJgdbNPhT<T>() where T : Controller
	{
		return OiUKSNNsMiDmpJqicFfFJgdbNPhT(typeof(T));
	}

	public static Type OiUKSNNsMiDmpJqicFfFJgdbNPhT(Type P_0)
	{
		if (object.ReferenceEquals(P_0, typeof(Joystick)))
		{
			return typeof(JoystickMap);
		}
		if (object.ReferenceEquals(P_0, typeof(Keyboard)))
		{
			return typeof(KeyboardMap);
		}
		if (object.ReferenceEquals(P_0, typeof(Mouse)))
		{
			return typeof(MouseMap);
		}
		if (object.ReferenceEquals(P_0, typeof(CustomController)))
		{
			return typeof(CustomControllerMap);
		}
		if (object.ReferenceEquals(P_0, typeof(Controller)))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		if (object.ReferenceEquals(P_0, typeof(ControllerWithMap)))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		if (object.ReferenceEquals(P_0, typeof(ControllerWithAxes)))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		throw new NotImplementedException();
	}

	public static Type csbCQEAMGwYqtjGNBuAfoRsQdIPD(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return typeof(JoystickMap);
		case ControllerType.Keyboard:
			return typeof(KeyboardMap);
		case ControllerType.Mouse:
			return typeof(MouseMap);
		case ControllerType.Custom:
			return typeof(CustomControllerMap);
		default:
			throw new NotImplementedException();
		}
	}

	public static Type zEQiHiFPFqWJWGquShEWbmUaHhgy(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return typeof(Joystick);
		case ControllerType.Keyboard:
			return typeof(Keyboard);
		case ControllerType.Mouse:
			return typeof(Mouse);
		case ControllerType.Custom:
			return typeof(CustomController);
		default:
			throw new NotImplementedException();
		}
	}

	public static ControllerType eqYfTtjgOFAvUUoLgNYFGNIvvfjb(Type P_0)
	{
		if ((object)P_0 == null)
		{
			throw new ArgumentNullException("controllerType");
		}
		while (true)
		{
			int num;
			if (object.ReferenceEquals(P_0, typeof(Joystick)))
			{
				num = -205261946;
			}
			else
			{
				if (!object.ReferenceEquals(P_0, typeof(Keyboard)))
				{
					if (object.ReferenceEquals(P_0, typeof(Mouse)))
					{
						return ControllerType.Mouse;
					}
					if (object.ReferenceEquals(P_0, typeof(CustomController)))
					{
						return ControllerType.Custom;
					}
					if (object.ReferenceEquals(P_0, typeof(Controller)))
					{
						break;
					}
					goto IL_005c;
				}
				num = -205261950;
			}
			goto IL_0013;
			IL_005c:
			int num2;
			if (object.ReferenceEquals(P_0, typeof(ControllerWithMap)))
			{
				num = -205261947;
				num2 = num;
			}
			else
			{
				num = -205261949;
				num2 = num;
			}
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num ^ -205261952)
				{
				case 0:
					num = -205261948;
					continue;
				case 4:
					break;
				case 1:
					goto IL_005c;
				case 6:
					return ControllerType.Joystick;
				case 2:
					return ControllerType.Keyboard;
				case 5:
					throw new Exception(P_0.Name + " is not an allowed type.");
				case 3:
					if (object.ReferenceEquals(P_0, typeof(ControllerWithAxes)))
					{
						throw new Exception(P_0.Name + " is not an allowed type.");
					}
					goto default;
				default:
					throw new NotImplementedException();
				}
				break;
			}
		}
		throw new Exception(P_0.Name + " is not an allowed type.");
	}

	public static ControllerType eqYfTtjgOFAvUUoLgNYFGNIvvfjb<T>()
	{
		return eqYfTtjgOFAvUUoLgNYFGNIvvfjb(typeof(T));
	}

	public static ControllerType UEaBpubjMbKDMgluOEfXWBGTaeTh(Type P_0)
	{
		if (!CthtWbOkHtbAUVHdvADstnQNNjZ(P_0, out var result))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		return result;
	}

	public static ControllerType UEaBpubjMbKDMgluOEfXWBGTaeTh<T>() where T : ControllerMap
	{
		return UEaBpubjMbKDMgluOEfXWBGTaeTh(typeof(T));
	}

	public static bool CthtWbOkHtbAUVHdvADstnQNNjZ(Type P_0, out ControllerType P_1)
	{
		if ((object)P_0 == null)
		{
			throw new ArgumentNullException("mapType");
		}
		while (true)
		{
			int num;
			if (object.ReferenceEquals(P_0, typeof(JoystickMap)))
			{
				num = -321465912;
			}
			else if (!object.ReferenceEquals(P_0, typeof(KeyboardMap)))
			{
				if (object.ReferenceEquals(P_0, typeof(MouseMap)))
				{
					P_1 = ControllerType.Mouse;
					return true;
				}
				if (object.ReferenceEquals(P_0, typeof(CustomControllerMap)))
				{
					num = -321465906;
				}
				else
				{
					if (!object.ReferenceEquals(P_0, typeof(ControllerMap)))
					{
						break;
					}
					num = -321465910;
				}
			}
			else
			{
				num = -321465911;
			}
			while (true)
			{
				switch (num ^ -321465908)
				{
				case 0:
					num = -321465907;
					continue;
				case 1:
					break;
				case 4:
					P_1 = ControllerType.Joystick;
					num = -321465905;
					continue;
				case 5:
					P_1 = ControllerType.Keyboard;
					return true;
				case 2:
					P_1 = ControllerType.Custom;
					return true;
				case 3:
					return true;
				default:
					P_1 = ControllerType.Keyboard;
					return false;
				}
				break;
			}
		}
		if (object.ReferenceEquals(P_0, typeof(ControllerMapWithAxes)))
		{
			P_1 = ControllerType.Keyboard;
			return false;
		}
		throw new NotImplementedException();
	}

	public static bool CthtWbOkHtbAUVHdvADstnQNNjZ<T>(out ControllerType P_0) where T : ControllerMap
	{
		return CthtWbOkHtbAUVHdvADstnQNNjZ(typeof(T), out P_0);
	}

	public static ControllerType YLkyUCTTmWijEoQYDHaKXbjUvdu(Type P_0)
	{
		if ((object)P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_003e;
		IL_0003:
		int num = 1020693573;
		goto IL_0008;
		IL_0008:
		switch (num ^ 0x3CD68C44)
		{
		case 3:
			break;
		case 1:
			throw new ArgumentNullException("controllerMapSaveDataType");
		case 0:
			goto IL_003e;
		case 2:
			throw new Exception(P_0.Name + " is not an allowed type.");
		default:
			throw new NotImplementedException();
		}
		goto IL_0003;
		IL_003e:
		if (object.ReferenceEquals(P_0, typeof(JoystickMapSaveData)))
		{
			return ControllerType.Joystick;
		}
		if (object.ReferenceEquals(P_0, typeof(KeyboardMapSaveData)))
		{
			return ControllerType.Keyboard;
		}
		if (object.ReferenceEquals(P_0, typeof(MouseMapSaveData)))
		{
			return ControllerType.Mouse;
		}
		if (object.ReferenceEquals(P_0, typeof(CustomControllerMapSaveData)))
		{
			return ControllerType.Custom;
		}
		int num2;
		if (!object.ReferenceEquals(P_0, typeof(ControllerMapSaveData)))
		{
			num = 1020693568;
			num2 = num;
		}
		else
		{
			num = 1020693574;
			num2 = num;
		}
		goto IL_0008;
	}

	public static ControllerType YLkyUCTTmWijEoQYDHaKXbjUvdu<T>() where T : ControllerMapSaveData
	{
		return YLkyUCTTmWijEoQYDHaKXbjUvdu(typeof(T));
	}

	public static bool YfzaYuFFeAGpZYIlhOCKodCcBwd(ControllerTemplateElementType P_0, ControllerElementType P_1)
	{
		while (true)
		{
			int num = 718726317;
			while (true)
			{
				switch (num ^ 0x2AD6E4AC)
				{
				case 3:
					break;
				case 1:
					switch (P_1)
					{
					default:
						goto IL_0032;
					case ControllerElementType.Axis:
						break;
					case ControllerElementType.Button:
						return P_0 == ControllerTemplateElementType.Button;
					}
					goto default;
				case 2:
					if (P_1 == ControllerElementType.CompoundElement)
					{
						return false;
					}
					throw new NotImplementedException();
				default:
					return P_0 == ControllerTemplateElementType.Axis;
				}
				break;
				IL_0032:
				num = 718726318;
			}
		}
	}

	public static ControllerElementType bfOOOfvhbAfeUGROtAICBZCUJgir(object P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("type");
		}
		Type type = P_0.GetType();
		if (object.ReferenceEquals(type, typeof(ControllerElementType)))
		{
			return (ControllerElementType)P_0;
		}
		if (object.ReferenceEquals(type, typeof(ControllerTemplateElementType)))
		{
			return bfOOOfvhbAfeUGROtAICBZCUJgir((ControllerTemplateElementType)P_0);
		}
		throw new NotImplementedException();
	}

	public static ControllerElementType bfOOOfvhbAfeUGROtAICBZCUJgir(ControllerTemplateElementType P_0)
	{
		switch (P_0)
		{
		case ControllerTemplateElementType.Axis:
			return ControllerElementType.Axis;
		case ControllerTemplateElementType.Button:
			return ControllerElementType.Button;
		default:
			throw new NotImplementedException();
		}
	}

	public static ControllerTemplateElementSourceType POoMsemLJtYIKBCNJkQeoSUfHSd(ControllerTemplateElementType P_0, bool P_1)
	{
		switch (P_0)
		{
		case ControllerTemplateElementType.Axis:
			return ControllerTemplateElementSourceType.Axis;
		case ControllerTemplateElementType.Button:
			return ControllerTemplateElementSourceType.Button;
		default:
			if (P_1)
			{
				throw new NotImplementedException();
			}
			return (ControllerTemplateElementSourceType)(-1);
		}
	}

	public static ControllerTemplateElementType BRBXzDYhhYIycYzhOeZDlUThiws(ControllerElementType P_0, bool P_1)
	{
		while (true)
		{
			switch (-363227763 ^ -363227764)
			{
			case 2:
				continue;
			case 1:
				switch (P_0)
				{
				case ControllerElementType.Axis:
					break;
				case ControllerElementType.Button:
					return ControllerTemplateElementType.Button;
				default:
					goto IL_003f;
				}
				goto case 0;
			case 0:
				{
					return ControllerTemplateElementType.Axis;
				}
				IL_003f:
				if (P_1)
				{
					throw new NotImplementedException();
				}
				break;
			}
			break;
		}
		return (ControllerTemplateElementType)(-1);
	}
}
