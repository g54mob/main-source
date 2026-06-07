using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;

namespace MeshXtensions
{
	public static class MeshX
	{
		private static MethodInfo getBuiltinExtraResourcesMethod;

		public static Mesh Cube()
		{
			return Cube(Vector3.one);
		}

		public static Mesh Cube(Vector3 size, float uvScale = 1f, int uvTiles = 1, float uvOffsetX = 0f, float uvOffsetY = 0f, float uvOffsetZ = 0f)
		{
			Mesh mesh = new Mesh();
			mesh.Clear();
			Vector3 vector = new Vector3((0f - size.x) * 0.5f, (0f - size.y) * 0.5f, size.z * 0.5f);
			Vector3 vector2 = new Vector3(size.x * 0.5f, (0f - size.y) * 0.5f, size.z * 0.5f);
			Vector3 vector3 = new Vector3(size.x * 0.5f, (0f - size.y) * 0.5f, (0f - size.z) * 0.5f);
			Vector3 vector4 = new Vector3((0f - size.x) * 0.5f, (0f - size.y) * 0.5f, (0f - size.z) * 0.5f);
			Vector3 vector5 = new Vector3((0f - size.x) * 0.5f, size.y * 0.5f, size.z * 0.5f);
			Vector3 vector6 = new Vector3(size.x * 0.5f, size.y * 0.5f, size.z * 0.5f);
			Vector3 vector7 = new Vector3(size.x * 0.5f, size.y * 0.5f, (0f - size.z) * 0.5f);
			Vector3 vector8 = new Vector3((0f - size.x) * 0.5f, size.y * 0.5f, (0f - size.z) * 0.5f);
			Vector3[] array = new Vector3[24]
			{
				vector, vector2, vector3, vector4, vector8, vector5, vector, vector4, vector5, vector6,
				vector2, vector, vector7, vector8, vector4, vector3, vector6, vector7, vector3, vector2,
				vector8, vector7, vector6, vector5
			};
			Vector3 up = Vector3.up;
			Vector3 down = Vector3.down;
			Vector3 forward = Vector3.forward;
			Vector3 back = Vector3.back;
			Vector3 left = Vector3.left;
			Vector3 right = Vector3.right;
			Vector3[] normals = new Vector3[24]
			{
				down, down, down, down, left, left, left, left, forward, forward,
				forward, forward, back, back, back, back, right, right, right, right,
				up, up, up, up
			};
			Vector2[] uv = NormalProjection(uvOffset: new Vector3(uvOffsetX, uvOffsetY, uvOffsetZ), vertices: RoundToSubV3(array, uvTiles, uvScale), normals: normals);
			int[] triangles = new int[36]
			{
				3, 1, 0, 3, 2, 1, 7, 5, 4, 7,
				6, 5, 11, 9, 8, 11, 10, 9, 15, 13,
				12, 15, 14, 13, 19, 17, 16, 19, 18, 17,
				23, 21, 20, 23, 22, 21
			};
			mesh.vertices = array;
			mesh.normals = normals;
			mesh.uv = uv;
			mesh.triangles = triangles;
			mesh.RecalculateBounds();
			return mesh;
		}

		public static Mesh IsoSphere(float radius, int recursionLevel = 3)
		{
			List<Vector3> vertices = new List<Vector3>();
			Dictionary<long, int> cache = new Dictionary<long, int>();
			float num = (1f + Mathf.Sqrt(5f)) / 2f;
			vertices.Add(new Vector3(-1f, num, 0f).normalized * radius);
			vertices.Add(new Vector3(1f, num, 0f).normalized * radius);
			vertices.Add(new Vector3(-1f, 0f - num, 0f).normalized * radius);
			vertices.Add(new Vector3(1f, 0f - num, 0f).normalized * radius);
			vertices.Add(new Vector3(0f, -1f, num).normalized * radius);
			vertices.Add(new Vector3(0f, 1f, num).normalized * radius);
			vertices.Add(new Vector3(0f, -1f, 0f - num).normalized * radius);
			vertices.Add(new Vector3(0f, 1f, 0f - num).normalized * radius);
			vertices.Add(new Vector3(num, 0f, -1f).normalized * radius);
			vertices.Add(new Vector3(num, 0f, 1f).normalized * radius);
			vertices.Add(new Vector3(0f - num, 0f, -1f).normalized * radius);
			vertices.Add(new Vector3(0f - num, 0f, 1f).normalized * radius);
			List<Triangle> list = new List<Triangle>();
			list.Add(new Triangle(0, 11, 5));
			list.Add(new Triangle(0, 5, 1));
			list.Add(new Triangle(0, 1, 7));
			list.Add(new Triangle(0, 7, 10));
			list.Add(new Triangle(0, 10, 11));
			list.Add(new Triangle(1, 5, 9));
			list.Add(new Triangle(5, 11, 4));
			list.Add(new Triangle(11, 10, 2));
			list.Add(new Triangle(10, 7, 6));
			list.Add(new Triangle(7, 1, 8));
			list.Add(new Triangle(3, 9, 4));
			list.Add(new Triangle(3, 4, 2));
			list.Add(new Triangle(3, 2, 6));
			list.Add(new Triangle(3, 6, 8));
			list.Add(new Triangle(3, 8, 9));
			list.Add(new Triangle(4, 9, 5));
			list.Add(new Triangle(2, 4, 11));
			list.Add(new Triangle(6, 2, 10));
			list.Add(new Triangle(8, 6, 7));
			list.Add(new Triangle(9, 8, 1));
			for (int i = 0; i < recursionLevel; i++)
			{
				List<Triangle> list2 = new List<Triangle>();
				foreach (Triangle item in list)
				{
					int middlePoint = getMiddlePoint(item.v1, item.v2, ref vertices, ref cache, radius);
					int middlePoint2 = getMiddlePoint(item.v2, item.v3, ref vertices, ref cache, radius);
					int middlePoint3 = getMiddlePoint(item.v3, item.v1, ref vertices, ref cache, radius);
					list2.Add(new Triangle(item.v1, middlePoint, middlePoint3));
					list2.Add(new Triangle(item.v2, middlePoint2, middlePoint));
					list2.Add(new Triangle(item.v3, middlePoint3, middlePoint2));
					list2.Add(new Triangle(middlePoint, middlePoint2, middlePoint3));
				}
				list = list2;
			}
			Mesh mesh = new Mesh();
			mesh.vertices = vertices.ToArray();
			List<int> list3 = new List<int>();
			for (int j = 0; j < list.Count; j++)
			{
				list3.Add(list[j].v1);
				list3.Add(list[j].v2);
				list3.Add(list[j].v3);
			}
			mesh.triangles = list3.ToArray();
			mesh.uv = new Vector2[vertices.Count];
			Vector3[] array = new Vector3[vertices.Count];
			for (int k = 0; k < array.Length; k++)
			{
				array[k] = vertices[k].normalized;
			}
			mesh.normals = array;
			mesh.RecalculateBounds();
			return mesh;
		}

