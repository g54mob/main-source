using Aggro.Core;
using Unity.Mathematics;
using UnityEngine;

[ExecuteInEditMode]
public class WarehouseInclusionZone : EntityBehaviourBase
{
	private Transform _t;

	protected override void OnEntityCreated()
	{
		_t = base.transform;
	}

	public Bounds GetBounds()
	{
		Bounds result = default(Bounds);
		result.Encapsulate(_t.TransformPoint(new Vector3(0.5f, 0f, 0.5f)));
		result.Encapsulate(_t.TransformPoint(new Vector3(0.5f, 0f, -0.5f)));
		result.Encapsulate(_t.TransformPoint(new Vector3(-0.5f, 0f, 0.5f)));
		result.Encapsulate(_t.TransformPoint(new Vector3(-0.5f, 0f, -0.5f)));
		return result;
	}

	public bool IsInBounds(Vector3 worldPos)
	{
		Vector3 vector = _t.InverseTransformPoint(worldPos);
		if (math.abs(vector.x) <= 0.5f)
		{
			return math.abs(vector.z) <= 0.5f;
		}
		return false;
	}

	private void OnDrawGizmos()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = new Color(0f, 1f, 0f, 0.35f);
		Gizmos.DrawCube(Vector3.zero, new Vector3(1f, 0.5f, 1f));
	}
}
