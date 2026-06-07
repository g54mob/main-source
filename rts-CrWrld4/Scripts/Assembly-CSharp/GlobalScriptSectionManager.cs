using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using mattmc3.dotmore.Collections.Generic;

public class GlobalScriptSectionManager : MonoBehaviour
{
	public Toggle executeWhenPaused;

	public ScriptSettingsDynamicContainer ssdc;

	private OrderedDictionary2<string, RplCore.Data> inputVars;

	public void Reshow()
	{
	}

	public void Refresh()
	{
	}

	public void OnApply()
	{
	}

	public void OnCancel()
	{
	}

	private HashSet<string> CompileAndMergeSettings(CPack.GlobalScript gs, out OrderedDictionary2<string, RplCore.Data> inputVars)
	{
		inputVars = null;
		return null;
	}
}
