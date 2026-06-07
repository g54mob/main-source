using System;
using Rewired;

internal static class KVNLqybISELdZVRJeMgGCnyHIcv
{
	public static ControllerElementType tqXxoFypSRMjqbMSyPdRCcUlCPX(ElementAssignmentType P_0)
	{
		int num;
		if (P_0 != ElementAssignmentType.Button)
		{
			if (P_0 == ElementAssignmentType.KeyboardKey)
			{
				goto IL_0008;
			}
			int num2;
			if (P_0 != ElementAssignmentType.FullAxis)
			{
				num = -317434358;
				num2 = num;
			}
			else
			{
				num = -317434357;
				num2 = num;
			}
			goto IL_000d;
		}
		goto IL_002a;
		IL_000d:
		while (true)
		{
			switch (num ^ -317434360)
			{
			case 0:
				break;
			case 1:
				goto IL_002a;
			case 2:
				goto IL_0040;
			default:
				return ControllerElementType.Axis;
			}
			break;
			IL_0040:
			if (P_0 == ElementAssignmentType.SplitAxis)
			{
				num = -317434357;
				continue;
			}
			throw new NotImplementedException();
		}
		goto IL_0008;
		IL_0008:
		num = -317434359;
		goto IL_000d;
		IL_002a:
		return ControllerElementType.Button;
	}

	public static ElementAssignmentType QGLZQcqhHfDHnTfecdpLzWoTlcl(ControllerType P_0, ControllerElementType P_1, AxisRange P_2)
	{
		ElementAssignmentType result = default(ElementAssignmentType);
		if (P_0 == ControllerType.Keyboard)
		{
			result = ElementAssignmentType.KeyboardKey;
			goto IL_0005;
		}
		goto IL_0056;
		IL_0056:
		int num;
		if (P_1 == ControllerElementType.Axis)
		{
			int num2;
			if (P_2 != AxisRange.Full)
			{
				num = -1420085763;
				num2 = num;
			}
			else
			{
				num = -1420085762;
				num2 = num;
			}
			goto IL_000a;
		}
		goto IL_0033;
		IL_0005:
		num = -1420085765;
		goto IL_000a;
		IL_000a:
		while (true)
		{
			switch (num ^ -1420085762)
			{
			case 6:
				break;
			case 1:
				goto IL_0033;
			case 3:
				result = ElementAssignmentType.SplitAxis;
				num = -1420085764;
				continue;
			case 5:
				num = -1420085764;
				continue;
			case 4:
				goto IL_0056;
			case 0:
				result = ElementAssignmentType.FullAxis;
				num = -1420085764;
				continue;
			default:
				return result;
			}
			break;
		}
		goto IL_0005;
		IL_0033:
		if (P_1 == ControllerElementType.Button)
		{
			return ElementAssignmentType.Button;
		}
		throw new NotImplementedException();
	}

