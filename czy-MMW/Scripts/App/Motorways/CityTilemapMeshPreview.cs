using UnityEngine;

namespace Motorways
{
	[ExecuteAlways]
	public class CityTilemapMeshPreview : MonoBehaviour
	{
		private MeshFilter _previewMeshFilter;

		private Material _landPreviewMaterial;

		private MeshRenderer _meshRenderer;

		private void Awake()
		{
			_previewMeshFilter = base.gameObject.AddComponent<MeshFilter>();
			_previewMeshFilter.gameObject.transform.localScale = new Vector3(2f, 2f, 1f);
			_meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
		}

		public void SetPreviewMaterial(Material material)
		{
			_landPreviewMaterial = material;
			GetComponent<MeshRenderer>().sharedMaterial = _landPreviewMaterial;
		}

		public void SetPreviewMesh(Mesh mesh)
		{
			_previewMeshFilter.sharedMesh = mesh;
		}

		public void SetSortingLayer(string sortingLayerName)
		{
			_meshRenderer.sortingLayerID = SortingLayer.NameToID(sortingLayerName);
		}

		public void SetSortingOrder(int sortingOrder)
		{
			_meshRenderer.sortingOrder = sortingOrder;
		}
	}
}
