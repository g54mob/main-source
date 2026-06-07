using UnityEngine;

public class WorldMapLandmarkPolygonVisual : MonoBehaviour
{
	[SerializeField]
	private PolygonMeshRenderer _meshRenderer;

	[SerializeField]
	private PolygonLineRenderer _lineRenderer;

	public void Initialize(LandmarkSpawner spawner)
	{
		Material material = GameManager.WorldManager.ReturnRegionProperties(spawner.RegionType)?.LandmarkMaterial;
		using ListPool<Vector2>.List list = ListPool<Vector2>.Get();
		spawner.PopulateWorldSpaceOutlineVertices(list);
		_meshRenderer.Initialize(list, material);
		_lineRenderer.InitializeLocalSpace(list);
	}
}
