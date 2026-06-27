using System;
using System.Collections.Generic;
using Restory.Data.Microstories;
using UnityEngine;

namespace Restory.Data.NPCs
{
	[CreateAssetMenu(menuName = "Restory/NPC Visits and Work Orders/GeneratedNpcsPrefabsList", fileName = "Generated NPCs Prefabs")]
	public class PrefabsForRandomNpcs : ScriptableObject
	{
		[Serializable]
		private class AgeToPrefab
		{
			public NpcAgeOptions Age;

			public GameObject Prefab;

			private static NpcAgeOptions[] eligibleNpcAgeOptions = new NpcAgeOptions[5]
			{
				NpcAgeOptions.Child,
				NpcAgeOptions.Teen,
				NpcAgeOptions.Adult,
				NpcAgeOptions.MiddleAged,
				NpcAgeOptions.Elderly
			};
		}

		[Serializable]
		private class GenderToAgeToPrefab
		{
			public NpcGenderOptions Gender;

			public AgeToPrefab[] AgesToPrefabs = new AgeToPrefab[0];

			private static NpcGenderOptions[] eligibleNpcGenderOptions = new NpcGenderOptions[2]
			{
				NpcGenderOptions.Male,
				NpcGenderOptions.Female
			};
		}

		[SerializeField]
		private GenderToAgeToPrefab[] npcPrefabs = new GenderToAgeToPrefab[0];

		private Dictionary<NpcGenderOptions, Dictionary<NpcAgeOptions, GameObject>> npcPrefabsDictionary = new Dictionary<NpcGenderOptions, Dictionary<NpcAgeOptions, GameObject>>();

		public GameObject GetNpcPrefab(NpcGenderOptions gender, NpcAgeOptions age)
		{
			if (npcPrefabsDictionary.TryGetValue(gender, out var value) && value.TryGetValue(age, out var value2))
			{
				return value2;
			}
			return null;
		}
	}
}
