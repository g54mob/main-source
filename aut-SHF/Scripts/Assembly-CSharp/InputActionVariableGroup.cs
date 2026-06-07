using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

[Serializable]
[DisplayName("Input Action", null)]
public class InputActionVariableGroup : IVariableGroup, IVariable
{
	[SerializeField]
	private InputActionAsset m_ActionsAsset;

	public object GetSourceValue(ISelectorInfo _)
	{
		return null;
	}

	public bool TryGetValue(string key, out IVariable value)
	{
		value = null;
		return false;
	}
}
