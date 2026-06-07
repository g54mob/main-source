using UnityEngine;

namespace UI.SpriteEditor
{
	public class CreateSquare : CreateShape
	{
		public override void Init(bool fill, Vector2Int imageSize, bool snap, bool select, GridDimensions gridSize = null)
		{
		}

		public override CreateShapeParameters Select(Vector2Int startingShapePoint, Vector2Int endCoords, bool fixedCentre, bool insideFilter, SEFilter filter = null)
		{
			return default(CreateShapeParameters);
		}

		private (Vector2Int, Vector2Int) CreateInImage(Vector2Int startC, Vector2Int endC, bool fixedCentre)
		{
			return default((Vector2Int, Vector2Int));
		}

		private (Vector2Int, Vector2Int) CreateInFilter(Vector2Int startC, Vector2Int endC, SEFilter filter, bool fixedCentre)
		{
			return default((Vector2Int, Vector2Int));
		}

		private (Vector2Int, Vector2Int) CreateFromVertex(Vector2Int startC, Vector2Int endC)
		{
			return default((Vector2Int, Vector2Int));
		}

		private (Vector2Int, Vector2Int) CreateFromCentre(Vector2Int startingShapeCoords, Vector2Int endCoords)
		{
			return default((Vector2Int, Vector2Int));
		}
	}
}
