namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerVictor : CharacterController
	{
		private float _armorBonus;

		private float _armorDelay;

		private float _armorTime;

		public override float PArmor()
		{
			return 0f;
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override void OnGetDamaged(string hexColor = "#ff0000", float vulnerabilityDelay = 120f, bool playDamageFx = true, bool playWeaponDamageFx = false)
		{
		}

		private void AddArmor()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void LevelUp()
		{
		}
	}
}