		public static Mesh Cylinder(float height, float radius, int segments = 18)
		{
			return Cone(height, radius, radius, segments);
		}

		public static Mesh Cone(float height, float bottomRadius, float topRadius = 1f, int segments = 18)
		{
			int num = 1;
			int num2 = segments + 1;
			Vector3[] array = new Vector3[num2 + num2 + segments * num * 2 + 2];
			int i = 0;
			float num3 = (float)Math.PI * 2f;
			array[i++] = new Vector3(0f, 0f, 0f);
			for (; i <= segments; i++)
			{
				float f = (float)i / (float)segments * num3;
				array[i] = new Vector3(Mathf.Cos(f) * bottomRadius, 0f, Mathf.Sin(f) * bottomRadius);
			}
			array[i++] = new Vector3(0f, height, 0f);
			for (; i <= segments * 2 + 1; i++)
			{
				float f2 = (float)(i - segments - 1) / (float)segments * num3;
				array[i] = new Vector3(Mathf.Cos(f2) * topRadius, height, Mathf.Sin(f2) * topRadius);
			}
			int num4 = 0;
			while (i <= array.Length - 4)
			{
				float f3 = (float)num4 / (float)segments * num3;
				array[i] = new Vector3(Mathf.Cos(f3) * topRadius, height, Mathf.Sin(f3) * topRadius);
				array[i + 1] = new Vector3(Mathf.Cos(f3) * bottomRadius, 0f, Mathf.Sin(f3) * bottomRadius);
				i += 2;
				num4++;
			}
			array[i] = array[segments * 2 + 2];
			array[i + 1] = array[segments * 2 + 3];
			Vector3[] array2 = new Vector3[array.Length];
			i = 0;
			while (i <= segments)
			{
				array2[i++] = Vector3.down;
			}
			while (i <= segments * 2 + 1)
			{
				array2[i++] = Vector3.up;
			}
			num4 = 0;
			while (i <= array.Length - 4)
			{
				float f4 = (float)num4 / (float)segments * num3;
				float x = Mathf.Cos(f4);
				float z = Mathf.Sin(f4);
				array2[i] = new Vector3(x, 0f, z);
				array2[i + 1] = array2[i];
				i += 2;
				num4++;
			}
			array2[i] = array2[segments * 2 + 2];
			array2[i + 1] = array2[segments * 2 + 3];
			Vector2[] array3 = new Vector2[array.Length];
			int j = 0;
			array3[j++] = new Vector2(0.5f, 0.5f);
			for (; j <= segments; j++)
			{
				float f5 = (float)j / (float)segments * num3;
				array3[j] = new Vector2(Mathf.Cos(f5) * 0.5f + 0.5f, Mathf.Sin(f5) * 0.5f + 0.5f);
			}
			array3[j++] = new Vector2(0.5f, 0.5f);
			for (; j <= segments * 2 + 1; j++)
			{
				float f6 = (float)j / (float)segments * num3;
				array3[j] = new Vector2(Mathf.Cos(f6) * 0.5f + 0.5f, Mathf.Sin(f6) * 0.5f + 0.5f);
			}
			int num5 = 0;
			while (j <= array3.Length - 4)
			{
				float x2 = (float)num5 / (float)segments;
				array3[j] = new Vector3(x2, 1f);
				array3[j + 1] = new Vector3(x2, 0f);
				j += 2;
				num5++;
			}
			array3[j] = new Vector2(1f, 1f);
			array3[j + 1] = new Vector2(1f, 0f);
			int num6 = segments + segments + segments * 2;
			int[] array4 = new int[num6 * 3 + 3];
			int num7 = 0;
			int num8 = 0;
			while (num7 < segments - 1)
			{
				array4[num8] = 0;
				array4[num8 + 1] = num7 + 1;
				array4[num8 + 2] = num7 + 2;
				num7++;
				num8 += 3;
			}
			array4[num8] = 0;
			array4[num8 + 1] = num7 + 1;
			array4[num8 + 2] = 1;
			num7++;
			num8 += 3;
			while (num7 < segments * 2)
			{
				array4[num8] = num7 + 2;
				array4[num8 + 1] = num7 + 1;
				array4[num8 + 2] = num2;
				num7++;
				num8 += 3;
			}
			array4[num8] = num2 + 1;
			array4[num8 + 1] = num7 + 1;
			array4[num8 + 2] = num2;
			num7++;
			num8 += 3;
			num7++;
			while (num7 <= num6)
			{
				array4[num8] = num7 + 2;
				array4[num8 + 1] = num7 + 1;
				array4[num8 + 2] = num7;
				num7++;
				num8 += 3;
				array4[num8] = num7 + 1;
				array4[num8 + 1] = num7 + 2;
				array4[num8 + 2] = num7;
				num7++;
				num8 += 3;
			}
			Mesh mesh = new Mesh();
			mesh.vertices = array;
			mesh.normals = array2;
			mesh.uv = array3;
			mesh.triangles = array4;
			mesh.RecalculateBounds();
			return mesh;
		}

