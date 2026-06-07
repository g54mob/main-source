using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Ex_Magistone1_Projectile : Projectile
	{
		[SerializeField]
		private List<MeshRenderer> _GemMeshes;

		[SerializeField]
		private GameObject _MeshContainer;

		[SerializeField]
		private SpriteRenderer _ShadowSprite;

		private const float Radius = 56f;

		private const float MinRotateDuration = 2f;

		private const float MaxRotateDuration = 3f;

		private Ex_Magistone1_Weapon _trueWeapon;

		private MeshRenderer _gemMesh;

		private int _meshIndex;

		private uint _tint;

		private int _spawnCounter;

		private float _spawnOffsetY;

		private Tween _posTween;

		private Tween _angleTween;

		private Tween _shadowFadeTween;

		private Tween _shadowScaleTween;

		private Timer _expireTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetSpawnOffsetY(float spawnOffsetY)
		{
		}

		private void SetupGemMesh()
		{
		}

		public void InitRotation()
		{
		}

		private void DropGem()
		{
		}

		private void DoShadowTween(Vector2 position, float tweenDuration, Ease ease)
		{
		}

		private void SpawnFragments()
		{
		}

		private void PlaySfx()
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
