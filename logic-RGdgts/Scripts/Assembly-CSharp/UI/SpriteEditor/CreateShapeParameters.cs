using System.Collections.Generic;
using UnityEngine;

namespace UI.SpriteEditor
{
	public struct CreateShapeParameters
	{
		public List<Vector2Int> borderCoords;

		public List<Vector2Int> insideCoords;

		public Vector2Int startCoords;

		public Vector2Int endCoords;

		public CreateShapeParameters(List<Vector2Int> frameCoords, List<Vector2Int> insideCoords, Vector2Int startCoords, Vector2Int endCoords)
		{
			borderCoords = null;
			this.insideCoords = null;
			this.startCoords = default(Vector2Int);
			this.endCoords = default(Vector2Int);
		}

		public void Init(CreateShapeParameters par)
		{
		}
	}
}
