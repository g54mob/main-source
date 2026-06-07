using System.Collections.Generic;
using Rewired;

public class GamepadChipModule : Module, IInputChip
{
	public enum Commands
	{

	}

	public class GamepadIsActive_EventData : EventData
	{
		public bool IsActive;

		public GamepadIsActive_EventData()
		{
		}

		public GamepadIsActive_EventData(bool isActive)
		{
		}
	}

	public class GamepadButton_EventData : EventData
	{
		public bool ButtonDown;

		public bool ButtonUp;

		public bool IsAxis;

		public InputName InputName;

		public GamepadButton_EventData()
		{
		}

		public GamepadButton_EventData(bool buttonDown, bool buttonUp, InputName inputName, bool isAxis)
		{
		}
	}

	private enum RewiredElementType
	{
		Button = 0,
		AxisFull = 1,
		AxisHalf = 2,
		ThumbStick = 3,
		DPad = 4
	}

	private ModuleProperty gamepadIndexProperty;

	private ModuleProperty isActiveProperty;

	private bool firstTickEvent;

	private static Dictionary<string, (RewiredElementType, int)> inputBindingsDictionary;

	private Rewired.Controller controller => null;

	public static ICollection<string> inputBindings => null;

	protected override void OnSetupFinished()
	{
	}

	public override void OnTurnOn()
	{
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	public void Update()
	{
	}

	private IControllerTemplateButton GetRewiredButton(Rewired.Controller controller, int id)
	{
		return null;
	}

	private IControllerTemplateAxis GetRewiredAxis(Rewired.Controller controller, int id)
	{
		return null;
	}

	private IControllerTemplateThumbStick GetRewiredThumbStick(Rewired.Controller controller, int id)
	{
		return null;
	}

	private IControllerTemplateDPad GetRewiredDPad(Rewired.Controller controller, int id)
	{
		return null;
	}

	public ICollection<string> GetInputBindings()
	{
		return null;
	}

	public InputBinding.Type GetInputBindingType(string name)
	{
		return default(InputBinding.Type);
	}

	public bool IsInputBindingValid(string name)
	{
		return false;
	}

	private float GetAxis((RewiredElementType, int) element, InputBinding.Direction direction)
	{
		return 0f;
	}

	private bool GetButtonState((RewiredElementType, int) element, InputBinding.Direction direction)
	{
		return false;
	}

	private bool GetButtonDown((RewiredElementType, int) element, InputBinding.Direction direction)
	{
		return false;
	}

	private bool GetButtonUp((RewiredElementType, int) element, InputBinding.Direction direction)
	{
		return false;
	}

	public float GetAxis(InputBinding inputBinding)
	{
		return 0f;
	}

	public bool GetButtonState(InputBinding inputBinding)
	{
		return false;
	}

	public bool GetButtonDown(InputBinding inputBinding)
	{
		return false;
	}

	public bool GetButtonUp(InputBinding inputBinding)
	{
		return false;
	}

	public InputSource Script_GetButtonInputSource(InputName name)
	{
		return default(InputSource);
	}

	public InputSource Script_GetAxisInputSource(InputName name)
	{
		return default(InputSource);
	}

	public InputSource Script_GetAxisInputSource(InputName negativeName, InputName positiveName)
	{
		return default(InputSource);
	}
}
