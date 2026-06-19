using System;
using System.Collections.Generic;
using Pug.UnityExtensions;

[Serializable]
public class SeasonAndLoot
{
	public Season season;

	[ArrayElementTitle("lootDropID")]
	public List<SeasonalLootDrop> lootDrops;
}
