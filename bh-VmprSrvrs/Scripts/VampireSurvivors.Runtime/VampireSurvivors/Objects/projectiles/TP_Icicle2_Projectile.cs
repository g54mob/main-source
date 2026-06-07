using System.Collections.Generic;
using DG.Tweening;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Icicle2_Projectile : Projectile
	{
		private const float BodyRadius = 24f;

		private const float Percentage = 0.0625f;

		private const float Radius = 0.5f;

		private const float SpeedModifier = 35f;

		private float _deltaTime;

		private readonly List<SpriteTextureData> _icicleSprites;

		private TP_Icicle2_Weapon _trueWeapon;

		private PhaserSprite _crystalSprite;

		private PhaserSprite _icicleSprite;

		private readonly float[] _requiemRandomOffsets;

		private int _requiemRandomIndex;

		private float _crystalAngle1;

		private float _crystalAngle2;

		private float _crystalAngle3;

		private float _crystalRotSpeedMod;

		private Tween _scaleTween;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitSprites()
		{
		}

		private void ScaleIn()
		{
		}

		private void StartTimers()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdatePosition()
		{
		}

		private void UpdateRotation()
		{
		}

		private void UpdateScale()
		{
		}

		private void UpdateCrystal()
		{
		}

		private void Expire()
		{
		}

		private void LaunchIcicle()
		{
		}

		public override void Despawn()
		{
		}

		private void ExplodeOnExpire()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
