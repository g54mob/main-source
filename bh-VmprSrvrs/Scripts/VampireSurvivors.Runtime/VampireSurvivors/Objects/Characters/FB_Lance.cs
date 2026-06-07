using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class FB_Lance : CharacterController_FirstBlood
	{
		private int enemyKilledCounter;

		private float cooldownCounter;

		private float speedCounter;

		private float cooldownAdded;

		private float speedAdded;

		private float maxCooldown;

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
