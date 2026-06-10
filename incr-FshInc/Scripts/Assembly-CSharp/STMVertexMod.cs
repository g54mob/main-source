using System;
using UnityEngine;

public class STMVertexMod : MonoBehaviour
{
	[Header("Curve")]
	public Vector3 positionOffset;

	public float angleOffset = -1f;

	public Vector3 pivot;

	public float letterRotation = 1f;

	[Header("Circle")]
	public float radius = 2f;

	[Range(0.0001f, 1f)]
	public float amountOfCircle = 1f;

	public bool positionsFillCircle = true;

	public void AlignToGrid(Vector3[] verts, Vector3[] middles, Vector3[] positions)
	{
		int num = 0;
		Vector3 vector = RoundDifference(positions[0]);
		int i = 0;
		for (int num2 = positions.Length; i < num2; i++)
		{
			if (positions[i].y != positions[num].y)
			{
				num = i;
				vector = RoundDifference(positions[num]);
			}
			verts[4 * i] += vector;
			verts[4 * i + 1] += vector;
			verts[4 * i + 2] += vector;
			verts[4 * i + 3] += vector;
		}
	}

	private Vector3 RoundDifference(Vector3 original)
	{
		Vector3 vector = new Vector3(Mathf.Round(original.x), Mathf.Round(original.y), Mathf.Round(original.z));
		return original - vector;
	}

	public void ApplyCurveToVertices(Vector3[] verts, Vector3[] middles, Vector3[] positions)
	{
		int i = 0;
		for (int num = verts.Length / 4; i < num; i++)
		{
			verts[4 * i] -= new Vector3(positionOffset.x, verts[4 * i].x * positionOffset.y, positionOffset.z);
			verts[4 * i + 1] -= new Vector3(positionOffset.x, verts[4 * i].x * positionOffset.y, positionOffset.z);
			verts[4 * i + 2] -= new Vector3(positionOffset.x, verts[4 * i].x * positionOffset.y, positionOffset.z);
			verts[4 * i + 3] -= new Vector3(positionOffset.x, verts[4 * i].x * positionOffset.y, positionOffset.z);
			Vector3 myPivot = new Vector3(middles[i].x, positions[i].y, middles[i].z);
			Vector3 angles = new Vector3(0f, 0f, angleOffset * middles[i].x);
			if (float.IsNaN(angles.z))
			{
				angles = Vector3.zero;
			}
			verts[4 * i] = RotatePointAroundPivot(verts[4 * i], myPivot, angles);
			verts[4 * i + 1] = RotatePointAroundPivot(verts[4 * i + 1], myPivot, angles);
			verts[4 * i + 2] = RotatePointAroundPivot(verts[4 * i + 2], myPivot, angles);
			verts[4 * i + 3] = RotatePointAroundPivot(verts[4 * i + 3], myPivot, angles);
			angles.z += positions[i].y * letterRotation;
			verts[4 * i] = RotatePointAroundPivot(verts[4 * i], pivot, angles);
			verts[4 * i + 1] = RotatePointAroundPivot(verts[4 * i + 1], pivot, angles);
			verts[4 * i + 2] = RotatePointAroundPivot(verts[4 * i + 2], pivot, angles);
			verts[4 * i + 3] = RotatePointAroundPivot(verts[4 * i + 3], pivot, angles);
		}
	}

	private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 myPivot, Vector3 angles)
	{
		Vector3 vector = point - myPivot;
		vector = Quaternion.Euler(angles) * vector;
		point = vector + myPivot;
		return point;
	}

	public void WrapAroundCircle(Vector3[] verts, Vector3[] middles, Vector3[] positions)
	{
		float num = 1E-05f;
		for (int i = 0; i < verts.Length / 4; i++)
		{
			num = Mathf.Max(num, verts[4 * i + 2].x);
		}
		float num2 = radius * 2f * MathF.PI;
		float num3 = amountOfCircle;
		if (!positionsFillCircle)
		{
			num3 = num / num2;
			if (num3 > 1f)
			{
				num3 = 1f;
			}
		}
		int j = 0;
		for (int num4 = verts.Length / 4; j < num4; j++)
		{
			float f = positions[j].x / num * MathF.PI * num3;
			float z = positions[j].x / num * num3 * -180f - 90f;
			Vector3 zero = Vector3.zero;
			Vector3 vector = verts[4 * j + 1] - verts[4 * j];
			Vector3 vector2 = verts[4 * j + 2] - verts[4 * j];
			Vector3 vector3 = verts[4 * j + 3] - verts[4 * j];
			verts[4 * j] = new Vector3(Mathf.Cos(f) * radius + zero.x, (0f - Mathf.Sin(f)) * radius + verts[4 * j].y, verts[4 * j].z);
			verts[4 * j + 1] = new Vector3(Mathf.Cos(f) * radius + vector.x, (0f - Mathf.Sin(f)) * radius + verts[4 * j + 1].y, verts[4 * j + 1].z);
			verts[4 * j + 2] = new Vector3(Mathf.Cos(f) * radius + vector2.x, (0f - Mathf.Sin(f)) * radius + verts[4 * j + 2].y, verts[4 * j + 2].z);
			verts[4 * j + 3] = new Vector3(Mathf.Cos(f) * radius + vector3.x, (0f - Mathf.Sin(f)) * radius + verts[4 * j + 3].y, verts[4 * j + 3].z);
			Vector3 myPivot = new Vector3(Mathf.Cos(f) * radius + middles[j].x - positions[j].x, (0f - Mathf.Sin(f)) * radius + positions[j].y, positions[j].z);
			Vector3 angles = new Vector3(0f, 0f, z);
			if (float.IsNaN(angles.z))
			{
				angles = Vector3.zero;
			}
			verts[4 * j] = RotatePointAroundPivot(verts[4 * j], myPivot, angles);
			verts[4 * j + 1] = RotatePointAroundPivot(verts[4 * j + 1], myPivot, angles);
			verts[4 * j + 2] = RotatePointAroundPivot(verts[4 * j + 2], myPivot, angles);
			verts[4 * j + 3] = RotatePointAroundPivot(verts[4 * j + 3], myPivot, angles);
		}
	}
}
