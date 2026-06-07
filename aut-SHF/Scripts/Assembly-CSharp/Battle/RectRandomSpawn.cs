using System;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class RectRandomSpawn : SallyPoint
	{
		[Tooltip("0ならデフォルトの外周を利用")]
		[Label("外周")]
		public Rect outerRect;

		[Label("出現除外範囲")]
		public Rect innerRect;

		public override Vector2 GetSallyPosition()
		{
			return default(Vector2);
		}

		public override Vector2 GetSallyPosition(Vector2? targetPosition)
		{
			return default(Vector2);
		}
	}
}
