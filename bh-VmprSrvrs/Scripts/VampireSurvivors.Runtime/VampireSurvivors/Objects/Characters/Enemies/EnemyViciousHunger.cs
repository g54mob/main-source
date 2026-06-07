using System.Collections.Generic;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyViciousHunger : EnemyController
	{
		[SerializeField]
		protected MeshRenderer eyeMesh;

		[SerializeField]
		protected Transform eyeModel;

		private float _sineF;

		private MultiTargetTween _spritesDeathTween;

		private MultiTargetTween _wingsAngleTween;

		private bool _isFirstUpdate;

		private float _eyeRotationX;

		private float _eyeRotationY;

		private TweenerCore<float, float, FloatOptions> SineTween;

		private MultiTargetTween _disappearTween;

		private TweenerCore<Vector3, Vector3, VectorOptions> _eyeScaleTween;

		private List<TweenerCore<Quaternion, Vector3, QuaternionOptions>> rotationTweens;

		private Circle _explosionCircle;

		private ParticleEmitterManager _pfxEmitter2;

		private ParticleEmitterManager _pfxEmitter;

		protected override void Awake()
		{
		}

		protected void RandomEyeAngle()
		{
		}

		protected override void OnRecycleEnemy()
		{
		}

		private void GenerateSpritesAndAnimations()
		{
		}

		private void UpdateSprites()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void Die()
		{
		}

		private void LateUpdate()
		{
		}

		public override void Disappear()
		{
		}

		public override void Despawn()
		{
		}
	}
}
