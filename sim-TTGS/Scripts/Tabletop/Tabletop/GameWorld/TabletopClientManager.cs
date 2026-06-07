using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class TabletopClientManager : ClientManager
	{
		public bool SpawnWargameOpponent(Transform spawnPoint, out TabletopClientBehaviour tabletopClientBehaviour)
		{
			if (SpawnClient(spawnPoint.position, spawnPoint.rotation, out var behaviour, out var _))
			{
				if (behaviour is TabletopClientBehaviour tabletopClientBehaviour2)
				{
					behaviour.Init(GetUniqueGameID());
					tabletopClientBehaviour = tabletopClientBehaviour2;
					return true;
				}
				DestroyClient(behaviour);
			}
			tabletopClientBehaviour = null;
			return false;
		}
	}
}
