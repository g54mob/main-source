using System;
using System.Collections.Generic;
using Factory;
using Factory.Pools;
using FixMath;
using Server;
using UnityEngine;

public abstract class BaseInGameDevToolCommand<CommandType> : Command, IDeserializedHandler, IReusable where CommandType : BaseInGameDevToolCommand<CommandType>
{
	public string commandSerializationName;

	public Vector2 cursorPosition;

	public Vector2Int cursorTilePosition;

	public DeviceInputType deviceInputType;

	[Serialize(false, null)]
	public Action<CommandType, ISimulation> commandToExecute;

	[Serialize(true, null)]
	protected Dictionary<string, bool> boolParameters = new Dictionary<string, bool>();

	[Serialize(true, null)]
	protected Dictionary<string, int> intParameters = new Dictionary<string, int>();

	[Serialize(true, null)]
	protected Dictionary<string, string> enumParameters = new Dictionary<string, string>();

	[Serialize(true, null)]
	protected Dictionary<string, Fix64> floatParameters = new Dictionary<string, Fix64>();

	[Serialize(true, null)]
	protected Dictionary<string, string> stringParameters = new Dictionary<string, string>();

	[Serialize(true, null)]
	protected Dictionary<string, string> parameterNameToFieldName = new Dictionary<string, string>();

	[Dependency]
	private IInGameDevToolsRegistry _devToolsRegistry;

	public override void Execute(ISimulation simulation)
	{
		if (commandToExecute != null || Diagnostics.Verify(LoadCommand(), "Failed to lazily load command {0}.", commandSerializationName))
		{
			commandToExecute((CommandType)this, simulation);
		}
	}

	public override void Reset()
	{
		base.Reset();
		commandSerializationName = "";
		cursorPosition = Vector2.zero;
		cursorTilePosition = Vector2Int.zero;
		deviceInputType = DeviceInputType.Touch;
		commandToExecute = null;
		boolParameters.Clear();
		intParameters.Clear();
		enumParameters.Clear();
		floatParameters.Clear();
		stringParameters.Clear();
		parameterNameToFieldName.Clear();
	}

	public virtual bool TryGetBoolParameter(string parameterName, out bool result)
	{
		return boolParameters.TryGetValue(parameterName, out result);
	}

	public virtual bool TryGetIntParameter(string parameterName, out int result)
	{
		return intParameters.TryGetValue(parameterName, out result);
	}

	public virtual bool TryGetEnumParameter<EnumType>(string parameterName, out EnumType result) where EnumType : struct
	{
		if (enumParameters.TryGetValue(parameterName, out var value))
		{
			return Enum.TryParse<EnumType>(value, out result);
		}
		result = default(EnumType);
		return false;
	}

	public virtual bool TryGetFloatParameter(string parameterName, out Fix64 result)
	{
		return floatParameters.TryGetValue(parameterName, out result);
	}

	public virtual bool GetStringParameter(string parameterName, out string result)
	{
		return stringParameters.TryGetValue(parameterName, out result);
	}

	public virtual void InitializeFromDevTool(IInGameDevTool devTool, bool useDefaultParameterValues)
	{
		boolParameters.Clear();
		foreach (IngameDevToolBoolParameter item in devTool.BoolParameters())
		{
			boolParameters.Add(item.ParameterName, useDefaultParameterValues ? item.DefaultValue : item.ParameterValue);
			if (!string.IsNullOrEmpty(item.ModelParameterFieldName) && item.ShouldSetValueOnField)
			{
				parameterNameToFieldName.Add(item.ParameterName, item.ModelParameterFieldName);
			}
		}
		intParameters.Clear();
		foreach (IngameDevToolIntParameter item2 in devTool.IntParameters())
		{
			intParameters.Add(item2.ParameterName, useDefaultParameterValues ? item2.DefaultValue : item2.ParameterValue);
			if (!string.IsNullOrEmpty(item2.ModelParameterFieldName) && item2.ShouldSetValueOnField)
			{
				parameterNameToFieldName.Add(item2.ParameterName, item2.ModelParameterFieldName);
			}
		}
		enumParameters.Clear();
		foreach (IInGameDevToolEnumParameter item3 in devTool.EnumParameters())
		{
			enumParameters.Add(item3.ParameterName, useDefaultParameterValues ? item3.ParameterSerializationDefaultValue : item3.ParameterSerializationValue);
			if (!string.IsNullOrEmpty(item3.ModelParameterFieldName) && item3.ShouldSetValueOnField)
			{
				parameterNameToFieldName.Add(item3.ParameterName, item3.ModelParameterFieldName);
			}
		}
		floatParameters.Clear();
		foreach (IngameDevToolFloatParameter item4 in devTool.FloatParameters())
		{
			floatParameters.Add(item4.ParameterName, useDefaultParameterValues ? item4.DefaultValue : item4.ParameterValue);
			if (!string.IsNullOrEmpty(item4.ModelParameterFieldName) && item4.ShouldSetValueOnField)
			{
				parameterNameToFieldName.Add(item4.ParameterName, item4.ModelParameterFieldName);
			}
		}
		stringParameters.Clear();
		foreach (IngameDevToolStringParameter item5 in devTool.StringParameters())
		{
			string value = string.Copy(useDefaultParameterValues ? item5.DefaultValue : item5.ParameterValue);
			stringParameters.Add(item5.ParameterName, value);
			if (!string.IsNullOrEmpty(item5.ModelParameterFieldName) && item5.ShouldSetValueOnField)
			{
				parameterNameToFieldName.Add(item5.ParameterName, item5.ModelParameterFieldName);
			}
		}
	}

	public virtual void SetEnumParameter<EnumType>(string parameterName, EnumType enumValue) where EnumType : struct
	{
		enumParameters.Add(parameterName, enumValue.ToString());
	}

	public void OnDeserialized(IScope context)
	{
		LoadCommand();
	}

	private bool LoadCommand()
	{
		IInGameDevTool devToolByCommandSerializationName = _devToolsRegistry.GetDevToolByCommandSerializationName(commandSerializationName);
		if (devToolByCommandSerializationName != null)
		{
			commandToExecute = devToolByCommandSerializationName.GetActionWithCommandType<CommandType>();
			return commandToExecute != null;
		}
		return commandToExecute != null;
	}
}
