using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class FB_Bill : CharacterController_FirstBlood
	{
		private int enemyKilledCounter;

		private float mightCounter;

		private float speedCounter;

		private float speedAdded;

		private float maxSpeed;

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override void OnQuit()
		{
		}

		public void OnEnemyKilled()
		{
		}

		private void HandleEquipment(WeaponType weaponType, float value, float delay = 0f)
		{
		}
	}
}
