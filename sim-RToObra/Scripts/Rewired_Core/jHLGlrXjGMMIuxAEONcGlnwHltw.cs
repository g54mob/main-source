using System;
using Rewired;

internal static class jHLGlrXjGMMIuxAEONcGlnwHltw
{
	public static ControllerElementType CSNCkOQjILujRXYRCEZThnKdpKC(ElementAssignmentType P_0)
	{
		if (P_0 != ElementAssignmentType.Button)
		{
			while (true)
			{
				int num = 1783445281;
				while (true)
				{
					switch (num ^ 0x6A4D3723)
					{
					case 4:
						break;
					case 1:
						goto IL_002a;
					case 3:
						goto end_IL_0004;
					case 2:
						goto IL_004b;
					default:
						return ControllerElementType.Axis;
					}
					break;
					IL_004b:
					int num2;
					switch (P_0)
					{
					case ElementAssignmentType.FullAxis:
						num = 1783445283;
						num2 = num;
						break;
					default:
						num = 1783445282;
						num2 = num;
						break;
					case ElementAssignmentType.KeyboardKey:
						num = 1783445280;
						break;
					}
					continue;
					IL_002a:
					if (P_0 == ElementAssignmentType.SplitAxis)
					{
						num = 1783445283;
						continue;
					}
					throw new NotImplementedException();
				}
				continue;
				end_IL_0004:
				break;
			}
		}
		return ControllerElementType.Button;
	}

	public static ElementAssignmentType lSBCIdCLIvgFKjfhAnNBSikLxLu(ControllerType P_0, ControllerElementType P_1, AxisRange P_2)
	{
		if (P_0 == ControllerType.Keyboard)
		{
			goto IL_0003;
		}
		goto IL_0045;
		IL_0003:
		int num = 455331249;
		goto IL_0008;
		IL_0008:
		ElementAssignmentType result = default(ElementAssignmentType);
		while (true)
		{
			switch (num ^ 0x1B23CDB0)
			{
			case 6:
				break;
			case 1:
				result = ElementAssignmentType.KeyboardKey;
				num = 455331253;
				continue;
			case 4:
				num = 455331253;
				continue;
			case 3:
				goto IL_0045;
			case 2:
				result = ElementAssignmentType.SplitAxis;
				num = 455331253;
				continue;
			case 7:
				result = ElementAssignmentType.FullAxis;
				num = 455331252;
				continue;
			case 0:
				goto IL_006e;
			default:
				return result;
			}
			break;
		}
		goto IL_0003;
		IL_0045:
		if (P_1 == ControllerElementType.Axis)
		{
			int num2;
			if (P_2 == AxisRange.Full)
			{
				num = 455331255;
				num2 = num;
			}
			else
			{
				num = 455331250;
				num2 = num;
			}
			goto IL_0008;
		}
		goto IL_006e;
		IL_006e:
		if (P_1 == ControllerElementType.Button)
		{
			return ElementAssignmentType.Button;
		}
		throw new NotImplementedException();
	}

	public static AxisRange xhcBmujAkypjDCXJnhcyvsqKwqic(Pole P_0)
	{
		switch (P_0)
		{
		case Pole.Positive:
			return AxisRange.Positive;
		case Pole.Negative:
			return AxisRange.Negative;
		default:
			throw new NotImplementedException();
		}
	}

	public static Type QVQCoFXUhwHCDKyGFSOINqJwlHX<T>() where T : Controller
	{
		return QVQCoFXUhwHCDKyGFSOINqJwlHX(typeof(T));
	}

