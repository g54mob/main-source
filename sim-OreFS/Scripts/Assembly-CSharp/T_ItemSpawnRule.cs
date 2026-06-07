using System;
using UnityEngine;

public class T_ItemSpawnRule : MonoBehaviour
{
	[Serializable]
	public class WeightedSO
	{
		public T_ItemSO so;

		[Min(0f)]
		public float percent;
	}

	public int spawnRuleID;

	[Header("Box Area")]
	[Tooltip("Square base edge length in world space")]
	[Min(0.01f)]
	[Range(0f, 15f)]
	public float size = 10f;

	[Tooltip("Box height in world space")]
	[Min(0.01f)]
	public float height = 2f;

	[Tooltip("Vertical offset of the box center in local space")]
	public float yOffset;

	[Header("Gizmos")]
	public bool drawGizmos = true;

	[Range(0f, 1f)]
	public float fillAlpha = 0.15f;

	public Color gizmoColor = new Color(0f, 1f, 1f, 1f);

	public Vector3 GetRandomWorldPositionInDisc()
	{
		float num = size * 0.5f;
		float num2 = height * 0.5f;
		float x = UnityEngine.Random.Range(0f - num, num);
		float z = UnityEngine.Random.Range(0f - num, num);
		float num3 = UnityEngine.Random.Range(0f - num2, num2);
		Vector3 position = new Vector3(x, num3 + yOffset, z);
		return base.transform.TransformPoint(position);
	}

	public float GetFootprintAreaXZ()
	{
		return size * size;
	}

	public float GetVolume()
	{
		return size * size * height;
	}
}
