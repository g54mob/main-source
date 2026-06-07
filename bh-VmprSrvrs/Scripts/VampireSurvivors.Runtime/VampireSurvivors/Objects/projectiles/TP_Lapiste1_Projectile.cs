using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Lapiste1_Projectile : Projectile
	{
		private const float Radius = 16f;

		private const float ScaleModifier = 1.5f;

		private readonly Vector2 BaseOffset;

		private TP_Lapiste1_Weapon _trueWeapon;

		private PhaserSprite _knuckleSprite;

		private int _cachedAmount;

		private float _cachedArea;

		private int _repeatCounter;

		private Timer _hitBoxTimer;

		private Tween _scaleTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitSprite()
		{
		}

		private void ScaleIn()
		{
		}

		private void PlaySfx()
		{
		}

		private void StartHitBoxTimer()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdatePosition()
		{
		}

		public override void Despawn()
		{
		}
	}
}
