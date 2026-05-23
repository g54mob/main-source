using System;
using System.Collections;
using Deform;
using Unity.Mathematics;
using UnityEngine;

public class CustomCrafitng : MonoBehaviour
{
	public enum DeformAxis
	{
		Y = 0,
		Z = 1
	}

	[Serializable]
	public class RingData
	{
		[Range(0.1f, 5f)]
		public float scale = 1f;

		[Range(-5f, 5f)]
		public float offset;
	}

	[Header("Deformation Settings")]
	public DeformAxis targetAxis = DeformAxis.Z;

	public LatticeDeformer lattice;

	public Transform headPos;

	public Transform camPos;

	public Vector3 headOffset;

	private float massSensitivity = 0.7f;

	[SerializeField]
	[HideInInspector]
	private float3[] originalPoints;

	[Header("Rocket Rings")]
	public RingData[] rings;

	public RocketAttachment part;

	private float originalVolume;

	private float originalMass;

	private float margin = 0.01f;

	private bool isInitalized;

	private MeshFilter targetMeshFilter;

	private int _closestVertexIndex = -1;

	private Vector3 _offset;

	public static event Action<RocketAttachment> OnPartsCustomed;

	private void OnEnable()
	{
		InitializeData();
	}

	private IEnumerator Start()
	{
		yield return null;
		CalculateInitialOffset();
		ApplyAllRings();
		UpdateHeadPosition();
	}

	private void OnValidate()
	{
		if (!(lattice != null))
		{
			return;
		}
		if (originalPoints == null || originalPoints.Length == 0)
		{
			InitializeData();
		}
		int num = ((targetAxis == DeformAxis.Z) ? lattice.Resolution.z : lattice.Resolution.y);
		if (originalPoints != null && rings != null && rings.Length == num)
		{
			if (headOffset == Vector3.zero)
			{
				CalculateInitialOffset();
			}
			ApplyAllRings();
			UpdateHeadPosition();
		}
		else if (rings != null && rings.Length != num)
		{
			InitializeData();
		}
	}

	public void InitializeData()
	{
		if (isInitalized)
		{
			return;
		}
		if (lattice != null && lattice.ControlPoints != null && lattice.ControlPoints.Length != 0)
		{
			originalPoints = new float3[lattice.ControlPoints.Length];
			Array.Copy(lattice.ControlPoints, originalPoints, lattice.ControlPoints.Length);
			int num = ((targetAxis == DeformAxis.Z) ? lattice.Resolution.z : lattice.Resolution.y);
			if (rings == null || rings.Length != num)
			{
				rings = new RingData[num];
				for (int i = 0; i < rings.Length; i++)
				{
					rings[i] = new RingData();
				}
			}
		}
		if (part != null)
		{
			originalMass = part.mass;
			targetMeshFilter = GetComponentInChildren<MeshFilter>();
			if (targetMeshFilter != null && targetMeshFilter.sharedMesh != null)
			{
				originalVolume = CalculateMeshVolume(targetMeshFilter.sharedMesh);
			}
		}
		isInitalized = true;
	}

	public void RecordRelationship()
	{
		if (!isInitalized || camPos == null)
		{
			return;
		}
		Vector3[] vertices = targetMeshFilter.sharedMesh.vertices;
		Vector3 vector = targetMeshFilter.transform.InverseTransformPoint(camPos.position);
		float num = float.MaxValue;
		for (int i = 0; i < vertices.Length; i++)
		{
			float num2 = Vector3.Distance(vector, vertices[i]);
			if (num2 < num)
			{
				num = num2;
				_closestVertexIndex = i;
			}
		}
		_offset = vector - vertices[_closestVertexIndex];
		Debug.Log("CamPos Recorded");
	}

	public void UpdateCamPosition()
	{
		if (_closestVertexIndex == -1 || targetMeshFilter == null)
		{
			return;
		}
		Mesh sharedMesh = targetMeshFilter.sharedMesh;
		if (!(sharedMesh == null))
		{
			Vector3[] vertices = sharedMesh.vertices;
			if (_closestVertexIndex < vertices.Length)
			{
				Vector3 position = vertices[_closestVertexIndex] + _offset;
				camPos.position = targetMeshFilter.transform.TransformPoint(position);
			}
		}
	}

