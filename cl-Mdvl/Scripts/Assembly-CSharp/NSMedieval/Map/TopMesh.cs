using System;
using NSEipix.Base;
using UnityEngine;
using UnityEngine.Rendering;

namespace NSMedieval.Map
{
	public class TopMesh : MonoBehaviour
	{
		[SerializeField]
		private MeshCollider combatMeshCollider;

		[NonSerialized]
		private MeshFilter meshFilter;

		[NonSerialized]
		private MeshRenderer meshRenderer;

		[NonSerialized]
		private World world;

		private bool init;

		private void LazyInit()
		{
			if (!init)
			{
				init = true;
				meshFilter = GetComponent<MeshFilter>();
				meshRenderer = GetComponent<MeshRenderer>();
				world = MonoSingleton<World>.Instance;
			}
		}

		public void SetupTopMesh(Mesh mesh)
		{
			LazyInit();
			meshFilter.sharedMesh = mesh;
			meshRenderer.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
			combatMeshCollider.sharedMesh = mesh;
		}
	}
}
