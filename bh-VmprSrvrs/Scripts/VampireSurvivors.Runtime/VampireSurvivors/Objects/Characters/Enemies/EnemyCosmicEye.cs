using System.Collections.Generic;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyCosmicEye : EnemyController
	{
		[SerializeField]
		protected Transform eyeModel;

		private bool _hasGeneratedSprites;

		private float _sineF;

		private PhaserSprite _wingL1;

		private PhaserSprite _wingR1;

		private PhaserSprite _wingL2;

		private PhaserSprite _wingR2;

		private PhaserSprite _wingL3;

		private PhaserSprite _wingR3;

		private PhaserSprite _wingSmL1;

		private PhaserSprite _wingSmR1;

		private PhaserSprite _wingSmL2;

		private PhaserSprite _wingSmR2;

		private PhaserSprite _wingSmL3;

		private PhaserSprite _wingSmR3;

		private MultiTargetTween _spritesDeathTween;

		private MultiTargetTween _wingsAngleTween;

		private bool _isFirstUpdate;

		private float _eyeRotationX;

		private float _eyeRotationY;

		private PhaserSprite[] AllWings;

		private PhaserSprite[] AllSmallWings;

		private PhaserSprite[] AllSprites;

		private TweenerCore<float, float, FloatOptions> SineTween;

		private MultiTargetTween _disappearTween;

		private TweenerCore<Vector3, Vector3, VectorOptions> _eyeScaleTween;

		private List<TweenerCore<Quaternion, Vector3, QuaternionOptions>> rotationTweens;

		private const string FrameNameWing = "desWing_i01.png";

		private const string FrameNameWingL = "desWingL_i01.png";

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

		protected override void OnDeathAnimationComplete()
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
