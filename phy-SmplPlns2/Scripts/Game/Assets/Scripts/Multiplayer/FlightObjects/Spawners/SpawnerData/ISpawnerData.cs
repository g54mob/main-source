using System.Collections.Generic;

namespace Assets.Scripts.Multiplayer.FlightObjects.Spawners.SpawnerData
{
	public interface ISpawnerData
	{
		void GetSpawnerData(IDictionary<string, string> data);
	}
}
