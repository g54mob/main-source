using System;
using Rewired;

internal static class uAOMfTHsnTLbvEUpHTchXYOhMgjh
{
	public static ControllerElementType XLKAHwgEgKUaInaXPLsoBHajZhZyA(ElementAssignmentType P_0)
	{
		switch (P_0)
		{
		case ElementAssignmentType.Button:
		case ElementAssignmentType.KeyboardKey:
			return ControllerElementType.Button;
		case ElementAssignmentType.FullAxis:
		case ElementAssignmentType.SplitAxis:
			return ControllerElementType.Axis;
		default:
			throw new NotImplementedException();
		}
	}

	public static ElementAssignmentType arQDbNGFpynvRIHzBKTuqECrEEpT(ControllerType P_0, ControllerElementType P_1, AxisRange P_2)
	{
		if (P_0 == ControllerType.Keyboard)
		{
			return ElementAssignmentType.KeyboardKey;
		}
		switch (P_1)
		{
		case ControllerElementType.Axis:
			if (P_2 == AxisRange.Full)
			{
				return ElementAssignmentType.FullAxis;
			}
			return ElementAssignmentType.SplitAxis;
		case ControllerElementType.Button:
			return ElementAssignmentType.Button;
		default:
			throw new NotImplementedException();
		}
	}

	public static AxisRange mNhbRQYYWlkcEsLXsHJTSlMucFfM(Pole P_0)
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

	public static Type BPPAFbbDFtiDUWhQIPhrffpUyeUtA<_0001>() where _0001 : Controller
	{
		return BPPAFbbDFtiDUWhQIPhrffpUyeUtA(typeof(_0001));
	}

	public static Type BPPAFbbDFtiDUWhQIPhrffpUyeUtA(Type P_0)
	{
		if ((object)P_0 == typeof(Joystick))
		{
			return typeof(JoystickMap);
		}
		if ((object)P_0 == typeof(Keyboard))
		{
			return typeof(KeyboardMap);
		}
		if ((object)P_0 == typeof(Mouse))
		{
			return typeof(MouseMap);
		}
		if ((object)P_0 == typeof(CustomController))
		{
			return typeof(CustomControllerMap);
		}
		if ((object)P_0 == typeof(Controller))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		if ((object)P_0 == typeof(ControllerWithMap))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		if ((object)P_0 == typeof(ControllerWithAxes))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		throw new NotImplementedException();
	}

	public static Type xvekHmAvPrjRCokllzEXUjejXvwW(ControllerType P_0)
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

	public static Type kiHgGCThMdrmhWxWkNYsnzAkPMZO(ControllerType P_0)
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

	public static ControllerType dCDiSNmXZWjCxMjhOfIfIHAULWGO(Type P_0)
	{
		if ((object)P_0 == null)
		{
			throw new ArgumentNullException("controllerType");
		}
		if ((object)P_0 == typeof(Joystick))
		{
			return ControllerType.Joystick;
		}
		if ((object)P_0 == typeof(Keyboard))
		{
			return ControllerType.Keyboard;
		}
		if ((object)P_0 == typeof(Mouse))
		{
			return ControllerType.Mouse;
		}
		if ((object)P_0 == typeof(CustomController))
		{
			return ControllerType.Custom;
		}
		if ((object)P_0 == typeof(Controller))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		if ((object)P_0 == typeof(ControllerWithMap))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		if ((object)P_0 == typeof(ControllerWithAxes))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		throw new NotImplementedException();
	}

	public static ControllerType dCDiSNmXZWjCxMjhOfIfIHAULWGO<_0001>()
	{
		return dCDiSNmXZWjCxMjhOfIfIHAULWGO(typeof(_0001));
	}

	public static ControllerType XhIiIdTNiByfMHGggxzLSYyeBeJA(Type P_0)
	{
		if (!XiwRDJOlGaIdvbITXANGklQcDAsaA(P_0, out var result))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		return result;
	}

