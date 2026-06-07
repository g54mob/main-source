using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SpiritTornado_Projectile : Projectile
	{
		private float _radius;

		private Vector2 _aimVec;

		private PhaserSprite _displaySprite;

		private PhaserSprite _animatedSprite;

		private uint[] _colors;

		private readonly BlendMode[] _blendModes;

		private bool _initSpriteTrail;

		private MultiTargetTween _scaleTween;

		private Timer _expireTimer;

		private Timer _chooseTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void TweenInOut(bool tweenIn = true)
		{
		}

		private void StartDespawn()
		{
		}

		private void TargetPlayer()
		{
		}

		private void ChooseTarget()
		{
		}

		private void StartChooseTargetTimer()
		{
		}

		private void LateUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
