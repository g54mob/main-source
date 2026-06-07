using System;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomeTechnologies.Utility.BVHTree
{
	[Serializable]
	public struct ObjectData
	{
		public MeshRenderer Renderer;

		public Mesh Mesh;

		public int SubMesheCount;

		public List<Vector3> VerticeList;

		public List<Vector3> NormalList;

		public int[] Indices;

		public bool HasNormals;

		public BVHNode BVH;

		public bool IsValid;

		public List<BVHNode> Nodes;

		public List<BVHTriangle> Prims;

		public int TerrainSourceID;

		public ObjectData(MeshRenderer r, int terrainSourceID)
		{
			Renderer = r;
			Mesh = r.GetComponent<MeshFilter>().sharedMesh;
			IsValid = Mesh != null;
			SubMesheCount = 0;
			VerticeList = null;
			NormalList = null;
			Indices = null;
			HasNormals = false;
			Prims = null;
			Nodes = null;
			TerrainSourceID = terrainSourceID;
			BVH = default(BVHNode);
			if (IsValid)
			{
				SubMesheCount = Mesh.subMeshCount;
				VerticeList = new List<Vector3>();
				Mesh.GetVertices(VerticeList);
				NormalList = new List<Vector3>();
				Mesh.GetNormals(NormalList);
				Indices = new int[Mesh.triangles.Length];
				Indices = Mesh.triangles;
				HasNormals = NormalList.Count > 0;
				Matrix4x4 localToWorldMatrix = Renderer.localToWorldMatrix;
				for (int i = 0; i < VerticeList.Count; i++)
				{
					VerticeList[i] = localToWorldMatrix.MultiplyPoint3x4(VerticeList[i]);
					NormalList[i] = localToWorldMatrix.MultiplyVector(NormalList[i]);
				}
			}
		}
	}
}
