using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellPruner : MonoBehaviour
{
	public GameObject tracksParent;

	[Range(0f, 16000f)]
	public float pruneDistance = 4000f;

	[HideInInspector]
	public Dictionary<Transform, float> cellDistances;

	[InspectorButton("CalculateDistances", true, true)]
	public bool calculateDistances;

	[InspectorButton("Prune", true, true)]
	public bool prune;

	public void CalculateDistances()
	{
		cellDistances = new Dictionary<Transform, float>();
		Dictionary<Transform, Bounds> dictionary = new Dictionary<Transform, Bounds>();
		foreach (Transform item in base.transform)
		{
			Bounds bounds = item.GetComponent<MeshFilter>().sharedMesh.bounds;
			dictionary[item] = new Bounds(item.position + bounds.center, bounds.size);
		}
		BezierPoint[] componentsInChildren = tracksParent.GetComponentsInChildren<BezierPoint>(includeInactive: true);
		foreach (BezierPoint bezierPoint in componentsInChildren)
		{
			foreach (Transform item2 in base.transform)
			{
				if (!cellDistances.ContainsKey(item2))
				{
					cellDistances[item2] = float.PositiveInfinity;
				}
				Vector3 vector = dictionary[item2].ClosestPoint(bezierPoint.position);
				float sqrMagnitude = (bezierPoint.position - vector).sqrMagnitude;
				if (sqrMagnitude < cellDistances[item2])
				{
					cellDistances[item2] = sqrMagnitude;
				}
			}
		}
		foreach (Transform item3 in cellDistances.Keys.ToList())
		{
			cellDistances[item3] = Mathf.Sqrt(cellDistances[item3]);
		}
	}

	public void Prune()
	{
		if (cellDistances == null)
		{
			return;
		}
		foreach (Transform item in cellDistances.Keys.ToList())
		{
			if (cellDistances[item] > pruneDistance)
			{
				cellDistances.Remove(item);
				Object.DestroyImmediate(item.gameObject);
			}
		}
	}
}
