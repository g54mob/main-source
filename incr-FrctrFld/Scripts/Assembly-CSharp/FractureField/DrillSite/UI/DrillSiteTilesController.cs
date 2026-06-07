using System.Collections.Generic;
using UnityEngine;

namespace FractureField.DrillSite.UI
{
	public class DrillSiteTilesController : MonoBehaviour
	{
		[SerializeField]
		private DrillSiteTileController _pfDrillSiteTile;

		[SerializeField]
		private int _numberOfLayers;

		[SerializeField]
		private bool _generateOnAwake;

		private const float HEX_WIDTH = 0.9525f;

		private const float HEX_HEIGHT = 1.09f;

		private Dictionary<Vector2Int, DrillSiteTileController> _tiles;

		private int _tileIndex;

		private void Awake()
		{
		}

		[ContextMenu("Generate Hexagonal Grid")]
		public void GenerateGridInEditor()
		{
		}

		[ContextMenu("Clear Grid")]
		public void ClearGrid()
		{
		}

		private void GenerateHexagonalGrid(int layers)
		{
		}

		private void GenerateRing(int layer)
		{
		}

		private void CreateTile(int q, int r)
		{
		}

		private void CreateTileAtPosition(Vector2 localPosition, int layer, int step)
		{
		}

		private Vector2Int WorldToGridCoords(Vector2 position)
		{
			return default(Vector2Int);
		}

		private Vector2 HexToWorldPosition(int q, int r)
		{
			return default(Vector2);
		}

		public DrillSiteTileController GetTile(int q, int r)
		{
			return null;
		}
	}
}
