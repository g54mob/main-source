using System;
using System.Collections.Generic;
using UnityEngine;

namespace WorldEnvironment.Structures
{
	[Serializable]
	public class StructureSettings
	{
		[Header("Prefab")]
		public StructureComponent Prefab;

		[Header("Spawn Chances")]
		[Range(0f, 1f)]
		public float SpawnChance = 0.5f;

		[Tooltip("Максимальна кількість цього типу на острові (0 = без обмежень)")]
		public int MaxCountPerIsland = 1;

		[Header("Conditions")]
		[Tooltip("Якщо увімкнено — ця структура може заспавнитись тільки якщо на острові вже є хоча б одна інша заспавнена структура. Корисно для 'додаткових' об'єктів що мають сенс лише поряд з чимось іншим — наприклад сторожова вежа біля табору, або знак біля руїни.")]
		public bool RequiresExistingStructure;

		[Header("Placement")]
		public float ClearanceRadius = 20f;

		public bool PreferSlopes;

		public float MaxSteepness = 45f;

		public float MinSteepnessForSlopes = 10f;

		[Header("Lootboxes")]
		public int MinLootboxCount;

		public int MaxLootboxCount = 2;

		public List<LootTableConfig> LootTables = new List<LootTableConfig>();

		[Range(0f, 1f)]
		public float LootboxSpawnChance = 0.8f;
	}
}
