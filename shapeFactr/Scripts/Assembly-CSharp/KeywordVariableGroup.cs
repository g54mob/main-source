using System;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.Localization.Tables;

[Serializable]
[DisplayName("Keyword", null)]
public class KeywordVariableGroup : IVariableGroup, IVariable
{
	[SerializeField]
	private MstKeyword mstKeyword;

	private static StringTable _table;

	public static void ResetTable()
	{
	}

	public object GetSourceValue(ISelectorInfo _)
	{
		return null;
	}

	public bool TryGetValue(string key, out IVariable value)
	{
		value = null;
		return false;
	}

	private string GetLocalizedString(LocalizeTextMasterStringKey key, bool isErrorDefaultValue = true)
	{
		return null;
	}
}
