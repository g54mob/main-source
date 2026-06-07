using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class PartyProjectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _trail;

		[SerializeField]
		private SpriteAnimation _SpriteAnimation;

		private Timer _expireTimer;

		private List<Transform> _positions;

		private uint _color;

		private float _saveVelX;

		private float _saveVelY;

		private List<float> _velMultipliersX;

		private List<float> _velMultipliersY;

		private List<float> _partyAngles;

		private PartyWeapon _trueWeapon;

		private MultiTargetTween _gravityTween;

		private Vector2 _leftVelocity;

		private Vector2 _rightVelocity;

		private float _bounceValue;

		private MultiTargetTween _angleTween;

		private List<int> _randomStartingFrame;

		private int _randomStartingIndex;

		private int _maxStartingFrame;

		private bool _canClearObjectsHit;

		private float _clearObjectTime;

		[NonSerialized]
		public float EnemiesHit;

		[NonSerialized]
		public List<Vector2> BouncePositions;

		[NonSerialized]
		public float SelfGravity;

		protected override void Awake()
		{
		}

		public int GetRandomFrame()
		{
			return 0;
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void ClearObjectsHit()
		{
		}

		public void SetType(int type)
		{
		}

		public void PickType()
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		public override void SetTarget(Transform target)
		{
		}

		private void Bounce(Body b, bool up, bool down, bool left, bool right)
		{
		}

		private void SetupTrails()
		{
		}

		private void FadeOutAndDispose()
		{
		}

		public override void Despawn()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void ClearPositions()
		{
		}

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}

		private void OnHasHitAnObjectLogic(IDamageable target, bool triggerHit)
		{
		}
	}
}