	public void CalculateInitialOffset()
	{
		if (targetAxis == DeformAxis.Z)
		{
			Rocket componentInParent = GetComponentInParent<Rocket>();
			if (componentInParent != null)
			{
				headPos = componentInParent.rocketHeadPos;
				camPos = componentInParent.camPos;
			}
		}
		if (headPos != null && lattice != null && originalPoints != null && originalPoints.Length != 0)
		{
			Vector3 zero = Vector3.zero;
			int num = 0;
			Vector3Int resolution = lattice.Resolution;
			if (targetAxis == DeformAxis.Z)
			{
				int z = resolution.z - 1;
				for (int i = 0; i < resolution.x; i++)
				{
					for (int j = 0; j < resolution.y; j++)
					{
						int index = lattice.GetIndex(i, j, z);
						zero += (Vector3)originalPoints[index];
						num++;
					}
				}
			}
			else
			{
				int y = resolution.y - 1;
				for (int k = 0; k < resolution.x; k++)
				{
					for (int l = 0; l < resolution.z; l++)
					{
						int index2 = lattice.GetIndex(k, y, l);
						zero += (Vector3)originalPoints[index2];
						num++;
					}
				}
			}
			if (num > 0)
			{
				Vector3 vector = zero / num;
				Vector3 vector2 = lattice.transform.InverseTransformPoint(headPos.position);
				headOffset = vector2 - vector;
			}
		}
		RecordRelationship();
	}

	public void UpdateHeadPosition()
	{
		if (lattice == null || headPos == null)
		{
			return;
		}
		Vector3Int resolution = lattice.Resolution;
		Vector3 zero = Vector3.zero;
		int num = 0;
		if (targetAxis == DeformAxis.Z)
		{
			int z = resolution.z - 1;
			for (int i = 0; i < resolution.x; i++)
			{
				for (int j = 0; j < resolution.y; j++)
				{
					int index = lattice.GetIndex(i, j, z);
					zero += (Vector3)lattice.ControlPoints[index];
					num++;
				}
			}
		}
		else
		{
			int y = resolution.y - 1;
			for (int k = 0; k < resolution.x; k++)
			{
				for (int l = 0; l < resolution.z; l++)
				{
					int index2 = lattice.GetIndex(k, y, l);
					zero += (Vector3)lattice.ControlPoints[index2];
					num++;
				}
			}
		}
		if (num > 0)
		{
			Vector3 position = zero / num + headOffset;
			Vector3 position2 = lattice.transform.TransformPoint(position);
			headPos.position = position2;
		}
	}

	public void ApplyAllRings()
	{
		Vector3Int resolution = lattice.Resolution;
		int num = ((targetAxis == DeformAxis.Z) ? resolution.z : resolution.y);
		float[] array = new float[num];
		float[] array2 = new float[num];
		for (int i = 0; i < num; i++)
		{
			int num2 = ((targetAxis == DeformAxis.Z) ? lattice.GetIndex(0, 0, i) : lattice.GetIndex(0, i, 0));
			float3 float5 = originalPoints[num2];
			array2[i] = ((targetAxis == DeformAxis.Z) ? float5.z : float5.y);
			array[i] = array2[i] + rings[i].offset;
		}
		for (int j = 1; j < num; j++)
		{
			array[j] = Mathf.Max(array[j], array[j - 1] + margin);
		}
		for (int num3 = num - 2; num3 >= 0; num3--)
		{
			array[num3] = Mathf.Min(array[num3], array[num3 + 1] - margin);
		}
		for (int k = 0; k < num; k++)
		{
			rings[k].offset = array[k] - array2[k];
		}
		for (int l = 0; l < resolution.z; l++)
		{
			for (int m = 0; m < resolution.y; m++)
			{
				for (int n = 0; n < resolution.x; n++)
				{
					int index = lattice.GetIndex(n, m, l);
					float3 controlPoint = originalPoints[index];
					if (targetAxis == DeformAxis.Z)
					{
						float offset = rings[l].offset;
						float scale = rings[l].scale;
						controlPoint.x *= scale;
						controlPoint.y *= scale;
						controlPoint.z += offset;
					}
					else
					{
						float offset2 = rings[m].offset;
						float scale2 = rings[m].scale;
						controlPoint.x *= scale2;
						controlPoint.z *= scale2;
						controlPoint.y += offset2;
					}
					lattice.SetControlPoint(n, m, l, controlPoint);
				}
			}
		}
	}

