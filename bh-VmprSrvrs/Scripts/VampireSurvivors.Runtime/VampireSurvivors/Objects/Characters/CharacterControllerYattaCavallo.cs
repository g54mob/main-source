using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerYattaCavallo : CharacterControllerHalloween
	{
		private float _amountBonus;

		private float _armorBonus;

		private float _maxHpBonus;

		private float _luckBonus;

		private MorphVFX _morphVFX;

		private bool _isMorphed;

		private CherryWeapon _cherryWeapon;

		public bool IsMorphed => false;

		public override void LevelUp()
		{
		}

		protected override void OnUpdate()
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
	}
}