		public static Mesh Prism(float height, float baseRadius, int sides = 3)
		{
			return Frustum(height, baseRadius, baseRadius, sides);
		}

		public static Mesh Frustum(float height, float baseRadius, float topRadius, int sides = 3)
		{
			throw new NotImplementedException();
		}

		public static Mesh Sweep(Vector2[] shapePoints, Vector3[] pathPoints, float uvPathScale = 1f, UVType uvPath = UVType.DistanceTiled, UVType uvShape = UVType.Equidistant, float uvShapeScale = 1f)
		{
			return Sweep(shapePoints, pathPoints, null, uvPathScale, uvPath, uvShape, uvShapeScale);
		}

		public static Vector3[] GetPathAutoTangents(Vector3[] pathPoints)
		{
			Vector3[] array = new Vector3[pathPoints.Length];
			for (int i = 0; i < pathPoints.Length; i++)
			{
				if (i < pathPoints.Length - 1)
				{
					array[i] = pathPoints[i + 1] - pathPoints[i];
				}
				else
				{
					array[i] = array[array.Length - 2];
				}
			}
			return array;
		}

		public static Mesh Sweep(Vector2[] shapePoints, Vector3[] pathPoints, Vector3[] pathTangents, float uvPathScale = 1f, UVType uvPath = UVType.DistanceTiled, UVType uvShape = UVType.Equidistant, float uvShapeScale = 1f, Vector3[] pathUps = null)
		{
			if (pathUps == null)
			{
				pathUps = new Vector3[pathPoints.Length];
				for (int i = 0; i < pathUps.Length; i++)
				{
					pathUps[i] = Vector3.up;
				}
			}
			Vector3[] array = new Vector3[shapePoints.Length * pathPoints.Length];
			Vector3[] array2 = new Vector3[array.Length];
			Vector2[] array3 = new Vector2[array.Length];
			Vector4[] array4 = new Vector4[array.Length];
			List<Triangle> list = new List<Triangle>();
			Vector3 zero = Vector3.zero;
			if (pathTangents == null || pathTangents.Length != pathPoints.Length)
			{
				pathTangents = GetPathAutoTangents(pathPoints);
			}
			float[] array5 = new float[shapePoints.Length - 1];
			float num = 0f;
			for (int j = 0; j < array5.Length; j++)
			{
				num = (array5[j] = num + Vector2.Distance(shapePoints[j], shapePoints[j + 1]));
			}
			float num2 = 0f;
			float num3 = 0f;
			if (uvPath == UVType.Equidistant)
			{
				for (int k = 0; k < pathPoints.Length; k++)
				{
					if (k != 0)
					{
						num2 += Vector3.Distance(pathPoints[k], pathPoints[k - 1]);
					}
				}
			}
			for (int l = 0; l < pathPoints.Length; l++)
			{
				zero = pathTangents[l];
				Vector3 vector = pathUps[l];
				Vector3 vector2 = -Vector3.Cross(zero.normalized, vector);
				Vector3 vector3 = pathPoints[l];
				float y = 0f;
				switch (uvPath)
				{
				case UVType.DistanceTiled:
					if (l != 0)
					{
						num3 += Vector3.Distance(pathPoints[l], pathPoints[l - 1]);
						y = num3 * uvPathScale;
					}
					break;
				case UVType.SegmentBased:
					y = (float)l * uvPathScale;
					break;
				case UVType.Equidistant:
					if (num2 != 0f && l != 0)
					{
						num3 += Vector3.Distance(pathPoints[l], pathPoints[l - 1]);
						y = num3 / num2 * uvPathScale;
					}
					break;
				}
				for (int m = 0; m < shapePoints.Length; m++)
				{
					int num4 = l * shapePoints.Length + m;
					array[num4] = vector3 + vector2 * shapePoints[m].x + vector * shapePoints[m].y;
					array2[num4] = Vector3.up;
					array4[num4] = vector2;
					float x = 0f;
					switch (uvShape)
					{
					case UVType.DistanceTiled:
						x = ((m == 0) ? 0f : (array5[m - 1] * uvShapeScale));
						break;
					case UVType.SegmentBased:
						x = (float)m / ((float)shapePoints.Length - 1f);
						break;
					case UVType.Equidistant:
						if (num != 0f && m != 0)
						{
							x = array5[m - 1] / num * uvShapeScale;
						}
						break;
					}
					array3[num4] = new Vector2(x, y);
					if (l > 0 && m > 0)
					{
						int num5 = num4 - shapePoints.Length;
						list.Add(new Triangle(num5 - 1, num4 - 1, num5));
						list.Add(new Triangle(num5, num4 - 1, num4));
					}
				}
			}
			Mesh mesh = NewMesh(array, array2, array3, list.ToArray());
			mesh.RecalculateNormals();
			mesh.tangents = array4;
			return mesh;
		}

