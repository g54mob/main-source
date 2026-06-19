using NaughtyAttributes;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
public class DropLootAuthoring : MonoBehaviour
{
	public bool hasLootTable;

	[ShowIf("hasLootTable")]
	[AllowNesting]
	public LootTableID lootTableID;

	public bool hasCustomLoot;

	[ShowIf("hasCustomLoot")]
	[AllowNesting]
	public CustomLoot customLoot;

	public bool hasSeasonalLoot;

	[ShowIf("hasSeasonalLoot")]
	[AllowNesting]
	[ArrayElementTitle("season")]
	public SeasonAndLoots seasonalLootDrops;

	public bool hasLootDropsOnUse;

	[ShowIf("hasLootDropsOnUse")]
	[AllowNesting]
	public OnUseLootDrops onUseLootDrops;

	public bool hasLootDropsOnTakingDamage;

	[ShowIf("hasLootDropsOnTakingDamage")]
	[AllowNesting]
	public LootDropsWhenDamaged lootDropsWhenDamaged;

	public int CalculateDamageToDealToDropLoot(int maxHealth)
	{
		return math.max(1, (int)((float)maxHealth * lootDropsWhenDamaged.healthPercentageDamageToDeal));
	}

	public int CalculateMinHealthToDropLoot(int maxHealth)
	{
		return (int)((float)maxHealth * lootDropsWhenDamaged.minHealthPercentageToDropLoot);
	}
}
