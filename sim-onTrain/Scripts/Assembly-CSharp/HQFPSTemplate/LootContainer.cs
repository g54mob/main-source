using HQFPSTemplate.Items;
using UnityEngine;

namespace HQFPSTemplate
{
	public class LootContainer : DestructibleObject
	{
		[BHeader("Loot")]
		[SerializeField]
		[Reorderable]
		private ItemGeneratorList m_PossibleLoot;

		[SerializeField]
		[Range(0f, 10f)]
		[Tooltip("How many items will be spawned.")]
		private int m_LootSpawnAmount = 1;

		[SerializeField]
		private Vector3 m_LootSpawnOffset = Vector3.zero;

		protected override void DestroyObject(DamageInfo data)
		{
			SpawnLoot();
			base.DestroyObject(data);
		}

		private void SpawnLoot()
		{
			int last = -1;
			for (int i = 0; i < m_LootSpawnAmount; i++)
			{
				ItemGenerator itemGenerator = m_PossibleLoot.ToArray().Select(ref last, ItemSelection.Method.RandomExcludeLast);
				GameObject gameObject = null;
				if (itemGenerator.GenerateMethod == ItemGenerator.Method.Specific)
				{
					gameObject = ItemDatabase.GetItemByName(itemGenerator.Name).Pickup;
				}
				else if (itemGenerator.GenerateMethod == ItemGenerator.Method.RandomFromCategory)
				{
					gameObject = ItemDatabase.GetRandomItemFromCategory(itemGenerator.Category).Pickup;
				}
				else if (itemGenerator.GenerateMethod == ItemGenerator.Method.Random)
				{
					ItemCategory randomCategory = ItemDatabase.GetRandomCategory();
					if (randomCategory != null)
					{
						gameObject = ItemDatabase.GetRandomItemFromCategory(randomCategory.Name).Pickup;
					}
				}
				if (gameObject != null)
				{
					Object.Instantiate(gameObject, base.transform.position + base.transform.TransformVector(m_LootSpawnOffset), Quaternion.identity);
				}
			}
		}
	}
}
