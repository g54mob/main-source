using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Ex_Magistone1_Projectile_Fragment : Projectile
	{
		[SerializeField]
		private List<MeshRenderer> _FragmentMeshes;

		[SerializeField]
		private GameObject _MeshContainer;

		[SerializeField]
		private SpriteRenderer _ShadowSprite;

		private const float Radius = 56f;

		private const float Gravity = 6.25f;

		private const float MinInitialSpeed = 2.5f;

		private const float MaxInitialSpeed = 3.5f;

		private const float ExtraSpeedForEvo = 1f;

		private const float BouncePosYVarianceLimit = 0.25f;

		private Ex_Magistone1_Weapon _trueWeapon;

		private MeshRenderer _fragmentMesh;

		private Vector2 _velocity;

		private float _initialSpeed;

		private int _flipSwitch;

		private float _bouncePosY;

		private float _bouncePosYVariance;

		private bool _hasBounced;

		private bool _isDespawning;

		private Vector3 _rotationEulers;

		private float _scaleMultiplier;

		private Tween _fadeTween;

		private Tween _scaleTween;

		private Tween _shadowFadeTween;

		private Tween _shadowScaleTween;

		public bool HasBounced => false;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void InitVelocity()
		{
		}

		private void UpdateVelocity()
		{
		}

		private void UpdateRotation()
		{
		}

		private void InitShadow()
		{
		}

		private void UpdateShadow()
		{
		}

		private void InitRotation()
		{
		}

		private void CheckForBounce()
		{
		}

		private void FadeOut()
		{
		}

		public void SetupFragmentMesh(int index, uint tint)
		{
		}

		public void SetFragmentScale(float scaleMultiplier)
		{
		}

		private float GetScaledAlpha()
		{
			return 0f;
		}

		public override void Despawn()
		{
		}
	}
}
