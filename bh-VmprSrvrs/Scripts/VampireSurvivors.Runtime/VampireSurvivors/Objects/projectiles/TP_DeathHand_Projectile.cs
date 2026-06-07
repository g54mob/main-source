using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_DeathHand_Projectile : Projectile
	{
		private bool _isLeftHand;

		private List<PhaserSprite> _armSprites;

		private PhaserSprite _crack;

		private ParticleSystem _rockParticles;

		[NonSerialized]
		public bool _isMoving;

		private float2 _startPosition;

		private float2 _targetPosition;

		private float _moveTween;

		private MultiTargetTween _screenShakeTween;

		private MultiTargetTween _crackTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void DoStep(float2 targetPos)
		{
		}

		private void EndStep()
		{
		}

		protected override void OnUpdate()
		{
		}

		public float2 CalculateTargetPos()
		{
			return default(float2);
		}

		private void UpdateJoints(float xOffset, List<PhaserSprite> armSprites, float extraScale)
		{
		}

		private float FindNextJointT(float2 start, float2 end, float2 lastJointPos, float lastJointT, float desiredDistance, float iterationStep = -0.01f)
		{
			return 0f;
		}

		private float2 ArmSample(float2 start, float2 end, float t)
		{
			return default(float2);
		}

		public override void Despawn()
		{
		}

		public void ScreenShake(int repeats = 6)
		{
		}
	}
}
