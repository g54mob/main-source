using Restory.Data.Microstories;
using Restory.Data.NPCs;
using UnityEngine;

namespace Restory.Gameplay.NPCs
{
	public class PrefabsForRandomNpcsProvidingService
	{
		private PrefabsForRandomNpcs prefabsForRandomNpcs;

		public PrefabsForRandomNpcsProvidingService(PrefabsForRandomNpcs prefabsForRandomNpcs)
		{
			this.prefabsForRandomNpcs = prefabsForRandomNpcs;
		}

		public GameObject GetNpcPrefab(NpcGenderOptions gender, NpcAgeOptions age)
		{
			return prefabsForRandomNpcs.GetNpcPrefab(gender, age);
		}
	}
}
