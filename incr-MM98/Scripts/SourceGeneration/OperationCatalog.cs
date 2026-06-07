using System;
using System.Collections.Generic;
using UnityEngine;

public class OperationCatalog : ScriptableCatalog<OperationData, Operation>
{
	public OperationCatalog(string name)
		: base(name)
	{
	}

	public override void Validate()
	{
		base.Validate();
		List<string> list = new List<string>();
		foreach (OperationData item in base.Collection)
		{
			foreach (UpgradeModifier modifier in item.modifiers)
			{
				if (modifier.upgrade != UpgradeNode.None && !CatalogProvider.Upgrades.TryGet(modifier.upgrade, out var _))
				{
					list.Add($"Operation missing dependency: {item.ID} -> {modifier.upgrade}");
				}
			}
		}
		if (list.Count != 0)
		{
			string text = "There are operations with values that are not available in the catalog.\n" + string.Join('\n', list);
			if (Application.isPlaying)
			{
				throw new ArgumentNullException(text);
			}
			Debug.LogError(text);
		}
	}
}
