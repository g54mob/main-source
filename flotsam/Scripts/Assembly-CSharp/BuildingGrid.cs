using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class BuildingGrid : SceneBehaviour
{
	[SerializeField]
	private VisualBoundary _gridBoundary;

	public float HeightOffset = 0.25f;

	[Header("Debug")]
	[SerializeField]
	private Vector2 _debugGridOffset = new Vector2(0f, 5f);

	[SerializeField]
	private int _debugGridWidth = 10;

	[SerializeField]
	private int _debugGridHeight = 10;

	private static BuildingGrid _instance;

	private MeshRenderer _meshRenderer;

	private MeshFilter _meshFilter;

	private Material _material;

	private Mesh _mesh;

	private Color[] _colors;

	private List<Vector2[]> _polygons;

	private List<Vector2[]> _localPolygons;

	private int _currentWidth;

	private int _currentHeight;

	private Vector2 _evenOffset = Vector2.zero;

	private Vector2 _unevenOffset = Vector2.zero;

	private Rect _localRectangle;

	private Rect _axisAlignedRect;

	public bool IsOn { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		if (_instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		_instance = this;
		_meshRenderer = base.gameObject.GetComponent<MeshRenderer>();
		_material = _meshRenderer.material;
		_meshFilter = base.gameObject.GetComponent<MeshFilter>();
		GameEventDispatcher.AddListener(GameEventType.ShowBuildGridSettingUpdated, OnGridSettingUpdated);
		IsOn = false;
		base.gameObject.SetActive(value: false);
	}

	private void OnDestroy()
	{
		if (_instance == this)
		{
			_instance = null;
		}
		GameEventDispatcher.RemoveListener(GameEventType.ShowBuildGridSettingUpdated, OnGridSettingUpdated);
	}

	[ContextMenu("Generate")]
	public void DebugGenerate()
	{
		_meshRenderer = base.gameObject.GetComponent<MeshRenderer>();
		_meshFilter = base.gameObject.GetComponent<MeshFilter>();
		_currentHeight = 0;
		_currentWidth = 0;
		Generate(_debugGridWidth, _debugGridHeight, _debugGridOffset);
	}

	public void Generate(int width, int height, Vector2 offset)
	{
		if (_currentWidth != width || _currentHeight != height)
		{
			_currentHeight = height;
			_currentWidth = width;
			if (width / 2 % 2 == 0)
			{
				_evenOffset = new Vector2(0.5f, 0.5f);
				_unevenOffset = new Vector2(0f, 0.5f);
			}
			else
			{
				_evenOffset = new Vector2(0f, 0.5f);
				_unevenOffset = new Vector2(0.5f, 0.5f);
			}
			_gridBoundary.SetSize((float)width / 2f, (float)height / 2f);
			_gridBoundary.transform.localPosition = offset.Vector3TopDown();
			_mesh = GenerateMesh(width, height, offset, ref _localPolygons, ref _polygons, ref _localRectangle);
			_meshFilter.mesh = _mesh;
			int gridSize = GameSettings.Instance.BuildableSettings.GridSize;
			_material.SetTextureScale("_Grid", new Vector2(width * gridSize / 2, height * gridSize / 2));
		}
	}

	public Mesh GenerateMesh(int width, int height, Vector2 offset, ref List<Vector2[]> localPolygons, ref List<Vector2[]> polygons, ref Rect localRectangle)
	{
		Mesh mesh = new Mesh();
		int gridSize = GameSettings.Instance.BuildableSettings.GridSize;
		int num = height * width;
		int num2 = num * 4;
		int num3 = num * 6;
		localPolygons = new List<Vector2[]>(num2);
		polygons = new List<Vector2[]>(num2);
		Vector3[] array = new Vector3[num2];
		Vector2[] array2 = new Vector2[num2];
		Vector3[] array3 = new Vector3[num2];
		int[] array4 = new int[num3];
		_colors = new Color[num2];
		int num4 = 0;
		float num5 = gridSize * width;
		float num6 = gridSize * height;
		Vector3 vector = new Vector3(num5 / 2f + offset.x, 0f, (0f - num6) / 2f + offset.y);
		Vector3 vector2 = new Vector3(0f, 0f, 1f);
		Vector3 vector3 = new Vector3(1f, 0f, 0f);
		localRectangle = new Rect(new Vector2((0f - num5) / 2f + offset.x, (0f - num6) / 2f + offset.y), new Vector2(num5, num6));
		float num7 = 1f / (float)height;
		float num8 = 1f / (float)width;
		for (int i = 0; i < height; i++)
		{
			Vector3 vector4 = vector + i * gridSize * vector2;
			Vector3 vector5 = vector + (i + 1) * gridSize * vector2;
			for (int j = 0; j < width; j++)
			{
				Vector2[] array5 = new Vector2[4];
				localPolygons.Add(array5);
				Vector2[] array6 = new Vector2[4];
				polygons.Add(array6);
				int num9 = num4 * 4;
				int num10 = num4 * 6;
				int num11 = num9;
				Vector3 vector6 = vector4 - vector3 * gridSize * j;
				Vector3 vector7 = base.transform.TransformPoint(vector6);
				array[num11] = vector6;
				Color white = Color.white;
				if (i == 0 || j == 0)
				{
					white.g = 0f;
				}
				_colors[num11] = white;
				array5[0] = vector6.Vector2TopDown();
				array6[0] = vector7.Vector2TopDown();
				num11 = num9 + 1;
				vector6 = vector4 - vector3 * gridSize * (j + 1);
				vector7 = base.transform.TransformPoint(vector6);
				array[num11] = vector6;
				white = Color.white;
				if (i == 0 || j == width - 1)
				{
					white.g = 0f;
				}
				_colors[num11] = white;
				array5[1] = vector6.Vector2TopDown();
				array6[1] = vector7.Vector2TopDown();
				num11 = num9 + 2;
				vector6 = vector5 - vector3 * gridSize * j;
				vector7 = base.transform.TransformPoint(vector6);
				array[num11] = vector6;
				white = Color.white;
				if (i == height - 1 || j == 0)
				{
					white.g = 0f;
				}
				_colors[num11] = white;
				array5[2] = vector6.Vector2TopDown();
				array6[2] = vector7.Vector2TopDown();
				num11 = num9 + 3;
				vector6 = vector5 - vector3 * gridSize * (j + 1);
				vector7 = base.transform.TransformPoint(vector6);
				array[num11] = vector6;
				white = Color.white;
				if (i == height - 1 || j == width - 1)
				{
					white.g = 0f;
				}
				_colors[num11] = white;
				array5[3] = vector6.Vector2TopDown();
				array6[3] = vector7.Vector2TopDown();
				int num12 = i + 1;
				int num13 = j + 1;
				array2[num9] = new Vector2((float)j * num8, (float)i * num7);
				array2[num9 + 1] = new Vector2((float)num13 * num8, (float)i * num7);
				array2[num9 + 2] = new Vector2((float)j * num8, (float)num12 * num7);
				array2[num9 + 3] = new Vector2((float)num13 * num8, (float)num12 * num7);
				array3[num9] = Vector3.up;
				array3[num9 + 1] = Vector3.up;
				array3[num9 + 2] = Vector3.up;
				array3[num9 + 3] = Vector3.up;
				array4[num10] = num9 + 2;
				array4[num10 + 1] = num9 + 1;
				array4[num10 + 2] = num9 + 3;
				array4[num10 + 3] = num9;
				array4[num10 + 4] = num9 + 1;
				array4[num10 + 5] = num9 + 2;
				num4++;
			}
		}
		mesh.vertices = array;
		mesh.uv = array2;
		mesh.normals = array3;
		mesh.triangles = array4;
		mesh.SetColors(_colors);
		mesh.RecalculateNormals();
		return mesh;
	}

	private void RecalculateGridPositions()
	{
		if (!base.gameObject.activeSelf || _polygons == null || _localPolygons == null)
		{
			return;
		}
		if (_polygons.Count != _localPolygons.Count)
		{
			throw new NotImplementedException();
		}
		Vector2[] array = new Vector2[4]
		{
			base.transform.TransformPoint(new Vector2(_localRectangle.xMin, _localRectangle.yMin).Vector3TopDown()).Vector2TopDown(),
			base.transform.TransformPoint(new Vector2(_localRectangle.xMin, _localRectangle.yMax).Vector3TopDown()).Vector2TopDown(),
			base.transform.TransformPoint(new Vector2(_localRectangle.xMax, _localRectangle.yMin).Vector3TopDown()).Vector2TopDown(),
			base.transform.TransformPoint(new Vector2(_localRectangle.xMax, _localRectangle.yMax).Vector3TopDown()).Vector2TopDown()
		};
		_axisAlignedRect = Rect.MinMaxRect(Mathf.Min(array[0].x, array[1].x, array[2].x, array[3].x), Mathf.Min(array[0].y, array[1].y, array[2].y, array[3].y), Mathf.Max(array[0].x, array[1].x, array[2].x, array[3].x), Mathf.Max(array[0].y, array[1].y, array[2].y, array[3].y));
		for (int i = 0; i < _localPolygons.Count; i++)
		{
			Vector2[] array2 = _polygons[i];
			Vector2[] array3 = _localPolygons[i];
			if (array2.Length != array3.Length)
			{
				throw new NotImplementedException();
			}
			for (int j = 0; j < array3.Length; j++)
			{
				array2[j] = base.transform.TransformPoint(array3[j].Vector3TopDown()).Vector2TopDown();
			}
		}
	}

	private void UpdateCollisions()
	{
		if (!base.gameObject.activeSelf || _polygons == null || _localPolygons == null)
		{
			return;
		}
		RecalculateGridPositions();
		bool flag = false;
		int count = _polygons.Count;
		List<Buildable> list = new List<Buildable>();
		foreach (Buildable buildable in Community.PlayerCommunity.Buildables)
		{
			if (buildable.BlockingPolygon.ReturnIsAxisAllignedRectangleOverlapping(_axisAlignedRect.min, _axisAlignedRect.max))
			{
				buildable.BlockingPolygon.FastUpdate();
				list.Add(buildable);
			}
		}
		for (int i = 0; i < count; i++)
		{
			flag = false;
			Vector2[] vertices = _polygons[i];
			foreach (Buildable item in list)
			{
				if (item.BlockingPolygon.ReturnArePolygonsOverlapping(vertices, includeTolerance: true))
				{
					flag = true;
					break;
				}
			}
			int num = i * 4;
			for (int j = 0; j < 4; j++)
			{
				_colors[num + j].r = (flag ? 1f : 0f);
			}
		}
		_mesh.SetColors(_colors);
		_mesh.RecalculateNormals();
	}

	public void SetTextureOffset(bool even)
	{
		Vector2 value = (even ? _evenOffset : _unevenOffset);
		_meshRenderer.sharedMaterial.SetTextureOffset("_Grid", value);
	}

	private void OnGridSettingUpdated(GameEvent gameEvent)
	{
		if (Settings.Instance.GameplayPlayerData.ShowBuildingGrid)
		{
			base.gameObject.SetActive(IsOn);
			if (IsOn)
			{
				UpdateCollisions();
			}
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public static void SetPlacement(Vector3 position, Hookable.Hook hook)
	{
		int gridIndex;
		Vector3 position2 = hook.ReturnPosition(position.Leveled(), snap: true, out gridIndex);
		Quaternion rotation = Quaternion.LookRotation(hook.Forward);
		SetPlacement(position2, rotation, gridIndex);
	}

	public static void SetPlacement(Vector3 position, Quaternion rotation, int gridIndex)
	{
		if (!(_instance == null))
		{
			Transform obj = _instance.transform;
			obj.position = position.SetY(_instance.HeightOffset);
			obj.rotation = rotation;
			_instance.SetTextureOffset(gridIndex % 2 == 0);
			_instance.UpdateCollisions();
		}
	}

	public static void Enable(BuildableProperties buildingProperties)
	{
		Enable(buildingProperties.Width, buildingProperties.Depth);
	}

	public static void Enable(int gridWidth, int gridHeight)
	{
		if (!(_instance == null))
		{
			int num = GameSettings.Instance.BuildableSettings.GridWidthDisplayPadding * 2;
			int gridHeightDisplayPadding = GameSettings.Instance.BuildableSettings.GridHeightDisplayPadding;
			int num2 = gridWidth * 2;
			int num3 = gridHeight * 2;
			Vector2 offset = new Vector2(0f, (float)(-gridHeightDisplayPadding - num3) / 2f);
			_instance.IsOn = true;
			_instance.gameObject.SetActive(Settings.Instance.GameplayPlayerData.ShowBuildingGrid ? true : false);
			_instance.Generate(num2 + num, num3 + gridHeightDisplayPadding, offset);
		}
	}

	public static void Disable()
	{
		if (!(_instance == null))
		{
			_instance.IsOn = false;
			_instance.gameObject.SetActive(value: false);
		}
	}
}
