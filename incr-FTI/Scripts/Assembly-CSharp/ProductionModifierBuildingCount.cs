public class ProductionModifierBuildingCount : ProductionModifier
{
	public readonly BuildingType buildingType;

	private readonly Town parentTown;

	public ProductionModifierBuildingCount(Town town, BuildingType t)
	{
		parentTown = town;
		buildingType = t;
		multiplier = 1f;
	}

	public override void CalcMultiplier()
	{
		multiplier = parentTown.MultiplierForBuilding(buildingType);
	}

	public override string DisplayLabel()
	{
		string text = "Building".Localized();
		if (Building.HasGlobalEffect(buildingType))
		{
			float value = base.gm.GlobalNumBuildingsOfType(buildingType);
			return "(" + text + ") " + TextDisplay.LabelForBuilding(buildingType) + " x" + TextDisplay.LocalizedNumber(value);
		}
		float value2 = parentTown.NumBuildingsOfType(buildingType);
		return "(" + text + ") " + TextDisplay.LabelForBuilding(buildingType) + " x" + TextDisplay.LocalizedNumber(value2);
	}
}
