using System.Collections.Generic;
using System.Linq;
using DV.TerrainTools;
using UnityEngine;

public class ConnectablePrefabReplacer : MonoBehaviour
{
	[InspectorButton("Replace", true, true)]
	public bool replace;

	public ConnectablePrefab searchFor;

	public ConnectablePrefab replaceWith;

	public bool dryRun = true;

	private void Replace()
	{
		if (searchFor == null)
		{
			Debug.LogError("Prefab to search for was not assigned");
			return;
		}
		if (replaceWith == null)
		{
			Debug.LogError("Prefab to replace with was not assigned");
			return;
		}
		List<Connectable> list = (from c in Object.FindObjectsOfType<Connectable>()
			where c.prefab == searchFor
			select c).ToList();
		Debug.Log($"Found {list.Count} connectables to update");
		if (dryRun)
		{
			Debug.Log("Dry run, nothing was modified.");
			return;
		}
		foreach (Connectable item in list)
		{
			item.prefab = replaceWith;
		}
		Debug.Log("Replaced.");
	}
}
