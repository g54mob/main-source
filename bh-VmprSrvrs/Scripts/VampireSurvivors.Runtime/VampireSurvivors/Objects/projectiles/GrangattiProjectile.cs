using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class GrangattiProjectile : Projectile
	{
		private ParticleEmitterManager _pfxEmitter;

		private Weapon _trueWeapon;

		private Timer _chooseTimer;

		private float _save_vel_x;

		private float _save_vel_y;

		private Vector2 _aimVec;

		private Timer _expireTimer;

		private MultiTargetTween _onExpireAlphaTween;

		private SpriteRenderer _summon;

		private MultiTargetTween _summonTween;

		private float _defaultSpeed;

		private MultiTargetTween _entryTween;

		private Circle _explosionCircle;

		private ParticleEmitterManager _pfxEmitter2;

		private List<Vector2> _ellipsePoints;

		private Timer _hitboxTimer;

		private SpriteAnimation _anims;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void onExpireTimer()
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		public void TargetPlayer()
		{
		}

		public void ChooseTarget()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
