using UnityEngine;

namespace UI.SpriteEditor
{
	public class CreateEllipse : CreateShape
	{
		private int a;

		private int b;

		private Coroutine searchXCo;

		private Coroutine serachYCo;

		public override void Init(bool fill, Vector2Int imageSize, bool snap, bool select, GridDimensions gridSize = null)
		{
		}

		public override CreateShapeParameters Select(Vector2Int startingShapeCoords, Vector2Int endCoords, bool fixedCentre, bool insideFilter, SEFilter filter = null)
		{
			return default(CreateShapeParameters);
		}

		private void CheckCoordAndAdd(int x, int y)
		{
		}

		private void CreateInImage(Vector2Int startingShapeCoords, Vector2Int endCoords, bool fixedCentre)
		{
		}

		private void CreateInFilter(Vector2Int startingShapeCoords, Vector2Int endCoords, SEFilter filter, bool fixedCentre)
		{
		}

		private void PlotEllipseFromCentre(Vector2Int startingShapeCoords, Vector2Int endCoords)
		{
		}

		private void PlotEllipseFromAngleOld(int x0, int y0, int x1, int y1)
		{
		}

		private void PlotEllipseFromAngle(int x0, int y0, int x1, int y1)
		{
		}

		private Vector2Int FindPoint(int xc, int yc, int x0, int y0)
		{
			return default(Vector2Int);
		}

		private void PlotEllipse(int x0, int y0, int a, int b)
		{
		}
	}
}
