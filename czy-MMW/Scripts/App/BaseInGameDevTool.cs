using System;
using System.Collections.Generic;
using Client;
using Factory;
using Factory.Pools;
using Motorways;
using Motorways.Themes;
using Motorways.Views;
using Server;
using UnityEngine;

public abstract class BaseInGameDevTool<DevToolType, CommandType> : IInGameDevTool, IReusable where DevToolType : BaseInGameDevTool<DevToolType, CommandType> where CommandType : BaseInGameDevToolCommand<CommandType>
{
	[Dependency]
	public IScope gameScope;

	[Dependency]
	protected InputState _inputState;

	[Dependency]
	protected ISimulation _simulation;

	[Dependency]
	protected TilemapView _tilemapView;

	protected string commandSerializationName;

	protected string editorDisplayName;

	protected string editorIconPath;

	protected List<KeyCode> keyCodes = new List<KeyCode>();

	protected List<int> mouseButtonIndicies = new List<int>();

	protected List<string> controllerLogicalActions = new List<string>();

	protected List<IngameDevToolBoolParameter> boolParameters = new List<IngameDevToolBoolParameter>();

	protected List<IngameDevToolIntParameter> intParameters = new List<IngameDevToolIntParameter>();

	protected List<IInGameDevToolEnumParameter> enumParameters = new List<IInGameDevToolEnumParameter>();

	protected List<IngameDevToolFloatParameter> floatParameters = new List<IngameDevToolFloatParameter>();

	protected List<IngameDevToolStringParameter> stringParameters = new List<IngameDevToolStringParameter>();

	protected List<InGameDevToolParameterType> parameterOrder = new List<InGameDevToolParameterType>();

	protected Action<DevToolType, ISimulation> clientCodeToExecute;

	protected Action<CommandType, ISimulation> commandToExecute;

	protected bool activateOnEditorButtonPress;

	protected string editorButtonText = "";

	protected bool wasButtonPressed;

	protected KeyCode hotkeyKeycode;

	protected KeyCode modifierKeycode;

	protected Action<CommandType, ISimulation> onHotkeyPressedCustomSetup;

	protected Dictionary<KeyCode, (string, int)> keyCodesToIntParameters = new Dictionary<KeyCode, (string, int)>();

	protected bool defaultsToNoneResetAfterUse;

	protected bool showGridWhenActive;

	protected Action<DevToolType> onSelected;

	protected Action<DevToolType, Vector2Int> onHoveredTileChanged;

	protected Action<DevToolType, Vector2Int, DebugTileDataViewer> drawOnTiles;

	protected Action<DevToolType> onDeselected;

	protected Vector2Int lastHoveredTile = Vector2Int.zero;

	protected DebugTileDataViewer debugTileDataViewer;

	public bool ResetToNoneAfterUse { get; set; }

	public IInGameDevTool SetCommandSerializationName(string newCommandSerializationName)
	{
		commandSerializationName = newCommandSerializationName;
		return this;
	}

	public DevToolType SetEditorDisplayName(string newDisplayName)
	{
		editorDisplayName = newDisplayName;
		return (DevToolType)this;
	}

	public DevToolType SetEditorIconPath(string newDisplayName)
	{
		editorIconPath = newDisplayName;
		return (DevToolType)this;
	}

	public virtual DevToolType ActivateOnKeyPressed(KeyCode keyCode)
	{
		if (!keyCodes.Contains(keyCode))
		{
			keyCodes.Add(keyCode);
		}
		return (DevToolType)this;
	}

	public virtual DevToolType ActivateOnMouseButtonDown(int buttonIndex)
	{
		if (!mouseButtonIndicies.Contains(buttonIndex))
		{
			mouseButtonIndicies.Add(buttonIndex);
		}
		return (DevToolType)this;
	}

	public virtual DevToolType ActivateOnLeftMouseButtonDown()
	{
		return ActivateOnMouseButtonDown(19);
	}

	public virtual DevToolType ActivateOnRightMouseButtonDown()
	{
		return ActivateOnMouseButtonDown(20);
	}

	public virtual DevToolType ActivateOnControllerLogicalAction(string logicalAction)
	{
		if (!controllerLogicalActions.Contains(logicalAction))
		{
			controllerLogicalActions.Add(logicalAction);
		}
		return (DevToolType)this;
	}

	public virtual DevToolType ActivateOnDefaultActionInput()
	{
		return ActivateOnLeftMouseButtonDown().ActivateOnControllerLogicalAction("ActivateSelected");
	}

	public virtual DevToolType ActivateOnInGameHotkey(KeyCode hotkey, KeyCode modifierKey = KeyCode.None)
	{
		hotkeyKeycode = hotkey;
		onHotkeyPressedCustomSetup = null;
		modifierKeycode = modifierKey;
		return (DevToolType)this;
	}

