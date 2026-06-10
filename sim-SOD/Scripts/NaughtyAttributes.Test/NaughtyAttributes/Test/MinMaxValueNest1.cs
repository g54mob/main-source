using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class MinMaxValueNest1
	{
		[MinValue(0)]
		[AllowNesting]
		public int min0Int;

		[MaxValue(0)]
		[AllowNesting]
		public int max0Int;

		[MinValue(0)]
		[MaxValue(1)]
		[AllowNesting]
		public float range01Float;

		[AllowNesting]
		[MaxValue(1)]
		[MinValue(0)]
		public Vector2 range01Vector2;

		[AllowNesting]
		[MaxValue(1)]
		[MinValue(0)]
		public Vector3 range01Vector3;

		[AllowNesting]
		[MaxValue(1)]
		[MinValue(0)]
		public Vector4 range01Vector4;

		[MinValue(0)]
		[AllowNesting]
		public Vector2Int min0Vector2Int;

		[MaxValue(100)]
		[AllowNesting]
		public Vector2Int max100Vector2Int;

		[MinValue(0)]
		[AllowNesting]
		public Vector3Int min0Vector3Int;

		[MaxValue(100)]
		[AllowNesting]
		public Vector3Int max100Vector3Int;

		public MinMaxValueNest2 nest2;
	}
}
