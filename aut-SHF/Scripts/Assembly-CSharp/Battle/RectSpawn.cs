using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class RectSpawn : SallyPoint
	{
		public Rect spawnRect;

		public float rectAngle;

		[Tooltip("eSpawnDirection.Randomは使えない")]
		public List<eSpawnDirection> enabledDerections;

		[Label("enabledDirections順")]
		public bool isOrder;

		public eSpawnDirection SpawnDirection { get; private set; }

		private eSpawnDirection GetDirectionByList => default(eSpawnDirection);

		public override void InitParameter(SallyPoint sallyPoint)
		{
		}

		public override Vector2 GetSallyPosition()
		{
			return default(Vector2);
		}

		public override Vector2 GetSallyPosition(Vector2? targetPosition)
		{
			return default(Vector2);
		}

		public Vector2 GetRectLinePosition(eSpawnDirection direction)
		{
			return default(Vector2);
		}

		public Vector3 GetMultipleByDirection(eSpawnDirection direction)
		{
			return default(Vector3);
		}
	}
}
