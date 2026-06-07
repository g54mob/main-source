using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{
	public bool inWater;

	public float density = 500f;

	public int slicesPerAxis = 2;

	public bool isConcave;

	public int voxelsLimit = 16;

	private const float DAMPFER = 0.1f;

	private const float WATER_DENSITY = 1000f;

	private float voxelHalfHeight;

	private Vector3 localArchimedesForce;

	private List<Vector3> voxels;

	private bool isMeshCollider;

	private List<Vector3[]> forces;

	public bool cooked;

	public bool overCooked;

	public int numOfIngred;

	public Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		InitializeBuoyancy();
		forces = new List<Vector3[]>();
		Quaternion rotation = base.transform.rotation;
		Vector3 position = base.transform.position;
		base.transform.rotation = Quaternion.identity;
		base.transform.position = Vector3.zero;
		if (GetComponentInChildren<Collider>() == null)
		{
			base.gameObject.AddComponent<MeshCollider>();
			Debug.LogWarning($"[Buoyancy.cs] Object \"{base.name}\" had no collider. MeshCollider has been added.");
		}
		isMeshCollider = GetComponent<MeshCollider>() != null;
		Bounds bounds = GetComponent<Collider>().bounds;
		if (bounds.size.x < bounds.size.y)
		{
			voxelHalfHeight = bounds.size.x;
		}
		else
		{
			voxelHalfHeight = bounds.size.y;
		}
		if (bounds.size.z < voxelHalfHeight)
		{
			voxelHalfHeight = bounds.size.z;
		}
		voxelHalfHeight /= 2 * slicesPerAxis;
		if (GetComponent<Rigidbody>() == null)
		{
			base.gameObject.AddComponent<Rigidbody>();
			Debug.LogWarning($"[Buoyancy.cs] Object \"{base.name}\" had no Rigidbody. Rigidbody has been added.");
		}
		voxels = SliceIntoVoxels(isMeshCollider && isConcave);
		base.transform.rotation = rotation;
		base.transform.position = position;
		float num = GetComponent<Rigidbody>().mass / density;
		WeldPoints(voxels, voxelsLimit);
		float y = 1000f * Mathf.Abs(Physics.gravity.y) * num;
		localArchimedesForce = new Vector3(0f, y, 0f) / voxels.Count;
		Debug.Log($"[Buoyancy.cs] Name=\"{base.name}\" volume={num:0.0}, mass={GetComponent<Rigidbody>().mass:0.0}, density={density:0.0}");
	}

	private List<Vector3> SliceIntoVoxels(bool concave)
	{
		List<Vector3> list = new List<Vector3>(slicesPerAxis * slicesPerAxis * slicesPerAxis);
		if (concave)
		{
			MeshCollider component = GetComponent<MeshCollider>();
			bool convex = component.convex;
			component.convex = false;
			Bounds bounds = GetComponent<Collider>().bounds;
			for (int i = 0; i < slicesPerAxis; i++)
			{
				for (int j = 0; j < slicesPerAxis; j++)
				{
					for (int k = 0; k < slicesPerAxis; k++)
					{
						float x = bounds.min.x + bounds.size.x / (float)slicesPerAxis * (0.5f + (float)i);
						float y = bounds.min.y + bounds.size.y / (float)slicesPerAxis * (0.5f + (float)j);
						float z = bounds.min.z + bounds.size.z / (float)slicesPerAxis * (0.5f + (float)k);
						Vector3 vector = base.transform.InverseTransformPoint(new Vector3(x, y, z));
						if (PointIsInsideMeshCollider(component, vector))
						{
							list.Add(vector);
						}
					}
				}
			}
			if (list.Count == 0)
			{
				list.Add(bounds.center);
			}
			component.convex = convex;
		}
		else
		{
			Bounds bounds2 = GetComponent<Collider>().bounds;
			for (int l = 0; l < slicesPerAxis; l++)
			{
				for (int m = 0; m < slicesPerAxis; m++)
				{
					for (int n = 0; n < slicesPerAxis; n++)
					{
						float x2 = bounds2.min.x + bounds2.size.x / (float)slicesPerAxis * (0.5f + (float)l);
						float y2 = bounds2.min.y + bounds2.size.y / (float)slicesPerAxis * (0.5f + (float)m);
						float z2 = bounds2.min.z + bounds2.size.z / (float)slicesPerAxis * (0.5f + (float)n);
						Vector3 item = base.transform.InverseTransformPoint(new Vector3(x2, y2, z2));
						list.Add(item);
					}
				}
			}
		}
		return list;
	}

	private static bool PointIsInsideMeshCollider(Collider c, Vector3 p)
	{
		Vector3[] array = new Vector3[6]
		{
			Vector3.up,
			Vector3.down,
			Vector3.left,
			Vector3.right,
			Vector3.forward,
			Vector3.back
		};
		foreach (Vector3 vector in array)
		{
			if (!c.Raycast(new Ray(p - vector * 1000f, vector), out var _, 1000f))
			{
				return false;
			}
		}
		return true;
	}

	private static void FindClosestPoints(IList<Vector3> list, out int firstIndex, out int secondIndex)
	{
		float num = float.MaxValue;
		float num2 = float.MinValue;
		firstIndex = 0;
		secondIndex = 1;
		for (int i = 0; i < list.Count - 1; i++)
		{
			for (int j = i + 1; j < list.Count; j++)
			{
				float num3 = Vector3.Distance(list[i], list[j]);
				if (num3 < num)
				{
					num = num3;
					firstIndex = i;
					secondIndex = j;
				}
				if (num3 > num2)
				{
					num2 = num3;
				}
			}
		}
	}

	private static void WeldPoints(IList<Vector3> list, int targetCount)
	{
		if (list.Count > 2 && targetCount >= 2)
		{
			while (list.Count > targetCount)
			{
				FindClosestPoints(list, out var firstIndex, out var secondIndex);
				Vector3 item = (list[firstIndex] + list[secondIndex]) * 0.5f;
				list.RemoveAt(secondIndex);
				list.RemoveAt(firstIndex);
				list.Add(item);
			}
		}
	}

	private float GetWaterLevel(float x, float z)
	{
		return 1.769f;
	}

	private void FixedUpdate()
	{
		if (!inWater)
		{
			return;
		}
		if (!cooked)
		{
			if (density >= 960f)
			{
				density -= Time.deltaTime * 6f;
			}
			else
			{
				InitializeBuoyancy();
				cooked = true;
			}
		}
		forces.Clear();
		foreach (Vector3 voxel in voxels)
		{
			Vector3 vector = base.transform.TransformPoint(voxel);
			float waterLevel = GetWaterLevel(vector.x, vector.z);
			if (vector.y - voxelHalfHeight < waterLevel)
			{
				float num = (waterLevel - vector.y) / (2f * voxelHalfHeight) + 0.5f;
				if (num > 1f)
				{
					num = 1f;
				}
				else if (num < 0f)
				{
					num = 0f;
				}
				Vector3 vector2 = -GetComponent<Rigidbody>().GetPointVelocity(vector) * 0.1f * GetComponent<Rigidbody>().mass + Mathf.Sqrt(num) * localArchimedesForce;
				GetComponent<Rigidbody>().AddForceAtPosition(vector2, vector);
				forces.Add(new Vector3[2] { vector, vector2 });
			}
		}
	}

	private void OnDrawGizmos()
	{
		if (voxels == null || forces == null)
		{
			return;
		}
		Gizmos.color = Color.yellow;
		foreach (Vector3 voxel in voxels)
		{
			Gizmos.DrawCube(base.transform.TransformPoint(voxel), new Vector3(0.05f, 0.05f, 0.05f));
		}
		Gizmos.color = Color.cyan;
		foreach (Vector3[] force in forces)
		{
			Gizmos.DrawCube(force[0], new Vector3(0.05f, 0.05f, 0.05f));
			Gizmos.DrawLine(force[0], force[0] + force[1] / GetComponent<Rigidbody>().mass);
		}
	}

	private void InitializeBuoyancy()
	{
		forces = new List<Vector3[]>();
		Quaternion rotation = base.transform.rotation;
		Vector3 position = base.transform.position;
		base.transform.rotation = Quaternion.identity;
		base.transform.position = Vector3.zero;
		if (GetComponent<Collider>() == null)
		{
			base.gameObject.AddComponent<MeshCollider>();
		}
		isMeshCollider = GetComponent<MeshCollider>() != null;
		Bounds bounds = GetComponent<Collider>().bounds;
		voxelHalfHeight = Mathf.Min(bounds.size.x, bounds.size.y, bounds.size.z) / (float)(2 * slicesPerAxis);
		if (GetComponent<Rigidbody>() == null)
		{
			base.gameObject.AddComponent<Rigidbody>();
		}
		rb.centerOfMass = new Vector3(0f, (0f - bounds.extents.y) * 0f, 0f) + base.transform.InverseTransformPoint(bounds.center);
		voxels = SliceIntoVoxels(isMeshCollider && isConcave);
		base.transform.rotation = rotation;
		base.transform.position = position;
		float num = GetComponent<Rigidbody>().mass / density;
		WeldPoints(voxels, voxelsLimit);
		float y = 1000f * Mathf.Abs(Physics.gravity.y) * num;
		localArchimedesForce = new Vector3(0f, y, 0f) / voxels.Count;
	}

	private void OnValidate()
	{
		if (Application.isPlaying)
		{
			InitializeBuoyancy();
		}
	}

	public void SetCenterOfMass()
	{
		Bounds bounds = GetComponent<Collider>().bounds;
		rb.centerOfMass = new Vector3(0f, (0f - bounds.extents.y) * 0f, 0f) + base.transform.InverseTransformPoint(bounds.center);
	}
}
