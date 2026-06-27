using UnityEngine;

namespace Restory.Gameplay.Soldering
{
	public class SolderTrace : MonoBehaviour
	{
		private MeshFilter meshFilter;

		private MeshRenderer meshRenderer;

		private Material solderMaterial;

		public void Init(Mesh traceMesh, Material solderMaterial)
		{
			if ((bool)meshFilter)
			{
				Debug.LogError("SolderTrace already initialized");
				Object.Destroy(traceMesh);
				return;
			}
			meshFilter = base.gameObject.AddComponent<MeshFilter>();
			meshFilter.sharedMesh = traceMesh;
			meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			this.solderMaterial = solderMaterial;
			Hide();
		}

		public void Hide()
		{
			meshRenderer.enabled = false;
		}

		public void ActivateSolderMaterial()
		{
			meshRenderer.material = solderMaterial;
			meshRenderer.enabled = true;
		}

		public void OverrideMaterial(Material material)
		{
			meshRenderer.material = material;
			meshRenderer.enabled = true;
		}
	}
}
