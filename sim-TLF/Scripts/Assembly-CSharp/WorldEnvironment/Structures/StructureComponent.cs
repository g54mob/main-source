using System;
using System.Collections.Generic;
using Items.Box;
using Services.Save.Boxes;
using Services.Save.SpawnedItems;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace WorldEnvironment.Structures
{
	public class StructureComponent : MonoBehaviour
	{
		[Header("Орієнтація")]
		[Tooltip("Яка вісь prefab'а є 'верхом'. Y — стандарт Unity.")]
		public ObjectUpAxis UpAxis;

		[Header("Межі структури")]
		[Tooltip("Точки що окреслюють межі структури (локальні координати відносно pivot'а prefab'а). Використовуються для перевірки рівності поверхні перед спавном — якщо між будь-якими двома точками є перепад висот, структура не спавниться.")]
		[SerializeField]
		private List<Transform> _localBoundaryPoints = new List<Transform>();

		[Header("Точки спавну лутбоксів")]
		[SerializeField]
		private List<Transform> _lootboxSpawnPoints = new List<Transform>();

		public List<Vector3> GetLocalBoundaryPoints()
		{
			List<Vector3> list = new List<Vector3>(_localBoundaryPoints.Count);
			foreach (Transform localBoundaryPoint in _localBoundaryPoints)
			{
				if (localBoundaryPoint != null)
				{
					list.Add(localBoundaryPoint.localPosition);
				}
			}
			return list;
		}

		public List<Vector3> GetWorldBoundaryPoints()
		{
			List<Vector3> list = new List<Vector3>(_localBoundaryPoints.Count);
			foreach (Transform localBoundaryPoint in _localBoundaryPoints)
			{
				if (localBoundaryPoint != null)
				{
					list.Add(localBoundaryPoint.position);
				}
			}
			return list;
		}

		public void GenerateLoot(System.Random prng, StructureSettings settings, DiContainer diContainer, string idPrefix)
		{
			if (_lootboxSpawnPoints.Count == 0)
			{
				Debug.LogWarning("[StructureComponent] " + base.name + ": Немає точок спавну лутбоксів!");
				return;
			}
			if (settings.LootTables == null || settings.LootTables.Count == 0)
			{
				Debug.LogWarning("[StructureComponent] " + base.name + ": LootTables порожній!");
				return;
			}
			int num = prng.Next(settings.MinLootboxCount, settings.MaxLootboxCount + 1);
			if (num <= 0)
			{
				return;
			}
			List<Transform> list = new List<Transform>(_lootboxSpawnPoints);
			for (int num2 = list.Count - 1; num2 > 0; num2--)
			{
				int num3 = prng.Next(num2 + 1);
				int index = num2;
				List<Transform> list2 = list;
				int index2 = num3;
				Transform transform = list[num3];
				Transform transform2 = list[num2];
				Transform transform3 = (list[index] = transform);
				transform3 = (list2[index2] = transform2);
			}
			int num4 = Mathf.Min(num, list.Count);
			for (int i = 0; i < num4; i++)
			{
				if (prng.NextDouble() > (double)settings.LootboxSpawnChance)
				{
					continue;
				}
				Transform transform6 = list[i];
				if (transform6 == null)
				{
					continue;
				}
				int index3 = prng.Next(settings.LootTables.Count);
				LootTableConfig lootTableConfig = settings.LootTables[index3];
				if (!(lootTableConfig == null))
				{
					if (lootTableConfig.BoxPrefab == null)
					{
						Debug.LogWarning("[StructureComponent] LootTable '" + lootTableConfig.DisplayName + "' не має BoxPrefab!");
						continue;
					}
					List<AssetReference> contentRefs = lootTableConfig.Roll(prng);
					GameObject obj = diContainer.InstantiatePrefab(lootTableConfig.BoxPrefab, transform6.position, transform6.rotation, base.transform);
					ItemBoxView component = obj.GetComponent<ItemBoxView>();
					component.Init(contentRefs);
					component.SetRescueWhenFallen(value: false);
					SpawnedBoxSaveHandler spawnedBoxSaveHandler = obj.AddComponent<SpawnedBoxSaveHandler>();
					diContainer.Inject(spawnedBoxSaveHandler);
					spawnedBoxSaveHandler.Init(component, $"{idPrefix}_{i}");
					SpawnedItemSaveHandler spawnedItemSaveHandler = obj.AddComponent<SpawnedItemSaveHandler>();
					diContainer.Inject(spawnedItemSaveHandler);
					spawnedItemSaveHandler.Init($"{idPrefix}_{i}", string.Empty);
				}
			}
		}
	}
}
