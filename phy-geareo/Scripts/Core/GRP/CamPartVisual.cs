using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class CamPartVisual : MonoBehaviour
	{
		public MeshFilter meshFilter;

		public MeshRenderer meshRenderer;

		public GameObject colliderObj;

		public List<Mesh> colMeshes;

		private MaterialBlockContainer materialBlock;

		private CamVisualOptions options;

		private float circum;

		public void Setup()
		{
		}

		public static Mesh BuildMesh(CamVisualOptions options, out float circumference)
		{
			circumference = default(float);
			return null;
		}

		public void BuildCollider(CamVisualOptions options)
		{
		}

		public void Build(CamVisualOptions options)
		{
		}

		public void SetMaterial(MaterialRowConfig material, Color color)
		{
		}

		public void SetTiling()
		{
		}
	}
}
