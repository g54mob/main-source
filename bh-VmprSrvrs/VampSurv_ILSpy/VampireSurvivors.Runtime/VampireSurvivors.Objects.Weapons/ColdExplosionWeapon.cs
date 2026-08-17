using System;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class ColdExplosionWeapon : Weapon
{
	public bool _DoesRetaliate;

	private bool _canExplode;

	private Tween _explodeTimer;

	public override float PPower()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num2;
			float num3 = default(float);
			if (characterController._sineMight == null)
			{
				float num = ((Equipment)this)._003COwner_003Ek__BackingField.PPower();
				num2 = num3;
			}
			else
			{
				float num4 = ((Equipment)this)._003COwner_003Ek__BackingField.PPower();
				if (characterController._sineMight == null)
				{
					goto IL_00f7;
				}
				float value = characterController._sineMight.Value;
				num2 = value * num3;
			}
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null)
			{
				bool flag = !(10f > num2);
				float num5 = 10f;
				if (!flag)
				{
					num5 = num2;
				}
				return num5 * currentWeaponData._003Cpower_003Ek__BackingField;
			}
		}
		goto IL_00f7;
		IL_00f7:
		throw new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_canExplode = true;
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public void ExplodeAt(Vector2 position, bool ignoreCooldown = false)
	{
		if (!ignoreCooldown)
		{
			if (_canExplode == ignoreCooldown)
			{
				return;
			}
			_canExplode = ignoreCooldown;
			if (_explodeTimer != null)
			{
				DG.Tweening.TweenExtensions.Kill(_explodeTimer);
			}
			TweenCallback callback = delegate
			{
				_canExplode = true;
			};
			Tween gameId = DOVirtual.DelayedCall(0.5f, callback, ignoreTimeScale: false);
			Tween explodeTimer = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
			_explodeTimer = explodeTimer;
		}
		Transform target = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
		Projectile projectile = base.FireOneProjectile(position, 0, target);
	}

	private void _003CExplodeAt_003Eb__6_0()
	{
		_canExplode = true;
	}
}
