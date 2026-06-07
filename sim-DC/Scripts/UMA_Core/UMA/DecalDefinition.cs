using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public class DecalDefinition
	{
		public string Name;

		public int InitialIndex;

		public GameObject DecalMeshObject;

		public Mesh bakedMesh;

		public Plane[] planesInWorldSpace;

		public int VertexNumber;

		public Vector3 WorldImpactPoint;

		public Vector3 LocalImpactPoint;

		public Material material;

		public float offset;

		private List<DecalInstance> Instances;

		public GameObject InstantiateSimpleDecal(GameObject umaParent, SkinnedMeshRenderer baseRenderer)
		{
			return null;
		}

		public void AddInstance(UMAData umaData, List<int> Vertexes)
		{
		}

		public void AddSubmesh(SkinnedMeshRenderer smr)
		{
		}
	}
}
