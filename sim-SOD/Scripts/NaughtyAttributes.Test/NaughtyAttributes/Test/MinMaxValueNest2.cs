using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class MinMaxValueNest2
	{
		[MinValue(0)]
		[AllowNesting]
		public int min0Int;

		[MaxValue(0)]
		[AllowNesting]
		public int max0Int;

		[MinValue(0)]
		[AllowNesting]
		[MaxValue(1)]
		public float range01Float;

		[MaxValue(1)]
		[AllowNesting]
		[MinValue(0)]
		public Vector2 range01Vector2;

		[MaxValue(1)]
		[MinValue(0)]
		[AllowNesting]
		public Vector3 range01Vector3;

		[MinValue(0)]
		[AllowNesting]
		[MaxValue(1)]
		public Vector4 range01Vector4;

		[AllowNesting]
		[MinValue(0)]
		public Vector2Int min0Vector2Int;

		[AllowNesting]
		[MaxValue(100)]
		public Vector2Int max100Vector2Int;

		[MinValue(0)]
		[AllowNesting]
		public Vector3Int min0Vector3Int;

		[AllowNesting]
		[MaxValue(100)]
		public Vector3Int max100Vector3Int;
	}
}
