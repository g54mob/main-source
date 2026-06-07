using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class CachedMesh
	{
		public List<Vertex> vertices = new List<Vertex>();

		public List<Vector3> normals = new List<Vector3>();

		public List<int> indices = new List<int>();

		public List<Vector2> originalUVs = new List<Vector2>();

		private SortedDictionary<int, List<int>> submeshIndices_;

		public Queue<Vertex> verticesQueue = new Queue<Vertex>();

		public SortedDictionary<int, List<int>> subMeshIndices
		{
			get
			{
				if (submeshIndices_ == null)
				{
					submeshIndices_ = new SortedDictionary<int, List<int>>();
				}
				return submeshIndices_;
			}
			set
			{
				submeshIndices_ = value;
			}
		}

		private Vertex GetNewVertex(Vertex v)
		{
			if (verticesQueue.Count > 0)
			{
				Vertex vertex = verticesQueue.Dequeue();
				vertex.Set(v);
				return vertex;
			}
			return new Vertex(v);
		}

		private Vertex GetNewVertex(Vector3 _pos, Vector2 _uv, Color _color)
		{
			if (verticesQueue.Count > 0)
			{
				Vertex vertex = verticesQueue.Dequeue();
				vertex.Set(_pos, _uv, _color);
				return vertex;
			}
			return new Vertex(_pos, _uv, _color);
		}

		public void Clear()
		{
			foreach (Vertex vertex in vertices)
			{
				verticesQueue.Enqueue(vertex);
			}
			vertices.Clear();
			normals.Clear();
			indices.Clear();
			originalUVs.Clear();
			if (submeshIndices_ == null)
			{
				return;
			}
			foreach (KeyValuePair<int, List<int>> item in submeshIndices_)
			{
				item.Value.Clear();
			}
		}

		public void Join(CachedMesh other, int submesh)
		{
			if (other == null)
			{
				return;
			}
			int count = vertices.Count;
			for (int i = 0; i < other.vertices.Count; i++)
			{
				vertices.Add(GetNewVertex(other.vertices[i]));
			}
			originalUVs.AddRange(other.originalUVs);
			normals.AddRange(other.normals);
			int count2 = indices.Count;
			for (int j = 0; j < other.indices.Count; j++)
			{
				indices.Add(other.indices[j] + count);
			}
			if (submesh != -1)
			{
				if (!subMeshIndices.TryGetValue(submesh, out var value))
				{
					subMeshIndices.Add(submesh, value = new List<int>());
				}
				for (int k = count2; k < indices.Count; k++)
				{
					value.Add(indices[k]);
				}
			}
		}

		public void JoinGroup(SimplePolygon simplePolygon)
		{
			CachedMesh renderableMesh = simplePolygon.renderableMesh;
			if (renderableMesh == null)
			{
				return;
			}
			int num = vertices.Count;
			Dictionary<int, int> dictionary = new Dictionary<int, int>(renderableMesh.vertices.Count);
			new Vector3Comparer();
			for (int i = 0; i < renderableMesh.vertices.Count; i++)
			{
				int num2 = num;
				for (int j = 0; j < vertices.Count; j++)
				{
					if (VertexEqualityComparer.Equivalent(vertices[j], renderableMesh.vertices[i]))
					{
						num2 = j;
						break;
					}
				}
				if (num2 == num)
				{
					vertices.Add(GetNewVertex(renderableMesh.vertices[i]));
					originalUVs.Add(renderableMesh.originalUVs[i]);
					normals.Add(renderableMesh.normals[i]);
					num++;
				}
				dictionary.Add(i, num2);
			}
			for (int k = 0; k < renderableMesh.indices.Count; k++)
			{
				indices.Add(dictionary[renderableMesh.indices[k]]);
			}
		}

		public CachedMesh Clone()
		{
			CachedMesh cachedMesh = new CachedMesh();
			cachedMesh.normals.AddRange(normals);
			cachedMesh.indices.AddRange(indices);
			cachedMesh.originalUVs.AddRange(originalUVs);
			for (int i = 0; i < vertices.Count; i++)
			{
				cachedMesh.vertices.Add(GetNewVertex(vertices[i]));
			}
			return cachedMesh;
		}

		public CachedMesh Invert()
		{
			for (int i = 0; i < indices.Count; i += 3)
			{
				int value = indices[i];
				indices[i] = indices[i + 2];
				indices[i + 2] = value;
			}
			for (int j = 0; j < normals.Count; j++)
			{
				normals[j] = -normals[j];
			}
			return this;
		}

		public bool Raycast(Ray ray, out float t, bool excludeBackface = false)
		{
			int count = indices.Count;
			for (int i = 0; i < count; i += 3)
			{
				if (MathUtil.Raycast(ray, vertices[indices[i]].pos, vertices[indices[i + 1]].pos, vertices[indices[i + 2]].pos, out t, excludeBackface))
				{
					return true;
				}
			}
			t = 0f;
			return false;
		}

		public bool FindFacePassedByRay(Ray ray, out Vertex v0, out Vertex v1, out Vertex v2)
		{
			v0 = null;
			v1 = null;
			v2 = null;
			int count = indices.Count;
			float dist = 0f;
			for (int i = 0; i < count; i += 3)
			{
				if (MathUtil.Raycast(ray, vertices[indices[i]].pos, vertices[indices[i + 1]].pos, vertices[indices[i + 2]].pos, out dist))
				{
					v0 = vertices[indices[i]];
					v1 = vertices[indices[i + 1]];
					v2 = vertices[indices[i + 2]];
					return true;
				}
			}
			dist = 0f;
			return false;
		}

		public bool IsUVPassed(Vector3 rayOrigin)
		{
			int count = indices.Count;
			float dist = 0f;
			for (int i = 0; i < count; i += 3)
			{
				if (MathUtil.Raycast(new Ray(rayOrigin, Vector3.forward), originalUVs[indices[i]], originalUVs[indices[i + 1]], originalUVs[indices[i + 2]], out dist))
				{
					return true;
				}
			}
			return false;
		}

		public bool HasTriangle(int i0, int i1, int i2)
		{
			for (int j = 0; j < indices.Count; j += 3)
			{
				if ((i0 == indices[j] && i1 == indices[j + 1] && i2 == indices[j + 2]) || (i0 == indices[j + 1] && i1 == indices[j + 2] && i2 == indices[j]) || (i0 == indices[j + 2] && i1 == indices[j] && i2 == indices[j + 1]))
				{
					return true;
				}
			}
			return false;
		}

		public void ConvertToRawMesh(UModeler modeler, Mesh outMesh)
		{
			int num = vertices.Count;
			if (modeler.backfaces)
			{
				num *= 2;
			}
			Vector3[] array = new Vector3[num];
			Vector2[] array2 = new Vector2[num];
			Vector3[] array3 = new Vector3[num];
			Color[] array4 = new Color[num];
			for (int i = 0; i < vertices.Count; i++)
			{
				array[i] = vertices[i].pos;
				array4[i] = vertices[i].color;
				array2[i] = vertices[i].uv;
				array3[i] = normals[i];
			}
			if (modeler.backfaces)
			{
				for (int j = 0; j < vertices.Count; j++)
				{
					int num2 = j + vertices.Count;
					array[num2] = vertices[j].pos;
					array4[num2] = vertices[j].color;
					array2[num2] = vertices[j].uv;
					array3[num2] = -normals[j];
				}
			}
			outMesh.Clear();
			if (num == 0)
			{
				return;
			}
			outMesh.vertices = array;
			outMesh.colors = array4;
			outMesh.uv = array2;
			outMesh.normals = array3;
			outMesh.subMeshCount = modeler.materials.Count;
			foreach (KeyValuePair<int, List<int>> subMeshIndex in subMeshIndices)
			{
				if (subMeshIndex.Key < modeler.materials.Count)
				{
					outMesh.SetTriangles(FillMeshTriangles(subMeshIndex.Value, modeler.backfaces), subMeshIndex.Key);
				}
			}
			for (int k = 0; k < outMesh.subMeshCount; k++)
			{
				if (!subMeshIndices.ContainsKey(k))
				{
					if (array.Length != 0)
					{
						int[] triangles = new int[3];
						outMesh.SetTriangles(triangles, k);
					}
					else
					{
						outMesh.SetTriangles(new int[0], k);
					}
				}
			}
			if (modeler.recalculateTangents)
			{
				outMesh.RecalculateTangents();
			}
		}

		public int[] FillMeshTriangles(List<int> in_indices, bool createBackfaces)
		{
			int num = in_indices.Count;
			if (createBackfaces)
			{
				num *= 2;
			}
			int[] array = new int[num];
			for (int i = 0; i < in_indices.Count; i++)
			{
				array[i] = in_indices[i];
			}
			if (createBackfaces)
			{
				for (int j = 0; j < in_indices.Count; j += 3)
				{
					int num2 = in_indices.Count + j;
					array[num2] = in_indices[j + 2] + vertices.Count;
					array[num2 + 1] = in_indices[j + 1] + vertices.Count;
					array[num2 + 2] = in_indices[j] + vertices.Count;
				}
			}
			return array;
		}

		public void ExpandInNormalDir(float offset)
		{
			for (int i = 0; i < vertices.Count; i++)
			{
				vertices[i].pos += normals[i] * offset;
			}
		}

		public bool RayHit(Vector3 origin, Vector3 dir, out float t)
		{
			t = 0f;
			for (int i = 0; i < indices.Count; i += 3)
			{
				Vector3 pos = vertices[indices[i]].pos;
				Vector3 pos2 = vertices[indices[i + 1]].pos;
				Vector3 pos3 = vertices[indices[i + 2]].pos;
				if (MathUtil.Raycast(new Ray(origin, dir), pos, pos2, pos3, out t))
				{
					return true;
				}
			}
			return false;
		}

		public List<SimplePolygon> ToPolygons(EPolygonFlag polygonFlag = (EPolygonFlag)0)
		{
			List<SimplePolygon> list = new List<SimplePolygon>();
			if (indices.Count > 0)
			{
				for (int i = 0; i < indices.Count; i += 3)
				{
					List<Vertex> list2 = new List<Vertex>();
					list2.Add(vertices[indices[i]]);
					list2.Add(vertices[indices[i + 1]]);
					list2.Add(vertices[indices[i + 2]]);
					list.Add(new SimplePolygon(list2, null, open: false, polygonFlag));
				}
			}
			else if (submeshIndices_ != null)
			{
				for (int j = 0; j < submeshIndices_.Count; j++)
				{
					List<int> list3 = submeshIndices_[j];
					for (int k = 0; k < list3.Count; k += 3)
					{
						SimplePolygon simplePolygon = new SimplePolygon(new List<Vertex>
						{
							vertices[list3[k]],
							vertices[list3[k + 1]],
							vertices[list3[k + 2]]
						}, null, open: false, polygonFlag);
						simplePolygon.matID = j;
						list.Add(simplePolygon);
					}
				}
			}
			return list;
		}

		public List<SimplePolygon> ToPolygonsClone(EPolygonFlag polygonFlag = (EPolygonFlag)0)
		{
			List<SimplePolygon> list = new List<SimplePolygon>();
			if (indices.Count > 0)
			{
				for (int i = 0; i < indices.Count; i += 3)
				{
					List<Vertex> list2 = new List<Vertex>();
					list2.Add(vertices[indices[i]].Clone());
					list2.Add(vertices[indices[i + 1]].Clone());
					list2.Add(vertices[indices[i + 2]].Clone());
					list.Add(new SimplePolygon(list2, null, open: false, polygonFlag));
				}
			}
			else if (submeshIndices_ != null)
			{
				for (int j = 0; j < submeshIndices_.Count; j++)
				{
					List<int> list3 = submeshIndices_[j];
					for (int k = 0; k < list3.Count; k += 3)
					{
						SimplePolygon simplePolygon = new SimplePolygon(new List<Vertex>
						{
							vertices[list3[k]].Clone(),
							vertices[list3[k + 1]].Clone(),
							vertices[list3[k + 2]].Clone()
						}, null, open: false, polygonFlag);
						simplePolygon.matID = j;
						list.Add(simplePolygon);
					}
				}
			}
			return list;
		}

		public EditableMesh ToModel(EPolygonFlag polygonFlag)
		{
			EditableMesh editableMesh = new EditableMesh();
			List<SimplePolygon> list = ToPolygons(polygonFlag);
			for (int i = 0; i < list.Count; i++)
			{
				if ((polygonFlag & EPolygonFlag.UVUnwrapped) != 0)
				{
					list[i].EnableUnwrapped(unwrapped: true);
				}
				editableMesh.AddPolygon(list[i]);
			}
			return editableMesh;
		}

		public void FromMesh(Mesh mesh)
		{
			int num = mesh.vertices.Length;
			int subMeshCount = mesh.subMeshCount;
			foreach (Vertex vertex in vertices)
			{
				verticesQueue.Enqueue(vertex);
			}
			vertices.Clear();
			normals.Clear();
			normals.AddRange(mesh.normals);
			for (int i = 0; i < num; i++)
			{
				vertices.Add(GetNewVertex(mesh.vertices[i], (mesh.uv != null && mesh.uv.Length != 0) ? mesh.uv[i] : Vector2.zero, (mesh.colors != null && mesh.colors.Length != 0) ? mesh.colors[i] : Color.white));
			}
			if (subMeshCount == 1)
			{
				indices = new List<int>(mesh.triangles);
				return;
			}
			submeshIndices_ = null;
			for (int j = 0; j < subMeshCount; j++)
			{
				subMeshIndices.Add(j, new List<int>(mesh.GetIndices(j)));
			}
		}
	}
}
