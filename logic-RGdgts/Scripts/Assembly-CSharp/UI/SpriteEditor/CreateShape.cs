using System.Collections.Generic;
using UnityEngine;

namespace UI.SpriteEditor
{
	public abstract class CreateShape
	{
		protected Vector2Int imageSize;

		protected int[,] fullImageBorder01Matrix;

		protected bool fill;

		protected bool select;

		protected bool snap;

		protected GridDimensions gridSize;

		public List<Vector2Int> borderCoords;

		public List<Vector2Int> insideCoords;

		protected CheckInsideBoundaries checkBoundaries;

		public virtual void Init(bool fill, Vector2Int imageSize, bool snap, bool select, GridDimensions gridSize = null)
		{
		}

		public abstract CreateShapeParameters Select(Vector2Int startingShapePoint, Vector2Int endPoint, bool fixedCentre = false, bool insideFilter = false, SEFilter filter = null);

		public void RefreshShape()
		{
		}

		public List<Vector2Int> LineAlgorithm(Vector2Int startCoords, Vector2Int endCoords)
		{
			return null;
		}

		public List<Vector2Int> AddPixelsInsideShapeBFS(Vector2 coords)
		{
			return null;
		}

		public void RefreshGridSize(GridDimensions gridSize)
		{
		}

		protected (Vector2Int, Vector2Int) SortCoordinates(Vector2Int coordsStart, Vector2Int coordsEnd)
		{
			return default((Vector2Int, Vector2Int));
		}

		protected (Vector2Int, Vector2Int) SnapFromCornerShapesToVertex(Vector2Int coordsStart, Vector2Int coordsEnd)
		{
			return default((Vector2Int, Vector2Int));
		}

		private Vector2Int SnapVertexCoordsTL(Vector2Int coords)
		{
			return default(Vector2Int);
		}

		private Vector2Int SnapVertexCoordsBR(Vector2Int coords)
		{
			return default(Vector2Int);
		}

		protected void AddCoordsToList(Vector2Int coords, List<Vector2Int> l)
		{
		}

		protected void AddCoordsToListOnce(Vector2Int coords, List<Vector2Int> l)
		{
		}

		public bool CheckInsideImage(int x, int y)
		{
			return false;
		}

		public bool CheckInsideX(int x)
		{
			return false;
		}

		public bool CheckInsideY(int y)
		{
			return false;
		}

		public (int, int) RescaleInsideRectangularBoundaries(int x, int y, Vector2Int start, Vector2Int end)
		{
			return default((int, int));
		}

		public (Vector2Int, Vector2Int) ReturnMaxMin(List<Vector2Int> coords)
		{
			return default((Vector2Int, Vector2Int));
		}
	}
}
