using System;
using DG.Tweening;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyStalkerTrappedSorceress : EnemyController
	{
		private float _sineF;

		private float _fireTime;

		private float _fireDelay;

		private EnemyType _bulletType;

		private int _activated;

		private Tween _onEnterTween;

		private Tween _onFireTimer;

		private Sequence _onSineTween;

		public Action OnDefeat;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Disappear()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void Die()
		{
		}

		private void Fire()
		{
		}
	}
}
