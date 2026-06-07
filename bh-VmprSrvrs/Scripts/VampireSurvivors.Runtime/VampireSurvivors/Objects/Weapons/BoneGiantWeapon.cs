using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class BoneGiantWeapon : BoneWeapon
	{
		private float2 _headOffset;

		private float2 _inv_headOffset;

		private float2 _haloOffset;

		private float2 _inv_haloOffset;

		private float2 _inv_frontOffset;

		private float2 _inv_backOffset;

		private float2 _frontOffset;

		private float2 _backOffset;

		private bool _hasSkeleton;

		private bool _hasCharacterSkeleton;

		private bool _areArmsAttached;

		private int _firedTimes;

		private int _secondaryFireCounter;

		private BulletPool _giantArmPool;

		private BoneGiantProjectile _frontArm;

		private BoneGiantProjectile _backArm;

		private PhaserSprite _head;

		private PhaserSprite _torso;

		private MultiTargetTween _armsSpinTween;

		private MultiTargetTween _armsSpinTween2;

		private bool _isAttacking;

		private PhaserSprite _halo;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		public override void InternalUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		private void InitSkeleton()
		{
		}

		private void UpdateSkeleton()
		{
		}

		private void AttachArms()
		{
		}

		private void DetachArms()
		{
		}

		private void SpinArms()
		{
		}

		private bool OnGiantArmOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void SetVisible(bool visible)
		{
		}

		public override void Cleanup()
		{
		}
	}
}
