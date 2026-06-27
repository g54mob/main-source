using System;
using Restory.Data.Microstories;
using Restory.Data.NPCs;
using UnityEngine;

namespace Restory.Gameplay.NPCs
{
	public class NpcCreationService
	{
		private PrefabsForRandomNpcsProvidingService randomNpcPrefabsProvider;

		private NpcFactory npcFactory;

		public NpcCreationService(PrefabsForRandomNpcsProvidingService randomNpcPrefabsProvider, NpcFactory npcFactory)
		{
			this.randomNpcPrefabsProvider = randomNpcPrefabsProvider;
			this.npcFactory = npcFactory;
		}

		public GameObject CreateNPC(MicroStoryInfo microStoryInfo, Transform spawnPoint, out GeneratedNpcInfo generatedNpcInfo)
		{
			GeneratedNpcSelectedOptions generatedNpcSelectedOptions = microStoryInfo.GenerateNPC();
			GameObject npcPrefab = randomNpcPrefabsProvider.GetNpcPrefab(generatedNpcSelectedOptions.Gender, generatedNpcSelectedOptions.Age);
			generatedNpcInfo = new GeneratedNpcInfo("NPC_" + Guid.NewGuid().ToString(), "", npcPrefab, generatedNpcSelectedOptions.Customization);
			GameObject gameObject = npcFactory.CreateInstanceFromPrefab(npcPrefab);
			if (gameObject.TryGetComponent<NpcCustomizationSwitcher>(out var component))
			{
				component.SetCustomization(generatedNpcSelectedOptions.Customization);
			}
			TeleportNpcToSpawnPoint(gameObject, spawnPoint);
			return gameObject;
		}

		public GameObject CreateNPC(GeneratedNpcInfo generatedNpcInfo, Transform spawnPoint)
		{
			GameObject gameObject = npcFactory.CreateInstanceFromPrefab(generatedNpcInfo.Prefab);
			if (gameObject.TryGetComponent<NpcCustomizationSwitcher>(out var component))
			{
				component.SetCustomization(generatedNpcInfo.Customization);
			}
			TeleportNpcToSpawnPoint(gameObject, spawnPoint);
			return gameObject;
		}

		public GameObject CreateNPC(StoryNpcInfo storyNpcInfo, Transform spawnPoint)
		{
			GameObject gameObject = npcFactory.CreateInstanceFromPrefab(storyNpcInfo.Prefab);
			TeleportNpcToSpawnPoint(gameObject, spawnPoint);
			return gameObject;
		}

		public void DestroyNPC(GameObject npc)
		{
			if (npc.TryGetComponent<NpcCustomizationSwitcher>(out var component))
			{
				component.Clean();
			}
			npcFactory.DisposeInstance(npc);
		}

		private static void TeleportNpcToSpawnPoint(GameObject npcInstance, Transform spawnPoint)
		{
			npcInstance.transform.position = spawnPoint.position;
			npcInstance.transform.rotation = spawnPoint.rotation;
		}
	}
}