	public virtual DevToolType ActivateOnInGameHotkeyCustomSetup(KeyCode hotkey, Action<CommandType, ISimulation> customSetup)
	{
		hotkeyKeycode = hotkey;
		onHotkeyPressedCustomSetup = customSetup;
		return (DevToolType)this;
	}

	public virtual DevToolType ActivateOnInGameHotkeyWithIntParameter(KeyCode hotkey, string parameterName, int parameterValue)
	{
		if (Diagnostics.Verify(!keyCodesToIntParameters.ContainsKey(hotkey)))
		{
			keyCodesToIntParameters.Add(hotkey, (parameterName, parameterValue));
		}
		return (DevToolType)this;
	}

	public virtual DevToolType ActivateOnEditorButton(string buttonText)
	{
		activateOnEditorButtonPress = true;
		editorButtonText = buttonText;
		return (DevToolType)this;
	}

	public virtual DevToolType DefaultToResettingToNoneAfterUse()
	{
		ResetToNoneAfterUse = true;
		defaultsToNoneResetAfterUse = true;
		return (DevToolType)this;
	}

	public DevToolType SetClientCodeToExecute(Action<DevToolType, ISimulation> newClientDelegate)
	{
		clientCodeToExecute = newClientDelegate;
		return (DevToolType)this;
	}

	public virtual DevToolType SetCommandToExecute(Action<CommandType, ISimulation> newCommand)
	{
		commandToExecute = newCommand;
		return (DevToolType)this;
	}

	public virtual DevToolType ShowGridWhenActive()
	{
		showGridWhenActive = true;
		return (DevToolType)this;
	}

	public virtual DevToolType ExecuteOnToolSelected(Action<DevToolType> onToolSelected)
	{
		onSelected = onToolSelected;
		return (DevToolType)this;
	}

	public virtual DevToolType ExecuteOnToolDeselected(Action<DevToolType> onToolDeselected)
	{
		onDeselected = onToolDeselected;
		return (DevToolType)this;
	}

	public virtual DevToolType ExecuteOnHoveredTileChanged(Action<DevToolType, Vector2Int> onNewTileHovered)
	{
		onHoveredTileChanged = onNewTileHovered;
		return (DevToolType)this;
	}

	public virtual DevToolType DrawOnTilesUnderCursor(Action<DevToolType, Vector2Int, DebugTileDataViewer> actionToDrawOnTiles)
	{
		drawOnTiles = actionToDrawOnTiles;
		return (DevToolType)this;
	}

	public DevToolType WithBoolParam(IngameDevToolBoolParameter boolParameter)
	{
		boolParameters.Add(boolParameter);
		parameterOrder.Add(InGameDevToolParameterType.Bool);
		return (DevToolType)this;
	}

	public DevToolType WithIntParam(IngameDevToolIntParameter intParameter)
	{
		intParameters.Add(intParameter);
		parameterOrder.Add(InGameDevToolParameterType.Int);
		return (DevToolType)this;
	}

	public DevToolType WithEnumParam(IInGameDevToolEnumParameter enumParameter)
	{
		enumParameters.Add(enumParameter);
		parameterOrder.Add(InGameDevToolParameterType.Enum);
		return (DevToolType)this;
	}

	public DevToolType WithFloatParam(IngameDevToolFloatParameter floatParameter)
	{
		floatParameters.Add(floatParameter);
		parameterOrder.Add(InGameDevToolParameterType.Float);
		return (DevToolType)this;
	}

	public DevToolType WithStringParam(IngameDevToolStringParameter stringParameter)
	{
		stringParameters.Add(stringParameter);
		parameterOrder.Add(InGameDevToolParameterType.String);
		return (DevToolType)this;
	}

	public DevToolType OverrideDrawEditorToolFunction(Action<DevToolType> newDrawEditorTool)
	{
		return (DevToolType)this;
	}

	public virtual string GetCommandSerializationName()
	{
		return commandSerializationName;
	}

	public virtual string GetEditorToolDisplayName()
	{
		string text = editorDisplayName;
		if (hotkeyKeycode != KeyCode.None)
		{
			text = text + " (" + GetHotkeyString() + ")";
		}
		return text;
	}

	public virtual string GetHotkeyString()
	{
		if (hotkeyKeycode == KeyCode.None)
		{
			return string.Empty;
		}
		string text = HotkeyDescription.GetHotkeyCharacter(hotkeyKeycode);
		if (modifierKeycode != KeyCode.None)
		{
			text = HotkeyDescription.GetHotkeyCharacter(modifierKeycode) + text;
		}
		return text;
	}

	public virtual string GetEditorToolDisplayNameWithoutHotkeyCode()
	{
		return editorDisplayName;
	}