	public float CalculateMeshVolume(Mesh mesh)
	{
		float num = 0f;
		Vector3[] vertices = mesh.vertices;
		int[] triangles = mesh.triangles;
		for (int i = 0; i < triangles.Length; i += 3)
		{
			Vector3 lhs = vertices[triangles[i]];
			Vector3 lhs2 = vertices[triangles[i + 1]];
			Vector3 rhs = vertices[triangles[i + 2]];
			num += Vector3.Dot(lhs, Vector3.Cross(lhs2, rhs)) / 6f;
		}
		return Mathf.Abs(num);
	}

	public void UpdateMassByVolume()
	{
		if (part == null || originalVolume <= 0f)
		{
			return;
		}
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (!(componentInChildren == null))
		{
			Mesh sharedMesh = componentInChildren.sharedMesh;
			float num = CalculateMeshVolume(sharedMesh) / originalVolume;
			float num2 = 1f + (num - 1f) * massSensitivity;
			float area = 1f + (num - 1f) * 0.2f;
			part.SetArea(area);
			part.mass = originalMass * num2;
			if (part.rocket != null && part.rocket.rb != null)
			{
				part.rocket.rb.mass -= part.mass;
				part.rocket.rb.mass += part.mass;
				part.rocket.UpdateCenterOfMass();
				part.rocket.CalculateTotalCP();
			}
			CustomCrafitng.OnPartsCustomed?.Invoke(part);
			Debug.Log($"원래 부피비: {num:F2}배 / 보정된 비율: {num2:F2}배 / 새 질량: {part.mass:F1}");
		}
	}

	public void UpdateCollider()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		MeshCollider componentInChildren2 = GetComponentInChildren<MeshCollider>();
		if (!(componentInChildren != null) || !(componentInChildren2 != null) || !(componentInChildren.sharedMesh != null))
		{
			return;
		}
		Mesh sharedMesh = componentInChildren.sharedMesh;
		sharedMesh.RecalculateBounds();
		Bounds bounds = sharedMesh.bounds;
		componentInChildren2.sharedMesh = null;
		componentInChildren2.sharedMesh = sharedMesh;
		if (part != null && part.rocket != null)
		{
			CapsuleCollider component = part.GetComponent<CapsuleCollider>();
			if (component != null)
			{
				Vector3 vector = componentInChildren.transform.TransformVector(bounds.size);
				Vector3 vector2 = component.transform.InverseTransformVector(vector);
				vector2 = new Vector3(Mathf.Abs(vector2.x), Mathf.Abs(vector2.y), Mathf.Abs(vector2.z));
				component.direction = 1;
				component.height = vector2.y;
				component.radius = Mathf.Max(vector2.x, vector2.z) / 2f;
				Vector3 position = componentInChildren.transform.TransformPoint(bounds.center);
				component.center = component.transform.InverseTransformPoint(position);
			}
		}
		Debug.Log("MeshCollider 및 캡슐 콜라이더 치수 갱신 완료!");
	}

	public void CalculateCMOffset()
	{
		if (lattice == null || rings == null || rings.Length == 0 || part == null)
		{
			return;
		}
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		Vector3Int resolution = lattice.Resolution;
		int num5 = ((targetAxis == DeformAxis.Z) ? resolution.z : resolution.y);
		for (int i = 0; i < num5; i++)
		{
			float num6 = 0f;
			int num7 = 0;
			if (targetAxis == DeformAxis.Z)
			{
				for (int j = 0; j < resolution.x; j++)
				{
					for (int k = 0; k < resolution.y; k++)
					{
						int index = lattice.GetIndex(j, k, i);
						num6 += originalPoints[index].z;
						num7++;
					}
				}
			}
			else
			{
				for (int l = 0; l < resolution.x; l++)
				{
					for (int m = 0; m < resolution.z; m++)
					{
						int index2 = lattice.GetIndex(l, i, m);
						num6 += originalPoints[index2].y;
						num7++;
					}
				}
			}
			float num8 = num6 / (float)num7;
			float num9 = num8 + rings[i].offset;
			float num10 = rings[i].scale * rings[i].scale;
			num += num9 * num10;
			num2 += num10;
			num3 += num8;
			num4 += 1f;
		}
		if (num2 > 0f && num4 > 0f)
		{
			float num11 = num / num2;
			float num12 = num3 / num4;
			float num13 = num11 - num12;
			Vector3 direction = ((targetAxis == DeformAxis.Z) ? new Vector3(0f, 0f, num13) : new Vector3(0f, num13, 0f));
			Vector3 direction2 = lattice.transform.TransformDirection(direction);
			part.massOffset = part.transform.InverseTransformDirection(direction2);
		}
	}
}
