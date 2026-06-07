using System;
using System.Collections.Generic;
using UnityEngine;

namespace GogoGaga.OptimizedRopesAndCables
{
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(Rope))]
	public class RopeMesh : MonoBehaviour
	{
		[Range(3f, 25f)]
		public int OverallDivision = 6;

		[Range(0.01f, 10f)]
		public float ropeWidth = 0.3f;

		[Range(3f, 20f)]
		public int radialDivision = 8;

		[Tooltip("For now only base color is applied")]
		public Material material;

		[Tooltip("Tiling density per meter of the rope")]
		public float tilingPerMeter = 1f;

		private Rope rope;

		private MeshFilter meshFilter;

		private MeshRenderer meshRenderer;

		private Mesh ropeMesh;

		private bool isStartOrEndPointMissing;

		private List<Vector3> vertices = new List<Vector3>();

		private List<int> triangles = new List<int>();

		private List<Vector2> uvs = new List<Vector2>();

		private void OnValidate()
		{
			InitializeComponents();
			if (!rope.IsPrefab)
			{
				SubscribeToRopeEvents();
				if ((bool)meshRenderer && (bool)material)
				{
					meshRenderer.material = material;
				}
			}
		}

		private void Awake()
		{
			InitializeComponents();
			SubscribeToRopeEvents();
		}

		private void OnEnable()
		{
			_ = Application.isPlaying;
			SubscribeToRopeEvents();
		}

		private void OnDisable()
		{
			UnsubscribeFromRopeEvents();
		}

		private void InitializeComponents()
		{
			if (!rope)
			{
				rope = GetComponent<Rope>();
			}
			if (!meshFilter)
			{
				meshFilter = GetComponent<MeshFilter>();
			}
			if (!meshRenderer)
			{
				meshRenderer = GetComponent<MeshRenderer>();
			}
			CheckEndPoints();
		}

		private void CheckEndPoints()
		{
			if (base.gameObject.scene.rootCount == 0)
			{
				isStartOrEndPointMissing = false;
			}
			else if (rope.StartPoint == null || rope.EndPoint == null)
			{
				isStartOrEndPointMissing = true;
				Debug.LogError("StartPoint or EndPoint is not assigned.", base.gameObject);
			}
			else
			{
				isStartOrEndPointMissing = false;
			}
		}

		private void SubscribeToRopeEvents()
		{
			UnsubscribeFromRopeEvents();
			if (rope != null)
			{
				rope.OnPointsChanged += GenerateMesh;
			}
		}

		private void UnsubscribeFromRopeEvents()
		{
			if (rope != null)
			{
				rope.OnPointsChanged -= GenerateMesh;
			}
		}

		public void CreateRopeMesh(Vector3[] points, float radius, int segmentsPerWire)
		{
			if (points == null || points.Length < 2)
			{
				Debug.LogError("Need at least two points to create a rope mesh.", base.gameObject);
				return;
			}
			if (ropeMesh == null)
			{
				ropeMesh = new Mesh
				{
					name = "RopeMesh"
				};
				meshFilter.mesh = ropeMesh;
			}
			else
			{
				ropeMesh.Clear();
			}
			_ = base.transform.position;
			vertices.Clear();
			triangles.Clear();
			uvs.Clear();
			float num = 0f;
			for (int i = 0; i < points.Length; i++)
			{
				Quaternion quaternion = Quaternion.LookRotation((i < points.Length - 1) ? (points[i + 1] - points[i]) : (points[i] - points[i - 1]), Vector3.up);
				for (int j = 0; j <= segmentsPerWire; j++)
				{
					float f = (float)j * MathF.PI * 2f / (float)segmentsPerWire;
					Vector3 vector = new Vector3(Mathf.Cos(f), Mathf.Sin(f), 0f) * radius;
					vertices.Add(base.transform.InverseTransformPoint(points[i] + quaternion * vector));
					float x = (float)j / (float)segmentsPerWire;
					float y = num * tilingPerMeter;
					uvs.Add(new Vector2(x, y));
				}
				if (i < points.Length - 1)
				{
					num += Vector3.Distance(points[i], points[i + 1]);
				}
			}
			for (int k = 0; k < points.Length - 1; k++)
			{
				for (int l = 0; l < segmentsPerWire; l++)
				{
					int num2 = k * (segmentsPerWire + 1) + l;
					int item = num2 + 1;
					int num3 = num2 + segmentsPerWire + 1;
					int item2 = num3 + 1;
					triangles.Add(num2);
					triangles.Add(item);
					triangles.Add(num3);
					triangles.Add(item);
					triangles.Add(item2);
					triangles.Add(num3);
				}
			}
			int count = vertices.Count;
			vertices.Add(base.transform.InverseTransformPoint(points[0]));
			uvs.Add(new Vector2(0.5f, 0f));
			Quaternion quaternion2 = Quaternion.LookRotation(points[1] - points[0]);
			for (int m = 0; m <= segmentsPerWire; m++)
			{
				float f2 = (float)m * MathF.PI * 2f / (float)segmentsPerWire;
				Vector3 vector2 = new Vector3(Mathf.Cos(f2), Mathf.Sin(f2), 0f) * radius;
				vertices.Add(base.transform.InverseTransformPoint(points[0] + quaternion2 * vector2));
				if (m < segmentsPerWire)
				{
					triangles.Add(count);
					triangles.Add(count + m + 1);
					triangles.Add(count + m + 2);
				}
				uvs.Add(new Vector2((Mathf.Cos(f2) + 1f) / 2f, (Mathf.Sin(f2) + 1f) / 2f));
			}
			int count2 = vertices.Count;
			vertices.Add(base.transform.InverseTransformPoint(points[^1]));
			uvs.Add(new Vector2(0.5f, num * tilingPerMeter));
			Quaternion quaternion3 = Quaternion.LookRotation(points[^1] - points[^2]);
			for (int n = 0; n <= segmentsPerWire; n++)
			{
				float f3 = (float)n * MathF.PI * 2f / (float)segmentsPerWire;
				Vector3 vector3 = new Vector3(Mathf.Cos(f3), Mathf.Sin(f3), 0f) * radius;
				vertices.Add(base.transform.InverseTransformPoint(points[^1] + quaternion3 * vector3));
				if (n < segmentsPerWire)
				{
					triangles.Add(count2);
					triangles.Add(count2 + n + 1);
					triangles.Add(count2 + n + 2);
				}
				uvs.Add(new Vector2((Mathf.Cos(f3) + 1f) / 2f, (Mathf.Sin(f3) + 1f) / 2f));
			}
			ropeMesh.vertices = vertices.ToArray();
			ropeMesh.triangles = triangles.ToArray();
			ropeMesh.uv = uvs.ToArray();
			ropeMesh.RecalculateNormals();
		}

		private void GenerateMesh()
		{
			if (this == null || rope == null || meshFilter == null)
			{
				return;
			}
			if (isStartOrEndPointMissing)
			{
				if (meshFilter.sharedMesh != null)
				{
					meshFilter.sharedMesh.Clear();
				}
				return;
			}
			Vector3[] array = new Vector3[OverallDivision + 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = rope.GetPointAt((float)i / (float)OverallDivision);
			}
			CreateRopeMesh(array, ropeWidth, radialDivision);
		}

		private void Update()
		{
			if (!rope.IsPrefab && Application.isPlaying)
			{
				GenerateMesh();
			}
		}

		private void DelayedGenerateMesh()
		{
			if (this != null)
			{
				GenerateMesh();
			}
		}

		private void OnDestroy()
		{
			UnsubscribeFromRopeEvents();
			if (meshRenderer != null)
			{
				UnityEngine.Object.Destroy(meshRenderer);
			}
			if (meshFilter != null)
			{
				UnityEngine.Object.Destroy(meshFilter);
			}
		}
	}
}
