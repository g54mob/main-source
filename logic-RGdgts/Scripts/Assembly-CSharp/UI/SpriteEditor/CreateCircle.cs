using UnityEngine;

namespace UI.SpriteEditor
{
	public class CreateCircle : CreateShape
	{
		private int radius;

		private Vector2Int startingShapeCoords;

		public override void Init(bool fill, Vector2Int imageSize, bool snap, bool select, GridDimensions gridSize = null)
		{
		}

		public override CreateShapeParameters Select(Vector2Int startingShapeCoords, Vector2Int endCoords, bool fixedCentre, bool insideFilter, SEFilter filter = null)
		{
			return default(CreateShapeParameters);
		}

		private void DrawCircleBres()
		{
		}

		private void DrawSimmetricCircle(int x, int y)
		{
		}

		private void AddGlobalCoords(int x, int y)
		{
		}
	}
}
