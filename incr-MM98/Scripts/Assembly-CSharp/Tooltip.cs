using System;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

[Serializable]
public struct Tooltip
{
	[Tooltip("Tooltip Title")]
	public LocalizedString title;

	[Tooltip("Tooltip Description")]
	public LocalizedString description;

	public void SetVariableTitle(string key, IVariable variable)
	{
		title[key] = variable;
	}

	public void SetVariablesTitle(params (string key, IVariable variable)[] variables)
	{
		for (int i = 0; i < variables.Length; i++)
		{
			var (key, variable) = variables[i];
			SetVariableTitle(key, variable);
		}
	}

	public void SetVariableDescription(string key, IVariable variable)
	{
		description[key] = variable;
	}

	public void SetVariablesDescription(params (string key, IVariable variable)[] variables)
	{
		for (int i = 0; i < variables.Length; i++)
		{
			var (key, variable) = variables[i];
			SetVariableDescription(key, variable);
		}
	}

	public void SetVariable(string key, IVariable variable)
	{
		SetVariableTitle(key, variable);
		SetVariableDescription(key, variable);
	}

	public void SetVariables(params (string key, IVariable variable)[] variables)
	{
		SetVariablesTitle(variables);
		SetVariablesDescription(variables);
	}
}
