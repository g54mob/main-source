using System;
using System.Collections.Generic;

[Serializable]
public struct OnUseLootDrops
{
	public LootTableID lootTableID;

	public EffectID spawnEffects;

	public List<OnUseLootDrop> lootDrops;
}
