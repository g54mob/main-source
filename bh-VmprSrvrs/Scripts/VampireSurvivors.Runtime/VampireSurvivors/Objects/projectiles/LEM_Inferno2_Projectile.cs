using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Graphics;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class LEM_Inferno2_Projectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _FireRendererBlue;

		[SerializeField]
		private SpriteRenderer _FireRendererRed;

		[SerializeField]
		private Texture _BlueTexture;

		[SerializeField]
		private Texture _RedTexture;

		[SerializeField]
		private GenericShadowText _TextCounterBlue;

		[SerializeField]
		private GenericShadowText _TextCounterRed;

		[SerializeField]
		private GenericShadowText _MultiplierText;

		private readonly float2 BodySize;

		private const float TweenInDurationMillis = 100f;

		private LEM_Inferno2_Weapon _trueWeapon;

		private float _currentAngleDeg;

		private int _lastBlueKillScore;

		private int _lastRedKillScore;

		private Material _instancedMaterialRed;

		private Material _instancedMaterialBlue;

		private MorphVFX _morphVFX;

		private Tween _alphaTween;

		private Tween _alphaTween2;

		private MultiTargetTween _textWobbleTweenBlue;

		private MultiTargetTween _textWobbleTweenRed;

		private Timer _expireTimer;

		private Timer _hitBoxTimer;

		private Timer _tweenInTimer;

		public float CurrentAngle => 0f;

		private float RotationDegreesPerSecond => 0f;

		private List<GenericShadowText> TextCounters => null;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitSprites()
		{
		}

		private void InitText()
		{
		}

		private void StartTimers()
		{
		}

		private void MakeMorphVFX()
		{
		}

		private float GetAlphaFromScale(float scale)
		{
			return 0f;
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateScale()
		{
		}

		private float GetPlayerFacingAngleDeg(bool invert = false)
		{
			return 0f;
		}

		private void UpdatePosition()
		{
		}

		private void UpdateText()
		{
		}

		private string GetFormattedKillText(int kills)
		{
			return null;
		}

		private void DoTextWobble(ref GenericShadowText textCounter, ref MultiTargetTween tween, int killCount = 0)
		{
		}

		private void CheckForNaneInf()
		{
		}

		public void SetAngle(float angleDegrees)
		{
		}

		private void FadeOut()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
