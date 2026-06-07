using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class NavMeshPathDebugger : MonoBehaviour
{
	[SerializeField]
	private float _markerRadius = 0.5f;

	private void OnDrawGizmos()
	{
		using ListPool<HierarchicalNodeMarker>.List list = ListPool<HierarchicalNodeMarker>.Get(GetComponentsInChildren<HierarchicalNodeMarker>());
		using ListPool<HierarchicalNodeMarker>.List list2 = ListPool<HierarchicalNodeMarker>.Get();
		foreach (HierarchicalNodeMarker item in list)
		{
			if (item.DoDebug)
			{
				list2.Add(item);
			}
			else
			{
				DrawNeighbors(item, list, Color.black);
			}
		}
		foreach (HierarchicalNodeMarker item2 in list2)
		{
			DrawNeighbors(item2, list, Color.green);
		}
	}

	private void DrawNeighbors(HierarchicalNodeMarker marker, List<HierarchicalNodeMarker> markers, Color color)
	{
		Vector3 position = marker.transform.position;
		float range = marker.Range;
		Gizmos.color = Color.red;
		foreach (HierarchicalNodeMarker marker2 in markers)
		{
			if (!(marker == marker2))
			{
				Vector3 position2 = marker2.transform.position;
				if (position.IsInRange(position2, range))
				{
					Gizmos.color = color;
					Gizmos.DrawLine(position, position2);
				}
			}
		}
		Gizmos.DrawWireSphere(position, _markerRadius);
	}

	private void AddMarkerNeighborsToPath(HierarchicalNodeMarker marker, List<HierarchicalNodeMarker> markers, List<HierarchicalNodeMarker> path)
	{
		using ListPool<HierarchicalNodeMarker>.List list = ListPool<HierarchicalNodeMarker>.Get();
		Vector3 position = marker.transform.position;
		float range = marker.Range;
		for (int i = 0; i < markers.Count; i++)
		{
			HierarchicalNodeMarker hierarchicalNodeMarker = markers[i];
			if (position.IsInRange(hierarchicalNodeMarker.transform.position, range))
			{
				markers.RemoveAt(i--);
				path.Add(hierarchicalNodeMarker);
				list.Add(hierarchicalNodeMarker);
			}
		}
		foreach (HierarchicalNodeMarker item in list)
		{
			AddMarkerNeighborsToPath(item, markers, path);
			Gizmos.DrawLine(marker.transform.position, item.transform.position);
		}
	}
}
