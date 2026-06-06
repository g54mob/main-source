using System;
using System.Collections.Generic;
using UnityEngine;

public class DatacenterCatalog : ScriptableCatalog<DatacenterData, Datacenter>
{
	public DatacenterCatalog(string name)
		: base(name)
	{
	}

	public override void Validate()
	{
		base.Validate();
		List<string> list = new List<string>();
		foreach (DatacenterData item in base.Collection)
		{
			if (item.prerequisite != Datacenter.None && !TryGet(item.prerequisite, out var _))
			{
				list.Add($"Datacenter missing dependency: {item.ID} -> {item.prerequisite}");
			}
		}
		if (list.Count != 0)
		{
			string text = "There are datacenters with values that are not available in the catalog.\n" + string.Join('\n', list);
			if (Application.isPlaying)
			{
				throw new ArgumentNullException(text);
			}
			Debug.LogError(text);
		}
	}
}
