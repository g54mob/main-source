using UnityEngine;

namespace Gh.Tk
{
	public class PukeSpawner : GameItemVisual
	{
		private ParticleSystem _particleSystem;

		private int spawnLimit;

		private int countBetweenSpawns;

		[PersistenceOptIn]
		private int _currentCountBetweenSpawns;

		[PersistenceOptIn]
		private int _currentSpawnCount;

		private Actor _actor;

		public override void Start()
		{
		}

		public void OnParticleCollision(GameObject other)
		{
		}

		public override void SaveState(IDataStore data)
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}
	}
}
