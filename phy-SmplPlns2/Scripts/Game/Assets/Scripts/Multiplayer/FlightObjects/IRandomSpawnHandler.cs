using System;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	public interface IRandomSpawnHandler
	{
		void OnSpawned(Random random, int spawnIndex, byte? networkedAreaItemId);
	}
}
