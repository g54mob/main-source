using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCatalog : ScriptableCatalog<UpgradeNodeData, UpgradeNode>
{
	public UpgradeCatalog(string name)
		: base(name)
	{
	}

	public override void Validate()
	{
		base.Validate();
		List<string> list = new List<string>();
		foreach (UpgradeNodeData item in base.Collection)
		{
			if (item.prerequisite != UpgradeNode.None && !TryGet(item.prerequisite, out var _))
			{
				list.Add($"Upgrade missing dependency: {item.ID} -> {item.prerequisite}");
			}
			if (item.research != ResearchNode.None && !CatalogProvider.Research.TryGet(item.research, out var _))
			{
				list.Add($"Upgrade missing research: {item.ID} -> {item.research}");
			}
		}
		if (list.Count != 0)
		{
			string text = "There are upgrades with values that are not available in the catalog.\n" + string.Join('\n', list);
			if (Application.isPlaying)
			{
				throw new ArgumentNullException(text);
			}
			Debug.LogError(text);
		}
	}
}
