using System;
using System.Collections.Generic;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class ScriptSettingsEditor : MonoBehaviour
{
	[NonSerialized]
	public CModScriptRow row;

	public ScriptSettingsDynamicContainer scriptSettingsDynamicContainer;

	private OrderedDictionary2<string, RplCore.Data> inputVars;

	public void Reshow()
	{
	}

	public void Show(CModScriptRow row)
	{
	}

	public void Refresh()
	{
	}

	public void OnApply()
	{
	}

	private HashSet<string> CompileAndMergeSettings(CMod.CModScript cms, out OrderedDictionary2<string, RplCore.Data> inputVars)
	{
		inputVars = null;
		return null;
	}

	public static void MergeSettings(OrderedDictionary2<string, RplCore.Data> source, OrderedDictionary2<string, RplCore.Data> dest)
	{
	}
}
