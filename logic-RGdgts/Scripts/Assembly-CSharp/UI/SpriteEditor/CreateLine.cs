using UnityEngine;

namespace UI.SpriteEditor
{
	public class CreateLine : CreateShape
	{
		public override void Init(bool fill, Vector2Int imageSize, bool snap, bool select, GridDimensions gridSize = null)
		{
		}

		public override CreateShapeParameters Select(Vector2Int startingShapeCoords, Vector2Int endCoords, bool fixedCentre = false, bool insideFilter = false, SEFilter filter = null)
		{
			return default(CreateShapeParameters);
		}
	}
}
