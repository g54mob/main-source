using System;
using UnityEngine;

namespace GRP
{
	public class RingVisual : MonoBehaviour
	{
		public MeshFilter meshFilter;

		public GameObject colliderObj;

		public MeshRenderer meshRenderer;

		[NonSerialized]
		public Mesh[] colMeshes;

		private RingVisualOptions options;

		public MaterialBlockContainer materialBlock;

		public void Setup()
		{
		}

		public static Mesh BuildMesh(RingVisualOptions options)
		{
			return null;
		}

		public static Mesh BuildMesh(RingVisualOptions options, GameObject colliderObj, out Mesh[] colMeshes)
		{
			colMeshes = null;
			return null;
		}

		public void Build(RingVisualOptions options)
		{
		}

		public void SetMaterial(MaterialRowConfig material, Color color)
		{
		}

		public void SetTiling()
		{
		}

		public void SetOffset(Id id)
		{
		}
	}
}