		public static Mesh SweepShapeBlend(CrossSection[] crossSections, Vector3[] pathPoints, Vector3[] pathTangents, float uvPathScale = 1f, UVType uvPath = UVType.DistanceTiled, UVType uvShape = UVType.Equidistant, float uvShapeScale = 1f, Vector3[] pathUps = null)
		{
			if (crossSections == null)
			{
				return null;
			}
			int num = crossSections[0].points.Length;
			for (int i = 0; i < crossSections.Length; i++)
			{
				if (crossSections[i].points.Length != num)
				{
					Debug.LogError("Trying to blend shapes that don't have the same number of vertices");
					return null;
				}
			}
			if (pathUps == null)
			{
				pathUps = new Vector3[pathPoints.Length];
				for (int j = 0; j < pathUps.Length; j++)
				{
					pathUps[j] = Vector3.up;
				}
			}
			Vector3[] array = new Vector3[num * pathPoints.Length];
			Vector3[] array2 = new Vector3[array.Length];
			Vector2[] array3 = new Vector2[array.Length];
			Vector4[] array4 = new Vector4[array.Length];
			List<Triangle> list = new List<Triangle>();
			Vector3 vector = Vector3.zero;
			float[] array5 = new float[num - 1];
			float num2 = 0f;
			for (int k = 0; k < array5.Length; k++)
			{
				num2 = (array5[k] = num2 + Vector2.Distance(crossSections[0].points[k], crossSections[0].points[k + 1]));
			}
			float num3 = 0f;
			float num4 = 0f;
			if (uvPath == UVType.Equidistant)
			{
				for (int l = 0; l < pathPoints.Length; l++)
				{
					if (l != 0)
					{
						num3 += Vector3.Distance(pathPoints[l], pathPoints[l - 1]);
					}
				}
			}
			CrossSection crossSection = crossSections[0];
			CrossSection crossSection2 = crossSections[1];
			int num5 = 1;
			for (int m = 0; m < pathPoints.Length; m++)
			{
				if (m == crossSection2.atIndex)
				{
					num5++;
					crossSection = crossSection2;
					crossSection2 = crossSections[num5];
				}
				float t = (float)(m - crossSection.atIndex) / (float)(crossSection2.atIndex - crossSection.atIndex);
				if (pathTangents != null && pathTangents.Length == pathPoints.Length)
				{
					vector = pathTangents[m];
				}
				else if (m < pathPoints.Length - 1)
				{
					vector = pathPoints[m + 1] - pathPoints[m];
				}
				Vector3 vector2 = pathUps[m];
				Vector3 vector3 = -Vector3.Cross(vector.normalized, vector2);
				Vector3 vector4 = pathPoints[m];
				float y = 0f;
				switch (uvPath)
				{
				case UVType.DistanceTiled:
					if (m != 0)
					{
						num4 += Vector3.Distance(pathPoints[m], pathPoints[m - 1]);
						y = num4 * uvPathScale;
					}
					break;
				case UVType.SegmentBased:
					y = (float)m * uvPathScale;
					break;
				case UVType.Equidistant:
					if (num3 != 0f && m != 0)
					{
						num4 += Vector3.Distance(pathPoints[m], pathPoints[m - 1]);
						y = num4 / num3 * uvPathScale;
					}
					break;
				}
				for (int n = 0; n < num; n++)
				{
					Vector2 vector5 = Vector2.Lerp(crossSection.points[n], crossSection2.points[n], t);
					int num6 = m * num + n;
					array[num6] = vector4 + vector3 * vector5.x + vector2 * vector5.y;
					array2[num6] = Vector3.up;
					array4[num6] = vector3;
					float x = 0f;
					switch (uvShape)
					{
					case UVType.DistanceTiled:
						x = ((n == 0) ? 0f : (array5[n - 1] * uvShapeScale));
						break;
					case UVType.SegmentBased:
						x = (float)n / ((float)num - 1f);
						break;
					case UVType.Equidistant:
						if (num2 != 0f && n != 0)
						{
							x = array5[n - 1] / num2 * uvShapeScale;
						}
						break;
					}
					array3[num6] = new Vector2(x, y);
					if (m > 0 && n > 0)
					{
						int num7 = num6 - num;
						list.Add(new Triangle(num7 - 1, num6 - 1, num7));
						list.Add(new Triangle(num7, num6 - 1, num6));
					}
				}
			}
			Mesh mesh = NewMesh(array, array2, array3, list.ToArray());
			mesh.RecalculateNormals();
			mesh.tangents = array4;
			return mesh;
		}

		public static Mesh Quadstrip(Vector3[] points, Vector3[] normals, float width, float uvScale = 1f)
		{
			if (points.Length < 2)
			{
				return null;
			}
			Vector3[] array = new Vector3[points.Length * 2];
			Vector3[] array2 = new Vector3[points.Length * 2];
			Vector2[] array3 = new Vector2[points.Length * 2];
			Triangle[] array4 = new Triangle[points.Length * 2];
			Vector3 vector = Vector3.zero;
			for (int i = 0; i < points.Length; i++)
			{
				if (i != points.Length - 1)
				{
					vector = points[i + 1] - points[i];
				}
				Vector3 vector2 = Vector3.Cross(vector.normalized, normals[i]);
				Vector3 vector3 = points[i] + vector2 * (width * 0.5f);
				Vector3 vector4 = points[i] + vector2 * (0f - width * 0.5f);
				array[i * 2] = vector3;
				array[i * 2 + 1] = vector4;
				array2[i * 2] = (array2[i * 2 + 1] = normals[i]);
				array3[i * 2] = new Vector2(0f, (float)i * uvScale);
				array3[i * 2 + 1] = new Vector2(1f, (float)i * uvScale);
				if (i != 0)
				{
					int num = i * 2;
					array4[i * 2] = new Triangle(num - 2, num, num - 1);
					array4[i * 2 + 1] = new Triangle(num - 1, num, num + 1);
				}
			}
			return NewMesh(array, array2, array3, array4);
		}

