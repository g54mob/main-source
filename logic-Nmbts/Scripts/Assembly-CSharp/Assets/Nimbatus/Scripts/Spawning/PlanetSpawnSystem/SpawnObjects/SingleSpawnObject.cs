using Assets.Nimbatus.Scripts.WorldObjects;

namespace Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem.SpawnObjects
{
	public class SingleSpawnObject : SpawnObject
	{
		public InteractiveWorldObject Object;

		public int MaxCount = 5;

		public bool TryAllSectors;

		public override void TryToSpawn(ESpawnSectorType sector, ESpawnRegion region)
		{
			if (Spawn(sector, region, false) || !TryAllSectors)
			{
				return;
			}
			for (int i = 1; i < 9; i++)
			{
				ESpawnSectorType sector2 = (ESpawnSectorType)i;
				if (Spawn(sector2, region, false))
				{
					break;
				}
			}
		}

		private bool Spawn(ESpawnSectorType sector, ESpawnRegion region, bool removeTerrain)
		{
			int num = 0;
			for (int i = 0; i < MaxCount * 5; i++)
			{
				if (Method.TryToSpawn(Object, sector, region) != null)
				{
					num++;
				}
				if (num >= MaxCount)
				{
					return true;
				}
			}
			return false;
		}
	}
}
