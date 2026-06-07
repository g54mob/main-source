using UnityEngine;

namespace Battle
{
	public abstract class UnitBaseBullet : BaseBullet
	{
		public UnitCollider collider;

		public HitEffect hitEffect;

		public HitEffect attackEffect;

		public bool receiveDragonLazer;

		protected BaseUnit parentUnit;

		public override eBattleTag Tag => default(eBattleTag);

		public override int TypeNum => 0;

		public abstract void HitEnemy(GameObject enemyObj);

		public override void RegisterParent(IBattleCycle parent)
		{
		}

		public virtual void PlayAttackEffect(Vector3 localPosition)
		{
		}

		public virtual void PlayHitSound()
		{
		}
	}
}
