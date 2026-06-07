using Logic.Shapes;
using UnityEngine;

namespace Utils
{
	public static class ShapeUtils
	{
		public static Vector3 SnapPositionToVoxelGrid(Vector3 position, Shape shape)
		{
			Vector3Int bounds = shape.GetBounds();
			position /= 0.1f;
			position = new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), Mathf.Round(position.z));
			position *= 0.1f;
			Vector3 vector = new Vector3((bounds.x % 2 == 0) ? 0f : 0.05f, 0f, (bounds.z % 2 == 0) ? 0f : 0.05f);
			return position + vector;
		}

		public static Vector3 SnapPositionToVoxelGrid(Vector3 position, Shape shape, Vector3 shapeOffset)
		{
			Vector3Int bounds = shape.GetBounds();
			position -= shapeOffset;
			position /= 0.1f;
			position = new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), Mathf.Round(position.z));
			position *= 0.1f;
			Vector3 vector = new Vector3((bounds.x % 2 == 0) ? 0f : 0.05f, 0f, (bounds.z % 2 == 0) ? 0f : 0.05f);
			return position + vector + shapeOffset;
		}
	}
}
