using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters
{
	public class EnemyWeakPoint : IDamageable
	{
		private EnemyController _parentEnemy;

		public ArcadeSprite _damageZone;

		public bool _isApplyingDamage;

		private Collider _damageZoneCollider;

		public EnemyWeakPoint(EnemyController parentEnemy)
		{
		}

		private bool OnBulletOverlapsDamageZone(CallbackContext context, ArcadeColliderType damageZone, ArcadeColliderType bullet)
		{
			return false;
		}

		public void Destroy()
		{
		}

		public float CurrentHealth()
		{
			return 0f;
		}

		public void Despawn()
		{
		}

		public void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public void GiveReward(Action<Pickup> onRewardGiven = null)
		{
		}

		public bool IsUnitDead()
		{
			return false;
		}

		public float MaxHp()
		{
			return 0f;
		}

		public void OnGetDamaged(HitVfxType hitVfxType, bool hasKb = true)
		{
		}
	}
}
