using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Rendering;

namespace CTS.GridSystem
{
	public class GridRenderer : MonoBehaviour
	{
		[SerializeField]
		[Required(null)]
		private Material _gridMaterial;

		[SerializeField]
		private bool _pivotCentered;

		[SerializeField]
		[ShowIf("_pivotCentered")]
		private int _outwardPadding;

		[SerializeField]
		private bool _needsCollider = true;

		[SerializeField]
		private float _visualScale = 1f;

		private MeshFilter _meshFilter;

		private Renderer _renderer;

		private GameObject _rendererGO;

		public BoxCollider Collider { get; private set; }

		public Bounds Bounds => _renderer.bounds;

		public Vector3[] Vertices { get; private set; }

		private void Awake()
		{
		}

		public void SetupGridFromBounds(Bounds p_gridBounds, Color p_color)
		{
			GenerateGrid(Mathf.RoundToInt(p_gridBounds.extents.x * 2f / 0.5f), Mathf.RoundToInt(p_gridBounds.extents.z * 2f / 0.5f), 0.5f, 0.5f, 0.2f);
			SetGridColor(p_color);
			base.transform.position = new Vector3((float)Mathf.CeilToInt(p_gridBounds.center.x * 4f) * 0.25f, 0f, (float)Mathf.CeilToInt(p_gridBounds.center.z * 4f) * 0.25f);
			ShowGrid(p_value: false);
		}

		public void GenerateGrid(int p_gridWidth, int p_gridHeight, float p_cellSize, float p_tilesOpacity = 0f, float p_gridThickness = 0.1f)
		{
			if (_pivotCentered)
			{
				int num = _outwardPadding * 2;
				p_gridWidth += num;
				p_gridHeight += num;
			}
			_rendererGO = new GameObject("Grid Renderer");
			_rendererGO.transform.SetParent(base.transform, worldPositionStays: false);
			_rendererGO.SetActive(value: false);
			_meshFilter = _rendererGO.AddComponent<MeshFilter>();
			_renderer = _rendererGO.AddComponent<MeshRenderer>();
			_renderer.material = _gridMaterial;
			_renderer.shadowCastingMode = ShadowCastingMode.Off;
			_renderer.lightProbeUsage = LightProbeUsage.Off;
			Mesh mesh = new Mesh();
			_meshFilter.mesh = mesh;
			mesh.name = "Procedural Grid";
			Vertices = new Vector3[(p_gridWidth + 1) * (p_gridHeight + 1)];
			Vector2[] array = new Vector2[Vertices.Length];
			int num2 = 0;
			for (int i = 0; i <= p_gridHeight; i++)
			{
				int num3 = 0;
				while (num3 <= p_gridWidth)
				{
					if (_pivotCentered)
					{
						Vertices[num2] = new Vector3((float)num3 * p_cellSize - (float)p_gridWidth * p_cellSize * 0.5f, 0f, (float)i * p_cellSize - (float)p_gridHeight * p_cellSize * 0.5f);
					}
					else
					{
						Vertices[num2] = new Vector3((float)num3 * p_cellSize, 0f, (float)i * p_cellSize);
					}
					array[num2] = new Vector2((float)num3 / (float)p_gridWidth, (float)i / (float)p_gridHeight);
					num3++;
					num2++;
				}
			}
			mesh.vertices = Vertices;
			mesh.uv = array;
			int[] array2 = new int[p_gridWidth * p_gridHeight * 6];
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			while (num6 < p_gridHeight)
			{
				int num7 = 0;
				while (num7 < p_gridWidth)
				{
					array2[num4] = num5;
					array2[num4 + 3] = (array2[num4 + 2] = num5 + 1);
					array2[num4 + 4] = (array2[num4 + 1] = num5 + p_gridWidth + 1);
					array2[num4 + 5] = num5 + p_gridWidth + 2;
					num7++;
					num4 += 6;
					num5++;
				}
				num6++;
				num5++;
			}
			mesh.triangles = array2;
			mesh.RecalculateNormals();
			_renderer.material.SetVector("_PlaneSize", new Vector2((float)p_gridWidth * p_cellSize, (float)p_gridHeight * p_cellSize));
			_renderer.material.SetFloat("_CellSize", p_cellSize * _visualScale);
			_renderer.material.SetFloat("_GridThickness", p_gridThickness);
			_renderer.material.SetFloat("_TilesOpacity", p_tilesOpacity);
			if (_needsCollider)
			{
				Collider = base.gameObject.AddComponent<BoxCollider>();
				Collider.isTrigger = true;
				Collider.AutoSet(_renderer.bounds);
				Collider.enabled = false;
			}
		}

		public void SetGridColor(Color p_color)
		{
			_renderer.material.SetColor("_Color", p_color);
		}

		public void ShowGrid(bool p_value)
		{
			if ((bool)Collider)
			{
				Collider.enabled = p_value;
			}
		}

		public Vector3 GetGridClosestVerticeFromWorldPosition(Vector3 p_worldPosition)
		{
			float num = float.PositiveInfinity;
			Vector3 result = Vector3.zero;
			Vector3[] vertices = _meshFilter.mesh.vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector3 vector = vertices[i] + base.transform.position;
				float sqrMagnitude = (p_worldPosition - vector).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = vector;
				}
			}
			return result;
		}
	}
}
