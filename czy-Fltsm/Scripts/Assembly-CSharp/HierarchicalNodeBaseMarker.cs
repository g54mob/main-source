using System.Collections.Generic;
using System.Linq;
using PajamaLlama.Debugs;
using UnityEngine;

public class HierarchicalNodeBaseMarker : HierarchicalNodeMarker
{
	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void OnDrawGizmosSelected()
	{
	}

	[ContextMenu("Set neighbors")]
	public new void SetNeighbors()
	{
		List<HierarchicalNodeMarker> list = GetComponentsInChildren<HierarchicalNodeMarker>().ToList();
		Debugger.Log($"Found {list.Count} children.");
		for (int i = 0; i < list.Count; i++)
		{
			list[i].SetNeighbors();
		}
	}
}
