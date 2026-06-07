using System;
using System.Collections.Generic;
using Server;
using UnityEngine;

public interface IInGameDevTool
{
	bool ResetToNoneAfterUse { get; set; }

	IInGameDevTool SetCommandSerializationName(string newCommandSerializationName);

	string GetCommandSerializationName();

	string GetEditorToolDisplayName();

	string GetEditorToolDisplayNameWithoutHotkeyCode();

	string GetEditorToolIconPath();

	IEnumerable<IngameDevToolBoolParameter> BoolParameters();

	IEnumerable<IngameDevToolIntParameter> IntParameters();

	IEnumerable<IInGameDevToolEnumParameter> EnumParameters();

	IEnumerable<IngameDevToolFloatParameter> FloatParameters();

	IEnumerable<IngameDevToolStringParameter> StringParameters();

	IngameDevToolBoolParameter GetBoolParameter(string parameterName);

	IngameDevToolIntParameter GetIntParameter(string parameterName);

	IngameDevToolEnumParameter<EnumType> GetEnumParameter<EnumType>(string parameterName) where EnumType : struct;

	string GetEnumParameterValueAsString(string parameterName);

	IngameDevToolFloatParameter GetFloatParameter(string parameterName);

	IngameDevToolStringParameter GetStringParameter(string parameterName);

	void PrepareTool();

	void Tick(TimeInterval tickTime, float stepAlpha, out bool activatedThisTick);

	void CleanupTool();

	Action<CommandType, ISimulation> GetActionWithCommandType<CommandType>();

	bool InGameHotkeyActivated();

	bool InGameParameterHotKeyActivated();

	void OnHotkeyActivated(bool useDefaultParameters);

	void OnToolSelected();

	void OnToolDeselected();

	bool HasHotKey();

	KeyCode GetHotKey();

	KeyCode GetModifierHotKey();
}
