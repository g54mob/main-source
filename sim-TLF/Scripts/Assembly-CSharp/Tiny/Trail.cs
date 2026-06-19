using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Tiny
{
	public class Trail : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The material to apply to the trail.")]
		private Material material;

		[SerializeField]
		[Tooltip("Define the lifetime of a point in the trail, in seconds.")]
		private float duration = 0.1f;

		[SerializeField]
		[Tooltip("Increase this value to make the trail corners appear rounder.")]
		private int corner = 1;

		[SerializeField]
		[Tooltip("Enable this to connect the first and last positions of the line, and form a closed loop.")]
		private bool loop;

		[SerializeField]
		[Tooltip("The array of Vector3 points to connect.")]
		private Vector3[] points = new Vector3[2]
		{
			new Vector3(0f, 0f, -1f),
			new Vector3(0f, 0f, 1f)
		};

		[NonSerialized]
		private GameObject trailGo;

		[NonSerialized]
		private Mesh mesh;

		[NonSerialized]
		private Vector3[] vertices;

		[NonSerialized]
		private Transform cacheTM;

		[NonSerialized]
		private int lastSegmentCount = -1;

		[NonSerialized]
		private int lastCorner = -1;

		[NonSerialized]
		private int pointCount = -1;

		[NonSerialized]
		private float toCornerT;

		private Coroutine update;

		public Vector3[] Points
		{
			get
			{
				return points;
			}
			set
			{
				points = value;
			}
		}

		public bool Loop
		{
			get
			{
				if (loop)
				{
					return points.Length >= 3;
				}
				return false;
			}
		}

		public void Clear()
		{
			if (base.enabled && pointCount > 1 && (bool)trailGo)
			{
				if (update != null)
				{
					StopCoroutine(update);
				}
				ClearVertices();
				update = StartCoroutine(PhysicsUpdate());
			}
		}

		private void Start()
		{
			cacheTM = base.transform;
			trailGo = new GameObject(base.name + "Trail", typeof(MeshFilter), typeof(MeshRenderer));
			UnityEngine.Object.DontDestroyOnLoad(trailGo);
			mesh = new Mesh
			{
				name = "Trail Effect"
			};
			mesh.MarkDynamic();
			trailGo.GetComponent<MeshFilter>().sharedMesh = mesh;
			trailGo.layer = base.gameObject.layer;
			MeshRenderer component = trailGo.GetComponent<MeshRenderer>();
			component.material = material;
			component.shadowCastingMode = ShadowCastingMode.Off;
			Initialize((int)(duration / Time.fixedDeltaTime));
		}

		private void OnDestroy()
		{
			if (mesh != null)
			{
				UnityEngine.Object.DestroyImmediate(mesh);
			}
			mesh = null;
			if (trailGo != null)
			{
				UnityEngine.Object.DestroyImmediate(trailGo);
			}
			trailGo = null;
		}

		private void OnEnable()
		{
			if (!(trailGo == null))
			{
				trailGo.SetActive(value: true);
				Initialize((int)(duration / Time.fixedDeltaTime));
			}
		}

		private void OnDisable()
		{
			if ((bool)trailGo)
			{
				trailGo.SetActive(value: false);
			}
			if (update != null)
			{
				StopCoroutine(update);
			}
			update = null;
		}

		private void SetVerticesAndCorner()
		{
			int num = pointCount + pointCount * corner;
			Array.Copy(vertices, 0, vertices, num, vertices.Length - num);
			TransformVertices();
			int num2 = num * 2;
			int num3 = num * 3;
			int num4 = -1;
			while (++num4 < pointCount)
			{
				Vector3 vector = vertices[num4];
				Vector3 vector2 = vertices[num4 + num];
				Vector3 vector3 = vertices[num4 + num2];
				Vector3 p = vertices[num4 + num3];
				int num5 = -1;
				int num6 = pointCount + num4;
				while (++num5 < corner)
				{
					float t = (float)(num5 + 1) * toCornerT;
					vertices[num6] = CatmullRomSpline(vector, vector, vector2, vector3, t);
					vertices[num6 + num] = CatmullRomSpline(vector, vector2, vector3, p, t);
					num6 += pointCount;
				}
			}
		}

		private void SetVertices()
		{
			Array.Copy(vertices, 0, vertices, pointCount, vertices.Length - pointCount);
			TransformVertices();
		}

		private IEnumerator PhysicsUpdate()
		{
			YieldInstruction wait = new WaitForFixedUpdate();
			Action action = ((corner > 0) ? new Action(SetVerticesAndCorner) : new Action(SetVertices));
			while (true)
			{
				yield return wait;
				action();
				cacheTM.hasChanged = false;
			}
		}

		private void LateUpdate()
		{
			if (cacheTM.hasChanged)
			{
				TransformVertices();
			}
			mesh.vertices = vertices;
			mesh.RecalculateBounds();
		}

		private void TransformVertices()
		{
			Matrix4x4 localToWorldMatrix = cacheTM.localToWorldMatrix;
			int num = -1;
			while (++num < pointCount)
			{
				vertices[num] = localToWorldMatrix.MultiplyPoint3x4(points[num]);
			}
		}

		private void ClearVertices()
		{
			TransformVertices();
			for (int i = pointCount; i < vertices.Length; i += pointCount)
			{
				Array.Copy(vertices, 0, vertices, i, pointCount);
			}
		}

		private void Initialize(int segment)
		{
			int num = ((segment >= 3) ? corner : 0);
			if (lastSegmentCount == segment && pointCount == points.Length && lastCorner == num)
			{
				ClearVertices();
				update = StartCoroutine(PhysicsUpdate());
				return;
			}
			pointCount = points.Length;
			lastCorner = num;
			lastSegmentCount = segment;
			if (pointCount <= 1)
			{
				mesh.Clear();
				return;
			}
			int num2 = segment + segment * num;
			Vector2[] array = new Vector2[pointCount * (num2 + 1)];
			bool flag = Loop;
			int[] array2 = new int[(flag ? pointCount : (pointCount - 1)) * 6 * num2];
			Vector2 vector = default(Vector2);
			int num3 = pointCount - 1;
			float num4 = 1f / (float)segment;
			float num5 = 1f / (float)num3;
			toCornerT = 1f / (float)(num + 1);
			int num6 = -1;
			int num7 = -1;
			while (++num6 <= segment)
			{
				vector.y = (float)num6 * num4;
				int num8 = -1;
				while (++num8 < pointCount)
				{
					vector.x = (float)num8 * num5;
					array[++num7] = vector;
				}
				if (num6 == segment)
				{
					continue;
				}
				int num9 = -1;
				while (++num9 < num)
				{
					vector.y = Mathf.Lerp((float)num6 * num4, (float)(num6 + 1) * num4, (float)(num9 + 1) * toCornerT);
					int num10 = -1;
					while (++num10 < pointCount)
					{
						vector.x = (float)num10 * num5;
						array[++num7] = vector;
					}
				}
			}
			int num11 = 0;
			int num12 = (flag ? (num3 + 1) : num3);
			int num13 = -1;
			while (++num13 < num2)
			{
				int num14 = num13 * pointCount;
				int num15 = num13 * pointCount;
				if (flag)
				{
					num14 += num3;
				}
				else
				{
					num15++;
				}
				int num16 = -1;
				while (++num16 < num12)
				{
					array2[num11] = num14;
					array2[num11 + 1] = num14 + pointCount;
					array2[num11 + 2] = num15;
					array2[num11 + 3] = num15;
					array2[num11 + 4] = num14 + pointCount;
					array2[num11 + 5] = num15 + pointCount;
					num11 += 6;
					num14 = num15++;
				}
			}
			vertices = new Vector3[array.Length];
			ClearVertices();
			mesh.vertices = vertices;
			mesh.uv = array;
			mesh.SetIndices(array2, MeshTopology.Triangles, 0);
			update = StartCoroutine(PhysicsUpdate());
		}

		private static Vector3 CatmullRomSpline(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
		{
			float num = t * t;
			float num2 = num * t;
			return 0.5f * (2f * p1 + (-p0 + p2) * t + (2f * p0 - 5f * p1 + 4f * p2 - p3) * num + (-p0 + 3f * p1 - 3f * p2 + p3) * num2);
		}
	}
}
