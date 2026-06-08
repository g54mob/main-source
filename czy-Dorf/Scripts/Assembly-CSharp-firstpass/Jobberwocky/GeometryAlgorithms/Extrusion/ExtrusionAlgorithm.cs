using System;
using System.Collections.Generic;
using System.Linq;
using Jobberwocky.GeometryAlgorithms.GeometryAlgorithms.Source.Algorithms;
using Jobberwocky.GeometryAlgorithms.Source.Core;
using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Extrusion
{
	public class ExtrusionAlgorithm : Algorithm<ExtrusionAlgorithm>
	{
		public Mesh Extrude(Mesh mesh, float height)
		{
			Vector3[] array = new Vector3[mesh.vertices.Length];
			for (int i = 0; i < mesh.vertices.Length; i++)
			{
				Vector3 vector = mesh.vertices[i];
				array[i] = new Vector3(vector.x, vector.y, vector.z + height);
			}
			int[] indices = mesh.GetIndices(0);
			if (height > 0f)
			{
				Array.Reverse(indices);
			}
			Dictionary<string, EdgeInt> dictionary = new Dictionary<string, EdgeInt>();
			int[] array2 = new int[indices.Length];
			for (int j = 0; j < indices.Length; j += 3)
			{
				array2[j] = mesh.vertices.Length + indices[j + 2];
				array2[j + 1] = mesh.vertices.Length + indices[j + 1];
				array2[j + 2] = mesh.vertices.Length + indices[j];
				for (int k = 0; k < 3; k++)
				{
					EdgeInt value = new EdgeInt(indices[j + k], indices[j + (k + 1) % 3]);
					string key = value.GetKey();
					if (dictionary.ContainsKey(key))
					{
						dictionary.Remove(key);
					}
					else
					{
						dictionary.Add(key, value);
					}
				}
			}
			int[] array3 = new int[6 * dictionary.Values.Count];
			EdgeInt[] array4 = Enumerable.ToArray(dictionary.Values);
			for (int l = 0; l < array4.Length; l++)
			{
				EdgeInt edgeInt = array4[l];
				array3[l * 6] = edgeInt.X + mesh.vertices.Length;
				array3[l * 6 + 1] = edgeInt.Y;
				array3[l * 6 + 2] = edgeInt.X;
				array3[l * 6 + 3] = edgeInt.Y;
				array3[l * 6 + 4] = edgeInt.X + mesh.vertices.Length;
				array3[l * 6 + 5] = edgeInt.Y + mesh.vertices.Length;
			}
			List<Vector3> list = new List<Vector3>(mesh.vertices.Length + array.Length);
			list.AddRange(mesh.vertices);
			list.AddRange(array);
			List<int> list2 = new List<int>(indices.Length + array2.Length + array3.Length);
			list2.AddRange(indices);
			list2.AddRange(array2);
			list2.AddRange(array3);
			Mesh mesh2 = new Mesh();
			mesh2.SetVertices(list);
			mesh2.SetIndices(list2.ToArray(), MeshTopology.Triangles, 0);
			mesh2.RecalculateBounds();
			mesh2.RecalculateNormals();
			return mesh2;
		}
	}
}
