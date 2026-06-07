using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class SantaJavelin2Weapon : SantaJavelinWeapon
	{
		[SerializeField]
		private List<MeshRenderer> _3DMeshes;

		[SerializeField]
		private Transform _RingTransform;

		[SerializeField]
		private MeshRenderer _RingMesh;

		[SerializeField]
		private Transform _Ring2Transform;

		[SerializeField]
		private MeshRenderer _Ring2Mesh;

		[SerializeField]
		private Transform _spearCTransform;

		[SerializeField]
		private MeshRenderer _spearCMesh;

		[SerializeField]
		private Transform _spearLTransform;

		[SerializeField]
		private MeshRenderer _spearLMesh;

		[SerializeField]
		private Transform _spearRTransform;

		[SerializeField]
		private MeshRenderer _spearRMesh;

		[SerializeField]
		private float _modelMaterialAlpha;

		private PhaserSprite _darkBackground;

		private PhaserSprite _lightBackground;

		private float _defaultSkyScale;

		private int _AccumulatedRosaries;

		private bool _isPlayingWSP;

		private float _delayBetweenWSP;

		private float _WSPDelayTotalTime;

		private static readonly int _ScrollSpeedX;

		private static readonly int _ScrollSpeedY;

		private static readonly int _AlphaMul;

		private MultiTargetTween _tween1;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tweenGems;

		private bool _generatedPools;

		private BulletPool _tvExplosionPool;

		public override bool SingleProjectile => false;

		public override float PPower()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public void StartWeirdSoulsPurifier()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void PlayWSP()
		{
		}

		private void AlternateBackgrounds()
		{
		}

		private void WSPDamage()
		{
		}

		private void PlaySFX(float vol1 = 1.8f, float vol2 = 0.5f)
		{
		}

		private void exe_FadeInBG()
		{
		}

		private void exe_RigthSpear()
		{
		}

		private void exe_LeftSpear()
		{
		}

		private void exe_CentralSpear()
		{
		}

		private void exe_Explode()
		{
		}

		private void OnWSPComplete()
		{
		}

		protected void ScreenShake(float duration = 24f, float strength = 1f)
		{
		}

		public override void Cleanup()
		{
		}

		public override void ForcedFire(bool hasTarget, Vector3 position, bool skipTriggers = false)
		{
		}

		protected override Vector3 Fire_FireProjectiles(bool hasTarget, Vector3 position, bool skipTriggers = false)
		{
			return default(Vector3);
		}

		protected override void OnStart()
		{
		}

		protected override void OnPause()
		{
		}

		protected override void OnResume()
		{
		}

		public void SecondaryFireAt(Vector2 targetPos)
		{
		}

		protected bool OnMinorBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
