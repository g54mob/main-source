using PajamaLlama.Flotsam.World;
using UnityEngine;

public class WorldMapSea : SceneBehaviour
{
	private const string MAP_OVERLAY_IS_VORONOI_PROPERTY = "_IsVoronoi";

	[SerializeField]
	private Material _dayMaterial;

	[SerializeField]
	private Material _nightMaterial;

	[SerializeField]
	private LineRenderer _borderPrefab;

	[SerializeField]
	private float _borderPositionY = -0.1f;

	[SerializeField]
	private LineRenderer _roadPrefab;

	[SerializeField]
	private float _roadPositionY = 1f;

	[SerializeField]
	private WorldRegionTypeFlags[] _noBorderFlags;

	private MeshFilter _meshFilter;

	private Mesh _defaultMesh;

	private MeshRenderer _meshRenderer;

	private Material _defaultMaterial;

	private Vector3 _defaultLocalScale;

	public Rect Bounds { get; private set; }

	private void OnDestroy()
	{
		if ((bool)_defaultMesh)
		{
			_meshFilter.mesh = _defaultMesh;
		}
		if ((bool)_defaultMaterial)
		{
			_meshRenderer.material = _defaultMaterial;
		}
		base.transform.localScale = _defaultLocalScale;
	}

	public void Initialize(WorldTile worldTile)
	{
		_defaultLocalScale = base.transform.localScale;
		if (worldTile.TryReturnWorldMapRegionMeshAndBounds(out var mesh, out var bounds))
		{
			if (_meshFilter == null)
			{
				_meshFilter = GetComponent<MeshFilter>();
			}
			_defaultMesh = _meshFilter.mesh;
			_meshFilter.mesh = mesh;
			_dayMaterial.SetInt("_IsVoronoi", 1);
			_nightMaterial.SetInt("_IsVoronoi", 1);
			if (_meshRenderer == null)
			{
				_meshRenderer = GetComponent<MeshRenderer>();
			}
			_defaultMaterial = _meshRenderer.material;
			_meshRenderer.material = _dayMaterial;
			base.transform.localScale = Vector3.one;
			Transform parent = ((_borderPrefab.transform.parent == null) ? base.transform : _borderPrefab.transform.parent);
			foreach (IWorldRegion region in worldTile.Regions)
			{
				InstantiateRegionBorder(region, parent);
			}
			foreach (RoadSpawner road in worldTile.Roads)
			{
				InstantiateLineRenderer(_roadPrefab, road.Nodes, parent, loop: false, _roadPositionY);
			}
			Bounds = bounds;
		}
		else
		{
			_dayMaterial.SetInt("_IsVoronoi", 0);
			_nightMaterial.SetInt("_IsVoronoi", 0);
		}
	}

	private void InstantiateRegionBorder(IWorldRegion region, Transform parent)
	{
		if (region.Border.IsNullOrEmpty() || region.Type == WorldRegionType.Shallow)
		{
			return;
		}
		using ListPool<Vector2>.List list = ListPool<Vector2>.Get();
		int num = -1;
		int num2 = region.Border.Length;
		while (0 < num2--)
		{
			WorldRegionBorderSegment worldRegionBorderSegment = region.Border[num2];
			if (_noBorderFlags.Contains(worldRegionBorderSegment.Flags))
			{
				if (num2 != -1)
				{
					break;
				}
			}
			else
			{
				num = num2;
			}
		}
		if (num == -1)
		{
			return;
		}
		WorldRegionBorderSegment worldRegionBorderSegment2 = region.Border[num];
		WorldRegionBorderSegment worldRegionBorderSegment3 = worldRegionBorderSegment2;
		list.Add(worldRegionBorderSegment2.Start);
		int num3 = region.Border.Length;
		while (0 < num3--)
		{
			WorldRegionBorderSegment worldRegionBorderSegment = region.Border.GetValueWrapped(++num);
			if (_noBorderFlags.Contains(worldRegionBorderSegment.Flags))
			{
				if (worldRegionBorderSegment3 != null)
				{
					list.Add(worldRegionBorderSegment3.End);
					InstantiateLineRenderer(_borderPrefab, list.ToArray(), parent, loop: false, _borderPositionY);
					list.Clear();
					worldRegionBorderSegment3 = null;
				}
			}
			else
			{
				list.Add(worldRegionBorderSegment.Start);
				worldRegionBorderSegment3 = worldRegionBorderSegment;
			}
		}
		if (list.Count > 0)
		{
			list.Add(worldRegionBorderSegment3.End);
			InstantiateLineRenderer(_borderPrefab, list.ToArray(), parent, loop: false, _borderPositionY);
		}
	}

	private void InstantiateLineRenderer(LineRenderer prefab, Vector2[] positions2D, Transform parent, bool loop, float borderPositionY)
	{
		LineRenderer lineRenderer = Object.Instantiate(prefab, parent);
		int num = positions2D.Length;
		Vector3[] array = new Vector3[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = positions2D[i];
		}
		lineRenderer.loop = loop;
		lineRenderer.positionCount = array.Length;
		lineRenderer.SetPositions(array);
		lineRenderer.gameObject.SetActive(value: true);
		lineRenderer.transform.localScale = Vector3.one;
		lineRenderer.transform.position = new Vector3(0f, borderPositionY, 0f);
	}
}
