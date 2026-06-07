namespace VampireSurvivors.Objects.Characters
{
	public class EME_CharacterControllerSiugnas : EME_CharacterControllerShowstopper
	{
		private int m_StatsApplied;

		private float[] m_HealthIncreases;

		private int followerNameindex;

		public override bool DrainWeaponsImmunity => false;

		private void SpawnNewEnemyFollower()
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override void Despawn()
		{
		}
	}
}
