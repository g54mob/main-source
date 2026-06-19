using System.Collections.Generic;
using Aggro.Core;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

[ExecuteInEditMode]
public class WarehouseExclusionZone : EntityBehaviourBase
{
	public bool allowRadiusChecking;

	private Transform _t;

	protected override void OnEntityCreated()
	{
		_t = base.transform;
	}

	private void OnDrawGizmos()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
		Gizmos.DrawCube(Vector3.zero, new Vector3(1f, 0.35f, 1f));
	}

	public void RemoveOverlapping(List<Vector3> serverSpawnLocs, float exclusionCheckRadius)
	{
		if (allowRadiusChecking)
		{
			float num = exclusionCheckRadius * exclusionCheckRadius;
			Vector3 position = _t.position;
			Quaternion quaternion2 = Quaternion.Inverse(_t.rotation);
			Vector3 vector = quaternion2 * _t.TransformVector(new Vector3(0.5f, 0f, 0.5f));
			for (int i = 0; i < serverSpawnLocs.Count; i++)
			{
				Vector3 vector2 = serverSpawnLocs[i] - position;
				vector2 = quaternion2 * vector2;
				Vector3 vector3 = new Vector3(math.clamp(vector2.x, 0f - vector.x, vector.x), 0f, math.clamp(vector2.z, 0f - vector.z, vector.z));
				if (math.lengthsq(vector2 - vector3) <= num)
				{
					serverSpawnLocs.RemoveAtSwapBack(i);
					i--;
				}
			}
			return;
		}
		Matrix4x4 worldToLocalMatrix = _t.worldToLocalMatrix;
		for (int j = 0; j < serverSpawnLocs.Count; j++)
		{
			Vector3 vector4 = worldToLocalMatrix * serverSpawnLocs[j].XYZW();
			if (math.abs(vector4.x) <= 0.5f && math.abs(vector4.z) <= 0.5f)
			{
				serverSpawnLocs.RemoveAtSwapBack(j);
				j--;
			}
		}
	}
}
