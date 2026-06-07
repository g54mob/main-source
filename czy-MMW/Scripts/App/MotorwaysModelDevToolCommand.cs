using System;
using System.Collections.Generic;
using System.Reflection;
using Factory;
using FixMath;
using Motorways.Models;
using Server;

public class MotorwaysModelDevToolCommand : BaseInGameDevToolCommand<MotorwaysModelDevToolCommand>
{
	[Dependency]
	protected CityPlanModel _cityPlanModel;

	[Dependency]
	protected ClockModel _clock;

	[Dependency]
	protected ISimulation _simulation;

	[Dependency]
	public IScope Scope { get; protected set; }

	public override void Execute(ISimulation simulation)
	{
		IInGameDevToolsRegistry inGameDevToolsRegistry = Scope.Get<IInGameDevToolsRegistry>();
		if (inGameDevToolsRegistry == null)
		{
			return;
		}
		IInGameModelDevTool modelDevToolByCommandSerializationName = inGameDevToolsRegistry.GetModelDevToolByCommandSerializationName(commandSerializationName);
		if (Diagnostics.Verify(modelDevToolByCommandSerializationName != null))
		{
			Action<MotorwaysModelDevToolCommand, ISimulation> actionWithCommandType = modelDevToolByCommandSerializationName.GetActionWithCommandType<MotorwaysModelDevToolCommand>();
			if (Diagnostics.Verify(actionWithCommandType != null))
			{
				actionWithCommandType(this, simulation);
			}
		}
	}

	public virtual void SyncValuesToModel<ModelType>(ModelType selectedModel)
	{
		if (selectedModel == null)
		{
			return;
		}
		foreach (KeyValuePair<string, bool> boolParameter in boolParameters)
		{
			if (!parameterNameToFieldName.ContainsKey(boolParameter.Key))
			{
				continue;
			}
			FieldInfo field = typeof(ModelType).GetField(parameterNameToFieldName[boolParameter.Key], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field != null)
			{
				field.SetValue(selectedModel, boolParameter.Value);
				continue;
			}
			PropertyInfo property = typeof(ModelType).GetProperty(parameterNameToFieldName[boolParameter.Key], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (Diagnostics.Verify(property != null))
			{
				property.SetValue(selectedModel, boolParameter.Value);
			}
		}
		foreach (KeyValuePair<string, int> intParameter in intParameters)
		{
			if (!parameterNameToFieldName.ContainsKey(intParameter.Key))
			{
				continue;
			}
			FieldInfo field2 = typeof(ModelType).GetField(parameterNameToFieldName[intParameter.Key], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field2 != null)
			{
				field2.SetValue(selectedModel, intParameter.Value);
				continue;
			}
			PropertyInfo property2 = typeof(ModelType).GetProperty(parameterNameToFieldName[intParameter.Key], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (Diagnostics.Verify(property2 != null))
			{
				property2.SetValue(selectedModel, intParameter.Value);
			}
		}
		foreach (KeyValuePair<string, string> enumParameter in enumParameters)
		{
			if (!parameterNameToFieldName.ContainsKey(enumParameter.Key))
			{
				continue;
			}
			FieldInfo field3 = typeof(ModelType).GetField(parameterNameToFieldName[enumParameter.Key], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field3 != null)
			{
				object value = null;
				Type fieldType = field3.FieldType;
				try
				{
					value = Enum.Parse(fieldType, enumParameter.Value);
				}
				catch (Exception)
				{
					Diagnostics.FailAssert("Failed to parse enum value {0}.{1}", enumParameter.Key, enumParameter.Value);
				}
				field3.SetValue(selectedModel, value);
				continue;
			}
			PropertyInfo property3 = typeof(ModelType).GetProperty(parameterNameToFieldName[enumParameter.Key], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (!Diagnostics.Verify(property3 != null))
			{
				continue;
			}
			object value2 = null;
			Type propertyType = property3.PropertyType;
			if (Diagnostics.Verify(propertyType != null))
			{
				try
				{
					value2 = Enum.Parse(propertyType, enumParameter.Value);
				}
				catch (Exception)
				{
					Diagnostics.FailAssert("Failed to parse enum value {0}.{1}", enumParameter.Key, enumParameter.Value);
				}
			}
			property3.SetValue(selectedModel, value2);
		}
		foreach (KeyValuePair<string, Fix64> floatParameter in floatParameters)
		{
			if (!parameterNameToFieldName.ContainsKey(floatParameter.Key))
			{
				continue;
			}
			FieldInfo field4 = typeof(ModelType).GetField(parameterNameToFieldName[floatParameter.Key], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field4 != null)
			{
				field4.SetValue(selectedModel, floatParameter.Value);
				continue;
			}
			PropertyInfo property4 = typeof(ModelType).GetProperty(parameterNameToFieldName[floatParameter.Key], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (Diagnostics.Verify(property4 != null))
			{
				property4.SetValue(selectedModel, floatParameter.Value);
			}
		}
		foreach (KeyValuePair<string, string> stringParameter in stringParameters)
		{
			if (!parameterNameToFieldName.ContainsKey(stringParameter.Key))
			{
				continue;
			}
			FieldInfo field5 = typeof(ModelType).GetField(parameterNameToFieldName[stringParameter.Key], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field5 != null)
			{
				field5.SetValue(selectedModel, stringParameter.Value);
				continue;
			}
			PropertyInfo property5 = typeof(ModelType).GetProperty(parameterNameToFieldName[stringParameter.Key], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (Diagnostics.Verify(property5 != null))
			{
				property5.SetValue(selectedModel, stringParameter.Value);
			}
		}
	}
}
