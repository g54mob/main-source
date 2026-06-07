using System.Collections.Generic;

public class IngameTowerData
{
	public TowerSettingData data;

	public List<ModifierData> list_PriceModifiers;

	public void AddPriceModifier(int id, float modifier, eModifierType modifierType)
	{
	}

	public void RemovePriceModifier(int id)
	{
	}

	public int GetCost()
	{
		return 0;
	}
}
