using System;
using System.Collections.Generic;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class ScriptSettingsDynamicContainer : MonoBehaviour
{
	public delegate void RE();

	public Transform container;

	private List<MonoBehaviour> inspectors;

	[NonSerialized]
	public OrderedDictionary2<string, RplCore.Data> rootInputVars;

	private IEnumerable<KeyValuePair<string, RplCore.Data>> data;

	private HashSet<string> hiddenInputVars;

	private RE reshow;

	public void Reshow()
	{
	}

	public void Show(IEnumerable<KeyValuePair<string, RplCore.Data>> data, HashSet<string> hiddenInputVars, OrderedDictionary2<string, RplCore.Data> rootInputVars, RE reshow)
	{
	}

	public List<MonoBehaviour> GetInspectors()
	{
		return null;
	}

	private void DestroyChildren(Transform transform)
	{
	}
}
