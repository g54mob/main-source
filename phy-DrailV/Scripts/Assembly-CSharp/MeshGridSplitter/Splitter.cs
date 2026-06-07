using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace MeshGridSplitter
{
	public static class Splitter
	{
		private class SplitterData
		{
			public MeshFilter sourceFilter;

			public MeshRenderer sourceRenderer;

			public Mesh sourceMesh;

			public Vector3[] sourceVertices;

			public int[] sourceTriangles;

			public Vector2[] sourceUvs;

			public Vector3[] sourceNormals;

			public float gridSize;

			public bool axisX;

			public bool axisY;

			public bool axisZ;

			public bool rebase;

			public bool allow32bitIndices;

			public SplitterData(MeshFilter source, float gridSize, bool axisX, bool axisY, bool axisZ, bool rebase, bool allow32bitIndices)
			{
				sourceFilter = source;
				this.gridSize = gridSize;
				this.axisX = axisX;
				this.axisY = axisY;
				this.axisZ = axisZ;
				this.rebase = rebase;
				this.allow32bitIndices = allow32bitIndices;
				sourceFilter = source;
				sourceRenderer = source.GetComponent<MeshRenderer>();
				sourceMesh = (sourceFilter ? sourceFilter.sharedMesh : null);
				sourceVertices = (sourceMesh ? sourceMesh.vertices : null);
				sourceTriangles = (sourceMesh ? sourceMesh.triangles : null);
				sourceUvs = (sourceMesh ? sourceMesh.uv : null);
				sourceNormals = (sourceMesh ? sourceMesh.normals : null);
				Validate();
			}

			public void Validate()
			{
				if (sourceFilter == null)
				{
					throw new ArgumentNullException("source");
				}
				if (sourceRenderer == null)
				{
					throw new InvalidProgramException("Couldn't find a MeshRenderer on the given source");
				}
				if (sourceMesh == null)
				{
					throw new InvalidProgramException("The sharedMesh on the given source is null");
				}
				if ((axisX ? 1 : 0) + (axisY ? 1 : 0) + (axisZ ? 1 : 0) < 1)
				{
					throw new ArgumentException("At least one axis must be true");
				}
				if (gridSize <= Mathf.Epsilon)
				{
					throw new ArgumentException("Grid size must be positive");
				}
			}
		}

		public static List<GameObject> Split(MeshFilter source, float gridSize, bool splitX, bool splitY, bool splitZ, bool rebase, Vector3 rebaseOrigin, bool allow32bitIndices)
		{
			SplitterData data = new SplitterData(source, gridSize, splitX, splitY, splitZ, rebase, allow32bitIndices);
			rebaseOrigin = (rebase ? rebaseOrigin : source.transform.position);
			Dictionary<GridCoordinates, List<int>> dictionary = MapTrianglesToGridNodes(data, rebaseOrigin);
			List<GameObject> list = new List<GameObject>();
			foreach (KeyValuePair<GridCoordinates, List<int>> item2 in dictionary)
			{
				GameObject item = CreateMesh(item2.Key, item2.Value, data);
				list.Add(item);
			}
			return list;
		}

		private static GameObject CreateMesh(GridCoordinates gridCoordinates, List<int> dictTris, SplitterData data)
		{
			GameObject gameObject = new GameObject();
			gameObject.name = "SubMesh " + gridCoordinates;
			gameObject.AddComponent<MeshFilter>();
			gameObject.AddComponent<MeshRenderer>();
			gameObject.transform.position = (data.rebase ? gridCoordinates.ToVector3() : data.sourceFilter.transform.position);
			Vector3 vector = gameObject.transform.position - data.sourceFilter.transform.position;
			gameObject.GetComponent<MeshRenderer>().sharedMaterial = data.sourceRenderer.sharedMaterial;
			List<Vector3> list = new List<Vector3>();
			List<int> list2 = new List<int>();
			List<Vector2> list3 = new List<Vector2>();
			List<Vector3> list4 = new List<Vector3>();
			for (int i = 0; i < dictTris.Count; i += 3)
			{
				list.Add(data.sourceVertices[dictTris[i]] - vector);
				list.Add(data.sourceVertices[dictTris[i + 1]] - vector);
				list.Add(data.sourceVertices[dictTris[i + 2]] - vector);
				list2.Add(i);
				list2.Add(i + 1);
				list2.Add(i + 2);
				list3.Add(data.sourceUvs[dictTris[i]]);
				list3.Add(data.sourceUvs[dictTris[i + 1]]);
				list3.Add(data.sourceUvs[dictTris[i + 2]]);
				list4.Add(data.sourceNormals[dictTris[i]]);
				list4.Add(data.sourceNormals[dictTris[i + 1]]);
				list4.Add(data.sourceNormals[dictTris[i + 2]]);
			}
			Mesh mesh = new Mesh();
			mesh.name = gridCoordinates.ToString();
			if (list.Count >= 65535)
			{
				if (data.allow32bitIndices)
				{
					Debug.LogWarning($"Mesh '{gameObject.name}' will use 32-bit indices, it has {list.Count} vertices", gameObject);
					mesh.indexFormat = IndexFormat.UInt32;
				}
				else
				{
					Debug.LogWarning($"Mesh '{gameObject.name}' has more than 65534 vertices, it'll probably look wrong. Consider using smaller grid size or enable `allow32bitIndices`", gameObject);
				}
			}
			mesh.vertices = list.ToArray();
			mesh.triangles = list2.ToArray();
			mesh.uv = list3.ToArray();
			mesh.normals = list4.ToArray();
			mesh.RecalculateTangents();
			gameObject.GetComponent<MeshFilter>().mesh = mesh;
			return gameObject;
		}

		private static Dictionary<GridCoordinates, List<int>> MapTrianglesToGridNodes(SplitterData data, Vector3 origin)
		{
			Dictionary<GridCoordinates, List<int>> dictionary = new Dictionary<GridCoordinates, List<int>>();
			for (int i = 0; i < data.sourceTriangles.Length; i += 3)
			{
				Vector3 vector = (data.sourceVertices[data.sourceTriangles[i]] + data.sourceVertices[data.sourceTriangles[i + 1]] + data.sourceVertices[data.sourceTriangles[i + 2]]) / 3f;
				Vector3 vector2 = data.sourceFilter.transform.position - origin;
				vector += vector2;
				vector.x = Mathf.Floor(vector.x / data.gridSize) * data.gridSize;
				vector.y = Mathf.Floor(vector.y / data.gridSize) * data.gridSize;
				vector.z = Mathf.Floor(vector.z / data.gridSize) * data.gridSize;
				GridCoordinates key = new GridCoordinates(data.axisX ? vector.x : 0f, data.axisY ? vector.y : 0f, data.axisZ ? vector.z : 0f);
				if (!dictionary.ContainsKey(key))
				{
					dictionary.Add(key, new List<int>());
				}
				dictionary[key].Add(data.sourceTriangles[i]);
				dictionary[key].Add(data.sourceTriangles[i + 1]);
				dictionary[key].Add(data.sourceTriangles[i + 2]);
			}
			return dictionary;
		}
	}
}