	public virtual string GetEditorToolIconPath()
	{
		return editorIconPath;
	}

	public IEnumerable<IngameDevToolBoolParameter> BoolParameters()
	{
		return boolParameters;
	}

	public IEnumerable<IngameDevToolIntParameter> IntParameters()
	{
		return intParameters;
	}

	public IEnumerable<IInGameDevToolEnumParameter> EnumParameters()
	{
		return enumParameters;
	}

	public IEnumerable<IngameDevToolFloatParameter> FloatParameters()
	{
		return floatParameters;
	}

	public IEnumerable<IngameDevToolStringParameter> StringParameters()
	{
		return stringParameters;
	}

	public virtual IngameDevToolBoolParameter GetBoolParameter(string parameterName)
	{
		foreach (IngameDevToolBoolParameter boolParameter in boolParameters)
		{
			if (boolParameter.ParameterName == parameterName)
			{
				return boolParameter;
			}
		}
		return null;
	}

	public virtual IngameDevToolIntParameter GetIntParameter(string parameterName)
	{
		foreach (IngameDevToolIntParameter intParameter in intParameters)
		{
			if (intParameter.ParameterName == parameterName)
			{
				return intParameter;
			}
		}
		return null;
	}

	public virtual IngameDevToolEnumParameter<EnumType> GetEnumParameter<EnumType>(string parameterName) where EnumType : struct
	{
		foreach (IInGameDevToolEnumParameter enumParameter in enumParameters)
		{
			if (enumParameter.ParameterName == parameterName && typeof(IngameDevToolEnumParameter<EnumType>).IsAssignableFrom(enumParameter.GetType()))
			{
				return (IngameDevToolEnumParameter<EnumType>)enumParameter;
			}
		}
		return null;
	}

	public virtual string GetEnumParameterValueAsString(string parameterName)
	{
		foreach (IInGameDevToolEnumParameter enumParameter in enumParameters)
		{
			if (enumParameter.ParameterName == parameterName)
			{
				return enumParameter.ParameterSerializationValue;
			}
		}
		Diagnostics.FailAssert("Can't find an enum parameter named {0} on tool {1}.", parameterName, GetCommandSerializationName());
		return null;
	}

	public virtual IngameDevToolFloatParameter GetFloatParameter(string parameterName)
	{
		foreach (IngameDevToolFloatParameter floatParameter in floatParameters)
		{
			if (floatParameter.ParameterName == parameterName)
			{
				return floatParameter;
			}
		}
		return null;
	}

	public virtual IngameDevToolStringParameter GetStringParameter(string parameterName)
	{
		foreach (IngameDevToolStringParameter stringParameter in stringParameters)
		{
			if (stringParameter.ParameterName == parameterName)
			{
				return stringParameter;
			}
		}
		return null;
	}

	public virtual void PrepareTool()
	{
	}

