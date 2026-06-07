using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutoTiling
{
	public class MeshData
	{
		private class IndexTriplet : IComparable
		{
			public int x;

			public int y;

			public int z;

			public IndexTriplet(int x, int y, int z)
			{
				this.x = x;
				this.y = y;
				this.z = z;
			}

			public int CompareTo(object otherObj)
			{
				if (!(otherObj is IndexTriplet indexTriplet))
				{
					return 1;
				}
				if (x < indexTriplet.x)
				{
					return -1;
				}
				if (x == indexTriplet.x)
				{
					if (y < indexTriplet.y)
					{
						return -1;
					}
					if (y == indexTriplet.y)
					{
						if (z < indexTriplet.z)
						{
							return -1;
						}
						if (z == indexTriplet.z)
						{
							return 0;
						}
						return 1;
					}
					return 1;
				}
				return 1;
			}
		}

		private List<Vector3> vertices = new List<Vector3>();

		private List<Vector3> normals = new List<Vector3>();

		private List<int>[] triangles = new List<int>[1];

		private List<Vector2> uv = new List<Vector2>();

		private List<Vector2> uv2 = new List<Vector2>();

		private List<Vector4> tangents = new List<Vector4>();

		public List<Vector3> Vertices => vertices;

		public List<Vector3> Normals => normals;

		public List<int>[] Triangles => triangles;

		public List<Vector2> UV => uv;

		public List<Vector2> UV2 => uv2;

		public List<Vector4> Tangents => tangents;

		public int subMeshCount
		{
			get
			{
				return triangles.Length;
			}
			set
			{
				List<int>[] array = new List<int>[value];
				for (int i = 0; i < array.Length; i++)
				{
					if (i < triangles.Length)
					{
						array[i] = triangles[i];
					}
					else
					{
						array[i] = new List<int>();
					}
				}
				triangles = array;
			}
		}

		public MeshData()
		{
			triangles = new List<int>[1];
			triangles[0] = new List<int>();
		}

		public MeshData(List<Vector3> vertices, List<Vector3> normals, List<int>[] triangles, List<Vector2> uv, List<Vector2> uv2, List<Vector4> tangents)
		{
			this.vertices = vertices;
			this.normals = normals;
			this.triangles = triangles;
			this.uv = uv;
			this.uv2 = uv2;
			this.tangents = tangents;
		}

		public MeshData Copy()
		{
			List<int>[] array = new List<int>[triangles.Length];
			for (int i = 0; i < triangles.Length; i++)
			{
				array[i] = new List<int>(triangles[i]);
			}
			return new MeshData(new List<Vector3>(vertices), new List<Vector3>(normals), array, new List<Vector2>(uv), new List<Vector2>(uv2), new List<Vector4>(tangents));
		}

		public void AddQuadTriangles()
		{
			if (triangles == null || triangles.Length < 1)
			{
				triangles = new List<int>[1];
			}
			if (triangles[0] == null)
			{
				triangles[0] = new List<int>();
			}
			if (triangles == null)
			{
				Debug.LogError("triangles were not set!");
				return;
			}
			if (triangles[0] == null)
			{
				Debug.LogError("triangles[0] was not set!");
				return;
			}
			if (vertices == null)
			{
				Debug.LogError("Vertices were not set!");
				return;
			}
			triangles[0].Add(vertices.Count - 4);
			triangles[0].Add(vertices.Count - 3);
			triangles[0].Add(vertices.Count - 2);
			triangles[0].Add(vertices.Count - 4);
			triangles[0].Add(vertices.Count - 2);
			triangles[0].Add(vertices.Count - 1);
		}

		public void AddTriangle(int tri)
		{
			if (triangles == null || triangles.Length < 1)
			{
				triangles = new List<int>[1];
				triangles[0] = new List<int>();
			}
			triangles[0].Add(tri);
		}

		public void AddTriangle(int tri, int materialIndex)
		{
			if (materialIndex >= triangles.Length)
			{
				if (materialIndex > 0)
				{
					Debug.LogError(string.Concat(GetType(), ".AddTriangle: the material index is too high, set subMeshCount first."));
				}
				else
				{
					AddTriangle(tri);
				}
				return;
			}
			if (triangles[materialIndex] == null)
			{
				triangles[materialIndex] = new List<int>();
			}
			triangles[materialIndex].Add(tri);
		}

		public void SetTriangles(Mesh mesh)
		{
			triangles = new List<int>[mesh.subMeshCount];
			if (mesh == null)
			{
				triangles[0] = new List<int>();
				return;
			}
			for (int i = 0; i < mesh.subMeshCount; i++)
			{
				if (mesh.GetTriangles(i) == null)
				{
					triangles[i] = new List<int>();
				}
				else
				{
					triangles[i] = new List<int>(mesh.GetTriangles(i));
				}
			}
		}

		public void SetTriangles(int[] newTriangles)
		{
			if (newTriangles == null)
			{
				triangles[0] = new List<int>();
			}
			else
			{
				triangles[0] = new List<int>(newTriangles);
			}
		}

		public void AddVertex(Vector3 vertex)
		{
			vertices.Add(vertex);
		}

		private void RemoveVertices(Dictionary<int, int> vertexIndexDict)
		{
			for (int num = vertices.Count - 1; num >= 0; num--)
			{
				if (vertexIndexDict.ContainsKey(num))
				{
					if (normals.Count > num)
					{
						normals.RemoveAt(num);
					}
					if (vertices.Count > num)
					{
						vertices.RemoveAt(num);
					}
					if (tangents.Count > num)
					{
						tangents.RemoveAt(num);
					}
					if (uv.Count > num)
					{
						uv.RemoveAt(num);
					}
					if (uv2.Count > num)
					{
						uv2.RemoveAt(num);
					}
					for (int i = 0; i < triangles.Length; i++)
					{
						for (int j = 0; j < triangles[i].Count; j++)
						{
							if (triangles[i][j] == num)
							{
								triangles[i][j] = vertexIndexDict[num];
							}
							else if (triangles[i][j] > num)
							{
								triangles[i][j]--;
							}
						}
					}
				}
			}
		}

		public void SetVertices(Vector3[] newVertices)
		{
			if (newVertices == null)
			{
				vertices = new List<Vector3>();
			}
			else
			{
				vertices = new List<Vector3>(newVertices);
			}
		}

		public void AddNormal(Vector3 normal)
		{
			normals.Add(normal);
		}

		public void SetNormals(Vector3[] newNormals)
		{
			if (newNormals == null)
			{
				normals = new List<Vector3>();
			}
			else
			{
				normals = new List<Vector3>(newNormals);
			}
		}

		public void AddTangent(Vector4 tangent)
		{
			tangents.Add(tangent);
		}

		public void SetTangents(Vector4[] newTangents)
		{
			if (newTangents == null)
			{
				tangents = new List<Vector4>();
			}
			else
			{
				tangents = new List<Vector4>(newTangents);
			}
		}

		public void AddUVCoordinates(Vector2[] uvCoordinates)
		{
			uv.AddRange(uvCoordinates);
		}

		public void AddUVCoordinate(Vector2 uvCoordinate)
		{
			uv.Add(uvCoordinate);
		}

		public void SetUV2Coordinates(Vector2[] uvCoordinates)
		{
			if (uvCoordinates == null)
			{
				uv2 = new List<Vector2>();
			}
			else
			{
				uv2 = new List<Vector2>(uvCoordinates);
			}
		}

		public void AddUV2Coordinate(Vector2 coordinate)
		{
			uv2.Add(coordinate);
		}

		public void RemoveDoubles(bool checkForDifferingUV2coords = false)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			for (int num = vertices.Count - 1; num >= 0; num--)
			{
				for (int i = 0; i < vertices.Count && i < num; i++)
				{
					if (vertices[num] == vertices[i] && normals[num] == normals[i] && tangents[num] == tangents[i] && (!checkForDifferingUV2coords || (checkForDifferingUV2coords && uv2[num] == uv2[i])))
					{
						dictionary[num] = i;
						break;
					}
				}
			}
			RemoveVertices(dictionary);
			List<int>[] array = new List<int>[1]
			{
				new List<int>()
			};
			for (int j = 0; j < triangles.Length; j++)
			{
				for (int k = 0; k < triangles[j].Count; k++)
				{
					array[0].Add(triangles[j][k]);
				}
			}
			triangles = array;
			List<IndexTriplet> list = new List<IndexTriplet>();
			for (int l = 0; l < triangles[0].Count; l += 3)
			{
				list.Add(new IndexTriplet(triangles[0][l], triangles[0][l + 1], triangles[0][l + 2]));
			}
			list.Sort();
			List<int> list2 = new List<int>();
			for (int m = 0; m < list.Count; m++)
			{
				list2.Add(list[m].x);
				list2.Add(list[m].y);
				list2.Add(list[m].z);
			}
			triangles[0] = list2;
		}
	}
}
