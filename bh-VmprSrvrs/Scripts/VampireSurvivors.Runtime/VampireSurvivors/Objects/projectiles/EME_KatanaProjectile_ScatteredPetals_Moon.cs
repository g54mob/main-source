using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.VFX.Shatter;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_KatanaProjectile_ScatteredPetals_Moon : Projectile
	{
		[SerializeField]
		private SpriteRenderer _MoonVFX;

		[SerializeField]
		private ParticleSystem ShatterFX;

		[SerializeField]
		private GameObject TearGO;

		private const float GlobalScale = 1f;

		private const float MoonVFXScale = 0.75f;

		private const float Radius = 100f;

		private ShatterVFX _shatterVfx;

		private MultiTargetTween[] _tweens;

		private Timer _expireTimer;

		private MultiTargetTween _moveTween;

		private MultiTargetTween _fadeTween;

		private MultiTargetTween _scaleTween;

		private EME_Katana2Weapon _trueWeapon;

		public event Action OnDespawn
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void Launch()
		{
		}

		private void Explode()
		{
		}

		private void InitShatterVfx()
		{
		}

		private void PlayShatterVfx()
		{
		}

		private void KillTweens()
		{
		}

		private static void KillTween(MultiTargetTween[] tweens)
		{
		}

		public override void Despawn()
		{
		}
	}
}
