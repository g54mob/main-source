using UnityEngine;

namespace NSMedieval.Views.Resources
{
	[RequireComponent(typeof(MeshVariationHandler))]
	public class ApplyMeshFilterSkinnedMeshRenderer : MonoBehaviour
	{
		[SerializeField]
		private SkinnedMeshRenderer skinnedMeshRenderer;

		private MeshFilter meshFilter;

		private bool filterApplied;

		public void ApplySkinnedMeshRenderer(SkinnedMeshRenderer skinnedMeshRenderer)
		{
			this.skinnedMeshRenderer = skinnedMeshRenderer;
			ApplyRenderer();
		}

		private void ApplyRenderer()
		{
			if (!(skinnedMeshRenderer == null) && !filterApplied)
			{
				filterApplied = true;
				Mesh sharedMesh = skinnedMeshRenderer.sharedMesh;
				meshFilter = base.gameObject.AddComponent<MeshFilter>();
				meshFilter.mesh = sharedMesh;
				base.gameObject.GetComponent<MeshVariationHandler>().AssignMeshes(meshFilter);
				base.gameObject.GetComponent<MeshVariationHandler>().AssignRenderer(skinnedMeshRenderer);
			}
		}

		private void Start()
		{
			ApplyRenderer();
		}
	}
}