	public static ControllerType XhIiIdTNiByfMHGggxzLSYyeBeJA<_0001>() where _0001 : ControllerMap
	{
		return XhIiIdTNiByfMHGggxzLSYyeBeJA(typeof(_0001));
	}

	public static bool XiwRDJOlGaIdvbITXANGklQcDAsaA(Type P_0, out ControllerType P_1)
	{
		if ((object)P_0 == null)
		{
			throw new ArgumentNullException("mapType");
		}
		if ((object)P_0 == typeof(JoystickMap))
		{
			P_1 = ControllerType.Joystick;
			return true;
		}
		if ((object)P_0 == typeof(KeyboardMap))
		{
			P_1 = ControllerType.Keyboard;
			return true;
		}
		if ((object)P_0 == typeof(MouseMap))
		{
			P_1 = ControllerType.Mouse;
			return true;
		}
		if ((object)P_0 == typeof(CustomControllerMap))
		{
			P_1 = ControllerType.Custom;
			return true;
		}
		if ((object)P_0 == typeof(ControllerMap))
		{
			P_1 = ControllerType.Keyboard;
			return false;
		}
		if ((object)P_0 == typeof(ControllerMapWithAxes))
		{
			P_1 = ControllerType.Keyboard;
			return false;
		}
		throw new NotImplementedException();
	}

	public static bool XiwRDJOlGaIdvbITXANGklQcDAsaA<_0001>(out ControllerType P_0) where _0001 : ControllerMap
	{
		return XiwRDJOlGaIdvbITXANGklQcDAsaA(typeof(_0001), out P_0);
	}

	public static ControllerType BFhPJuTSfRAKfWOopkccSyfpnIHq(Type P_0)
	{
		if ((object)P_0 == null)
		{
			throw new ArgumentNullException("controllerMapSaveDataType");
		}
		if ((object)P_0 == typeof(JoystickMapSaveData))
		{
			return ControllerType.Joystick;
		}
		if ((object)P_0 == typeof(KeyboardMapSaveData))
		{
			return ControllerType.Keyboard;
		}
		if ((object)P_0 == typeof(MouseMapSaveData))
		{
			return ControllerType.Mouse;
		}
		if ((object)P_0 == typeof(CustomControllerMapSaveData))
		{
			return ControllerType.Custom;
		}
		if ((object)P_0 == typeof(ControllerMapSaveData))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		throw new NotImplementedException();
	}

	public static ControllerType BFhPJuTSfRAKfWOopkccSyfpnIHq<_0001>() where _0001 : ControllerMapSaveData
	{
		return BFhPJuTSfRAKfWOopkccSyfpnIHq(typeof(_0001));
	}

	public static bool TUibHCXgdJpNwgxVPYRazOMZLYAI(ControllerTemplateElementType P_0, ControllerElementType P_1)
	{
		switch (P_1)
		{
		case ControllerElementType.Axis:
			return P_0 == ControllerTemplateElementType.Axis;
		case ControllerElementType.Button:
			return P_0 == ControllerTemplateElementType.Button;
		case ControllerElementType.CompoundElement:
			return false;
		default:
			throw new NotImplementedException();
		}
	}

	public static ControllerElementType emBXVZpTuXINfilcDcYgCfWhEPDJA(object P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("type");
		}
		Type type = P_0.GetType();
		if ((object)type == typeof(ControllerElementType))
		{
			return (ControllerElementType)P_0;
		}
		if ((object)type == typeof(ControllerTemplateElementType))
		{
			return emBXVZpTuXINfilcDcYgCfWhEPDJA((ControllerTemplateElementType)P_0);
		}
		throw new NotImplementedException();
	}

	public static ControllerElementType emBXVZpTuXINfilcDcYgCfWhEPDJA(ControllerTemplateElementType P_0)
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

	public static ControllerTemplateElementSourceType YyjJqQyIpkrdrxdRdEuEvKgCrLGD(ControllerTemplateElementType P_0, bool P_1)
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

	public static ControllerTemplateElementType KbOOarMfeRNXDeaPioFdqvTWLNBW(ControllerElementType P_0, bool P_1)
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
