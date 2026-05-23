using UnityEngine;

namespace Battle
{
	public abstract class EnemyBaseBullet : BaseBullet, IReceiveDamageable, IReceiveCollider
	{
		[SerializeField]
		private CircleCollider2D _collider;

		[SerializeField]
		private bool _throughCollider;

		protected BaseEnemy parent;

		public override eBattleTag Tag => default(eBattleTag);

		public override int TypeNum => 0;

		public int CutDamage { get; set; }

		public bool ThroughCollider { get; set; }

		public CircleCollider2D Collider => null;

		public int? ColliderGroupId { get; set; }

		public GameObject ColliderGroupRoot { get; set; }

		public bool ReceiveOk => false;

		public float SqrDistanceGate => 0f;

		public bool CheckGateCollision => false;

		public virtual bool ReceiveDamage(int unitAttackPoint, eLuggage giverLuggage, bool displayDamage = true, bool isAdditionalDamage = false)
		{
			return false;
		}

		protected virtual void AttackTown()
		{
		}

		protected virtual int GetTownAttackPoint()
		{
			return 0;
		}

		public override void RegisterParent(IBattleCycle parent)
		{
		}
	}
}
