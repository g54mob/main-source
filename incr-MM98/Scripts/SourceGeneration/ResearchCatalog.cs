using System;
using System.Collections.Generic;
using UnityEngine;

public class ResearchCatalog : ScriptableCatalog<ResearchNodeData, ResearchNode>
{
	public ResearchCatalog(string name)
		: base(name)
	{
	}

	public override void Validate()
	{
		base.Validate();
		List<string> list = new List<string>();
		foreach (ResearchNodeData item in base.Collection)
		{
			if (item.operation != Operation.None && !CatalogProvider.Operations.TryGet(item.operation, out var _))
			{
				list.Add($"Research missing dependency: {item.ID} -> {item.operation}");
			}
		}
		if (list.Count != 0)
		{
			string text = "There are research with values that are not available in the catalog.\n" + string.Join('\n', list);
			if (Application.isPlaying)
			{
				throw new ArgumentNullException(text);
			}
			Debug.LogError(text);
		}
	}
}
