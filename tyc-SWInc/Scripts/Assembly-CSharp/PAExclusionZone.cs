using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PAExclusionZone : MonoBehaviour
{
	public static List<PAExclusionZone> exclusionZones;

	public LayerMask affectsLayers = -1;

	public Vector3 edgeThreshold = new Vector3(0.9f, 0.9f, 0.9f);

	public bool important;

	private Bounds bounds
	{
		get
		{
			Vector3 rhs = Vector3.Max(base.transform.TransformPoint(Vector3.right * 0.5f), base.transform.TransformPoint(Vector3.left * 0.5f));
			rhs = Vector3.Max(base.transform.TransformPoint(Vector3.up * 0.5f), rhs);
			rhs = Vector3.Max(base.transform.TransformPoint(Vector3.down * 0.5f), rhs);
			rhs = Vector3.Max(base.transform.TransformPoint(Vector3.forward * 0.5f), rhs);
			rhs = Vector3.Max(base.transform.TransformPoint(Vector3.back * 0.5f), rhs);
			return new Bounds(base.transform.position, (rhs - base.transform.position) * 2f);
		}
	}

	public static void RegisterZone(PAExclusionZone zone)
	{
		if (exclusionZones == null)
		{
			exclusionZones = new List<PAExclusionZone>();
		}
		if (!exclusionZones.Contains(zone))
		{
			exclusionZones.Add(zone);
		}
	}

	public static void UnregisterZone(PAExclusionZone zone)
	{
		if (exclusionZones != null && exclusionZones.Contains(zone))
		{
			exclusionZones.Remove(zone);
		}
		exclusionZones.RemoveAll((PAExclusionZone obj) => obj == null);
	}

	private void OnEnable()
	{
		RegisterZone(this);
	}

	private void OnDisable()
	{
		UnregisterZone(this);
	}

	private void OnDrawGizmos()
	{
	}

	private static Vector3 ClosestPointOnBounds(Bounds bounds, Vector3 point)
	{
		return bounds.ClosestPoint(point);
	}

	public static bool GetExclusionZones(ref PAExclusionZone[] zones, Vector3 position, Bounds checkBounds, int layer)
	{
		bool result = false;
		for (int i = 0; i < zones.Length; i++)
		{
			zones[i] = null;
		}
		if (exclusionZones == null)
		{
			return result;
		}
		for (int j = 0; j < exclusionZones.Count; j++)
		{
			PAExclusionZone pAExclusionZone = exclusionZones[j];
			if (!checkBounds.Intersects(pAExclusionZone.bounds) || ((1 << layer) & (int)pAExclusionZone.affectsLayers) == 0)
			{
				continue;
			}
			result = true;
			for (int k = 0; k < zones.Length; k++)
			{
				if (zones[k] == null)
				{
					zones[k] = pAExclusionZone;
					break;
				}
				float num = Vector3.SqrMagnitude(ClosestPointOnBounds(pAExclusionZone.bounds, position) - position);
				float num2 = Vector3.SqrMagnitude(ClosestPointOnBounds(zones[k].bounds, position) - position);
				if ((pAExclusionZone.important && !zones[k].important) || (pAExclusionZone.important == zones[k].important && num < num2))
				{
					for (int num3 = zones.Length - 1; num3 > k; num3--)
					{
						zones[num3] = zones[num3 - 1];
					}
					zones[k] = pAExclusionZone;
					break;
				}
			}
		}
		return result;
	}

	public static PAExclusionZone Create(string name)
	{
		return new GameObject(name).AddComponent<PAExclusionZone>();
	}
}
