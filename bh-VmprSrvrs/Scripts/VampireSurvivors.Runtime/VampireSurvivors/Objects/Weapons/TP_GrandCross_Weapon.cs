using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_GrandCross_Weapon : Weapon
	{
		public float defaultWidth;

		private float _crossTime;

		private float _nextInterval;

		private float _projectileStock;

		private float _projectileTime;

		private float _projectileInterval;

		private PhaserSprite _lightSprite;

		private bool _hasSprites;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private ParticleSystem _pfx;

		private Rectangle _pfxRecta;

		public bool ManualFire;

		private float Intensity()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void CheckForVFXTweenOut()
		{
		}

		private void LateUpdate()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		public override void Cleanup()
		{
		}
	}
}
