using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDiamondTint_Axe : EnemyDiamondTint
{
	protected override bool IsImmovable => false;

	protected override bool IsAxe => true;

	protected override bool IsSnake => false;

	protected override bool DoBaseUpdate => true;

	protected override uint[] TintProgression => new uint[4] { 16764108u, 16746632u, 16729156u, 16711680u };

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		if (!((EnemyController)this)._003CIsDead_003Ek__BackingField && !_isInvul)
		{
			int hitsTaken = _hitsTaken + 1;
			_hitsTaken = hitsTaken;
			_isInvul = true;
			ChangeFrame();
			float invulDelay = base.InvulDelay;
			Action onComplete = delegate
			{
				_isInvul = false;
			};
			object obj = default(object);
			float duration = (float)obj * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			PlayVFXFlash(showHitVfx);
			_receivingDamage = false;
		}
		if (!((EnemyController)this)._003CIsDead_003Ek__BackingField && !_isInvul)
		{
			_ = 1073741824;
		}
	}

	public EnemyDiamondTint_Axe()
	{
		base._grav = 0.3125f;
		((EnemyDiamond)this)._002Ector();
	}
}
