using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Interfaces
{
	public interface IDamageable
	{
		void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true);

		void OnGetDamaged(HitVfxType hitVfxType, bool hasKb = true);

		bool IsUnitDead();

		float MaxHp();

		float CurrentHealth();

		GameObject GetGameObject();

		void Despawn();

		void GiveReward(Action<Pickup> onRewardGiven = null);
	}
}
