using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class HawkMaster : BaseEnemy
	{
		public float spawnRadius;

		public Vector2 offset;

		[SerializeField]
		private Hawk _hawkPrefab;

		private Hawk[] _hawks;

		private float[] spawnDegrees;

		public Queue<int> SelectedDegrees;

		public float[] SpawnDegrees => null;

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		public Vector3 PositionSetting(float degree)
		{
			return default(Vector3);
		}

		public Vector3 GetWarpPos()
		{
			return default(Vector3);
		}

		protected override void AttackTown()
		{
		}

		public override void DestroyObj()
		{
		}
	}
}
