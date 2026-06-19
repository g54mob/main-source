using System.Collections.Generic;
using Aggro.Core.Networking;
using DevCmdLine.UI;
using UnityEngine;

public class DevCmdOptionModifier : DevCmdOptionUIBase
{
	public override bool TryGetInitial(out string optionStr, out bool isEnd)
	{
		optionStr = "Modifier";
		isEnd = false;
		if (GameUtil.isReady)
		{
			return NetworkAggroManagerBase<ModifierManager>.ManagerExists();
		}
		return false;
	}

	public override List<DevCmdSubOption> Selected(List<object> contexts)
	{
		List<DevCmdSubOption> list = new List<DevCmdSubOption>();
		GameObject[] modifierPrefabs = NetworkAggroManagerBase<ModifierManager>.instance.GetModifierPrefabs();
		foreach (GameObject gameObject in modifierPrefabs)
		{
			list.Add(new DevCmdSubOption
			{
				text = gameObject.GetComponent<ModifierBase>().modifierName,
				context = gameObject,
				isEnd = true
			});
		}
		return list;
	}

	public override string ConstructCmd(List<object> contexts)
	{
		return "modifier " + ((GameObject)contexts[0]).name;
	}
}
