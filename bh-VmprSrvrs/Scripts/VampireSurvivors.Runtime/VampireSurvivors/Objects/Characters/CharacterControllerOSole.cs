using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerOSole : CharacterControllerHalloween
	{
		private float _amountBonus;

		private float _armorBonus;

		private float _maxHpBonus;

		private MorphVFX _morphVFX;

		private bool _isMorphed;

		private Weapon _evolvedWeapon;

		private PhaserSprite _sprCore;

		private PhaserSprite _sprFlower;

		private PhaserSprite _sprPond;

		private PhaserSprite _sprSplash;

		private PhaserSprite _sprGrass;

		public bool IsMorphed => false;

		protected override void OnUpdate()
		{
		}

		public override void LevelUp()
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		private void MorphedOnStop()
		{
		}

		private void MakeMorphVFX()
		{
		}

		protected override void OnStop()
		{
		}

		private void Morph()
		{
		}

		private void MakeSprites()
		{
		}

		private void UpdateSprites()
		{
		}
	}
}
