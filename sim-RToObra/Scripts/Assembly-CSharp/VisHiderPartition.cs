using System.Collections.Generic;
using UnityEngine;

public class VisHiderPartition : MonoBehaviour
{
	public int bit;

	public Bounds bounds;

	[Readonly]
	public List<GameObject> targetRoots = new List<GameObject>();

	[Readonly]
	public string importedRootPath;

	[Readonly]
	public string importedIgnoreComponentTypeName;

	[MomentId]
	public string afterMomentId;

	private bool requiredMomentHasBeenVisited;

	public bool containsPlayer
	{
		get
		{
			return requiredMomentHasBeenVisited && base.isActiveAndEnabled;
		}
	}

	public void CheckMomentVisited()
	{
		requiredMomentHasBeenVisited = !afterMomentId.HasValue() || SaveData.it.momentRo[afterMomentId].visited;
	}

	public void DebugForceOn()
	{
		requiredMomentHasBeenVisited = true;
	}
}
