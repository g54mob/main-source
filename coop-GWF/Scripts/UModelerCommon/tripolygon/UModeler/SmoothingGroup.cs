using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class SmoothingGroup : PolygonResources
	{
		[SerializeField]
		public string name;

		private SortedDictionary<int, CachedMesh> meshes_;

		public override void Invalidate()
		{
			meshes_ = null;
		}

		protected override PolygonResources CreateResources()
		{
			return new SmoothingGroup();
		}

		public override PolygonResources Clone(Dictionary<SimplePolygon, SimplePolygon> originalToClone)
		{
			SmoothingGroup obj = base.Clone(originalToClone) as SmoothingGroup;
			obj.name = name.Clone() as string;
			return obj;
		}

		public SortedDictionary<int, CachedMesh> CreateMeshes(EditableMesh edMesh)
		{
			if (meshes_ != null)
			{
				return meshes_;
			}
			Dictionary<int, EditableMesh> dictionary = new Dictionary<int, EditableMesh>();
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (edMesh.Contains(polygon))
				{
					if (!dictionary.TryGetValue(polygon.matID, out var value))
					{
						value = new EditableMesh();
						dictionary.Add(polygon.matID, value);
					}
					value.AddPolygon(polygon);
				}
			}
			SortedDictionary<int, CachedMesh> sortedDictionary = new SortedDictionary<int, CachedMesh>();
			Dictionary<Vector3, Vector3> dictionary2 = new Dictionary<Vector3, Vector3>(new Vector3Comparer());
			foreach (KeyValuePair<int, EditableMesh> item in dictionary)
			{
				int key = item.Key;
				EditableMesh value2 = item.Value;
				CachedMesh cachedMesh = new CachedMesh();
				for (int j = 0; j < value2.GetPolygonCount(); j++)
				{
					cachedMesh.JoinGroup(value2.GetPolygon(j));
				}
				value2.InvalidateCache();
				value2.editableMeshCache.Clear();
				for (int k = 0; k < cachedMesh.normals.Count; k++)
				{
					VertexInfo vertexInfo = value2.editableMeshCache.FindVertexByPos(cachedMesh.vertices[k].pos);
					Vector3 value3 = Vector3.zero;
					if (!dictionary2.TryGetValue(vertexInfo.pos, out value3))
					{
						for (int l = 0; l < vertexInfo.tokens.Count; l++)
						{
							value3 += vertexInfo.tokens[l].polygon.plane.normal;
						}
						value3.Normalize();
						dictionary2.Add(vertexInfo.pos, value3);
					}
					cachedMesh.normals[k] = value3.normalized;
				}
				sortedDictionary.Add(key, cachedMesh);
			}
			meshes_ = sortedDictionary;
			return meshes_;
		}

		public Dictionary<Vector3, Vector3> GetNormals(EditableMesh edMesh)
		{
			Dictionary<Vector3, Vector3> dictionary = new Dictionary<Vector3, Vector3>(new Vector3Comparer());
			edMesh.editableMeshCache.Clear();
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				for (int j = 0; j < polygon.GetVertexCount(); j++)
				{
					VertexInfo vertexInfo = edMesh.editableMeshCache.FindVertexByPos(polygon.GetVertex(j).pos);
					if (!dictionary.ContainsKey(polygon.GetVertex(j).pos))
					{
						Vector3 zero = Vector3.zero;
						for (int k = 0; k < vertexInfo.tokens.Count; k++)
						{
							zero += vertexInfo.tokens[k].polygon.plane.normal;
						}
						zero.Normalize();
						dictionary.Add(polygon.GetVertex(j).pos, zero);
					}
				}
			}
			return dictionary;
		}

		public override void Read(BinaryReader binaryReader)
		{
			name = binaryReader.ReadString();
			base.Read(binaryReader);
		}

		public override void Write(BinaryWriter binaryWriter)
		{
			binaryWriter.Write(name);
			base.Write(binaryWriter);
		}
	}
}
