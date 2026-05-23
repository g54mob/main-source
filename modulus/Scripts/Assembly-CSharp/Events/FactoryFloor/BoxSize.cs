using UnityEngine;

namespace Events.FactoryFloor
{
	public class BoxSize
	{
		public Vector3Int StartPosition { get; }

		public Vector3Int EndPosition { get; }

		public BoxSize(Vector3Int startPosition, Vector3Int endPosition)
		{
			StartPosition = startPosition;
			EndPosition = endPosition;
		}
	}
}
