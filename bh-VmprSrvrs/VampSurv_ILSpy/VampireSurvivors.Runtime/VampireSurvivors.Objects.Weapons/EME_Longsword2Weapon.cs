using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Longsword2Weapon : EME_Longsword1Weapon
{
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public EME_Longsword2Weapon _003C_003E4__this;

		public Vector2 pos;

		public int index;

		public BulletPool pool;

		internal void _003CFire_FireGlimmerProjectile_003Eb__0()
		{
			Vector2 vector = default(Vector2);
			Projectile projectile = _003C_003E4__this.FireOneProjectile(vector, index);
		}
	}

	protected override int ComboIndexFinal => base.ComboIndex2;

	protected override int GlimmerTier => 2;

	protected override int _comboIndex1 => 1;

	protected override int _comboIndex2 => 5;

	protected override int _comboIndex3 => 21;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		((EME_Weapon)this).InitWeapon(characterController, weaponType);
	}

	protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_0084: Invalid comparison between O and F4
		//IL_00e2: Expected I4, but got O
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals9._003C_003E4__this = this;
		CS_0024_003C_003E8__locals9.pos = pos;
		BulletPool pool2 = default(BulletPool);
		CS_0024_003C_003E8__locals9.pool = pool2;
		CS_0024_003C_003E8__locals9.index = index;
		Vector2 vector = default(Vector2);
		BulletPool bulletPool = default(BulletPool);
		if (CS_0024_003C_003E8__locals9.pool != _glimmer2Pool)
		{
			base.Fire_FireGlimmerProjectile(vector, CS_0024_003C_003E8__locals9.index, target, bulletPool);
			return;
		}
		Projectile projectile = base.FireOneProjectile(vector, CS_0024_003C_003E8__locals9.index);
		float num = base.PAmount();
		if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)11f))
		{
			Action onComplete = delegate
			{
				Vector2 pos2 = default(Vector2);
				Projectile projectile2 = CS_0024_003C_003E8__locals9._003C_003E4__this.FireOneProjectile(pos2, CS_0024_003C_003E8__locals9.index);
			};
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, (byte)(int)bulletPool != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}
}
