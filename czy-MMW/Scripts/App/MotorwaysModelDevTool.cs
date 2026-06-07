using System;
using System.Reflection;
using FixMath;
using Server;
using UnityEngine;

public abstract class MotorwaysModelDevTool<ModelType, DevToolType> : MotorwaysSharedDevTool<DevToolType, MotorwaysModelDevToolCommand>, IInGameModelDevTool, IInGameDevTool where ModelType : class, IModel where DevToolType : MotorwaysModelDevTool<ModelType, DevToolType>
{
	protected Action<MotorwaysModelDevToolCommand, ModelType, ISimulation> modelCommandToExecute;

	protected Action<MotorwaysModelDevTool<ModelType, DevToolType>, ModelType> onSelectedModelCommandToExecute;

	protected ToolModelType _toolModelType;

	protected Vector2Int selectedModelCoordinates;

	protected ModelType selectedModel;

	public ModelType SelectedModel => selectedModel;

	public virtual ToolModelType GetToolModelType()
	{
		return _toolModelType;
	}

	[Obsolete("If you're using a MotorwaysModelDevTool you should use SetModelCommandToExecute()", true)]
	public override DevToolType SetCommandToExecute(Action<MotorwaysModelDevToolCommand, ISimulation> newCommand)
	{
		throw new InvalidOperationException("If you're using a MotorwaysModelDevTool you should use SetModelCommandToExecute()");
	}

	[Obsolete("In model tools, all input and activation code is handled internally.", true)]
	public override DevToolType ActivateOnKeyPressed(KeyCode keyCode)
	{
		throw new InvalidOperationException("In model tools, all input and activation code is handled internally.");
	}

	[Obsolete("In model tools, all input and activation code is handled internally.", true)]
	public override DevToolType ActivateOnMouseButtonDown(int buttonIndex)
	{
		throw new InvalidOperationException("In model tools, all input and activation code is handled internally.");
	}

	[Obsolete("In model tools, all input and activation code is handled internally.", true)]
	public override DevToolType ActivateOnLeftMouseButtonDown()
	{
		throw new InvalidOperationException("In model tools, all input and activation code is handled internally.");
	}

	[Obsolete("In model tools, all input and activation code is handled internally.", true)]
	public override DevToolType ActivateOnRightMouseButtonDown()
	{
		throw new InvalidOperationException("In model tools, all input and activation code is handled internally.");
	}

	[Obsolete("In model tools, all input and activation code is handled internally.", true)]
	public override DevToolType ActivateOnControllerLogicalAction(string logicalAction)
	{
		throw new InvalidOperationException("In model tools, all input and activation code is handled internally.");
	}

	[Obsolete("In model tools, all input and activation code is handled internally.", true)]
	public override DevToolType ActivateOnDefaultActionInput()
	{
		throw new InvalidOperationException("In model tools, all input and activation code is handled internally.");
	}

	[Obsolete("In model tools, all input and activation code is handled internally.", true)]
	public override DevToolType ActivateOnInGameHotkey(KeyCode hotkey, KeyCode modifierHotKey = KeyCode.None)
	{
		throw new InvalidOperationException("In model tools, all input and activation code is handled internally.");
	}

	[Obsolete("In model tools, all input and activation code is handled internally.", true)]
	public override DevToolType ActivateOnInGameHotkeyCustomSetup(KeyCode hotkey, Action<MotorwaysModelDevToolCommand, ISimulation> customSetup)
	{
		throw new InvalidOperationException("In model tools, all input and activation code is handled internally.");
	}

	[Obsolete("In model tools, all input and activation code is handled internally.", true)]
	public virtual DevToolType ActivateOnInGameHotkeyWithIntParameter(KeyCode hotkey, int parameterValue, string parameterName)
	{
		throw new InvalidOperationException("In model tools, all input and activation code is handled internally.");
	}

	[Obsolete("In model tools, all input and activation code is handled internally.", true)]
	public override DevToolType ActivateOnEditorButton(string buttonText)
	{
		throw new InvalidOperationException("In model tools, all input and activation code is handled internally.");
	}

	public virtual DevToolType SetModelCommandToExecute(Action<MotorwaysModelDevToolCommand, ModelType, ISimulation> newCommand)
	{
		modelCommandToExecute = newCommand;
		return (DevToolType)this;
	}

	public virtual DevToolType SetOnModelSelectedCommandToExecute(Action<MotorwaysModelDevTool<ModelType, DevToolType>, ModelType> newCommand)
	{
		onSelectedModelCommandToExecute = newCommand;
		return (DevToolType)this;
	}

	public MotorwaysModelDevTool()
	{
		mouseButtonIndicies.Add(0);
		editorButtonText = "Apply";
		activateOnEditorButtonPress = true;
	}

	public override Command GenerateCommand(bool useDefaultParameterValues = false)
	{
		MotorwaysModelDevToolCommand obj = (MotorwaysModelDevToolCommand)base.GenerateCommand(useDefaultParameterValues);
		obj.SetEnumParameter("ToolModelType", _toolModelType);
		obj.cursorTilePosition = selectedModelCoordinates;
		return obj;
	}

