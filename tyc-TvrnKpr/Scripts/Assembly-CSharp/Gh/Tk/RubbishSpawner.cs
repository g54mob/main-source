namespace Gh.Tk
{
	public class RubbishSpawner : AttachedBehaviour
	{
		private const float minSpawnTime = 30f;

		private const float maxSpawnTime = 60f;

		[PersistenceOptIn]
		private float _spawnCountdown;

		[PersistenceOptIn]
		public ValueWithModifiers SpawnRateFactor;

		[PersistenceOptIn]
		public int SpawnAmount;

		public override void Start()
		{
		}

		protected override void UpdateInternal()
		{
		}

		private void SpawnPositionalDirt()
		{
		}
	}
}
