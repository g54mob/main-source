using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Graphics;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Unused_LEM_Inferno2_Projectile : Projectile
	{
		[SerializeField]
		private GenericShadowText _TextCounter;

		[SerializeField]
		private SpriteRenderer _ColourBlockRenderer;

		[SerializeField]
		private Texture _RedTexture;

		[SerializeField]
		private Color _RedTint;

		[SerializeField]
		private Texture _BlueTexture;

		[SerializeField]
		private Color _BlueTint;

		[SerializeField]
		private SpriteRenderer _FlameRenderer;

		private Unused_LEM_Inferno2_Weapon _trueWeapon;

		private Material _instancedMaterial;

		private Material _instancedMaterial2;

		private float _projHeight;

		private float _naneinfPercentage;

		private bool _isRising;

		private Tween _scaleTween;

		private Tween _posTween;

		private MultiTargetTween _fadeTween;

		private float ProjWidth => 0f;

		private bool IsFirstProj => false;

		private bool NaneinfReached => false;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitPosition()
		{
		}

		private void InitBody()
		{
		}

		private void InitSprites()
		{
		}

		private void FadeIn()
		{
		}

		private void CheckForFullAlphaFade()
		{
		}

		private void ScaleIn()
		{
		}

		private void ScaleOut()
		{
		}

		private float GetProjHeight()
		{
			return 0f;
		}

		private void SetText()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdateBody()
		{
		}

		private void UpdateFlame()
		{
		}

		private void UpdateText()
		{
		}

		private void FadeOut()
		{
		}

		public override void Despawn()
		{
		}
	}
}