	public override Action<CommandType, ISimulation> GetActionWithCommandType<CommandType>()
	{
		if (typeof(CommandType).IsAssignableFrom(typeof(MotorwaysModelDevToolCommand)))
		{
			return (Action<CommandType, ISimulation>)(object)new Action<MotorwaysModelDevToolCommand, ISimulation>(CallUserFunction);
		}
		return null;
	}

	protected void CallUserFunction(MotorwaysModelDevToolCommand modelDevToolCommand, ISimulation simulation)
	{
		if (Diagnostics.Verify(modelDevToolCommand.TryGetEnumParameter<ToolModelType>("ToolModelType", out var _), "We should always have the ToolModelType parameter in a MotorwaysModelDevTool!") && TryGetModelAtCoordinates(modelDevToolCommand.cursorTilePosition, out var foundModel))
		{
			modelDevToolCommand.SyncValuesToModel(foundModel);
			if (modelCommandToExecute != null)
			{
				modelCommandToExecute(modelDevToolCommand, foundModel, simulation);
			}
		}
	}

	protected abstract bool TryGetModelAtCoordinates(Vector2Int modelCoordinates, out ModelType foundModel);

	public void OnModelActivation()
	{
		OnActivation();
	}

	protected override void OnActivation()
	{
		if (wasButtonPressed)
		{
			if (clientCodeToExecute != null)
			{
				clientCodeToExecute((DevToolType)this, _simulation);
			}
			_simulation.ScheduleCommand(GenerateCommand());
			wasButtonPressed = false;
		}
		else
		{
			AttemptToSelectModelUnderCursor();
		}
	}

	protected virtual void AttemptToSelectModelUnderCursor()
	{
		Vector2Int mouseTilePosition = _tilemapView.GetMouseTilePosition();
		if (TryGetModelAtCoordinates(mouseTilePosition, out var foundModel))
		{
			selectedModel = foundModel;
			selectedModelCoordinates = mouseTilePosition;
			SyncValuesFromModel();
			SelectedNewModel();
			gameScope.Get<InGameDevToolsRegistry>().UpdateEditorIfPresent();
		}
	}

	protected virtual void SelectedNewModel()
	{
		if (onSelectedModelCommandToExecute != null)
		{
			onSelectedModelCommandToExecute(this, SelectedModel);
		}
	}

	protected virtual void SyncValuesFromModel()
	{
		if (selectedModel == null)
		{
			return;
		}
		foreach (IngameDevToolBoolParameter boolParameter in boolParameters)
		{
			if (string.IsNullOrEmpty(boolParameter.ModelParameterFieldName))
			{
				continue;
			}
			FieldInfo field = typeof(ModelType).GetField(boolParameter.ModelParameterFieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field != null)
			{
				bool value = (bool)field.GetValue(selectedModel);
				boolParameter.SetValue(value);
				continue;
			}
			PropertyInfo property = typeof(ModelType).GetProperty(boolParameter.ModelParameterFieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (Diagnostics.Verify(property != null))
			{
				bool value2 = (bool)property.GetValue(selectedModel);
				boolParameter.SetValue(value2);
			}
		}
		foreach (IngameDevToolIntParameter intParameter in intParameters)
		{
			if (string.IsNullOrEmpty(intParameter.ModelParameterFieldName))
			{
				continue;
			}
			FieldInfo field2 = typeof(ModelType).GetField(intParameter.ModelParameterFieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field2 != null)
			{
				int value3 = (int)field2.GetValue(selectedModel);
				intParameter.SetValue(value3);
				continue;
			}
			PropertyInfo property2 = typeof(ModelType).GetProperty(intParameter.ModelParameterFieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (Diagnostics.Verify(property2 != null))
			{
				int value4 = (int)property2.GetValue(selectedModel);
				intParameter.SetValue(value4);
			}
		}
		foreach (IInGameDevToolEnumParameter enumParameter in enumParameters)
		{
			enumParameter.UpdateParameterValueFromModelField(selectedModel);
		}
		foreach (IngameDevToolFloatParameter floatParameter in floatParameters)
		{
			if (string.IsNullOrEmpty(floatParameter.ModelParameterFieldName))
			{
				continue;
			}
			FieldInfo field3 = typeof(ModelType).GetField(floatParameter.ModelParameterFieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field3 != null)
			{
				Fix64 value5 = (Fix64)field3.GetValue(selectedModel);
				floatParameter.SetValue(value5);
				continue;
			}
			PropertyInfo property3 = typeof(ModelType).GetProperty(floatParameter.ModelParameterFieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (Diagnostics.Verify(property3 != null))
			{
				Fix64 value6 = (Fix64)property3.GetValue(selectedModel);
				floatParameter.SetValue(value6);
			}
		}
		foreach (IngameDevToolStringParameter stringParameter in stringParameters)
		{
			if (string.IsNullOrEmpty(stringParameter.ModelParameterFieldName))
			{
				continue;
			}
			FieldInfo field4 = typeof(ModelType).GetField(stringParameter.ModelParameterFieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field4 != null)
			{
				string value7 = (string)field4.GetValue(selectedModel);
				stringParameter.SetValue(value7);
				continue;
			}
			PropertyInfo property4 = typeof(ModelType).GetProperty(stringParameter.ModelParameterFieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (Diagnostics.Verify(property4 != null))
			{
				string value8 = (string)property4.GetValue(selectedModel);
				stringParameter.SetValue(value8);
			}
		}
	}
}
