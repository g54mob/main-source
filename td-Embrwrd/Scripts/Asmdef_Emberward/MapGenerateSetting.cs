using System;

[Serializable]
public class MapGenerateSetting
{
	public eWorldType WorldType;

	public int Step;

	public int MinNodeInStep;

	public int MaxNodeInStep;

	public int Weight_Level;

	public int Weight_Level_Corrupted;

	public int Weight_Shop;

	public int Weight_Workshop;

	public int Weight_SpecialEvent;

	public int Weight_Altar;

	public int Weight_Quest;

	public int Weight_Campsite;

	public int Seed;

	public MapGenerateSetting(eWorldType worldType, int step, int minNodeInStep, int maxNodeInStep, int weight_Level, int weight_Shop, int weight_Workshop, int weight_SpecialEvent, int weight_Altar, int weight_Campsite)
	{
	}

	public MapGenerateSetting(eWorldType worldType, int seed = -1)
	{
	}
}