	public static Type QVQCoFXUhwHCDKyGFSOINqJwlHX(Type P_0)
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
			while (true)
			{
				switch (-1747603543 ^ -1747603544)
				{
				case 2:
					break;
				case 1:
					throw new Exception(P_0.Name + " is not an allowed type.");
				case 4:
					goto end_IL_0086;
				case 0:
					goto IL_00f8;
				default:
					goto IL_012a;
				}
				continue;
				end_IL_0086:
				break;
			}
		}
		if (object.ReferenceEquals(P_0, typeof(ControllerWithMap)))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		goto IL_00f8;
		IL_012a:
		throw new NotImplementedException();
		IL_00f8:
		if (object.ReferenceEquals(P_0, typeof(ControllerWithAxes)))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		goto IL_012a;
	}

	public static Type ebPmSAGjuLEVuTpyFneZoOZkAlf(ControllerType P_0)
	{
		while (true)
		{
			int num = 466773597;
			while (true)
			{
				switch (num ^ 0x1BD2665F)
				{
				case 0:
					break;
				case 2:
					switch (P_0)
					{
					default:
						goto IL_003b;
					case ControllerType.Joystick:
						break;
					case ControllerType.Keyboard:
						return typeof(KeyboardMap);
					case ControllerType.Mouse:
						return typeof(MouseMap);
					case ControllerType.Custom:
						return typeof(CustomControllerMap);
					}
					goto default;
				default:
					return typeof(JoystickMap);
				case 1:
					throw new NotImplementedException();
				}
				break;
				IL_003b:
				num = 466773598;
			}
		}
	}

	public static Type xbShhsTyjufEgbkGvlwBPcrMlZG(ControllerType P_0)
	{
		while (true)
		{
			int num = 618503293;
			while (true)
			{
				switch (num ^ 0x24DD9C7E)
				{
				case 2:
					break;
				case 3:
					switch (P_0)
					{
					default:
						goto IL_0036;
					case ControllerType.Joystick:
						break;
					case ControllerType.Keyboard:
						return typeof(Keyboard);
					case ControllerType.Mouse:
						return typeof(Mouse);
					}
					goto default;
				case 0:
					if (P_0 == ControllerType.Custom)
					{
						return typeof(CustomController);
					}
					throw new NotImplementedException();
				default:
					return typeof(Joystick);
				}
				break;
				IL_0036:
				num = 618503294;
			}
		}
	}

	public static ControllerType yvGjdUkdfNXoVbjQBzWMoiyuhXy(Type P_0)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_006e;
		IL_0003:
		int num = -711689796;
		goto IL_0008;
		IL_0008:
		while (true)
		{
			switch (num ^ -711689798)
			{
			case 5:
				break;
			case 7:
				if (object.ReferenceEquals(P_0, typeof(ControllerWithAxes)))
				{
					throw new Exception(P_0.Name + " is not an allowed type.");
				}
				goto default;
			case 2:
				goto IL_006e;
			case 6:
				throw new ArgumentNullException("controllerType");
			case 3:
				goto IL_00b3;
			case 1:
				throw new Exception(P_0.Name + " is not an allowed type.");
			case 0:
				return ControllerType.Keyboard;
			case 8:
				throw new Exception(P_0.Name + " is not an allowed type.");
			default:
				throw new NotImplementedException();
			}
			break;
			IL_00b3:
			int num2;
			if (object.ReferenceEquals(P_0, typeof(ControllerWithMap)))
			{
				num = -711689806;
				num2 = num;
			}
			else
			{
				num = -711689795;
				num2 = num;
			}
		}
		goto IL_0003;
		IL_006e:
		if (object.ReferenceEquals(P_0, typeof(Joystick)))
		{
			return ControllerType.Joystick;
		}
		if (object.ReferenceEquals(P_0, typeof(Keyboard)))
		{
			num = -711689798;
		}
		else
		{
			if (object.ReferenceEquals(P_0, typeof(Mouse)))
			{
				return ControllerType.Mouse;
			}
			if (object.ReferenceEquals(P_0, typeof(CustomController)))
			{
				return ControllerType.Custom;
			}
			int num3;
			if (object.ReferenceEquals(P_0, typeof(Controller)))
			{
				num = -711689797;
				num3 = num;
			}
			else
			{
				num = -711689799;
				num3 = num;
			}
		}
		goto IL_0008;
	}

	public static ControllerType yvGjdUkdfNXoVbjQBzWMoiyuhXy<T>()
	{
		return yvGjdUkdfNXoVbjQBzWMoiyuhXy(typeof(T));
	}

	public static ControllerType OuwjTmlLtjgfufdOpsQAzxoKtoz(Type P_0)
	{
		ControllerType result;
		if (!YNhoXxOenbkjqMNFOeqjMuLAxBd(P_0, out result))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		return result;
	}

	public static ControllerType OuwjTmlLtjgfufdOpsQAzxoKtoz<T>() where T : ControllerMap
	{
		return OuwjTmlLtjgfufdOpsQAzxoKtoz(typeof(T));
	}

	public static bool YNhoXxOenbkjqMNFOeqjMuLAxBd(Type P_0, out ControllerType P_1)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_0065;
		IL_0003:
		int num = -1634404020;
		goto IL_0008;
		IL_0008:
		switch (num ^ -1634404019)
		{
		case 5:
			break;
		case 1:
			throw new ArgumentNullException("mapType");
		case 6:
			P_1 = ControllerType.Custom;
			return true;
		case 2:
			goto IL_0065;
		case 4:
			return true;
		case 0:
			return true;
		default:
			P_1 = ControllerType.Keyboard;
			return false;
		}
		goto IL_0003;
		IL_0065:
		if (object.ReferenceEquals(P_0, typeof(JoystickMap)))
		{
			P_1 = ControllerType.Joystick;
			num = -1634404019;
		}
		else if (!object.ReferenceEquals(P_0, typeof(KeyboardMap)))
		{
			if (object.ReferenceEquals(P_0, typeof(MouseMap)))
			{
				P_1 = ControllerType.Mouse;
				return true;
			}
			if (!object.ReferenceEquals(P_0, typeof(CustomControllerMap)))
			{
				if (!object.ReferenceEquals(P_0, typeof(ControllerMap)))
				{
					if (object.ReferenceEquals(P_0, typeof(ControllerMapWithAxes)))
					{
						P_1 = ControllerType.Keyboard;
						return false;
					}
					throw new NotImplementedException();
				}
				num = -1634404018;
			}
			else
			{
				num = -1634404021;
			}
		}
		else
		{
			P_1 = ControllerType.Keyboard;
			num = -1634404023;
		}
		goto IL_0008;
	}

	public static bool YNhoXxOenbkjqMNFOeqjMuLAxBd<T>(out ControllerType P_0) where T : ControllerMap
	{
		return YNhoXxOenbkjqMNFOeqjMuLAxBd(typeof(T), out P_0);
	}

	public static ControllerType AToeXWXPtWRLyxoecNjTwJnPrbG(Type P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("controllerMapSaveDataType");
		}
		while (true)
		{
			if (object.ReferenceEquals(P_0, typeof(JoystickMapSaveData)))
			{
				return ControllerType.Joystick;
			}
			if (object.ReferenceEquals(P_0, typeof(KeyboardMapSaveData)))
			{
				int num = 1457889344;
				while (true)
				{
					switch (num ^ 0x56E5A043)
					{
					case 0:
						num = 1457889345;
						continue;
					case 2:
						break;
					case 3:
						return ControllerType.Keyboard;
					default:
						goto end_IL_0033;
					}
					break;
				}
				continue;
			}
			if (object.ReferenceEquals(P_0, typeof(MouseMapSaveData)))
			{
				return ControllerType.Mouse;
			}
			if (object.ReferenceEquals(P_0, typeof(CustomControllerMapSaveData)))
			{
				return ControllerType.Custom;
			}
			if (!object.ReferenceEquals(P_0, typeof(ControllerMapSaveData)))
			{
				break;
			}
			throw new Exception(P_0.Name + " is not an allowed type.");
			continue;
			end_IL_0033:
			break;
		}
		throw new NotImplementedException();
	}

	public static ControllerType AToeXWXPtWRLyxoecNjTwJnPrbG<T>() where T : ControllerMapSaveData
	{
		return AToeXWXPtWRLyxoecNjTwJnPrbG(typeof(T));
	}

	public static bool CGvNMgTtJKByfBoLCudPLkyvgkV(ControllerTemplateElementType P_0, ControllerElementType P_1)
	{
		while (true)
		{
			int num = -646417686;
			while (true)
			{
				switch (num ^ -646417688)
				{
				case 3:
					break;
				case 2:
					switch (P_1)
					{
					default:
						num = -646417684;
						continue;
					case ControllerElementType.Axis:
						break;
					case ControllerElementType.Button:
						return P_0 == ControllerTemplateElementType.Button;
					}
					goto default;
				case 4:
					if (P_1 != ControllerElementType.CompoundElement)
					{
						num = -646417688;
						continue;
					}
					return false;
				default:
					return P_0 == ControllerTemplateElementType.Axis;
				case 0:
					throw new NotImplementedException();
				}
				break;
			}
		}
	}

	public static ControllerElementType dESgFzzjUASSsXqyQnTPkfkTyAG(object P_0)
	{
		if (P_0 == null)
		{
			while (true)
			{
				switch (-1413717183 ^ -1413717184)
				{
				case 0:
					continue;
				case 1:
					throw new ArgumentNullException("type");
				}
				break;
			}
		}
		Type type = P_0.GetType();
		if (object.ReferenceEquals(type, typeof(ControllerElementType)))
		{
			return (ControllerElementType)P_0;
		}
		if (object.ReferenceEquals(type, typeof(ControllerTemplateElementType)))
		{
			return dESgFzzjUASSsXqyQnTPkfkTyAG((ControllerTemplateElementType)P_0);
		}
		throw new NotImplementedException();
	}

	public static ControllerElementType dESgFzzjUASSsXqyQnTPkfkTyAG(ControllerTemplateElementType P_0)
	{
		while (true)
		{
			switch (-245917985 ^ -245917987)
			{
			case 0:
				continue;
			case 2:
				switch (P_0)
				{
				case ControllerTemplateElementType.Axis:
					break;
				case ControllerTemplateElementType.Button:
					return ControllerElementType.Button;
				default:
					throw new NotImplementedException();
				}
				break;
			}
			break;
		}
		return ControllerElementType.Axis;
	}

	public static ControllerTemplateElementSourceType XSaogomKcrJgoEtpmWlrLVouCEB(ControllerTemplateElementType P_0, bool P_1)
	{
		while (true)
		{
			int num = -352984580;
			while (true)
			{
				switch (num ^ -352984579)
				{
				case 2:
					break;
				case 0:
					throw new NotImplementedException();
				case 4:
					return ControllerTemplateElementSourceType.Axis;
				case 5:
				{
					int num2;
					if (P_1)
					{
						num = -352984579;
						num2 = num;
					}
					else
					{
						num = -352984578;
						num2 = num;
					}
					continue;
				}
				case 1:
					switch (P_0)
					{
					case ControllerTemplateElementType.Axis:
						break;
					case ControllerTemplateElementType.Button:
						return ControllerTemplateElementSourceType.Button;
					default:
						num = -352984584;
						continue;
					}
					goto case 4;
				default:
					return (ControllerTemplateElementSourceType)(-1);
				}
				break;
			}
		}
	}

	public static ControllerTemplateElementType LpJPZRKGuKEvAFVHrgyOCheoguI(ControllerElementType P_0, bool P_1)
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
