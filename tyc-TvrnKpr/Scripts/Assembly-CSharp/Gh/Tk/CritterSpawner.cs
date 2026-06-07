using System;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class CritterSpawner : Prop
	{
		[PersistenceOptIn]
		private float _nextSpawnTime;

		[PersistenceOptIn]
		private float _origTimeSpanUntilSpawn;

		[PersistenceOptIn]
		private float _currentPercentage;

		public static event EventHandler CritterSpawnerChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void UpdateInternal()
		{
		}

		private void UpdateCurrentPercentage()
		{
		}

		private void SpawnCritter()
		{
		}

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
