using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class GizmosExtension
	{
		public enum CapsuleDirection
		{
			AxisX = 0,
			AxisY = 1,
			AxisZ = 2
		}

		private struct CapsuleData
		{
			private const float MEANINGFUL_DECIMALS = 1000f;

			private int m_Segments;

			private int m_Direction;

			private int m_Height;

			private int m_Radius;

			public int Segments => m_Segments;

			public int Direction => m_Direction;

			public float Height => (float)m_Height / 1000f;

			public float Radius => (float)m_Radius / 1000f;

			public static CapsuleData Create(int segments, int direction, float height, float radius)
			{
				return new CapsuleData
				{
					m_Segments = ((segments % 2 != 0) ? (segments + 1) : segments),
					m_Direction = Mathf.Clamp(direction, 0, 2),
					m_Height = Mathf.FloorToInt(height * 1000f),
					m_Radius = Mathf.FloorToInt(radius * 1000f)
				};
			}
		}

		private class CapsuleCache : Dictionary<CapsuleData, Mesh>
		{
		}

		public enum CrossDirection
		{
			Forward = 0,
			Upwards = 1,
			Sidewards = 2
		}

		private static Mesh ARROW_MESH;

		private static readonly Vector2[] ARROW_MESH_OUTLINE = new Vector2[7]
		{
			new Vector2(0f, 1f),
			new Vector2(1f, 2f),
			new Vector2(2f, 3f),
			new Vector2(3f, 4f),
			new Vector2(4f, 5f),
			new Vector2(5f, 6f),
			new Vector2(6f, 0f)
		};

		private static readonly Color ARROW_COLOR_FILL = new Color(0f, 0f, 0f, 0.2f);

		private static Mesh BOX_MESH;

		private static readonly CapsuleCache CAPSULE_MESHES = new CapsuleCache();

		private static Mesh CIRCLE_SOLID;

		private const int CIRCLE_SEGMENTS = 90;

		private static readonly Vector3[] DIRECTIONS = new Vector3[4]
		{
			Vector3.left,
			Vector3.back,
			Vector3.right,
			Vector3.forward
		};

		private static readonly Mesh[] OCTAHEDRON_MESHES = new Mesh[7];

		private const int MIN_SUBDIVISIONS = 0;

		private const int MAX_SUBDIVISIONS = 6;

		private const int DEFAULT = 5;

		private static readonly Vector3[] TRIANGLE_VERTICES = new Vector3[4]
		{
			new Vector3(-1f, 0f, 0f),
			new Vector3(0f, 0f, 1f),
			new Vector3(1f, 0f, 0f),
			new Vector3(-1f, 0f, 0f)
		};

		public static void Arc(Vector3 position, Quaternion rotation, float angle, float minRadius, float maxRadius)
		{
			Mesh arcMesh = GetArcMesh(angle, minRadius, maxRadius);
			Color color = Gizmos.color;
			Gizmos.DrawMesh(arcMesh, position, rotation, Vector3.one);
			Gizmos.color = color;
		}

		private static Mesh GetArcMesh(float angle, float minRadius, float maxRadius)
		{
			int num = Mathf.FloorToInt(angle / 10f);
			Mesh mesh = new Mesh
			{
				vertices = new Vector3[4 * num],
				triangles = new int[6 * num]
			};
			Vector3[] array = new Vector3[4 * num];
			Vector2[] array2 = new Vector2[4 * num];
			Vector3[] array3 = new Vector3[4 * num];
			int[] array4 = new int[6 * num];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = new Vector2(0f, 0f);
			}
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = new Vector3(0f, 1f, 0f);
			}
			mesh.uv = array2;
			mesh.normals = array;
			float num2 = (0f - angle) / 2f;
			float num3 = (angle / 2f - num2) / (float)num;
			float num4 = num2;
			float num5 = num2 + num3;
			for (int k = 0; k < num; k++)
			{
				Vector3 vector = new Vector3(Mathf.Sin(MathF.PI / 180f * num4), 0f, Mathf.Cos(MathF.PI / 180f * num4));
				Vector3 vector2 = new Vector3(Mathf.Sin(MathF.PI / 180f * num5), 0f, Mathf.Cos(MathF.PI / 180f * num5));
				Vector3 vector3 = vector * minRadius;
				Vector3 vector4 = vector * maxRadius;
				Vector3 vector5 = vector2 * minRadius;
				Vector3 vector6 = vector2 * maxRadius;
				int num6 = 4 * k;
				int num7 = 4 * k + 1;
				int num8 = 4 * k + 2;
				int num9 = 4 * k + 3;
				array3[num6] = vector3;
				array3[num7] = vector4;
				array3[num8] = vector6;
				array3[num9] = vector5;
				array4[6 * k] = num6;
				array4[6 * k + 1] = num7;
				array4[6 * k + 2] = num8;
				array4[6 * k + 3] = num8;
				array4[6 * k + 4] = num9;
				array4[6 * k + 5] = num6;
				num4 += num3;
				num5 += num3;
			}
			mesh.vertices = array3;
			mesh.triangles = array4;
			return mesh;
		}

		public static void Arrow(Vector3 position, Vector3 direction, float size = 1f)
		{
			Quaternion rotation = Quaternion.LookRotation(direction);
			Arrow(position, rotation, size);
		}

		public static void Arrow(Vector3 position, Quaternion rotation, float size = 1f)
		{
			Mesh arrowMesh = GetArrowMesh();
			Color color = Gizmos.color;
			Gizmos.color = ARROW_COLOR_FILL;
			Gizmos.DrawMesh(arrowMesh, position, rotation, Vector3.one * size);
			Gizmos.color = color;
			for (int i = 0; i < ARROW_MESH_OUTLINE.Length; i++)
			{
				Gizmos.DrawLine(position + rotation * arrowMesh.vertices[(int)ARROW_MESH_OUTLINE[i].x] * size, position + rotation * arrowMesh.vertices[(int)ARROW_MESH_OUTLINE[i].y] * size);
			}
		}

		private static Mesh GetArrowMesh()
		{
			if (ARROW_MESH != null)
			{
				return ARROW_MESH;
			}
			Vector3[] vertices = new Vector3[7]
			{
				new Vector3(0f, 0f, 1f),
				new Vector3(-1f, 0f, 0f),
				new Vector3(-0.5f, 0f, 0f),
				new Vector3(-0.5f, 0f, -1f),
				new Vector3(0.5f, 0f, -1f),
				new Vector3(0.5f, 0f, 0f),
				new Vector3(1f, 0f, 0f)
			};
			int[] triangles = new int[15]
			{
				0, 6, 5, 0, 5, 4, 0, 4, 3, 0,
				3, 2, 0, 2, 1
			};
			Vector2[] uv = new Vector2[7]
			{
				new Vector2(0.5f, 1f),
				new Vector2(1f, 0.5f),
				new Vector2(0.25f, 0.5f),
				new Vector2(0.25f, 0f),
				new Vector2(0.75f, 0f),
				new Vector2(0.75f, 0.5f),
				new Vector2(1f, 0.5f)
			};
			Vector3[] normals = new Vector3[7]
			{
				Vector3.up,
				Vector3.up,
				Vector3.up,
				Vector3.up,
				Vector3.up,
				Vector3.up,
				Vector3.up
			};
			Mesh obj = new Mesh
			{
				vertices = vertices,
				triangles = triangles,
				normals = normals,
				uv = uv
			};
			ARROW_MESH = obj;
			return obj;
		}

		public static void Bounds(Bounds bounds)
		{
			float x = bounds.extents.x;
			float y = bounds.extents.y;
			float z = bounds.extents.z;
			Vector3 vector = bounds.center + new Vector3(x, y, z);
			Vector3 vector2 = bounds.center + new Vector3(x, y, 0f - z);
			Vector3 vector3 = bounds.center + new Vector3(0f - x, y, z);
			Vector3 vector4 = bounds.center + new Vector3(0f - x, y, 0f - z);
			Vector3 vector5 = bounds.center + new Vector3(x, 0f - y, z);
			Vector3 to = bounds.center + new Vector3(x, 0f - y, 0f - z);
			Vector3 vector6 = bounds.center + new Vector3(0f - x, 0f - y, z);
			Vector3 vector7 = bounds.center + new Vector3(0f - x, 0f - y, 0f - z);
			Gizmos.DrawLine(vector, vector3);
			Gizmos.DrawLine(vector, vector2);
			Gizmos.DrawLine(vector3, vector4);
			Gizmos.DrawLine(vector2, vector4);
			Gizmos.DrawLine(vector, vector5);
			Gizmos.DrawLine(vector2, to);
			Gizmos.DrawLine(vector3, vector6);
			Gizmos.DrawLine(vector4, vector7);
			Gizmos.DrawLine(vector5, vector6);
			Gizmos.DrawLine(vector5, to);
			Gizmos.DrawLine(vector6, vector7);
			Gizmos.DrawLine(vector7, to);
		}

		public static void Box(Vector3 center, Quaternion rotation, Vector3 size)
		{
			Gizmos.DrawMesh(GetBoxMesh(), center, rotation, size);
		}

		public static void BoxWire(Vector3 center, Quaternion rotation, Vector3 size)
		{
			Gizmos.DrawWireMesh(GetBoxMesh(), center, rotation, size);
		}

		private static Mesh GetBoxMesh()
		{
			if (BOX_MESH != null)
			{
				return BOX_MESH;
			}
			Vector3[] vertices = new Vector3[8]
			{
				new Vector3(-0.5f, -0.5f, -0.5f),
				new Vector3(0.5f, -0.5f, -0.5f),
				new Vector3(0.5f, 0.5f, -0.5f),
				new Vector3(-0.5f, 0.5f, -0.5f),
				new Vector3(-0.5f, 0.5f, 0.5f),
				new Vector3(0.5f, 0.5f, 0.5f),
				new Vector3(0.5f, -0.5f, 0.5f),
				new Vector3(-0.5f, -0.5f, 0.5f)
			};
			int[] triangles = new int[36]
			{
				0, 2, 1, 0, 3, 2, 2, 3, 4, 2,
				4, 5, 1, 2, 5, 1, 5, 6, 0, 7,
				4, 0, 4, 3, 5, 4, 7, 5, 7, 6,
				0, 6, 7, 0, 1, 6
			};
			Mesh mesh = new Mesh();
			mesh.name = "Box";
			mesh.vertices = vertices;
			mesh.triangles = triangles;
			mesh.Optimize();
			mesh.RecalculateNormals();
			BOX_MESH = mesh;
			return mesh;
		}

		public static void Capsule(Vector3 origin, Quaternion rotation, float radius, float height, int segments, int direction)
		{
			Gizmos.DrawMesh(RequestCapsule(radius, height, segments, direction), origin, rotation, Vector3.one);
		}

		public static void CapsuleWire(Vector3 origin, Quaternion rotation, float radius, float height, int segments, int direction)
		{
			Gizmos.DrawWireMesh(RequestCapsule(radius, height, segments, direction), origin, rotation, Vector3.one);
		}

		private static Mesh RequestCapsule(float radius, float height, int segments, int direction)
		{
			CapsuleData capsuleData = CapsuleData.Create(segments, direction, height, radius);
			if (!CAPSULE_MESHES.TryGetValue(capsuleData, out var value) || value == null)
			{
				value = CreateCapsule(capsuleData);
				CAPSULE_MESHES[capsuleData] = value;
			}
			return value;
		}

		private static Mesh CreateCapsule(CapsuleData data)
		{
			int num = data.Segments + 1;
			float[] array = new float[num];
			float[] array2 = new float[num];
			float[] array3 = new float[num];
			float[] array4 = new float[num];
			float num2 = 0f;
			float num3 = 0f;
			for (int i = 0; i < num; i++)
			{
				array[i] = Mathf.Sin(num2 * (MathF.PI / 180f));
				array2[i] = Mathf.Cos(num2 * (MathF.PI / 180f));
				array3[i] = Mathf.Cos(num3 * (MathF.PI / 180f));
				array4[i] = Mathf.Sin(num3 * (MathF.PI / 180f));
				num2 += 360f / (float)data.Segments;
				num3 += 180f / (float)data.Segments;
			}
			Vector3[] array5 = new Vector3[num * (num + 1)];
			Vector2[] array6 = new Vector2[array5.Length];
			int num4 = 0;
			float num5 = (data.Height - data.Radius * 2f) * 0.5f;
			if (num5 < 0f)
			{
				num5 = 0f;
			}
			float num6 = 1f / (float)(num - 1);
			int num7 = Mathf.CeilToInt((float)num * 0.5f);
			for (int j = 0; j < num7; j++)
			{
				for (int k = 0; k < num; k++)
				{
					array5[num4] = new Vector3(array[k] * array4[j], array3[j], array2[k] * array4[j]) * data.Radius;
					array5[num4].y = num5 + array5[num4].y;
					float x = 1f - num6 * (float)k;
					float y = (array5[num4].y + data.Height * 0.5f) / data.Height;
					array6[num4] = new Vector2(x, y);
					num4++;
				}
			}
			for (int l = Mathf.FloorToInt((float)num * 0.5f); l < num; l++)
			{
				for (int m = 0; m < num; m++)
				{
					array5[num4] = new Vector3(array[m] * array4[l], array3[l], array2[m] * array4[l]) * data.Radius;
					array5[num4].y = 0f - num5 + array5[num4].y;
					float x = 1f - num6 * (float)m;
					float y = (array5[num4].y + data.Height * 0.5f) / data.Height;
					array6[num4] = new Vector2(x, y);
					num4++;
				}
			}
			int[] array7 = new int[data.Segments * (data.Segments + 1) * 2 * 3];
			int n = 0;
			int num8 = 0;
			for (; n < data.Segments + 1; n++)
			{
				int num9 = 0;
				while (num9 < data.Segments)
				{
					array7[num8] = n * (data.Segments + 1) + num9;
					array7[num8 + 1] = (n + 1) * (data.Segments + 1) + num9;
					array7[num8 + 2] = (n + 1) * (data.Segments + 1) + num9 + 1;
					array7[num8 + 3] = n * (data.Segments + 1) + num9 + 1;
					array7[num8 + 4] = n * (data.Segments + 1) + num9;
					array7[num8 + 5] = (n + 1) * (data.Segments + 1) + num9 + 1;
					num9++;
					num8 += 6;
				}
			}
			Quaternion quaternion = data.Direction switch
			{
				0 => Quaternion.Euler(0f, 0f, 90f), 
				1 => Quaternion.identity, 
				2 => Quaternion.Euler(90f, 0f, 0f), 
				_ => Quaternion.identity, 
			};
			for (int num10 = 0; num10 < array5.Length; num10++)
			{
				array5[num10] = quaternion * array5[num10];
			}
			Mesh mesh = new Mesh();
			mesh.name = "Capsule";
			mesh.vertices = array5;
			mesh.uv = array6;
			mesh.triangles = array7;
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();
			mesh.Optimize();
			return mesh;
		}

		public static void Circle(Vector3 position, float diameter, bool solid = false)
		{
			Circle(position, diameter, Vector3.up, solid);
		}

		public static void Circle(Vector3 position, float diameter, Vector3 normal, bool solid = false)
		{
			if (solid)
			{
				CircleSolid(position, diameter, normal);
			}
			else
			{
				CircleWire(position, diameter, normal);
			}
		}

		private static void CircleSolid(Vector3 position, float radius, Vector3 normal)
		{
			Mesh circleSolidMesh = GetCircleSolidMesh();
			Color color = Gizmos.color;
			Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);
			Gizmos.DrawMesh(circleSolidMesh, position, rotation, Vector3.one * radius);
			Gizmos.color = color;
		}

		private static void CircleWire(Vector3 position, float radius, Vector3 normal)
		{
			Vector3 vector = normal.normalized * radius;
			Vector3 rhs = Vector3.Slerp(vector, -vector, 0.5f);
			Vector3 vector2 = Vector3.Cross(vector, rhs).normalized * radius;
			Matrix4x4 matrix4x = new Matrix4x4
			{
				[0] = vector2.x,
				[1] = vector2.y,
				[2] = vector2.z,
				[4] = vector.x,
				[5] = vector.y,
				[6] = vector.z,
				[8] = rhs.x,
				[9] = rhs.y,
				[10] = rhs.z
			};
			Vector3 vector3 = position + matrix4x.MultiplyPoint3x4(Vector3.right);
			Vector3 vector4 = Vector3.zero;
			for (int i = 0; i < 91; i++)
			{
				vector4.x = Mathf.Cos((float)(i * 4) * (MathF.PI / 180f));
				vector4.z = Mathf.Sin((float)(i * 4) * (MathF.PI / 180f));
				vector4.y = 0f;
				vector4 = position + matrix4x.MultiplyPoint3x4(vector4);
				Gizmos.DrawLine(vector3, vector4);
				vector3 = vector4;
			}
		}

		private static Mesh GetCircleSolidMesh()
		{
			if (CIRCLE_SOLID != null)
			{
				return CIRCLE_SOLID;
			}
			List<Vector3> list = new List<Vector3>(92);
			int[] array = new int[270];
			float num = 0f;
			list.Add(Vector3.zero);
			for (int i = 1; i < 92; i++)
			{
				list.Add(new Vector3(Mathf.Cos(num), 0f, Mathf.Sin(num)));
				num -= MathF.PI / 45f;
				if (i > 1)
				{
					int num2 = (i - 2) * 3;
					array[num2] = 0;
					array[num2 + 1] = i - 1;
					array[num2 + 2] = i;
				}
			}
			Mesh mesh = new Mesh();
			mesh.SetVertices(list);
			mesh.SetIndices(array, MeshTopology.Triangles, 0);
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();
			CIRCLE_SOLID = mesh;
			return mesh;
		}

		public static void Cross(Vector3 position, CrossDirection direction, float radius)
		{
			Vector3 vector;
			Vector3 to;
			Vector3 vector2;
			Vector3 to2;
			switch (direction)
			{
			case CrossDirection.Forward:
				vector = position + Vector3.up * radius;
				to = position - Vector3.up * radius;
				vector2 = position + Vector3.right * radius;
				to2 = position - Vector3.right * radius;
				break;
			case CrossDirection.Upwards:
				vector = position + Vector3.forward * radius;
				to = position - Vector3.forward * radius;
				vector2 = position + Vector3.right * radius;
				to2 = position - Vector3.right * radius;
				break;
			case CrossDirection.Sidewards:
				vector = position + Vector3.forward * radius;
				to = position - Vector3.forward * radius;
				vector2 = position + Vector3.up * radius;
				to2 = position - Vector3.up * radius;
				break;
			default:
				throw new ArgumentOutOfRangeException("direction", direction, null);
			}
			Gizmos.DrawLine(vector, to);
			Gizmos.DrawLine(vector2, to2);
		}

		public static void Cylinder(Vector3 origin, float height, float radius)
		{
			Cylinder(origin, origin + Vector3.up * height, radius);
		}

		public static void Cylinder(Vector3 positionA, Vector3 positionB, float radius)
		{
			Vector3 vector = (positionB - positionA).normalized * radius;
			Vector3 vector2 = Vector3.Slerp(vector, -vector, 0.5f);
			Vector3 vector3 = Vector3.Cross(vector, vector2).normalized * radius;
			Circle(positionA, radius, vector);
			Circle(positionB, radius, -vector);
			Gizmos.DrawLine(positionA + vector3, positionB + vector3);
			Gizmos.DrawLine(positionA - vector3, positionB - vector3);
			Gizmos.DrawLine(positionA + vector2, positionB + vector2);
			Gizmos.DrawLine(positionA - vector2, positionB - vector2);
		}

		public static void Octahedron(Vector3 origin, Quaternion rotation, float radius, int subdivisions = 5)
		{
			Gizmos.DrawMesh(RequestOctahedron(subdivisions), origin, rotation, Vector3.one * radius);
		}

		public static void OctahedronWire(Vector3 origin, Quaternion rotation, float radius, int subdivisions = 5)
		{
			Gizmos.DrawWireMesh(RequestOctahedron(subdivisions), origin, rotation, Vector3.one * radius);
		}

		private static Mesh RequestOctahedron(int subdivisions)
		{
			subdivisions = Mathf.Clamp(subdivisions, 0, 6);
			if (OCTAHEDRON_MESHES[subdivisions] == null)
			{
				OCTAHEDRON_MESHES[subdivisions] = CreateOctahedron(subdivisions);
			}
			return OCTAHEDRON_MESHES[subdivisions];
		}

		private static Mesh CreateOctahedron(int subdivisions)
		{
			subdivisions = Mathf.Clamp(subdivisions, 0, 6);
			int num = 1 << subdivisions;
			Vector3[] array = new Vector3[(num + 1) * (num + 1) * 4 - (num * 2 - 1) * 3];
			int[] triangles = new int[(1 << subdivisions * 2 + 3) * 3];
			CreateOctahedronVertices(array, triangles, num);
			Vector3[] normals = new Vector3[array.Length];
			OctahedronNormalize(array, normals);
			return new Mesh
			{
				name = "Octahedron",
				vertices = array,
				normals = normals,
				triangles = triangles
			};
		}

		private static void CreateOctahedronVertices(Vector3[] vertices, int[] triangles, int resolution)
		{
			int num = 0;
			int num2 = 0;
			int t = 0;
			for (int i = 0; i < 4; i++)
			{
				vertices[num++] = Vector3.down;
			}
			for (int j = 1; j <= resolution; j++)
			{
				float t2 = (float)j / (float)resolution;
				Vector3 vector = (vertices[num++] = Vector3.Lerp(Vector3.down, Vector3.forward, t2));
				for (int k = 0; k < 4; k++)
				{
					Vector3 vector2 = vector;
					vector = Vector3.Lerp(Vector3.down, DIRECTIONS[k], t2);
					t = CreateOctahedronLowerStrip(j, num, num2, t, triangles);
					num = CreateOctahedronVertexLine(vector2, vector, j, num, vertices);
					num2 += ((j <= 1) ? 1 : (j - 1));
				}
				num2 = num - 1 - j * 4;
			}
			for (int num3 = resolution - 1; num3 >= 1; num3--)
			{
				float t3 = (float)num3 / (float)resolution;
				Vector3 vector3 = (vertices[num++] = Vector3.Lerp(Vector3.up, Vector3.forward, t3));
				for (int l = 0; l < 4; l++)
				{
					Vector3 vector4 = vector3;
					vector3 = Vector3.Lerp(Vector3.up, DIRECTIONS[l], t3);
					t = CreateOctahedronUpperStrip(num3, num, num2, t, triangles);
					num = CreateOctahedronVertexLine(vector4, vector3, num3, num, vertices);
					num2 += num3 + 1;
				}
				num2 = num - 1 - num3 * 4;
			}
			for (int m = 0; m < 4; m++)
			{
				triangles[t++] = num2;
				triangles[t++] = num;
				num2 = (triangles[t++] = num2 + 1);
				vertices[num++] = Vector3.up;
			}
		}

		private static int CreateOctahedronVertexLine(Vector3 from, Vector3 to, int steps, int v, Vector3[] vertices)
		{
			for (int i = 1; i <= steps; i++)
			{
				vertices[v++] = Vector3.Lerp(from, to, (float)i / (float)steps);
			}
			return v;
		}

		private static int CreateOctahedronLowerStrip(int steps, int vTop, int vBottom, int t, int[] triangles)
		{
			for (int i = 1; i < steps; i++)
			{
				triangles[t++] = vBottom;
				triangles[t++] = vTop - 1;
				triangles[t++] = vTop;
				triangles[t++] = vBottom++;
				triangles[t++] = vTop++;
				triangles[t++] = vBottom;
			}
			triangles[t++] = vBottom;
			triangles[t++] = vTop - 1;
			triangles[t++] = vTop;
			return t;
		}

		private static int CreateOctahedronUpperStrip(int steps, int vTop, int vBottom, int t, int[] triangles)
		{
			triangles[t++] = vBottom;
			triangles[t++] = vTop - 1;
			triangles[t++] = ++vBottom;
			for (int i = 1; i <= steps; i++)
			{
				triangles[t++] = vTop - 1;
				triangles[t++] = vTop;
				triangles[t++] = vBottom;
				triangles[t++] = vBottom;
				triangles[t++] = vTop++;
				triangles[t++] = ++vBottom;
			}
			return t;
		}

		private static void OctahedronNormalize(Vector3[] vertices, Vector3[] normals)
		{
			for (int i = 0; i < vertices.Length; i++)
			{
				normals[i] = (vertices[i] = vertices[i].normalized);
			}
		}

		public static void Triangle(Vector3 position, Vector3 direction, float size = 1f)
		{
			Quaternion rotation = Quaternion.LookRotation(direction);
			Triangle(position, rotation, size);
		}

		public static void Triangle(Vector3 position, Quaternion rotation, float size = 1f)
		{
			for (int i = 1; i < TRIANGLE_VERTICES.Length; i++)
			{
				Gizmos.DrawLine(position + rotation * TRIANGLE_VERTICES[i] * size, position + rotation * TRIANGLE_VERTICES[i - 1] * size);
			}
		}

		public static void Vision(Vector3 position, Quaternion rotation, float angle, float radius, float height)
		{
			Mesh visionMesh = GetVisionMesh(angle, radius, height);
			Color color = Gizmos.color;
			Gizmos.DrawMesh(visionMesh, position, rotation, Vector3.one);
			Gizmos.color = color;
		}

		private static Mesh GetVisionMesh(float angle, float radius, float height)
		{
			int num = Mathf.CeilToInt(angle / 10f);
			int num2 = (num + 2) * 2;
			int num3 = num * 3 * 2 + 12 + num * 6;
			Mesh mesh = new Mesh
			{
				vertices = new Vector3[num2],
				triangles = new int[num3]
			};
			Vector3[] array = new Vector3[num2];
			Vector2[] array2 = new Vector2[num2];
			Vector3[] array3 = new Vector3[num2];
			int[] array4 = new int[num3];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = new Vector2(0f, 0f);
			}
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = new Vector3(0f, 1f, 0f);
			}
			mesh.uv = array2;
			mesh.normals = array;
			float num4 = MathF.PI / 180f * angle;
			int num5 = num + 2;
			int num6 = num * 3;
			array3[0] = new Vector3(0f, (0f - height) * 0.5f, 0f);
			array3[num5] = new Vector3(0f, height * 0.5f, 0f);
			for (int k = 0; k <= num; k++)
			{
				float f = (float)k / (float)num * num4;
				array3[k + 1] = new Vector3(Mathf.Sin(f) * radius, (0f - height) * 0.5f, Mathf.Cos(f) * radius);
				array3[num5 + k + 1] = new Vector3(Mathf.Sin(f) * radius, height * 0.5f, Mathf.Cos(f) * radius);
				if (k != 0)
				{
					array4[(k - 1) * 3] = 0;
					array4[(k - 1) * 3 + 1] = k + 1;
					array4[(k - 1) * 3 + 2] = k;
					array4[num6 + (k - 1) * 3] = num5;
					array4[num6 + (k - 1) * 3 + 1] = num5 + k;
					array4[num6 + (k - 1) * 3 + 2] = num5 + k + 1;
				}
			}
			array4[num3 - num * 6 - 12] = 0;
			array4[num3 - num * 6 - 11] = 1;
			array4[num3 - num * 6 - 10] = num5 + 1;
			array4[num3 - num * 6 - 9] = num5;
			array4[num3 - num * 6 - 8] = 0;
			array4[num3 - num * 6 - 7] = num5 + 1;
			array4[num3 - num * 6 - 6] = 0;
			array4[num3 - num * 6 - 5] = num5;
			array4[num3 - num * 6 - 4] = num5 - 1;
			array4[num3 - num * 6 - 3] = num5;
			array4[num3 - num * 6 - 2] = num5 + num5 - 1;
			array4[num3 - num * 6 - 1] = num5 - 1;
			for (int l = 0; l < num; l++)
			{
				array4[num3 - (l * 6 + 1)] = l + 1;
				array4[num3 - (l * 6 + 2)] = num5 + l + 1;
				array4[num3 - (l * 6 + 3)] = l + 2;
				array4[num3 - (l * 6 + 4)] = l + 2;
				array4[num3 - (l * 6 + 5)] = num5 + l + 1;
				array4[num3 - (l * 6 + 6)] = num5 + l + 2;
			}
			mesh.vertices = array3;
			mesh.triangles = array4;
			return mesh;
		}
	}
}
