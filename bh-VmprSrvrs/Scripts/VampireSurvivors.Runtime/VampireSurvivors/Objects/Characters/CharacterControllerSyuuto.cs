using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerSyuuto : CharacterController
	{
		private bool _hasSecondAnim;

		private float _armorBonus;

		private float _areaBonus;

		private float _speedBonus;

		private float _moveSpeedBonus;

		private float _maxHpBonus;

		private SpriteRenderer _sparkSprite;

		private SpriteRenderer _ringSprite;

		private MultiTargetTween _ringTween;

		private MultiTargetTween _sparkTween;

		private SpriteRenderer _burstSprite;

		private SpriteRenderer _darkSprite;

		private MultiTargetTween _darkTween;

		private SpriteAnimation _burstAnim;

		private bool _isMorphed;

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		private void MakeMorphVFX()
		{
		}

		public override void AfterFullInitialization()
		{
		}

		public override void LevelUp()
		{
		}

		public override void OnWeaponMadeLevelOne(WeaponType type)
		{
		}

		private void Morph()
		{
		}

		private void PlaySparkle()
		{
		}
	}
}
