using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AssignLayersToBridges : MonoBehaviour
{
	[Header("This script shouldn't be used anymore!")]
	[Layer]
	public int layerToAssign;

	[InspectorButton("Assign", true, true)]
	public bool assign;

	public void Assign()
	{
		List<Transform> list = (from t in Object.FindObjectsOfType<Transform>()
			where t.name == "viaduct_bridge" && t.childCount != 0
			select t).ToList();
		if (list.Count == 0)
		{
			Debug.LogWarning("Found 0 bridges!");
			return;
		}
		foreach (Transform item in list)
		{
			item.gameObject.SetLayersRecursive(layerToAssign);
		}
		Debug.Log($"Assigned '{LayerMask.LayerToName(layerToAssign)}' layer to {list.Count} bridges");
	}
}
