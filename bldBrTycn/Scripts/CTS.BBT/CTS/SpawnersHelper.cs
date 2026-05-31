using System.Collections;
using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public static class SpawnersHelper
	{
		public static IEnumerator CustomerSpreadOutSpawnsCoroutine(ESubSpecies subSpecies, float startDelay = 60f, float spawnCooldown = 60f, int amountPerSpawn = 1)
		{
			yield return new WaitForSeconds(startDelay);
			while (true)
			{
				if (CTSSingleton<LevelParameters>.Instance.IsOpen)
				{
					CTSSingleton<CustomerSpawner>.Instance.Spawn(amountPerSpawn, subSpecies);
				}
				yield return new WaitForSeconds(spawnCooldown);
			}
		}

		public static IEnumerator CustomerSpreadOutSpawnsCoroutine(ESubSpecies subSpecies, AutoSpawnData autoSpawnData)
		{
			return CustomerSpreadOutSpawnsCoroutine(subSpecies, autoSpawnData.FirstSpawnDelay, autoSpawnData.SpawnCooldown, autoSpawnData.AmountPerSpawn);
		}

		public static IEnumerator CustomerSpreadOutSpawnsCoroutine(CustomerParameters subSpecies, float startDelay = 60f, float spawnCooldown = 60f, int amountPerSpawn = 1)
		{
			yield return new WaitForSeconds(startDelay);
			while (true)
			{
				if (CTSSingleton<LevelParameters>.Instance.IsOpen)
				{
					CTSSingleton<CustomerSpawner>.Instance.SpawnSpecific(amountPerSpawn, subSpecies);
				}
				yield return new WaitForSeconds(spawnCooldown);
			}
		}

		public static IEnumerator CustomerSpreadOutSpawnsCoroutine(CustomerParameters subSpecies, AutoSpawnData autoSpawnData)
		{
			return CustomerSpreadOutSpawnsCoroutine(subSpecies, autoSpawnData.FirstSpawnDelay, autoSpawnData.SpawnCooldown, autoSpawnData.AmountPerSpawn);
		}

		public static IEnumerator InvestigatorSpreadOutSpawnsCoroutine(float startDelay = 60f, float spawnCooldown = 60f, int amountPerSpawn = 1)
		{
			yield return new WaitForSeconds(startDelay);
			while (true)
			{
				CTSSingleton<HostileCharacterSpawner>.Instance.SpawnInvestigators(amountPerSpawn);
				yield return new WaitForSeconds(spawnCooldown);
			}
		}

		public static IEnumerator InvestigatorSpreadOutSpawnsCoroutine(AutoSpawnData autoSpawnData)
		{
			return InvestigatorSpreadOutSpawnsCoroutine(autoSpawnData.FirstSpawnDelay, autoSpawnData.SpawnCooldown, autoSpawnData.AmountPerSpawn);
		}

		public static IEnumerator HuntersSpreadOutSpawnsCoroutine(float startDelay = 60f, float spawnCooldown = 60f, int amountPerSpawn = 1)
		{
			yield return new WaitForSeconds(startDelay);
			while (true)
			{
				CTSSingleton<HostileCharacterSpawner>.Instance.SpawnHunters(amountPerSpawn);
				yield return new WaitForSeconds(spawnCooldown);
			}
		}

		public static IEnumerator HuntersSpreadOutSpawnsCoroutine(AutoSpawnData autoSpawnData)
		{
			return HuntersSpreadOutSpawnsCoroutine(autoSpawnData.FirstSpawnDelay, autoSpawnData.SpawnCooldown, autoSpawnData.AmountPerSpawn);
		}
	}
}
