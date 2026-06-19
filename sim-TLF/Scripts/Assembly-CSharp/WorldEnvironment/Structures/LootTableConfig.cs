using System;
using System.Collections.Generic;
using Items.Box;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace WorldEnvironment.Structures
{
	[CreateAssetMenu(fileName = "LootTable", menuName = "World/Loot Table Config")]
	public class LootTableConfig : ScriptableObject
	{
		[Tooltip("Назва для зручності в інспекторі")]
		public string DisplayName = "New Loot Table";

		[Header("Box Prefab")]
		[Tooltip("Префаб коробки (ItemBoxView) що буде заспавнена. Різні таблиці можуть мати різні типи коробок — скриню, барель, мішок тощо.")]
		public ItemBoxView BoxPrefab;

		[Header("Loot Entries")]
		[Tooltip("Список можливих айтемів. Кожен має незалежний шанс випасти.")]
		public List<LootEntry> Entries = new List<LootEntry>();

		public List<AssetReference> Roll(System.Random prng)
		{
			List<AssetReference> list = new List<AssetReference>();
			foreach (LootEntry entry in Entries)
			{
				if (entry.ItemRef != null && !(prng.NextDouble() > (double)entry.DropChance))
				{
					int num = prng.Next(entry.MinCount, entry.MaxCount + 1);
					for (int i = 0; i < num; i++)
					{
						list.Add(entry.ItemRef);
					}
				}
			}
			return list;
		}
	}
}