	public virtual void Tick(TimeInterval tickTime, float stepAlpha, out bool activatedThisTick)
	{
		Vector2Int mouseTilePosition = _tilemapView.GetMouseTilePosition();
		if (mouseTilePosition != lastHoveredTile)
		{
			if (onHoveredTileChanged != null)
			{
				onHoveredTileChanged((DevToolType)this, mouseTilePosition);
			}
			if (drawOnTiles != null)
			{
				if (debugTileDataViewer == null)
				{
					debugTileDataViewer = new GameObject("Tile Drawing For " + GetCommandSerializationName() + " Tool").AddComponent<DebugTileDataViewer>();
					debugTileDataViewer.onlyDrawWhenSelected = false;
				}
				drawOnTiles((DevToolType)this, mouseTilePosition, debugTileDataViewer);
			}
			lastHoveredTile = mouseTilePosition;
		}
		if (showGridWhenActive)
		{
			Color globalColor = (gameScope.Get<IThemeDatabase>() as MotorwaysThemeDatabase).GetGlobalColor(ThemedMaterialType.Dark);
			for (int i = -50; i < 50; i += 2)
			{
				Debug.DrawLine(new Vector3(i + 1, -200f), new Vector3(i + 1, 200f), globalColor, 0.1f, depthTest: false);
				Debug.DrawLine(new Vector3(-200f, i + 1), new Vector3(200f, i + 1), globalColor, 0.1f, depthTest: false);
			}
		}
		bool flag = wasButtonPressed;
		if (!flag)
		{
			flag = TryAssignHotkeyParameters();
		}
		if (!flag)
		{
			foreach (KeyCode keyCode in keyCodes)
			{
				if (Input.GetKeyDown(keyCode))
				{
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			foreach (string controllerLogicalAction in controllerLogicalActions)
			{
				_ = controllerLogicalAction;
			}
		}
		if (!flag)
		{
			IPointerState mouse = _inputState.Mouse;
			foreach (int mouseButtonIndicy in mouseButtonIndicies)
			{
				if (mouse.GetButtonState(mouseButtonIndicy).CurrentState == InputEventButtonState.JustDown)
				{
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			OnActivation();
		}
		activatedThisTick = flag;
	}

	private bool TryAssignHotkeyParameters()
	{
		foreach (KeyValuePair<KeyCode, (string, int)> keyCodesToIntParameter in keyCodesToIntParameters)
		{
			if (!Input.GetKeyDown(keyCodesToIntParameter.Key))
			{
				continue;
			}
			foreach (IngameDevToolIntParameter intParameter in intParameters)
			{
				if (intParameter.ParameterName == keyCodesToIntParameter.Value.Item1)
				{
					intParameter.SetValue(keyCodesToIntParameter.Value.Item2);
					return true;
				}
			}
			Diagnostics.FailAssert("Couldn't find an int parameter named {0} which is assigned to {1}!", keyCodesToIntParameter.Value.Item1, keyCodesToIntParameter.Key);
		}
		return false;
	}

	protected virtual void OnActivation()
	{
		if (clientCodeToExecute != null)
		{
			clientCodeToExecute((DevToolType)this, _simulation);
		}
		if (commandToExecute != null)
		{
			_simulation.ScheduleCommand(GenerateCommand());
		}
		wasButtonPressed = false;
	}

	public virtual Command GenerateCommand(bool useDefaultParameterValues = false)
	{
		CommandType val = gameScope.Get<CommandType>();
		val.InitializeFromDevTool(this, useDefaultParameterValues);
		val.commandSerializationName = commandSerializationName;
		val.commandToExecute = commandToExecute;
		val.cursorTilePosition = _tilemapView.GetMouseTilePosition();
		return val;
	}

	public virtual void CleanupTool()
	{
	}

	public virtual void OnToolSelected()
	{
		if (onSelected != null)
		{
			onSelected((DevToolType)this);
		}
	}

	public virtual void OnToolDeselected()
	{
		if (debugTileDataViewer != null)
		{
			UnityEngine.Object.Destroy(debugTileDataViewer.gameObject);
			debugTileDataViewer = null;
		}
		if (onDeselected != null)
		{
			onDeselected((DevToolType)this);
		}
	}

	public virtual void DrawEditorTool()
	{
	}

	public virtual void DrawBaseEditorTool(DevToolType devTool)
	{
	}

	public virtual void Reset()
	{
		commandSerializationName = "";
		editorDisplayName = "";
		editorIconPath = "";
		keyCodes.Clear();
		keyCodesToIntParameters.Clear();
		mouseButtonIndicies.Clear();
		controllerLogicalActions.Clear();
		boolParameters.Clear();
		intParameters.Clear();
		enumParameters.Clear();
		floatParameters.Clear();
		stringParameters.Clear();
		parameterOrder.Clear();
		commandToExecute = null;
		clientCodeToExecute = null;
		activateOnEditorButtonPress = false;
		editorButtonText = "";
		wasButtonPressed = false;
		hotkeyKeycode = KeyCode.None;
		modifierKeycode = KeyCode.None;
		onHotkeyPressedCustomSetup = null;
		defaultsToNoneResetAfterUse = false;
		showGridWhenActive = false;
		lastHoveredTile = default(Vector2Int);
	}

	public virtual Action<RequestedCommandType, ISimulation> GetActionWithCommandType<RequestedCommandType>()
	{
		if (typeof(RequestedCommandType) == typeof(CommandType))
		{
			return (Action<RequestedCommandType, ISimulation>)(object)commandToExecute;
		}
		return null;
	}

	public bool InGameHotkeyActivated()
	{
		if (Input.GetKeyDown(hotkeyKeycode))
		{
			if (modifierKeycode != KeyCode.None)
			{
				return Input.GetKey(modifierKeycode);
			}
			return true;
		}
		return false;
	}

	public bool InGameParameterHotKeyActivated()
	{
		return TryAssignHotkeyParameters();
	}

	public void OnHotkeyActivated(bool useDefaultValues)
	{
		if (clientCodeToExecute != null)
		{
			clientCodeToExecute((DevToolType)this, _simulation);
		}
		if (commandToExecute != null)
		{
			CommandType val = (CommandType)GenerateCommand(useDefaultValues);
			if (onHotkeyPressedCustomSetup != null)
			{
				onHotkeyPressedCustomSetup(val, _simulation);
			}
			_simulation.ScheduleCommand(val);
		}
	}

	public bool HasHotKey()
	{
		return hotkeyKeycode != KeyCode.None;
	}

	public KeyCode GetHotKey()
	{
		return hotkeyKeycode;
	}

	public KeyCode GetModifierHotKey()
	{
		return modifierKeycode;
	}
}
