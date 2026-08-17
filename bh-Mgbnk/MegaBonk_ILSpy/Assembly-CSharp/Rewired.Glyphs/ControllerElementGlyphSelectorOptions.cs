using System;
using Cpp2ILInjected;

namespace Rewired.Glyphs;

[Serializable]
public class ControllerElementGlyphSelectorOptions
{
	private bool _useLastActiveController = true;

	private ControllerType[] _controllerTypeOrder = new ControllerType[4]
	{
		ControllerType.Joystick,
		ControllerType.Custom,
		ControllerType.Mouse,
		ControllerType.Keyboard
	};

	private static ControllerElementGlyphSelectorOptions s_defaultOptions;

	public bool useLastActiveController
	{
		get
		{
			return _useLastActiveController;
		}
		set
		{
			_useLastActiveController = value;
		}
	}

	public ControllerType[] controllerTypeOrder
	{
		get
		{
			return _controllerTypeOrder;
		}
		set
		{
			_controllerTypeOrder = value;
		}
	}

	public static ControllerElementGlyphSelectorOptions defaultOptions
	{
		get
		{
			if (s_defaultOptions != null)
			{
				return s_defaultOptions;
			}
			ControllerElementGlyphSelectorOptions controllerElementGlyphSelectorOptions = new ControllerElementGlyphSelectorOptions();
			controllerElementGlyphSelectorOptions._useLastActiveController = true;
			controllerElementGlyphSelectorOptions._controllerTypeOrder = new ControllerType[4]
			{
				ControllerType.Joystick,
				ControllerType.Custom,
				ControllerType.Mouse,
				ControllerType.Keyboard
			};
			s_defaultOptions = controllerElementGlyphSelectorOptions;
			return controllerElementGlyphSelectorOptions;
		}
		set
		{
			s_defaultOptions = value;
		}
	}

	public unsafe virtual bool TryGetControllerTypeOrder(int index, out ControllerType controllerType)
	{
		//IL_007d: Expected I4, but got O
		ControllerType[] array = _controllerTypeOrder;
		if (_controllerTypeOrder != null)
		{
			ref ControllerType reference;
			if (index < array.Length)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (Rewired.ControllerType[])+20+index @ rdx (System.Int32)*4]");
				reference = ref *(ControllerType*)null;
				return true;
			}
			reference = ref *(ControllerType*)null;
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public ControllerElementGlyphSelectorOptions()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
