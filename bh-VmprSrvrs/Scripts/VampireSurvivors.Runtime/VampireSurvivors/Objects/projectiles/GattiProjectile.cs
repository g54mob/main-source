using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class GattiProjectile : Projectile
	{
		private Timer _chooseTimer;

		private float _saveVelX;

		private float _saveVelY;

		private Vector2 _aimVec;

		private Timer _expireTimer;

		private MultiTargetTween _onExpireAlphaTween;

		private SpriteRenderer _summon;

		private MultiTargetTween _summonTween;

		private float _defaultSpeed;

		private MultiTargetTween _entryTween;

		private SpriteAnimation _anims;

		protected List<string> _catFrames;

		protected override void Awake()
		{
		}

		protected virtual void CreateCatAnim()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		private void OnExpireTimer()
		{
		}

		private void TargetPlayer()
		{
		}

		private void ChooseTarget()
		{
		}
	}
}
