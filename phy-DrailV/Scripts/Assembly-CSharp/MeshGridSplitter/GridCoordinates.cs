using UnityEngine;

namespace MeshGridSplitter
{
	public struct GridCoordinates
	{
		private static readonly float precision = 100f;

		private Vector3Int value;

		public GridCoordinates(float x, float y, float z)
		{
			value = new Vector3Int(Mathf.RoundToInt(x * precision), Mathf.RoundToInt(y * precision), Mathf.RoundToInt(z * precision));
		}

		public Vector3 ToVector3()
		{
			return new Vector3((float)value.x / precision, (float)value.y / precision, (float)value.z / precision);
		}

		public override string ToString()
		{
			Vector3 vector = ToVector3();
			return $"GridCoordinates({vector.x}, {vector.y}, {vector.z})";
		}
	}
}
