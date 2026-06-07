using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Death_Character : TP_Character
	{
		private float _cooldownBonus;

		private float _greedBonus;

		private float _mightBonus;

		private bool _isMorphed;

		private PhaserSprite _sparkSprite;

		private PhaserSprite _ringSprite;

		private PhaserSprite _burstSprite;

		private PhaserSprite _darkSprite;

		private SpriteAnimation _burstSpriteAnim;

		private MultiTargetTween _ringTween;

		private MultiTargetTween _sparkTween;

		private MultiTargetTween _darkTween;

		private PhaserSprite _deathMask;

		private PhaserSprite _deathSpine;

		private PhaserSprite _deathCape;

		private PhaserSprite _leftEye;

		private PhaserSprite _rightEye;

		public override bool DrainWeaponsImmunity => false;

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override void LevelUp()
		{
		}

		public void Morph(bool addBonusStats = true)
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void OnDeath()
		{
		}

		private void SetupSparkle()
		{
		}

		private void PlaySparkle()
		{
		}

		private void CreateMegaloDeathSprites()
		{
		}

		private void UpdateMegaloDeathParts()
		{
		}

		private void UpdateEyes()
		{
		}
	}
}