	public static AxisRange EiuWvruFgagCgFlUXngcwHoQsdfT(Pole P_0)
	{
		if (P_0 == Pole.Positive)
		{
			goto IL_0003;
		}
		int num;
		if (P_0 == Pole.Negative)
		{
			num = 897689517;
			goto IL_0008;
		}
		throw new NotImplementedException();
		IL_0003:
		num = 897689516;
		goto IL_0008;
		IL_0008:
		switch (num ^ 0x3581A7AD)
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

	public static Type beQrZUtPxkjJgsLHhWMUcWVoKJI<T>() where T : Controller
	{
		return beQrZUtPxkjJgsLHhWMUcWVoKJI(typeof(T));
	}

	public static Type beQrZUtPxkjJgsLHhWMUcWVoKJI(Type P_0)
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
			while (true)
			{
				switch (0x683DE294 ^ 0x683DE295)
				{
				case 4:
					break;
				case 3:
					goto end_IL_006c;
				case 0:
					goto IL_00c7;
				case 1:
					return typeof(CustomControllerMap);
				default:
					goto IL_0136;
				}
				continue;
				end_IL_006c:
				break;
			}
			goto IL_0095;
		}
		if (object.ReferenceEquals(P_0, typeof(Controller)))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		goto IL_00c7;
		IL_0136:
		throw new NotImplementedException();
		IL_00c7:
		if (object.ReferenceEquals(P_0, typeof(ControllerWithMap)))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		goto IL_0095;
		IL_0095:
		if (object.ReferenceEquals(P_0, typeof(ControllerWithAxes)))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		goto IL_0136;
	}

	public static Type TKxhaVgFjyhZurDqIjwyHOrHDds(ControllerType P_0)
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

	public static Type EySesnjFwiUNBJGHLtrRiimIqoP(ControllerType P_0)
	{
		switch (P_0)
		{
		default:
			while (true)
			{
				switch (0x63168B51 ^ 0x63168B50)
				{
				case 0:
					continue;
				case 1:
					if (P_0 == ControllerType.Custom)
					{
						return typeof(CustomController);
					}
					throw new NotImplementedException();
				}
				break;
			}
			goto case ControllerType.Joystick;
		case ControllerType.Joystick:
			return typeof(Joystick);
		case ControllerType.Keyboard:
			return typeof(Keyboard);
		case ControllerType.Mouse:
			return typeof(Mouse);
		}
	}

	public static ControllerType RIWyjaYtsZsyVFuzjhpKVaeskTY(Type P_0)
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
				num = -643568559;
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
						throw new Exception(P_0.Name + " is not an allowed type.");
					}
					goto IL_00d0;
				}
				num = -643568560;
			}
			while (true)
			{
				switch (num ^ -643568560)
				{
				case 3:
					num = -643568556;
					continue;
				case 4:
					break;
				case 1:
					return ControllerType.Joystick;
				case 0:
					return ControllerType.Keyboard;
				case 2:
					goto IL_00d0;
				case 5:
					goto IL_0102;
				default:
					goto end_IL_003f;
				}
				break;
			}
			continue;
			IL_0102:
			if (!object.ReferenceEquals(P_0, typeof(ControllerWithAxes)))
			{
				break;
			}
			throw new Exception(P_0.Name + " is not an allowed type.");
			IL_00d0:
			if (object.ReferenceEquals(P_0, typeof(ControllerWithMap)))
			{
				throw new Exception(P_0.Name + " is not an allowed type.");
			}
			goto IL_0102;
			continue;
			end_IL_003f:
			break;
		}
		throw new NotImplementedException();
	}

	public static ControllerType RIWyjaYtsZsyVFuzjhpKVaeskTY<T>()
	{
		return RIWyjaYtsZsyVFuzjhpKVaeskTY(typeof(T));
	}

	public static ControllerType xIarQlHMflKGZNPPZtUIQbkWHfqF(Type P_0)
	{
		ControllerType result;
		if (!lhExmyUkbaDBFiWyGarzfcKOyeC(P_0, out result))
		{
			while (true)
			{
				switch (-1323403740 ^ -1323403739)
				{
				case 2:
					continue;
				case 1:
					throw new Exception(P_0.Name + " is not an allowed type.");
				}
				break;
			}
		}
		return result;
	}

	public static ControllerType xIarQlHMflKGZNPPZtUIQbkWHfqF<T>() where T : ControllerMap
	{
		return xIarQlHMflKGZNPPZtUIQbkWHfqF(typeof(T));
	}

	public static bool lhExmyUkbaDBFiWyGarzfcKOyeC(Type P_0, out ControllerType P_1)
	{
		if ((object)P_0 == null)
		{
			throw new ArgumentNullException("mapType");
		}
		while (true)
		{
			if (object.ReferenceEquals(P_0, typeof(JoystickMap)))
			{
				P_1 = ControllerType.Joystick;
				return true;
			}
			if (object.ReferenceEquals(P_0, typeof(KeyboardMap)))
			{
				P_1 = ControllerType.Keyboard;
				return true;
			}
			int num;
			if (object.ReferenceEquals(P_0, typeof(MouseMap)))
			{
				P_1 = ControllerType.Mouse;
				num = -85367265;
			}
			else if (object.ReferenceEquals(P_0, typeof(CustomControllerMap)))
			{
				num = -85367267;
			}
			else
			{
				if (!object.ReferenceEquals(P_0, typeof(ControllerMap)))
				{
					break;
				}
				P_1 = ControllerType.Keyboard;
				num = -85367266;
			}
			while (true)
			{
				switch (num ^ -85367265)
				{
				case 3:
					num = -85367269;
					continue;
				case 4:
					break;
				case 2:
					P_1 = ControllerType.Custom;
					num = -85367270;
					continue;
				case 0:
					return true;
				case 5:
					return true;
				default:
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

	public static bool lhExmyUkbaDBFiWyGarzfcKOyeC<T>(out ControllerType P_0) where T : ControllerMap
	{
		return lhExmyUkbaDBFiWyGarzfcKOyeC(typeof(T), out P_0);
	}

	public static ControllerType dJubVUhPgOyGFVjxOXBJXXJNwBH(Type P_0)
	{
		if ((object)P_0 == null)
		{
			throw new ArgumentNullException("controllerMapSaveDataType");
		}
		while (!object.ReferenceEquals(P_0, typeof(JoystickMapSaveData)))
		{
			int num;
			if (object.ReferenceEquals(P_0, typeof(KeyboardMapSaveData)))
			{
				num = -1880500625;
			}
			else if (!object.ReferenceEquals(P_0, typeof(MouseMapSaveData)))
			{
				int num2;
				if (object.ReferenceEquals(P_0, typeof(CustomControllerMapSaveData)))
				{
					num = -1880500628;
				}
				else if (!object.ReferenceEquals(P_0, typeof(ControllerMapSaveData)))
				{
					num = -1880500630;
					num2 = num;
				}
				else
				{
					num = -1880500627;
					num2 = num;
				}
			}
			else
			{
				num = -1880500626;
			}
			while (true)
			{
				switch (num ^ -1880500625)
				{
				case 6:
					goto IL_000e;
				case 4:
					break;
				case 1:
					return ControllerType.Mouse;
				case 2:
					throw new Exception(P_0.Name + " is not an allowed type.");
				case 3:
					return ControllerType.Custom;
				case 0:
					return ControllerType.Keyboard;
				default:
					throw new NotImplementedException();
				}
				break;
				IL_000e:
				num = -1880500629;
			}
		}
		return ControllerType.Joystick;
	}

	public static ControllerType dJubVUhPgOyGFVjxOXBJXXJNwBH<T>() where T : ControllerMapSaveData
	{
		return dJubVUhPgOyGFVjxOXBJXXJNwBH(typeof(T));
	}

	public static bool texDHprRVSCDIhdEcHxFsscbHjUA(ControllerTemplateElementType P_0, ControllerElementType P_1)
	{
		switch (P_1)
		{
		default:
			while (true)
			{
				switch (-1558588753 ^ -1558588754)
				{
				case 0:
					continue;
				case 1:
					throw new NotImplementedException();
				}
				break;
			}
			goto case ControllerElementType.Axis;
		case ControllerElementType.Axis:
			return P_0 == ControllerTemplateElementType.Axis;
		case ControllerElementType.Button:
			return P_0 == ControllerTemplateElementType.Button;
		case ControllerElementType.CompoundElement:
			return false;
		}
	}

	public static ControllerElementType GbAArqJlIQEtJddnaipTXTcVclHP(object P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("type");
		}
		while (true)
		{
			Type type = P_0.GetType();
			int num;
			if (object.ReferenceEquals(type, typeof(ControllerElementType)))
			{
				num = -1209370907;
			}
			else
			{
				if (!object.ReferenceEquals(type, typeof(ControllerTemplateElementType)))
				{
					break;
				}
				num = -1209370906;
			}
			while (true)
			{
				switch (num ^ -1209370906)
				{
				case 2:
					goto IL_000e;
				case 1:
					break;
				case 3:
					return (ControllerElementType)P_0;
				default:
					return GbAArqJlIQEtJddnaipTXTcVclHP((ControllerTemplateElementType)P_0);
				}
				break;
				IL_000e:
				num = -1209370905;
			}
		}
		throw new NotImplementedException();
	}

	public static ControllerElementType GbAArqJlIQEtJddnaipTXTcVclHP(ControllerTemplateElementType P_0)
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

	public static ControllerTemplateElementSourceType ctsjnxILofJVXeJcAthlmduipVQ(ControllerTemplateElementType P_0, bool P_1)
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

	public static ControllerTemplateElementType epHGbImMBWbvvjSPHgtWxljmdtP(ControllerElementType P_0, bool P_1)
	{
		switch (P_0)
		{
		case ControllerElementType.Axis:
			return ControllerTemplateElementType.Axis;
		case ControllerElementType.Button:
			return ControllerTemplateElementType.Button;
		default:
			if (P_1)
			{
				throw new NotImplementedException();
			}
			return (ControllerTemplateElementType)(-1);
		}
	}
}