		private static Mesh NewMesh(Vector3[] vertices, Vector3[] normals, Vector2[] uvs, Triangle[] triangles)
		{
			int[] tris = Triangle.ToIntArray(triangles);
			return NewMesh(vertices, normals, uvs, tris);
		}

		private static Mesh NewMesh(Vector3[] vertices, Vector3[] normals, Vector2[] uvs, int[] tris)
		{
			Mesh mesh = new Mesh();
			if (vertices.Length >= 65535)
			{
				Debug.LogWarning($"Number of vertices is {vertices.Length}, mesh will use 32-bit indices");
				mesh.indexFormat = IndexFormat.UInt32;
			}
			mesh.vertices = vertices;
			mesh.normals = normals;
			mesh.uv = uvs;
			mesh.triangles = tris;
			return mesh;
		}

		public static Mesh GetCube(Vector3 rootPos, float length, float width, float height, bool bottomPivot, int subTiles, float uvScale)
		{
			Mesh mesh = new Mesh();
			mesh.Clear();
			Vector3 vector = rootPos + new Vector3((0f - length) * 0.5f, (0f - height) * 0.5f, width * 0.5f);
			Vector3 vector2 = rootPos + new Vector3(length * 0.5f, (0f - height) * 0.5f, width * 0.5f);
			Vector3 vector3 = rootPos + new Vector3(length * 0.5f, (0f - height) * 0.5f, (0f - width) * 0.5f);
			Vector3 vector4 = rootPos + new Vector3((0f - length) * 0.5f, (0f - height) * 0.5f, (0f - width) * 0.5f);
			Vector3 vector5 = rootPos + new Vector3((0f - length) * 0.5f, height * 0.5f, width * 0.5f);
			Vector3 vector6 = rootPos + new Vector3(length * 0.5f, height * 0.5f, width * 0.5f);
			Vector3 vector7 = rootPos + new Vector3(length * 0.5f, height * 0.5f, (0f - width) * 0.5f);
			Vector3 vector8 = rootPos + new Vector3((0f - length) * 0.5f, height * 0.5f, (0f - width) * 0.5f);
			Vector3[] array = new Vector3[24]
			{
				vector, vector2, vector3, vector4, vector8, vector5, vector, vector4, vector5, vector6,
				vector2, vector, vector7, vector8, vector4, vector3, vector6, vector7, vector3, vector2,
				vector8, vector7, vector6, vector5
			};
			if (bottomPivot)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] += Vector3.up * (height / 2f);
				}
			}
			Vector3 up = Vector3.up;
			Vector3 down = Vector3.down;
			Vector3 forward = Vector3.forward;
			Vector3 back = Vector3.back;
			Vector3 left = Vector3.left;
			Vector3 right = Vector3.right;
			Vector3[] normals = new Vector3[24]
			{
				down, down, down, down, left, left, left, left, forward, forward,
				forward, forward, back, back, back, back, right, right, right, right,
				up, up, up, up
			};
			Vector2[] uv = NormalProjection(RoundToSubV3(array, subTiles, uvScale), normals);
			int[] triangles = new int[36]
			{
				3, 1, 0, 3, 2, 1, 7, 5, 4, 7,
				6, 5, 11, 9, 8, 11, 10, 9, 15, 13,
				12, 15, 14, 13, 19, 17, 16, 19, 18, 17,
				23, 21, 20, 23, 22, 21
			};
			mesh.vertices = array;
			mesh.normals = normals;
			mesh.uv = uv;
			mesh.triangles = triangles;
			mesh.RecalculateBounds();
			return mesh;
		}

		public static Mesh GetCubeTest(Vector3 rootPos, float length, float width, float height, bool bottomPivot, int subTiles, float uvScale)
		{
			Mesh mesh = new Mesh();
			mesh.Clear();
			Vector3 vector = rootPos + new Vector3((0f - length) * 0.5f, (0f - height) * 0.5f, width * 0.5f);
			Vector3 vector2 = rootPos + new Vector3(length * 0.5f, (0f - height) * 0.5f, width * 0.5f);
			Vector3 vector3 = rootPos + new Vector3(length * 0.5f, (0f - height) * 0.5f, (0f - width) * 0.5f);
			Vector3 vector4 = rootPos + new Vector3((0f - length) * 0.5f, (0f - height) * 0.5f, (0f - width) * 0.5f);
			Vector3 vector5 = rootPos + new Vector3((0f - length) * 0.5f, height * 0.5f, width * 0.5f);
			Vector3 vector6 = rootPos + new Vector3(length * 0.5f, height * 0.5f, width * 0.5f);
			Vector3 vector7 = rootPos + new Vector3(length * 0.5f, height * 0.5f, (0f - width) * 0.5f);
			Vector3 vector8 = rootPos + new Vector3((0f - length) * 0.5f, height * 0.5f, (0f - width) * 0.5f);
			Vector3[] array = new Vector3[24]
			{
				vector, vector2, vector3, vector4, vector8, vector5, vector, vector4, vector5, vector6,
				vector2, vector, vector7, vector8, vector4, vector3, vector6, vector7, vector3, vector2,
				vector8, vector7, vector6, vector5
			};
			if (bottomPivot)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] += Vector3.up * (height / 2f);
				}
			}
			Vector3 up = Vector3.up;
			Vector3 down = Vector3.down;
			Vector3 forward = Vector3.forward;
			Vector3 back = Vector3.back;
			Vector3 left = Vector3.left;
			Vector3 right = Vector3.right;
			Vector3[] normals = new Vector3[24]
			{
				down, down, down, down, left, left, left, left, forward, forward,
				forward, forward, back, back, back, back, right, right, right, right,
				up, up, up, up
			};
			Vector2[] uv = NormalProjection(RoundToSubV3(array, subTiles, uvScale), normals);
			int[] triangles = new int[6] { 11, 9, 8, 11, 10, 9 };
			mesh.vertices = array;
			mesh.normals = normals;
			mesh.uv = uv;
			mesh.triangles = triangles;
			mesh.RecalculateBounds();
			return mesh;
		}

		public static Mesh DrawQuad(Vector3 rootPos, float width, float height, Vector3 normalDir, bool bottomPivot, int subTiles, float uvScale)
		{
			return DrawQuad(rootPos, width, height, normalDir, 0f, bottomPivot, subTiles, uvScale);
		}

		public static Mesh DrawQuad(Vector3 rootPos, float width, float height, Vector3 normalDir, float deviateNormal, bool bottomPivot, int subTiles, float uvScale)
		{
			Mesh mesh = new Mesh();
			mesh.Clear();
			Vector3 vector = new Vector3((0f - width) * 0.5f, height * 0.5f);
			Vector3 vector2 = new Vector3(width * 0.5f, height * 0.5f);
			Vector3 vector3 = new Vector3((0f - width) * 0.5f, (0f - height) * 0.5f);
			Vector3 vector4 = new Vector3(width * 0.5f, (0f - height) * 0.5f);
			Vector3[] vertices = new Vector3[4] { vector, vector2, vector3, vector4 };
			vertices = FromToDirVertices(vertices, normalDir);
			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] += rootPos;
				if (bottomPivot)
				{
					vertices[i] += Vector3.up * (height / 2f);
				}
			}
			Vector3[] array = new Vector3[4];
			Vector3 vector5 = normalDir;
			if (deviateNormal != 0f)
			{
				vector5 = DeviateDir(vector5, deviateNormal);
			}
			for (int j = 0; j < 4; j++)
			{
				array[j] = vector5;
			}
			Vector2[] uv = NormalProjection(RoundToSubV3(vertices, subTiles, uvScale), array);
			int[] triangles = new int[6] { 2, 1, 0, 2, 3, 1 };
			mesh.vertices = vertices;
			mesh.normals = array;
			mesh.uv = uv;
			mesh.triangles = triangles;
			mesh.RecalculateBounds();
			return mesh;
		}

		public static CombineInstance GetBlockInstance(Mesh m, int index = 0, bool destroyImmediate = false)
		{
			CombineInstance result = new CombineInstance
			{
				mesh = m,
				transform = Matrix4x4.identity,
				subMeshIndex = index
			};
			if (!destroyImmediate)
			{
				UnityEngine.Object.Destroy(m);
			}
			return result;
		}

		public static Mesh Combine(Mesh[] meshes, bool recalculateBounds = true, bool destroyImmediate = false)
		{
			CombineInstance[] array = new CombineInstance[meshes.Length];
			for (int i = 0; i < meshes.Length; i++)
			{
				array[i] = meshes[i].GetCombineInstance(0, destroyMesh: false);
			}
			Mesh mesh = new Mesh();
			int num = meshes.Sum((Mesh mesh2) => mesh2.vertices.Length);
			if (num >= 65535)
			{
				Debug.LogWarning($"Number of vertices is {num}, combined mesh will use 32-bit indices");
				mesh.indexFormat = IndexFormat.UInt32;
			}
			mesh.CombineMeshes(array, mergeSubMeshes: true);
			for (int num2 = 0; num2 < meshes.Length; num2++)
			{
				if (destroyImmediate)
				{
					UnityEngine.Object.DestroyImmediate(meshes[num2]);
				}
				else
				{
					UnityEngine.Object.Destroy(meshes[num2]);
				}
			}
			if (recalculateBounds)
			{
				mesh.RecalculateBounds();
			}
			return mesh;
		}

		public static CombineInstance GetCombineInstance(this Mesh m, int index = 0, bool destroyMesh = true, bool destroyImmediate = false)
		{
			CombineInstance result = new CombineInstance
			{
				mesh = m,
				transform = Matrix4x4.identity,
				subMeshIndex = index
			};
			if (destroyMesh)
			{
				if (!destroyImmediate)
				{
					UnityEngine.Object.Destroy(m);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(m);
				}
			}
			return result;
		}

		public static void InitializeMesh(this GameObject go, Mesh mesh = null, Material material = null)
		{
			if (material == null)
			{
				material = GetDefaultMaterial();
			}
			MeshFilter meshFilter = go.GetComponent<MeshFilter>();
			if (meshFilter == null)
			{
				meshFilter = go.AddComponent<MeshFilter>();
			}
			if ((bool)mesh)
			{
				meshFilter.mesh = mesh;
			}
			MeshRenderer meshRenderer = go.GetComponent<MeshRenderer>();
			if (meshRenderer == null)
			{
				meshRenderer = go.AddComponent<MeshRenderer>();
			}
			meshRenderer.sharedMaterial = material;
		}

		public static GameObject InitializeSeparateMesh(this GameObject thisObject, Mesh mesh = null, Material material = null)
		{
			GameObject gameObject = new GameObject("MeshObject");
			gameObject.transform.parent = thisObject.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.InitializeMesh(mesh, material);
			return gameObject;
		}

		public static void SetMesh(this GameObject thisObject, Mesh mesh, bool autoAddFilter = true)
		{
			MeshFilter component = thisObject.GetComponent<MeshFilter>();
			if (!component)
			{
				if (autoAddFilter)
				{
					thisObject.InitializeMesh(mesh);
				}
				else
				{
					Debug.LogWarning("The object doesn't have a MeshFilter");
				}
				return;
			}
			if ((bool)component.sharedMesh)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(component.sharedMesh);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(component.sharedMesh);
				}
			}
			component.sharedMesh = mesh;
		}

		public static void SetMaterial(this GameObject thisObject, Material material, bool autoAddRenderer = true)
		{
			MeshRenderer component = thisObject.GetComponent<MeshRenderer>();
			if (!component)
			{
				if (autoAddRenderer)
				{
					thisObject.InitializeMesh(null, material);
				}
				else
				{
					Debug.LogWarning("The object doesn't have a MeshRenderer");
				}
			}
			else
			{
				component.material = material;
			}
		}

		public static Vector3 CenterToAverage(this Mesh mesh)
		{
			Vector3 vector = Vector3.zero;
			Vector3[] vertices = mesh.vertices;
			if (vertices.Length == 0)
			{
				return Vector3.zero;
			}
			for (int i = 0; i < vertices.Length; i++)
			{
				vector = vertices[i];
			}
			vector /= (float)vertices.Length;
			mesh.Translate(-vector);
			return vector;
		}

		public static Vector3 CenterToBounds(this Mesh mesh)
		{
			Vector3 center = mesh.bounds.center;
			mesh.Translate(-center);
			return center;
		}

		public static void Translate(this Mesh mesh, Vector3 by)
		{
			mesh.vertices = TranslateVertices(mesh.vertices, by);
		}

		public static void Rotate(this Mesh mesh, float degrees, Vector3 axis)
		{
			mesh.vertices = RotateVertices(mesh.vertices, degrees, axis);
			mesh.normals = RotateVertices(mesh.normals, degrees, axis);
		}

		[Obsolete]
		public static void RotateMesh(Mesh mesh, float degrees, Vector3 axis)
		{
			mesh.vertices = RotateVertices(mesh.vertices, degrees, axis);
			mesh.normals = RotateVertices(mesh.normals, degrees, axis);
		}

		public static Vector3[] TranslateVertices(Vector3[] vertices, Vector3 by)
		{
			if (vertices == null || vertices.Length == 0)
			{
				return vertices;
			}
			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] += by;
			}
			return vertices;
		}

		public static Vector3[] RotateVertices(Vector3[] vertices, float angle, Vector3 axis)
		{
			if (vertices == null)
			{
				return null;
			}
			if (vertices.Length == 0)
			{
				return vertices;
			}
			Quaternion quaternion = Quaternion.AngleAxis(angle, axis);
			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] = quaternion * vertices[i];
			}
			return vertices;
		}

		public static CombineInstance GetInstanceWithMatrix(this Mesh m, Vector3 position, Quaternion rotation, Vector3 scale)
		{
			Matrix4x4 transform = default(Matrix4x4);
			transform.SetTRS(position, rotation, scale);
			return new CombineInstance
			{
				mesh = m,
				transform = transform
			};
		}

		public static void FromMatrix4x4(this Transform transform, Matrix4x4 matrix)
		{
			transform.localScale = matrix.GetScale();
			transform.rotation = matrix.GetRotation();
			transform.position = matrix.GetPosition();
		}

		public static Quaternion GetRotation(this Matrix4x4 matrix)
		{
			float num = Mathf.Sqrt(1f + matrix.m00 + matrix.m11 + matrix.m22) / 2f;
			float num2 = 4f * num;
			float x = (matrix.m21 - matrix.m12) / num2;
			float y = (matrix.m02 - matrix.m20) / num2;
			float z = (matrix.m10 - matrix.m01) / num2;
			return new Quaternion(x, y, z, num);
		}

		public static Vector3 GetPosition(this Matrix4x4 matrix)
		{
			float m = matrix.m03;
			float m2 = matrix.m13;
			float m3 = matrix.m23;
			return new Vector3(m, m2, m3);
		}

		public static Vector3 GetScale(this Matrix4x4 m)
		{
			float x = Mathf.Sqrt(m.m00 * m.m00 + m.m01 * m.m01 + m.m02 * m.m02);
			float y = Mathf.Sqrt(m.m10 * m.m10 + m.m11 * m.m11 + m.m12 * m.m12);
			float z = Mathf.Sqrt(m.m20 * m.m20 + m.m21 * m.m21 + m.m22 * m.m22);
			return new Vector3(x, y, z);
		}

		public static Material GetDefaultMaterial()
		{
			return null;
		}

		public static Vector3[] FromToDirVertices(Vector3[] vertices, Vector3 toDir)
		{
			Vector3[] array = new Vector3[vertices.Length];
			Quaternion quaternion = Quaternion.FromToRotation(Vector3.forward, toDir);
			for (int i = 0; i < vertices.Length; i++)
			{
				array[i] = quaternion * vertices[i];
			}
			return array;
		}

		private static Vector3[] RoundToSubV3(Vector3[] vectors, int subTiles, float uvScale)
		{
			Vector3[] array = (Vector3[])vectors.Clone();
			for (int i = 0; i < array.Length; i++)
			{
				if (subTiles != 0)
				{
					array[i] = new Vector3(RtF(array[i].x * uvScale, subTiles), RtF(array[i].y * uvScale, subTiles), RtF(array[i].z * uvScale, subTiles));
				}
				else
				{
					array[i] = new Vector3(Mathf.Round(array[i].x * (float)subTiles), Mathf.Round(array[i].y), Mathf.Round(array[i].z));
				}
			}
			return array;
		}

		private static float RtF(float f, int divisions)
		{
			if (divisions == 0)
			{
				divisions = 1;
			}
			float num = f;
			num *= (float)divisions;
			num = ((!(num <= 0.5f) || num == 0f) ? Mathf.Round(num) : Mathf.Ceil(num));
			return num / (float)divisions;
		}

		private static Vector2[] NormalProjection(Vector3[] vertices, Vector3[] normals)
		{
			return NormalProjection(vertices, Vector3.zero, normals);
		}

		private static Vector2[] NormalProjection(Vector3[] vertices, Vector3 uvOffset, Vector3[] normals)
		{
			Vector2[] array = new Vector2[vertices.Length];
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector3 vector = vertices[i] + uvOffset;
				if (VAbs(normals[i]) == Vector3.up)
				{
					array[i].x = vector.x;
					array[i].y = vector.z;
				}
				else if (VAbs(normals[i]) == Vector3.forward)
				{
					array[i].x = vector.x;
					array[i].y = vector.y;
				}
				else
				{
					array[i].x = vector.z;
					array[i].y = vector.y;
				}
			}
			return array;
		}

		public static Vector3 DeviateDir(Vector3 dir, float deviation)
		{
			return dir + new Vector3(UnityEngine.Random.Range(0f - deviation, deviation), UnityEngine.Random.Range(0f - deviation, deviation), UnityEngine.Random.Range(0f - deviation, deviation));
		}

		private static int getMiddlePoint(int p1, int p2, ref List<Vector3> vertices, ref Dictionary<long, int> cache, float radius)
		{
			bool num = p1 < p2;
			long num2 = (num ? p1 : p2);
			long num3 = (num ? p2 : p1);
			long key = (num2 << 32) + num3;
			if (cache.TryGetValue(key, out var value))
			{
				return value;
			}
			Vector3 vector = vertices[p1];
			Vector3 vector2 = vertices[p2];
			Vector3 vector3 = new Vector3((vector.x + vector2.x) / 2f, (vector.y + vector2.y) / 2f, (vector.z + vector2.z) / 2f);
			int count = vertices.Count;
			vertices.Add(vector3.normalized * radius);
			cache.Add(key, count);
			return count;
		}

		public static void RecalculateTangents(this Mesh mesh)
		{
			int[] triangles = mesh.triangles;
			Vector3[] vertices = mesh.vertices;
			Vector2[] uv = mesh.uv;
			Vector3[] normals = mesh.normals;
			int num = triangles.Length;
			int num2 = vertices.Length;
			Vector3[] array = new Vector3[num2];
			Vector3[] array2 = new Vector3[num2];
			Vector4[] array3 = new Vector4[num2];
			for (long num3 = 0L; num3 < num; num3 += 3)
			{
				long num4 = triangles[num3];
				long num5 = triangles[num3 + 1];
				long num6 = triangles[num3 + 2];
				Vector3 vector = vertices[num4];
				Vector3 vector2 = vertices[num5];
				Vector3 vector3 = vertices[num6];
				Vector2 vector4 = uv[num4];
				Vector2 vector5 = uv[num5];
				Vector2 vector6 = uv[num6];
				float num7 = vector2.x - vector.x;
				float num8 = vector3.x - vector.x;
				float num9 = vector2.y - vector.y;
				float num10 = vector3.y - vector.y;
				float num11 = vector2.z - vector.z;
				float num12 = vector3.z - vector.z;
				float num13 = vector5.x - vector4.x;
				float num14 = vector6.x - vector4.x;
				float num15 = vector5.y - vector4.y;
				float num16 = vector6.y - vector4.y;
				float num17 = 1f / (num13 * num16 - num14 * num15);
				Vector3 vector7 = new Vector3((num16 * num7 - num15 * num8) * num17, (num16 * num9 - num15 * num10) * num17, (num16 * num11 - num15 * num12) * num17);
				Vector3 vector8 = new Vector3((num13 * num8 - num14 * num7) * num17, (num13 * num10 - num14 * num9) * num17, (num13 * num12 - num14 * num11) * num17);
				array[num4] += vector7;
				array[num5] += vector7;
				array[num6] += vector7;
				array2[num4] += vector8;
				array2[num5] += vector8;
				array2[num6] += vector8;
			}
			for (long num18 = 0L; num18 < num2; num18++)
			{
				Vector3 normal = normals[num18];
				Vector3 tangent = array[num18];
				Vector3.OrthoNormalize(ref normal, ref tangent);
				array3[num18].x = tangent.x;
				array3[num18].y = tangent.y;
				array3[num18].z = tangent.z;
				array3[num18].w = ((Vector3.Dot(Vector3.Cross(normal, tangent), array2[num18]) < 0f) ? (-1f) : 1f);
			}
			mesh.tangents = array3;
		}

		private static Vector3 VAbs(Vector3 v)
		{
			return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
		}

		private static Vector2[] ToV2A(Vector3[] v)
		{
			Vector2[] array = new Vector2[v.Length];
			for (int i = 0; i < v.Length; i++)
			{
				array[i].x = v[i].x;
				array[i].y = v[i].y;
			}
			return array;
		}
	}
}
