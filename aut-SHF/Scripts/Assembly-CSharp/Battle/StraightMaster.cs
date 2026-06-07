using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class StraightMaster : BaseEnemy
	{
		[Header("出現設定")]
		[Label("排出量")]
		public int value;

		[Label("間隔(s)")]
		public double span;

		[SerializeField]
		private Straight straightPrefab;

		private Vector3 _spawnPosition;

		private List<Straight> _group;

		private double _nextSpawnTime;

		private EnemyBaseInfo _copyInfo;

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		public override void DestroyObj()
		{
		}

		public override void Withdrawal()
		{
		}

		protected override void AttackTown()
		{
		}

		public override bool ReceiveDamage(int unitAttackPoint, eLuggage giverUnit, bool displayDamage = true, bool isAdditionalDamage = true)
		{
			return false;
		}
	}
}
