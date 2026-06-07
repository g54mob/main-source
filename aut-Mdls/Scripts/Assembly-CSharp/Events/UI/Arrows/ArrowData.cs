using UnityEngine;

namespace Events.UI.Arrows
{
	public struct ArrowData
	{
		public Vector3Int Origin;

		public Vector3Int End;

		public float Height;

		public ArrowData(Vector3Int origin, Vector3Int end, float height = 3f)
		{
			Origin = origin;
			End = end;
			Height = height;
		}
	}
}
