using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Punch1Weapon : EME_Weapon
	{
		private const float RAKSHA_REPEAT_INTERVAL = 500f;

		private bool _flipVisuals;

		private float _screenPerimeter;

		[SerializeField]
		private ParticleSystem guayimPunchingVFX;

		private PhaserSprite _guayimPlayerSpriteRenderer;

		private PhaserSprite _guayimBackgroundFader;

		private float _guayimExecutionDelayDefault;

		private float _guayimExecutionDelta;

		private float _guayimExecutionDelay;

		private bool _isGuayimRunning;

		private bool _playSoundsDuringUpdate;

		private float _detuneValue;

		public SfxType HitSound;

		private float _guayimFiringDelta;

		private float _guayimFiringDelay;

		private bool _updateGuayim;

		private MultiTargetTween _guayimFadeTween;

		protected override int EvolutionLevel => 0;

		protected override int _comboIndex1 => 0;

		protected override int _comboIndex2 => 0;

		protected override int _comboIndex3 => 0;

		protected override int ComboIndexFinal => 0;

		public override void InternalUpdate()
		{
		}

		protected override void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		public void FireSpecialProjectiles()
		{
		}

		private float Perimeter(Rect rect)
		{
			return 0f;
		}

		private Vector2 GetPoint(Rect rectangle, float ratio)
		{
			return default(Vector2);
		}

		protected override void InitGlimmer1BulletPool()
		{
		}

		protected override void InitGlimmer2BulletPool()
		{
		}

		protected override void InitGlimmer3BulletPool()
		{
		}

		protected bool OnBulletOverlapsEnemyHighDamage(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected bool OnBulletOverlapsEnemyLowDamage(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
		{
			return default(WeaponType);
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void StartGuayim()
		{
		}

		private void DisplayGuayimVFX()
		{
		}

		private void HideGuayimVFX()
		{
		}

		private void StopGuayim()
		{
		}

		private void ClearGuayimVFX()
		{
		}

		public void GuayimUpdate()
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
