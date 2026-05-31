using System;
using Rewired;

internal static class XqmnYoifzflCsKxcFaHDewlkEkh
{
	public static ControllerElementType oVgOuHppbsfQJuEfZwNSyeJURnL(ElementAssignmentType P_0)
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

	public static ElementAssignmentType TIeZCkzWuGkHIQITPOhOHQretQz(ControllerType P_0, ControllerElementType P_1, AxisRange P_2)
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

	public static AxisRange HbHyHxvgRXOuVwvWaeCzlAldJLx(Pole P_0)
	{
		return P_0 switch
		{
			Pole.Positive => AxisRange.Positive, 
			Pole.Negative => AxisRange.Negative, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static Type aJrrqGyLCDRlBrfkAGETCWIFCyIz<T>() where T : Controller
	{
		return aJrrqGyLCDRlBrfkAGETCWIFCyIz(typeof(T));
	}

	public static Type aJrrqGyLCDRlBrfkAGETCWIFCyIz(Type P_0)
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

	public static Type MRUvqFxlANUbPgxDzQjxtkXcEdsA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => typeof(JoystickMap), 
			ControllerType.Keyboard => typeof(KeyboardMap), 
			ControllerType.Mouse => typeof(MouseMap), 
			ControllerType.Custom => typeof(CustomControllerMap), 
			_ => throw new NotImplementedException(), 
		};
	}

	public static Type ZEvBbjjmPRfIaVKmqxjGJUjtsWBR(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => typeof(Joystick), 
			ControllerType.Keyboard => typeof(Keyboard), 
			ControllerType.Mouse => typeof(Mouse), 
			ControllerType.Custom => typeof(CustomController), 
			_ => throw new NotImplementedException(), 
		};
	}

	public static ControllerType COrXrkTEKmpseQxNMlRJlIhLHQU(Type P_0)
	{
		if ((object)P_0 == null)
		{
			throw new ArgumentNullException("controllerType");
		}
		if (object.ReferenceEquals(P_0, typeof(Joystick)))
		{
			return ControllerType.Joystick;
		}
		if (object.ReferenceEquals(P_0, typeof(Keyboard)))
		{
			return ControllerType.Keyboard;
		}
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

	public static ControllerType COrXrkTEKmpseQxNMlRJlIhLHQU<T>()
	{
		return COrXrkTEKmpseQxNMlRJlIhLHQU(typeof(T));
	}

	public static ControllerType uEVNVvQRYSYawWaGkSxRghrpBcv(Type P_0)
	{
		if (!ctIasoEjDOEPmNnnXJueFDtghIqF(P_0, out var result))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		return result;
	}

	public static ControllerType uEVNVvQRYSYawWaGkSxRghrpBcv<T>() where T : ControllerMap
	{
		return uEVNVvQRYSYawWaGkSxRghrpBcv(typeof(T));
	}

	public static bool ctIasoEjDOEPmNnnXJueFDtghIqF(Type P_0, out ControllerType P_1)
	{
		if ((object)P_0 == null)
		{
			throw new ArgumentNullException("mapType");
		}
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
		if (object.ReferenceEquals(P_0, typeof(MouseMap)))
		{
			P_1 = ControllerType.Mouse;
			return true;
		}
		if (object.ReferenceEquals(P_0, typeof(CustomControllerMap)))
		{
			P_1 = ControllerType.Custom;
			return true;
		}
		if (object.ReferenceEquals(P_0, typeof(ControllerMap)))
		{
			P_1 = ControllerType.Keyboard;
			return false;
		}
		if (object.ReferenceEquals(P_0, typeof(ControllerMapWithAxes)))
		{
			P_1 = ControllerType.Keyboard;
			return false;
		}
		throw new NotImplementedException();
	}

	public static bool ctIasoEjDOEPmNnnXJueFDtghIqF<T>(out ControllerType P_0) where T : ControllerMap
	{
		return ctIasoEjDOEPmNnnXJueFDtghIqF(typeof(T), out P_0);
	}

	public static ControllerType knHEmNEychMikCIUrAVKQpOamGHf(Type P_0)
	{
		if ((object)P_0 == null)
		{
			throw new ArgumentNullException("controllerMapSaveDataType");
		}
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
		if (object.ReferenceEquals(P_0, typeof(ControllerMapSaveData)))
		{
			throw new Exception(P_0.Name + " is not an allowed type.");
		}
		throw new NotImplementedException();
	}

	public static ControllerType knHEmNEychMikCIUrAVKQpOamGHf<T>() where T : ControllerMapSaveData
	{
		return knHEmNEychMikCIUrAVKQpOamGHf(typeof(T));
	}

	public static bool kGUAgzoWmpBJnomvNrYAMpbELMU(ControllerTemplateElementType P_0, ControllerElementType P_1)
	{
		return P_1 switch
		{
			ControllerElementType.Axis => P_0 == ControllerTemplateElementType.Axis, 
			ControllerElementType.Button => P_0 == ControllerTemplateElementType.Button, 
			ControllerElementType.CompoundElement => false, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static ControllerElementType BftiocUDprOjmsXKNAlEbrrmBZF(object P_0)
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
			return BftiocUDprOjmsXKNAlEbrrmBZF((ControllerTemplateElementType)P_0);
		}
		throw new NotImplementedException();
	}

	public static ControllerElementType BftiocUDprOjmsXKNAlEbrrmBZF(ControllerTemplateElementType P_0)
	{
		return P_0 switch
		{
			ControllerTemplateElementType.Axis => ControllerElementType.Axis, 
			ControllerTemplateElementType.Button => ControllerElementType.Button, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static ControllerTemplateElementSourceType rqHcoxLXFOnPmvALtcjiEEdZOdIu(ControllerTemplateElementType P_0, bool P_1)
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

	public static ControllerTemplateElementType bRoFBEhvbtKvQuxtaxsFNImJRNR(ControllerElementType P_0, bool P_1)
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
