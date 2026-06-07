using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WorldMapFogOfWar : SceneBehaviour
{
	[Serializable]
	public class PersistentData
	{
		private Rect _bounds;

		private byte[] _alphas;

		private int _tileWidth;

		private int _tileDepth;

		private int _gridWidth;

		private int _gridDepth;

		public Rect Bounds => _bounds;

		public byte[] Alphas => _alphas;

		public int TileWidth => _tileWidth;

		public int TileDepth => _tileDepth;

		public int GridWidth => _gridWidth;

		public int GridDepth => _gridDepth;

		public PersistentData(WorldMapFogOfWar instance)
		{
			_bounds = instance.Bounds;
			_alphas = instance.ReturnAlphas();
			_tileWidth = instance.TileSizeX;
			_tileDepth = instance.TileSizeZ;
			_gridWidth = instance.GridSizeX;
			_gridDepth = instance.GridSizeZ;
		}
	}

	[Header("Plane Generation")]
	[SerializeField]
	private int _tileSizeX;

	[SerializeField]
	private int _tileSizeZ;

	[SerializeField]
	private int _tilePadding = 1;

	[Header("Clearance")]
	[SerializeField]
	private Transform _player;

	[SerializeField]
	private Gradient _clearGradient;

	[SerializeField]
	private float _clearRange = 250f;

	[SerializeField]
	private float _clearDeviation;

	[SerializeField]
	[Range(1f, 25f)]
	private float _clearDeviationFrequency = 1f;

	[SerializeField]
	[Min(0f)]
	private int _regionClearRectMargin = 1;

	[Header("Other")]
	[SerializeField]
	[Tooltip("FowOfWar that is marked as padding will not update its clearance (alphas)")]
	private bool _isPadding;

	[Header("Debug")]
	[SerializeField]
	private bool _debugGradient;

	[SerializeField]
	private bool _debugGrid;

	[SerializeField]
	private int _debugGridSizeX;

	[SerializeField]
	private int _debugGridSizeZ;

	private static List<WorldMapFogOfWar> _instances = new List<WorldMapFogOfWar>();

	private Vector3 _position;

	private Mesh _mesh;

	private Rect _meshBounds;

	private int _vertexRowCount;

	private int _vertexColumnCount;

	private int _vertexCount;

	private Vector3[] _vertices;

	private Color[] _colors;

	private RectInt _clearRect;

	private IWorldRegion _debugRegion;

	public WorldTile WorldTile { get; private set; }

	public Rect Bounds { get; private set; }

	public int GridSizeX { get; private set; } = -1;

	public int GridSizeZ { get; private set; } = -1;

	public int TileSizeX { get; private set; }

	public int TileSizeZ { get; private set; }

	protected override void Awake()
	{
		if (GridSizeX < 0)
		{
			GridSizeX = _debugGridSizeX;
		}
		if (GridSizeZ < 0)
		{
			GridSizeZ = _debugGridSizeZ;
		}
		base.Awake();
	}

	public void Initialize(WorldTile worldTile)
	{
		WorldTile = worldTile;
		Initialize(worldTile.FogOfWarBounds, worldTile.WorldPosition, worldTile.FogOfWarAlphas, worldTile.FogOfWarPersistentData);
	}

	public void Initialize(Rect bounds, Vector3 position)
	{
		Initialize(bounds, position, null, null);
	}

	private void Initialize(Rect bounds, Vector3 position, byte[] alphas, PersistentData persistentData)
	{
		_position = position;
		if (_debugGrid)
		{
			TileSizeX = _tileSizeX;
			TileSizeZ = _tileSizeZ;
			GridSizeX = _debugGridSizeX;
			GridSizeZ = _debugGridSizeZ;
		}
		else if (persistentData == null)
		{
			TileSizeX = _tileSizeX;
			TileSizeZ = _tileSizeZ;
			GridSizeX = Mathf.CeilToInt(bounds.size.x / (float)TileSizeX) + _tilePadding * 2;
			GridSizeZ = Mathf.CeilToInt(bounds.size.y / (float)TileSizeZ) + _tilePadding * 2;
		}
		else
		{
			TileSizeX = persistentData.TileWidth;
			TileSizeZ = persistentData.TileDepth;
			GridSizeX = persistentData.GridWidth;
			GridSizeZ = persistentData.GridDepth;
		}
		GenerateMesh(bounds, alphas);
		if (!_isPadding)
		{
			_instances.Add(this);
		}
	}

	private void Update()
	{
		if (_debugGradient || _debugRegion != null)
		{
			UpdateAlphas(_debugRegion);
		}
	}

	private void OnDestroy()
	{
		_instances.Remove(this);
	}

	public static void ScoutArea(Vector3 position, float clearRadius)
	{
		foreach (WorldMapFogOfWar instance in _instances)
		{
			instance.UpdateAlphas(position, clearRadius);
		}
	}

	public static void ScoutRegion(IWorldRegion region)
	{
		foreach (WorldMapFogOfWar instance in _instances)
		{
			instance.UpdateAlphas(region);
		}
	}

	public void RestoreLastTileAlphas()
	{
		int num = _tilePadding + 2;
		for (int i = 0; i < _vertexRowCount; i++)
		{
			for (int j = 0; j < num; j++)
			{
				int num2 = j + i * _vertexColumnCount;
				Color color = _colors[num2];
				color.a = 1f;
				_colors[num2] = color;
			}
		}
		_mesh.colors = _colors;
	}

	private void GenerateMesh(Rect bounds, byte[] alphas)
	{
		int num = 0;
		int num2 = 0;
		Vector3 vector = new Vector3(GridSizeX * TileSizeX, 0f, GridSizeZ * TileSizeZ);
		Vector3 vector2 = bounds.center.Vector3TopDown() - vector / 2f;
		Vector3 zero = Vector3.zero;
		Vector2 zero2 = Vector2.zero;
		Vector3 up = Vector3.up;
		Bounds = bounds;
		_meshBounds = new Rect(vector2.Vector2TopDown(), vector.Vector2TopDown());
		int gridSizeX = GridSizeX;
		int gridSizeZ = GridSizeZ;
		_vertexColumnCount = gridSizeX + 1;
		_vertexRowCount = gridSizeZ + 1;
		_vertexCount = _vertexRowCount * _vertexColumnCount;
		_vertices = new Vector3[_vertexColumnCount * _vertexRowCount];
		Vector2[] array = new Vector2[_vertexCount];
		Vector3[] array2 = new Vector3[_vertexCount];
		_colors = new Color[_vertexCount];
		int[] array3 = new int[gridSizeX * gridSizeZ * 6];
		for (int i = 0; i < _vertexRowCount; i++)
		{
			zero.z = vector2.z + (float)(i * TileSizeZ);
			zero2.y = i;
			for (int j = 0; j < _vertexColumnCount; j++)
			{
				zero.x = vector2.x + (float)(j * TileSizeX);
				zero2.x = j;
				_vertices[num] = zero;
				array[num] = zero2;
				array2[num] = up;
				_colors[num] = Color.black;
				if (j < gridSizeX && i < gridSizeZ)
				{
					int num3 = num;
					int num4 = num + 1;
					int num5 = num4 + gridSizeX;
					int num6 = num5 + 1;
					array3[num2++] = num3;
					array3[num2++] = num5;
					array3[num2++] = num4;
					array3[num2++] = num4;
					array3[num2++] = num5;
					array3[num2++] = num6;
				}
				num++;
			}
		}
		_mesh = new Mesh();
		if (65535 < _vertexCount)
		{
			_mesh.indexFormat = IndexFormat.UInt32;
		}
		_mesh.vertices = _vertices;
		_mesh.uv = array;
		_mesh.normals = array2;
		RestoreAlphas(alphas, _colors, _vertexCount);
		_mesh.colors = _colors;
		_mesh.triangles = array3;
		GetComponent<MeshFilter>().mesh = _mesh;
	}

	private void UpdateAlphas(Vector3 position, float clearRadius)
	{
		if (_vertices == null)
		{
			return;
		}
		position -= _position;
		UpdateClearRect(position, clearRadius);
		for (int i = _clearRect.yMin; i < _clearRect.yMax; i++)
		{
			for (int j = _clearRect.xMin; j < _clearRect.xMax; j++)
			{
				int num = j + i * _vertexColumnCount;
				float num2 = Vector3.Distance(_vertices[num], position);
				if (num2 < clearRadius)
				{
					float a = _clearGradient.Evaluate(Mathf.Clamp01(num2 / clearRadius)).a;
					Color color = _colors[num];
					if (_debugGradient || a < color.a)
					{
						color.a = a;
						_colors[num] = color;
					}
				}
			}
		}
		_mesh.colors = _colors;
	}

	private void UpdateAlphas(IWorldRegion region)
	{
		if (_vertices == null)
		{
			return;
		}
		Vector2 vector = region.Bounds.center - WorldTile.Offset;
		float fogOfWarRegionMargin = GameSettings.Instance.GameplaySettings.FogOfWarRegionMargin;
		float num = region.Bounds.size.magnitude / 2f + fogOfWarRegionMargin;
		Vector2 vector2 = WorldTile.Offset - region.WorldTile.Offset;
		UpdateClearRect(vector, num, _regionClearRectMargin);
		for (int i = _clearRect.yMin; i < _clearRect.yMax; i++)
		{
			for (int j = _clearRect.xMin; j < _clearRect.xMax; j++)
			{
				int num2 = j + i * _vertexColumnCount;
				Vector2 vector3 = _vertices[num2].Vector2TopDown();
				if (Vector2.Distance(vector3, vector) < num && region.TryReturnDistanceToBorder(out var distance, vector3 + vector2, fogOfWarRegionMargin))
				{
					float num3 = Mathf.Sin(vector3.x * _clearDeviationFrequency) + Mathf.Cos(vector3.y * _clearDeviationFrequency);
					distance += num3 * _clearDeviation;
					float a = _clearGradient.Evaluate(1f - distance / _clearRange).a;
					Color color = _colors[num2];
					if (_debugGradient || a < color.a)
					{
						color.a = a;
						_colors[num2] = color;
					}
				}
			}
		}
		_mesh.colors = _colors;
	}

	private void RestoreAlphas(byte[] alphasToRestore, Color[] colors, int vertexCount)
	{
		if (alphasToRestore == null)
		{
			return;
		}
		int num = alphasToRestore.Length;
		if (num != _vertexCount)
		{
			Debug.LogErrorFormat("alpha count ({0}) != vertex count ({1})!", num, _vertexCount);
			return;
		}
		for (int i = 0; i < num; i++)
		{
			Color color = colors[i];
			color.a = (float)(int)alphasToRestore[i] / 255f;
			colors[i] = color;
		}
	}

	private void UpdateClearRect(Vector2 center, float radius, int margin = 0)
	{
		Vector2 vector = center - _meshBounds.min;
		_clearRect.xMin = Mathf.Clamp(Mathf.FloorToInt((vector.x - radius) / (float)TileSizeX) - margin, 0, _vertexColumnCount);
		_clearRect.yMin = Mathf.Clamp(Mathf.FloorToInt((vector.y - radius) / (float)TileSizeZ) - margin, 0, _vertexRowCount);
		_clearRect.xMax = Mathf.Clamp(Mathf.CeilToInt((vector.x + radius) / (float)TileSizeX) + margin, 0, _vertexColumnCount);
		_clearRect.yMax = Mathf.Clamp(Mathf.CeilToInt((vector.y + radius) / (float)TileSizeZ) + margin, 0, _vertexRowCount);
	}

	private void UpdateClearRect(Vector3 center, float radius)
	{
		UpdateClearRect(center.Vector2TopDown(), radius);
	}

	public byte[] ReturnAlphas()
	{
		if (_colors == null)
		{
			return null;
		}
		int num = _colors.Length;
		byte[] array = new byte[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = (byte)Mathf.FloorToInt(_colors[i].a * 255f);
		}
		return array;
	}
}
