using System;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Discus1_Projectile : Projectile
	{
		private enum ScreenEdge
		{
			None = 0,
			Top = 1,
			Bottom = 2,
			Left = 3,
			Right = 4
		}

		private Vector3 _movement;

		private float _rotationInc;

		private float _flipSwitch;

		[NonSerialized]
		public float orbitRadius;

		[NonSerialized]
		public float orbitAngle;

		private MultiTargetTween _radiusTween;

		private MultiTargetTween _speedTween;

		private MultiTargetTween _scaleTween;

		private float _spinDuration;

		private bool _rotatingState;

		private bool _shootState;

		private bool _anticlockwiseSpin;

		private bool _hasStucktoWall;

		private Timer _explosionTimer;

		private ScreenEdge _screenEdge;

		private float2 _lastVelocity;

		protected virtual float SpeedFactor => 0f;

		protected virtual bool CanBounce => false;

		protected virtual string FrameName => null;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void InitBouncing()
		{
		}

		public void shootDiscus()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void HandleScreenEdges()
		{
		}

		private void StickToScreenEdge(ScreenEdge nextEdge, ArcadeRect playArea)
		{
		}

		private bool HitsTop(ArcadeRect playArea)
		{
			return false;
		}

		private bool HitsBottom(ArcadeRect playArea)
		{
			return false;
		}

		private bool HitsRight(ArcadeRect playArea)
		{
			return false;
		}

		private bool HitsLeft(ArcadeRect playArea)
		{
			return false;
		}

		private void StickToWall(float2 normal)
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		public override void Despawn()
		{
		}
	}
}
