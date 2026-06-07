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
	public class LEM_Inferno1_Projectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _FireRenderer;

		[SerializeField]
		private Texture _RedTexture;

		[SerializeField]
		private Texture _BlueTexture;

		[SerializeField]
		private GenericShadowText _TextCounter;

		private readonly float2 BodySize;

		private const float TweenInDurationMillis = 500f;

		private LEM_Inferno1_Weapon _trueWeapon;

		private float _currentAngleDeg;

		private int _lastKillCount;

		private Material _instancedMaterial;

		private Tween _alphaTween;

		private MultiTargetTween _textWobbleTween;

		private Timer _expireTimer;

		private Timer _hitBoxTimer;

		private Timer _tweenInTimer;

		public float CurrentAngle => 0f;

		private bool IsCounterProj => false;

		private float RotationDegreesPerSecond => 0f;

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

		private void TweenIn()
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

		private void DoTextWobble(int killCount = 0)
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
